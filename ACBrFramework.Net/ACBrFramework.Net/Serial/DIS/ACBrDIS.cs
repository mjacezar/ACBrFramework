using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ACBrFramework.DIS
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
	[Guid("ADA025EF-3A42-49A0-A569-90BD9CDE987C")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IACBrDISEvents
	{
		[DispId(1)]
		void OnAtualiza(AtualizaEventArgs e);
	}

	#endregion IDispatch Interface

	#region Delegates

	#region Comments

	///os componentes COM não suportam Generics
	///Estas são implementações específicas de delegates que no .Net são representados como EventHandler<T>

	#endregion Comments

	public delegate void AtualizaEventHandler(AtualizaEventArgs e);

	#endregion Delegates

#endif

	#endregion COM Interop

	#region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("81B99D20-759F-4DDB-9EA0-E9087AD44D6C")]
	[ComSourceInterfaces(typeof(IACBrDISEvents))]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM Interop Attributes

	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.Serial.DIS.ico.bmp")]
	public sealed class ACBrDIS : ACBrComponent, IDisposable
	{
		#region Events

#if COM_INTEROP

		public event AtualizaEventHandler OnAtualiza
#else
		public event EventHandler<AtualizaEventArgs> OnAtualiza
#endif
		{
			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			add
			{
				onAtualiza.Add(value);
			}

			#region COM_INTEROP

#if COM_INTEROP
			[ComVisible(false)]
#endif

			#endregion COM_INTEROP

			remove
			{
				onAtualiza.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<AtualizaEventArgs, ACBrDISInterop.AtualizaCallback> onAtualiza;

		#endregion Fields

		#region Constructor

		public ACBrDIS()
		{
			onAtualiza = new ACBrEventHandler<AtualizaEventArgs, ACBrDISInterop.AtualizaCallback>(this, OnAtualizaCallback, ACBrDISInterop.DIS_SetOnAtualiza);
		}

		#endregion Constructor

		#region Properties

		public bool Ativo
		{
			get
			{
				return GetBool(ACBrDISInterop.DIS_GetAtivo);
			}
		}

		public ModeloDIS Modelo
		{
			get
			{
				return (ModeloDIS)GetInt32(ACBrDISInterop.DIS_GetModelo);
			}
			set
			{
				SetInt32(ACBrDISInterop.DIS_SetModelo, (int)value);
			}
		}

		public string ModeloStr
		{
			get
			{
				return GetString(ACBrDISInterop.DIS_GetModeloStr);
			}
		}

		public ACBrDevice Device { get; private set; }

		public Point Cursor
		{
			get
			{
				int x;
				int y;

				int ret = ACBrDISInterop.DIS_GetCursor(this.Handle, out x, out y);
				CheckResult(ret);

				return new Point(x, y);
			}
		}

		public int LinhasCount
		{
			get
			{
				return GetInt32(ACBrDISInterop.DIS_GetLinhasCount);
			}
			set
			{
				SetInt32(ACBrDISInterop.DIS_SetLinhasCount, value);
			}
		}

		public int Colunas
		{
			get
			{
				return GetInt32(ACBrDISInterop.DIS_GetColunas);
			}
			set
			{
				SetInt32(ACBrDISInterop.DIS_SetColunas, value);
			}
		}

		public Alinhamento Alinhamento
		{
			get
			{
				return (Alinhamento)GetInt32(ACBrDISInterop.DIS_GetAlinhamento);
			}
			set
			{
				SetInt32(ACBrDISInterop.DIS_SetAlinhamento, Convert.ToInt32(value));
			}
		}

		public int Intervalo
		{
			get
			{
				return GetInt32(ACBrDISInterop.DIS_GetIntervalo);
			}
			set
			{
				SetInt32(ACBrDISInterop.DIS_SetIntervalo, value);
			}
		}

		public int Passos
		{
			get
			{
				return GetInt32(ACBrDISInterop.DIS_GetPassos);
			}
			set
			{
				SetInt32(ACBrDISInterop.DIS_SetPassos, value);
			}
		}

		public bool RemoveAcentos
		{
			get
			{
				return GetBool(ACBrDISInterop.DIS_GetRemoveAcentos);
			}
			set
			{
				SetBool(ACBrDISInterop.DIS_SetRemoveAcentos, value);
			}
		}

		public int IntervaloEnvioBytes
		{
			get
			{
				return GetInt32(ACBrDISInterop.DIS_GetIntervaloEnvioBytes);
			}
			set
			{
				SetInt32(ACBrDISInterop.DIS_SetIntervaloEnvioBytes, value);
			}
		}

		public bool Trabalhando
		{
			get
			{
				return GetBool(ACBrDISInterop.DIS_GetTrabalhando);
			}
		}

		#endregion Properties

		#region Methods

		public void Ativar()
		{
			int ret = ACBrDISInterop.DIS_Ativar(this.Handle);
			CheckResult(ret);
		}

		public void Desativar()
		{
			int ret = ACBrDISInterop.DIS_Desativar(this.Handle);
			CheckResult(ret);
		}

		public void LimparDisplay()
		{
			int ret = ACBrDISInterop.DIS_LimparDisplay(this.Handle);
			CheckResult(ret);
		}

		public void LimparLinha(int linha)
		{
			int ret = ACBrDISInterop.DIS_LimparLinha(this.Handle, linha);
			CheckResult(ret);
		}

		public void PosicionarCursor(int linha, int coluna)
		{
			int ret = ACBrDISInterop.DIS_PosicionarCursor(this.Handle, linha, coluna);
			CheckResult(ret);
		}

		public void Escrever(string text)
		{
			int ret = ACBrDISInterop.DIS_Escrever(this.Handle, ToUTF8(text));
			CheckResult(ret);
		}

		public void ExibirLinha(int linha, string text)
		{
			int ret = ACBrDISInterop.DIS_ExibirLinha(this.Handle, linha, ToUTF8(text));
			CheckResult(ret);
		}

		public void ExibirLinha(int linha, string text, Alinhamento alinhamento)
		{
			int ret = ACBrDISInterop.DIS_ExibirLinhaAlinhamento(this.Handle, linha, ToUTF8(text), Convert.ToInt32(alinhamento));
			CheckResult(ret);
		}

		public void ExibirLinha(int linha, string text, EfeitoExibir efeito)
		{
			int ret = ACBrDISInterop.DIS_ExibirLinhaEfeito(this.Handle, linha, ToUTF8(text), Convert.ToInt32(efeito));
			CheckResult(ret);
		}

		public void RolarLinha(int linha, EfeitoRolar efeito)
		{
			int ret = ACBrDISInterop.DIS_RolarLinha(this.Handle, linha, Convert.ToInt32(efeito));
			CheckResult(ret);
		}

		public void Parar()
		{
			int ret = ACBrDISInterop.DIS_Parar(this.Handle);
			CheckResult(ret);
		}

		public void Continuar()
		{
			int ret = ACBrDISInterop.DIS_Continuar(this.Handle);
			CheckResult(ret);
		}

		public void PararLinha(int linha)
		{
			int ret = ACBrDISInterop.DIS_PararLinha(this.Handle, linha);
			CheckResult(ret);
		}

		public void ContinuarLinha(int linha)
		{
			int ret = ACBrDISInterop.DIS_ContinuarLinha(this.Handle, linha);
			CheckResult(ret);
		}

		#region Override Methods

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrDISInterop.DIS_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr DIS não inicializado.");
			}
		}

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrDISInterop.DIS_Create);
			Device = new ACBrDevice(this);
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrDISInterop.DIS_Destroy);
			}
		}

		#endregion Override Methods

		#region EventHandlers

		[AllowReversePInvokeCalls]
		private void OnAtualizaCallback(int linha, string textoVisivel)
		{
			if (onAtualiza.IsAssigned)
			{
				AtualizaEventArgs e = new AtualizaEventArgs();
				e.Linha = linha;
				e.TextoVisivel = FromUTF8(textoVisivel);
				onAtualiza.Raise(e);
			}
		}

		#endregion EventHandlers

		#endregion Methods
	}
}