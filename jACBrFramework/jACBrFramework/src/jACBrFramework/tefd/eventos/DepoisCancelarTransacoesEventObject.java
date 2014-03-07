package jACBrFramework.tefd.eventos;

import jACBrFramework.tefd.RespostasPendentes;
import java.util.EventObject;

/**
 * Evento acionado apos cancelar o cupom.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 14:17:33, revisao: $Id$
 */
public class DepoisCancelarTransacoesEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = 8289873235288308358L;
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Retorno da ECF.
     */
    private RespostasPendentes respostasPendentes;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public DepoisCancelarTransacoesEventObject(Object pSource, RespostasPendentes pRespostasPendentes) {
        super(pSource);
        this.respostasPendentes = pRespostasPendentes;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Retorno da ECF.
     * @return the respostasPendentes
     */
    public RespostasPendentes getRespostasPendentes() {
        return respostasPendentes;
    }
    // </editor-fold>    

}