using System;

namespace ACBrFramework.SPEDFiscal
{
	/// Tipo de movimenta��o do bem ou componente
	public enum ACBrMovimentoBens
	{
		mbcSI,             // SI = Saldo inicial de bens imobilizados
		mbcIM,             // IM = Imobiliza��o de bem individual
		mbcIA,             // IA = Imobiliza��o em Andamento - Componente
		mbcCI,             // CI = Conclus�o de Imobiliza��o em Andamento � Bem Resultante
		mbcMC,             // MC = Imobiliza��o oriunda do Ativo Circulante
		mbcBA,             // BA = Baixa do Saldo de ICMS - Fim do per�odo de apropria��o
		mbcAT,             // AT = Aliena��o ou Transfer�ncia
		mbcPE,             // PE = Perecimento, Extravio ou Deteriora��o
		mbcOT              // OT = Outras Sa�das do Imobilizado
	};
}
