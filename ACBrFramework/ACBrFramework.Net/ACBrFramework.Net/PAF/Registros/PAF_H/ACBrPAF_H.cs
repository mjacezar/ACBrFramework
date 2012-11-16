using System;
using System.ComponentModel;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAF_H : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_H(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroH1 = new ACBrPAFRegistroH1();
			this.RegistroH2 = new ACBrPAFRegistrosH2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroH1 RegistroH1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosH2 RegistroH2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroH1 = null;
			RegistroH1 = new ACBrPAFRegistroH1();
			RegistroH2.Clear();
		}

		#endregion Methods
	}
}