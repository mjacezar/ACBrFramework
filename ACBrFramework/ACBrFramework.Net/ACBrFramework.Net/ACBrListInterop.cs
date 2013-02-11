using System;
using System.Collections.Generic;
using System.ComponentModel;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("CDF895D4-5B09-46E0-8109-E5F75E255983")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	public abstract class ACBrListInterop<TItem> : ACBrClassInterop, IEnumerable<TItem> where TItem : ACBrClassInterop
	{
		#region Inner Types

		protected delegate int AddEntryPointDelegate(IntPtr handle, IntPtr itemHandle);

		protected delegate int RemoveEntryPointDelegate(IntPtr handle, IntPtr itemHandle);

		protected delegate int ClearEntryPointDelegate(IntPtr handle);

		#endregion Inner Types

		#region Fields

		private readonly List<TItem> list;
		private readonly AddEntryPointDelegate addEntryPoint;
		private readonly RemoveEntryPointDelegate removeEntryPoint;
		private readonly ClearEntryPointDelegate clearEntryPoint;

		#endregion Fields

		#region Properties

		public int Count
		{
			get
			{
				return list.Count;
			}
		}

		public TItem this[int index]
		{
			get
			{
				return list[index];
			}
		}

		#endregion Properties

		#region Constructor

		protected ACBrListInterop(AddEntryPointDelegate addEntryPoint, RemoveEntryPointDelegate removeEntryPoint, ClearEntryPointDelegate clearEntryPoint)
		{
			this.list = new List<TItem>();
			this.addEntryPoint = addEntryPoint;
			this.removeEntryPoint = removeEntryPoint;
			this.clearEntryPoint = clearEntryPoint;
		}

		#endregion Constructor

		#region Methods

		public virtual void Add(TItem item)
		{
			CallAdd(item);
			list.Add(item);
		}

		public void Clear()
		{
			CallClear();
			list.Clear();
		}

		public bool Remove(TItem item)
		{
			CallRemove(item);
			return list.Remove(item);
		}

		public bool Contains(TItem item)
		{
			return list.Contains(item);
		}

		public TItem[] ToArray()
		{
			return list.ToArray();
		}

		#region P/Invoke Helpers

		private void CallAdd(TItem item)
		{
			var ret = addEntryPoint(this.Handle, item.Handle);
			CheckResult(ret);
		}

		private void CallRemove(TItem item)
		{
			var ret = removeEntryPoint(this.Handle, item.Handle);
			CheckResult(ret);
		}

		private void CallClear()
		{
			var ret = clearEntryPoint(this.Handle);
			CheckResult(ret);
		}

		#endregion P/Invoke Helpers

		#endregion Methods

		#region IEnumerable

		public IEnumerator<TItem> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable
	}
}