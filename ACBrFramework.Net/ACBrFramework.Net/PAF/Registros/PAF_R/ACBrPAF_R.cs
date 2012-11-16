using System;
using System.ComponentModel;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAF_R : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_R(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroR1 = new ACBrPAFRegistroR1();
			this.RegistroR2 = new ACBrPAFRegistrosR2();
			this.RegistroR4 = new ACBrPAFRegistrosR4();
			this.RegistroR6 = new ACBrPAFRegistrosR6();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroR1 RegistroR1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosR2 RegistroR2 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosR4 RegistroR4 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosR6 RegistroR6 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroR1 = null;
			RegistroR1 = new ACBrPAFRegistroR1();
			RegistroR2.Clear();
			RegistroR4.Clear();
			RegistroR6.Clear();
		}

		#endregion Methods
	}
}