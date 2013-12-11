using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrDefExporter
{
	internal class JavaDefExporter : DefExporter
	{
		#region Fields

		private string className;

		#endregion Fields
		
		#region Properties

		public override Language Language
		{
			get
			{
				return Language.Java;
			}
		}

		protected Dictionary<Type, string> ByRefTypeNames { get; private set; }

		#endregion Properties

		#region Constructor

		public JavaDefExporter(string path)
			: base(path)
		{
		}

		#endregion Constructor

		#region Methods

		protected override void InitializeTypeNames()
		{
			TypeNames[typeof(void)] = "void";
			TypeNames[typeof(IntPtr)] = "int";
			TypeNames[typeof(Int16)] = "short";
			TypeNames[typeof(Int32)] = "int";
			TypeNames[typeof(Int64)] = "long";
			TypeNames[typeof(bool)] = "boolean";
			TypeNames[typeof(Double)] = "double";
			TypeNames[typeof(String)] = "String";
			TypeNames[typeof(Char)] = "char";
			TypeNames[typeof(StringBuilder)] = "ByteBuffer";

			ByRefTypeNames = new Dictionary<Type, string>();
			ByRefTypeNames[typeof(IntPtr)] = "IntByReference";
			ByRefTypeNames[typeof(Int16)] = "ShortByReference";
			ByRefTypeNames[typeof(Int32)] = "IntByReference";
			ByRefTypeNames[typeof(Int64)] = "LongByReference";
			ByRefTypeNames[typeof(bool)] = "IntByReference";
			ByRefTypeNames[typeof(Double)] = "DoubleByReference";
		}

		protected override void BeginHeader(StreamWriter writer, Type interopType)
		{
			writer.WriteLine("/**");
			writer.WriteLine(" * ACBrFramework DefExporter");
			writer.WriteLine(" * Este arquivo foi gerado automaticamente - não altere");
			writer.WriteLine(" * This file was generated automatically - don't change it.");
			writer.WriteLine(" **/");
			writer.WriteLine();
		}

		protected override void BeginDefines(StreamWriter writer, Type interopType)
		{
			this.className = string.Format("{0}Interop", GetComponentName(interopType));

			writer.WriteLine("package jACBrFramework.interop;");

			writer.WriteLine("import jACBrFramework.InteropLib;");
			writer.WriteLine("import com.sun.jna.*;");
			writer.WriteLine("import com.sun.jna.ptr.*;");
			writer.WriteLine("import java.nio.ByteBuffer;");
			writer.WriteLine("import java.util.Arrays;");
			writer.WriteLine("import java.util.List;");
			writer.WriteLine();

			writer.WriteLine("public interface {0} extends InteropLib {{", className);
			writer.WriteLine("");
			writer.WriteLine("\tpublic static final {0} INSTANCE = ({0})Native.loadLibrary(InteropLib.JNA_LIBRARY_NAME, {0}.class);", className);
			writer.WriteLine();
		}

		protected override void ExportTypes(StreamWriter writer, Type interopType)
		{
            writer.WriteLine("\t// Tipos de dados");

			foreach (var type in GetTypes(interopType))
			{
				if (type.IsSubclassOf(typeof(Delegate)))
				{
					ExportDelegate(writer, type);
				}
				else
				{
					ExportStruct(writer, type);
				}
			}

			writer.WriteLine();
		}

		protected override void ExportMethods(StreamWriter writer, Type InteropType)
		{
            writer.WriteLine("\t// Funções");

			foreach (var method in GetMethods(InteropType))
			{
				ExportMethod(writer, method);
			}
		}

		protected override void EndDefines(StreamWriter writer, Type InteropType)
		{
			writer.WriteLine("}");
		}

		private void ExportMethod(StreamWriter writer, MethodInfo methodInfo)
		{
			StringBuilder parameters = new StringBuilder();
			foreach (var param in methodInfo.GetParameters())
			{
				if (parameters.Length > 0) parameters.Append(", ");

				string paramDeclaration = GetMethodParamDeclaration(param);
				parameters.Append(paramDeclaration);
			}

            const string METHOD_DECLARATION = "\tint {0}({1});";
			string methodDeclaration = string.Format(METHOD_DECLARATION, methodInfo.Name, parameters);

			writer.WriteLine(methodDeclaration);
		}

		private string GetMethodParamDeclaration(ParameterInfo param)
		{
			Type type = param.ParameterType.IsArray ? param.ParameterType.GetElementType() : param.ParameterType;
			bool isByRef = type.IsByRef || param.IsRetval || param.IsOut;

			if (type.IsByRef) type = type.GetElementType();
			if (type.IsSubclassOf(typeof(Enum))) type = typeof(int);

			StringBuilder declaration = new StringBuilder();

			string typeName = null;

			if (isByRef)
			{
				ByRefTypeNames.TryGetValue(type, out typeName);
			}
			else
			{
				TypeNames.TryGetValue(type, out typeName);
			}

			if (typeName == null) typeName = string.Format("{0}.{1}", className, type.Name);

			declaration.AppendFormat("{0} {1}", typeName, param.Name);

			if (param.ParameterType.IsArray)
			{
				declaration.Append("[]");
			}

			return declaration.ToString();
		}

		private void ExportStruct(StreamWriter writer, Type type)
		{
            writer.WriteLine("\tpublic static class {0} extends Structure {{", type.Name);

			StringBuilder fieldNames = new StringBuilder();

			BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
			FieldInfo[] fields = type.GetFields(bindingFlags);

			foreach (FieldInfo field in fields)
			{
				StringBuilder declaration = new StringBuilder();

				Type fieldType;
				string typeName;

				MarshalAsAttribute marshalAs = (MarshalAsAttribute)Attribute.GetCustomAttribute(field, typeof(MarshalAsAttribute), false);
				if (marshalAs != null)
				{
					fieldType = GetUnmanagedType(marshalAs.Value);
				}
				else
				{
					fieldType = field.FieldType;
				}

				if (!TypeNames.TryGetValue(fieldType, out typeName))
				{
					typeName = fieldType.Name;
				}

				if (marshalAs != null && marshalAs.SizeConst > 0)
				{
                    writer.WriteLine("\t\tpublic {0}[] {1} = new {0}[{2}];", (typeName.Equals("char") ? "byte" : typeName), field.Name, marshalAs.SizeConst);
				}
				else
				{
                    writer.WriteLine("\t\tpublic {0} {1};", typeName, field.Name);
				}

				if (fieldNames.Length > 0) fieldNames.Append(" , ");
				fieldNames.AppendFormat("\"{0}\"", field.Name);

			}

			writer.WriteLine();

            writer.WriteLine("\t\t@Override");
            writer.WriteLine("\t\tprotected List<String> getFieldOrder() {");
            writer.WriteLine("\t\t\treturn Arrays.asList({0});", fieldNames);
            writer.WriteLine("\t\t}");
			writer.WriteLine();

            writer.WriteLine("\t\tpublic static class ByReference extends {0} implements Structure.ByReference {{ }}", type.Name);
            writer.WriteLine("\t\tpublic static class ByValue extends {0} implements Structure.ByValue {{ }}", type.Name);

            writer.WriteLine("\t}");
            writer.WriteLine();
		}

		private void ExportDelegate(StreamWriter writer, Type type)
		{
			MethodInfo method = type.GetMethod("Invoke");

			string returnValue;

			if (!TypeNames.TryGetValue(method.ReturnType, out returnValue))
			{
				returnValue = method.ReturnType.Name;
			}

			string functionName = type.Name;

            writer.WriteLine("\tpublic interface {0} extends com.sun.jna.Callback {{", functionName);
            writer.Write("\t\t{0} invoke(", returnValue);

			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length > 0)
			{
				for (int i = 0; i < parameters.Length; i++)
				{
					ParameterInfo param = parameters[i];

					Type fieldType;
					string typeName;
					string arrayDeclaration;

					MarshalAsAttribute marshalAs = (MarshalAsAttribute)Attribute.GetCustomAttribute(param, typeof(MarshalAsAttribute), false);
					if (marshalAs != null)
					{
						fieldType = GetUnmanagedType(marshalAs.Value);
					}
					else if (param.ParameterType.IsByRef)
					{
						fieldType = param.ParameterType.GetElementType();
					}
					else
					{
						fieldType = param.ParameterType;
					}

					if (fieldType.IsSubclassOf(typeof(Enum))) fieldType = typeof(int);

					bool isByRef = param.IsOut || param.IsRetval || param.ParameterType.IsByRef;

					if (isByRef)
					{
						ByRefTypeNames.TryGetValue(fieldType, out typeName);
					}
					else
					{
						TypeNames.TryGetValue(fieldType, out typeName);
					}

					if (typeName == null) typeName = string.Format("{0}.{1}", className, fieldType.Name);


					if (marshalAs != null && marshalAs.SizeConst > 0)
					{
						arrayDeclaration = string.Format("[{0}]", marshalAs.SizeConst);
					}
					else
					{
						arrayDeclaration = null;
					}


					if (i > 0) writer.Write(",");
					writer.Write("{0} {1}{2}", typeName, param.Name, arrayDeclaration);
				}
			}

			writer.WriteLine(");");
            writer.WriteLine("\t}");
		}

		#endregion Methods
	}
}