using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ACBrFramework.NFE
{
	public class NFrefCollectionItem
	{
		public NFrefCollectionItem()
		{
			this.RefNF = new RefNF();
			this.RefNFP = new RefNFP();
			this.RefECF = new RefECF();
		}

		public string refNFe { get; set; }
		public string refCTe { get; set; }
		public RefNF RefNF { get; private set; }
		public RefNFP RefNFP { get; private set; }
		public RefECF RefECF { get; private set; }
	}
}