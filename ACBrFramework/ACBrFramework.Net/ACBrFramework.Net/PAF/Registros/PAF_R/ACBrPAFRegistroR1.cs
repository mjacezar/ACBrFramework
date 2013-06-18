using System;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("92441A52-71E5-4720-B0C2-68465C026113")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAFRegistroR1
	{
		#region Properties

		public string NUM_FAB { get; set; }

		public string MF_ADICIONAL { get; set; }

		public string TIPO_ECF { get; set; }

		public string MARCA_ECF { get; set; }

		public string MODELO_ECF { get; set; }

		public string VERSAO_SB { get; set; }

		public DateTime DT_INST_SB { get; set; }

		public DateTime HR_INST_SB { get; set; }

		public int NUM_SEQ_ECF { get; set; }

		public string CNPJ { get; set; }

		public string IE { get; set; }

		public string CNPJ_SH { get; set; }

		public string IE_SH { get; set; }

		public string IM_SH { get; set; }

		public string NOME_SH { get; set; }

		public string NOME_PAF { get; set; }

		public string VER_PAF { get; set; }

		public string COD_MD5 { get; set; }

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public string ER_PAF_ECF { get; set; }

		public bool InclusaoExclusao { get; set; }

		public bool RegistroValido { get; set; }

		#endregion Properties
	}
}