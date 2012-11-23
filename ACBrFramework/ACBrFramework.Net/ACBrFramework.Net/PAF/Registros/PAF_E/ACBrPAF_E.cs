using System.ComponentModel;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAF_E : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_E(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroE1 = new ACBrPAFRegistroE1();
			this.RegistroE2 = new ACBrPAFRegistrosE2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroE1 RegistroE1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosE2 RegistroE2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroE1 = null;
			RegistroE1 = new ACBrPAFRegistroE1();
			RegistroE2.Clear();
		}

		#endregion Methods
	}
}