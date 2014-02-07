package jACBrFramework.sped.blocoC;

import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrSpedFiscalInterop;
import jACBrFramework.sped.ACBrSpedFiscal;

/**
 * Encerramento do bloco C.
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 13:14:49, revisao: $Id$
 */
public class RegistroC990 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Instancia de acesso ao ACBr.
     */
    private ACBrSpedFiscal sped;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public RegistroC990(ACBrSpedFiscal pSped) {
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
        int lQtdeLinha = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_C_RegistroC990_GetQTD_LIN_C(sped.getHandle());
        sped.checkResult(lQtdeLinha);   
        return lQtdeLinha;
    }      
    // </editor-fold>     
}