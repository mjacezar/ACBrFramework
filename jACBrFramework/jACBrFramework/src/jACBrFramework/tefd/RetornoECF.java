package jACBrFramework.tefd;

/**
 * Retorno da ECF.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 14:33:52, revisao: $Id$
 */
public enum RetornoECF {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Livre('L', "Livre"),
    VendaDeItens('V', "Venda"),
    PagamentoOuSubTotal('P', "Pagamento ou subtotal"),
    CDC('C', "CDC"),
    RelatorioGerencial('G', "Relatório Gerencial"),
    CDCouRelatorioGerencial('R', "CDC ou Relatório Gerencial"),
    RecebimentoNaoFiscal('N', "Recebimento Não Fiscal"),
    Outro('O', "Outros");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do retorno.
     */
    private String descricao;
    /**
     * Codigo do retorno.
     */
    private char codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    RetornoECF(char pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do retorno.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do retorno.
     * @return the codigo
     */
    public char getCodigo() {
        return codigo;
    }

    /**
     * Codigo do retorno.
     * @return the codigo
     */
    public int getCodigoInt() {
        return (int)codigo;
    }
    
    /**
     * Recupera o enum pelo codigo correspondente.
     * 
     * @param pCodigo codigo a ser recuperado.
     * @return 
     */
    public static RetornoECF valueOf(int pCodigo) {
        for (RetornoECF lRetornoECF : values()) {
            if (lRetornoECF.getCodigoInt()== pCodigo) return lRetornoECF;
        }
        return null;
    } 
    
    /**
     * Recupera o enum pelo codigo correspondente.
     * 
     * @param pCodigo codigo a ser recuperado.
     * @return 
     */
    public static RetornoECF valueOf(char pCodigo) {
        for (RetornoECF lRetornoECF : values()) {
            if (lRetornoECF.getCodigo() == pCodigo) return lRetornoECF;
        }
        return null;
    }      
    // </editor-fold>         

}