using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class NFrefCollectionItem : ACBrComposedComponent
	{
		#region Constructor

		public NFrefCollectionItem(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
			this.RefNF = new RefNF(parent, composedHandle);
			this.RefNFP = new RefNFP(parent, composedHandle);
			this.RefECF = new RefECF(parent, composedHandle);
		}

		#endregion Constructor

		#region Properties

		public string RefNFe 
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_GetrefNFe);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_SetrefNFe, value);
			}
		}

		public string RefCTe
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_GetrefCTe);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_SetrefCTe, value);
			}
		}

		public RefNF RefNF { get; private set; }

		public RefNFP RefNFP { get; private set; }

		public RefECF RefECF { get; private set; }

		#endregion Properties
	}
}