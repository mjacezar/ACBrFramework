using System;
using System.Collections.Generic;

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

		public Schema Schema { get; set; }
		public infNFe infNFe { get; private set; }
		public Ide Ide { get; private set; }
		#endregion Properties

		#region Methods
		#endregion Methods
	}
}