package jACBrFramework.sped.bloco9;

import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrSpedFiscalInterop;
import jACBrFramework.sped.ACBrSpedFiscal;

/**
 * Encerramento do arquivo digital.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:21:19, revisao: $Id$
 */
public class Registro9999 {
    
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Instancia de acesso ao ACBr.
     */
    private ACBrSpedFiscal sped;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public Registro9999(ACBrSpedFiscal pSped) {
        this.sped = pSped;
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Components Methods">    
    /**
     * Recupera a quantidade de linhas do arquivo.
     * 
     * @return quantidade de linhas do arquivo.
     * @throws ACBrException 
     */
    public int getQtdeLinha() throws ACBrException {
        int lQtdeLinha = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_9_Registro9999_GetQTD_LIN(sped.getHandle());
        sped.checkResult(lQtdeLinha);   
        return lQtdeLinha;
    }      
    // </editor-fold>  
}