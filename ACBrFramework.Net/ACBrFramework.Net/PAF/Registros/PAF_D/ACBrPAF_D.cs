using System;
using System.ComponentModel;

namespace ACBrFramework
{
	public sealed class ACBrPAF_D : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_D(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroD1 = new ACBrPAFRegistroD1();
			this.RegistroD2 = new ACBrPAFRegistrosD2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroD1 RegistroD1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosD2 RegistroD2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroD1 = null;
			RegistroD1 = new ACBrPAFRegistroD1();
			RegistroD2.Clear();
		}

		public bool SaveFileTXT_D(string arquivo)
		{
			int i, ItemIndex = 0;
			int D3 = 0;

			foreach (ACBrPAFRegistroD2 D2 in RegistroD2)
			{
				D3 += D2.RegistroD3.Count;
			}

			ACBrPAFInterop.RegistroHD1Rec RegistroD1Rec = new ACBrPAFInterop.RegistroHD1Rec();
			ACBrPAFInterop.RegistroD2Rec[] RegistroD2Rec = new ACBrPAFInterop.RegistroD2Rec[RegistroD2.Count];
			ACBrPAFInterop.RegistroD3Rec[] RegistroD3Rec = new ACBrPAFInterop.RegistroD3Rec[D3];

			RegistroD1Rec.RAZAOSOCIAL = ToUTF8(RegistroD1.RazaoSocial);
			RegistroD1Rec.CNPJ = ToUTF8(RegistroD1.CNPJ);
			RegistroD1Rec.UF = ToUTF8(RegistroD1.UF);
			RegistroD1Rec.IE = ToUTF8(RegistroD1.IE);
			RegistroD1Rec.IM = ToUTF8(RegistroD1.IM);

			for (i = 0; i < RegistroD2.Count; i++)
			{
				RegistroD2Rec[i].QTD_D3 = RegistroD2[i].RegistroD3.Count;
				RegistroD2Rec[i].NUM_FAB = ToUTF8(RegistroD2[i].NUM_FAB);
				RegistroD2Rec[i].MF_ADICIONAL = ToUTF8(RegistroD2[i].MF_ADICIONAL);
				RegistroD2Rec[i].TIPO_ECF = ToUTF8(RegistroD2[i].TIPO_ECF);
				RegistroD2Rec[i].MARCA_ECF = ToUTF8(RegistroD2[i].MARCA_ECF);
				RegistroD2Rec[i].MODELO_ECF = ToUTF8(RegistroD2[i].MODELO_ECF);
				RegistroD2Rec[i].COO = ToUTF8(RegistroD2[i].COO);
				RegistroD2Rec[i].NUM_DAV = ToUTF8(RegistroD2[i].NUM_DAV);
				RegistroD2Rec[i].DT_DAV = RegistroD2[i].DT_DAV.ToOADate();
				RegistroD2Rec[i].TIT_DAV = ToUTF8(RegistroD2[i].TIT_DAV);
				RegistroD2Rec[i].VLT_DAV = Convert.ToDouble(RegistroD2[i].VLT_DAV);
				RegistroD2Rec[i].COO_DFV = ToUTF8(RegistroD2[i].COO_DFV);
				RegistroD2Rec[i].NUMERO_ECF = ToUTF8(RegistroD2[i].NUMERO_ECF);
				RegistroD2Rec[i].NOME_CLIENTE = ToUTF8(RegistroD2[i].NOME_CLIENTE);
				RegistroD2Rec[i].CPF_CNPJ = ToUTF8(RegistroD2[i].CPF_CNPJ);
				RegistroD2Rec[i].RegistroValido = RegistroD2[i].RegistroValido;

				foreach (ACBrPAFRegistroD3 RegistroD3 in RegistroD2[i].RegistroD3)
				{
					RegistroD3Rec[ItemIndex].DT_INCLUSAO = RegistroD3.DT_INCLUSAO.ToOADate();
					RegistroD3Rec[ItemIndex].NUM_ITEM = RegistroD3.NUM_ITEM;
					RegistroD3Rec[ItemIndex].COD_ITEM = ToUTF8(RegistroD3.COD_ITEM);
					RegistroD3Rec[ItemIndex].DESC_ITEM = ToUTF8(RegistroD3.DESC_ITEM);
					RegistroD3Rec[ItemIndex].QTDE_ITEM = Convert.ToDouble(RegistroD3.QTDE_ITEM);
					RegistroD3Rec[ItemIndex].UNI_ITEM = ToUTF8(RegistroD3.UNI_ITEM);
					RegistroD3Rec[ItemIndex].VL_UNIT = Convert.ToDouble(RegistroD3.VL_UNIT);
					RegistroD3Rec[ItemIndex].VL_DESCTO = Convert.ToDouble(RegistroD3.VL_DESCTO);
					RegistroD3Rec[ItemIndex].VL_ACRES = Convert.ToDouble(RegistroD3.VL_ACRES);
					RegistroD3Rec[ItemIndex].VL_TOTAL = Convert.ToDouble(RegistroD3.VL_TOTAL);
					RegistroD3Rec[ItemIndex].DEC_VL_UNIT = RegistroD3.DEC_VL_UNIT;
					RegistroD3Rec[ItemIndex].DEC_QTDE_ITEM = RegistroD3.DEC_QTDE_ITEM;
					RegistroD3Rec[ItemIndex].SIT_TRIB = ToUTF8(RegistroD3.SIT_TRIB);
					RegistroD3Rec[ItemIndex].ALIQ = Convert.ToDouble(RegistroD3.ALIQ);
					RegistroD3Rec[ItemIndex].IND_CANC = ToUTF8(RegistroD3.IND_CANC);
					RegistroD3Rec[ItemIndex].RegistroValido = RegistroD3.RegistroValido;
					ItemIndex++;
				}
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_D(this.Handle, RegistroD1Rec, RegistroD2Rec, RegistroD2.Count, RegistroD3Rec, ToUTF8(arquivo));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Methods
	}
}