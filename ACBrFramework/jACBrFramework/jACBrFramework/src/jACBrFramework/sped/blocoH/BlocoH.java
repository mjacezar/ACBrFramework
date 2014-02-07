package jACBrFramework.sped.blocoH;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrSpedFiscalInterop;
import jACBrFramework.sped.ACBrSpedFiscal;
import java.util.Date;

/**
 * Inventario fisico.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 15:32:47, revisao: $Id$
 */
public class BlocoH {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Instancia de acesso ao ACBr.
     */
    private ACBrSpedFiscal sped;
    /**
     * Abertura do bloco H.
     */
    private RegistroH001 registroH001 = new RegistroH001();   
    /**
     * Encerramento do bloco H.
     */
    private RegistroH990 registroH990 = null;       
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public BlocoH(ACBrSpedFiscal pSped) {
        this.sped = pSped;
        registroH990 = new RegistroH990(pSped);
    }
    // </editor-fold>     
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta a data inicial do bloco H.
     * 
     * @param pDataInicial data inicial do bloco H.
     * @throws ACBrException 
     */
    public void setDataInicial(Date pDataInicial) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_H_SetDT_INI(sped.getHandle(), OleDate.toOADate(pDataInicial));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data inicial do bloco H.
     * 
     * @return data inicial do bloco H.
     * @throws ACBrException 
     */
    public Date getDataInicial() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_H_GetDT_INI(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }   
    
    /**
     * Seta a data final do bloco H.
     * 
     * @param pDataFinal data final do bloco H.
     * @throws ACBrException 
     */
    public void setDataFinal(Date pDataFinal) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_H_SetDT_FIN(sped.getHandle(), OleDate.toOADate(pDataFinal));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data final do bloco H.
     * 
     * @return data final do bloco H.
     * @throws ACBrException 
     */
    public Date getDataFinal() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_H_GetDT_FIN(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }     
    
    /**
     * Verifica se obloco H foi gravado.
     * 
     * @return indica a gravacao do bloco H.
     * @throws ACBrException 
     */
    public boolean isGravado() throws ACBrException {
        return ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_H_GetGravado(sped.getHandle()) != 0;
    }       
    // </editor-fold>  
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Abertura do bloco H.
     * @return the registroH001
     */
    public RegistroH001 getRegistroH001() {
        return registroH001;
    }

    /**
     * Encerramento do bloco H.
     * @return the registroH990
     */
    public RegistroH990 getRegistroH990() {
        return registroH990;
    }
    // </editor-fold>      
    
}