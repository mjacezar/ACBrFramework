using System;
using System.ComponentModel;

namespace ACBrFramework
{
	public sealed class ACBrPAF_H : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_H(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroH1 = new ACBrPAFRegistroH1();
			this.RegistroH2 = new ACBrPAFRegistrosH2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroH1 RegistroH1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosH2 RegistroH2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroH1 = null;
			RegistroH1 = new ACBrPAFRegistroH1();
			RegistroH2.Clear();
		}

		public bool SaveFileTXT_H(string arquivo)
		{
			int i;

			ACBrPAFInterop.RegistroHD2Rec RegistroH1Rec = new ACBrPAFInterop.RegistroHD2Rec();
			ACBrPAFInterop.RegistroH2Rec[] RegistroH2Rec = new ACBrPAFInterop.RegistroH2Rec[RegistroH2.Count];

			RegistroH1Rec.RAZAOSOCIAL = ToUTF8(RegistroH1.RazaoSocial);
			RegistroH1Rec.CNPJ = ToUTF8(RegistroH1.CNPJ);
			RegistroH1Rec.UF = ToUTF8(RegistroH1.UF);
			RegistroH1Rec.IE = ToUTF8(RegistroH1.IE);
			RegistroH1Rec.IM = ToUTF8(RegistroH1.IM);
			RegistroH1Rec.NUM_FAB = ToUTF8(RegistroH1.NUM_FAB);
			RegistroH1Rec.MF_ADICIONAL = ToUTF8(RegistroH1.MF_ADICIONAL);
			RegistroH1Rec.TIPO_ECF = ToUTF8(RegistroH1.TIPO_ECF);
			RegistroH1Rec.MARCA_ECF = ToUTF8(RegistroH1.MARCA_ECF);
			RegistroH1Rec.MODELO_ECF = ToUTF8(RegistroH1.NUM_FAB);
			RegistroH1Rec.DT_EST = RegistroH1.DT_EST.ToOADate();
			RegistroH1Rec.RegistroValido = RegistroH1.RegistroValido;
			RegistroH1Rec.InclusaoExclusao = RegistroH1.InclusaoExclusao;

			for (i = 0; i < RegistroH2.Count; i++)
			{
				RegistroH2Rec[i].CNPJ_CRED_CARTAO = ToUTF8(RegistroH2[i].CNPJ_CRED_CARTAO);
				RegistroH2Rec[i].COO = RegistroH2[i].COO;
				RegistroH2Rec[i].CCF = RegistroH2Rec[i].CCF;
				RegistroH2Rec[i].VLR_TROCO = RegistroH2Rec[i].VLR_TROCO;
				RegistroH2Rec[i].DT_TROCO = RegistroH2[i].DT_TROCO.ToOADate();
				RegistroH2Rec[i].CPF = ToUTF8(RegistroH2[i].CPF);
				RegistroH2Rec[i].Titulo = ToUTF8(RegistroH2[i].Titulo);
				RegistroH2Rec[i].RegistroValido = RegistroH2[i].RegistroValido;
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_H(this.Handle, RegistroH1Rec, RegistroH2Rec, RegistroH2.Count, ToUTF8(arquivo));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Methods
	}
}