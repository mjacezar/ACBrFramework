using System;
using System.ComponentModel;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("9FA0F390-307D-44AE-972F-6E63BB77509F")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	[DesignerCategory("ACBr")]
	[DesignTimeVisible(true)]
	public abstract class ACBrComponent : ACBrClassInterop, IComponent
	{
		#region Fields

		private ISite site;

		#endregion Fields

		#region Constructor

		protected ACBrComponent() : base()
		{
		}

		#endregion Constructor

		#region IComponent

		ISite IComponent.Site
		{
			get
			{
				return this.site;
			}
			set
			{
				this.site = value;
			}
		}

		[Browsable(false)]
		protected virtual bool DesignMode
		{
			get
			{
				bool isDesignMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

				if (!isDesignMode)
				{
					isDesignMode = site != null && site.DesignMode;
				}

				return isDesignMode;
			}
		}

		#endregion IComponent
	}
}