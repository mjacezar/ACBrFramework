using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.DIS
{
	public static class ACBrDISInterop
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
		public delegate void AtualizaCallback(int linha, string textoVisivel);

		#endregion InteropTypes

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_Create(ref IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_Destroy(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_GetUltimoErro(IntPtr disHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Ativar/Desativar

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_Ativar(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_Desativar(IntPtr disHandle);

		#endregion Ativar/Desativar

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_GetModelo(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_SetModelo(IntPtr disHandle, int modelo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_GetModeloStr(IntPtr disHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_GetAtivo(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_GetCursor(IntPtr disHandle, out int x, out int y);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_GetLinhasCount(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_SetLinhasCount(IntPtr disHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_GetColunas(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_SetColunas(IntPtr disHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_GetAlinhamento(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_SetAlinhamento(IntPtr disHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_GetIntervalo(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_SetIntervalo(IntPtr disHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_GetPassos(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_SetPassos(IntPtr disHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_GetRemoveAcentos(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_SetRemoveAcentos(IntPtr disHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_GetIntervaloEnvioBytes(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_SetIntervaloEnvioBytes(IntPtr disHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_GetTrabalhando(IntPtr disHandle);

		#endregion Propriedades do Componente

		#region Methods

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_LimparDisplay(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_LimparLinha(IntPtr disHandle, int Linha);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_PosicionarCursor(IntPtr disHandle, int Linha, int Coluna);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_Escrever(IntPtr disHandle, string AText);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_ExibirLinha(IntPtr disHandle, int Linha, string AText);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_ExibirLinhaAlinhamento(IntPtr disHandle, int Linha, string AText, int Alinhamento);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_ExibirLinhaEfeito(IntPtr disHandle, int Linha, string AText, int Efeito);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_RolarLinha(IntPtr disHandle, int Linha, int Efeito);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_Parar(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_Continuar(IntPtr disHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_PararLinha(IntPtr disHandle, int Linha);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_ContinuarLinha(IntPtr disHandle, int Linha);

		#endregion Methods

		#region Eventos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DIS_SetOnAtualiza(IntPtr disHandle, AtualizaCallback method);

		#endregion Eventos

		#endregion ACBrBal
	}
}