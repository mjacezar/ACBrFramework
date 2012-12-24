using System;
using System.Collections.Generic;
using System.Linq;

namespace ACBrFramework.SPED
{
	class ACBrSPEDBloco0
	{
		public ACBrSPEDBloco0()
		{
			Registro0000 = new ACBrSpedRegistro0000();
			Registro0001 = new ACBrSpedRegistro0001();
		}

		public ACBrSpedRegistro0000 Registro0000 { get; private set; }
		public ACBrSpedRegistro0001 Registro0001 { get; private set; }
	}
}
