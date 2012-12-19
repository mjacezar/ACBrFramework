using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework
{
	public abstract class ACBrInteropBase
	{
		#region Inner Types

		protected delegate int GetStringEntryPointDelegate(IntPtr handle, StringBuilder buffer, int bufferLen);

		protected delegate int GetDoubleEntryPointDelegate(IntPtr handle, ref double value);

		protected delegate int GetInt32EntryPointDelegate(IntPtr handle);

		protected delegate int SetStringEntryPointDelegate(IntPtr handle, string value);

		protected delegate int SetArrayStringEntryPointDelegate(IntPtr handle, string[] value, int count);

		protected delegate int GetArrayStringEntryPointDelegate(IntPtr handle, StringBuilder value, int bufferLen, int index);

		protected delegate int SetdoubleEntryPointDelegate(IntPtr handle, double value);

		protected delegate int SetInt32EntryPointDelegate(IntPtr handle, int value);

		protected delegate int SetCharEntryPointDelegate(IntPtr handle, char value);

		protected delegate int SetBoolEntryPointDelegate(IntPtr handle, bool value);

		#endregion Inner Types

		#region Properties

		public abstract IntPtr Handle { get; }

		#endregion Properties

		#region Constructor

		protected ACBrInteropBase()
		{
		}

		#endregion Constructor

		#region P/Invoke Helpers

		protected string ToUTF8(string value)
		{
			if (string.IsNullOrEmpty(value)) return string.Empty;

			return Encoding.Default.GetString(Encoding.UTF8.GetBytes(value));
		}

        protected int ToUTF8(int value)
        {
            int retorno = -1;

            if (int.TryParse(value.ToString(), out retorno))
                return retorno;

            return retorno;
        }

        protected double ToUTF8(decimal value)
        {
            double retorno = -1;

            if (double.TryParse(value.ToString(), out retorno))
                return retorno;

            return retorno;
        }

        protected double ToUTF8(DateTime value)
        {
            return value.ToOADate();
        }

		protected string FromUTF8(string value)
		{
			if (value == null) return null;
			if (value.Length == 0) return string.Empty;

			return Encoding.UTF8.GetString(Encoding.Default.GetBytes(value));
		}

		protected string FromUTF8(StringBuilder value)
		{
			if (value == null) return null;
			if (value.Length == 0) return string.Empty;

			return Encoding.UTF8.GetString(Encoding.Default.GetBytes(value.ToString()));
		}

        protected int FromUTF8(int value)
        {
            int retorno = -1;

            if (int.TryParse(value.ToString(), out retorno))
                return retorno;

            return retorno;
        }

        protected decimal FromUTF8(double value)
        {
            decimal retorno = -1;

            if (decimal.TryParse(value.ToString(), out retorno))
                return retorno;

            return retorno;
        }

        protected string GetAbout(GetStringEntryPointDelegate entryPoint)
        {
            const int BUFFER_LEN = 256;
            return string.Format("ACBr: {0} ACBrFramework: {1}", GetString(entryPoint, BUFFER_LEN), this.GetType().Assembly.GetName().Version);
        }

		protected string GetString(GetStringEntryPointDelegate entryPoint)
		{
			const int BUFFER_LEN = 256;
			return GetString(entryPoint, BUFFER_LEN);
		}

		protected string GetString(GetStringEntryPointDelegate entryPoint, int bufferLen)
		{
			StringBuilder buffer = new StringBuilder(bufferLen);

			int ret = entryPoint(Handle, buffer, bufferLen);
			CheckResult(ret);

			return FromUTF8(buffer);
		}

		protected void SetString(SetStringEntryPointDelegate entryPoint, string value)
		{
			int ret = entryPoint(Handle, ToUTF8(value));
			CheckResult(ret);
		}

		protected string[] GetStringArray(GetArrayStringEntryPointDelegate entryPoint, GetInt32EntryPointDelegate GetCount)
		{
			const int BUFFER_LEN = 256;
			return GetStringArray(entryPoint, GetCount, BUFFER_LEN);
		}

		protected string[] GetStringArray(GetArrayStringEntryPointDelegate entryPoint, GetInt32EntryPointDelegate GetCount, int bufferLen)
		{
			int count = GetCount(Handle);
			CheckResult(count);

			string[] Retorno = new string[count];

			for (int i = 0; i < count; i++)
			{
				StringBuilder buffer = new StringBuilder(bufferLen);
				int ret = entryPoint(Handle, buffer, bufferLen, i);
				CheckResult(ret);
				Retorno[i] = FromUTF8(buffer);
			}

			return Retorno;
		}

		protected string[] GetStringArray(IntPtr ptr, int len)
		{
			if (ptr == IntPtr.Zero) return null;
			if (len == 0) return new string[0];

			string[] array = new string[len];

			for (int i = 0; i < len; i++)
			{
				int offSet = Marshal.SizeOf(typeof(IntPtr)) * i;
				IntPtr elementPtr = new IntPtr(ptr.ToInt32() + offSet);

				IntPtr strPtr = Marshal.ReadIntPtr(elementPtr);

				array[i] = FromUTF8(Marshal.PtrToStringAnsi(strPtr));
			}

			return array;
		}

		protected void SetStringArray(SetArrayStringEntryPointDelegate entryPoint, string[] value)
		{
			string[] array = new string[value.Length];

			for (int i = 0; i < value.Length; i++)
			{
				array[i] = ToUTF8(value[i]);
			}

			int ret = entryPoint(Handle, array, array.Length);
			CheckResult(ret);
		}

		protected DateTime GetDateTime(GetDoubleEntryPointDelegate entryPoint)
		{
			double ticks = 0d;
			int ret = entryPoint(Handle, ref ticks);
			CheckResult(ret);

			return DateTime.FromOADate(ticks);
		}

		protected void SetDateTime(SetdoubleEntryPointDelegate entryPoint, DateTime value)
		{
			double ticks = value.ToOADate();
			int ret = entryPoint(Handle, ticks);
			CheckResult(ret);
		}

		protected decimal GetDecimal(GetDoubleEntryPointDelegate entryPoint)
		{
			double value = 0d;
			int ret = entryPoint(Handle, ref value);
			CheckResult(ret);

			return Convert.ToDecimal(value);
		}

		protected void SetDecimal(SetdoubleEntryPointDelegate entryPoint, decimal value)
		{
			int ret = entryPoint(Handle, Convert.ToDouble(value));
			CheckResult(ret);
		}

		protected int GetInt32(GetInt32EntryPointDelegate entryPoint)
		{
			int ret = entryPoint(Handle);
			CheckResult(ret);

			return ret;
		}

		protected void SetInt32(SetInt32EntryPointDelegate entryPoint, int value)
		{
			int ret = entryPoint(Handle, value);
			CheckResult(ret);
		}

		protected char GetChar(GetInt32EntryPointDelegate entryPoint)
		{
			int ret = entryPoint(Handle);
			CheckResult(ret);

			return (char)ret;
		}

		protected void SetChar(SetCharEntryPointDelegate entryPoint, char value)
		{
			int ret = entryPoint(Handle, value);
			CheckResult(ret);
		}

		protected bool GetBool(GetInt32EntryPointDelegate entryPoint)
		{
			int ret = entryPoint(Handle);
			CheckResult(ret);

			return ret == 1 ? true : false;
		}

		protected void SetBool(SetBoolEntryPointDelegate entryPoint, bool value)
		{
			int ret = entryPoint(Handle, value);
			CheckResult(ret);
		}		

		protected internal abstract void CheckResult(int result);

		#region Documentation

		/// <summary>
		/// Prepara o StringBuilder recebido de uma função Callback, isto é, recebida pelo disparo de um evento.
		/// </summary>

		#endregion Documentation

		protected void PrepareOutStringBuilder(StringBuilder builder, int capacity)
		{
			Type type = typeof(StringBuilder);
			const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			FieldInfo field = type.GetField("m_MaxCapacity", flags);
			field.SetValue(builder, capacity - 1);

			builder.Capacity = capacity - 1;
		}

		#endregion P/Invoke Helpers
	}
}