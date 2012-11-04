using System;
using System.ComponentModel;

namespace ACBrFramework
{
	public sealed class ACBrPAF_B : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_B(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroB1 = new ACBrPAFRegistroB1();
			this.RegistroB2 = new ACBrPAFRegistrosB2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroB1 RegistroB1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosB2 RegistroB2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroB1 = null;
			RegistroB1 = new ACBrPAFRegistroB1();
			RegistroB2.Clear();
		}

		public bool SaveFileTXT_B(string arquivo)
		{
			int i;

			ACBrPAFInterop.RegistroHD1Rec RegistroB1Rec = new ACBrPAFInterop.RegistroHD1Rec();
			ACBrPAFInterop.RegistroB2Rec[] RegistroB2Rec = new ACBrPAFInterop.RegistroB2Rec[RegistroB2.Count];

			RegistroB1Rec.RAZAOSOCIAL = ToUTF8(RegistroB1.RazaoSocial);
			RegistroB1Rec.CNPJ = ToUTF8(RegistroB1.CNPJ);
			RegistroB1Rec.UF = ToUTF8(RegistroB1.UF);
			RegistroB1Rec.IE = ToUTF8(RegistroB1.IE);
			RegistroB1Rec.IM = ToUTF8(RegistroB1.IM);

			for (i = 0; i < RegistroB2.Count; i++)
			{
				RegistroB2Rec[i].BOMBA = ToUTF8(RegistroB2[i].BOMBA);
				RegistroB2Rec[i].BICO = ToUTF8(RegistroB2[i].BICO);
				RegistroB2Rec[i].DATA = RegistroB2[i].DATA.ToOADate();
				RegistroB2Rec[i].HORA = RegistroB2[i].HORA.ToOADate();
				RegistroB2Rec[i].MOTIVO = ToUTF8(RegistroB2[i].MOTIVO);
				RegistroB2Rec[i].CNPJ_EMPRESA = ToUTF8(RegistroB2[i].CNPJ_EMPRESA);
				RegistroB2Rec[i].CPF_TECNICO = ToUTF8(RegistroB2[i].CPF_TECNICO);
				RegistroB2Rec[i].NRO_LACRE_ANTES = ToUTF8(RegistroB2[i].NRO_LACRE_ANTES);
				RegistroB2Rec[i].NRO_LACRE_APOS = ToUTF8(RegistroB2[i].NRO_LACRE_ANTES);
				RegistroB2Rec[i].ENCERRANTE_ANTES = Convert.ToDouble(RegistroB2[i].ENCERRANTE_ANTES);
				RegistroB2Rec[i].ENCERRANTE_APOS = Convert.ToDouble(RegistroB2[i].ENCERRANTE_APOS);
				RegistroB2Rec[i].RegistroValido = RegistroB2[i].RegistroValido;
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_B(this.Handle, RegistroB1Rec, RegistroB2Rec, RegistroB2.Count, ToUTF8(arquivo));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Methods
	}
}