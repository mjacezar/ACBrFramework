package jACBrFramework.sintegra;

import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrClass;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrSintegraInterop;
import java.nio.ByteBuffer;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Classe para comunicacao e geracao do sintegra.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 13:35:31, revisao: $Id$
 */
public final class ACBrSintegra extends ACBrClass {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * @see SintegraRegistro10
     */
    private SintegraRegistro10 registro10 = new SintegraRegistro10();
    /**
     * @see SintegraRegistro11
     */
    private SintegraRegistro11 registro11 = new SintegraRegistro11();
    /**
     * @see SintegraRegistro50
     */
    private Collection<SintegraRegistro50> registros50 = new ArrayList<SintegraRegistro50>();
    /**
     * @see SintegraRegistro51
     */
    private Collection<SintegraRegistro51> registros51 = new ArrayList<SintegraRegistro51>();
    /**
     * @see SintegraRegistro53
     */
    private Collection<SintegraRegistro53> registros53 = new ArrayList<SintegraRegistro53>();
    /**
     * @see SintegraRegistro54
     */
    private Collection<SintegraRegistro54> registros54 = new ArrayList<SintegraRegistro54>();
    /**
     * @see SintegraRegistro55
     */
    private Collection<SintegraRegistro55> registros55 = new ArrayList<SintegraRegistro55>();
    /**
     * @see SintegraRegistro56
     */
    private Collection<SintegraRegistro56> registros56 = new ArrayList<SintegraRegistro56>();
    /**
     * @see SintegraRegistro60A
     */
    private Collection<SintegraRegistro60A> registros60A = new ArrayList<SintegraRegistro60A>();
    /**
     * @see SintegraRegistro60D
     */
    private Collection<SintegraRegistro60D> registros60D = new ArrayList<SintegraRegistro60D>();
    /**
     * @see SintegraRegistro60I
     */
    private Collection<SintegraRegistro60I> registros60I = new ArrayList<SintegraRegistro60I>();
    /**
     * @see SintegraRegistro60M
     */
    private Collection<SintegraRegistro60M> registros60M = new ArrayList<SintegraRegistro60M>();
    /**
     * @see SintegraRegistro60R
     */
    private Collection<SintegraRegistro60R> registros60R = new ArrayList<SintegraRegistro60R>();
    /**
     * @see SintegraRegistro61
     */
    private Collection<SintegraRegistro61> registros61 = new ArrayList<SintegraRegistro61>();
    /**
     * @see SintegraRegistro61R
     */
    private Collection<SintegraRegistro61R> registros61R = new ArrayList<SintegraRegistro61R>();
    /**
     * @see SintegraRegistro70
     */
    private Collection<SintegraRegistro70> registros70 = new ArrayList<SintegraRegistro70>();
    /**
     * @see SintegraRegistro71
     */
    private Collection<SintegraRegistro71> registros71 = new ArrayList<SintegraRegistro71>();
    /**
     * @see SintegraRegistro74
     */
    private Collection<SintegraRegistro74> registros74 = new ArrayList<SintegraRegistro74>();
    /**
     * @see SintegraRegistro75
     */
    private Collection<SintegraRegistro75> registros75 = new ArrayList<SintegraRegistro75>();
    /**
     * @see SintegraRegistro76
     */
    private Collection<SintegraRegistro76> registros76 = new ArrayList<SintegraRegistro76>();
    /**
     * @see SintegraRegistro77
     */
    private Collection<SintegraRegistro77> registros77 = new ArrayList<SintegraRegistro77>();
    /**
     * @see SintegraRegistro85
     */
    private Collection<SintegraRegistro85> registros85 = new ArrayList<SintegraRegistro85>();
    /**
     * @see SintegraRegistro86
     */
    private Collection<SintegraRegistro86> registros86 = new ArrayList<SintegraRegistro86>();
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Construtor padrao.
     *
     * @throws ACBrException excecao acionada ao construir o objeto.
     */
    public ACBrSintegra() throws ACBrException {
    }
    /**
     * Cria um novo objeto com base no charset recebido.
     * 
     * @param pCharset charset utilizado na conversao para geracao do sintegra.
     */
    public ACBrSintegra(Charset pCharset) throws ACBrException {
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
        int ret = ACBrSintegraInterop.INSTANCE.SIN_Create(handle);
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
            int ret = ACBrSintegraInterop.INSTANCE.SIN_Destroy(getHandle());
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
                int ret = ACBrSintegraInterop.INSTANCE.SIN_GetUltimoErro(getHandle(), buffer, LEN);

                lMessage = fromUTF8(buffer, ret);
                throw new ACBrException(lMessage);
            }
            case -2: {
                throw new ACBrException("ACBr Sintegra não inicializado.");
            }
        }
    }
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta o nome do arquivo para exportacao.
     * 
     * @param pNomeArquivo nome do arquivo que sera geracao.
     * @throws ACBrException 
     */
    public void setNomeArquivo(String pNomeArquivo) throws ACBrException {
        int ret = ACBrSintegraInterop.INSTANCE.SIN_SetFileName(getHandle(), toUTF8(pNomeArquivo));
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
        int ret = ACBrSintegraInterop.INSTANCE.SIN_GetFileName(getHandle(), lNomeArquivo, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lNomeArquivo, ret);
    }
    
    /**
     * Obtem a versao da biblioteca.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getVersao() throws ACBrException {
        ByteBuffer lVersao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrSintegraInterop.INSTANCE.SIN_GetVersao(getHandle(), lVersao, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lVersao, ret);
    }    

    /**
     * Seta a versao do validador do sintegra.
     * 
     * @param pVersao versao associada ao arquivo.
     * @throws ACBrException 
     */
    public void setVersaoValidador(VersaoValidador pVersao) throws ACBrException {
        int ret = ACBrSintegraInterop.INSTANCE.SIN_SetVersaoValidador(getHandle(), pVersao.getId());
        checkResult(ret);
    }    

    /**
     * Obtem a versao do validador.
     * 
     * @return
     * @throws ACBrException 
     */
    public int getVersaoValidador() throws ACBrException {
        return ACBrSintegraInterop.INSTANCE.SIN_GetVersaoValidador(getHandle());
    }       
    
    /**
     * Ativa o componente para geracao do arquivo.
     * 
     * @param pAtivo indica se o mesmo esta ativo ou nao.
     * @throws ACBrException 
     */
    public void setAtivo(boolean pAtivo) throws ACBrException {
        int ret = ACBrSintegraInterop.INSTANCE.SIN_SetAtivo(getHandle(), pAtivo);
        checkResult(ret);
    }    
    
    /**
     * Verifica se o componente esta ativo.
     * 
     * @return status do componente.
     * @throws ACBrException 
     */
    public boolean isAtivo() throws ACBrException {
        return ACBrSintegraInterop.INSTANCE.SIN_GetAtivo(getHandle()) != 0;
    }       

    /**
     * Informa88C.
     * 
     * @param pInforma
     * @throws ACBrException 
     */
    public void setInforma88C(boolean pInforma) throws ACBrException {
        int ret = ACBrSintegraInterop.INSTANCE.SIN_SetInforma88C(getHandle(), pInforma);
        checkResult(ret);
    }     
    
    /**
     * Verifica informe 88C.
     * 
     * @return
     * @throws ACBrException 
     */
    public boolean isInforma88C() throws ACBrException {
        return ACBrSintegraInterop.INSTANCE.SIN_GetInforma88C(getHandle()) != 0;
    }       

    /**
     * Informa88EAN.
     * 
     * @param pInforma
     * @throws ACBrException 
     */
    public void setInforma88EAN(boolean pInforma) throws ACBrException {
        int ret = ACBrSintegraInterop.INSTANCE.SIN_SetInforma88EAN(getHandle(), pInforma);
        checkResult(ret);
    }     
    
    /**
     * Verifica informe 88EAN.
     * 
     * @return
     * @throws ACBrException 
     */
    public boolean isInforma88EAN() throws ACBrException {
        return ACBrSintegraInterop.INSTANCE.SIN_GetInforma88EAN(getHandle()) != 0;
    }     

    /**
     * Informa88SME.
     * 
     * @param pInforma
     * @throws ACBrException 
     */
    public void setInforma88SME(boolean pInforma) throws ACBrException {
        int ret = ACBrSintegraInterop.INSTANCE.SIN_SetInforma88SME(getHandle(), pInforma);
        checkResult(ret);
    }     
    
    /**
     * Verifica informe 88SME.
     * 
     * @return
     * @throws ACBrException 
     */
    public boolean isInforma88SME() throws ACBrException {
        return ACBrSintegraInterop.INSTANCE.SIN_GetInforma88SME(getHandle()) != 0;
    }      

    /**
     * Informa88SMS.
     * 
     * @param pInforma
     * @throws ACBrException 
     */
    public void setInforma88SMS(boolean pInforma) throws ACBrException {
        int ret = ACBrSintegraInterop.INSTANCE.SIN_SetInforma88SMS(getHandle(), pInforma);
        checkResult(ret);
    }     
    
    /**
     * Verifica informe 88SSMS.
     * 
     * @return
     * @throws ACBrException 
     */
    public boolean isInforma88SMS() throws ACBrException {
        return ACBrSintegraInterop.INSTANCE.SIN_GetInforma88SMS(getHandle()) != 0;
    }     

    /**
     * InformaSapiMG.
     * 
     * @param pInforma
     * @throws ACBrException 
     */
    public void setInformaSapiMG(boolean pInforma) throws ACBrException {
        int ret = ACBrSintegraInterop.INSTANCE.SIN_SetInformaSapiMG(getHandle(), pInforma);
        checkResult(ret);
    }     
    
    /**
     * Verifica informe SapiMG.
     * 
     * @return
     * @throws ACBrException 
     */
    public boolean isInformaSapiMG() throws ACBrException {
        return ACBrSintegraInterop.INSTANCE.SIN_GetInformaSapiMG(getHandle()) != 0;
    } 
    
    /**
     * Realiza a geracao do arquivo do sintegra.
     * 
     * @throws ACBrException 
     */
    public void geraArquivo() throws ACBrException {
        gerarRegistro10();
        gerarRegistro11();
        gerarRegistro50();
        gerarRegistro51();
        gerarRegistro53();
        gerarRegistro54();
        gerarRegistro55();
        gerarRegistro56();
        gerarRegistro60M();
        gerarRegistro60A();
        gerarRegistro60D();
        gerarRegistro60I();
        gerarRegistro60R();
        gerarRegistro61();
        gerarRegistro61R();
        gerarRegistro70();
        gerarRegistro71();
        gerarRegistro74();
        gerarRegistro75();
        gerarRegistro76();
        gerarRegistro77();
        gerarRegistro85();
        gerarRegistro86();

        int ret = ACBrSintegraInterop.INSTANCE.SIN_GeraArquivo(getHandle());
        checkResult(ret);

        limparRegistros(false);
    }
    
    /**
     * Realiza a limpeza de todos os registros.
     * 
     * @throws ACBrException 
     */
    public void limparRegistros() throws ACBrException {
        limparRegistros(true);
    }
    
    /**
     * Realiza a limpeza dos registros.
     * 
     * @param pLimpaComponente 
     * @throws ACBrException 
     */
    private void limparRegistros(boolean pLimpaComponente) throws ACBrException {
        if (pLimpaComponente) {
            int ret = ACBrSintegraInterop.INSTANCE.SIN_LimparRegistros(getHandle());
            checkResult(ret);
        }

        registro10 = new SintegraRegistro10();
        registro11 = new SintegraRegistro11();
        if (registros50 != null) registros50.clear();
        if (registros51 != null) registros51.clear();
        if (registros53 != null) registros53.clear();
        if (registros54 != null) registros54.clear();
        if (registros55 != null) registros55.clear();
        if (registros56 != null) registros56.clear();
        if (registros60A != null) registros60A.clear();
        if (registros60D != null) registros60D.clear();
        if (registros60I != null) registros60I.clear();
        if (registros60M != null) registros60M.clear();
        if (registros60R != null) registros60R.clear();
        if (registros61 != null) registros61.clear();
        if (registros61R != null) registros61R.clear();
        if (registros70 != null) registros70.clear();
        if (registros71 != null) registros71.clear();
        if (registros74 != null) registros74.clear();
        if (registros75 != null) registros75.clear();
        if (registros76 != null) registros76.clear();
        if (registros77 != null) registros77.clear();
        if (registros85 != null) registros85.clear();
        if (registros86 != null) registros86.clear();
    }
    
    /**
     * Envia o registro 10 para geracao.
     * 
     * @throws ACBrException 
     */
    private void gerarRegistro10() throws ACBrException {
        if (registro10 == null) throw new ACBrException("Registro 10 não informado.");
        ACBrSintegraInterop.Registro10Rec lRecord = new ACBrSintegraInterop.Registro10Rec();        
        lRecord.CNPJ = toByte(registro10.getCnpj(), 15);
        lRecord.Inscricao = toByte(registro10.getInscricao(), 15);
        lRecord.RazaoSocial = toByte(registro10.getRazaoSocial(), 36);
        lRecord.Cidade = toByte(registro10.getCidade(), 31);
        lRecord.Estado = toByte(registro10.getEstado(), 3);
        lRecord.Telefone = toByte(registro10.getTelefone(), 13);
        lRecord.DataInicial = OleDate.toOADate(registro10.getDataInicial());
        lRecord.DataFinal = OleDate.toOADate(registro10.getDataFinal());
        lRecord.NaturezaInformacoes = registro10.getNaturezaInformacao().getCodigo();
        lRecord.FinalidadeArquivo = registro10.getFinalidadeArquivo().getCodigo();
        lRecord.CodigoConvenio = registro10.getConvenio().getCodigo();
        
        int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro10(getHandle(), lRecord);        
        checkResult(ret);
    }

    /**
     * Envia o registro 11 para geracao.
     * 
     * @throws ACBrException 
     */
    private void gerarRegistro11() throws ACBrException {
        if (registro11 == null) throw new ACBrException("Registro 11 não informado.");
        ACBrSintegraInterop.Registro11Rec lRecord = new ACBrSintegraInterop.Registro11Rec();
        lRecord.Responsavel = toByte(registro11.getResponsavel(), 29);
        lRecord.Bairro = toByte(registro11.getBairro(), 16);
        lRecord.Cep = toByte(registro11.getCep(), 9);
        lRecord.Numero = toByte(registro11.getNumero(), 6);
        lRecord.Complemento = toByte(registro11.getComplemento(), 23);
        lRecord.Endereco = toByte(registro11.getEndereco(), 35);
        lRecord.Telefone = toByte(registro11.getTelefone(), 13);

        int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro11(getHandle(), lRecord);
        checkResult(ret);
    }

    /**
     * Envia os registros 50 para geracao.
     * 
     * @throws ACBrException 
     */
    private void gerarRegistro50() throws ACBrException {
        if (registros50 != null && registros50.size() > 0) {
            ACBrSintegraInterop.Registro50Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro50Rec.class, registros50.size());
            int i = 0;
            for (SintegraRegistro50 lRegistro50 : registros50) {
                lRecord[i].CPFCNPJ = toByte(lRegistro50.getCpfCnpj(), 15);
                lRecord[i].Inscricao = toByte(lRegistro50.getInscricao(), 15);
                lRecord[i].UF = toByte(lRegistro50.getUf(), 3);
                lRecord[i].Situacao = toByte(lRegistro50.getSituacao(), 2);
                lRecord[i].Aliquota = lRegistro50.getAliquota();
                lRecord[i].Isentas = lRegistro50.getIsentas();
                lRecord[i].Icms = lRegistro50.getIcms();
                lRecord[i].ValorContabil = lRegistro50.getValorContabil();
                lRecord[i].BasedeCalculo = lRegistro50.getBaseCalculo();
                lRecord[i].Outras = lRegistro50.getOutras();
                lRecord[i].EmissorDocumento = toByte(lRegistro50.getEmissorDocumento().getTipo(), 2);
                lRecord[i].Cfop = toByte(lRegistro50.getCfop(), 5);
                lRecord[i].Serie = toByte(lRegistro50.getSerie(), 4);
                lRecord[i].Modelo = toByte(lRegistro50.getModelo(), 3);
                lRecord[i].Numero = toByte(lRegistro50.getNumero(), 7);
                lRecord[i].DataDocumento = OleDate.toOADate(lRegistro50.getDataDocumento());
                i++;
            }
            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro50(getHandle(), lRecord, registros50.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 51 para geracao.
     * 
     * @throws ACBrException 
     */
    private void gerarRegistro51() throws ACBrException {
        if (registros51 != null && registros51.size() > 0) {
            ACBrSintegraInterop.Registro51Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro51Rec.class, registros51.size());
            int i = 0;
            for (SintegraRegistro51 lRegistro51 : registros51) {
                lRecord[i].CPFCNPJ = toByte(lRegistro51.getCpfCnpj(), 15);
                lRecord[i].Inscricao = toByte(lRegistro51.getInscricao(), 15);
                lRecord[i].Estado = toByte(lRegistro51.getEstado(), 3);
                lRecord[i].ValorContabil = lRegistro51.getValorContabil();
                lRecord[i].Cfop = toByte(lRegistro51.getCfop(), 5);
                lRecord[i].Serie = toByte(lRegistro51.getSerie(), 4);
                lRecord[i].Numero = toByte(lRegistro51.getNumero(), 7);
                lRecord[i].DataDocumento = OleDate.toOADate(lRegistro51.getDataDocumento());
                lRecord[i].ValorIpi = lRegistro51.getValorIpi();
                lRecord[i].Situacao = toByte(lRegistro51.getSituacao(), 2);
                lRecord[i].ValorIsentas = lRegistro51.getValorIsentas();
                lRecord[i].ValorOutras = lRegistro51.getValorOutras();
                i++;
            }
            
            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro51(getHandle(), lRecord, registros51.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 53 para geracao.
     * 
     * @throws ACBrException 
     */
    private void gerarRegistro53() throws ACBrException {
        if (registros53 != null && registros53.size() > 0) {
            ACBrSintegraInterop.Registro53Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro53Rec.class, registros53.size());
            int i = 0;
            for (SintegraRegistro53 lRegistro53 : registros53) {    
                lRecord[i].CPFCNPJ = toByte(lRegistro53.getCpfCnpj(), 15);
                lRecord[i].Inscricao = toByte(lRegistro53.getInscricao(), 15);
                lRecord[i].Estado = toByte(lRegistro53.getEstado(), 3);
                lRecord[i].Serie = toByte(lRegistro53.getSerie(), 4);
                lRecord[i].DataDocumento = OleDate.toOADate(lRegistro53.getDataDocumento());
                lRecord[i].Cfop = toByte(lRegistro53.getCfop(), 5);
                lRecord[i].Numero = toByte(lRegistro53.getNumero(), 7);
                lRecord[i].Situacao = toByte(lRegistro53.getSituacao(), 4);
                lRecord[i].CodigoAntecipacao = toByte(lRegistro53.getCodigoAntecipacao(), 2);
                lRecord[i].BaseST = lRegistro53.getBaseST();
                lRecord[i].Modelo = toByte(lRegistro53.getModelo(), 3);
                lRecord[i].Emitente = toByte(lRegistro53.getEmitente().getTipo(), 2);
                lRecord[i].Despesas = lRegistro53.getDespesas();
                lRecord[i].IcmsRetido = lRegistro53.getIcmsRetido();
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro53(getHandle(), lRecord, registros53.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 54 para geracao.
     * 
     * @throws ACBrException 
     */
    private void gerarRegistro54() throws ACBrException {
        if (registros54 != null && registros54.size() > 0) {        
            ACBrSintegraInterop.Registro54Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro54Rec.class, registros54.size());
            int i = 0;
            for (SintegraRegistro54 lRegistro54 : registros54) {                
                lRecord[i].CPFCNPJ = toByte(lRegistro54.getCpfCnpj(), 15);
                lRecord[i].Aliquota = lRegistro54.getAliquota();
                lRecord[i].BaseST = lRegistro54.getBaseST();
                lRecord[i].BasedeCalculo = lRegistro54.getBaseCalculo();
                lRecord[i].Quantidade = lRegistro54.getQuantidade();
                lRecord[i].ValorDescontoDespesa = lRegistro54.getValorDescontoDespesa();
                lRecord[i].ValorIpi = lRegistro54.getValorIpi();
                lRecord[i].Valor = lRegistro54.getValor();
                lRecord[i].NumeroItem = lRegistro54.getNumeroItem();
                lRecord[i].CST = toByte(lRegistro54.getCst(), 4);
                lRecord[i].Codigo = toByte(lRegistro54.getCodigo(), 15);
                lRecord[i].CFOP = toByte(lRegistro54.getCfop(), 5);
                lRecord[i].Descricao = toByte(lRegistro54.getDescricao(), 54);
                lRecord[i].Numero = toByte(lRegistro54.getNumero(), 7);
                lRecord[i].Modelo = toByte(lRegistro54.getModelo(), 3);
                lRecord[i].Serie = toByte(lRegistro54.getSerie(), 4);
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro54(getHandle(), lRecord, registros54.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 55 para geracao.
     * 
     * @throws ACBrException 
     */    
    private void gerarRegistro55() throws ACBrException {
        if (registros55 != null && registros55.size() > 0) {              
            ACBrSintegraInterop.Registro55Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro55Rec.class, registros55.size());
            int i = 0;
            for (SintegraRegistro55 lRegistro55 : registros55) {
                lRecord[i].Valor = lRegistro55.getValor();
                lRecord[i].Agencia = lRegistro55.getAgencia();
                lRecord[i].Banco = lRegistro55.getBanco();
                lRecord[i].NumeroConvenio = toByte(lRegistro55.getNumeroConvenio(), 31);
                lRecord[i].Inscricao = toByte(lRegistro55.getInscricao(), 15);
                lRecord[i].MesAno = toByte(lRegistro55.getMesAno(), 7);
                lRecord[i].CNPJ = toByte(lRegistro55.getCnpj(), 15);
                lRecord[i].UF = toByte(lRegistro55.getUf(), 3);
                lRecord[i].Numero = toByte(lRegistro55.getNumero(), 15);
                lRecord[i].DataPagamento = OleDate.toOADate(lRegistro55.getDataPagamento());
                lRecord[i].Vencimento = OleDate.toOADate(lRegistro55.getVencimento());
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro55(getHandle(), lRecord, registros55.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 56 para geracao.
     * 
     * @throws ACBrException 
     */        
    private void gerarRegistro56() throws ACBrException {
        if (registros56 != null && registros56.size() > 0) { 
            ACBrSintegraInterop.Registro56Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro56Rec.class, registros56.size());
            int i = 0;
            for (SintegraRegistro56 lRegistro56 : registros56) {
                lRecord[i].Cnpj = toByte(lRegistro56.getCnpj(), 15);
                lRecord[i].Modelo = toByte(lRegistro56.getModelo(), 3);
                lRecord[i].Serie = toByte(lRegistro56.getSerie(), 4);
                lRecord[i].Numero = toByte(lRegistro56.getNumero(), 7);
                lRecord[i].Cfop = toByte(lRegistro56.getCfop(), 5);
                lRecord[i].Cst = toByte(lRegistro56.getCst(), 4);
                lRecord[i].NumeroItem = lRegistro56.getNumeroItem();
                lRecord[i].Codigo = toByte(lRegistro56.getCodigo(), 15);
                lRecord[i].TipoOperacao = toByte(lRegistro56.getTipoOperacao().getCodigo(), 2);
                lRecord[i].CnpjConcessionaria = toByte(lRegistro56.getCnpjConcessionaria(), 15);
                lRecord[i].Ipi = lRegistro56.getIpi();
                lRecord[i].Chassi = toByte(lRegistro56.getChassi(), 18);
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro56(getHandle(), lRecord, registros56.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 60A para geracao.
     * 
     * @throws ACBrException 
     */     
    private void gerarRegistro60A() throws ACBrException {
        if (registros60A != null && registros60A.size() > 0) { 
            ACBrSintegraInterop.Registro60ARec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro60ARec.class, registros60A.size());
            int i = 0;
            for (SintegraRegistro60A lRegistro60A : registros60A) {
                lRecord[i].NumSerie = toByte(lRegistro60A.getNumSerie(), 21);
                lRecord[i].Aliquota = toByte(lRegistro60A.getAliquota(), 5);
                lRecord[i].Emissao = OleDate.toOADate(lRegistro60A.getEmissao());
                lRecord[i].Valor = lRegistro60A.getValor();
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro60A(getHandle(), lRecord, registros60A.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 60D para geracao.
     *
     * @throws ACBrException
     */
    private void gerarRegistro60D() throws ACBrException {
        if (registros60D != null && registros60D.size() > 0) {
            ACBrSintegraInterop.Registro60DRec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro60DRec.class, registros60D.size());
            int i = 0;
            for (SintegraRegistro60D lRegistro60D : registros60D) {
                lRecord[i].NumSerie = toByte(lRegistro60D.getNumSerie(), 21);
                lRecord[i].StAliquota = toByte(lRegistro60D.getStAliquota(), 5);
                lRecord[i].Emissao = OleDate.toOADate(lRegistro60D.getEmissao());
                lRecord[i].Valor = lRegistro60D.getValor();
                lRecord[i].Codigo = toByte(lRegistro60D.getCodigo(), 15);
                lRecord[i].ValorIcms = lRegistro60D.getValorIcms();
                lRecord[i].Quantidade = lRegistro60D.getQuantidade();
                lRecord[i].BaseDeCalculo = lRegistro60D.getBaseCalculo();
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro60D(getHandle(), lRecord, registros60D.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 60I para geracao.
     *
     * @throws ACBrException
     */
    private void gerarRegistro60I() throws ACBrException {
        if (registros60I != null && registros60I.size() > 0) {
            ACBrSintegraInterop.Registro60IRec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro60IRec.class, registros60I.size());
            int i = 0;
            for (SintegraRegistro60I lRegistro60I : registros60I) {
                lRecord[i].NumSerie = toByte(lRegistro60I.getNumSerie(), 21);
                lRecord[i].StAliquota = toByte(lRegistro60I.getStAliquota(), 5);
                lRecord[i].Emissao = OleDate.toOADate(lRegistro60I.getEmissao());
                lRecord[i].Valor = lRegistro60I.getValor();
                lRecord[i].Codigo = toByte(lRegistro60I.getCodigo(), 15);
                lRecord[i].ValorIcms = lRegistro60I.getValorIcms();
                lRecord[i].Quantidade = lRegistro60I.getQuantidade();
                lRecord[i].BaseDeCalculo = lRegistro60I.getBaseCalculo();
                lRecord[i].Item = lRegistro60I.getItem();
                lRecord[i].Cupom = toByte(lRegistro60I.getCupom(), 7);
                lRecord[i].ModeloDoc = toByte(lRegistro60I.getModeloDoc(), 3);
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro60I(getHandle(), lRecord, registros60I.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 60M para geracao.
     *
     * @throws ACBrException
     */    
    private void gerarRegistro60M() throws ACBrException {
        if (registros60M != null && registros60M.size() > 0) {
            ACBrSintegraInterop.Registro60MRec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro60MRec.class, registros60M.size());
            int i = 0;
            for (SintegraRegistro60M lRegistro60M : registros60M) {
                lRecord[i].CRO = lRegistro60M.getCro();
                lRecord[i].NumOrdem = lRegistro60M.getNumOrdem();
                lRecord[i].VendaBruta = lRegistro60M.getVendaBruta();
                lRecord[i].ModeloDoc = toByte(lRegistro60M.getModeloDoc(), 3);
                lRecord[i].ValorGT = lRegistro60M.getValorGT();
                lRecord[i].CRZ = lRegistro60M.getCrz();
                lRecord[i].CooFinal = lRegistro60M.getCooFinal();
                lRecord[i].CooInicial = lRegistro60M.getCooInicial();
                lRecord[i].NumSerie = toByte(lRegistro60M.getNumSerie(), 21);
                lRecord[i].Emissao = OleDate.toOADate(lRegistro60M.getEmissao());
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro60M(getHandle(), lRecord, registros60M.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 60R para geracao.
     *
     * @throws ACBrException
     */        
    private void gerarRegistro60R() throws ACBrException {
        if (registros60R != null && registros60R.size() > 0) {
            ACBrSintegraInterop.Registro60RRec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro60RRec.class, registros60R.size());
            int i = 0;
            for (SintegraRegistro60R lRegistro60R : registros60R) {
                lRecord[i].BaseDeCalculo = lRegistro60R.getBaseCalculo();
                lRecord[i].Valor = lRegistro60R.getValor();
                lRecord[i].Qtd = lRegistro60R.getQtd();
                lRecord[i].MesAno = toByte(lRegistro60R.getMesAno(), 7);
                lRecord[i].Codigo = toByte(lRegistro60R.getCodigo(), 15);
                lRecord[i].Aliquota = toByte(lRegistro60R.getAliquota(), 5);
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro60R(getHandle(), lRecord, registros60R.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 61 para geracao.
     *
     * @throws ACBrException
     */
    private void gerarRegistro61() throws ACBrException {
        if (registros61 != null && registros61.size() > 0) {
            ACBrSintegraInterop.Registro61Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro61Rec.class, registros61.size());
            int i = 0;
            for (SintegraRegistro61 lRegistro61 : registros61) {
                lRecord[i].Emissao = OleDate.toOADate(lRegistro61.getEmissao());
                lRecord[i].Valor = lRegistro61.getValor();
                lRecord[i].ValorIcms = lRegistro61.getValorIcms();
                lRecord[i].Outras = lRegistro61.getOutras();
                lRecord[i].BaseDeCalculo = lRegistro61.getBaseCalculo();
                lRecord[i].Isentas = lRegistro61.getIsentas();
                lRecord[i].NumOrdemInicial = lRegistro61.getNumOrdemInicial();
                lRecord[i].NumOrdemFinal = lRegistro61.getNumOrdemFinal();
                lRecord[i].Modelo = toByte(lRegistro61.getModelo(), 3);
                lRecord[i].SubSerie = toByte(lRegistro61.getSubSerie(), 3);
                lRecord[i].Serie = toByte(lRegistro61.getSerie(), 4);
                lRecord[i].Aliquota = lRegistro61.getAliquota();
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro61(getHandle(), lRecord, registros61.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 61R para geracao.
     *
     * @throws ACBrException
     */
    private void gerarRegistro61R() throws ACBrException {
        if (registros61R != null && registros61R.size() > 0) {
            ACBrSintegraInterop.Registro61RRec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro61RRec.class, registros61R.size());
            int i = 0;
            for (SintegraRegistro61R lRegistro61R : registros61R) {
                lRecord[i].Aliquota = lRegistro61R.getAliquota();
                lRecord[i].Valor = lRegistro61R.getValor();
                lRecord[i].Qtd = lRegistro61R.getQtd();
                lRecord[i].MesAno = toByte(lRegistro61R.getMesAno(), 7);
                lRecord[i].Codigo = toByte(lRegistro61R.getCodigo(), 15);
                lRecord[i].BaseDeCalculo = lRegistro61R.getBaseCalculo();
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro61R(getHandle(), lRecord, registros61R.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 70 para geracao.
     *
     * @throws ACBrException
     */
    private void gerarRegistro70() throws ACBrException {
        if (registros70 != null && registros70.size() > 0) {
            ACBrSintegraInterop.Registro70Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro70Rec.class, registros70.size());
            int i = 0;
            for (SintegraRegistro70 lRegistro70 : registros70) {
                lRecord[i].Icms = lRegistro70.getIcms();
                lRecord[i].ValorContabil = lRegistro70.getValorContabil();
                lRecord[i].UF = toByte(lRegistro70.getUf(), 3);
                lRecord[i].Isentas = lRegistro70.getIsentas();
                lRecord[i].SubSerie = toByte(lRegistro70.getSubSerie(), 3);
                lRecord[i].Serie = toByte(lRegistro70.getSerie(), 2);
                lRecord[i].DataDocumento = OleDate.toOADate(lRegistro70.getDataDocumento());
                lRecord[i].Modelo = toByte(lRegistro70.getModelo(), 3);
                lRecord[i].CPFCNPJ = toByte(lRegistro70.getCpfCnpj(), 15);
                lRecord[i].Cfop = toByte(lRegistro70.getCfop(), 5);
                lRecord[i].Numero = toByte(lRegistro70.getNumero(), 7);
                lRecord[i].Inscricao = toByte(lRegistro70.getInscricao(), 15);
                lRecord[i].Situacao = toByte(lRegistro70.getSituacao(), 15);
                lRecord[i].Outras = lRegistro70.getOutras();
                lRecord[i].BasedeCalculo = lRegistro70.getBaseCalculo();
                lRecord[i].CifFobOutros = toByte(lRegistro70.getCifFobOutros().getCodigo(), 2);
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro70(getHandle(), lRecord, registros70.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 71 para geracao.
     *
     * @throws ACBrException
     */
    private void gerarRegistro71() throws ACBrException {
        if (registros71 != null && registros71.size() > 0) {
            ACBrSintegraInterop.Registro71Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro71Rec.class, registros71.size());
            int i = 0;
            for (SintegraRegistro71 lRegistro71 : registros71) {
                lRecord[i].CPFCNPJ = toByte(lRegistro71.getCpfCnpj(), 15);
                lRecord[i].Inscricao = toByte(lRegistro71.getInscricao(), 15);
                lRecord[i].DataDocumento = OleDate.toOADate(lRegistro71.getDataDocumento());
                lRecord[i].Modelo = toByte(lRegistro71.getModelo(), 3);
                lRecord[i].Serie = toByte(lRegistro71.getSerie(), 2);
                lRecord[i].SubSerie = toByte(lRegistro71.getSubSerie(), 3);
                lRecord[i].Numero = toByte(lRegistro71.getNumero(), 7);
                lRecord[i].UF = toByte(lRegistro71.getUf(), 3);
                lRecord[i].UFNF = toByte(lRegistro71.getUfNF(), 3);
                lRecord[i].CPFCNPJNF = toByte(lRegistro71.getCpfCnpjNF(), 15);
                lRecord[i].InscricaoNF = toByte(lRegistro71.getInscricaoNF(), 15);
                lRecord[i].DataNF = OleDate.toOADate(lRegistro71.getDataNF());
                lRecord[i].ModeloNF = toByte(lRegistro71.getModeloNF(), 3);
                lRecord[i].SerieNF = toByte(lRegistro71.getSerieNF(), 4);
                lRecord[i].NumeroNF = toByte(lRegistro71.getNumeroNF(), 7);
                lRecord[i].ValorNF = lRegistro71.getValorNF();
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro71(getHandle(), lRecord, registros71.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 74 para geracao.
     *
     * @throws ACBrException
     */
    private void gerarRegistro74() throws ACBrException {
        if (registros74 != null && registros74.size() > 0) {
            ACBrSintegraInterop.Registro74Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro74Rec.class, registros74.size());
            int i = 0;
            for (SintegraRegistro74 lRegistro74 : registros74) {
                lRecord[i].ValorProduto = lRegistro74.getValorProduto();
                lRecord[i].CodigoPosse = toByte(lRegistro74.getCodigoPosse(), 2);
                lRecord[i].InscricaoPossuidor = toByte(lRegistro74.getInscricaoPossuidor(), 15);
                lRecord[i].Codigo = toByte(lRegistro74.getCodigo(), 15);
                lRecord[i].CNPJPossuidor = toByte(lRegistro74.getCnpjPossuidor(), 15);
                lRecord[i].UFPossuidor = toByte(lRegistro74.getUfPossuidor(), 3);
                lRecord[i].Data = OleDate.toOADate(lRegistro74.getData());
                lRecord[i].Quantidade = lRegistro74.getQuantidade();
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro74(getHandle(), lRecord, registros74.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 75 para geracao.
     *
     * @throws ACBrException
     */    
    private void gerarRegistro75() throws ACBrException {
        if (registros75 != null && registros75.size() > 0) {
            ACBrSintegraInterop.Registro75Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro75Rec.class, registros75.size());
            int i = 0;
            for (SintegraRegistro75 lRegistro75 : registros75) {
                lRecord[i].Codigo = toByte(lRegistro75.getCodigo(), 15);
                lRecord[i].Descricao = toByte(lRegistro75.getDescricao(), 54);
                lRecord[i].Reducao = lRegistro75.getReducao();
                lRecord[i].BaseST = lRegistro75.getBaseST();
                lRecord[i].AliquotaIpi = lRegistro75.getAliquotaIpi();
                lRecord[i].NCM = toByte(lRegistro75.getNcm(), 9);
                lRecord[i].Unidade = toByte(lRegistro75.getUnidade(), 7);
                lRecord[i].AliquotaICMS = lRegistro75.getAliquotaICMS();
                lRecord[i].DataFinal = OleDate.toOADate(lRegistro75.getDataFinal());
                lRecord[i].DataInicial = OleDate.toOADate(lRegistro75.getDataInicial());
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro75(getHandle(), lRecord, registros75.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 76 para geracao.
     *
     * @throws ACBrException
     */        
    private void gerarRegistro76() throws ACBrException {
        if (registros76 != null && registros76.size() > 0) {
            ACBrSintegraInterop.Registro76Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro76Rec.class, registros76.size());
            int i = 0;
            for (SintegraRegistro76 lRegistro76 : registros76) {
                lRecord[i].Isentas = lRegistro76.getIsentas();
                lRecord[i].ValorTotal = lRegistro76.getValorTotal();
                lRecord[i].Icms = lRegistro76.getIcms();
                lRecord[i].BasedeCalculo = lRegistro76.getBaseCalculo();
                lRecord[i].Outras = lRegistro76.getOutras();
                lRecord[i].Modelo = lRegistro76.getModelo();
                lRecord[i].Numero = lRegistro76.getNumero();
                lRecord[i].Situacao = toByte(lRegistro76.getSituacao(), 2);
                lRecord[i].Inscricao = toByte(lRegistro76.getInscricao(), 15);
                lRecord[i].SubSerie = toByte(lRegistro76.getSubSerie(), 3);
                lRecord[i].Uf = toByte(lRegistro76.getUf(), 3);
                lRecord[i].Serie = toByte(lRegistro76.getSerie(), 3);
                lRecord[i].Cfop = toByte(lRegistro76.getCfop(), 5);
                lRecord[i].CPFCNPJ = toByte(lRegistro76.getCpfCnpj(), 15);
                lRecord[i].DataDocumento = OleDate.toOADate(lRegistro76.getDataDocumento());
                lRecord[i].TipoReceita = lRegistro76.getTipoReceita();
                lRecord[i].Aliquota = lRegistro76.getAliquota();
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro76(getHandle(), lRecord, registros76.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 77 para geracao.
     *
     * @throws ACBrException
     */
    private void gerarRegistro77() throws ACBrException {
        if (registros77 != null && registros77.size() > 0) {
            ACBrSintegraInterop.Registro77Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro77Rec.class, registros77.size());
            int i = 0;
            for (SintegraRegistro77 lRegistro77 : registros77) {
                lRecord[i].Quantidade = lRegistro77.getQuantidade();
                lRecord[i].ValorServico = lRegistro77.getValorServico();
                lRecord[i].ValorDesconto = lRegistro77.getValorDesconto();
                lRecord[i].BaseDeCalculo = lRegistro77.getBaseCalculo();
                lRecord[i].Modelo = lRegistro77.getModelo();
                lRecord[i].Numero = lRegistro77.getNumero();
                lRecord[i].NumeroTerminal = lRegistro77.getNumeroTerminal();
                lRecord[i].NumeroItem = lRegistro77.getNumeroItem();
                lRecord[i].Aliquota = lRegistro77.getAliquota();
                lRecord[i].CNPJMF = toByte(lRegistro77.getCnpjMF(), 15);
                lRecord[i].Cfop = toByte(lRegistro77.getCfop(), 5);
                lRecord[i].Codigo = toByte(lRegistro77.getCodigo(), 12);
                lRecord[i].SubSerie = toByte(lRegistro77.getSubSerie(), 3);
                lRecord[i].CPFCNPJ = toByte(lRegistro77.getCpfCnpj(), 15);
                lRecord[i].Serie = toByte(lRegistro77.getSerie(), 3);
                lRecord[i].TipoReceita = lRegistro77.getTipoReceita();
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro77(getHandle(), lRecord, registros77.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 85 para geracao.
     *
     * @throws ACBrException
     */
    private void gerarRegistro85() throws ACBrException {
        if (registros85 != null && registros85.size() > 0) {
            ACBrSintegraInterop.Registro85Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro85Rec.class, registros85.size());
            int i = 0;
            for (SintegraRegistro85 lRegistro85 : registros85) {
                lRecord[i].Declaracao = toByte(lRegistro85.getDeclaracao(), 12);
                lRecord[i].DataDeclaracao = OleDate.toOADate(lRegistro85.getDataDeclaracao());
                lRecord[i].NaturezaExportacao = toByte(lRegistro85.getNaturezaExportacao().getCodigo(), 12);
                lRecord[i].RegistroExportacao = toByte(lRegistro85.getRegistroExportacao(), 13);
                lRecord[i].DataRegistro = OleDate.toOADate(lRegistro85.getDataRegistro());
                lRecord[i].Conhecimento = toByte(lRegistro85.getConhecimento(), 17);
                lRecord[i].DataConhecimento = OleDate.toOADate(lRegistro85.getDataConhecimento());
                lRecord[i].TipoConhecimento = toByte(lRegistro85.getTipoConhecimento(), 3);
                lRecord[i].Pais = toByte(lRegistro85.getPais(), 5);
                lRecord[i].DataAverbacao = OleDate.toOADate(lRegistro85.getDataAverbacao());
                lRecord[i].NumeroNotaFiscal = toByte(lRegistro85.getNumeroNotaFiscal(), 7);
                lRecord[i].DataNotaFiscal = OleDate.toOADate(lRegistro85.getDataNotaFiscal());
                lRecord[i].Modelo = toByte(lRegistro85.getModelo(), 3);
                lRecord[i].Serie = toByte(lRegistro85.getSerie(), 4);
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro85(getHandle(), lRecord, registros85.size());
            checkResult(ret);
        }
    }

    /**
     * Envia os registros 86 para geracao.
     *
     * @throws ACBrException
     */
    private void gerarRegistro86() throws ACBrException {
        if (registros86 != null && registros86.size() > 0) {
            ACBrSintegraInterop.Registro86Rec[] lRecord = criaVetorJNA(ACBrSintegraInterop.Registro86Rec.class, registros86.size());
            int i = 0;
            for (SintegraRegistro86 lRegistro86 : registros86) {
                lRecord[i].RegistroExportacao = toByte(lRegistro86.getRegistroExportacao(), 13);
                lRecord[i].DataRegistro = OleDate.toOADate(lRegistro86.getDataRegistro());
                lRecord[i].CPFCNPJ = toByte(lRegistro86.getCpfCnpj(), 15);
                lRecord[i].Inscricao = toByte(lRegistro86.getInscricao(), 15);
                lRecord[i].UF = toByte(lRegistro86.getUf(), 3);
                lRecord[i].NumeroNotaFiscal = toByte(lRegistro86.getNumeroNotaFiscal(), 7);
                lRecord[i].DataDocumento = OleDate.toOADate(lRegistro86.getDataDocumento());
                lRecord[i].Modelo = toByte(lRegistro86.getModelo(), 3);
                lRecord[i].Serie = toByte(lRegistro86.getSerie(), 4);
                lRecord[i].Codigo = toByte(lRegistro86.getCodigo(), 15);
                lRecord[i].Quantidade = lRegistro86.getQuantidade();
                lRecord[i].ValorUnitario = lRegistro86.getValorUnitario();
                lRecord[i].ValorTotalProduto = lRegistro86.getValorTotalProduto();
                lRecord[i].Relacionamento = toByte(lRegistro86.getRelacionamento(), 2);
                i++;
            }

            int ret = ACBrSintegraInterop.INSTANCE.SIN_Registro86(getHandle(), lRecord, registros86.size());
            checkResult(ret);
        }
    }
    // </editor-fold>   
    //<editor-fold defaultstate="collapsed" desc="Getters - Setters">

    /**
     * @see SintegraRegistro10
     * @return the registro10
     */
    public SintegraRegistro10 getRegistro10() {
        return registro10;
    }

    /**
     * @see SintegraRegistro10
     * @param registro10 the registro10 to set
     */
    public void setRegistro10(SintegraRegistro10 registro10) {
        this.registro10 = registro10;
    }

    /**
     * @see SintegraRegistro11
     * @return the registro11
     */
    public SintegraRegistro11 getRegistro11() {
        return registro11;
    }

    /**
     * @see SintegraRegistro11
     * @param registro11 the registro11 to set
     */
    public void setRegistro11(SintegraRegistro11 registro11) {
        this.registro11 = registro11;
    }

    /**
     * @see SintegraRegistro50
     * @return the registros50
     */
    public Collection<SintegraRegistro50> getRegistros50() {
        return registros50;
    }

    /**
     * @see SintegraRegistro50
     * @param registros50 the registros50 to set
     */
    public void setRegistros50(Collection<SintegraRegistro50> registros50) {
        this.registros50 = registros50;
    }

    /**
     * @see SintegraRegistro51
     * @return the registros51
     */
    public Collection<SintegraRegistro51> getRegistros51() {
        return registros51;
    }

    /**
     * @see SintegraRegistro51
     * @param registros51 the registros51 to set
     */
    public void setRegistros51(Collection<SintegraRegistro51> registros51) {
        this.registros51 = registros51;
    }

    /**
     * @see SintegraRegistro53
     * @return the registros53
     */
    public Collection<SintegraRegistro53> getRegistros53() {
        return registros53;
    }

    /**
     * @see SintegraRegistro53
     * @param registros53 the registros53 to set
     */
    public void setRegistros53(Collection<SintegraRegistro53> registros53) {
        this.registros53 = registros53;
    }

    /**
     * @see SintegraRegistro54
     * @return the registros54
     */
    public Collection<SintegraRegistro54> getRegistros54() {
        return registros54;
    }

    /**
     * @see SintegraRegistro54
     * @param registros54 the registros54 to set
     */
    public void setRegistros54(Collection<SintegraRegistro54> registros54) {
        this.registros54 = registros54;
    }

    /**
     * @see SintegraRegistro55
     * @return the registros55
     */
    public Collection<SintegraRegistro55> getRegistros55() {
        return registros55;
    }

    /**
     * @see SintegraRegistro55
     * @param registros55 the registros55 to set
     */
    public void setRegistros55(Collection<SintegraRegistro55> registros55) {
        this.registros55 = registros55;
    }

    /**
     * @see SintegraRegistro56
     * @return the registros56
     */
    public Collection<SintegraRegistro56> getRegistros56() {
        return registros56;
    }

    /**
     * @see SintegraRegistro56
     * @param registros56 the registros56 to set
     */
    public void setRegistros56(Collection<SintegraRegistro56> registros56) {
        this.registros56 = registros56;
    }

    /**
     * @see SintegraRegistro60A
     * @return the registros60A
     */
    public Collection<SintegraRegistro60A> getRegistros60A() {
        return registros60A;
    }

    /**
     * @see SintegraRegistro60A
     * @param registros60A the registros60A to set
     */
    public void setRegistros60A(Collection<SintegraRegistro60A> registros60A) {
        this.registros60A = registros60A;
    }

    /**
     * @see SintegraRegistro60D
     * @return the registros60D
     */
    public Collection<SintegraRegistro60D> getRegistros60D() {
        return registros60D;
    }

    /**
     * @see SintegraRegistro60D
     * @param registros60D the registros60D to set
     */
    public void setRegistros60D(Collection<SintegraRegistro60D> registros60D) {
        this.registros60D = registros60D;
    }

    /**
     * @see SintegraRegistro60I
     * @return the registros60I
     */
    public Collection<SintegraRegistro60I> getRegistros60I() {
        return registros60I;
    }

    /**
     * @see SintegraRegistro60I
     * @param registros60I the registros60I to set
     */
    public void setRegistros60I(Collection<SintegraRegistro60I> registros60I) {
        this.registros60I = registros60I;
    }

    /**
     * @see SintegraRegistro60M
     * @return the registros60M
     */
    public Collection<SintegraRegistro60M> getRegistros60M() {
        return registros60M;
    }

    /**
     * @see SintegraRegistro60M
     * @param registros60M the registros60M to set
     */
    public void setRegistros60M(Collection<SintegraRegistro60M> registros60M) {
        this.registros60M = registros60M;
    }

    /**
     * @see SintegraRegistro60R
     * @return the registros60R
     */
    public Collection<SintegraRegistro60R> getRegistros60R() {
        return registros60R;
    }

    /**
     * @see SintegraRegistro60R
     * @param registros60R the registros60R to set
     */
    public void setRegistros60R(Collection<SintegraRegistro60R> registros60R) {
        this.registros60R = registros60R;
    }

    /**
     * @see SintegraRegistro61
     * @return the registros61
     */
    public Collection<SintegraRegistro61> getRegistros61() {
        return registros61;
    }

    /**
     * @see SintegraRegistro61
     * @param registros61 the registros61 to set
     */
    public void setRegistros61(Collection<SintegraRegistro61> registros61) {
        this.registros61 = registros61;
    }

    /**
     * @see SintegraRegistro61R
     * @return the registros61R
     */
    public Collection<SintegraRegistro61R> getRegistros61R() {
        return registros61R;
    }

    /**
     * @see SintegraRegistro61R
     * @param registros61R the registros61R to set
     */
    public void setRegistros61R(Collection<SintegraRegistro61R> registros61R) {
        this.registros61R = registros61R;
    }

    /**
     * @see SintegraRegistro70
     * @return the registros70
     */
    public Collection<SintegraRegistro70> getRegistros70() {
        return registros70;
    }

    /**
     * @see SintegraRegistro70
     * @param registros70 the registros70 to set
     */
    public void setRegistros70(Collection<SintegraRegistro70> registros70) {
        this.registros70 = registros70;
    }

    /**
     * @see SintegraRegistro71
     * @return the registros71
     */
    public Collection<SintegraRegistro71> getRegistros71() {
        return registros71;
    }

    /**
     * @see SintegraRegistro71
     * @param registros71 the registros71 to set
     */
    public void setRegistros71(Collection<SintegraRegistro71> registros71) {
        this.registros71 = registros71;
    }

    /**
     * @see SintegraRegistro74
     * @return the registros74
     */
    public Collection<SintegraRegistro74> getRegistros74() {
        return registros74;
    }

    /**
     * @see SintegraRegistro74
     * @param registros74 the registros74 to set
     */
    public void setRegistros74(Collection<SintegraRegistro74> registros74) {
        this.registros74 = registros74;
    }

    /**
     * @see SintegraRegistro75
     * @return the registros75
     */
    public Collection<SintegraRegistro75> getRegistros75() {
        return registros75;
    }

    /**
     * @see SintegraRegistro75
     * @param registros75 the registros75 to set
     */
    public void setRegistros75(Collection<SintegraRegistro75> registros75) {
        this.registros75 = registros75;
    }

    /**
     * @see SintegraRegistro76
     * @return the registros76
     */
    public Collection<SintegraRegistro76> getRegistros76() {
        return registros76;
    }

    /**
     * @see SintegraRegistro76
     * @param registros76 the registros76 to set
     */
    public void setRegistros76(Collection<SintegraRegistro76> registros76) {
        this.registros76 = registros76;
    }

    /**
     * @see SintegraRegistro77
     * @return the registros77
     */
    public Collection<SintegraRegistro77> getRegistros77() {
        return registros77;
    }

    /**
     * @see SintegraRegistro77
     * @param registros77 the registros77 to set
     */
    public void setRegistros77(Collection<SintegraRegistro77> registros77) {
        this.registros77 = registros77;
    }

    /**
     * @see SintegraRegistro85
     * @return the registros85
     */
    public Collection<SintegraRegistro85> getRegistros85() {
        return registros85;
    }

    /**
     * @see SintegraRegistro85
     * @param registros85 the registros85 to set
     */
    public void setRegistros85(Collection<SintegraRegistro85> registros85) {
        this.registros85 = registros85;
    }

    /**
     * @see SintegraRegistro86
     * @return the registros86
     */
    public Collection<SintegraRegistro86> getRegistros86() {
        return registros86;
    }

    /**
     * @see SintegraRegistro86
     * @param registros86 the registros86 to set
     */
    public void setRegistros86(Collection<SintegraRegistro86> registros86) {
        this.registros86 = registros86;
    }
    // </editor-fold> 

}