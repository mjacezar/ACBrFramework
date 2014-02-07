package jACBrFramework.sped;

/**
 * Codigo do tipo de ligacao.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 08:44:34, revisao: $Id$
 */
public enum TipoLigacao {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Nenhum(-1, "'' - Para uso quando o documento for cancelado"),
    Monofasico(1, "1 - Monofásico"),
    Bifasico(2, "2 - Bifásico"),
    Trifasico(3, "3 - Trifásico");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de ligacao.
     */
    private String descricao;
    /**
     * Codigo do tipo de ligacao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoLigacao(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de ligacao.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de ligacao.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>     
}