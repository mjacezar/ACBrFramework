using System;
using System.ComponentModel;

namespace ACBrFramework
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public abstract class ACBrComposedComponent : ACBrInteropBase
	{
		#region Properties

		[Browsable(false)]
		public ACBrComponent Parent { get; private set; }

		[Browsable(false)]
		public override IntPtr Handle
		{
			get
			{
				return Parent.Handle;
			}
		}

		#endregion Properties

		#region Constructor

		protected ACBrComposedComponent(ACBrComponent parent)
		{
			this.Parent = parent;
		}

		#endregion Constructor

		#region Methods

		protected internal override void CheckResult(int result)
		{
			Parent.CheckResult(result);
		}

		#endregion Methods
	}
}