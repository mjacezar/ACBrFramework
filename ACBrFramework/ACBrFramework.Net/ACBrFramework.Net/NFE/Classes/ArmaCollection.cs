using System;
using System.Collections;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
    public sealed class ArmaCollection : ACBrComposedComponent, IEnumerable<ArmaCollectionItem>
    {
        #region Constructor

        internal ArmaCollection(ACBrNFE parent, IntPtr composedHandle)
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
                return GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Arma_Count);
            }
        }

        public ArmaCollectionItem this[int idx]
        {
            get
            {
                if (idx >= Count) throw new IndexOutOfRangeException();

                IntPtr armHandle;
                int ret = ACBrNFEInterop.NFE_NFe_Det_GetItem(this.Handle, ComposedHandle, out armHandle, idx);
                CheckResult(ret);

                return new ArmaCollectionItem(this.Parent, armHandle);
            }
            set
            {
                int ret = ACBrNFEInterop.NFE_NFe_Det_SetItem(this.Handle, ComposedHandle, value.ComposedHandle, idx);
                CheckResult(ret);
            }
        }

        #endregion Properties

        #region Methods

        public ArmaCollectionItem Add()
        {
            IntPtr armHandle;
            int ret = ACBrNFEInterop.NFE_NFe_Det_Item_Arma_Add(this.Handle, ComposedHandle, out armHandle);
            CheckResult(ret);

            return new ArmaCollectionItem(this.Parent, armHandle);
        }

        public void Clear()
        {
            int ret = ACBrNFEInterop.NFE_NFe_Det_Item_Arma_Clear(this.Handle, ComposedHandle);
            CheckResult(ret);
        }

        #endregion Methods

        #region IEnumerable<ArmaCollectionItem>

        public IEnumerator<ArmaCollectionItem> GetEnumerator()
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
