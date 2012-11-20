using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.SPEDFiscal
{
    class ACBrSPEDFiscalInterop
    {
        #region DLL

#if x86
        private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

        #endregion DLL

        #region ACBrSPEDFiscal

        #region Constructors/Erro Handler

        [DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SPDF_Create(ref IntPtr cnieeHandle);

        [DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SPDF_Destroy(ref IntPtr cnieeHandle);

        [DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SPDF_GetUltimoErro(IntPtr cnieeHandle, StringBuilder buffer, int bufferLen);

        #endregion Constructors/Erro Handler

        #endregion ACBrSPEDFiscal
    }
}
