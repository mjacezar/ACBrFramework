using System;
using System.ComponentModel;

namespace ACBrFramework
{
	public sealed class ACBrPAF_R : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_R(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroR1 = new ACBrPAFRegistroR1();
			this.RegistroR2 = new ACBrPAFRegistrosR2();
			this.RegistroR4 = new ACBrPAFRegistrosR4();
			this.RegistroR6 = new ACBrPAFRegistrosR6();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroR1 RegistroR1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosR2 RegistroR2 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosR4 RegistroR4 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosR6 RegistroR6 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroR1 = null;
			RegistroR1 = new ACBrPAFRegistroR1();
			RegistroR2.Clear();
			RegistroR4.Clear();
			RegistroR6.Clear();
		}

		public bool SaveFileTXT_R(string arquivo)
		{
			int i, ItemR3 = 0, ItemR5 = 0, ItemR7 = 0, R3 = 0, R5 = 0, R7 = 0;

			#region Contadores

			foreach (ACBrPAFRegistroR2 R2 in RegistroR2)
			{
				R3 += R2.RegistroR3.Count;
			}

			foreach (ACBrPAFRegistroR4 R4 in RegistroR4)
			{
				R5 += R4.RegistroR5.Count;
				R7 += R4.RegistroR7.Count;
			}

			foreach (ACBrPAFRegistroR6 R6 in RegistroR6)
			{
				R7 += R6.RegistroR7.Count;
			}

			#endregion Contadores

			ACBrPAFInterop.RegistroR1Rec RegistroR1Rec = new ACBrPAFInterop.RegistroR1Rec();
			ACBrPAFInterop.RegistroR2Rec[] RegistroR2Rec = new ACBrPAFInterop.RegistroR2Rec[RegistroR2.Count];
			ACBrPAFInterop.RegistroR3Rec[] RegistroR3Rec = new ACBrPAFInterop.RegistroR3Rec[R3];
			ACBrPAFInterop.RegistroR4Rec[] RegistroR4Rec = new ACBrPAFInterop.RegistroR4Rec[RegistroR4.Count];
			ACBrPAFInterop.RegistroR5Rec[] RegistroR5Rec = new ACBrPAFInterop.RegistroR5Rec[R5];
			ACBrPAFInterop.RegistroR6Rec[] RegistroR6Rec = new ACBrPAFInterop.RegistroR6Rec[RegistroR6.Count];
			ACBrPAFInterop.RegistroR7Rec[] RegistroR7Rec = new ACBrPAFInterop.RegistroR7Rec[R7];

			RegistroR1Rec.NUM_FAB = ToUTF8(RegistroR1.NUM_FAB);
			RegistroR1Rec.MF_ADICIONAL = ToUTF8(RegistroR1.MF_ADICIONAL);
			RegistroR1Rec.TIPO_ECF = ToUTF8(RegistroR1.TIPO_ECF);
			RegistroR1Rec.MARCA_ECF = ToUTF8(RegistroR1.MARCA_ECF);
			RegistroR1Rec.MODELO_ECF = ToUTF8(RegistroR1.MODELO_ECF);
			RegistroR1Rec.VERSAO_SB = ToUTF8(RegistroR1.VERSAO_SB);
			RegistroR1Rec.DT_INST_SB = RegistroR1.DT_INST_SB.ToOADate();
			RegistroR1Rec.HR_INST_SB = RegistroR1.HR_INST_SB.ToOADate();
			RegistroR1Rec.NUM_SEQ_ECF = RegistroR1.NUM_SEQ_ECF;
			RegistroR1Rec.CNPJ = ToUTF8(RegistroR1.CNPJ);
			RegistroR1Rec.IE = ToUTF8(RegistroR1.IE);
			RegistroR1Rec.CNPJ_SH = ToUTF8(RegistroR1.CNPJ_SH);
			RegistroR1Rec.IE_SH = ToUTF8(RegistroR1.IE_SH);
			RegistroR1Rec.IM_SH = ToUTF8(RegistroR1.IM_SH);
			RegistroR1Rec.NOME_SH = ToUTF8(RegistroR1.NOME_SH);
			RegistroR1Rec.NOME_PAF = ToUTF8(RegistroR1.NOME_PAF);
			RegistroR1Rec.VER_PAF = ToUTF8(RegistroR1.VER_PAF);
			RegistroR1Rec.COD_MD5 = ToUTF8(RegistroR1.COD_MD5);
			RegistroR1Rec.DT_INI = RegistroR1.DT_INI.ToOADate();
			RegistroR1Rec.DT_FIN = RegistroR1.DT_FIN.ToOADate();
			RegistroR1Rec.ER_PAF_ECF = ToUTF8(RegistroR1.ER_PAF_ECF);
			RegistroR1Rec.InclusaoExclusao = RegistroR1.InclusaoExclusao;
			RegistroR1Rec.RegistroValido = RegistroR1.RegistroValido;

			//R2 e R3
			for (i = 0; i < RegistroR2.Count; i++)
			{
				RegistroR2Rec[i].QTD_R3 = RegistroR2[i].RegistroR3.Count;
				RegistroR2Rec[i].NUM_USU = RegistroR2[i].NUM_USU;
				RegistroR2Rec[i].CRZ = RegistroR2[i].CRZ;
				RegistroR2Rec[i].COO = RegistroR2[i].COO;
				RegistroR2Rec[i].CRO = RegistroR2[i].CRO;
				RegistroR2Rec[i].DT_MOV = RegistroR2[i].DT_MOV.ToOADate();
				RegistroR2Rec[i].DT_EMI = RegistroR2[i].DT_EMI.ToOADate();
				RegistroR2Rec[i].HR_EMI = Convert.ToDouble(RegistroR2[i].HR_EMI);
				RegistroR2Rec[i].VL_VBD = Convert.ToDouble(RegistroR2[i].VL_VBD);
				RegistroR2Rec[i].PAR_ECF = ToUTF8(RegistroR2[i].PAR_ECF);
				RegistroR2Rec[i].RegistroValido = RegistroR2[i].RegistroValido;

				foreach (ACBrPAFRegistroR3 RegistroR3 in RegistroR2[i].RegistroR3)
				{
					RegistroR3Rec[ItemR3].TOT_PARCIAL = ToUTF8(RegistroR3.TOT_PARCIAL);
					RegistroR3Rec[ItemR3].VL_ACUM = Convert.ToDouble(RegistroR3.VL_ACUM);
					RegistroR3Rec[ItemR3].RegistroValido = RegistroR3.RegistroValido;
					ItemR3++;
				}
			}

			//R4, R5 e R7
			for (i = 0; i < RegistroR4.Count; i++)
			{
				RegistroR4Rec[i].QTD_R5 = RegistroR4[i].RegistroR5.Count;
				RegistroR4Rec[i].QTD_R7 = RegistroR4[i].RegistroR7.Count;
				RegistroR4Rec[i].NUM_USU = RegistroR4[i].NUM_USU;
				RegistroR4Rec[i].NUM_CONT = RegistroR4[i].NUM_CONT;
				RegistroR4Rec[i].COO = RegistroR4[i].COO;
				RegistroR4Rec[i].DT_INI = RegistroR4[i].DT_INI.ToOADate();
				RegistroR4Rec[i].SUB_DOCTO = Convert.ToDouble(RegistroR4[i].SUB_DOCTO);
				RegistroR4Rec[i].SUB_DESCTO = Convert.ToDouble(RegistroR4[i].SUB_DESCTO);
				RegistroR4Rec[i].TP_DESCTO = ToUTF8(RegistroR4[i].TP_DESCTO);
				RegistroR4Rec[i].SUB_ACRES = Convert.ToDouble(RegistroR4[i].SUB_ACRES);
				RegistroR4Rec[i].TP_ACRES = ToUTF8(RegistroR4[i].TP_ACRES);
				RegistroR4Rec[i].VL_TOT = Convert.ToDouble(RegistroR4[i].VL_TOT);
				RegistroR4Rec[i].CANC = ToUTF8(RegistroR4[i].CANC);
				RegistroR4Rec[i].VL_CA = Convert.ToDouble(RegistroR4[i].VL_CA);
				RegistroR4Rec[i].ORDEM_DA = ToUTF8(RegistroR4[i].ORDEM_DA);
				RegistroR4Rec[i].NOME_CLI = ToUTF8(RegistroR4[i].NOME_CLI);
				RegistroR4Rec[i].CNPJ_CPF = ToUTF8(RegistroR4[i].CNPJ_CPF);
				RegistroR4Rec[i].RegistroValido = RegistroR4[i].RegistroValido;

				foreach (ACBrPAFRegistroR5 RegistroR5 in RegistroR4[i].RegistroR5)
				{
					RegistroR5Rec[ItemR5].NUM_ITEM = RegistroR5.NUM_ITEM;
					RegistroR5Rec[ItemR5].COD_ITEM = ToUTF8(RegistroR5.COD_ITEM);
					RegistroR5Rec[ItemR5].DESC_ITEM = ToUTF8(RegistroR5.DESC_ITEM);
					RegistroR5Rec[ItemR5].QTDE_ITEM = Convert.ToDouble(RegistroR5.QTDE_ITEM);
					RegistroR5Rec[ItemR5].UN_MED = ToUTF8(RegistroR5.UN_MED);
					RegistroR5Rec[ItemR5].VL_UNIT = Convert.ToDouble(RegistroR5.VL_UNIT);
					RegistroR5Rec[ItemR5].DESCTO_ITEM = Convert.ToDouble(RegistroR5.DESCTO_ITEM);
					RegistroR5Rec[ItemR5].ACRES_ITEM = Convert.ToDouble(RegistroR5.ACRES_ITEM);
					RegistroR5Rec[ItemR5].VL_TOT_ITEM = Convert.ToDouble(RegistroR5.VL_TOT_ITEM);
					RegistroR5Rec[ItemR5].COD_TOT_PARC = ToUTF8(RegistroR5.COD_TOT_PARC);
					RegistroR5Rec[ItemR5].IND_CANC = ToUTF8(RegistroR5.IND_CANC);
					RegistroR5Rec[ItemR5].QTDE_CANC = Convert.ToDouble(RegistroR5.QTDE_CANC);
					RegistroR5Rec[ItemR5].VL_CANC = Convert.ToDouble(RegistroR5.VL_CANC);
					RegistroR5Rec[ItemR5].VL_CANC_ACRES = Convert.ToDouble(RegistroR5.VL_CANC_ACRES);
					RegistroR5Rec[ItemR5].IAT = ToUTF8(RegistroR5.IAT);
					RegistroR5Rec[ItemR5].IPPT = ToUTF8(RegistroR5.IPPT);
					RegistroR5Rec[ItemR5].QTDE_DECIMAL = RegistroR5.QTDE_DECIMAL;
					RegistroR5Rec[ItemR5].VL_DECIMAL = RegistroR5.VL_DECIMAL;
					RegistroR5Rec[ItemR5].RegistroValido = RegistroR5.RegistroValido;
					ItemR5++;
				}

				foreach (ACBrPAFRegistroR7 RegistroR7 in RegistroR4[i].RegistroR7)
				{
					RegistroR7Rec[ItemR7].CCF = RegistroR7.CCF;
					RegistroR7Rec[ItemR7].GNF = RegistroR7.GNF;
					RegistroR7Rec[ItemR7].MP = ToUTF8(RegistroR7.MP);
					RegistroR7Rec[ItemR7].VL_PAGTO = Convert.ToDouble(RegistroR7.VL_PAGTO);
					RegistroR7Rec[ItemR7].IND_EST = ToUTF8(RegistroR7.IND_EST);
					RegistroR7Rec[ItemR7].VL_EST = Convert.ToDouble(RegistroR7.VL_EST);
					RegistroR7Rec[ItemR7].RegistroValido = RegistroR7.RegistroValido;
					ItemR7++;
				}
			}

			//R6 e R7
			for (i = 0; i < RegistroR6.Count; i++)
			{
				RegistroR6Rec[i].QTD_R7 = RegistroR6[i].RegistroR7.Count;
				RegistroR6Rec[i].NUM_USU = RegistroR6[i].NUM_USU;
				RegistroR6Rec[i].COO = RegistroR6[i].COO;
				RegistroR6Rec[i].GNF = RegistroR6[i].GNF;
				RegistroR6Rec[i].GRG = RegistroR6[i].GRG;
				RegistroR6Rec[i].CDC = RegistroR6[i].CDC;
				RegistroR6Rec[i].DENOM = ToUTF8(RegistroR6[i].DENOM);
				RegistroR6Rec[i].DT_FIN = RegistroR6[i].DT_FIN.ToOADate();
				RegistroR6Rec[i].HR_FIN = RegistroR6[i].HR_FIN.ToOADate();
				RegistroR6Rec[i].RegistroValido = RegistroR6[i].RegistroValido;

				foreach (ACBrPAFRegistroR7 RegistroR7 in RegistroR6[i].RegistroR7)
				{
					RegistroR7Rec[ItemR7].CCF = RegistroR7.CCF;
					RegistroR7Rec[ItemR7].GNF = RegistroR7.GNF;
					RegistroR7Rec[ItemR7].MP = ToUTF8(RegistroR7.MP);
					RegistroR7Rec[ItemR7].VL_PAGTO = Convert.ToDouble(RegistroR7.VL_PAGTO);
					RegistroR7Rec[ItemR7].IND_EST = ToUTF8(RegistroR7.IND_EST);
					RegistroR7Rec[ItemR7].VL_EST = Convert.ToDouble(RegistroR7.VL_EST);
					RegistroR7Rec[ItemR7].RegistroValido = RegistroR7.RegistroValido;
					ItemR7++;
				}
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_R(this.Handle, RegistroR1Rec, RegistroR2Rec, RegistroR2.Count, RegistroR3Rec, RegistroR4Rec, RegistroR4.Count, RegistroR5Rec, RegistroR6Rec, RegistroR6.Count, RegistroR7Rec, ToUTF8(arquivo));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Methods
	}
}