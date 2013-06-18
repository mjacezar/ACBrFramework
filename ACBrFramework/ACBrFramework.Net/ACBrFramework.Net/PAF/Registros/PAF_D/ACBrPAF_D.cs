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
    [Guid("39420A22-B8C3-47D8-8BF5-225EA71B3B15")]
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