namespace ACBrFramework.SPED
{
	/// Código de grupo de tensão
	public enum ACBrGrupoTensao
	{
		gtNenhum,      // '' - Vazio. Para uso quando o documento for cancelado.
		gtA1,          // 01 - A1 - Alta Tensão (230kV ou mais)
		gtA2,          // 02 - A2 - Alta Tensão (88 a 138kV)
		gtA3,          // 03 - A3 - Alta Tensão (69kV)
		gtA3a,         // 04 - A3a - Alta Tensão (30kV a 44kV)
		gtA4,          // 05 - A4 - Alta Tensão (2,3kV a 25kV)
		gtAS,          // 06 - AS - Alta Tensão Subterrâneo 06
		gtB107,        // 07 - B1 - Residencial 07
		gtB108,        // 08 - B1 - Residencial Baixa Renda 08
		gtB209,        // 09 - B2 - Rural 09
		gtB2Rural,     // 10 - B2 - Cooperativa de Eletrificação Rural
		gtB2Irrigacao, // 11 - B2 - Serviço Público de Irrigação
		gtB3,          // 12 - B3 - Demais Classes
		gtB4a,         // 13 - B4a - Iluminação Pública - rede de distribuição
		gtB4b          // 14 - B4b - Iluminação Pública - bulbo de lâmpada
	};
}