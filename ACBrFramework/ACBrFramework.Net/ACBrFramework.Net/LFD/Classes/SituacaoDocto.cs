namespace ACBrFramework.LFD
{
	/// Situação do Documento
	public enum SituacaoDocto
	{
		Regular,                     // 00 - Documento regular
		ExtempRegular,               // 01 - Escrituração extemporânea de documento regular
		Cancelado,                   // 02 - Documento cancelado
		CancelamentoDocAnterior,     // 03 - Cancelamento de cupom fiscal anterior
		CanceladoExtemp,             // 04 - Escrituração extemporânea de documento cancelado
		DesfazimentoNegocio,         // 05 - Desfazimento de negócio
		DocumentoReferenciado,       // 06 - Documento referenciado
		RegularSimples,              // 07 - Documento regular - Simples Nacional
		ExtempRegularSimples,        // 08 - Documento regular extemporâneo - Simples Nacional
		LancDoctoregular,            // 50 - Lançamento de documento regular
		LancExtempDoctoRegular,      // 51 - Lançamento de documento regular extemporâneo
		LancDoctoCancelado,          // 52 - Lançamento de documento cancelado
		LancCancelamentoDocAnterior, // 53 - Lançamento de cancelamento de cupom fiscal anterior
		LancCanceladoExtemp,         // 54 - Lançamento de documento cancelado extemporâneo
		LancDesfazimentoNegocio,     // 55 - Lançamento de desfazimento de negócio
		LancDocumentoReferenciado,   // 56 - Lançamento de documento referenciado
		LancDoctoOutrasSituacoes,    // 58 - Lançamento de documento em outras situações de repercussão nula
		LancDoctoRepercNevativa      // 59 - Lançamento de documento com repercussão negativa  
	};
}