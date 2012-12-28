namespace ACBrFramework.Sped
{
	/// Situa��o do Documento
	public enum SituacaoDocto
	{
		Regular,                 // 00 - Documento regular
		ExtempRegular,           // 01 - Escritura��o extempor�nea de documento regular
		Cancelado,               // 02 - Documento cancelado
		CanceladoExtemp,         // 03 - Escritura��o extempor�nea de documento cancelado
		DoctoDenegado,           // 04 - NF-e ou CT-e - denegado
		DoctoNumInutilizada,     // 05 - NF-e ou CT-e - Numera��o inutilizada
		FiscalCompl,             // 06 - Documento Fiscal Complementar
		ExtempCompl,             // 07 - Escritura��o extempor�nea de documento complementar
		RegimeEspecNEsp          // 08 - Documento Fiscal emitido com base em Regime Especial ou Norma Espec�fica
	};
}