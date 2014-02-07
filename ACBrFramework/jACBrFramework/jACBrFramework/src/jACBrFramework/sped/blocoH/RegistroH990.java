package jACBrFramework.sped.blocoH;

import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrSpedFiscalInterop;
import jACBrFramework.sped.ACBrSpedFiscal;

/**
 * Encerramento do bloco H.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 16:31:23, revisao: $Id$
 */
public class RegistroH990 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Instancia de acesso ao ACBr.
     */
    private ACBrSpedFiscal sped;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public RegistroH990(ACBrSpedFiscal pSped) {
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
        int lQtdeLinha = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_H_RegistroH990_GetQTD_LIN_H(sped.getHandle());
        sped.checkResult(lQtdeLinha);   
        return lQtdeLinha;
    }      
    // </editor-fold>         
}