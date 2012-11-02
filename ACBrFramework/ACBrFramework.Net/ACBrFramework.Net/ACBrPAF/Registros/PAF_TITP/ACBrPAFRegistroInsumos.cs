using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework
{
	public sealed class ACBrPAFRegistroInsumos : ACBrComposedComponent, IEnumerable<ACBrPAFRegistroInsumo>
	{
		#region Constructor

		int MercadoriaIndex = -1;

		internal ACBrPAFRegistroInsumos(ACBrPAFRegistroMercadorias Mercadoria): base(Mercadoria.Parent)	{}

		#endregion Constructor

		#region Properties

		public int Count
		{
			get
			{
				return GetInt32Count(ACBrPAFInterop.PAF_TITP_Insumos_Count, 0);
			}
		}

		[IndexerName("GetItem")]
		public ACBrPAFRegistroInsumo this[int index]
		{
			get
			{
				return Get(index);
			}
		}

		#endregion Properties

		#region Methods

		public void New(ACBrPAFRegistroInsumo Insumo)
		{
			ACBrPAFInterop.RegistroTITPRec item = new ACBrPAFInterop.RegistroTITPRec();
			item.Codigo = ToUTF8(Insumo.Codigo);
			item.Descricao = ToUTF8(Insumo.Descricao);
			item.Aliquota = Insumo.Aliquota;
			item.Unidade = ToUTF8(Insumo.Unidade);
			item.Quantidade = Insumo.Quantidade;
			item.Ean = ToUTF8(Insumo.Ean);
			item.CST = ToUTF8(Insumo.CST);
			item.VlrUnitario = Insumo.VlrUnitario;
			int ret = ACBrPAFInterop.PAF_TITP_Insumos_New(this.Handle, item, 0);
			CheckResult(ret);
		}

		public void Clear()
		{
			int ret = ACBrPAFInterop.PAF_TITP_Insumos_Clear(this.Handle, 0);
			CheckResult(ret);
		}

		private ACBrPAFRegistroInsumo Get(int index)
		{
			ACBrPAFInterop.RegistroTITPRec item = new ACBrPAFInterop.RegistroTITPRec();
			int ret = ACBrPAFInterop.PAF_TITP_Insumos_Get(this.Handle, ref item, MercadoriaIndex, index);
			CheckResult(ret);

			ACBrPAFRegistroInsumo insumo = new ACBrPAFRegistroInsumo();
			insumo.Codigo = FromUTF8(item.Codigo);
			insumo.Descricao = FromUTF8(item.Descricao);
			insumo.Aliquota = item.Aliquota;
			insumo.Unidade = FromUTF8(item.Unidade);
			insumo.Quantidade = item.Quantidade;
			insumo.Ean = FromUTF8(item.Ean);
			insumo.CST = FromUTF8(item.CST);
			insumo.VlrUnitario = item.VlrUnitario;
			return insumo;
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroInsumo>

		public IEnumerator<ACBrPAFRegistroInsumo> GetEnumerator()
		{
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				yield return Get(i);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroInsumo>
	}
}
