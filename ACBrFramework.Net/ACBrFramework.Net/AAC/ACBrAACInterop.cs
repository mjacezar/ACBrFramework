using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.AAC
{
	public static class ACBrAACInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrACC

		#region Interop Types

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate bool AntesArquivoCallback();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void NoArgumentsCallback();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate string CryptCallback(string value);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate string OnGetChaveCallback();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void VerificarRecomporNumSerieCallback(string NumSerie, double ValorGT, ref int CRO, ref int CNI);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate double VerificarRecomporValorGTCallback(string NumSerie);


		[StructLayout(LayoutKind.Sequential)]
		public struct TECFAutorizado
		{
			[MarshalAs(UnmanagedType.R8)]
			public double ValorGT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
			public string NumeroSerie;

			[MarshalAs(UnmanagedType.I4)]
			public int CRO;

			[MarshalAs(UnmanagedType.I4)]
			public int CNI;

			[MarshalAs(UnmanagedType.R8)]
			public double DtHrAtualizado;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct TECFArquivo
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
			public string NOME_ARQUIVO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
			public string MD5;
		}

		#endregion Interop Types

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_Create(ref IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_Destroy(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_GetUltimoErro(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Propriedades do Componente

		#region Propriedades AAC

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_GetNomeArquivoAux(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetNomeArquivoAux(IntPtr aacHandle, string caminho);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_GetArqLOG(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetArqLOG(IntPtr aacHandle, string arqLog);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_GetCriarBAK(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetCriarBAK(IntPtr aacHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_GetEfetuarFlush(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetEfetuarFlush(IntPtr aacHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_GetGravarConfigApp(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetGravarConfigApp(IntPtr aacHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_GetGravarDadosPAF(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetGravarDadosPAF(IntPtr aacHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_GetGravarDadosSH(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetGravarDadosSH(IntPtr aacHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_GetGravarTodosECFs(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetGravarTodosECFs(IntPtr aacHandle, bool value);

		#endregion Propriedades AAC

		#region Identificação do PAF

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_GetNumeroLaudo(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_SetNumeroLaudo(IntPtr aacHandle, string razaoSocial);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_GetVersaoER(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_SetVersaoER(IntPtr aacHandle, string razaoSocial);

		#endregion Identificação do PAF

		#region Dados da SoftwareHouse

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_GetCNPJ(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_SetCNPJ(IntPtr aacHandle, string cnpj);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_GetRazaoSocial(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_SetRazaoSocial(IntPtr aacHandle, string razaoSocial);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_GetEndereco(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_SetEndereco(IntPtr aacHandle, string endereco);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_GetCep(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_SetCep(IntPtr aacHandle, string cep);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_GetCidade(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_SetCidade(IntPtr aacHandle, string cidade);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_GetUf(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_SetUf(IntPtr aacHandle, string uf);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_GetTelefone(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_SetTelefone(IntPtr aacHandle, string telefone);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_GetContato(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_SetContato(IntPtr aacHandle, string contato);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_GetEmail(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_SetEmail(IntPtr aacHandle, string email);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_GetIE(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_SetIE(IntPtr aacHandle, string ie);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_GetIM(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Empresa_SetIM(IntPtr aacHandle, string im);

		#endregion Dados da SoftwareHouse

		#region Dados do Aplicativo

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetNome(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetNome(IntPtr aacHandle, string nome);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetLinguagem(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetLinguagem(IntPtr aacHandle, string linguagem);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetBancoDados(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetBancoDados(IntPtr aacHandle, string banco);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetSistemaOperacional(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetSistemaOperacional(IntPtr aacHandle, string sistema);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetVersao(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetVersao(IntPtr aacHandle, string versao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_PrincipalExe_GetNome(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_PrincipalExe_SetNome(IntPtr aacHandle, string exePrincipal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_PrincipalExe_GetMD5(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_PrincipalExe_SetMD5(IntPtr aacHandle, string md5Exe);

		#endregion Dados do Aplicativo

		#region Dados de Funcionalidade

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetTipoFuncionamento(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetTipoFuncionamento(IntPtr aacHandle, int tipo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetTipoDesenvolvimento(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetTipoDesenvolvimento(IntPtr aacHandle, int tipo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetIntegracaoPafECF(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetIntegracaoPafECF(IntPtr aacHandle, int tipo);

		#endregion Dados de Funcionalidade

		#region Dados de Nao Concomitancia

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetRealizaPreVenda(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetRealizaPreVenda(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetRealizaDAVECF(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetRealizaDAVECF(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetRealizaDAVNaoFiscal(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetRealizaDAVNaoFiscal(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetRealizaDAVOS(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetRealizaDAVOS(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetDAVConfAnexoII(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetDAVConfAnexoII(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetRealizaLancamentoMesa(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetRealizaLancamentoMesa(IntPtr aacHandle, bool check);

		#endregion Dados de Nao Concomitancia

		#region Dados Aplicações Especiais

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetIndiceTecnicoProd(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetIndiceTecnicoProd(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetBarSimilarECFRestaurante(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetBarSimilarECFRestaurante(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetBarSimilarECFComum(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetBarSimilarECFComum(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetBarSimilarBalanca(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetBarSimilarBalanca(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetUsaImpressoraNaoFiscal(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetUsaImpressoraNaoFiscal(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetDAVDiscrFormula(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetDAVDiscrFormula(IntPtr aacHandle, bool check);

		#endregion Dados Aplicações Especiais

		#region Dados Criterios UF

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetTotalizaValoresLista(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetTotalizaValoresLista(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetTransfPreVenda(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetTransfPreVenda(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetTransfDAV(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetTransfDAV(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetRecompoeGT(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetRecompoeGT(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetEmitePED(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetEmitePED(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetCupomMania(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetCupomMania(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetMinasLegal(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetMinasLegal(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetParaibaLegal(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetParaibaLegal(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetNotaLegalDF(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetNotaLegalDF(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetRecompoeNumSerie(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetRecompoeNumSerie(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetTrocoEmCartao(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetTrocoEmCartao(IntPtr aacHandle, bool check);

		#endregion Dados Criterios UF

		#region Posto Combustiveis

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetAcumulaVolumeDiario(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetAcumulaVolumeDiario(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetArmazenaEncerranteIniFinal(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetArmazenaEncerranteIniFinal(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetCadastroPlacaBomba(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetCadastroPlacaBomba(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetEmiteContrEncerrAposREDZLEIX(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetEmiteContrEncerrAposREDZLEIX(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetImpedeVendaVlrZero(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetImpedeVendaVlrZero(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetIntegradoComBombas(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetIntegradoComBombas(IntPtr aacHandle, bool check);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetCriaAbastDivergEncerrante(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetCriaAbastDivergEncerrante(IntPtr aacHandle, bool check);

		#endregion Posto Combustiveis

		#region Transporte Passageiros

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_GetTransportePassageiro(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_Paf_SetTransportePassageiro(IntPtr aacHandle, bool check);

		#endregion Transporte Passageiros

		#region Dados Parametros

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_GetParams(IntPtr aacHandle, StringBuilder buffer, int bufferLen, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_GetParamsCount(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetParams(IntPtr aacHandle, string[] parametros, int count);

		#endregion Dados Parametros

		#region ECFs Autorizadas

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_ECFsAutorizados_Clear(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_ECFsAutorizados_New(IntPtr aacHandle, TECFAutorizado ecfAutorizado);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_ECFsAutorizados_Get(IntPtr aacHandle, ref TECFAutorizado retAutorizado, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_ECFsAutorizados_Count(IntPtr aacHandle);

		#endregion ECFs Autorizadas

		#region Outros Arquivos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_OutrosArquivos_Clear(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_OutrosArquivos_New(IntPtr aacHandle, TECFArquivo ecfArquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_OutrosArquivos_Get(IntPtr aacHandle, ref TECFArquivo ecfArquivo, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_OutrosArquivos_Count(IntPtr aacHandle);

		#endregion Outros Arquivos

		#region ArquivoListaAutenticados

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_ArquivoListaAutenticados_GetNome(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_ArquivoListaAutenticados_SetNome(IntPtr aacHandle, string buffer);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_ArquivoListaAutenticados_GetMD5(IntPtr aacHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_IdentPaf_ArquivoListaAutenticados_SetMD5(IntPtr aacHandle, string buffer);

		#endregion ArquivoListaAutenticados

		#endregion Propriedades do Componente

		#region Métodos do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_AbrirArquivo(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SalvarArquivo(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_VerificaReCarregarArquivo(IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_VerificarGTECF(IntPtr aacHandle, string numSerie, ref double grandeTotal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_AtualizarValorGT(IntPtr aacHandle, string numSerie, double grandeTotal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_AchaECF(IntPtr aacHandle, string numSerie, ref TECFAutorizado ECF);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_AchaIndiceECF(IntPtr aacHandle, string numSerie, ref int indice);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_AtualizarMD5(IntPtr aacHandle, string md5);

		#endregion Métodos do Componente

		#region Events

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetOnAntesAbrirArquivo(IntPtr aacHandle, [MarshalAs(UnmanagedType.FunctionPtr)] AntesArquivoCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetAntesGravarArquivo(IntPtr aacHandle, [MarshalAs(UnmanagedType.FunctionPtr)] AntesArquivoCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetOnCrypt(IntPtr aacHandle, [MarshalAs(UnmanagedType.FunctionPtr)] CryptCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetOnDeCrypt(IntPtr aacHandle, [MarshalAs(UnmanagedType.FunctionPtr)] CryptCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetOnDepoisAbrirArquivo(IntPtr aacHandle, [MarshalAs(UnmanagedType.FunctionPtr)] NoArgumentsCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetOnDepoisGravarArquivo(IntPtr aacHandle, [MarshalAs(UnmanagedType.FunctionPtr)] NoArgumentsCallback method);
		
		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetOnGetChave(IntPtr aacHandle, [MarshalAs(UnmanagedType.FunctionPtr)] OnGetChaveCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetVerificarRecomporNumSerie(IntPtr aacHandle, [MarshalAs(UnmanagedType.FunctionPtr)] VerificarRecomporNumSerieCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int AAC_SetVerificarRecomporValor(IntPtr aacHandle, [MarshalAs(UnmanagedType.FunctionPtr)] VerificarRecomporValorGTCallback method);


		#endregion Events

		#endregion ACBrACC
	}
}