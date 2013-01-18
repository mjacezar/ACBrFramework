using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.NFE
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.NFE.ico.bmp")]
	public class ACBrNFE : ACBrComponent, IDisposable
	{
		#region Events
				
		#endregion Events

		#region Fields
		#endregion Fields

		#region Constructor

		public ACBrNFE()
		{
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public NFEConfiguracoes Configuracoes { get; private set; }
			
		#endregion Properties

		#region Methods

		#region Funções

			#endregion Funções

		#region EventHandlers

			#endregion EventHandlers

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrNFEInterop.NFE_Create);
			this.Configuracoes = new NFEConfiguracoes(this);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrNFEInterop.NFE_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBrNFE não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrNFEInterop.NFE_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}