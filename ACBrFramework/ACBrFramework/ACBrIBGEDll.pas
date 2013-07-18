unit ACBrIBGEDll;

interface

uses
  SysUtils,
  Classes,
  ACBrIBGE;

{ Ponteiros de função para uso nos eventos}
type TBuscaEfetuadaCallback = procedure(); cdecl;

{Classe que armazena os EventHandlers para o componente ACBr}
type TEventHandlers = class
    OnBuscaEfetuadaCallback : TBuscaEfetuadaCallback;
    procedure OnBuscaEfetuada(Sender: TObject);
end;


{Handle para o componente TACBrECF }
type TIBGEHandle = record
  UltimoErro : String;
  IBGE : TACBrIBGE;
  EventHandlers : TEventHandlers;
end;

{Ponteiro para o Handle }
type PIBGEHandle = ^TIBGEHandle;

{Records estilo C utilizados nos retornos das funções}

type TCidadeRec = record
      Municipio       : array[0..50] of char;
      CodMunicio      : Integer;
      UF              : array[0..2] of char;
      CodUF           : Integer;
      Area            : double;
end;

implementation

{%region Constructor/Destructor}
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
CRIA um novo componente TACBrIBGE retornando o ponteiro para o objeto criado.
Este ponteiro deve ser armazenado pela aplicação que utiliza a DLL e informado
em todas as chamadas de função relativas ao TACBrIBGE
}
Function IBGE_Create(var ibgeHandle: PIBGEHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  try

     New(ibgeHandle);

     ibgeHandle^.IBGE := TACBrIBGE.Create(nil);
     ibgeHandle^.EventHandlers := TEventHandlers.Create();
     ibgeHandle^.UltimoErro := '';
     Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        ibgeHandle^.UltimoErro := exception.Message;
     end
  end;

end;

{
DESTRÓI o objeto TACBrIBGE e libera a memória utilizada.
Esta função deve SEMPRE ser chamada pela aplicação que utiliza a DLL
quando o componente não mais for utilizado.
}
Function IBGE_Destroy(ibgeHandle: PibgeHandle): Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (ibgeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try

    ibgeHandle^.IBGE.Destroy();
    ibgeHandle^.IBGE := nil;

    Dispose(ibgeHandle);
    ibgeHandle := nil;
    Result := 0;

  except
     on exception : Exception do
     begin
        Result := -1;
        ibgeHandle^.UltimoErro := exception.Message;
     end
  end;

end;

Function IBGE_GetUltimoErro(const ibgeHandle: PIBGEHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  try
     StrPLCopy(Buffer, ibgeHandle^.UltimoErro, BufferLen);
     Result := length(ibgeHandle^.UltimoErro);
  except
     on exception : Exception do
     begin
        ibgeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

{%region Methodos do componente}

Function IBGE_BuscarPorCodigo(const ibgeHandle: PIBGEHandle; const codigo : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ibgeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := ibgeHandle^.IBGE.BuscarPorCodigo(codigo);
  except
     on exception : Exception do
     begin
        ibgeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function IBGE_BuscarPorNome(const ibgeHandle: PIBGEHandle; const nome, uf : PChar; exata :  Boolean) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ibgeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := ibgeHandle^.IBGE.BuscarPorNome(nome, uf, exata);
  except
     on exception : Exception do
     begin
        ibgeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

Function IBGE_Cidades_GetCount(const ibgeHandle: PIBGEHandle) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ibgeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try
     Result := ibgeHandle^.IBGE.Cidades.Count;
   except
     on exception : Exception do
     begin
        ibgeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

Function IBGE_Cidades_GetItem(const ibgeHandle: PIBGEHandle; var retCidade : TCidadeRec; const index : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  cidade : TACBrIBGECidade;
begin

  if (ibgeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

   try

      if (index >= 0) and (index < ibgeHandle^.IBGE.Cidades.Count) then
      begin
              cidade := ibgeHandle^.IBGE.Cidades[index];

              StrPLCopy(retCidade.Municipio, cidade.Municipio, 50);
              retCidade.CodMunicio := cidade.CodMunicio;
              StrPLCopy(retCidade.UF, cidade.UF, 2);
              retCidade.Area := cidade.Area;
              retCidade.CodUF := cidade.CodUF;
              Result := 0;
      end
      else
      begin
              Result := -3;
      end;

   except
     on exception : Exception do
     begin
        ibgeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
   end;
end;

{%endregion}

{%region Eventos }

procedure TEventHandlers.OnBuscaEfetuada(Sender: TObject);
begin
     OnBuscaEfetuadaCallback();
end;

Function IBGE_SetOnBuscaEfetuada(const ibgeHandle: PIBGEHandle; const method : TBuscaEfetuadaCallback) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
begin

  if (ibgeHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
  if Assigned(method) then
  begin
        ibgeHandle^.IBGE.OnBuscaEfetuada := ibgeHandle^.EventHandlers.OnBuscaEfetuada;
        ibgeHandle^.EventHandlers.OnBuscaEfetuadaCallback := method;
        Result := 0;
  end
  else
  begin
        ibgeHandle^.IBGE.OnBuscaEfetuada := nil;
        ibgeHandle^.EventHandlers.OnBuscaEfetuadaCallback := nil;
        Result := 0;
  end;
  except
     on exception : Exception do
     begin
        ibgeHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;
end;

{%endregion}

exports

{ Funções }

IBGE_Create,
IBGE_Destroy,
IBGE_GetUltimoErro,

IBGE_BuscarPorCodigo,
IBGE_BuscarPorNome,
IBGE_Cidades_GetCount,
IBGE_Cidades_GetItem,
IBGE_SetOnBuscaEfetuada;

end.
