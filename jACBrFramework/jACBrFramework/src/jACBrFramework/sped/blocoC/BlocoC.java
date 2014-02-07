package jACBrFramework.sped.blocoC;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrSpedFiscalInterop;
import jACBrFramework.sped.ACBrSpedFiscal;
import java.util.Date;

/**
 * Documentos Fiscais I - Mercadorias (ICMS/IPI).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:31:54, revisao: $Id$
 */
public class BlocoC {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Instancia de acesso ao ACBr.
     */
    private ACBrSpedFiscal sped;
    /**
     * Abertura do bloco C.
     */
    private RegistroC001 registroC001 = new RegistroC001();   
    /**
     * Encerramento do bloco c.
     */
    private RegistroC990 registroC990 = null;       
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public BlocoC(ACBrSpedFiscal pSped) {
        this.sped = pSped;
        registroC990 = new RegistroC990(pSped);
    }
    // </editor-fold>     
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta a data inicial do bloco C.
     * 
     * @param pDataInicial data inicial do bloco C.
     * @throws ACBrException 
     */
    public void setDataInicial(Date pDataInicial) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_C_SetDT_INI(sped.getHandle(), OleDate.toOADate(pDataInicial));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data inicial do bloco C.
     * 
     * @return data inicial do bloco C.
     * @throws ACBrException 
     */
    public Date getDataInicial() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_C_GetDT_INI(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }   
    
    /**
     * Seta a data final do bloco C.
     * 
     * @param pDataFinal data final do bloco C.
     * @throws ACBrException 
     */
    public void setDataFinal(Date pDataFinal) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_C_SetDT_FIN(sped.getHandle(), OleDate.toOADate(pDataFinal));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data final do bloco C.
     * 
     * @return data final do bloco C.
     * @throws ACBrException 
     */
    public Date getDataFinal() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_C_GetDT_FIN(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }     
    
    /**
     * Verifica se o bloco C foi gravado.
     * 
     * @return indica a gravacao do bloco C.
     * @throws ACBrException 
     */
    public boolean isGravado() throws ACBrException {
        return ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_C_GetGravado(sped.getHandle()) != 0;
    }       
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Abertura do bloco C.
     * @return the registroC001
     */
    public RegistroC001 getRegistroC001() {
        return registroC001;
    }

    /**
     * Encerramento do bloco c.
     * @return the registroC990
     */
    public RegistroC990 getRegistroC990() {
        return registroC990;
    }
    // </editor-fold>    
    
}