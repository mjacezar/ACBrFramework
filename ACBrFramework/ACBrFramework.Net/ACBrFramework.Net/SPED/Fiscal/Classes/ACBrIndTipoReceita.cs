using System;

namespace ACBrFramework.SPEDFiscal
{
	/// Indicador do tipo de receita
	public enum ACBrIndTipoReceita
	{
		recServicoPrestado,          // 0 - Receita pr�pria - servi�os prestados;
		recCobrancaDebitos,          // 1 - Receita pr�pria - cobran�a de d�bitos;
		recVendaMerc,                // 2 - Receita pr�pria - venda de mercadorias;
		recServicoPrePago,           // 3 - Receita pr�pria - venda de servi�o pr�-pago;
		recOutrasProprias,           // 4 - Outras receitas pr�prias;
		recTerceiroCoFaturamento,    // 5 - Receitas de terceiros (co-faturamento};
		recTerceiroOutras            // 9 - Outras receitas de terceiros
	};
}
