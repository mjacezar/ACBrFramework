using System.ComponentModel;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAF_B : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_B(ACBrPAF Paf)
			: base(Paf)
		{
			RegistroB1 = new ACBrPAFRegistroB1();
			RegistroB2 = new ACBrPAFRegistrosB2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroB1 RegistroB1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosB2 RegistroB2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroB1 = null;
			RegistroB1 = new ACBrPAFRegistroB1();
			RegistroB2.Clear();
		}

		#endregion Methods
	}
}