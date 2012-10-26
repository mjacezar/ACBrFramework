using System;
using System.ComponentModel;
using System.Drawing;

namespace ACBrFramework
{
	[ToolboxBitmap(typeof(ACBrAAC), @"ACBrAAC.ico.bmp")]
	public class ACBrAAC : ACBrComponent, IDisposable
	{
		#region EventHandlers

		public event EventHandler<ChaveEventArgs> OnGetChave;

		#endregion EventHandlers

		#region Fields

		private StrFunctionPtrDelegate onGetChave;

		#endregion Fields

		#region Constructor

		public ACBrAAC()
		{
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

		public int VerificarGrandeTotal(string numSerie, double grandTotal)
		{
			int ret = ACBrAACInterop.AAC_VerificarGTECF(this.Handle, numSerie, ref grandTotal);

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
					throw new ACBrECFException(error);

				case -2:

					throw new ACBrECFException("ACBr AAC não inicializado.");
			}
		}

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrAACInterop.AAC_Create);
			IdentPaf = new ACBrECFIdenticacaoPaf(this);

			InitializeEvents();
		}

		private void InitializeEvents()
		{
			int ret;

			onGetChave = new StrFunctionPtrDelegate(aac_OnGetChave);
			ret = ACBrAACInterop.AAC_SetOnGetChave(this.Handle, onGetChave);
			CheckResult(ret);
		}

		#endregion Overrides Methods

		#region EventHandlers

		private string aac_OnGetChave()
		{
			ChaveEventArgs e = new ChaveEventArgs();
			
			if (OnGetChave != null)
			{
				OnGetChave(this, e);
			}

			return e.Chave;
		}

		#endregion EventHandlers

		#endregion Methods
	}
}