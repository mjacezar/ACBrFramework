using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace ACBrFramework
{
	public sealed class ACBrPAFPAF_TITP
	{
		#region Constructor

		internal ACBrPAFPAF_TITP() 
		{
			this.Mercadorias = new ACBrPAFRegistroMercadorias();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroMercadorias Mercadorias { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			Mercadorias.Clear();
		}

		#endregion Methods
	}
}
