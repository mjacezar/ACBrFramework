using System;
using System.ComponentModel;

namespace ACBrFramework
{
	public sealed class ACBrPAF_T : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_T(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroT1 = new ACBrPAFRegistroT1();
			this.RegistroT2 = new ACBrPAFRegistrosT2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroT1 RegistroT1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosT2 RegistroT2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroT1 = null;
			RegistroT1 = new ACBrPAFRegistroT1();
			RegistroT2.Clear();
		}

		public bool SaveFileTXT_T(string arquivo)
		{
			int i;

			ACBrPAFInterop.RegistroHD1Rec RegistroT1Rec = new ACBrPAFInterop.RegistroHD1Rec();
			ACBrPAFInterop.RegistroT2Rec[] RegistroT2Rec = new ACBrPAFInterop.RegistroT2Rec[RegistroT2.Count];

			RegistroT1Rec.RAZAOSOCIAL = ToUTF8(RegistroT1.RazaoSocial);
			RegistroT1Rec.CNPJ = ToUTF8(RegistroT1.CNPJ);
			RegistroT1Rec.UF = ToUTF8(RegistroT1.UF);
			RegistroT1Rec.IE = ToUTF8(RegistroT1.IE);
			RegistroT1Rec.IM = ToUTF8(RegistroT1.IM);

			for (i = 0; i < RegistroT2.Count; i++)
			{
				RegistroT2Rec[i].DT_MOV = RegistroT2[i].DT_MOV.ToOADate();
				RegistroT2Rec[i].TP_DOCTO = ToUTF8(RegistroT2[i].TP_DOCTO);
				RegistroT2Rec[i].SERIE = ToUTF8(RegistroT2[i].SERIE);
				RegistroT2Rec[i].NUM_BILH_I = RegistroT2[i].NUM_BILH_I;
				RegistroT2Rec[i].NUM_BILH_F = RegistroT2[i].NUM_BILH_F;
				RegistroT2Rec[i].NUM_ECF = ToUTF8(RegistroT2[i].NUM_ECF);
				RegistroT2Rec[i].CRZ = RegistroT2[i].CRZ;
				RegistroT2Rec[i].CFOP = ToUTF8(RegistroT2[i].CFOP);
				RegistroT2Rec[i].VL_CONT = RegistroT2[i].VL_CONT;
				RegistroT2Rec[i].VL_BASECALC = RegistroT2[i].VL_BASECALC;
				RegistroT2Rec[i].ALIQ = RegistroT2[i].ALIQ;
				RegistroT2Rec[i].VL_IMPOSTO = RegistroT2[i].VL_IMPOSTO;
				RegistroT2Rec[i].VL_ISENTAS = RegistroT2[i].VL_ISENTAS;
				RegistroT2Rec[i].VL_OUTRAS = RegistroT2[i].VL_OUTRAS;
				RegistroT2Rec[i].RegistroValido = RegistroT2[i].RegistroValido;
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_T(this.Handle, RegistroT1Rec, RegistroT2Rec, RegistroT2.Count, ToUTF8(arquivo));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Methods
	}
}