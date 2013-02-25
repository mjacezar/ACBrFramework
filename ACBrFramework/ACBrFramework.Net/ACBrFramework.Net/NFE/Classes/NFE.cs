using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class NFE : ACBrComposedComponent
	{
		#region Fields
		#endregion Fields

		#region Constructor

		internal NFE(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{

		}

		#endregion Constructor

		#region Properties

		private new ACBrNFE Parent
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
