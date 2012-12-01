namespace ACBrFramework.SPED
{
	/// Tipo de movimentação do bem ou componente
	public enum ACBrMovimentoBens
	{
		mbcSI,             // SI = Saldo inicial de bens imobilizados
		mbcIM,             // IM = Imobilização de bem individual
		mbcIA,             // IA = Imobilização em Andamento - Componente
		mbcCI,             // CI = Conclusão de Imobilização em Andamento – Bem Resultante
		mbcMC,             // MC = Imobilização oriunda do Ativo Circulante
		mbcBA,             // BA = Baixa do Saldo de ICMS - Fim do período de apropriação
		mbcAT,             // AT = Alienação ou Transferência
		mbcPE,             // PE = Perecimento, Extravio ou Deterioração
		mbcOT              // OT = Outras Saídas do Imobilizado
	};
}