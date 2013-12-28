package jACBrFramework.serial.ecf;

import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrECFInterop;

/**
 * Configuracao de barras.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/12/2013 13:17:24, revisao: $Id$
 */
public class ConfigBarras {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Instancia ECF para obter o handler.
     */
    ACBrECF ecf = null;
    /**
     * Buffer para leitura dos dados.
     */
    protected final int STR_BUFFER_LEN = 256;
    // </editor-fold>       
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Cria um novo objeto para manipulacao dados da Altura.
     * 
     * @param pEcf instancia para auxiliar a comunicacao com o Acbr.
     */
    ConfigBarras(ACBrECF pEcf) throws ACBrException {
        this.ecf = pEcf;
    }
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">   
    /**
     * Indica a exibicao do codigo.
     * 
     * @param pMostrarCodigo indica se o codigo deve ser exibido.
     * @throws ACBrException 
     */
    public void setMostrarCodigo(boolean pMostrarCodigo) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_ConfigBarras_SetMostrarCodigo(ecf.getHandle(), pMostrarCodigo);
        ecf.checkResult(ret);  
    }    

    /**
     * Verifica se o codigo sera exibido.
     * 
     * @return indica se o codigo deve ser exibido.
     * @throws ACBrException 
     */
    public boolean isMostrarCodigo() throws ACBrException {
        return ACBrECFInterop.INSTANCE.ECF_ConfigBarras_GetMostrarCodigo(ecf.getHandle()) != 0;
    }      
    
    /**
     * Seta a altura configurada.
     * 
     * @param pAltura altura configurada.
     * @throws ACBrException 
     */
    public void setAltura(int pAltura) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_ConfigBarras_SetAltura(ecf.getHandle(), pAltura);
        ecf.checkResult(ret);  
    }    

    /**
     * Recupera a altura configurada.
     * 
     * @return altura configurada.
     * @throws ACBrException 
     */
    public int getAltura() throws ACBrException {
        IntByReference lAltura = new IntByReference();                
        int ret = ACBrECFInterop.INSTANCE.ECF_ConfigBarras_GetAltura(ecf.getHandle(), lAltura);
        ecf.checkResult(ret);  
        return lAltura.getValue();
    }       
    
    /**
     * Seta a altura da linha.
     * 
     * @param pLarguraLinha largura da linha.
     * @throws ACBrException 
     */
    public void setLarguraLinha(int pLarguraLinha) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_ConfigBarras_SetLarguraLinha(ecf.getHandle(), pLarguraLinha);
        ecf.checkResult(ret);  
    }    

    /**
     * Recupera a largura da linha.
     * 
     * @return largura da linha.
     * @throws ACBrException 
     */
    public int getLarguraLinha() throws ACBrException {
        IntByReference lLarguraLinha = new IntByReference();                
        int ret = ACBrECFInterop.INSTANCE.ECF_ConfigBarras_GetLarguraLinha(ecf.getHandle(), lLarguraLinha);
        ecf.checkResult(ret);  
        return lLarguraLinha.getValue();
    } 
    // </editor-fold>    

}