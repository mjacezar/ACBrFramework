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
	[Guid("E17A9C6C-CC0C-43E9-9956-289E0025CB83")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class ACBrPAF_C : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_C(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroC1 = new ACBrPAFRegistroC1();
			this.RegistroC2 = new ACBrPAFRegistrosC2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroC1 RegistroC1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosC2 RegistroC2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroC1 = null;
			RegistroC1 = new ACBrPAFRegistroC1();
			RegistroC2.Clear();
		}

		#endregion Methods
	}
}