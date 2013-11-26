using System;
using System.Linq;
using System.Drawing;
using System.ComponentModel;
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

		public event EventHandler<ChaveEventArgs> OnPAFGetKeyRSA
#endif
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP
			add
			{
				onPAFGetKeyRSA.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP
			remove
			{
				onPAFGetKeyRSA.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<ChaveEventArgs, ACBrPAFInterop.PAFGetKeyRSACallback> onPAFGetKeyRSA;

		private ACBrAAC aac;
		private ACBrEAD ead;

		#endregion Fields

		#region Constructor

		public ACBrPAF()
		{
			onPAFGetKeyRSA = new ACBrEventHandler<ChaveEventArgs, ACBrPAFInterop.PAFGetKeyRSACallback>(this, OnPAFGetKeyRSACallBack, ACBrPAFInterop.PAF_SetOnPAFGetKeyRSA);
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
        public ACBrPAF_A PAF_A { get; private set; }
                        
        [Browsable(false)]
		public ACBrPAF_B PAF_B { get; private set; }

		[Browsable(false)]
		public ACBrPAF_C PAF_C { get; private set; }

		[Browsable(false)]
		public ACBrPAF_D PAF_D { get; private set; }

		[Browsable(false)]
		public ACBrPAF_E PAF_E { get; private set; }

		[Browsable(false)]
		public ACBrPAF_H PAF_H { get; private set; }

		[Browsable(false)]
		public ACBrPAF_N PAF_N { get; private set; }

		[Browsable(false)]
		public ACBrPAF_P PAF_P { get; private set; }

		[Browsable(false)]
		public ACBrPAF_R PAF_R { get; private set; }

		[Browsable(false)]
		public ACBrPAF_T PAF_T { get; private set; }

        [Browsable(false)]
        public ACBrPAF_U PAF_U { get; private set; }

		[Browsable(false)]
		public ACBrPAF_TITP PAF_TITP { get; private set; }

		public ACBrAAC AAC
		{
			get
			{
				return this.aac;
			}
			set
			{
				if (value == null)
				{
					int ret = ACBrPAFInterop.PAF_SetAAC(this.Handle, IntPtr.Zero);
					CheckResult(ret);

					this.aac = null;
				}
				else
				{
					int ret = ACBrPAFInterop.PAF_SetAAC(this.Handle, value.Handle);
					CheckResult(ret);

					this.aac = value;
				}
			}
		}

		public ACBrEAD EAD
		{
			get
			{
				return this.ead;
			}
			set
			{
				if (value == null)
				{
					int ret = ACBrPAFInterop.PAF_SetEAD(this.Handle, IntPtr.Zero);
					CheckResult(ret);

					this.aac = null;
				}
				else
				{
					int ret = ACBrPAFInterop.PAF_SetEAD(this.Handle, value.Handle);
					CheckResult(ret);

					this.ead = value;
				}
			}
		}

		#endregion Properties

		#region Methods

		public bool AssinarArquivoComEAD(string arquivo)
		{
			int ret = ACBrPAFInterop.PAF_AssinarArquivoComEAD(this.Handle, arquivo);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_B(string arquivo)
		{
            PAF_Preenche_B();
			int ret = ACBrPAFInterop.PAF_SaveFileTXT_B(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_B.LimparRegistros();
			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_C(string arquivo)
        {
            PAF_Preenche_C();
			int ret = ACBrPAFInterop.PAF_SaveFileTXT_C(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_C.LimparRegistros();
			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_D(string arquivo)
		{
            PAF_Preenche_D();
			int ret = ACBrPAFInterop.PAF_SaveFileTXT_D(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_D.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_E(string arquivo)
		{
            PAF_Preenche_E();
			int ret = ACBrPAFInterop.PAF_SaveFileTXT_E(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_E.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_H(string arquivo)
		{
            PAF_Preenche_H();
			int ret = ACBrPAFInterop.PAF_SaveFileTXT_H(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_H.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_N(string arquivo)
		{
            PAF_Preenche_N();

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_N(Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_N.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_P(string arquivo)
		{
            PAF_Preenche_P();
			int ret = ACBrPAFInterop.PAF_SaveFileTXT_P(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_P.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_R(string arquivo)
		{
            PAF_Preenche_R();
			int ret = ACBrPAFInterop.PAF_SaveFileTXT_R(Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_R.LimparRegistros();
			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_T(string arquivo)
		{
            PAF_Preenche_T();

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_T(this.Handle, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_T.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_TITP(string arquivo)
		{
            PAF_Preenche_TITP();

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_TITP(this.Handle, arquivo.ToUTF8());
			CheckResult(ret);
			PAF_TITP.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

        public bool SaveFileTXT_RegistrosECF(string arquivo)
        {
            #region Preenche os registros
                        
            PAF_Preenche_A();
            PAF_Preenche_D();
            PAF_Preenche_E();                    
            PAF_Preenche_P();
            PAF_Preenche_R();
            PAF_Preenche_U();

            #endregion

            int ret = ACBrPAFInterop.PAF_SaveFileTXT_RegistrosPAF(Handle, arquivo.ToUTF8());

            CheckResult(ret);
            LimparRegistros();
            return Convert.ToBoolean(ret);
        }

        #region Preenche Registros

        private void PAF_Preenche_T()
        {
            int i;

            ACBrPAFInterop.RegistroHD1Rec RegistroT1Rec = new ACBrPAFInterop.RegistroHD1Rec();
            ACBrPAFInterop.RegistroT2Rec[] RegistroT2Rec = new ACBrPAFInterop.RegistroT2Rec[PAF_T.RegistroT2.Count];

            RegistroT1Rec.RAZAOSOCIAL = ToUTF8(PAF_T.RegistroT1.RazaoSocial);
            RegistroT1Rec.CNPJ = ToUTF8(PAF_T.RegistroT1.CNPJ);
            RegistroT1Rec.UF = ToUTF8(PAF_T.RegistroT1.UF);
            RegistroT1Rec.IE = ToUTF8(PAF_T.RegistroT1.IE);
            RegistroT1Rec.IM = ToUTF8(PAF_T.RegistroT1.IM);

            for (i = 0; i < PAF_T.RegistroT2.Count; i++)
            {
                RegistroT2Rec[i].DT_MOV = PAF_T.RegistroT2[i].DT_MOV.ToOADate();
                RegistroT2Rec[i].TP_DOCTO = ToUTF8(PAF_T.RegistroT2[i].TP_DOCTO);
                RegistroT2Rec[i].SERIE = ToUTF8(PAF_T.RegistroT2[i].SERIE);
                RegistroT2Rec[i].NUM_BILH_I = PAF_T.RegistroT2[i].NUM_BILH_I;
                RegistroT2Rec[i].NUM_BILH_F = PAF_T.RegistroT2[i].NUM_BILH_F;
                RegistroT2Rec[i].NUM_ECF = ToUTF8(PAF_T.RegistroT2[i].NUM_ECF);
                RegistroT2Rec[i].CRZ = PAF_T.RegistroT2[i].CRZ;
                RegistroT2Rec[i].CFOP = ToUTF8(PAF_T.RegistroT2[i].CFOP);
                RegistroT2Rec[i].VL_CONT = PAF_T.RegistroT2[i].VL_CONT;
                RegistroT2Rec[i].VL_BASECALC = PAF_T.RegistroT2[i].VL_BASECALC;
                RegistroT2Rec[i].ALIQ = PAF_T.RegistroT2[i].ALIQ;
                RegistroT2Rec[i].VL_IMPOSTO = PAF_T.RegistroT2[i].VL_IMPOSTO;
                RegistroT2Rec[i].VL_ISENTAS = PAF_T.RegistroT2[i].VL_ISENTAS;
                RegistroT2Rec[i].VL_OUTRAS = PAF_T.RegistroT2[i].VL_OUTRAS;
                RegistroT2Rec[i].RegistroValido = PAF_T.RegistroT2[i].RegistroValido;
            }

            int ret = ACBrPAFInterop.PAF_Preenche_T(Handle, RegistroT1Rec, RegistroT2Rec, PAF_T.RegistroT2.Count);
            CheckResult(ret);
        }

        private void PAF_Preenche_U()
        {
            ACBrPAFInterop.RegistroHD1Rec registroU1Rec = new ACBrPAFInterop.RegistroHD1Rec
            {
                CNPJ = PAF_U.RegistroU1.CNPJ,
                IE = PAF_U.RegistroU1.IE,
                IM = PAF_U.RegistroU1.IM,
                RAZAOSOCIAL = PAF_U.RegistroU1.RazaoSocial
            };

            int ret = ACBrPAFInterop.PAF_Preenche_U(Handle, registroU1Rec);
            CheckResult(ret);
        }

        private void PAF_Preenche_N()
        {
            int i;

            ACBrPAFInterop.RegistroHD1Rec RegistroN1Rec = new ACBrPAFInterop.RegistroHD1Rec();
            ACBrPAFInterop.RegistroN2Rec RegistroN2Rec = new ACBrPAFInterop.RegistroN2Rec();
            ACBrPAFInterop.RegistroN3Rec[] RegistroN3Rec = new ACBrPAFInterop.RegistroN3Rec[PAF_N.RegistroN3.Count];

            RegistroN1Rec.RAZAOSOCIAL = ToUTF8(PAF_N.RegistroN1.RazaoSocial);
            RegistroN1Rec.CNPJ = ToUTF8(PAF_N.RegistroN1.CNPJ);
            RegistroN1Rec.UF = ToUTF8(PAF_N.RegistroN1.UF);
            RegistroN1Rec.IE = ToUTF8(PAF_N.RegistroN1.IE);
            RegistroN1Rec.IM = ToUTF8(PAF_N.RegistroN1.IM);

            RegistroN2Rec.NOME = ToUTF8(PAF_N.RegistroN2.NOME);
            RegistroN2Rec.LAUDO = ToUTF8(PAF_N.RegistroN2.LAUDO);
            RegistroN2Rec.VERSAO = ToUTF8(PAF_N.RegistroN2.VERSAO);

            for (i = 0; i < PAF_N.RegistroN3.Count; i++)
            {
                RegistroN3Rec[i].NOME_ARQUIVO = ToUTF8(PAF_N.RegistroN3[i].NOME_ARQUIVO);
                RegistroN3Rec[i].MD5 = ToUTF8(PAF_N.RegistroN3[i].MD5);
            }

            int ret = ACBrPAFInterop.PAF_Preenche_N(Handle, RegistroN1Rec, RegistroN2Rec, RegistroN3Rec, PAF_N.RegistroN3.Count);
            CheckResult(ret);
        }

        private void PAF_Preenche_R()
        {
            #region Contadores
            int ItemR1 = 0, ItemR2 = 0, ItemR3 = 0, ItemR4 = 0, ItemR5 = 0, ItemR6 = 0, ItemR7 = 0,
                CR2 = 0, CR3 = 0, CR4 = 0, CR5 = 0, CR6 = 0, CR7 = 0;

            foreach(ACBrPAFRegistroR1 R1 in PAF_R.RegistroR1)
            {

                CR2 += R1.RegistroR2.Count;
                foreach(ACBrPAFRegistroR2 R2 in R1.RegistroR2)
                {
                    CR3 += R2.RegistroR3.Count;
                }

                CR4 += R1.RegistroR4.Count;
                foreach(ACBrPAFRegistroR4 R4 in R1.RegistroR4)
                {
                    CR5 += R4.RegistroR5.Count;
                    CR7 += R4.RegistroR7.Count;
                }

                CR6 += R1.RegistroR6.Count;
                foreach(ACBrPAFRegistroR6 R6 in R1.RegistroR6)
                {
                    CR7 += R6.RegistroR7.Count;
                }
            }
            #endregion Contadores

            #region Arrays
            ACBrPAFInterop.RegistroR1Rec[] RegistrosR1Rec = new ACBrPAFInterop.RegistroR1Rec[PAF_R.RegistroR1.Count];
            ACBrPAFInterop.RegistroR2Rec[] RegistrosR2Rec = new ACBrPAFInterop.RegistroR2Rec[CR2];
            ACBrPAFInterop.RegistroR3Rec[] RegistrosR3Rec = new ACBrPAFInterop.RegistroR3Rec[CR3];
            ACBrPAFInterop.RegistroR4Rec[] RegistrosR4Rec = new ACBrPAFInterop.RegistroR4Rec[CR4];
            ACBrPAFInterop.RegistroR5Rec[] RegistrosR5Rec = new ACBrPAFInterop.RegistroR5Rec[CR5];
            ACBrPAFInterop.RegistroR6Rec[] RegistrosR6Rec = new ACBrPAFInterop.RegistroR6Rec[CR6];
            ACBrPAFInterop.RegistroR7Rec[] RegistrosR7Rec = new ACBrPAFInterop.RegistroR7Rec[CR7];
            #endregion

            foreach(ACBrPAFRegistroR1 R1 in PAF_R.RegistroR1)
            {
                #region R1
                RegistrosR1Rec[ItemR1].QTD_R2 = R1.RegistroR2.Count;
                RegistrosR1Rec[ItemR1].QTD_R4 = R1.RegistroR4.Count;
                RegistrosR1Rec[ItemR1].QTD_R6 = R1.RegistroR6.Count;
                RegistrosR1Rec[ItemR1].NUM_FAB = ToUTF8(R1.NUM_FAB);
                RegistrosR1Rec[ItemR1].MF_ADICIONAL = ToUTF8(R1.MF_ADICIONAL);
                RegistrosR1Rec[ItemR1].TIPO_ECF = ToUTF8(R1.TIPO_ECF);
                RegistrosR1Rec[ItemR1].MARCA_ECF = ToUTF8(R1.MARCA_ECF);
                RegistrosR1Rec[ItemR1].MODELO_ECF = ToUTF8(R1.MODELO_ECF);
                RegistrosR1Rec[ItemR1].VERSAO_SB = ToUTF8(R1.VERSAO_SB);
                RegistrosR1Rec[ItemR1].DT_INST_SB = R1.DT_INST_SB.ToOADate();
                RegistrosR1Rec[ItemR1].HR_INST_SB = R1.HR_INST_SB.ToOADate();
                RegistrosR1Rec[ItemR1].NUM_SEQ_ECF = R1.NUM_SEQ_ECF;
                RegistrosR1Rec[ItemR1].CNPJ = ToUTF8(R1.CNPJ);
                RegistrosR1Rec[ItemR1].IE = ToUTF8(R1.IE);
                RegistrosR1Rec[ItemR1].CNPJ_SH = ToUTF8(R1.CNPJ_SH);
                RegistrosR1Rec[ItemR1].IE_SH = ToUTF8(R1.IE_SH);
                RegistrosR1Rec[ItemR1].IM_SH = ToUTF8(R1.IM_SH);
                RegistrosR1Rec[ItemR1].NOME_SH = ToUTF8(R1.NOME_SH);
                RegistrosR1Rec[ItemR1].NOME_PAF = ToUTF8(R1.NOME_PAF);
                RegistrosR1Rec[ItemR1].VER_PAF = ToUTF8(R1.VER_PAF);
                RegistrosR1Rec[ItemR1].COD_MD5 = ToUTF8(R1.COD_MD5);
                RegistrosR1Rec[ItemR1].DT_INI = R1.DT_INI.ToOADate();
                RegistrosR1Rec[ItemR1].DT_FIN = R1.DT_FIN.ToOADate();
                RegistrosR1Rec[ItemR1].ER_PAF_ECF = ToUTF8(R1.ER_PAF_ECF);
                RegistrosR1Rec[ItemR1].InclusaoExclusao = R1.InclusaoExclusao;
                RegistrosR1Rec[ItemR1].RegistroValido = R1.RegistroValido;
                #endregion

                #region R2 e R3
                foreach(ACBrPAFRegistroR2 R2 in R1.RegistroR2)
                {
                    RegistrosR2Rec[ItemR2].QTD_R3 = R2.RegistroR3.Count;
                    RegistrosR2Rec[ItemR2].NUM_USU = R2.NUM_USU;
                    RegistrosR2Rec[ItemR2].CRZ = R2.CRZ;
                    RegistrosR2Rec[ItemR2].COO = R2.COO;
                    RegistrosR2Rec[ItemR2].CRO = R2.CRO;
                    RegistrosR2Rec[ItemR2].DT_MOV = R2.DT_MOV.ToOADate();
                    RegistrosR2Rec[ItemR2].DT_EMI = R2.DT_EMI.ToOADate();
                    RegistrosR2Rec[ItemR2].HR_EMI = R2.HR_EMI.ToOADate();
                    RegistrosR2Rec[ItemR2].VL_VBD = Convert.ToDouble(R2.VL_VBD);
                    RegistrosR2Rec[ItemR2].PAR_ECF = ToUTF8(R2.PAR_ECF);
                    RegistrosR2Rec[ItemR2].RegistroValido = R2.RegistroValido;

                    foreach(ACBrPAFRegistroR3 RegistroR3 in R2.RegistroR3)
                    {
                        RegistrosR3Rec[ItemR3].TOT_PARCIAL = ToUTF8(RegistroR3.TOT_PARCIAL);
                        RegistrosR3Rec[ItemR3].VL_ACUM = Convert.ToDouble(RegistroR3.VL_ACUM);
                        RegistrosR3Rec[ItemR3].RegistroValido = RegistroR3.RegistroValido;
                        ItemR3++;
                    }

                    ItemR2++;
                }
                #endregion

                #region R4, R5 e R7
                foreach(ACBrPAFRegistroR4 R4 in R1.RegistroR4)
                {
                    RegistrosR4Rec[ItemR4].QTD_R5 = R4.RegistroR5.Count;
                    RegistrosR4Rec[ItemR4].QTD_R7 = R4.RegistroR7.Count;
                    RegistrosR4Rec[ItemR4].NUM_USU = R4.NUM_USU;
                    RegistrosR4Rec[ItemR4].NUM_CONT = R4.NUM_CONT;
                    RegistrosR4Rec[ItemR4].COO = R4.COO;
                    RegistrosR4Rec[ItemR4].DT_INI = R4.DT_INI.ToOADate();
                    RegistrosR4Rec[ItemR4].SUB_DOCTO = Convert.ToDouble(R4.SUB_DOCTO);
                    RegistrosR4Rec[ItemR4].SUB_DESCTO = Convert.ToDouble(R4.SUB_DESCTO);
                    RegistrosR4Rec[ItemR4].TP_DESCTO = ToUTF8(R4.TP_DESCTO);
                    RegistrosR4Rec[ItemR4].SUB_ACRES = Convert.ToDouble(R4.SUB_ACRES);
                    RegistrosR4Rec[ItemR4].TP_ACRES = ToUTF8(R4.TP_ACRES);
                    RegistrosR4Rec[ItemR4].VL_TOT = Convert.ToDouble(R4.VL_TOT);
                    RegistrosR4Rec[ItemR4].CANC = ToUTF8(R4.CANC);
                    RegistrosR4Rec[ItemR4].VL_CA = Convert.ToDouble(R4.VL_CA);
                    RegistrosR4Rec[ItemR4].ORDEM_DA = ToUTF8(R4.ORDEM_DA);
                    RegistrosR4Rec[ItemR4].NOME_CLI = ToUTF8(R4.NOME_CLI);
                    RegistrosR4Rec[ItemR4].CNPJ_CPF = ToUTF8(R4.CNPJ_CPF);
                    RegistrosR4Rec[ItemR4].RegistroValido = R4.RegistroValido;

                    foreach(ACBrPAFRegistroR5 RegistroR5 in R4.RegistroR5)
                    {
                        RegistrosR5Rec[ItemR5].NUM_CONT = RegistroR5.NUM_CONT;
                        RegistrosR5Rec[ItemR5].NUM_ITEM = RegistroR5.NUM_ITEM;
                        RegistrosR5Rec[ItemR5].COD_ITEM = ToUTF8(RegistroR5.COD_ITEM);
                        RegistrosR5Rec[ItemR5].DESC_ITEM = ToUTF8(RegistroR5.DESC_ITEM);
                        RegistrosR5Rec[ItemR5].QTDE_ITEM = Convert.ToDouble(RegistroR5.QTDE_ITEM);
                        RegistrosR5Rec[ItemR5].UN_MED = ToUTF8(RegistroR5.UN_MED);
                        RegistrosR5Rec[ItemR5].VL_UNIT = Convert.ToDouble(RegistroR5.VL_UNIT);
                        RegistrosR5Rec[ItemR5].DESCTO_ITEM = Convert.ToDouble(RegistroR5.DESCTO_ITEM);
                        RegistrosR5Rec[ItemR5].ACRES_ITEM = Convert.ToDouble(RegistroR5.ACRES_ITEM);
                        RegistrosR5Rec[ItemR5].VL_TOT_ITEM = Convert.ToDouble(RegistroR5.VL_TOT_ITEM);
                        RegistrosR5Rec[ItemR5].COD_TOT_PARC = ToUTF8(RegistroR5.COD_TOT_PARC);
                        RegistrosR5Rec[ItemR5].IND_CANC = ToUTF8(RegistroR5.IND_CANC);
                        RegistrosR5Rec[ItemR5].QTDE_CANC = Convert.ToDouble(RegistroR5.QTDE_CANC);
                        RegistrosR5Rec[ItemR5].VL_CANC = Convert.ToDouble(RegistroR5.VL_CANC);
                        RegistrosR5Rec[ItemR5].VL_CANC_ACRES = Convert.ToDouble(RegistroR5.VL_CANC_ACRES);
                        RegistrosR5Rec[ItemR5].IAT = ToUTF8(RegistroR5.IAT);
                        RegistrosR5Rec[ItemR5].IPPT = ToUTF8(RegistroR5.IPPT);
                        RegistrosR5Rec[ItemR5].QTDE_DECIMAL = RegistroR5.QTDE_DECIMAL;
                        RegistrosR5Rec[ItemR5].VL_DECIMAL = RegistroR5.VL_DECIMAL;
                        RegistrosR5Rec[ItemR5].RegistroValido = RegistroR5.RegistroValido;
                        ItemR5++;
                    }

                    foreach(ACBrPAFRegistroR7 RegistroR7 in R4.RegistroR7)
                    {
                        RegistrosR7Rec[ItemR7].CCF = RegistroR7.CCF;
                        RegistrosR7Rec[ItemR7].GNF = RegistroR7.GNF;
                        RegistrosR7Rec[ItemR7].MP = ToUTF8(RegistroR7.MP);
                        RegistrosR7Rec[ItemR7].VL_PAGTO = Convert.ToDouble(RegistroR7.VL_PAGTO);
                        RegistrosR7Rec[ItemR7].IND_EST = ToUTF8(RegistroR7.IND_EST);
                        RegistrosR7Rec[ItemR7].VL_EST = Convert.ToDouble(RegistroR7.VL_EST);
                        RegistrosR7Rec[ItemR7].RegistroValido = RegistroR7.RegistroValido;
                        ItemR7++;
                    }

                    ItemR4++;
                }
                #endregion

                #region R6 e R7
                foreach(ACBrPAFRegistroR6 R6 in R1.RegistroR6)
                {
                    RegistrosR6Rec[ItemR6].QTD_R7 = R6.RegistroR7.Count;
                    RegistrosR6Rec[ItemR6].NUM_USU = R6.NUM_USU;
                    RegistrosR6Rec[ItemR6].COO = R6.COO;
                    RegistrosR6Rec[ItemR6].GNF = R6.GNF;
                    RegistrosR6Rec[ItemR6].GRG = R6.GRG;
                    RegistrosR6Rec[ItemR6].CDC = R6.CDC;
                    RegistrosR6Rec[ItemR6].DENOM = ToUTF8(R6.DENOM);
                    RegistrosR6Rec[ItemR6].DT_FIN = R6.DT_FIN.ToOADate();
                    RegistrosR6Rec[ItemR6].HR_FIN = R6.HR_FIN.ToOADate();
                    RegistrosR6Rec[ItemR6].RegistroValido = R6.RegistroValido;

                    foreach(ACBrPAFRegistroR7 RegistroR7 in R6.RegistroR7)
                    {
                        RegistrosR7Rec[ItemR7].CCF = RegistroR7.CCF;
                        RegistrosR7Rec[ItemR7].GNF = RegistroR7.GNF;
                        RegistrosR7Rec[ItemR7].MP = ToUTF8(RegistroR7.MP);
                        RegistrosR7Rec[ItemR7].VL_PAGTO = Convert.ToDouble(RegistroR7.VL_PAGTO);
                        RegistrosR7Rec[ItemR7].IND_EST = ToUTF8(RegistroR7.IND_EST);
                        RegistrosR7Rec[ItemR7].VL_EST = Convert.ToDouble(RegistroR7.VL_EST);
                        RegistrosR7Rec[ItemR7].RegistroValido = RegistroR7.RegistroValido;
                        ItemR7++;
                    }

                    ItemR6++;
                }
                #endregion

                ItemR1++;
            }

            int ret = ACBrPAFInterop.PAF_Preenche_R(Handle, PAF_R.RegistroR1.Count,
                                                            RegistrosR1Rec,
                                                            RegistrosR2Rec,
                                                            RegistrosR3Rec,
                                                            RegistrosR4Rec,
                                                            RegistrosR5Rec,
                                                            RegistrosR6Rec,
                                                            RegistrosR7Rec);
            CheckResult(ret);
        }

        private void PAF_Preenche_P()
        {
            ACBrPAFInterop.RegistroHD1Rec registroP1Rec = new ACBrPAFInterop.RegistroHD1Rec
            {
                CNPJ = PAF_P.RegistroP1.CNPJ,
                IE = PAF_P.RegistroP1.IE,
                IM = PAF_P.RegistroP1.IM,
                RAZAOSOCIAL = PAF_P.RegistroP1.RazaoSocial,
                UF = PAF_P.RegistroP1.UF
            };

            ACBrPAFInterop.RegistroP2Rec[] RegistrosP2Rec = (from x in PAF_P.RegistroP2
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

            int ret = ACBrPAFInterop.PAF_Preenche_P(Handle, registroP1Rec, RegistrosP2Rec, RegistrosP2Rec.Count());
            CheckResult(ret);
        }

        private void PAF_Preenche_E()
        {
            #region E1
            ACBrPAFInterop.RegistroHD2Rec RegistroE1Rec = new ACBrPAFInterop.RegistroHD2Rec
            {
                RAZAOSOCIAL = ToUTF8(PAF_E.RegistroE1.RazaoSocial),
                CNPJ = ToUTF8(PAF_E.RegistroE1.CNPJ),
                UF = ToUTF8(PAF_E.RegistroE1.UF),
                IE = ToUTF8(PAF_E.RegistroE1.IE),
                IM = ToUTF8(PAF_E.RegistroE1.IM),
                TIPO_ECF = ToUTF8(PAF_E.RegistroE1.TIPO_ECF),
                MARCA_ECF = ToUTF8(PAF_E.RegistroE1.MARCA_ECF),
                MODELO_ECF = ToUTF8(PAF_E.RegistroE1.MODELO_ECF),
                NUM_FAB = ToUTF8(PAF_E.RegistroE1.NUM_FAB),
                MF_ADICIONAL = ToUTF8(PAF_E.RegistroE1.MF_ADICIONAL),
                DT_EST = PAF_E.RegistroE1.DT_EST.ToOADate(),
                RegistroValido = PAF_E.RegistroE1.RegistroValido,
                InclusaoExclusao = PAF_E.RegistroE1.InclusaoExclusao
            };
            #endregion

            #region E2
            ACBrPAFInterop.RegistroE2Rec[] RegistrosE2Rec = (from x in PAF_E.RegistroE2
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
            ACBrPAFInterop.RegistroE3Rec RegistroE3Rec = new ACBrPAFInterop.RegistroE3Rec
            {
                DataEstoque = PAF_E.RegistroE3.DataEstoque.ToOADate(),
                HoraEstoque = (double)PAF_E.RegistroE3.HoraEstoque,
                MarcaECF = PAF_E.RegistroE3.MarcaECF,
                MFAdicional = PAF_E.RegistroE3.MFAdicional,
                ModeloECF = PAF_E.RegistroE3.ModeloECF,
                NumeroFabricacao = PAF_E.RegistroE3.NumeroFabricacao,
                RegistroValido = PAF_E.RegistroE3.RegistroValido,
                TipoECF = PAF_E.RegistroE3.TipoECF,
            };
            #endregion

            int ret = ACBrPAFInterop.PAF_Preenche_E(Handle, RegistroE1Rec, RegistrosE2Rec, RegistroE3Rec, PAF_E.RegistroE2.Count);
            CheckResult(ret);
        }

        private void PAF_Preenche_H()
        {
            #region H1
            ACBrPAFInterop.RegistroHD2Rec RegistroH1Rec = new ACBrPAFInterop.RegistroHD2Rec();
            RegistroH1Rec.RAZAOSOCIAL = ToUTF8(PAF_H.RegistroH1.RazaoSocial);
            RegistroH1Rec.CNPJ = ToUTF8(PAF_H.RegistroH1.CNPJ);
            RegistroH1Rec.UF = ToUTF8(PAF_H.RegistroH1.UF);
            RegistroH1Rec.IE = ToUTF8(PAF_H.RegistroH1.IE);
            RegistroH1Rec.IM = ToUTF8(PAF_H.RegistroH1.IM);
            RegistroH1Rec.TIPO_ECF = ToUTF8(PAF_H.RegistroH1.TIPO_ECF);
            RegistroH1Rec.MARCA_ECF = ToUTF8(PAF_H.RegistroH1.MARCA_ECF);
            RegistroH1Rec.MODELO_ECF = ToUTF8(PAF_H.RegistroH1.MODELO_ECF);
            RegistroH1Rec.NUM_FAB = ToUTF8(PAF_H.RegistroH1.NUM_FAB);
            RegistroH1Rec.MF_ADICIONAL = ToUTF8(PAF_H.RegistroH1.MF_ADICIONAL);
            RegistroH1Rec.DT_EST = PAF_H.RegistroH1.DT_EST.ToOADate();
            RegistroH1Rec.RegistroValido = PAF_H.RegistroH1.RegistroValido;
            RegistroH1Rec.InclusaoExclusao = PAF_H.RegistroH1.InclusaoExclusao;
            #endregion

            #region H2
            ACBrPAFInterop.RegistroH2Rec[] RegistroH2Rec = (from x in PAF_H.RegistroH2
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

            int ret = ACBrPAFInterop.PAF_Preenche_H(Handle, RegistroH1Rec, RegistroH2Rec, PAF_H.RegistroH2.Count);
            CheckResult(ret);
        }

        private void PAF_Preenche_D()
        {
            #region Variáveis
            int i, IndexD3 = 0, IndexD4 = 0;
            int D3 = PAF_D.RegistroD2.Sum(s => s.RegistroD3.Count);
            int D4 = PAF_D.RegistroD2.Sum(s => s.RegistroD4.Count);

            ACBrPAFInterop.RegistroHD1Rec RegistroD1Rec = new ACBrPAFInterop.RegistroHD1Rec();
            ACBrPAFInterop.RegistroD2Rec[] RegistrosD2Rec = new ACBrPAFInterop.RegistroD2Rec[PAF_D.RegistroD2.Count];
            ACBrPAFInterop.RegistroD3Rec[] RegistrosD3Rec = new ACBrPAFInterop.RegistroD3Rec[D3];
            ACBrPAFInterop.RegistroD4Rec[] RegistrosD4Rec = new ACBrPAFInterop.RegistroD4Rec[D3];
            #endregion

            #region D1
            RegistroD1Rec.RAZAOSOCIAL = ToUTF8(PAF_D.RegistroD1.RazaoSocial);
            RegistroD1Rec.CNPJ = ToUTF8(PAF_D.RegistroD1.CNPJ);
            RegistroD1Rec.UF = ToUTF8(PAF_D.RegistroD1.UF);
            RegistroD1Rec.IE = ToUTF8(PAF_D.RegistroD1.IE);
            RegistroD1Rec.IM = ToUTF8(PAF_D.RegistroD1.IM);
            #endregion

            for(i = 0; i < PAF_D.RegistroD2.Count; i++)
            {
                #region D2
                RegistrosD2Rec[i].QTD_D3 = PAF_D.RegistroD2[i].RegistroD3.Count;
                RegistrosD2Rec[i].QTD_D4 = PAF_D.RegistroD2[i].RegistroD4.Count;
                RegistrosD2Rec[i].NUM_FAB = ToUTF8(PAF_D.RegistroD2[i].NUM_FAB);
                RegistrosD2Rec[i].MF_ADICIONAL = ToUTF8(PAF_D.RegistroD2[i].MF_ADICIONAL);
                RegistrosD2Rec[i].TIPO_ECF = ToUTF8(PAF_D.RegistroD2[i].TIPO_ECF);
                RegistrosD2Rec[i].MARCA_ECF = ToUTF8(PAF_D.RegistroD2[i].MARCA_ECF);
                RegistrosD2Rec[i].MODELO_ECF = ToUTF8(PAF_D.RegistroD2[i].MODELO_ECF);
                RegistrosD2Rec[i].COO = ToUTF8(PAF_D.RegistroD2[i].COO);
                RegistrosD2Rec[i].NUM_DAV = ToUTF8(PAF_D.RegistroD2[i].NUM_DAV);
                RegistrosD2Rec[i].DT_DAV = PAF_D.RegistroD2[i].DT_DAV.ToOADate();
                RegistrosD2Rec[i].TIT_DAV = ToUTF8(PAF_D.RegistroD2[i].TIT_DAV);
                RegistrosD2Rec[i].VLT_DAV = Convert.ToDouble(PAF_D.RegistroD2[i].VLT_DAV);
                RegistrosD2Rec[i].COO_DFV = ToUTF8(PAF_D.RegistroD2[i].COO_DFV);
                RegistrosD2Rec[i].NUMERO_ECF = ToUTF8(PAF_D.RegistroD2[i].NUMERO_ECF);
                RegistrosD2Rec[i].NOME_CLIENTE = ToUTF8(PAF_D.RegistroD2[i].NOME_CLIENTE);
                RegistrosD2Rec[i].CPF_CNPJ = ToUTF8(PAF_D.RegistroD2[i].CPF_CNPJ);
                RegistrosD2Rec[i].RegistroValido = PAF_D.RegistroD2[i].RegistroValido;
                #endregion

                #region D3
                foreach(ACBrPAFRegistroD3 RegistroD3 in PAF_D.RegistroD2[i].RegistroD3)
                {
                    RegistrosD3Rec[IndexD3].DT_INCLUSAO = RegistroD3.DT_INCLUSAO.ToOADate();
                    RegistrosD3Rec[IndexD3].NUM_ITEM = RegistroD3.NUM_ITEM;
                    RegistrosD3Rec[IndexD3].COD_ITEM = ToUTF8(RegistroD3.COD_ITEM);
                    RegistrosD3Rec[IndexD3].DESC_ITEM = ToUTF8(RegistroD3.DESC_ITEM);
                    RegistrosD3Rec[IndexD3].QTDE_ITEM = Convert.ToDouble(RegistroD3.QTDE_ITEM);
                    RegistrosD3Rec[IndexD3].UNI_ITEM = ToUTF8(RegistroD3.UNI_ITEM);
                    RegistrosD3Rec[IndexD3].VL_UNIT = Convert.ToDouble(RegistroD3.VL_UNIT);
                    RegistrosD3Rec[IndexD3].VL_DESCTO = Convert.ToDouble(RegistroD3.VL_DESCTO);
                    RegistrosD3Rec[IndexD3].VL_ACRES = Convert.ToDouble(RegistroD3.VL_ACRES);
                    RegistrosD3Rec[IndexD3].VL_TOTAL = Convert.ToDouble(RegistroD3.VL_TOTAL);
                    RegistrosD3Rec[IndexD3].DEC_VL_UNIT = RegistroD3.DEC_VL_UNIT;
                    RegistrosD3Rec[IndexD3].DEC_QTDE_ITEM = RegistroD3.DEC_QTDE_ITEM;
                    RegistrosD3Rec[IndexD3].SIT_TRIB = ToUTF8(RegistroD3.SIT_TRIB);
                    RegistrosD3Rec[IndexD3].ALIQ = Convert.ToDouble(RegistroD3.ALIQ);
                    RegistrosD3Rec[IndexD3].IND_CANC = ToUTF8(RegistroD3.IND_CANC);
                    RegistrosD3Rec[IndexD3].RegistroValido = RegistroD3.RegistroValido;

                    IndexD3++;
                }
                #endregion

                #region D4
                foreach(ACBrPAFRegistroD4 RegistroD4 in PAF_D.RegistroD2[i].RegistroD4)
                {
                    RegistrosD4Rec[IndexD4].NumeroDAV = RegistroD4.NumeroDAV;
                    RegistrosD4Rec[IndexD4].DataAlteracao = (double)RegistroD4.DataAlteracao;
                    RegistrosD4Rec[IndexD4].HoraAlteracao = (double)RegistroD4.HoraAlteracao;
                    RegistrosD4Rec[IndexD4].CodigoProdutoServico = RegistroD4.CodigoProdutoServico;
                    RegistrosD4Rec[IndexD4].Descricao = RegistroD4.Descricao;
                    RegistrosD4Rec[IndexD4].Quantidade = (double)RegistroD4.Quantidade;
                    RegistrosD4Rec[IndexD4].Unidade = RegistroD4.Unidade;
                    RegistrosD4Rec[IndexD4].ValorUnitario = (double)RegistroD4.ValorUnitario;
                    RegistrosD4Rec[IndexD4].DescontoSobreItem = (double)RegistroD4.DescontoSobreItem;
                    RegistrosD4Rec[IndexD4].AcrescimoSobreItem = (double)RegistroD4.AcrescimoSobreItem;
                    RegistrosD4Rec[IndexD4].ValorTotalLiquido = (double)RegistroD4.ValorTotalLiquido;
                    RegistrosD4Rec[IndexD4].SituacaoTributaria = RegistroD4.SituacaoTributaria;
                    RegistrosD4Rec[IndexD4].Aliquota = (double)RegistroD4.Aliquota;
                    RegistrosD4Rec[IndexD4].IndicadorCancelamento = RegistroD4.IndicadorCancelamento;
                    RegistrosD4Rec[IndexD4].CasasDecimaisQtd = RegistroD4.CasasDecimaisQtd;
                    RegistrosD4Rec[IndexD4].CasasDecimaisVlUn = RegistroD4.CasasDecimaisVlUn;
                    RegistrosD4Rec[IndexD4].TipoAlteracao = RegistroD4.TipoAlteracao;

                    IndexD4++;
                }
                #endregion
            }

            int ret = ACBrPAFInterop.PAF_Preenche_D(Handle, RegistroD1Rec, RegistrosD2Rec, PAF_D.RegistroD2.Count, RegistrosD3Rec, RegistrosD4Rec, RegistrosD4Rec.Count());
            CheckResult(ret);
        }

        private void PAF_Preenche_C()
        {
            #region C1
            ACBrPAFInterop.RegistroHD1Rec RegistroC1Rec = new ACBrPAFInterop.RegistroHD1Rec
                {
                    RAZAOSOCIAL = ToUTF8(PAF_C.RegistroC1.RazaoSocial),
                    CNPJ = ToUTF8(PAF_C.RegistroC1.CNPJ),
                    UF = ToUTF8(PAF_C.RegistroC1.UF),
                    IE = ToUTF8(PAF_C.RegistroC1.IE),
                    IM = ToUTF8(PAF_C.RegistroC1.IM)
                };
            #endregion

            #region C2
            ACBrPAFInterop.RegistroC2Rec[] RegistrosC2Rec = (from x in PAF_C.RegistroC2
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

            int ret = ACBrPAFInterop.PAF_Preenche_C(Handle, RegistroC1Rec, RegistrosC2Rec, PAF_C.RegistroC2.Count);
            CheckResult(ret);
        }

        private void PAF_Preenche_B()
        {
            #region B1
            ACBrPAFInterop.RegistroHD1Rec RegistroB1Rec = new ACBrPAFInterop.RegistroHD1Rec
            {
                RAZAOSOCIAL = ToUTF8(PAF_B.RegistroB1.RazaoSocial),
                CNPJ = ToUTF8(PAF_B.RegistroB1.CNPJ),
                UF = ToUTF8(PAF_B.RegistroB1.UF),
                IE = ToUTF8(PAF_B.RegistroB1.IE),
                IM = ToUTF8(PAF_B.RegistroB1.IM)
            };
            #endregion

            #region B2
            ACBrPAFInterop.RegistroB2Rec[] RegistrosB2Rec = (from x in PAF_B.RegistroB2
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

            int ret = ACBrPAFInterop.PAF_Preenche_B(Handle, RegistroB1Rec, RegistrosB2Rec, PAF_B.RegistroB2.Count);
            CheckResult(ret);
        }

        private void PAF_Preenche_A()
        {
            ACBrPAFInterop.RegistroA2Rec[] RegistrosA2Rec = (from x in PAF_A.RegistroA2
                                                             select new ACBrPAFInterop.RegistroA2Rec
                                                             {
                                                                 CodigoTipoDocumento = ((int)x.CodigoTipoDocumento).ToString(),
                                                                 Data = x.Data.ToOADate(),
                                                                 MeioDePagamento = x.MeioPagamento,
                                                                 RegistroValido = x.RegistroValido
                                                             }).ToArray();

            int ret = ACBrPAFInterop.PAF_Preenche_A(Handle, RegistrosA2Rec, PAF_A.RegistroA2.Count);
            CheckResult(ret);
        }

        private void PAF_Preenche_TITP()
        {
            int ItemIndex = 0;
            int InsumosCount = 0;

            foreach (ACBrPAFRegistroMercadoria mercadoria in PAF_TITP.Mercadorias)
            {
                InsumosCount += mercadoria.Insumos.Count;
            }

            ACBrPAFInterop.RegistroMercadoriasRec[] MercadoriasRec = new ACBrPAFInterop.RegistroMercadoriasRec[PAF_TITP.Mercadorias.Count];
            ACBrPAFInterop.RegistroInsumosRec[] InsumosRec = new ACBrPAFInterop.RegistroInsumosRec[InsumosCount];

            for (int i = 0; i < PAF_TITP.Mercadorias.Count; i++)
            {
                MercadoriasRec[i].Descricao = ToUTF8(PAF_TITP.Mercadorias[i].Descricao);
                MercadoriasRec[i].Codigo = ToUTF8(PAF_TITP.Mercadorias[i].Codigo);
                MercadoriasRec[i].Aliquota = Convert.ToDouble(PAF_TITP.Mercadorias[i].Aliquota);
                MercadoriasRec[i].Unidade = ToUTF8(PAF_TITP.Mercadorias[i].Unidade);
                MercadoriasRec[i].Quantidade = Convert.ToDouble(PAF_TITP.Mercadorias[i].Quantidade);
                MercadoriasRec[i].Ean = ToUTF8(PAF_TITP.Mercadorias[i].Ean);
                MercadoriasRec[i].CST = ToUTF8(PAF_TITP.Mercadorias[i].CST);
                MercadoriasRec[i].VlrUnitario = Convert.ToDouble(PAF_TITP.Mercadorias[i].VlrUnitario);
                MercadoriasRec[i].QTD_Insumos = PAF_TITP.Mercadorias[i].Insumos.Count;

                foreach (ACBrPAFRegistroInsumo Insumo in PAF_TITP.Mercadorias[i].Insumos)
                {
                    InsumosRec[ItemIndex].Descricao = ToUTF8(Insumo.Descricao);
                    InsumosRec[ItemIndex].Codigo = ToUTF8(Insumo.Codigo);
                    InsumosRec[ItemIndex].Aliquota = Convert.ToDouble(Insumo.Aliquota);
                    InsumosRec[ItemIndex].Unidade = ToUTF8(Insumo.Unidade);
                    InsumosRec[ItemIndex].Quantidade = Convert.ToDouble(Insumo.Quantidade);
                    InsumosRec[ItemIndex].Ean = ToUTF8(Insumo.Ean);
                    InsumosRec[ItemIndex].CST = ToUTF8(Insumo.CST);
                    InsumosRec[ItemIndex].VlrUnitario = Convert.ToDouble(Insumo.VlrUnitario);
                    ItemIndex++;
                }
            }

            int ret = ACBrPAFInterop.PAF_Preenche_TITP(this.Handle, MercadoriasRec, PAF_TITP.Mercadorias.Count, InsumosRec, PAF_TITP.Titulo.ToUTF8(),
                                                        PAF_TITP.Data.ToOADate());
			CheckResult(ret);
        }

        private void LimparRegistros()
        {
            PAF_A.LimparRegistros();
            PAF_B.LimparRegistros();
            PAF_C.LimparRegistros();
            PAF_D.LimparRegistros();
            PAF_E.LimparRegistros();
            PAF_N.LimparRegistros();
            PAF_P.LimparRegistros();
            PAF_R.LimparRegistros();
            PAF_T.LimparRegistros();
            PAF_U.LimparRegistros();
        }

        #endregion Preenche Registros

        #region Override Methods

        protected internal override void OnInitialize()
		{
			CallCreate(ACBrPAFInterop.PAF_Create);
            PAF_A = new ACBrPAF_A(this);
			PAF_B = new ACBrPAF_B(this);
			PAF_C = new ACBrPAF_C(this);
			PAF_D = new ACBrPAF_D(this);
			PAF_E = new ACBrPAF_E(this);
			PAF_H = new ACBrPAF_H(this);
			PAF_N = new ACBrPAF_N(this);
			PAF_P = new ACBrPAF_P(this);
			PAF_R = new ACBrPAF_R(this);
			PAF_T = new ACBrPAF_T(this);
            PAF_U = new ACBrPAF_U(this);
			PAF_TITP = new ACBrPAF_TITP(this);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrPAFInterop.PAF_GetUltimoErro);
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
		private string OnPAFGetKeyRSACallBack()
		{
			ChaveEventArgs e = new ChaveEventArgs();

			if (onPAFGetKeyRSA.IsAssigned)
				onPAFGetKeyRSA.Raise(e);

			return e.Chave;
		}

		#endregion EventHandlers

		#endregion Methods
	}
}