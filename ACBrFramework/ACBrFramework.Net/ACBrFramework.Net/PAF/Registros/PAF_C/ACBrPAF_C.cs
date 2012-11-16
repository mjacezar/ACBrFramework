using System;
using System.ComponentModel;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAF_C : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_C(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroC1 = new ACBrPAFRegistroC1();
			this.RegistroC2 = new ACBrPAFRegistrosC2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroC1 RegistroC1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosC2 RegistroC2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroC1 = null;
			RegistroC1 = new ACBrPAFRegistroC1();
			RegistroC2.Clear();
		}

		#endregion Methods
	}
}