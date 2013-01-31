using System;
using System.ComponentModel;
using System.Text;
#if COM_INTEROP
using System.Runtime.InteropServices;
#endif

namespace ACBrFramework
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("93CB443A-7AA7-4E6F-816E-8BFE5CA18261")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public abstract class ACBrComposedComponent : ACBrInteropBase
	{
		#region InnerTypes

		protected delegate int GetComposedStringEntryPointDelegate(IntPtr handle, IntPtr composedHandle, StringBuilder buffer, int bufferLen);

		protected delegate int GetComposedDoubleEntryPointDelegate(IntPtr handle, IntPtr composedHandle, ref double value);

		protected delegate int GetComposedInt32EntryPointDelegate(IntPtr handle, IntPtr composedHandle);

		protected delegate int SetComposedStringEntryPointDelegate(IntPtr handle, IntPtr composedHandle, string value);

		protected delegate int SetComposedArrayStringEntryPointDelegate(IntPtr handle, IntPtr composedHandle, string[] value, int count);

		protected delegate int GetComposedArrayStringEntryPointDelegate(IntPtr handle, IntPtr composedHandle, StringBuilder value, int bufferLen, int index);

		protected delegate int SetComposedDoubleEntryPointDelegate(IntPtr handle, IntPtr composedHandle, double value);

		protected delegate int SetComposedInt32EntryPointDelegate(IntPtr handle, IntPtr composedHandle, int value);

		protected delegate int SetComposedCharEntryPointDelegate(IntPtr handle, IntPtr composedHandle, char value);

		protected delegate int SetComposedBoolEntryPointDelegate(IntPtr handle, IntPtr composedHandle, bool value);

		#endregion InnerTypes

		#region Fields

		private IntPtr composedHandle;

		#endregion Fields

		#region Properties

		[Browsable(false)]
		public ACBrComponent Parent { get; private set; }

		[Browsable(false)]
		public override IntPtr Handle
		{
			get
			{
				return Parent.Handle;
			}
		}

		[Browsable(false)]
		public virtual IntPtr ComposedHandle
		{
			get
			{
				return this.composedHandle;
			}
		}

		#endregion Properties

		#region Constructor

		protected ACBrComposedComponent(ACBrComponent parent)
		{
			this.Parent = parent;
			this.composedHandle = IntPtr.Zero;
		}

		protected ACBrComposedComponent(ACBrComponent parent, IntPtr composedHandle)
		{
			this.Parent = parent;
			this.composedHandle = composedHandle;
		}

		#endregion Constructor

		#region Methods

		protected internal override void CheckResult(int result)
		{
			Parent.CheckResult(result);
		}

		#region P/Invoke Helpers

		protected string GetString(GetComposedStringEntryPointDelegate entryPoint)
		{
			const int BUFFER_LEN = 256;
			return GetString(entryPoint, BUFFER_LEN);
		}

		protected string GetString(GetComposedStringEntryPointDelegate entryPoint, int bufferLen)
		{
			StringBuilder buffer = new StringBuilder(bufferLen);

			int ret = entryPoint(Handle, composedHandle, buffer, bufferLen);
			CheckResult(ret);

			return FromUTF8(buffer);
		}

		protected void SetString(SetComposedStringEntryPointDelegate entryPoint, string value)
		{
			int ret = entryPoint(Handle, composedHandle, ToUTF8(value));
			CheckResult(ret);
		}

		protected string[] GetStringArray(GetComposedArrayStringEntryPointDelegate entryPoint, GetComposedInt32EntryPointDelegate GetCount)
		{
			const int BUFFER_LEN = 256;
			return GetStringArray(entryPoint, GetCount, BUFFER_LEN);
		}

		protected string[] GetStringArray(GetComposedArrayStringEntryPointDelegate entryPoint, GetComposedInt32EntryPointDelegate GetCount, int bufferLen)
		{
			int count = GetCount(Handle, composedHandle);
			CheckResult(count);

			string[] Retorno = new string[count];

			for (int i = 0; i < count; i++)
			{
				StringBuilder buffer = new StringBuilder(bufferLen);
				int ret = entryPoint(Handle, composedHandle, buffer, bufferLen, i);
				CheckResult(ret);
				Retorno[i] = FromUTF8(buffer);
			}

			return Retorno;
		}

		protected void SetStringArray(SetComposedArrayStringEntryPointDelegate entryPoint, string[] value)
		{
			string[] array = new string[value.Length];

			for (int i = 0; i < value.Length; i++)
			{
				array[i] = ToUTF8(value[i]);
			}

			int ret = entryPoint(Handle, composedHandle, array, array.Length);
			CheckResult(ret);
		}

		protected DateTime GetDateTime(GetComposedDoubleEntryPointDelegate entryPoint)
		{
			double ticks = 0d;
			int ret = entryPoint(Handle, composedHandle, ref ticks);
			CheckResult(ret);

			return DateTime.FromOADate(ticks);
		}

		protected void SetDateTime(SetComposedDoubleEntryPointDelegate entryPoint, DateTime value)
		{
			double ticks = value.ToOADate();
			int ret = entryPoint(Handle, composedHandle, ticks);
			CheckResult(ret);
		}

		protected decimal GetDecimal(GetComposedDoubleEntryPointDelegate entryPoint)
		{
			double value = 0d;
			int ret = entryPoint(Handle, composedHandle, ref value);
			CheckResult(ret);

			return Convert.ToDecimal(value);
		}

		protected void SetDecimal(SetComposedDoubleEntryPointDelegate entryPoint, decimal value)
		{
			int ret = entryPoint(Handle, composedHandle, Convert.ToDouble(value));
			CheckResult(ret);
		}

		protected int GetInt32(GetComposedInt32EntryPointDelegate entryPoint)
		{
			int ret = entryPoint(Handle, composedHandle);
			CheckResult(ret);

			return ret;
		}

		protected void SetInt32(SetComposedInt32EntryPointDelegate entryPoint, int value)
		{
			int ret = entryPoint(Handle, composedHandle, value);
			CheckResult(ret);
		}

		protected char GetChar(GetComposedInt32EntryPointDelegate entryPoint)
		{
			int ret = entryPoint(Handle, composedHandle);
			CheckResult(ret);

			return (char)ret;
		}

		protected void SetChar(SetComposedCharEntryPointDelegate entryPoint, char value)
		{
			int ret = entryPoint(Handle, composedHandle, value);
			CheckResult(ret);
		}

		protected bool GetBool(GetComposedInt32EntryPointDelegate entryPoint)
		{
			int ret = entryPoint(Handle, composedHandle);
			CheckResult(ret);

			return ret == 1 ? true : false;
		}

		protected void SetBool(SetComposedBoolEntryPointDelegate entryPoint, bool value)
		{
			int ret = entryPoint(Handle, composedHandle, value);
			CheckResult(ret);
		}

		#endregion P/Invoke Helpers

		#endregion Methods
	}
}