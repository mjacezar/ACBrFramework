package jACBrFramework.ead;

import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrClass;
import jACBrFramework.ACBrEventListener;
import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrEADInterop;
import java.nio.ByteBuffer;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Classe para para as operacoes EAD.
 * 
 * @author Jose Mauro
 * @version Criado em: 11/12/2013 09:53:11, revisao: $Id$
 */
public class ACBrEAD extends ACBrClass {

    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Construtor padrao.
     *
     * @throws ACBrException excecao acionada ao construir o objeto.
     */
    public ACBrEAD() throws ACBrException {
    }
    /**
     * Cria um novo objeto com base no charset recebido.
     * 
     * @param pCharset charset utilizado na conversao para geracao do sintegra.
     */
    public ACBrEAD(Charset pCharset) throws ACBrException {
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
        int ret = ACBrEADInterop.INSTANCE.EAD_Create(handle);
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
            int ret = ACBrEADInterop.INSTANCE.EAD_Destroy(getHandle());
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
                int ret = ACBrEADInterop.INSTANCE.EAD_GetUltimoErro(getHandle(), buffer, LEN);

                lMessage = fromUTF8(buffer, ret);
                throw new ACBrException(lMessage);
            }
            case -2: {
                throw new ACBrException("ACBr EAD não inicializado.");
            }
        }
    }
	
    // </editor-fold>       
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta a chave privada e um Wrapper para o evento 
     * {@see ACBrEAD#addOnGetChavePrivada}
     * @param pChavePrivada chave privada.
     */
    public void setChavePrivada(final String pChavePrivada) {
        addOnGetChavePrivada(new ACBrEventListener<EADChavePrivadaEventObject>() {
            @Override
            public void notification(EADChavePrivadaEventObject e) {
                e.setKey(pChavePrivada);
            }
        });        
    }
    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Seta a chave publica e um Wrapper para o evento 
     * {@see ACBrEAD#addOnGetChavePublica}
     * @param pChavePublica chave publica.
     */
    public void setChavePublica(final String pChavePublica) {
        addOnGetChavePublica(new ACBrEventListener<EADChavePublicaEventObject>() {
            @Override
            public void notification(EADChavePublicaEventObject e) {
                e.setKey(pChavePublica);
            }
        });
    } 
    
    /**
     * Obtem a versao do OpenSSL
     * 
     * @return
     * @throws ACBrException 
     */
    public String getOpenSSL_Version() throws ACBrException {
        ByteBuffer lVersao = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrEADInterop.INSTANCE.EAD_GetOpenSSL_Version(getHandle(), lVersao, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lVersao, ret);
    }    
    /**
     * Obtem informacoes sobre a biblioteca.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getAbout() throws ACBrException {
        ByteBuffer lAbout = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrEADInterop.INSTANCE.EAD_GetAbout(getHandle(), lAbout, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lAbout, ret);
    }    
    
    /**
     * Realiza a geracao das chaves publica/privada para assinatura dos arquivos.
     * 
     * @return chave geradas.
     * @throws ACBrException 
     */
    public Chaves gerarChaves() throws ACBrException {
        final int BUFFER_LEN = 1024;
        ByteBuffer lChavePublica = ByteBuffer.allocate(BUFFER_LEN);
        ByteBuffer lChavePrivada = ByteBuffer.allocate(BUFFER_LEN);

        int ret = ACBrEADInterop.INSTANCE.EAD_GerarChaves(getHandle(), lChavePublica, lChavePrivada, BUFFER_LEN);
        checkResult(ret);

        return new Chaves(fromUTF8(lChavePublica, 1024), fromUTF8(lChavePrivada, 1024));
    }
    
    /**
     * Calcula o expoente e modulo do EAD.
     * 
     * @return
     * @throws ACBrException 
     */
    public ModuloExpoente calcularModuloeExpoente() throws ACBrException {
        final int BUFFER_LEN = 1024;
        ByteBuffer lModulo = ByteBuffer.allocate(BUFFER_LEN);
        ByteBuffer lExpoente = ByteBuffer.allocate(BUFFER_LEN);

        int ret = ACBrEADInterop.INSTANCE.EAD_CalcularModuloeExpoente(getHandle(), lModulo, lExpoente, BUFFER_LEN);
        checkResult(ret);

        return new ModuloExpoente(fromUTF8(lModulo, ret), fromUTF8(lExpoente, ret));    
    }
    
    /**
     * @see ACBrEAD#gerarXMLeECFc(java.lang.String, java.lang.String) 
     */
    public void gerarXMLeECFc(String pNomeSH) throws ACBrException {
        gerarXMLeECFc(pNomeSH, "");
    }

    /**
     * Realiza a geracao do arquivo xml eECFc.
     * 
     * @param pNomeSH nome da softhouse.
     * @param pCaminhoArquivo caminho para geracao do arquivo.
     * @throws ACBrException 
     */
    public void gerarXMLeECFc(String pNomeSH, String pCaminhoArquivo) throws ACBrException {
        int ret = ACBrEADInterop.INSTANCE.EAD_GerarXMLeECFc(getHandle(), toUTF8(pNomeSH), toUTF8(pCaminhoArquivo));
        checkResult(ret);
    }    
    
    /**
     * Realiza a conversao de eECFc para OpenSSL.
     * 
     * @param pArquivo arquivo a ser convertido.
     * @return
     * @throws ACBrException 
     */
    public String converteXMLeECFcParaOpenSSL(String pArquivo) throws ACBrException {
        final int BUFFER_LEN = 512;
        ByteBuffer lChavePublica = ByteBuffer.allocate(BUFFER_LEN);
        int ret = ACBrEADInterop.INSTANCE.EAD_ConverteXMLeECFcParaOpenSSL(getHandle(), toUTF8(pArquivo), lChavePublica, BUFFER_LEN);
        checkResult(ret);
        return fromUTF8(lChavePublica, ret);
    }    
    
    /**
     * Calcula o hash para o arquivo informado com base no algoritmo fornecido.
     * 
     * @param pArquivo arquivo que tera o hash calculado.
     * @param pHashType tipo para calculo do hash.
     * @return
     * @throws ACBrException 
     */
    public String calcularHashArquivo(String pArquivo, EADDigest pHashType) throws ACBrException {
        final int BUFFER_LEN = 128;
        ByteBuffer lHash = ByteBuffer.allocate(BUFFER_LEN);
        int ret = ACBrEADInterop.INSTANCE.EAD_CalcularHashArquivo(getHandle(), toUTF8(pArquivo), pHashType.getCodigo(), lHash, BUFFER_LEN);
        checkResult(ret);
        return fromUTF8(lHash, ret);
    }  
    
    /**
     * @see ACBrEAD#calcularHash(java.lang.String, jACBrFramework.ead.EADDigest) 
     */
    public List<String> calcularHash(List<String> pAstring, EADDigest pHashType) throws ACBrException {
        List<String> lRetorno = new ArrayList<String>();
        String[] lHash = calcularHash(pAstring.toArray(new String[pAstring.size()]), pHashType);
        lRetorno.addAll(Arrays.asList(lHash));
        return lRetorno;
    }

    /**
     * @see ACBrEAD#calcularHash(java.lang.String, jACBrFramework.ead.EADDigest) 
     */
    public String[] calcularHash(String[] pAString, EADDigest pHashType) throws ACBrException {
        String[] lRetorno = new String[pAString.length];
        for (int i = 0; i < pAString.length; i++) {
            lRetorno[i] = calcularHash(pAString[i], pHashType);
        }
        return lRetorno;
    }

    /**
     * Calcula o hash para a string recebida.
     * 
     * @param pAString string que tera o hash calculado.
     * @param pHashType tipo de hash a ser aplicado.
     * @return
     * @throws ACBrException 
     */
    public String calcularHash(String pAString, EADDigest pHashType) throws ACBrException {
        final int BUFFER_LEN = 128;
        ByteBuffer lHash = ByteBuffer.allocate(BUFFER_LEN);
        int ret = ACBrEADInterop.INSTANCE.EAD_CalcularHash(getHandle(), toUTF8(pAString), 
                pHashType.getCodigo(), lHash, BUFFER_LEN);
        checkResult(ret);
        return fromUTF8(lHash, ret);
    }  
    
    /**
     * Calcula o EAD para o arquivo recebido.
     * 
     * @param pArquivo arquivo que tera o EAD calculado.
     * @return EAD associado ao arquivo.
     * @throws ACBrException 
     */
    public String calcularEADArquivo(String pArquivo) throws ACBrException {
        final int BUFFER_LEN = 1024;
        ByteBuffer lEAD = ByteBuffer.allocate(BUFFER_LEN);
        int ret = ACBrEADInterop.INSTANCE.EAD_CalcularEADArquivo(getHandle(), toUTF8(pArquivo), lEAD, BUFFER_LEN);
        checkResult(ret);
        return fromUTF8(lEAD, ret);
    }   
    
    /**
     * @see ACBrEAD#calcularEAD(java.lang.String[]) 
     */
    public String calcularEAD(List<String> pAString) throws ACBrException {
        return calcularEAD(pAString.toArray(new String[pAString.size()]));
    }

    /**
     * Realiza o calculo do EAD para as strings recebidas.
     * 
     * @param pAString strings para calculo do EAD.
     * @return EAD calculado.
     * @throws ACBrException 
     */
    public String calcularEAD(String[] pAString) throws ACBrException {
        final int BUFFER_LEN = 256;
        ByteBuffer lEAD = ByteBuffer.allocate(BUFFER_LEN);
        int ret = ACBrEADInterop.INSTANCE.EAD_CalcularEAD(getHandle(), toUTF8(pAString), lEAD, BUFFER_LEN);
        checkResult(ret);
        return fromUTF8(lEAD, ret);
    }
    
    /**
     * Calcula a chave publica.
     * 
     * @return chave publica calculada.
     * @throws ACBrException 
     */
    public String calcularChavePublica() throws ACBrException {
        final int BUFFER_LEN = 512;
        ByteBuffer lChavePublica = ByteBuffer.allocate(BUFFER_LEN);
        int ret = ACBrEADInterop.INSTANCE.EAD_CalcularChavePublica(getHandle(), lChavePublica, BUFFER_LEN);
        checkResult(ret);
        return fromUTF8(lChavePublica, ret);
    }

    /**
     * Assina um arquivo EAD.
     * 
     * @param pArquivo arquivo a ser assinado.
     * @param pRemover indica remocao.
     * @return
     * @throws ACBrException 
     */
    public String assinarArquivoComEAD(String pArquivo, boolean pRemover) throws ACBrException {
        final int BUFFER_LEN = 1024;
        ByteBuffer lEAD = ByteBuffer.allocate(BUFFER_LEN);
        int ret = ACBrEADInterop.INSTANCE.EAD_AssinarArquivoComEAD(getHandle(), toUTF8(pArquivo), 
                pRemover, lEAD, BUFFER_LEN);
        checkResult(ret);
        return fromUTF8(lEAD, ret);
    }    
    
    /**
     * Verifica assinatura do arquivo EAD.
     * 
     * @param pArquivo arquivo a ser verificado.
     * @return
     * @throws ACBrException 
     */
    public boolean verificarEADArquivo(String pArquivo) throws ACBrException {
        int ret = ACBrEADInterop.INSTANCE.EAD_VerificarEADArquivo(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
        return ret != 0;
    }    
    
    /**
     * Verifica a assinatura EAD para a string recebida.
     * 
     * @param pAString string a ser verificada.
     * @return
     * @throws ACBrException 
     */
    public boolean verificarEAD(String pAString) throws ACBrException {
        int ret = ACBrEADInterop.INSTANCE.EAD_VerificarEAD(getHandle(), toUTF8(pAString));
        checkResult(ret);
        return ret != 0;
    }   
    
    /**
     * Realiza remocao da assinatura EAD do arquivo.
     * 
     * @param pArquivo arquivo para remocao.
     * @throws ACBrException 
     */
    public void removeEADArquivo(String pArquivo) throws ACBrException {
        int ret = ACBrEADInterop.INSTANCE.EAD_RemoveEADArquivo(getHandle(), toUTF8(pArquivo));
        checkResult(ret);
    }
    
    /**
     * Calcula o MD5 para o arquivo recebido.
     * 
     * @param pArquivo arquivo que sera calculado o MD5.
     * @return
     * @throws ACBrException 
     */
    public String MD5FromFile(String pArquivo) throws ACBrException {
        final int BUFFER_LEN = 256;
        ByteBuffer md5 = ByteBuffer.allocate(BUFFER_LEN);
        int ret = ACBrEADInterop.INSTANCE.EAD_MD5FromFile(getHandle(), toUTF8(pArquivo), md5, BUFFER_LEN);
        checkResult(ret);
        return fromUTF8(md5, ret);
    }  
    
    /**
     * Realiza o calculo do MD5 para a string recebida.
     * 
     * @param pAString string para calcular o MD5.
     * @return
     * @throws ACBrException 
     */
    public String MD5FromString(String pAString) throws ACBrException {
        final int BUFFER_LEN = 256;
        ByteBuffer md5 = ByteBuffer.allocate(BUFFER_LEN);
        int ret = ACBrEADInterop.INSTANCE.EAD_MD5FromString(getHandle(), toUTF8(pAString), md5, BUFFER_LEN);
        checkResult(ret);
        return fromUTF8(md5, ret);
    }    
    // </editor-fold>       
	//<editor-fold defaultstate="collapsed" desc="onGetChavePrivada">
    /**
     * Adiciona o listener para obtencao da chave de privada.
     * 
     * @param pListener 
     */
	public void addOnGetChavePrivada(ACBrEventListener<EADChavePrivadaEventObject> pListener) {
		if (!hasListeners("onGetChavePrivada")) {
			ACBrEADInterop.INSTANCE.EAD_SetOnGetChavePrivada(getHandle(), new ACBrEADInterop.GetChavePrivadaCallback() {
                @Override
                public String invoke() {
                    return onGetChavePrivada();
                }
			});
		}
		addListener("onGetChavePrivada", pListener);
	}

    /**
     * Remove o listener associado.
     * 
     * @param pListener 
     */
	public void removeOnGetChavePrivada(ACBrEventListener<EADChavePrivadaEventObject> pListener) {
		removeListener("onGetChavePrivada", pListener);
		if (!hasListeners("onGetChavePrivada")) {
			ACBrEADInterop.INSTANCE.EAD_SetOnGetChavePrivada(getHandle(), null);
		}
	}

    /**
     * Chave privada associada ao arquivo.
     * 
     * @return 
     */
	private String onGetChavePrivada() {
		EADChavePrivadaEventObject e = new EADChavePrivadaEventObject(this, "");
		notifyListeners("onGetChavePrivada", e);
		return e.getKey();
	}
	//</editor-fold>    
	//<editor-fold defaultstate="collapsed" desc="onGetChavePublica">
    /**
     * Adiciona o listener para obtencao da chave de publica.
     * 
     * @param pListener 
     */
	public void addOnGetChavePublica(ACBrEventListener<EADChavePublicaEventObject> pListener) {
		if (!hasListeners("onGetChavePublica")) {
			ACBrEADInterop.INSTANCE.EAD_SetOnGetChavePublica(getHandle(), new ACBrEADInterop.GetChavePublicaCallback() {
                @Override
                public String invoke() {
                    return onGetChavePublica();
                }
			});
		}
		addListener("onGetChavePublica", pListener);
	}

    /**
     * Remove o listener associado.
     * 
     * @param pListener 
     */
	public void removeOnGetChavePublica(ACBrEventListener<EADChavePublicaEventObject> pListener) {
		removeListener("onGetChavePublica", pListener);
		if (!hasListeners("onGetChavePublica")) {
			ACBrEADInterop.INSTANCE.EAD_SetOnGetChavePublica(getHandle(), null);
		}
	}

    /**
     * Chave publica associada ao arquivo.
     * 
     * @return 
     */
	private String onGetChavePublica() {
		EADChavePublicaEventObject e = new EADChavePublicaEventObject(this, "");
		notifyListeners("onGetChavePublica", e);
		return e.getKey();
	}
	//</editor-fold>    
    
}