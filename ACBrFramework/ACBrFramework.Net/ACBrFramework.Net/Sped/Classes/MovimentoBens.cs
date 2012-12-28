namespace ACBrFramework.Sped
{
	/// Tipo de movimentação do bem ou componente
	public enum MovimentoBens
	{
		SI,             // SI = Saldo inicial de bens imobilizados
		IM,             // IM = Imobilização de bem individual
		IA,             // IA = Imobilização em Andamento - Componente
		CI,             // CI = Conclusão de Imobilização em Andamento – Bem Resultante
		MC,             // MC = Imobilização oriunda do Ativo Circulante
		BA,             // BA = Baixa do Saldo de ICMS - Fim do período de apropriação
		AT,             // AT = Alienação ou Transferência
		PE,             // PE = Perecimento, Extravio ou Deterioração
		OT              // OT = Outras Saídas do Imobilizado
	};
}