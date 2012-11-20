unit ACBrSpedFiscaldll;

interface

uses
  Classes,
  SysUtils,
  ACBrSPED,
  ACBrSpedFiscal,
  ACBrCommonDLL;

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

exports

{ Funções }
SPDF_Create,
SPDF_Destroy,
SPDF_GetUltimoErro;
end.

