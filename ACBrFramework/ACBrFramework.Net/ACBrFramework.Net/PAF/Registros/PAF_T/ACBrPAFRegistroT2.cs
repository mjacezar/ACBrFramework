using System;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("0475014E-606A-4CB4-A7B7-C8694F54BAC0")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAFRegistroT2
	{
		#region Properties

		public DateTime DT_MOV { get; set; }

		public string TP_DOCTO { get; set; }

		public string SERIE { get; set; }

		public int NUM_BILH_I { get; set; }

		public int NUM_BILH_F { get; set; }

		public string NUM_ECF { get; set; }

		public int CRZ { get; set; }

		public string CFOP { get; set; }

		public double VL_CONT { get; set; }

		public double VL_BASECALC { get; set; }

		public double ALIQ { get; set; }

		public double VL_IMPOSTO { get; set; }

		public double VL_ISENTAS { get; set; }

		public double VL_OUTRAS { get; set; }

		public bool RegistroValido { get; set; }

		#endregion Properties
	}
}