using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("3013571E-8C5B-4045-9CD8-C1CFD2684C14")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAF_TITP : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_TITP(ACBrPAF Paf)
			: base(Paf)
		{
			Mercadorias = new ACBrPAFRegistroMercadorias();
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