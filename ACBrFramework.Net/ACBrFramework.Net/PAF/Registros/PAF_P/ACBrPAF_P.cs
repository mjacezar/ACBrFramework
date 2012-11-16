using System;
using System.ComponentModel;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAF_P : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_P(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroP1 = new ACBrPAFRegistroP1();
			this.RegistroP2 = new ACBrPAFRegistrosP2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroP1 RegistroP1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosP2 RegistroP2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroP1 = null;
			RegistroP1 = new ACBrPAFRegistroP1();
			RegistroP2.Clear();
		}

		#endregion Methods
	}
}