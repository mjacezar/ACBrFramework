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

		#endregion Properties

		#region Methods
		#endregion Methods
	}
}