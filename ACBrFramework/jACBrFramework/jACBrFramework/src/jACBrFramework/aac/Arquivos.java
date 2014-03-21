package jACBrFramework.aac;

import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrAACInterop;
import java.util.ArrayList;
import java.util.Iterator;

/**
 * Representa a comunicacao com os arquivos criptografados.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 15:05:13, revisao: $Id$
 */
public class Arquivos extends ACBrAACWrapper implements Iterable<Arquivo> {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Iterator que sera processado.
     */
    private ArrayList<Arquivo> arquivos = null;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Cria um novo objeto empresa.
     * 
     * @param pAac instancia para auxiliar a criptografia.
     */
    Arquivos(ACBrAAC pAac) {
        super(pAac);        
    }    
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Methods">
    @Override
    public Iterator<Arquivo> iterator() {
        arquivos = new ArrayList<Arquivo>();
        try {
            int lCount = count();
            for (int i = 0; i < lCount; i++) {
                arquivos.add(get(i));
            }
            return arquivos.iterator();
        } catch (ACBrException e) {
            e.printStackTrace();
        }
        return null;
    }
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Verifica a quantidade de arquivos.
     * 
     * @return 
     */
    public int count() {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_OutrosArquivos_Count(getHandle());
    }
    
    /**
     * Obtem o arquivo pelo indice recebido.
     * 
     * @param pIndex indice para recuperacao do arquivo.
     * @return
     * @throws ACBrException 
     */
    public Arquivo get(int pIndex) throws ACBrException {
        ACBrAACInterop.TECFArquivo lItem = new ACBrAACInterop.TECFArquivo();
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_OutrosArquivos_Get(getHandle(), lItem, pIndex);
        checkResult(ret);

        Arquivo lAacArquivo = new Arquivo();
        lAacArquivo.setNome(fromUTF8(lItem.NOME_ARQUIVO));
        lAacArquivo.setMd5(fromUTF8(lItem.MD5));
        return lAacArquivo;        
    }
    
    /**
     * Limpa a lista de arquivos.
     * 
     * @throws ACBrException 
     */
    public void clear() throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_OutrosArquivos_Clear(getHandle());
        checkResult(ret);
    }
    
    /**
     * Cria um novo arquivo.
     * 
     * @param pArquivo registro a ser acrescido.
     * @throws ACBrException 
     */
    public void add(Arquivo pArquivo) throws ACBrException {
        ACBrAACInterop.TECFArquivo.ByValue lItem = new ACBrAACInterop.TECFArquivo.ByValue();
        lItem.NOME_ARQUIVO = toByte(pArquivo.getNome(), 51);
        lItem.MD5 = toByte(pArquivo.getMd5(), 33);

        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_OutrosArquivos_New(getHandle(), lItem);
        checkResult(ret);        
    }
    // </editor-fold>        
}