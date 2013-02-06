unit ACBrCEPDll;


interface

uses
  Classes, SysUtils,
  ACBrCEP;

type TNoArgumentsCallback = procedure(); cdecl;
type TAntesAbrirHTTPCallback = function(const AURL : pChar) : pChar; cdecl;

type TEventHandlersCEP = class

  OnBuscaEfetuadaCallback : TNoArgumentsCallback;
  OnAntesAbrirHTTPCallback :  TAntesAbrirHTTPCallback;

  procedure OnBuscaEfetuada(Sender: TObject);
  procedure OnAntesAbrirHTTP(var AURL : String);

end;

{Handle para o componente TACBrCEP }
type TCEPHandle = record
  UltimoErro : String;
  CEP : TACBrCEP;
  EventHandlers : TEventHandlersCEP;
end;

{Ponteiro para o Handle }
type PCEPHandle = ^TCEPHandle;

implementation

{%region Constructor/Destructor }
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
CRIA um novo componente TACBrCEP retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrCEP
}
Function CEP_Create(var cepHandle: PCEPHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try

     New(cepHandle);

     cepHandle^.CEP := TACBrCEP.Create(nil);
     cepHandle^.EventHandlers := TEventHandlersCEP.Create();
     cepHandle^.UltimoErro := '';
     Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        cepHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrCEP e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function CEP_Destroy(var cepHandle: PCEPHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

    cepHandle^.CEP.Destroy();
    cepHandle^.CEP := nil;

    Dispose(cepHandle);
    cepHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        cepHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function CEP_GetUltimoErro(const cepHandle: PCEPHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, cepHandle^.UltimoErro, BufferLen);
     Result := length(cepHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Funções mapeando as propriedades do componente }

Function CEP_GetChaveAcesso(const cepHandle: PCEPHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, cepHandle^.CEP.ChaveAcesso, BufferLen);
     Result := length(cepHandle^.CEP.ChaveAcesso);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_SetChaveAcesso(const cepHandle: PCEPHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     cepHandle^.CEP.ChaveAcesso := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_GetURL(const cepHandle: PCEPHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, cepHandle^.CEP.URL, BufferLen);
     Result := length(cepHandle^.CEP.ChaveAcesso);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_GetParseText(const cepHandle: PCEPHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if cepHandle^.CEP.ParseText then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_SetParseText(const cepHandle: PCEPHandle; const value : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     cepHandle^.CEP.ParseText := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_GetProxyHost(const cepHandle: PCEPHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, cepHandle^.CEP.ProxyHost, BufferLen);
     Result := length(cepHandle^.CEP.ChaveAcesso);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_SetProxyHost(const cepHandle: PCEPHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     cepHandle^.CEP.ProxyHost := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_GetProxyPort(const cepHandle: PCEPHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, cepHandle^.CEP.ProxyPort, BufferLen);
     Result := length(cepHandle^.CEP.ChaveAcesso);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_SetProxyPort(const cepHandle: PCEPHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     cepHandle^.CEP.ProxyPort := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_GetProxyUser(const cepHandle: PCEPHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, cepHandle^.CEP.ProxyUser, BufferLen);
     Result := length(cepHandle^.CEP.ChaveAcesso);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_SetProxyUser(const cepHandle: PCEPHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     cepHandle^.CEP.ProxyUser := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_GetProxyPass(const cepHandle: PCEPHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, cepHandle^.CEP.ProxyPass, BufferLen);
     Result := length(cepHandle^.CEP.ChaveAcesso);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_SetProxyPass(const cepHandle: PCEPHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     cepHandle^.CEP.ProxyPass := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_GetWebService(const cepHandle: PCEPHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(cepHandle^.CEP.WebService);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_SetWebService(const cepHandle: PCEPHandle; const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     cepHandle^.CEP.WebService := TACBrCEPWebService(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Endereços }

Function CEP_GetEnderecos(const cepHandle: PCEPHandle; var endsHandle : TACBrCEPEnderecos) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     endsHandle := cepHandle^.CEP.Enderecos;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Enderecos_GetCount(const cepHandle: PCEPHandle; const endsHandle : TACBrCEPEnderecos) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := endsHandle.Count;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Enderecos_GetItem(const cepHandle: PCEPHandle; const endsHandle : TACBrCEPEnderecos; const index : Integer; var endHandle : TACBrCEPEndereco) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     endHandle :=  endsHandle[index];
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Endereço }

Function CEP_Endereco_GetCEP(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, endHandle.CEP, BufferLen);
     Result := length(endHandle.CEP);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_SetCEP(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     endHandle.CEP := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_GetBairro(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, endHandle.Bairro, BufferLen);
     Result := length(endHandle.Bairro);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_SetBairro(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     endHandle.Bairro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_GetComplemento(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, endHandle.Complemento, BufferLen);
     Result := length(endHandle.Complemento);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_SetComplemento(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     endHandle.Complemento := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_GetTipo_Logradouro(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, endHandle.Tipo_Logradouro, BufferLen);
     Result := length(endHandle.Tipo_Logradouro);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_SetTipo_Logradouro(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     endHandle.Tipo_Logradouro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_GetLogradouro(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, endHandle.Logradouro, BufferLen);
     Result := length(endHandle.Logradouro);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_SetLogradouro(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     endHandle.Logradouro := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_GetMunicipio(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, endHandle.Municipio, BufferLen);
     Result := length(endHandle.Municipio);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_SetMunicipio(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     endHandle.Municipio := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_GetUF(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, endHandle.UF, BufferLen);
     Result := length(endHandle.UF);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_SetUF(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     endHandle.UF := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_GetIBGE_Municipio(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, endHandle.IBGE_Municipio, BufferLen);
     Result := length(endHandle.IBGE_Municipio);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_SetIBGE_Municipio(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     endHandle.IBGE_Municipio := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_Endereco_GetIBGE_UF(const cepHandle: PCEPHandle; const endHandle : TACBrCEPEndereco; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrPLCopy(Buffer, endHandle.IBGE_UF, BufferLen);
     Result := length(endHandle.IBGE_UF);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion }

{%region Metodos }

Function CEP_LerConfiguracoesProxy(const cepHandle: PCEPHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     cepHandle^.CEP.LerConfiguracoesProxy;
     Result := 0;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_BuscarPorCEP(const cepHandle: PCEPHandle; const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := cepHandle^.CEP.BuscarPorCEP(value);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_BuscarPorLogradouro(const cepHandle: PCEPHandle; const ACidade, ATipo_Logradouro, ALogradouro, AUF,
         ABairro : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := cepHandle^.CEP.BuscarPorLogradouro(ACidade, ATipo_Logradouro, ALogradouro, AUF, ABairro);
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Eventos }

procedure TEventHandlersCEP.OnBuscaEfetuada(Sender: TObject);
begin
     OnBuscaEfetuadaCallback();
end;

procedure TEventHandlersCEP.OnAntesAbrirHTTP(var AURL : String);
begin
    AURL := OnAntesAbrirHTTPCallback(pChar(AURL));
end;

Function CEP_SetOnBuscaEfetuada(const cepHandle: PCEPHandle; const method : TNoArgumentsCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        cepHandle^.CEP.OnBuscaEfetuada := cepHandle^.EventHandlers.OnBuscaEfetuada;
        cepHandle^.EventHandlers.OnBuscaEfetuadaCallback := method;
        Result := 0;
  end
  else
  begin
        cepHandle^.CEP.OnBuscaEfetuada := nil;
        cepHandle^.EventHandlers.OnBuscaEfetuadaCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function CEP_SetOnAntesAbrirHTTP(const cepHandle: PCEPHandle; const method : TAntesAbrirHTTPCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (cepHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        cepHandle^.CEP.OnAntesAbrirHTTP := cepHandle^.EventHandlers.OnAntesAbrirHTTP;
        cepHandle^.EventHandlers.OnAntesAbrirHTTPCallback := method;
        Result := 0;
  end
  else
  begin
        cepHandle^.CEP.OnAntesAbrirHTTP := nil;
        cepHandle^.EventHandlers.OnAntesAbrirHTTPCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        cepHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

exports

{Constructor/Destructor}
CEP_Create, CEP_Destroy,
CEP_GetUltimoErro,

{Funções mapeando as propriedades do componente}
CEP_GetChaveAcesso, CEP_SetChaveAcesso,
CEP_GetParseText, CEP_SetParseText,
CEP_GetProxyHost, CEP_SetProxyHost,
CEP_GetProxyPort, CEP_SetProxyPort,
CEP_GetProxyUser, CEP_SetProxyUser,
CEP_GetProxyPass, CEP_SetProxyPass,
CEP_GetWebService, CEP_SetWebService,
CEP_GetURL,

{Enderecos}
CEP_GetEnderecos, CEP_Enderecos_GetCount,
CEP_Enderecos_GetItem,

{Endereco}
CEP_Endereco_GetCEP, CEP_Endereco_SetCEP,
CEP_Endereco_GetBairro, CEP_Endereco_SetBairro,
CEP_Endereco_GetComplemento, CEP_Endereco_SetComplemento,
CEP_Endereco_GetTipo_Logradouro, CEP_Endereco_SetTipo_Logradouro,
CEP_Endereco_GetLogradouro, CEP_Endereco_SetLogradouro,
CEP_Endereco_GetMunicipio, CEP_Endereco_SetMunicipio,
CEP_Endereco_GetUF, CEP_Endereco_SetUF,
CEP_Endereco_GetIBGE_Municipio, CEP_Endereco_SetIBGE_Municipio,
CEP_Endereco_GetIBGE_UF,

{Metodos}
CEP_BuscarPorCEP, CEP_BuscarPorLogradouro,
CEP_LerConfiguracoesProxy,

{Eventos}
CEP_SetOnBuscaEfetuada, CEP_SetOnAntesAbrirHTTP;

end.
