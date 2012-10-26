unit ACBrCommonDll;

interface

uses
  SysUtils,
  Classes;

{ Ponteiros de função }
type TProcedurePtr = procedure ();
type TStrFunctionPtr = function () : PChar;
type TDoubleProcedurePrt = procedure(const value : Double);

implementation
end.


