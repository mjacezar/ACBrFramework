package jACBrFramework.aac;

import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrAACInterop;
import java.nio.ByteBuffer;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 15:12:55, revisao: $Id$
 */
public class ArquivoListaAutenticados extends ACBrAACWrapper {

    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Cria um novo objeto empresa.
     * 
     * @param pAac instancia para auxiliar a criptografia.
     */
    ArquivoListaAutenticados(ACBrAAC pAac) {
        super(pAac);        
    }    
    // </editor-fold>     
    //<editor-fold defaultstate="collapsed" desc="Components Methods">    
    /**
     * Nome do arquivo.
     * 
     * @param pNome
     * @throws ACBrException 
     */
    public void setNome(String pNome) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_ArquivoListaAutenticados_SetNome(getHandle(), toUTF8(pNome));
        checkResult(ret);
    }
    
    /**
     * Nome do arquivo.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNome() throws ACBrException {
        ByteBuffer lNome = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_ArquivoListaAutenticados_GetNome(getHandle(), lNome, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lNome, ret);
    }         
    
    /**
     * MD5
     * 
     * @param pMD5
     * @throws ACBrException 
     */
    public void setMD5(String pMD5) throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_ArquivoListaAutenticados_SetMD5(getHandle(), toUTF8(pMD5));
        checkResult(ret);
    }
    
    /**
     * MD5
     * 
     * @return
     * @throws ACBrException 
     */
    public String getMD5() throws ACBrException {
        ByteBuffer lMd5 = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_ArquivoListaAutenticados_GetMD5(getHandle(), lMd5, STR_BUFFER_LEN);
        checkResult(ret);   
        return fromUTF8(lMd5, ret);
    }
    // </editor-fold>     
    
}