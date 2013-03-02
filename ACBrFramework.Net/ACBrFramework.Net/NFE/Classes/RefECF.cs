using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public class RefECF : ACBrComposedComponent
	{
		#region Constructor

		public RefECF(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle){	}

		#endregion Constructor

		#region Properties

		public ECFModRef Modelo
		{
			get
			{
				return (ECFModRef)GetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefECF_Getmodelo);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefECF_Setmodelo, (int)value);
			}
		}

		public string NECF
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefECF_GetnECF);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefECF_SetnECF, value);
			}
		}

		public string NCOO
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefECF_GetnCOO);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefECF_SetnCOO, value);
			}
		}

		#endregion Properties
	}
}
