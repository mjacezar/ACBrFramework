package jACBrFramework.aac;

import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrAACInterop;
import java.util.ArrayList;
import java.util.Iterator;

/**
 * Identificacao das ECFs autorizadas.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 14:24:19, revisao: $Id$
 */
public class ECFs extends ACBrAACWrapper implements Iterable<AACECF> {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Iterator que sera processado.
     */
    private ArrayList<AACECF> ecfs = null;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Cria um novo objeto empresa.
     * 
     * @param pAac instancia para auxiliar a criptografia.
     */
    ECFs(ACBrAAC pAac) {
        super(pAac);        
    }    
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Methods">
    @Override
    public Iterator<AACECF> iterator() {
        ecfs = new ArrayList<AACECF>();
        try {
            int lCount = count();
            for (int i = 0; i < lCount; i++) {
                ecfs.add(get(i));
            }
            return ecfs.iterator();
        } catch (ACBrException e) {
            e.printStackTrace();
        }
        return null;
    }
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">
    /**
     * Verifica a quantidade de registros autorizados.
     * 
     * @return 
     */
    public int count() {
        return ACBrAACInterop.INSTANCE.AAC_IdentPaf_ECFsAutorizados_Count(getHandle());
    }
    
    /**
     * Obtem o ECF autorizado pelo indice recebido.
     * 
     * @param pIndex indice para recuperacao do ecf autorizado.
     * @return
     * @throws ACBrException 
     */
    public AACECF get(int pIndex) throws ACBrException {
        ACBrAACInterop.TECFAutorizado lItem = new ACBrAACInterop.TECFAutorizado();
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_ECFsAutorizados_Get(getHandle(), lItem, pIndex);
        checkResult(ret);

        AACECF aacECF = new AACECF();
        aacECF.setValorGT(lItem.ValorGT);
        aacECF.setNumeroSerie(fromUTF8(lItem.NumeroSerie));
        aacECF.setCni(lItem.CNI);
        aacECF.setCro(lItem.CRO);
        aacECF.setDtHrAtualizado(OleDate.fromOADate(lItem.DtHrAtualizado));
        return aacECF;        
    }
    
    /**
     * Limpa a lista de ECFs autorizados.
     * 
     * @throws ACBrException 
     */
    public void clear() throws ACBrException {
        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_ECFsAutorizados_Clear(getHandle());
        checkResult(ret);
    }
    
    /**
     * Cria um novo registro de autorizacao.
     * 
     * @param pAacECF registro a ser acrescido.
     * @throws ACBrException 
     */
    public void add(AACECF pAacECF) throws ACBrException {
        ACBrAACInterop.TECFAutorizado.ByValue lItem = new ACBrAACInterop.TECFAutorizado.ByValue();
        lItem.ValorGT = pAacECF.getValorGT();
        lItem.NumeroSerie = toByte(pAacECF.getNumeroSerie(), 30);
        lItem.CNI = pAacECF.getCni();
        lItem.CRO = pAacECF.getCro();

        int ret = ACBrAACInterop.INSTANCE.AAC_IdentPaf_ECFsAutorizados_New(getHandle(), lItem);
        checkResult(ret);        
    }
    // </editor-fold>    
    
}