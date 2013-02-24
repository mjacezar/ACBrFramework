unit ACBrValidadorDll;

interface

uses
  Classes,
  SysUtils,
  ACBrValidador;

{ Ponteiros de função para uso nos eventos}
type TOnMsgErroCallback = procedure(Mensagem : PChar); cdecl;

{Classe que armazena os EventHandlers para o componente ACBr}
type TEventHandlers = class
  OnMsgErroCallback : TOnMsgErroCallback;
  procedure OnMsgErro(Mensagem : String);
end;

{Handle para o componente TACBrValidador}
type TVALHandle = record
  UltimoErro : String;
  Val : TACBrValidador;
  EventHandlers : TEventHandlers;
end;

{Ponteiro para o Handle }
type PVALHandle = ^TVALHandle;


implementation

{%region Create/Destroy/Erro}
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
CRIA um novo componente TACBrValidador retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrValidador.
}
Function VAL_Create(var valHandle: PVALHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try
     New(valHandle);
     valHandle^.Val := TACBrValidador.Create(nil);
     valHandle^.EventHandlers := TEventHandlers.Create();
     valHandle^.UltimoErro:= '';
     Result := 0;
  except
     on exception : Exception do
     begin
        Result := -1;
        valHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrValidador e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function VAL_Destroy(valHandle: PVALHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
    valHandle^.Val.Destroy();
    valHandle^.Val := nil;

    Dispose(valHandle);
    valHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        valHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function VAL_GetUltimoErro(const valHandle: PVALHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, valHandle^.UltimoErro, BufferLen);
     Result := length(valHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Funções mapeando as propriedades do componente}

Function VAL_GetDocumento(const valHandle: PVALHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := valHandle^.Val.Documento;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_SetDocumento(const valHandle: PVALHandle; Const Arquivo : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     valHandle^.Val.Documento := Arquivo;
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_GetComplemento(const valHandle: PVALHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := valHandle^.Val.Complemento;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_SetComplemento(const valHandle: PVALHandle; Const Complemento : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     valHandle^.Val.Complemento := Complemento;
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_GetIgnorarChar(const valHandle: PVALHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := valHandle^.Val.IgnorarChar;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_SetIgnorarChar(const valHandle: PVALHandle; Const IgnorarChar : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     valHandle^.Val.IgnorarChar := IgnorarChar;
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_GetTipoDocto(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := Integer(valHandle^.Val.TipoDocto);
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_SetTipoDocto(const valHandle: PVALHandle; Const TipoDocto : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     valHandle^.Val.TipoDocto := TACBrValTipoDocto(TipoDocto);
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_GetAjustarTamanho(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if valHandle^.Val.AjustarTamanho then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_SetAjustarTamanho(const valHandle: PVALHandle; const AjustarTamanho : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     valHandle^.VAL.AjustarTamanho := AjustarTamanho;
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_GetExibeDigitoCorreto(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if valHandle^.Val.ExibeDigitoCorreto then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_SetExibeDigitoCorreto(const valHandle: PVALHandle; const ExibeDigitoCorreto : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     valHandle^.VAL.ExibeDigitoCorreto := ExibeDigitoCorreto;
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_GetPermiteVazio(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if valHandle^.Val.PermiteVazio then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_SetPermiteVazio(const valHandle: PVALHandle; const PermiteVazio : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     valHandle^.VAL.PermiteVazio := PermiteVazio;
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_GetRaiseExcept(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if valHandle^.Val.RaiseExcept then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_SetRaiseExcept(const valHandle: PVALHandle; const RaiseExcept : Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     valHandle^.VAL.RaiseExcept := RaiseExcept;
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Funções mapeando as propriedades do componente não visiveis}

Function VAL_GetDoctoValidado(const valHandle: PVALHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := valHandle^.Val.DoctoValidado;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_GetMsgErro(const valHandle: PVALHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := valHandle^.Val.MsgErro;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_GetDigitoCalculado(const valHandle: PVALHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := valHandle^.Val.DigitoCalculado;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Modulo}

Function VAL_Modulo_GetDocumento(const valHandle: PVALHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := valHandle^.Val.Modulo.Documento;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_SetDocumento(const valHandle: PVALHandle; Const value : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     valHandle^.Val.Modulo.Documento := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_GetMultiplicadorInicial(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := valHandle^.Val.Modulo.MultiplicadorInicial;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_SetMultiplicadorInicial(const valHandle: PVALHandle; Const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     valHandle^.Val.Modulo.MultiplicadorInicial := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_GetMultiplicadorFinal(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := valHandle^.Val.Modulo.MultiplicadorFinal;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_SetMultiplicadorFinal(const valHandle: PVALHandle; Const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     valHandle^.Val.Modulo.MultiplicadorFinal := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_GetMultiplicadorAtual(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := valHandle^.Val.Modulo.MultiplicadorAtual;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_SetMultiplicadorAtual(const valHandle: PVALHandle; Const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     valHandle^.Val.Modulo.MultiplicadorAtual := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_GetDigitoFinal(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := valHandle^.Val.Modulo.DigitoFinal;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_GetModuloFinal(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := valHandle^.Val.Modulo.ModuloFinal;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_GetSomaDigitos(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := valHandle^.Val.Modulo.SomaDigitos;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_GetFormulaDigito(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     Result := Integer(valHandle^.Val.Modulo.FormulaDigito);
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_SetFormulaDigito(const valHandle: PVALHandle; Const value : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     valHandle^.Val.Modulo.FormulaDigito := TACBrCalcDigFormula(value);
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_Calcular(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    valHandle^.Val.Modulo.Calcular;
    Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function VAL_Modulo_CalculoPadrao(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
    valHandle^.Val.Modulo.CalculoPadrao;
    Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

{%endregion}

{%region Metodos do Componente}

Function VAL_Validar(const valHandle: PVALHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if valHandle^.Val.Validar then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_Formatar(const valHandle: PVALHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrTmp := valHandle^.Val.Formatar;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_FormatarCEP(const valHandle: PVALHandle; Const CEP : pChar; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrTmp := valHandle^.Val.FormatarCEP(CEP);
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_FormatarCheque(const valHandle: PVALHandle; Const Cheque : pChar; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrTmp := valHandle^.Val.FormatarCheque(Cheque);
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_FormatarCNPJ(const valHandle: PVALHandle; Const CNPJ : pChar; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrTmp := valHandle^.Val.FormatarCNPJ(CNPJ);
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_FormatarCPF(const valHandle: PVALHandle; Const CPF : pChar; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrTmp := valHandle^.Val.FormatarCPF(CPF);
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_FormatarIE(const valHandle: PVALHandle; Const IE, UF : pChar; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrTmp := valHandle^.Val.FormatarIE(IE, UF);
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_FormatarPIS(const valHandle: PVALHandle; Const PIS : pChar; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrTmp := valHandle^.Val.FormatarPIS(PIS);
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function VAL_FormatarSUFRAMA(const valHandle: PVALHandle; Const SUFRAMA : pChar; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     StrTmp := valHandle^.Val.FormatarSUFRAMA(SUFRAMA);
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
     Result := 0;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Eventos}

procedure TEventHandlers.OnMsgErro(Mensagem : String);
begin
     OnMsgErroCallback(PChar(Mensagem));
end;

Function VAL_SetOnMsgErro(const valHandle: PVALHandle; const method : TOnMsgErroCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (valHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        valHandle^.Val.OnMsgErro := valHandle^.EventHandlers.OnMsgErro;
        valHandle^.EventHandlers.OnMsgErroCallback := method;
        Result := 0;
  end
  else
  begin
        valHandle^.Val.OnMsgErro := nil;
        valHandle^.EventHandlers.OnMsgErroCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        valHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

exports

{ Create/Destroy/Erro }
VAL_Create, VAL_Destroy, VAL_GetUltimoErro,

{ Funções mapeando as propriedades do componente }
VAL_GetDocumento, VAL_SetDocumento, VAL_GetComplemento, VAL_SetComplemento,
VAL_GetIgnorarChar, VAL_SetIgnorarChar, VAL_GetTipoDocto, VAL_SetTipoDocto,
VAL_GetAjustarTamanho, VAL_SetAjustarTamanho, VAL_GetExibeDigitoCorreto, VAL_SetExibeDigitoCorreto,
VAL_GetPermiteVazio, VAL_SetPermiteVazio, VAL_GetRaiseExcept, VAL_SetRaiseExcept,

{ Funções mapeando as propriedades do componente não visiveis }
VAL_GetDoctoValidado, VAL_GetMsgErro, VAL_GetDigitoCalculado,

{ Modulo }
VAL_Modulo_GetDocumento, VAL_Modulo_SetDocumento,
VAL_Modulo_GetMultiplicadorInicial, VAL_Modulo_SetMultiplicadorInicial,
VAL_Modulo_GetMultiplicadorFinal, VAL_Modulo_SetMultiplicadorFinal,
VAL_Modulo_GetMultiplicadorAtual, VAL_Modulo_SetMultiplicadorAtual,
VAL_Modulo_GetDigitoFinal, VAL_Modulo_GetModuloFinal, VAL_Modulo_GetSomaDigitos,
VAL_Modulo_GetFormulaDigito, VAL_Modulo_SetFormulaDigito,
VAL_Modulo_Calcular, VAL_Modulo_CalculoPadrao,


{ Metodos do Componente }
VAL_Validar, VAL_Formatar, VAL_FormatarCEP, VAL_FormatarCheque,
VAL_FormatarCNPJ, VAL_FormatarCPF, VAL_FormatarIE, VAL_FormatarPIS,
 VAL_FormatarSUFRAMA,

{ Evento }
VAL_SetOnMsgErro;

end.

