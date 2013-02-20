/**
* ACBrFramework DefExporter
* Este arquivo foi gerado automaticamente
**/



#ifndef ACBr
#define ACBr

typedef void* INTPTR;
typedef char* PCHAR;
typedef char BOOL;

#endif


#ifndef _ACBrDevice_H_
#define _ACBrDevice_H_

#ifdef __cplusplus
#define DllImport extern "C"
#else
#define DllImport extern
#endif


// Tipos de dados


// Funções

DllImport int DEV_GetBaud(const INTPTR ecfHandle);
DllImport int DEV_GetDataBits(const INTPTR ecfHandle);
DllImport int DEV_GetHandShake(const INTPTR ecfHandle);
DllImport int DEV_GetHardFlow(const INTPTR ecfHandle);
DllImport int DEV_GetMaxBandwidth(const INTPTR ecfHandle);
DllImport int DEV_GetParity(const INTPTR ecfHandle);
DllImport int DEV_GetPorta(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int DEV_GetProcessMessages(const INTPTR ecfHandle);
DllImport int DEV_GetSoftFlow(const INTPTR ecfHandle);
DllImport int DEV_GetStopBits(const INTPTR ecfHandle);
DllImport int DEV_GetTimeOut(const INTPTR ecfHandle);
DllImport int DEV_SetBaud(const INTPTR ecfHandle, const int baud);
DllImport int DEV_SetDataBits(const INTPTR ecfHandle, const int dataBits);
DllImport int DEV_SetHandShake(const INTPTR ecfHandle, const int handShake);
DllImport int DEV_SetHardFlow(const INTPTR ecfHandle, const BOOL hardFlow);
DllImport int DEV_SetMaxBandwidth(const INTPTR ecfHandle, const int maxBandwidth);
DllImport int DEV_SetParity(const INTPTR ecfHandle, const int parity);
DllImport int DEV_SetPorta(const INTPTR ecfHandle, const PCHAR porta);
DllImport int DEV_SetProcessMessages(const INTPTR ecfHandle, const BOOL processMessages);
DllImport int DEV_SetSoftFlow(const INTPTR ecfHandle, const BOOL softFlow);
DllImport int DEV_SetStopBits(const INTPTR ecfHandle, const int stopBits);
DllImport int DEV_SetTimeOut(const INTPTR ecfHandle, const int timeOut);


#endif
