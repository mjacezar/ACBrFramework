using System;
using System.Text;
using System.ComponentModel;

namespace ACBrFramework.NFE
{
	public sealed class NFECFGWebServices : ACBrComposedComponent
	{
		#region Constructor

		public NFECFGWebServices(ACBrNFE parent)
			: base(parent)
		{

		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public bool Visualizar
		{
			get
			{
				return GetBool(ACBrNFEInterop.NFE_CFG_WebServices_GetVisualizar);
			}
			set
			{
				SetBool(ACBrNFEInterop.NFE_CFG_WebServices_SetVisualizar, value);
			}
		}

		[Browsable(true)]
		public NFeUF UF
		{
			get
			{
				return (NFeUF)Enum.Parse(typeof(NFeUF), GetString(ACBrNFEInterop.NFE_CFG_WebServices_GetUF));
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_WebServices_SetUF, value.ToString());
			}
		}

		[Browsable(true)]
		public int UFCodigo
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_CFG_WebServices_GetUFCodigo);
			}
		}

		[Browsable(true)]
		public TipoAmbiente Ambiente
		{
			get
			{
				return (TipoAmbiente)GetInt32(ACBrNFEInterop.NFE_CFG_WebServices_GetAmbiente);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_CFG_WebServices_SetAmbiente, (int)value);
			}
		}

		[Browsable(true)]
		public int AmbienteCodigo
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_CFG_WebServices_GetAmbienteCodigo);
			}
		}

		[Browsable(true)]
		public string ProxyHost
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_WebServices_GetProxyHost);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_WebServices_SetProxyHost, value);
			}
		}

		[Browsable(true)]
		public string ProxyPort
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_WebServices_GetProxyPort);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_WebServices_SetProxyPort, value);
			}
		}

		[Browsable(true)]
		public string ProxyUser
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_WebServices_GetProxyUser);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_WebServices_SetProxyUser, value);
			}
		}

		[Browsable(true)]
		public string ProxyPass
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_WebServices_GetProxyPass);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_WebServices_SetProxyPass, value);
			}
		}

		[Browsable(true)]
		public uint AguardarConsultaRet
		{
			get
			{
				return (uint)GetInt32(ACBrNFEInterop.NFE_CFG_WebServices_GetAguardarConsultaRet);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_CFG_WebServices_SetAguardarConsultaRet, (int)value);
			}
		}

		[Browsable(true)]
		public int Tentativas
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_CFG_WebServices_GetTentativas);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_CFG_WebServices_SetTentativas, value);
			}
		}

		[Browsable(true)]
		public bool AjustaAguardaConsultaRet
		{
			get
			{
				return GetBool(ACBrNFEInterop.NFE_CFG_WebServices_GetAjustaAguardaConsultaRet);
			}
			set
			{
				SetBool(ACBrNFEInterop.NFE_CFG_WebServices_SetAjustaAguardaConsultaRet, value);
			}
		}

		#endregion Properties

		#region Methods

		#endregion Methods
	}
}
