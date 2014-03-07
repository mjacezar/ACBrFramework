package jACBrFramework.tefd;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrComposedClass;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrTEFInterop;
import java.nio.ByteBuffer;
import java.util.Date;

/**
 * Resposta recebida do TEF.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/02/2014 17:27:20, revisao: $Id$
 */
public class Resp extends ACBrComposedClass {

    //<editor-fold defaultstate="collapsed" desc="Constructor">
    Resp(ACBrTEFD pParent, int pComposedHandle) throws ACBrException {
        super(pParent, pComposedHandle);
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Recupera o objeto mandatario associado a resposta.
     * 
     * @return 
     */
    @Override
    public ACBrTEFD getParent() {
        return (ACBrTEFD)super.getParent();
    }
    
    /**
     * Recupera o header.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getHeader() throws ACBrException {
        ByteBuffer lHeader = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetHeader(getHandle(), getComposedHandler(), lHeader, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lHeader, ret);
    }    
    
    /**
     * Recupera o documento vinculado.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getDocumentoVinculado() throws ACBrException {
        ByteBuffer lDocumentoVinculado = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetDocumentoVinculado(getHandle(), getComposedHandler(), lDocumentoVinculado, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lDocumentoVinculado, ret);
    }    
    
    /**
     * Recupera os caracteres magneticos codificados em 7 barras.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getCMC7() throws ACBrException {
        ByteBuffer lCMC7 = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetCMC7(getHandle(), getComposedHandler(), lCMC7, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lCMC7, ret);
    }    
    

    /**
     * Obtem a moeda da requisicao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getTipoPessoa() throws ACBrException {
        ByteBuffer lTipoPessoa = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetTipoPessoa(getHandle(), getComposedHandler(), lTipoPessoa, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lTipoPessoa, ret);
    }     
    
    /**
     * Recupera os dados do documento da pessoa.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getDocumentoPessoa() throws ACBrException {
        ByteBuffer lDocumentoPessoa = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetDocumentoPessoa(getHandle(), getComposedHandler(), lDocumentoPessoa, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lDocumentoPessoa, ret);
    } 
    
    /**
     * Recupera os dados de rede.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getRede() throws ACBrException {
        ByteBuffer lRede = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetRede(getHandle(), getComposedHandler(), lRede, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lRede, ret);
    }    
    
    /**
     * Recupera o nsu da transacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNSU() throws ACBrException {
        ByteBuffer lNSU = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetNSU(getHandle(), getComposedHandler(), lNSU, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lNSU, ret);
    }    
    
    /**
     * Recupera a finalizacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getFinalizacao() throws ACBrException {
        ByteBuffer lFinalizacao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetFinalizacao(getHandle(), getComposedHandler(), lFinalizacao, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lFinalizacao, ret);
    }
    
    /**
     * Recupera o status da transacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getStatusTransacao() throws ACBrException {
        ByteBuffer lStatusTransacao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetStatusTransacao(getHandle(), getComposedHandler(), lStatusTransacao, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lStatusTransacao, ret);
    }   
    
    /**
     * Recupera o NSU da transacao cancelada.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNSUTransacaoCancelada() throws ACBrException {
        ByteBuffer lNSUTransacaoCancelada = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetNSUTransacaoCancelada(getHandle(), getComposedHandler(), lNSUTransacaoCancelada, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lNSUTransacaoCancelada, ret);
    }   
    
    /**
     * Recupera o texto especial operador.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getTextoEspecialOperador() throws ACBrException {
        ByteBuffer lTextoEspecialOperador = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetTextoEspecialOperador(getHandle(), getComposedHandler(), lTextoEspecialOperador, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lTextoEspecialOperador, ret);
    }     
    
    /**
     * Recupera o texto especial cliente.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getTextoEspecialCliente() throws ACBrException {
        ByteBuffer lTextoEspecialCliente = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetTextoEspecialCliente(getHandle(), getComposedHandler(), lTextoEspecialCliente, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lTextoEspecialCliente, ret);
    }  
    
    /**
     * Recupera a autenticacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getAutenticacao() throws ACBrException {
        ByteBuffer lAutenticacao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetAutenticacao(getHandle(), getComposedHandler(), lAutenticacao, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lAutenticacao, ret);
    }   
    
    /**
     * Recupera o banco.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getBanco() throws ACBrException {
        ByteBuffer lBanco = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetBanco(getHandle(), getComposedHandler(), lBanco, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lBanco, ret);
    }      
    
    /**
     * Recupera a agencia.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getAgencia() throws ACBrException {
        ByteBuffer lAgencia = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetAgencia(getHandle(), getComposedHandler(), lAgencia, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lAgencia, ret);
    }      

    /**
     * Recupera a agenciaDC.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getAgenciaDC() throws ACBrException {
        ByteBuffer lAgenciaDC = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetAgenciaDC(getHandle(), getComposedHandler(), lAgenciaDC, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lAgenciaDC, ret);
    }      
    
    /**
     * Recupera a conta.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getConta() throws ACBrException {
        ByteBuffer lConta = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetConta(getHandle(), getComposedHandler(), lConta, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lConta, ret);
    }     
    
    /**
     * Recupera a ContaDC.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getContaDC() throws ACBrException {
        ByteBuffer lContaDC = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetContaDC(getHandle(), getComposedHandler(), lContaDC, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lContaDC, ret);
    }   
    
    /**
     * Recupera o cheque.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getCheque() throws ACBrException {
        ByteBuffer lCheque = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetCheque(getHandle(), getComposedHandler(), lCheque, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lCheque, ret);
    }  
    
    /**
     * Recupera o chequeDC.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getChequeDC() throws ACBrException {
        ByteBuffer lChequeDC = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetChequeDC(getHandle(), getComposedHandler(), lChequeDC, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lChequeDC, ret);
    }    
    
    /**
     * Recupera o nome da administadora.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNomeAdministradora() throws ACBrException {
        ByteBuffer lNomeAdministradora = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetNomeAdministradora(getHandle(), getComposedHandler(), lNomeAdministradora, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lNomeAdministradora, ret);
    }     

    /**
     * Recupera trailer.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getTrailer() throws ACBrException {
        ByteBuffer lTrailer = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetTrailer(getHandle(), getComposedHandler(), lTrailer, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lTrailer, ret);
    }     

    /**
     * Recupera o arquivo de backup.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getArqBackup() throws ACBrException {
        ByteBuffer lArqBackup = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetArqBackup(getHandle(), getComposedHandler(), lArqBackup, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lArqBackup, ret);
    }     
    
    /**
     * Recupera o arquivo de respostas pendentes.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getArqRespPendente() throws ACBrException {
        ByteBuffer lArqRespPendente = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetArqRespPendente(getHandle(), getComposedHandler(), lArqRespPendente, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lArqRespPendente, ret);
    }   
    
    /**
     * Recupera o indice da forma de pagamento.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getIndiceFPG_ECF() throws ACBrException {
        ByteBuffer lIndiceFPG_ECF = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetIndiceFPG_ECF(getHandle(), getComposedHandler(), lIndiceFPG_ECF, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lIndiceFPG_ECF, ret);
    }     
    
    /**
     * Recupera a instituicao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getInstituicao() throws ACBrException {
        ByteBuffer lInstituicao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetInstituicao(getHandle(), getComposedHandler(), lInstituicao, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lInstituicao, ret);
    }   
    
    /**
     * Recupera a modalidade de pagamento.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getModalidadePagto() throws ACBrException {
        ByteBuffer lModalidadePagto = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetModalidadePagto(getHandle(), getComposedHandler(), lModalidadePagto, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lModalidadePagto, ret);
    }      
    
    /**
     * Recupera a modalidade de pagamento descrita.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getModalidadePagtoDescrita() throws ACBrException {
        ByteBuffer lModalidadePagtoDescrita = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetModalidadePagtoDescrita(getHandle(), getComposedHandler(), lModalidadePagtoDescrita, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lModalidadePagtoDescrita, ret);
    }     
    
    /**
     * Recupera a modalidade de pagamento em extenso.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getModalidadeExtenso() throws ACBrException {
        ByteBuffer lModalidadeExtenso = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetModalidadeExtenso(getHandle(), getComposedHandler(), lModalidadeExtenso, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lModalidadeExtenso, ret);
    }       
    
    /**
     * Recupera o codigo da rede autorizada.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getCodigoRedeAutorizada() throws ACBrException {
        ByteBuffer lCodigoRedeAutorizada = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetCodigoRedeAutorizada(getHandle(), getComposedHandler(), lCodigoRedeAutorizada, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lCodigoRedeAutorizada, ret);
    }       

    /**
     * Obtem o identificador da resposta.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getID() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetID(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret;
    }      
    
    /**
     * Obtem a moeda da resposta.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getMoeda() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetMoeda(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret;
    }   
    
    /**
     * Obtem o tipo da transacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getTipoTransacao() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetTipoTransacao(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret;
    }     
    
    /**
     * Obtem o codigo da autorizacao da transacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getCodigoAutorizacaoTransacao() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetCodigoAutorizacaoTransacao(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret;
    }         
    
    /**
     * Obtem o numero de lote da transacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getNumeroLoteTransacao() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetNumeroLoteTransacao(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret;
    }  
    
    /**
     * Obtem o tipo de parcelamento.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getTipoParcelamento() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetTipoParcelamento(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret;
    } 
    
    /**
     * Obtem a quantidade de parcelas.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getQtdParcelas() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetQtdParcelas(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret;
    }     
    
    /**
     * Obtem a quantidade de linhas do comprovante.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getQtdLinhasComprovante() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetQtdLinhasComprovante(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret;
    }    
    
    /**
     * Obtem a ordem de pagamento.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getOrdemPagamento() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetOrdemPagamento(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret;
    } 
    
    /**
     * Obtem o tipo de GP.
     * 
     * @return
     * @throws ACBrException 
     */
    public TefTipo getTipoGP() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetTipoGP(getHandle(), getComposedHandler());
        checkResult(ret);
        return TefTipo.valueOf(ret);
    }   
    
    /**
     * Obtem o parcelador.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getParceladoPor() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetParceladoPor(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret;
    }  
    
    /**
     * Obtem o tipo de operacao.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getTipoOperacao() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetTipoOperacao(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret;
    }      
    
    /**
     * Verifica CNF foi enviado.
     * 
     * @return indica CNF enviado.
     * @throws ACBrException 
     */
    public boolean isCNFEnviado() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetCNFEnviado(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret == 1;
    }      
    
    /**
     * Verifica se a transacao foi aprovada.
     * 
     * @return indica transacao aprovada.
     * @throws ACBrException 
     */
    public boolean isTransacaoAprovada() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetTransacaoAprovada(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret == 1;
    }      
    
    /**
     * Verifica se e uma transacao de debito.
     * 
     * @return indica transacao de debito.
     * @throws ACBrException 
     */
    public boolean isDebito() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetDebito(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret == 1;
    }   
    
    /**
     * Verifica se e uma transacao de credito.
     * 
     * @return indica transacao de credito.
     * @throws ACBrException 
     */
    public boolean isCredito() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetCredito(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret == 1;
    }   
    
    /**
     * Recupera o valor total da transacao.
     * 
     * @return valor total da transacao.
     * @throws ACBrException 
     */
    public double getValorTotal() throws ACBrException {
        DoubleByReference lValorTotal = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetValorTotal(getHandle(), getComposedHandler(), lValorTotal);
        checkResult(ret);   
        return lValorTotal.getValue();
    }      
    
    /**
     * Recupera o valor original da transacao.
     * 
     * @return valor original da transacao.
     * @throws ACBrException 
     */
    public double getValorOriginal() throws ACBrException {
        DoubleByReference lValorOriginal = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetValorOriginal(getHandle(), getComposedHandler(), lValorOriginal);
        checkResult(ret);   
        return lValorOriginal.getValue();
    }      
    
    /**
     * Recupera o valor do saque.
     * 
     * @return valor do saque.
     * @throws ACBrException 
     */
    public double getSaque() throws ACBrException {
        DoubleByReference lSaque = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetSaque(getHandle(), getComposedHandler(), lSaque);
        checkResult(ret);   
        return lSaque.getValue();
    }      
    
    /**
     * Recupera o valor do desconto.
     * 
     * @return valor do desconto.
     * @throws ACBrException 
     */
    public double getDesconto() throws ACBrException {
        DoubleByReference lDesconto = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetDesconto(getHandle(), getComposedHandler(), lDesconto);
        checkResult(ret);   
        return lDesconto.getValue();
    }      
    
    /**
     * Recupera o valor da entrada CDC.
     * 
     * @return valor da entrada CDC.
     * @throws ACBrException 
     */
    public double getValorEntradaCDC() throws ACBrException {
        DoubleByReference lValorEntradaCDC = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetValorEntradaCDC(getHandle(), getComposedHandler(), lValorEntradaCDC);
        checkResult(ret);   
        return lValorEntradaCDC.getValue();
    } 
    
    /**
     * Recupera a data do cheque.
     * 
     * @return data do cheque.
     * @throws ACBrException 
     */
    public Date getDataCheque() throws ACBrException {
        DoubleByReference lDataCheque = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetDataCheque(getHandle(), getComposedHandler(), lDataCheque);
        checkResult(ret);   
        return OleDate.fromOADate(lDataCheque.getValue());
    }     
    
    /**
     * Recupera a data e hora da transacao do host.
     * 
     * @return data e hora da transacao do host.
     * @throws ACBrException 
     */
    public Date getDataHoraTransacaoHost() throws ACBrException {
        DoubleByReference lDataHoraTransacaoHost = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetDataHoraTransacaoHost(getHandle(), getComposedHandler(), lDataHoraTransacaoHost);
        checkResult(ret);   
        return OleDate.fromOADate(lDataHoraTransacaoHost.getValue());
    }     
    
    /**
     * Recupera a data e hora da transacao local.
     * 
     * @return data e hora da transacao local.
     * @throws ACBrException 
     */
    public Date getDataHoraTransacaoLocal() throws ACBrException {
        DoubleByReference lDataHoraTransacaoLocal = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetDataHoraTransacaoLocal(getHandle(), getComposedHandler(), lDataHoraTransacaoLocal);
        checkResult(ret);   
        return OleDate.fromOADate(lDataHoraTransacaoLocal.getValue());
    }     
    
    /**
     * Recupera a data do pre-datado.
     * 
     * @return data do pre-datado.
     * @throws ACBrException 
     */
    public Date getDataPreDatado() throws ACBrException {
        DoubleByReference lDataPreDatado = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetDataPreDatado(getHandle(), getComposedHandler(), lDataPreDatado);
        checkResult(ret);   
        return OleDate.fromOADate(lDataPreDatado.getValue());
    }     
    
    /**
     * Recupera data e hora da transacao cancelada.
     * 
     * @return data e hora da transacao cancelada.
     * @throws ACBrException 
     */
    public Date getDataHoraTransacaoCancelada() throws ACBrException {
        DoubleByReference lDataHoraTransacaoCancelada = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetDataHoraTransacaoCancelada(getHandle(), getComposedHandler(), lDataHoraTransacaoCancelada);
        checkResult(ret);   
        return OleDate.fromOADate(lDataHoraTransacaoCancelada.getValue());
    }     
    
    /**
     * Recupera data e hora do comprovante da transacao.
     * 
     * @return data e hora do comprovante da transacao.
     * @throws ACBrException 
     */
    public Date getDataHoraTransacaoComprovante() throws ACBrException {
        DoubleByReference lDataHoraTransacaoComprovante = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetDataHoraTransacaoComprovante(getHandle(), getComposedHandler(), lDataHoraTransacaoComprovante);
        checkResult(ret);   
        return OleDate.fromOADate(lDataHoraTransacaoComprovante.getValue());
    }     
    
    /**
     * Recupera data do vencimento.
     * 
     * @return data do vencimento.
     * @throws ACBrException 
     */
    public Date getDataVencimento() throws ACBrException {
        DoubleByReference lDataVencimento = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetDataVencimento(getHandle(), getComposedHandler(), lDataVencimento);
        checkResult(ret);   
        return OleDate.fromOADate(lDataVencimento.getValue());
    }     
    
    /**
     * Recupera data de entrada CDC.
     * 
     * @return data de entrada CDC.
     * @throws ACBrException 
     */
    public Date getDataEntradaCDC() throws ACBrException {
        DoubleByReference lDataEntradaCDC = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetDataEntradaCDC(getHandle(), getComposedHandler(), lDataEntradaCDC);
        checkResult(ret);   
        return OleDate.fromOADate(lDataEntradaCDC.getValue());
    }     
    
    /**
     * Obtem as linhas do comprovante da primeira via.
     * 
     * @return linhas do comprovante.
     * @throws ACBrException 
     */
    public String[] getImagemComprovante1aVia() throws ACBrException {
        int count = ACBrTEFInterop.INSTANCE.TEF_Resp_GetImagemComprovante1aViaCount(getHandle(), getComposedHandler());
        checkResult(count);
        String[] lLinhas = new String[count];
        for (int i = 0; i < count; i++) {
            ByteBuffer lLinha = ByteBuffer.allocate(STR_BUFFER_LEN);
            int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetImagemComprovante1aViaLinha(getHandle(), getComposedHandler(), lLinha, STR_BUFFER_LEN, i);
            checkResult(ret);   
            lLinhas[i] = fromUTF8(lLinha, ret);
        }
        return lLinhas;
    }    
    
    /**
     * Obtem as linhas do comprovante da segunda via.
     * 
     * @return linhas do comprovante.
     * @throws ACBrException 
     */
    public String[] getImagemComprovante2aVia() throws ACBrException {
        int count = ACBrTEFInterop.INSTANCE.TEF_Resp_GetImagemComprovante2aViaCount(getHandle(), getComposedHandler());
        checkResult(count);
        String[] lLinhas = new String[count];
        for (int i = 0; i < count; i++) {
            ByteBuffer lLinha = ByteBuffer.allocate(STR_BUFFER_LEN);
            int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_GetImagemComprovante2aViaLinha(getHandle(), getComposedHandler(), lLinha, STR_BUFFER_LEN, i);
            checkResult(ret);   
            lLinhas[i] = fromUTF8(lLinha, ret);
        }
        return lLinhas;
    }    
    
    /**
     * Realiza a leitura das informacoes da sequencia 0 para a identificacao 
     * recebida.
     * 
     * @param pIdentificacao identificacao a ser lida.
     * @return 
     * @throws ACBrException 
     */
    public String leInformacao(int pIdentificacao) throws ACBrException {
        return leInformacao(pIdentificacao, 0);
    }

    /**
     * Realiza a leitura da informacao para a sequencia e identificacao recebida.
     * 
     * @param pIdentificacao identificacao recebida.
     * @param pSequencia sequencia a ser lida.
     * @return informacao lida.
     * @throws ACBrException 
     */
    public String leInformacao(int pIdentificacao, int pSequencia) throws ACBrException {
        ByteBuffer lIdentificacao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrTEFInterop.INSTANCE.TEF_Resp_LeInformacao(getHandle(), getComposedHandler(), lIdentificacao, STR_BUFFER_LEN, pIdentificacao, pSequencia);
        checkResult(ret);   
        return fromUTF8(lIdentificacao, ret);
    }    
    // </editor-fold>

}