package jACBrFramework.sped.blocoD;

import jACBrFramework.sped.ServicoPrestado;

/**
 * Terminal faturado.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 09:33:24, revisao: $Id$
 */
public class RegistroD530 {

    //TODO Esta faltando campos ver Interop.
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Indicador do tipo de servico prestado.
     */
    private ServicoPrestado IND_SERV;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Indicador do tipo de servico prestado.
     * @return the IND_SERV
     */
    public ServicoPrestado getIND_SERV() {
        return IND_SERV;
    }

    /**
     * Indicador do tipo de servico prestado.
     * @param IND_SERV the IND_SERV to set
     */
    public void setIND_SERV(ServicoPrestado IND_SERV) {
        this.IND_SERV = IND_SERV;
    }
    // </editor-fold>    
    
}