package jACBrFramework.sped.blocoD;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrSpedFiscalInterop;
import jACBrFramework.sped.ACBrSpedFiscal;
import java.util.Date;

/**
 * Documentos Fiscais II - Servicos (ICMS).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 13:26:17, revisao: $Id$
 */
public class BlocoD {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Instancia de acesso ao ACBr.
     */
    private ACBrSpedFiscal sped;
    /**
     * Abertura do bloco D.
     */
    private RegistroD001 registroD001 = new RegistroD001();   
    /**
     * Encerramento do bloco D.
     */
    private RegistroD990 registroD990 = null;       
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public BlocoD(ACBrSpedFiscal pSped) {
        this.sped = pSped;
        registroD990 = new RegistroD990(pSped);
    }
    // </editor-fold>     
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta a data inicial do bloco D.
     * 
     * @param pDataInicial data inicial do bloco D.
     * @throws ACBrException 
     */
    public void setDataInicial(Date pDataInicial) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_D_SetDT_INI(sped.getHandle(), OleDate.toOADate(pDataInicial));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data inicial do bloco D.
     * 
     * @return data inicial do bloco D.
     * @throws ACBrException 
     */
    public Date getDataInicial() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_D_GetDT_INI(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }   
    
    /**
     * Seta a data final do bloco D.
     * 
     * @param pDataFinal data final do bloco D.
     * @throws ACBrException 
     */
    public void setDataFinal(Date pDataFinal) throws ACBrException {     
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_D_SetDT_FIN(sped.getHandle(), OleDate.toOADate(pDataFinal));
        sped.checkResult(ret);
    }  
    
    /**
     * Recupera a data final do bloco D.
     * 
     * @return data final do bloco D.
     * @throws ACBrException 
     */
    public Date getDataFinal() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_D_GetDT_FIN(sped.getHandle(), lData);
        sped.checkResult(ret);   
        return OleDate.fromOADate(lData.getValue());
    }     
    
    /**
     * Verifica se o bloco D foi gravado.
     * 
     * @return indica a gravacao do bloco D.
     * @throws ACBrException 
     */
    public boolean isGravado() throws ACBrException {
        return ACBrSpedFiscalInterop.INSTANCE.SPDF_Bloco_D_GetGravado(sped.getHandle()) != 0;
    }       
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Abertura do bloco D.
     * @return the registroD001
     */
    public RegistroD001 getRegistroD001() {
        return registroD001;
    }

    /**
     * Abertura do bloco D.
     * @param registroD001 the registroD001 to set
     */
    public void setRegistroD001(RegistroD001 registroD001) {
        this.registroD001 = registroD001;
    }

    /**
     * Encerramento do bloco D.
     * @return the registroD990
     */
    public RegistroD990 getRegistroD990() {
        return registroD990;
    }

    /**
     * Encerramento do bloco D.
     * @param registroD990 the registroD990 to set
     */
    public void setRegistroD990(RegistroD990 registroD990) {
        this.registroD990 = registroD990;
    }
    // </editor-fold>    
    
}