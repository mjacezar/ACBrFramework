package jACBrFramework.sped;

/**
 * Perfil de apresentacao do arquivo fiscal.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 08:34:38, revisao: $Id$
 */
public enum Perfil {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    PerfilA(0, "Perfil A"),
    PerfilB(1, "Perfil B"),
    PerfilC(2, "Perfil C");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do perfil.
     */
    private String descricao;
    /**
     * Codigo do perfil.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    Perfil(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do perfil.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do perfil.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       
}