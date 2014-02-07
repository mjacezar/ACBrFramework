package jACBrFramework.sped;

/**
 * Tipo de servico prestado.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 09:36:08, revisao: $Id$
 */
public enum ServicoPrestado {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Telefonia(0, "0 - Telefonia"),
    ComunicacaoDados(1, "1 - Comunicação de dados"),
    TVAssinatura(2, "2 - TV por assinatura"),
    AcessoInternet(3, "3 - Provimento de acesso à Internet;"),
    Multimidia(4, "4 - Multimídia"),
    Outros(8, "9 - Outros");
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de servico.
     */
    private String descricao;
    /**
     * Codigo do tipo de servico.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    ServicoPrestado(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de servico.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de servico.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>   
        
}