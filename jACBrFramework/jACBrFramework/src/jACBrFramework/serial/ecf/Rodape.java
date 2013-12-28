package jACBrFramework.serial.ecf;

import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrECFInterop;
import java.nio.ByteBuffer;

/**
 * Contem as informacoes a serem impressas no rodape do cupom.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/12/2013 11:28:26, revisao: $Id$
 */
public class Rodape {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Instancia ECF para obter o handler.
     */
    ACBrECF ecf = null;
    /**
     * Informacoes relativas a nota fiscais legal do DF.
     */
    private RodapeNotaLegalDF notaLegalDF;
    /**
     * Informacoes associadas a bares, restaurantes e similares.
     */
    private Restaurante restaurante;
    /**
     * Informacoes relativas aos valores aproximados de impostos.
     */
    private Imposto imposto;
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
    Rodape(ACBrECF pEcf) throws ACBrException {
        this.ecf = pEcf;
        notaLegalDF = new RodapeNotaLegalDF(pEcf);
        restaurante = new Restaurante(pEcf);
        imposto = new Imposto(pEcf);
    }
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">   
    /**
     * Seta o numero dav associado a venda.
     * 
     * @param pDav documento auxiliar de venda.
     * @throws ACBrException 
     */
    public void setDav(String pDav) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_SetDav(ecf.getHandle(), ecf.toUTF8(pDav));
        ecf.checkResult(ret);
    }    
    
    /**
     * Recupera o DAV.
     * 
     * @return documento auxiliar de venda.
     * @throws ACBrException 
     */
    public String getDav() throws ACBrException {
        ByteBuffer lDav = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_GetDav(ecf.getHandle(), lDav, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lDav, ret);
    }    

    /**
     * Seta o numero davos associado a venda.
     * 
     * @param pDavOs documento auxiliar de venda ordem serviço.
     * @throws ACBrException 
     */
    public void setDavOs(String pDavOs) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_SetDavOs(ecf.getHandle(), ecf.toUTF8(pDavOs));
        ecf.checkResult(ret);
    }    
    
    /**
     * Recupera o DAV.
     * 
     * @return documento auxiliar de venda ordem serviço.
     * @throws ACBrException 
     */
    public String getDavOs() throws ACBrException {
        ByteBuffer lDavOs = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_GetDavOs(ecf.getHandle(), lDavOs, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lDavOs, ret);
    }    

    /**
     * Seta o MD5 a ser impresso.
     * 
     * @param pMD5 md5 para impressao.
     * @throws ACBrException 
     */
    public void setMD5(String pMD5) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_SetMD5(ecf.getHandle(), ecf.toUTF8(pMD5));
        ecf.checkResult(ret);
    }    
    
    /**
     * Recupera o MD5 que sera impresso.
     * 
     * @return md5 a ser impresso.
     * @throws ACBrException 
     */
    public String getMD5() throws ACBrException {
        ByteBuffer lMD5 = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_GetDavOs(ecf.getHandle(), lMD5, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lMD5, ret);
    }    
    
    /**
     * Seta o numero de prevenda associada a venda.
     * 
     * @param pPreVenda numero da prevenda.
     * @throws ACBrException 
     */
    public void setPreVenda(String pPreVenda) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_SetPreVenda(ecf.getHandle(), ecf.toUTF8(pPreVenda));
        ecf.checkResult(ret);
    }    
    
    /**
     * Recupera o numero da prevenda
     * 
     * @return prevenda associada.
     * @throws ACBrException 
     */
    public String getPreVenda() throws ACBrException {
        ByteBuffer lPreVenda = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_GetPreVenda(ecf.getHandle(), lPreVenda, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lPreVenda, ret);
    }    
        
    /**
     * Seta a utilizacao do cupom mania.
     * 
     * @param pCupomMania indica que o cupom mania deve ser utilizado.
     * @throws ACBrException 
     */
    public void setCupomMania(boolean pCupomMania) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_SetCupomMania(ecf.getHandle(), pCupomMania);
        ecf.checkResult(ret);
    }    

    /**
     * Verifica se o sistema utiliza cupom mania.
     * 
     * @return indica a utilizacao do cupom mania.
     * @throws ACBrException 
     */
    public boolean isCupomMania() throws ACBrException {
        return ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_GetCupomMania(ecf.getHandle()) != 0;
    }
    
    /**
     * Seta a utilizacao do minas legal.
     * 
     * @param pMinasLegal indica que o minas legal deve ser utilizado.
     * @throws ACBrException 
     */
    public void setMinasLegal(boolean pMinasLegal) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_SetMinasLegal(ecf.getHandle(), pMinasLegal);
        ecf.checkResult(ret);
    }    

    /**
     * Verifica se o sistema utiliza minas legal.
     * 
     * @return indica a utilizacao do minas legal.
     * @throws ACBrException 
     */
    public boolean isMinasLegal() throws ACBrException {
        return ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_GetMinasLegal(ecf.getHandle()) != 0;
    }  
    
    /**
     * Seta a utilizacao do paraiba legal.
     * 
     * @param pParaibaLegal indica que o paraiba legal deve ser utilizado.
     * @throws ACBrException 
     */
    public void setParaibaLegal(boolean pParaibaLegal) throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_SetParaibaLegal(ecf.getHandle(), pParaibaLegal);
        ecf.checkResult(ret);
    }    

    /**
     * Verifica se o sistema utiliza paraiba legal.
     * 
     * @return indica a utilizacao do paraiba legal.
     * @throws ACBrException 
     */
    public boolean isParaibaLegal() throws ACBrException {
        return ACBrECFInterop.INSTANCE.ECF_InfoRodapeCupom_GetParaibaLegal(ecf.getHandle()) != 0;
    }      
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">
    /**
     * Informacoes relativas a nota fiscais legal do DF.
     * @return the notaLegalDF
     */
    public RodapeNotaLegalDF getNotaLegalDF() {
        return notaLegalDF;
    }

    /**
     * Informacoes associadas a bares, restaurantes e similares.
     * @return the restaurante
     */
    public Restaurante getRestaurante() {
        return restaurante;
    }

    /**
     * Informacoes relativas aos valores aproximados de impostos.
     * @return the imposto
     */
    public Imposto getImposto() {
        return imposto;
    }
    // </editor-fold>    
    
}