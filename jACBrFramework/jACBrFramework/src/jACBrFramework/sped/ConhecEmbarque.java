package jACBrFramework.sped;

/**
 * Informacao do tipo de conhecimento de embarque.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 16:21:50, revisao: $Id$
 */
public enum ConhecEmbarque {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    AWB(1, "01 – AWB"),
    MAWB(2, "02 – MAWB"),
    HAWB(3, "03 – HAWB"),
    COMAT(4, "04 – COMAT"),
    RExpressas(6, "06 – R. EXPRESSAS"),
    EtiqREspressas(7, "07 – ETIQ. REXPRESSAS"),
    HrExpressas(8, "08 – HR. EXPRESSAS"),
    AV7(9, "09 – AV7"),
    BL(10, "10 – BL"),
    MBL(11, "11 – MBL"),
    HBL(12, "12 – HBL"),
    CTR(13, "CRT"),
    DSIC(14, "14 – DSIC"),
    ComatBL(16, "16 – COMAT BL"),
    RWB(17, "17 – RWB"),
    HRWB(18, "18 – HRWB"),
    TifDta(19, "19 – TIF/DTA"),
    CP2(20, "20 – CP2"),
    NaoIATA(91, "91 – NÂO IATA"),
    MNaoIATA(92, "92 – MNAO IATA"),
    HNaoIATA(93, "HNAO IATA"),
    COutros(99, "99 – OUTROS");  
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do conhecimento de embarque.
     */
    private String descricao;
    /**
     * Codigo do conhecimento de embarque.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    ConhecEmbarque(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do conhecimento de embarque.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do conhecimento de embarque.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>   
    
}