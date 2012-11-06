using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ACBrFramework.AAC
{
	[ToolboxBitmap(typeof(ACBrAAC), @"AAC.ico.bmp")]
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

		public string NomeArquivoLog
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

		public string Parametros
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_GetParams);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_SetParams, value);
			}
		}

		[Browsable(true)]
		public ACBrECFIdenticacaoPaf IdentPaf { get; private set; }

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

		public int VerificarGTECF(string numSerie, ref decimal grandeTotal)
		{
			double _grandeTotal = 0d;
			int ret = ACBrAACInterop.AAC_VerificarGTECF(this.Handle, numSerie, ref _grandeTotal);
			CheckResult(ret);

			grandeTotal = Convert.ToDecimal(_grandeTotal);
			return ret;
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
			IdentPaf = new ACBrECFIdenticacaoPaf(this);
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