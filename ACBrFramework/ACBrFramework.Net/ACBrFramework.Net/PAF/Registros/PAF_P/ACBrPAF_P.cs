using System;
using System.ComponentModel;

namespace ACBrFramework
{
	public sealed class ACBrPAF_P : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_P(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroP1 = new ACBrPAFRegistroP1();
			this.RegistroP2 = new ACBrPAFRegistrosP2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroP1 RegistroP1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosP2 RegistroP2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroP1 = null;
			RegistroP1 = new ACBrPAFRegistroP1();
			RegistroP2.Clear();
		}

		public bool SaveFileTXT_P(string arquivo)
		{
			int i;

			ACBrPAFInterop.RegistroHD1Rec RegistroP1Rec = new ACBrPAFInterop.RegistroHD1Rec();
			ACBrPAFInterop.RegistroP2Rec[] RegistroP2Rec = new ACBrPAFInterop.RegistroP2Rec[RegistroP2.Count];

			RegistroP1Rec.RAZAOSOCIAL = RegistroP1.RazaoSocial;
			RegistroP1Rec.CNPJ = RegistroP1.CNPJ;
			RegistroP1Rec.UF = RegistroP1.UF;
			RegistroP1Rec.IE = RegistroP1.IE;
			RegistroP1Rec.IM = RegistroP1.IM;

			for (i = 0; i < RegistroP2.Count; i++)
			{
				RegistroP2Rec[i].COD_MERC_SERV = RegistroP2[i].COD_MERC_SERV;
				RegistroP2Rec[i].DESC_MERC_SERV = RegistroP2[i].DESC_MERC_SERV;
				RegistroP2Rec[i].UN_MED = RegistroP2[i].UN_MED;
				RegistroP2Rec[i].IAT = RegistroP2[i].IAT;
				RegistroP2Rec[i].IPPT = RegistroP2[i].IPPT;
				RegistroP2Rec[i].ST = RegistroP2[i].ST;
				RegistroP2Rec[i].ALIQ = Convert.ToDouble(RegistroP2[i].ALIQ);
				RegistroP2Rec[i].VL_UNIT = Convert.ToDouble(RegistroP2[i].VL_UNIT);
				RegistroP2Rec[i].RegistroValido = RegistroP2[i].RegistroValido;
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_P(this.Handle, RegistroP1Rec, RegistroP2Rec, RegistroP2.Count, ToUTF8(arquivo));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Methods
	}
}