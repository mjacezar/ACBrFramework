package jACBrFramework.tefd;

/**
 * Operacoes da ECF.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/02/2014 15:22:09, revisao: $Id$
 */
public enum OperacaoECF {
    
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    AbreGerencial(0, "0 - Abertura Relatório Gerencial"),
    FechaGerencial(1, "1 - Fechamento Relatório gerencial"),
    PulaLinhas(2, "2 - Pular Linhas"),
    SubTotalizaCupom(3, "3 - Subtotalizacao Cupom"),
    FechaCupom(4, "4 - Fechamento Cupom"),
    FechaVinculado(5, "5 - Fechamento cupom vinculado"),
    CancelaCupom(6, "6 - Cancelamento de Cupom"),
    ImprimePagamentos(7, "7 - Impressao de pagamento");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao das operacoes da ECF.
     */
    private String descricao;
    /**
     * Codigo das operacoes da ECF.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    OperacaoECF(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao das operacoes da ECF.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo das operacoes da ECF.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    
    /**
     * Recupera o enum pelo codigo correspondente.
     * 
     * @param pCodigo codigo a ser recuperado.
     * @return 
     */
    public static OperacaoECF valueOf(int pCodigo) {
        for (OperacaoECF lOperacaoECF : values()) {
            if (lOperacaoECF.getCodigo() == pCodigo) return lOperacaoECF;
        }
        return null;
    }     
    // </editor-fold>      
		
}