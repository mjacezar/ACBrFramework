using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;

namespace ACBrFramework.CEP
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.CEP.ico.bmp")]
	public class ACBrCEP : ACBrComponent, IDisposable
	{
		#region Events

		public event EventHandler OnBuscaEfetuada
		{
			add
			{
				onBuscaEfetuada.Add(value);
			}
			remove
			{
				onBuscaEfetuada.Remove(value);
			}
		}

		public event EventHandler<AntesAbrirHTTPEventArgs> OnAntesAbrirHTTP
		{
			add
			{
				onAntesAbrirHTTP.Add(value);
			}
			remove
			{
				onAntesAbrirHTTP.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private Enderecos enderecos;
		private readonly ACBrEventHandler<ACBrCEPInterop.NoArgumentCallback> onBuscaEfetuada;
		private readonly ACBrEventHandler<AntesAbrirHTTPEventArgs, ACBrCEPInterop.AntesAbrirHTTPCallback> onAntesAbrirHTTP;

		#endregion Fields

		#region Constructor

		public ACBrCEP()
		{
			onBuscaEfetuada = new ACBrEventHandler<ACBrCEPInterop.NoArgumentCallback>(this, OnBuscaEfetuadaCallback, ACBrCEPInterop.CEP_SetOnBuscaEfetuada);
			onAntesAbrirHTTP = new ACBrEventHandler<AntesAbrirHTTPEventArgs, ACBrCEPInterop.AntesAbrirHTTPCallback>(this, OnAntesAbrirHTTPCallback, ACBrCEPInterop.CEP_SetOnAntesAbrirHTTP);
		}

		#endregion Constructor

		#region Properties

		[Category("Geral")]
		public string ChaveAcesso
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_GetChaveAcesso);
			}
			set
			{
				SetString(ACBrCEPInterop.CEP_SetChaveAcesso, value);
			}
		}

		[Category("Geral")]
		public string URL
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_GetURL);
			}
		}

		[Category("Geral")]
		public CEPWebService WebService
		{
			get
			{
				return (CEPWebService)GetInt32(ACBrCEPInterop.CEP_GetWebService);
			}
			set
			{
				SetInt32(ACBrCEPInterop.CEP_SetWebService, (int)value);
			}
		}

		[Category("Geral")]
		public bool ParseText
		{
			get
			{
				return GetBool(ACBrCEPInterop.CEP_GetParseText);
			}
			set
			{
				SetBool(ACBrCEPInterop.CEP_SetParseText, value);
			}
		}

		[Category("Proxy")]
		public string ProxyUser
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_GetProxyUser);
			}
			set
			{
				SetString(ACBrCEPInterop.CEP_SetProxyUser, value);
			}
		}

		[Category("Proxy")]
		public string ProxyPass
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_GetProxyPass);
			}
			set
			{
				SetString(ACBrCEPInterop.CEP_SetProxyPass, value);
			}
		}

		[Category("Proxy")]
		public string ProxyHost
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_GetProxyHost);
			}
			set
			{
				SetString(ACBrCEPInterop.CEP_SetProxyHost, value);
			}
		}

		[Category("Proxy")]
		public string ProxyPort
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_GetProxyPort);
			}
			set
			{
				SetString(ACBrCEPInterop.CEP_SetProxyPort, value);
			}
		}

		[Browsable(false)]
		public Enderecos Enderecos
		{
			get
			{
				if (enderecos == null)
				{
					IntPtr composedComponent;
					int ret = ACBrCEPInterop.CEP_GetEnderecos(this.Handle, out composedComponent);
					CheckResult(ret);

					enderecos = new Enderecos(this, composedComponent);

					return enderecos;
				}
				else
					return enderecos;
			}
		}

		#endregion Properties

		#region Methods

		#region Funções

		public bool LerConfiguracoesProxy()
		{
			int ret = ACBrCEPInterop.CEP_LerConfiguracoesProxy(Handle);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		public int BuscarPorCEP(string cep)
		{
			int ret = ACBrCEPInterop.CEP_BuscarPorCEP(Handle, ToUTF8(cep));
			CheckResult(ret);

			return ret;
		}

		public int BuscarPorLogradouro(string cidade, string tipo, string logradouro, string uf, string bairro)
		{
			int ret = ACBrCEPInterop.CEP_BuscarPorLogradouro(Handle, ToUTF8(cidade), ToUTF8(tipo), ToUTF8(logradouro), ToUTF8(uf), ToUTF8(bairro));
			CheckResult(ret);

			return ret;
		}

		#endregion Funções

		#region Callback EventHandlers

		[AllowReversePInvokeCalls]
		private void OnBuscaEfetuadaCallback()
		{
			if (onBuscaEfetuada.IsAssigned)
			{
				onBuscaEfetuada.Raise();
			}
		}

		[AllowReversePInvokeCalls]
		private string OnAntesAbrirHTTPCallback(string url)
		{
			AntesAbrirHTTPEventArgs e = new AntesAbrirHTTPEventArgs(url);

			if (onAntesAbrirHTTP.IsAssigned)
				onAntesAbrirHTTP.Raise(e);

			return ToUTF8(e.AURL);
		}

		#endregion Callback EventHandlers

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrCEPInterop.CEP_Create);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrCEPInterop.CEP_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBrCEP não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrCEPInterop.CEP_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}