using System;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{

    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("67524F20-FAF3-4BF5-BDB5-4D3FE51AB050")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

    public sealed class ACBrPAFRegistroH2
	{
		#region Properties

		public string NUM_FAB { get; set; }

		public string MF_ADICIONAL { get; set; }

		public string TIPO_ECF { get; set; }

		public string MARCA_ECF { get; set; }

		public string MODELO_ECF { get; set; }

		public string CNPJ_CRED_CARTAO { get; set; }

		public int COO { get; set; }

		public int CCF { get; set; }

		public decimal VLR_TROCO {
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;
            #region COM_INTEROP

#if COM_INTEROP
            [param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }

		public DateTime DT_TROCO { get; set; }

		public string CPF { get; set; }

		public string Titulo { get; set; }

		public bool InclusaoExclusao { get; set; }

		public bool RegistroValido { get; set; }

		#endregion Properties
	}
}