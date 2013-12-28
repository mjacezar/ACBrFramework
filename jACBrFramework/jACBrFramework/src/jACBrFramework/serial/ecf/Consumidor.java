package jACBrFramework.serial.ecf;

import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrECFInterop;
import java.nio.ByteBuffer;

/**
 * Informacoes relativas ao consumidor.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/12/2013 13:44:02, revisao: $Id$
 */
public class Consumidor {
    
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
    Consumidor(ACBrECF pEcf) throws ACBrException {
        this.ecf = pEcf;
    }
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">   
    /**
     * Obtem o documento de identificacao do consumidor.
     * 
     * @return documento de identificacao do consumidor.
     * @throws ACBrException 
     */
    public String getDocumento() throws ACBrException {
        ByteBuffer lDocumento = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_Consumidor_GetDocumento(ecf.getHandle(), lDocumento, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lDocumento, ret);
    }

    /**
     * Nome do consumidor.
     * 
     * @return nome do consumidor.
     * @throws ACBrException 
     */
    public String getNome() throws ACBrException {
        ByteBuffer lNome = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_Consumidor_GetNome(ecf.getHandle(), lNome, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lNome, ret);
    }
    
    /**
     * Endereco do consumidor.
     * 
     * @return endereco do consumidor.
     * @throws ACBrException 
     */
    public String getEndereco() throws ACBrException {
        ByteBuffer lEndereco = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_Consumidor_GetEndereco(ecf.getHandle(), lEndereco, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lEndereco, ret);
    }  
    
    /**
     * Verifica se houve atribuicao de consumidor.
     * 
     * @return indica se houve atribuicao de consumidor.
     * @throws ACBrException 
     */
    public boolean isAtribuido() throws ACBrException {
        return ACBrECFInterop.INSTANCE.ECF_Consumidor_GetAtribuido(ecf.getHandle()) != 0;
    }   
    
    /**
     * Indica se as informacoes foram enviadas.
     * 
     * @param pEnviado indica que as informacoes foram enviadas.
     * @throws ACBrException 
     */
    public void setEnviado(boolean pEnviado) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_Consumidor_SetEnviado(ecf.getHandle(), pEnviado);
        ecf.checkResult(ret);
    }  
    
    /**
     * Verifica se as informacoes foram enviadas.
     * 
     * @return indica se as informacoes foram enviadas.
     * @throws ACBrException 
     */
    public boolean isEnviado() throws ACBrException {
        return ACBrECFInterop.INSTANCE.ECF_Consumidor_GetEnviado(ecf.getHandle()) != 0;
    }       
    
    /**
     * Realiza a atribuicao das informacoes do consumidor.
     * 
     * @param pCpfCnpj documento de identificacao do consumidor.
     * @param pNome nome do consumidor.
     * @param pEndereco endereco do consumidor.
     * @throws ACBrException 
     */
    public void atribuiConsumidor(String pCpfCnpj, String pNome, String pEndereco) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_Consumidor_AtribuiConsumidor(ecf.getHandle(), 
                ecf.toUTF8(pCpfCnpj), ecf.toUTF8(pNome), ecf.toUTF8(pEndereco));
        ecf.checkResult(ret);
    } 
    
    /**
     * Reinicia as informacoes do consumidor.
     * 
     * @throws ACBrException 
     */
    public void zera() throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_Consumidor_Zera(ecf.getHandle());
        ecf.checkResult(ret);
    }    
    // </editor-fold>

}