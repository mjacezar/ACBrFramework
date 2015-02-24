using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("FE794E56-6509-48EE-91A5-8963A9742FC5")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAF_T : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_T(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroT1 = new ACBrPAFRegistroT1();
			this.RegistroT2 = new ACBrPAFRegistrosT2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroT1 RegistroT1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosT2 RegistroT2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroT1 = null;
			RegistroT1 = new ACBrPAFRegistroT1();
			RegistroT2.Clear();
		}

		#endregion Methods
	}
}