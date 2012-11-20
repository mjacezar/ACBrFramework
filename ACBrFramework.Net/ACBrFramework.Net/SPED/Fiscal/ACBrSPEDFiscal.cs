using System;
using System.Drawing;
using System.ComponentModel;

namespace ACBrFramework.SPEDFiscal
{
    [ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.SPED.Fiscal.ico.bmp")]
    class ACBrSPEDFiscal : ACBrComponent, IDisposable
    {

        #region Methods

        #region Override Methods

		protected internal override void OnInitializeComponent()
		{
            CallCreate(ACBrSPEDFiscalInterop.SPDF_Create);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

                    string error = GetString(ACBrSPEDFiscalInterop.SPDF_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

                    throw new ACBrException("ACBrSPEDFiscal não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (Handle != IntPtr.Zero)
			{
                CallDestroy(ACBrSPEDFiscalInterop.SPDF_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
    }
}
