package jACBrFramework.paf;

import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrClass;
import jACBrFramework.ACBrEventListener;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.aac.ACBrAAC;
import jACBrFramework.ead.ACBrEAD;
import jACBrFramework.interop.ACBrPAFInterop;
import java.nio.ByteBuffer;
import java.nio.charset.Charset;

/**
 * Classe para para as operacoes do PAF.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 14:10:14, revisao: $Id$
 */
public class ACBrPAF extends ACBrClass {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Instancia AAC.
     */
    private ACBrAAC aac;
    /**
     * Instancia EAD.
     */
    private ACBrEAD ead;
    /**
     * Registros {@see ACBrPAF_A}.
     */
    private ACBrPAF_A paf_A = new ACBrPAF_A();
    /**
     * Registros {@see ACBrPAF_B}.
     */
    private ACBrPAF_B paf_B = new ACBrPAF_B();
    /**
     * Registros {@see ACBrPAF_C}.
     */
    private ACBrPAF_C paf_C = new ACBrPAF_C();
    /**
     * Registros {@see ACBrPAF_D}.
     */
    private ACBrPAF_D paf_D = new ACBrPAF_D();
    /**
     * Registros {@see ACBrPAF_E}.
     */
    private ACBrPAF_E paf_E = new ACBrPAF_E();
    /**
     * Registros {@see ACBrPAF_H}.
     */
    private ACBrPAF_H paf_H = new ACBrPAF_H();
    /**
     * Registros {@see ACBrPAF_N}.
     */
    private ACBrPAF_N paf_N = new ACBrPAF_N();
    /**
     * Registros {@see ACBrPAF_P}.
     */
    private ACBrPAF_P paf_P = new ACBrPAF_P();
    /**
     * Registros {@see ACBrPAF_R}.
     */
    private ACBrPAF_R paf_R = new ACBrPAF_R();
    /**
     * Registros {@see ACBrPAF_T}.
     */
    private ACBrPAF_T paf_T = new ACBrPAF_T();
    /**
     * Registros {@see ACBrPAF_U}.
     */
    private ACBrPAF_U paf_U = new ACBrPAF_U();
    /**
     * Registros {@see ACBrPAF_TITP}.
     */
    private ACBrPAF_TITP paf_TITP = new ACBrPAF_TITP();
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Construtor padrao.
     *
     * @throws ACBrException excecao acionada ao construir o objeto.
     */
    public ACBrPAF() throws ACBrException {
    }
    /**
     * Cria um novo objeto com base no charset recebido.
     * 
     * @param pCharset charset utilizado na conversao para geracao do sintegra.
     */
    public ACBrPAF(Charset pCharset) throws ACBrException {
        this();
        setCustomCharset(pCharset);
    }    
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Override Methods">
    /**
     * Realiza a inicializacao da comunicacao com a acbr.
     *
     * @throws ACBrException excecao acionada ao inicializar o componente.
     */
    @Override
    protected void onInitialize() throws ACBrException {
        IntByReference handle = new IntByReference();
        int ret = ACBrPAFInterop.INSTANCE.PAF_Create(handle);
        checkResult(ret);
        setHandle(handle.getValue());
    }

    /**
     * Finaliza a comunicacao com a acbr.
     *
     * @throws ACBrException excecao acionada ao finalizar a comunicacao.
     */
    @Override
    protected void onFinalize() throws ACBrException {
        if (getHandle() != 0) {
            int ret = ACBrPAFInterop.INSTANCE.PAF_Destroy(getHandle());
            checkResult(ret);
            setHandle(0);
        }
    }

    /**
     * Responsavel pela verificacao dos resultados a cada operacao.
     *
     * @param pResult resultado da operacao.
     * @throws ACBrException mensagem de erro caso nao tenha havido
     * processamento com sucesso.
     */
    @Override
    protected void checkResult(int pResult) throws ACBrException {
        switch (pResult) {
            case -1: {
                String lMessage;
                final int LEN = 1024;
                ByteBuffer buffer = ByteBuffer.allocate(LEN);
                int ret = ACBrPAFInterop.INSTANCE.PAF_GetUltimoErro(getHandle(), buffer, LEN);

                lMessage = fromUTF8(buffer, ret);
                throw new ACBrException(lMessage);
            }
            case -2: {
                throw new ACBrException("ACBr PAF não inicializado.");
            }
        }
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta a chave RSA e um Wrapper para o evento 
     * 
     * {@see ACBrPAF#addOnPAFGetKeyRSA}
     * @param pKeyRSA chave rsa.
     */
    public void setKeyRSA(final String pKeyRSA) {
        addOnPAFGetKeyRSA(new ACBrEventListener<PAFGetKeyRSAEventObject>() {
            @Override
            public void notification(PAFGetKeyRSAEventObject e) {
                e.setKey(pKeyRSA);
            }
        });
    }    
    
    /**
     * Seta o nome do arquivo para exportacao.
     * 
     * @param pNomeArquivo nome do arquivo que sera geracao.
     * @throws ACBrException 
     */
    public void setNomeArquivo(String pNomeArquivo) throws ACBrException {
        int ret = ACBrPAFInterop.INSTANCE.PAF_SetPath(getHandle(), toUTF8(pNomeArquivo));
        checkResult(ret);
    }
    
    /**
     * Recupera o nome do arquivo associado a geracao.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNomeArquivo() throws ACBrException {
        ByteBuffer lNomeArquivo = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrPAFInterop.INSTANCE.PAF_GetPath(getHandle(), lNomeArquivo, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lNomeArquivo, ret);
    }    
    
    /**
     * Seta o delimitador do arquivo.
     * 
     * @param pDelimitador delimitador associado ao arquivo.
     * @throws ACBrException 
     */
    public void setDelimitador(String pDelimitador) throws ACBrException {
        int ret = ACBrPAFInterop.INSTANCE.PAF_SetDelimitador(getHandle(), toUTF8(pDelimitador));
        checkResult(ret);
    }

    /**
     * Recupera o delimitador de arquivo.
     * 
     * @return delimitador de arquivo.
     * @throws ACBrException 
     */
    public String getDelimitador() throws ACBrException {
        ByteBuffer lDelimitador = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrPAFInterop.INSTANCE.PAF_GetDelimitador(getHandle(), lDelimitador, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lDelimitador, ret);
    }
    
    /**
     * Seta a mascara para geracao do arquivo.
     * 
     * @param pCurMascara mascara associada ao arquivo.
     * @throws ACBrException 
     */
    public void setCurMascara(String pCurMascara) throws ACBrException {
        int ret = ACBrPAFInterop.INSTANCE.PAF_SetCurMascara(getHandle(), toUTF8(pCurMascara));
        checkResult(ret);
    }

    /**
     * Recupera a mascara associada a geracao do arquivo.
     * 
     * @return mascara associada ao arquivo.
     * @throws ACBrException 
     */
    public String getCurMascara() throws ACBrException {
        ByteBuffer lMascara = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrPAFInterop.INSTANCE.PAF_GetCurMascara(getHandle(), lMascara, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lMascara, ret);
    }  
    
    /**
     * Indica que as string sofrerao trim.
     * 
     * @param pTrimString indica que o trim deve ser aplicado nas strings.
     * @throws ACBrException 
     */
    public void setTrimString(boolean pTrimString) throws ACBrException {
        int ret = ACBrPAFInterop.INSTANCE.PAF_SetTrimString(getHandle(), pTrimString);
        checkResult(ret);
    }

    /**
     * Verifica se as strings do arquivos sofrerao trim.
     * 
     * @return indica se as string sofrerao trim.
     * @throws ACBrException 
     */
    public boolean isTrimString() throws ACBrException {
        return ACBrPAFInterop.INSTANCE.PAF_GetTrimString(getHandle()) != 0;
    }    
    
    /**
     * Informa se o arquivo sera ou nao assinado.
     * 
     * @param pIndAssinarArquivo indica que o o arquivo deve ser assinado.
     * @throws ACBrException 
     */
    public void setAssinarArquivo(boolean pIndAssinarArquivo) throws ACBrException {
        int ret = ACBrPAFInterop.INSTANCE.PAF_SetAssinarArquivo(getHandle(), pIndAssinarArquivo);
        checkResult(ret);
    }

    /**
     * Verifica se o arquivo e assinado.
     * 
     * @return indica se o arquivo gerado e assinado.
     * @throws ACBrException 
     */
    public boolean isAssinarArquivo() throws ACBrException {
        return ACBrPAFInterop.INSTANCE.PAF_GetAssinarArquivo(getHandle()) != 0;
    }     
    
    /**
     * Seta a utilizacao do AAC.
     * 
     * @param pAac instancia do AAC.
     * @throws ACBrException 
     */
    public void setAac(ACBrAAC pAac) throws ACBrException {
        int lHandle = pAac == null ? new IntByReference().getValue() : pAac.getHandle();
        int ret = ACBrPAFInterop.INSTANCE.PAF_SetAAC(getHandle(), lHandle);
        checkResult(ret);
        this.aac = pAac;
    }   
    
    /**
     * Seta a utilizacao do EAD.
     * 
     * @param pEad instancia do EAD.
     * @throws ACBrException 
     */
    public void setEad(ACBrEAD pEad) throws ACBrException {
        int lHandle = pEad == null ? new IntByReference().getValue() : pEad.getHandle();
        int ret = ACBrPAFInterop.INSTANCE.PAF_SetEAD(getHandle(), lHandle);
        checkResult(ret);
        this.ead = pEad;
    }
    
    /**
     * Assina o arquivo com EAD.
     * 
     * @param pArquivo arquivo a ser assinado.
     * @return indica o status da assinatura.
     * @throws ACBrException 
     */
    public boolean assinarArquivoComEAD(String pArquivo) throws ACBrException {
        int ret = ACBrPAFInterop.INSTANCE.PAF_AssinarArquivoComEAD(getHandle(), toUTF8(pArquivo));
        checkResult(ret);

        return ret != 0;
    }    
    
    /**
     * Preenche os valores do PAF_A.
     * 
     * @throws ACBrException 
     */
    private void preenche_A() throws ACBrException {
        // Criando as variaveis para A2.
        ACBrPAFInterop.RegistroA2Rec[] lRecord = criaVetorJNA(ACBrPAFInterop.RegistroA2Rec.class, paf_A.getRegistrosA2().size());
        // Montando o registro A2.  
        int i = 0;
        for (ACBrPAFRegistroA2 lRegistro : paf_A.getRegistrosA2()) {
            lRecord[i].Data = OleDate.toOADate(lRegistro.getData());
            lRecord[i].MeioDePagamento = toByte(lRegistro.getMeioPagamento(), 26);
            lRecord[i].CodigoTipoDocumento = toByte(lRegistro.getCodigoTipoDocumento().getCodigo(), 2);
            lRecord[i].Valor = lRegistro.getValor();
            lRecord[i].RegistroValido = lRegistro.isRegistroValido();
            i++;
        }
        int ret = ACBrPAFInterop.INSTANCE.PAF_Preenche_A(getHandle(), lRecord, paf_A.getRegistrosA2().size());
        checkResult(ret);
    }    

    /**
     * Preenche os valores do PAF_B.
     * 
     * @throws ACBrException 
     */
    private void preenche_B() throws ACBrException {
        // Criando as variaveis para B1 e B2.
        ACBrPAFInterop.RegistroHD1Rec lRegistroB1 = new ACBrPAFInterop.RegistroHD1Rec();
        ACBrPAFInterop.RegistroB2Rec[] lRegistrosB2 = criaVetorJNA(ACBrPAFInterop.RegistroB2Rec.class, paf_B.getRegistrosB2().size());
        
        // Montando o registro B1.  
        lRegistroB1.RAZAOSOCIAL = toByte(paf_B.getRegistroB1().getRazaoSocial(), 51);
        lRegistroB1.UF = toByte(paf_B.getRegistroB1().getUf(), 3);
        lRegistroB1.CNPJ = toByte(paf_B.getRegistroB1().getCnpj(), 15);
        lRegistroB1.IE = toByte(paf_B.getRegistroB1().getInscEstadual(), 15);
        lRegistroB1.IM = toByte(paf_B.getRegistroB1().getInscMunicipal(), 15);
        
        // Montando o registro B2.  
        int i = 0;
        for (ACBrPAFRegistroB2 lRegistro : paf_B.getRegistrosB2()) {
            lRegistrosB2[i].BOMBA = toByte(lRegistro.getBomba(), 4);
            lRegistrosB2[i].BICO = toByte(lRegistro.getBico(), 4);
            lRegistrosB2[i].DATA = OleDate.toOADate(lRegistro.getData());
            lRegistrosB2[i].HORA = OleDate.toOADate(lRegistro.getHora());
            lRegistrosB2[i].MOTIVO = toByte(lRegistro.getMotivo(), 51);
            lRegistrosB2[i].CNPJ_EMPRESA = toByte(lRegistro.getCnpjEmpresa(), 15);
            lRegistrosB2[i].CPF_TECNICO = toByte(lRegistro.getCpfTecnico(), 12);
            lRegistrosB2[i].NRO_LACRE_ANTES = toByte(lRegistro.getNumLacreAntes(), 16);
            lRegistrosB2[i].NRO_LACRE_APOS = toByte(lRegistro.getNumLacreApos(), 16);
            lRegistrosB2[i].ENCERRANTE_ANTES = lRegistro.getEncerranteAntes();
            lRegistrosB2[i].ENCERRANTE_APOS = lRegistro.getEncerranteApos();
            lRegistrosB2[i].RegistroValido = lRegistro.isRegistroValido();
            i++;
        }
        int ret = ACBrPAFInterop.INSTANCE.PAF_Preenche_B(getHandle(), lRegistroB1, lRegistrosB2, paf_B.getRegistrosB2().size());
        checkResult(ret);
    }
    
    /**
     * Preenche os valores do PAF_C.
     * 
     * @throws ACBrException 
     */
    private void preenche_C() throws ACBrException {
        // Criando as variaveis para C1 e C2.
        ACBrPAFInterop.RegistroHD1Rec lRegistroC1 = new ACBrPAFInterop.RegistroHD1Rec();
        ACBrPAFInterop.RegistroC2Rec[] lRegistrosC2 = criaVetorJNA(ACBrPAFInterop.RegistroC2Rec.class, paf_C.getRegistrosC2().size());
        
        // Montando o registro C1.  
        lRegistroC1.RAZAOSOCIAL = toByte(paf_C.getRegistroC1().getRazaoSocial(), 51);
        lRegistroC1.UF = toByte(paf_C.getRegistroC1().getUf(), 3);
        lRegistroC1.CNPJ = toByte(paf_C.getRegistroC1().getCnpj(), 15);
        lRegistroC1.IE = toByte(paf_C.getRegistroC1().getInscEstadual(), 15);
        lRegistroC1.IM = toByte(paf_C.getRegistroC1().getInscMunicipal(), 15);
        
        // Montando o registro C2.  
        int i = 0;
        for (ACBrPAFRegistroC2 lRegistro : paf_C.getRegistrosC2()) {
            lRegistrosC2[i].ID_ABASTECIMENTO = toByte(lRegistro.getIdAbastecimento(), 16);
            lRegistrosC2[i].TANQUE = toByte(lRegistro.getTanque(), 4);
            lRegistrosC2[i].BOMBA = toByte(lRegistro.getBomba(), 4);
            lRegistrosC2[i].COMBUSTIVEL = toByte(lRegistro.getCombustivel(), 21);
            lRegistrosC2[i].DATA_ABASTECIMENTO = OleDate.toOADate(lRegistro.getDataAbastecimento());
            lRegistrosC2[i].HORA_ABASTECIMENTO = OleDate.toOADate(lRegistro.getHoraAbastecimento());
            lRegistrosC2[i].ENCERRANTE_INICIAL = lRegistro.getEncerranteInicial();
            lRegistrosC2[i].ENCERRANTE_FINAL = lRegistro.getEncerrantaFinal();
            lRegistrosC2[i].STATUS_ABASTECIMENTO = toByte(lRegistro.getStatusAbastecimento(), 11);
            lRegistrosC2[i].NRO_SERIE_ECF = toByte(lRegistro.getNumSerieEcf(), 15);
            lRegistrosC2[i].DATA = OleDate.toOADate(lRegistro.getData());
            lRegistrosC2[i].HORA = OleDate.toOADate(lRegistro.getHora());
            lRegistrosC2[i].COO = lRegistro.getCoo();
            lRegistrosC2[i].NRO_NOTA_FISCAL = lRegistro.getNumNotaFiscal();
            lRegistrosC2[i].VOLUME = lRegistro.getVolume();
            lRegistrosC2[i].RegistroValido = lRegistro.isRegistroValido();
            i++;
        }
        int ret = ACBrPAFInterop.INSTANCE.PAF_Preenche_C(getHandle(), lRegistroC1, lRegistrosC2, paf_C.getRegistrosC2().size());
        checkResult(ret);
    }
    
    /**
     * Preenche os valores do PAF_D.
     * 
     * @throws ACBrException 
     */
    private void preenche_D() throws ACBrException {
        // Criando as variaveis para D1, D2, D3 e D4.
        ACBrPAFInterop.RegistroHD1Rec lRegistroD1 = new ACBrPAFInterop.RegistroHD1Rec();
        ACBrPAFInterop.RegistroD2Rec[] lRegistrosD2 = criaVetorJNA(ACBrPAFInterop.RegistroD2Rec.class, paf_D.getRegistrosD2().size());
        ACBrPAFInterop.RegistroD3Rec[] lRegistrosD3 = criaVetorJNA(ACBrPAFInterop.RegistroD3Rec.class, paf_D.countD3());
        ACBrPAFInterop.RegistroD4Rec[] lRegistrosD4 = criaVetorJNA(ACBrPAFInterop.RegistroD4Rec.class, paf_D.countD4());

        // Montando o registro D1.        
        lRegistroD1.RAZAOSOCIAL = toByte(paf_D.getRegistroD1().getRazaoSocial(), 51);
        lRegistroD1.UF = toByte(paf_D.getRegistroD1().getUf(), 3);
        lRegistroD1.CNPJ = toByte(paf_D.getRegistroD1().getCnpj(), 15);
        lRegistroD1.IE = toByte(paf_D.getRegistroD1().getInscEstadual(), 15);
        lRegistroD1.IM = toByte(paf_D.getRegistroD1().getInscMunicipal(), 15);
        
        int iDxD2 = 0, iDxD3 = 0, iDxD4 = 0;
        for (ACBrPAFRegistroD2 lRegistroD2 : paf_D.getRegistrosD2()) {
            // Populando o registro D2
            lRegistrosD2[iDxD2].QTD_D3 = lRegistroD2.getRegistrosD3().size();
            lRegistrosD2[iDxD2].QTD_D4 = lRegistroD2.getRegistrosD4().size();
            lRegistrosD2[iDxD2].NUM_FAB = toByte(lRegistroD2.getNumFabricacao(), 21);
            lRegistrosD2[iDxD2].MF_ADICIONAL = toByte(lRegistroD2.getMfAdicional(), 2);
            lRegistrosD2[iDxD2].TIPO_ECF = toByte(lRegistroD2.getTipoEcf(), 8);
            lRegistrosD2[iDxD2].MARCA_ECF = toByte(lRegistroD2.getMarcaEcf(), 21);
            lRegistrosD2[iDxD2].MODELO_ECF = toByte(lRegistroD2.getModeloEcf(), 21);
            lRegistrosD2[iDxD2].COO = toByte(lRegistroD2.getCoo(), 7);
            lRegistrosD2[iDxD2].NUM_DAV = toByte(lRegistroD2.getNumDav(), 14);
            lRegistrosD2[iDxD2].DT_DAV = OleDate.toOADate(lRegistroD2.getDataDav());
            lRegistrosD2[iDxD2].TIT_DAV = toByte(lRegistroD2.getTituloDav(), 31);
            lRegistrosD2[iDxD2].VLT_DAV = lRegistroD2.getValorTotalDav();
            lRegistrosD2[iDxD2].COO_DFV = toByte(lRegistroD2.getCooDocFiscalVenda(), 7);
            lRegistrosD2[iDxD2].NUMERO_ECF = toByte(lRegistroD2.getNumeroEcf(), 4);
            lRegistrosD2[iDxD2].NOME_CLIENTE = toByte(lRegistroD2.getNomeCliente(), 41);
            lRegistrosD2[iDxD2].CPF_CNPJ = toByte(lRegistroD2.getCpfCnpj(), 15);
            lRegistrosD2[iDxD2].RegistroValido = lRegistroD2.isRegistroValido();
            
            // Populando o registro D3
            for (ACBrPAFRegistroD3 lRegistroD3 : lRegistroD2.getRegistrosD3()) {
                lRegistrosD3[iDxD3].DT_INCLUSAO = OleDate.toOADate(lRegistroD3.getDataInclucao());
                lRegistrosD3[iDxD3].NUM_ITEM = lRegistroD3.getNumItem();
                lRegistrosD3[iDxD3].COD_ITEM = toByte(lRegistroD3.getCodItem(), 15);
                lRegistrosD3[iDxD3].DESC_ITEM = toByte(lRegistroD3.getDescrItem(), 101);
                lRegistrosD3[iDxD3].QTDE_ITEM = lRegistroD3.getQtdeItem();
                lRegistrosD3[iDxD3].UNI_ITEM = toByte(lRegistroD3.getUnidItem(), 4);
                lRegistrosD3[iDxD3].VL_UNIT = lRegistroD3.getValorItem();
                lRegistrosD3[iDxD3].VL_DESCTO = lRegistroD3.getValorDesconto();
                lRegistrosD3[iDxD3].VL_ACRES = lRegistroD3.getValorAcrescimo();
                lRegistrosD3[iDxD3].VL_TOTAL = lRegistroD3.getValorTotal();
                lRegistrosD3[iDxD3].DEC_VL_UNIT = lRegistroD3.getCasasDecimaisVlrUn();
                lRegistrosD3[iDxD3].DEC_QTDE_ITEM = lRegistroD3.getCasasDecimaisQtd();
                lRegistrosD3[iDxD3].SIT_TRIB = toByte(lRegistroD3.getSituacaoTributaria(), 2);
                lRegistrosD3[iDxD3].ALIQ = lRegistroD3.getAliquota();
                lRegistrosD3[iDxD3].IND_CANC = toByte(lRegistroD3.getIndCancelamento(), 2);
                lRegistrosD3[iDxD3].RegistroValido = lRegistroD3.isRegistroValido();
                iDxD3++;                
            }
            
            // Populando o registro D4
            for (ACBrPAFRegistroD4 lRegistroD4 : lRegistroD2.getRegistrosD4()) {
                lRegistrosD4[iDxD4].NumeroDAV = toByte(lRegistroD4.getNumeroDAV(), 14);
                lRegistrosD4[iDxD4].DataAlteracao = OleDate.toOADate(lRegistroD4.getDataAlteracao());
                lRegistrosD4[iDxD4].HoraAlteracao = OleDate.toOADate(lRegistroD4.getHoraAlteracao());
                lRegistrosD4[iDxD4].CodigoProdutoServico = toByte(lRegistroD4.getCodigoProdutoServico(), 15);
                lRegistrosD4[iDxD4].Descricao = toByte(lRegistroD4.getDescricao(), 101);
                lRegistrosD4[iDxD4].Quantidade = lRegistroD4.getQuantidade();
                lRegistrosD4[iDxD4].Unidade = toByte(lRegistroD4.getUnidade(), 4);
                lRegistrosD4[iDxD4].ValorUnitario = lRegistroD4.getValorUnitario();
                lRegistrosD4[iDxD4].DescontoSobreItem = lRegistroD4.getDescontoSobreItem();
                lRegistrosD4[iDxD4].AcrescimoSobreItem = lRegistroD4.getAcrescimoSobreItem();
                lRegistrosD4[iDxD4].ValorTotalLiquido = lRegistroD4.getValorTotalLiquido();
                lRegistrosD4[iDxD4].SituacaoTributaria = toByte(lRegistroD4.getSituacaoTributaria(), 2);
                lRegistrosD4[iDxD4].Aliquota = lRegistroD4.getAliquota();
                lRegistrosD4[iDxD4].IndicadorCancelamento = toByte(lRegistroD4.getIndicadorCancelamento(), 2);
                lRegistrosD4[iDxD4].CasasDecimaisQtd = lRegistroD4.getCasasDecimaisQtd();
                lRegistrosD4[iDxD4].CasasDecimaisVlUn = lRegistroD4.getCasasDecimaisVlrUn();
                lRegistrosD4[iDxD4].TipoAlteracao = toByte(lRegistroD4.getTipoAlteracao(), 2);
                iDxD4++;
            }
            
            iDxD2++;
        }
        int ret = ACBrPAFInterop.INSTANCE.PAF_Preenche_D(getHandle(), lRegistroD1, 
                lRegistrosD2, paf_D.getRegistrosD2().size(), lRegistrosD3, lRegistrosD4, paf_D.countD4());
        checkResult(ret);
    }

    /**
     * Preenche os valores do PAF_E.
     * 
     * @throws ACBrException 
     */
    private void preenche_E() throws ACBrException {
        // Criando as variaveis para E1, E2 e E3.
        ACBrPAFInterop.RegistroHD2Rec lRegistroE1 = new ACBrPAFInterop.RegistroHD2Rec();
        ACBrPAFInterop.RegistroE2Rec[] lRegistrosE2 = criaVetorJNA(ACBrPAFInterop.RegistroE2Rec.class, paf_E.getRegistrosE2().size());
        ACBrPAFInterop.RegistroE3Rec lRegistroE3 = new ACBrPAFInterop.RegistroE3Rec();
        
        // Montando o registro E1. 
        lRegistroE1.RAZAOSOCIAL = toByte(paf_E.getRegistroE1().getRazaoSocial(), 51);
        lRegistroE1.UF = toByte(paf_E.getRegistroE1().getUf(), 3);
        lRegistroE1.CNPJ = toByte(paf_E.getRegistroE1().getCnpj(), 15);
        lRegistroE1.IE = toByte(paf_E.getRegistroE1().getInscEstadual(), 15);
        lRegistroE1.IM = toByte(paf_E.getRegistroE1().getInscMunicipal(), 15);
        lRegistroE1.NUM_FAB = toByte(paf_E.getRegistroE1().getNumFabricacao(), 21);
        lRegistroE1.MF_ADICIONAL = toByte(paf_E.getRegistroE1().getMfAdicional(), 2);
        lRegistroE1.TIPO_ECF = toByte(paf_E.getRegistroE1().getTipoEcf(), 8);
        lRegistroE1.MARCA_ECF = toByte(paf_E.getRegistroE1().getMarcaEcf(), 21);
        lRegistroE1.MODELO_ECF = toByte(paf_E.getRegistroE1().getModeloEcf(), 21);        
        lRegistroE1.DT_EST = OleDate.toOADate(paf_E.getRegistroE1().getDataEstoque());
        lRegistroE1.RegistroValido = paf_E.getRegistroE1().isRegistroValido();
        lRegistroE1.InclusaoExclusao = paf_E.getRegistroE1().isInclusaoExclusao();
                
        // Montando o registro E2.
        int i = 0;
        for (ACBrPAFRegistroE2 lRegistroE2 : paf_E.getRegistrosE2()) {
            lRegistrosE2[i].COD_MERC = toByte(lRegistroE2.getCodMercadoria(), 15);
            lRegistrosE2[i].DESC_MERC = toByte(lRegistroE2.getDescMercadoria(), 51);
            lRegistrosE2[i].UN_MED = toByte(lRegistroE2.getUnidadeMedida(), 7);
            lRegistrosE2[i].QTDE_EST = lRegistroE2.getQtdeEstoque();
            lRegistrosE2[i].RegistroValido = lRegistroE2.isRegistroValido();
            i++;
        }
        
        // Montando o registro E3.
        lRegistroE3.NumeroFabricacao = toByte(paf_E.getRegistroE3().getNumFabricacao(), 21);
        lRegistroE3.MFAdicional = toByte(paf_E.getRegistroE3().getMfAdicional(), 2);
        lRegistroE3.TipoECF = toByte(paf_E.getRegistroE3().getTipoEcf(), 8);
        lRegistroE3.MarcaECF = toByte(paf_E.getRegistroE3().getMarcaEcf(), 21);
        lRegistroE3.ModeloECF = toByte(paf_E.getRegistroE3().getModeloEcf(), 21);
        lRegistroE3.DataEstoque = OleDate.toOADate(paf_E.getRegistroE3().getDataEstoque());
        lRegistroE3.HoraEstoque = OleDate.toOADate(paf_E.getRegistroE3().getHoraEstoque());
        lRegistroE3.RegistroValido = paf_E.getRegistroE3().isRegistroValido();
         
        int ret = ACBrPAFInterop.INSTANCE.PAF_Preenche_E(getHandle(), lRegistroE1, 
                lRegistrosE2, lRegistroE3, paf_E.getRegistrosE2().size());
        checkResult(ret);
    } 
    
    /**
     * Preenche os valores do PAF_H.
     * 
     * @throws ACBrException 
     */
    private void preenche_H() throws ACBrException {
        // Criando as variaveis H1 e H3.
        ACBrPAFInterop.RegistroHD2Rec lRegistroH1 = new ACBrPAFInterop.RegistroHD2Rec();
        ACBrPAFInterop.RegistroH2Rec[] lRegistrosH2 = criaVetorJNA(ACBrPAFInterop.RegistroH2Rec.class, paf_H.getRegistrosH2().size());
        
        // Montando o registro H1. 
        lRegistroH1.RAZAOSOCIAL = toByte(paf_H.getRegistroH1().getRazaoSocial(), 51);
        lRegistroH1.UF = toByte(paf_H.getRegistroH1().getUf(), 3);
        lRegistroH1.CNPJ = toByte(paf_H.getRegistroH1().getCnpj(), 15);
        lRegistroH1.IE = toByte(paf_H.getRegistroH1().getInscEstadual(), 15);
        lRegistroH1.IM = toByte(paf_H.getRegistroH1().getInscMunicipal(), 15);
        lRegistroH1.NUM_FAB = toByte(paf_H.getRegistroH1().getNumFabricacao(), 21);
        lRegistroH1.MF_ADICIONAL = toByte(paf_H.getRegistroH1().getMfAdicional(), 2);
        lRegistroH1.TIPO_ECF = toByte(paf_H.getRegistroH1().getTipoEcf(), 8);
        lRegistroH1.MARCA_ECF = toByte(paf_H.getRegistroH1().getMarcaEcf(), 21);
        lRegistroH1.MODELO_ECF = toByte(paf_H.getRegistroH1().getModeloEcf(), 21);        
        lRegistroH1.DT_EST = OleDate.toOADate(paf_H.getRegistroH1().getDataEstoque());
        lRegistroH1.RegistroValido = paf_H.getRegistroH1().isRegistroValido();
        lRegistroH1.InclusaoExclusao = paf_H.getRegistroH1().isInclusaoExclusao();
                
        // Montando o registro H2.
        int i = 0;
        for (ACBrPAFRegistroH2 lRegistroH2 : paf_H.getRegistrosH2()) {
            lRegistrosH2[i].CNPJ_CRED_CARTAO = toByte(lRegistroH2.getCnpjCredenciadoraCartao(), 15);
            lRegistrosH2[i].COO = lRegistroH2.getCoo();
            lRegistrosH2[i].CCF = lRegistroH2.getCcf();
            lRegistrosH2[i].VLR_TROCO = lRegistroH2.getVlrTroco();
            lRegistrosH2[i].DT_TROCO = OleDate.toOADate(lRegistroH2.getDataTroco());
            lRegistrosH2[i].CPF = toByte(lRegistroH2.getCpfAdquirente(), 15);
            lRegistrosH2[i].Titulo = toByte(lRegistroH2.getNumTitulo(), 8);
            lRegistrosH2[i].RegistroValido = false;
            i++;
        }
        
        int ret = ACBrPAFInterop.INSTANCE.PAF_Preenche_H(getHandle(), lRegistroH1, 
                lRegistrosH2, paf_H.getRegistrosH2().size());
        checkResult(ret);
    }  
    
    /**
     * Preenche os valores do PAF_N.
     * 
     * @throws ACBrException 
     */
    private void preenche_N() throws ACBrException {
        // Criando as variaveis N1, N2 e N3.
        ACBrPAFInterop.RegistroHD1Rec lRegistroN1 = new ACBrPAFInterop.RegistroHD1Rec();
        ACBrPAFInterop.RegistroN2Rec lRegistroN2 = new ACBrPAFInterop.RegistroN2Rec();
        ACBrPAFInterop.RegistroN3Rec[] lRegistrosN3 = criaVetorJNA(ACBrPAFInterop.RegistroN3Rec.class, paf_N.getRegistrosN3().size());
        
        // Montando o registro N1.
        lRegistroN1.RAZAOSOCIAL = toByte(paf_N.getRegistroN1().getRazaoSocial(), 51);
        lRegistroN1.UF = toByte(paf_N.getRegistroN1().getUf(), 3);
        lRegistroN1.CNPJ = toByte(paf_N.getRegistroN1().getCnpj(), 15);
        lRegistroN1.IE = toByte(paf_N.getRegistroN1().getInscEstadual(), 15);
        lRegistroN1.IM = toByte(paf_N.getRegistroN1().getInscMunicipal(), 15);
        
        // Montando o registro N2.
        lRegistroN2.LAUDO = toByte(paf_N.getRegistroN2().getLaudo(), 11);
        lRegistroN2.NOME = toByte(paf_N.getRegistroN2().getNome(), 51);
        lRegistroN2.VERSAO = toByte(paf_N.getRegistroN2().getVersao(), 11);
        
        // Montando o registro N3.
        int i = 0;
        for (ACBrPAFRegistroN3 lRegistro : paf_N.getRegistrosN3()) {
            lRegistrosN3[i].NOME_ARQUIVO = toByte(lRegistro.getNomeArquivo(), 51);
            lRegistrosN3[i].MD5 = toByte(lRegistro.getMd5(), 33);
            i++;
        }
        
        int ret = ACBrPAFInterop.INSTANCE.PAF_Preenche_N(getHandle(), 
                lRegistroN1, lRegistroN2, lRegistrosN3, paf_N.getRegistrosN3().size());
        checkResult(ret);
    }  
    
    /**
     * Preenche os valores do PAF_P.
     * 
     * @throws ACBrException 
     */
    private void preenche_P() throws ACBrException {
        // Criando as variaveis P1 e P2.
        ACBrPAFInterop.RegistroHD1Rec lRegistroP1 = new ACBrPAFInterop.RegistroHD1Rec();
        ACBrPAFInterop.RegistroP2Rec[] lRegistrosP2 = criaVetorJNA(ACBrPAFInterop.RegistroP2Rec.class, paf_P.getRegistrosP2().size());
        
        // Montando o registro P1.
        lRegistroP1.RAZAOSOCIAL = toByte(paf_P.getRegistroP1().getRazaoSocial(), 51);
        lRegistroP1.UF = toByte(paf_P.getRegistroP1().getUf(), 3);
        lRegistroP1.CNPJ = toByte(paf_P.getRegistroP1().getCnpj(), 15);
        lRegistroP1.IE = toByte(paf_P.getRegistroP1().getInscEstadual(), 15);
        lRegistroP1.IM = toByte(paf_P.getRegistroP1().getInscMunicipal(), 15);
        
        // Montando o registro P2.
        int i = 0;
        for (ACBrPAFRegistroP2 lRegistro : paf_P.getRegistrosP2()) {
            lRegistrosP2[i].COD_MERC_SERV = toByte(lRegistro.getCodMercadoriaServico(), 15);
            lRegistrosP2[i].DESC_MERC_SERV = toByte(lRegistro.getDescMercadoriaServico(), 51);
            lRegistrosP2[i].UN_MED = toByte(lRegistro.getUnidadeMedida(), 7);
            lRegistrosP2[i].IAT = toByte(lRegistro.getIat(), 2);
            lRegistrosP2[i].IPPT = toByte(lRegistro.getIppt(), 2);
            lRegistrosP2[i].ST = toByte(lRegistro.getSt(), 2);
            lRegistrosP2[i].ALIQ = lRegistro.getAliquota();
            lRegistrosP2[i].VL_UNIT = lRegistro.getValorUnitario();
            lRegistrosP2[i].RegistroValido = lRegistro.isRegistroValido();
            i++;
        }
        
        int ret = ACBrPAFInterop.INSTANCE.PAF_Preenche_P(getHandle(), 
                lRegistroP1, lRegistrosP2, paf_P.getRegistrosP2().size());
        checkResult(ret);
    }    
    
    private void preenche_R() throws ACBrException {
        int itemR1 = 0, itemR2 = 0, itemR3 = 0, itemR4 = 0, itemR5 = 0, itemR6 = 0, 
            itemR7 = 0, qtde2 = 0, qtde3 = 0, qtde4 = 0, qtde5 = 0, qtde6 = 0, qtde7 = 0;

        // Definindo o tamanho dos vetores de dados.
        for (ACBrPAFRegistroR1 r1 : paf_R.getRegistrosR1()) {
            qtde2 += r1.getRegistrosR2().size();
            for (ACBrPAFRegistroR2 r2 : r1.getRegistrosR2()) {
                qtde3 += r2.getRegistrosR3().size();
            }

            qtde4 += r1.getRegistrosR4().size();
            for (ACBrPAFRegistroR4 r4 : r1.getRegistrosR4()) {
                qtde5 += r4.getRegistrosR5().size();
                qtde7 += r4.getRegistrosR7().size();
            }

            qtde6 += r1.getRegistrosR6().size();
            for (ACBrPAFRegistroR6 r6 : r1.getRegistrosR6()){
                qtde7 += r6.getRegistrosR7().size();
            }
        }   
        
        // Criando as variaveis para os registros R1, R2, R3, R4, R5, R6 e R7.
        ACBrPAFInterop.RegistroR1Rec[] registrosR1 = criaVetorJNA(ACBrPAFInterop.RegistroR1Rec.class, paf_R.getRegistrosR1().size());
        ACBrPAFInterop.RegistroR2Rec[] registrosR2 = criaVetorJNA(ACBrPAFInterop.RegistroR2Rec.class, qtde2);
        ACBrPAFInterop.RegistroR3Rec[] registrosR3 = criaVetorJNA(ACBrPAFInterop.RegistroR3Rec.class, qtde3);
        ACBrPAFInterop.RegistroR4Rec[] registrosR4 = criaVetorJNA(ACBrPAFInterop.RegistroR4Rec.class, qtde4);
        ACBrPAFInterop.RegistroR5Rec[] registrosR5 = criaVetorJNA(ACBrPAFInterop.RegistroR5Rec.class, qtde5);
        ACBrPAFInterop.RegistroR6Rec[] registrosR6 = criaVetorJNA(ACBrPAFInterop.RegistroR6Rec.class, qtde6);
        ACBrPAFInterop.RegistroR7Rec[] registrosR7 = criaVetorJNA(ACBrPAFInterop.RegistroR7Rec.class, qtde7);            
        
        for (ACBrPAFRegistroR1 r1 : paf_R.getRegistrosR1()) {
            // Montando o registro R1.
            registrosR1[itemR1].QTD_R2 = r1.getRegistrosR2().size();
            registrosR1[itemR1].QTD_R4 = r1.getRegistrosR4().size();
            registrosR1[itemR1].QTD_R6 = r1.getRegistrosR6().size();
            registrosR1[itemR1].NUM_FAB = toByte(r1.getNumFabricacao(), 21);
            registrosR1[itemR1].MF_ADICIONAL = toByte(r1.getMfAdicional(), 2);
            registrosR1[itemR1].TIPO_ECF = toByte(r1.getTipoEcf(), 8);
            registrosR1[itemR1].MARCA_ECF = toByte(r1.getMarcaEcf(), 21);
            registrosR1[itemR1].MODELO_ECF = toByte(r1.getModeloEcf(), 21);
            registrosR1[itemR1].VERSAO_SB = toByte(r1.getVersaoSb(), 11);
            registrosR1[itemR1].DT_INST_SB = OleDate.toOADate(r1.getDtInstalacaoSb());
            registrosR1[itemR1].HR_INST_SB = OleDate.toOADate(r1.getHoraInstalacaoSb());
            registrosR1[itemR1].NUM_SEQ_ECF = r1.getNumSeqEcf();
            registrosR1[itemR1].CNPJ = toByte(r1.getCnpj(), 15);
            registrosR1[itemR1].IE = toByte(r1.getInscEstadual(), 15);
            registrosR1[itemR1].CNPJ_SH = toByte(r1.getCnpjSh(), 15);
            registrosR1[itemR1].IE_SH = toByte(r1.getInscEstadualSh(), 15);
            registrosR1[itemR1].IM_SH = toByte(r1.getInscMunicipalSh(), 15);
            registrosR1[itemR1].NOME_SH = toByte(r1.getNomeSh(), 41);
            registrosR1[itemR1].NOME_PAF = toByte(r1.getNomePaf(), 41);
            registrosR1[itemR1].VER_PAF = toByte(r1.getVersaoPaf(), 11);
            registrosR1[itemR1].COD_MD5 = toByte(r1.getCodigoMd5(), 33);
            registrosR1[itemR1].DT_INI = OleDate.toOADate(r1.getDataInicial());
            registrosR1[itemR1].DT_FIN = OleDate.toOADate(r1.getDataFim());
            registrosR1[itemR1].ER_PAF_ECF = toByte(r1.getVersaoRequisitosPaf(), 5);
            registrosR1[itemR1].InclusaoExclusao = r1.isInclusaoExclusao();
            registrosR1[itemR1].RegistroValido = r1.isRegistroValido();

            // Montando o registro R2 e R3.
            for (ACBrPAFRegistroR2 r2 : r1.getRegistrosR2()) {
                // Montando o registro R2.
                registrosR2[itemR2].QTD_R3 = r2.getRegistrosR3().size();
                registrosR2[itemR2].NUM_USU = r2.getNumeroUsuario();
                registrosR2[itemR2].CRZ = r2.getCrz();
                registrosR2[itemR2].COO = r2.getCoo();
                registrosR2[itemR2].CRO = r2.getCro();
                registrosR2[itemR2].DT_MOV = OleDate.toOADate(r2.getDataMovimento());
                registrosR2[itemR2].DT_EMI = OleDate.toOADate(r2.getDataEmissao());
                registrosR2[itemR2].HR_EMI = OleDate.toOADate(r2.getHoraEmissao());
                registrosR2[itemR2].VL_VBD = r2.getVendaBrutaDiaria();
                registrosR2[itemR2].PAR_ECF = toByte(r2.getParametroEcf(), 2);
                registrosR2[itemR2].RegistroValido = r2.isRegistroValido();

                // Montando o registro R3.
                for (ACBrPAFRegistroR3 r3 : r2.getRegistrosR3()) {
                    registrosR3[itemR3].TOT_PARCIAL = toByte(r3.getCodTotalzadorParcial(), 8);
                    registrosR3[itemR3].VL_ACUM = r3.getValorAcumulado();
                    registrosR3[itemR3].RegistroValido = r3.isRegistroValido();
                    itemR3++;
                }
                itemR2++;
            }

            // Montando o registro R4, R5 e R7.
            for (ACBrPAFRegistroR4 r4 : r1.getRegistrosR4()) {
                // Montando o registro R4.
                registrosR4[itemR4].QTD_R5 = r4.getRegistrosR5().size();
                registrosR4[itemR4].QTD_R7 = r4.getRegistrosR7().size();
                registrosR4[itemR4].NUM_USU = r4.getNumeroUsuario();
                registrosR4[itemR4].NUM_CONT = r4.getNumContador();
                registrosR4[itemR4].COO = r4.getCoo();
                registrosR4[itemR4].DT_INI = OleDate.toOADate(r4.getDataInicioEmissao());
                registrosR4[itemR4].SUB_DOCTO = r4.getSubTotalDocumento();
                registrosR4[itemR4].SUB_DESCTO = r4.getDescontoSobreSubtotal();
                registrosR4[itemR4].TP_DESCTO = toByte(r4.getTipoDesconto(), 2);
                registrosR4[itemR4].SUB_ACRES = r4.getAcrescimoSobreSubtotal();
                registrosR4[itemR4].TP_ACRES = toByte(r4.getTipoAcrescimo(), 2);
                registrosR4[itemR4].VL_TOT = r4.getValorTotalLiquido();
                registrosR4[itemR4].CANC = toByte(r4.getIndCancelamento(), 2);
                registrosR4[itemR4].VL_CA = r4.getValorCancelamento();
                registrosR4[itemR4].ORDEM_DA = toByte(r4.getOrdemAplicacaoDescAcres(), 2);
                registrosR4[itemR4].NOME_CLI = toByte(r4.getNomeCliente(), 41);
                registrosR4[itemR4].CNPJ_CPF = toByte(r4.getCnpjCpf(), 15);
                registrosR4[itemR4].RegistroValido = r4.isRegistroValido();

                // Montando o registro R5.
                for (ACBrPAFRegistroR5 r5 : r4.getRegistrosR5()) {
                    registrosR5[itemR5].NUM_CONT = r5.getNumContador();
                    registrosR5[itemR5].NUM_ITEM = r5.getNumItem();
                    registrosR5[itemR5].COD_ITEM = toByte(r5.getCodItem(), 15);
                    registrosR5[itemR5].DESC_ITEM = toByte(r5.getDescricaoItem(), 101);
                    registrosR5[itemR5].QTDE_ITEM = r5.getQtdeItem();
                    registrosR5[itemR5].UN_MED = toByte(r5.getUnidadeMedida(), 4);
                    registrosR5[itemR5].VL_UNIT = r5.getValorUnitario();
                    registrosR5[itemR5].DESCTO_ITEM = r5.getDescontoItem();
                    registrosR5[itemR5].ACRES_ITEM = r5.getAcrescimoItem();
                    registrosR5[itemR5].VL_TOT_ITEM = r5.getValorTotalLiquidoItem();
                    registrosR5[itemR5].COD_TOT_PARC = toByte(r5.getCodTotalizadorParcial(), 8);
                    registrosR5[itemR5].IND_CANC = toByte(r5.getIndCancelamento(), 2);
                    registrosR5[itemR5].QTDE_CANC = r5.getQtdeCancelada();
                    registrosR5[itemR5].VL_CANC = r5.getValorCancelamento();
                    registrosR5[itemR5].VL_CANC_ACRES = r5.getValorCancelamentoAcresc();
                    registrosR5[itemR5].IAT = toByte(r5.getIat(), 2);
                    registrosR5[itemR5].IPPT = toByte(r5.getIppt(), 2);
                    registrosR5[itemR5].QTDE_DECIMAL = r5.getNumCasasDecimaisEmQtde();
                    registrosR5[itemR5].VL_DECIMAL = r5.getNumCasasDecimaisEmValor();
                    registrosR5[itemR5].RegistroValido = r5.isRegistroValido();
                    itemR5++;
                }

                // Montando o registro R7.
                for (ACBrPAFRegistroR7 r7 : r4.getRegistrosR7()) {
                    registrosR7[itemR7].CCF = r7.getCcf();
                    registrosR7[itemR7].GNF = r7.getGnf();
                    registrosR7[itemR7].MP = toByte(r7.getMeioPagamento(), 16);
                    registrosR7[itemR7].VL_PAGTO = r7.getValorPago();
                    registrosR7[itemR7].IND_EST = toByte(r7.getIndEstorno(), 2);
                    registrosR7[itemR7].VL_EST = r7.getValorEstorno();
                    registrosR7[itemR7].RegistroValido = r7.isRegistroValido();
                    itemR7++;
                }

                itemR4++;
            }

            // Montando o registro R6 e R7.
            for (ACBrPAFRegistroR6 r6 : r1.getRegistrosR6()) {
                // Montando o registro R6.
                registrosR6[itemR6].QTD_R7 = r6.getRegistrosR7().size();
                registrosR6[itemR6].NUM_USU = r6.getNumeroUsuario();
                registrosR6[itemR6].COO = r6.getCoo();
                registrosR6[itemR6].GNF = r6.getGnf();
                registrosR6[itemR6].GRG = r6.getGrg();
                registrosR6[itemR6].CDC = r6.getCdc();
                registrosR6[itemR6].DENOM = toByte(r6.getDenominacao(), 3);
                registrosR6[itemR6].DT_FIN = OleDate.toOADate(r6.getDataFinalEmissao());
                registrosR6[itemR6].HR_FIN = OleDate.toOADate(r6.getHoraFinalEmissao());
                registrosR6[itemR6].RegistroValido = r6.isRegistroValido();

                // Montando o registro R7.
                for (ACBrPAFRegistroR7 r7 : r6.getRegistrosR7()) {
                    registrosR7[itemR7].CCF = r7.getCcf();
                    registrosR7[itemR7].GNF = r7.getGnf();
                    registrosR7[itemR7].MP = toByte(r7.getMeioPagamento(), 16);
                    registrosR7[itemR7].VL_PAGTO = r7.getValorPago();
                    registrosR7[itemR7].IND_EST = toByte(r7.getIndEstorno(), 2);
                    registrosR7[itemR7].VL_EST = r7.getValorEstorno();
                    registrosR7[itemR7].RegistroValido = r7.isRegistroValido();
                    itemR7++;
                }
                itemR6++;
            }
            itemR1++;
        }

        int ret = ACBrPAFInterop.INSTANCE.PAF_Preenche_R(getHandle(), paf_R.getRegistrosR1().size(),
                registrosR1, registrosR2, registrosR3, registrosR4, registrosR5,
                registrosR6, registrosR7);
        checkResult(ret);
    }        
    
    /**
     * Preenche os valores do PAF_T.
     * 
     * @throws ACBrException 
     */
    private void preenche_T() throws ACBrException {
        // Criando as variaveis para T1 e T2.
        ACBrPAFInterop.RegistroHD1Rec lRegistroT1 = new ACBrPAFInterop.RegistroHD1Rec();
        ACBrPAFInterop.RegistroT2Rec[] lRegistrosT2 = criaVetorJNA(ACBrPAFInterop.RegistroT2Rec.class, paf_T.getRegistrosT2().size());
        
        // Montando o registro T1.  
        lRegistroT1.RAZAOSOCIAL = toByte(paf_T.getRegistroT1().getRazaoSocial(), 51);
        lRegistroT1.UF = toByte(paf_T.getRegistroT1().getUf(), 3);
        lRegistroT1.CNPJ = toByte(paf_T.getRegistroT1().getCnpj(), 15);
        lRegistroT1.IE = toByte(paf_T.getRegistroT1().getInscEstadual(), 15);
        lRegistroT1.IM = toByte(paf_T.getRegistroT1().getInscMunicipal(), 15);
        
        // Montando o registro T2.  
        int i = 0;
        for (ACBrPAFRegistroT2 lRegistro : paf_T.getRegistrosT2()) {
            lRegistrosT2[i].DT_MOV = OleDate.toOADate(lRegistro.getDataMovimento());
            lRegistrosT2[i].TP_DOCTO = toByte(lRegistro.getTipoDocumento(), 11);
            lRegistrosT2[i].SERIE = toByte(lRegistro.getSerie(), 3);
            lRegistrosT2[i].NUM_BILH_I = lRegistro.getNumeroBilheteInicial();
            lRegistrosT2[i].NUM_BILH_F = lRegistro.getNumeroBilheteFinal();
            lRegistrosT2[i].NUM_ECF = toByte(lRegistro.getNumEcf(), 21);
            lRegistrosT2[i].CRZ = lRegistro.getCrz();
            lRegistrosT2[i].CFOP = toByte(lRegistro.getCfop(), 5);
            lRegistrosT2[i].VL_CONT = lRegistro.getValorContabil();
            lRegistrosT2[i].VL_BASECALC = lRegistro.getValorBaseCalculo();
            lRegistrosT2[i].ALIQ = lRegistro.getAliquota();
            lRegistrosT2[i].VL_IMPOSTO = lRegistro.getValorImposto();
            lRegistrosT2[i].VL_ISENTAS = lRegistro.getValorIsentas();
            lRegistrosT2[i].VL_OUTRAS = lRegistro.getValorOutras();
            lRegistrosT2[i].RegistroValido = lRegistro.isRegistroValido();
            i++;
        }
        int ret = ACBrPAFInterop.INSTANCE.PAF_Preenche_T(getHandle(), lRegistroT1, 
                lRegistrosT2, paf_T.getRegistrosT2().size());
        checkResult(ret);
    }   
    
    /**
     * Preenche os valores do PAF_TITP.
     * 
     * @throws ACBrException 
     */
    private void preenche_TITP() throws ACBrException {
        // Criando as variaveis para Mercadorias e insumos.
        ACBrPAFInterop.RegistroMercadoriasRec[] mercadorias = criaVetorJNA(ACBrPAFInterop.RegistroMercadoriasRec.class, paf_TITP.getMercadorias().size());
        ACBrPAFInterop.RegistroInsumosRec[] insumos = criaVetorJNA(ACBrPAFInterop.RegistroInsumosRec.class, paf_TITP.countInsumos());
        
        // Montando o registro de Mercadorias.  
        int i = 0, iDxInsumo = 0;        
        for (ACBrPAFRegistroMercadoria lRegistro : paf_TITP.getMercadorias()) {
            mercadorias[i].Descricao = toByte(lRegistro.getDescricao(), 101);
            mercadorias[i].Codigo = toByte(lRegistro.getCodigo(), 15);
            mercadorias[i].Aliquota = lRegistro.getAliquota();
            mercadorias[i].Unidade = toByte(lRegistro.getUnidade(), 4);
            mercadorias[i].Quantidade = lRegistro.getQuantidade();
            mercadorias[i].Ean = toByte(lRegistro.getEan(), 14);
            mercadorias[i].CST = toByte(lRegistro.getCst(), 4);
            mercadorias[i].VlrUnitario = lRegistro.getVlrUnitario();
            mercadorias[i].QTD_Insumos = lRegistro.getInsumos().size();
            
            // Montando o registro de insumos.  
            for (ACBrPAFRegistroInsumo lInsumo : lRegistro.getInsumos()) {
                insumos[iDxInsumo].Descricao = toByte(lInsumo.getDescricao(), 101);
                insumos[iDxInsumo].Codigo = toByte(lInsumo.getCodigo(), 15);
                insumos[iDxInsumo].Aliquota = lInsumo.getAliquota();
                insumos[iDxInsumo].Unidade = toByte(lInsumo.getUnidade(), 4);
                insumos[iDxInsumo].Quantidade = lInsumo.getQuantidade();
                insumos[iDxInsumo].Ean = toByte(lInsumo.getEan(), 14);
                insumos[iDxInsumo].CST = toByte(lInsumo.getCst(), 4);
                insumos[iDxInsumo].VlrUnitario = lInsumo.getVlrUnitario();
                iDxInsumo++;
            }            
            i++;
        }
        int ret = ACBrPAFInterop.INSTANCE.PAF_Preenche_TITP(getHandle(), mercadorias, 
                paf_TITP.getMercadorias().size(), insumos, toUTF8(paf_TITP.getTitulo()), OleDate.toOADate(paf_TITP.getData()));
        checkResult(ret);
    }    
    
    /**
     * Preenche os valores do PAF_U.
     * 
     * @throws ACBrException 
     */
    private void preenche_U() throws ACBrException {
        // Criando as variaveis para U1.
        ACBrPAFInterop.RegistroHD1Rec lRegistroU = new ACBrPAFInterop.RegistroHD1Rec();
        
        // Montando o registro U1.  
        lRegistroU.RAZAOSOCIAL = toByte(paf_U.getRegistroU1().getRazaoSocial(), 51);
        lRegistroU.UF = toByte(paf_U.getRegistroU1().getUf(), 3);
        lRegistroU.CNPJ = toByte(paf_U.getRegistroU1().getCnpj(), 15);
        lRegistroU.IE = toByte(paf_U.getRegistroU1().getInscEstadual(), 15);
        lRegistroU.IM = toByte(paf_U.getRegistroU1().getInscMunicipal(), 15);        
        
        int ret = ACBrPAFInterop.INSTANCE.PAF_Preenche_U(getHandle(), lRegistroU);
        checkResult(ret);
    }      
    
    /**
     * Salva os arquivos do registro B em arquivo.
     * 
     * @param pArquivo arquivo de saida. 
     * @return status da operacao.
     * @throws ACBrException 
     */
    public boolean saveFileTXT_B(String pArquivo) throws ACBrException {
        preenche_B();
        int ret = ACBrPAFInterop.INSTANCE.PAF_SaveFileTXT_B(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
        paf_B.limparRegistros();
        return ret != 0;
    }

    /**
     * Salva os arquivos do registro C em arquivo.
     * 
     * @param pArquivo arquivo de saida. 
     * @return status da operacao.
     * @throws ACBrException 
     */
    public boolean saveFileTXT_C(String pArquivo) throws ACBrException {
        preenche_C();
        int ret = ACBrPAFInterop.INSTANCE.PAF_SaveFileTXT_C(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
        paf_C.limparRegistros();
        return ret != 0;
    }   
    
    /**
     * Salva os arquivos do registro D em arquivo.
     * 
     * @param pArquivo arquivo de saida. 
     * @return status da operacao.
     * @throws ACBrException 
     */
    public boolean saveFileTXT_D(String pArquivo) throws ACBrException {
        preenche_D();
        int ret = ACBrPAFInterop.INSTANCE.PAF_SaveFileTXT_D(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
        paf_D.limparRegistros();
        return ret != 0;
    }    
    
    /**
     * Salva os arquivos do registro E em arquivo.
     * 
     * @param pArquivo arquivo de saida. 
     * @return status da operacao.
     * @throws ACBrException 
     */
    public boolean saveFileTXT_E(String pArquivo) throws ACBrException {
        preenche_E();
        int ret = ACBrPAFInterop.INSTANCE.PAF_SaveFileTXT_E(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
        paf_E.limparRegistros();
        return ret != 0;
    }      
    
    /**
     * Salva os arquivos do registro H em arquivo.
     * 
     * @param pArquivo arquivo de saida. 
     * @return status da operacao.
     * @throws ACBrException 
     */
    public boolean saveFileTXT_H(String pArquivo) throws ACBrException {
        preenche_H();
        int ret = ACBrPAFInterop.INSTANCE.PAF_SaveFileTXT_H(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
        paf_H.limparRegistros();
        return ret != 0;
    }      
        
    /**
     * Salva os arquivos do registro N em arquivo.
     * 
     * @param pArquivo arquivo de saida. 
     * @return status da operacao.
     * @throws ACBrException 
     */
    public boolean saveFileTXT_N(String pArquivo) throws ACBrException {
        preenche_N();
        int ret = ACBrPAFInterop.INSTANCE.PAF_SaveFileTXT_N(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
        paf_N.limparRegistros();
        return ret != 0;
    }     
    
    /**
     * Salva os arquivos do registro P em arquivo.
     * 
     * @param pArquivo arquivo de saida. 
     * @return status da operacao.
     * @throws ACBrException 
     */
    public boolean saveFileTXT_P(String pArquivo) throws ACBrException {
        preenche_P();
        int ret = ACBrPAFInterop.INSTANCE.PAF_SaveFileTXT_P(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
        paf_P.limparRegistros();
        return ret != 0;
    }     
    
    /**
     * Salva os arquivos do registro R em arquivo.
     * 
     * @param pArquivo arquivo de saida. 
     * @return status da operacao.
     * @throws ACBrException 
     */
    public boolean saveFileTXT_R(String pArquivo) throws ACBrException {
        preenche_R();
        int ret = ACBrPAFInterop.INSTANCE.PAF_SaveFileTXT_R(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
        paf_R.limparRegistros();
        return ret != 0;
    }      
    
    /**
     * Salva os arquivos do registro T em arquivo.
     * 
     * @param pArquivo arquivo de saida. 
     * @return status da operacao.
     * @throws ACBrException 
     */
    public boolean saveFileTXT_T(String pArquivo) throws ACBrException {
        preenche_T();
        int ret = ACBrPAFInterop.INSTANCE.PAF_SaveFileTXT_T(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
        paf_T.limparRegistros();
        return ret != 0;
    }     

    /**
     * Salva os arquivos do registro TITP em arquivo.
     * 
     * @param pArquivo arquivo de saida. 
     * @return status da operacao.
     * @throws ACBrException 
     */
    public boolean saveFileTXT_TITP(String pArquivo) throws ACBrException {
        preenche_TITP();
        int ret = ACBrPAFInterop.INSTANCE.PAF_SaveFileTXT_TITP(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
        paf_TITP.limparRegistros();
        return ret != 0;
    }    
    
    /**
     * Salva os arquivos do registro PAF em arquivo.
     * 
     * @param pArquivo arquivo de saida. 
     * @return status da operacao.
     * @throws ACBrException 
     */
    public boolean saveFileTXT_RegistrosECF(String pArquivo) throws ACBrException {
        preenche_A();
        preenche_D();
        preenche_E();                    
        preenche_P();
        preenche_R();
        preenche_U();
        int ret = ACBrPAFInterop.INSTANCE.PAF_SaveFileTXT_RegistrosPAF(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
        limparRegistros();
        return ret != 0;
    }    
    // </editor-fold>
	//<editor-fold defaultstate="collapsed" desc="onPAFGetKeyRSA">
    /**
     * Adiciona o listener para setar a chave.
     * @param pListener 
     */
	public void addOnPAFGetKeyRSA(ACBrEventListener<PAFGetKeyRSAEventObject> pListener) {
		if (!hasListeners("onPAFGetKeyRSA")) {
			ACBrPAFInterop.INSTANCE.PAF_SetOnPAFGetKeyRSA(getHandle(), new ACBrPAFInterop.PAFGetKeyRSACallback() {

                @Override
                public String invoke() {
                    return onPAFGetKeyRSA();
                }
			});
		}
		addListener("onPAFGetKeyRSA", pListener);
	}

    /**
     * Remove o listener associado.
     * @param pListener 
     */
	public void removeOnPAFGetKeyRSA(ACBrEventListener<PAFGetKeyRSAEventObject> pListener) {
		removeListener("onPAFGetKeyRSA", pListener);

		if (!hasListeners("onPAFGetKeyRSA")) {
			ACBrPAFInterop.INSTANCE.PAF_SetOnPAFGetKeyRSA(getHandle(), null);
		}
	}

    /**
     * Obtem o valor da chave.
     * @return 
     */
	private String onPAFGetKeyRSA() {
		PAFGetKeyRSAEventObject e = new PAFGetKeyRSAEventObject(this, "");
		notifyListeners("onPAFGetKeyRSA", e);
		return e.getKey();
	}
	//</editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Limpa os registros.
     */
    private void limparRegistros() {
        paf_A.limparRegistros();
        paf_B.limparRegistros();
        paf_C.limparRegistros();
        paf_D.limparRegistros();
        paf_E.limparRegistros();
        paf_N.limparRegistros();
        paf_P.limparRegistros();
        paf_R.limparRegistros();
        paf_T.limparRegistros();
        paf_U.limparRegistros();
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Getters - Setters">
    /**
     * Instancia AAC.
     * @return the aac
     */
    public ACBrAAC getAac() {
        return aac;
    }

    /**
     * Instancia EAD.
     * @return the ead
     */
    public ACBrEAD getEad() {
        return ead;
    }

    /**
     * Registros {@see ACBrPAF_A}.
     * @return the paf_A
     */
    public ACBrPAF_A getPaf_A() {
        return paf_A;
    }

    /**
     * Registros {@see ACBrPAF_B}.
     * @return the paf_B
     */
    public ACBrPAF_B getPaf_B() {
        return paf_B;
    }

    /**
     * Registros {@see ACBrPAF_C}.
     * @return the paf_C
     */
    public ACBrPAF_C getPaf_C() {
        return paf_C;
    }

    /**
     * Registros {@see ACBrPAF_D}.
     * @return the paf_D
     */
    public ACBrPAF_D getPaf_D() {
        return paf_D;
    }

    /**
     * Registros {@see ACBrPAF_E}.
     * @return the paf_E
     */
    public ACBrPAF_E getPaf_E() {
        return paf_E;
    }

    /**
     * Registros {@see ACBrPAF_H}.
     * @return the paf_H
     */
    public ACBrPAF_H getPaf_H() {
        return paf_H;
    }

    /**
     * Registros {@see ACBrPAF_N}.
     * @return the paf_N
     */
    public ACBrPAF_N getPaf_N() {
        return paf_N;
    }

    /**
     * Registros {@see ACBrPAF_P}.
     * @return the paf_P
     */
    public ACBrPAF_P getPaf_P() {
        return paf_P;
    }

    /**
     * Registros {@see ACBrPAF_R}.
     * @return the paf_R
     */
    public ACBrPAF_R getPaf_R() {
        return paf_R;
    }

    /**
     * Registros {@see ACBrPAF_T}.
     * @return the paf_T
     */
    public ACBrPAF_T getPaf_T() {
        return paf_T;
    }

    /**
     * Registros {@see ACBrPAF_U}.
     * @return the paf_U
     */
    public ACBrPAF_U getPaf_U() {
        return paf_U;
    }

    /**
     * Registros {@see ACBrPAF_TITP}.
     * @return the paf_TITP
     */
    public ACBrPAF_TITP getPaf_TITP() {
        return paf_TITP;
    }
    // </editor-fold>
    
}