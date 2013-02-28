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
			this.Emit = new Emit(parent, composedHandle);
			this.infNFE = new infNFe(parent, composedHandle);
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

		public Schema schema
		{
			get
			{
				return (Schema)GetInt32(ACBrNFEInterop.NFE_NFe_Getschema);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Setschema, (int)value);
			}
		}

		public infNFe infNFE { get; private set; }

		public Emit Emit { get; private set; }

		#endregion Properties

		#region Methods
		#endregion Methods
	}
}
