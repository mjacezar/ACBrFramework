using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ACBrFramework.AAC
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
	[Guid("C895D1F5-DCC6-48FE-8F86-427EDC0962F2")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IACBrAACEvents
	{
		[DispId(1)]
		void OnAntesAbrirArquivo(AntesArquivoEventArgs e);

		/*
		[DispId(2)]
		void OnAntesGravarArquivo(AntesArquivoEventArgs e);
		*/

		[DispId(3)]
		void OnCrypt(CryptEventArgs e);

		[DispId(4)]
		void OnDeCrypt(DecryptEventArgs e);

		[DispId(5)]
		void OnDepoisAbrirArquivo();

		[DispId(6)]
		void OnDepoisGravarArquivo();

		[DispId(7)]
		void OnGetChave(ChaveEventArgs e);

		[DispId(8)]
		void VerificarRecomporNumSerie(VerificarRecomporNumSerieEventArgs e);

		/*
		[DispId(9)]
		void VerificarRecomporValorGT(VerificarRecomporValorGTEventArgs e);
		 * */
	}

	#endregion IDispatch Interface

	#region Delegates

	#region Comments

	///os componentes COM não suportam Generics
	///Estas são implementações específicas de delegates que no .Net são representados como EventHandler<T>

	#endregion Comments

	public delegate void AntesArquivoEventHandler(AntesArquivoEventArgs e);

	public delegate void CryptEventHandler(CryptEventArgs e);

	public delegate void DecryptEventHandler(DecryptEventArgs e);

	public delegate void ChaveEventHandler(ChaveEventArgs e);

	public delegate void VerificarRecomporNumSerieEventHandler(VerificarRecomporNumSerieEventArgs e);

	public delegate void VerificarRecomporValorGTEventHandler(VerificarRecomporValorGTEventArgs e);

	#endregion Delegates

#endif

	#endregion COM Interop

	#region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("D34A09C2-3058-4EEC-BB5E-976F48928B5B")]
	[ComSourceInterfaces(typeof(IACBrAACEvents))]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM Interop Attributes

	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.AAC.ico.bmp")]
	public class ACBrAAC : ACBrComponent, IDisposable
	{
		#region EventHandlers

#if COM_INTEROP

		public event AntesArquivoEventHandler OnAntesAbrirArquivo
#else

		public event EventHandler<AntesArquivoEventArgs> OnAntesAbrirArquivo
#endif
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			add
			{
				onAntesAbrirArquivo.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			remove
			{
				onAntesAbrirArquivo.Remove(value);
			}
		}

#if COM_INTEROP

		public event AntesArquivoEventHandler OnAntesGravarArquivo
#else
		public event EventHandler<AntesArquivoEventArgs> OnAntesGravarArquivo
#endif
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			add
			{
				onAntesGravarArquivo.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			remove
			{
				onAntesGravarArquivo.Remove(value);
			}
		}

#if COM_INTEROP

		public event CryptEventHandler OnCrypt
#else
		public event EventHandler<CryptEventArgs> OnCrypt
#endif
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			add
			{
				onCrypt.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			remove
			{
				onCrypt.Remove(value);
			}
		}

#if COM_INTEROP

		public event DecryptEventHandler OnDecrypt
#else
		public event EventHandler<DecryptEventArgs> OnDecrypt
#endif
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			add
			{
				onDeCrypt.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			remove
			{
				onDeCrypt.Remove(value);
			}
		}

		public event EventHandler OnDepoisAbrirArquivo
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			add
			{
				onDepoisAbrirArquivo.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			remove
			{
				onDepoisAbrirArquivo.Remove(value);
			}
		}

		public event EventHandler OnDepoisGravarArquivo
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			add
			{
				onDepoisGravarArquivo.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			remove
			{
				onDepoisGravarArquivo.Remove(value);
			}
		}

#if COM_INTEROP

		public event ChaveEventHandler OnGetChave
#else

		public event EventHandler<ChaveEventArgs> OnGetChave
#endif
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			add
			{
				onGetChave.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			remove
			{
				onGetChave.Remove(value);
			}
		}

#if COM_INTEROP

		public event VerificarRecomporNumSerieEventHandler VerificarRecomporNumSerie
#else
		public event EventHandler<VerificarRecomporNumSerieEventArgs> VerificarRecomporNumSerie
#endif
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			add
			{
				onVerificarRecomporNumSerie.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			remove
			{
				onVerificarRecomporNumSerie.Remove(value);
			}
		}

#if COM_INTEROP

		public event VerificarRecomporValorGTEventHandler VerificarRecomporValorGT
#else
		public event EventHandler<VerificarRecomporValorGTEventArgs> VerificarRecomporValorGT
#endif
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			add
			{
				onVerificarRecomporValorGT.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			remove
			{
				onVerificarRecomporValorGT.Remove(value);
			}
		}

		#endregion EventHandlers

		#region Fields

		private readonly ACBrEventHandler<AntesArquivoEventArgs, ACBrAACInterop.AntesArquivoCallback> onAntesAbrirArquivo;
		private readonly ACBrEventHandler<AntesArquivoEventArgs, ACBrAACInterop.AntesArquivoCallback> onAntesGravarArquivo;
		private readonly ACBrEventHandler<CryptEventArgs, ACBrAACInterop.CryptCallback> onCrypt;
		private readonly ACBrEventHandler<DecryptEventArgs, ACBrAACInterop.CryptCallback> onDeCrypt;
		private readonly ACBrEventHandler<ACBrAACInterop.NoArgumentsCallback> onDepoisAbrirArquivo;
		private readonly ACBrEventHandler<ACBrAACInterop.NoArgumentsCallback> onDepoisGravarArquivo;
		private readonly ACBrEventHandler<ChaveEventArgs, ACBrAACInterop.OnGetChaveCallback> onGetChave;
		private readonly ACBrEventHandler<VerificarRecomporNumSerieEventArgs, ACBrAACInterop.VerificarRecomporNumSerieCallback> onVerificarRecomporNumSerie;
		private readonly ACBrEventHandler<VerificarRecomporValorGTEventArgs, ACBrAACInterop.VerificarRecomporValorGTCallback> onVerificarRecomporValorGT;

		#endregion Fields

		#region Constructor

		public ACBrAAC()
		{
			onAntesAbrirArquivo = new ACBrEventHandler<AntesArquivoEventArgs, ACBrAACInterop.AntesArquivoCallback>(this, OnAntesAbrirArquivoCallBack, ACBrAACInterop.AAC_SetOnAntesAbrirArquivo);
			onAntesGravarArquivo = new ACBrEventHandler<AntesArquivoEventArgs, ACBrAACInterop.AntesArquivoCallback>(this, OnAntesGravarArquivoCallBack, ACBrAACInterop.AAC_SetAntesGravarArquivo);
			onCrypt = new ACBrEventHandler<CryptEventArgs, ACBrAACInterop.CryptCallback>(this, OnCryptCallBack, ACBrAACInterop.AAC_SetOnCrypt);
			onDeCrypt = new ACBrEventHandler<DecryptEventArgs, ACBrAACInterop.CryptCallback>(this, OnDeCryptCallBack, ACBrAACInterop.AAC_SetOnDeCrypt);
			onDepoisAbrirArquivo = new ACBrEventHandler<ACBrAACInterop.NoArgumentsCallback>(this, OnDepoisAbrirArquivoCallBack, ACBrAACInterop.AAC_SetOnDepoisAbrirArquivo);
			onDepoisGravarArquivo = new ACBrEventHandler<ACBrAACInterop.NoArgumentsCallback>(this, OnDepoisGravarArquivoCallBack, ACBrAACInterop.AAC_SetOnDepoisGravarArquivo);
			onGetChave = new ACBrEventHandler<ChaveEventArgs, ACBrAACInterop.OnGetChaveCallback>(this, OnGetChaveCallBack, ACBrAACInterop.AAC_SetOnGetChave);
			onVerificarRecomporNumSerie = new ACBrEventHandler<VerificarRecomporNumSerieEventArgs, ACBrAACInterop.VerificarRecomporNumSerieCallback>(this, OnVerificarRecomporNumSerieCallBack, ACBrAACInterop.AAC_SetVerificarRecomporNumSerie);
			onVerificarRecomporValorGT = new ACBrEventHandler<VerificarRecomporValorGTEventArgs, ACBrAACInterop.VerificarRecomporValorGTCallback>(this, OnVerificarRecomporValorGTCallBack, ACBrAACInterop.AAC_SetVerificarRecomporValor);
		}

		#endregion Constructor

		#region Properties

		[Category("AAC")]
		public string NomeArquivoAuxiliar
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_GetNomeArquivoAux);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_SetNomeArquivoAux, value);
			}
		}

		[Category("AAC")]
		public string ArqLOG
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_GetArqLOG);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_SetArqLOG, value);
			}
		}

		[Category("AAC")]
		public string[] Params
		{
			get
			{
				return GetStringArray(ACBrAACInterop.AAC_GetParams, ACBrAACInterop.AAC_GetParamsCount);
			}
			set
			{
				SetStringArray(ACBrAACInterop.AAC_SetParams, value);
			}
		}

		[Category("AAC")]
		public bool CriarBAK
		{
			get
			{
				return GetBool(ACBrAACInterop.AAC_GetCriarBAK);
			}
			set
			{
				SetBool(ACBrAACInterop.AAC_SetCriarBAK, value);
			}
		}

		[Category("AAC")]
		public bool EfetuarFlush
		{
			get
			{
				return GetBool(ACBrAACInterop.AAC_GetEfetuarFlush);
			}
			set
			{
				SetBool(ACBrAACInterop.AAC_SetEfetuarFlush, value);
			}
		}

		[Category("AAC")]
		public bool GravarConfigApp
		{
			get
			{
				return GetBool(ACBrAACInterop.AAC_GetGravarConfigApp);
			}
			set
			{
				SetBool(ACBrAACInterop.AAC_SetGravarConfigApp, value);
			}
		}

		[Category("AAC")]
		public bool GravarDadosPAF
		{
			get
			{
				return GetBool(ACBrAACInterop.AAC_GetGravarDadosPAF);
			}
			set
			{
				SetBool(ACBrAACInterop.AAC_SetGravarDadosPAF, value);
			}
		}

		[Category("AAC")]
		public bool GravarDadosSH
		{
			get
			{
				return GetBool(ACBrAACInterop.AAC_GetGravarDadosSH);
			}
			set
			{
				SetBool(ACBrAACInterop.AAC_SetGravarDadosSH, value);
			}
		}

		[Category("AAC")]
		public bool GravarTodosECFs
		{
			get
			{
				return GetBool(ACBrAACInterop.AAC_GetGravarTodosECFs);
			}
			set
			{
				SetBool(ACBrAACInterop.AAC_SetGravarTodosECFs, value);
			}
		}

		[Browsable(true)]
		[Category("Identificação")]
		public IdenticacaoPaf IdentPaf { get; private set; }

		#endregion Properties

		#region Methods

		public void AbrirArquivo()
		{
			int ret = ACBrAACInterop.AAC_AbrirArquivo(this.Handle);
			CheckResult(ret);
		}

		public void SalvarArquivo()
		{
			int ret = ACBrAACInterop.AAC_SalvarArquivo(this.Handle);
			CheckResult(ret);
		}

		public void VerificaReCarregarArquivo()
		{
			int ret = ACBrAACInterop.AAC_VerificaReCarregarArquivo(this.Handle);
			CheckResult(ret);
		}

		public int VerificarGTECF(string numSerie, ref decimal grandeTotal)
		{
			double _grandeTotal = Convert.ToDouble(grandeTotal);
			int ret = ACBrAACInterop.AAC_VerificarGTECF(this.Handle, numSerie, ref _grandeTotal);
			CheckResult(ret);

			grandeTotal = Convert.ToDecimal(_grandeTotal);
			return ret;
		}

		public void AtualizarValorGT(string numSerie, decimal grandeTotal)
		{
			double _grandeTotal = Convert.ToDouble(grandeTotal);
			int ret = ACBrAACInterop.AAC_AtualizarValorGT(this.Handle, numSerie, _grandeTotal);
			CheckResult(ret);
		}

		public void AtualizarMD5(string md5)
		{
			int ret = ACBrAACInterop.AAC_AtualizarMD5(this.Handle, md5);
			CheckResult(ret);
		}

		public int AchaIndiceECF(string serie)
		{
			int retorno = -1;
			int ret = ACBrAACInterop.AAC_AchaIndiceECF(this.Handle, serie, ref retorno);
			CheckResult(ret);

			return retorno;
		}

		public AACECF AchaECF(string serie)
		{
			ACBrAACInterop.TECFAutorizado ECFRec = new ACBrAACInterop.TECFAutorizado();
			int ret = ACBrAACInterop.AAC_AchaECF(this.Handle, serie, ref ECFRec);
			CheckResult(ret);

			if (ret == 0)
				return null;

			AACECF retorno = new AACECF();
			retorno.CNI = ECFRec.CNI;
			retorno.CRO = ECFRec.CRO;
			retorno.ValorGT = Convert.ToDecimal(ECFRec.ValorGT);
			retorno.DtHrAtualizado = DateTime.FromOADate(ECFRec.DtHrAtualizado);
			retorno.NumeroSerie = FromUTF8(ECFRec.NumeroSerie);

			return retorno;
		}

		public int ECFsAutorizadosCount
		{
			get
			{
				int ret = ACBrAACInterop.AAC_IdentPaf_ECFsAutorizados_Count(this.Handle);
				CheckResult(ret);

				return ret;
			}
		}

		#region Overrides Methods

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrAACInterop.AAC_Destroy);
			}
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrAACInterop.AAC_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr AAC não inicializado.");
			}
		}

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrAACInterop.AAC_Create);
			IdentPaf = new IdenticacaoPaf(this);
		}

		#endregion Overrides Methods

		#region EventHandlers

		[AllowReversePInvokeCalls]
		private bool OnAntesAbrirArquivoCallBack()
		{
			AntesArquivoEventArgs e = new AntesArquivoEventArgs();

			if (onAntesAbrirArquivo.IsAssigned)
				onAntesAbrirArquivo.Raise(e);

			return e.Continua;
		}

		[AllowReversePInvokeCalls]
		private bool OnAntesGravarArquivoCallBack()
		{
			AntesArquivoEventArgs e = new AntesArquivoEventArgs();

			if (onAntesAbrirArquivo.IsAssigned)
				onAntesAbrirArquivo.Raise(e);

			return e.Continua;
		}

		[AllowReversePInvokeCalls]
		private string OnCryptCallBack(string value)
		{
			CryptEventArgs e = new CryptEventArgs(value);

			if (onCrypt.IsAssigned)
				onCrypt.Raise(e);

			return ToUTF8(e.Resposta);
		}

		[AllowReversePInvokeCalls]
		private string OnDeCryptCallBack(string value)
		{
			DecryptEventArgs e = new DecryptEventArgs(value);

			if (onDeCrypt.IsAssigned)
				onDeCrypt.Raise(e);

			return ToUTF8(e.Resposta);
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisAbrirArquivoCallBack()
		{
			if (onDepoisAbrirArquivo.IsAssigned)
				onDepoisAbrirArquivo.Raise();
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisGravarArquivoCallBack()
		{
			if (onDepoisGravarArquivo.IsAssigned)
				onDepoisGravarArquivo.Raise();
		}

		[AllowReversePInvokeCalls]
		private string OnGetChaveCallBack()
		{
			ChaveEventArgs e = new ChaveEventArgs();

			if (onGetChave.IsAssigned)
				onGetChave.Raise(e);

			return ToUTF8(e.Chave);
		}

		[AllowReversePInvokeCalls]
		private void OnVerificarRecomporNumSerieCallBack(string NumSerie, double ValorGT, ref int CRO, ref int CNI)
		{
			VerificarRecomporNumSerieEventArgs e = new VerificarRecomporNumSerieEventArgs(NumSerie, Convert.ToDecimal(ValorGT));

			if (onVerificarRecomporNumSerie.IsAssigned)
			{
				onVerificarRecomporNumSerie.Raise(e);
			}

			CRO = e.CRO;
			CNI = e.CNI;
		}

		[AllowReversePInvokeCalls]
		private double OnVerificarRecomporValorGTCallBack(string NumSerie)
		{
			VerificarRecomporValorGTEventArgs e = new VerificarRecomporValorGTEventArgs(NumSerie);

			if (onVerificarRecomporValorGT.IsAssigned)
				onVerificarRecomporValorGT.Raise(e);

			return Convert.ToDouble(e.ValorGT);
		}

		#endregion EventHandlers

		#endregion Methods
	}
}