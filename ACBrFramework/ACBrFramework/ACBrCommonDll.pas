unit ACBrCommonDll;

interface

uses
  SysUtils,
  Classes;

{ Ponteiros de função }
type TProcedurePtr = procedure (); cdecl;
type TStrFunctionPtr = function () : PChar; cdecl;
type TDoubleProcedurePtr = procedure(const value : Double); cdecl;
type TBobinaProcedurePtr = procedure(const Linhas : PChar; const Operacao : PChar); cdecl;

implementation
end.


