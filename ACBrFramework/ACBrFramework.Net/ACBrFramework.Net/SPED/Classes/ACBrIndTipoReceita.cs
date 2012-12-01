namespace ACBrFramework.SPED
{
	/// Indicador do tipo de receita
	public enum ACBrIndTipoReceita
	{
		recServicoPrestado,          // 0 - Receita própria - serviços prestados;
		recCobrancaDebitos,          // 1 - Receita própria - cobrança de débitos;
		recVendaMerc,                // 2 - Receita própria - venda de mercadorias;
		recServicoPrePago,           // 3 - Receita própria - venda de serviço pré-pago;
		recOutrasProprias,           // 4 - Outras receitas próprias;
		recTerceiroCoFaturamento,    // 5 - Receitas de terceiros (co-faturamento};
		recTerceiroOutras            // 9 - Outras receitas de terceiros
	};
}