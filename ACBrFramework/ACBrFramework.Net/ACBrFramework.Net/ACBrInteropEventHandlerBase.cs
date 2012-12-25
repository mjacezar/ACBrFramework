using System;
using System.ComponentModel;

namespace ACBrFramework
{
	internal abstract class ACBrInteropEventHandlerBase<TEventHandler, TCallback>
		where TEventHandler : class
		where TCallback : class
	{
		#region InnerTypes

		public delegate int SetCallbackEntryPointDelegate(IntPtr handle, TCallback callback);

		#endregion InnerTypes

		#region Fields

		private readonly ACBrInteropBase component;
		private readonly TCallback callback;
		private readonly SetCallbackEntryPointDelegate setCallback;

		private Delegate eventHandler;

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

		protected ACBrInteropEventHandlerBase(ACBrInteropBase component, TCallback callback, SetCallbackEntryPointDelegate setCallback)
		{
			this.component = component;
			this.callback = callback;
			this.setCallback = setCallback;
		}

		#endregion Constructor

		#region Methods

		protected void Add(Delegate value)
		{
			bool isAssigned = this.IsAssigned;
			eventHandler = Delegate.Combine(eventHandler, value);

			if (!isAssigned)
			{
				int ret = setCallback(component.Handle, callback);
				component.CheckResult(ret);
			}
		}

		protected void Remove(Delegate value)
		{
			eventHandler = Delegate.Remove(eventHandler, value);

			if (eventHandler == null)
			{
				int ret = setCallback(component.Handle, null);
				component.CheckResult(ret);
			}
		}

		protected void Raise(EventArgs e)
		{
			if (eventHandler != null)
			{
				ISynchronizeInvoke synchronizeInvoke = eventHandler.Target as ISynchronizeInvoke;

				if (synchronizeInvoke == null)
				{
					eventHandler.DynamicInvoke(this.component, e);
				}
				else
				{
					synchronizeInvoke.Invoke(eventHandler, new object[] { this.component, e });
				}
			}
		}

		#endregion Methods
	}
}