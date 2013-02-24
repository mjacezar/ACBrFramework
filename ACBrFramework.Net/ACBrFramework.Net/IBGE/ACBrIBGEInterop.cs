using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.IBGE
{
	public static class ACBrIBGEInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrIBGE

		#region InnerTypes

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void OnBuscaEfetuadaCallback();

		[StructLayout(LayoutKind.Sequential)]
		public struct CidadeRec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
			public string Municipio;

			[MarshalAs(UnmanagedType.I4)]
			public int CodMunicio;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;

			[MarshalAs(UnmanagedType.I4)]
			public int CodUF;

			[MarshalAs(UnmanagedType.R8)]
			public double Area;
		}

		#endregion InnerTypes

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int IBGE_Create(ref IntPtr ibgeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int IBGE_Destroy(IntPtr ibgeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int IBGE_GetUltimoErro(IntPtr ibgeHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Metodos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int IBGE_BuscarPorCodigo(IntPtr ibgeHandle, int codigo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int IBGE_BuscarPorNome(IntPtr ibgeHandle, string cidade);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int IBGE_Cidades_GetCount(IntPtr ibgeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int IBGE_Cidades_GetItem(IntPtr ibgeHandle, ref CidadeRec cidadeRec, int index);

		#endregion Metodos

		#region Eventos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int IBGE_SetOnBuscaEfetuada(IntPtr ibgeHandle, OnBuscaEfetuadaCallback method);

		#endregion Eventos

		#endregion ACBrIBGE
	}
}