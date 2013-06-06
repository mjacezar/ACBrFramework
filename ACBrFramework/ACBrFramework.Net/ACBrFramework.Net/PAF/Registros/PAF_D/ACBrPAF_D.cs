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
	[Guid("4213AA68-5C58-4DC0-A927-B0040C80466F")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP


	public sealed class ACBrPAF_D : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_D(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroD1 = new ACBrPAFRegistroD1();
			this.RegistroD2 = new ACBrPAFRegistrosD2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroD1 RegistroD1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosD2 RegistroD2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroD1 = null;
			RegistroD1 = new ACBrPAFRegistroD1();
			RegistroD2.Clear();
		}

		#endregion Methods
	}
}