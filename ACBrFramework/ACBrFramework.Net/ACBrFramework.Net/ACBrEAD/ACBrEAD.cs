using System;
using System.Drawing;
using System.Text;

namespace ACBrFramework
{
	[ToolboxBitmap(typeof(ACBrEAD), @"ACBrEAD.ico.bmp")]
	public class ACBrEAD : ACBrComponent, IDisposable
	{
		#region Propriedaes

		public string ChavePrivada
		{
			get
			{
				return GetString(ACBrEADInterop.EAD_GetChavePrivada, 1024);
			}
			set
			{
				SetString(ACBrEADInterop.EAD_SetChavePrivada, value);
			}
		}

		public string ChavePublica
		{
			get
			{
				return GetString(ACBrEADInterop.EAD_GetChavePublica, 512);
			}
			set
			{
				SetString(ACBrEADInterop.EAD_SetChavePublica, value);
			}
		}

		#endregion Propriedaes

		#region Constructor

		public ACBrEAD()
		{
		}

		#endregion Constructor

		#region Methods

		#region Fun��es

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

		public void ConverteXMLeECFcParaOpenSSL(string Arquivo)
		{
			int ret = ACBrEADInterop.EAD_ConverteXMLeECFcParaOpenSSL(this.Handle, Arquivo);
			CheckResult(ret);
		}

		public string CalcularHashArquivo(string Arquivo, EADDigest HashType)
		{
			const int BUFFER_LEN = 256;
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

		public void AssinarArquivoComEAD(string Arquivo, bool Remover)
		{
			int ret = ACBrEADInterop.EAD_AssinarArquivoComEAD(this.Handle, Arquivo, Remover);
			CheckResult(ret);
		}

		public bool VerificarEADArquivo(string Arquivo)
		{
			int ret = ACBrEADInterop.EAD_VerificarEADArquivo(this.Handle, Arquivo);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Fun��es

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

					throw new ACBrECFException("ACBr EAD n�o inicializado.");
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