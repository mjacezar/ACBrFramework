using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class EnderDest: ACBrComposedComponent
	{
		#region Constructor

		internal EnderDest(ACBrNFE parent, IntPtr composedHandle)
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

		public int CEP
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_GetCEP);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_SetCEP, value);
			}
		}

		public int CMun
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_GetCMun);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_SetCMun, value);
			}
		}

		public int CPais
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_GetCPais);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_SetCPais, value);
			}
		}

		public string Fone
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_GetFone);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_SetFone, value);
			}
		}

		public string Nro
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_GetNro);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_SetNro, value);
			}
		}

		public string UF
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_GetUF);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_SetUF, value);
			}
		}

		public string XBairro
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_GetXBairro);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_SetXBairro, value);
			}
		}

		public string XCpl
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_GetXCpl);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_SetXCpl, value);
			}
		}

		public string XLgr
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_GetXLgr);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_SetXLgr, value);
			}
		}

		public string XMun
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_GetXMun);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_SetXMun, value);
			}
		}

		public string XPais
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_GetXPais);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Dest_EnderDest_SetXPais, value);
			}
		}

		#endregion Properties
	}
}