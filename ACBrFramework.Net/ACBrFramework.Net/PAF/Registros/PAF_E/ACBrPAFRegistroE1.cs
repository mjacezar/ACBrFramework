using System;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{

    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("E11B3B88-1E35-49DA-803C-554FB6F79E5B")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP
	public sealed class ACBrPAFRegistroE1
	{
		#region Properties

		public string RazaoSocial { get; set; }

		public string UF { get; set; }

		public string CNPJ { get; set; }

		public string IE { get; set; }

		public string IM { get; set; }

		public string NUM_FAB { get; set; }

		public string MF_ADICIONAL { get; set; }

		public string TIPO_ECF { get; set; }

		public string MARCA_ECF { get; set; }

		public string MODELO_ECF { get; set; }

		public DateTime DT_EST { get; set; }

		public bool RegistroValido { get; set; }

		public bool InclusaoExclusao { get; set; }

		#endregion Properties
	}
}