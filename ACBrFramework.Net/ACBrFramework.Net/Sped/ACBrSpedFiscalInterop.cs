using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.Sped
{
	internal class ACBrSpedFiscalInterop
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
		public static extern int SPDF_Create(ref IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Destroy(ref IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetUltimoErro(IntPtr spdfHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetAbout(IntPtr spdfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetArquivo(IntPtr spdfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetArquivo(IntPtr spdfHandle, string arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetCurMascara(IntPtr spdfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetCurMascara(IntPtr spdfHandle, string mascara);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetPath(IntPtr spdfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetPath(IntPtr spdfHandle, string path);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetDelimitador(IntPtr spdfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetDelimitador(IntPtr spdfHandle, string delimitador);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetLinhasBuffer(IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetLinhasBuffer(IntPtr spdfHandle, int linhas);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetTrimString(IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetTrimString(IntPtr spdfHandle, bool trim);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetDT_INI(IntPtr spdfHandle, ref double data);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetDT_INI(IntPtr spdfHandle, double data);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetDT_FIN(IntPtr spdfHandle, ref double data);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetDT_FIN(IntPtr spdfHandle, double data);

		#endregion Propriedades do Componente

		#region Metodos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_IniciaGeracao(IntPtr spdfHandle);

		#endregion Metodos

		#endregion ACBrSPEDFiscal
	}
}