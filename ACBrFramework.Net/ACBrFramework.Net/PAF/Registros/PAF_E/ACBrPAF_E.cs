using System;
using System.ComponentModel;

namespace ACBrFramework
{
	public sealed class ACBrPAF_E : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_E(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroE1 = new ACBrPAFRegistroE1();
			this.RegistroE2 = new ACBrPAFRegistrosE2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroE1 RegistroE1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosE2 RegistroE2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroE1 = null;
			RegistroE1 = new ACBrPAFRegistroE1();
			RegistroE2.Clear();
		}

		public bool SaveFileTXT_E(string arquivo)
		{
			int i;

			ACBrPAFInterop.RegistroHD2Rec RegistroE1Rec = new ACBrPAFInterop.RegistroHD2Rec();
			ACBrPAFInterop.RegistroE2Rec[] RegistroE2Rec = new ACBrPAFInterop.RegistroE2Rec[RegistroE2.Count];

			RegistroE1Rec.RAZAOSOCIAL = ToUTF8(RegistroE1.RazaoSocial);
			RegistroE1Rec.CNPJ = ToUTF8(RegistroE1.CNPJ);
			RegistroE1Rec.UF = ToUTF8(RegistroE1.UF);
			RegistroE1Rec.IE = ToUTF8(RegistroE1.IE);
			RegistroE1Rec.IM = ToUTF8(RegistroE1.IM);
			RegistroE1Rec.NUM_FAB = ToUTF8(RegistroE1.NUM_FAB);
			RegistroE1Rec.MF_ADICIONAL = ToUTF8(RegistroE1.MF_ADICIONAL);
			RegistroE1Rec.TIPO_ECF = ToUTF8(RegistroE1.TIPO_ECF);
			RegistroE1Rec.MARCA_ECF = ToUTF8(RegistroE1.MARCA_ECF);
			RegistroE1Rec.MODELO_ECF = ToUTF8(RegistroE1.NUM_FAB);
			RegistroE1Rec.DT_EST = RegistroE1.DT_EST.ToOADate();
			RegistroE1Rec.RegistroValido = RegistroE1.RegistroValido;
			RegistroE1Rec.InclusaoExclusao = RegistroE1.InclusaoExclusao;

			for (i = 0; i < RegistroE2.Count; i++)
			{
				RegistroE2Rec[i].COD_MERC = ToUTF8(RegistroE2[i].COD_MERC);
				RegistroE2Rec[i].DESC_MERC = ToUTF8(RegistroE2[i].DESC_MERC);
				RegistroE2Rec[i].UN_MED = ToUTF8(RegistroE2[i].UN_MED);
				RegistroE2Rec[i].QTDE_EST = Convert.ToDouble(RegistroE2[i].QTDE_EST);
				RegistroE2Rec[i].RegistroValido = RegistroE2[i].RegistroValido;
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_E(this.Handle, RegistroE1Rec, RegistroE2Rec, RegistroE2.Count, ToUTF8(arquivo));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Methods
	}
}