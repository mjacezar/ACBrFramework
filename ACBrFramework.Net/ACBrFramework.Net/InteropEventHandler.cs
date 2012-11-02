using System;

namespace ACBrFramework
{
	public class InteropEventHandler<T, TCallback>
		where T : EventArgs
		where TCallback : class
	{
		#region InnerTypes

		public delegate int SetCallbackEntryPointDelegate(IntPtr handle, TCallback callback);

		#endregion InnerTypes

		#region Fields

		private readonly ACBrInteropBase component;
		private readonly TCallback callback;
		private readonly SetCallbackEntryPointDelegate setCallback;

		private EventHandler<T> eventHandler;

		#endregion Fields

		#region Properties

		public bool IsAssigned
		{
			get
			{
				return this.eventHandler != null;
			}
		}

		#endregion Properties

		#region Constructor

		public InteropEventHandler(ACBrInteropBase component, TCallback callback, SetCallbackEntryPointDelegate setCallback)
		{
			this.component = component;
			this.callback = callback;
			this.setCallback = setCallback;
		}

		#endregion Constructor

		#region Methods

		public void Add(EventHandler<T> value)
		{
			bool isAssigned = this.IsAssigned;
			eventHandler = (EventHandler<T>)Delegate.Combine(eventHandler, value);

			if (!isAssigned)
			{
				int ret = setCallback(component.Handle, callback);
				component.CheckResult(ret);
			}
		}

		public void Remove(EventHandler<T> value)
		{
			eventHandler = (EventHandler<T>)Delegate.Remove(eventHandler, value);

			if (eventHandler == null)
			{
				int ret = setCallback(component.Handle, null);
				component.CheckResult(ret);
			}
		}

		public void Raise(T e)
		{
			if (eventHandler != null)
			{
				eventHandler(component, e);
			}
		}

		#endregion Methods
	}

	public class InteropEventHandler<TCallback> : InteropEventHandler<EventArgs, TCallback> where TCallback : class
	{

		#region Constructor

		public InteropEventHandler(ACBrInteropBase component, TCallback callback, SetCallbackEntryPointDelegate setCallback)
			: base(component, callback, setCallback)
		{
		}

		#endregion Constructor

	}

}