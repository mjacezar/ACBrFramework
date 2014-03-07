package jACBrFramework.tefd;

import jACBrFramework.ACBrComposedClass;
import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrTEFInterop;
import java.nio.ByteBuffer;

/**
 * TEF da Auttar.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/02/2014 09:46:28, revisao: $Id$
 */
public class TefAuttar extends ACBrComposedClass {

    //<editor-fold defaultstate="collapsed" desc="Constructor">
    TefAuttar(ACBrTEFD pParent) throws ACBrException {
        super(pParent);
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Informa se o GP sera auto ativado.
     * 
     * @param pIndAutoAtivarGP indica auto ativar GP.
     * @throws ACBrException 
     */
    public void setAutoAtivarGP(boolean pIndAutoAtivarGP) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_SetAutoAtivarGP(getHandle(), pIndAutoAtivarGP);
        checkResult(ret);
    }
    
    /**
     * Verifica se indica auto ativacao.
     * 
     * @return indica auto ativacao.
     * @throws ACBrException 
     */
    public boolean isAutoAtivarGP() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_GetAutoAtivarGP(getHandle());
        checkResult(ret);
        return ret == 1;
    }   
    
    /**
     * Informa o numero de vias.
     * 
     * @param pNumVias numero de vias.
     * @throws ACBrException 
     */
    public void setNumVias(int pNumVias) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_SetNumVias(getHandle(), pNumVias);
        checkResult(ret);
    }
    
    /**
     * Verifica o numero de vias.
     * 
     * @return numero de vias.
     * @throws ACBrException 
     */
    public int getNumVias() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_GetNumVias(getHandle());
        checkResult(ret);
        return ret;
    }       
    
    /**
     * Informa a espera do STS.
     * 
     * @param pEsperaSTS valor de espera STS..
     * @throws ACBrException 
     */
    public void setEsperaSTS(int pEsperaSTS) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_SetEsperaSTS(getHandle(), pEsperaSTS);
        checkResult(ret);
    }
    
    /**
     * Obtem o tempo de espera.
     * 
     * @return tempo de espera.
     * @throws ACBrException 
     */
    public int getEsperaSTS() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_GetEsperaSTS(getHandle());
        checkResult(ret);
        return ret;
    } 
    
    /**
     * Seta o nome do arquivo temporario.
     * 
     * @param pArqTemp nome do arquivo temporario.
     * @throws ACBrException 
     */
    public void setArqTemp(String pArqTemp) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_SetArqTemp(getHandle(), toUTF8(pArqTemp));
        checkResult(ret);
    }
    
    /**
     * Recupera o nome do arquivo temporario.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getArqTemp() throws ACBrException {
        ByteBuffer lArqTemp = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_GetArqTemp(getHandle(), lArqTemp, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lArqTemp, ret);
    }      
    
    /**
     * Seta o nome do arquivo de requisicao.
     * 
     * @param pArqReq nome do arquivo de requisicao.
     * @throws ACBrException 
     */
    public void setArqReq(String pArqReq) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_SetArqReq(getHandle(), toUTF8(pArqReq));
        checkResult(ret);
    }
    
    /**
     * Recupera o nome do arquivo temporario.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getArqReq() throws ACBrException {
        ByteBuffer lArqReq = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_GetArqReq(getHandle(), lArqReq, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lArqReq, ret);
    }      
    
    /**
     * Seta o nome do arquivo STS.
     * 
     * @param pArqSTS nome do arquivo STS.
     * @throws ACBrException 
     */
    public void setArqSTS(String pArqSTS) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_SetArqSTS(getHandle(), toUTF8(pArqSTS));
        checkResult(ret);
    }
    
    /**
     * Recupera o nome do arquivo STS.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getArqSTS() throws ACBrException {
        ByteBuffer lArqSTS = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_GetArqSTS(getHandle(), lArqSTS, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lArqSTS, ret);
    }       
    
    /**
     * Seta o nome do arquivo resposta.
     * 
     * @param pArqResp nome do arquivo resposta.
     * @throws ACBrException 
     */
    public void setArqResp(String pArqResp) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_SetArqResp(getHandle(), toUTF8(pArqResp));
        checkResult(ret);
    }
    
    /**
     * Recupera o nome do arquivo de respota.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getArqResp() throws ACBrException {
        ByteBuffer lArqResp = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_GetArqResp(getHandle(), lArqResp, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lArqResp, ret);
    }       

    /**
     * Seta o nome do executavel GP.
     * 
     * @param pGPExeName nome do executavel GP.
     * @throws ACBrException 
     */
    public void setGPExeName(String pGPExeName) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_SetGPExeName(getHandle(), toUTF8(pGPExeName));
        checkResult(ret);
    }
    
    /**
     * Recupera o nome do executavel GP.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getGPExeName() throws ACBrException {
        ByteBuffer lGPExeName = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_GetGPExeName(getHandle(), lGPExeName, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lGPExeName, ret);
    }       
    
    /**
     * Seta o nome do TEF.
     * 
     * @param pName nome do TEF.
     * @throws ACBrException 
     */
    public void setName(String pName) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_SetName(getHandle(), toUTF8(pName));
        checkResult(ret);
    }
    
    /**
     * Recupera o nome do TEF.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getName() throws ACBrException {
        ByteBuffer lName = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_GetName(getHandle(), lName, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lName, ret);
    }
    
    /**
     * Indica se o TEF esta habilitado.
     * 
     * @param pHabilitado indica se o TEF esta habilitado.
     * @throws ACBrException 
     */
    public void setHabilitado(boolean pHabilitado) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_SetHabilitado(getHandle(), pHabilitado);
        checkResult(ret);
    }
    
    /**
     * Verifica se o TEF esta habilitado.
     * 
     * @return indica se o TEF esta habilitado.
     * @throws ACBrException 
     */
    public boolean isHabilitado() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFAuttar_GetHabilitado(getHandle());
        checkResult(ret);
        return ret == 1;
    }   
    // </editor-fold>

}