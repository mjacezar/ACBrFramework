using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace ACBrFramework
{
	public sealed class ACBrPAFPAF_TITP : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAFPAF_TITP(ACBrPAF acbrPAF) 
			: base(acbrPAF) 
		{
			this.Mercadorias = new ACBrPAFRegistroMercadorias(this);
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroMercadorias Mercadorias { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			int ret = ACBrPAFInterop.PAF_TITP_LimpaRegistros(this.Handle);
			CheckResult(ret);
		}

		#endregion Methods
	}
}
