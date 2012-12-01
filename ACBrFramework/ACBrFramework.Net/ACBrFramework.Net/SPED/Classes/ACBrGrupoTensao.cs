namespace ACBrFramework.SPED
{
	/// C�digo de grupo de tens�o
	public enum ACBrGrupoTensao
	{
		gtNenhum,      // '' - Vazio. Para uso quando o documento for cancelado.
		gtA1,          // 01 - A1 - Alta Tens�o (230kV ou mais)
		gtA2,          // 02 - A2 - Alta Tens�o (88 a 138kV)
		gtA3,          // 03 - A3 - Alta Tens�o (69kV)
		gtA3a,         // 04 - A3a - Alta Tens�o (30kV a 44kV)
		gtA4,          // 05 - A4 - Alta Tens�o (2,3kV a 25kV)
		gtAS,          // 06 - AS - Alta Tens�o Subterr�neo 06
		gtB107,        // 07 - B1 - Residencial 07
		gtB108,        // 08 - B1 - Residencial Baixa Renda 08
		gtB209,        // 09 - B2 - Rural 09
		gtB2Rural,     // 10 - B2 - Cooperativa de Eletrifica��o Rural
		gtB2Irrigacao, // 11 - B2 - Servi�o P�blico de Irriga��o
		gtB3,          // 12 - B3 - Demais Classes
		gtB4a,         // 13 - B4a - Ilumina��o P�blica - rede de distribui��o
		gtB4b          // 14 - B4b - Ilumina��o P�blica - bulbo de l�mpada
	};
}