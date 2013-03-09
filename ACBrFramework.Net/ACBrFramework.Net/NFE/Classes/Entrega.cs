using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class Entrega : ACBrComposedComponent
	{
		#region Constructor

		internal Entrega(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{

		}

		#endregion Constructor

		#region Properties

		private new ACBrNFE Parent
		{
			get
			{
				return (ACBrNFE)base.Parent;
			}
		}

		public int CMun
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Entrega_GetCMun);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Entrega_SetCMun, value);
			}
		}

		public string CNPJCPF
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Entrega_GetCNPJCPF);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Entrega_SetCNPJCPF, value);
			}
		}

		public string XLgr
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Entrega_GetXLgr);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Entrega_SetXLgr, value);
			}
		}

		public string Nro
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Entrega_GetNro);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Entrega_SetNro, value);
			}
		}

		public string XCpl
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Entrega_GetXCpl);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Entrega_SetXCpl, value);
			}
		}

		public string XBairro
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Entrega_GetXBairro);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Entrega_SetXBairro, value);
			}
		}

		public string XMun
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Entrega_GetXMun);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Entrega_SetXMun, value);
			}
		}

		public string UF
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Entrega_GetUF);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Entrega_SetUF, value);
			}
		}

		#endregion Properties
	}
}
