using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{

    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("FA6E9B08-3D51-4337-BB87-589B75EF5BEB")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

    public sealed class ACBrPAF_E: ACBrComposedComponent
    {
        #region Constructor

        internal ACBrPAF_E(ACBrPAF Paf)
            : base(Paf)
        {
            this.RegistroE1 = new ACBrPAFRegistroE1();
            this.RegistroE2 = new ACBrPAFRegistrosE2();
            RegistroE3 = new ACBrPAFRegistroE3();
        }

        #endregion Constructor

        #region Properties

        [Browsable(true)]
        public ACBrPAFRegistroE1 RegistroE1 { get; private set; }

        [Browsable(true)]
        public ACBrPAFRegistrosE2 RegistroE2 { get; private set; }

        [Browsable(true)]
        public ACBrPAFRegistroE3 RegistroE3 { get; private set; }

        #endregion Properties

        #region Methods

        public void LimparRegistros()
        {
            RegistroE1 = null;
            RegistroE1 = new ACBrPAFRegistroE1();
            RegistroE2.Clear();
            RegistroE3 = null;
            RegistroE3 = new ACBrPAFRegistroE3();
        }
        #endregion Methods
    }
}