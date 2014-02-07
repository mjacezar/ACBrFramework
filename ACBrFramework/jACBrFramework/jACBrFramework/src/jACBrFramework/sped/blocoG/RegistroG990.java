package jACBrFramework.sped.blocoG;

import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrSpedFiscalInterop;
import jACBrFramework.sped.ACBrSpedFiscal;

/**
 * Encerramento do bloco G.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 15:25:47, revisao: $Id$
 */
public class RegistroG990 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Instancia de acesso ao ACBr.
     */
    private ACBrSpedFiscal sped;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public RegistroG990(ACBrSpedFiscal pSped) {
        this.sped = pSped;
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Components Methods">    
    /**
     * Recupera a quantidade de linhas do bloco.
     * 
     * @return quantidade de linhas do bloco.
     * @throws ACBrException 
     */
    public int getQtdeLinha() throws ACBrException {
        int lQtdeLinha = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_G_RegistroG990_GetQTD_LIN_G(sped.getHandle());
        sped.checkResult(lQtdeLinha);   
        return lQtdeLinha;
    }      
    // </editor-fold>      
}