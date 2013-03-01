using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ACBrFramework.NFE
{
	public sealed class NFrefCollectionItem : ACBrComposedComponent
	{
		#region Constructor

		public NFrefCollectionItem(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
			this.RefNF = new RefNF();
			this.RefNFP = new RefNFP();
			this.RefECF = new RefECF();
		}

		#endregion Constructor

		#region Properties

		public string refNFe { get; set; }
		public string refCTe { get; set; }
		public RefNF RefNF { get; private set; }
		public RefNFP RefNFP { get; private set; }
		public RefECF RefECF { get; private set; }

		#endregion Properties
	}
}