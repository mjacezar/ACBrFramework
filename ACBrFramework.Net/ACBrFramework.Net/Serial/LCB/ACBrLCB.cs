using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ACBrFramework.LCB
{
    #region COM Interop

    /* NOTAS para COM INTEROP
	 * Há um modo de compilação com a diretiva COM_INTEROP que inseri atributos e código específico
	 * para a DLL ser exportada para COM (ActiveX)
	 *
	 * O modelo COM possui alguma limitações/diferenças em relação ao modelo .NET
	 * Inserir os #if COM_INTEROP para prover implementações distintas nas modificações necessárias para COM:
	 *
	 * - Inserir atributos ComVisible(true), Guid("xxx") e ClassInterface(ClassInterfaceType.AutoDual) em todas as classes envolvidas
	 *
	 * - Propriedades/métodos que usam "Decimal" devem incluir o atributo MarshalAs(UnmanagedType.Currency)
	 *   usar [return: ...] para retornos de métodos e propriedades ou [param: ...] para o set de propriedades
	 *
	 * - Métodos que recebem array como parâmetros devem fazer como "ref".
	 *   Propriedades só podem retornar arrays, nunca receber.
	 *
	 * - Overload não é permitido. Métodos com mesmos nomes devem ser renomeados.
	 *   É possível usar parâmetros default, simplificando a necessidade de Overload
	 *
	 * - Generic não deve ser usado. Todas as classes Generic devem ser re-escritas como classes específicas
	 *
	 * - Eventos precisam de uma Interface com as declarações dos métodos (eventos) com o atributo [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	 *   A classe que declara os eventos precisa do atributo [ComSourceInterfaces(typeof(INomeDaInterface))]
	 *   Nenhum delegate deverá ser Generic, precisam ser re-escritos.
	 *
	 *   OBS: Por padrão o modelo .Net recebe os eventos com a assinatura void(object sender, EventArgs e)
	 *   O modelo COM não precisa desses parâmetros. Assim o delegate EventHandler foi redefinido para uma assinatura void()
	 *   Outros EventArgs devem seguir a assitarua COM void(MyEventArg e) ao invés da assinatura .NET void(object sender, MyEventArgs e)
	 * */

#if COM_INTEROP

    #region IDispatch Interface

    #region Documentation

    /// <summary>
    /// Interface contendo os eventos publicados pelo componente COM
    /// </summary>

    #endregion Documentation

    [ComVisible(true)]
    [Guid("64B823A3-9D78-4AA8-8F69-01D660139B39")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IACBrLCBEvents
    {
        [DispId(1)]
        void OnLePeso();
    }

    #endregion IDispatch Interface

    #region Delegates

    #region Comments

    ///os componentes COM não suportam Generics
    ///Estas são implementações específicas de delegates que no .Net são representados como EventHandler<T>

    #endregion Comments

    #endregion Delegates

#endif

    #endregion COM Interop

    #region COM Interop Attributes

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("8A8A68B0-D64A-4ACB-8A20-57D978B04082")]
    [ComSourceInterfaces(typeof(IACBrLCBEvents))]
    [ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.Serial.LCB.ico.bmp")]
	public sealed class ACBrLCB : ACBrComponent, IDisposable
	{
		#region Events

		public event EventHandler OnLeCodigo
		{
            #region COM_INTEROP

#if COM_INTEROP
            [ComVisible(false)]
#endif

            #endregion COM_INTEROP
			add
			{
				onLeCodigo.Add(value);
			}

            #region COM_INTEROP

#if COM_INTEROP
            [ComVisible(false)]
#endif

            #endregion COM_INTEROP
			remove
			{
				onLeCodigo.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<ACBrLCBInterop.LeCodigoCallback> onLeCodigo;

		#endregion Fields

		#region Constructor

		public ACBrLCB()
		{
			onLeCodigo = new ACBrEventHandler<ACBrLCBInterop.LeCodigoCallback>(this, OnLeCodigoCallback, ACBrLCBInterop.LCB_SetOnLeCodigo);
		}

		#endregion Constructor

		#region Properties

		public bool Ativo
		{
			get
			{
				return GetBool(ACBrLCBInterop.LCB_GetAtivo);
			}
		}

		public string Porta
		{
			get
			{
				return GetString(ACBrLCBInterop.LCB_GetPorta);
			}
			set
			{
				SetString(ACBrLCBInterop.LCB_SetPorta, value);
			}
		}

		public ACBrDevice Device { get; private set; }

		public string UltimoCodigo
		{
			get
			{
				return GetString(ACBrLCBInterop.LCB_GetUltimoErro);
			}
		}

		public string UltimaLeitura
		{
			get
			{
				return GetString(ACBrLCBInterop.LCB_GetUltimaLeitura);
			}
		}

		#endregion Properties

		#region Methods

		public void Ativar()
		{
			int ret = ACBrLCBInterop.LCB_Ativar(this.Handle);
			CheckResult(ret);
		}

		public void Desativar()
		{
			int ret = ACBrLCBInterop.LCB_Desativar(this.Handle);
			CheckResult(ret);
		}

		public string LerString()
		{
			return GetString(ACBrLCBInterop.LCB_LerString);
		}

		#region Callback EventHandlers

		[AllowReversePInvokeCalls]
		private void OnLeCodigoCallback()
		{
			if (onLeCodigo.IsAssigned)
			{
				onLeCodigo.Raise();
			}
		}

		#endregion Callback EventHandlers

		#region Override Methods

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrLCBInterop.LCB_Create);
			Device = new ACBrDevice(this);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					const int BUFFER_LEN = 1024;
					string error = GetString(ACBrLCBInterop.LCB_GetUltimoErro, BUFFER_LEN);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr LCB não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrLCBInterop.LCB_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}