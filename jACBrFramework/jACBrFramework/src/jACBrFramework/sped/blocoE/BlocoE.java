package jACBrFramework.sped.blocoE;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrSpedFiscalInterop;
import jACBrFramework.sped.ACBrSpedFiscal;
import java.util.Date;

/**
 * Apuracao do ICMS e do IPI.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 11:06:13, revisao: $Id$
 */
public class BlocoE {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Instancia de acesso ao ACBr.
     */
    private ACBrSpedFiscal sped;
    /**
     * Abertura do bloco E.
     */
    private RegistroE001 registroE001 = new RegistroE001();   
    /**
     * Encerramento do bloco E.
     */
    private RegistroE990 registroE990 = null;       
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public BlocoE(ACBrSpedFiscal pSped) {
        this.sped = pSped;
        registroE990 = new RegistroE990(pSped);
    }
    // </editor-fold>     
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta a data inicial do bloco E.
     * 
     * @param pDataInicial data inicial do bloco E.
     * @throws ACBrException 
     */
    public void setDataInicial(Date pDataInicial) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_E_SetDT_INI(sped.getHandle(), OleDate.toOADate(pDataInicial));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data inicial do bloco E.
     * 
     * @return data inicial do bloco E.
     * @throws ACBrException 
     */
    public Date getDataInicial() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_E_GetDT_INI(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }   
    
    /**
     * Seta a data final do bloco E.
     * 
     * @param pDataFinal data final do bloco E.
     * @throws ACBrException 
     */
    public void setDataFinal(Date pDataFinal) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_E_SetDT_FIN(sped.getHandle(), OleDate.toOADate(pDataFinal));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data final do bloco E.
     * 
     * @return data final do bloco E.
     * @throws ACBrException 
     */
    public Date getDataFinal() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_E_GetDT_FIN(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }     
    
    /**
     * Verifica se o bloco E foi gravado.
     * 
     * @return indica a gravacao do bloco E.
     * @throws ACBrException 
     */
    public boolean isGravado() throws ACBrException {
        return ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_E_GetGravado(sped.getHandle()) != 0;
    }       
    // </editor-fold>  
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Abertura do bloco E.
     * @return the registroE001
     */
    public RegistroE001 getRegistroE001() {
        return registroE001;
    }

    /**
     * Encerramento do bloco E.
     * @return the registroE990
     */
    public RegistroE990 getRegistroE990() {
        return registroE990;
    }
    // </editor-fold>    
    
}