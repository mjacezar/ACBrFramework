using System;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("218422c6-f2ee-47dc-aea0-dc8f66b0d031")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

    public sealed class ACBrPAFRegistroD2
	{
		#region Constructor

		public ACBrPAFRegistroD2()
		{
			RegistroD3 = new ACBrPAFRegistrosD3();
            RegistroD4 = new ACBrPAFRegistrosD4();
		}

		#endregion Constructor

		#region Properties

		public string NUM_FAB { get; set; }

		public string MF_ADICIONAL { get; set; }

		public string TIPO_ECF { get; set; }

		public string MARCA_ECF { get; set; }

		public string MODELO_ECF { get; set; }

		public string COO { get; set; }

		public string NUM_DAV { get; set; }

		public DateTime DT_DAV { get; set; }

		public string TIT_DAV { get; set; }

		public decimal VLT_DAV {
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

		public string COO_DFV { get; set; }

		public string NUMERO_ECF { get; set; }

		public string NOME_CLIENTE { get; set; }

		public string CPF_CNPJ { get; set; }

		public bool RegistroValido { get; set; }

		public ACBrPAFRegistrosD3 RegistroD3 { get; private set; }

        public ACBrPAFRegistrosD4 RegistroD4 { get; private set; }

		#endregion Properties
	}
}