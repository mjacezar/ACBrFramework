﻿using System;

namespace ACBrFramework
{
	public sealed class ACBrPAFRegistroD2
	{
		#region Constructor

		public ACBrPAFRegistroD2()
		{
			RegistroD3 = new ACBrPAFRegistrosD3();
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

		public decimal VLT_DAV { get; set; }

		public string COO_DFV { get; set; }

		public string NUMERO_ECF { get; set; }

		public string NOME_CLIENTE { get; set; }

		public string CPF_CNPJ { get; set; }

		public bool RegistroValido { get; set; }

		public ACBrPAFRegistrosD3 RegistroD3 { get; private set; }

		#endregion Properties
	}
}