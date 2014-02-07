package jACBrFramework.sped.blocoG;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrSpedFiscalInterop;
import jACBrFramework.sped.ACBrSpedFiscal;
import java.util.Date;

/**
 * Controle do credito de ICMS do ativo permanente - CIAP -modelos "C" e "D".
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 14:52:01, revisao: $Id$
 */
public class BlocoG {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Instancia de acesso ao ACBr.
     */
    private ACBrSpedFiscal sped;
    /**
     * Abertura do bloco G.
     */
    private RegistroG001 registroG001 = new RegistroG001();   
    /**
     * Encerramento do bloco G.
     */
    private RegistroG990 registroG990 = null;       
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public BlocoG(ACBrSpedFiscal pSped) {
        this.sped = pSped;
        registroG990 = new RegistroG990(pSped);
    }
    // </editor-fold>     
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta a data inicial do bloco G.
     * 
     * @param pDataInicial data inicial do bloco G.
     * @throws ACBrException 
     */
    public void setDataInicial(Date pDataInicial) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_G_SetDT_INI(sped.getHandle(), OleDate.toOADate(pDataInicial));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data inicial do bloco G.
     * 
     * @return data inicial do bloco G.
     * @throws ACBrException 
     */
    public Date getDataInicial() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_G_GetDT_INI(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }   
    
    /**
     * Seta a data final do bloco G.
     * 
     * @param pDataFinal data final do bloco G.
     * @throws ACBrException 
     */
    public void setDataFinal(Date pDataFinal) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_G_SetDT_FIN(sped.getHandle(), OleDate.toOADate(pDataFinal));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data final do bloco G.
     * 
     * @return data final do bloco G.
     * @throws ACBrException 
     */
    public Date getDataFinal() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_G_GetDT_FIN(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }     
    
    /**
     * Verifica se obloco G foi gravado.
     * 
     * @return indica a gravacao do bloco G.
     * @throws ACBrException 
     */
    public boolean isGravado() throws ACBrException {
        return ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_G_GetGravado(sped.getHandle()) != 0;
    }       
    // </editor-fold>  
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Abertura do bloco G.
     * @return the registroG001
     */
    public RegistroG001 getRegistroG001() {
        return registroG001;
    }

    /**
     * Encerramento do bloco G.
     * @return the registroG990
     */
    public RegistroG990 getRegistroG990() {
        return registroG990;
    }
    // </editor-fold>    
    
}