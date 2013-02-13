using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ACBrFramework.Sped
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.Sped.ico.bmp")]
	public class ACBrSpedFiscal : ACBrComponent, IDisposable
	{
		#region Fields

		private readonly ACBrEventHandler<ErrorEventArgs, ACBrSpedFiscalInterop.StringCallback> onError;

		#endregion Fields

		#region Events

		public event EventHandler<ErrorEventArgs> OnError
		{
			add
			{
				onError.Add(value);
			}
			remove
			{
				onError.Remove(value);
			}
		}

		#endregion Events

		#region Constructor

		public ACBrSpedFiscal()
		{
			onError = new ACBrEventHandler<ErrorEventArgs, ACBrSpedFiscalInterop.StringCallback>(this, OnErrorCallback, ACBrSpedFiscalInterop.SPDF_SetOnError);
		}

		#endregion Constructor

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

		public void SaveFileTXT()
		{
			SendBlocos();

			int ret = ACBrSpedFiscalInterop.SPDF_SaveFileTXT(this.Handle);
			CheckResult(ret);

			CreateBlocos();
		}

		private void CreateBlocos()
		{
			Bloco_0 = new Bloco0(this);
			Bloco_1 = new Bloco1(this);
			Bloco_9 = new Bloco9(this);
			Bloco_C = new BlocoC(this);
			Bloco_D = new BlocoD(this);
			Bloco_E = new BlocoE(this);
			Bloco_G = new BlocoG(this);
			Bloco_H = new BlocoH(this);
		}

		#region Interop

		private void SendBlocos()
		{
			SendBloco0();
			SendBloco1();
			SendBloco9();
			SendBlocoC();
			SendBlocoD();
			SendBlocoE();
			SendBlocoG();
			SendBlocoH();
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
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC790>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC790New);

			foreach (var itemC791 in item.RegistroC791)
			{
				SendRegistroC791(itemC791);
			}
		}

		private void SendRegistroC791(RegistroC791 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC791>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC791New);
		}

		private void SendRegistroC800(RegistroC800 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC800>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC800New);

			foreach (var itemC850 in item.RegistroC850)
			{
				SendRegistroC850(itemC850);
			}
		}

		private void SendRegistroC850(RegistroC850 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC850>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC850New);
		}

		private void SendRegistroC860(RegistroC860 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC860>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC860New);

			foreach (var itemC890 in item.RegistroC890)
			{
				SendRegistroC890(itemC890);
			}
		}

		private void SendRegistroC890(RegistroC890 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoCRegistroC890>(item, ACBrSpedFiscalInterop.SPDF_Bloco_C_RegistroC890New);
		}

		#endregion BlocoC Interop

		#region BlocoD Interop

		private void SendBlocoD()
		{
			SendRegistroD001();
		}

		private void SendRegistroD001()
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD001>(Bloco_D.RegistroD001, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD001New);

			foreach (var itemD100 in Bloco_D.RegistroD001.RegistroD100)
			{
				SendRegistroD100(itemD100);
			}

			foreach (var itemD300 in Bloco_D.RegistroD001.RegistroD300)
			{
				SendRegistroD300(itemD300);
			}

			foreach (var itemD350 in Bloco_D.RegistroD001.RegistroD350)
			{
				SendRegistroD350(itemD350);
			}

			foreach (var itemD400 in Bloco_D.RegistroD001.RegistroD400)
			{
				SendRegistroD400(itemD400);
			}

			foreach (var itemD500 in Bloco_D.RegistroD001.RegistroD500)
			{
				SendRegistroD500(itemD500);
			}

			foreach (var itemD600 in Bloco_D.RegistroD001.RegistroD600)
			{
				SendRegistroD600(itemD600);
			}

			foreach (var itemD695 in Bloco_D.RegistroD001.RegistroD695)
			{
				SendRegistroD695(itemD695);
			}
		}

		private void SendRegistroD100(RegistroD100 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD100>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD100New);

			foreach (var itemD110 in item.RegistroD110)
			{
				SendRegistroD110(itemD110);
			}

			foreach (var itemD130 in item.RegistroD130)
			{
				SendRegistroD130(itemD130);
			}

			foreach (var itemD140 in item.RegistroD140)
			{
				SendRegistroD140(itemD140);
			}

			foreach (var itemD150 in item.RegistroD150)
			{
				SendRegistroD150(itemD150);
			}

			foreach (var itemD160 in item.RegistroD160)
			{
				SendRegistroD160(itemD160);
			}

			foreach (var itemD170 in item.RegistroD170)
			{
				SendRegistroD170(itemD170);
			}

			foreach (var itemD180 in item.RegistroD180)
			{
				SendRegistroD180(itemD180);
			}

			foreach (var itemD190 in item.RegistroD190)
			{
				SendRegistroD190(itemD190);
			}

			foreach (var itemD195 in item.RegistroD195)
			{
				SendRegistroD195(itemD195);
			}
		}

		private void SendRegistroD110(RegistroD110 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD110>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD110New);

			foreach (var itemD120 in item.RegistroD120)
			{
				SendRegistroD120(itemD120);
			}
		}

		private void SendRegistroD120(RegistroD120 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD120>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD120New);
		}

		private void SendRegistroD130(RegistroD130 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD130>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD130New);
		}

		private void SendRegistroD140(RegistroD140 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD140>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD140New);
		}

		private void SendRegistroD150(RegistroD150 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD150>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD150New);
		}

		private void SendRegistroD160(RegistroD160 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD160>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD160New);

			foreach (var itemD161 in item.RegistroD161)
			{
				SendRegistroD161(itemD161);
			}

			foreach (var itemD162 in item.RegistroD162)
			{
				SendRegistroD162(itemD162);
			}
		}

		private void SendRegistroD161(RegistroD161 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD161>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD161New);
		}

		private void SendRegistroD162(RegistroD162 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD162>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD162New);
		}

		private void SendRegistroD170(RegistroD170 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD170>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD170New);
		}

		private void SendRegistroD180(RegistroD180 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD180>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD180New);
		}

		private void SendRegistroD190(RegistroD190 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD190>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD190New);
		}

		private void SendRegistroD195(RegistroD195 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD195>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD195New);

			foreach (var itemD197 in item.RegistroD197)
			{
				SendRegistroD197(itemD197);
			}
		}

		private void SendRegistroD197(RegistroD197 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD197>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD197New);
		}

		private void SendRegistroD300(RegistroD300 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD300>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD300New);

			foreach (var itemD301 in item.RegistroD301)
			{
				SendRegistroD301(itemD301);
			}

			foreach (var itemD310 in item.RegistroD310)
			{
				SendRegistroD310(itemD310);
			}
		}

		private void SendRegistroD301(RegistroD301 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD301>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD301New);
		}

		private void SendRegistroD310(RegistroD310 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD310>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD310New);
		}

		private void SendRegistroD350(RegistroD350 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD350>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD350New);

			foreach (var itemD355 in item.RegistroD355)
			{
				SendRegistroD355(itemD355);
			}
		}

		private void SendRegistroD355(RegistroD355 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD355>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD355New);

			foreach (var itemD360 in item.RegistroD360)
			{
				SendRegistroD360(itemD360);
			}

			foreach (var itemD365 in item.RegistroD365)
			{
				SendRegistroD365(itemD365);
			}

			foreach (var itemD390 in item.RegistroD390)
			{
				SendRegistroD390(itemD390);
			}
		}

		private void SendRegistroD360(RegistroD360 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD360>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD360New);
		}

		private void SendRegistroD365(RegistroD365 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD365>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD365New);

			foreach (var itemD370 in item.RegistroD370)
			{
				SendRegistroD370(itemD370);
			}
		}

		private void SendRegistroD370(RegistroD370 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD370>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD370New);
		}

		private void SendRegistroD390(RegistroD390 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD390>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD390New);
		}

		private void SendRegistroD400(RegistroD400 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD400>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD400New);

			foreach (var itemD410 in item.RegistroD410)
			{
				SendRegistroD410(itemD410);
			}

			foreach (var itemD420 in item.RegistroD420)
			{
				SendRegistroD420(itemD420);
			}
		}

		private void SendRegistroD410(RegistroD410 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD410>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD410New);

			foreach (var itemD411 in item.RegistroD411)
			{
				SendRegistroD411(itemD411);
			}
		}

		private void SendRegistroD411(RegistroD411 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD411>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD411New);
		}

		private void SendRegistroD420(RegistroD420 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD420>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD420New);
		}

		private void SendRegistroD500(RegistroD500 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD500>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD500New);

			foreach (var itemD510 in item.RegistroD510)
			{
				SendRegistroD510(itemD510);
			}

			foreach (var itemD530 in item.RegistroD530)
			{
				SendRegistroD530(itemD530);
			}

			foreach (var itemD590 in item.RegistroD590)
			{
				SendRegistroD590(itemD590);
			}
		}

		private void SendRegistroD510(RegistroD510 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD510>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD510New);
		}

		private void SendRegistroD530(RegistroD530 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD530>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD530New);
		}

		private void SendRegistroD590(RegistroD590 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD590>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD590New);
		}

		private void SendRegistroD600(RegistroD600 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD600>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD600New);

			foreach (var itemD610 in item.RegistroD610)
			{
				SendRegistroD610(itemD610);
			}

			foreach (var itemD690 in item.RegistroD690)
			{
				SendRegistroD690(itemD690);
			}
		}

		private void SendRegistroD610(RegistroD610 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD610>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD610New);
		}

		private void SendRegistroD690(RegistroD690 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD690>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD690New);
		}

		private void SendRegistroD695(RegistroD695 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD695>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD695New);

			foreach (var itemD696 in item.RegistroD696)
			{
				SendRegistroD696(itemD696);
			}
		}

		private void SendRegistroD696(RegistroD696 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD696>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD696New);

			foreach (var itemD697 in item.RegistroD697)
			{
				SendRegistroD697(itemD697);
			}
		}

		private void SendRegistroD697(RegistroD697 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoDRegistroD697>(item, ACBrSpedFiscalInterop.SPDF_Bloco_D_RegistroD697New);
		}

		#endregion BlocoD Interop

		#region BlocoE Interop

		private void SendBlocoE()
		{
			SendRegistroE001();
		}

		private void SendRegistroE001()
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE001>(Bloco_E.RegistroE001, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE001New);

			foreach (var itemE100 in Bloco_E.RegistroE001.RegistroE100)
			{
				SendRegistroE100(itemE100);
			}

			foreach (var itemE200 in Bloco_E.RegistroE001.RegistroE200)
			{
				SendRegistroE200(itemE200);
			}

			foreach (var itemE500 in Bloco_E.RegistroE001.RegistroE500)
			{
				SendRegistroE500(itemE500);
			}
		}

		private void SendRegistroE100(RegistroE100 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE100>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE100New);

			SendRegistroE110(item.RegistroE110);
		}

		private void SendRegistroE110(RegistroE110 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE110>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE110New);

			foreach (var itemE111 in item.RegistroE111)
			{
				SendRegistroE111(itemE111);
			}

			foreach (var itemE115 in item.RegistroE115)
			{
				SendRegistroE115(itemE115);
			}

			foreach (var itemE116 in item.RegistroE116)
			{
				SendRegistroE116(itemE116);
			}
		}

		private void SendRegistroE111(RegistroE111 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE111>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE111New);

			foreach (var itemE112 in item.RegistroE112)
			{
				SendRegistroE112(itemE112);
			}

			foreach (var itemE113 in item.RegistroE113)
			{
				SendRegistroE113(itemE113);
			}
		}

		private void SendRegistroE112(RegistroE112 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE112>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE112New);
		}

		private void SendRegistroE113(RegistroE113 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE113>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE113New);
		}

		private void SendRegistroE115(RegistroE115 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE115>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE115New);
		}

		private void SendRegistroE116(RegistroE116 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE116>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE116New);
		}

		private void SendRegistroE200(RegistroE200 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE200>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE200New);

			foreach (var itemE210 in item.RegistroE210)
			{
				SendRegistroE210(itemE210);
			}
		}

		private void SendRegistroE210(RegistroE210 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE210>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE210New);

			foreach (var itemE220 in item.RegistroE220)
			{
				SendRegistroE220(itemE220);
			}

			foreach (var itemE250 in item.RegistroE250)
			{
				SendRegistroE250(itemE250);
			}
		}

		private void SendRegistroE220(RegistroE220 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE220>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE220New);

			foreach (var itemE230 in item.RegistroE230)
			{
				SendRegistroE230(itemE230);
			}

			foreach (var itemE240 in item.RegistroE240)
			{
				SendRegistroE240(itemE240);
			}
		}

		private void SendRegistroE230(RegistroE230 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE230>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE230New);
		}

		private void SendRegistroE240(RegistroE240 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE240>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE240New);
		}

		private void SendRegistroE250(RegistroE250 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE250>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE250New);
		}

		private void SendRegistroE500(RegistroE500 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE500>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE500New);

			foreach (var itemE510 in item.RegistroE510)
			{
				SendRegistroE510(itemE510);
			}

			foreach (var itemE520 in item.RegistroE520)
			{
				SendRegistroE520(itemE520);
			}
		}

		private void SendRegistroE510(RegistroE510 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE510>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE510New);
		}

		private void SendRegistroE520(RegistroE520 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE520>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE520New);

			foreach (var itemE530 in item.RegistroE530)
			{
				SendRegistroE530(itemE530);
			}
		}

		private void SendRegistroE530(RegistroE530 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoERegistroE530>(item, ACBrSpedFiscalInterop.SPDF_Bloco_E_RegistroE530New);
		}

		#endregion BlocoE Interop

		#region BlocoG Interop

		private void SendBlocoG()
		{
			SendRegistroG001();
		}

		private void SendRegistroG001()
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoGRegistroG001>(Bloco_G.RegistroG001, ACBrSpedFiscalInterop.SPDF_Bloco_G_RegistroG001New);

			foreach (var itemG110 in Bloco_G.RegistroG001.RegistroG110)
			{
				SendRegistroG110(itemG110);
			}
		}

		private void SendRegistroG110(RegistroG110 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoGRegistroG110>(item, ACBrSpedFiscalInterop.SPDF_Bloco_G_RegistroG110New);

			foreach (var itemG125 in item.RegistroG125)
			{
				SendRegistroG125(itemG125);
			}
		}

		private void SendRegistroG125(RegistroG125 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoGRegistroG125>(item, ACBrSpedFiscalInterop.SPDF_Bloco_G_RegistroG125New);

			foreach (var itemG126 in item.RegistroG126)
			{
				SendRegistroG126(itemG126);
			}

			foreach (var itemG130 in item.RegistroG130)
			{
				SendRegistroG130(itemG130);
			}
		}

		private void SendRegistroG126(RegistroG126 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoGRegistroG126>(item, ACBrSpedFiscalInterop.SPDF_Bloco_G_RegistroG126New);
		}

		private void SendRegistroG130(RegistroG130 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoGRegistroG130>(item, ACBrSpedFiscalInterop.SPDF_Bloco_G_RegistroG130New);

			foreach (var itemG140 in item.RegistroG140)
			{
				SendRegistroG140(itemG140);
			}
		}

		private void SendRegistroG140(RegistroG140 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoGRegistroG140>(item, ACBrSpedFiscalInterop.SPDF_Bloco_G_RegistroG140New);
		}

		#endregion BlocoG Interop

		#region BlocoH Interop

		private void SendBlocoH()
		{
			SendRegistroH001();
		}

		private void SendRegistroH001()
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoHRegistroH001>(Bloco_H.RegistroH001, ACBrSpedFiscalInterop.SPDF_Bloco_H_RegistroH001New);

			foreach (var itemH005 in Bloco_H.RegistroH001.RegistroH005)
			{
				SendRegistroH005(itemH005);
			}
		}

		private void SendRegistroH005(RegistroH005 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoHRegistroH005>(item, ACBrSpedFiscalInterop.SPDF_Bloco_H_RegistroH005New);

			foreach (var itemH010 in item.RegistroH010)
			{
				SendRegistroH010(itemH010);
			}
		}

		private void SendRegistroH010(RegistroH010 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoHRegistroH010>(item, ACBrSpedFiscalInterop.SPDF_Bloco_H_RegistroH010New);

			foreach (var itemH020 in item.RegistroH020)
			{
				SendRegistroH020(itemH020);
			}
		}

		private void SendRegistroH020(RegistroH020 item)
		{
			SendRecord<ACBrSpedFiscalInterop.BlocoHRegistroH020>(item, ACBrSpedFiscalInterop.SPDF_Bloco_H_RegistroH020New);
		}

		#endregion BlocoH Interop

		#region Interop Helpers

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

			object record = new TRecord();

			foreach (var field in recordType.GetFields())
			{
				PropertyInfo propertyInfo = itemType.GetProperty(field.Name);
				if (propertyInfo == null) throw new Exception(string.Format("O tipo {0} não possui a propriedade {1}", itemType.Name, field.Name));
				
				object value = propertyInfo.GetValue(item, null);

				if (field.FieldType == typeof(string))
				{
					var str = ToUTF8((string)value);
					field.SetValue(record, str);
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
					throw new Exception(string.Format("{0}: Tipo de dado {0} não esperado.", itemType.Name, field.FieldType.Name));
				}
			}

			return (TRecord)record;
		}

		#endregion Interop

		#endregion Interop

		#region Override Methods

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrSpedFiscalInterop.SPDF_Create);
			CreateBlocos();
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

		#region Callback EventHandlers

		[AllowReversePInvokeCalls]
		private void OnErrorCallback(string msgErro)
		{
			if (onError.IsAssigned)
			{
				ErrorEventArgs e = new ErrorEventArgs(FromUTF8(msgErro));
				onError.Raise(e);
			}
		}

		#endregion

		#endregion Methods
	}
}