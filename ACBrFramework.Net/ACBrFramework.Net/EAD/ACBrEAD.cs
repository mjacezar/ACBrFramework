using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.EAD
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
	[Guid("566764AC-08FC-4946-81A6-CBDA2BEB5801")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IACBrEADEvents
	{
		[DispId(1)]
		void OnGetChavePublica(ChaveEventArgs e);

		[DispId(2)]
		void OnGetChavePrivada(ChaveEventArgs e);
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
	[Guid("E694C7C6-5C00-4F73-B091-6CF27AAD0682")]
	[ComSourceInterfaces(typeof(IACBrEADEvents))]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM Interop Attributes

	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.EAD.ico.bmp")]
	public class ACBrEAD : ACBrComponent, IDisposable
	{
		#region Events

#if COM_INTEROP

		public event ChaveEventHandler OnGetChavePublica
#else

		public event EventHandler<ChaveEventArgs> OnGetChavePublica
#endif
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			add
			{
				onGetChavePublica.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			remove
			{
				onGetChavePublica.Remove(value);
			}
		}

#if COM_INTEROP

		public event ChaveEventHandler OnGetChavePrivada
#else

		public event EventHandler<ChaveEventArgs> OnGetChavePrivada
#endif
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			add
			{
				onGetChavePrivada.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

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

		#region Properties

		[Category("Geral")]
		public string OpenSSL_Version
		{
			get
			{
				return GetString(ACBrEADInterop.EAD_GetOpenSSL_Version);
			}
		}

		[Category("Geral")]
		public string About
		{
			get
			{
				return GetAbout(ACBrEADInterop.EAD_GetAbout);
			}
		}

		#endregion Properties

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

		public void GerarXMLeECFc(string NomeSH)
		{
			GerarXMLeECFc(NomeSH, null);
		}

		public void GerarXMLeECFc(string NomeSH, string CaminhoArquivo)
		{
			int ret = ACBrEADInterop.EAD_GerarXMLeECFc(this.Handle, NomeSH, CaminhoArquivo);
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

		#region COM_INTEROP

#if COM_INTEROP

		[ComVisible(false)]
#endif

		#endregion COM_INTEROP

		public List<string> CalcularHash(List<string> Astring, EADDigest HashType)
		{
			List<string> retorno = new List<string>();
			retorno.AddRange(CalcularHash(Astring.ToArray(), HashType));
			return retorno;
		}

		public string[] CalcularHash(string[] AString, EADDigest HashType)
		{
			string[] Retorno = new string[AString.Length];

			for (int i = 0; i < AString.Length; i++)
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

		#region COM_INTEROP

#if COM_INTEROP

		[ComVisible(false)]
#endif

		#endregion COM_INTEROP

		public string CalcularEAD(List<string> AString)
		{
			return CalcularEAD(AString.ToArray());
		}

		public string CalcularEAD(string[] AString)
		{
			const int BUFFER_LEN = 256;
			StringBuilder EAD = new StringBuilder(BUFFER_LEN);
			int ret = ACBrEADInterop.EAD_CalcularEAD(Handle, AString, EAD, BUFFER_LEN);
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

		public bool VerificarEAD(string AString)
		{
			int ret = ACBrEADInterop.EAD_VerificarEAD(this.Handle, AString);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		public void RemoveEADArquivo(string Arquivo)
		{
			int ret = ACBrEADInterop.EAD_RemoveEADArquivo(Handle, Arquivo);
			CheckResult(ret);
		}

		public string MD5FromFile(string Arquivo)
		{
			const int BUFFER_LEN = 256;
			StringBuilder MD5 = new StringBuilder(BUFFER_LEN);
			int ret = ACBrEADInterop.EAD_MD5FromFile(Handle, Arquivo, MD5, BUFFER_LEN);
			CheckResult(ret);
			return MD5.ToString();
		}

		public string MD5FromString(string AString)
		{
			const int BUFFER_LEN = 256;
			StringBuilder MD5 = new StringBuilder(BUFFER_LEN);
			int ret = ACBrEADInterop.EAD_MD5FromString(Handle, AString, MD5, BUFFER_LEN);
			CheckResult(ret);
			return MD5.ToString();
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

		protected internal override void OnInitialize()
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