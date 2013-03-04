using ACBrFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ACBrDefExporter
{
	internal class StubGenerator
	{
		#region Fields

		private string className;
		private string interopClassName;
		private string interopPrefix;

		#endregion Fields

		#region Properties

		public Type ComponentType { get; private set; }

		public Type InteropType { get; private set; }

		public string Path { get; set; }

		#endregion Properties

		#region Constructor

		public StubGenerator(Type componentType, string path) : this(componentType, null, null, path)
		{
		}

		public StubGenerator(Type componentType, Type interopType, string interopPrefix, string path)
		{
			this.ComponentType = componentType;
			this.Path = path;

			if (componentType.IsSubclassOf(typeof(ACBrInteropBase)))
			{
				if (interopType == null || interopPrefix == null) throw new ArgumentNullException();
				this.InteropType = interopType;
				this.interopPrefix = interopPrefix;
			}

			Initialize();
		}

		private void Initialize()
		{
			if (ComponentType.IsSubclassOf(typeof(EventArgs)))
			{
				className = ComponentType.Name.Replace("EventArgs", "EventObject");
			}
			else
			{
				className = ComponentType.Name;
			}

			if (InteropType != null)
			{
				interopClassName = InteropType.Name;
			}
		}

		#endregion Constructor

		#region Methods

		public void Generate()
		{
			string filePath = System.IO.Path.Combine(Path, string.Format("{0}.java", className));

			using (StreamWriter writer = new StreamWriter(filePath))
			{
				WriteClassDeclaration(writer);
				WriteFields(writer);
				WriteConstructor(writer);

				WriteEvents(writer);

				WriteProperties(writer);
				WriteMethods(writer);

				WriteClassFinalization(writer);

				writer.Flush();
			}
		}

		private void WriteEvents(StreamWriter writer)
		{
			if (!ComponentType.IsSubclassOf(typeof(ACBrInteropBase))) return;

			writer.WriteLine();
			writer.WriteLine("//<editor-fold defaultstate=\"collapsed\" desc=\"Events\">");

			foreach (var eventInfo in ComponentType.GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
			{
				WriteEvent(writer, eventInfo);
			}

			writer.WriteLine();
			writer.WriteLine();
			writer.WriteLine("//</editor-fold>");
		}

		private void WriteEvent(StreamWriter writer, EventInfo eventInfo)
		{
			string eventName = JavaHelper.GetCammelCase(eventInfo.Name);
			writer.WriteLine("//<editor-fold defaultstate=\"collapsed\" desc=\"{0}\">", eventName);

			Type eventArgs;

			if (eventInfo.EventHandlerType == typeof(EventHandler))
			{
				eventArgs = typeof(EventArgs);
			}
			else
			{
				eventArgs = eventInfo.EventHandlerType.GetGenericArguments()[0];
			}

			string eventArgsName = eventArgs.Name.Replace("EventArgs", "EventObject");
			string interopCallbackName = eventArgs.Name.Replace("EventArgs", "Callback");
			Type interopDelegateType = InteropType.GetNestedType(interopCallbackName);
			MethodInfo interopDelegate = interopDelegateType.GetMethod("Invoke");


			writer.WriteLine("public void add{0}(ACBrEventListener<{1}> listener)", eventInfo.Name, eventArgsName);
			writer.WriteLine("{");
			writer.WriteLine("	if (!hasListeners(\"{0}\"))", eventName);
			writer.WriteLine("	{");
			writer.WriteLine("		{0}.INSTANCE.{1}_Set{2}(getHandle(), new {0}.{3}()", interopClassName, interopPrefix, eventInfo.Name, interopCallbackName);
			writer.WriteLine("		{");
			writer.WriteLine("			@Override");
			writer.WriteLine("			public void invoke({0})", JavaHelper.GetMethodDeclarationParamList(interopDelegate));
			writer.WriteLine("			{");
			writer.WriteLine("				{0}({1});", eventName, JavaHelper.GetInteropMethodParamInvocationList(interopDelegate));
			writer.WriteLine("			}");
			writer.WriteLine("		});");
			writer.WriteLine("	}");
			writer.WriteLine("");
			writer.WriteLine("	addListener(\"{0}\", listener);", eventName);
			writer.WriteLine("}");
			writer.WriteLine("");
			writer.WriteLine("");


			writer.WriteLine("public void remove{0}(ACBrEventListener<{1}> listener)", eventInfo.Name, eventArgsName);
			writer.WriteLine("{");
			writer.WriteLine("	removeListener(\"{0}\", listener);", eventName);
			writer.WriteLine("");
			writer.WriteLine("	if (!hasListeners(\"{0}\"))", eventName);
			writer.WriteLine("	{");
			writer.WriteLine("		{0}.INSTANCE.{1}_Set{2}(getHandle(), null);", interopClassName, interopPrefix, eventInfo.Name);
			writer.WriteLine("	}");
			writer.WriteLine("}");

			writer.WriteLine("");
			writer.WriteLine("");

			writer.WriteLine("private void {0}({1})", eventName, JavaHelper.GetMethodDeclarationParamList(interopDelegate));
			writer.WriteLine("{");
			writer.WriteLine("	{0} e = new {0}(this{1});", eventArgsName, JavaHelper.GetMethodParamInvocationList(interopDelegate));
			writer.WriteLine("	notifyListeners(\"{0}\", e);", eventName);
			writer.WriteLine("}");

			writer.WriteLine();
			writer.WriteLine();
			writer.WriteLine("//</editor-fold>");
		}

		#region ClassDeclaration

		private void WriteClassDeclaration(StreamWriter writer)
		{
			writer.WriteLine();
			writer.Write("public final class {0}", className);

			if (ComponentType.IsSubclassOf(typeof(ACBrClassInterop)))
			{
				writer.WriteLine(" extends ACBrClass");
			}
			else if (ComponentType.IsSubclassOf(typeof(ACBrComposedComponent)))
			{
				writer.WriteLine(" extends ACBrComposedClass");
			}
			else if (ComponentType.IsSubclassOf(typeof(EventArgs)))
			{
				writer.WriteLine(" extends EventObject");
			}
			else
			{
				writer.WriteLine("");
			}

			writer.WriteLine("{");
			writer.WriteLine("");
			writer.WriteLine("");
		}

		private void WriteClassFinalization(StreamWriter writer)
		{
			writer.WriteLine("");
			writer.WriteLine("");
			writer.WriteLine("}");
		}

		#endregion ClassDeclaration

		#region WriteFields

		private void WriteFields(StreamWriter writer)
		{
			if (ComponentType.IsSubclassOf(typeof(ACBrInteropBase))) return;

			writer.WriteLine();
			writer.WriteLine("//<editor-fold defaultstate=\"collapsed\" desc=\"Fields\">");

			foreach (var property in ComponentType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
			{
				WriteField(writer, property);
			}

			writer.WriteLine();
			writer.WriteLine();
			writer.WriteLine("//</editor-fold>");
		}

		private void WriteField(StreamWriter writer, PropertyInfo property)
		{
			string typeName = JavaHelper.GetTypeName(property.PropertyType);
			string name = JavaHelper.GetCammelCase(property.Name);

			writer.WriteLine("	private {0} {1};", typeName, name);
		}

		#endregion WriteFields

		#region WriteConstructor

		private void WriteConstructor(StreamWriter writer)
		{

			writer.WriteLine();
			writer.WriteLine("//<editor-fold defaultstate=\"collapsed\" desc=\"Constructor\">");

			if (ComponentType.IsSubclassOf(typeof(EventArgs)))
			{
				List<string> fields = new List<string>();
				writer.Write("public {0}(Object source", className);

				foreach (var property in ComponentType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
				{
					string typeName = JavaHelper.GetTypeName(property.PropertyType);
					string fieldName = JavaHelper.GetCammelCase(property.Name);
					writer.Write(", {0} {1}", typeName, fieldName);
					fields.Add(fieldName);
				}

				writer.WriteLine(")");
				writer.WriteLine("{");
				writer.WriteLine("	super(source);");
				foreach (var fieldName in fields)
				{
					writer.WriteLine("	this.{0} = {0};", fieldName);
				}
				writer.WriteLine("}");
			}
			else if (ComponentType.IsSubclassOf(typeof(ACBrComposedComponent)))
			{

			}

			writer.WriteLine();
			writer.WriteLine();
			writer.WriteLine("//</editor-fold>");


		}

		#endregion WriteConstructor

		#region WriteMethods

		private void WriteMethods(StreamWriter writer)
		{
			writer.WriteLine();
			writer.WriteLine("//<editor-fold defaultstate=\"collapsed\" desc=\"Interop Methods\">");

			foreach (var method in ComponentType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
			{
				///Construtores, acessores de propriedades e de eventos são ignorados
				if (method.IsConstructor || method.Name.StartsWith("get_") || method.Name.StartsWith("set_") || method.Name.StartsWith("add_") || method.Name.StartsWith("remove_")) continue;

				///Métodos com ComVisible=False são overloads e devem ser implementados diretamente em Java, não devem ser exportados.
				ComVisibleAttribute comVisibleAttribute = (ComVisibleAttribute)Attribute.GetCustomAttribute(method, typeof(ComVisibleAttribute));
				if (comVisibleAttribute != null && comVisibleAttribute.Value == false) continue;

				WriteMethod(writer, method);
			}

			writer.WriteLine();
			writer.WriteLine();
			writer.WriteLine("//</editor-fold>");
		}

		private void WriteMethod(StreamWriter writer, MethodInfo method)
		{
			writer.WriteLine();
			writer.WriteLine();

			string returnName = JavaHelper.GetTypeName(method.ReturnType);
			string methodName = JavaHelper.GetCammelCase(method.Name);

			writer.WriteLine("public {0} {1}({2}) throws ACBrException", returnName, methodName, JavaHelper.GetMethodDeclarationParamList(method));
			writer.WriteLine("{");
			WriteMethodBody(writer, method);
			writer.WriteLine("}");
		}

		private void WriteMethodBody(StreamWriter writer, MethodInfo method)
		{
			string returnVarDeclaration;
			string returnRefParams;
			string returnStatement;

			Type returnElementType = method.ReturnType.IsArray ? method.ReturnType.GetElementType() : method.ReturnType;
			string returnTypeName = JavaHelper.GetTypeName(returnElementType);

			if (returnElementType == typeof(string))
			{
				returnVarDeclaration = "ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);";
				returnRefParams = ", returnBuffer, STR_BUFFER_LEN";
				returnStatement = "fromUTF8(returnBuffer, ret)";
			}
			else if (returnElementType == typeof(DateTime))
			{
				returnVarDeclaration = "DoubleByReference returnValue = new DoubleByReference();";
				returnRefParams = ", returnValue";
				returnStatement = "OleDate.fromOADate(returnValue.getValue())";
			}
			else if (returnElementType == typeof(Double) || method.ReturnType == typeof(decimal))
			{
				returnVarDeclaration = "DoubleByReference returnValue = new DoubleByReference();";
				returnRefParams = ", returnValue";
				returnStatement = "returnValue.getValue()";
			}
			else if (returnElementType == typeof(Boolean))
			{
				returnVarDeclaration = "";
				returnRefParams = "";
				returnStatement = "ret != 0";
			}
			else if (returnElementType == typeof(int) || method.ReturnType.IsSubclassOf(typeof(Enum)))
			{
				returnVarDeclaration = "";
				returnRefParams = "";
				returnStatement = "ret";
			}
			else if (returnElementType == typeof(void))
			{
				returnVarDeclaration = "";
				returnRefParams = "";
				returnStatement = "";
			}
			else
			{
				writer.WriteLine("	//NotImplemented");
				return;
			}

			string methodName;
			
			if (method.Name.StartsWith("get_"))
			{
				methodName = string.Format("Get{0}", method.Name.Substring(4));
			}
			else if (method.Name.StartsWith("set_"))
			{
				methodName = string.Format("Set{0}", method.Name.Substring(4));
			}
			else
			{
				methodName = method.Name;
			}


			writer.WriteLine("");

			if (method.ReturnType.IsArray)
			{
				writer.WriteLine("	int count = {0}.INSTANCE.{1}_{2}Count(getHandle());", interopClassName, interopPrefix, methodName);
				writer.WriteLine("	checkResult(count);");
				writer.WriteLine("");
				writer.WriteLine("	{0}[] array = new {0}[count];", returnTypeName);
				writer.WriteLine("	for(int i = 0; i < array.length; i++)");
				writer.WriteLine("	{");

				returnRefParams += ", i";
			}

			writer.WriteLine("	{0}", returnVarDeclaration);
			writer.WriteLine("	int ret = {0}.INSTANCE.{1}_{2}(getHandle(){3}{4});", interopClassName, interopPrefix, methodName, JavaHelper.GetInteropMethodParamInvocationList(method), returnRefParams);
			writer.WriteLine("	checkResult(ret);");
			writer.WriteLine("");

			if (method.ReturnType.IsArray)
			{
				writer.WriteLine("	array[i] = {0};", returnStatement);
				writer.WriteLine("	}");
				writer.WriteLine("");
				writer.WriteLine("	return array;");
			}
			else if (!string.IsNullOrEmpty(returnStatement))
			{
				writer.WriteLine("	return {0};", returnStatement);
			}

		}

		#endregion WriteMethods

		#region WriteProperties

		private void WriteProperties(StreamWriter writer)
		{
			writer.WriteLine();
			writer.WriteLine("//<editor-fold defaultstate=\"collapsed\" desc=\"Properties\">");

			foreach (var property in ComponentType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
			{
				if (InteropType == null)
				{
					WriteProperty(writer, property);
				}
				else
				{
					WriteInteropProperty(writer, property);
				}
			}

			writer.WriteLine();
			writer.WriteLine();
			writer.WriteLine("//</editor-fold>");
		}

		private void WriteProperty(StreamWriter writer, PropertyInfo property)
		{
			writer.WriteLine();
			writer.WriteLine();

			string typeName = JavaHelper.GetTypeName(property.PropertyType);

			if (property.CanRead && property.GetGetMethod().IsPublic)
			{
				writer.WriteLine("public {0} get{1}()", typeName, property.Name);
				writer.WriteLine("{");
				writer.WriteLine("	return this.{0};", JavaHelper.GetCammelCase(property.Name));
				writer.WriteLine("}");
			}

			writer.WriteLine();
			writer.WriteLine();

			if (property.CanWrite && property.GetSetMethod() != null && property.GetSetMethod().IsPublic)
			{
				writer.WriteLine("public void set{0}({1} value)", property.Name, typeName);
				writer.WriteLine("{");
				writer.WriteLine("	this.{0} = value;", JavaHelper.GetCammelCase(property.Name));
				writer.WriteLine("}");
			}
		}

		private void WriteInteropProperty(StreamWriter writer, PropertyInfo property)
		{
			writer.WriteLine();
			writer.WriteLine();

			string typeName = JavaHelper.GetTypeName(property.PropertyType);

			if (property.CanRead && property.GetGetMethod().IsPublic)
			{
				writer.WriteLine("public {0} get{1}() throws ACBrException", typeName, property.Name);
				writer.WriteLine("{");
				WriteMethodBody(writer, property.GetGetMethod());
				writer.WriteLine("}");
			}

			writer.WriteLine();
			writer.WriteLine();

			if (property.CanWrite && property.GetSetMethod() != null && property.GetSetMethod().IsPublic)
			{
				writer.WriteLine("public void set{0}({1} value) throws ACBrException", property.Name, typeName);
				writer.WriteLine("{");
				WriteMethodBody(writer, property.GetSetMethod());
				writer.WriteLine("}");
			}
		}

		#endregion WriteProperties

		#endregion Methods
	}
}