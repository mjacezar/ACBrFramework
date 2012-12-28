namespace ACBrFramework.Sped
{
	/// Situação do Documento
	public enum SituacaoDocto
	{
		Regular,                 // 00 - Documento regular
		ExtempRegular,           // 01 - Escrituração extemporânea de documento regular
		Cancelado,               // 02 - Documento cancelado
		CanceladoExtemp,         // 03 - Escrituração extemporânea de documento cancelado
		DoctoDenegado,           // 04 - NF-e ou CT-e - denegado
		DoctoNumInutilizada,     // 05 - NF-e ou CT-e - Numeração inutilizada
		FiscalCompl,             // 06 - Documento Fiscal Complementar
		ExtempCompl,             // 07 - Escrituração extemporânea de documento complementar
		RegimeEspecNEsp          // 08 - Documento Fiscal emitido com base em Regime Especial ou Norma Específica
	};
}