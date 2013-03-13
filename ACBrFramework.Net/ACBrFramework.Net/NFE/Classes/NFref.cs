using System;
using System.Collections;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class NFref : ACBrComposedComponent, IEnumerable<NFrefCollectionItem>
	{
		#region Constructor

		internal NFref(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{

		}

		#endregion Constructor

		#region Properties

		private new ACBrNFE Parent
		{
			get
			{
				return (ACBrNFE)base.Parent;
			}
		}

		public int Count
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Count);
			}
		}

		public NFrefCollectionItem this[int idx]
		{
			get
			{
				if (idx >= Count) throw new IndexOutOfRangeException();

				IntPtr nfHandle;
				int ret = ACBrNFEInterop.NFE_NFe_Ide_NFref_GetItem(this.Handle, ComposedHandle, out nfHandle, idx);
				CheckResult(ret);

				return new NFrefCollectionItem(this.Parent, nfHandle);
			}
			set
			{
				int ret = ACBrNFEInterop.NFE_NFe_Ide_NFref_SetItem(this.Handle, ComposedHandle, value.ComposedHandle, idx);
				CheckResult(ret);
			}
		}

		#endregion Properties

		#region Methods

		public NFrefCollectionItem Add()
		{
			IntPtr nrefHandle;
			int ret = ACBrNFEInterop.NFE_NFe_Ide_NFref_Add(this.Handle, ComposedHandle, out nrefHandle);
			CheckResult(ret);

			return new NFrefCollectionItem(this.Parent, nrefHandle);
		}

		public void Clear()
		{
			int ret = ACBrNFEInterop.NFE_NFe_Ide_NFref_Clear(this.Handle, ComposedHandle);
			CheckResult(ret);
		}

		#endregion Methods

		#region IEnumerable<NotasFiscais>

		public IEnumerator<NFrefCollectionItem> GetEnumerator()
		{
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				yield return this[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion IEnumerable<NotasFiscais>
	}
}