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
DESTRÓI o objeto TACBrLFD e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function LFD_Destroy(lfdHandle: PTFDHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
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

Function LFD_SaveFileTXT(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
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
     COD_CONTEUDO  := TACBrConteudoArquivo(registro0000.COD_CONTEUDO);
     FANTASIA      := registro0000.FANTASIA;
     NIRE          := registro0000.NIRE;
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
          COD_MUN:= registro0001.COD_MUN;
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
       NOMERESP     := registro0005.NOMERESP;
       COD_ASS      := registro0005.COD_ASS;
       CPFRESP      := registro0005.CPFRESP;
       CEP          := registro0005.CEP;
       ENDERECO     := registro0005.ENDERECO;
       NUM          := registro0005.NUM;
       COMPL        := registro0005.COMPL;
       BAIRRO       := registro0005.BAIRRO;
       CEP_CP       := registro0005.CEP_CP;
       CP           := registro0005.CP;
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

Function LFD_Bloco_0_Registro0025New(const lfdHandle: PTFDHandle; const registro0025 : Bloco0Registro0025) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_0.Registro0025New do
     begin
        CODBF_ICMS := TACBrCODBFICMS(registro0025.CODBF_ICMS);
        CODBF_ISS := TACBrCODBFISS(registro0025.CODBF_ISS);
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
       CEP_CF     := registro0100.CEP_CP;
       CP         := registro0100.CP;
       ENDERECO   := registro0100.ENDERECO;
       NUM        := registro0100.NUM;
       COMPL      := registro0100.COMPL;
       BAIRRO     := registro0100.BAIRRO;
       UF         := registro0100.UF;
       FONE       := registro0100.FONE;
       FAX        := registro0100.FAX;
       EMAIL      := registro0100.EMAIL;
       COD_MUN    := registro0100.COD_MUN;
       COD_ASS    :=  registro0100.COD_ASS[0];
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
     IE_ST       := registro0150.IE_ST;
     IE          := registro0150.IE;
     IM          := registro0150.IM;
     COD_MUN     := registro0150.COD_MUN;
     SUFRAMA     := registro0150.SUFRAMA;
     ENDERECO    := registro0150.ENDERECO;
     NUM         := registro0150.NUM;
     COMPL       := registro0150.COMPL;
     BAIRRO      := registro0150.BAIRRO;
     UF          := registro0150.UF;

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
         CEP        := registro0175.CEP;
         ENDERECO   := registro0175.ENDERECO;
         NUM        := registro0175.NUM;
         COMPL      := registro0175.COMPL;
         BAIRRO     := registro0175.BAIRRO;
         CEP_CP     := registro0175.CEP_CP;
         CP         := registro0175.CP;
         FONE       := registro0175.FONE;
         FAX        := registro0175.FAX;
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
        COD_GEN      := registro0200.COD_GEN;
        COD_LST      := registro0200.COD_LST;

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

Function LFD_Bloco_0_Registro0210New(const lfdHandle: PTFDHandle; const registro0210 : Bloco0Registro0210) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_0.Registro0210New do
     begin
        UNID_ITEM 	  := registro0210.UNID_ITEM;
	COD_ITEM_COMP     := registro0210.COD_ITEM_COMP;
	QTD_COMP	  := registro0210.QTD_COMP;
	UNID_COMP 	  := registro0210.UNID_COMP;
	PERDA_COMP	  := registro0210.PERDA_COMP;
	DT_INI_COMP	  := registro0210.DT_INI_COMP;
	DT_FIN_COMP 	  := registro0210.DT_FIN_COMP;
	IND_ALT 	  := TACBrIndAlteracao(registro0210.IND_ALT);
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

{%region BlocoA}

Function LFD_Bloco_A_GetDT_INI(const lfdHandle: PTFDHandle; var dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtIni  := Double(lfdHandle^.LFD.Bloco_A.DT_INI);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_A_SetDT_INI(const lfdHandle: PTFDHandle; const dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lfdHandle^.LFD.Bloco_A.DT_INI := TDateTime(dtIni);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_A_GetDT_FIN(const lfdHandle: PTFDHandle; var dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtFin  := Double(lfdHandle^.LFD.Bloco_A.DT_FIN);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_A_SetDT_FIN(const lfdHandle: PTFDHandle; const dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lfdHandle^.LFD.Bloco_A.DT_FIN := TDateTime(dtFin);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_A_GetGravado(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if lfdHandle^.LFD.Bloco_A.Gravado then
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

Function LFD_Bloco_A_RegistroA001New(const lfdHandle: PTFDHandle; const registroA001 : BlocoARegistroA001) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_A.RegistroA001New do
     begin
          IND_MOV:= TACBrLIndicadorMovimento(registroA001.IND_MOV);
          COD_MUN:= registroA001.COD_MUN;
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

Function LFD_Bloco_A_RegistroA350New(const lfdHandle: PTFDHandle; const registroA350 : BlocoARegistroA350) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_A.RegistroA350New do
     begin
        CPF_CONS        := registroA350.CPF_CONS;
        CNPJ_CONS       := registroA350.CNPJ_CONS;
        COD_MOD         := registroA350.COD_MOD;
        COD_SIT         := TACBrlSituacaoDocto(registroA350.COD_SIT);
        ECF_CX          := registroA350.ECF_CX;
        ECF_FAB         := registroA350.ECF_FAB;
        CRO             := registroA350.CRO;
        CRZ             := registroA350.CRZ;
        NUM_DOC         := registroA350.NUM_DOC;
        DT_DOC          := registroA350.DT_DOC;
        COP             := registroA350.COP;
        VL_DOC          := registroA350.VL_DOC;
        VL_CANC_ISS     := registroA350.VL_CANC_ISS;
        VL_CANC_ICMS    := registroA350.VL_CANC_ICMS;
        VL_DESC_ISS     := registroA350.VL_DESC_ISS;
        VL_DESC_ICMS    := registroA350.VL_DESC_ICMS;
        VL_ACMO_ISS     := registroA350.VL_ACMO_ISS;
        VL_ACMO_ICMS    := registroA350.VL_ACMO_ICMS;
        VL_BC_ISS       := registroA350.VL_BC_ISS;
        VL_ISS          := registroA350.VL_ISS;
        VL_ISN_ISS      := registroA350.VL_ISN_ISS;
        VL_NT_ISS       := registroA350.VL_NT_ISS;
        VL_RET_ISS      := registroA350.VL_RET_ISS;
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

Function LFD_Bloco_A_RegistroA360New(const lfdHandle: PTFDHandle; const registroA360 : BlocoARegistroA360) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_A.RegistroA360New do
     begin
        NUM_ITEM      := registroA360.NUM_ITEM;
        COD_ITEM      := registroA360.COD_ITEM;
        UNID          := registroA360.UNID;
        VL_UNIT       := registroA360.VL_UNIT;
        QTD           := registroA360.QTD;
        QTDCANC       := registroA360.QTDCANC;
        VL_DESC_I     := registroA360.VL_DESC_I;
        VL_ACMO_I     := registroA360.VL_ACMO_I;
        VL_CANC_I     := registroA360.VL_CANC_I;
        VL_ITEM       := registroA360.VL_ITEM;
        CTISS         := registroA360.CTISS;
        VL_BC_ISS_I   := registroA360.VL_BC_ISS_I;
        ALIQ_ISS      := registroA360.ALIQ_ISS;
        VL_ISS_I      := registroA360.VL_ISS_I;
        VL_ISN_ISS_I  := registroA360.VL_ISN_ISS_I;
        VL_NT_ISS_I   := registroA360.VL_NT_ISS_I;
        VL_RT_ISS_I   := registroA360.VL_RT_ISS_I;
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
Function LFD_Bloco_A_RegistroA990_GetQTD_LIN_A(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := lfdHandle^.LFD.Bloco_A.RegistroA990.QTD_LIN_A;
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
          IND_MOV:= TACBrLIndicadorMovimento(registroC001.IND_MOV);
          COD_MUN:= registroC001.COD_MUN;
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

Function LFD_Bloco_C_RegistroC020New(const lfdHandle: PTFDHandle; const registroC020 : BlocoCRegistroC020) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC020New do
     begin
        IND_OPER    := TACBrlTipoOperacao(registroC020.IND_OPER);
        IND_EMIT    := TACBrlEmitente(registroC020.IND_EMIT);
        COD_PART    := registroC020.COD_PART;
        COD_MOD     := registroC020.COD_MOD;
        COD_SIT     := TACBrlSituacaoDocto(registroC020.COD_SIT);
        SER         := registroC020.SER;
        NUM_DOC     := registroC020.NUM_DOC;
        CHV_NFE     := registroC020.CHV_NFE;
        DT_EMIS     := TDateTime(registroC020.DT_EMIS);
        DT_DOC      := TDateTime(registroC020.DT_DOC);
        COD_NAT     := registroC020.COD_NAT;
        IND_PGTO    := TACBrlTipoPagamento(registroC020.IND_PGTO);
        VL_DOC      := registroC020.VL_DOC;
        VL_DESC     := registroC020.VL_DESC;
        VL_ACMO     := registroC020.VL_ACMO;
        VL_MERC     := registroC020.VL_MERC;
        IND_FRT     := TACBrTipoFrete(registroC020.IND_FRT);
        VL_FRT      := registroC020.VL_FRT;
        VL_SEG      := registroC020.VL_SEG;
        VL_OUT_DA   := registroC020.VL_OUT_DA;
        VL_BC_ICMS  := registroC020.VL_BC_ICMS;
        VL_ICMS     := registroC020.VL_ICMS;
        VL_BC_ST    := registroC020.VL_BC_ST;
        VL_ICMS_ST  := registroC020.VL_ICMS_ST;
        VL_AT       := registroC020.VL_AT;
        VL_IPI      := registroC020.VL_IPI;
        COD_INF_OBS := registroC020.COD_INF_OBS;
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

Function LFD_Bloco_C_RegistroC550New(const lfdHandle: PTFDHandle; const registroC550 : BlocoCRegistroC550) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC550New do
     begin
        CPF_CONS   := registroC550.CPF_CONS;
        CNPJ_CONS  := registroC550.CNPJ_CONS;
        COD_MOD    := registroC550.COD_MOD;
        COD_SIT    := TACBrlSituacaoDocto(registroC550.COD_SIT);
        SER        := registroC550.SER;
        SUB        := registroC550.SUB;
        NUM_DOC    := registroC550.NUM_DOC;
        DT_DOC     := registroC550.DT_DOC;
        COP        := registroC550.COP;
        VL_DOC     := registroC550.VL_DOC;
        VL_DESC    := registroC550.VL_DESC;
        VL_ACMO    := registroC550.VL_ACMO;
        VL_MERC    := registroC550.VL_MERC;
        VL_BC_ICMS := registroC550.VL_BC_ICMS;
        VL_ICMS    := registroC550.VL_ICMS;
        COD_INF_OBS:= registroC550.COD_INF_OBS;
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

Function LFD_Bloco_C_RegistroC555New(const lfdHandle: PTFDHandle; const registroC555 : BlocoCRegistroC555) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC555New do
     begin
        NUM_ITEM      := registroC555.NUM_ITEM;
        COD_ITEM      := registroC555.COD_ITEM;
        UNID          := registroC555.UNID;
        VL_UNIT       := registroC555.VL_UNIT;
        QTD           := registroC555.QTD;
        VL_DESC_I     := registroC555.VL_DESC_I;
        VL_ACMO_I     := registroC555.VL_ACMO_I;
        VL_ITEM       := registroC555.VL_ITEM;
        CST           := registroC555.CST;
        CFOP          := registroC555.CFOP;
        VL_BC_ICMS_I  := registroC555.VL_BC_ICMS_I;
        ALIQ_ICMS     := registroC555.ALIQ_ICMS;
        VL_ICMS_I     := registroC555.VL_ICMS_I;
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
        CPF_CONS       := registroC600.CPF_CONS;
        CNPJ_CONS      := registroC600.CNPJ_CONS;
        COD_MOD        := registroC600.COD_MOD;
        COD_SIT        := TACBrlSituacaoDocto(registroC600.COD_SIT);
        ECF_CX         := registroC600.ECF_CX;
        ECF_FAB        := registroC600.ECF_FAB;
        CRO            := registroC600.CRO;
        CRZ            := registroC600.CRZ;
        NUM_DOC        := registroC600.NUM_DOC;
        DT_DOC         := registroC600.DT_DOC;
        COP            := registroC600.COP;
        VL_DOC         := registroC600.VL_DOC;
        VL_CANC_ICMS   := registroC600.VL_CANC_ICMS;
        VL_DESC_ICMS   := registroC600.VL_DESC_ICMS;
        VL_ACMO_ICMS   := registroC600.VL_ACMO_ICMS;
        VL_CANC_ISS    := registroC600.VL_CANC_ISS;
        VL_DESC_ISS    := registroC600.VL_DESC_ISS;
        VL_ACMO_ISS    := registroC600.VL_ACMO_ISS;
        VL_BC_ICMS     := registroC600.VL_BC_ICMS;
        VL_ICMS        := registroC600.VL_ICMS;
        VL_ISN         := registroC600.VL_ISN;
        VL_NT          := registroC600.VL_NT;
        VL_ST          := registroC600.VL_ST;
        VL_ISS         := registroC600.VL_ISS;
        VL_ICMS_ST     := registroC600.VL_ICMS_ST;
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

Function LFD_Bloco_C_RegistroC605New(const lfdHandle: PTFDHandle; const registroC605 : BlocoCRegistroC605) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with lfdHandle^.LFD.Bloco_C.RegistroC605New do
     begin
        NUM_ITEM      := registroC605.NUM_ITEM;
        COD_ITEM      := registroC605.COD_ITEM;
        UNID          := registroC605.UNID;
        VL_UNIT       := registroC605.VL_UNIT;
        QTD           := registroC605.QTD;
        QTD_CANC_I    := registroC605.QTD_CANC_I;
        VL_ITEM       := registroC605.VL_ITEM;
        VL_DESC_I     := registroC605.VL_DESC_I;
        VL_CANC_I     := registroC605.VL_CANC_I;
        VL_ACMO_I     := registroC605.VL_ACMO_I;
        VL_ISS        := registroC605.VL_ISS;
        CST           := registroC605.CST;
        CFOP          := registroC605.CFOP;
        VL_BC_ICMS_I  := registroC605.VL_BC_ICMS_I;
        ALIQ_ICMS     := registroC605.ALIQ_ICMS;
        VL_ICMS_I     := registroC605.VL_ICMS_I;
        VL_ISN_I      := registroC605.VL_ISN_I;
        VL_NT_I       := registroC605.VL_NT_I;
        VL_ST_I       := registroC605.VL_ST_I;
        VL_ICMS_ST_I  := registroC605.VL_ICMS_ST_I;
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


{%region Bloco9}

Function LFD_Bloco_9_GetDT_INI(const lfdHandle: PTFDHandle; var dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtIni  := Double(lfdHandle^.LFD.Bloco_9.DT_INI);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_9_SetDT_INI(const lfdHandle: PTFDHandle; const dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lfdHandle^.LFD.Bloco_9.DT_INI := TDateTime(dtIni);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_9_GetDT_FIN(const lfdHandle: PTFDHandle; var dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtFin  := Double(lfdHandle^.LFD.Bloco_9.DT_FIN);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_9_SetDT_FIN(const lfdHandle: PTFDHandle; const dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     lfdHandle^.LFD.Bloco_9.DT_FIN := TDateTime(dtFin);
     Result := 0;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_9_GetGravado(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if lfdHandle^.LFD.Bloco_9.Gravado then
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

Function LFD_Bloco_9_Registro9001New(const lfdHandle: PTFDHandle; const registro9001 : Bloco9Registro9001) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_9.Registro9001 do
     BEGIN
          IND_MOV := TACBrLIndicadorMovimento(registro9001.IND_MOV);
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

Function LFD_Bloco_9_Registro9900New(const lfdHandle: PTFDHandle; const registro9900 : Bloco9Registro9900) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with lfdHandle^.LFD.Bloco_9.Registro9900.New do
     BEGIN
          REG_BLC := registro9900.REG_BLC;
          QTD_REG_BLC := registro9900.QTD_REG_BLC;
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

Function LFD_Bloco_9_Registro9990_GetQTD_LIN_9(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := lfdHandle^.LFD.Bloco_9.Registro9990.QTD_LIN_9;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function LFD_Bloco_9_Registro9999_GetQTD_LIN(const lfdHandle: PTFDHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (lfdHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := lfdHandle^.LFD.Bloco_9.Registro9999.QTD_LIN;
  except
     on exception : Exception do
     begin
        lfdHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion Bloco9}

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
LFD_Bloco_0_Registro0025New,
LFD_Bloco_0_Registro0100New,
LFD_Bloco_0_Registro0150New,
LFD_Bloco_0_Registro0175New,
LFD_Bloco_0_Registro0200New,
LFD_Bloco_0_Registro0205New,
LFD_Bloco_0_Registro0210New,
LFD_Bloco_0_Registro0990_GetQTD_LIN_0,

{%endregion Bloco0}


{%region BlocoA}

LFD_Bloco_A_GetDT_INI, LFD_Bloco_A_SetDT_INI,
LFD_Bloco_A_GetDT_FIN, LFD_Bloco_A_SetDT_FIN,
LFD_Bloco_A_GetGravado,
LFD_Bloco_A_RegistroA001New,
LFD_Bloco_A_RegistroA350New,
LFD_Bloco_A_RegistroA360New,
LFD_Bloco_A_RegistroA990_GetQTD_LIN_A,

{%endregion BlocoA}


{%region BlocoC}

LFD_Bloco_C_GetDT_INI, LFD_Bloco_C_SetDT_INI,
LFD_Bloco_C_GetDT_FIN, LFD_Bloco_C_SetDT_FIN,
LFD_Bloco_C_GetGravado,
LFD_Bloco_C_RegistroC001New,
LFD_Bloco_C_RegistroC020New,
LFD_Bloco_C_RegistroC550New,
LFD_Bloco_C_RegistroC555New,
LFD_Bloco_C_RegistroC600New,
LFD_Bloco_C_RegistroC605New,
LFD_Bloco_C_RegistroC990_GetQTD_LIN_C,

{%endregion BlocoC}

{%region Bloco9}

LFD_Bloco_9_GetDT_INI, LFD_Bloco_9_SetDT_INI,
LFD_Bloco_9_GetDT_FIN, LFD_Bloco_9_SetDT_FIN,
LFD_Bloco_9_GetGravado,
LFD_Bloco_9_Registro9001New,
LFD_Bloco_9_Registro9900New,
LFD_Bloco_9_Registro9990_GetQTD_LIN_9,
LFD_Bloco_9_Registro9999_GetQTD_LIN;

{%endregion Bloco9}


end.

