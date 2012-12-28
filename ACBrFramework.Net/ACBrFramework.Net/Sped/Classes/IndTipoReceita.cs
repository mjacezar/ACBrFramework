namespace ACBrFramework.Sped
{
	/// Indicador do tipo de receita
	public enum IndTipoReceita
	{
		ServicoPrestado,          // 0 - Receita própria - serviços prestados;
		CobrancaDebitos,          // 1 - Receita própria - cobrança de débitos;
		VendaMerc,                // 2 - Receita própria - venda de mercadorias;
		ServicoPrePago,           // 3 - Receita própria - venda de serviço pré-pago;
		OutrasProprias,           // 4 - Outras receitas próprias;
		TerceiroCoFaturamento,    // 5 - Receitas de terceiros (co-faturamento};
		TerceiroOutras            // 9 - Outras receitas de terceiros
	};
}