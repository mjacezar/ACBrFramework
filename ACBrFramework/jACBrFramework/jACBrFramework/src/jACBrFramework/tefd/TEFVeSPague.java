package jACBrFramework.tefd;

import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrComposedClass;
import jACBrFramework.ACBrEventListener;
import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrTEFInterop;
import jACBrFramework.tefd.eventos.TEFVeSPagueExibeMenuEventObject;
import jACBrFramework.tefd.eventos.TEFVeSPagueObtemCampoEventObject;
import java.nio.ByteBuffer;

/**
 * TEF TEFVeSPague.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/02/2014 16:17:37, revisao: $Id$
 */
public class TEFVeSPague extends ACBrComposedClass {

    //<editor-fold defaultstate="collapsed" desc="Constructor">
    TEFVeSPague(ACBrTEFD pParent) throws ACBrException {
        super(pParent);
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta a aplicacao.
     * 
     * @param pAplicacao aplicacao.
     * @throws ACBrException 
     */
    public void setAplicacao(String pAplicacao) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetAplicacao(getHandle(), toUTF8(pAplicacao));
        checkResult(ret);
    }
    
    /**
     * Recupera a aplicacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getAplicacao() throws ACBrException {
        ByteBuffer lAplicacao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetAplicacao(getHandle(), lAplicacao, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lAplicacao, ret);
    }     
    
    /**
     * Seta a versao do aplicativo.
     * 
     * @param pAplicacaoVersao versao do aplicativo.
     * @throws ACBrException 
     */
    public void setAplicacaoVersao(String pAplicacaoVersao) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetAplicacaoVersao(getHandle(), toUTF8(pAplicacaoVersao));
        checkResult(ret);
    }
    
    /**
     * Recupera a versao do aplicativo.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getAplicacaoVersao() throws ACBrException {
        ByteBuffer lAplicacaoVersao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetAplicacaoVersao(getHandle(), lAplicacaoVersao, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lAplicacaoVersao, ret);
    }     
    
    /**
     * Seta o nome do exe.
     * 
     * @param pGPExeName nome do exe.
     * @throws ACBrException 
     */
    public void setGPExeName(String pGPExeName) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetGPExeName(getHandle(), toUTF8(pGPExeName));
        checkResult(ret);
    }
    
    /**
     * Recupera o nome do exe.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getGPExeName() throws ACBrException {
        ByteBuffer lGPExeName = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetGPExeName(getHandle(), lGPExeName, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lGPExeName, ret);
    }     
    
    /**
     * Seta os parametros do exe.
     * 
     * @param pGPExeParams parametros do exe.
     * @throws ACBrException 
     */
    public void setGPExeParams(String pGPExeParams) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetGPExeParams(getHandle(), toUTF8(pGPExeParams));
        checkResult(ret);
    }
    
    /**
     * Recupera os parametros do exe.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getGPExeParams() throws ACBrException {
        ByteBuffer lGPExeParams = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetGPExeParams(getHandle(), lGPExeParams, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lGPExeParams, ret);
    }     
    
    /**
     * Seta o endereco IP para comunicacao.
     * 
     * @param pEnderecoIP endereco IP para comunicacao.
     * @throws ACBrException 
     */
    public void setEnderecoIP(String pEnderecoIP) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetEnderecoIP(getHandle(), toUTF8(pEnderecoIP));
        checkResult(ret);
    }
    
    /**
     * Recupera o endereco IP para comunicacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getEnderecoIP() throws ACBrException {
        ByteBuffer lEnderecoIP = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetEnderecoIP(getHandle(), lEnderecoIP, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lEnderecoIP, ret);
    }     
    
    /**
     * Seta a porta para comunicacao.
     * 
     * @param pPorta porta para comunicacao.
     * @throws ACBrException 
     */
    public void setPorta(String pPorta) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetPorta(getHandle(), toUTF8(pPorta));
        checkResult(ret);
    }
    
    /**
     * Recupera a porta para comunicacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getPorta() throws ACBrException {
        ByteBuffer lPorta = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetPorta(getHandle(), lPorta, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lPorta, ret);
    }     
    
    /**
     * Informa o timeout.
     * 
     * @param pTimeOut timeout.
     * @throws ACBrException 
     */
    public void setTimeOut(int pTimeOut) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetTimeOut(getHandle(), pTimeOut);
        checkResult(ret);
    }
    
    /**
     * Verifica o timeout.
     * 
     * @return timeout.
     * @throws ACBrException 
     */
    public int getTimeOut() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetTimeOut(getHandle());
        checkResult(ret);
        return ret;
    }    
    
    /**
     * Indica se ha pendencias.
     * 
     * @param pTemPendencias indica se ha pendencias.
     * @throws ACBrException 
     */
    public void setTemPendencias(boolean pTemPendencias) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetTemPendencias(getHandle(), pTemPendencias);
        checkResult(ret);
    }
    
    /**
     * Verifica se ha pendencias.
     * 
     * @return indica se ha pendencias.
     * @throws ACBrException 
     */
    public boolean isTemPendencias() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetTemPendencias(getHandle());
        checkResult(ret);
        return ret == 1;
    }     
    
    /**
     * Informa transacao ADM.
     * 
     * @param pTransacaoADM informa transacao ADM.
     * @throws ACBrException 
     */
    public void setTransacaoADM(String pTransacaoADM) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetTransacaoADM(getHandle(), pTransacaoADM);
        checkResult(ret);
    }
    
    /**
     * Verifica transacao ADM.
     * 
     * @return transacao ADM.
     * @throws ACBrException 
     */
    public String getTransacaoADM() throws ACBrException {
        ByteBuffer lTransacaoADM = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetTransacaoADM(getHandle(), lTransacaoADM, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lTransacaoADM, ret);
    }  
    
    /**
     * Informa transacao CRT.
     * 
     * @param pTransacaoCRT informa transacao CRT.
     * @throws ACBrException 
     */
    public void setTransacaoCRT(String pTransacaoCRT) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetTransacaoCRT(getHandle(), pTransacaoCRT);
        checkResult(ret);
    }
    
    /**
     * Verifica transacao CRT.
     * 
     * @return transacao CRT.
     * @throws ACBrException 
     */
    public String getTransacaoCRT() throws ACBrException {
        ByteBuffer lTransacaoCRT = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetTransacaoCRT(getHandle(), lTransacaoCRT, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lTransacaoCRT, ret);
    }  

    /**
     * Informa transacao CHQ.
     * 
     * @param pTransacaoCRT informa transacao CHQ.
     * @throws ACBrException 
     */
    public void setTransacaoCHQ(String pTransacaoCHQ) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetTransacaoCHQ(getHandle(), pTransacaoCHQ);
        checkResult(ret);
    }
    
    /**
     * Verifica transacao CHQ.
     * 
     * @return transacao CHQ.
     * @throws ACBrException 
     */
    public String getTransacaoCHQ() throws ACBrException {
        ByteBuffer lTransacaoCHQ = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetTransacaoCHQ(getHandle(), lTransacaoCHQ, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lTransacaoCHQ, ret);
    }  

    /**
     * Informa transacao CNC.
     * 
     * @param pTransacaoCRT informa transacao CNC.
     * @throws ACBrException 
     */
    public void setTransacaoCNC(String pTransacaoCNC) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetTransacaoCNC(getHandle(), pTransacaoCNC);
        checkResult(ret);
    }
    
    /**
     * Verifica transacao CNC.
     * 
     * @return transacao CNC.
     * @throws ACBrException 
     */
    public String getTransacaoCNC() throws ACBrException {
        ByteBuffer lTransacaoCNC = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetTransacaoCNC(getHandle(), lTransacaoCNC, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lTransacaoCNC, ret);
    }  
    
    /**
     * Informa a opcao da transacao.
     * 
     * @param pTransacaoOpcao opcao das transacao.
     * @throws ACBrException 
     */
    public void setTransacaoOpcao(String pTransacaoOpcao) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetTransacaoOpcao(getHandle(), pTransacaoOpcao);
        checkResult(ret);
    }
    
    /**
     * Verifica opcao das transacao.
     * 
     * @return opcao das transacao.
     * @throws ACBrException 
     */
    public String getTransacaoOpcao() throws ACBrException {
        ByteBuffer lTransacaoOpcao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetTransacaoOpcao(getHandle(), lTransacaoOpcao, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lTransacaoOpcao, ret);
    }      
    
    /**
     * Informa reimpressao da transacao.
     * 
     * @param pTransacaoReImpressao reimpressao da transacao.
     * @throws ACBrException 
     */
    public void setTransacaoReImpressao(String pTransacaoReImpressao) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetTransacaoReImpressao(getHandle(), pTransacaoReImpressao);
        checkResult(ret);
    }
    
    /**
     * Verifica reimpressao da transacao.
     * 
     * @return reimpressao da transacao.
     * @throws ACBrException 
     */
    public String getTransacaoReImpressao() throws ACBrException {
        ByteBuffer lTransacaoReImpressao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetTransacaoReImpressao(getHandle(), lTransacaoReImpressao, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lTransacaoReImpressao, ret);
    }      
    
    /**
     * Informa transacao pendente.
     * 
     * @param pTransacaoPendente transacao pendente.
     * @throws ACBrException 
     */
    public void setTransacaoPendente(String pTransacaoPendente) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetTransacaoPendente(getHandle(), pTransacaoPendente);
        checkResult(ret);
    }
    
    /**
     * Verifica transacao pendente.
     * 
     * @return transacao pendente.
     * @throws ACBrException 
     */
    public String getTransacaoPendente() throws ACBrException {
        ByteBuffer lTransacaoPendente = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_GetTransacaoPendente(getHandle(), lTransacaoPendente, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lTransacaoPendente, ret);
    }      
    // </editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onExibeMenu">
	public void addOnExibeMenu(ACBrEventListener<TEFVeSPagueExibeMenuEventObject> pListener) {
		if (!hasListeners("onExibeMenu")) {
            ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetOnExibeMenu(getHandle(), new ACBrTEFInterop.TEFVeSPagueExibeMenuCallback() {
                @Override
                public void invoke(String pTitulo, int pOpcoes, int pOpcoesCount, int pMemo, int pMemoCount, IntByReference pItemSelecionado) {
                    onExibeMenu(pTitulo, pOpcoes, pOpcoesCount, pMemo, pMemoCount, pItemSelecionado);
                }
			});
		}
		addListener("onExibeMenu", pListener);
	}
    
	public void removeOnExibeMenu(ACBrEventListener<TEFVeSPagueExibeMenuEventObject> pListener) {
		removeListener("onExibeMenu", pListener);

		if (!hasListeners("onExibeMenu")) {
			ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetOnExibeMenu(getHandle(), null);
		}
	}

	private void onExibeMenu(String pTitulo, int pOpcoes, int pOpcoesCount, int pMemo, int pMemoCount, IntByReference pItemSelecionado) {
		TEFVeSPagueExibeMenuEventObject e = new TEFVeSPagueExibeMenuEventObject(this, pTitulo, pOpcoes, pOpcoesCount);
        //TODO Verificar processo de leitura de opcoes.
        pItemSelecionado = e.getItemSelecionado();
		notifyListeners("onExibeMenu", e);
	}
	//</editor-fold>  
	//<editor-fold defaultstate="collapsed" desc="onObtemCampo">
	public void addOnObtemCampo(ACBrEventListener<TEFVeSPagueObtemCampoEventObject> pListener) {
		if (!hasListeners("onObtemCampo")) {
            ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetOnObtemCampo(getHandle(), new ACBrTEFInterop.TEFVeSPagueObtemCampoCalback() {
                @Override
                public void invoke(String pTitulo, String pMascara, char pTipo, ByteBuffer pResposta, IntByReference pDigitado) {
                    onObtemCampo(pTitulo, pMascara, pTipo, pResposta, pDigitado);
                }
			});
		}
		addListener("onObtemCampo", pListener);
	}
    
	public void removeOnObtemCampo(ACBrEventListener<TEFVeSPagueObtemCampoEventObject> pListener) {
		removeListener("onObtemCampo", pListener);

		if (!hasListeners("onObtemCampo")) {
			ACBrTEFInterop.INSTANCE.TEF_TEFVeSPague_SetOnObtemCampo(getHandle(), null);
		}
	}
    
	private void onObtemCampo(String pTitulo, String pMascara, char pTipo, ByteBuffer pResposta, IntByReference pDigitado) {
		TEFVeSPagueObtemCampoEventObject e = new TEFVeSPagueObtemCampoEventObject(this, pTitulo, pMascara, pTipo);
        //TODO Verificar processo de leitura de opcoes.
        pResposta = e.getResposta();
        pDigitado = e.getDigitado();
		notifyListeners("onObtemCampo", e);
	}
	//</editor-fold>  
    
}