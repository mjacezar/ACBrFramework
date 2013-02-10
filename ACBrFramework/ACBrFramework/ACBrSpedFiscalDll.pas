unit ACBrSpedFiscaldll;

interface

uses
  Classes,
  SysUtils,
  ACBrSpedDll,
  ACBrSpedFiscal,
  ACBrEFDBlocos,
  ACBrEFDBloco_0;

{Classe que armazena os EventHandlers para o componente ACBr}
type TEventHandlers = class
end;

{Handle para o componente TACBrSPEDFiscal}
type TSPDFHandle = record
  UltimoErro : String;
  SPEDFiscal : TACBrSPEDFiscal;
  EventHandlers : TEventHandlers;
end;

{Ponteiro para o Handle }
type PSPDFHandle = ^TSPDFHandle;


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
CRIA um novo componente TACBrSPEDFiscal retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrPAF.
}
Function SPDF_Create(var spdfHandle: PSPDFHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try
     New(spdfHandle);
     spdfHandle^.SPEDFiscal := TACBrSPEDFiscal.Create(nil);
     spdfHandle^.EventHandlers := TEventHandlers.Create();
     spdfHandle^.UltimoErro:= '';
     Result := 0;
  except
     on exception : Exception do
     begin
        Result := -1;
        spdfHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrSPEDFiscal e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function SPDF_Destroy(var spdfHandle: PSPDFHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
    spdfHandle^.SPEDFiscal.Destroy();
    spdfHandle^.SPEDFiscal := nil;

    Dispose(spdfHandle);
    spdfHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        spdfHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function SPDF_GetUltimoErro(const spdfHandle: PSPDFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, spdfHandle^.UltimoErro, BufferLen);
     Result := length(spdfHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Funções mapeando as propriedades do componente }

Function SPDF_GetAbout(const spdfHandle: PSPDFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := spdfHandle^.SPEDFiscal.About;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_GetArquivo(const spdfHandle: PSPDFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := spdfHandle^.SPEDFiscal.Arquivo;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_SetArquivo(const spdfHandle: PSPDFHandle; Const Arquivo : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     spdfHandle^.SPEDFiscal.Arquivo := Arquivo;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_GetCurMascara(const spdfHandle: PSPDFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := spdfHandle^.SPEDFiscal.CurMascara;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_SetCurMascara(const spdfHandle: PSPDFHandle; Const CurMascara : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     spdfHandle^.SPEDFiscal.CurMascara := CurMascara;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_GetPath(const spdfHandle: PSPDFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := spdfHandle^.SPEDFiscal.Path;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_SetPath(const spdfHandle: PSPDFHandle; Const Path : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     spdfHandle^.SPEDFiscal.Path := Path;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_GetDelimitador(const spdfHandle: PSPDFHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := spdfHandle^.SPEDFiscal.Delimitador;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_SetDelimitador(const spdfHandle: PSPDFHandle; Const Delimitador : pChar) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     spdfHandle^.SPEDFiscal.Delimitador := Delimitador;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function SPDF_GetLinhasBuffer(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := spdfHandle^.SPEDFiscal.LinhasBuffer;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_SetLinhasBuffer(const spdfHandle: PSPDFHandle; const Linhas: Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.LinhasBuffer := Linhas;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_GetTrimString(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if spdfHandle^.SPEDFiscal.TrimString then
      Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_SetTrimString(const spdfHandle: PSPDFHandle; const TrimString: Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.TrimString := TrimString;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

 {%region Funções mapeando as propriedades do componente não visiveis}

Function SPDF_GetDT_INI(const spdfHandle: PSPDFHandle; var Data : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Data := Double(spdfHandle^.SPEDFiscal.DT_INI);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_SetDT_INI(const spdfHandle: PSPDFHandle; const Data : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.DT_INI := Data;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_GetDT_FIN(const spdfHandle: PSPDFHandle; var Data : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Data := Double(spdfHandle^.SPEDFiscal.DT_FIN);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_SetDT_FIN(const spdfHandle: PSPDFHandle; const Data : Double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.DT_FIN := Data;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Methods }

Function SPDF_IniciaGeracao(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.IniciaGeracao;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Bloco0}

Function SPDF_Bloco_0_GetDT_INI(const spdfHandle: PSPDFHandle; var dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtIni  := Double(spdfHandle^.SPEDFiscal.Bloco_0.DT_INI);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_SetDT_INI(const spdfHandle: PSPDFHandle; const dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.Bloco_0.DT_INI := TDateTime(dtIni);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_GetDT_FIN(const spdfHandle: PSPDFHandle; var dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtFin  := Double(spdfHandle^.SPEDFiscal.Bloco_0.DT_FIN);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_SetDT_FIN(const spdfHandle: PSPDFHandle; const dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.Bloco_0.DT_FIN := TDateTime(dtFin);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_GetGravado(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if spdfHandle^.SPEDFiscal.Bloco_0.Gravado then
     Result := 1
     else
     Result := 0;

  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0000New(const spdfHandle: PSPDFHandle; const registro0000 : Bloco0Registro0000) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0000New do
     BEGIN

     COD_VER       := TACBrVersaoLeiaute(registro0000.COD_VER);
     COD_FIN       := TACBrCodFinalidade(registro0000.COD_FIN);
     DT_INI        := TDateTime(registro0000.DT_INI);
     DT_FIN        := TDateTime(registro0000.DT_FIN);
     NOME          := registro0000.NOME;
     CNPJ          := registro0000.CNPJ;
     CPF           := registro0000.CNPJ;
     UF            := registro0000.UF;
     IE            := registro0000.IE;
     COD_MUN       := registro0000.COD_MUN;
     IM            := registro0000.IM;
     SUFRAMA       := registro0000.SUFRAMA;
     IND_PERFIL    := TACBrPerfil(registro0000.IND_PERFIL);
     IND_ATIV      := TACBrAtividade(registro0000.IND_ATIV);

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0001New(const spdfHandle: PSPDFHandle; const registro0001 : Bloco0Registro0001) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0001New do
     begin
          IND_MOV:= TACBrIndicadorMovimento(registro0001.IND_MOV);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0005New(const spdfHandle: PSPDFHandle; const registro0005 : Bloco0Registro0005) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0005New do
     begin

       FANTASIA     := registro0005.FANTASIA;
       CEP          := registro0005.FANTASIA;
       ENDERECO     := registro0005.FANTASIA;
       NUM          := registro0005.FANTASIA;
       COMPL        := registro0005.FANTASIA;
       BAIRRO       := registro0005.FANTASIA;
       FONE         := registro0005.FANTASIA;
       FAX          := registro0005.FANTASIA;
       EMAIL        := registro0005.FANTASIA;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0015New(const spdfHandle: PSPDFHandle; const registro0015 : Bloco0Registro0015) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0015New do
     begin

        UF_ST   := registro0015.UF_ST;
        IE_ST   := registro0015.IE_ST;

     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0100New(const spdfHandle: PSPDFHandle; const registro0100 : Bloco0Registro0100) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0100New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0150New(const spdfHandle: PSPDFHandle; const registro0150 : Bloco0Registro0150) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0150New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0175New(const spdfHandle: PSPDFHandle; const registro0175 : Bloco0Registro0175) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0175New do
     begin

        DT_ALT   := TDateTime(registro0175.DT_ALT);
        NR_CAMPO := registro0175.NR_CAMPO;
        CONT_ANT := registro0175.CONT_ANT;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0190New(const spdfHandle: PSPDFHandle; const registro0190 : Bloco0Registro0190) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0190New do
     begin

        UNID  := registro0190.UNID;
        DESCR := registro0190.DESCR;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0200New(const spdfHandle: PSPDFHandle; const registro0200 : Bloco0Registro0200) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0200New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0205New(const spdfHandle: PSPDFHandle; const registro0205 : Bloco0Registro0205) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0205New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0206New(const spdfHandle: PSPDFHandle; const registro0206 : Bloco0Registro0206) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0206New do
     begin

        COD_COMB := registro0206.COD_COMB;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0220New(const spdfHandle: PSPDFHandle; const registro0220 : Bloco0Registro0220) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0220New do
     begin

          UNID_CONV := registro0220.UNID_CONV;
          FAT_CONV  := registro0220.FAT_CONV;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0300New(const spdfHandle: PSPDFHandle; const registro0300 : Bloco0Registro0300) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0300New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0305New(const spdfHandle: PSPDFHandle; const registro0305 : Bloco0Registro0305) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0305New do
     begin

        COD_CCUS  := registro0305.COD_CCUS;
        FUNC      := registro0305.FUNC;
        VIDA_UTIL := registro0305.VIDA_UTIL;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0400New(const spdfHandle: PSPDFHandle; const registro0400 : Bloco0Registro0400) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0400New do
     begin

        COD_NAT   := registro0400.COD_NAT;
        DESCR_NAT := registro0400.DESCR_NAT;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0450New(const spdfHandle: PSPDFHandle; const registro0450 : Bloco0Registro0450) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0450New do
     begin

        COD_INF := registro0450.COD_INF;
        TXT     := registro0450.TXT;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0460New(const spdfHandle: PSPDFHandle; const registro0460 : Bloco0Registro0460) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0460New do
     begin

        COD_OBS := registro0460.COD_OBS;
        TXT     := registro0460.TXT;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0500New(const spdfHandle: PSPDFHandle; const registro0500 : Bloco0Registro0500) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0500New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0600New(const spdfHandle: PSPDFHandle; const registro0600 : Bloco0Registro0600) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_0.Registro0600New do
     begin
          DT_ALT    := TDateTime(registro0600.DT_ALT);
          COD_CCUS  := registro0600.COD_CCUS;
          CCUS      := registro0600.CCUS;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_0_Registro0990_GetQTD_LIN_0(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := spdfHandle^.SPEDFiscal.Bloco_0.Registro0990.QTD_LIN_0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion Bloco0}

{%region Bloco1}

Function SPDF_Bloco_1_GetDT_INI(const spdfHandle: PSPDFHandle; var dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtIni  := Double(spdfHandle^.SPEDFiscal.Bloco_1.DT_INI);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_SetDT_INI(const spdfHandle: PSPDFHandle; const dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.Bloco_1.DT_INI := TDateTime(dtIni);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_GetDT_FIN(const spdfHandle: PSPDFHandle; var dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtFin  := Double(spdfHandle^.SPEDFiscal.Bloco_1.DT_FIN);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_SetDT_FIN(const spdfHandle: PSPDFHandle; const dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.Bloco_1.DT_FIN := TDateTime(dtFin);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_GetGravado(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if spdfHandle^.SPEDFiscal.Bloco_1.Gravado then
     Result := 1
     else
     Result := 0;

  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1001New(const spdfHandle: PSPDFHandle; const registro1001 : Bloco1Registro1001) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1001New do
     BEGIN
          IND_MOV := TACBrIndicadorMovimento(registro1001.IND_MOV);
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1010New(const spdfHandle: PSPDFHandle; const registro1010 : Bloco1Registro1010) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1010New do
     BEGIN

     IND_EXP    := registro1010.IND_EXP;
     IND_CCRF   := registro1010.IND_CCRF;
     IND_COMB   := registro1010.IND_COMB;
     IND_USINA  := registro1010.IND_USINA;
     IND_VA     := registro1010.IND_VA;
     IND_EE     := registro1010.IND_EE;
     IND_CART   := registro1010.IND_CART;
     IND_FORM   := registro1010.IND_FORM;
     IND_AER    := registro1010.IND_AER;

     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1100New(const spdfHandle: PSPDFHandle; const registro1100 : Bloco1Registro1100) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1100New do
     BEGIN
          IND_DOC   := TACBrTipoDocto(registro1100.IND_DOC);
          NRO_DE    := registro1100.NRO_DE;
          DT_DE     := TDateTime(registro1100.DT_DE);
          NAT_EXP   := TACBrExportacao(registro1100.NAT_EXP);
          NRO_RE    := registro1100.NRO_RE;
          DT_RE     := TDateTime(registro1100.DT_RE);
          CHC_EMB   := registro1100.CHC_EMB;
          DT_CHC    := TDateTime(registro1100.DT_CHC);
          DT_AVB    := TDateTime(registro1100.DT_AVB);
          TP_CHC    := TACBrConhecEmbarque(registro1100.TP_CHC);
          PAIS      := registro1100.PAIS;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1105New(const spdfHandle: PSPDFHandle; const registro1105 : Bloco1Registro1105) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1105New do
     BEGIN
          COD_MOD   := registro1105.COD_MOD;
          SERIE     := registro1105.SERIE;
          NUM_DOC   := registro1105.NUM_DOC;
          CHV_NFE   := registro1105.CHV_NFE;
          DT_DOC    := TDateTime(registro1105.DT_DOC);
          COD_ITEM  := registro1105.COD_ITEM;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1110New(const spdfHandle: PSPDFHandle; const registro1110 : Bloco1Registro1110) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1110New do
     BEGIN
          COD_PART  := registro1110.COD_PART;
          COD_MOD   := registro1110.COD_MOD;
          SER       := registro1110.SER;
          NUM_DOC   := registro1110.NUM_DOC;
          DT_DOC    := TDateTime(registro1110.DT_DOC);
          CHV_NFE   := registro1110.CHV_NFE;
          NR_MEMO   := registro1110.NR_MEMO;
          QTD       := registro1110.QTD;
          UNID      := registro1110.UNID;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1200New(const spdfHandle: PSPDFHandle; const registro1200 : Bloco1Registro1200) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1200New do
     BEGIN
          COD_AJ_APUR   := registro1200.COD_AJ_APUR;
          SLD_CRED      := registro1200.SLD_CRED;
          CRED_APR      := registro1200.CRED_APR;
          CRED_RECEB    := registro1200.CRED_RECEB;
          CRED_UTIL     := registro1200.CRED_UTIL;
          SLD_CRED_FIM  := registro1200.SLD_CRED_FIM;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1210New(const spdfHandle: PSPDFHandle; const registro1210 : Bloco1Registro1210) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1210New do
     BEGIN
          TIPO_UTIL     := registro1210.TIPO_UTIL;
          NR_DOC        := registro1210.NR_DOC;
          VL_CRED_UTIL  := registro1210.VL_CRED_UTIL;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1300New(const spdfHandle: PSPDFHandle; const registro1300 : Bloco1Registro1300) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1300New do
     BEGIN
          COD_ITEM      := registro1300.COD_ITEM;
          DT_FECH       := TDateTime(registro1300.DT_FECH);
          ESTQ_ABERT    := registro1300.ESTQ_ABERT;
          VOL_ENTR      := registro1300.VOL_ENTR;
          VOL_DISP      := registro1300.VOL_DISP;
          VOL_SAIDAS    := registro1300.VOL_SAIDAS;
          ESTQ_ESCR     := registro1300.ESTQ_ESCR;
          VAL_AJ_PERDA  := registro1300.VAL_AJ_PERDA;
          VAL_AJ_GANHO  := registro1300.VAL_AJ_GANHO;
          FECH_FISICO   := registro1300.FECH_FISICO;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1310New(const spdfHandle: PSPDFHandle; const registro1310 : Bloco1Registro1310) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1310New do
     BEGIN
          NUM_TANQUE     := registro1310.NUM_TANQUE;
          ESTQ_ABERT     := registro1310.ESTQ_ABERT;
          VOL_ENTR       := registro1310.VOL_ENTR;
          VOL_DISP       := registro1310.VOL_DISP;
          VOL_SAIDAS     := registro1310.VOL_SAIDAS;
          ESTQ_ESCR      := registro1310.ESTQ_ESCR;
          VAL_AJ_PERDA   := registro1310.VAL_AJ_PERDA;
          VAL_AJ_GANHO   := registro1310.VAL_AJ_GANHO;
          FECH_FISICO    := registro1310.FECH_FISICO;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1320New(const spdfHandle: PSPDFHandle; const registro1320 : Bloco1Registro1320) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1320New do
     BEGIN
          NUM_BICO     := registro1320.NUM_BICO;
          NR_INTERV    := registro1320.NR_INTERV;
          MOT_INTERV   := registro1320.MOT_INTERV;
          NOM_INTERV   := registro1320.NOM_INTERV;
          CNPJ_INTERV  := registro1320.CNPJ_INTERV;
          CPF_INTERV   := registro1320.CPF_INTERV;
          VAL_FECHA    := registro1320.VAL_FECHA;
          VAL_ABERT    := registro1320.VAL_ABERT;
          VOL_AFERI    := registro1320.VOL_AFERI;
          VOL_VENDAS   := registro1320.VOL_VENDAS;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1350New(const spdfHandle: PSPDFHandle; const registro1350 : Bloco1Registro1350) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1350New do
     BEGIN
          SERIE       := registro1350.SERIE;
          FABRICANTE  := registro1350.FABRICANTE;
          MODELO      := registro1350.MODELO;
          TIPO_MEDICAO:= TACBrMedicao(registro1350.TIPO_MEDICAO);
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1360New(const spdfHandle: PSPDFHandle; const registro1360 : Bloco1Registro1360) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1360New do
     BEGIN
        NUM_LACRE     := registro1360.NUM_LACRE;
        DT_APLICACAO  := TDateTime(registro1360.DT_APLICACAO);
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1370New(const spdfHandle: PSPDFHandle; const registro1370 : Bloco1Registro1370) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1370New do
     BEGIN
        NUM_BICO    := registro1370.NUM_BICO;
        COD_ITEM    := registro1370.COD_ITEM;
        NUM_TANQUE  := registro1370.NUM_TANQUE;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1390New(const spdfHandle: PSPDFHandle; const registro1390 : Bloco1Registro1390) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1390New do
     BEGIN
        COD_PROD  := registro1390.COD_PROD;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1400New(const spdfHandle: PSPDFHandle; const registro1400 : Bloco1Registro1400) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1400New do
     BEGIN
          COD_ITEM  := registro1400.COD_ITEM;
          MUN       := registro1400.MUN;
          VALOR     := registro1400.VALOR;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1500New(const spdfHandle: PSPDFHandle; const registro1500 : Bloco1Registro1500) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1500New do
     BEGIN
         IND_OPER        := registro1500.IND_OPER;
         IND_EMIT        := registro1500.IND_EMIT;
         COD_PART        := registro1500.COD_PART;
         COD_MOD         := registro1500.COD_MOD;
         COD_SIT         := TACBrSituacaoDocto(registro1500.COD_SIT);
         SER             := registro1500.SER;
         SUB             := registro1500.SUB;
         COD_CONS        := TACBrClasseConsumo(registro1500.COD_CONS);
         NUM_DOC         := registro1500.NUM_DOC;
         DT_DOC          := TDateTime(registro1500.DT_DOC);
         DT_E_S          := TDateTime(registro1500.DT_E_S);
         VL_DOC          := registro1500.VL_DOC;
         VL_DESC         := registro1500.VL_DESC;
         VL_FORN         := registro1500.VL_FORN;
         VL_SERV_NT      := registro1500.VL_SERV_NT;
         VL_TERC         := registro1500.VL_TERC;
         VL_DA           := registro1500.VL_DA;
         VL_BC_ICMS      := registro1500.VL_BC_ICMS;
         VL_ICMS         := registro1500.VL_ICMS;
         VL_BC_ICMS_ST   := registro1500.VL_BC_ICMS_ST;
         VL_ICMS_ST      := registro1500.VL_ICMS_ST;
         COD_INF         := registro1500.COD_INF;
         VL_PIS          := registro1500.VL_PIS;
         VL_COFINS       := registro1500.VL_COFINS;
         TP_LIGACAO      := TACBrTipoLigacao(registro1500.TP_LIGACAO);
         COD_GRUPO_TENSAO:= TACBrGrupoTensao(registro1500.COD_GRUPO_TENSAO);
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1510New(const spdfHandle: PSPDFHandle; const registro1510 : Bloco1Registro1510) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1510New do
     BEGIN
          NUM_ITEM        := registro1510.NUM_ITEM;
          COD_ITEM        := registro1510.COD_ITEM;
          COD_CLASS       := registro1510.COD_CLASS;
          QTD             := registro1510.QTD;
          UNID            := registro1510.UNID;
          VL_ITEM         := registro1510.VL_ITEM;
          VL_DESC         := registro1510.VL_DESC;
          CST_ICMS        := registro1510.CST_ICMS;
          CFOP            := registro1510.CFOP;
          VL_BC_ICMS      := registro1510.VL_BC_ICMS;
          ALIQ_ICMS       := registro1510.ALIQ_ICMS;
          VL_ICMS         := registro1510.VL_ICMS;
          VL_BC_ICMS_ST   := registro1510.VL_BC_ICMS_ST;
          ALIQ_ST         := registro1510.ALIQ_ST;
          VL_ICMS_ST      := registro1510.VL_ICMS_ST;
          IND_REC         := TACBrTipoReceita(registro1510.IND_REC);
          COD_PART        := registro1510.COD_PART;
          VL_PIS          := registro1510.VL_PIS;
          VL_COFINS       := registro1510.VL_COFINS;
          COD_CTA         := registro1510.COD_CTA;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1600New(const spdfHandle: PSPDFHandle; const registro1600 : Bloco1Registro1600) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1600New do
     BEGIN
          COD_PART     := registro1600.COD_PART;
          TOT_CREDITO  := registro1600.TOT_CREDITO;
          TOT_DEBITO   := registro1600.TOT_DEBITO;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1700New(const spdfHandle: PSPDFHandle; const registro1700 : Bloco1Registro1700) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1700New do
     BEGIN
          COD_DISP   := TACBrDispositivo(registro1700.COD_DISP);
          COD_MOD    := registro1700.COD_MOD;
          SER        := registro1700.SER;
          SUB        := registro1700.SUB;
          NUM_DOC_INI:= registro1700.NUM_DOC_INI;
          NUM_DOC_FIN:= registro1700.NUM_DOC_FIN;
          NUM_AUT    := registro1700.NUM_AUT;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1710New(const spdfHandle: PSPDFHandle; const registro1710 : Bloco1Registro1710) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1710New do
     BEGIN
          NUM_DOC_INI := registro1710.NUM_DOC_INI;
          NUM_DOC_FIN := registro1710.NUM_DOC_FIN;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1800New(const spdfHandle: PSPDFHandle; const registro1800 : Bloco1Registro1800) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_1.Registro1800New do
     BEGIN
          VL_CARGA       := registro1800.VL_CARGA;
          VL_PASS        := registro1800.VL_PASS;
          VL_FAT         := registro1800.VL_FAT;
          IND_RAT        := registro1800.IND_RAT;
          VL_ICMS_ANT    := registro1800.VL_ICMS_ANT;
          VL_BC_ICMS     := registro1800.VL_BC_ICMS;
          VL_ICMS_APUR   := registro1800.VL_ICMS_APUR;
          VL_BC_ICMS_APUR:= registro1800.VL_BC_ICMS_APUR;
          VL_DIF         := registro1800.VL_DIF;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_1_Registro1990_GetQTD_LIN_1(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := spdfHandle^.SPEDFiscal.Bloco_1.Registro1990.QTD_LIN_1;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion Bloco1}



{%region Bloco9}

Function SPDF_Bloco_9_GetDT_INI(const spdfHandle: PSPDFHandle; var dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtIni  := Double(spdfHandle^.SPEDFiscal.Bloco_9.DT_INI);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_9_SetDT_INI(const spdfHandle: PSPDFHandle; const dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.Bloco_9.DT_INI := TDateTime(dtIni);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_9_GetDT_FIN(const spdfHandle: PSPDFHandle; var dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtFin  := Double(spdfHandle^.SPEDFiscal.Bloco_9.DT_FIN);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_9_SetDT_FIN(const spdfHandle: PSPDFHandle; const dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.Bloco_9.DT_FIN := TDateTime(dtFin);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_9_GetGravado(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if spdfHandle^.SPEDFiscal.Bloco_9.Gravado then
     Result := 1
     else
     Result := 0;

  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_9_Registro9001New(const spdfHandle: PSPDFHandle; const registro9001 : Bloco9Registro9001) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_9.Registro9001 do
     BEGIN
          IND_MOV := TACBrIndicadorMovimento(registro9001.IND_MOV);
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_9_Registro9900New(const spdfHandle: PSPDFHandle; const registro9900 : Bloco9Registro9900) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

     with spdfHandle^.SPEDFiscal.Bloco_9.Registro9900.New do
     BEGIN
          REG_BLC := registro9900.REG_BLC;
          QTD_REG_BLC := registro9900.QTD_REG_BLC;
     end;

     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_9_Registro9990_GetQTD_LIN_9(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := spdfHandle^.SPEDFiscal.Bloco_9.Registro9990.QTD_LIN_9;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_9_Registro9999_GetQTD_LIN(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := spdfHandle^.SPEDFiscal.Bloco_9.Registro9999.QTD_LIN;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion Bloco9}

{%region BlocoC}

Function SPDF_Bloco_C_GetDT_INI(const spdfHandle: PSPDFHandle; var dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtIni  := Double(spdfHandle^.SPEDFiscal.Bloco_C.DT_INI);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_SetDT_INI(const spdfHandle: PSPDFHandle; const dtIni : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.Bloco_C.DT_INI := TDateTime(dtIni);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_GetDT_FIN(const spdfHandle: PSPDFHandle; var dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     dtFin  := Double(spdfHandle^.SPEDFiscal.Bloco_C.DT_FIN);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_SetDT_FIN(const spdfHandle: PSPDFHandle; const dtFin : double) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     spdfHandle^.SPEDFiscal.Bloco_0.DT_FIN := TDateTime(dtFin);
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_GetGravado(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if spdfHandle^.SPEDFiscal.Bloco_0.Gravado then
     Result := 1
     else
     Result := 0;

  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC001New(const spdfHandle: PSPDFHandle; const registroC001 : BlocoCRegistroC001) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC001New do
     begin
          IND_MOV:= TACBrIndicadorMovimento(registroC001.IND_MOV);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC100New(const spdfHandle: PSPDFHandle; const registroC100 : BlocoCRegistroC100) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC100New do
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
          VL_DOC        := Currency(registroC100.VL_DOC);
          IND_PGTO      := TACBrTipoPagamento(registroC100.IND_PGTO);
          VL_DESC       := Currency(registroC100.VL_DESC);
          VL_ABAT_NT    := Currency(registroC100.VL_ABAT_NT);
          VL_MERC       := Currency(registroC100.VL_MERC);
          IND_FRT       := TACBrTipoFrete(registroC100.IND_FRT);
          VL_FRT        := Currency(registroC100.VL_FRT);
          VL_SEG        := Currency(registroC100.VL_SEG);
          VL_OUT_DA     := Currency( registroC100.VL_OUT_DA);
          VL_BC_ICMS    := Currency(registroC100.VL_BC_ICMS);
          VL_ICMS       := Currency(registroC100.VL_ICMS);
          VL_BC_ICMS_ST := Currency(registroC100.VL_BC_ICMS_ST);
          VL_ICMS_ST    := Currency(registroC100.VL_ICMS_ST);
          VL_IPI        := Currency(registroC100.VL_IPI);
          VL_PIS        := Currency(registroC100.VL_PIS);
          VL_COFINS     := Currency(registroC100.VL_COFINS);
          VL_PIS_ST     := Currency(registroC100.VL_PIS_ST);
          VL_COFINS_ST  := Currency(registroC100.VL_COFINS_ST);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC110New(const spdfHandle: PSPDFHandle; const registroC110 : BlocoCRegistroC110) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC110New do
     begin
          COD_INF      := registroC110.COD_INF;
          TXT_COMPL    := registroC110.TXT_COMPL;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC105New(const spdfHandle: PSPDFHandle; const registroC105 : BlocoCRegistroC105) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC105New do
     begin
          OPER   := TACBrTipoOperacaoST(registroC105.OPER);
          UF     := registroC105.UF;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC111New(const spdfHandle: PSPDFHandle; const registroC111 : BlocoCRegistroC111) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC111New do
     begin
         NUM_PROC   := registroC111.NUM_PROC;
         IND_PROC   := TACBrOrigemProcesso(registroC111.IND_PROC);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC112New(const spdfHandle: PSPDFHandle; const registroC112 : BlocoCRegistroC112) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC112New do
     begin
        COD_DA     :=   TACBrDoctoArrecada(registroC112.COD_DA);
        UF         :=   registroC112.UF;
        NUM_DA     :=   registroC112.NUM_DA;
        COD_AUT    :=   registroC112.COD_AUT;
        VL_DA      :=   Currency(registroC112.VL_DA);
        DT_VCTO    :=   TDateTime(registroC112.DT_VCTO);
        DT_PGTO    :=   TDateTime(registroC112.DT_PGTO);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC113New(const spdfHandle: PSPDFHandle; const registroC113 : BlocoCRegistroC113) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC113New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC114New(const spdfHandle: PSPDFHandle; const registroC114 : BlocoCRegistroC114) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC114New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC115New(const spdfHandle: PSPDFHandle; const registroC115 : BlocoCRegistroC115) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC115New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC116New(const spdfHandle: PSPDFHandle; const registroC116 : BlocoCRegistroC116) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC116New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC120New(const spdfHandle: PSPDFHandle; const registroC120 : BlocoCRegistroC120) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC120New do
     begin
         COD_DOC_IMP   := TACBrDoctoImporta(registroC120.COD_DOC_IMP);
         NUM_DOC__IMP  := registroC120.NUM_DOC__IMP;
         PIS_IMP       := Currency(registroC120.PIS_IMP);
         COFINS_IMP    := Currency(registroC120.COFINS_IMP);
         NUM_ACDRAW    := registroC120.NUM_ACDRAW;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC130New(const spdfHandle: PSPDFHandle; const registroC130 : BlocoCRegistroC130) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC130New do
     begin
        VL_SERV_NT     := Currency(registroC130.VL_SERV_NT);
        VL_BC_ISSQN    := Currency(registroC130.VL_BC_ISSQN);
        VL_ISSQN       := Currency(registroC130.VL_ISSQN);
        VL_BC_IRRF     := Currency(registroC130.VL_BC_IRRF);
        VL_IRRF        := Currency(registroC130.VL_IRRF);
        VL_BC_PREV     := Currency(registroC130.VL_BC_PREV);
        VL_PREV        := Currency(registroC130.VL_PREV);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC140New(const spdfHandle: PSPDFHandle; const registroC140 : BlocoCRegistroC140) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC140New do
     begin
          IND_EMIT   :=  TACBrEmitente(registroC140.IND_EMIT);
          IND_TIT    :=  TACBrTipoTitulo(registroC140.IND_TIT);
          DESC_TIT   :=  registroC140.DESC_TIT;
          NUM_TIT    :=  registroC140.NUM_TIT;
          QTD_PARC   :=  registroC140.QTD_PARC;
          VL_TIT     :=  Currency(registroC140.VL_TIT);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC141New(const spdfHandle: PSPDFHandle; const registroC141 : BlocoCRegistroC141) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC141New do
     begin
        NUM_PARC := registroC141.NUM_PARC;
        DT_VCTO  := TDateTime(registroC141.DT_VCTO);
        VL_PARC  := Currency(registroC141.VL_PARC);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC160New(const spdfHandle: PSPDFHandle; const registroC160 : BlocoCRegistroC160) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC160New do
     begin
       COD_PART   :=  registroC160.COD_PART;
       VEIC_ID    :=  registroC160.VEIC_ID;
       QTD_VOL    :=  registroC160.QTD_VOL;
       PESO_BRT   :=  Currency(registroC160.PESO_BRT);
       PESO_LIQ   :=  Currency(registroC160.PESO_LIQ);
       UF_ID      :=  registroC160.UF_ID;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC165New(const spdfHandle: PSPDFHandle; const registroC165 : BlocoCRegistroC165) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC165New do
     begin
        COD_PART  := registroC165.COD_PART;
        VEIC_ID   := registroC165.VEIC_ID;
        COD_AUT   := registroC165.COD_AUT;
        NR_PASSE  := registroC165.NR_PASSE;
        HORA      := registroC165.HORA;
        TEMPER    := registroC165.TEMPER;
        QTD_VOL   := registroC165.QTD_VOL;
        PESO_BRT  := Currency(registroC165.PESO_BRT);
        PESO_LIQ  := Currency(registroC165.PESO_LIQ);
        NOM_MOT   := registroC165.NOM_MOT;
        CPF       := registroC165.CPF;
        UF_ID     := registroC165.UF_ID;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC170New(const spdfHandle: PSPDFHandle; const registroC170 : BlocoCRegistroC170) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC170New do
     begin
         NUM_ITEM        := registroC170.NUM_ITEM;
         COD_ITEM        := registroC170.COD_ITEM;
         DESCR_COMPL     := registroC170.DESCR_COMPL;
         QTD             := registroC170.QTD;
         UNID            := registroC170.UNID;
         VL_ITEM         := Currency(registroC170.VL_ITEM);
         VL_DESC         := Currency(registroC170.VL_DESC);
         IND_MOV         := TACBrMovimentacaoFisica(registroC170.IND_MOV);
         CST_ICMS        := registroC170.CST_ICMS;
         CFOP            := registroC170.CFOP;
         COD_NAT         := registroC170.COD_NAT;
         VL_BC_ICMS      := Currency(registroC170.VL_BC_ICMS);
         ALIQ_ICMS       := Currency(registroC170.ALIQ_ICMS);
         VL_ICMS         := Currency(registroC170.VL_ICMS);
         VL_BC_ICMS_ST   := Currency(registroC170.VL_BC_ICMS_ST);
         ALIQ_ST         := Currency(registroC170.ALIQ_ST);
         VL_ICMS_ST      := Currency(registroC170.VL_ICMS_ST);
         IND_APUR        := TACBrApuracaoIPI(registroC170.IND_APUR);
         CST_IPI         := registroC170.CST_IPI;
         COD_ENQ         := registroC170.COD_ENQ;
         VL_BC_IPI       := Currency(registroC170.VL_BC_IPI);
         ALIQ_IPI        := Currency(registroC170.ALIQ_IPI);
         VL_IPI          := Currency(registroC170.VL_IPI);
         CST_PIS         := registroC170.CST_PIS;
         VL_BC_PIS       := Currency(registroC170.VL_BC_PIS);
         ALIQ_PIS_PERC   := Currency(registroC170.ALIQ_PIS_PERC);
         QUANT_BC_PIS    := registroC170.QUANT_BC_PIS;
         ALIQ_PIS_R      := Currency(registroC170.ALIQ_PIS_R);
         VL_PIS          := Currency(registroC170.VL_PIS);
         CST_COFINS      := registroC170.CST_COFINS;
         VL_BC_COFINS    := Currency(registroC170.VL_BC_COFINS);
         ALIQ_COFINS_PERC:= Currency(registroC170.ALIQ_COFINS_PERC);
         QUANT_BC_COFINS := registroC170.QUANT_BC_COFINS;
         ALIQ_COFINS_R   := Currency(registroC170.ALIQ_COFINS_R);
         VL_COFINS       := Currency(registroC170.VL_COFINS);
         COD_CTA         := registroC170.COD_CTA;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC171New(const spdfHandle: PSPDFHandle; const registroC171 : BlocoCRegistroC171) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC171New do
     begin
          NUM_TANQUE := registroC171.NUM_TANQUE;
          QTDE       := registroC171.QTDE;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC172New(const spdfHandle: PSPDFHandle; const registroC172 : BlocoCRegistroC172) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC172New do
     begin
         VL_BC_ISSQN := Currency(registroC172.VL_BC_ISSQN);
         ALIQ_ISSQN  := Currency(registroC172.ALIQ_ISSQN);
         VL_ISSQN    := Currency(registroC172.VL_ISSQN);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC173New(const spdfHandle: PSPDFHandle; const registroC173 : BlocoCRegistroC173) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC173New do
     begin
        LOTE_MED   := registroC173.LOTE_MED;
        QTD_ITEM   := registroC173.QTD_ITEM;
        DT_FAB     := TDateTime(registroC173.DT_FAB);
        DT_VAL     := TDateTime(registroC173.DT_VAL);
        IND_MED    := TACBrTipoBaseMedicamento(registroC173.IND_MED);
        TP_PROD    := TACBrTipoProduto(registroC173.TP_PROD);
        VL_TAB_MAX := Currency(registroC173.VL_TAB_MAX);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC174New(const spdfHandle: PSPDFHandle; const registroC174 : BlocoCRegistroC174) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC174New do
     begin
         IND_ARM      := TACBrTipoArmaFogo(registroC174.IND_ARM);
         NUM_ARM      := registroC174.NUM_ARM;
         DESCR_COMPL  := registroC174.DESCR_COMPL;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC175New(const spdfHandle: PSPDFHandle; const registroC175 : BlocoCRegistroC175) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC175New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC176New(const spdfHandle: PSPDFHandle; const registroC176 : BlocoCRegistroC176) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC176New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC177New(const spdfHandle: PSPDFHandle; const registroC177 : BlocoCRegistroC177) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC177New do
     begin
         COD_SELO_IPI  := registroC177.COD_SELO_IPI;
         QT_SELO_IPI   := Currency(registroC177.QT_SELO_IPI);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC178New(const spdfHandle: PSPDFHandle; const registroC178 : BlocoCRegistroC178) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC178New do
     begin
        CL_ENQ     :=  registroC178.CL_ENQ;
        VL_UNID    :=  Currency(registroC178.VL_UNID);
        QUANT_PAD  :=  registroC178.QUANT_PAD;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC179New(const spdfHandle: PSPDFHandle; const registroC179 : BlocoCRegistroC179) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC179New do
     begin
         BC_ST_ORIG_DEST := Currency(registroC179.BC_ST_ORIG_DEST);
         ICMS_ST_REP     := Currency(registroC179.ICMS_ST_REP);
         ICMS_ST_COMPL   := Currency(registroC179.ICMS_ST_COMPL);
         BC_RET          := Currency(registroC179.BC_RET);
         ICMS_RET        := Currency(registroC179.ICMS_RET);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC190New(const spdfHandle: PSPDFHandle; const registroC190 : BlocoCRegistroC190) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC190New do
     begin
        CST_ICMS       :=  registroC190.CST_ICMS;
        CFOP           :=  registroC190.CFOP;
        ALIQ_ICMS      :=  Currency(registroC190.ALIQ_ICMS);
        VL_OPR         :=  Currency(registroC190.VL_OPR);
        VL_BC_ICMS     :=  Currency(registroC190.VL_BC_ICMS);
        VL_ICMS        :=  Currency(registroC190.VL_ICMS);
        VL_BC_ICMS_ST  :=  Currency(registroC190.VL_BC_ICMS_ST);
        VL_ICMS_ST     :=  Currency(registroC190.VL_ICMS_ST);
        VL_RED_BC      :=  Currency(registroC190.VL_RED_BC);
        VL_IPI         :=  Currency(registroC190.VL_IPI);
        COD_OBS        :=  registroC190.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC195New(const spdfHandle: PSPDFHandle; const registroC195 : BlocoCRegistroC195) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC195New do
     begin
       COD_OBS   := registroC195.COD_OBS;
       TXT_COMPL := registroC195.TXT_COMPL;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC197New(const spdfHandle: PSPDFHandle; const registroC197 : BlocoCRegistroC197) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC197New do
     begin
        COD_AJ          := registroC197.COD_AJ;
        DESCR_COMPL_AJ  := registroC197.DESCR_COMPL_AJ;
        COD_ITEM        := registroC197.COD_ITEM;
        VL_BC_ICMS      := Currency(registroC197.VL_BC_ICMS);
        ALIQ_ICMS       := Currency(registroC197.ALIQ_ICMS);
        VL_ICMS         := Currency(registroC197.VL_ICMS);
        VL_OUTROS       := Currency(registroC197.VL_OUTROS);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC300New(const spdfHandle: PSPDFHandle; const registroC300 : BlocoCRegistroC300) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC300New do
     begin
        COD_MOD      := registroC300.COD_MOD;
        SER          := registroC300.SER;
        SUB          := registroC300.SUB;
        NUM_DOC_INI  := registroC300.NUM_DOC_INI;
        NUM_DOC_FIN  := registroC300.NUM_DOC_FIN;
        DT_DOC       := TDateTime(registroC300.DT_DOC);
        VL_DOC       := Currency(registroC300.VL_DOC);
        VL_PIS       := Currency(registroC300.VL_PIS);
        VL_COFINS    := Currency(registroC300.VL_COFINS);
        COD_CTA      := registroC300.COD_CTA;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC310New(const spdfHandle: PSPDFHandle; const registroC310 : BlocoCRegistroC310) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC310New do
     begin
        NUM_DOC_CANC := registroC310.NUM_DOC_CANC;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC320New(const spdfHandle: PSPDFHandle; const registroC320 : BlocoCRegistroC320) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC320New do
     begin
          CST_ICMS    := registroC320.CST_ICMS;
          CFOP        := registroC320.CFOP;
          ALIQ_ICMS   := Currency(registroC320.ALIQ_ICMS);
          VL_OPR      := Currency(registroC320.VL_OPR);
          VL_BC_ICMS  := Currency(registroC320.VL_BC_ICMS);
          VL_ICMS     := Currency(registroC320.VL_ICMS);
          VL_RED_BC   := Currency(registroC320.VL_RED_BC);
          COD_OBS     := registroC320.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC321New(const spdfHandle: PSPDFHandle; const registroC321 : BlocoCRegistroC321) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC321New do
     begin
         COD_ITEM    := registroC321.COD_ITEM;
         QTD         := Currency(registroC321.QTD);
         UNID        := registroC321.UNID;
         VL_ITEM     := Currency(registroC321.VL_ITEM);
         VL_DESC     := Currency(registroC321.VL_DESC);
         VL_BC_ICMS  := Currency(registroC321.VL_BC_ICMS);
         VL_ICMS     := Currency(registroC321.VL_ICMS);
         VL_PIS      := Currency(registroC321.VL_PIS);
         VL_COFINS   := Currency(registroC321.VL_COFINS);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC350New(const spdfHandle: PSPDFHandle; const registroC350 : BlocoCRegistroC350) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC350New do
     begin
        SER       := registroC350.SER;
        SUB_SER   := registroC350.SUB_SER;
        NUM_DOC   := registroC350.NUM_DOC;
        DT_DOC    := TDateTime(registroC350.DT_DOC);
        CNPJ_CPF  := registroC350.CNPJ_CPF;
        VL_MERC   := Currency(registroC350.VL_MERC);
        VL_DOC    := Currency(registroC350.VL_DOC);
        VL_DESC   := Currency(registroC350.VL_DESC);
        VL_PIS    := Currency(registroC350.VL_PIS);
        VL_COFINS := Currency(registroC350.VL_COFINS);
        COD_CTA   := registroC350.COD_CTA;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;


Function SPDF_Bloco_C_RegistroC370New(const spdfHandle: PSPDFHandle; const registroC370 : BlocoCRegistroC370) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC370New do
     begin
        NUM_ITEM  := registroC370.NUM_ITEM;
        COD_ITEM  := registroC370.COD_ITEM;
        QTD       := registroC370.QTD;
        UNID      := registroC370.UNID;
        VL_ITEM   := Currency(registroC370.VL_ITEM);
        VL_DESC   := Currency(registroC370.VL_DESC);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC390New(const spdfHandle: PSPDFHandle; const registroC390 : BlocoCRegistroC390) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC390New do
     begin
        CST_ICMS    := registroC390.CST_ICMS;
        CFOP        := registroC390.CFOP;
        ALIQ_ICMS   := Currency(registroC390.ALIQ_ICMS);
        VL_OPR      := Currency(registroC390.VL_OPR);
        VL_BC_ICMS  := Currency(registroC390.VL_BC_ICMS);
        VL_ICMS     := Currency(registroC390.VL_ICMS);
        VL_RED_BC   := Currency(registroC390.VL_RED_BC);
        COD_OBS     := registroC390.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC400New(const spdfHandle: PSPDFHandle; const registroC400 : BlocoCRegistroC400) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC400New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC405New(const spdfHandle: PSPDFHandle; const registroC405 : BlocoCRegistroC405) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC405New do
     begin
        DT_DOC       := TDateTime(registroC405.DT_DOC);
        CRO          := registroC405.CRO;
        CRZ          := registroC405.CRZ;
        NUM_COO_FIN  := registroC405.NUM_COO_FIN;
        GT_FIN       := Currency(registroC405.GT_FIN);
        VL_BRT       := Currency(registroC405.VL_BRT);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC410New(const spdfHandle: PSPDFHandle; const registroC410 : BlocoCRegistroC410) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC410New do
     begin
         VL_PIS      := registroC410.VL_PIS;
         VL_COFINS   := registroC410.VL_COFINS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC420New(const spdfHandle: PSPDFHandle; const registroC420 : BlocoCRegistroC420) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC420New do
     begin
         COD_TOT_PAR   := registroC420.COD_TOT_PAR;
         VLR_ACUM_TOT  := Currency(registroC420.VLR_ACUM_TOT);
         NR_TOT        := registroC420.NR_TOT;
         DESCR_NR_TOT  := registroC420.DESCR_NR_TOT;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC425New(const spdfHandle: PSPDFHandle; const registroC425 : BlocoCRegistroC425) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC425New do
     begin
        COD_ITEM  := registroC425.COD_ITEM;
        QTD       := registroC425.QTD;
        UNID      := registroC425.UNID;
        VL_ITEM   := Currency(registroC425.VL_ITEM);
        VL_PIS    := Currency(registroC425.VL_PIS);
        VL_COFINS := Currency(registroC425.VL_COFINS);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC460New(const spdfHandle: PSPDFHandle; const registroC460 : BlocoCRegistroC460) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC460New do
     begin
        COD_MOD   := registroC460.COD_MOD;
        COD_SIT   := TACBrSituacaoDocto(registroC460.COD_SIT);
        NUM_DOC   := registroC460.NUM_DOC;
        DT_DOC    := TDateTime(registroC460.DT_DOC);
        VL_DOC    := Currency(registroC460.VL_DOC);
        VL_PIS    := Currency(registroC460.VL_PIS);
        VL_COFINS := Currency(registroC460.VL_COFINS);
        CPF_CNPJ  := registroC460.CPF_CNPJ;
        NOM_ADQ   := registroC460.NOM_ADQ;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC490New(const spdfHandle: PSPDFHandle; const registroC490 : BlocoCRegistroC490) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC490New do
     begin
          CST_ICMS   := registroC490.CST_ICMS;
          CFOP       := registroC490.CFOP;
          ALIQ_ICMS  := Currency(registroC490.ALIQ_ICMS);
          VL_OPR     := Currency(registroC490.VL_OPR);
          VL_BC_ICMS := Currency(registroC490.VL_BC_ICMS);
          VL_ICMS    := Currency(registroC490.VL_ICMS);
          COD_OBS    := registroC490.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC495New(const spdfHandle: PSPDFHandle; const registroC495 : BlocoCRegistroC495) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC495New do
     begin
        ALIQ_ICMS   := Currency(registroC495.ALIQ_ICMS);
        COD_ITEM    := registroC495.COD_ITEM;
        QTD         := registroC495.QTD;
        QTD_CANC    := registroC495.QTD_CANC;
        UNID        := registroC495.UNID;
        VL_ITEM     := Currency(registroC495.VL_ITEM);
        VL_DESC     := Currency(registroC495.VL_DESC);
        VL_CANC     := Currency(registroC495.VL_CANC);
        VL_ACMO     := Currency(registroC495.VL_ACMO);
        VL_BC_ICMS  := Currency(registroC495.VL_BC_ICMS);
        VL_ICMS     := Currency(registroC495.VL_ICMS);
        VL_ISEN     := Currency(registroC495.VL_ISEN);
        VL_NT       := Currency(registroC495.VL_NT);
        VL_ICMS_ST  := Currency(registroC495.VL_ICMS_ST);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC500New(const spdfHandle: PSPDFHandle; const registroC500 : BlocoCRegistroC500) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC500New do
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
          VL_DOC             :=  Currency(registroC500.VL_DOC);
          VL_DESC            :=  Currency(registroC500.VL_DESC);
          VL_FORN            :=  Currency(registroC500.VL_FORN);
          VL_SERV_NT         :=  Currency(registroC500.VL_SERV_NT);
          VL_TERC            :=  Currency(registroC500.VL_TERC);
          VL_DA              :=  Currency(registroC500.VL_DA);
          VL_BC_ICMS         :=  Currency(registroC500.VL_BC_ICMS);
          VL_ICMS            :=  Currency(registroC500.VL_ICMS);
          VL_BC_ICMS_ST      :=  Currency(registroC500.VL_BC_ICMS_ST);
          VL_ICMS_ST         := Currency( registroC500.VL_ICMS_ST);
          COD_INF            :=  registroC500.COD_INF;
          VL_PIS             :=  Currency(registroC500.VL_PIS);
          VL_COFINS          :=  Currency(registroC500.VL_COFINS);
          TP_LIGACAO         :=  TACBrTipoLigacao(registroC500.TP_LIGACAO);
          COD_GRUPO_TENSAO   :=  TACBrGrupoTensao(registroC500.COD_GRUPO_TENSAO);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC510New(const spdfHandle: PSPDFHandle; const registroC510 : BlocoCRegistroC510) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC510New do
     begin
         NUM_ITEM       := registroC510.NUM_ITEM;
         COD_ITEM       := registroC510.COD_ITEM;
         COD_CLASS      := registroC510.COD_CLASS;
         QTD            := registroC510.QTD;
         UNID           := registroC510.UNID;
         VL_ITEM        := Currency(registroC510.VL_ITEM);
         VL_DESC        := Currency(registroC510.VL_DESC);
         CST_ICMS       := registroC510.CST_ICMS;
         CFOP           := registroC510.CFOP;
         VL_BC_ICMS     := Currency(registroC510.VL_BC_ICMS);
         ALIQ_ICMS      := Currency(registroC510.ALIQ_ICMS);
         VL_ICMS        := Currency(registroC510.VL_ICMS);
         VL_BC_ICMS_ST  := Currency(registroC510.VL_BC_ICMS_ST);
         ALIQ_ST        := Currency(registroC510.ALIQ_ST);
         VL_ICMS_ST     := Currency(registroC510.VL_ICMS_ST);
         IND_REC        := TACBrTipoReceita(registroC510.IND_REC);
         COD_PART       := registroC510.COD_PART;
         VL_PIS         := Currency(registroC510.VL_PIS);
         VL_COFINS      := Currency(registroC510.VL_COFINS);
         COD_CTA        := registroC510.COD_CTA;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC590New(const spdfHandle: PSPDFHandle; const registroC590 : BlocoCRegistroC590) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC590New do
     begin
         CST_ICMS       := registroC590.CST_ICMS;
         CFOP           := registroC590.CFOP;
         ALIQ_ICMS      := Currency(registroC590.ALIQ_ICMS);
         VL_OPR         := Currency(registroC590.VL_OPR);
         VL_BC_ICMS     := Currency(registroC590.VL_BC_ICMS);
         VL_ICMS        := Currency(registroC590.VL_ICMS);
         VL_BC_ICMS_ST  := Currency(registroC590.VL_BC_ICMS_ST);
         VL_ICMS_ST     := Currency(registroC590.VL_ICMS_ST);
         VL_RED_BC      := Currency(registroC590.VL_RED_BC);
         COD_OBS        := registroC590.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC600New(const spdfHandle: PSPDFHandle; const registroC600 : BlocoCRegistroC600) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC600New do
     begin
        COD_MOD           := registroC600.COD_MOD;
        COD_MUN           := registroC600. COD_MUN;
        SER               := registroC600.SER;
        SUB               := registroC600.SUB;
        COD_CONS          := registroC600.COD_CONS;
        QTD_CONS          := Currency(registroC600.QTD_CONS);
        QTD_CANC          := Currency(registroC600.QTD_CANC);
        DT_DOC            := TDateTime(registroC600.DT_DOC);
        VL_DOC            := Currency(registroC600.VL_DOC);
        VL_DESC           := Currency(registroC600.VL_DESC);
        CONS              := Currency(registroC600.CONS);
        VL_FORN           := Currency(registroC600.VL_FORN);
        VL_SERV_NT        := Currency(registroC600.VL_SERV_NT);
        VL_TERC           := Currency(registroC600.VL_TERC);
        VL_DA             := Currency(registroC600.VL_DA);
        VL_BC_ICMS        := Currency(registroC600.VL_BC_ICMS);
        VL_ICMS           := Currency(registroC600.VL_ICMS);
        VL_BC_ICMS_ST     := Currency(registroC600.VL_BC_ICMS_ST);
        VL_ICMS_ST        := Currency(registroC600.VL_ICMS_ST);
        VL_PIS            := Currency(registroC600.VL_PIS);
        VL_COFINS         := Currency(registroC600.VL_COFINS);
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC601New(const spdfHandle: PSPDFHandle; const registroC601 : BlocoCRegistroC601) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC601New do
     begin
        NUM_DOC_CANC           := registroC601.NUM_DOC_CANC;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC610New(const spdfHandle: PSPDFHandle; const registroC610 : BlocoCRegistroC610) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC610New do
     begin
         COD_CLASS    := registroC610.COD_CLASS;
         COD_ITEM     := registroC610.COD_ITEM;
         QTD          := registroC610.QTD;
         UNID         := registroC610.UNID;
         VL_ITEM      := Currency(registroC610.VL_ITEM);
         VL_DESC      := Currency(registroC610.VL_DESC);
         CST_ICMS     := registroC610.CST_ICMS;
         CFOP         := registroC610.CFOP;
         ALIQ_ICMS    := Currency(registroC610.ALIQ_ICMS);
         VL_BC_ICMS   := Currency(registroC610.VL_BC_ICMS);
         VL_ICMS      := Currency(registroC610.VL_ICMS);
         VL_BC_ICMS_ST:= Currency(registroC610.VL_BC_ICMS_ST);
         VL_ICMS_ST   := Currency(registroC610.VL_ICMS_ST);
         VL_PIS       := Currency(registroC610.VL_PIS);
         VL_COFINS    := Currency(registroC610.VL_COFINS);
         COD_CTA      := registroC610.COD_CTA;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC690New(const spdfHandle: PSPDFHandle; const registroC690 : BlocoCRegistroC690) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC690New do
     begin
        CST_ICMS         := registroC690.CST_ICMS;
        CFOP             := registroC690.CFOP;
        ALIQ_ICMS        := Currency(registroC690.ALIQ_ICMS);
        VL_OPR           := Currency(registroC690.VL_OPR);
        VL_BC_ICMS       := Currency(registroC690.VL_BC_ICMS);
        VL_ICMS          := Currency(registroC690.VL_ICMS);
        VL_RED_BC        := Currency(registroC690.VL_RED_BC);
        VL_BC_ICMS_ST    := Currency(registroC690.VL_BC_ICMS_ST);
        VL_ICMS_ST       := Currency(registroC690.VL_ICMS_ST);
        COD_OBS          := registroC690.COD_OBS;
     end;
     Result := 0;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function SPDF_Bloco_C_RegistroC700New(const spdfHandle: PSPDFHandle; const registroC700 : BlocoCRegistroC700) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     with spdfHandle^.SPEDFiscal.Bloco_C.RegistroC700New do
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
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;


Function SPDF_Bloco_C_RegistroC990_GetQTD_LIN_C(const spdfHandle: PSPDFHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

 if (spdfHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := spdfHandle^.SPEDFiscal.Bloco_C.RegistroC990.QTD_LIN_C;
  except
     on exception : Exception do
     begin
        spdfHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion BlocoC}

exports

{ Create/Destroy/Erro }
SPDF_Create,
SPDF_Destroy,
SPDF_GetUltimoErro,

{ Funções mapeando as propriedades do componente }

SPDF_GetAbout, SPDF_GetArquivo, SPDF_SetArquivo,
SPDF_GetCurMascara, SPDF_SetCurMascara, SPDF_GetPath,
SPDF_SetPath, SPDF_GetDelimitador, SPDF_SetDelimitador,
SPDF_GetLinhasBuffer, SPDF_SetLinhasBuffer, SPDF_GetTrimString,
SPDF_SetTrimString, SPDF_GetDT_INI, SPDF_SetDT_INI,
SPDF_GetDT_FIN, SPDF_SetDT_FIN,

{ Methods }
SPDF_IniciaGeracao,

{%region Bloco0}

SPDF_Bloco_0_GetDT_INI, SPDF_Bloco_0_SetDT_INI,
SPDF_Bloco_0_GetDT_FIN, SPDF_Bloco_0_SetDT_FIN,
SPDF_Bloco_0_GetGravado,
SPDF_Bloco_0_Registro0000New,
SPDF_Bloco_0_Registro0001New,
SPDF_Bloco_0_Registro0005New,
SPDF_Bloco_0_Registro0015New,
SPDF_Bloco_0_Registro0100New,
SPDF_Bloco_0_Registro0150New,
SPDF_Bloco_0_Registro0175New,
SPDF_Bloco_0_Registro0190New,
SPDF_Bloco_0_Registro0200New,
SPDF_Bloco_0_Registro0205New,
SPDF_Bloco_0_Registro0206New,
SPDF_Bloco_0_Registro0220New,
SPDF_Bloco_0_Registro0300New,
SPDF_Bloco_0_Registro0305New,
SPDF_Bloco_0_Registro0400New,
SPDF_Bloco_0_Registro0450New,
SPDF_Bloco_0_Registro0460New,
SPDF_Bloco_0_Registro0500New,
SPDF_Bloco_0_Registro0600New,
SPDF_Bloco_0_Registro0990_GetQTD_LIN_0,

{%endregion Bloco0}

{%region Bloco1}

SPDF_Bloco_1_GetDT_INI, SPDF_Bloco_1_SetDT_INI,
SPDF_Bloco_1_GetDT_FIN, SPDF_Bloco_1_SetDT_FIN,
SPDF_Bloco_1_GetGravado,
SPDF_Bloco_1_Registro1001New,
SPDF_Bloco_1_Registro1010New,
SPDF_Bloco_1_Registro1100New,
SPDF_Bloco_1_Registro1105New,
SPDF_Bloco_1_Registro1110New,
SPDF_Bloco_1_Registro1200New,
SPDF_Bloco_1_Registro1210New,
SPDF_Bloco_1_Registro1300New,
SPDF_Bloco_1_Registro1310New,
SPDF_Bloco_1_Registro1320New,
SPDF_Bloco_1_Registro1350New,
SPDF_Bloco_1_Registro1360New,
SPDF_Bloco_1_Registro1370New,
SPDF_Bloco_1_Registro1390New,
SPDF_Bloco_1_Registro1400New,
SPDF_Bloco_1_Registro1990_GetQTD_LIN_1,

{%endregion Bloco1}

{%region Bloco9}

SPDF_Bloco_9_GetDT_INI, SPDF_Bloco_9_SetDT_INI,
SPDF_Bloco_9_GetDT_FIN, SPDF_Bloco_9_SetDT_FIN,
SPDF_Bloco_9_GetGravado,
SPDF_Bloco_9_Registro9001New,
SPDF_Bloco_9_Registro9900New,
SPDF_Bloco_9_Registro9990_GetQTD_LIN_9,
SPDF_Bloco_9_Registro9999_GetQTD_LIN,

{%endregion Bloco9}

{%region BlocoC}

SPDF_Bloco_C_GetDT_INI, SPDF_Bloco_C_SetDT_INI,
SPDF_Bloco_C_GetDT_FIN, SPDF_Bloco_C_SetDT_FIN,
SPDF_Bloco_C_GetGravado,
SPDF_Bloco_C_RegistroC001New,
SPDF_Bloco_C_RegistroC100New,
SPDF_Bloco_C_RegistroC110New,
SPDF_Bloco_C_RegistroC105New,
SPDF_Bloco_C_RegistroC111New,
SPDF_Bloco_C_RegistroC112New,
SPDF_Bloco_C_RegistroC113New,
SPDF_Bloco_C_RegistroC114New,
SPDF_Bloco_C_RegistroC115New,
SPDF_Bloco_C_RegistroC116New,
SPDF_Bloco_C_RegistroC120New,
SPDF_Bloco_C_RegistroC130New,
SPDF_Bloco_C_RegistroC140New,
SPDF_Bloco_C_RegistroC141New,
SPDF_Bloco_C_RegistroC160New,
SPDF_Bloco_C_RegistroC165New,
SPDF_Bloco_C_RegistroC170New,
SPDF_Bloco_C_RegistroC171New,
SPDF_Bloco_C_RegistroC172New,
SPDF_Bloco_C_RegistroC173New,
SPDF_Bloco_C_RegistroC174New,
SPDF_Bloco_C_RegistroC175New,
SPDF_Bloco_C_RegistroC176New,
SPDF_Bloco_C_RegistroC177New,
SPDF_Bloco_C_RegistroC178New,
SPDF_Bloco_C_RegistroC179New,
SPDF_Bloco_C_RegistroC190New,
SPDF_Bloco_C_RegistroC195New,
SPDF_Bloco_C_RegistroC197New,
SPDF_Bloco_C_RegistroC300New,
SPDF_Bloco_C_RegistroC310New,
SPDF_Bloco_C_RegistroC320New,
SPDF_Bloco_C_RegistroC321New,
SPDF_Bloco_C_RegistroC350New,
SPDF_Bloco_C_RegistroC370New,
SPDF_Bloco_C_RegistroC390New,
SPDF_Bloco_C_RegistroC400New,
SPDF_Bloco_C_RegistroC405New,
SPDF_Bloco_C_RegistroC410New,
SPDF_Bloco_C_RegistroC420New,
SPDF_Bloco_C_RegistroC425New,
SPDF_Bloco_C_RegistroC460New,
SPDF_Bloco_C_RegistroC490New,
SPDF_Bloco_C_RegistroC495New,
SPDF_Bloco_C_RegistroC500New,
SPDF_Bloco_C_RegistroC510New,
SPDF_Bloco_C_RegistroC590New,
SPDF_Bloco_C_RegistroC600New,
SPDF_Bloco_C_RegistroC601New,
SPDF_Bloco_C_RegistroC610New,
SPDF_Bloco_C_RegistroC690New,
SPDF_Bloco_C_RegistroC700New,
SPDF_Bloco_C_RegistroC990_GetQTD_LIN_C

{%endregion BlocoC}
;
end.

