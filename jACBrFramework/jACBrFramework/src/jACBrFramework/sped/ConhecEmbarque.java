package jACBrFramework.sped;

/**
 * Informacao do tipo de conhecimento de embarque.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 16:21:50, revisao: $Id$
 */
public enum ConhecEmbarque {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    AWB(0, "01 – AWB"),
    MAWB(1, "02 – MAWB"),
    HAWB(2, "03 – HAWB"),
    COMAT(3, "04 – COMAT"),
    RExpressas(4, "06 – R. EXPRESSAS"),
    EtiqREspressas(5, "07 – ETIQ. REXPRESSAS"),
    HrExpressas(6, "08 – HR. EXPRESSAS"),
    AV7(7, "09 – AV7"),
    BL(8, "10 – BL"),
    MBL(9, "11 – MBL"),
    HBL(10, "12 – HBL"),
    CTR(11, "CRT"),
    DSIC(12, "14 – DSIC"),
    ComatBL(13, "16 – COMAT BL"),
    RWB(14, "17 – RWB"),
    HRWB(15, "18 – HRWB"),
    TifDta(16, "19 – TIF/DTA"),
    CP2(17, "20 – CP2"),
    NaoIATA(18, "91 – NÂO IATA"),
    MNaoIATA(19, "92 – MNAO IATA"),
    HNaoIATA(20, "HNAO IATA"),
    COutros(21, "99 – OUTROS");  
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