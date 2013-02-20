/**
* ACBrFramework DefExporter
* Este arquivo foi gerado automaticamente
**/



#ifndef ACBr
#define ACBr

typedef void* INTPTR;
typedef char* PCHAR;
typedef char BOOL;

#endif


#ifndef _ACBrAAC_H_
#define _ACBrAAC_H_

#ifdef __cplusplus
#define DllImport extern "C"
#else
#define DllImport extern
#endif


// Tipos de dados

typedef BOOL (*AntesArquivoCallback) (void);

typedef PCHAR (*CryptCallback) (PCHAR value);

typedef void (*NoArgumentsCallback) (void);

typedef PCHAR (*OnGetChaveCallback) (void);

typedef struct
{
	char NOME_ARQUIVO[51];
	char MD5[33];
} TECFArquivo;

typedef struct
{
	double ValorGT;
	char NumeroSerie[30];
	int CRO;
	int CNI;
	double DtHrAtualizado;
} TECFAutorizado;

typedef void (*VerificarRecomporNumSerieCallback) (PCHAR NumSerie,double ValorGT,int *CRO,int *CNI);

typedef double (*VerificarRecomporValorGTCallback) (PCHAR NumSerie);


// Funções

DllImport int AAC_AbrirArquivo(const INTPTR aacHandle);
DllImport int AAC_AchaECF(const INTPTR aacHandle, const PCHAR numSerie, TECFAutorizado* ECF);
DllImport int AAC_AchaIndiceECF(const INTPTR aacHandle, const PCHAR numSerie, int* indice);
DllImport int AAC_AtualizarMD5(const INTPTR aacHandle, const PCHAR md5);
DllImport int AAC_AtualizarValorGT(const INTPTR aacHandle, const PCHAR numSerie, const double grandeTotal);
DllImport int AAC_Create(INTPTR* aacHandle);
DllImport int AAC_Destroy(INTPTR* aacHandle);
DllImport int AAC_GetArqLOG(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_GetCriarBAK(const INTPTR aacHandle);
DllImport int AAC_GetEfetuarFlush(const INTPTR aacHandle);
DllImport int AAC_GetGravarConfigApp(const INTPTR aacHandle);
DllImport int AAC_GetGravarDadosPAF(const INTPTR aacHandle);
DllImport int AAC_GetGravarDadosSH(const INTPTR aacHandle);
DllImport int AAC_GetGravarTodosECFs(const INTPTR aacHandle);
DllImport int AAC_GetNomeArquivoAux(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_GetParams(const INTPTR aacHandle, PCHAR buffer, const int bufferLen, const int index);
DllImport int AAC_GetParamsCount(const INTPTR aacHandle);
DllImport int AAC_GetUltimoErro(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_ArquivoListaAutenticados_GetMD5(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_ArquivoListaAutenticados_GetNome(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_ArquivoListaAutenticados_SetMD5(const INTPTR aacHandle, const PCHAR buffer);
DllImport int AAC_IdentPaf_ArquivoListaAutenticados_SetNome(const INTPTR aacHandle, const PCHAR buffer);
DllImport int AAC_IdentPaf_ECFsAutorizados_Clear(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_ECFsAutorizados_Count(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_ECFsAutorizados_Get(const INTPTR aacHandle, TECFAutorizado* retAutorizado, const int index);
DllImport int AAC_IdentPaf_ECFsAutorizados_New(const INTPTR aacHandle, const TECFAutorizado ecfAutorizado);
DllImport int AAC_IdentPaf_Empresa_GetCep(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Empresa_GetCidade(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Empresa_GetCNPJ(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Empresa_GetContato(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Empresa_GetEmail(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Empresa_GetEndereco(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Empresa_GetIE(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Empresa_GetIM(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Empresa_GetRazaoSocial(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Empresa_GetTelefone(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Empresa_GetUf(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Empresa_SetCep(const INTPTR aacHandle, const PCHAR cep);
DllImport int AAC_IdentPaf_Empresa_SetCidade(const INTPTR aacHandle, const PCHAR cidade);
DllImport int AAC_IdentPaf_Empresa_SetCNPJ(const INTPTR aacHandle, const PCHAR cnpj);
DllImport int AAC_IdentPaf_Empresa_SetContato(const INTPTR aacHandle, const PCHAR contato);
DllImport int AAC_IdentPaf_Empresa_SetEmail(const INTPTR aacHandle, const PCHAR email);
DllImport int AAC_IdentPaf_Empresa_SetEndereco(const INTPTR aacHandle, const PCHAR endereco);
DllImport int AAC_IdentPaf_Empresa_SetIE(const INTPTR aacHandle, const PCHAR ie);
DllImport int AAC_IdentPaf_Empresa_SetIM(const INTPTR aacHandle, const PCHAR im);
DllImport int AAC_IdentPaf_Empresa_SetRazaoSocial(const INTPTR aacHandle, const PCHAR razaoSocial);
DllImport int AAC_IdentPaf_Empresa_SetTelefone(const INTPTR aacHandle, const PCHAR telefone);
DllImport int AAC_IdentPaf_Empresa_SetUf(const INTPTR aacHandle, const PCHAR uf);
DllImport int AAC_IdentPaf_GetNumeroLaudo(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_GetVersaoER(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_OutrosArquivos_Clear(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_OutrosArquivos_Count(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_OutrosArquivos_Get(const INTPTR aacHandle, TECFArquivo* ecfArquivo, const int index);
DllImport int AAC_IdentPaf_OutrosArquivos_New(const INTPTR aacHandle, const TECFArquivo ecfArquivo);
DllImport int AAC_IdentPaf_Paf_GetAcumulaVolumeDiario(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetArmazenaEncerranteIniFinal(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetBancoDados(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Paf_GetBarSimilarBalanca(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetBarSimilarECFComum(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetBarSimilarECFRestaurante(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetCadastroPlacaBomba(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetCriaAbastDivergEncerrante(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetCupomMania(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetDAVConfAnexoII(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetDAVDiscrFormula(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetEmiteContrEncerrAposREDZLEIX(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetEmitePED(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetImpedeVendaVlrZero(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetIndiceTecnicoProd(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetIntegracaoPafECF(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetIntegradoComBombas(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetLinguagem(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Paf_GetMinasLegal(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetNome(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Paf_GetNotaLegalDF(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetParaibaLegal(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetRealizaDAVECF(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetRealizaDAVNaoFiscal(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetRealizaDAVOS(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetRealizaLancamentoMesa(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetRealizaPreVenda(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetRecompoeGT(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetRecompoeNumSerie(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetSistemaOperacional(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Paf_GetTipoDesenvolvimento(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetTipoFuncionamento(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetTotalizaValoresLista(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetTransfDAV(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetTransfPreVenda(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetTransportePassageiro(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetTrocoEmCartao(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetUsaImpressoraNaoFiscal(const INTPTR aacHandle);
DllImport int AAC_IdentPaf_Paf_GetVersao(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Paf_PrincipalExe_GetMD5(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Paf_PrincipalExe_GetNome(const INTPTR aacHandle, PCHAR buffer, const int bufferLen);
DllImport int AAC_IdentPaf_Paf_PrincipalExe_SetMD5(const INTPTR aacHandle, const PCHAR md5Exe);
DllImport int AAC_IdentPaf_Paf_PrincipalExe_SetNome(const INTPTR aacHandle, const PCHAR exePrincipal);
DllImport int AAC_IdentPaf_Paf_SetAcumulaVolumeDiario(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetArmazenaEncerranteIniFinal(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetBancoDados(const INTPTR aacHandle, const PCHAR banco);
DllImport int AAC_IdentPaf_Paf_SetBarSimilarBalanca(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetBarSimilarECFComum(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetBarSimilarECFRestaurante(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetCadastroPlacaBomba(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetCriaAbastDivergEncerrante(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetCupomMania(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetDAVConfAnexoII(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetDAVDiscrFormula(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetEmiteContrEncerrAposREDZLEIX(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetEmitePED(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetImpedeVendaVlrZero(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetIndiceTecnicoProd(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetIntegracaoPafECF(const INTPTR aacHandle, const int tipo);
DllImport int AAC_IdentPaf_Paf_SetIntegradoComBombas(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetLinguagem(const INTPTR aacHandle, const PCHAR linguagem);
DllImport int AAC_IdentPaf_Paf_SetMinasLegal(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetNome(const INTPTR aacHandle, const PCHAR nome);
DllImport int AAC_IdentPaf_Paf_SetNotaLegalDF(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetParaibaLegal(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetRealizaDAVECF(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetRealizaDAVNaoFiscal(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetRealizaDAVOS(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetRealizaLancamentoMesa(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetRealizaPreVenda(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetRecompoeGT(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetRecompoeNumSerie(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetSistemaOperacional(const INTPTR aacHandle, const PCHAR sistema);
DllImport int AAC_IdentPaf_Paf_SetTipoDesenvolvimento(const INTPTR aacHandle, const int tipo);
DllImport int AAC_IdentPaf_Paf_SetTipoFuncionamento(const INTPTR aacHandle, const int tipo);
DllImport int AAC_IdentPaf_Paf_SetTotalizaValoresLista(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetTransfDAV(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetTransfPreVenda(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetTransportePassageiro(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetTrocoEmCartao(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetUsaImpressoraNaoFiscal(const INTPTR aacHandle, const BOOL check);
DllImport int AAC_IdentPaf_Paf_SetVersao(const INTPTR aacHandle, const PCHAR versao);
DllImport int AAC_IdentPaf_SetNumeroLaudo(const INTPTR aacHandle, const PCHAR razaoSocial);
DllImport int AAC_IdentPaf_SetVersaoER(const INTPTR aacHandle, const PCHAR razaoSocial);
DllImport int AAC_SalvarArquivo(const INTPTR aacHandle);
DllImport int AAC_SetAntesGravarArquivo(const INTPTR aacHandle, const AntesArquivoCallback method);
DllImport int AAC_SetArqLOG(const INTPTR aacHandle, const PCHAR arqLog);
DllImport int AAC_SetCriarBAK(const INTPTR aacHandle, const BOOL value);
DllImport int AAC_SetEfetuarFlush(const INTPTR aacHandle, const BOOL value);
DllImport int AAC_SetGravarConfigApp(const INTPTR aacHandle, const BOOL value);
DllImport int AAC_SetGravarDadosPAF(const INTPTR aacHandle, const BOOL value);
DllImport int AAC_SetGravarDadosSH(const INTPTR aacHandle, const BOOL value);
DllImport int AAC_SetGravarTodosECFs(const INTPTR aacHandle, const BOOL value);
DllImport int AAC_SetNomeArquivoAux(const INTPTR aacHandle, const PCHAR caminho);
DllImport int AAC_SetOnAntesAbrirArquivo(const INTPTR aacHandle, const AntesArquivoCallback method);
DllImport int AAC_SetOnCrypt(const INTPTR aacHandle, const CryptCallback method);
DllImport int AAC_SetOnDeCrypt(const INTPTR aacHandle, const CryptCallback method);
DllImport int AAC_SetOnDepoisAbrirArquivo(const INTPTR aacHandle, const NoArgumentsCallback method);
DllImport int AAC_SetOnDepoisGravarArquivo(const INTPTR aacHandle, const NoArgumentsCallback method);
DllImport int AAC_SetOnGetChave(const INTPTR aacHandle, const OnGetChaveCallback method);
DllImport int AAC_SetParams(const INTPTR aacHandle, const PCHAR parametros[], const int count);
DllImport int AAC_SetVerificarRecomporNumSerie(const INTPTR aacHandle, const VerificarRecomporNumSerieCallback method);
DllImport int AAC_SetVerificarRecomporValor(const INTPTR aacHandle, const VerificarRecomporValorGTCallback method);
DllImport int AAC_VerificaReCarregarArquivo(const INTPTR aacHandle);
DllImport int AAC_VerificarGTECF(const INTPTR aacHandle, const PCHAR numSerie, double* grandeTotal);


#endif
