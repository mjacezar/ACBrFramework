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

		public virtual string refNFe { get; set; }
		public virtual string refCTe { get; set; }
		public virtual RefNF RefNF { get; private set; }
		public virtual RefNFP RefNFP { get; private set; }
		public virtual RefECF RefECF { get; private set; }
	}
}