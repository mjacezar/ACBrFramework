using System;

namespace ACBrFramework.SPEDFiscal
{
	/// Tipo do item � Atividades Industriais, Comerciais e Servi�os:
	public enum ACBrTipoItem
	{
		tiMercadoriaRevenda,    // 00 � Mercadoria para Revenda
		tiMateriaPrima,         // 01 � Mat�ria-Prima;
		tiEmbalagem,            // 02 � Embalagem;
		tiProdutoProcesso,      // 03 � Produto em Processo;
		tiProdutoAcabado,       // 04 � Produto Acabado;
		tiSubproduto,           // 05 � Subproduto;
		tiProdutoIntermediario, // 06 � Produto Intermedi�rio;
		tiMaterialConsumo,      // 07 � Material de Uso e Consumo;
		tiAtivoImobilizado,     // 08 � Ativo Imobilizado;
		tiServicos,             // 09 � Servi�os;
		tiOutrosInsumos,        // 10 � Outros Insumos;
		tiOutras                // 99 � Outras
	};
}
