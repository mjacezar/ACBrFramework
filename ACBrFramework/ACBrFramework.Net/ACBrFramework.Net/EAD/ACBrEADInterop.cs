using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework
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

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_GetChavePrivada(IntPtr eadHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_SetChavePrivada(IntPtr eadHandle, string chave);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_GetChavePublica(IntPtr eadHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_SetChavePublica(IntPtr eadHandle, string chave);

		#endregion Propriedades do Componente

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_Create(ref IntPtr eadHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_Destroy(ref IntPtr eadHandle);

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
		public static extern int EAD_GerarXMLeECFc_NP(IntPtr eadHandle, String NomeSH);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_ConverteXMLeECFcParaOpenSSL(IntPtr eadHandle, String Arquivo, StringBuilder Hash, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_CalcularHashArquivo(IntPtr eadHandle, String Arquivo, int HashType, StringBuilder Hash, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_CalcularEADArquivo(IntPtr eadHandle, String Arquivo, StringBuilder EAD, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_AssinarArquivoComEAD(IntPtr eadHandle, String Arquivo, bool Remove, StringBuilder EAD, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_VerificarEADArquivo(IntPtr eadHandle, String Arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_SetOnGetChavePublica(IntPtr eadHandle, [MarshalAs(UnmanagedType.FunctionPtr)] Delegate method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int EAD_SetOnGetChavePrivada(IntPtr eadHandle, [MarshalAs(UnmanagedType.FunctionPtr)] Delegate method);

		#endregion Methods

		#endregion ACBrEAD
	}
}