using ACBrFramework.AAC;
using ACBrFramework.EAD;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

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
			int i;

			ACBrPAFInterop.RegistroHD1Rec RegistroB1Rec = new ACBrPAFInterop.RegistroHD1Rec();
			ACBrPAFInterop.RegistroB2Rec[] RegistroB2Rec = new ACBrPAFInterop.RegistroB2Rec[PAF_B.RegistroB2.Count];

			RegistroB1Rec.RAZAOSOCIAL = ToUTF8(PAF_B.RegistroB1.RazaoSocial);
			RegistroB1Rec.CNPJ = ToUTF8(PAF_B.RegistroB1.CNPJ);
			RegistroB1Rec.UF = ToUTF8(PAF_B.RegistroB1.UF);
			RegistroB1Rec.IE = ToUTF8(PAF_B.RegistroB1.IE);
			RegistroB1Rec.IM = ToUTF8(PAF_B.RegistroB1.IM);

			for (i = 0; i < PAF_B.RegistroB2.Count; i++)
			{
				RegistroB2Rec[i].BOMBA = ToUTF8(PAF_B.RegistroB2[i].BOMBA);
				RegistroB2Rec[i].BICO = ToUTF8(PAF_B.RegistroB2[i].BICO);
				RegistroB2Rec[i].DATA = PAF_B.RegistroB2[i].DATA.ToOADate();
				RegistroB2Rec[i].HORA = PAF_B.RegistroB2[i].HORA.ToOADate();
				RegistroB2Rec[i].MOTIVO = ToUTF8(PAF_B.RegistroB2[i].MOTIVO);
				RegistroB2Rec[i].CNPJ_EMPRESA = ToUTF8(PAF_B.RegistroB2[i].CNPJ_EMPRESA);
				RegistroB2Rec[i].CPF_TECNICO = ToUTF8(PAF_B.RegistroB2[i].CPF_TECNICO);
				RegistroB2Rec[i].NRO_LACRE_ANTES = ToUTF8(PAF_B.RegistroB2[i].NRO_LACRE_ANTES);
				RegistroB2Rec[i].NRO_LACRE_APOS = ToUTF8(PAF_B.RegistroB2[i].NRO_LACRE_ANTES);
				RegistroB2Rec[i].ENCERRANTE_ANTES = Convert.ToDouble(PAF_B.RegistroB2[i].ENCERRANTE_ANTES);
				RegistroB2Rec[i].ENCERRANTE_APOS = Convert.ToDouble(PAF_B.RegistroB2[i].ENCERRANTE_APOS);
				RegistroB2Rec[i].RegistroValido = PAF_B.RegistroB2[i].RegistroValido;
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_B(this.Handle, RegistroB1Rec, RegistroB2Rec, PAF_B.RegistroB2.Count, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_B.LimparRegistros();
			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_C(string arquivo)
		{
			int i;

			ACBrPAFInterop.RegistroHD1Rec RegistroC1Rec = new ACBrPAFInterop.RegistroHD1Rec();
			ACBrPAFInterop.RegistroC2Rec[] RegistroC2Rec = new ACBrPAFInterop.RegistroC2Rec[PAF_C.RegistroC2.Count];

			RegistroC1Rec.RAZAOSOCIAL = ToUTF8(PAF_C.RegistroC1.RazaoSocial);
			RegistroC1Rec.CNPJ = ToUTF8(PAF_C.RegistroC1.CNPJ);
			RegistroC1Rec.UF = ToUTF8(PAF_C.RegistroC1.UF);
			RegistroC1Rec.IE = ToUTF8(PAF_C.RegistroC1.IE);
			RegistroC1Rec.IM = ToUTF8(PAF_C.RegistroC1.IM);

			for (i = 0; i < PAF_C.RegistroC2.Count; i++)
			{
				RegistroC2Rec[i].ID_ABASTECIMENTO = ToUTF8(PAF_C.RegistroC2[i].ID_ABASTECIMENTO);
				RegistroC2Rec[i].TANQUE = ToUTF8(PAF_C.RegistroC2[i].TANQUE);
				RegistroC2Rec[i].BOMBA = ToUTF8(PAF_C.RegistroC2[i].BOMBA);
				RegistroC2Rec[i].COMBUSTIVEL = ToUTF8(PAF_C.RegistroC2[i].COMBUSTIVEL);
				RegistroC2Rec[i].DATA_ABASTECIMENTO = PAF_C.RegistroC2[i].DATA_ABASTECIMENTO.ToOADate();
				RegistroC2Rec[i].HORA_ABASTECIMENTO = PAF_C.RegistroC2[i].HORA_ABASTECIMENTO.ToOADate();
				RegistroC2Rec[i].ENCERRANTE_INICIAL = Convert.ToDouble(PAF_C.RegistroC2[i].ENCERRANTE_INICIAL);
				RegistroC2Rec[i].ENCERRANTE_FINAL = Convert.ToDouble(PAF_C.RegistroC2[i].ENCERRANTE_FINAL);
				RegistroC2Rec[i].STATUS_ABASTECIMENTO = ToUTF8(PAF_C.RegistroC2[i].STATUS_ABASTECIMENTO);
				RegistroC2Rec[i].NRO_SERIE_ECF = ToUTF8(PAF_C.RegistroC2[i].NRO_SERIE_ECF);
				RegistroC2Rec[i].DATA = PAF_C.RegistroC2[i].DATA.ToOADate();
				RegistroC2Rec[i].HORA = PAF_C.RegistroC2[i].HORA.ToOADate();
				RegistroC2Rec[i].COO = PAF_C.RegistroC2[i].COO;
				RegistroC2Rec[i].NRO_NOTA_FISCAL = PAF_C.RegistroC2[i].NRO_NOTA_FISCAL;
				RegistroC2Rec[i].VOLUME = Convert.ToDouble(PAF_C.RegistroC2[i].VOLUME);
				RegistroC2Rec[i].RegistroValido = PAF_C.RegistroC2[i].RegistroValido;
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_C(this.Handle, RegistroC1Rec, RegistroC2Rec, PAF_C.RegistroC2.Count, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_C.LimparRegistros();
			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_D(string arquivo)
		{
			int i, ItemIndex = 0;
			int D3 = 0;

			foreach (ACBrPAFRegistroD2 D2 in PAF_D.RegistroD2)
			{
				D3 += D2.RegistroD3.Count;
			}

			ACBrPAFInterop.RegistroHD1Rec RegistroD1Rec = new ACBrPAFInterop.RegistroHD1Rec();
			ACBrPAFInterop.RegistroD2Rec[] RegistroD2Rec = new ACBrPAFInterop.RegistroD2Rec[PAF_D.RegistroD2.Count];
			ACBrPAFInterop.RegistroD3Rec[] RegistroD3Rec = new ACBrPAFInterop.RegistroD3Rec[D3];

			RegistroD1Rec.RAZAOSOCIAL = ToUTF8(PAF_D.RegistroD1.RazaoSocial);
			RegistroD1Rec.CNPJ = ToUTF8(PAF_D.RegistroD1.CNPJ);
			RegistroD1Rec.UF = ToUTF8(PAF_D.RegistroD1.UF);
			RegistroD1Rec.IE = ToUTF8(PAF_D.RegistroD1.IE);
			RegistroD1Rec.IM = ToUTF8(PAF_D.RegistroD1.IM);

			for (i = 0; i < PAF_D.RegistroD2.Count; i++)
			{
				RegistroD2Rec[i].QTD_D3 = PAF_D.RegistroD2[i].RegistroD3.Count;
				RegistroD2Rec[i].NUM_FAB = ToUTF8(PAF_D.RegistroD2[i].NUM_FAB);
				RegistroD2Rec[i].MF_ADICIONAL = ToUTF8(PAF_D.RegistroD2[i].MF_ADICIONAL);
				RegistroD2Rec[i].TIPO_ECF = ToUTF8(PAF_D.RegistroD2[i].TIPO_ECF);
				RegistroD2Rec[i].MARCA_ECF = ToUTF8(PAF_D.RegistroD2[i].MARCA_ECF);
				RegistroD2Rec[i].MODELO_ECF = ToUTF8(PAF_D.RegistroD2[i].MODELO_ECF);
				RegistroD2Rec[i].COO = ToUTF8(PAF_D.RegistroD2[i].COO);
				RegistroD2Rec[i].NUM_DAV = ToUTF8(PAF_D.RegistroD2[i].NUM_DAV);
				RegistroD2Rec[i].DT_DAV = PAF_D.RegistroD2[i].DT_DAV.ToOADate();
				RegistroD2Rec[i].TIT_DAV = ToUTF8(PAF_D.RegistroD2[i].TIT_DAV);
				RegistroD2Rec[i].VLT_DAV = Convert.ToDouble(PAF_D.RegistroD2[i].VLT_DAV);
				RegistroD2Rec[i].COO_DFV = ToUTF8(PAF_D.RegistroD2[i].COO_DFV);
				RegistroD2Rec[i].NUMERO_ECF = ToUTF8(PAF_D.RegistroD2[i].NUMERO_ECF);
				RegistroD2Rec[i].NOME_CLIENTE = ToUTF8(PAF_D.RegistroD2[i].NOME_CLIENTE);
				RegistroD2Rec[i].CPF_CNPJ = ToUTF8(PAF_D.RegistroD2[i].CPF_CNPJ);
				RegistroD2Rec[i].RegistroValido = PAF_D.RegistroD2[i].RegistroValido;

				foreach (ACBrPAFRegistroD3 RegistroD3 in PAF_D.RegistroD2[i].RegistroD3)
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

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_D(this.Handle, RegistroD1Rec, RegistroD2Rec, PAF_D.RegistroD2.Count, RegistroD3Rec, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_D.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_E(string arquivo)
		{
			int i;

			ACBrPAFInterop.RegistroHD2Rec RegistroE1Rec = new ACBrPAFInterop.RegistroHD2Rec();
			ACBrPAFInterop.RegistroE2Rec[] RegistroE2Rec = new ACBrPAFInterop.RegistroE2Rec[PAF_E.RegistroE2.Count];

			RegistroE1Rec.RAZAOSOCIAL = ToUTF8(PAF_E.RegistroE1.RazaoSocial);
			RegistroE1Rec.CNPJ = ToUTF8(PAF_E.RegistroE1.CNPJ);
			RegistroE1Rec.UF = ToUTF8(PAF_E.RegistroE1.UF);
			RegistroE1Rec.IE = ToUTF8(PAF_E.RegistroE1.IE);
			RegistroE1Rec.IM = ToUTF8(PAF_E.RegistroE1.IM);
			RegistroE1Rec.TIPO_ECF = ToUTF8(PAF_E.RegistroE1.TIPO_ECF);
			RegistroE1Rec.MARCA_ECF = ToUTF8(PAF_E.RegistroE1.MARCA_ECF);
			RegistroE1Rec.MODELO_ECF = ToUTF8(PAF_E.RegistroE1.MODELO_ECF);
			RegistroE1Rec.NUM_FAB = ToUTF8(PAF_E.RegistroE1.NUM_FAB);
			RegistroE1Rec.MF_ADICIONAL = ToUTF8(PAF_E.RegistroE1.MF_ADICIONAL);
			RegistroE1Rec.DT_EST = PAF_E.RegistroE1.DT_EST.ToOADate();
			RegistroE1Rec.RegistroValido = PAF_E.RegistroE1.RegistroValido;
			RegistroE1Rec.InclusaoExclusao = PAF_E.RegistroE1.InclusaoExclusao;

			for (i = 0; i < PAF_E.RegistroE2.Count; i++)
			{
				RegistroE2Rec[i].COD_MERC = ToUTF8(PAF_E.RegistroE2[i].COD_MERC);
				RegistroE2Rec[i].DESC_MERC = ToUTF8(PAF_E.RegistroE2[i].DESC_MERC);
				RegistroE2Rec[i].UN_MED = ToUTF8(PAF_E.RegistroE2[i].UN_MED);
				RegistroE2Rec[i].QTDE_EST = Convert.ToDouble(PAF_E.RegistroE2[i].QTDE_EST);
				RegistroE2Rec[i].RegistroValido = PAF_E.RegistroE2[i].RegistroValido;
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_E(this.Handle, RegistroE1Rec, RegistroE2Rec, PAF_E.RegistroE2.Count, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_E.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_H(string arquivo)
		{
			int i;

			ACBrPAFInterop.RegistroHD2Rec RegistroH1Rec = new ACBrPAFInterop.RegistroHD2Rec();
			ACBrPAFInterop.RegistroH2Rec[] RegistroH2Rec = new ACBrPAFInterop.RegistroH2Rec[PAF_H.RegistroH2.Count];

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

			for (i = 0; i < PAF_H.RegistroH2.Count; i++)
			{
				RegistroH2Rec[i].CNPJ_CRED_CARTAO = ToUTF8(PAF_H.RegistroH2[i].CNPJ_CRED_CARTAO);
				RegistroH2Rec[i].COO = PAF_H.RegistroH2[i].COO;
				RegistroH2Rec[i].CCF = PAF_H.RegistroH2[i].CCF;
				RegistroH2Rec[i].VLR_TROCO = Convert.ToDouble(PAF_H.RegistroH2[i].VLR_TROCO);
				RegistroH2Rec[i].DT_TROCO = PAF_H.RegistroH2[i].DT_TROCO.ToOADate();
				RegistroH2Rec[i].CPF = ToUTF8(PAF_H.RegistroH2[i].CPF);
				RegistroH2Rec[i].Titulo = ToUTF8(PAF_H.RegistroH2[i].Titulo);
				RegistroH2Rec[i].RegistroValido = PAF_H.RegistroH2[i].RegistroValido;
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_H(this.Handle, RegistroH1Rec, RegistroH2Rec, PAF_H.RegistroH2.Count, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_H.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_N(string arquivo)
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

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_N(Handle, RegistroN1Rec, RegistroN2Rec, RegistroN3Rec, PAF_N.RegistroN3.Count, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_N.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_P(string arquivo)
		{
			int i;

			ACBrPAFInterop.RegistroHD1Rec RegistroP1Rec = new ACBrPAFInterop.RegistroHD1Rec();
			ACBrPAFInterop.RegistroP2Rec[] RegistroP2Rec = new ACBrPAFInterop.RegistroP2Rec[PAF_P.RegistroP2.Count];

			RegistroP1Rec.RAZAOSOCIAL = PAF_P.RegistroP1.RazaoSocial;
			RegistroP1Rec.CNPJ = PAF_P.RegistroP1.CNPJ;
			RegistroP1Rec.UF = PAF_P.RegistroP1.UF;
			RegistroP1Rec.IE = PAF_P.RegistroP1.IE;
			RegistroP1Rec.IM = PAF_P.RegistroP1.IM;

			for (i = 0; i < PAF_P.RegistroP2.Count; i++)
			{
				RegistroP2Rec[i].COD_MERC_SERV = PAF_P.RegistroP2[i].COD_MERC_SERV;
				RegistroP2Rec[i].DESC_MERC_SERV = PAF_P.RegistroP2[i].DESC_MERC_SERV;
				RegistroP2Rec[i].UN_MED = PAF_P.RegistroP2[i].UN_MED;
				RegistroP2Rec[i].IAT = PAF_P.RegistroP2[i].IAT;
				RegistroP2Rec[i].IPPT = PAF_P.RegistroP2[i].IPPT;
				RegistroP2Rec[i].ST = PAF_P.RegistroP2[i].ST;
				RegistroP2Rec[i].ALIQ = Convert.ToDouble(PAF_P.RegistroP2[i].ALIQ);
				RegistroP2Rec[i].VL_UNIT = Convert.ToDouble(PAF_P.RegistroP2[i].VL_UNIT);
				RegistroP2Rec[i].RegistroValido = PAF_P.RegistroP2[i].RegistroValido;
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_P(this.Handle, RegistroP1Rec, RegistroP2Rec, PAF_P.RegistroP2.Count, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_P.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_R(string arquivo)
		{
			int ItemR1 = 0, ItemR2 = 0, ItemR3 = 0, ItemR4= 0 , ItemR5 = 0, ItemR6 = 0, ItemR7 = 0,
				CR2 = 0, CR3 = 0, CR4 = 0, CR5 = 0, CR6 = 0, CR7 = 0;

			#region Contadores

			foreach (ACBrPAFRegistroR1 R1 in PAF_R.RegistroR1)
			{

				CR2 += R1.RegistroR2.Count;
				foreach (ACBrPAFRegistroR2 R2 in R1.RegistroR2)
				{
					CR3 += R2.RegistroR3.Count;
				}

				CR4 += R1.RegistroR4.Count;
				foreach (ACBrPAFRegistroR4 R4 in R1.RegistroR4)
				{
					CR5 += R4.RegistroR5.Count;
					CR7 += R4.RegistroR7.Count;
				}

				CR6 += R1.RegistroR6.Count;
				foreach (ACBrPAFRegistroR6 R6 in R1.RegistroR6)
				{
					CR7 += R6.RegistroR7.Count;
				}
			}

			#endregion Contadores

			ACBrPAFInterop.RegistroR1Rec[] RegistroR1Rec = new ACBrPAFInterop.RegistroR1Rec[PAF_R.RegistroR1.Count];
			ACBrPAFInterop.RegistroR2Rec[] RegistroR2Rec = new ACBrPAFInterop.RegistroR2Rec[CR2];
			ACBrPAFInterop.RegistroR3Rec[] RegistroR3Rec = new ACBrPAFInterop.RegistroR3Rec[CR3];
			ACBrPAFInterop.RegistroR4Rec[] RegistroR4Rec = new ACBrPAFInterop.RegistroR4Rec[CR4];
			ACBrPAFInterop.RegistroR5Rec[] RegistroR5Rec = new ACBrPAFInterop.RegistroR5Rec[CR5];
			ACBrPAFInterop.RegistroR6Rec[] RegistroR6Rec = new ACBrPAFInterop.RegistroR6Rec[CR6];
			ACBrPAFInterop.RegistroR7Rec[] RegistroR7Rec = new ACBrPAFInterop.RegistroR7Rec[CR7];

			foreach (ACBrPAFRegistroR1 R1 in PAF_R.RegistroR1)
			{
				RegistroR1Rec[ItemR1].QTD_R2 = R1.RegistroR2.Count;
				RegistroR1Rec[ItemR1].NUM_FAB = ToUTF8(R1.NUM_FAB);
				RegistroR1Rec[ItemR1].MF_ADICIONAL = ToUTF8(R1.MF_ADICIONAL);
				RegistroR1Rec[ItemR1].TIPO_ECF = ToUTF8(R1.TIPO_ECF);
				RegistroR1Rec[ItemR1].MARCA_ECF = ToUTF8(R1.MARCA_ECF);
				RegistroR1Rec[ItemR1].MODELO_ECF = ToUTF8(R1.MODELO_ECF);
				RegistroR1Rec[ItemR1].VERSAO_SB = ToUTF8(R1.VERSAO_SB);
				RegistroR1Rec[ItemR1].DT_INST_SB = R1.DT_INST_SB.ToOADate();
				RegistroR1Rec[ItemR1].HR_INST_SB = R1.HR_INST_SB.ToOADate();
				RegistroR1Rec[ItemR1].NUM_SEQ_ECF = R1.NUM_SEQ_ECF;
				RegistroR1Rec[ItemR1].CNPJ = ToUTF8(R1.CNPJ);
				RegistroR1Rec[ItemR1].IE = ToUTF8(R1.IE);
				RegistroR1Rec[ItemR1].CNPJ_SH = ToUTF8(R1.CNPJ_SH);
				RegistroR1Rec[ItemR1].IE_SH = ToUTF8(R1.IE_SH);
				RegistroR1Rec[ItemR1].IM_SH = ToUTF8(R1.IM_SH);
				RegistroR1Rec[ItemR1].NOME_SH = ToUTF8(R1.NOME_SH);
				RegistroR1Rec[ItemR1].NOME_PAF = ToUTF8(R1.NOME_PAF);
				RegistroR1Rec[ItemR1].VER_PAF = ToUTF8(R1.VER_PAF);
				RegistroR1Rec[ItemR1].COD_MD5 = ToUTF8(R1.COD_MD5);
				RegistroR1Rec[ItemR1].DT_INI = R1.DT_INI.ToOADate();
				RegistroR1Rec[ItemR1].DT_FIN = R1.DT_FIN.ToOADate();
				RegistroR1Rec[ItemR1].ER_PAF_ECF = ToUTF8(R1.ER_PAF_ECF);
				RegistroR1Rec[ItemR1].InclusaoExclusao = R1.InclusaoExclusao;
				RegistroR1Rec[ItemR1].RegistroValido = R1.RegistroValido;

				//R2 e R3
				foreach(ACBrPAFRegistroR2 R2 in R1.RegistroR2)
				{
					RegistroR2Rec[ItemR2].QTD_R3 = R2.RegistroR3.Count;
					RegistroR2Rec[ItemR2].NUM_USU = R2.NUM_USU;
					RegistroR2Rec[ItemR2].CRZ = R2.CRZ;
					RegistroR2Rec[ItemR2].COO = R2.COO;
					RegistroR2Rec[ItemR2].CRO = R2.CRO;
					RegistroR2Rec[ItemR2].DT_MOV = R2.DT_MOV.ToOADate();
					RegistroR2Rec[ItemR2].DT_EMI = R2.DT_EMI.ToOADate();
					RegistroR2Rec[ItemR2].HR_EMI = R2.HR_EMI.ToOADate();
					RegistroR2Rec[ItemR2].VL_VBD = Convert.ToDouble(R2.VL_VBD);
					RegistroR2Rec[ItemR2].PAR_ECF = ToUTF8(R2.PAR_ECF);
					RegistroR2Rec[ItemR2].RegistroValido = R2.RegistroValido;

					foreach (ACBrPAFRegistroR3 RegistroR3 in R2.RegistroR3)
					{
						RegistroR3Rec[ItemR3].TOT_PARCIAL = ToUTF8(RegistroR3.TOT_PARCIAL);
						RegistroR3Rec[ItemR3].VL_ACUM = Convert.ToDouble(RegistroR3.VL_ACUM);
						RegistroR3Rec[ItemR3].RegistroValido = RegistroR3.RegistroValido;
						ItemR3++;
					}

					ItemR2++;
				}

				//R4, R5 e R7				
				foreach (ACBrPAFRegistroR4 R4 in R1.RegistroR4)
				{
					RegistroR4Rec[ItemR4].QTD_R5 = R4.RegistroR5.Count;
					RegistroR4Rec[ItemR4].QTD_R7 = R4.RegistroR7.Count;
					RegistroR4Rec[ItemR4].NUM_USU = R4.NUM_USU;
					RegistroR4Rec[ItemR4].NUM_CONT = R4.NUM_CONT;
					RegistroR4Rec[ItemR4].COO = R4.COO;
					RegistroR4Rec[ItemR4].DT_INI = R4.DT_INI.ToOADate();
					RegistroR4Rec[ItemR4].SUB_DOCTO = Convert.ToDouble(R4.SUB_DOCTO);
					RegistroR4Rec[ItemR4].SUB_DESCTO = Convert.ToDouble(R4.SUB_DESCTO);
					RegistroR4Rec[ItemR4].TP_DESCTO = ToUTF8(R4.TP_DESCTO);
					RegistroR4Rec[ItemR4].SUB_ACRES = Convert.ToDouble(R4.SUB_ACRES);
					RegistroR4Rec[ItemR4].TP_ACRES = ToUTF8(R4.TP_ACRES);
					RegistroR4Rec[ItemR4].VL_TOT = Convert.ToDouble(R4.VL_TOT);
					RegistroR4Rec[ItemR4].CANC = ToUTF8(R4.CANC);
					RegistroR4Rec[ItemR4].VL_CA = Convert.ToDouble(R4.VL_CA);
					RegistroR4Rec[ItemR4].ORDEM_DA = ToUTF8(R4.ORDEM_DA);
					RegistroR4Rec[ItemR4].NOME_CLI = ToUTF8(R4.NOME_CLI);
					RegistroR4Rec[ItemR4].CNPJ_CPF = ToUTF8(R4.CNPJ_CPF);
					RegistroR4Rec[ItemR4].RegistroValido = R4.RegistroValido;

					foreach (ACBrPAFRegistroR5 RegistroR5 in R4.RegistroR5)
					{
						RegistroR5Rec[ItemR5].NUM_CONT = RegistroR5.NUM_CONT;
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

					foreach (ACBrPAFRegistroR7 RegistroR7 in R4.RegistroR7)
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

					ItemR4++;
				}

				//R6 e R7
				foreach (ACBrPAFRegistroR6 R6 in R1.RegistroR6)
				{
					RegistroR6Rec[ItemR6].QTD_R7 = R6.RegistroR7.Count;
					RegistroR6Rec[ItemR6].NUM_USU = R6.NUM_USU;
					RegistroR6Rec[ItemR6].COO = R6.COO;
					RegistroR6Rec[ItemR6].GNF = R6.GNF;
					RegistroR6Rec[ItemR6].GRG = R6.GRG;
					RegistroR6Rec[ItemR6].CDC = R6.CDC;
					RegistroR6Rec[ItemR6].DENOM = ToUTF8(R6.DENOM);
					RegistroR6Rec[ItemR6].DT_FIN = R6.DT_FIN.ToOADate();
					RegistroR6Rec[ItemR6].HR_FIN = R6.HR_FIN.ToOADate();
					RegistroR6Rec[ItemR6].RegistroValido = R6.RegistroValido;

					foreach (ACBrPAFRegistroR7 RegistroR7 in R6.RegistroR7)
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

					ItemR6++;
				}

				ItemR1++;
			}

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_R(this.Handle, RegistroR1Rec, PAF_R.RegistroR1.Count,
	                                   			       RegistroR2Rec, CR2, RegistroR3Rec, CR3, RegistroR4Rec, 
											           CR4, RegistroR5Rec, CR5, RegistroR6Rec, CR6, 
												       RegistroR7Rec, CR7, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_R.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_T(string arquivo)
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

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_T(this.Handle, RegistroT1Rec, RegistroT2Rec, PAF_T.RegistroT2.Count, ToUTF8(arquivo));
			CheckResult(ret);
			PAF_T.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		public bool SaveFileTXT_TITP(string arquivo)
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

			int ret = ACBrPAFInterop.PAF_SaveFileTXT_TITP(this.Handle, MercadoriasRec, PAF_TITP.Mercadorias.Count, InsumosRec, ToUTF8(arquivo), ToUTF8(PAF_TITP.Titulo), PAF_TITP.Data.ToOADate());
			CheckResult(ret);
			PAF_TITP.LimparRegistros();

			return Convert.ToBoolean(ret);
		}

		#region Override Methods

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrPAFInterop.PAF_Create);
			PAF_B = new ACBrPAF_B(this);
			PAF_C = new ACBrPAF_C(this);
			PAF_D = new ACBrPAF_D(this);
			PAF_E = new ACBrPAF_E(this);
			PAF_H = new ACBrPAF_H(this);
			PAF_N = new ACBrPAF_N(this);
			PAF_P = new ACBrPAF_P(this);
			PAF_R = new ACBrPAF_R(this);
			PAF_T = new ACBrPAF_T(this);
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