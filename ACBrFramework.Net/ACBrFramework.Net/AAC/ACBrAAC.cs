using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ACBrFramework.AAC
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.AAC.ico.bmp")]
	public class ACBrAAC : ACBrComponent, IDisposable
	{
		#region EventHandlers

		public event EventHandler<AntesArquivoArgs> OnAntesAbrirArquivo
		{
			add
			{
				onAntesAbrirArquivo.Add(value);
			}
			remove
			{
				onAntesAbrirArquivo.Remove(value);
			}
		}

		public event EventHandler<AntesArquivoArgs> OnAntesGravarArquivo
		{
			add
			{
				onAntesGravarArquivo.Add(value);
			}
			remove
			{
				onAntesGravarArquivo.Remove(value);
			}
		}

		public event EventHandler<OnCryptArgs> OnCrypt
		{
			add
			{
				onCrypt.Add(value);
			}
			remove
			{
				onCrypt.Remove(value);
			}
		}

		public event EventHandler<OnDeCryptArgs> OnDeCrypt
		{
			add
			{
				onDeCrypt.Add(value);
			}
			remove
			{
				onDeCrypt.Remove(value);
			}
		}

		public event EventHandler OnDepoisAbrirArquivo
		{
			add
			{
				onDepoisAbrirArquivo.Add(value);
			}
			remove
			{
				onDepoisAbrirArquivo.Remove(value);
			}
		}

		public event EventHandler OnDepoisGravarArquivo
		{
			add
			{
				onDepoisGravarArquivo.Add(value);
			}
			remove
			{
				onDepoisGravarArquivo.Remove(value);
			}
		}

		public event EventHandler<ChaveEventArgs> OnGetChave
		{
			add
			{
				onGetChave.Add(value);
			}
			remove
			{
				onGetChave.Remove(value);
			}
		}

		public event EventHandler<VerificarRecomporNumSerieArgs> VerificarRecomporNumSerie
		{
			add
			{
				onVerificarRecomporNumSerie.Add(value);
			}
			remove
			{
				onVerificarRecomporNumSerie.Remove(value);
			}
		}

		public event EventHandler<VerificarRecomporValorGTArgs> VerificarRecomporValorGT
		{
			add
			{
				onVerificarRecomporValorGT.Add(value);
			}
			remove
			{
				onVerificarRecomporValorGT.Remove(value);
			}
		}

		#endregion EventHandlers

		#region Fields

		private readonly ACBrEventHandler<AntesArquivoArgs, ACBrAACInterop.AntesArquivoCallback> onAntesAbrirArquivo;
		private readonly ACBrEventHandler<AntesArquivoArgs, ACBrAACInterop.AntesArquivoCallback> onAntesGravarArquivo;
		private readonly ACBrEventHandler<OnCryptArgs, ACBrAACInterop.CryptCallback> onCrypt;
		private readonly ACBrEventHandler<OnDeCryptArgs, ACBrAACInterop.CryptCallback> onDeCrypt;
		private readonly ACBrEventHandler<ACBrAACInterop.NoArgumentsCallback> onDepoisAbrirArquivo;
		private readonly ACBrEventHandler<ACBrAACInterop.NoArgumentsCallback> onDepoisGravarArquivo;
		private readonly ACBrEventHandler<ChaveEventArgs, ACBrAACInterop.OnGetChaveCallback> onGetChave;
		private readonly ACBrEventHandler<VerificarRecomporNumSerieArgs, ACBrAACInterop.VerificarRecomporNumSerieCallback> onVerificarRecomporNumSerie;
		private readonly ACBrEventHandler<VerificarRecomporValorGTArgs, ACBrAACInterop.VerificarRecomporValorGTCallback> onVerificarRecomporValorGT;

		#endregion Fields

		#region Constructor

		public ACBrAAC()
		{
			onAntesAbrirArquivo = new ACBrEventHandler<AntesArquivoArgs, ACBrAACInterop.AntesArquivoCallback>(this, OnAntesAbrirArquivoCallBack, ACBrAACInterop.AAC_SetOnAntesAbrirArquivo);
			onAntesGravarArquivo = new ACBrEventHandler<AntesArquivoArgs, ACBrAACInterop.AntesArquivoCallback>(this, OnAntesGravarArquivoCallBack, ACBrAACInterop.AAC_SetAntesGravarArquivo);
			onCrypt = new ACBrEventHandler<OnCryptArgs, ACBrAACInterop.CryptCallback>(this, OnCryptCallBack, ACBrAACInterop.AAC_SetOnCrypt);
			onDeCrypt = new ACBrEventHandler<OnDeCryptArgs, ACBrAACInterop.CryptCallback>(this, OnDeCryptCallBack, ACBrAACInterop.AAC_SetOnDeCrypt);
			onDepoisAbrirArquivo = new ACBrEventHandler<ACBrAACInterop.NoArgumentsCallback>(this, OnDepoisAbrirArquivoCallBack,ACBrAACInterop.AAC_SetOnDepoisAbrirArquivo);
			onDepoisGravarArquivo = new ACBrEventHandler<ACBrAACInterop.NoArgumentsCallback>(this, OnDepoisGravarArquivoCallBack, ACBrAACInterop.AAC_SetOnDepoisGravarArquivo);
			onGetChave = new ACBrEventHandler<ChaveEventArgs, ACBrAACInterop.OnGetChaveCallback>(this, OnGetChaveCallBack, ACBrAACInterop.AAC_SetOnGetChave);
			onVerificarRecomporNumSerie = new ACBrEventHandler<VerificarRecomporNumSerieArgs, ACBrAACInterop.VerificarRecomporNumSerieCallback>(this, OnVerificarRecomporNumSerieCallBack, ACBrAACInterop.AAC_SetVerificarRecomporNumSerie);
			onVerificarRecomporValorGT = new ACBrEventHandler<VerificarRecomporValorGTArgs, ACBrAACInterop.VerificarRecomporValorGTCallback>(this, OnVerificarRecomporValorGTCallBack, ACBrAACInterop.AAC_SetVerificarRecomporValor);
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
			double _grandeTotal = 0d;
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
			retorno.CNI = FromUTF8(ECFRec.CNI);
			retorno.CRO = FromUTF8(ECFRec.CRO);
			retorno.ValorGT = FromUTF8(ECFRec.ValorGT);
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

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrAACInterop.AAC_Create);
			IdentPaf = new IdenticacaoPaf(this);
		}

		#endregion Overrides Methods

		#region EventHandlers

		[AllowReversePInvokeCalls]
		private bool OnAntesAbrirArquivoCallBack()
		{
			AntesArquivoArgs e = new AntesArquivoArgs();

			if (onAntesAbrirArquivo.IsAssigned)
				onAntesAbrirArquivo.Raise(e);

			return e.Continua;
		}

		[AllowReversePInvokeCalls]
		private bool OnAntesGravarArquivoCallBack()
		{
			AntesArquivoArgs e = new AntesArquivoArgs();

			if (onAntesAbrirArquivo.IsAssigned)
				onAntesAbrirArquivo.Raise(e);

			return e.Continua;
		}

		[AllowReversePInvokeCalls]
		private string OnCryptCallBack(string value)
		{
			OnCryptArgs e = new OnCryptArgs(value);

			if (onCrypt.IsAssigned)
				onCrypt.Raise(e);

			return ToUTF8(e.Resposta);
		}

		[AllowReversePInvokeCalls]
		private string OnDeCryptCallBack(string value)
		{
			OnDeCryptArgs e = new OnDeCryptArgs(value);

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
			VerificarRecomporNumSerieArgs e = new VerificarRecomporNumSerieArgs(NumSerie, ValorGT);
	
			if (onVerificarRecomporNumSerie.IsAssigned)
				onVerificarRecomporNumSerie.Raise(e);

			CRO = e.CRO;
			CNI = e.CNI;
		}

		[AllowReversePInvokeCalls]
		private double OnVerificarRecomporValorGTCallBack(string NumSerie)
		{
			VerificarRecomporValorGTArgs e = new VerificarRecomporValorGTArgs(NumSerie);

			if (onVerificarRecomporValorGT.IsAssigned)
				onVerificarRecomporValorGT.Raise(e);

			return e.ValorGT;
		}

		#endregion EventHandlers

		#endregion Methods
	}
}