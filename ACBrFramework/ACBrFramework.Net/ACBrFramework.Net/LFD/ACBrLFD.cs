using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ACBrFramework.LFD
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.LFD.ico.bmp")]
	public class ACBrLFD : ACBrComponent, IDisposable
	{
		#region Fields

		private readonly ACBrEventHandler<ErrorEventArgs, ACBrLFDInterop.StringCallback> onError;

		#endregion Fields

		#region Events

		public event EventHandler<ErrorEventArgs> OnError
		{
			add
			{
				onError.Add(value);
			}
			remove
			{
				onError.Remove(value);
			}
		}

		#endregion Events

		#region Constructor

		public ACBrLFD()
		{
			onError = new ACBrEventHandler<ErrorEventArgs, ACBrLFDInterop.StringCallback>(this, OnErrorCallback, ACBrLFDInterop.LFD_SetOnError);
		}

		#endregion Constructor

		#region Properties

		[Category("Geral")]
		public string About
		{
			get
			{
				return GetAbout(ACBrLFDInterop.LFD_GetAbout);
			}
		}

		[Category("Geral")]
		public string Arquivo
		{
			get
			{
				return GetString(ACBrLFDInterop.LFD_GetArquivo);
			}
			set
			{
				SetString(ACBrLFDInterop.LFD_SetArquivo, value);
			}
		}

		[Category("Geral")]
		public string CurMascara
		{
			get
			{
				return GetString(ACBrLFDInterop.LFD_GetCurMascara);
			}
			set
			{
				SetString(ACBrLFDInterop.LFD_SetCurMascara, value);
			}
		}

		[Category("Geral")]
		public string Path
		{
			get
			{
				return GetString(ACBrLFDInterop.LFD_GetPath);
			}
			set
			{
				SetString(ACBrLFDInterop.LFD_SetPath, value);
			}
		}

		[Category("Geral")]
		public string Delimitador
		{
			get
			{
				return GetString(ACBrLFDInterop.LFD_GetDelimitador);
			}
			set
			{
				SetString(ACBrLFDInterop.LFD_SetDelimitador, value);
			}
		}

		[Category("Geral")]
		public int LinhasBuffer
		{
			get
			{
				return GetInt32(ACBrLFDInterop.LFD_GetLinhasBuffer);
			}
			set
			{
				SetInt32(ACBrLFDInterop.LFD_SetLinhasBuffer, value);
			}
		}

		[Category("Geral")]
		public Boolean TrimString
		{
			get
			{
				return GetBool(ACBrLFDInterop.LFD_GetTrimString);
			}
			set
			{
				SetBool(ACBrLFDInterop.LFD_SetTrimString, value);
			}
		}

		[Browsable(false)]
		public DateTime DT_INI
		{
			get
			{
				return GetDateTime(ACBrLFDInterop.LFD_GetDT_INI);
			}
			set
			{
				SetDateTime(ACBrLFDInterop.LFD_SetDT_INI, value);
			}
		}

		[Browsable(false)]
		public DateTime DT_FIN
		{
			get
			{
				return GetDateTime(ACBrLFDInterop.LFD_GetDT_FIN);
			}
			set
			{
				SetDateTime(ACBrLFDInterop.LFD_SetDT_FIN, value);
			}
		}

		[Browsable(false)]
		public Bloco0 Bloco_0 { get; private set; }

		[Browsable(false)]
		public BlocoA Bloco_A { get; private set; }

		[Browsable(false)]
		public BlocoC Bloco_C { get; private set; }

		[Browsable(false)]
		public Bloco9 Bloco_9 { get; private set; }

		#endregion Properties

		#region Methods

		public void SaveFileTXT()
		{
			SendBlocos();

			int ret = ACBrLFDInterop.LFD_SaveFileTXT(this.Handle);
			CheckResult(ret);

			CreateBlocos();
		}

		private void CreateBlocos()
		{
			Bloco_0 = new Bloco0(this);
			Bloco_A = new BlocoA(this);
			Bloco_C = new BlocoC(this);
			Bloco_9 = new Bloco9(this);
		}

		#region Interop

		private void SendBlocos()
		{
			SendBloco0();
			SendBlocoA();
			SendBlocoC();
			SendBloco9();
		}

		#region Bloco0 Interop

		private void SendBloco0()
		{
			SendRegistro0000();
			SendRegistro0001();
		}

		private void SendRegistro0000()
		{
			SendRecord<ACBrLFDInterop.Bloco0Registro0000>(Bloco_0.Registro0000, ACBrLFDInterop.LFD_Bloco_0_Registro0000New);
		}

		private void SendRegistro0001()
		{
			SendRecord<ACBrLFDInterop.Bloco0Registro0001>(Bloco_0.Registro0001, ACBrLFDInterop.LFD_Bloco_0_Registro0001New);

			SendRegistro0005();

			foreach (var item in Bloco_0.Registro0001.Registro0025)
			{
				SendRegistro0025(item);
			}

			SendRegistro0100();

			foreach (var item in Bloco_0.Registro0001.Registro0150)
			{
				SendRegistro0150(item);
			}

			foreach (var item in Bloco_0.Registro0001.Registro0200)
			{
				SendRegistro0200(item);
			}
		}

		private void SendRegistro0005()
		{
			SendRecord<ACBrLFDInterop.Bloco0Registro0005>(Bloco_0.Registro0001.Registro0005, ACBrLFDInterop.LFD_Bloco_0_Registro0005New);
		}

		private void SendRegistro0025(Registro0025 item)
		{
			SendRecord<ACBrLFDInterop.Bloco0Registro0025>(item, ACBrLFDInterop.LFD_Bloco_0_Registro0025New);
		}

		private void SendRegistro0100()
		{
			SendRecord<ACBrLFDInterop.Bloco0Registro0100>(Bloco_0.Registro0001.Registro0100, ACBrLFDInterop.LFD_Bloco_0_Registro0100New);
		}

		private void SendRegistro0150(Registro0150 item)
		{
			SendRecord<ACBrLFDInterop.Bloco0Registro0150>(item, ACBrLFDInterop.LFD_Bloco_0_Registro0150New);

			foreach (var item0175 in item.Registro0175)
			{
				SendRegistro0175(item0175);
			}
		}

		private void SendRegistro0175(Registro0175 item)
		{
			SendRecord<ACBrLFDInterop.Bloco0Registro0175>(item, ACBrLFDInterop.LFD_Bloco_0_Registro0175New);
		}

		private void SendRegistro0200(Registro0200 item)
		{
			SendRecord<ACBrLFDInterop.Bloco0Registro0200>(item, ACBrLFDInterop.LFD_Bloco_0_Registro0200New);

			foreach (var item0205 in item.Registro0205)
			{
				SendRegistro0205(item0205);
			}
		}

		private void SendRegistro0205(Registro0205 item)
		{
			SendRecord<ACBrLFDInterop.Bloco0Registro0205>(item, ACBrLFDInterop.LFD_Bloco_0_Registro0205New);
		}

		#endregion Bloco0 Interop

		#region BlocoA Interop

		private void SendBlocoA()
		{
			SendRegistroA001();
		}

		private void SendRegistroA001()
		{
			SendRecord<ACBrLFDInterop.BlocoARegistroA001>(Bloco_A.RegistroA001, ACBrLFDInterop.LFD_Bloco_A_RegistroA001New);

			foreach (var item in Bloco_A.RegistroA001.RegistroA350)
			{
				SendRegistroA350(item);
			}
		}

		private void SendRegistroA350(RegistroA350 item)
		{
			SendRecord<ACBrLFDInterop.BlocoARegistroA350>(item, ACBrLFDInterop.LFD_Bloco_A_RegistroA350New);

			foreach (var itemA360 in item.RegistroA360)
			{
				SendRegistroA360(itemA360);
			}
		}

		private void SendRegistroA360(RegistroA360 item)
		{
			SendRecord<ACBrLFDInterop.BlocoARegistroA360>(item, ACBrLFDInterop.LFD_Bloco_A_RegistroA360New);
		}

		#endregion BlocoA Interop

		#region BlocoC Interop

		private void SendBlocoC()
		{
			SendRegistroC001();
		}

		private void SendRegistroC001()
		{
			SendRecord<ACBrLFDInterop.BlocoCRegistroC001>(Bloco_C.RegistroC001, ACBrLFDInterop.LFD_Bloco_C_RegistroC001New);

			foreach (var item in Bloco_C.RegistroC001.RegistroC020)
			{
				SendRegistroC020(item);
			}

			foreach (var item in Bloco_C.RegistroC001.RegistroC550)
			{
				SendRegistroC550(item);
			}

			foreach (var item in Bloco_C.RegistroC001.RegistroC600)
			{
				SendRegistroC600(item);
			}
		}

		private void SendRegistroC020(RegistroC020 item)
		{
			SendRecord<ACBrLFDInterop.BlocoCRegistroC020>(item, ACBrLFDInterop.LFD_Bloco_C_RegistroC020New);
		}

		private void SendRegistroC550(RegistroC550 item)
		{
			SendRecord<ACBrLFDInterop.BlocoCRegistroC550>(item, ACBrLFDInterop.LFD_Bloco_C_RegistroC550New);

			foreach (var itemC555 in item.RegistroC555)
			{
				SendRegistroC555(itemC555);
			}
		}

		private void SendRegistroC555(RegistroC555 item)
		{
			SendRecord<ACBrLFDInterop.BlocoCRegistroC555>(item, ACBrLFDInterop.LFD_Bloco_C_RegistroC555New);
		}

		private void SendRegistroC600(RegistroC600 item)
		{
			SendRecord<ACBrLFDInterop.BlocoCRegistroC600>(item, ACBrLFDInterop.LFD_Bloco_C_RegistroC600New);

			foreach (var itemC605 in item.RegistroC605)
			{
				SendregistroC605(itemC605);
			}
		}

		private void SendregistroC605(RegistroC605 item)
		{
			SendRecord<ACBrLFDInterop.BlocoCRegistroC605>(item, ACBrLFDInterop.LFD_Bloco_C_RegistroC605New);
		}

		#endregion BlocoC Interop

		#region Bloco9 Interop

		private void SendBloco9()
		{
			SendRegistro9001();

			foreach (var item9900 in this.Bloco_9.Registro9900)
			{
				SendRegistro9900(item9900);
			}
		}

		private void SendRegistro9001()
		{
			SendRecord<ACBrLFDInterop.Bloco9Registro9001>(Bloco_9.Registro9001, ACBrLFDInterop.LFD_Bloco_9_Registro9001New);
		}

		private void SendRegistro9900(Registro9900 item)
		{
			SendRecord<ACBrLFDInterop.Bloco9Registro9900>(item, ACBrLFDInterop.LFD_Bloco_9_Registro9900New);
		}

		#endregion Bloco9 Interop

		#region Interop Helpers

		private void SendRecord<TRecord>(object item, Func<IntPtr, TRecord, int> sendRecordMethod) where TRecord : struct
		{
			TRecord record = BindRecord<TRecord>(item);
			int ret = sendRecordMethod(this.Handle, record);
			CheckResult(ret);
		}

		private TRecord BindRecord<TRecord>(object item) where TRecord : struct
		{
			Type recordType = typeof(TRecord);
			Type itemType = item.GetType();

			object record = new TRecord();

			foreach (var field in recordType.GetFields())
			{
				PropertyInfo propertyInfo = itemType.GetProperty(field.Name);
				if (propertyInfo == null) throw new Exception(string.Format("O tipo {0} não possui a propriedade {1}", itemType.Name, field.Name));
				
				object value = propertyInfo.GetValue(item, null);

				if (field.FieldType == typeof(string))
				{
					var str = ToUTF8((string)value);
					field.SetValue(record, str);
				}
				else if (field.FieldType == typeof(double))
				{
					if (value is DateTime)
					{
						field.SetValue(record, ((DateTime)value).ToOADate());
					}
					else
					{
						field.SetValue(record, Convert.ToDouble(value));
					}
				}
				else if (field.FieldType == typeof(int))
				{
					field.SetValue(record, Convert.ToInt32(value));
				}
				else if (field.FieldType == typeof(short))
				{
					field.SetValue(record, Convert.ToInt16(value));
				}
				else if (field.FieldType == typeof(long))
				{
					field.SetValue(record, Convert.ToInt64(value));
				}
				else if (field.FieldType == typeof(float))
				{
					field.SetValue(record, Convert.ToSingle(value));
				}
				else
				{
					throw new Exception(string.Format("{0}: Tipo de dado {0} não esperado.", itemType.Name, field.FieldType.Name));
				}
			}

			return (TRecord)record;
		}

		#endregion Interop

		#endregion Interop

		#region Override Methods

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrLFDInterop.LFD_Create);
			CreateBlocos();
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrLFDInterop.LFD_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBrLFD não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrLFDInterop.LFD_Destroy);
			}
		}

		#endregion Override Methods

		#region Callback EventHandlers

		[AllowReversePInvokeCalls]
		private void OnErrorCallback(string msgErro)
		{
			if (onError.IsAssigned)
			{
				ErrorEventArgs e = new ErrorEventArgs(FromUTF8(msgErro));
				onError.Raise(e);
			}
		}

		#endregion

		#endregion Methods
	}
}