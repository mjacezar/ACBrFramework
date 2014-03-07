package jACBrFramework.tefd.eventos;

import com.sun.jna.ptr.IntByReference;
import jACBrFramework.tefd.TipoRelatorio;
import java.util.EventObject;

/**
 * Evento de impressao de cupom.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 13:26:24, revisao: $Id$
 */
public class ComandaECFImprimeViaEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = 5732943645023086876L;    
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Tipo de relatorio.
     */
    private TipoRelatorio tipoRelatorio;
    /**
     * Via de impressao.
     */
    private int via;
    /**
     * Imagem do comprovante.
     */
    private String[] imagemComprovante;
    /**
     * Tamanho do vetor de comprovante.
     */
    private int imagemComprovanteQtde;
    /**
     * Retorno da ECF.
     */
    private IntByReference retornoEcf;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public ComandaECFImprimeViaEventObject(Object pSource, TipoRelatorio pTipoRelatorio, 
            int pVia, String[] pImagemComprovante, int imagemComprovanteQtde) {
        super(pSource);
        this.tipoRelatorio = pTipoRelatorio;
        this.via = pVia;
        this.imagemComprovante = pImagemComprovante;
        this.imagemComprovanteQtde = imagemComprovanteQtde;
        this.retornoEcf = new IntByReference();
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Tipo de relatorio.
     * @return the tipoRelatorio
     */
    public TipoRelatorio getTipoRelatorio() {
        return tipoRelatorio;
    }

    /**
     * Via de impressao.
     * @return the via
     */
    public int getVia() {
        return via;
    }

    /**
     * Imagem do comprovante.
     * @return the imagemComprovante
     */
    public String[] getImagemComprovante() {
        return imagemComprovante;
    }

    /**
     * Tamanho do vetor de comprovante.
     * @return the imagemComprovanteQtde
     */
    public int getImagemComprovanteQtde() {
        return imagemComprovanteQtde;
    }

    /**
     * Retorno da ECF.
     * @return the retornoEcf
     */
    public IntByReference getRetornoEcf() {
        return retornoEcf;
    }

    /**
     * Retorno da ECF.
     * @param retornoEcf the retornoEcf to set
     */
    public void setRetornoEcf(IntByReference retornoEcf) {
        this.retornoEcf = retornoEcf;
    }
    // </editor-fold>    

}