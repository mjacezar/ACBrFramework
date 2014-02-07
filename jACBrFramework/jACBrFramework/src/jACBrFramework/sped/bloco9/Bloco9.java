package jACBrFramework.sped.bloco9;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrSpedFiscalInterop;
import jACBrFramework.sped.ACBrSpedFiscal;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Controle e encerramento do arquivo digital.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:14:52, revisao: $Id$
 */
public class Bloco9 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Instancia de acesso ao ACBr.
     */
    private ACBrSpedFiscal sped;
    /**
     * Abertura do bloco 9.
     */
    private Registro9001 registro9001 = new Registro9001();
    /**
     * Registros do arquivo.
     */
    private Collection<Registro9900> registro9900 = new ArrayList<Registro9900>(); 
    /**
     * Encerramento do bloco 9.
     */
    private Registro9990 registro9990 = null;    
    /**
     * Encerramento do arquivo digital.
     */
    private Registro9999 registro9999 = null;    
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public Bloco9(ACBrSpedFiscal pSped) {
        this.sped = pSped;
        registro9990 = new Registro9990(pSped);
        registro9999 = new Registro9999(pSped);
    }
    // </editor-fold> 
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta a data inicial do bloco 9.
     * 
     * @param pDataInicial data inicial do bloco 9.
     * @throws ACBrException 
     */
    public void setDataInicial(Date pDataInicial) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_9_SetDT_INI(sped.getHandle(), OleDate.toOADate(pDataInicial));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data inicial do bloco 9.
     * 
     * @return data inicial do bloco 9.
     * @throws ACBrException 
     */
    public Date getDataInicial() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_9_GetDT_INI(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }   
    
    /**
     * Seta a data final do bloco 9.
     * 
     * @param pDataFinal data final do bloco 9.
     * @throws ACBrException 
     */
    public void setDataFinal(Date pDataFinal) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_9_SetDT_FIN(sped.getHandle(), OleDate.toOADate(pDataFinal));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data final do bloco 9.
     * 
     * @return data final do bloco 9.
     * @throws ACBrException 
     */
    public Date getDataFinal() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_9_GetDT_FIN(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }     
    
    /**
     * Verifica se o bloco 9 foi gravado.
     * 
     * @return indica a gravacao do bloco 9.
     * @throws ACBrException 
     */
    public boolean isGravado() throws ACBrException {
        return ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_9_GetGravado(sped.getHandle()) != 0;
    }       
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Abertura do bloco 9.
     * @return the registro9001
     */
    public Registro9001 getRegistro9001() {
        return registro9001;
    }

    /**
     * Registros do arquivo.
     * @return the registro9900
     */
    public Collection<Registro9900> getRegistro9900() {
        return registro9900;
    }

    /**
     * Encerramento do bloco 9.
     * @return the registro9990
     */
    public Registro9990 getRegistro9990() {
        return registro9990;
    }

    /**
     * Encerramento do arquivo digital.
     * @return the registro9999
     */
    public Registro9999 getRegistro9999() {
        return registro9999;
    }
    // </editor-fold> 
    
}