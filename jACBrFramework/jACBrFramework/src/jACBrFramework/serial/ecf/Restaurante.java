package jACBrFramework.serial.ecf;

import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrECFInterop;
import java.nio.ByteBuffer;

/**
 * Controle da impressao do rodape de dados de restaurante.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/12/2013 11:42:00, revisao: $Id$
 */
public class Restaurante {
    
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
    Restaurante(ACBrECF pEcf) throws ACBrException {
        this.ecf = pEcf;
    }
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">   
    /**
     * Indica que as informacoes referente a restaurantes.
     * 
     * @param pImprimir indica que a impressao deve ser realizada.
     * @throws ACBrException 
     */
    public void setImprimir(boolean pImprimir) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Restaurante_SetImprimir(ecf.getHandle(), pImprimir);
        ecf.checkResult(ret);
    }    

    /**
     * Verifica se havera impressao dos dados de restaurante.
     * 
     * @return indica se a impressao sera ou nao realizada.
     * @throws ACBrException 
     */
    public boolean isImprimir() throws ACBrException {
        return ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Restaurante_GetImprimir(ecf.getHandle()) != 0;
    }      
    
    /**
     * Seta a Ecf associada.
     * 
     * @param pEcf identificador da Ecf.
     * @throws ACBrException 
     */
    public void setEcf(int pEcf) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Restaurante_SetECF(ecf.getHandle(), pEcf);
        ecf.checkResult(ret);
    }    

    /**
     * Recupera o identificador da Ecf.
     * 
     * @return identificador da Ecf.
     * @throws ACBrException 
     */
    public int getEcf() throws ACBrException {
        return ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Restaurante_GetECF(ecf.getHandle());
    }      

    /**
     * Seta o coo associado a operacao.
     * 
     * @param pCoo contador de ordem da operacao.
     * @throws ACBrException 
     */
    public void setCoo(int pCoo) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Restaurante_SetCOO(ecf.getHandle(), pCoo);
        ecf.checkResult(ret);
    }    

    /**
     * Recupera o coo associado a operacao.
     * 
     * @return coo associado.
     * @throws ACBrException 
     */
    public int getCoo() throws ACBrException {
        return ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Restaurante_GetCOO(ecf.getHandle());
    }      
    
    /**
     * Seta o contador especifico de relatorio gerencial.
     * 
     * @param pCer seta o valor do cer.
     * @throws ACBrException 
     */
    public void setCer(int pCer) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Restaurante_SetCER(ecf.getHandle(), pCer);
        ecf.checkResult(ret);
    }    

    /**
     * Obtem o contador especifico de relatorio gerencial.
     * 
     * @return cer associado.
     * @throws ACBrException 
     */
    public int getCer() throws ACBrException {
        return ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Restaurante_GetCER(ecf.getHandle());
    }      
    
    /**
     * Seta a mesa associada.
     * 
     * @param pMesa mesa referenciada no rodape.
     * @throws ACBrException 
     */
    public void setMesa(String pMesa) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Restaurante_SetMesa(ecf.getHandle(), ecf.toUTF8(pMesa));
        ecf.checkResult(ret);
    }    
    
    /**
     * Recupera o identificador da mesa.
     * 
     * @return identificador da mesa.
     * @throws ACBrException 
     */
    public String getMesa() throws ACBrException {
        ByteBuffer lMesa = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_Restaurante_GetMesa(ecf.getHandle(), lMesa, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lMesa, ret);
    }
    // </editor-fold>

}