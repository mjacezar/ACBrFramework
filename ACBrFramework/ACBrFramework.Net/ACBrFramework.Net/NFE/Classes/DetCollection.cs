using System;
using System.Collections;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class DetCollection : ACBrComposedComponent, IEnumerable<DetCollectionItem>
	{
		#region Constructor

		internal DetCollection(ACBrNFE parent, IntPtr composedHandle)
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
				return GetInt32(ACBrNFEInterop.NFE_NFe_Det_Count);
			}
		}

		public DetCollectionItem this[int idx]
		{
			get
			{
				if (idx >= Count) throw new IndexOutOfRangeException();

				IntPtr nfHandle;
				int ret = ACBrNFEInterop.NFE_NFe_Det_GetItem(this.Handle, ComposedHandle, out nfHandle, idx);
				CheckResult(ret);

				return new DetCollectionItem(this.Parent, nfHandle);
			}
			set
			{
				int ret = ACBrNFEInterop.NFE_NFe_Det_SetItem(this.Handle, ComposedHandle, value.ComposedHandle, idx);
				CheckResult(ret);
			}
		}

		#endregion Properties

		#region Methods

		public DetCollectionItem Add()
		{
			IntPtr detHandle;
			int ret = ACBrNFEInterop.NFE_NFe_Det_Add(this.Handle, ComposedHandle, out detHandle);
			CheckResult(ret);

			return new DetCollectionItem(this.Parent, detHandle);
		}

		public void Clear()
		{
			int ret = ACBrNFEInterop.NFE_NFe_Det_Clear(this.Handle, ComposedHandle);
			CheckResult(ret);
		}

		#endregion Methods

		#region IEnumerable<DetCollectionItem>

		public IEnumerator<DetCollectionItem> GetEnumerator()
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