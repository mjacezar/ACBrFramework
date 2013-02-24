using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.CNIEE
{
	public static class ACBrCNIEEInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrCNIEE

		#region Interop Types

		[StructLayout(LayoutKind.Sequential)]
		public struct CNIEERegistroRec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Marca;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Modelo;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string Versao;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string Tipo;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
			public string MarcaDescr;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
			public string ModeloDescr;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string VersaoSB;

			[MarshalAs(UnmanagedType.I4)]
			public int QtLacreSL;

			[MarshalAs(UnmanagedType.I4)]
			public int QTLacreFab;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string MFD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string LacreMFD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 26)]
			public string AtoAprovacao;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 26)]
			public string AtoRegistro;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string FormatoNumero;
		}

		#endregion Interop Types

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_GetArquivo(IntPtr cnieeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_SetArquivo(IntPtr cnieeHandle, string arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_GetVersaoArquivo(IntPtr cnieeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_GetURLDownload(IntPtr cnieeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_SetURLDownload(IntPtr cnieeHandle, string urlDownload);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_GetProxyUser(IntPtr cnieeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_SetProxyUser(IntPtr cnieeHandle, string proxyUser);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_GetProxyPass(IntPtr cnieeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_SetProxyPass(IntPtr cnieeHandle, string proxyPass);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_GetProxyHost(IntPtr cnieeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_SetProxyHost(IntPtr cnieeHandle, string proxyHost);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_GetProxyPort(IntPtr cnieeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_SetProxyPort(IntPtr cnieeHandle, string proxyPort);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_GetParseText(IntPtr cnieeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_SetParseText(IntPtr cnieeHandle, bool parseText);

		#endregion Propriedades do Componente

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_Create(ref IntPtr cnieeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_Destroy(IntPtr cnieeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_GetUltimoErro(IntPtr cnieeHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Methods

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_LerConfiguracoesProxy(IntPtr cnieeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_DownloadTabela(IntPtr cnieeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_AbrirTabela(IntPtr cnieeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_Exportar(IntPtr cnieeHandle, string path, string delimitador, int tipo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_BuscarECF(IntPtr cnieeHandle, ref CNIEERegistroRec Registro, string marca, string modelo, string versaosb);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_GetRegistro(IntPtr cnieeHandle, ref CNIEERegistroRec Registro, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int CNIEE_GetRegistroCount(IntPtr cnieeHandle);

		#endregion Methods

		#endregion ACBrCNIEE
	}
}