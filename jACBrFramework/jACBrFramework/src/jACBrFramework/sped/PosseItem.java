package jACBrFramework.sped;

/**
 * Indicador de propriedade/pose do item.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 16:10:45, revisao: $Id$
 */
public enum PosseItem {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Informante(0, "0 - Item de propriedade do informante e em seu poder"),
    InformanteNoTerceiro(1, "1 - Item de propriedade do informante em posse de terceiros"),
    TerceiroNoInformante(2, "2 - Item de propriedade de terceiros em posse do informante");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de posse.
     */
    private String descricao;
    /**
     * Codigo do tipo de posse.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    PosseItem(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de posse.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de posse.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>      
        
}