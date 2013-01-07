using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.Validador
{
	public static class ACBrValidadorInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region InteropTypes

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void OnMsgErroCallback(string Mensagem);

		#endregion InteropTypes

		#region ACBrValidador

		#region Propriedades Visiveis do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_GetDocumento(IntPtr valHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_SetDocumento(IntPtr valHandle, string documento);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_GetComplemento(IntPtr valHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_SetComplemento(IntPtr valHandle, string complemento);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_GetIgnorarChar(IntPtr valHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_SetIgnorarChar(IntPtr valHandle, string ignorar);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_GetTipoDocto(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_SetTipoDocto(IntPtr valHandle, int doc);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_GetAjustarTamanho(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_SetAjustarTamanho(IntPtr valHandle, bool ajustar);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_GetExibeDigitoCorreto(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_SetExibeDigitoCorreto(IntPtr valHandle, bool exibe);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_GetPermiteVazio(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_SetPermiteVazio(IntPtr valHandle, bool permite);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_GetRaiseExcept(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_SetRaiseExcept(IntPtr valHandle, bool permite);

		#endregion Propriedades Visiveis do Componente

		#region Propriedades Não Visiveis do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_GetDoctoValidado(IntPtr valHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_GetMsgErro(IntPtr valHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_GetDigitoCalculado(IntPtr valHandle, StringBuilder buffer, int bufferLen);

		#endregion Propriedades Não Visiveis do Componente

		#region Modulo

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_GetDocumento(IntPtr valHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_SetDocumento(IntPtr valHandle, string documento);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_GetMultiplicadorInicial(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_SetMultiplicadorInicial(IntPtr valHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_GetMultiplicadorFinal(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_SetMultiplicadorFinal(IntPtr valHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_GetMultiplicadorAtual(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_SetMultiplicadorAtual(IntPtr valHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_GetDigitoFinal(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_GetModuloFinal(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_GetSomaDigitos(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_GetFormulaDigito(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_SetFormulaDigito(IntPtr valHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_Calcular(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Modulo_CalculoPadrao(IntPtr valHandle);

		#endregion Modulo

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Create(ref IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Destroy(ref IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_GetUltimoErro(IntPtr valHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Methods

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Validar(IntPtr valHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_Formatar(IntPtr valHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_FormatarCEP(IntPtr valHandle, string documento, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_FormatarCheque(IntPtr valHandle, string documento, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_FormatarCNPJ(IntPtr valHandle, string documento, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_FormatarCPF(IntPtr valHandle, string documento, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_FormatarIE(IntPtr valHandle, string ie, string uf, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_FormatarPIS(IntPtr valHandle, string documento, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_FormatarSUFRAMA(IntPtr valHandle, string documento, StringBuilder buffer, int bufferLen);

		#region Evento

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int VAL_SetOnMsgErro(IntPtr valHandle, OnMsgErroCallback method);

		#endregion Evento

		#endregion Methods

		#endregion ACBrValidador
	}
}