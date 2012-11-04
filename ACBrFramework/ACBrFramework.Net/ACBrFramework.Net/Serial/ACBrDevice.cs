﻿namespace ACBrFramework
{
	public class ACBrDevice : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrDevice(ACBrComponent owner)
			: base(owner)
		{
		}

		#endregion Constructor

		#region Properties

		public string Porta
		{
			get
			{
				return GetString(ACBrDeviceInterop.DEV_GetPorta);
			}
			set
			{
				SetString(ACBrDeviceInterop.DEV_SetPorta, value);
			}
		}

		public int Baud
		{
			get
			{
				return GetInt32(ACBrDeviceInterop.DEV_GetBaud);
			}
			set
			{
				SetInt32(ACBrDeviceInterop.DEV_SetBaud, value);
			}
		}

		public int DataBits
		{
			get
			{
				return GetInt32(ACBrDeviceInterop.DEV_GetDataBits);
			}
			set
			{
				SetInt32(ACBrDeviceInterop.DEV_SetDataBits, value);
			}
		}

		public SerialParity Parity
		{
			get
			{
				return (SerialParity)GetInt32(ACBrDeviceInterop.DEV_GetParity);
			}
			set
			{
				SetInt32(ACBrDeviceInterop.DEV_SetParity, (int)value);
			}
		}

		public SerialStopBits StopBits
		{
			get
			{
				return (SerialStopBits)GetInt32(ACBrDeviceInterop.DEV_GetStopBits);
			}
			set
			{
				SetInt32(ACBrDeviceInterop.DEV_SetStopBits, (int)value);
			}
		}

		public SerialHandShake HandShake
		{
			get
			{
				return (SerialHandShake)GetInt32(ACBrDeviceInterop.DEV_GetHandShake);
			}
			set
			{
				SetInt32(ACBrDeviceInterop.DEV_SetHandShake, (int)value);
			}
		}

		public bool HardFlow
		{
			get
			{
				return GetBool(ACBrDeviceInterop.DEV_GetHardFlow);
			}
			set
			{
				SetBool(ACBrDeviceInterop.DEV_SetHardFlow, value);
			}
		}

		public bool SoftFlow
		{
			get
			{
				return GetBool(ACBrDeviceInterop.DEV_GetSoftFlow);
			}
			set
			{
				SetBool(ACBrDeviceInterop.DEV_SetSoftFlow, value);
			}
		}

		public int TimeOut
		{
			get
			{
				return GetInt32(ACBrDeviceInterop.DEV_GetTimeOut);
			}
			set
			{
				SetInt32(ACBrDeviceInterop.DEV_SetTimeOut, value);
			}
		}

		#endregion Properties
	}
}