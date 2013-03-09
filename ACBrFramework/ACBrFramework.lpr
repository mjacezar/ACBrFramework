library ACBrFramework;

{$IFDEF FPC}
  {$MODE Delphi}
{$ENDIF}

uses

  ACBrDeviceDll, ACBrECFDll, ACBrPAFDll, ACBrEADDll,
  ACBrSintegraDll, ACBrBALDll, ACBrLCBDll, ACBrAACDLL,
  ACBrTEFDll, ACBrCNIEEDll, ACBrSpedDll, ACBrSpedFiscalDll,
  ACBrSMSDll, ACBrIBGEDll, ACBrValidadorDll, ACBrRFDDll,
  ACBrCEPDll, ACBrDISDll{$IFNDEF x64},ACBrNFe2Dll{$ENDIF}
  ;

{$R *.res}
begin
end.
