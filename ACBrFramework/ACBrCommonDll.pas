unit ACBrCommonDll;

interface

uses
  SysUtils,
  Classes;

{ Ponteiros de função }
type TProcedurePtr = procedure ();
type TStrFunctionPtr = function () : PChar;
type TDoubleProcedurePtr = procedure(const value : Double);
type TBobinaProcedurePtr = procedure(const Linhas : PChar; const Operacao : PChar);

implementation
end.


