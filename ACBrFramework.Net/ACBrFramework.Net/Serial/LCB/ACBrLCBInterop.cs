using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.LCB
{
	public static class ACBrLCBInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrLCB

		#region InnerTypes

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void LeCodigoCallback();

		#endregion InnerTypes

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LCB_Create(ref IntPtr lcbHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LCB_Destroy(IntPtr lcbHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LCB_GetUltimoErro(IntPtr lcbHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Ativar/Desativar

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LCB_Ativar(IntPtr lcbHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LCB_Desativar(IntPtr lcbHandle);

		#endregion Ativar/Desativar

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LCB_GetPorta(IntPtr lcbHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LCB_SetPorta(IntPtr lcbHandle, string porta);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LCB_GetAtivo(IntPtr lcbHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LCB_GetUltimoCodigo(IntPtr lcbHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LCB_GetUltimaLeitura(IntPtr lcbHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LCB_LerString(IntPtr lcbHandle, StringBuilder buffer, int bufferLen);

		#endregion Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LCB_SetOnLeCodigo(IntPtr lcbHandle, LeCodigoCallback method);

		#endregion ACBrLCB
	}
}