using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.SMS
{
	public static class ACBrSMSInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrSMS

		#region InnerTypes

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void OnProgressoCallback(int AAtual, int ATotal);

		[StructLayout(LayoutKind.Sequential)]
		public struct MSGRec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
			public string Telefone;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 321)]
			public string Message;
		}

		#endregion InnerTypes

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_Create(ref IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_Destroy(ref IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetUltimoErro(IntPtr smsHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetModelo(IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_SetModelo(IntPtr smsHandle, int modelo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetAtivo(IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_SetAtivo(IntPtr smsHandle, bool ativo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetATResult(IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_SetATResult(IntPtr smsHandle, bool ativo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetQuebraMensagens(IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_SetQuebraMensagens(IntPtr smsHandle, bool quebra);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetRecebeConfirmacao(IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_SetRecebeConfirmacao(IntPtr smsHandle, bool quebra);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetATTimeOut(IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_SetATTimeOut(IntPtr smsHandle, int timeout);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetIntervaloEntreMensagens(IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_SetIntervaloEntreMensagens(IntPtr smsHandle, int intervalo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetBandejasSimCard(IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetSimCard(IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetUltimaResposta(IntPtr smsHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetUltimoComando(IntPtr smsHandle, StringBuilder buffer, int bufferLen);

		#endregion Propriedades do Componente

		#region Propriedades Não Visiveis

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetEmLinha(IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetIMEI(IntPtr smsHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetIMSI(IntPtr smsHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetOperadora(IntPtr smsHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetFabricante(IntPtr smsHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetModeloModem(IntPtr smsHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetFirmware(IntPtr smsHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetEstadoSincronismo(IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_GetNivelSinal(IntPtr smsHandle, ref double nivel);

		#endregion Propriedades Não Visiveis

		#region Metodos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_Ativar(IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_Desativar(IntPtr smsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_EnviarSMS(IntPtr smsHandle, string telefone, string menssagem, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_EnviarSMSLote(IntPtr smsHandle, IntPtr msgHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_ListarMensagens(IntPtr smsHandle, int filtro, string path);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_TrocarBandeja(IntPtr smsHandle, int sim);

		#endregion Metodos

		#region Eventos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_SetOnProgresso(IntPtr smsHandle, OnProgressoCallback method);

		#endregion Eventos

		#region ACBrSMSMensagems

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int MSG_Create(ref IntPtr msgHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int MSG_Destroy(ref IntPtr msgHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int MSG_GetUltimoErro(IntPtr msgHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int MSG_Add(IntPtr msgHandle, string telefone, string menssagem);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int MSG_LoadFromFrile(IntPtr msgHandle, string arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int MSG_GetMessage(IntPtr msgHandle, StringBuilder telefone, StringBuilder mensagem, int bufferLen, int index);

		#endregion ACBrSMSMensagems

		#endregion ACBrSMS
	}
}