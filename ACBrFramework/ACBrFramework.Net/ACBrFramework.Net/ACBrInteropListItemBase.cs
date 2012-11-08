using System;
using System.Text;

namespace ACBrFramework
{
	public abstract class ACBrInteropListItemBase : ACBrComposedComponent
	{
		#region InnerTypes

		protected delegate int GetIndexedStringEntryPointDelegate(IntPtr handle, int index, StringBuilder buffer, int bufferLen);

		protected delegate int GetIndexedInt32EntryPointDelegate(IntPtr handle, int index);

		protected delegate int GetIndexedDoubleEntryPointDelegate(IntPtr handle, int index, ref double value);

		#endregion InnerTypes

		#region Constructor

		protected ACBrInteropListItemBase(ACBrComponent parent, int index)
			: base(parent)
		{
			this.Index = index;
		}

		#endregion Constructor

		#region Properties

		public int Index { get; private set; }

		#endregion Properties

		#region Method

		protected decimal GetDecimal(GetIndexedDoubleEntryPointDelegate entryPoint)
		{
			double value = 0d;
			int ret = entryPoint(Handle, Index, ref value);
			CheckResult(ret);

			return Convert.ToDecimal(value);
		}

		protected bool GetBool(GetIndexedInt32EntryPointDelegate entryPoint)
		{
			int ret = entryPoint(Handle, Index);
			CheckResult(ret);

			return ret == 1 ? true : false;
		}

		protected int GetInt32(GetIndexedInt32EntryPointDelegate entryPoint)
		{
			int ret = entryPoint(Handle, Index);
			CheckResult(ret);

			return ret;
		}

		protected string GetString(GetIndexedStringEntryPointDelegate entryPoint)
		{
			const int BUFFER_LEN = 256;
			return GetString(entryPoint, BUFFER_LEN);
		}

		protected string GetString(GetIndexedStringEntryPointDelegate entryPoint, int bufferLen)
		{
			StringBuilder buffer = new StringBuilder(bufferLen);

			int ret = entryPoint(Handle, Index, buffer, bufferLen);
			CheckResult(ret);

			return FromUTF8(buffer);
		}

		protected DateTime GetDateTime(GetIndexedDoubleEntryPointDelegate entryPoint)
		{
			double ticks = 0d;
			int ret = entryPoint(Handle, Index, ref ticks);
			CheckResult(ret);

			return DateTime.FromOADate(ticks);
		}

		#endregion Method
	}
}