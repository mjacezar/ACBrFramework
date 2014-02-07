package jACBrFramework.sped.blocoD;

import jACBrFramework.sped.IndTipoReceita;

/**
 * Itens do documento - Nota Fiscal de Servico de comunicacao (codigo 21) e
 * servico de telecomunicacao (codigo 22).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 17:22:15, revisao: $Id$
 */
public class RegistroD510 {

    //TODO Esta faltando campos ver Interop.
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Indicador do tipo de receita.
     */
    private IndTipoReceita IND_REC;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Indicador do tipo de receita.
     * @return the IND_REC
     */
    public IndTipoReceita getIND_REC() {
        return IND_REC;
    }

    /**
     * Indicador do tipo de receita.
     * @param IND_REC the IND_REC to set
     */
    public void setIND_REC(IndTipoReceita IND_REC) {
        this.IND_REC = IND_REC;
    }
    // </editor-fold>    
    
}