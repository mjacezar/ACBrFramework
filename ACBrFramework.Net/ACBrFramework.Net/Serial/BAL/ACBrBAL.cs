using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ACBrFramework.BAL
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
    public interface IACBrBALEvents
    {
        [DispId(1)]
        void OnLePeso(LePesoEventArgs e);         
    }

    #endregion IDispatch Interface

    #region Delegates

    #region Comments

    ///os componentes COM não suportam Generics
    ///Estas são implementações específicas de delegates que no .Net são representados como EventHandler<T>

    #endregion Comments

    public delegate void LePesoEventHandler(LePesoEventArgs e);

    #endregion Delegates

#endif

    #endregion COM Interop

    #region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("D5DB5593-6185-466B-8E91-D8FCCE183324")]
    [ComSourceInterfaces(typeof(IACBrBALEvents))]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    [ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.Serial.BAL.ico.bmp")]
	public sealed class ACBrBAL : ACBrComponent, IDisposable
	{
		#region Events

#if COM_INTEROP
        public event LePesoEventHandler OnLePeso
#else
		public event EventHandler<LePesoEventArgs> OnLePeso
#endif
        {
            #region COM_INTEROP

#if COM_INTEROP
            [ComVisible(false)]
#endif

            #endregion COM_INTEROP
			add
			{
				onLePeso.Add(value);
			}

            #region COM_INTEROP

#if COM_INTEROP
            [ComVisible(false)]
#endif

            #endregion COM_INTEROP
			remove
			{
				onLePeso.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<LePesoEventArgs, ACBrBALInterop.LePesoCallback> onLePeso;

		#endregion Fields

		#region Constructor

		public ACBrBAL()
		{
			onLePeso = new ACBrEventHandler<LePesoEventArgs, ACBrBALInterop.LePesoCallback>(this, OnLePesoCallback, ACBrBALInterop.BAL_SetOnLePeso);
		}

		#endregion Constructor

		#region Properties

		public bool Ativo
		{
			get
			{
				return GetBool(ACBrBALInterop.BAL_GetAtivo);
			}
		}

		public ModeloBal Modelo
		{
			get
			{
				return (ModeloBal)GetInt32(ACBrBALInterop.BAL_GetModelo);
			}
			set
			{
				SetInt32(ACBrBALInterop.BAL_SetModelo, (int)value);
			}
		}

		public string ModeloStr
		{
			get
			{
				return GetString(ACBrBALInterop.BAL_GetModeloStr);
			}
		}

		public string Porta
		{
			get
			{
				return GetString(ACBrBALInterop.BAL_GetPorta);
			}
			set
			{
				SetString(ACBrBALInterop.BAL_SetPorta, value);
			}
		}

		public ACBrDevice Device { get; private set; }

		public bool MonitoraBalanca
		{
			get
			{
				return GetBool(ACBrBALInterop.BAL_GetMonitoraBalanca);
			}
			set
			{
				SetBool(ACBrBALInterop.BAL_SetMonitoraBalanca, value);
			}
		}

		public decimal UltimoPesoLido
        {
            #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get
            {                
                return GetDecimal(ACBrBALInterop.BAL_GetUltimoPesoLido);
			}
		}

		public string UltimaResposta
		{
			get
			{
				return GetString(ACBrBALInterop.BAL_GetUltimaResposta);
			}
		}

		#endregion Properties

		#region Methods

		public void Ativar()
		{
			int ret = ACBrBALInterop.BAL_Ativar(this.Handle);
			CheckResult(ret);
		}

		public void Desativar()
		{
			int ret = ACBrBALInterop.BAL_Desativar(this.Handle);
			CheckResult(ret);
		}

        #region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

        #endregion COM_INTEROP
        public decimal LePeso(int timeout = 3000)
		{
			double peso = 0;
			int ret = ACBrBALInterop.BAL_LePeso(Handle, timeout, ref peso);
			CheckResult(ret);

			return Convert.ToDecimal(peso);
		}

		#region Override Methods

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrBALInterop.BAL_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr BAL não inicializado.");
			}
		}

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrBALInterop.BAL_Create);
			Device = new ACBrDevice(this);
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrBALInterop.BAL_Destroy);
			}
		}

		#endregion Override Methods

		#region EventHandlers

		[AllowReversePInvokeCalls]
		private void OnLePesoCallback(double value)
		{
			if (onLePeso.IsAssigned)
			{
				LePesoEventArgs e = new LePesoEventArgs();
				e.Peso = Convert.ToDecimal(value);
				onLePeso.Raise(e);
			}
		}

		#endregion EventHandlers

		#endregion Methods
	}
}