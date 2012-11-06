using System;
using System.ComponentModel;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAF_C : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_C(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroC1 = new ACBrPAFRegistroC1();
			this.RegistroC2 = new ACBrPAFRegistrosC2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroC1 RegistroC1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosC2 RegistroC2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroC1 = null;
			RegistroC1 = new ACBrPAFRegistroC1();
			RegistroC2.Clear();
		}

		public bool SaveFileTXT_C(string arquivo)
		{
			int i;

			ACBrPAFInterop.RegistroHD1Rec RegistroC1Rec = new ACBrPAFInterop.RegistroHD1Rec();
			ACBrPAFInterop.RegistroC2Rec[] RegistroC2Rec = new ACBrPAFInterop.RegistroC2Rec[RegistroC2.Count];

			RegistroC1Rec.RAZAOSOCIAL = ToUTF8(RegistroC1.RazaoSocial);
			RegistroC1Rec.CNPJ = ToUTF8(RegistroC1.CNPJ);
			RegistroC1Rec.UF = ToUTF8(RegistroC1.UF);
			RegistroC1Rec.IE = ToUTF8(RegistroC1.IE);
			RegistroC1Rec.IM = ToUTF8(RegistroC1.IM);

			for (i = 0; i < RegistroC2.Count; i++)
			{
				RegistroC2Rec[i].ID_ABASTECIMENTO = ToUTF8(RegistroC2[i].ID_ABASTECIMENTO);
				RegistroC2Rec[i].TANQUE = ToUTF8(RegistroC2[i].TANQUE);
				RegistroC2Rec[i].BOMBA = ToUTF8(RegistroC2[i].BOMBA);
				RegistroC2Rec[i].COMBUSTIVEL = ToUTF8(RegistroC2[i].COMBUSTIVEL);
				RegistroC2Rec[i].DATA_ABASTECIMENTO = RegistroC2[i].DATA_ABASTECIMENTO.ToOADate();
				RegistroC2Rec[i].HORA_ABASTECIMENTO = RegistroC2[i].HORA_ABASTECIMENTO.ToOADate();
				RegistroC2Rec[i].ENCERRANTE_INICIAL = Convert.ToDouble(RegistroC2[i].ENCERRANTE_INICIAL);
				RegistroC2Rec[i].ENCERRANTE_FINAL = Convert.ToDouble(RegistroC2[i].ENCERRANTE_FINAL);
				RegistroC2Rec[i].STATUS_ABASTECIMENTO = ToUTF8(RegistroC2[i].STATUS_ABASTECIMENTO);
				RegistroC2Rec[i].NRO_SERIE_ECF = ToUTF8(RegistroC2[i].NRO_SERIE_ECF);
				RegistroC2Rec[i].DATA = RegistroC2[i].DATA.ToOADate();
				RegistroC2Rec[i].HORA = RegistroC2[i].HORA.ToOADate();
				RegistroC2Rec[i].COO = RegistroC2[i].COO;
				RegistroC2Rec[i].NRO_NOTA_FISCAL = RegistroC2[i].NRO_NOTA_FISCAL;
				RegistroC2Rec[i].VOLUME = Convert.ToDouble(RegistroC2[i].VOLUME);
				RegistroC2Rec[i].RegistroValido = RegistroC2[i].RegistroValido;
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_C(this.Handle, RegistroC1Rec, RegistroC2Rec, RegistroC2.Count, ToUTF8(arquivo));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Methods
	}
}