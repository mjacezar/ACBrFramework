using System;

namespace ACBrFramework.SPEDFiscal
{
	/// Situa��o do Documento
	public enum ACBrSituacaoDocto
	{
		sdRegular,                 // 00 - Documento regular
		sdExtempRegular,           // 01 - Escritura��o extempor�nea de documento regular
		sdCancelado,               // 02 - Documento cancelado
		sdCanceladoExtemp,         // 03 - Escritura��o extempor�nea de documento cancelado
		sdDoctoDenegado,           // 04 - NF-e ou CT-e - denegado
		sdDoctoNumInutilizada,     // 05 - NF-e ou CT-e - Numera��o inutilizada
		sdFiscalCompl,             // 06 - Documento Fiscal Complementar
		sdExtempCompl,             // 07 - Escritura��o extempor�nea de documento complementar
		sdRegimeEspecNEsp          // 08 - Documento Fiscal emitido com base em Regime Especial ou Norma Espec�fica
	};
}
