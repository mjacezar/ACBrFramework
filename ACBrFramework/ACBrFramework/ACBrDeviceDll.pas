unit ACBrDeviceDll;

interface

uses
  SysUtils,
  Classes,
  ACBrECF,
  ACBrBAL,
  ACBrLCB,
  ACBrDIS,
  ACBrDevice,
  ACBrBase,
  ACBrUtil;

{Handle para o componente TACBrECF }
type TDeviceHandle = record
  UltimoErro : String;
  Component : TACBrComponent;
end;

{Ponteiro para o Handle }
type PDeviceHandle = ^TDeviceHandle;

Function GetDevice(const deviceHandle: PDeviceHandle) : TACBrDevice;

implementation

Function DEV_GetPorta(const deviceHandle: PDeviceHandle; Buffer : pChar; const BufferLen : Integer) : Integer ; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF} export;
var
  StrTmp : String;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

 try
     StrTmp := GetDevice(deviceHandle).Porta;
     StrPLCopy(Buffer, StrTmp, BufferLen);
     Result := length(StrTmp);
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_SetPorta(const deviceHandle: PDeviceHandle; const Porta : pChar) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     GetDevice(deviceHandle).Porta := Porta;
     Result := 0;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_GetBaud(const deviceHandle: PDeviceHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := GetDevice(deviceHandle).Baud;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_SetBaud(const deviceHandle: PDeviceHandle; const Baud : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     GetDevice(deviceHandle).Baud := Baud;
     Result := 0;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_GetDataBits(const deviceHandle: PDeviceHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := GetDevice(deviceHandle).Data;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_SetDataBits(const deviceHandle: PDeviceHandle; const DataBits : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     GetDevice(deviceHandle).Data := DataBits;
     Result := 0;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_GetParity(const deviceHandle: PDeviceHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(GetDevice(deviceHandle).Parity);
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_SetParity(const deviceHandle: PDeviceHandle; const Parity : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     GetDevice(deviceHandle).Parity := TACBrSerialParity(Parity);
     Result := 0;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_GetStopBits(const deviceHandle: PDeviceHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(GetDevice(deviceHandle).Stop);
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_SetStopBits(const deviceHandle: PDeviceHandle; const StopBits : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     GetDevice(deviceHandle).Stop := TACBrSerialStop(StopBits);
     Result := 0;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_GetHandShake(const deviceHandle: PDeviceHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(GetDevice(deviceHandle).HandShake);
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_SetHandShake(const deviceHandle: PDeviceHandle; const HandShake : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     GetDevice(deviceHandle).HandShake := TACBrHandShake(HandShake);
     Result := 0;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_GetHardFlow(const deviceHandle: PDeviceHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(GetDevice(deviceHandle).HardFlow);
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_SetHardFlow(const deviceHandle: PDeviceHandle; const HardFlow : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     GetDevice(deviceHandle).HardFlow := HardFlow;
     Result := 0;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_GetSoftFlow(const deviceHandle: PDeviceHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := Integer(GetDevice(deviceHandle).SoftFlow);
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_SetSoftFlow(const deviceHandle: PDeviceHandle; const SoftFlow : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     GetDevice(deviceHandle).SoftFlow := SoftFlow;
     Result := 0;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_GetTimeOut(const deviceHandle: PDeviceHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := GetDevice(deviceHandle).TimeOut;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_SetTimeOut(const deviceHandle: PDeviceHandle; const TimeOut : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     GetDevice(deviceHandle).TimeOut := TimeOut;
     Result := 0;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_GetMaxBandwidth(const deviceHandle: PDeviceHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     Result := GetDevice(deviceHandle).MaxBandwidth;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_SetMaxBandwidth(const deviceHandle: PDeviceHandle; const MaxBandwidth : Integer) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     GetDevice(deviceHandle).MaxBandwidth := MaxBandwidth;
     Result := 0;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_GetProcessMessages(const deviceHandle: PDeviceHandle) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     if GetDevice(deviceHandle).ProcessMessages then
       Result := 1
     else
       Result := 0;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function DEV_SetProcessMessages(const deviceHandle: PDeviceHandle; const value : Boolean) : Integer; {$IFDEF STDCALL} stdcall; {$ENDIF} {$IFDEF CDECL} cdecl; {$ENDIF}  export;
begin

  if (deviceHandle = nil) then
  begin
     Result := -2;
     Exit;
  end;

  try
     GetDevice(deviceHandle).ProcessMessages := value;
     Result := 0;
  except
     on exception : Exception do
     begin
        deviceHandle^.UltimoErro := exception.Message;
        Result := -1;
     end
  end;

end;

Function GetDevice(const deviceHandle: PDeviceHandle) : TACBrDevice;
begin

    if (deviceHandle^.Component is TACBrECF) then
         result := TACBrECF(deviceHandle.Component).Device
    else if (deviceHandle^.Component is TACBrBAL) then
      result := TACBrBAL(deviceHandle.Component).Device
    else if (deviceHandle^.Component is TACBrLCB) then
      result := TACBrLCB(deviceHandle.Component).Device
    else if (deviceHandle.Component is TACBrDIS) then
      result := TACBrDIS(deviceHandle.Component).Device;

end;

exports


DEV_GetPorta, DEV_SetPorta,
DEV_GetBaud, DEV_SetBaud,
DEV_GetDataBits, DEV_SetDataBits,
DEV_GetParity, DEV_SetParity,
DEV_GetStopBits, DEV_SetStopBits,
DEV_GetHandShake, DEV_SetHandShake,
DEV_GetHardFlow, DEV_SetHardFlow,
DEV_GetSoftFlow, DEV_SetSoftFlow,
DEV_GetTimeOut, DEV_SetTimeOut,
DEV_GetProcessMessages, DEV_SetProcessMessages,
DEV_GetMaxBandwidth, DEV_SetMaxBandwidth;


end.
