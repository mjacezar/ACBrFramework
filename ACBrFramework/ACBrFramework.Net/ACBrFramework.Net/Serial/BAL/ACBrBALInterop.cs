using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.BAL
{
	public static class ACBrBALInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrBal

		#region InteropTypes

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void LePesoCallback(double value);

		#endregion InteropTypes

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_Create(ref IntPtr balHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_Destroy(IntPtr balHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_GetUltimoErro(IntPtr balHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Ativar/Desativar

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_Ativar(IntPtr balHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_Desativar(IntPtr balHandle);

		#endregion Ativar/Desativar

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_GetModelo(IntPtr balHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_SetModelo(IntPtr balHandle, int modelo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_GetModeloStr(IntPtr balHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_GetPorta(IntPtr balHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_SetPorta(IntPtr balHandle, string porta);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_GetAtivo(IntPtr balHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_GetUltimoPesoLido(IntPtr balHandle, ref double peso);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_GetUltimaResposta(IntPtr balHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_LePeso(IntPtr balHandle, int timeout, ref double peso);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_GetMonitoraBalanca(IntPtr balHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_SetMonitoraBalanca(IntPtr balHandle, bool monitora);

		#endregion Propriedades do Componente

		#region Eventos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int BAL_SetOnLePeso(IntPtr balHandle, [MarshalAs(UnmanagedType.FunctionPtr)] Delegate method);

		#endregion Eventos

		#endregion ACBrBal
	}
}