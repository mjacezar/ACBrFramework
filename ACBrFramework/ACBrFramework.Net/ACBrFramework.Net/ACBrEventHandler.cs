using System;

namespace ACBrFramework
{
	internal class ACBrEventHandler<TEventArgs, TCallback> : ACBrInteropEventHandlerBase<EventHandler<TEventArgs>, TCallback>
		where TEventArgs : EventArgs
		where TCallback : class
	{
		#region Constructor

		public ACBrEventHandler(ACBrInteropBase component, TCallback callback, SetCallbackEntryPointDelegate setCallback) : base(component, callback, setCallback) { }

		#endregion Constructor

		#region Methods

		public void Add(EventHandler<TEventArgs> value)
		{
			base.Add(value);
		}

		public void Remove(EventHandler<TEventArgs> value)
		{
			base.Remove(value);
		}

		public void Raise(TEventArgs e)
		{
			base.Raise(e);
		}

		#endregion Methods
	}

	internal class ACBrEventHandler<TCallback> : ACBrInteropEventHandlerBase<EventHandler, TCallback> where TCallback : class
	{
		#region Constructor

		public ACBrEventHandler(ACBrInteropBase component, TCallback callback, SetCallbackEntryPointDelegate setCallback) : base(component, callback, setCallback) { }

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

		public void Raise(EventArgs e)
		{
			base.Raise(e);
		}

		public void Raise()
		{
			base.Raise(EventArgs.Empty);
		}

		#endregion Methods
	}

	internal sealed class ACBrEventHandler : ACBrEventHandler<ACBrEventHandler.Callback>
	{
		#region InnerTypes

		public delegate void Callback();

		#endregion InnerTypes

		#region Constructor

		public ACBrEventHandler(ACBrInteropBase component, Callback callback, SetCallbackEntryPointDelegate setCallback) : base(component, callback, setCallback) { }

		#endregion Constructor
	}
}