package jACBrFramework.tefd;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrComposedClass;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrTEFInterop;
import java.nio.ByteBuffer;
import java.util.Date;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 27/02/2014 16:17:17, revisao: $Id$
 */
public class Req extends ACBrComposedClass {

    //<editor-fold defaultstate="collapsed" desc="Constructor">
    Req(ACBrTEFD pParent, int pComposedHandle) throws ACBrException {
        super(pParent, pComposedHandle);
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta o header do TEF.
     * 
     * @param pHeader header.
     * @throws ACBrException 
     */
    public void setHeader(String pHeader) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_SetHeader(getHandle(), getComposedHandler(), toUTF8(pHeader));
        checkResult(ret);
    }
    
    /**
     * Recupera o header.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getHeader() throws ACBrException {
        ByteBuffer lHeader = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_GetHeader(getHandle(), getComposedHandler(), lHeader, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lHeader, ret);
    }
    
    /**
     * Seta o documento vinculado.
     * 
     * @param pDocumentoVinculado documento vinculado.
     * @throws ACBrException 
     */
    public void setDocumentoVinculado(String pDocumentoVinculado) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_SetDocumentoVinculado(getHandle(), getComposedHandler(), toUTF8(pDocumentoVinculado));
        checkResult(ret);
    }
    
    /**
     * Recupera o documento vinculado.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getDocumentoVinculado() throws ACBrException {
        ByteBuffer lDocumentoVinculado = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_GetDocumentoVinculado(getHandle(), getComposedHandler(), lDocumentoVinculado, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lDocumentoVinculado, ret);
    }
    
    /**
     * Seta os caracteres magneticos codificados em 7 barras.
     * 
     * @param pCMC7 caracteres magneticos codificados em 7 barras.
     * @throws ACBrException 
     */
    public void setCMC7(String pCMC7) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_SetCMC7(getHandle(), getComposedHandler(), toUTF8(pCMC7));
        checkResult(ret);
    }
    
    /**
     * Recupera os caracteres magneticos codificados em 7 barras.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getCMC7() throws ACBrException {
        ByteBuffer lCMC7 = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_GetCMC7(getHandle(), getComposedHandler(), lCMC7, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lCMC7, ret);
    }
    
    /**
     * Seta os dados de documento da pessoa.
     * 
     * @param pDocumentoPessoa dados de documento da pessoa.
     * @throws ACBrException 
     */
    public void setDocumentoPessoa(String pDocumentoPessoa) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_SetDocumentoPessoa(getHandle(), getComposedHandler(), toUTF8(pDocumentoPessoa));
        checkResult(ret);
    }
    
    /**
     * Recupera os dados do documento da pessoa.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getDocumentoPessoa() throws ACBrException {
        ByteBuffer lDocumentoPessoa = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_GetDocumentoPessoa(getHandle(), getComposedHandler(), lDocumentoPessoa, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lDocumentoPessoa, ret);
    }

    /**
     * Seta os dados de rede.
     * 
     * @param pRede dados de rede.
     * @throws ACBrException 
     */
    public void setRede(String pRede) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_SetRede(getHandle(), getComposedHandler(), toUTF8(pRede));
        checkResult(ret);
    }
    
    /**
     * Recupera os dados de rede.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getRede() throws ACBrException {
        ByteBuffer lRede = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_GetRede(getHandle(), getComposedHandler(), lRede, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lRede, ret);
    }
    
    /**
     * Seta o NSU da transacao.
     * 
     * @param pNSU nsu da transaco.
     * @throws ACBrException 
     */
    public void setNSU(String pNSU) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_SetNSU(getHandle(), getComposedHandler(), toUTF8(pNSU));
        checkResult(ret);
    }
    
    /**
     * Recupera o nsu da transacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNSU() throws ACBrException {
        ByteBuffer lNSU = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_GetNSU(getHandle(), getComposedHandler(), lNSU, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lNSU, ret);
    }
    
    /**
     * Seta a finalizacao.
     * 
     * @param pFinalizacao finalizacao.
     * @throws ACBrException 
     */
    public void setFinalizacao(String pFinalizacao) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_SetFinalizacao(getHandle(), getComposedHandler(), toUTF8(pFinalizacao));
        checkResult(ret);
    }
    
    /**
     * Recupera a finalizacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getFinalizacao() throws ACBrException {
        ByteBuffer lFinalizacao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_GetFinalizacao(getHandle(), getComposedHandler(), lFinalizacao, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lFinalizacao, ret);
    }
    
    /**
     * Seta o identificador da requisicao.
     * 
     * @param pID identificador da requisicao.
     * @throws ACBrException 
     */
    public void setID(int pID) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_SetID(getHandle(), getComposedHandler(), pID);
        checkResult(ret);
    }    

    /**
     * Obtem o identificador da requisicao.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getID() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_GetID(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret;
    }  
    
    /**
     * Seta a moeda da requisicao.
     * 
     * @param pMoeda moeda da requisicao.
     * @throws ACBrException 
     */
    public void setMoeda(int pMoeda) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_SetMoeda(getHandle(), getComposedHandler(), pMoeda);
        checkResult(ret);
    }    

    /**
     * Obtem a moeda da requisicao.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getMoeda() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_GetMoeda(getHandle(), getComposedHandler());
       checkResult(ret);
       return ret;
    }   
    
    /**
     * Seta o tipo da pessoa associada a transacao.
     * 
     * @param pTipoPessoa tipo da pessoa associada a transacao.
     * @throws ACBrException 
     */
    public void setTipoPessoa(char pTipoPessoa) throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_SetTipoPessoa(getHandle(), getComposedHandler(), pTipoPessoa);
        checkResult(ret);
    }    

    /**
     * Obtem a moeda da requisicao.
     * 
     * @return
     * @throws ACBrException 
     */
    public char getTipoPessoa() throws ACBrException {
        return (char)ACBrTEFInterop.INSTANCE.TEF_Req_GetTipoPessoa(getHandle(), getComposedHandler());
    } 
    
    /**
     * Seta o valor total da transacao.
     * 
     * @param pValorTotal valor total da transacao.
     * @throws ACBrException 
     */
    public void setValorTotal(double pValorTotal) throws ACBrException {     
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_SetValorTotal(getHandle(), getComposedHandler(), pValorTotal);
        checkResult(ret);
    }  
    
    /**
     * Recupera o valor total da transacao.
     * 
     * @return valor total da transacao.
     * @throws ACBrException 
     */
    public double getValorTotal() throws ACBrException {
        DoubleByReference lValorTotal = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_GetValorTotal(getHandle(), getComposedHandler(), lValorTotal);
        checkResult(ret);   
        return lValorTotal.getValue();
    }    
    
    /**
     * Seta a data do cheque.
     * 
     * @param pDataCheque data do cheque.
     * @throws ACBrException 
     */
    public void setDataCheque(Date pDataCheque) throws ACBrException {     
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_SetDataCheque(getHandle(), getComposedHandler(), OleDate.toOADate(pDataCheque));
        checkResult(ret);
    }  
    
    /**
     * Recupera a data do cheque.
     * 
     * @return data do cheque.
     * @throws ACBrException 
     */
    public Date getDataCheque() throws ACBrException {
        DoubleByReference lDataCheque = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_GetDataCheque(getHandle(), getComposedHandler(), lDataCheque);
        checkResult(ret);   
        return OleDate.fromOADate(lDataCheque.getValue());
    }     
    
    /**
     * Seta a data e hora do comprovante da transacao.
     * 
     * @param pDataHoraTransacaoComprovante data e hora do comprovante da transacao.
     * @throws ACBrException 
     */
    public void setDataHoraTransacaoComprovante(Date pDataHoraTransacaoComprovante) throws ACBrException {     
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_SetDataHoraTransacaoComprovante(getHandle(), getComposedHandler(), OleDate.toOADate(pDataHoraTransacaoComprovante));
        checkResult(ret);
    }  
    
    /**
     * Recupera a data e hora do comprovante da transacao.
     * 
     * @return data e hora do comprovante da transacao.
     * @throws ACBrException 
     */
    public Date getDataHoraTransacaoComprovante() throws ACBrException {
        DoubleByReference lDataHoraTransacaoComprovante = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Req_GetDataHoraTransacaoComprovante(getHandle(), getComposedHandler(), lDataHoraTransacaoComprovante);
        checkResult(ret);   
        return OleDate.fromOADate(lDataHoraTransacaoComprovante.getValue());
    }
    // </editor-fold>    

}