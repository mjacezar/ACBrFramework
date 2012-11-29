unit ACBrAACDLL;

interface

uses
  SysUtils,
  Classes,
  ACBrPAFClass,
  ACBrAAC,
  ACBrUtil,
  ACBrCommonDll;

{ Ponteiros de função }
type TGetChaveCallback = function () : PChar; cdecl;

{Classe para armazenar EventHandlers do componente }
type TEventHandlers = class
     ChaveCriptografia : String;
     OnGetChaveCallback : TGetChaveCallback;
     procedure OnGetChave(var Chave: AnsiString);
end;

{Handle para o componente TACBrAAC}
type TAACHandle = record
  UltimoErro : String;
  AAC : TACBrAAC;
  EventHandlers : TEventHandlers;
end;

{Ponteiro para o Handle }
type PAACHandle = ^TAACHandle;

{Records estilo C utilizados nos retornos das funções}

type TECFAutorizado = record
     ValorGT : double;
     Serie :  array[0..30] of char;
     CNI : integer;
     CRO : integer;
     DtHrAtualizado : double;
end;

type TECFArquivo = record
     NOME_ARQUIVO : array[0..50] of char;
     MD5          : array[0..32] of char;
end;

implementation

{%region Constructor/Destructor/Erro}
{
PADRONIZAÇÃO DAS FUNÇÕES:

        PARÂMETROS:
        Todas as funções recebem o parâmetro "handle" que é o ponteiro
        para o componente instanciado; Este ponteiro deve ser armazenado
        pela aplicação que utiliza a DLL;

        RETORNO:
        Todas as funções da biblioteca retornam um Integer com as possíveis Respostas:

                MAIOR OU IGUAL A ZERO: SUCESSO
                Outos retornos maior que zero indicam sucesso, com valor específico de cada função.

                MENOR QUE ZERO: ERROS

                  -1 : Erro ao executar;
                       Vide UltimoErro

                  -2 : ACBr não inicializado.

                  Outros retornos negativos indicam erro específico de cada função;

                  A função "UltimoErro" retornará a mensagem da última exception disparada pelo componente.
}


{
CRIA um novo componente TACBrAAC retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrAAC
}
Function AAC_Create(var aacHandle: PAACHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try
     New(aacHandle);
     aacHandle^.AAC := TACBrAAC.Create(nil);
     aacHandle^.EventHandlers := TEventHandlers.Create();
     aacHandle^.UltimoErro := '';
     Result := 0;
  except
     on exception : Exception do
     begin
        Result := -1;
        aacHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrAAC e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function AAC_Destroy(var aacHandle: PAACHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

    aacHandle^.AAC.Destroy;
    aacHandle^.AAC := nil;

    Dispose(aacHandle);
    aacHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        aacHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function AAC_GetUltimoErro(const aacHandle: PAACHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, aacHandle^.UltimoErro, BufferLen);
     Result := length(aacHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Propriedades do AAC}

Function AAC_GetArqLOG(const aacHandle: PAACHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.ArqLOG;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_SetArqLOG(const aacHandle: PAACHandle; const ArqLOG : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.ArqLOG := ArqLOG;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_GetCriarBAK(const aacHandle: PAACHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if aacHandle^.AAC.CriarBAK then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_SetCriarBAK(const aacHandle: PAACHandle; const value : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.CriarBAK := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_GetEfetuarFlush(const aacHandle: PAACHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if aacHandle^.AAC.EfetuarFlush then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_SetEfetuarFlush(const aacHandle: PAACHandle; const value : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.EfetuarFlush := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_GetGravarConfigApp(const aacHandle: PAACHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if aacHandle^.AAC.GravarConfigApp then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function AAC_SetGravarConfigApp(const aacHandle: PAACHandle; const value : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.GravarConfigApp := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function AAC_GetGravarDadosPAF(const aacHandle: PAACHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if aacHandle^.AAC.GravarDadosPAF then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function AAC_SetGravarDadosPAF(const aacHandle: PAACHandle; const value : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.GravarDadosPAF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function AAC_GetGravarDadosSH(const aacHandle: PAACHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if aacHandle^.AAC.GravarDadosSH then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function AAC_SetGravarDadosSH(const aacHandle: PAACHandle; const value : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.GravarDadosSH := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function AAC_GetGravarTodosECFs(const aacHandle: PAACHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if aacHandle^.AAC.GravarTodosECFs then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function AAC_SetGravarTodosECFs(const aacHandle: PAACHandle; const value : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.GravarTodosECFs := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function AAC_GetNomeArquivoAux(const aacHandle: PAACHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.NomeArquivoAux;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_SetNomeArquivoAux(const aacHandle: PAACHandle; const NomeArquivoAux : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.NomeArquivoAux := NomeArquivoAux;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_GetParams(const aacHandle: PAACHandle; Buffer : pChar; const BufferLen, index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.Params[Index];
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_GetParamsCount(const aacHandle: PAACHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := aacHandle^.AAC.Params.Count;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_SetParams(const aacHandle: PAACHandle; const Params : array of pChar; const count : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  i  : Integer;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.Params.Clear;
     for i := 0 to count - 1 do
     begin
        aacHandle^.AAC.Params.Add(Params[i]);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_GetChave(const aacHandle: PAACHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

 try
     StrTmp := aacHandle^.EventHandlers.ChaveCriptografia;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_SetChave(const aacHandle: PAACHandle; const Chave : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try
     if not Assigned(aacHandle^.AAC.OnGetChave) then
     begin
     aacHandle^.AAC.OnGetChave := aacHandle^.EventHandlers.OnGetChave;
     end;
     aacHandle^.EventHandlers.ChaveCriptografia := Chave;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Metodos do AAC}

Function AAC_AbrirArquivo(const aacHandle: PAACHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.AbrirArquivo;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_SalvarArquivo(const aacHandle: PAACHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;
  try
     aacHandle^.AAC.SalvarArquivo;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_VerificarGTECF(const aacHandle: PAACHandle; const NumSerie : pChar; var GrandeTotal : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;
  try
     Result := aacHandle^.AAC.VerificarGTECF(NumSerie, GrandeTotal);

     //Os retornos do método VerificarGTECF são números negativos
     //Para o ACBrDLL os retornos precisam ser positivos, caso contrário serão exceptions
     // Retornos:
     //   0 = Tudo OK
     //  -1 = NumSerie não encontrado
     //  -2 = GT não confere
     Result := Result * -1;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_AtualizarValorGT(const aacHandle: PAACHandle; const NumSerie : pChar; var GrandeTotal : Double) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;
  try
     aacHandle^.AAC.AtualizarValorGT(NumSerie, GrandeTotal);
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Dados de ECF autorizados}

Function AAC_IdentPaf_ECFsAutorizados_Clear(const aacHandle: PAACHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.ECFsAutorizados.Clear;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_ECFsAutorizados_Get(const aacHandle: PAACHandle; var retEcfAutorizado : TEcfAutorizado; const index : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  ecfAutorizado : TACBrAACECF;
begin
  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      if (index >= 0) and (index < aacHandle^.AAC.IdentPAF.ECFsAutorizados.Count) then
         begin

              ecfAutorizado := aacHandle^.AAC.IdentPAF.ECFsAutorizados[index];
              retEcfAutorizado.CNI := ecfAutorizado.CNI;
              retEcfAutorizado.CRO := ecfAutorizado.CRO;
              retEcfAutorizado.ValorGT := ecfAutorizado.ValorGT;
              retEcfAutorizado.Serie := pChar(ecfAutorizado.NumeroSerie);
              Result := 0;
      end
      else
      begin
              Result := -3;
      end;

   except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function AAC_IdentPaf_ECFsAutorizados_New(const aacHandle: PAACHandle;  const retEcfAutorizado : TEcfAutorizado) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  serie : Pchar;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     begin
          with aacHandle^.AAc.IdentPAF.ECFsAutorizados.New do
          begin
               serie := StrAlloc(30);
               StrPLCopy(serie, retEcfAutorizado.Serie, 30);
               NumeroSerie := string(serie);
               ValorGT := retEcfAutorizado.ValorGT;
               CRO := retEcfAutorizado.CRO;
               CNI := retEcfAutorizado.CNI;
               StrDispose(serie);
          end;
          Result := 0;
    end;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_ECFsAutorizados_Count(const aacHandle: PAACHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := aacHandle^.AAC.IdentPAF.ECFsAutorizados.Count;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Dados de Outros Arquivos}

Function AAC_IdentPaf_OutrosArquivos_Clear(const aacHandle: PAACHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.OutrosArquivos.Clear;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_OutrosArquivos_Get(const aacHandle: PAACHandle; var retECFArquivos :  TECFArquivo; const index : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  ecfArquivo : TACBrECFArquivo;
begin
  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
      if (index >= 0) and (index < aacHandle^.AAC.IdentPAF.OutrosArquivos.Count) then
         begin
              ecfArquivo :=  aacHandle^.AAC.IdentPAF.OutrosArquivos[index];
              retECFArquivos.NOME_ARQUIVO := pChar(ecfArquivo.Nome);
              retECFArquivos.MD5 := pChar(ecfArquivo.MD5);
              Result := 0;
      end
      else
      begin
              Result := -3;
      end;

   except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function AAC_IdentPaf_OutrosArquivos_New(const aacHandle: PAACHandle;  const ECFArquivos : TECFArquivo) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with aacHandle^.AAc.IdentPAF.OutrosArquivos.New do
     begin
        Nome := ECFArquivos.NOME_ARQUIVO;
        MD5  := ECFArquivos.MD5;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function AAC_IdentPaf_OutrosArquivos_Count(const aacHandle: PAACHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := aacHandle^.AAC.IdentPAF.OutrosArquivos.Count;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region ArquivoListaAutenticados}

Function AAC_IdentPaf_ArquivoListaAutenticados_GetNome(const aacHandle: PAACHandle; Buffer : pChar; const BufferLen : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrTmp := aacHandle^.AAC.IdentPAF.ArquivoListaAutenticados.Nome;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_ArquivoListaAutenticados_SetNome(const aacHandle: PAACHandle; const Nome : pChar ) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.ArquivoListaAutenticados.Nome := Nome;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_ArquivoListaAutenticados_GetMD5(const aacHandle: PAACHandle; Buffer : pChar; const BufferLen : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrTmp := aacHandle^.AAC.IdentPAF.ArquivoListaAutenticados.MD5;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_ArquivoListaAutenticados_SetMD5(const aacHandle: PAACHandle; const md5 : pChar ) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.ArquivoListaAutenticados.MD5 := md5;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Dados da identificação do PAF}

Function AAC_IdentPaf_GetNumeroLaudo (const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.NumeroLaudo;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_SetNumeroLaudo(const aacHandle: PaacHandle; const numLaudo : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.NumeroLaudo := numLaudo;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_GetVersaoER (const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.VersaoER;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_SetVersaoER(const aacHandle: PaacHandle; const versaoER : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.VersaoER := versaoER;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region DADOS DE NÃO CONCOMITÂNCIA}

Function AAC_IdentPaf_Paf_GetRealizaPreVenda(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.RealizaPreVenda);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetRealizaPreVenda(const aacHandle: PaacHandle; const RealizaPreVenda : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.RealizaPreVenda := RealizaPreVenda;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetRealizaDAVECF(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.RealizaDAVECF);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetRealizaDAVECF(const aacHandle: PaacHandle; const RealizaDAVECF : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.RealizaDAVECF := RealizaDAVECF;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetRealizaDAVNaoFiscal(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.RealizaDAVNaoFiscal);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetRealizaDAVNaoFiscal(const aacHandle: PaacHandle; const RealizaDAVNaoFiscal : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.RealizaDAVNaoFiscal := RealizaDAVNaoFiscal;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetRealizaDAVOS(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.RealizaDAVOS);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetRealizaDAVOS(const aacHandle: PaacHandle; const RealizaDAVOS : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.RealizaDAVOS := RealizaDAVOS;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetDAVConfAnexoII(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.DAVConfAnexoII);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetDAVConfAnexoII(const aacHandle: PaacHandle; const DAVConfAnexoII : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.DAVConfAnexoII := DAVConfAnexoII;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetRealizaLancamentoMesa(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.RealizaLancamentoMesa);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetRealizaLancamentoMesa(const aacHandle: PaacHandle; const RealizaLancamentoMesa : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.RealizaLancamentoMesa := RealizaLancamentoMesa;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region DADOS DE FUNCIONALIDADE}

Function AAC_IdentPaf_Paf_GetTipoFuncionamento(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin


  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.TipoFuncionamento);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetTipoFuncionamento(const aacHandle: PaacHandle; const TipoFuncionamento : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.TipoFuncionamento := TACBrPAFTipoFuncionamento(TipoFuncionamento);
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetTipoDesenvolvimento(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.TipoDesenvolvimento);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetTipoDesenvolvimento(const aacHandle: PaacHandle; const TipoDesenvolvimento : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.TipoDesenvolvimento := TACBrPAFTipoDesenvolvimento(TipoDesenvolvimento);
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetIntegracaoPafECF(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.IntegracaoPAFECF);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetIntegracaoPafECF(const aacHandle: PaacHandle; const IntegracaoPafECF : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.IntegracaoPAFECF := TACBrPAFTipoIntegracao(IntegracaoPafECF);
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region DADOS DO APLICATIVO}

Function AAC_IdentPaf_Paf_GetNome(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Paf.Nome;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetNome(const aacHandle: PaacHandle; const Nome : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.Nome := Nome;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetLinguagem(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Paf.Linguagem;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetLinguagem(const aacHandle: PaacHandle; const Linguagem : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.Linguagem := Linguagem;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetBancoDados(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Paf.BancoDados;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetBancoDados(const aacHandle: PaacHandle; const BancoDados : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.BancoDados := BancoDados;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetSistemaOperacional(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Paf.SistemaOperacional;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetSistemaOperacional(const aacHandle: PaacHandle; const SistemaOperacional : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.SistemaOperacional := SistemaOperacional;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetVersao(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Paf.Versao;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetVersao(const aacHandle: PaacHandle; const Versao : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.Versao := Versao;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_PrincipalExe_GetNome(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Paf.PrincipalExe.Nome;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_PrincipalExe_SetNome(const aacHandle: PaacHandle; const NomePrincipalExe : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.PrincipalExe.Nome := NomePrincipalExe;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_PrincipalExe_GetMD5(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Paf.PrincipalExe.MD5;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_PrincipalExe_SetMD5(const aacHandle: PaacHandle; const MD5 : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.PrincipalExe.MD5 := MD5;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region DADOS DE APLICAÇÕES ESPECIAIS}

Function AAC_IdentPaf_Paf_GetIndiceTecnicoProd(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.IndiceTecnicoProd);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetIndiceTecnicoProd(const aacHandle: PaacHandle; const IndiceTecnicoProd : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.IndiceTecnicoProd := IndiceTecnicoProd;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetBarSimilarECFRestaurante(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.BarSimilarECFRestaurante);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetBarSimilarECFRestaurante(const aacHandle: PaacHandle; const BarSimilarECFRestaurante : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.BarSimilarECFRestaurante := BarSimilarECFRestaurante;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetBarSimilarECFComum(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.BarSimilarECFComum);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetBarSimilarECFComum(const aacHandle: PaacHandle; const BarSimilarECFComum : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.BarSimilarECFComum := BarSimilarECFComum;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetBarSimilarBalanca(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.BarSimilarBalanca);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetBarSimilarBalanca(const aacHandle: PaacHandle; const BarSimilarBalanca : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.BarSimilarBalanca := BarSimilarBalanca;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetUsaImpressoraNaoFiscal(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.UsaImpressoraNaoFiscal);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetUsaImpressoraNaoFiscal(const aacHandle: PaacHandle; const UsaImpressoraNaoFiscal : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.UsaImpressoraNaoFiscal := UsaImpressoraNaoFiscal;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetDAVDiscrFormula(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.DAVDiscrFormula);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetDAVDiscrFormula(const aacHandle: PaacHandle; const DAVDiscrFormula : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.DAVDiscrFormula := DAVDiscrFormula;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region CRITÉRIOS POR UF }

Function AAC_IdentPaf_Paf_GetTotalizaValoresLista(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.TotalizaValoresLista);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetTotalizaValoresLista(const aacHandle: PaacHandle; const TotalizaValoresLista : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.TotalizaValoresLista := TotalizaValoresLista;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetTransfPreVenda(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.TransfPreVenda);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetTransfPreVenda(const aacHandle: PaacHandle; const TransfPreVenda : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.TransfPreVenda := TransfPreVenda;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetTransfDAV(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.TransfDAV);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetTransfDAV(const aacHandle: PaacHandle; const TransfDAV : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.TransfDAV := TransfDAV;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetRecompoeGT(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.RecompoeGT);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetRecompoeGT(const aacHandle: PaacHandle; const RecompoeGT : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.RecompoeGT := RecompoeGT;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetEmitePED(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.EmitePED);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetEmitePED(const aacHandle: PaacHandle; const EmitePED : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.EmitePED := EmitePED;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetCupomMania(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.CupomMania);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetCupomMania(const aacHandle: PaacHandle; const CupomMania : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.CupomMania := CupomMania;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_GetMinasLegal(const aacHandle: PaacHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(aacHandle^.AAC.IdentPAF.Paf.MinasLegal);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Paf_SetMinasLegal(const aacHandle: PaacHandle; const MinasLegal : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Paf.MinasLegal := MinasLegal;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region DADOS DA SOFTWARE HOUSE}

Function AAC_IdentPaf_Empresa_GetCNPJ(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Empresa.CNPJ;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_SetCNPJ(const aacHandle: PaacHandle; const CNPJ : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Empresa.CNPJ := CNPJ;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_GetRazaoSocial(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Empresa.RazaoSocial;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_SetRazaoSocial(const aacHandle: PaacHandle; const RazaoSocial : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Empresa.RazaoSocial := RazaoSocial;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_GetEndereco(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Empresa.Endereco;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_SetEndereco(const aacHandle: PaacHandle; const Endereco : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Empresa.Endereco := Endereco;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_GetCep(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Empresa.Cep;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_SetCep(const aacHandle: PaacHandle; const Cep : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Empresa.Cep := Cep;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_GetCidade(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Empresa.Cidade;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_SetCidade(const aacHandle: PaacHandle; const Cidade : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Empresa.Cidade := Cidade;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_GetUf(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Empresa.Uf;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_SetUf(const aacHandle: PaacHandle; const Uf : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Empresa.Uf := Uf;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_GetTelefone(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Empresa.Telefone;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_SetTelefone(const aacHandle: PaacHandle; const Telefone : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Empresa.Telefone := Telefone;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_GetContato(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Empresa.Contato;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_SetContato(const aacHandle: PaacHandle; const Contato : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Empresa.Contato := Contato;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_GetEmail(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Empresa.Email;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_SetEmail(const aacHandle: PaacHandle; const Email : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Empresa.Email := Email;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_GetIE(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Empresa.IE;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_SetIE(const aacHandle: PaacHandle; const IE : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Empresa.IE := IE;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_GetIM(const aacHandle: PaacHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := aacHandle^.AAC.IdentPAF.Empresa.IM;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function AAC_IdentPaf_Empresa_SetIM(const aacHandle: PaacHandle; const IM : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     aacHandle^.AAC.IdentPAF.Empresa.IM := IM;
     Result := 0;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Eventos}

procedure TEventHandlers.OnGetChave(var Chave: AnsiString);
begin
  if (Length(ChaveCriptografia) > 0) then
   Chave :=  ChaveCriptografia
  else
    Chave:= OnGetChaveCallback();
end;

Function AAC_SetOnGetChave(const aacHandle: PAACHandle; const method : TGetChaveCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (aacHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if Assigned(method) then
     begin
     aacHandle^.AAC.OnGetChave := aacHandle^.EventHandlers.OnGetChave;
     aacHandle^.EventHandlers.OnGetChaveCallback := method;
     Result := 0;
     end
     else
     begin
        aacHandle^.AAC.OnGetChave := nil;
        aacHandle^.EventHandlers.OnGetChaveCallback := nil;
        Result := 0;
     end;
  except
     on exception : Exception do
     begin
        aacHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

exports

{ Funções }
AAC_Create,
AAC_Destroy,
AAC_GetUltimoErro,

{ Propriedades do Componente }

AAC_GetNomeArquivoAux, AAC_SetNomeArquivoAux,
AAC_AtualizarValorGT, AAC_VerificarGTECF,
AAC_GetParams, AAC_SetParams, AAC_GetParamsCount,
AAC_GetChave,AAC_SetChave,
AAC_GetArqLOG, AAC_SetArqLOG,

AAC_GetCriarBAK, AAC_SetCriarBAK,
AAC_GetEfetuarFlush, AAC_SetEfetuarFlush,
AAC_GetGravarConfigApp, AAC_SetGravarConfigApp,
AAC_GetGravarDadosPAF, AAC_SetGravarDadosPAF,
AAC_GetGravarDadosSH, AAC_SetGravarDadosSH,
AAC_GetGravarTodosECFs, AAC_SetGravarTodosECFs,

AAC_IdentPaf_GetNumeroLaudo, AAC_IdentPaf_SetNumeroLaudo,
AAC_IdentPaf_GetVersaoER, AAC_IdentPaf_SetVersaoER,

AAC_IdentPaf_Paf_GetRealizaPreVenda,AAC_IdentPaf_Paf_SetRealizaPreVenda,
AAC_IdentPaf_Paf_GetRealizaDAVECF,AAC_IdentPaf_Paf_SetRealizaDAVECF,
AAC_IdentPaf_Paf_GetRealizaDAVNaoFiscal,AAC_IdentPaf_Paf_SetRealizaDAVNaoFiscal,
AAC_IdentPaf_Paf_GetRealizaDAVOS,AAC_IdentPaf_Paf_SetRealizaDAVOS,
AAC_IdentPaf_Paf_GetDAVConfAnexoII,AAC_IdentPaf_Paf_SetDAVConfAnexoII,
AAC_IdentPaf_Paf_GetRealizaLancamentoMesa,AAC_IdentPaf_Paf_SetRealizaLancamentoMesa,

//funcionalidades
AAC_IdentPaf_Paf_GetTipoFuncionamento,AAC_IdentPaf_Paf_SetTipoFuncionamento,
AAC_IdentPaf_Paf_GetTipoDesenvolvimento,AAC_IdentPaf_Paf_SetTipoDesenvolvimento,
AAC_IdentPaf_Paf_GetIntegracaoPafECF,AAC_IdentPaf_Paf_SetIntegracaoPafECF,
//software house
AAC_IdentPaf_Empresa_GetCNPJ, AAC_IdentPaf_Empresa_SetCNPJ,
AAC_IdentPaf_Empresa_GetRazaoSocial,AAC_IdentPaf_Empresa_SetRazaoSocial,
AAC_IdentPaf_Empresa_GetEndereco,AAC_IdentPaf_Empresa_SetEndereco,
AAC_IdentPaf_Empresa_GetCep,AAC_IdentPaf_Empresa_SetCep,
AAC_IdentPaf_Empresa_GetCidade,AAC_IdentPaf_Empresa_SetCidade,
AAC_IdentPaf_Empresa_GetUf,AAC_IdentPaf_Empresa_SetUf,
AAC_IdentPaf_Empresa_GetTelefone,AAC_IdentPaf_Empresa_SetTelefone,
AAC_IdentPaf_Empresa_GetContato,AAC_IdentPaf_Empresa_SetContato,
AAC_IdentPaf_Empresa_GetEmail,AAC_IdentPaf_Empresa_SetEmail,
AAC_IdentPaf_Empresa_GetIE,AAC_IdentPaf_Empresa_SetIE,
AAC_IdentPaf_Empresa_GetIM,AAC_IdentPaf_Empresa_SetIM,
//aplicativo
AAC_IdentPaf_Paf_GetNome,AAC_IdentPaf_Paf_SetNome,
AAC_IdentPaf_Paf_GetLinguagem,AAC_IdentPaf_Paf_SetLinguagem,
AAC_IdentPaf_Paf_GetBancoDados, AAC_IdentPaf_Paf_SetBancoDados,
AAC_IdentPaf_Paf_GetSistemaOperacional,AAC_IdentPaf_Paf_SetSistemaOperacional,
AAC_IdentPaf_Paf_GetVersao, AAC_IdentPaf_Paf_SetVersao,
AAC_IdentPaf_Paf_PrincipalExe_GetNome,AAC_IdentPaf_Paf_PrincipalExe_SetNome,
AAC_IdentPaf_Paf_PrincipalExe_GetMD5,AAC_IdentPaf_Paf_PrincipalExe_SetMD5,
//especiais
AAC_IdentPaf_Paf_GetIndiceTecnicoProd,AAC_IdentPaf_Paf_SetIndiceTecnicoProd,
AAC_IdentPaf_Paf_GetBarSimilarECFRestaurante,AAC_IdentPaf_Paf_SetBarSimilarECFRestaurante,
AAC_IdentPaf_Paf_GetBarSimilarECFComum,AAC_IdentPaf_Paf_SetBarSimilarECFComum,
AAC_IdentPaf_Paf_GetBarSimilarBalanca,AAC_IdentPaf_Paf_SetBarSimilarBalanca,
AAC_IdentPaf_Paf_GetUsaImpressoraNaoFiscal,AAC_IdentPaf_Paf_SetUsaImpressoraNaoFiscal,
AAC_IdentPaf_Paf_GetDAVDiscrFormula,AAC_IdentPaf_Paf_SetDAVDiscrFormula,
//criterios por uf
AAC_IdentPaf_Paf_GetTotalizaValoresLista,AAC_IdentPaf_Paf_SetTotalizaValoresLista,
AAC_IdentPaf_Paf_GetTransfPreVenda,AAC_IdentPaf_Paf_SetTransfPreVenda,
AAC_IdentPaf_Paf_GetTransfDAV,AAC_IdentPaf_Paf_SetTransfDAV,
AAC_IdentPaf_Paf_GetRecompoeGT,AAC_IdentPaf_Paf_SetRecompoeGT,
AAC_IdentPaf_Paf_GetEmitePED,AAC_IdentPaf_Paf_SetEmitePED,
AAC_IdentPaf_Paf_GetCupomMania,AAC_IdentPaf_Paf_SetCupomMania,
AAC_IdentPaf_Paf_GetMinasLegal,AAC_IdentPaf_Paf_SetMinasLegal,


{ Métodos do Componente }
AAC_AbrirArquivo,
AAC_SalvarArquivo,

{ ECFs Autorizados }
AAC_IdentPaf_ECFsAutorizados_Clear,
AAC_IdentPaf_ECFsAutorizados_New,
AAC_IdentPaf_ECFsAutorizados_Get,
AAC_IdentPaf_ECFsAutorizados_Count,

{ Outros Arquivos }
AAC_IdentPaf_OutrosArquivos_Clear,
AAC_IdentPaf_OutrosArquivos_New,
AAC_IdentPaf_OutrosArquivos_Get,
AAC_IdentPaf_OutrosArquivos_Count,

{ ArquivoListaAutenticados }
AAC_IdentPaf_ArquivoListaAutenticados_GetNome,
AAC_IdentPaf_ArquivoListaAutenticados_SetNome,
AAC_IdentPaf_ArquivoListaAutenticados_GetMD5,
AAC_IdentPaf_ArquivoListaAutenticados_SetMD5,

{Eventos}
AAC_SetOnGetChave;



end.

