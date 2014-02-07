package jACBrFramework.sped.blocoC;

/**
 * Documentos cancelados - consolidacao diaria de notas fiscais/contas de energia
 * eletrica (codigo 06), nota fiscal/conta de forneciemnto de agua canalizada (codigo 29) 
 * e nota fiscal/conta de fornecimento de gas (codigo 28).
 *  
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 09:26:56, revisao: $Id$
 */
public class RegistroC601 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero do documento fiscal cancelado.
     */
    private String NUM_DOC_CANC;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Numero do documento fiscal cancelado.
     * @return the NUM_DOC_CANC
     */
    public String getNUM_DOC_CANC() {
        return NUM_DOC_CANC;
    }

    /**
     * Numero do documento fiscal cancelado.
     * @param NUM_DOC_CANC the NUM_DOC_CANC to set
     */
    public void setNUM_DOC_CANC(String NUM_DOC_CANC) {
        this.NUM_DOC_CANC = NUM_DOC_CANC;
    }
    // </editor-fold>
    
}