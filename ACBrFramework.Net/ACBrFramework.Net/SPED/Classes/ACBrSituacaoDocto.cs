namespace ACBrFramework.SPED
{
	/// Situação do Documento
	public enum ACBrSituacaoDocto
	{
		sdRegular,                 // 00 - Documento regular
		sdExtempRegular,           // 01 - Escrituração extemporânea de documento regular
		sdCancelado,               // 02 - Documento cancelado
		sdCanceladoExtemp,         // 03 - Escrituração extemporânea de documento cancelado
		sdDoctoDenegado,           // 04 - NF-e ou CT-e - denegado
		sdDoctoNumInutilizada,     // 05 - NF-e ou CT-e - Numeração inutilizada
		sdFiscalCompl,             // 06 - Documento Fiscal Complementar
		sdExtempCompl,             // 07 - Escrituração extemporânea de documento complementar
		sdRegimeEspecNEsp          // 08 - Documento Fiscal emitido com base em Regime Especial ou Norma Específica
	};
}