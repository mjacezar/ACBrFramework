package jACBrFramework.tefd;

import com.sun.jna.ptr.DoubleByReference;
import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrComposedClass;
import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrTEFInterop;
import java.util.ArrayList;
import java.util.Iterator;

/**
 * Controle de respostas pendentes.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/02/2014 17:26:23, revisao: $Id$
 */
public class RespostasPendentes extends ACBrComposedClass implements Iterable<Resp> {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Iterator que sera processado.
     */
    private ArrayList<Resp> resp = null;
    // </editor-fold>       
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    RespostasPendentes(ACBrTEFD pParent, int pComposedHandle) throws ACBrException {
        super(pParent, pComposedHandle);
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Methods">
    @Override
    public Iterator<Resp> iterator() {
        resp = new ArrayList<Resp>();
        try {
            int lCount = count();
            for (int i = 0; i < lCount; i++) {
                resp.add(get(i));
            }
            return resp.iterator();
        } catch (ACBrException e) {
            e.printStackTrace();
        }
        return null;
    }
    // </editor-fold>   
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Recupera o objeto mandatario associado a resposta.
     * 
     * @return 
     */
    @Override
    public ACBrTEFD getParent() {
        return (ACBrTEFD)super.getParent();
    }
    
    /**
     * Verifica a quantidade de resp.
     * 
     * @return 
     */
    public int count() throws ACBrException {
        int ret = ACBrTEFInterop.INSTANCE.TEF_RespostasPendentes_GetCount(getHandle(), getComposedHandler());
        checkResult(ret);
        return ret;
    }    
    
    /**
     * Recupera o saldo restante.
     * 
     * @return saldo restante.
     * @throws ACBrException 
     */
    public double getSaldoRestante() throws ACBrException {
        DoubleByReference lSaldoRestante = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_RespostasPendentes_GetSaldoRestante(getHandle(), getComposedHandler(), lSaldoRestante);
        checkResult(ret);   
        return lSaldoRestante.getValue();
    }       
    
    /**
     * Recupera o total de desconto.
     * 
     * @return total de desconto.
     * @throws ACBrException 
     */
    public double getTotalDesconto() throws ACBrException {
        DoubleByReference lTotalDesconto = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_RespostasPendentes_GetTotalDesconto(getHandle(), getComposedHandler(), lTotalDesconto);
        checkResult(ret);   
        return lTotalDesconto.getValue();
    }       
    
    /**
     * Recupera o total pago.
     * 
     * @return total pago.
     * @throws ACBrException 
     */
    public double getTotalPago() throws ACBrException {
        DoubleByReference lTotalPago = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_RespostasPendentes_GetTotalPago(getHandle(), getComposedHandler(), lTotalPago);
        checkResult(ret);   
        return lTotalPago.getValue();
    }       
    
    /**
     * Recupera o saldo a pagar.
     * 
     * @return saldo a pagar.
     * @throws ACBrException 
     */
    public double getSaldoAPagar() throws ACBrException {
        DoubleByReference lSaldoAPagar = new DoubleByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_RespostasPendentes_GetSaldoAPagar(getHandle(), getComposedHandler(), lSaldoAPagar);
        checkResult(ret);   
        return lSaldoAPagar.getValue();
    }    
    
    /**
     * Obtem a resp pelo indice recebido.
     * 
     * @param pIndex indice para recuperacao da resp.
     * @return
     * @throws ACBrException 
     */
    public Resp get(int pIndex) throws ACBrException {
        IntByReference lRespHandler = new IntByReference();
        int ret = ACBrTEFInterop.INSTANCE.TEF_RespostasPendentes_GetItem(getHandle(), getComposedHandler(), pIndex, lRespHandler);
        checkResult(ret);
        return new Resp(this.getParent(), lRespHandler.getValue());
    }    
    // </editor-fold>
        
}