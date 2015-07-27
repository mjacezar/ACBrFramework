using System;
using System.Linq;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ACBrFramework.AAC;
using ACBrFramework.EAD;

namespace ACBrFramework.PAF
{
	#region COM Interop

	/* NOTAS para COM INTEROP
	 * Há um modo de compilação com a diretiva COM_INTEROP que inseri atributos e código específico
	 * para a DLL ser exportada para COM (ActiveX)
	 *
	 * O modelo COM possui alguma limitações/diferenças em relação ao modelo .NET
	 * Inserir os #if COM_INTEROP para prover implementações distintas nas modificações necessárias para COM:
	 *
	 * - Inserir atributos ComVisible(true), Guid("xxx") e ClassInterface(ClassInterfaceType.AutoDual) em todas as classes envolvidas
	 *
	 * - Propriedades/métodos que usam "Decimal" devem incluir o atributo MarshalAs(UnmanagedType.Currency)
	 *   usar [return: ...] para retornos de métodos e propriedades ou [param: ...] para o set de propriedades
	 *
	 * - Métodos que recebem array como parâmetros devem fazer como "ref".
	 *   Propriedades só podem retornar arrays, nunca receber.
	 *
	 * - Overload não é permitido. Métodos com mesmos nomes devem ser renomeados.
	 *   É possível usar parâmetros default, simplificando a necessidade de Overload
	 *
	 * - Generic não deve ser usado. Todas as classes Generic devem ser re-escritas como classes específicas
	 *
	 * - Eventos precisam de uma Interface com as declarações dos métodos (eventos) com o atributo [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	 *   A classe que declara os eventos precisa do atributo [ComSourceInterfaces(typeof(INomeDaInterface))]
	 *   Nenhum delegate deverá ser Generic, precisam ser re-escritos.
	 *
	 *   OBS: Por padrão o modelo .Net recebe os eventos com a assinatura void(object sender, EventArgs e)
	 *   O modelo COM não precisa desses parâmetros. Assim o delegate EventHandler foi redefinido para uma assinatura void()
	 *   Outros EventArgs devem seguir a assitarua COM void(MyEventArg e) ao invés da assinatura .NET void(object sender, MyEventArgs e)
	 * */

#if COM_INTEROP

	#region IDispatch Interface

	#region Documentation

	/// <summary>
	/// Interface contendo os eventos publicados pelo componente COM
	/// </summary>

	#endregion Documentation

	[ComVisible(true)]
	[Guid("0AB7983D-009E-473B-85F1-8FC356DC0041")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IACBrPAFEvents
	{		
	}

	#endregion IDispatch Interface

	#region Delegates

	#region Comments

	///os componentes COM não suportam Generics
	///Estas são implementações específicas de delegates que no .Net são representados como EventHandler<T>

	#endregion Comments

	public delegate void ChaveEventHandler(ChaveEventArgs e);

	#endregion Delegates

#endif

	#endregion COM Interop

	#region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("BADFA834-3646-475D-A734-8FA882E320CA")]
	[ComSourceInterfaces(typeof(IACBrPAFEvents))]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM Interop Attributes

	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.PAF.ico.bmp")]
	public class ACBrPAF : ACBrComponent, IDisposable
	{
		#region Events

		#if COM_INTEROP

		public event ChaveEventHandler OnPAFGetKeyRSA
#else

		public event EventHandler<ChaveEventArgs> OnPafGetKeyRsa
#endif
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP
			add
			{
				onPafGetKeyRsa.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP
			remove
			{
				onPafGetKeyRsa.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<ChaveEventArgs, ACBrPAFInterop.PAFGetKeyRSACallback> onPafGetKeyRsa;

		private ACBrAAC aac;
		private ACBrEAD ead;

		#endregion Fields

		#region Constructor

		public ACBrPAF()
		{
			onPafGetKeyRsa = new ACBrEventHandler<ChaveEventArgs, ACBrPAFInterop.PAFGetKeyRSACallback>(this, OnPafGetKeyRsaCallBack, ACBrPAFInterop.PAF_SetOnPAFGetKeyRSA);
		}

		#endregion Constructor

		#region Properties

		public string Path
		{
			get
			{
				return GetString(ACBrPAFInterop.PAF_GetPath);
			}
			set
			{
				SetString(ACBrPAFInterop.PAF_SetPath, value);
			}
		}

		public string Delimitador
		{
			get
			{
				return GetString(ACBrPAFInterop.PAF_GetDelimitador);
			}
			set
			{
				SetString(ACBrPAFInterop.PAF_SetDelimitador, value);
			}
		}

		public string CurMascara
		{
			get
			{
				return GetString(ACBrPAFInterop.PAF_GetCurMascara);
			}
			set
			{
				SetString(ACBrPAFInterop.PAF_SetCurMascara, value);
			}
		}

		public bool TrimString
		{
			get
			{
				return GetBool(ACBrPAFInterop.PAF_GetTrimString);
			}
			set
			{
				SetBool(ACBrPAFInterop.PAF_SetTrimString, value);
			}
		}

		public bool AssinarArquivo
		{
			get
			{
				return GetBool(ACBrPAFInterop.PAF_GetAssinarArquivo);
			}
			set
			{
				SetBool(ACBrPAFInterop.PAF_SetAssinarArquivo, value);
			}
		}

        [Browsable(false)]
        public ACBrPAF_A PafA { get; private set; }
                        
        [Browsable(false)]
		public ACBrPAF_B PafB { get; private set; }

		[Browsable(false)]
		public ACBrPAF_C PafC { get; private set; }

		[Browsable(false)]
		public ACBrPAF_D PafD { get; private set; }

		[Browsable(false)]
		public ACBrPAF_E PafE { get; private set; }

		[Browsable(false)]
		public ACBrPAF_H PafH { get; private set; }

		[Browsable(false)]
		public ACBrPAF_N PafN { get; private set; }

		[Browsable(false)]
		public ACBrPAF_P PafP { get; private set; }

		[Browsable(false)]
		public ACBrPAF_R PafR { get; private set; }

		[Browsable(false)]
		public ACBrPAF_S PafS { get; private set; }

		[Browsable(false)]
		public ACBrPAF_T PafT { get; private set; }

        [Browsable(false)]
        public ACBrPAF_U PafU { get; private set; }

		[Browsable(false)]
		public ACBrPAF_TITP PafTitp { get; private set; }

		public ACBrAAC Aac
		{
			get
			{
				return this.aac;
			}
			set
			{
				if (value == null)
				{
					var ret = ACBrPAFInterop.PAF_SetAAC(this.Handle, IntPtr.Zero);
					CheckResult(ret);

					this.aac = null;
				}
				else
				{
					var ret = ACBrPAFInterop.PAF_SetAAC(this.Handle, value.Handle);
					CheckResult(ret);

					this.aac = value;
				}
			}
		}

		public ACBrEAD Ead
		{
			get
			{
				return this.ead;
			}
			set
			{
				if (value == null)
				{
					var ret = ACBrPAFInterop.PAF_SetEAD(this.Handle, IntPtr.Zero);
					CheckResult(ret);

					this.aac = null;
				}
				else
				{
					var ret = ACBrPAFInterop.PAF_SetEAD(this.Handle, value.Handle);
					CheckResult(ret);

					this.ead = value;
				}
			}
		}

		#endregion Properties

		#region Methods

		public bool AssinarArquivoComEad(string arquivo)
		{
			var ret = ACBrPAFInterop.PAF_AssinarArquivoComEAD(this.Handle, arquivo);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_B(string arquivo)
		{
            PAF_Preenche_B();
			var ret = ACBrPAFInterop.PAF_SaveFileTXT_B(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PafB.LimparRegistros();
			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_C(string arquivo)
        {
            PAF_Preenche_C();
			var ret = ACBrPAFInterop.PAF_SaveFileTXT_C(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PafC.LimparRegistros();
			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_D(string arquivo)
		{
            PAF_Preenche_D();
			var ret = ACBrPAFInterop.PAF_SaveFileTXT_D(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PafD.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_E(string arquivo)
		{
            PAF_Preenche_E();
			var ret = ACBrPAFInterop.PAF_SaveFileTXT_E(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PafE.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_H(string arquivo)
		{
            PAF_Preenche_H();
			var ret = ACBrPAFInterop.PAF_SaveFileTXT_H(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PafH.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_N(string arquivo)
		{
            PAF_Preenche_N();

			var ret = ACBrPAFInterop.PAF_SaveFileTXT_N(Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PafN.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_P(string arquivo)
		{
            PAF_Preenche_P();
			var ret = ACBrPAFInterop.PAF_SaveFileTXT_P(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PafP.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_R(string arquivo)
		{
            PAF_Preenche_R();
			var ret = ACBrPAFInterop.PAF_SaveFileTXT_R(Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PafR.LimparRegistros();
			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_T(string arquivo)
		{
            PAF_Preenche_T();

			var ret = ACBrPAFInterop.PAF_SaveFileTXT_T(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PafT.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_TITP(string arquivo)
		{
            PAF_Preenche_TITP();

			var ret = ACBrPAFInterop.PAF_SaveFileTXT_TITP(this.Handle, arquivo.ToUTF8());
			CheckResult(ret);
			PafTitp.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

        public bool SaveFileTXT_RegistrosECF(string arquivo)
        {
            #region Preenche os registros
                        
            PAF_Preenche_A();
            PAF_Preenche_B();
            PAF_Preenche_C();
            PAF_Preenche_D();
            PAF_Preenche_E();
            PAF_Preenche_H();
            PAF_Preenche_N();
            PAF_Preenche_P();
            PAF_Preenche_R();
            PAF_Preenche_T();
            PAF_Preenche_S();
            PAF_Preenche_U();

            #endregion

            var ret = ACBrPAFInterop.PAF_SaveFileTXT_RegistrosPAF(Handle, arquivo.ToUTF8());

            CheckResult(ret);
            LimparRegistros();
            return Convert.ToBoolean(ret);
        }

        #region Preenche Registros

        private void PAF_Preenche_T()
        {
            int i;
            var registroT1Rec = new ACBrPAFInterop.RegistroHD1Rec();
            var registroT2Rec = new ACBrPAFInterop.RegistroT2Rec[PafT.RegistroT2.Count];

            registroT1Rec.RAZAOSOCIAL = ToUTF8(PafT.RegistroT1.RazaoSocial);
            registroT1Rec.CNPJ = ToUTF8(PafT.RegistroT1.CNPJ);
            registroT1Rec.UF = ToUTF8(PafT.RegistroT1.UF);
            registroT1Rec.IE = ToUTF8(PafT.RegistroT1.IE);
            registroT1Rec.IM = ToUTF8(PafT.RegistroT1.IM);

            for (i = 0; i < PafT.RegistroT2.Count; i++)
            {
                registroT2Rec[i].DT_MOV = PafT.RegistroT2[i].DT_MOV.ToOADate();
                registroT2Rec[i].TP_DOCTO = ToUTF8(PafT.RegistroT2[i].TP_DOCTO);
                registroT2Rec[i].SERIE = ToUTF8(PafT.RegistroT2[i].SERIE);
                registroT2Rec[i].NUM_BILH_I = PafT.RegistroT2[i].NUM_BILH_I;
                registroT2Rec[i].NUM_BILH_F = PafT.RegistroT2[i].NUM_BILH_F;
                registroT2Rec[i].NUM_ECF = ToUTF8(PafT.RegistroT2[i].NUM_ECF);
                registroT2Rec[i].CRZ = PafT.RegistroT2[i].CRZ;
                registroT2Rec[i].CFOP = ToUTF8(PafT.RegistroT2[i].CFOP);
                registroT2Rec[i].VL_CONT = PafT.RegistroT2[i].VL_CONT;
                registroT2Rec[i].VL_BASECALC = PafT.RegistroT2[i].VL_BASECALC;
                registroT2Rec[i].ALIQ = PafT.RegistroT2[i].ALIQ;
                registroT2Rec[i].VL_IMPOSTO = PafT.RegistroT2[i].VL_IMPOSTO;
                registroT2Rec[i].VL_ISENTAS = PafT.RegistroT2[i].VL_ISENTAS;
                registroT2Rec[i].VL_OUTRAS = PafT.RegistroT2[i].VL_OUTRAS;
                registroT2Rec[i].RegistroValido = PafT.RegistroT2[i].RegistroValido;
            }

            var ret = ACBrPAFInterop.PAF_Preenche_T(Handle, registroT1Rec, registroT2Rec, PafT.RegistroT2.Count);
            CheckResult(ret);
        }

        private void PAF_Preenche_U()
        {
            var registroU1Rec = new ACBrPAFInterop.RegistroHD1Rec
            {
                CNPJ = PafU.RegistroU1.CNPJ,
                IE = PafU.RegistroU1.IE,
                IM = PafU.RegistroU1.IM,
                RAZAOSOCIAL = PafU.RegistroU1.RazaoSocial
            };

            var ret = ACBrPAFInterop.PAF_Preenche_U(Handle, registroU1Rec);
            CheckResult(ret);
        }

        private void PAF_Preenche_N()
        {
            int i;

            var registroN1Rec = new ACBrPAFInterop.RegistroHD1Rec();
            var registroN2Rec = new ACBrPAFInterop.RegistroN2Rec();
            var registroN3Rec = new ACBrPAFInterop.RegistroN3Rec[PafN.RegistroN3.Count];

            registroN1Rec.RAZAOSOCIAL = ToUTF8(PafN.RegistroN1.RazaoSocial);
            registroN1Rec.CNPJ = ToUTF8(PafN.RegistroN1.CNPJ);
            registroN1Rec.UF = ToUTF8(PafN.RegistroN1.UF);
            registroN1Rec.IE = ToUTF8(PafN.RegistroN1.IE);
            registroN1Rec.IM = ToUTF8(PafN.RegistroN1.IM);

            registroN2Rec.NOME = ToUTF8(PafN.RegistroN2.NOME);
            registroN2Rec.LAUDO = ToUTF8(PafN.RegistroN2.LAUDO);
            registroN2Rec.VERSAO = ToUTF8(PafN.RegistroN2.VERSAO);

            for (i = 0; i < PafN.RegistroN3.Count; i++)
            {
                registroN3Rec[i].NOME_ARQUIVO = ToUTF8(PafN.RegistroN3[i].NOME_ARQUIVO);
                registroN3Rec[i].MD5 = ToUTF8(PafN.RegistroN3[i].MD5);
            }

            var ret = ACBrPAFInterop.PAF_Preenche_N(Handle, registroN1Rec, registroN2Rec, registroN3Rec, PafN.RegistroN3.Count);
            CheckResult(ret);
        }

        private void PAF_Preenche_R()
        {
            #region Contadores

            int itemR1 = 0, itemR2 = 0, itemR3 = 0, itemR4 = 0, itemR5 = 0, itemR6 = 0, itemR7 = 0;
			var cr2 = PafR.RegistroR1.Sum(s => s.RegistroR2.Count);
			var cr3 = PafR.RegistroR1.Sum(s => s.RegistroR2.Sum(c => c.RegistroR3.Count));
			var cr4 = PafR.RegistroR1.Sum(s => s.RegistroR4.Count);
			var cr5 = PafR.RegistroR1.Sum(s => s.RegistroR4.Sum(c => c.RegistroR5.Count));
			var cr6 = PafR.RegistroR1.Sum(s => s.RegistroR6.Count);
			var cr7 = PafR.RegistroR1.Sum(s => s.RegistroR4.Sum(c => c.RegistroR7.Count) +
											   s.RegistroR6.Sum(c => c.RegistroR7.Count));

			#endregion Contadores

            #region Arrays

            var registrosR1Rec = new ACBrPAFInterop.RegistroR1Rec[PafR.RegistroR1.Count];
            var registrosR2Rec = new ACBrPAFInterop.RegistroR2Rec[cr2];
            var registrosR3Rec = new ACBrPAFInterop.RegistroR3Rec[cr3];
            var registrosR4Rec = new ACBrPAFInterop.RegistroR4Rec[cr4];
            var registrosR5Rec = new ACBrPAFInterop.RegistroR5Rec[cr5];
            var registrosR6Rec = new ACBrPAFInterop.RegistroR6Rec[cr6];
            var registrosR7Rec = new ACBrPAFInterop.RegistroR7Rec[cr7];

            #endregion

            foreach(ACBrPAFRegistroR1 r1 in PafR.RegistroR1)
            {
                #region R1

                registrosR1Rec[itemR1].QTD_R2 = r1.RegistroR2.Count;
                registrosR1Rec[itemR1].QTD_R4 = r1.RegistroR4.Count;
                registrosR1Rec[itemR1].QTD_R6 = r1.RegistroR6.Count;
                registrosR1Rec[itemR1].NUM_FAB = ToUTF8(r1.NUM_FAB);
                registrosR1Rec[itemR1].MF_ADICIONAL = ToUTF8(r1.MF_ADICIONAL);
                registrosR1Rec[itemR1].TIPO_ECF = ToUTF8(r1.TIPO_ECF);
                registrosR1Rec[itemR1].MARCA_ECF = ToUTF8(r1.MARCA_ECF);
                registrosR1Rec[itemR1].MODELO_ECF = ToUTF8(r1.MODELO_ECF);
                registrosR1Rec[itemR1].VERSAO_SB = ToUTF8(r1.VERSAO_SB);
                registrosR1Rec[itemR1].DT_INST_SB = r1.DT_INST_SB.ToOADate();
                registrosR1Rec[itemR1].HR_INST_SB = r1.HR_INST_SB.ToOADate();
                registrosR1Rec[itemR1].NUM_SEQ_ECF = r1.NUM_SEQ_ECF;
                registrosR1Rec[itemR1].CNPJ = ToUTF8(r1.CNPJ);
                registrosR1Rec[itemR1].IE = ToUTF8(r1.IE);
                registrosR1Rec[itemR1].CNPJ_SH = ToUTF8(r1.CNPJ_SH);
                registrosR1Rec[itemR1].IE_SH = ToUTF8(r1.IE_SH);
                registrosR1Rec[itemR1].IM_SH = ToUTF8(r1.IM_SH);
                registrosR1Rec[itemR1].NOME_SH = ToUTF8(r1.NOME_SH);
                registrosR1Rec[itemR1].NOME_PAF = ToUTF8(r1.NOME_PAF);
                registrosR1Rec[itemR1].VER_PAF = ToUTF8(r1.VER_PAF);
                registrosR1Rec[itemR1].COD_MD5 = ToUTF8(r1.COD_MD5);
                registrosR1Rec[itemR1].DT_INI = r1.DT_INI.ToOADate();
                registrosR1Rec[itemR1].DT_FIN = r1.DT_FIN.ToOADate();
                registrosR1Rec[itemR1].ER_PAF_ECF = ToUTF8(r1.ER_PAF_ECF);
                registrosR1Rec[itemR1].InclusaoExclusao = r1.InclusaoExclusao;
                registrosR1Rec[itemR1].RegistroValido = r1.RegistroValido;

                #endregion

                #region R2 e R3

                foreach(ACBrPAFRegistroR2 r2 in r1.RegistroR2)
                {
                    registrosR2Rec[itemR2].QTD_R3 = r2.RegistroR3.Count;
                    registrosR2Rec[itemR2].NUM_USU = r2.NUM_USU;
                    registrosR2Rec[itemR2].CRZ = r2.CRZ;
                    registrosR2Rec[itemR2].COO = r2.COO;
                    registrosR2Rec[itemR2].CRO = r2.CRO;
                    registrosR2Rec[itemR2].DT_MOV = r2.DT_MOV.ToOADate();
                    registrosR2Rec[itemR2].DT_EMI = r2.DT_EMI.ToOADate();
                    registrosR2Rec[itemR2].HR_EMI = r2.HR_EMI.ToOADate();
                    registrosR2Rec[itemR2].VL_VBD = Convert.ToDouble(r2.VL_VBD);
                    registrosR2Rec[itemR2].PAR_ECF = ToUTF8(r2.PAR_ECF);
                    registrosR2Rec[itemR2].RegistroValido = r2.RegistroValido;

                    foreach(ACBrPAFRegistroR3 registroR3 in r2.RegistroR3)
                    {
                        registrosR3Rec[itemR3].TOT_PARCIAL = ToUTF8(registroR3.TOT_PARCIAL);
                        registrosR3Rec[itemR3].VL_ACUM = Convert.ToDouble(registroR3.VL_ACUM);
                        registrosR3Rec[itemR3].RegistroValido = registroR3.RegistroValido;
                        itemR3++;
                    }

                    itemR2++;
                }

                #endregion

                #region R4, R5 e R7
                foreach(ACBrPAFRegistroR4 r4 in r1.RegistroR4)
                {
                    registrosR4Rec[itemR4].QTD_R5 = r4.RegistroR5.Count;
                    registrosR4Rec[itemR4].QTD_R7 = r4.RegistroR7.Count;
                    registrosR4Rec[itemR4].NUM_USU = r4.NUM_USU;
                    registrosR4Rec[itemR4].NUM_CONT = r4.NUM_CONT;
                    registrosR4Rec[itemR4].COO = r4.COO;
                    registrosR4Rec[itemR4].DT_INI = r4.DT_INI.ToOADate();
                    registrosR4Rec[itemR4].SUB_DOCTO = Convert.ToDouble(r4.SUB_DOCTO);
                    registrosR4Rec[itemR4].SUB_DESCTO = Convert.ToDouble(r4.SUB_DESCTO);
                    registrosR4Rec[itemR4].TP_DESCTO = ToUTF8(r4.TP_DESCTO);
                    registrosR4Rec[itemR4].SUB_ACRES = Convert.ToDouble(r4.SUB_ACRES);
                    registrosR4Rec[itemR4].TP_ACRES = ToUTF8(r4.TP_ACRES);
                    registrosR4Rec[itemR4].VL_TOT = Convert.ToDouble(r4.VL_TOT);
                    registrosR4Rec[itemR4].CANC = ToUTF8(r4.CANC);
                    registrosR4Rec[itemR4].VL_CA = Convert.ToDouble(r4.VL_CA);
                    registrosR4Rec[itemR4].ORDEM_DA = ToUTF8(r4.ORDEM_DA);
                    registrosR4Rec[itemR4].NOME_CLI = ToUTF8(r4.NOME_CLI);
                    registrosR4Rec[itemR4].CNPJ_CPF = ToUTF8(r4.CNPJ_CPF);
                    registrosR4Rec[itemR4].RegistroValido = r4.RegistroValido;

                    foreach(ACBrPAFRegistroR5 registroR5 in r4.RegistroR5)
                    {
                        registrosR5Rec[itemR5].NUM_CONT = registroR5.NUM_CONT;
                        registrosR5Rec[itemR5].NUM_ITEM = registroR5.NUM_ITEM;
                        registrosR5Rec[itemR5].COD_ITEM = ToUTF8(registroR5.COD_ITEM);
                        registrosR5Rec[itemR5].DESC_ITEM = ToUTF8(registroR5.DESC_ITEM);
                        registrosR5Rec[itemR5].QTDE_ITEM = Convert.ToDouble(registroR5.QTDE_ITEM);
                        registrosR5Rec[itemR5].UN_MED = ToUTF8(registroR5.UN_MED);
                        registrosR5Rec[itemR5].VL_UNIT = Convert.ToDouble(registroR5.VL_UNIT);
                        registrosR5Rec[itemR5].DESCTO_ITEM = Convert.ToDouble(registroR5.DESCTO_ITEM);
                        registrosR5Rec[itemR5].ACRES_ITEM = Convert.ToDouble(registroR5.ACRES_ITEM);
                        registrosR5Rec[itemR5].VL_TOT_ITEM = Convert.ToDouble(registroR5.VL_TOT_ITEM);
                        registrosR5Rec[itemR5].COD_TOT_PARC = ToUTF8(registroR5.COD_TOT_PARC);
                        registrosR5Rec[itemR5].IND_CANC = ToUTF8(registroR5.IND_CANC);
                        registrosR5Rec[itemR5].QTDE_CANC = Convert.ToDouble(registroR5.QTDE_CANC);
                        registrosR5Rec[itemR5].VL_CANC = Convert.ToDouble(registroR5.VL_CANC);
                        registrosR5Rec[itemR5].VL_CANC_ACRES = Convert.ToDouble(registroR5.VL_CANC_ACRES);
                        registrosR5Rec[itemR5].IAT = ToUTF8(registroR5.IAT);
                        registrosR5Rec[itemR5].IPPT = ToUTF8(registroR5.IPPT);
                        registrosR5Rec[itemR5].QTDE_DECIMAL = registroR5.QTDE_DECIMAL;
                        registrosR5Rec[itemR5].VL_DECIMAL = registroR5.VL_DECIMAL;
                        registrosR5Rec[itemR5].RegistroValido = registroR5.RegistroValido;
                        itemR5++;
                    }

                    foreach(ACBrPAFRegistroR7 registroR7 in r4.RegistroR7)
                    {
						registrosR7Rec[itemR7].COO = registroR7.COO;
                        registrosR7Rec[itemR7].CCF = registroR7.CCF;
                        registrosR7Rec[itemR7].GNF = registroR7.GNF;
                        registrosR7Rec[itemR7].MP = ToUTF8(registroR7.MP);
                        registrosR7Rec[itemR7].VL_PAGTO = Convert.ToDouble(registroR7.VL_PAGTO);
                        registrosR7Rec[itemR7].IND_EST = ToUTF8(registroR7.IND_EST);
                        registrosR7Rec[itemR7].VL_EST = Convert.ToDouble(registroR7.VL_EST);
                        registrosR7Rec[itemR7].RegistroValido = registroR7.RegistroValido;
                        itemR7++;
                    }

                    itemR4++;
                }
                #endregion

                #region R6 e R7

                foreach(ACBrPAFRegistroR6 r6 in r1.RegistroR6)
                {
                    registrosR6Rec[itemR6].QTD_R7 = r6.RegistroR7.Count;
                    registrosR6Rec[itemR6].NUM_USU = r6.NUM_USU;
                    registrosR6Rec[itemR6].COO = r6.COO;
                    registrosR6Rec[itemR6].GNF = r6.GNF;
                    registrosR6Rec[itemR6].GRG = r6.GRG;
                    registrosR6Rec[itemR6].CDC = r6.CDC;
                    registrosR6Rec[itemR6].DENOM = ToUTF8(r6.DENOM);
                    registrosR6Rec[itemR6].DT_FIN = r6.DT_FIN.ToOADate();
                    registrosR6Rec[itemR6].HR_FIN = r6.HR_FIN.ToOADate();
                    registrosR6Rec[itemR6].RegistroValido = r6.RegistroValido;

                    foreach(ACBrPAFRegistroR7 registroR7 in r6.RegistroR7)
                    {
						registrosR7Rec[itemR7].COO = registroR7.COO;
                        registrosR7Rec[itemR7].CCF = registroR7.CCF;
                        registrosR7Rec[itemR7].GNF = registroR7.GNF;
                        registrosR7Rec[itemR7].MP = ToUTF8(registroR7.MP);
                        registrosR7Rec[itemR7].VL_PAGTO = Convert.ToDouble(registroR7.VL_PAGTO);
                        registrosR7Rec[itemR7].IND_EST = ToUTF8(registroR7.IND_EST);
                        registrosR7Rec[itemR7].VL_EST = Convert.ToDouble(registroR7.VL_EST);
                        registrosR7Rec[itemR7].RegistroValido = registroR7.RegistroValido;
                        itemR7++;
                    }

                    itemR6++;
                }

                #endregion

                itemR1++;
            }

            var ret = ACBrPAFInterop.PAF_Preenche_R(Handle, PafR.RegistroR1.Count,
                                                            registrosR1Rec,
                                                            registrosR2Rec,
                                                            registrosR3Rec,
                                                            registrosR4Rec,
                                                            registrosR5Rec,
                                                            registrosR6Rec,
                                                            registrosR7Rec);
            CheckResult(ret);
        }

        private void PAF_Preenche_P()
        {
            var registroP1Rec = new ACBrPAFInterop.RegistroHD1Rec
            {
                CNPJ = PafP.RegistroP1.CNPJ,
                IE = PafP.RegistroP1.IE,
                IM = PafP.RegistroP1.IM,
                RAZAOSOCIAL = PafP.RegistroP1.RazaoSocial,
                UF = PafP.RegistroP1.UF
            };

            var registrosP2Rec = (from x in PafP.RegistroP2
                                                             select new ACBrPAFInterop.RegistroP2Rec
                                                             {
                                                                 ALIQ = (double)x.ALIQ,
                                                                 COD_MERC_SERV = x.COD_MERC_SERV,
                                                                 DESC_MERC_SERV = x.DESC_MERC_SERV,
                                                                 IAT = x.IAT,
                                                                 IPPT = x.IPPT,
                                                                 RegistroValido = x.RegistroValido,
                                                                 ST = x.ST,
                                                                 UN_MED = x.UN_MED,
                                                                 VL_UNIT = (double)x.VL_UNIT
                                                             }).ToArray();

            var ret = ACBrPAFInterop.PAF_Preenche_P(Handle, registroP1Rec, registrosP2Rec, registrosP2Rec.Count());
            CheckResult(ret);
        }

	    private void PAF_Preenche_S()
	    {
	        if (PafS.RegistroS2.Count < 1)
	            return;

	        var registrosS2Rec = (from x in PafS.RegistroS2
	            select new ACBrPAFInterop.RegistroS2Rec
	            {
	                QTD_S3 = x.RegistroS3.Count,
	                CNPJ = ToUTF8(x.CNPJ),
	                DT_ABER = x.DT_ABER.ToOADate(),
	                SITU = ToUTF8(x.SITU),
	                VL_TOT = (double) x.VL_TOT,
	                COO_CM = ToUTF8(x.COO_CM),
	                NUM_FAB_CM = ToUTF8(x.NUM_FAB_CM),
	                COO = ToUTF8(x.COO),
	                NUM_FAB = ToUTF8(x.NUM_FAB)
	            }).ToArray();

            var s3Count = PafS.RegistroS2.Sum(x => x.RegistroS3.Count);
	        var registrosS3Rec = new ACBrPAFInterop.RegistroS3Rec[0];
	        if (s3Count > 0)
	        {
	            registrosS3Rec = (from s in ((from x in PafS.RegistroS2 select x.RegistroS3.AsEnumerable())
	                .Aggregate((i, j) => i.Concat(j)))
	                select new ACBrPAFInterop.RegistroS3Rec
	                {
	                    COD_ITEM = ToUTF8(s.COD_ITEM),
	                    DESC_ITEM = ToUTF8(s.DESC_ITEM),
	                    QTDE_ITEM = (double) s.QTDE_ITEM,
	                    UNI_ITEM = ToUTF8(s.UNI_ITEM),
	                    VL_UNIT = (double) s.VL_UNIT
	                }).ToArray();
	        }

	        var ret = ACBrPAFInterop.PAF_Preenche_S(Handle, registrosS2Rec.Length, registrosS2Rec, registrosS3Rec);
	        CheckResult(ret);
	    }

	    private void PAF_Preenche_E()
        {
            #region E1
            var registroE1Rec = new ACBrPAFInterop.RegistroHD2Rec
            {
                RAZAOSOCIAL = ToUTF8(PafE.RegistroE1.RazaoSocial),
                CNPJ = ToUTF8(PafE.RegistroE1.CNPJ),
                UF = ToUTF8(PafE.RegistroE1.UF),
                IE = ToUTF8(PafE.RegistroE1.IE),
                IM = ToUTF8(PafE.RegistroE1.IM),
                TIPO_ECF = ToUTF8(PafE.RegistroE1.TIPO_ECF),
                MARCA_ECF = ToUTF8(PafE.RegistroE1.MARCA_ECF),
                MODELO_ECF = ToUTF8(PafE.RegistroE1.MODELO_ECF),
                NUM_FAB = ToUTF8(PafE.RegistroE1.NUM_FAB),
                MF_ADICIONAL = ToUTF8(PafE.RegistroE1.MF_ADICIONAL),
                DT_EST = PafE.RegistroE1.DT_EST.ToOADate(),
                RegistroValido = PafE.RegistroE1.RegistroValido,
                InclusaoExclusao = PafE.RegistroE1.InclusaoExclusao
            };
            #endregion

            #region E2
            var registrosE2Rec = (from x in PafE.RegistroE2
                                                             select new ACBrPAFInterop.RegistroE2Rec
                                                             {
                                                                 COD_MERC = ToUTF8(x.COD_MERC),
                                                                 DESC_MERC = ToUTF8(x.DESC_MERC),
                                                                 UN_MED = ToUTF8(x.UN_MED),
                                                                 QTDE_EST = Convert.ToDouble(x.QTDE_EST),
                                                                 RegistroValido = x.RegistroValido,
                                                             }).ToArray();
            #endregion

            #region E3
            var registroE3Rec = new ACBrPAFInterop.RegistroE3Rec
            {
                DataEstoque = PafE.RegistroE3.DataEstoque.ToOADate(),
                MarcaECF = PafE.RegistroE3.MarcaECF,
                MFAdicional = PafE.RegistroE3.MFAdicional,
                ModeloECF = PafE.RegistroE3.ModeloECF,
                NumeroFabricacao = PafE.RegistroE3.NumeroFabricacao,
                RegistroValido = PafE.RegistroE3.RegistroValido,
                TipoECF = PafE.RegistroE3.TipoECF,
            };
            #endregion

            var ret = ACBrPAFInterop.PAF_Preenche_E(Handle, registroE1Rec, registrosE2Rec, registroE3Rec, PafE.RegistroE2.Count);
            CheckResult(ret);
        }

        private void PAF_Preenche_H()
        {
            #region H1

			var registroH1Rec = new ACBrPAFInterop.RegistroHD2Rec() 
			{ 
				RAZAOSOCIAL = ToUTF8(PafH.RegistroH1.RazaoSocial), 
				CNPJ = ToUTF8(PafH.RegistroH1.CNPJ),
				UF = ToUTF8(PafH.RegistroH1.UF),
				IE = ToUTF8(PafH.RegistroH1.IE),
				IM = ToUTF8(PafH.RegistroH1.IM),
				TIPO_ECF = ToUTF8(PafH.RegistroH1.TIPO_ECF),
				MARCA_ECF = ToUTF8(PafH.RegistroH1.MARCA_ECF),
				MODELO_ECF = ToUTF8(PafH.RegistroH1.MODELO_ECF),
				NUM_FAB = ToUTF8(PafH.RegistroH1.NUM_FAB),
				MF_ADICIONAL = ToUTF8(PafH.RegistroH1.MF_ADICIONAL),
				DT_EST = PafH.RegistroH1.DT_EST.ToOADate(),
				RegistroValido = PafH.RegistroH1.RegistroValido,
				InclusaoExclusao = PafH.RegistroH1.InclusaoExclusao
			};
            
			#endregion

            #region H2

            var registroH2Rec = (from x in PafH.RegistroH2
                                                            select new ACBrPAFInterop.RegistroH2Rec
                                                            {
                                                                CNPJ_CRED_CARTAO = x.CNPJ_CRED_CARTAO,
                                                                COO = x.COO,
                                                                CCF = x.CCF,
                                                                VLR_TROCO = (double)x.VLR_TROCO,
                                                                DT_TROCO = x.DT_TROCO.ToOADate(),
                                                                CPF = x.CPF,
                                                                Titulo = x.Titulo,
                                                                RegistroValido = false
                                                            }).ToArray();

            #endregion

            var ret = ACBrPAFInterop.PAF_Preenche_H(Handle, registroH1Rec, registroH2Rec, PafH.RegistroH2.Count);
            CheckResult(ret);
        }

	    private void PAF_Preenche_D()
	    {
	        #region D1

	        var registroD1Rec = new ACBrPAFInterop.RegistroHD1Rec()
	        {
	            RAZAOSOCIAL = ToUTF8(PafD.RegistroD1.RazaoSocial),
	            CNPJ = ToUTF8(PafD.RegistroD1.CNPJ),
	            UF = ToUTF8(PafD.RegistroD1.UF),
	            IE = ToUTF8(PafD.RegistroD1.IE),
	            IM = ToUTF8(PafD.RegistroD1.IM)
	        };

	        #endregion D1

	        #region D2

	        var registrosD2Rec = (from x in PafD.RegistroD2
	            select new ACBrPAFInterop.RegistroD2Rec
	            {
	                QTD_D3 = x.RegistroD3.Count,
	                QTD_D4 = x.RegistroD4.Count,
	                NUM_FAB = ToUTF8(x.NUM_FAB),
	                MF_ADICIONAL = ToUTF8(x.MF_ADICIONAL),
	                TIPO_ECF = ToUTF8(x.TIPO_ECF),
	                MARCA_ECF = ToUTF8(x.MARCA_ECF),
	                MODELO_ECF = ToUTF8(x.MODELO_ECF),
	                COO = ToUTF8(x.COO),
	                NUM_DAV = ToUTF8(x.NUM_DAV),
	                DT_DAV = x.DT_DAV.ToOADate(),
	                TIT_DAV = ToUTF8(x.TIT_DAV),
	                VLT_DAV = Convert.ToDouble(x.VLT_DAV),
	                COO_DFV = ToUTF8(x.COO_DFV),
	                NUMERO_ECF = ToUTF8(x.NUMERO_ECF),
	                NOME_CLIENTE = ToUTF8(x.NOME_CLIENTE),
	                CPF_CNPJ = ToUTF8(x.CPF_CNPJ),
	                RegistroValido = x.RegistroValido
	            }).ToArray();

	        #endregion

	        #region D3

	        var d3Count = PafD.RegistroD2.Sum(x => x.RegistroD3.Count);
	        var registrosD3Rec = new ACBrPAFInterop.RegistroD3Rec[0];
	        if (d3Count > 0)
	        {
	            registrosD3Rec = (((from x in PafD.RegistroD2
	                where x.RegistroD3.Any()
	                select x.RegistroD3.AsEnumerable())
	                .Aggregate((pafRegistroD3S, registroD3S) =>
	                {
	                    if (pafRegistroD3S != null && registroD3S != null)
	                        return pafRegistroD3S.Concat(registroD3S);

	                    return new List<ACBrPAFRegistroD3>().AsEnumerable();
	                })).Select(s => new ACBrPAFInterop.RegistroD3Rec
	                {
	                    DT_INCLUSAO = s.DT_INCLUSAO.ToOADate(),
	                    NUM_ITEM = s.NUM_ITEM,
	                    COD_ITEM = ToUTF8(s.COD_ITEM),
	                    DESC_ITEM = ToUTF8(s.DESC_ITEM),
	                    QTDE_ITEM = Convert.ToDouble(s.QTDE_ITEM),
	                    UNI_ITEM = ToUTF8(s.UNI_ITEM),
	                    VL_UNIT = Convert.ToDouble(s.VL_UNIT),
	                    VL_DESCTO = Convert.ToDouble(s.VL_DESCTO),
	                    VL_ACRES = Convert.ToDouble(s.VL_ACRES),
	                    VL_TOTAL = Convert.ToDouble(s.VL_TOTAL),
	                    DEC_VL_UNIT = s.DEC_VL_UNIT,
	                    DEC_QTDE_ITEM = s.DEC_QTDE_ITEM,
	                    SIT_TRIB = ToUTF8(s.SIT_TRIB),
	                    ALIQ = Convert.ToDouble(s.ALIQ),
	                    IND_CANC = ToUTF8(s.IND_CANC),
	                    RegistroValido = s.RegistroValido
	                })).ToArray();
	        }

	        #endregion D3

	        #region D4

	        var d4Count = PafD.RegistroD2.Sum(x => x.RegistroD4.Count);
	        var registrosD4Rec = new ACBrPAFInterop.RegistroD4Rec[0];
	        if (d4Count > 0)
	        {
	            registrosD4Rec = (from s in
	                ((from x in PafD.RegistroD2 where x.RegistroD4.Any() select x.RegistroD4.AsEnumerable())
	                    .Where(i => i.Any()).Aggregate((i, j) => i.Concat(j)))
	                select new ACBrPAFInterop.RegistroD4Rec
	                {
	                    NumeroDAV = s.NumeroDAV,
	                    DataAlteracao = s.DataAlteracao.ToOADate(),
	                    CodigoProdutoServico = s.CodigoProdutoServico,
	                    Descricao = s.Descricao,
	                    Quantidade = (double) s.Quantidade,
	                    Unidade = s.Unidade,
	                    ValorUnitario = (double) s.ValorUnitario,
	                    DescontoSobreItem = (double) s.DescontoSobreItem,
	                    AcrescimoSobreItem = (double) s.AcrescimoSobreItem,
	                    ValorTotalLiquido = (double) s.ValorTotalLiquido,
	                    SituacaoTributaria = s.SituacaoTributaria,
	                    Aliquota = (double) s.Aliquota,
	                    IndicadorCancelamento = s.IndicadorCancelamento,
	                    CasasDecimaisQtd = s.CasasDecimaisQtd,
	                    CasasDecimaisVlUn = s.CasasDecimaisVlUn,
	                    TipoAlteracao = s.TipoAlteracao
	                }).ToArray();
	        }

	        #endregion D4			

	        var ret = ACBrPAFInterop.PAF_Preenche_D(Handle, registroD1Rec, registrosD2Rec, PafD.RegistroD2.Count,
	            registrosD3Rec, registrosD4Rec, registrosD4Rec.Count());
	        CheckResult(ret);
	    }

	    private void PAF_Preenche_C()
        {
            #region C1
            var registroC1Rec = new ACBrPAFInterop.RegistroHD1Rec
                {
                    RAZAOSOCIAL = ToUTF8(PafC.RegistroC1.RazaoSocial),
                    CNPJ = ToUTF8(PafC.RegistroC1.CNPJ),
                    UF = ToUTF8(PafC.RegistroC1.UF),
                    IE = ToUTF8(PafC.RegistroC1.IE),
                    IM = ToUTF8(PafC.RegistroC1.IM)
                };
            #endregion

            #region C2
            var registrosC2Rec = (from x in PafC.RegistroC2
                                                             select new ACBrPAFInterop.RegistroC2Rec
                                                             {
                                                                 ID_ABASTECIMENTO = ToUTF8(x.ID_ABASTECIMENTO),
                                                                 TANQUE = ToUTF8(x.TANQUE),
                                                                 BOMBA = ToUTF8(x.BOMBA),
                                                                 COMBUSTIVEL = ToUTF8(x.COMBUSTIVEL),
                                                                 DATA_ABASTECIMENTO = x.DATA_ABASTECIMENTO.ToOADate(),
                                                                 HORA_ABASTECIMENTO = x.HORA_ABASTECIMENTO.ToOADate(),
                                                                 ENCERRANTE_INICIAL = Convert.ToDouble(x.ENCERRANTE_INICIAL),
                                                                 ENCERRANTE_FINAL = Convert.ToDouble(x.ENCERRANTE_FINAL),
                                                                 STATUS_ABASTECIMENTO = ToUTF8(x.STATUS_ABASTECIMENTO),
                                                                 NRO_SERIE_ECF = ToUTF8(x.NRO_SERIE_ECF),
                                                                 DATA = x.DATA.ToOADate(),
                                                                 HORA = x.HORA.ToOADate(),
                                                                 COO = x.COO,
                                                                 NRO_NOTA_FISCAL = x.NRO_NOTA_FISCAL,
                                                                 VOLUME = Convert.ToDouble(x.VOLUME),
                                                                 RegistroValido = x.RegistroValido
                                                             }).ToArray();

            #endregion

            var ret = ACBrPAFInterop.PAF_Preenche_C(Handle, registroC1Rec, registrosC2Rec, PafC.RegistroC2.Count);
            CheckResult(ret);
        }

        private void PAF_Preenche_B()
        {
            #region B1
            var registroB1Rec = new ACBrPAFInterop.RegistroHD1Rec
            {
                RAZAOSOCIAL = ToUTF8(PafB.RegistroB1.RazaoSocial),
                CNPJ = ToUTF8(PafB.RegistroB1.CNPJ),
                UF = ToUTF8(PafB.RegistroB1.UF),
                IE = ToUTF8(PafB.RegistroB1.IE),
                IM = ToUTF8(PafB.RegistroB1.IM)
            };
            #endregion

            #region B2
            var registrosB2Rec = (from x in PafB.RegistroB2
                                                             select new ACBrPAFInterop.RegistroB2Rec
                                                             {
                                                                 BOMBA = ToUTF8(x.BOMBA),
                                                                 BICO = ToUTF8(x.BICO),
                                                                 DATA = x.DATA.ToOADate(),
                                                                 HORA = x.HORA.ToOADate(),
                                                                 MOTIVO = ToUTF8(x.MOTIVO),
                                                                 CNPJ_EMPRESA = ToUTF8(x.CNPJ_EMPRESA),
                                                                 CPF_TECNICO = ToUTF8(x.CPF_TECNICO),
                                                                 NRO_LACRE_ANTES = ToUTF8(x.NRO_LACRE_ANTES),
                                                                 NRO_LACRE_APOS = ToUTF8(x.NRO_LACRE_ANTES),
                                                                 ENCERRANTE_ANTES = Convert.ToDouble(x.ENCERRANTE_ANTES),
                                                                 ENCERRANTE_APOS = Convert.ToDouble(x.ENCERRANTE_APOS),
                                                                 RegistroValido = x.RegistroValido
                                                             }).ToArray();
            #endregion

            var ret = ACBrPAFInterop.PAF_Preenche_B(Handle, registroB1Rec, registrosB2Rec, PafB.RegistroB2.Count);
            CheckResult(ret);
        }

        private void PAF_Preenche_A()
        {
            var registrosA2Rec = (from x in PafA.RegistroA2
                                                             select new ACBrPAFInterop.RegistroA2Rec
                                                             {
                                                                 CodigoTipoDocumento = ((int)x.CodigoTipoDocumento).ToString(),
                                                                 Data = x.Data.ToOADate(),
                                                                 MeioDePagamento = x.MeioPagamento,
                                                                 RegistroValido = x.RegistroValido,
																 Valor = (double)x.Valor
                                                             }).ToArray();

            var ret = ACBrPAFInterop.PAF_Preenche_A(Handle, registrosA2Rec, PafA.RegistroA2.Count);
            CheckResult(ret);
        }

        private void PAF_Preenche_TITP()
        {
            var itemIndex = 0;
			var insumosCount = PafTitp.Mercadorias.Sum(s => s.Insumos.Count);

            var mercadoriasRec = new ACBrPAFInterop.RegistroMercadoriasRec[PafTitp.Mercadorias.Count];
            var insumosRec = new ACBrPAFInterop.RegistroInsumosRec[insumosCount];

            for (var i = 0; i < PafTitp.Mercadorias.Count; i++)
            {
                mercadoriasRec[i].Descricao = ToUTF8(PafTitp.Mercadorias[i].Descricao);
                mercadoriasRec[i].Codigo = ToUTF8(PafTitp.Mercadorias[i].Codigo);
                mercadoriasRec[i].Aliquota = Convert.ToDouble(PafTitp.Mercadorias[i].Aliquota);
                mercadoriasRec[i].Unidade = ToUTF8(PafTitp.Mercadorias[i].Unidade);
                mercadoriasRec[i].Quantidade = Convert.ToDouble(PafTitp.Mercadorias[i].Quantidade);
                mercadoriasRec[i].Ean = ToUTF8(PafTitp.Mercadorias[i].Ean);
                mercadoriasRec[i].CST = ToUTF8(PafTitp.Mercadorias[i].CST);
                mercadoriasRec[i].VlrUnitario = Convert.ToDouble(PafTitp.Mercadorias[i].VlrUnitario);
                mercadoriasRec[i].QTD_Insumos = PafTitp.Mercadorias[i].Insumos.Count;

                foreach (ACBrPAFRegistroInsumo insumo in PafTitp.Mercadorias[i].Insumos)
                {
                    insumosRec[itemIndex].Descricao = ToUTF8(insumo.Descricao);
                    insumosRec[itemIndex].Codigo = ToUTF8(insumo.Codigo);
                    insumosRec[itemIndex].Aliquota = Convert.ToDouble(insumo.Aliquota);
                    insumosRec[itemIndex].Unidade = ToUTF8(insumo.Unidade);
                    insumosRec[itemIndex].Quantidade = Convert.ToDouble(insumo.Quantidade);
                    insumosRec[itemIndex].Ean = ToUTF8(insumo.Ean);
                    insumosRec[itemIndex].CST = ToUTF8(insumo.CST);
                    insumosRec[itemIndex].VlrUnitario = Convert.ToDouble(insumo.VlrUnitario);
                    itemIndex++;
                }
            }

            var ret = ACBrPAFInterop.PAF_Preenche_TITP(this.Handle, mercadoriasRec, PafTitp.Mercadorias.Count, insumosRec, PafTitp.Titulo.ToUTF8(),
                                                        PafTitp.Data.ToOADate());
			CheckResult(ret);
        }

        private void LimparRegistros()
        {
            PafA.LimparRegistros();
            PafB.LimparRegistros();
            PafC.LimparRegistros();
            PafD.LimparRegistros();
            PafE.LimparRegistros();
            PafN.LimparRegistros();
            PafP.LimparRegistros();
            PafR.LimparRegistros();
            PafT.LimparRegistros();
            PafU.LimparRegistros();
        }

        #endregion Preenche Registros

        #region Override Methods

        protected internal override void OnInitialize()
		{
			CallCreate(ACBrPAFInterop.PAF_Create);
            PafA = new ACBrPAF_A(this);
			PafB = new ACBrPAF_B(this);
			PafC = new ACBrPAF_C(this);
			PafD = new ACBrPAF_D(this);
			PafE = new ACBrPAF_E(this);
			PafH = new ACBrPAF_H(this);
			PafN = new ACBrPAF_N(this);
			PafP = new ACBrPAF_P(this);
			PafR = new ACBrPAF_R(this);
			PafS = new ACBrPAF_S(this);
			PafT = new ACBrPAF_T(this);
            PafU = new ACBrPAF_U(this);
			PafTitp = new ACBrPAF_TITP(this);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					var error = GetString(ACBrPAFInterop.PAF_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr PAF não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrPAFInterop.PAF_Destroy);
			}
		}

		#endregion Override Methods

		#region EventHandlers

		[AllowReversePInvokeCalls]
		private string OnPafGetKeyRsaCallBack()
		{
			var e = new ChaveEventArgs();

			if (onPafGetKeyRsa.IsAssigned)
				onPafGetKeyRsa.Raise(e);

			return e.Chave;
		}

		#endregion EventHandlers

		#endregion Methods
	}
}