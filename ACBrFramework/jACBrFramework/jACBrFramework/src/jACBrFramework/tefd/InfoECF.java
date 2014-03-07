package jACBrFramework.tefd;

/**
 * Valor do Saldo restante "A Pagar" do Cupom
 * Estado do ECF "L" Livre, "V" Em Venda de Itens, "P" Em Pagamento, "C" CDC ou Vinculado, 
 * "G" Relatorio Gerencial, "N" Nao Fiscal (em qq fase, pois e dificil detectar a fase),
 * "O" Outro
 * Valor Total de Pagamentos registrados, na Aplicacao, e nao enviados ao ECF.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/02/2014 15:17:14, revisao: $Id$
 */
public enum InfoECF {
    
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    SubTotal(0, "0 - SubTotal"),
    EstadoECF(1, "1 - Estado ECF"),
    TotalAPagar(2, "2 - Total a pagar");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao das informacoes ECF.
     */
    private String descricao;
    /**
     * Codigo das informacoes ECF.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    InfoECF(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao das informacoes ECF.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo das informacoes ECF.
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
    public static InfoECF valueOf(int pCodigo) {
        for (InfoECF lInfoECF : values()) {
            if (lInfoECF.getCodigo() == pCodigo) return lInfoECF;
        }
        return null;
    }     
    // </editor-fold>    

}