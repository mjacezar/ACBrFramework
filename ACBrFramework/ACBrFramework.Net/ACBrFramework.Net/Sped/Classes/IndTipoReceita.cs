namespace ACBrFramework.Sped
{
	/// Indicador do tipo de receita
	public enum IndTipoReceita
	{
		ServicoPrestado,          // 0 - Receita pr�pria - servi�os prestados;
		CobrancaDebitos,          // 1 - Receita pr�pria - cobran�a de d�bitos;
		VendaMerc,                // 2 - Receita pr�pria - venda de mercadorias;
		ServicoPrePago,           // 3 - Receita pr�pria - venda de servi�o pr�-pago;
		OutrasProprias,           // 4 - Outras receitas pr�prias;
		TerceiroCoFaturamento,    // 5 - Receitas de terceiros (co-faturamento};
		TerceiroOutras            // 9 - Outras receitas de terceiros
	};
}