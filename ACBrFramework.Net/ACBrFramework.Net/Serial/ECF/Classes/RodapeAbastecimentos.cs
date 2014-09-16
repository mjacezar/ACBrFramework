using System;
using System.Collections.Generic;
#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.ECF
{
    #region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("59F119F6-2A97-4434-8E40-7AD9A762A2E0")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP
    public sealed class RodapeAbastecimentos : ACBrComposedComponent, IEnumerable<RodapeAbastecimento>
    {
        #region Fields

        List<RodapeAbastecimento> Itens;

        #endregion Fields

        #region Constructor

        internal RodapeAbastecimentos(Rodape rodape)
            : base(rodape.Parent)
        {
            Itens = new List<RodapeAbastecimento>();
        }

        #endregion Constructor

        #region Properties

        public bool Imprimir
        {
            get
            {
                return GetBool(ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_GetImprimir);
            }
            set
            {
                SetBool(ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_SetImprimir, value);
            }
        }

        public int Count { get { return Itens.Count; } }

        public RodapeAbastecimento this[int index]
		{
			get
			{
				if (index >= Count) throw new IndexOutOfRangeException();
                return Itens[index];
			}
		}

        #endregion Properties

        #region Methods

        public RodapeAbastecimento AddNew()
        {
            IntPtr composedHandle;
            int ret = ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_New(this.Handle, out composedHandle);
            CheckResult(ret);

            var item = new RodapeAbastecimento((ACBrECF)this.Parent, composedHandle);
            Itens.Add(item);
            return item;
        }

        public void Remove(RodapeAbastecimento abastecimento)
        {
            int ret = ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_Remove(this.Handle, abastecimento.ComposedHandle);
            CheckResult(ret);
            Itens.Remove(abastecimento);
        }

        public void RemoveAt(int idx)
        {
            var abastecimento = Itens[idx];
            int ret = ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_Remove(this.Handle, abastecimento.ComposedHandle);
            CheckResult(ret);
            Itens.Remove(abastecimento);
        }

        public void Clear()
        {
            int ret = ACBrECFInterop.ECF_InfoRodapeCupom_PostoCombustivel_Clear(this.Handle);
            CheckResult(ret);
        }

        #endregion Methods

        #region IEnumerable

        public IEnumerator<RodapeAbastecimento> GetEnumerator()
        {
            return Itens.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion IEnumerable
    }
}