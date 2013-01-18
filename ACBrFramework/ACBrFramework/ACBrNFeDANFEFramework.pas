{******************************************************************************
|* Historico
|*
|* 10/01/2013: Rafael Dias
|*  - Inicio do desenvolvimento
******************************************************************************}
{$I ACBr.inc}

unit ACBrNFeDANFEFramework;

interface

uses
  SysUtils,
  Classes,
  ACBrNFeDANFEClass,
  pcnNFe,
  pcnConversao;

type TImprimirCallback = procedure(NFE : TNFe); cdecl;

type
  TACBrNFeDANFEFramework = class( TACBrNFeDANFEClass )
  private
    ImprimirDANFECallback : TImprimirCallback;
    ImprimirDANFEPDFCallback : TImprimirCallback;
    ImprimirEVENTOCallback : TImprimirCallback;
    ImprimirEVENTOPDFCallback : TImprimirCallback;
  public
    constructor Create(AOwner: TComponent); override;
    destructor Destroy; override;
    property ImprimirDANFE: TImprimirCallback read ImprimirDANFECallback write ImprimirDANFECallback ;
    property ImprimirDANFEPDF: TImprimirCallback read ImprimirDANFEPDFCallback write ImprimirDANFEPDFCallback ;
    property ImprimirEVENTO: TImprimirCallback read ImprimirEVENTOCallback write ImprimirEVENTOCallback ;
    property ImprimirEVENTOPDF: TImprimirCallback read ImprimirEVENTOPDFCallback write ImprimirEVENTOPDFCallback ;
    procedure ImprimirDANFE(NFE: TNFe = nil); override;
    procedure ImprimirDANFEPDF(NFE: TNFe = nil); override;
    procedure ImprimirEVENTO(NFE: TNFe = nil); override;
    procedure ImprimirEVENTOPDF(NFE: TNFe = nil); override;
  end;

implementation

constructor TACBrNFeDANFEFramework.Create(AOwner: TComponent);
begin
  inherited create( AOwner );
end;

destructor TACBrNFeDANFEFramework.Destroy;
begin
  inherited Destroy;
end;

procedure TACBrNFeDANFEFramework.ImprimirDANFE(NFE: TNFe);
begin
  ImprimirDANFECallback(NFE);
end;

procedure TACBrNFeDANFEFramework.ImprimirDANFEPDF(NFE: TNFe);
begin
  ImprimirDANFEPDFCallback(NFE);
end;

procedure TACBrNFeDANFEFramework.ImprimirEVENTO(NFE: TNFe);
begin
   ImprimirEVENTOCallback(NFE);
end;

procedure TACBrNFeDANFEFramework.ImprimirEVENTOPDF(NFE: TNFe);
begin
  ImprimirEVENTOCallback(NFE);
end;

end.
