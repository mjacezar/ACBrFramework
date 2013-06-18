using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("45802471-7AFE-4B99-9325-EC357B0CD978")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAF_P : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_P(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroP1 = new ACBrPAFRegistroP1();
			this.RegistroP2 = new ACBrPAFRegistrosP2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistroP1 RegistroP1 { get; private set; }

		[Browsable(true)]
		public ACBrPAFRegistrosP2 RegistroP2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroP1 = null;
			RegistroP1 = new ACBrPAFRegistroP1();
			RegistroP2.Clear();
		}

		#endregion Methods
	}
}