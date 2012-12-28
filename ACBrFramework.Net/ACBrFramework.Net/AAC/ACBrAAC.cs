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

		#endregion EventHandlers

		#region Fields

		private readonly ACBrEventHandler<ChaveEventArgs, ACBrAACInterop.OnGetChaveCallback> onGetChave;

		#endregion Fields

		#region Constructor

		public ACBrAAC()
		{
			onGetChave = new ACBrEventHandler<ChaveEventArgs, ACBrAACInterop.OnGetChaveCallback>(this, OnGetChaveCallBack, ACBrAACInterop.AAC_SetOnGetChave);
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
		private string OnGetChaveCallBack()
		{
			ChaveEventArgs e = new ChaveEventArgs();

			if (onGetChave.IsAssigned)
				onGetChave.Raise(e);

			return e.Chave;
		}

		#endregion EventHandlers

		#endregion Methods
	}
}