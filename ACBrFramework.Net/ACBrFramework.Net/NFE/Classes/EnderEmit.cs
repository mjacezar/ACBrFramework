using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class EnderEmit : ACBrComposedComponent
	{
		#region Constructor

		internal EnderEmit(ACBrNFE parent, IntPtr composedHandle)
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
				return GetInt32(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_GetCEP);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_SetCEP, value);
			}
		}

		public int CMun
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_GetcMun);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_SetcMun, value);
			}
		}

		public int CPais
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_GetcPais);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_SetcPais, value);
			}
		}

		public string Fone
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_Getfone);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_Setfone, value);
			}
		}

		public string Nro
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_Getnro);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_Setnro, value);
			}
		}

		public string UF
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_GetUF);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_SetUF, value);
			}
		}

		public string XBairro
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_GetxBairro);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_SetxBairro, value);
			}
		}

		public string XCpl
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_GetxCpl);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_SetxCpl, value);
			}
		}

		public string XLgr
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_GetxLgr);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_SetxLgr, value);
			}
		}

		public string XMun
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_GetxMun);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_SetxMun, value);
			}
		}

		public string XPais
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_GetxPais);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_EnderEmit_SetxPais, value);
			}
		}

		#endregion Properties
	}
}
