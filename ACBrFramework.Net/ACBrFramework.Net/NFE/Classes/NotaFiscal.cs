using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public class NotaFiscal : ACBrComposedComponent
	{
		#region Fields
		#endregion Fields

		#region Constructor

		internal NotaFiscal(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
			infNFe = new infNFe();
			Ide = new Ide();
		}

		#endregion Constructor

		#region Properties

		public new ACBrNFE Parent
		{
			get
			{
				return (ACBrNFE)base.Parent;
			}
		}

		public Schema Schema { get; set; }
		public infNFe infNFe { get; private set; }
		public Ide Ide { get; private set; }

		#endregion Properties

		#region Methods
		#endregion Methods
	}
}