package jACBrFramework.aac;

import jACBrFramework.ACBrException;
import java.nio.ByteBuffer;

/**
 * Classe para auxiliar no processo de obtencao da comunicacao com o componente.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 10:25:44, revisao: $Id$
 */
class ACBrAACWrapper {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Instancia AAC para obter o handler.
     */
    ACBrAAC aac = null;
    /**
     * Buffer para leitura dos dados.
     */
    protected final int STR_BUFFER_LEN = 256;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Cria um novo objeto wrapper.
     * 
     * @param pAac instancia para auxiliar a criptografia.
     */
    ACBrAACWrapper(ACBrAAC pAac) {
        this.aac = pAac;
    }    
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * @see ACBrAAC#toUTF8(java.lang.String) 
     */
    String toUTF8(String pValor) {
        return aac.toUTF8(pValor);
    }
    
    /**
     * @see ACBrAAC#fromUTF8(java.nio.ByteBuffer, int) 
     */
    String fromUTF8(ByteBuffer pBuffer, int pLen) {
        return aac.fromUTF8(pBuffer, pLen);
    } 
    
    /**
     * @see ACBrAAC#fromUTF8(byte[]) 
     */
    String fromUTF8(byte[] pValue) {
        return aac.fromUTF8(pValue);
    }
    
    /**
     * @see ACBrAAC#checkResult(int) 
     */    
    void checkResult(int pResult) throws ACBrException {
        aac.checkResult(pResult);
    }
    
    /**
     * @see ACBrAAC#getHandle() 
     */    
    public int getHandle() {
        return aac.getHandle();
    }
    
    /**
     * @see ACBrAAC#toByte(java.lang.String, int) 
     */       
    byte[] toByte(String pValue, int pSize) {    
        return aac.toByte(pValue, pSize);
    }
    // </editor-fold>      
    
}