unit ACBrNFe2Dll;

interface

uses
  Classes,
  ACBrNFe,
  pcnConversao,
  pcnNFe,
  ACBrNFeNotasFiscais,
  SysUtils;

type TEventHandlersNFE = class
end;

{%region Handler}

{Handle para o componente TACBrNFE}
type TNFEHandle = record
  UltimoErro : String;
  NFE : TACBrNFE;
  EventHandlers : TEventHandlersNFE;
end;

{Ponteiro para o Handle }
type PNFEHandle = ^TNFEHandle;

{%endregion}

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
CRIA um novo componente TACBrNFE retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrNFE
}
Function NFE_Create(var nfeHandle: PNFEHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try
     New(nfeHandle);
     nfeHandle^.NFE := TACBrNFE.Create(nil);
     nfeHandle^.EventHandlers := TEventHandlersNFE.Create();
     nfeHandle^.UltimoErro := '';
     Result := 0;
  except
     on exception : Exception do
     begin
        Result := -1;
        nfeHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrNFE e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function NFE_Destroy(var nfeHandle: PNFEHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

    nfeHandle^.NFE.Destroy;
    nfeHandle^.NFE := nil;

    Dispose(nfeHandle);
    nfeHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        nfeHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function NFE_GetUltimoErro(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.UltimoErro, BufferLen);
     Result := length(nfeHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Configurações }

{%region Geral}

Function NFE_CFG_Geral_GetFormaEmissao(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(nfeHandle^.NFE.Configuracoes.Geral.FormaEmissao);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Geral_SetFormaEmissao(const nfeHandle: PNFEHandle;const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Geral.FormaEmissao := TpcnTipoEmissao(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Geral_GetFormaEmissaoCodigo(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeHandle^.NFE.Configuracoes.Geral.FormaEmissaoCodigo;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Geral_GetSalvar(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfeHandle^.NFE.Configuracoes.Geral.Salvar then
     Result := 1
     else
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Geral_SetSalvar(const nfeHandle: PNFEHandle;const value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Geral.Salvar := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Geral_GetAtualizarXMLCancelado(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfeHandle^.NFE.Configuracoes.Geral.AtualizarXMLCancelado then
     Result := 1
     else
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Geral_SetAtualizarXMLCancelado(const nfeHandle: PNFEHandle;const value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Geral.AtualizarXMLCancelado := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Geral_GetPathSalvar(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.Geral.PathSalvar, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Geral_SetPathSalvar(const nfeHandle: PNFEHandle;const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Geral.PathSalvar := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Geral_GetPathSchemas(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.Geral.PathSchemas, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Geral_SetPathSchemas(const nfeHandle: PNFEHandle;const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Geral.PathSchemas := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Geral_GetIniFinXMLSECAutomatico(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfeHandle^.NFE.Configuracoes.Geral.IniFinXMLSECAutomatico then
     Result := 1
     else
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Geral_SetIniFinXMLSECAutomatico(const nfeHandle: PNFEHandle;const value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Geral.IniFinXMLSECAutomatico := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Geral_Save(const nfeHandle: PNFEHandle;const AXMLName, AXMLFile, aPath : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  ret : Boolean;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     ret := nfeHandle^.NFE.Configuracoes.Geral.Save(AXMLName, AXMLFile, aPath);
     if ret then
     Result := 1
     else
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Arquivo}

Function NFE_CFG_Arquivos_GetAdicionarLiteral(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     if (nfeHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     if nfeHandle^.NFE.Configuracoes.Arquivos.AdicionarLiteral then
     Result := 1
     else
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_SetAdicionarLiteral(const nfeHandle: PNFEHandle;const value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     if (nfeHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     nfeHandle^.NFE.Configuracoes.Arquivos.AdicionarLiteral := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_GetEmissaoPathNFe(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     if (nfeHandle = nil) then
     begin
     Result := -2;
     Exit;
     end;

     if nfeHandle^.NFE.Configuracoes.Arquivos.EmissaoPathNFe then
     Result := 1
     else
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_SetEmissaoPathNFe(const nfeHandle: PNFEHandle;const value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Arquivos.EmissaoPathNFe := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_GetSalvar(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfeHandle^.NFE.Configuracoes.Arquivos.Salvar then
     Result := 1
     else
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_SetSalvar(const nfeHandle: PNFEHandle;const value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Arquivos.Salvar := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_GetPastaMensal(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfeHandle^.NFE.Configuracoes.Arquivos.PastaMensal then
     Result := 1
     else
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_SetPastaMensal(const nfeHandle: PNFEHandle;const value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Arquivos.PastaMensal := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_GetPathNFe(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.Arquivos.PathNFe, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_SetPathNFe(const nfeHandle: PNFEHandle;const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Arquivos.PathNFe := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_GetPathCan(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.Arquivos.PathCan, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_SetPathCan(const nfeHandle: PNFEHandle;const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Arquivos.PathCan := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_GetPathInu(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.Arquivos.PathInu, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_SetPathInu(const nfeHandle: PNFEHandle;const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Arquivos.PathInu := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_GetPathDPEC(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.Arquivos.PathDPEC, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_SetPathDPEC(const nfeHandle: PNFEHandle;const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Arquivos.PathDPEC := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_GetPathCCe(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.Arquivos.PathCCe, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_SetPathCCe(const nfeHandle: PNFEHandle;const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Arquivos.PathCCe := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_GetPathMDe(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.Arquivos.PathMDe, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_SetPathMDe(const nfeHandle: PNFEHandle;const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Arquivos.PathMDe := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_GetPathEvento(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.Arquivos.PathEvento, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_SetPathEvento(const nfeHandle: PNFEHandle;const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Arquivos.PathEvento := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_FGetPathCan(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  strTemp : string;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTemp := nfeHandle^.NFE.Configuracoes.Arquivos.GetPathCan;
     StrPLCopy(Buffer, strTemp, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_FGetPathDPEC(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  strTemp : string;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTemp := nfeHandle^.NFE.Configuracoes.Arquivos.GetPathDPEC;
     StrPLCopy(Buffer, strTemp, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_FGetPathInu(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  strTemp : string;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTemp := nfeHandle^.NFE.Configuracoes.Arquivos.GetPathInu;
     StrPLCopy(Buffer, strTemp, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_FGetPathNFe(const nfeHandle: PNFEHandle;const value : Double ; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  strTemp : string;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTemp := nfeHandle^.NFE.Configuracoes.Arquivos.GetPathNFe(value);
     StrPLCopy(Buffer, strTemp, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_FGetPathCCe(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  strTemp : string;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTemp := nfeHandle^.NFE.Configuracoes.Arquivos.GetPathCCe;
     StrPLCopy(Buffer, strTemp, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_FGetPathMDe(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  strTemp : string;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTemp := nfeHandle^.NFE.Configuracoes.Arquivos.GetPathMDe;
     StrPLCopy(Buffer, strTemp, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Arquivos_FGetPathEvento(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  strTemp : string;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     strTemp := nfeHandle^.NFE.Configuracoes.Arquivos.GetPathEvento;
     StrPLCopy(Buffer, strTemp, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Certificados}

Function NFE_CFG_Certificados_GetCertificado(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.Certificados.Certificado, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Certificados_SetCertificado(const nfeHandle: PNFEHandle;const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Certificados.Certificado := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Certificados_GetSenha(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.Certificados.Senha, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_Certificados_SetSenha(const nfeHandle: PNFEHandle;const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.Certificados.Senha := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region WebServices}

Function NFE_CFG_WebServices_GetVisualizar(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfeHandle^.NFE.Configuracoes.WebServices.Visualizar then
     Result := 1
     else
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_SetVisualizar(const nfeHandle: PNFEHandle;const value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.WebServices.Visualizar := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_GetUF(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.WebServices.UF, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_SetUF(const nfeHandle: PNFEHandle;const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.WebServices.UF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_GetUFCodigo(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeHandle^.NFE.Configuracoes.WebServices.UFCodigo;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_GetAmbiente(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(nfeHandle^.NFE.Configuracoes.WebServices.Ambiente);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_SetAmbiente(const nfeHandle: PNFEHandle; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.WebServices.Ambiente := TpcnTipoAmbiente(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_GetAmbienteCodigo(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeHandle^.NFE.Configuracoes.WebServices.AmbienteCodigo;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_GetProxyHost(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.WebServices.ProxyHost, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_SetProxyHost(const nfeHandle: PNFEHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.WebServices.ProxyHost := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_GetProxyPort(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.WebServices.ProxyPort, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_SetProxyPort(const nfeHandle: PNFEHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.WebServices.ProxyPort := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_GetProxyUser(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.WebServices.ProxyUser, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_SetProxyUser(const nfeHandle: PNFEHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.WebServices.ProxyUser := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_GetProxyPass(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeHandle^.NFE.Configuracoes.WebServices.ProxyPass, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_SetProxyPass(const nfeHandle: PNFEHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.WebServices.ProxyPass := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_GetAguardarConsultaRet(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeHandle^.NFE.Configuracoes.WebServices.AguardarConsultaRet;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_SetAguardarConsultaRet(const nfeHandle: PNFEHandle;const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.WebServices.AguardarConsultaRet := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_GetTentativas(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeHandle^.NFE.Configuracoes.WebServices.Tentativas;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_SetTentativas(const nfeHandle: PNFEHandle;const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.WebServices.Tentativas := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_GetIntervaloTentativas(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeHandle^.NFE.Configuracoes.WebServices.IntervaloTentativas;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_SetIntervaloTentativas(const nfeHandle: PNFEHandle; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.WebServices.IntervaloTentativas := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

Function NFE_CFG_WebServices_GetAjustaAguardaConsultaRet(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfeHandle^.NFE.Configuracoes.WebServices.AjustaAguardaConsultaRet then
     Result := 1
     else
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_CFG_WebServices_SetAjustaAguardaConsultaRet(const nfeHandle: PNFEHandle; const value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.Configuracoes.WebServices.AjustaAguardaConsultaRet := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end
end;

{%endregion}

{%endregion}

{%region WebServices}

{%endregion}

{%region NotasFiscais }

Function NFE_NotasFiscais_Add(const nfeHandle: PNFEHandle; var nfHandle : NotaFiscal) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfHandle := nfeHandle^.NFE.NotasFiscais.Add;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_Insert(const nfeHandle: PNFEHandle; var nfHandle : NotaFiscal; const idx : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfHandle := nfeHandle^.NFE.NotasFiscais.Insert(idx);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_GetItem(const nfeHandle: PNFEHandle; var nfHandle : NotaFiscal; const idx : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfHandle := nfeHandle^.NFE.NotasFiscais.Items[idx];
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_SetItem(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal; const idx : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.NotasFiscais.Items[idx] := nfHandle;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_Clear(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.NotasFiscais.Clear;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_Count(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeHandle^.NFE.NotasFiscais.Count;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_Assinar(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.NotasFiscais.Assinar;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_GerarNFe(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.NotasFiscais.GerarNFe;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_Valida(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.NotasFiscais.Valida;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_ValidaAssinatura(const nfeHandle: PNFEHandle;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  MSG : String;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfeHandle^.NFE.NotasFiscais.ValidaAssinatura(MSG) then
     begin
        StrPLCopy(Buffer, MSG, BufferLen);
        Result := 1;
     end
     else
        Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_Imprimir(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.NotasFiscais.Imprimir;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_ImprimirPDF(const nfeHandle: PNFEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeHandle^.NFE.NotasFiscais.ImprimirPDF;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_GetNamePath(const nfeHandle: PNFEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var TempStr : String;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     TempStr := nfeHandle^.NFE.NotasFiscais.GetNamePath;
     StrPLCopy(Buffer, TempStr, BufferLen);
     Result := length(TempStr);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_LoadFromFile(const nfeHandle: PNFEHandle; const arquivo : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfeHandle^.NFE.NotasFiscais.LoadFromFile(arquivo) then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_LoadFromString(const nfeHandle: PNFEHandle; const xml : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfeHandle^.NFE.NotasFiscais.LoadFromString(xml) then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_SaveToFile(const nfeHandle: PNFEHandle; const arquivo : pChar; const txt : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfeHandle^.NFE.NotasFiscais.SaveToFile(arquivo, txt) then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NotasFiscais_SaveToTXT(const nfeHandle: PNFEHandle; const arquivo : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfeHandle^.NFE.NotasFiscais.SaveToTXT(arquivo) then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Nota Fiscal }

Function NFE_NF_GetNFe(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal; var nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle := nfHandle.NFe;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_GetAlertas(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfHandle.Alertas, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_SetAlertas(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfHandle.Alertas := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_GetXML(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfHandle.XML, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_SetXML(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfHandle.XML := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_GetMsg(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfHandle.Msg, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_SetMsg(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfHandle.Msg := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_GetNomeArq(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfHandle.NomeArq, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_SetNomeArq(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfHandle.NomeArq := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_GetConfirmada(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfHandle.Confirmada then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_SetConfirmada(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal; const value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfHandle.Confirmada := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_Imprimir(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfHandle.Imprimir;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_ImprimirPDF(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfHandle.ImprimirPDF;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_SaveToFile(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal; const CaminhoArquivo: pChar; const SalvaTXT : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if nfHandle.SaveToFile(CaminhoArquivo, SalvaTXT) then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NF_EnviarEmail(const nfeHandle: PNFEHandle; const nfHandle : NotaFiscal; const sSmtpHost, sSmtpPort, sSmtpUser, sSmtpPasswd, sFrom,
                                sTo, sAssunto: pChar; sMensagem : array of pChar; szMensagem: Integer;
                                SSL, EnviaPDF: Boolean; sCC: array of pChar; szCC : Integer;
                                sAnexos: array of pChar; szAnexos : Integer;
                                PedeConfirma, AguardarEnvio: Boolean; NomeRemetente: pChar;
                                TLS, UsarThread: Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  MSG : TStrings;
  CC : TStrings;
  Anexos : TStrings;
  i : Integer;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     MSG := TStrings.Create;
     for i := 0  to szMensagem - 1 do
     begin
       MSG.Add(sMensagem[i]);
     end;

     CC := TStrings.Create;
     for i := 0  to szCC - 1 do
     begin
       CC.Add(sCC[i]);
     end;

     Anexos := TStrings.Create;
     for i := 0  to szAnexos - 1 do
     begin
       Anexos.Add(sAnexos[i]);
     end;

     nfHandle.EnviarEmail(sSmtpHost, sSmtpPort, sSmtpUser, sSmtpPasswd, sFrom,
                          sTo, sAssunto, MSG, SSL, EnviaPDF, CC, Anexos,
                          PedeConfirma, AguardarEnvio, NomeRemetente,
                          TLS, UsarThread);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region NFe }

Function NFE_NFe_Getschema(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(nfeeHandle.schema);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Setschema(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.schema := Tpcnschema(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%region infNFe }

Function NFE_NFe_infNFe_GetID(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.infNFe.ID, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_infNFe_SetID(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.infNFe.ID := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_infNFe_GetVersao(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     value := Double(nfeeHandle.infNFe.Versao);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_infNFe_SetVersao(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.infNFe.Versao := Real(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_infNFe_GetVersaoStr(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.infNFe.VersaoStr, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Ide }

Function NFE_NFe_Ide_GetcUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Ide.cUF;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetcUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.cUF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GetcNF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Ide.cNF;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetcNF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.cNF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GetnatOp(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Ide.natOp, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetnatOp(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.natOp := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GetindPag(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(nfeeHandle.Ide.indPag);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetindPag(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.indPag := TpcnIndicadorPagamento(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_Getmodelo(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Ide.modelo;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_Setmodelo(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.modelo := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_Getserie(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Ide.serie;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_Setserie(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.serie := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GetnNF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Ide.nNF;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetnNF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.nNF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GetdEmi(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     value := nfeeHandle.Ide.dEmi;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetdEmi(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.dEmi := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GetdSaiEnt(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     value := nfeeHandle.Ide.dSaiEnt;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetdSaiEnt(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.dSaiEnt := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GethSaiEnt(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     value := nfeeHandle.Ide.hSaiEnt;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SethSaiEnt(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.hSaiEnt := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GettpNF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(nfeeHandle.Ide.tpNF);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SettpNF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.tpNF := TpcnTipoNFe(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GetcMunFG(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Ide.cMunFG;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetcMunFG(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.cMunFG := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GettpImp(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(nfeeHandle.Ide.tpImp);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SettpImp(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.tpImp := TpcnTipoImpressao(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GettpEmis(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(nfeeHandle.Ide.tpEmis);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SettpEmis(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.tpEmis := TpcnTipoEmissao(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GetcDV(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Ide.cDV;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetcDV(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.cDV := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GettpAmb(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(nfeeHandle.Ide.tpAmb);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SettpAmb(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.tpAmb := TpcnTipoAmbiente(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GetfinNFe(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(nfeeHandle.Ide.finNFe);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetfinNFe(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.finNFe := TpcnFinalidadeNFe(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GetprocEmi(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(nfeeHandle.Ide.procEmi);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetprocEmi(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.procEmi := TpcnProcessoEmissao(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GetverProc(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Ide.verProc, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetverProc(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.verProc := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GetdhCont(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; var value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     value := nfeeHandle.Ide.dhCont;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetdhCont(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.dhCont := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_GetxJust(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Ide.xJust, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_SetxJust(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.xJust := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%region NFref }

Function NFE_NFe_Ide_NFref_Count(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Ide.NFref.Count;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Clear(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.NFref.Clear;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Add(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; var nfrefHandle: TNFrefCollectionItem) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle := nfeeHandle.Ide.NFref.Add;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_GetItem(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; var nfrefHandle: TNFrefCollectionItem; const idx : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle := nfeeHandle.Ide.NFref.Items[idx];
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_SetItem(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; const nfrefHandle: TNFrefCollectionItem; const idx : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Ide.NFref.Items[idx] := nfrefHandle;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region NFref Item }

Function NFE_NFe_Ide_NFref_Item_GetrefCTe(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfrefHandle.refCTe, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_SetrefCTe(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.refCTe := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_GetrefNFe(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfrefHandle.refNFe, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_SetrefNFe(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.refNFe := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%region NFref Item RefNF }

Function NFE_NFe_Ide_NFref_Item_RefNF_GetAAMM(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfrefHandle.RefNF.AAMM, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNF_SetAAMM(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefNF.AAMM := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNF_GetCNPJ(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfrefHandle.RefNF.CNPJ, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNF_SetCNPJ(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefNF.CNPJ := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNF_GetcUF(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfrefHandle.RefNF.cUF;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNF_SetcUF(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefNF.cUF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNF_Getmodelo(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfrefHandle.RefNF.modelo;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNF_Setmodelo(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefNF.modelo := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNF_Getserie(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfrefHandle.RefNF.serie;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNF_Setserie(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefNF.serie := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNF_GetnNF(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfrefHandle.RefNF.nNF;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNF_SetnNF(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefNF.nNF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region NFref Item RefNFP }

Function NFE_NFe_Ide_NFref_Item_RefNFP_GetAAMM(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfrefHandle.RefNFP.AAMM, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNFP_SetAAMM(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefNFP.AAMM := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNFP_GetIE(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfrefHandle.RefNFP.IE, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNFP_SetIE(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefNFP.IE := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNFP_GetCNPJCPF(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfrefHandle.RefNFP.CNPJCPF, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNFP_SetCNPJCPF(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefNFP.CNPJCPF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNFP_GetcUF(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfrefHandle.RefNFP.cUF;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNFP_SetcUF(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefNFP.cUF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNFP_Getmodelo(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfrefHandle.RefNFP.modelo , BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNFP_Setmodelo(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefNFP.modelo := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNFP_Getserie(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfrefHandle.RefNFP.serie;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNFP_Setserie(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefNFP.serie := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNFP_GetnNF(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfrefHandle.RefNFP.nNF;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefNFP_SetnNF(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefNFP.nNF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region NFref Item RefECF }

Function NFE_NFe_Ide_NFref_Item_RefECF_Getmodelo(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(nfrefHandle.RefECF.modelo);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefECF_Setmodelo(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefECF.nNF := TpcnECFModRef(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefECF_GetnCOO(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfrefHandle.RefECF.nCOO, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefECF_SetnCOO(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefECF.nCOO := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefECF_GetnECF(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfrefHandle.RefECF.nECF, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Ide_NFref_Item_RefECF_SetnECF(const nfeHandle: PNFEHandle; const nfrefHandle: TNFrefCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfrefHandle.RefECF.nECF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%endregion}

{%endregion}

{%region Emit }

Function NFE_NFe_Emit_GetCNAE(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.CNAE, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_SetCNAE(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.CNAE := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_GetCNPJCPF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.CNPJCPF, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_SetCNPJCPF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.CNPJCPF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_GetIE(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.IE, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_SetIE(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.IE := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_GetIEST(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.IEST, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_SetIEST(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.IEST := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_GetIM(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.IM, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_SetIM(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.IM := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_GetxFant(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.xFant, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_SetxFant(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.xFant := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_GetxNome(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.xNome, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_SetxNome(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.xNome := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_GetCRT(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(nfeeHandle.Emit.CRT);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_SetCRT(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.CRT := TpcnCRT(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%region NFe Emit EnderEmit }

Function NFE_NFe_Emit_EnderEmit_GetCEP(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Emit.EnderEmit.CEP;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_SetCEP(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.EnderEmit.CEP := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_GetcMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Emit.EnderEmit.cMun;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_SetcMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.EnderEmit.cMun := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_GetcPais(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Emit.EnderEmit.cPais;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_SetcPais(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.EnderEmit.cPais := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_Getfone(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.EnderEmit.fone, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_Setfone(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.EnderEmit.fone := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_Getnro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.EnderEmit.nro, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_Setnro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.EnderEmit.nro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_GetUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.EnderEmit.UF, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_SetUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.EnderEmit.UF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_GetxBairro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.EnderEmit.xBairro, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_SetxBairro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.EnderEmit.xBairro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_GetxCpl(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.EnderEmit.xCpl, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_SetxCpl(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.EnderEmit.xCpl := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_GetxLgr(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.EnderEmit.xLgr, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_SetxLgr(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.EnderEmit.xLgr := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_GetxMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.EnderEmit.xMun, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_SetxMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.EnderEmit.xMun := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_GetxPais(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Emit.EnderEmit.xPais, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Emit_EnderEmit_SetxPais(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Emit.EnderEmit.xPais := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%endregion}

{%region Avulsa }

Function NFE_NFe_Avulsa_GetCNPJ(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Avulsa.CNPJ, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_SetCNPJ(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Avulsa.CNPJ := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_GetFone(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Avulsa.fone, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_SetFone(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Avulsa.fone := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_GetMatr(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Avulsa.matr, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_SetMatr(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Avulsa.matr := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_GetNDAR(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Avulsa.nDAR, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_SetNDAR(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Avulsa.nDAR := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_GetRepEmi(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Avulsa.repEmi, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_SetRepEmi(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Avulsa.repEmi := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_GetUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Avulsa.UF, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_SetUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Avulsa.UF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_GetVDAR(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Avulsa.vDAR, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_SetVDAR(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Avulsa.vDAR := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_GetXAgente(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Avulsa.xAgente, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_SetXAgente(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Avulsa.xAgente := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_GetXOrgao(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Avulsa.xOrgao, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_SetXOrgao(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Avulsa.xOrgao := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_GetDEmi(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; var  value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     value := nfeeHandle.Avulsa.dEmi;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_SetDEmi(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Avulsa.dEmi := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_GetDPag(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; var  value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     value := nfeeHandle.Avulsa.dPag;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Avulsa_SetDPag(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Avulsa.dPag := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Dest }

Function NFE_NFe_Dest_GetCNPJCPF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Dest.CNPJCPF, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_SetCNPJCPF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.CNPJCPF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_GetXNome(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Dest.xNome, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_SetXNome(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.xNome := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_GetIE(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Dest.IE, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_SetIE(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.IE := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_GetISUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Dest.ISUF, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_SetISUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.ISUF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_GetEmail(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Dest.Email, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_SetEmail(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.Email := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%region NFe Destt EnderEmit }

Function NFE_NFe_Dest_EnderDest_GetCEP(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Dest.EnderDest.CEP;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_SetCEP(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.EnderDest.CEP := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_GetCMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Dest.EnderDest.cMun;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_SetCMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.EnderDest.cMun := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_GetCPais(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Dest.EnderDest.cPais;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_SetCPais(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.EnderDest.cPais := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_GetFone(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Dest.EnderDest.fone, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_SetFone(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.EnderDest.fone := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_GetNro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Dest.EnderDest.nro, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_SetNro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.EnderDest.nro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_GetUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Dest.EnderDest.UF, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_SetUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.EnderDest.UF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_GetXBairro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Dest.EnderDest.xBairro, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_SetXBairro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.EnderDest.xBairro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_GetXCpl(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Dest.EnderDest.xCpl, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_SetXCpl(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.EnderDest.xCpl := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_GetXLgr(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Dest.EnderDest.xLgr, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_SetXLgr(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.EnderDest.xLgr := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_GetXMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Dest.EnderDest.xMun, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_SetXMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.EnderDest.xMun := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_GetXPais(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Dest.EnderDest.xPais, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Dest_EnderDest_SetXPais(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Dest.EnderDest.xPais := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%endregion}

{%region Retirada }

Function NFE_NFe_Retirada_GetCNPJCPF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Retirada.CNPJCPF, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_SetCNPJCPF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Retirada.CNPJCPF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_GetXLgr(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Retirada.xLgr, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_SetXLgr(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Retirada.xLgr := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_GetNro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Retirada.nro, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_SetNro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Retirada.nro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_GetXCpl(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Retirada.xCpl, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_SetXCpl(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Retirada.xCpl := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_GetXBairro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Retirada.xBairro, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_SetXBairro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Retirada.xBairro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_GetXMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Retirada.xMun, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_SetXMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Retirada.xMun := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_GetUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Retirada.UF, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_SetUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Retirada.UF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_GetCMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Retirada.cMun;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Retirada_SetCMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Retirada.cMun := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Entrega }

Function NFE_NFe_Entrega_GetCNPJCPF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Entrega.CNPJCPF, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_SetCNPJCPF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Entrega.CNPJCPF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_GetXLgr(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Entrega.xLgr, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_SetXLgr(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Entrega.xLgr := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_GetNro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Entrega.nro, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_SetNro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Entrega.nro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_GetXCpl(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Entrega.xCpl, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_SetXCpl(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Entrega.xCpl := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_GetXBairro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Entrega.xBairro, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_SetXBairro(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Entrega.xBairro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_GetXMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Entrega.xMun, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_SetXMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Entrega.xMun := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_GetUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, nfeeHandle.Entrega.UF, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_SetUF(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Entrega.UF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_GetCMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Entrega.cMun;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Entrega_SetCMun(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe;  const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Entrega.cMun := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Det }

Function NFE_NFe_Det_Add(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; var detHandle : TDetCollectionItem) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     detHandle := nfeeHandle.Det.Add;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Insert(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; var detHandle : TDetCollectionItem; const idx : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     detHandle := nfeeHandle.Det.Insert(idx);
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_GetItem(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; var detHandle : TDetCollectionItem; const idx : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     detHandle := nfeeHandle.Det.Items[idx];
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_SetItem(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe; const detHandle : TDetCollectionItem; const idx : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Det.Items[idx] := detHandle;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Clear(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     nfeeHandle.Det.Clear;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Count(const nfeHandle: PNFEHandle; const nfeeHandle : TNFe) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := nfeeHandle.Det.Count;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%region Det Item }

Function NFE_NFe_Det_Item_Prod_GetCProd(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, detHandle.Prod.cProd, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Item_Prod_SetCProd(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     detHandle.Prod.cProd := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Item_Prod_GetNItem(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := detHandle.Prod.nItem;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Item_Prod_SetNItem(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     detHandle.Prod.nItem := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Item_Prod_GetXProd(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, detHandle.Prod.xProd, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Item_Prod_SetXProd(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     detHandle.Prod.xProd := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Item_Prod_GetCEAN(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, detHandle.Prod.cEAN, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Item_Prod_SetCEAN(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     detHandle.Prod.cEAN := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Item_Prod_GetNCM(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, detHandle.Prod.NCM, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Item_Prod_SetNCM(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     detHandle.Prod.NCM := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Item_Prod_GetEXTIPI(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, detHandle.Prod.EXTIPI, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Item_Prod_SetEXTIPI(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     detHandle.Prod.EXTIPI := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Item_Prod_GetCFOP(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, detHandle.Prod.CFOP, BufferLen);
     Result := length(Buffer);
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function NFE_NFe_Det_Item_Prod_SetCFOP(const nfeHandle: PNFEHandle; const detHandle : TDetCollectionItem; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (nfeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     detHandle.Prod.CFOP := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        nfeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%endregion}

{%endregion}

exports

{ Constructor/Destructor/Erro }
NFE_Create,
NFE_Destroy,
NFE_GetUltimoErro,

{%region Configurações }

{ Geral }
NFE_CFG_Geral_GetFormaEmissao, NFE_CFG_Geral_SetFormaEmissao,
NFE_CFG_Geral_GetSalvar, NFE_CFG_Geral_SetSalvar,
NFE_CFG_Geral_GetAtualizarXMLCancelado, NFE_CFG_Geral_SetAtualizarXMLCancelado,
NFE_CFG_Geral_GetPathSalvar, NFE_CFG_Geral_SetPathSalvar,
NFE_CFG_Geral_GetPathSchemas, NFE_CFG_Geral_SetPathSchemas,
NFE_CFG_Geral_GetIniFinXMLSECAutomatico, NFE_CFG_Geral_SetIniFinXMLSECAutomatico,
NFE_CFG_Geral_GetFormaEmissaoCodigo, NFE_CFG_Geral_Save,

{ Arquivo }
NFE_CFG_Arquivos_GetAdicionarLiteral, NFE_CFG_Arquivos_SetAdicionarLiteral,
NFE_CFG_Arquivos_GetEmissaoPathNFe, NFE_CFG_Arquivos_SetEmissaoPathNFe,
NFE_CFG_Arquivos_GetSalvar, NFE_CFG_Arquivos_SetSalvar,
NFE_CFG_Arquivos_GetPastaMensal, NFE_CFG_Arquivos_SetPastaMensal,
NFE_CFG_Arquivos_GetPathNFe, NFE_CFG_Arquivos_SetPathNFe,
NFE_CFG_Arquivos_GetPathCan, NFE_CFG_Arquivos_SetPathCan,
NFE_CFG_Arquivos_GetPathInu, NFE_CFG_Arquivos_SetPathInu,
NFE_CFG_Arquivos_GetPathDPEC, NFE_CFG_Arquivos_SetPathDPEC,
NFE_CFG_Arquivos_GetPathCCe, NFE_CFG_Arquivos_SetPathCCe,
NFE_CFG_Arquivos_GetPathMDe, NFE_CFG_Arquivos_SetPathMDe,
NFE_CFG_Arquivos_GetPathEvento, NFE_CFG_Arquivos_SetPathEvento,
NFE_CFG_Arquivos_FGetPathNFe, NFE_CFG_Arquivos_FGetPathCan,
NFE_CFG_Arquivos_FGetPathInu, NFE_CFG_Arquivos_FGetPathDPEC,
NFE_CFG_Arquivos_FGetPathCCe, NFE_CFG_Arquivos_FGetPathMDe,
NFE_CFG_Arquivos_FGetPathEvento,

{ Certificados }
NFE_CFG_Certificados_GetCertificado, NFE_CFG_Certificados_SetCertificado,
NFE_CFG_Certificados_GetSenha, NFE_CFG_Certificados_SetSenha,

{ WebServices }
NFE_CFG_WebServices_GetVisualizar, NFE_CFG_WebServices_SetVisualizar,
NFE_CFG_WebServices_GetUF, NFE_CFG_WebServices_SetUF,
NFE_CFG_WebServices_GetAmbiente, NFE_CFG_WebServices_SetAmbiente,
NFE_CFG_WebServices_GetUFCodigo, NFE_CFG_WebServices_GetAmbienteCodigo,
NFE_CFG_WebServices_GetProxyHost, NFE_CFG_WebServices_SetProxyHost,
NFE_CFG_WebServices_GetProxyPort, NFE_CFG_WebServices_SetProxyPort,
NFE_CFG_WebServices_GetProxyUser, NFE_CFG_WebServices_SetProxyUser,
NFE_CFG_WebServices_GetProxyPass, NFE_CFG_WebServices_SetProxyPass,
NFE_CFG_WebServices_GetAguardarConsultaRet, NFE_CFG_WebServices_SetAguardarConsultaRet,
NFE_CFG_WebServices_GetTentativas, NFE_CFG_WebServices_SetTentativas,
NFE_CFG_WebServices_GetIntervaloTentativas, NFE_CFG_WebServices_SetIntervaloTentativas,
NFE_CFG_WebServices_GetAjustaAguardaConsultaRet, NFE_CFG_WebServices_SetAjustaAguardaConsultaRet,

{%endregion}

{%region NotasFiscais }

NFE_NotasFiscais_Add, NFE_NotasFiscais_Insert,
NFE_NotasFiscais_GetItem, NFE_NotasFiscais_SetItem,
NFE_NotasFiscais_Clear, NFE_NotasFiscais_Count, NFE_NotasFiscais_Assinar,
NFE_NotasFiscais_GerarNFe, NFE_NotasFiscais_Valida,
NFE_NotasFiscais_ValidaAssinatura, NFE_NotasFiscais_Imprimir,
NFE_NotasFiscais_ImprimirPDF, NFE_NotasFiscais_GetNamePath,
NFE_NotasFiscais_LoadFromFile, NFE_NotasFiscais_LoadFromString,
NFE_NotasFiscais_SaveToFile, NFE_NotasFiscais_SaveToTXT,

{%endregion}

{%region Nota Fical }

NFE_NF_GetNFe,
NFE_NF_GetAlertas, NFE_NF_SetAlertas,
NFE_NF_GetXML, NFE_NF_SetXML,
NFE_NF_GetMsg, NFE_NF_SetMsg,
NFE_NF_GetNomeArq, NFE_NF_SetNomeArq,
NFE_NF_GetConfirmada, NFE_NF_SetConfirmada,
NFE_NF_Imprimir, NFE_NF_ImprimirPDF,
NFE_NF_SaveToFile, NFE_NF_EnviarEmail,

{%endregion}

{%region NFe }

NFE_NFe_Getschema, NFE_NFe_Setschema,

{%region infNFe }

NFE_NFe_infNFe_GetID, NFE_NFe_infNFe_SetID,
NFE_NFe_infNFe_GetVersao, NFE_NFe_infNFe_SetVersao,
NFE_NFe_infNFe_GetVersaoStr,

{%endregion}

{%region Ide }

NFE_NFe_Ide_GetcUF, NFE_NFe_Ide_SetcUF,
NFE_NFe_Ide_GetcNF, NFE_NFe_Ide_SetcNF,
NFE_NFe_Ide_GetnatOp, NFE_NFe_Ide_SetnatOp,
NFE_NFe_Ide_GetindPag, NFE_NFe_Ide_SetindPag,
NFE_NFe_Ide_Getmodelo, NFE_NFe_Ide_Setmodelo,
NFE_NFe_Ide_Getserie, NFE_NFe_Ide_Setserie,
NFE_NFe_Ide_GetnNF, NFE_NFe_Ide_SetnNF,
NFE_NFe_Ide_GetdEmi, NFE_NFe_Ide_SetdEmi,
NFE_NFe_Ide_GetdSaiEnt, NFE_NFe_Ide_SetdSaiEnt,
NFE_NFe_Ide_GettpNF, NFE_NFe_Ide_SettpNF,
NFE_NFe_Ide_GetcMunFG, NFE_NFe_Ide_SetcMunFG,
NFE_NFe_Ide_GettpImp, NFE_NFe_Ide_SettpImp,
NFE_NFe_Ide_GettpEmis, NFE_NFe_Ide_SettpEmis,
NFE_NFe_Ide_GetcDV, NFE_NFe_Ide_SetcDV,
NFE_NFe_Ide_GettpAmb, NFE_NFe_Ide_SettpAmb,
NFE_NFe_Ide_GetfinNFe, NFE_NFe_Ide_SetfinNFe,
NFE_NFe_Ide_GetprocEmi, NFE_NFe_Ide_SetprocEmi,
NFE_NFe_Ide_GetverProc, NFE_NFe_Ide_SetverProc,
NFE_NFe_Ide_GetdhCont, NFE_NFe_Ide_SetdhCont,
NFE_NFe_Ide_GetxJust, NFE_NFe_Ide_SetxJust,

NFE_NFe_Ide_NFref_Count, NFE_NFe_Ide_NFref_Clear,
NFE_NFe_Ide_NFref_Add, NFE_NFe_Ide_NFref_GetItem,
NFE_NFe_Ide_NFref_SetItem,

NFE_NFe_Ide_NFref_Item_GetrefCTe, NFE_NFe_Ide_NFref_Item_SetrefCTe,
NFE_NFe_Ide_NFref_Item_GetrefNFe, NFE_NFe_Ide_NFref_Item_SetrefNFe,

NFE_NFe_Ide_NFref_Item_RefNF_GetAAMM, NFE_NFe_Ide_NFref_Item_RefNF_SetAAMM,
NFE_NFe_Ide_NFref_Item_RefNF_GetCNPJ, NFE_NFe_Ide_NFref_Item_RefNF_SetCNPJ,
NFE_NFe_Ide_NFref_Item_RefNF_GetcUF, NFE_NFe_Ide_NFref_Item_RefNF_SetcUF,
NFE_NFe_Ide_NFref_Item_RefNF_Getmodelo, NFE_NFe_Ide_NFref_Item_RefNF_Setmodelo,
NFE_NFe_Ide_NFref_Item_RefNF_Getserie, NFE_NFe_Ide_NFref_Item_RefNF_Setserie,
NFE_NFe_Ide_NFref_Item_RefNF_GetnNF, NFE_NFe_Ide_NFref_Item_RefNF_GetnNF,

NFE_NFe_Ide_NFref_Item_RefNFP_GetAAMM, NFE_NFe_Ide_NFref_Item_RefNFP_SetAAMM,
NFE_NFe_Ide_NFref_Item_RefNFP_GetCNPJCPF, NFE_NFe_Ide_NFref_Item_RefNFP_SetCNPJCPF,
NFE_NFe_Ide_NFref_Item_RefNFP_GetIE, NFE_NFe_Ide_NFref_Item_RefNFP_SetIE,
NFE_NFe_Ide_NFref_Item_RefNFP_GetcUF, NFE_NFe_Ide_NFref_Item_RefNFP_SetcUF,
NFE_NFe_Ide_NFref_Item_RefNFP_Getmodelo, NFE_NFe_Ide_NFref_Item_RefNFP_Setmodelo,
NFE_NFe_Ide_NFref_Item_RefNFP_Getserie, NFE_NFe_Ide_NFref_Item_RefNFP_Setserie,
NFE_NFe_Ide_NFref_Item_RefNFP_GetnNF, NFE_NFe_Ide_NFref_Item_RefNFP_GetnNF,

NFE_NFe_Ide_NFref_Item_RefECF_Getmodelo, NFE_NFe_Ide_NFref_Item_RefECF_Setmodelo,
NFE_NFe_Ide_NFref_Item_RefECF_GetnCOO, NFE_NFe_Ide_NFref_Item_RefECF_SetnCOO,
NFE_NFe_Ide_NFref_Item_RefECF_GetnECF, NFE_NFe_Ide_NFref_Item_RefECF_SetnECF,

{%endregion}

{%region Emit }

NFE_NFe_Emit_GetCNAE, NFE_NFe_Emit_SetCNAE,
NFE_NFe_Emit_GetCNPJCPF, NFE_NFe_Emit_SetCNPJCPF,
NFE_NFe_Emit_GetIE, NFE_NFe_Emit_SetIE,
NFE_NFe_Emit_GetIEST, NFE_NFe_Emit_SetIEST,
NFE_NFe_Emit_GetIM, NFE_NFe_Emit_SetIM,
NFE_NFe_Emit_GetxFant, NFE_NFe_Emit_SetxFant,
NFE_NFe_Emit_GetxNome, NFE_NFe_Emit_SetxNome,
NFE_NFe_Emit_GetCRT, NFE_NFe_Emit_SetCRT,

NFE_NFe_Emit_EnderEmit_GetCEP, NFE_NFe_Emit_EnderEmit_SetCEP,
NFE_NFe_Emit_EnderEmit_GetcMun, NFE_NFe_Emit_EnderEmit_SetcMun,
NFE_NFe_Emit_EnderEmit_GetcPais, NFE_NFe_Emit_EnderEmit_SetcPais,
NFE_NFe_Emit_EnderEmit_Getfone, NFE_NFe_Emit_EnderEmit_Setfone,
NFE_NFe_Emit_EnderEmit_Getnro, NFE_NFe_Emit_EnderEmit_Setnro,
NFE_NFe_Emit_EnderEmit_GetUF, NFE_NFe_Emit_EnderEmit_SetUF,
NFE_NFe_Emit_EnderEmit_GetxBairro, NFE_NFe_Emit_EnderEmit_SetxBairro,
NFE_NFe_Emit_EnderEmit_GetxCpl, NFE_NFe_Emit_EnderEmit_SetxCpl,
NFE_NFe_Emit_EnderEmit_GetxLgr, NFE_NFe_Emit_EnderEmit_SetxLgr,
NFE_NFe_Emit_EnderEmit_GetxMun, NFE_NFe_Emit_EnderEmit_SetxMun,
NFE_NFe_Emit_EnderEmit_GetxPais, NFE_NFe_Emit_EnderEmit_SetxPais,

{%endregion}

{%region Avulsa }

NFE_NFe_Avulsa_GetCNPJ, NFE_NFe_Avulsa_SetCNPJ,
NFE_NFe_Avulsa_GetFone, NFE_NFe_Avulsa_SetFone,
NFE_NFe_Avulsa_GetMatr, NFE_NFe_Avulsa_SetMatr,
NFE_NFe_Avulsa_GetNDAR, NFE_NFe_Avulsa_SetNDAR,
NFE_NFe_Avulsa_GetRepEmi, NFE_NFe_Avulsa_SetRepEmi,
NFE_NFe_Avulsa_GetUF, NFE_NFe_Avulsa_SetUF,
NFE_NFe_Avulsa_GetVDAR, NFE_NFe_Avulsa_SetVDAR,
NFE_NFe_Avulsa_GetXAgente, NFE_NFe_Avulsa_SetXAgente,
NFE_NFe_Avulsa_GetXOrgao, NFE_NFe_Avulsa_SetXOrgao,
NFE_NFe_Avulsa_GetDEmi, NFE_NFe_Avulsa_SetDEmi,
NFE_NFe_Avulsa_GetDPag, NFE_NFe_Avulsa_SetDPag,

{%endregion}

{%region Dest }

 NFE_NFe_Dest_GetCNPJCPF, NFE_NFe_Dest_SetCNPJCPF,
 NFE_NFe_Dest_GetXNome, NFE_NFe_Dest_SetXNome,
 NFE_NFe_Dest_GetIE, NFE_NFe_Dest_SetIE,
 NFE_NFe_Dest_GetISUF, NFE_NFe_Dest_SetISUF,
 NFE_NFe_Dest_GetEmail, NFE_NFe_Dest_SetEmail,

 NFE_NFe_Dest_EnderDest_GetCEP, NFE_NFe_Dest_EnderDest_SetCEP,
 NFE_NFe_Dest_EnderDest_GetcMun, NFE_NFe_Dest_EnderDest_SetcMun,
 NFE_NFe_Dest_EnderDest_GetcPais, NFE_NFe_Dest_EnderDest_SetcPais,
 NFE_NFe_Dest_EnderDest_Getfone, NFE_NFe_Dest_EnderDest_Setfone,
 NFE_NFe_Dest_EnderDest_Getnro, NFE_NFe_Dest_EnderDest_Setnro,
 NFE_NFe_Dest_EnderDest_GetUF, NFE_NFe_Dest_EnderDest_SetUF,
 NFE_NFe_Dest_EnderDest_GetxBairro, NFE_NFe_Dest_EnderDest_SetxBairro,
 NFE_NFe_Dest_EnderDest_GetxCpl, NFE_NFe_Dest_EnderDest_SetxCpl,
 NFE_NFe_Dest_EnderDest_GetxLgr, NFE_NFe_Dest_EnderDest_SetxLgr,
 NFE_NFe_Dest_EnderDest_GetxMun, NFE_NFe_Dest_EnderDest_SetxMun,
 NFE_NFe_Dest_EnderDest_GetxPais, NFE_NFe_Dest_EnderDest_SetxPais,

{%endregion}

{%region Retirada }

NFE_NFe_Retirada_GetCNPJCPF, NFE_NFe_Retirada_SetCNPJCPF,
NFE_NFe_Retirada_GetXLgr, NFE_NFe_Retirada_SetXLgr,
NFE_NFe_Retirada_GetNro, NFE_NFe_Retirada_SetNro,
NFE_NFe_Retirada_GetXCpl, NFE_NFe_Retirada_SetXCpl,
NFE_NFe_Retirada_GetXBairro, NFE_NFe_Retirada_SetXBairro,
NFE_NFe_Retirada_GetXMun, NFE_NFe_Retirada_SetXMun,
NFE_NFe_Retirada_GetUF, NFE_NFe_Retirada_SetUF,
NFE_NFe_Retirada_GetCMun, NFE_NFe_Retirada_GetCMun,

{%endregion}

{%region Entrega }

NFE_NFe_Entrega_GetCNPJCPF, NFE_NFe_Entrega_SetCNPJCPF,
NFE_NFe_Entrega_GetXLgr, NFE_NFe_Entrega_SetXLgr,
NFE_NFe_Entrega_GetNro, NFE_NFe_Entrega_SetNro,
NFE_NFe_Entrega_GetXCpl, NFE_NFe_Entrega_SetXCpl,
NFE_NFe_Entrega_GetXBairro, NFE_NFe_Entrega_SetXBairro,
NFE_NFe_Entrega_GetXMun, NFE_NFe_Entrega_SetXMun,
NFE_NFe_Entrega_GetUF, NFE_NFe_Entrega_SetUF,
NFE_NFe_Entrega_GetCMun, NFE_NFe_Entrega_GetCMun,

{%endregion}

{%region Det }

NFE_NFe_Det_Add, NFE_NFe_Det_Insert,
NFE_NFe_Det_GetItem, NFE_NFe_Det_SetItem,
NFE_NFe_Det_Clear, NFE_NFe_Det_Count;

{%endregion}

{%endregion}


end.

