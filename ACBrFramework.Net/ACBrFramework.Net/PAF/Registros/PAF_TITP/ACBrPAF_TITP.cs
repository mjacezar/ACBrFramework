using System;
using System.ComponentModel;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAF_TITP : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_TITP(ACBrPAF Paf)
			: base(Paf)
		{
			this.Mercadorias = new ACBrPAFRegistroMercadorias();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroMercadorias Mercadorias { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			Mercadorias.Clear();
		}

		public Boolean SaveFileTXT_TITP(string arquivo)
		{
			int ItemIndex = 0;
			int InsumosCount = 0;

			foreach (ACBrPAFRegistroMercadoria mercadoria in Mercadorias)
			{
				InsumosCount += mercadoria.Insumos.Count;
			}

			ACBrPAFInterop.RegistroMercadoriasRec[] MercadoriasRec = new ACBrPAFInterop.RegistroMercadoriasRec[Mercadorias.Count];
			ACBrPAFInterop.RegistroInsumosRec[] InsumosRec = new ACBrPAFInterop.RegistroInsumosRec[InsumosCount];

			for (int i = 0; i < Mercadorias.Count; i++)
			{
				MercadoriasRec[i].Descricao = ToUTF8(Mercadorias[i].Descricao);
				MercadoriasRec[i].Codigo = ToUTF8(Mercadorias[i].Codigo);
				MercadoriasRec[i].Aliquota = Mercadorias[i].Aliquota;
				MercadoriasRec[i].Unidade = ToUTF8(Mercadorias[i].Unidade);
				MercadoriasRec[i].Quantidade = Mercadorias[i].Quantidade;
				MercadoriasRec[i].Ean = ToUTF8(Mercadorias[i].Ean);
				MercadoriasRec[i].CST = ToUTF8(Mercadorias[i].CST);
				MercadoriasRec[i].VlrUnitario = Mercadorias[i].VlrUnitario;
				MercadoriasRec[i].QTD_Insumos = Mercadorias[i].Insumos.Count;

				foreach (ACBrPAFRegistroInsumo Insumo in Mercadorias[i].Insumos)
				{
					InsumosRec[ItemIndex].Descricao = ToUTF8(Insumo.Descricao);
					InsumosRec[ItemIndex].Codigo = ToUTF8(Insumo.Codigo);
					InsumosRec[ItemIndex].Aliquota = Insumo.Aliquota;
					InsumosRec[ItemIndex].Unidade = ToUTF8(Insumo.Unidade);
					InsumosRec[ItemIndex].Quantidade = Insumo.Quantidade;
					InsumosRec[ItemIndex].Ean = ToUTF8(Insumo.Ean);
					InsumosRec[ItemIndex].CST = ToUTF8(Insumo.CST);
					InsumosRec[ItemIndex].VlrUnitario = Insumo.VlrUnitario;
					ItemIndex++;
				}
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_TITP(this.Handle, MercadoriasRec, Mercadorias.Count, InsumosRec, ToUTF8(arquivo));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Methods
	}
}