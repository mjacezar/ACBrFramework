using System.ComponentModel;
#region COM_INTEROP
#if COM_INTEROP
using System.Runtime.InteropServices;
#endif
#endregion COM_INTEROP

namespace ACBrFramework.PAF
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("5CD0A673-57BD-460E-8B8E-421E62744010")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

    public sealed class ACBrPAF_U : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_U(ACBrPAF Paf)
			: base(Paf)
		{
			RegistroU1 = new ACBrPAFRegistroU1();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroU1 RegistroU1 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroU1 = null;
			RegistroU1 = new ACBrPAFRegistroU1();
		}

		#endregion Methods
	}
}