unit ACBrCommonDll;

interface

uses
  SysUtils,
  Classes;

{ Ponteiros de função }
type TCallback = procedure (); cdecl;
type TStrFunctionPtr = function () : PChar; cdecl;

implementation
end.


