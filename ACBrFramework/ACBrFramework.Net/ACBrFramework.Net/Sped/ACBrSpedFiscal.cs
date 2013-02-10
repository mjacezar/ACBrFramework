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
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0000>(Bloco_0.Registro0000, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0000New);
		}

		private void SendRegistro0001()
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0001>(Bloco_0.Registro0001, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0001New);

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
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0005>(Bloco_0.Registro0001.Registro0005, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0005New);
		}

		private void SendRegistro0015(Registro0015 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0015>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0015New);
		}

		private void SendRegistro0100()
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0100>(Bloco_0.Registro0001.Registro0100, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0100New);
		}

		private void SendRegistro0150(Registro0150 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0150>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0150New);

			foreach (var item0175 in item.Registro0175)
			{
				SendRegistro0175(item0175);
			}
		}

		private void SendRegistro0175(Registro0175 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0175>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0175New);
		}

		private void SendRegistro0190(Registro0190 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0190>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0190New);
		}

		private void SendRegistro0200(Registro0200 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0200>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0200New);

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
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0205>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0205New);
		}

		private void SendRegistro0206(Registro0206 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0206>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0206New);
		}

		private void SendRegistro0220(Registro0220 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0220>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0220New);
		}

		private void SendRegistro0300(Registro0300 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0300>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0300New);

			foreach (var item0305 in item.Registro0305)
			{
				SendRegistro0305(item0305);
			}
		}

		private void SendRegistro0305(Registro0305 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0305>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0305New);
		}

		private void SendRegistro0400(Registro0400 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0400>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0400New);
		}

		private void SendRegistro0450(Registro0450 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0450>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0450New);
		}

		private void SendRegistro0460(Registro0460 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0460>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0460New);
		}

		private void SendRegistro0500(Registro0500 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0500>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0500New);
		}

		private void SendRegistro0600(Registro0600 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco0Registro0600>(item, ACBrSpedFiscalInterop.SPDF_Bloco_0_Registro0600New);
		}

		#endregion Bloco0 Interop

		#region Bloco1 Interop

		private void SendBloco1()
		{
			SendRegistro1001();
		}

		private void SendRegistro1001()
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1001>(Bloco_1.Registro1001, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1001New);

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
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1010>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1010New);
		}

		private void SendRegistro1100(Registro1100 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1100>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1100New);

			foreach (var item1105 in item.Registro1105)
			{
				SendRegistro1105(item1105);
			}
		}

		private void SendRegistro1105(Registro1105 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1105>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1105New);

			foreach (var item1110 in item.Registro1110)
			{
				SendRegistro1110(item1110);
			}
		}

		private void SendRegistro1110(Registro1110 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1110>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1110New);
		}

		private void SendRegistro1200(Registro1200 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1200>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1200New);

			foreach (var item1210 in item.Registro1210)
			{
				SendRegistro1210(item1210);
			}
		}

		private void SendRegistro1210(Registro1210 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1210>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1210New);
		}

		private void SendRegistro1300(Registro1300 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1300>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1300New);

			foreach (var item1310 in item.Registro1310)
			{
				SendRegistro1310(item1310);
			}
		}

		private void SendRegistro1310(Registro1310 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1310>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1310New);

			foreach (var item1320 in item.Registro1320)
			{
				SendRegistro1320(item1320);
			}
		}

		private void SendRegistro1320(Registro1320 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1320>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1320New);
		}

		private void SendRegistro1350(Registro1350 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1350>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1350New);

			foreach (var item1360 in item.Registro1360)
			{
				SendRegistro1360(item1360);
			}

			foreach (var item1370 in item.Registro1370)
			{
				SendRegistro1370(item1370);
			}
		}

		private void SendRegistro1360(Registro1360 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1360>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1360New);
		}

		private void SendRegistro1370(Registro1370 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1370>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1370New);
		}

		private void SendRegistro1390(Registro1390 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1390>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1390New);
		}

		private void SendRegistro1400(Registro1400 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1400>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1400New);
		}

		private void SendRegistro1500(Registro1500 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1500>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1500New);

			foreach (var item1510 in item.Registro1510)
			{
				SendRegistro1510(item1510);
			}
		}

		private void SendRegistro1510(Registro1510 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1510>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1510New);
		}

		private void SendRegistro1600(Registro1600 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1600>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1600New);
		}

		private void SendRegistro1700(Registro1700 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1700>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1700New);

			foreach (var item1710 in item.Registro1710)
			{
				SendRegistro1710(item1710);
			}
		}

		private void SendRegistro1710(Registro1710 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1710>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1710New);
		}

		private void SendRegistro1800(Registro1800 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco1Registro1800>(item, ACBrSpedFiscalInterop.SPDF_Bloco_1_Registro1800New);
		}

		#endregion Bloco1 Interop

		#region Bloco9 Interop

		private void SendBloco9()
		{
			SendRegistro9001();

			foreach (var item9900 in this.Bloco_9.Registro9900)
			{
				SendRegistro9900(item9900);
			}
		}

		private void SendRegistro9001()
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco9Registro9001>(Bloco_9.Registro9001, ACBrSpedFiscalInterop.SPDF_Bloco_9_Registro9001New);
		}

		private void SendRegistro9900(Registro9900 item)
		{
			SendRecord<ACBrSpedFiscalInterop.Bloco9Registro9900>(item, ACBrSpedFiscalInterop.SPDF_Bloco_9_Registro9900New);
		}

		#endregion Bloco9 Interop

		#region BlocoC Interop

		private void SendBlocoC()
		{
			SendRegistroC001();
		}

		private void SendRegistroC001()
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC001>(Bloco_C.RegistroC001, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC001New);

			foreach (var itemC100 in Bloco_C.RegistroC001.RegistroC100)
			{
				SendRegistroC100(itemC100);
			}

			foreach (var itemC300 in Bloco_C.RegistroC001.RegistroC300)
			{
				SendRegistroC300(itemC300);
			}

			foreach (var itemC350 in Bloco_C.RegistroC001.RegistroC350)
			{
				SendRegistroC350(itemC350);
			}

			foreach (var itemC400 in Bloco_C.RegistroC001.RegistroC400)
			{
				SendRegistroC400(itemC400);
			}

			foreach (var itemC495 in Bloco_C.RegistroC001.RegistroC495)
			{
				SendRegistroC495(itemC495);
			}

			foreach (var itemC500 in Bloco_C.RegistroC001.RegistroC500)
			{
				SendRegistroC500(itemC500);
			}

			foreach (var itemC600 in Bloco_C.RegistroC001.RegistroC600)
			{
				SendRegistroC600(itemC600);
			}

			foreach (var itemC700 in Bloco_C.RegistroC001.RegistroC700)
			{
				SendRegistroC700(itemC700);
			}

			foreach (var itemC800 in Bloco_C.RegistroC001.RegistroC800)
			{
				SendRegistroC800(itemC800);
			}

			foreach (var itemC860 in Bloco_C.RegistroC001.RegistroC860)
			{
				SendRegistroC860(itemC860);
			}
		}

		private void SendRegistroC100(RegistroC100 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC100>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC100New);

			foreach (var itemC105 in item.RegistroC105)
			{
				SendRegistroC105(itemC105);
			}

			foreach (var itemC110 in item.RegistroC110)
			{
				SendRegistroC110(itemC110);
			}

			foreach (var itemC120 in item.RegistroC120)
			{
				SendRegistroC120(itemC120);
			}

			foreach (var itemC130 in item.RegistroC130)
			{
				SendRegistroC130(itemC130);
			}

			foreach (var itemC140 in item.RegistroC140)
			{
				SendRegistroC140(itemC140);
			}

			foreach (var itemC160 in item.RegistroC160)
			{
				SendRegistroC160(itemC160);
			}

			foreach (var itemC165 in item.RegistroC165)
			{
				SendRegistroC165(itemC165);
			}

			foreach (var itemC170 in item.RegistroC170)
			{
				SendRegistroC170(itemC170);
			}

			foreach (var itemC190 in item.RegistroC190)
			{
				SendRegistroC190(itemC190);
			}

			foreach (var itemC195 in item.RegistroC195)
			{
				SendRegistroC195(itemC195);
			}
		}

		private void SendRegistroC105(RegistroC105 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC105>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC105New);
		}

		private void SendRegistroC110(RegistroC110 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC110>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC110New);

			foreach (var itemC111 in item.RegistroC111)
			{
				SendRegistroC111(itemC111);
			}

			foreach (var itemC112 in item.RegistroC112)
			{
				SendRegistroC112(itemC112);
			}

			foreach (var itemC113 in item.RegistroC113)
			{
				SendRegistroC113(itemC113);
			}

			foreach (var itemC114 in item.RegistroC114)
			{
				SendRegistroC114(itemC114);
			}

			foreach (var itemC115 in item.RegistroC115)
			{
				SendRegistroC115(itemC115);
			}

			foreach (var itemC116 in item.RegistroC116)
			{
				SendRegistroC116(itemC116);
			}
		}

		private void SendRegistroC111(RegistroC111 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC111>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC111New);
		}

		private void SendRegistroC112(RegistroC112 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC112>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC112New);
		}

		private void SendRegistroC113(RegistroC113 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC113>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC113New);
		}

		private void SendRegistroC114(RegistroC114 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC114>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC114New);
		}

		private void SendRegistroC115(RegistroC115 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC115>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC115New);
		}

		private void SendRegistroC116(RegistroC116 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC116>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC116New);
		}

		private void SendRegistroC120(RegistroC120 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC120>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC120New);
		}

		private void SendRegistroC130(RegistroC130 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC130>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC130New);
		}

		private void SendRegistroC140(RegistroC140 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC140>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC140New);

			foreach (var itemC141 in item.RegistroC141)
			{
				SendRegistroC141(itemC141);
			}
		}

		private void SendRegistroC141(RegistroC141 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC141>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC141New);
		}

		private void SendRegistroC160(RegistroC160 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC160>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC160New);
		}

		private void SendRegistroC165(RegistroC165 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC165>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC165New);
		}

		private void SendRegistroC170(RegistroC170 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC170>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC170New);

			foreach (var itemC171 in item.RegistroC171)
			{
				SendRegistroC171(itemC171);
			}

			foreach (var itemC172 in item.RegistroC172)
			{
				SendRegistroC172(itemC172);
			}

			foreach (var itemC173 in item.RegistroC173)
			{
				SendRegistroC173(itemC173);
			}

			foreach (var itemC174 in item.RegistroC174)
			{
				SendRegistroC174(itemC174);
			}

			foreach (var itemC175 in item.RegistroC175)
			{
				SendRegistroC175(itemC175);
			}

			foreach (var itemC176 in item.RegistroC176)
			{
				SendRegistroC176(itemC176);
			}

			foreach (var itemC177 in item.RegistroC177)
			{
				SendRegistroC177(itemC177);
			}

			foreach (var itemC178 in item.RegistroC178)
			{
				SendRegistroC178(itemC178);
			}

			foreach (var itemC179 in item.RegistroC179)
			{
				SendRegistroC179(itemC179);
			}
		}

		private void SendRegistroC171(RegistroC171 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC171>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC171New);
		}

		private void SendRegistroC172(RegistroC172 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC172>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC172New);
		}

		private void SendRegistroC173(RegistroC173 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC173>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC173New);
		}

		private void SendRegistroC174(RegistroC174 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC174>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC174New);
		}

		private void SendRegistroC175(RegistroC175 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC175>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC175New);
		}

		private void SendRegistroC176(RegistroC176 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC176>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC176New);
		}

		private void SendRegistroC177(RegistroC177 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC177>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC177New);
		}

		private void SendRegistroC178(RegistroC178 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC178>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC178New);
		}

		private void SendRegistroC179(RegistroC179 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC179>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC179New);
		}

		private void SendRegistroC190(RegistroC190 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC190>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC190New);
		}

		private void SendRegistroC195(RegistroC195 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC195>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC195New);

			foreach (var itemC197 in item.RegistroC197)
			{
				SendRegistroC197(itemC197);
			}
		}

		private void SendRegistroC197(RegistroC197 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC197>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC197New);
		}

		private void SendRegistroC300(RegistroC300 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC300>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC300New);

			foreach (var itemC310 in item.RegistroC310)
			{
				SendRegistroC310(itemC310);
			}

			foreach (var itemC320 in item.RegistroC320)
			{
				SendRegistroC320(itemC320);
			}
		}

		private void SendRegistroC310(RegistroC310 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC310>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC310New);
		}

		private void SendRegistroC320(RegistroC320 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC320>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC320New);

			foreach (var itemC321 in item.RegistroC321)
			{
				SendRegistroC321(itemC321);
			}
		}

		private void SendRegistroC321(RegistroC321 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC321>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC321New);
		}

		private void SendRegistroC350(RegistroC350 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC350>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC350New);

			foreach (var itemC370 in item.RegistroC370)
			{
				SendRegistroC370(itemC370);
			}

			foreach (var itemC390 in item.RegistroC390)
			{
				SendRegistroC390(itemC390);
			}
		}

		private void SendRegistroC370(RegistroC370 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC370>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC370New);
		}

		private void SendRegistroC390(RegistroC390 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC390>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC390New);
		}

		private void SendRegistroC400(RegistroC400 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC400>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC400New);

			foreach (var itemC405 in item.RegistroC405)
			{
				SendRegistroC405(itemC405);
			}
		}

		private void SendRegistroC405(RegistroC405 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC405>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC405New);

			foreach (var itemC410 in item.RegistroC410)
			{
				SendRegistroC410(itemC410);
			}

			foreach (var itemC420 in item.RegistroC420)
			{
				SendRegistroC420(itemC420);
			}

			foreach (var itemC460 in item.RegistroC460)
			{
				SendRegistroC460(itemC460);
			}

			foreach (var itemC490 in item.RegistroC490)
			{
				SendRegistroC490(itemC490);
			}
		}

		private void SendRegistroC410(RegistroC410 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC410>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC410New);
		}

		private void SendRegistroC420(RegistroC420 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC420>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC420New);

			foreach (var itemC425 in item.RegistroC425)
			{
				SendRegistroC425(itemC425);
			}
		}

		private void SendRegistroC425(RegistroC425 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC425>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC425New);
		}

		private void SendRegistroC460(RegistroC460 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC460>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC460New);

			foreach (var itemC470 in item.RegistroC470)
			{
				SendRegistroC470(itemC470);
			}
		}

		private void SendRegistroC470(RegistroC470 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC470>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC470New);
		}

		private void SendRegistroC490(RegistroC490 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC490>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC490New);
		}

		private void SendRegistroC495(RegistroC495 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC495>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC495New);
		}

		private void SendRegistroC500(RegistroC500 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC500>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC500New);

			foreach (var itemC510 in item.RegistroC510)
			{
				SendRegistroC510(itemC510);
			}

			foreach (var itemC590 in item.RegistroC590)
			{
				SendRegistroC590(itemC590);
			}
		}

		private void SendRegistroC510(RegistroC510 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC510>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC510New);
		}

		private void SendRegistroC590(RegistroC590 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC590>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC590New);
		}

		private void SendRegistroC600(RegistroC600 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC600>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC600New);

			foreach (var itemC601 in item.RegistroC601)
			{
				SendRegistroC601(itemC601);
			}

			foreach (var itemC610 in item.RegistroC610)
			{
				SendRegistroC610(itemC610);
			}

			foreach (var itemC690 in item.RegistroC690)
			{
				SendRegistroC690(itemC690);
			}
		}

		private void SendRegistroC601(RegistroC601 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC601>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC601New);
		}

		private void SendRegistroC610(RegistroC610 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC610>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC610New);
		}

		private void SendRegistroC690(RegistroC690 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC690>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC690New);
		}

		private void SendRegistroC700(RegistroC700 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC700>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC700New);

			foreach (var itemC790 in item.RegistroC790)
			{
				SendRegistroC790(itemC790);
			}
		}

		private void SendRegistroC790(RegistroC790 item)
		{
			
		}

		private void SendRegistroC800(RegistroC800 item)
		{
			throw new NotImplementedException();
		}

		private void SendRegistroC860(RegistroC860 item)
		{
			throw new NotImplementedException();
		}

		#endregion BlocoC Interop

		#region Interop

		private void SendRecord<TRecord>(object item, Func<IntPtr, TRecord, int> sendRecordMethod) where TRecord : struct
		{
			TRecord record = BindRecord<TRecord>(item);
			int ret = sendRecordMethod(this.Handle, record);
			CheckResult(ret);
		}

		private TRecord BindRecord<TRecord>(object item) where TRecord : struct
		{
			Type recordType = typeof(TRecord);
			Type itemType = item.GetType();

			TRecord record = new TRecord();

			foreach (var field in recordType.GetFields())
			{
				object value = itemType.GetField(field.Name).GetValue(item);

				if (field.FieldType == typeof(string))
				{
					field.SetValue(record, ToUTF8((string)value));
				}
				else if (field.FieldType == typeof(double))
				{
					if (value is DateTime)
					{
						field.SetValue(record, ((DateTime)value).ToOADate());
					}
					else
					{
						field.SetValue(record, Convert.ToDouble(value));
					}
				}
				else if (field.FieldType == typeof(int))
				{
					field.SetValue(record, Convert.ToInt32(value));
				}
				else if (field.FieldType == typeof(short))
				{
					field.SetValue(record, Convert.ToInt16(value));
				}
				else if (field.FieldType == typeof(long))
				{
					field.SetValue(record, Convert.ToInt64(value));
				}
				else if (field.FieldType == typeof(float))
				{
					field.SetValue(record, Convert.ToSingle(value));
				}
				else
				{
					throw new NotImplementedException();
				}
			}

			return record;
		}

		#endregion Interop

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrSpedFiscalInterop.SPDF_Create);

			Bloco_0 = new Bloco0(this);
			Bloco_1 = new Bloco1(this);
			Bloco_9 = new Bloco9(this);
			Bloco_C = new BlocoC(this);
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