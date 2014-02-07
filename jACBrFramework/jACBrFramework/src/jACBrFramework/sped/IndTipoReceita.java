package jACBrFramework.sped;

/**
 * Tipo de receita.
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 17:27:06, revisao: $Id$
 */
public enum IndTipoReceita {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    ServicoPrestado(0, "0 - Receita própria - serviços prestados"),
    CobrancaDebitos(1, "1 - Receita própria - cobrança de débitos"),
    VendaMerc(2, "2 - Receita própria - venda de mercadorias"),
    ServicoPrePago(3, "3 - Receita própria - venda de serviço pré-pago"),
    OutrasProprias(4, "4 - Outras receitas próprias"),
    TerceiroCoFaturamento(5, "5 - Receitas de terceiros (co-faturamento)"),
    TerceiroOutras(9, "9 - Outras receitas de terceiros");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do indicador de tipo de receita.
     */
    private String descricao;
    /**
     * Codigo do indicador de tipo de receita.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    IndTipoReceita(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do indicador de tipo de receita.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do indicador de tipo de receita.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold> 
        
}