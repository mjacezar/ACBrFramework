package jACBrFramework.serial.ecf;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrECFInterop;
import java.nio.ByteBuffer;

/**
 * Representa os impostos de acordo com a lei de transparencia fiscal.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/12/2013 12:44:22, revisao: $Id$
 */
public class Imposto {
    
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
     * Cria um novo objeto para manipulacao dados da ECF.
     * 
     * @param pEcf instancia para auxiliar a comunicacao com o Acbr.
     */
    Imposto(ACBrECF pEcf) throws ACBrException {
        this.ecf = pEcf;
    }
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">   
    /**
     * Seta o texto associado aos impostos.
     * 
     * @param pTexto texto a ser impresso.
     * @throws ACBrException 
     */
    public void setTexto(String pTexto) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Imposto_SetTexto(ecf.getHandle(), ecf.toUTF8(pTexto));
        ecf.checkResult(ret);
    }    
    
    /**
     * Recupera o texto associado a impressao dos impostos.
     * 
     * @return texto associado a impressao dos impostos.
     * @throws ACBrException 
     */
    public String getTexto() throws ACBrException {
        ByteBuffer lTexto = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Imposto_GetTexto(ecf.getHandle(), lTexto, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lTexto, ret);
    }
    
    /**
     * Seta a fonte responsavel pela apuracao do valor aproximado de impostos.
     * 
     * @param pFonte fonte apuradora.
     * @throws ACBrException 
     */
    public void setFonte(String pFonte) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Imposto_SetFonte(ecf.getHandle(), ecf.toUTF8(pFonte));
        ecf.checkResult(ret);
    }    
    
    /**
     * Recupera a fonte associada ao rodape para impressao.
     * 
     * @return fonte dos valores aproximados de imposto.
     * @throws ACBrException 
     */
    public String getFonte() throws ACBrException {
        ByteBuffer lFonte = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Imposto_GetFonte(ecf.getHandle(), lFonte, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lFonte, ret);
    }
    
    /**
     * Seta o valor aproximado de impostos presente no cupom.
     * 
     * @param pValorAproximado valor aproximado de impostos.
     * @throws ACBrException 
     */
    public void setValorAproximado(double pValorAproximado) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Imposto_SetValorAproximado(ecf.getHandle(), pValorAproximado);
        ecf.checkResult(ret);
    }
    
    /**
     * Obtem o valor aproximado de impostos.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getValorAproximado() throws ACBrException {
        DoubleByReference lValorAproximado = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Imposto_GetValorAproximado(ecf.getHandle(), lValorAproximado);
        ecf.checkResult(ret);
        return lValorAproximado.getValue();
    }      
    // </editor-fold>

}