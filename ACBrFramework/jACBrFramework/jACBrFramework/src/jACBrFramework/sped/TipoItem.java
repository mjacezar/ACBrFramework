package jACBrFramework.sped;

/**
 *  Tipo do item – items Industriais, Comerciais e Servicos.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 09:52:38, revisao: $Id$
 */
public enum TipoItem {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    MercadoriaRevenda(0, "00 – Mercadoria para Revenda"),
    MateriaPrima(1, "01 – Matéria-Prima"),
    Embalagem(2, "02 – Embalagem"),
    ProdutoProcesso(3, "Produto em Processo"),
    ProdutoAcabado(4, "Produto Acabado"),
    Subproduto(5, "05 – Subproduto"),
    ProdutoIntermediario(6, "06 – Produto Intermediário"),
    MaterialConsumo(7, "07 – Material de Uso e Consumo"),
    AtivoImobilizado(8, "08 – Ativo Imobilizado"),
    Servicos(9, "09 – Serviços"),
    OutrosInsumos(10, "10 – Outros Insumos"),
    Outras(99, "99 – Outras");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de item.
     */
    private String descricao;
    /**
     * Codigo do tipo de item.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoItem(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de item.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de item.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       
}