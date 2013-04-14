using System;
using System.Collections;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
    public sealed class MedCollection : ACBrComposedComponent, IEnumerable<MedCollectionItem>
    {
        #region Constructor

        internal MedCollection(ACBrNFE parent, IntPtr composedHandle)
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
                return GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Med_Count);
            }
        }

        public MedCollectionItem this[int idx]
        {
            get
            {
                if (idx >= Count) throw new IndexOutOfRangeException();

                IntPtr medHandle;
                int ret = ACBrNFEInterop.NFE_NFe_Det_GetItem(this.Handle, ComposedHandle, out medHandle, idx);
                CheckResult(ret);

                return new MedCollectionItem(this.Parent, medHandle);
            }
            set
            {
                int ret = ACBrNFEInterop.NFE_NFe_Det_SetItem(this.Handle, ComposedHandle, value.ComposedHandle, idx);
                CheckResult(ret);
            }
        }

        #endregion Properties

        #region Methods

        public MedCollectionItem Add()
        {
            IntPtr medHandle;
            int ret = ACBrNFEInterop.NFE_NFe_Det_Item_Med_Add(this.Handle, ComposedHandle, out medHandle);
            CheckResult(ret);

            return new MedCollectionItem(this.Parent, medHandle);
        }

        public void Clear()
        {
            int ret = ACBrNFEInterop.NFE_NFe_Det_Item_Med_Clear(this.Handle, ComposedHandle);
            CheckResult(ret);
        }

        #endregion Methods

        #region IEnumerable<MedCollectionItem>

        public IEnumerator<MedCollectionItem> GetEnumerator()
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