package jACBrFramework.serial.ecf;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrECFInterop;

/** 
 * Informacoes do rodape para nota fiscal legal do DF.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/12/2013 11:29:30, revisao: $Id$
 */
public class RodapeNotaLegalDF {
    
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
    RodapeNotaLegalDF(ACBrECF pEcf) throws ACBrException {
        this.ecf = pEcf;
    }
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">   
    /**
     * Indica que as informacoes referente ao DF deve ser impressa no cupom.
     * 
     * @param pImprimir indica que a impressao deve ser realizada.
     * @throws ACBrException 
     */
    public void setImprimir(boolean pImprimir) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_NotaLegalDF_SetImprimir(ecf.getHandle(), pImprimir);
        ecf.checkResult(ret);
    }    

    /**
     * Verifica se havera impressao da nota fiscal legal do DF.
     * 
     * @return indica se a impressao sera ou nao realizada.
     * @throws ACBrException 
     */
    public boolean isImprimir() throws ACBrException {
        return ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_NotaLegalDF_GetImprimir(ecf.getHandle()) != 0;
    }      
    
    /**
     * Indica que ha programa de credito de nota fiscal legal.
     * 
     * @param pProgramaDeCredito indica programa de credito.
     * @throws ACBrException 
     */
    public void setProgramaDeCredito(boolean pProgramaDeCredito) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_NotaLegalDF_SetProgramaDeCredito(ecf.getHandle(), pProgramaDeCredito);
        ecf.checkResult(ret);
    }    

    /**
     * Verifica se ha programa de credito.
     * 
     * @return indica se ha ou nao programa de credito.
     * @throws ACBrException 
     */
    public boolean isProgramaDeCredito() throws ACBrException {
        return ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_NotaLegalDF_GetProgramaDeCredito(ecf.getHandle()) != 0;
    }      
    
    /**
     * Seta o valor de ICMS.
     * 
     * @param pValor valor de ICMS.
     * @throws ACBrException 
     */
    public void setValorICMS(double pValor) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_NotaLegalDF_SetValorICMS(ecf.getHandle(), pValor);
        ecf.checkResult(ret);
    }
    
    /**
     * Obtem o valor do ICMS.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getValorICMS() throws ACBrException {
        DoubleByReference lValorIcms = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_NotaLegalDF_GetValorICMS(ecf.getHandle(), lValorIcms);
        ecf.checkResult(ret);
        return lValorIcms.getValue();
    }   
        
    /**
     * Seta o valor de ISS.
     * 
     * @param pValor valor de ISS.
     * @throws ACBrException 
     */
    public void setValorISS(double pValor) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_NotaLegalDF_SetValorISS(ecf.getHandle(), pValor);
        ecf.checkResult(ret);
    }
    
    /**
     * Obtem o valor do ISS.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getValorISS() throws ACBrException {
        DoubleByReference lValorIss = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_NotaLegalDF_GetValorISS(ecf.getHandle(), lValorIss);
        ecf.checkResult(ret);
        return lValorIss.getValue();
    }   
    // </editor-fold>
    
}