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
    [Guid("1971A11B-0DE3-46B9-A38D-3446AA238552")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

    public sealed class ACBrPAFRegistroN3
    {
        #region Properties

        public string NOME_ARQUIVO { get; set; }

        public string MD5 { get; set; }

        #endregion Properties
    }
}