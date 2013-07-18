using System;

namespace ACBrFramework
{
	#region COM Interop

#if COM_INTEROP

	#region Documentation
	/// <summary>
	/// Redefine o tipo EventHandler para um delegate vazio
	/// As assinaturas de eventos no .Net são diferentes dos componentes COM
	/// Ex: um evento OnClick() no VB6 é OnClick(object sender, EventArgs e) no .Net
	/// Esse novo delegate ajuda a manter o interop mais amigável ao COM
	/// </summary>
	#endregion Documentation
	public delegate void EventHandler();
	
#endif

	#endregion COM Interop

	internal class ACBrEventHandler<TEventArgs, TCallback> : ACBrInteropEventHandlerBase<EventHandler<TEventArgs>, TCallback>
		where TEventArgs : EventArgs
		where TCallback : class
	{
		#region Constructor

		public ACBrEventHandler(ACBrInteropBase component, TCallback callback, SetCallbackEntryPointDelegate setCallback)
			: base(component, callback, setCallback)
		{
		}

		#endregion Constructor

		#region Methods

#if COM_INTEROP
		public new void Add(Delegate value)
		{
			base.Add(value);
		}

		public new void Remove(Delegate value)
		{
			base.Remove(value);
		}
#else
		public void Add(EventHandler<TEventArgs> value)
		{
			base.Add(value);
		}

		public void Remove(EventHandler<TEventArgs> value)
		{
			base.Remove(value);
		}
#endif
		public void Raise(TEventArgs e)
		{
			base.Raise(e);
		}

		#endregion Methods
	}

	internal class ACBrEventHandler<TCallback> : ACBrInteropEventHandlerBase<EventHandler, TCallback> where TCallback : class
	{
		#region Constructor

		public ACBrEventHandler(ACBrInteropBase component, TCallback callback, SetCallbackEntryPointDelegate setCallback)
			: base(component, callback, setCallback)
		{
		}

		#endregion Constructor

		#region Methods

		public void Add(EventHandler value)
		{
			base.Add(value);
		}

		public void Remove(EventHandler value)
		{
			base.Remove(value);
		}

		public new void Raise(EventArgs e)
		{
			base.Raise(e);
		}

		public void Raise()
		{
			base.Raise(EventArgs.Empty);
		}

		#endregion Methods
	}
}