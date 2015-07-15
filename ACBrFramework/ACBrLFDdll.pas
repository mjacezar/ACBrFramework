unit ACBrLFDDll;

{$mode delphi}

interface

uses
  Classes, SysUtils,
  ACBrLFD,
  ACBrLFDBlocosDll,
  ACBrLFDBlocos,
  ACBrLFDBloco_0;

type TEventHandlers = class
  OnErrorCallback : TStringCallback;
  procedure OnError(const MsnError: AnsiString);
end;

{Handle para o componente TACBrSPEDFiscal}
type TLFDHandle = record
  UltimoErro : String;
  LFD : TACBrLFD;
  EventHandlers : TEventHandlers;
end;

{Ponteiro para o Handle }
type PTFDHandle = ^TLFDHandle;

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
CRIA um novo componente TACBrLFD retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrPAF.
}
Function LFD_Create(var lfdHandle: PTFDHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin
  New(lfdHandle);

  try
     lfdHandle^.LFD := TACBrLFD.Create(nil);
     lfdHandle^.EventHandlers := TEventHandlers.Create();
     lfdHandle^.UltimoErro:= '';
     Result := 0;
  except
     on exception : Exception do
     begin
        Result := -1;
        lfdHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrSPEDFiscal e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function LFD_Destroy(var lfdHandle: PTFDHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
    lfdHandle^.LFD.Destroy();
    lfdHandle^.LFD := nil;

    Dispose(lfdHandle);
    lfdHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        lfdHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function LFD_GetUltimoErro(const lfdHandle: PTFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, lfdHandle^.UltimoErro, BufferLen);
     Result := length(lfdHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Funções mapeando as propriedades do componente }

Function LFD_GetAbout(const lfdHandle: PTFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := lfdHandle^.LFD.About;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LFD_GetArquivo(const lfdHandle: PTFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := lfdHandle^.LFD.Arquivo;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LFD_SetArquivo(const lfdHandle: PTFDHandle; Const Arquivo : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     lfdHandle^.LFD.Arquivo := Arquivo;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LFD_GetCurMascara(const lfdHandle: PTFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := lfdHandle^.LFD.CurMascara;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LFD_SetCurMascara(const lfdHandle: PTFDHandle; Const CurMascara : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     lfdHandle^.LFD.CurMascara := CurMascara;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LFD_GetPath(const lfdHandle: PTFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (LFDHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := lfdHandle^.LFD.Path;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        LFDHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LFD_SetPath(const lfdHandle: PTFDHandle; Const Path : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     lfdHandle^.LFD.Path := Path;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LFD_GetDelimitador(const lfdHandle: PTFDHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := lfdHandle^.LFD.Delimitador;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LFD_SetDelimitador(const lfdHandle: PTFDHandle; Const Delimitador : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     lfdHandle^.LFD.Delimitador := Delimitador;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function LFD_GetLinhasBuffer(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (LFDHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := lfdHandle^.LFD.LinhasBuffer;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_SetLinhasBuffer(const lfdHandle: PTFDHandle; const Linhas: Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (LFDHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lfdHandle^.LFD.LinhasBuffer := Linhas;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_GetTrimString(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if lfdHandle^.LFD.TrimString then
      Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_SetTrimString(const lfdHandle: PTFDHandle; const TrimString: Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lfdHandle^.LFD.TrimString := TrimString;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Funções mapeando as propriedades do componente não visiveis}

Function LFD_GetDT_INI(const lfdHandle: PTFDHandle; var Data : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (lfdHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    Data := Double(lfdHandle^.LFD.DT_INI);
    Result := 0;
 except
    on exception : Exception do
    begin
       lfdHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

Function LFD_SetDT_INI(const lfdHandle: PTFDHandle; const Data : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (lfdHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    lfdHandle^.LFD.DT_INI := Data;
    Result := 0;
 except
    on exception : Exception do
    begin
       lfdHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

Function LFD_GetDT_FIN(const lfdHandle: PTFDHandle; var Data : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (lfdHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    Data := Double(lfdHandle^.LFD.DT_FIN);
    Result := 0;
 except
    on exception : Exception do
    begin
       lfdHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

Function LFD_SetDT_FIN(const lfdHandle: PTFDHandle; const Data : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

if (lfdHandle = nil) then
 begin
    Result := -2;
    Exit;
 end;

 try
    lfdHandle^.LFD.DT_FIN := Data;
    Result := 0;
 except
    on exception : Exception do
    begin
       lfdHandle^.UltimoErro := exception.Message;
       Result := -1;
    end
 end;
end;

{%endregion}

{%region Methods }

Function LFD_IniciaGeracao(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lfdHandle^.LFD.IniciaGeracao;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LDF_SaveFileTXT(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lfdHandle^.LFD.SaveFileTXT;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Eventos }

procedure TEventHandlers.OnError(const MsnError: AnsiString);
begin
     OnErrorCallback(pchar(MsnError));
end;

{%endregion Eventos }

{%region Set Eventos }

Function LFD_SetOnError(const lfdHandle: PTFDHandle; const method : TStringCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        lfdHandle^.LFD.OnError := lfdHandle^.EventHandlers.OnError;
        lfdHandle^.EventHandlers.OnErrorCallback := method;
        Result := 0;
  end
  else
  begin
        lfdHandle^.LFD.OnError := nil;
        lfdHandle^.EventHandlers.OnErrorCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion Set Eventos }

{%region Bloco0}

Function LFD_Bloco_0_GetDT_INI(const lfdHandle: PTFDHandle; var dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtIni  := Double(lfdHandle^.LFD.Bloco_0.DT_INI);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_SetDT_INI(const lfdHandle: PTFDHandle; const dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lfdHandle^.LFD.Bloco_0.DT_INI := TDateTime(dtIni);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_GetDT_FIN(const lfdHandle: PTFDHandle; var dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtFin  := Double(lfdHandle^.LFD.Bloco_0.DT_FIN);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_SetDT_FIN(const lfdHandle: PTFDHandle; const dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lfdHandle^.LFD.Bloco_0.DT_FIN := TDateTime(dtFin);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_GetGravado(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if lfdHandle^.LFD.Bloco_0.Gravado then
     Result := 1
     else
     Result := 0;

  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0000New(const lfdHandle: PTFDHandle; const registro0000 : Bloco0Registro0000) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_0.Registro0000New do
     BEGIN

     COD_VER       := TACBrLVersaoLeiaute(registro0000.COD_VER);
     COD_FIN       := TACBrLCodFinalidade(registro0000.COD_FIN);
     DT_INI        := TDateTime(registro0000.DT_INI);
     DT_FIN        := TDateTime(registro0000.DT_FIN);
     NOME          := registro0000.NOME;
     CNPJ          := registro0000.CNPJ;
     UF            := registro0000.UF;
     IE            := registro0000.IE;
     COD_MUN       := registro0000.COD_MUN;
     IM            := registro0000.IM;
     SUFRAMA       := registro0000.SUFRAMA;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0001New(const lfdHandle: PTFDHandle; const registro0001 : Bloco0Registro0001) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_0.Registro0001New do
     begin
          IND_MOV:= TACBrLIndicadorMovimento(registro0001.IND_MOV);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0005New(const lfdHandle: PTFDHandle; const registro0005 : Bloco0Registro0005) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_0.Registro0005New do
     begin

       NOMERESP     := registro0005.FANTASIA;
       CEP          := registro0005.CEP;
       ENDERECO     := registro0005.ENDERECO;
       NUM          := registro0005.NUM;
       COMPL        := registro0005.COMPL;
       BAIRRO       := registro0005.BAIRRO;
       FONE         := registro0005.FONE;
       FAX          := registro0005.FAX;
       EMAIL        := registro0005.EMAIL;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0100New(const lfdHandle: PTFDHandle; const registro0100 : Bloco0Registro0100) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_0.Registro0100New do
     begin

       NOME       := registro0100.NOME;
       CPF        := registro0100.CPF;
       CRC        := registro0100.CRC;
       CNPJ       := registro0100.CNPJ;
       CEP        := registro0100.CEP;
       ENDERECO   := registro0100.ENDERECO;
       NUM        := registro0100.NUM;
       COMPL      := registro0100.COMPL;
       BAIRRO     := registro0100.BAIRRO;
       FONE       := registro0100.FONE;
       FAX        := registro0100.FAX;
       EMAIL      := registro0100.EMAIL;
       COD_MUN    := registro0100.COD_MUN;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0150New(const lfdHandle: PTFDHandle; const registro0150 : Bloco0Registro0150) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_0.Registro0150New do
     begin

     COD_PART    := registro0150.COD_PART;
     NOME        := registro0150.NOME;
     COD_PAIS    := registro0150.COD_PAIS;
     CNPJ        := registro0150.CNPJ;
     CPF         := registro0150.CPF;
     IE          := registro0150.IE;
     COD_MUN     := registro0150.COD_MUN;
     SUFRAMA     := registro0150.SUFRAMA;
     ENDERECO    := registro0150.ENDERECO;
     NUM         := registro0150.NUM;
     COMPL       := registro0150.COMPL;
     BAIRRO      := registro0150.BAIRRO;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0175New(const lfdHandle: PTFDHandle; const registro0175 : Bloco0Registro0175) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_0.Registro0175New do
     begin

        DT_ALT   := TDateTime(registro0175.DT_ALT);
        NR_CAMPO := registro0175.NR_CAMPO;
        CONT_ANT := registro0175.CONT_ANT;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0190New(const lfdHandle: PTFDHandle; const registro0190 : Bloco0Registro0190) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_0.Registro0190New do
     begin

        UNID  := registro0190.UNID;
        DESCR := registro0190.DESCR;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0200New(const lfdHandle: PTFDHandle; const registro0200 : Bloco0Registro0200) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_0.Registro0200New do
     begin

        COD_ITEM     := registro0200.COD_ITEM;
        DESCR_ITEM   := registro0200.DESCR_ITEM;
        COD_BARRA    := registro0200.COD_BARRA;
        COD_ANT_ITEM := registro0200.COD_ANT_ITEM;
        UNID_INV     := registro0200.UNID_INV;
        TIPO_ITEM    := TACBrTipoItem(registro0200.TIPO_ITEM);
        COD_NCM      := registro0200.COD_NCM;
        EX_IPI       := registro0200.EX_IPI;
        COD_GEN      := registro0200.COD_GEN;
        COD_LST      := registro0200.COD_LST;
        ALIQ_ICMS    := registro0200.ALIQ_ICMS;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0205New(const lfdHandle: PTFDHandle; const registro0205 : Bloco0Registro0205) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_0.Registro0205New do
     begin

        DESCR_ANT_ITEM := registro0205.DESCR_ANT_ITEM;
        DT_INI         := TDateTime(registro0205.DT_INI);
        DT_FIN         := TDateTime(registro0205.DT_FIN);
        COD_ANT_ITEM   := registro0205.COD_ANT_ITEM;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0206New(const lfdHandle: PTFDHandle; const registro0206 : Bloco0Registro0206) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_0.Registro0206New do
     begin

        COD_COMB := registro0206.COD_COMB;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0220New(const lfdHandle: PTFDHandle; const registro0220 : Bloco0Registro0220) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_0.Registro0220New do
     begin

          UNID_CONV := registro0220.UNID_CONV;
          FAT_CONV  := registro0220.FAT_CONV;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0300New(const lfdHandle: PTFDHandle; const registro0300 : Bloco0Registro0300) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_0.Registro0300New do
     begin
        COD_IND_BEM := registro0300.COD_IND_BEM;
        IDENT_MERC  := registro0300.IDENT_MERC;
        DESCR_ITEM  := registro0300.DESCR_ITEM;
        COD_PRNC    := registro0300.COD_PRNC;
        COD_CTA     := registro0300.COD_CTA;
        NR_PARC     := registro0300.NR_PARC;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0305New(const lfdHandle: PTFDHandle; const registro0305 : Bloco0Registro0305) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_0.Registro0305New do
     begin

        COD_CCUS  := registro0305.COD_CCUS;
        FUNC      := registro0305.FUNC;
        VIDA_UTIL := registro0305.VIDA_UTIL;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0400New(const lfdHandle: PTFDHandle; const registro0400 : Bloco0Registro0400) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_0.Registro0400New do
     begin

        COD_NAT   := registro0400.COD_NAT;
        DESCR_NAT := registro0400.DESCR_NAT;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0450New(const lfdHandle: PTFDHandle; const registro0450 : Bloco0Registro0450) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_0.Registro0450New do
     begin

        COD_INF := registro0450.COD_INF;
        TXT     := registro0450.TXT;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0460New(const lfdHandle: PTFDHandle; const registro0460 : Bloco0Registro0460) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_0.Registro0460New do
     begin

        COD_OBS := registro0460.COD_OBS;
        TXT     := registro0460.TXT;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0500New(const lfdHandle: PTFDHandle; const registro0500 : Bloco0Registro0500) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_0.Registro0500New do
     begin
          DT_ALT      := TDateTime(registro0500.DT_ALT);
          COD_NAT_CC  := registro0500.COD_NAT_CC;
          IND_CTA     := registro0500.IND_CTA;
          NIVEL       := registro0500.NIVEL;
          COD_CTA     := registro0500.COD_CTA;
          NOME_CTA    := registro0500.NOME_CTA;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0600New(const lfdHandle: PTFDHandle; const registro0600 : Bloco0Registro0600) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_0.Registro0600New do
     begin
          DT_ALT    := TDateTime(registro0600.DT_ALT);
          COD_CCUS  := registro0600.COD_CCUS;
          CCUS      := registro0600.CCUS;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_0_Registro0990_GetQTD_LIN_0(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := lfdHandle^.LFD.Bloco_0.Registro0990.QTD_LIN_0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion Bloco0}

{%region BlocoC}

Function LFD_Bloco_C_GetDT_INI(const lfdHandle: PTFDHandle; var dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtIni  := Double(lfdHandle^.LFD.Bloco_C.DT_INI);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_SetDT_INI(const lfdHandle: PTFDHandle; const dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lfdHandle^.LFD.Bloco_C.DT_INI := TDateTime(dtIni);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_GetDT_FIN(const lfdHandle: PTFDHandle; var dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtFin  := Double(lfdHandle^.LFD.Bloco_C.DT_FIN);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_SetDT_FIN(const lfdHandle: PTFDHandle; const dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lfdHandle^.LFD.Bloco_0.DT_FIN := TDateTime(dtFin);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_GetGravado(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if lfdHandle^.LFD.Bloco_0.Gravado then
     Result := 1
     else
     Result := 0;

  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC001New(const lfdHandle: PTFDHandle; const registroC001 : BlocoCRegistroC001) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC001New do
     begin
          IND_MOV:= TACBrIndicadorMovimento(registroC001.IND_MOV);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC100New(const lfdHandle: PTFDHandle; const registroC100 : BlocoCRegistroC100) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC100New do
     begin
          IND_OPER      := TACBrTipoOperacao(registroC100.IND_OPER);
          IND_EMIT      := TACBrEmitente(registroC100.IND_EMIT);
          COD_PART      := registroC100.COD_PART;
          COD_MOD       := registroC100.COD_MOD;
          COD_SIT       := TACBrSituacaoDocto(registroC100.COD_SIT);
          SER           := registroC100.SER;
          NUM_DOC       := registroC100.NUM_DOC;
          CHV_NFE       := registroC100.CHV_NFE;
          DT_DOC        := TDateTime(registroC100.DT_DOC);
          DT_E_S        := TDateTime(registroC100.DT_E_S);
          VL_DOC        := registroC100.VL_DOC;
          IND_PGTO      := TACBrTipoPagamento(registroC100.IND_PGTO);
          VL_DESC       := registroC100.VL_DESC;
          VL_ABAT_NT    := registroC100.VL_ABAT_NT;
          VL_MERC       := registroC100.VL_MERC;
          IND_FRT       := TACBrTipoFrete(registroC100.IND_FRT);
          VL_FRT        := registroC100.VL_FRT;
          VL_SEG        := registroC100.VL_SEG;
          VL_OUT_DA     := registroC100.VL_OUT_DA;
          VL_BC_ICMS    := registroC100.VL_BC_ICMS;
          VL_ICMS       := registroC100.VL_ICMS;
          VL_BC_ICMS_ST := registroC100.VL_BC_ICMS_ST;
          VL_ICMS_ST    := registroC100.VL_ICMS_ST;
          VL_IPI        := registroC100.VL_IPI;
          VL_PIS        := registroC100.VL_PIS;
          VL_COFINS     := registroC100.VL_COFINS;
          VL_PIS_ST     := registroC100.VL_PIS_ST;
          VL_COFINS_ST  := registroC100.VL_COFINS_ST;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC110New(const lfdHandle: PTFDHandle; const registroC110 : BlocoCRegistroC110) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC110New do
     begin
          COD_INF      := registroC110.COD_INF;
          TXT_COMPL    := registroC110.TXT_COMPL;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC105New(const lfdHandle: PTFDHandle; const registroC105 : BlocoCRegistroC105) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC105New do
     begin
          OPER   := TACBrTipoOperacaoST(registroC105.OPER);
          UF     := registroC105.UF;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC111New(const lfdHandle: PTFDHandle; const registroC111 : BlocoCRegistroC111) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC111New do
     begin
         NUM_PROC   := registroC111.NUM_PROC;
         IND_PROC   := TACBrOrigemProcesso(registroC111.IND_PROC);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC112New(const lfdHandle: PTFDHandle; const registroC112 : BlocoCRegistroC112) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC112New do
     begin
        COD_DA     :=   TACBrDoctoArrecada(registroC112.COD_DA);
        UF         :=   registroC112.UF;
        NUM_DA     :=   registroC112.NUM_DA;
        COD_AUT    :=   registroC112.COD_AUT;
        VL_DA      :=   registroC112.VL_DA;
        DT_VCTO    :=   TDateTime(registroC112.DT_VCTO);
        DT_PGTO    :=   TDateTime(registroC112.DT_PGTO);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC113New(const lfdHandle: PTFDHandle; const registroC113 : BlocoCRegistroC113) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC113New do
     begin
         IND_OPER   := TACBrTipoOperacao(registroC113.IND_OPER);
         IND_EMIT   := TACBrEmitente(registroC113.IND_EMIT);
         COD_PART   := registroC113.COD_PART;
         COD_MOD    := registroC113.COD_MOD;
         SER        := registroC113.SER;
         SUB        := registroC113.SUB;
         NUM_DOC    := registroC113.NUM_DOC;
         DT_DOC     := TDateTime(registroC113.DT_DOC);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC114New(const lfdHandle: PTFDHandle; const registroC114 : BlocoCRegistroC114) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC114New do
     begin
        COD_MOD   :=  registroC114.COD_MOD;
        ECF_FAB   :=  registroC114.ECF_FAB;
        ECF_CX    :=  registroC114.ECF_CX;
        NUM_DOC   :=  registroC114.NUM_DOC;
        DT_DOC    :=  TDateTime(registroC114.DT_DOC);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC115New(const lfdHandle: PTFDHandle; const registroC115 : BlocoCRegistroC115) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC115New do
     begin
        IND_CARGA     := TACBrTipoTransporte(registroC115.IND_CARGA);
        CNPJ_COL      := registroC115.CNPJ_COL;
        IE_COL        := registroC115.IE_COL;
        CPF_COL       := registroC115.CPF_COL;
        COD_MUN_COL   := registroC115.COD_MUN_COL;
        CNPJ_ENTG     := registroC115.CNPJ_ENTG;
        IE_ENTG       := registroC115.IE_ENTG;
        CPF_ENTG      := registroC115.CPF_ENTG;
        COD_MUN_ENTG  := registroC115.COD_MUN_ENTG;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC116New(const lfdHandle: PTFDHandle; const registroC116 : BlocoCRegistroC116) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC116New do
     begin
         COD_MOD   := registroC116.COD_MOD;
         NR_SAT    := registroC116.NR_SAT;
         CHV_CFE   := registroC116.CHV_CFE;
         NUM_CFE   := registroC116.NUM_CFE;
         DT_DOC    := TDateTime(registroC116.DT_DOC);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC120New(const lfdHandle: PTFDHandle; const registroC120 : BlocoCRegistroC120) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC120New do
     begin
         COD_DOC_IMP   := TACBrDoctoImporta(registroC120.COD_DOC_IMP);
         NUM_DOC__IMP  := registroC120.NUM_DOC__IMP;
         PIS_IMP       := registroC120.PIS_IMP;
         COFINS_IMP    := registroC120.COFINS_IMP;
         NUM_ACDRAW    := registroC120.NUM_ACDRAW;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC130New(const lfdHandle: PTFDHandle; const registroC130 : BlocoCRegistroC130) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC130New do
     begin
        VL_SERV_NT     := registroC130.VL_SERV_NT;
        VL_BC_ISSQN    := registroC130.VL_BC_ISSQN;
        VL_ISSQN       := registroC130.VL_ISSQN;
        VL_BC_IRRF     := registroC130.VL_BC_IRRF;
        VL_IRRF        := registroC130.VL_IRRF;
        VL_BC_PREV     := registroC130.VL_BC_PREV;
        VL_PREV        := registroC130.VL_PREV;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC140New(const lfdHandle: PTFDHandle; const registroC140 : BlocoCRegistroC140) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC140New do
     begin
          IND_EMIT   :=  TACBrEmitente(registroC140.IND_EMIT);
          IND_TIT    :=  TACBrTipoTitulo(registroC140.IND_TIT);
          DESC_TIT   :=  registroC140.DESC_TIT;
          NUM_TIT    :=  registroC140.NUM_TIT;
          QTD_PARC   :=  registroC140.QTD_PARC;
          VL_TIT     :=  registroC140.VL_TIT;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC141New(const lfdHandle: PTFDHandle; const registroC141 : BlocoCRegistroC141) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC141New do
     begin
        NUM_PARC := registroC141.NUM_PARC;
        DT_VCTO  := TDateTime(registroC141.DT_VCTO);
        VL_PARC  := registroC141.VL_PARC;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC160New(const lfdHandle: PTFDHandle; const registroC160 : BlocoCRegistroC160) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC160New do
     begin
       COD_PART   :=  registroC160.COD_PART;
       VEIC_ID    :=  registroC160.VEIC_ID;
       QTD_VOL    :=  registroC160.QTD_VOL;
       PESO_BRT   :=  registroC160.PESO_BRT;
       PESO_LIQ   :=  registroC160.PESO_LIQ;
       UF_ID      :=  registroC160.UF_ID;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC165New(const lfdHandle: PTFDHandle; const registroC165 : BlocoCRegistroC165) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC165New do
     begin
        COD_PART  := registroC165.COD_PART;
        VEIC_ID   := registroC165.VEIC_ID;
        COD_AUT   := registroC165.COD_AUT;
        NR_PASSE  := registroC165.NR_PASSE;
        HORA      := registroC165.HORA;
        TEMPER    := registroC165.TEMPER;
        QTD_VOL   := registroC165.QTD_VOL;
        PESO_BRT  := registroC165.PESO_BRT;
        PESO_LIQ  := registroC165.PESO_LIQ;
        NOM_MOT   := registroC165.NOM_MOT;
        CPF       := registroC165.CPF;
        UF_ID     := registroC165.UF_ID;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC170New(const lfdHandle: PTFDHandle; const registroC170 : BlocoCRegistroC170) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC170New do
     begin
         NUM_ITEM        := registroC170.NUM_ITEM;
         COD_ITEM        := registroC170.COD_ITEM;
         DESCR_COMPL     := registroC170.DESCR_COMPL;
         QTD             := registroC170.QTD;
         UNID            := registroC170.UNID;
         VL_ITEM         := registroC170.VL_ITEM;
         VL_DESC         := registroC170.VL_DESC;
         IND_MOV         := TACBrMovimentacaoFisica(registroC170.IND_MOV);
         CST_ICMS        := registroC170.CST_ICMS;
         CFOP            := registroC170.CFOP;
         COD_NAT         := registroC170.COD_NAT;
         VL_BC_ICMS      := registroC170.VL_BC_ICMS;
         ALIQ_ICMS       := registroC170.ALIQ_ICMS;
         VL_ICMS         := registroC170.VL_ICMS;
         VL_BC_ICMS_ST   := registroC170.VL_BC_ICMS_ST;
         ALIQ_ST         := registroC170.ALIQ_ST;
         VL_ICMS_ST      := registroC170.VL_ICMS_ST;
         IND_APUR        := TACBrApuracaoIPI(registroC170.IND_APUR);
         CST_IPI         := registroC170.CST_IPI;
         COD_ENQ         := registroC170.COD_ENQ;
         VL_BC_IPI       := registroC170.VL_BC_IPI;
         ALIQ_IPI        := registroC170.ALIQ_IPI;
         VL_IPI          := registroC170.VL_IPI;
         CST_PIS         := registroC170.CST_PIS;
         VL_BC_PIS       := registroC170.VL_BC_PIS;
         ALIQ_PIS_PERC   := registroC170.ALIQ_PIS_PERC;
         QUANT_BC_PIS    := registroC170.QUANT_BC_PIS;
         ALIQ_PIS_R      := registroC170.ALIQ_PIS_R;
         VL_PIS          := registroC170.VL_PIS;
         CST_COFINS      := registroC170.CST_COFINS;
         VL_BC_COFINS    := registroC170.VL_BC_COFINS;
         ALIQ_COFINS_PERC:= registroC170.ALIQ_COFINS_PERC;
         QUANT_BC_COFINS := registroC170.QUANT_BC_COFINS;
         ALIQ_COFINS_R   := registroC170.ALIQ_COFINS_R;
         VL_COFINS       := registroC170.VL_COFINS;
         COD_CTA         := registroC170.COD_CTA;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC171New(const lfdHandle: PTFDHandle; const registroC171 : BlocoCRegistroC171) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC171New do
     begin
          NUM_TANQUE := registroC171.NUM_TANQUE;
          QTDE       := registroC171.QTDE;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC172New(const lfdHandle: PTFDHandle; const registroC172 : BlocoCRegistroC172) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC172New do
     begin
         VL_BC_ISSQN := registroC172.VL_BC_ISSQN;
         ALIQ_ISSQN  := registroC172.ALIQ_ISSQN;
         VL_ISSQN    := registroC172.VL_ISSQN;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC173New(const lfdHandle: PTFDHandle; const registroC173 : BlocoCRegistroC173) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC173New do
     begin
        LOTE_MED   := registroC173.LOTE_MED;
        QTD_ITEM   := registroC173.QTD_ITEM;
        DT_FAB     := TDateTime(registroC173.DT_FAB);
        DT_VAL     := TDateTime(registroC173.DT_VAL);
        IND_MED    := TACBrTipoBaseMedicamento(registroC173.IND_MED);
        TP_PROD    := TACBrTipoProduto(registroC173.TP_PROD);
        VL_TAB_MAX := registroC173.VL_TAB_MAX;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC174New(const lfdHandle: PTFDHandle; const registroC174 : BlocoCRegistroC174) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC174New do
     begin
         IND_ARM      := TACBrTipoArmaFogo(registroC174.IND_ARM);
         NUM_ARM      := registroC174.NUM_ARM;
         DESCR_COMPL  := registroC174.DESCR_COMPL;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC175New(const lfdHandle: PTFDHandle; const registroC175 : BlocoCRegistroC175) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC175New do
     begin
         IND_VEIC_OPER  := TACBrTipoOperacaoVeiculo(registroC175.IND_VEIC_OPER);
         CNPJ           := registroC175.CNPJ;
         UF             := registroC175.UF;
         CHASSI_VEIC    := registroC175.CHASSI_VEIC;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC176New(const lfdHandle: PTFDHandle; const registroC176 : BlocoCRegistroC176) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC176New do
     begin
         COD_MOD_ULT_E   := registroC176.COD_MOD_ULT_E;
         NUM_DOC_ULT_E   := registroC176.NUM_DOC_ULT_E;
         SER_ULT_E       := registroC176.SER_ULT_E;
         DT_ULT_E        := TDateTime(registroC176.DT_ULT_E);
         COD_PART_ULT_E  := registroC176.COD_PART_ULT_E;
         QUANT_ULT_E     := registroC176.QUANT_ULT_E;
         VL_UNIT_ULT_E   := registroC176.VL_UNIT_ULT_E;
         VL_UNIT_BC_ST   := registroC176.VL_UNIT_BC_ST;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC177New(const lfdHandle: PTFDHandle; const registroC177 : BlocoCRegistroC177) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC177New do
     begin
         COD_SELO_IPI  := registroC177.COD_SELO_IPI;
         QT_SELO_IPI   := registroC177.QT_SELO_IPI;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC178New(const lfdHandle: PTFDHandle; const registroC178 : BlocoCRegistroC178) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC178New do
     begin
        CL_ENQ     :=  registroC178.CL_ENQ;
        VL_UNID    :=  registroC178.VL_UNID;
        QUANT_PAD  :=  registroC178.QUANT_PAD;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC179New(const lfdHandle: PTFDHandle; const registroC179 : BlocoCRegistroC179) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC179New do
     begin
         BC_ST_ORIG_DEST := registroC179.BC_ST_ORIG_DEST;
         ICMS_ST_REP     := registroC179.ICMS_ST_REP;
         ICMS_ST_COMPL   := registroC179.ICMS_ST_COMPL;
         BC_RET          := registroC179.BC_RET;
         ICMS_RET        := registroC179.ICMS_RET;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC190New(const lfdHandle: PTFDHandle; const registroC190 : BlocoCRegistroC190) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC190New do
     begin
        CST_ICMS       :=  registroC190.CST_ICMS;
        CFOP           :=  registroC190.CFOP;
        ALIQ_ICMS      :=  registroC190.ALIQ_ICMS;
        VL_OPR         :=  registroC190.VL_OPR;
        VL_BC_ICMS     :=  registroC190.VL_BC_ICMS;
        VL_ICMS        :=  registroC190.VL_ICMS;
        VL_BC_ICMS_ST  :=  registroC190.VL_BC_ICMS_ST;
        VL_ICMS_ST     :=  registroC190.VL_ICMS_ST;
        VL_RED_BC      :=  registroC190.VL_RED_BC;
        VL_IPI         :=  registroC190.VL_IPI;
        COD_OBS        :=  registroC190.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC195New(const lfdHandle: PTFDHandle; const registroC195 : BlocoCRegistroC195) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC195New do
     begin
       COD_OBS   := registroC195.COD_OBS;
       TXT_COMPL := registroC195.TXT_COMPL;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC197New(const lfdHandle: PTFDHandle; const registroC197 : BlocoCRegistroC197) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC197New do
     begin
        COD_AJ          := registroC197.COD_AJ;
        DESCR_COMPL_AJ  := registroC197.DESCR_COMPL_AJ;
        COD_ITEM        := registroC197.COD_ITEM;
        VL_BC_ICMS      := registroC197.VL_BC_ICMS;
        ALIQ_ICMS       := registroC197.ALIQ_ICMS;
        VL_ICMS         := registroC197.VL_ICMS;
        VL_OUTROS       := registroC197.VL_OUTROS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC300New(const lfdHandle: PTFDHandle; const registroC300 : BlocoCRegistroC300) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC300New do
     begin
        COD_MOD      := registroC300.COD_MOD;
        SER          := registroC300.SER;
        SUB          := registroC300.SUB;
        NUM_DOC_INI  := registroC300.NUM_DOC_INI;
        NUM_DOC_FIN  := registroC300.NUM_DOC_FIN;
        DT_DOC       := TDateTime(registroC300.DT_DOC);
        VL_DOC       := registroC300.VL_DOC;
        VL_PIS       := registroC300.VL_PIS;
        VL_COFINS    := registroC300.VL_COFINS;
        COD_CTA      := registroC300.COD_CTA;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC310New(const lfdHandle: PTFDHandle; const registroC310 : BlocoCRegistroC310) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC310New do
     begin
        NUM_DOC_CANC := registroC310.NUM_DOC_CANC;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC320New(const lfdHandle: PTFDHandle; const registroC320 : BlocoCRegistroC320) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC320New do
     begin
          CST_ICMS    := registroC320.CST_ICMS;
          CFOP        := registroC320.CFOP;
          ALIQ_ICMS   := registroC320.ALIQ_ICMS;
          VL_OPR      := registroC320.VL_OPR;
          VL_BC_ICMS  := registroC320.VL_BC_ICMS;
          VL_ICMS     := registroC320.VL_ICMS;
          VL_RED_BC   := registroC320.VL_RED_BC;
          COD_OBS     := registroC320.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC321New(const lfdHandle: PTFDHandle; const registroC321 : BlocoCRegistroC321) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC321New do
     begin
         COD_ITEM    := registroC321.COD_ITEM;
         QTD         := registroC321.QTD;
         UNID        := registroC321.UNID;
         VL_ITEM     := registroC321.VL_ITEM;
         VL_DESC     := registroC321.VL_DESC;
         VL_BC_ICMS  := registroC321.VL_BC_ICMS;
         VL_ICMS     := registroC321.VL_ICMS;
         VL_PIS      := registroC321.VL_PIS;
         VL_COFINS   := registroC321.VL_COFINS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC350New(const lfdHandle: PTFDHandle; const registroC350 : BlocoCRegistroC350) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC350New do
     begin
        SER       := registroC350.SER;
        SUB_SER   := registroC350.SUB_SER;
        NUM_DOC   := registroC350.NUM_DOC;
        DT_DOC    := TDateTime(registroC350.DT_DOC);
        CNPJ_CPF  := registroC350.CNPJ_CPF;
        VL_MERC   := registroC350.VL_MERC;
        VL_DOC    := registroC350.VL_DOC;
        VL_DESC   := registroC350.VL_DESC;
        VL_PIS    := registroC350.VL_PIS;
        VL_COFINS := registroC350.VL_COFINS;
        COD_CTA   := registroC350.COD_CTA;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC370New(const lfdHandle: PTFDHandle; const registroC370 : BlocoCRegistroC370) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC370New do
     begin
        NUM_ITEM  := registroC370.NUM_ITEM;
        COD_ITEM  := registroC370.COD_ITEM;
        QTD       := registroC370.QTD;
        UNID      := registroC370.UNID;
        VL_ITEM   := registroC370.VL_ITEM;
        VL_DESC   := registroC370.VL_DESC;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC390New(const lfdHandle: PTFDHandle; const registroC390 : BlocoCRegistroC390) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC390New do
     begin
        CST_ICMS    := registroC390.CST_ICMS;
        CFOP        := registroC390.CFOP;
        ALIQ_ICMS   := registroC390.ALIQ_ICMS;
        VL_OPR      := registroC390.VL_OPR;
        VL_BC_ICMS  := registroC390.VL_BC_ICMS;
        VL_ICMS     := registroC390.VL_ICMS;
        VL_RED_BC   := registroC390.VL_RED_BC;
        COD_OBS     := registroC390.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC400New(const lfdHandle: PTFDHandle; const registroC400 : BlocoCRegistroC400) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC400New do
     begin
        COD_MOD := registroC400.COD_MOD;
        ECF_MOD := registroC400.ECF_MOD;
        ECF_FAB := registroC400.ECF_FAB;
        ECF_CX  := registroC400.ECF_CX;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC405New(const lfdHandle: PTFDHandle; const registroC405 : BlocoCRegistroC405) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC405New do
     begin
        DT_DOC       := TDateTime(registroC405.DT_DOC);
        CRO          := registroC405.CRO;
        CRZ          := registroC405.CRZ;
        NUM_COO_FIN  := registroC405.NUM_COO_FIN;
        GT_FIN       := registroC405.GT_FIN;
        VL_BRT       := registroC405.VL_BRT;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC410New(const lfdHandle: PTFDHandle; const registroC410 : BlocoCRegistroC410) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC410New do
     begin
         VL_PIS      := registroC410.VL_PIS;
         VL_COFINS   := registroC410.VL_COFINS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC420New(const lfdHandle: PTFDHandle; const registroC420 : BlocoCRegistroC420) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC420New do
     begin
         COD_TOT_PAR   := registroC420.COD_TOT_PAR;
         VLR_ACUM_TOT  := registroC420.VLR_ACUM_TOT;
         NR_TOT        := registroC420.NR_TOT;
         DESCR_NR_TOT  := registroC420.DESCR_NR_TOT;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC425New(const lfdHandle: PTFDHandle; const registroC425 : BlocoCRegistroC425) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC425New do
     begin
        COD_ITEM  := registroC425.COD_ITEM;
        QTD       := registroC425.QTD;
        UNID      := registroC425.UNID;
        VL_ITEM   := registroC425.VL_ITEM;
        VL_PIS    := registroC425.VL_PIS;
        VL_COFINS := registroC425.VL_COFINS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC460New(const lfdHandle: PTFDHandle; const registroC460 : BlocoCRegistroC460) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC460New do
     begin
        COD_MOD   := registroC460.COD_MOD;
        COD_SIT   := TACBrSituacaoDocto(registroC460.COD_SIT);
        NUM_DOC   := registroC460.NUM_DOC;
        DT_DOC    := TDateTime(registroC460.DT_DOC);
        VL_DOC    := registroC460.VL_DOC;
        VL_PIS    := registroC460.VL_PIS;
        VL_COFINS := registroC460.VL_COFINS;
        CPF_CNPJ  := registroC460.CPF_CNPJ;
        NOM_ADQ   := registroC460.NOM_ADQ;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC470New(const lfdHandle: PTFDHandle; const registroC470 : BlocoCRegistroC470) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC470New do
     begin
        COD_ITEM   := registroC470.COD_ITEM;
        QTD        := registroC470.QTD;
        QTD_CANC   := registroC470.QTD_CANC;
        UNID       := registroC470.UNID;
        VL_ITEM    := registroC470.VL_ITEM;
        CST_ICMS   := registroC470.CST_ICMS;
        CFOP       := registroC470.CFOP;
        ALIQ_ICMS  := registroC470.ALIQ_ICMS;
        VL_PIS     := registroC470.VL_PIS;
        VL_COFINS  := registroC470.VL_COFINS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC490New(const lfdHandle: PTFDHandle; const registroC490 : BlocoCRegistroC490) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC490New do
     begin
          CST_ICMS   := registroC490.CST_ICMS;
          CFOP       := registroC490.CFOP;
          ALIQ_ICMS  := registroC490.ALIQ_ICMS;
          VL_OPR     := registroC490.VL_OPR;
          VL_BC_ICMS := registroC490.VL_BC_ICMS;
          VL_ICMS    := registroC490.VL_ICMS;
          COD_OBS    := registroC490.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC495New(const lfdHandle: PTFDHandle; const registroC495 : BlocoCRegistroC495) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC495New do
     begin
        ALIQ_ICMS   := registroC495.ALIQ_ICMS;
        COD_ITEM    := registroC495.COD_ITEM;
        QTD         := registroC495.QTD;
        QTD_CANC    := registroC495.QTD_CANC;
        UNID        := registroC495.UNID;
        VL_ITEM     := registroC495.VL_ITEM;
        VL_DESC     := registroC495.VL_DESC;
        VL_CANC     := registroC495.VL_CANC;
        VL_ACMO     := registroC495.VL_ACMO;
        VL_BC_ICMS  := registroC495.VL_BC_ICMS;
        VL_ICMS     := registroC495.VL_ICMS;
        VL_ISEN     := registroC495.VL_ISEN;
        VL_NT       := registroC495.VL_NT;
        VL_ICMS_ST  := registroC495.VL_ICMS_ST;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC500New(const lfdHandle: PTFDHandle; const registroC500 : BlocoCRegistroC500) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC500New do
     begin
          IND_OPER           :=  TACBrTipoOperacao(registroC500.IND_OPER);
          IND_EMIT           :=  TACBrEmitente(registroC500.IND_EMIT);
          COD_PART           :=  registroC500.COD_PART;
          COD_MOD            :=  registroC500.COD_MOD;
          COD_SIT            :=  TACBrSituacaoDocto(registroC500.COD_SIT);
          SER                :=  registroC500.SER;
          SUB                :=  registroC500.SUB;
          COD_CONS           :=  registroC500.COD_CONS;
          NUM_DOC            :=  registroC500.NUM_DOC;
          DT_DOC             :=  TDateTime(registroC500.DT_DOC);
          DT_E_S             :=  TDateTime(registroC500.DT_E_S);
          VL_DOC             :=  registroC500.VL_DOC;
          VL_DESC            :=  registroC500.VL_DESC;
          VL_FORN            :=  registroC500.VL_FORN;
          VL_SERV_NT         :=  registroC500.VL_SERV_NT;
          VL_TERC            :=  registroC500.VL_TERC;
          VL_DA              :=  registroC500.VL_DA;
          VL_BC_ICMS         :=  registroC500.VL_BC_ICMS;
          VL_ICMS            :=  registroC500.VL_ICMS;
          VL_BC_ICMS_ST      :=  registroC500.VL_BC_ICMS_ST;
          VL_ICMS_ST         :=  registroC500.VL_ICMS_ST;
          COD_INF            :=  registroC500.COD_INF;
          VL_PIS             :=  registroC500.VL_PIS;
          VL_COFINS          :=  registroC500.VL_COFINS;
          TP_LIGACAO         :=  TACBrTipoLigacao(registroC500.TP_LIGACAO);
          COD_GRUPO_TENSAO   :=  TACBrGrupoTensao(registroC500.COD_GRUPO_TENSAO);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC510New(const lfdHandle: PTFDHandle; const registroC510 : BlocoCRegistroC510) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC510New do
     begin
         NUM_ITEM       := registroC510.NUM_ITEM;
         COD_ITEM       := registroC510.COD_ITEM;
         COD_CLASS      := registroC510.COD_CLASS;
         QTD            := registroC510.QTD;
         UNID           := registroC510.UNID;
         VL_ITEM        := registroC510.VL_ITEM;
         VL_DESC        := registroC510.VL_DESC;
         CST_ICMS       := registroC510.CST_ICMS;
         CFOP           := registroC510.CFOP;
         VL_BC_ICMS     := registroC510.VL_BC_ICMS;
         ALIQ_ICMS      := registroC510.ALIQ_ICMS;
         VL_ICMS        := registroC510.VL_ICMS;
         VL_BC_ICMS_ST  := registroC510.VL_BC_ICMS_ST;
         ALIQ_ST        := registroC510.ALIQ_ST;
         VL_ICMS_ST     := registroC510.VL_ICMS_ST;
         IND_REC        := TACBrTipoReceita(registroC510.IND_REC);
         COD_PART       := registroC510.COD_PART;
         VL_PIS         := registroC510.VL_PIS;
         VL_COFINS      := registroC510.VL_COFINS;
         COD_CTA        := registroC510.COD_CTA;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC590New(const lfdHandle: PTFDHandle; const registroC590 : BlocoCRegistroC590) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC590New do
     begin
         CST_ICMS       := registroC590.CST_ICMS;
         CFOP           := registroC590.CFOP;
         ALIQ_ICMS      := registroC590.ALIQ_ICMS;
         VL_OPR         := registroC590.VL_OPR;
         VL_BC_ICMS     := registroC590.VL_BC_ICMS;
         VL_ICMS        := registroC590.VL_ICMS;
         VL_BC_ICMS_ST  := registroC590.VL_BC_ICMS_ST;
         VL_ICMS_ST     := registroC590.VL_ICMS_ST;
         VL_RED_BC      := registroC590.VL_RED_BC;
         COD_OBS        := registroC590.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC600New(const lfdHandle: PTFDHandle; const registroC600 : BlocoCRegistroC600) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC600New do
     begin
        COD_MOD           := registroC600.COD_MOD;
        COD_MUN           := registroC600. COD_MUN;
        SER               := registroC600.SER;
        SUB               := registroC600.SUB;
        COD_CONS          := registroC600.COD_CONS;
        QTD_CONS          := registroC600.QTD_CONS;
        QTD_CANC          := registroC600.QTD_CANC;
        DT_DOC            := TDateTime(registroC600.DT_DOC);
        VL_DOC            := registroC600.VL_DOC;
        VL_DESC           := registroC600.VL_DESC;
        CONS              := registroC600.CONS;
        VL_FORN           := registroC600.VL_FORN;
        VL_SERV_NT        := registroC600.VL_SERV_NT;
        VL_TERC           := registroC600.VL_TERC;
        VL_DA             := registroC600.VL_DA;
        VL_BC_ICMS        := registroC600.VL_BC_ICMS;
        VL_ICMS           := registroC600.VL_ICMS;
        VL_BC_ICMS_ST     := registroC600.VL_BC_ICMS_ST;
        VL_ICMS_ST        := registroC600.VL_ICMS_ST;
        VL_PIS            := registroC600.VL_PIS;
        VL_COFINS         := registroC600.VL_COFINS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC601New(const lfdHandle: PTFDHandle; const registroC601 : BlocoCRegistroC601) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC601New do
     begin
        NUM_DOC_CANC           := registroC601.NUM_DOC_CANC;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC610New(const lfdHandle: PTFDHandle; const registroC610 : BlocoCRegistroC610) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC610New do
     begin
         COD_CLASS    := registroC610.COD_CLASS;
         COD_ITEM     := registroC610.COD_ITEM;
         QTD          := registroC610.QTD;
         UNID         := registroC610.UNID;
         VL_ITEM      := registroC610.VL_ITEM;
         VL_DESC      := registroC610.VL_DESC;
         CST_ICMS     := registroC610.CST_ICMS;
         CFOP         := registroC610.CFOP;
         ALIQ_ICMS    := registroC610.ALIQ_ICMS;
         VL_BC_ICMS   := registroC610.VL_BC_ICMS;
         VL_ICMS      := registroC610.VL_ICMS;
         VL_BC_ICMS_ST:= registroC610.VL_BC_ICMS_ST;
         VL_ICMS_ST   := registroC610.VL_ICMS_ST;
         VL_PIS       := registroC610.VL_PIS;
         VL_COFINS    := registroC610.VL_COFINS;
         COD_CTA      := registroC610.COD_CTA;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC690New(const lfdHandle: PTFDHandle; const registroC690 : BlocoCRegistroC690) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC690New do
     begin
        CST_ICMS         := registroC690.CST_ICMS;
        CFOP             := registroC690.CFOP;
        ALIQ_ICMS        := registroC690.ALIQ_ICMS;
        VL_OPR           := registroC690.VL_OPR;
        VL_BC_ICMS       := registroC690.VL_BC_ICMS;
        VL_ICMS          := registroC690.VL_ICMS;
        VL_RED_BC        := registroC690.VL_RED_BC;
        VL_BC_ICMS_ST    := registroC690.VL_BC_ICMS_ST;
        VL_ICMS_ST       := registroC690.VL_ICMS_ST;
        COD_OBS          := registroC690.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC700New(const lfdHandle: PTFDHandle; const registroC700 : BlocoCRegistroC700) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC700New do
     begin
         COD_MOD        := registroC700.COD_MOD;
         SER            := registroC700.SER;
         NRO_ORD_INI    := registroC700.NRO_ORD_INI;
         NRO_ORD_FIN    := registroC700.NRO_ORD_FIN;
         DT_DOC_INI     := TDateTime(registroC700.DT_DOC_INI);
         DT_DOC_FIN     := TDateTime(registroC700.DT_DOC_FIN);
         NOM_MEST       := registroC700.NOM_MEST;
         CHV_COD_DIG    := registroC700.CHV_COD_DIG;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC790New(const lfdHandle: PTFDHandle; const registroC790 : BlocoCRegistroC790) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC790New do
     begin
        CST_ICMS         := registroC790.CST_ICMS;
        CFOP             := registroC790.CFOP;
        ALIQ_ICMS        := registroC790.ALIQ_ICMS;
        VL_OPR           := registroC790.VL_OPR;
        VL_BC_ICMS       := registroC790.VL_BC_ICMS;
        VL_ICMS          := registroC790.VL_ICMS;
        VL_BC_ICMS_ST    := registroC790.VL_BC_ICMS_ST;
        VL_ICMS_ST       := registroC790.VL_ICMS_ST;
        VL_RED_BC        := registroC790.VL_RED_BC;
        COD_OBS          := registroC790.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC791New(const lfdHandle: PTFDHandle; const registroC791 : BlocoCRegistroC791) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC791New do
     begin
       UF             := registroC791.UF;
       VL_BC_ICMS_ST  := registroC791.VL_BC_ICMS_ST;
       VL_ICMS_ST     := registroC791.VL_ICMS_ST;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC800New(const lfdHandle: PTFDHandle; const registroC800 : BlocoCRegistroC800) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC800New do
     begin
        COD_MOD        := registroC800.COD_MOD;
        COD_SIT        := TACBrSituacaoDocto(registroC800.COD_SIT);
        NUM_CFE        := registroC800.NUM_CFE;
        DT_DOC         := TDateTime(registroC800.DT_DOC);
        VL_CFE         := registroC800.VL_CFE;
        VL_PIS         := registroC800.VL_PIS;
        VL_COFINS      := registroC800.VL_COFINS;
        CNPJ_CPF       := registroC800.CNPJ_CPF;
        NR_SAT         := registroC800.NR_SAT;
        CHV_CFE        := registroC800.CHV_CFE;
        VL_DESC        := registroC800.VL_DESC;
        VL_MERC        := registroC800.VL_MERC;
        VL_OUT_DA      := registroC800.VL_OUT_DA;
        VL_ICMS        := registroC800.VL_ICMS;
        VL_PIS_ST      := registroC800.VL_PIS_ST;
        VL_COFINS_ST   := registroC800.VL_COFINS_ST;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC850New(const lfdHandle: PTFDHandle; const registroC850 : BlocoCRegistroC850) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC850New do
     begin
        CST_ICMS    := registroC850.CST_ICMS;
        CFOP        := registroC850.CFOP;
        ALIQ_ICMS   := registroC850.ALIQ_ICMS;
        VL_OPR      := registroC850.VL_OPR;
        VL_BC_ICMS  := registroC850.VL_BC_ICMS;
        VL_ICMS     := registroC850.VL_ICMS;
        COD_OBS     := registroC850.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC860New(const lfdHandle: PTFDHandle; const registroC860 : BlocoCRegistroC860) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC860New do
     begin
          COD_MOD  := registroC860.COD_MOD;
          NR_SAT   := registroC860.NR_SAT;
          DT_DOC   := TDateTime(registroC860.DT_DOC);
          DOC_INI  := registroC860.DOC_INI;
          DOC_FIN  := registroC860.DOC_FIN;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC890New(const lfdHandle: PTFDHandle; const registroC890 : BlocoCRegistroC890) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC890New do
     begin
        CST_ICMS    := registroC890.CST_ICMS;
        CFOP        := registroC890.CFOP;
        ALIQ_ICMS   := registroC890.ALIQ_ICMS;
        VL_OPR      := registroC890.VL_OPR;
        VL_BC_ICMS  := registroC890.VL_BC_ICMS;
        VL_ICMS     := registroC890.VL_ICMS;
        COD_OBS     := registroC890.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_C_RegistroC990_GetQTD_LIN_C(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := lfdHandle^.LFD.Bloco_C.RegistroC990.QTD_LIN_C;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion BlocoC}

exports

{ Create/Destroy/Erro }
LFD_Create,
LFD_Destroy,
LFD_GetUltimoErro,

{ Funções mapeando as propriedades do componente }
LFD_GetAbout, LFD_GetArquivo, LFD_SetArquivo,
LFD_GetCurMascara, LFD_SetCurMascara, LFD_GetPath,
LFD_SetPath, LFD_GetDelimitador, LFD_SetDelimitador,
LFD_GetLinhasBuffer, LFD_SetLinhasBuffer, LFD_GetTrimString,
LFD_SetTrimString, LFD_GetDT_INI, LFD_SetDT_INI,
LFD_GetDT_FIN, LFD_SetDT_FIN,

{ Methods }
LFD_SaveFileTXT, LFD_IniciaGeracao,

{ Events }
LFD_SetOnError,

{%region Bloco0}

LFD_Bloco_0_GetDT_INI, LFD_Bloco_0_SetDT_INI,
LFD_Bloco_0_GetDT_FIN, LFD_Bloco_0_SetDT_FIN,
LFD_Bloco_0_GetGravado,
LFD_Bloco_0_Registro0000New,
LFD_Bloco_0_Registro0001New,
LFD_Bloco_0_Registro0005New,
LFD_Bloco_0_Registro0015New,
LFD_Bloco_0_Registro0100New,
LFD_Bloco_0_Registro0150New,
LFD_Bloco_0_Registro0175New,
LFD_Bloco_0_Registro0190New,
LFD_Bloco_0_Registro0200New,
LFD_Bloco_0_Registro0205New,
LFD_Bloco_0_Registro0206New,
LFD_Bloco_0_Registro0220New,
LFD_Bloco_0_Registro0300New,
LFD_Bloco_0_Registro0305New,
LFD_Bloco_0_Registro0400New,
LFD_Bloco_0_Registro0450New,
LFD_Bloco_0_Registro0460New,
LFD_Bloco_0_Registro0500New,
LFD_Bloco_0_Registro0600New,
LFD_Bloco_0_Registro0990_GetQTD_LIN_0,

{%endregion Bloco0}

{%region BlocoC}

LFD_Bloco_C_GetDT_INI, LFD_Bloco_C_SetDT_INI,
LFD_Bloco_C_GetDT_FIN, LFD_Bloco_C_SetDT_FIN,
LFD_Bloco_C_GetGravado,
LFD_Bloco_C_RegistroC001New,
LFD_Bloco_C_RegistroC100New,
LFD_Bloco_C_RegistroC110New,
LFD_Bloco_C_RegistroC105New,
LFD_Bloco_C_RegistroC111New,
LFD_Bloco_C_RegistroC112New,
LFD_Bloco_C_RegistroC113New,
LFD_Bloco_C_RegistroC114New,
LFD_Bloco_C_RegistroC115New,
LFD_Bloco_C_RegistroC116New,
LFD_Bloco_C_RegistroC120New,
LFD_Bloco_C_RegistroC130New,
LFD_Bloco_C_RegistroC140New,
LFD_Bloco_C_RegistroC141New,
LFD_Bloco_C_RegistroC160New,
LFD_Bloco_C_RegistroC165New,
LFD_Bloco_C_RegistroC170New,
LFD_Bloco_C_RegistroC171New,
LFD_Bloco_C_RegistroC172New,
LFD_Bloco_C_RegistroC173New,
LFD_Bloco_C_RegistroC174New,
LFD_Bloco_C_RegistroC175New,
LFD_Bloco_C_RegistroC176New,
LFD_Bloco_C_RegistroC177New,
LFD_Bloco_C_RegistroC178New,
LFD_Bloco_C_RegistroC179New,
LFD_Bloco_C_RegistroC190New,
LFD_Bloco_C_RegistroC195New,
LFD_Bloco_C_RegistroC197New,
LFD_Bloco_C_RegistroC300New,
LFD_Bloco_C_RegistroC310New,
LFD_Bloco_C_RegistroC320New,
LFD_Bloco_C_RegistroC321New,
LFD_Bloco_C_RegistroC350New,
LFD_Bloco_C_RegistroC370New,
LFD_Bloco_C_RegistroC390New,
LFD_Bloco_C_RegistroC400New,
LFD_Bloco_C_RegistroC405New,
LFD_Bloco_C_RegistroC410New,
LFD_Bloco_C_RegistroC420New,
LFD_Bloco_C_RegistroC425New,
LFD_Bloco_C_RegistroC460New,
LFD_Bloco_C_RegistroC470New,
LFD_Bloco_C_RegistroC490New,
LFD_Bloco_C_RegistroC495New,
LFD_Bloco_C_RegistroC500New,
LFD_Bloco_C_RegistroC510New,
LFD_Bloco_C_RegistroC590New,
LFD_Bloco_C_RegistroC600New,
LFD_Bloco_C_RegistroC601New,
LFD_Bloco_C_RegistroC610New,
LFD_Bloco_C_RegistroC690New,
LFD_Bloco_C_RegistroC700New,
LFD_Bloco_C_RegistroC790New,
LFD_Bloco_C_RegistroC791New,
LFD_Bloco_C_RegistroC800New,
LFD_Bloco_C_RegistroC850New,
LFD_Bloco_C_RegistroC860New,
LFD_Bloco_C_RegistroC890New,
LFD_Bloco_C_RegistroC990_GetQTD_LIN_C

{%endregion BlocoC}

end.

