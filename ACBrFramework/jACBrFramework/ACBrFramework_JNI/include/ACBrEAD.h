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


#ifndef _ACBrEAD_H_
#define _ACBrEAD_H_

#ifdef __cplusplus
#define DllImport extern "C"
#else
#define DllImport extern
#endif


// Tipos de dados

typedef PCHAR (*OnGetChavePrivadaCallback) (void);

typedef PCHAR (*OnGetChavePublicaCallback) (void);


// Funções

DllImport int EAD_AssinarArquivoComEAD(const INTPTR eadHandle, const PCHAR Arquivo, const BOOL Remove, PCHAR EAD, const int bufferLen);
DllImport int EAD_CalcularChavePublica(const INTPTR eadHandle, PCHAR ChavePUB, const int bufferLen);
DllImport int EAD_CalcularEAD(const INTPTR eadHandle, const PCHAR EString[], PCHAR EAD, const int bufferLen);
DllImport int EAD_CalcularEADArquivo(const INTPTR eadHandle, const PCHAR Arquivo, PCHAR EAD, const int bufferLen);
DllImport int EAD_CalcularHash(const INTPTR eadHandle, const PCHAR AString, const int HashType, PCHAR Hash, const int bufferLen);
DllImport int EAD_CalcularHashArquivo(const INTPTR eadHandle, const PCHAR Arquivo, const int HashType, PCHAR Hash, const int bufferLen);
DllImport int EAD_CalcularModuloeExpoente(const INTPTR eadHandle, PCHAR Modulo, PCHAR Expoente, const int bufferLen);
DllImport int EAD_ConverteXMLeECFcParaOpenSSL(const INTPTR eadHandle, const PCHAR Arquivo, PCHAR Hash, const int bufferLen);
DllImport int EAD_Create(INTPTR* eadHandle);
DllImport int EAD_Destroy(INTPTR* eadHandle);
DllImport int EAD_GerarChaves(const INTPTR eadHandle, PCHAR ChavePUB, PCHAR ChavePRI, const int bufferLen);
DllImport int EAD_GerarXMLeECFc(const INTPTR eadHandle, const PCHAR NomeSH, const PCHAR PathArquivo);
DllImport int EAD_GetAbout(const INTPTR eadHandle, PCHAR buffer, const int bufferLen);
DllImport int EAD_GetOpenSSL_Version(const INTPTR eadHandle, PCHAR buffer, const int bufferLen);
DllImport int EAD_GetUltimoErro(const INTPTR eadHandle, PCHAR buffer, const int bufferLen);
DllImport int EAD_MD5FromFile(const INTPTR eadHandle, const PCHAR Arquivo, PCHAR MD5, const int bufferLen);
DllImport int EAD_MD5FromString(const INTPTR eadHandle, const PCHAR AString, PCHAR MD5, const int bufferLen);
DllImport int EAD_RemoveEADArquivo(const INTPTR eadHandle, const PCHAR Arquivo);
DllImport int EAD_SetOnGetChavePrivada(const INTPTR eadHandle, const Delegate method);
DllImport int EAD_SetOnGetChavePublica(const INTPTR eadHandle, const Delegate method);
DllImport int EAD_VerificarEAD(const INTPTR eadHandle, const PCHAR ead);
DllImport int EAD_VerificarEADArquivo(const INTPTR eadHandle, const PCHAR Arquivo);


#endif
