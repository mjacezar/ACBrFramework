using System;
using System.Drawing;
using System.Text;

namespace ACBrFramework
{
	[ToolboxBitmap(typeof(ACBrEAD), @"ACBrEAD.ico.bmp")]
	public class ACBrEAD : ACBrComponent, IDisposable
	{
		#region Events

		public event EventHandler<ChaveEventArgs> OnGetChavePublica;
		public event EventHandler<ChaveEventArgs> OnGetChavePrivada;

		#endregion Events

		#region Fields

		private StrFunctionDelegate onGetChavePublica;
		private StrFunctionDelegate onGetChavePrivada;

		#endregion Fields

		#region Constructor

		public ACBrEAD()
		{
		}

		#endregion Constructor

		#region Methods

		#region Funções

		public void GerarChaves(out string ChavePublica, out string ChavePrivada)
		{
			const int BUFFER_LEN = 1024;
			StringBuilder ChavePUB = new StringBuilder(BUFFER_LEN);
			StringBuilder ChavePRI = new StringBuilder(BUFFER_LEN);

			int ret = ACBrEADInterop.EAD_GerarChaves(this.Handle, ChavePUB, ChavePRI, BUFFER_LEN);
			CheckResult(ret);

			ChavePublica = FromUTF8(ChavePUB);
			ChavePrivada = FromUTF8(ChavePRI);
		}

		public void CalcularModuloeExpoente(out string Modulo, out string Expoente)
		{
			const int BUFFER_LEN = 1024;
			StringBuilder Mod = new StringBuilder(BUFFER_LEN);
			StringBuilder Expo = new StringBuilder(BUFFER_LEN);

			int ret = ACBrEADInterop.EAD_CalcularModuloeExpoente(this.Handle, Mod, Expo, BUFFER_LEN);
			CheckResult(ret);

			Modulo = FromUTF8(Mod);
			Expoente = FromUTF8(Expo);
		}

		public void GerarXMLeECFc(string NomeSH, string CaminhoArquivo)
		{
			int ret = ACBrEADInterop.EAD_GerarXMLeECFc(this.Handle, NomeSH, CaminhoArquivo);
			CheckResult(ret);
		}

		public void GerarXMLeECFc(string NomeSH)
		{
			int ret = ACBrEADInterop.EAD_GerarXMLeECFc_NP(this.Handle, NomeSH);
			CheckResult(ret);
		}

		public string ConverteXMLeECFcParaOpenSSL(string Arquivo)
		{
			const int BUFFER_LEN = 512;
			StringBuilder ChavePUB = new StringBuilder(BUFFER_LEN);
			int ret = ACBrEADInterop.EAD_ConverteXMLeECFcParaOpenSSL(this.Handle, Arquivo, ChavePUB, BUFFER_LEN);
			CheckResult(ret);
			return ChavePUB.ToString();
		}

		public string CalcularHashArquivo(string Arquivo, EADDigest HashType)
		{
			const int BUFFER_LEN = 128;
			StringBuilder Hash = new StringBuilder(BUFFER_LEN);
			int ret = ACBrEADInterop.EAD_CalcularHashArquivo(this.Handle, Arquivo, (int)HashType, Hash, BUFFER_LEN);
			CheckResult(ret);
			return Hash.ToString();
		}

		public string CalcularEADArquivo(string Arquivo)
		{
			const int BUFFER_LEN = 256;
			StringBuilder EAD = new StringBuilder(BUFFER_LEN);
			int ret = ACBrEADInterop.EAD_CalcularEADArquivo(this.Handle, Arquivo, EAD, BUFFER_LEN);
			CheckResult(ret);
			return EAD.ToString();
		}

		public string CalcularChavePublica()
		{
			const int BUFFER_LEN = 512;
			StringBuilder ChavePUB = new StringBuilder(BUFFER_LEN);
			int ret = ACBrEADInterop.EAD_CalcularChavePublica(this.Handle, ChavePUB, BUFFER_LEN);
			CheckResult(ret);
			return ChavePUB.ToString();
		}

		public string AssinarArquivoComEAD(string Arquivo, bool Remover)
		{
			const int BUFFER_LEN = 256;
			StringBuilder EAD = new StringBuilder(BUFFER_LEN);
			int ret = ACBrEADInterop.EAD_AssinarArquivoComEAD(this.Handle, Arquivo, Remover, EAD, BUFFER_LEN);
			CheckResult(ret);
			return EAD.ToString();
		}

		public bool VerificarEADArquivo(string Arquivo)
		{
			int ret = ACBrEADInterop.EAD_VerificarEADArquivo(this.Handle, Arquivo);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Funções

		#region EventHandlers

		private string ead_OnGetChavePublica()
		{
			ChaveEventArgs e = new ChaveEventArgs();

			if (OnGetChavePublica != null)
			{
				OnGetChavePublica(this, e);
			}

			return e.Chave;
		}

		private string ead_OnGetChavePrivada()
		{
			ChaveEventArgs e = new ChaveEventArgs();

			if (onGetChavePrivada != null)
			{
				OnGetChavePrivada(this, e);
			}

			return e.Chave;
		}

		#endregion EventHandlers

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrEADInterop.EAD_Create);

			InitializeEvents();
		}

		private void InitializeEvents()
		{
			int ret;

			onGetChavePublica = new StrFunctionDelegate(ead_OnGetChavePublica);
			onGetChavePrivada = new StrFunctionDelegate(ead_OnGetChavePrivada);

			ret = ACBrEADInterop.EAD_SetOnGetChavePublica(this.Handle, onGetChavePublica);
			CheckResult(ret);

			ret = ACBrEADInterop.EAD_SetOnGetChavePrivada(this.Handle, onGetChavePrivada);
			CheckResult(ret);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrEADInterop.EAD_GetUltimoErro);
					throw new ACBrECFException(error);

				case -2:

					throw new ACBrECFException("ACBr EAD não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrEADInterop.EAD_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}