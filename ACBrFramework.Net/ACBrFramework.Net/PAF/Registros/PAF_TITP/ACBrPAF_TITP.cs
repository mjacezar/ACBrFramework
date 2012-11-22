using System;
using System.ComponentModel;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAF_TITP : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_TITP(ACBrPAF Paf)
			: base(Paf)
		{
			this.Mercadorias = new ACBrPAFRegistroMercadorias();
		}

		#endregion Constructor

		#region Properties

        public DateTime Data { get; set; }
        public string Titulo { get; set; }

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