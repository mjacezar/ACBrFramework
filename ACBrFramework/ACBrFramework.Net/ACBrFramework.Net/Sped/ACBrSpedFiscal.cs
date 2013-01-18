using System;
using System.ComponentModel;
using System.Drawing;

namespace ACBrFramework.Sped
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.Sped.ico.bmp")]
	public class ACBrSpedFiscal : ACBrComponent, IDisposable
	{
		#region Properties

		[Category("Geral")]
		public string About
		{
			get
			{
				return GetAbout(ACBrSpedFiscalInterop.SPDF_GetAbout);
			}
		}

		[Category("Geral")]
		public string Arquivo
		{
			get
			{
				return GetString(ACBrSpedFiscalInterop.SPDF_GetArquivo);
			}
			set
			{
				SetString(ACBrSpedFiscalInterop.SPDF_SetArquivo, value);
			}
		}

		[Category("Geral")]
		public string CurMascara
		{
			get
			{
				return GetString(ACBrSpedFiscalInterop.SPDF_GetCurMascara);
			}
			set
			{
				SetString(ACBrSpedFiscalInterop.SPDF_SetCurMascara, value);
			}
		}

		[Category("Geral")]
		public string Path
		{
			get
			{
				return GetString(ACBrSpedFiscalInterop.SPDF_GetPath);
			}
			set
			{
				SetString(ACBrSpedFiscalInterop.SPDF_SetPath, value);
			}
		}

		[Category("Geral")]
		public string Delimitador
		{
			get
			{
				return GetString(ACBrSpedFiscalInterop.SPDF_GetDelimitador);
			}
			set
			{
				SetString(ACBrSpedFiscalInterop.SPDF_SetDelimitador, value);
			}
		}

		[Category("Geral")]
		public int LinhasBuffer
		{
			get
			{
				return GetInt32(ACBrSpedFiscalInterop.SPDF_GetLinhasBuffer);
			}
			set
			{
				SetInt32(ACBrSpedFiscalInterop.SPDF_SetLinhasBuffer, value);
			}
		}

		[Category("Geral")]
		public Boolean TrimString
		{
			get
			{
				return GetBool(ACBrSpedFiscalInterop.SPDF_GetTrimString);
			}
			set
			{
				SetBool(ACBrSpedFiscalInterop.SPDF_SetTrimString, value);
			}
		}

		[Browsable(false)]
		public DateTime DT_INI
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_GetDT_INI);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_SetDT_INI, value);
			}
		}

		[Browsable(false)]
		public DateTime DT_FIN
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_GetDT_FIN);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_SetDT_FIN, value);
			}
		}

		[Browsable(false)]
		public Bloco0 Bloco_0 { get; private set; }

		[Browsable(false)]
		public Bloco1 Bloco_1 { get; private set; }

		[Browsable(false)]
		public Bloco9 Bloco_9 { get; private set; }

		[Browsable(false)]
		public BlocoC Bloco_C { get; private set; }

		[Browsable(false)]
		public BlocoD Bloco_D { get; private set; }

		[Browsable(false)]
		public BlocoE Bloco_E { get; private set; }

		[Browsable(false)]
		public BlocoG Bloco_G { get; private set; }

		[Browsable(false)]
		public BlocoH Bloco_H { get; private set; }

		#endregion Properties

		#region Methods

		public void IniciaGeracao()
		{
			int ret = ACBrSpedFiscalInterop.SPDF_IniciaGeracao(this.Handle);
			CheckResult(ret);
		}

		#region Bloco0 Interop

		private void SendBloco0()
		{
			SendRegistro0000();
			SendRegistro0001();
		}

		private void SendRegistro0000()
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0000();
			record.COD_VER = (int)Bloco_0.Registro0000.COD_VER;
			record.COD_FIN = (int)Bloco_0.Registro0000.COD_FIN;
			record.DT_INI = Bloco_0.Registro0000.DT_INI.ToOADate();
			record.DT_FIN = Bloco_0.Registro0000.DT_FIN.ToOADate();
			record.NOME = ToUTF8(Bloco_0.Registro0000.NOME);
			record.CNPJ = ToUTF8(Bloco_0.Registro0000.CNPJ);
			record.CPF = ToUTF8(Bloco_0.Registro0000.CPF);
			record.UF = ToUTF8(Bloco_0.Registro0000.UF);
			record.IE = ToUTF8(Bloco_0.Registro0000.IE);
			record.COD_MUN = ToUTF8(Bloco_0.Registro0000.COD_MUN);
			record.IM = ToUTF8(Bloco_0.Registro0000.IM);
			record.SUFRAMA = ToUTF8(Bloco_0.Registro0000.SUFRAMA);
			record.IND_PERFIL = (int)Bloco_0.Registro0000.IND_PERFIL;
			record.IND_ATIV = (int)Bloco_0.Registro0000.IND_ATIV;

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0000New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0001()
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0001();
			record.IND_MOV = (int)Bloco_0.Registro0001.IND_MOV;

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0001New(this.Handle, record);
			CheckResult(ret);

			SendRegistro0005();

			foreach (var item in Bloco_0.Registro0001.Registro0015)
			{
				SendRegistro0015(item);
			}

			SendRegistro0100();

			foreach (var item in Bloco_0.Registro0001.Registro0150)
			{
				SendRegistro0150(item);
			}

			foreach (var item in Bloco_0.Registro0001.Registro0190)
			{
				SendRegistro0190(item);
			}

			foreach (var item in Bloco_0.Registro0001.Registro0200)
			{
				SendRegistro0200(item);
			}

			foreach (var item in Bloco_0.Registro0001.Registro0300)
			{
				SendRegistro0300(item);
			}

			foreach (var item in Bloco_0.Registro0001.Registro0400)
			{
				SendRegistro0400(item);
			}

			foreach (var item in Bloco_0.Registro0001.Registro0450)
			{
				SendRegistro0450(item);
			}

			foreach (var item in Bloco_0.Registro0001.Registro0460)
			{
				SendRegistro0460(item);
			}

			foreach (var item in Bloco_0.Registro0001.Registro0500)
			{
				SendRegistro0500(item);
			}

			foreach (var item in Bloco_0.Registro0001.Registro0600)
			{
				SendRegistro0600(item);
			}
		}

		private void SendRegistro0005()
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0005();
			record.FANTASIA = ToUTF8(Bloco_0.Registro0001.Registro0005.FANTASIA);
			record.CEP = ToUTF8(Bloco_0.Registro0001.Registro0005.CEP);
			record.ENDERECO = ToUTF8(Bloco_0.Registro0001.Registro0005.ENDERECO);
			record.NUM = ToUTF8(Bloco_0.Registro0001.Registro0005.NUM);
			record.COMPL = ToUTF8(Bloco_0.Registro0001.Registro0005.COMPL);
			record.BAIRRO = ToUTF8(Bloco_0.Registro0001.Registro0005.BAIRRO);
			record.FONE = ToUTF8(Bloco_0.Registro0001.Registro0005.FONE);
			record.FAX = ToUTF8(Bloco_0.Registro0001.Registro0005.FAX);
			record.EMAIL = ToUTF8(Bloco_0.Registro0001.Registro0005.EMAIL);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0005New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0015(Registro0015 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0015();
			record.UF_ST = item.UF_ST;
			record.IE_ST = item.IE_ST;

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0015New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0100()
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0100();
			record.NOME = ToUTF8(Bloco_0.Registro0001.Registro0100.NOME);
			record.CPF = ToUTF8(Bloco_0.Registro0001.Registro0100.CPF);
			record.CRC = ToUTF8(Bloco_0.Registro0001.Registro0100.CRC);
			record.CNPJ = ToUTF8(Bloco_0.Registro0001.Registro0100.CNPJ);
			record.CEP = ToUTF8(Bloco_0.Registro0001.Registro0100.CEP);
			record.ENDERECO = ToUTF8(Bloco_0.Registro0001.Registro0100.ENDERECO);
			record.NUM = ToUTF8(Bloco_0.Registro0001.Registro0100.NUM);
			record.COMPL = ToUTF8(Bloco_0.Registro0001.Registro0100.COMPL);
			record.BAIRRO = ToUTF8(Bloco_0.Registro0001.Registro0100.BAIRRO);
			record.FONE = ToUTF8(Bloco_0.Registro0001.Registro0100.FONE);
			record.FAX = ToUTF8(Bloco_0.Registro0001.Registro0100.FAX);
			record.EMAIL = ToUTF8(Bloco_0.Registro0001.Registro0100.EMAIL);
			record.COD_MUN = Bloco_0.Registro0001.Registro0100.COD_MUN;

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0100New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0150(Registro0150 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0150();
			record.COD_PART = ToUTF8(item.COD_PART);
			record.NOME = ToUTF8(item.NOME);
			record.COD_PAIS = ToUTF8(item.COD_PAIS);
			record.CNPJ = ToUTF8(item.CNPJ);
			record.CPF = ToUTF8(item.CPF);
			record.IE = ToUTF8(item.IE);
			record.COD_MUN = item.COD_MUN;
			record.SUFRAMA = ToUTF8(item.SUFRAMA);
			record.ENDERECO = ToUTF8(item.ENDERECO);
			record.NUM = ToUTF8(item.NUM);
			record.COMPL = ToUTF8(item.COMPL);
			record.BAIRRO = ToUTF8(item.BAIRRO);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0150New(this.Handle, record);
			CheckResult(ret);

			foreach (var item0175 in item.Registro0175)
			{
				SendRegistro0175(item0175);
			}
		}

		private void SendRegistro0175(Registro0175 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0175();
			record.DT_ALT = item.DT_ALT.ToOADate();
			record.NR_CAMPO = ToUTF8(item.NR_CAMPO);
			record.CONT_ANT = ToUTF8(item.CONT_ANT);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0175New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0190(Registro0190 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0190();
			record.UNID = ToUTF8(item.UNID);
			record.DESCR = ToUTF8(item.DESCR);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0190New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0200(Registro0200 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0200();
			record.COD_ITEM = ToUTF8(item.COD_ITEM);
			record.DESCR_ITEM = ToUTF8(item.DESCR_ITEM);
			record.COD_BARRA = ToUTF8(item.COD_BARRA);
			record.COD_ANT_ITEM = ToUTF8(item.COD_ANT_ITEM);
			record.UNID_INV = ToUTF8(item.UNID_INV);
			record.TIPO_ITEM = (int)item.TIPO_ITEM;
			record.COD_NCM = ToUTF8(item.COD_NCM);
			record.EX_IPI = ToUTF8(item.EX_IPI);
			record.COD_GEN = ToUTF8(item.COD_GEN);
			record.COD_LST = ToUTF8(item.COD_LST);
			record.ALIQ_ICMS = Convert.ToDouble(item.ALIQ_ICMS);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0200New(this.Handle, record);
			CheckResult(ret);

			foreach (var item0205 in item.Registro0205)
			{
				SendRegistro0205(item0205);
			}

			foreach (var item0206 in item.Registro0206)
			{
				SendRegistro0206(item0206);
			}

			foreach (var item0220 in item.Registro0220)
			{
				SendRegistro0220(item0220);
			}
		}

		private void SendRegistro0205(Registro0205 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0205();
			record.DESCR_ANT_ITEM = ToUTF8(item.DESCR_ANT_ITEM);
			record.DT_INI = item.DT_INI.ToOADate();
			record.DT_FIN = item.DT_FIN.ToOADate();
			record.COD_ANT_ITEM = ToUTF8(item.COD_ANT_ITEM);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0205New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0206(Registro0206 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0206();
			record.COD_COMB = ToUTF8(item.COD_COMB);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0206New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0220(Registro0220 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0220();
			record.UNID_CONV = ToUTF8(item.UNID_CONV);
			record.FAT_CONV = Convert.ToDouble(item.FAT_CONV);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0220New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0300(Registro0300 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0300();
			record.COD_IND_BEM = ToUTF8(item.COD_IND_BEM);
			record.IDENT_MERC = (int)item.IDENT_MERC;
			record.DESCR_ITEM = ToUTF8(item.DESCR_ITEM);
			record.COD_PRNC = ToUTF8(item.COD_PRNC);
			record.COD_CTA = ToUTF8(item.COD_CTA);
			record.NR_PARC = Convert.ToDouble(item.NR_PARC);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0300New(this.Handle, record);
			CheckResult(ret);

			foreach (var item0305 in item.Registro0305)
			{
				SendRegistro0305(item0305);
			}
		}

		private void SendRegistro0305(Registro0305 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0305();
			record.COD_CCUS = ToUTF8(item.COD_CCUS);
			record.FUNC = ToUTF8(item.FUNC);
			record.VIDA_UTIL = item.VIDA_UTIL;

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0305New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0400(Registro0400 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0400();
			record.COD_NAT = ToUTF8(item.COD_NAT);
			record.DESCR_NAT = ToUTF8(item.DESCR_NAT);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0400New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0450(Registro0450 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0450();
			record.COD_INF = ToUTF8(item.COD_INF);
			record.TXT = ToUTF8(item.TXT);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0450New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0460(Registro0460 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0460();
			record.COD_OBS = ToUTF8(item.COD_OBS);
			record.TXT = ToUTF8(item.TXT);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0460New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0500(Registro0500 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0500();
			record.DT_ALT = item.DT_ALT.ToOADate();
			record.COD_NAT_CC = ToUTF8(item.COD_NAT_CC);
			record.IND_CTA = ToUTF8(item.IND_CTA);
			record.NIVEL = ToUTF8(item.NIVEL);
			record.COD_CTA = ToUTF8(item.COD_CTA);
			record.NOME_CTA = ToUTF8(item.NOME_CTA);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0500New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro0600(Registro0600 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco0Registro0600();
			record.DT_ALT  = item.DT_ALT.ToOADate();
			record.COD_CCUS = ToUTF8(record.COD_CCUS);
			record.CCUS = ToUTF8(record.CCUS);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0600New(this.Handle, record);
			CheckResult(ret);
		}

#endregion Bloco0 Interop

		#region Bloco1 Interop

		private void SendBloco1()
		{
			SendRegistro1001();
		}

		private void SendRegistro1001()
		{
			var record = new ACBrSpedFiscalInterop.Bloco1Registro1001();
			record.IND_MOV = (int)Bloco_1.Registro1001.IND_MOV;

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1001New(this.Handle, record);
			CheckResult(ret);

			foreach (var item in Bloco_1.Registro1001.Registro1010)
			{
				SendRegistro1010(item);
			}

			foreach (var item in Bloco_1.Registro1001.Registro1100)
			{
				SendRegistro1100(item);
			}

			foreach (var item in Bloco_1.Registro1001.Registro1200)
			{
				SendRegistro1200(item);
			}

			foreach (var item in Bloco_1.Registro1001.Registro1300)
			{
				SendRegistro1300(item);
			}

			foreach (var item in Bloco_1.Registro1001.Registro1350)
			{
				SendRegistro1350(item);
			}

			foreach (var item in Bloco_1.Registro1001.Registro1390)
			{
				SendRegistro1390(item);
			}

			foreach (var item in Bloco_1.Registro1001.Registro1400)
			{
				SendRegistro1400(item);
			}

			foreach (var item in Bloco_1.Registro1001.Registro1500)
			{
				SendRegistro1500(item);
			}

			foreach (var item in Bloco_1.Registro1001.Registro1600)
			{
				SendRegistro1600(item);
			}

			foreach (var item in Bloco_1.Registro1001.Registro1700)
			{
				SendRegistro1700(item);
			}

			foreach (var item in Bloco_1.Registro1001.Registro1800)
			{
				SendRegistro1800(item);
			}
		}

		private void SendRegistro1010(Registro1010 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco1Registro1010();
			record.IND_EXP   = ToUTF8(item.IND_EXP);
			record.IND_CCRF = ToUTF8(item.IND_CCRF);
			record.IND_COMB = ToUTF8(item.IND_COMB);
			record.IND_USINA = ToUTF8(item.IND_USINA);
			record.IND_VA = ToUTF8(item.IND_VA);
			record.IND_EE = ToUTF8(item.IND_EE);
			record.IND_CART = ToUTF8(item.IND_CART);
			record.IND_FORM = ToUTF8(item.IND_FORM);
			record.IND_AER = ToUTF8(item.IND_AER);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1010New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro1100(Registro1100 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco1Registro1100();
			record.IND_DOC = (int)item.IND_DOC;
			record.NRO_DE = ToUTF8(item.NRO_DE);
			record.DT_DE = item.DT_DE.ToOADate();
			record.NAT_EXP = (int)item.NAT_EXP;
			record.NRO_RE = ToUTF8(item.NRO_RE);
			record.DT_RE = item.DT_RE.ToOADate();
			record.CHC_EMB = ToUTF8(item.CHC_EMB);
			record.DT_CHC = item.DT_CHC.ToOADate();
			record.DT_AVB = item.DT_AVB.ToOADate();
			record.TP_CHC = (int)item.TP_CHC;
			record.PAIS = ToUTF8(item.PAIS);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1100New(this.Handle, record);
			CheckResult(ret);

			foreach (var item1105 in item.Registro1105)
			{
				SendRegistro1105(item1105);
			}
		}

		private void SendRegistro1105(Registro1105 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco1Registro1105();
			record.COD_MOD = ToUTF8(item.COD_MOD);
			record.SERIE = ToUTF8(item.SERIE);
			record.NUM_DOC = ToUTF8(item.NUM_DOC);
			record.CHV_NFE = ToUTF8(item.CHV_NFE);
			record.DT_DOC = item.DT_DOC.ToOADate();
			record.COD_ITEM = ToUTF8(item.COD_ITEM);
			
			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1105New(this.Handle, record);
			CheckResult(ret);

			foreach (var item1110 in item.Registro1110)
			{
				SendRegistro1110(item1110);
			}
		}

		private void SendRegistro1110(Registro1110 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco1Registro1110();
			record.COD_PART = ToUTF8(item.COD_PART);
			record.COD_MOD = ToUTF8(item.COD_MOD);
			record.SER = ToUTF8(item.SER);
			record.NUM_DOC = ToUTF8(item.NUM_DOC);
			record.DT_DOC = item.DT_DOC.ToOADate();
			record.CHV_NFE = ToUTF8(item.CHV_NFE);
			record.NR_MEMO = ToUTF8(item.NR_MEMO);
			record.QTD = Convert.ToDouble(item.QTD);
			record.UNID = ToUTF8(item.UNID);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1110New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro1200(Registro1200 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco1Registro1200();
			record.COD_AJ_APUR = ToUTF8(item.COD_AJ_APUR);
			record.SLD_CRED = Convert.ToDouble(item.SLD_CRED);
			record.CRED_APR = Convert.ToDouble(item.CRED_APR);
			record.CRED_RECEB = Convert.ToDouble(item.CRED_RECEB);
			record.CRED_UTIL = Convert.ToDouble(item.CRED_UTIL);
			record.SLD_CRED_FIM = Convert.ToDouble(item.SLD_CRED_FIM);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1200New(this.Handle, record);
			CheckResult(ret);

			foreach (var item1210 in item.Registro1210)
			{
				SendRegistro1210(item1210);
			}
		}

		private void SendRegistro1210(Registro1210 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco1Registro1210();
			record.TIPO_UTIL = ToUTF8(item.TIPO_UTIL);
			record.NR_DOC = ToUTF8(item.NR_DOC);
			record.VL_CRED_UTIL = Convert.ToDouble(item.VL_CRED_UTIL);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1210New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro1300(Registro1300 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco1Registro1300();
			record.COD_ITEM = ToUTF8(item.COD_ITEM);
			record.DT_FECH = item.DT_FECH.ToOADate();
			record.ESTQ_ABERT = Convert.ToDouble(item.ESTQ_ABERT);
			record.VOL_ENTR = Convert.ToDouble(item.VOL_ENTR);
			record.VOL_DISP = Convert.ToDouble(item.VOL_DISP);
			record.VOL_SAIDAS = Convert.ToDouble(item.VOL_SAIDAS);
			record.ESTQ_ESCR = Convert.ToDouble(item.ESTQ_ESCR);
			record.VAL_AJ_PERDA = Convert.ToDouble(item.VAL_AJ_PERDA);
			record.VAL_AJ_GANHO = Convert.ToDouble(item.VAL_AJ_GANHO);
			record.FECH_FISICO = Convert.ToDouble(item.FECH_FISICO);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1300New(this.Handle, record);
			CheckResult(ret);

			foreach (var item1310 in item.Registro1310)
			{
				SendRegistro1310(item1310);
			}
		}

		private void SendRegistro1310(Registro1310 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco1Registro1310();
			record.NUM_TANQUE = ToUTF8(item.NUM_TANQUE);
			record.ESTQ_ABERT = Convert.ToDouble(item.ESTQ_ABERT);
			record.VOL_ENTR = Convert.ToDouble(item.VOL_ENTR);
			record.VOL_DISP = Convert.ToDouble(item.VOL_DISP);
			record.VOL_SAIDAS = Convert.ToDouble(item.VOL_SAIDAS);
			record.ESTQ_ESCR = Convert.ToDouble(item.ESTQ_ESCR);
			record.VAL_AJ_PERDA = Convert.ToDouble(item.VAL_AJ_PERDA);
			record.VAL_AJ_GANHO = Convert.ToDouble(item.VAL_AJ_GANHO);
			record.FECH_FISICO = Convert.ToDouble(item.FECH_FISICO);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1310New(this.Handle, record);
			CheckResult(ret);

			foreach (var item1320 in item.Registro1320)
			{
				SendRegistro1320(item1320);
			}
		}

		private void SendRegistro1320(Registro1320 item)
		{
			var record = new ACBrSpedFiscalInterop.Bloco1Registro1320();
			record.NUM_BICO = ToUTF8(item.NUM_BICO);
			record.NR_INTERV = ToUTF8(item.NR_INTERV);
			record.MOT_INTERV = ToUTF8(item.MOT_INTERV);
			record.NOM_INTERV = ToUTF8(item.NOM_INTERV);
			record.CNPJ_INTERV = ToUTF8(item.CNPJ_INTERV);
			record.CPF_INTERV = ToUTF8(item.CPF_INTERV);
			record.VAL_FECHA = Convert.ToDouble(item.VAL_FECHA);
			record.VAL_ABERT = Convert.ToDouble(item.VAL_ABERT);
			record.VOL_AFERI = Convert.ToDouble(item.VOL_AFERI);
			record.VOL_VENDAS = Convert.ToDouble(item.VOL_VENDAS);

			int ret = ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1320New(this.Handle, record);
			CheckResult(ret);
		}

		private void SendRegistro1350(Registro1350 item)
		{
			throw new NotImplementedException();
		}

		private void SendRegistro1390(Registro1390 item)
		{
			throw new NotImplementedException();
		}

		private void SendRegistro1400(Registro1400 item)
		{
			throw new NotImplementedException();
		}

		private void SendRegistro1500(Registro1500 item)
		{
			throw new NotImplementedException();
		}

		private void SendRegistro1600(Registro1600 item)
		{
			throw new NotImplementedException();
		}

		private void SendRegistro1700(Registro1700 item)
		{
			throw new NotImplementedException();
		}

		private void SendRegistro1800(Registro1800 item)
		{
			throw new NotImplementedException();
		}

		#endregion Bloco1 Interop

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrSpedFiscalInterop.SPDF_Create);

			Bloco_0 = new Bloco0(this);
			Bloco_1 = new Bloco1(this);
			Bloco_9 = new Bloco9();
			Bloco_C = new BlocoC();
			Bloco_D = new BlocoD();
			Bloco_E = new BlocoE();
			Bloco_G = new BlocoG();
			Bloco_H = new BlocoH();
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrSpedFiscalInterop.SPDF_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBrSPEDFiscal não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrSpedFiscalInterop.SPDF_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}