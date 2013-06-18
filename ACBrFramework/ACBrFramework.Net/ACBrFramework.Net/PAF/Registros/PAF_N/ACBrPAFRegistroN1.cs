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
    [Guid("67C8C5C9-80F1-4627-99ED-4B8C5B46A985")]
    [ComSourceInterfaces(typeof(IACBrPAFEvents))]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM Interop Attributes

    public sealed class ACBrPAFRegistroN1
    {

        #region Properties

        public string RazaoSocial { get; set; }

        public string UF { get; set; }

        public string CNPJ { get; set; }

        public string IE { get; set; }

        public string IM { get; set; }

        #endregion Properties
    }
}