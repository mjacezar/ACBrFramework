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
		public static extern int SMS_Destroy(IntPtr smsHandle);

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

		#region ACBrSMSMensagem

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSG_Create(ref IntPtr msgHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSG_Destroy(IntPtr msgHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSG_GetUltimoErro(IntPtr msgHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSG_GetMensagem(IntPtr msgHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSG_SetMensagem(IntPtr msgHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSG_GetTelefone(IntPtr msgHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSG_SetTelefone(IntPtr msgHandle, string value);

		#endregion ACBrSMSMensagem

		#region ACBrSMSMensagems

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSGC_Create(ref IntPtr msgcHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSGC_Destroy(IntPtr msgcHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSGC_GetUltimoErro(IntPtr msgcHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSGC_Add(IntPtr msgcHandle, IntPtr msgHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSGC_Remove(IntPtr msgcHandle, IntPtr msgHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSGC_Clear(IntPtr msgcHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSGC_LoadFromFrile(IntPtr msgcHandle, string arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SMS_MSGC_GetMSG(IntPtr msgcHandle, IntPtr msgHandle, int index);
		
		#endregion ACBrSMSMensagems

		#endregion ACBrSMS
	}
}