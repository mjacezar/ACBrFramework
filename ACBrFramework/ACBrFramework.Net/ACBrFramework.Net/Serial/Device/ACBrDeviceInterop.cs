using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework
{
	public static class ACBrDeviceInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrDeviceInterop

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_GetPorta(IntPtr ecfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_SetPorta(IntPtr ecfHandle, string porta);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_GetBaud(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_SetBaud(IntPtr ecfHandle, int baud);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_GetDataBits(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_SetDataBits(IntPtr ecfHandle, int dataBits);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_GetParity(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_SetParity(IntPtr ecfHandle, int parity);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_GetStopBits(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_SetStopBits(IntPtr ecfHandle, int stopBits);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_GetHandShake(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_SetHandShake(IntPtr ecfHandle, int handShake);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_GetHardFlow(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_SetHardFlow(IntPtr ecfHandle, bool hardFlow);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_GetSoftFlow(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_SetSoftFlow(IntPtr ecfHandle, bool softFlow);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_GetTimeOut(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_SetTimeOut(IntPtr ecfHandle, int timeOut);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_GetMaxBandwidth(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_SetMaxBandwidth(IntPtr ecfHandle, int maxBandwidth);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_GetProcessMessages(IntPtr ecfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int DEV_SetProcessMessages(IntPtr ecfHandle, bool processMessages);

		#endregion ACBrDeviceInterop
	}
}