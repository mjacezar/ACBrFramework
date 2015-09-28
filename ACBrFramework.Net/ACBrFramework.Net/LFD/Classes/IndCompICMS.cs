namespace ACBrFramework.LFD
{
	public enum IndCompICMS
	{
		SemValor,         // 00- Sem valor de crédito do ICMS a complementar;
		DifICMSST,        // 01- Complemento relativo à diferença do ICMS da substituição tributária calculado a menor;
		DifAliqAtivoFixo, // 02- Complemento do diferencial de alíquotas do ICMS relativo a aquisições para o ativo fixo;
		AliqUsoConsumo,   // 03- Complemento do diferencial de alíquotas do ICMS relativo a aquisições para uso e/ou consumo;
		AliqOutrasSitu,   // 04- Complemento do diferencial de alíquotas do ICMS relativo a outras situações;
		AntecTributaria,  // 05- Complemento relativo à antecipação tributária;
		ProgBenFical,     // 06- Complemento relativo a programa de benefício fiscal;
		OutrasSituacoes   // 99- Outras situações (descrever em observações)     
    };


}