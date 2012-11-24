using System;

namespace ACBrFramework.SPEDFiscal
{
	/// Indicador da origem do processo
	public enum ACBrOrigemProcesso
	{
		opSefaz,            // 0 - Sefaz
		opJusticaFederal,   // 1 - Justi�a Federal
		opJusticaEstadual,  // 2 - Justi�a Estadual
		opSecexRFB,         // 3 - Secex/RFB
		opOutros,           // 9 - Outros
		opNenhum           // Preencher vazio
	};
}
