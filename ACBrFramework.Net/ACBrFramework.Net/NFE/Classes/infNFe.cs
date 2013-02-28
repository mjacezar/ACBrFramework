using System;

namespace ACBrFramework.NFE
{
	public sealed class infNFe : ACBrComposedComponent
	{
		#region Constructor

		internal infNFe(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{

		}

		#endregion Constructor

		#region Properties

		public string ID 
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_infNFe_GetID);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_infNFe_SetID, value);
			}
		}

		public decimal Versao 
		{
			get
			{
				return GetDecimal(ACBrNFEInterop.NFE_NFe_infNFe_GetVersao);
			}
			set
			{
				SetDecimal(ACBrNFEInterop.NFE_NFe_infNFe_SetVersao, value);
			}
		}

		public string VersaoStr
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_infNFe_GetVersaoStr);
			}
		}

		#endregion Properties
	}
}
