using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.CEP
{
	public static class ACBrCEPInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrCEP

		#region Interop Types

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void NoArgumentCallback();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate string AntesAbrirHTTPCallback(string url);

		#endregion Interop Types

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_GetChaveAcesso(IntPtr cepHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_SetChaveAcesso(IntPtr cepHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_GetURL(IntPtr cepHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_GetWebService(IntPtr cepHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_SetWebService(IntPtr cepHandle, int value);
		
		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_GetProxyUser(IntPtr cepHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_SetProxyUser(IntPtr cepHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_GetProxyPass(IntPtr cepHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_SetProxyPass(IntPtr cepHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_GetProxyHost(IntPtr cepHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_SetProxyHost(IntPtr cepHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_GetProxyPort(IntPtr cepHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_SetProxyPort(IntPtr cepHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_GetParseText(IntPtr cepHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_SetParseText(IntPtr cepHandle, bool value);

		#endregion Propriedades do Componente

		#region Endereços

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_GetEnderecos(IntPtr cepHandle, out IntPtr endsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Enderecos_GetCount(IntPtr cepHandle, IntPtr endsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Enderecos_GetItem(IntPtr cepHandle, IntPtr endsHandle, int index, out IntPtr endHandle);

		#endregion Endereços

		#region Endereço

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_GetCEP(IntPtr cepHandle, IntPtr endHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_SetCEP(IntPtr cepHandle, IntPtr endHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_GetBairro(IntPtr cepHandle, IntPtr endHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_SetBairro(IntPtr cepHandle, IntPtr endHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_GetComplemento(IntPtr cepHandle, IntPtr endHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_SetComplemento(IntPtr cepHandle, IntPtr endHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_GetTipo_Logradouro(IntPtr cepHandle, IntPtr endHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_SetTipo_Logradouro(IntPtr cepHandle, IntPtr endHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_GetLogradouro(IntPtr cepHandle, IntPtr endHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_SetLogradouro(IntPtr cepHandle, IntPtr endHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_GetMunicipio(IntPtr cepHandle, IntPtr endHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_SetMunicipio(IntPtr cepHandle, IntPtr endHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_GetUF(IntPtr cepHandle, IntPtr endHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_SetUF(IntPtr cepHandle, IntPtr endHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_GetIBGE_Municipio(IntPtr cepHandle, IntPtr endHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_SetIBGE_Municipio(IntPtr cepHandle, IntPtr endHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Endereco_GetIBGE_UF(IntPtr cepHandle, IntPtr endHandle, StringBuilder buffer, int bufferLen);

		#endregion Endereço

		#region Eventos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_SetOnBuscaEfetuada(IntPtr cepHandle, NoArgumentCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_SetOnAntesAbrirHTTP(IntPtr cepHandle, AntesAbrirHTTPCallback method);

		#endregion Eventos

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Create(ref IntPtr cepHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_Destroy(IntPtr cepHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_GetUltimoErro(IntPtr cepHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Methods

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_BuscarPorCEP(IntPtr cepHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_BuscarPorLogradouro(IntPtr cepHandle, string cidade, string tipo, string logradouro, string uf, string bairro);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CEP_LerConfiguracoesProxy(IntPtr cepHandle);
		

		#endregion Methods

		#endregion ACBrCEP
	}
}