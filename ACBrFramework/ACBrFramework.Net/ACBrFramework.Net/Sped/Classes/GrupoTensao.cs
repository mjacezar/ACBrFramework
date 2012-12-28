namespace ACBrFramework.Sped
{
	/// C�digo de grupo de tens�o
	public enum GrupoTensao
	{
		Nenhum,      // '' - Vazio. Para uso quando o documento for cancelado.
		A1,          // 01 - A1 - Alta Tens�o (230kV ou mais)
		A2,          // 02 - A2 - Alta Tens�o (88 a 138kV)
		A3,          // 03 - A3 - Alta Tens�o (69kV)
		A3a,         // 04 - A3a - Alta Tens�o (30kV a 44kV)
		A4,          // 05 - A4 - Alta Tens�o (2,3kV a 25kV)
		AS,          // 06 - AS - Alta Tens�o Subterr�neo 06
		B107,        // 07 - B1 - Residencial 07
		B108,        // 08 - B1 - Residencial Baixa Renda 08
		B209,        // 09 - B2 - Rural 09
		B2Rural,     // 10 - B2 - Cooperativa de Eletrifica��o Rural
		B2Irrigacao, // 11 - B2 - Servi�o P�blico de Irriga��o
		B3,          // 12 - B3 - Demais Classes
		B4a,         // 13 - B4a - Ilumina��o P�blica - rede de distribui��o
		B4b          // 14 - B4b - Ilumina��o P�blica - bulbo de l�mpada
	};
}