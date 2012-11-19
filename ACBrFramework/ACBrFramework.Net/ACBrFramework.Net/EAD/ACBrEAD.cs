using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.EAD
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.EAD.ico.bmp")]
	public class ACBrEAD : ACBrComponent, IDisposable
	{
		#region Events

		public event EventHandler<ChaveEventArgs> OnGetChavePublica
		{
			add
			{
				onGetChavePublica.Add(value);
			}
			remove
			{
				onGetChavePublica.Remove(value);
			}
		}

		public event EventHandler<ChaveEventArgs> OnGetChavePrivada
		{
			add
			{
				onGetChavePrivada.Add(value);
			}
			remove
			{
				onGetChavePrivada.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<ChaveEventArgs, ACBrEADInterop.OnGetChavePublicaCallback> onGetChavePublica;
		private readonly ACBrEventHandler<ChaveEventArgs, ACBrEADInterop.OnGetChavePrivadaCallback> onGetChavePrivada;

		#endregion Fields

		#region Constructor

		public ACBrEAD()
		{
			onGetChavePrivada = new ACBrEventHandler<ChaveEventArgs, ACBrEADInterop.OnGetChavePrivadaCallback>(this, OnGetChavePrivadaCallBack, ACBrEADInterop.EAD_SetOnGetChavePrivada);
			onGetChavePublica = new ACBrEventHandler<ChaveEventArgs, ACBrEADInterop.OnGetChavePublicaCallback>(this, OnGetChavePublicaCallBack, ACBrEADInterop.EAD_SetOnGetChavePublica);
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
			int ret = ACBrEADInterop.EAD_CalcularHashArquivo(Handle, Arquivo, (int)HashType, Hash, BUFFER_LEN);
			CheckResult(ret);
			return Hash.ToString();
		}

        public string[] CalcularHash(string[] AString, EADDigest HashType)
        {
            string[] Retorno = new string[AString.Length];

            for(int i = 0; i < AString.Length; i++)
            {
                Retorno[i] = CalcularHash(AString[i], HashType);
            }

            return Retorno;
        }

        public string CalcularHash(string AString, EADDigest HashType)
        {
            const int BUFFER_LEN = 128;
            StringBuilder Hash = new StringBuilder(BUFFER_LEN);
            int ret = ACBrEADInterop.EAD_CalcularHash(Handle, AString, (int)HashType, Hash, BUFFER_LEN);
            CheckResult(ret);
            return Hash.ToString();
        }

		public string CalcularEADArquivo(string Arquivo)
		{
			const int BUFFER_LEN = 256;
			StringBuilder EAD = new StringBuilder(BUFFER_LEN);
			int ret = ACBrEADInterop.EAD_CalcularEADArquivo(Handle, Arquivo, EAD, BUFFER_LEN);
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
		private string OnGetChavePublicaCallBack()
		{
			ChaveEventArgs e = new ChaveEventArgs();

			if (onGetChavePublica.IsAssigned)
				onGetChavePublica.Raise(e);

			return e.Chave;
		}

		[AllowReversePInvokeCalls]
		private string OnGetChavePrivadaCallBack()
		{
			ChaveEventArgs e = new ChaveEventArgs();

			if (onGetChavePrivada.IsAssigned)
				onGetChavePrivada.Raise(e);

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
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr EAD não inicializado.");
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