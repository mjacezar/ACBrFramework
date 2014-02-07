package jACBrFramework.sped.bloco0;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrSpedFiscalInterop;
import jACBrFramework.sped.ACBrSpedFiscal;
import java.util.Date;

/**
 * Abertura identificacao e referencias.
 * 
 * @author Jose Mauro
 * @version Criado em: 24/01/2014 17:34:32, revisao: $Id$
 */
public class Bloco0 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Instancia de acesso ao ACBr.
     */
    private ACBrSpedFiscal sped;
    /**
     * Abertura do arquivo digital e identificacao da entidade.
     */
    private Registro0000 registro0000 = new Registro0000();
    /**
     * Abertura do bloco 0.
     */
    private Registro0001 registro0001 = new Registro0001();
    /**
     * Encerramento do bloco 0.
     */
    private Registro0990 registro0990 = null;  
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public Bloco0(ACBrSpedFiscal pSped) {
        this.sped = pSped;
        registro0990 = new Registro0990(pSped);
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta a data inicial do bloco 0.
     * 
     * @param pDataInicial data inicial do bloco 0.
     * @throws ACBrException 
     */
    public void setDataInicial(Date pDataInicial) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_0_SetDT_INI(sped.getHandle(), OleDate.toOADate(pDataInicial));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data inicial do bloco 0.
     * 
     * @return data inicial do bloco 0.
     * @throws ACBrException 
     */
    public Date getDataInicial() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_0_GetDT_INI(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }   
    
    /**
     * Seta a data final do bloco 0.
     * 
     * @param pDataFinal data final do bloco 0.
     * @throws ACBrException 
     */
    public void setDataFinal(Date pDataFinal) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_0_SetDT_FIN(sped.getHandle(), OleDate.toOADate(pDataFinal));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data final do bloco 0.
     * 
     * @return data final do bloco 0.
     * @throws ACBrException 
     */
    public Date getDataFinal() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_0_GetDT_FIN(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }     
    
    /**
     * Verifica se o bloco 0 foi gravado.
     * 
     * @return indica a gravacao do bloco 0.
     * @throws ACBrException 
     */
    public boolean isGravado() throws ACBrException {
        return ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_0_GetGravado(sped.getHandle()) != 0;
    }       
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Abertura do arquivo digital e identificacao da entidade.
     * @return the registro0000
     */
    public Registro0000 getRegistro0000() {
        return registro0000;
    }

    /**
     * Abertura do bloco 0.
     * @return the registro0001
     */
    public Registro0001 getRegistro0001() {
        return registro0001;
    }

    /**
     * Encerramento do bloco 0.
     * @return the registro0990
     */
    public Registro0990 getRegistro0990() {
        return registro0990;
    }
    // </editor-fold>
    
}