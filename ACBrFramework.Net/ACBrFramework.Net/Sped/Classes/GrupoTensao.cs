namespace ACBrFramework.Sped
{
	/// Código de grupo de tensão
	public enum GrupoTensao
	{
		Nenhum,      // '' - Vazio. Para uso quando o documento for cancelado.
		A1,          // 01 - A1 - Alta Tensão (230kV ou mais)
		A2,          // 02 - A2 - Alta Tensão (88 a 138kV)
		A3,          // 03 - A3 - Alta Tensão (69kV)
		A3a,         // 04 - A3a - Alta Tensão (30kV a 44kV)
		A4,          // 05 - A4 - Alta Tensão (2,3kV a 25kV)
		AS,          // 06 - AS - Alta Tensão Subterrâneo 06
		B107,        // 07 - B1 - Residencial 07
		B108,        // 08 - B1 - Residencial Baixa Renda 08
		B209,        // 09 - B2 - Rural 09
		B2Rural,     // 10 - B2 - Cooperativa de Eletrificação Rural
		B2Irrigacao, // 11 - B2 - Serviço Público de Irrigação
		B3,          // 12 - B3 - Demais Classes
		B4a,         // 13 - B4a - Iluminação Pública - rede de distribuição
		B4b          // 14 - B4b - Iluminação Pública - bulbo de lâmpada
	};
}