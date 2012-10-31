using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework
{
	[ToolboxBitmap(typeof(ACBrEAD), @"ACBrEAD.ico.bmp")]
	public class ACBrEAD : ACBrComponent, IDisposable
	{
		#region Events

        public event EventHandler<ChaveEventArgs> OnGetChavePublica
        {
            add
            {
                bool isAssigned = onGetChavePublicaHandler != null;
                onGetChavePublicaHandler = (EventHandler<ChaveEventArgs>)Delegate.Combine(onGetChavePublicaHandler, value);

                if (!isAssigned)
                {
                    onGetChavePublicaCallback = new StrFunctionPtrDelegate(ead_OnGetChavePublica);
                    int ret = ACBrEADInterop.EAD_SetOnGetChavePublica(this.Handle, onGetChavePublicaCallback);
                    CheckResult(ret);
                }
            }
            remove
            {
                onGetChavePublicaHandler = (EventHandler<ChaveEventArgs>)Delegate.Remove(onGetChavePublicaHandler, value);

                if (onGetChavePublicaHandler == null)
                {
                    int ret = ACBrEADInterop.EAD_SetOnGetChavePublica(this.Handle, null);
                    CheckResult(ret);

                    onGetChavePublicaCallback = null;
                }
            }
        }

		public event EventHandler<ChaveEventArgs> OnGetChavePrivada
        {
            add
            {
                bool isAssigned = onGetChavePrivadaHandler != null;
                onGetChavePrivadaHandler = (EventHandler<ChaveEventArgs>)Delegate.Combine(onGetChavePrivadaHandler, value);

                if (!isAssigned)
                {
                    onGetChavePrivadaCallback = new StrFunctionPtrDelegate(ead_OnGetChavePrivada);
                    int ret = ACBrEADInterop.EAD_SetOnGetChavePrivada(this.Handle, onGetChavePrivadaCallback);
                    CheckResult(ret);
                }
            }
            remove
            {
                onGetChavePrivadaHandler = (EventHandler<ChaveEventArgs>)Delegate.Remove(onGetChavePrivadaHandler, value);

                if (onGetChavePrivadaHandler == null)
                {
                    int ret = ACBrEADInterop.EAD_SetOnGetChavePrivada(this.Handle, null);
                    CheckResult(ret);

                    onGetChavePrivadaCallback = null;
                }
            }
        }

		#endregion Events

		#region Fields

        private StrFunctionPtrDelegate onGetChavePublicaCallback;
        private StrFunctionPtrDelegate onGetChavePrivadaCallback;

        private EventHandler<ChaveEventArgs> onGetChavePublicaHandler;
        private EventHandler<ChaveEventArgs> onGetChavePrivadaHandler;

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

        [AllowReversePInvokeCalls]
		private string ead_OnGetChavePublica()
		{
			ChaveEventArgs e = new ChaveEventArgs();

			if (onGetChavePublicaHandler != null)
			{
                onGetChavePublicaHandler(this, e);
			}

			return e.Chave;
		}

        [AllowReversePInvokeCalls]
		private string ead_OnGetChavePrivada()
		{
			ChaveEventArgs e = new ChaveEventArgs();

            if (onGetChavePrivadaHandler != null)
			{
                onGetChavePrivadaHandler(this, e);
			}

			return e.Chave;
		}

		#endregion EventHandlers

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrEADInterop.EAD_Create);	
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