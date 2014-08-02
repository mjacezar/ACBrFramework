using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("1514DD6B-B7CE-4D6B-8FE7-6057C5803E14")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class ACBrPAF_S : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrPAF_S(ACBrPAF Paf)
			: base(Paf)
		{
			this.RegistroS2 = new ACBrPAFRegistrosS2();
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public ACBrPAFRegistrosS2 RegistroS2 { get; private set; }

		#endregion Properties

		#region Methods

		public void LimparRegistros()
		{
			RegistroS2.Clear();
		}

		#endregion Methods
	}
}