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
	[Guid("0EBF3B3B-0D0D-4C34-BE1B-8878AD1EF57D")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

    public sealed class ACBrPAF_A : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_A(ACBrPAF Paf)
			: base(Paf)
		{
			RegistroA1 = new ACBrPAFRegistroA1();
			RegistroA2 = new ACBrPAFRegistrosA2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroA1 RegistroA1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosA2 RegistroA2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroA1 = null;
			RegistroA1 = new ACBrPAFRegistroA1();
			RegistroA2.Clear();
		}

		#endregion Methods
	}
}