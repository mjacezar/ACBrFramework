package jACBrFramework.tefd;

import jACBrFramework.ACBrComposedClass;
import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrTEFInterop;
import java.nio.ByteBuffer;

/**
 * Registro de itenficacao do TEF.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/02/2014 14:56:46, revisao: $Id$
 */
public class Identificacao extends ACBrComposedClass {

    //<editor-fold defaultstate="collapsed" desc="Constructor">
    Identificacao(ACBrTEFD pParent) throws ACBrException {
        super(pParent);
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta o nome da aplicacao.
     * 
     * @param pNomeAplicacao nome da aplicacao.
     * @throws ACBrException 
     */
    public void setNomeAplicacao(String pNomeAplicacao) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Identificacao_SetNomeAplicacao(getHandle(), toUTF8(pNomeAplicacao));
        checkResult(ret);
    }
    
    /**
     * Recupera o nome da aplicacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNomeAplicacao() throws ACBrException {
        ByteBuffer lNomeAplicacao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Identificacao_GetNomeAplicacao(getHandle(), lNomeAplicacao, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lNomeAplicacao, ret);
    }
    
    /**
     * Seta a versao da aplicacao.
     * 
     * @param pVersaoAplicacao versao da aplicacao.
     * @throws ACBrException 
     */
    public void setVersaoAplicacao(String pVersaoAplicacao) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Identificacao_SetVersaoAplicacao(getHandle(), toUTF8(pVersaoAplicacao));
        checkResult(ret);
    }
    
    /**
     * Recupera a versao da aplicacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getVersaoAplicacao() throws ACBrException {
        ByteBuffer lVersaoAplicacao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Identificacao_GetVersaoAplicacao(getHandle(), lVersaoAplicacao, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lVersaoAplicacao, ret);
    }  
    
    /**
     * Seta a software house.
     * 
     * @param pSoftwareHouse dados da software house.
     * @throws ACBrException 
     */
    public void setSoftwareHouse(String pSoftwareHouse) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Identificacao_SetSoftwareHouse(getHandle(), toUTF8(pSoftwareHouse));
        checkResult(ret);
    }
    
    /**
     * Recupera a software house.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getSoftwareHouse() throws ACBrException {
        ByteBuffer lSoftwareHouse = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Identificacao_GetSoftwareHouse(getHandle(), lSoftwareHouse, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lSoftwareHouse, ret);
    }    
    
    /**
     * Seta a razao social.
     * 
     * @param pRazaoSocial razao social.
     * @throws ACBrException 
     */
    public void setRazaoSocial(String pRazaoSocial) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Identificacao_SetRazaoSocial(getHandle(), toUTF8(pRazaoSocial));
        checkResult(ret);
    }
    
    /**
     * Recupera a razao social.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getRazaoSocial() throws ACBrException {
        ByteBuffer lRazaoSocial = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Identificacao_GetRazaoSocial(getHandle(), lRazaoSocial, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lRazaoSocial, ret);
    }    
    // </editor-fold>    

}