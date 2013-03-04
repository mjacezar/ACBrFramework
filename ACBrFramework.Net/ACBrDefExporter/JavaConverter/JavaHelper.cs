using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ACBrDefExporter
{
	internal static class JavaHelper
	{
		private static Dictionary<Type, string> typeNames;

		static JavaHelper()
		{
			typeNames = new Dictionary<Type, string>();
			typeNames[typeof(void)] = "void";
			typeNames[typeof(IntPtr)] = "int";
			typeNames[typeof(Int16)] = "short";
			typeNames[typeof(Int32)] = "int";
			typeNames[typeof(Int64)] = "long";
			typeNames[typeof(bool)] = "boolean";
			typeNames[typeof(Double)] = "double";
			typeNames[typeof(Decimal)] = "double";
			typeNames[typeof(String)] = "String";
			typeNames[typeof(Char)] = "char";
			typeNames[typeof(DateTime)] = "Date";

		}

		public static string GetTypeName(Type type, string outterClassName = null, bool isByRef = false)
		{
			if (type.IsSubclassOf(typeof(Enum))) type = typeof(int);
			string typeName;
			if (!typeNames.TryGetValue(type, out typeName))
			{
				if (string.IsNullOrEmpty(outterClassName))
				{
					typeName = type.Name;
				}
				else
				{
					typeName = string.Format("{0}.{1}", outterClassName, type.Name);
				}
			}

			if (isByRef)
			{
				//TODO: Verificar ByRef no Java (via Generic?)
			}

			return typeName;
		}

		public static string GetMethodDeclarationParamList(MethodInfo method, string outterClassName = null)
		{
			StringBuilder declaration = new StringBuilder();
			foreach (var param in method.GetParameters())
			{
				if (declaration.Length > 0) declaration.Append(", ");
				declaration.Append(GetMethodParamDeclaration(param, outterClassName));
			}

			return declaration.ToString();
		}

		public static string GetMethodParamDeclaration(ParameterInfo param, string outterClassName = null)
		{
			Type type = param.ParameterType.IsArray ? param.ParameterType.GetElementType() : param.ParameterType;
			bool isByRef = type.IsByRef || param.IsRetval || param.IsOut;

			if (type.IsByRef) type = type.GetElementType();
			if (type.IsSubclassOf(typeof(Enum))) type = typeof(int);

			StringBuilder declaration = new StringBuilder();

			string typeName = GetTypeName(type, outterClassName, isByRef);

			declaration.AppendFormat("{0} {1}", typeName, param.Name);

			if (param.ParameterType.IsArray)
			{
				declaration.Append("[]");
			}

			return declaration.ToString();
		}


		public static string GetMethodParamInvocationList(MethodInfo method)
		{
			StringBuilder declaration = new StringBuilder();
			foreach (var param in method.GetParameters())
			{
				declaration.Append(", ");
				declaration.Append(param.Name);
			}

			return declaration.ToString();
		}

		public static string GetInteropMethodParamInvocationList(MethodInfo method)
		{
			StringBuilder declaration = new StringBuilder();
			foreach (var param in method.GetParameters())
			{
				declaration.Append(", ");
				declaration.Append(GetInteropMethodParamInvocation(param));
			}

			return declaration.ToString();
		}

		public static string GetInteropMethodParamInvocation(ParameterInfo param)
		{
			Type type = param.ParameterType.IsArray ? param.ParameterType.GetElementType() : param.ParameterType;
			bool isByRef = type.IsByRef || param.IsRetval || param.IsOut;

			if (type.IsByRef) type = type.GetElementType();
			if (type.IsSubclassOf(typeof(Enum))) type = typeof(int);

			string functionName;

			if (param.ParameterType == typeof(string) || param.ParameterType == typeof(string[]))
			{
				functionName = "toUTF8({0})";
			}
			else if (param.ParameterType == typeof(DateTime) || param.ParameterType == typeof(DateTime[]))
			{
				functionName = "OleDate.toOADate({0})";
			} 
			else
			{
				functionName = "{0}";
			}

			string paramInvocation = string.Format(functionName, param.Name);

			if (param.ParameterType.IsArray)
			{
				paramInvocation = string.Format("{0}, {1}.length", paramInvocation, param.Name);
			}

			return paramInvocation;
		}


		public static string GetCammelCase(string memberName)
		{
			return memberName.Substring(0, 1).ToLower() + memberName.Substring(1);
		}
	}
}
