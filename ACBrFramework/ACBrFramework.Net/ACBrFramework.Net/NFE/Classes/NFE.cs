using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ACBrFramework.NFE
{
	public class NFE
	{
		#region Constructor

		public NFE()
		{
			this.infNFe = new infNFe();
			this.Ide = new Ide();
		}

		#endregion Constructor

		#region Properties

		public virtual Schema Schema { get; set; }
		public virtual infNFe infNFe { get; private set; }
		public virtual Ide Ide { get; private set; }
		#endregion Properties

		#region Methods
		#endregion Methods
	}
}