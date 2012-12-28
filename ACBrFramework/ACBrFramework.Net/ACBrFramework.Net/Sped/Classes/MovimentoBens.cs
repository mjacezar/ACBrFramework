namespace ACBrFramework.Sped
{
	/// Tipo de movimenta��o do bem ou componente
	public enum MovimentoBens
	{
		SI,             // SI = Saldo inicial de bens imobilizados
		IM,             // IM = Imobiliza��o de bem individual
		IA,             // IA = Imobiliza��o em Andamento - Componente
		CI,             // CI = Conclus�o de Imobiliza��o em Andamento � Bem Resultante
		MC,             // MC = Imobiliza��o oriunda do Ativo Circulante
		BA,             // BA = Baixa do Saldo de ICMS - Fim do per�odo de apropria��o
		AT,             // AT = Aliena��o ou Transfer�ncia
		PE,             // PE = Perecimento, Extravio ou Deteriora��o
		OT              // OT = Outras Sa�das do Imobilizado
	};
}