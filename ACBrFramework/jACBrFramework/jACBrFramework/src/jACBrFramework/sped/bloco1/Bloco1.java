package jACBrFramework.sped.bloco1;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrSpedFiscalInterop;
import jACBrFramework.sped.ACBrSpedFiscal;
import java.util.Date;

/**
 * Outras informacoes.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 11:44:59, revisao: $Id$
 */
public class Bloco1 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Instancia de acesso ao ACBr.
     */
    private ACBrSpedFiscal sped;
    /**
     * Abertura do bloco 1.
     */
    private Registro1001 registro1001 = new Registro1001();
    /**
     * Encerramento do bloco 1.
     */
    private Registro1990 registro1990 = null;  
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public Bloco1(ACBrSpedFiscal pSped) {
        this.sped = pSped;
        registro1990 = new Registro1990(pSped);
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta a data inicial do bloco 1.
     * 
     * @param pDataInicial data inicial do bloco 1.
     * @throws ACBrException 
     */
    public void setDataInicial(Date pDataInicial) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_1_SetDT_INI(sped.getHandle(), OleDate.toOADate(pDataInicial));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data inicial do bloco 1.
     * 
     * @return data inicial do bloco 1.
     * @throws ACBrException 
     */
    public Date getDataInicial() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_1_GetDT_INI(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }   
    
    /**
     * Seta a data final do bloco 1.
     * 
     * @param pDataFinal data final do bloco 1.
     * @throws ACBrException 
     */
    public void setDataFinal(Date pDataFinal) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_1_SetDT_FIN(sped.getHandle(), OleDate.toOADate(pDataFinal));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data final do bloco 1.
     * 
     * @return data final do bloco 1.
     * @throws ACBrException 
     */
    public Date getDataFinal() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_1_GetDT_FIN(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }     
    
    /**
     * Verifica se o bloco 1 foi gravado.
     * 
     * @return indica a gravacao do bloco 1.
     * @throws ACBrException 
     */
    public boolean isGravado() throws ACBrException {
        return ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_1_GetGravado(sped.getHandle()) != 0;
    }       
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">         
    /**
     * Abertura do bloco 1.
     * @return the registro1001
     */
    public Registro1001 getRegistro1001() {
        return registro1001;
    }

    /**
     * Encerramento do bloco 1.
     * @return the registro1990
     */
    public Registro1990 getRegistro1990() {
        return registro1990;
    }
    // </editor-fold>
    
}