using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("BE2C4130-A9A9-4905-851D-F134396893F9")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAF_R : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_R(ACBrPAF Paf)
			: base(Paf)
		{
			RegistroR1 = new ACBrPAFRegistrosR1();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistrosR1 RegistroR1 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroR1 = null;
			RegistroR1.Clear();
		}

		#endregion Methods
	}
}