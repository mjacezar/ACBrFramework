using System;
using System.ComponentModel;

namespace ACBrFramework
{
	public sealed class ACBrPAF_N : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_N(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroN1 = new ACBrPAFRegistroN1();
			this.RegistroN2 = new ACBrPAFRegistroN2();
			this.RegistroN3 = new ACBrPAFRegistrosN3();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroN1 RegistroN1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistroN2 RegistroN2 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosN3 RegistroN3 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroN1 = null;
			RegistroN1 = new ACBrPAFRegistroN1();
			RegistroN2 = null;
			RegistroN2 = new ACBrPAFRegistroN2();
			RegistroN3.Clear();
		}

		public bool SaveFileTXT_N(string arquivo)
		{
			int i;

			ACBrPAFInterop.RegistroHD1Rec RegistroN1Rec = new ACBrPAFInterop.RegistroHD1Rec();
			ACBrPAFInterop.RegistroN2Rec RegistroN2Rec = new ACBrPAFInterop.RegistroN2Rec();
			ACBrPAFInterop.RegistroN3Rec[] RegistroN3Rec = new ACBrPAFInterop.RegistroN3Rec[RegistroN3.Count];

			RegistroN1Rec.RAZAOSOCIAL = ToUTF8(RegistroN1.RazaoSocial);
			RegistroN1Rec.CNPJ = ToUTF8(RegistroN1.CNPJ);
			RegistroN1Rec.UF = ToUTF8(RegistroN1.UF);
			RegistroN1Rec.IE = ToUTF8(RegistroN1.IE);
			RegistroN1Rec.IM = ToUTF8(RegistroN1.IM);

			RegistroN2Rec.QTD_N3 = RegistroN3.Count;
			RegistroN2Rec.NOME = ToUTF8(RegistroN2.NOME);
			RegistroN2Rec.LAUDO = ToUTF8(RegistroN2.LAUDO);
			RegistroN2Rec.VERSAO = ToUTF8(RegistroN2.VERSAO);

			for (i = 0; i < RegistroN3.Count; i++)
			{
				RegistroN3Rec[i].NOME_ARQUIVO = ToUTF8(RegistroN3[i].NOME_ARQUIVO);
				RegistroN3Rec[i].MD5 = ToUTF8(RegistroN3[i].MD5);
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_N(this.Handle, RegistroN1Rec, RegistroN2Rec, RegistroN3Rec, ToUTF8(arquivo));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Methods
	}
}