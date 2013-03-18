using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class DetCollectionItem : ACBrComposedComponent
	{
		#region Constructor

		internal DetCollectionItem(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
			Prod = new Prod(parent, composedHandle);
		}

		#endregion Constructor

		#region Propriedades

		public Prod Prod { get; private set; }

		#endregion Propriedades
	}
}