using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class Retirada : ACBrComposedComponent
	{
		#region Constructor

		internal Retirada(ACBrNFE parent, IntPtr composedHandle)
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
				return GetInt32(ACBrNFEInterop.NFE_NFe_Retirada_GetCMun);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Retirada_SetCMun, value);
			}
		}

		public string CNPJCPF
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Retirada_GetCNPJCPF);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Retirada_SetCNPJCPF, value);
			}
		}

		public string XLgr
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Retirada_GetXLgr);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Retirada_SetXLgr, value);
			}
		}

		public string Nro
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Retirada_GetNro);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Retirada_SetNro, value);
			}
		}

		public string XCpl
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Retirada_GetXCpl);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Retirada_SetXCpl, value);
			}
		}

		public string XBairro
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Retirada_GetXBairro);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Retirada_SetXBairro, value);
			}
		}

		public string XMun
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Retirada_GetXMun);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Retirada_SetXMun, value);
			}
		}

		public string UF
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Retirada_GetUF);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Retirada_SetUF, value);
			}
		}

		#endregion Properties
	}
}