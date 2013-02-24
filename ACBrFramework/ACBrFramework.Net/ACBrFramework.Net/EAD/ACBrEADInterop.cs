using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.EAD
{
	public static class ACBrEADInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrEAD

		#region Interop Types

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate string OnGetChavePublicaCallback();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate string OnGetChavePrivadaCallback();

		#endregion Interop Types

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_GetOpenSSL_Version(IntPtr eadHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_GetAbout(IntPtr eadHandle, StringBuilder buffer, int bufferLen);

		#endregion Propriedades do Componente

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_Create(ref IntPtr eadHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_Destroy(IntPtr eadHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_GetUltimoErro(IntPtr eadHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Methods

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_GerarChaves(IntPtr eadHandle, StringBuilder ChavePUB, StringBuilder ChavePRI, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_CalcularModuloeExpoente(IntPtr eadHandle, StringBuilder Modulo, StringBuilder Expoente, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_CalcularChavePublica(IntPtr eadHandle, StringBuilder ChavePUB, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_GerarXMLeECFc(IntPtr eadHandle, String NomeSH, String PathArquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_ConverteXMLeECFcParaOpenSSL(IntPtr eadHandle, String Arquivo, StringBuilder Hash, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_CalcularHashArquivo(IntPtr eadHandle, String Arquivo, int HashType, StringBuilder Hash, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_CalcularHash(IntPtr eadHandle, String AString, int HashType, StringBuilder Hash, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_CalcularEADArquivo(IntPtr eadHandle, String Arquivo, StringBuilder EAD, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_CalcularEAD(IntPtr eadHandle, String[] EString, StringBuilder EAD, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_AssinarArquivoComEAD(IntPtr eadHandle, String Arquivo, bool Remove, StringBuilder EAD, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_VerificarEADArquivo(IntPtr eadHandle, String Arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_VerificarEAD(IntPtr eadHandle, String ead);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_RemoveEADArquivo(IntPtr eadHandle, String Arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_SetOnGetChavePublica(IntPtr eadHandle, [MarshalAs(UnmanagedType.FunctionPtr)] Delegate method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_SetOnGetChavePrivada(IntPtr eadHandle, [MarshalAs(UnmanagedType.FunctionPtr)] Delegate method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_MD5FromFile(IntPtr eadHandle, String Arquivo, StringBuilder MD5, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_MD5FromString(IntPtr eadHandle, String AString, StringBuilder MD5, int bufferLen);

		#endregion Methods

		#endregion ACBrEAD
	}
}