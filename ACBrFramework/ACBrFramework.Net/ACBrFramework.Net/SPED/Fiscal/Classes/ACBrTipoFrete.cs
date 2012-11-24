using System;

namespace ACBrFramework.SPEDFiscal
{
	/// Indicador do tipo do frete
	public enum ACBrTipoFrete
	{
		tfPorContaTerceiros,     // 0 - Por conta de terceiros
		tfPorContaEmitente,      // 1 - Por conta do emitente
		tfPorContaDestinatario,  // 2 - Por conta do destinat�rio
		tfSemCobrancaFrete,      // 9 - Sem cobran�a de frete
		tfNenhum                 // Preencher vazio
	};
}
