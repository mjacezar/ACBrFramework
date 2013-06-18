#region COM_INTEROP
#if COM_INTEROP
using System.Runtime.InteropServices;
#endif
#endregion COM_INTEROP

namespace ACBrFramework.PAF
{
    #region COM Interop Attributes

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("CC0A4ECA-FF6B-437F-9F70-EF63E4493771")]
    [ComSourceInterfaces(typeof(IACBrPAFEvents))]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM Interop Attributes

    public sealed class ACBrPAFRegistroN2
    {
        #region Properties

        public string LAUDO { get; set; }

        public string NOME { get; set; }

        public string VERSAO { get; set; }

        #endregion Properties
    }
}