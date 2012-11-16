using System;
using System.ComponentModel;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAF_N : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_N(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroN1 = new ACBrPAFRegistroN1();
			this.RegistroN2 = new ACBrPAFRegistroN2();
			this.RegistroN3 = new ACBrPAFRegistrosN3();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroN1 RegistroN1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistroN2 RegistroN2 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosN3 RegistroN3 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroN1 = null;
			RegistroN1 = new ACBrPAFRegistroN1();
			RegistroN2 = null;
			RegistroN2 = new ACBrPAFRegistroN2();
			RegistroN3.Clear();
		}
		
		#endregion Methods
	}
}