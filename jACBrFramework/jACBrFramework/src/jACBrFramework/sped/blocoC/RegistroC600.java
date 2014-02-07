package jACBrFramework.sped.blocoC;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Consolidacao diaria de notas fiscais/contas de energia eletrica (codigo 06),
 * nota fiscal/conta de fornecimento de agua canalizada (codigo 29) e nota fiscal/conta
 * de fornecimento de gas (codigo 28) (empresas nao obrigadas ao convenio ICMS 115/03)
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 09:26:45, revisao: $Id$
 */
public class RegistroC600 {
    
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Documentos cancelados - consolidacao diaria de notas fiscais/contas de energia 
     * eletrica (codigo 06), nota fiscal/conta de forneciemnto de agua canalizada (codigo 29) 
     * e nota fiscal/conta de fornecimento de gas (codigo 28).
     */
    private Collection<RegistroC601> registroC601 = new ArrayList<RegistroC601>(); 
    /**
     * Itens do documento consolidado notas fiscais/contas de energia eletrica 
     * (codigo 06), nota fiscal/conta de fornecimento de agua canalizada (codigo 29) 
     * e nota fiscal/conta de fornecimento de gas (codigo 28)
     * (empresas nao obrigadas ao convenio ICMS 115/03).
     */
    private Collection<RegistroC610> registroC610 = new ArrayList<RegistroC610>(); 
    /**
     * Registro analitico dos documentos (notas fiscais/contas de energia eletrica)
     * (codigo 06), nota fiscal/conta de fornecimento de agua canalizada (codigo 29)
     * e nota fisscal/conta de fornecimento de gas (codigo 28).
     */
    private Collection<RegistroC690> registroC690 = new ArrayList<RegistroC690>();     
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1 .
     */
    private String COD_MOD;
    /**
     * Codigo do municipio dos pontos de CONS, conforme a tabela IBGE.
     */
    private String COD_MUN;
    /**
     * Serie do documento fiscal.
     */
    private String SER;
    /**
     * Subserie do documento fiscal.
     */
    private String SUB;
    /**
     * Codigo de classe de CONS de energia eletrica ou gas.
     */
    private String COD_CONS;
    /**
     * Quantidade de documentos consolidados neste registro.
     */
    private double QTD_CONS;
    /**
     * Quantidade de documentos cancelados.
     */
    private double QTD_CANC;
    /**
     * Data dos documentos consolidados.
     */
    private Date DT_DOC;
    /**
     * Valor total dos documentos.
     */
    private double VL_DOC;
    /**
     * Valor acumulado dos descontos.
     */
    private double VL_DESC;
    /**
     * Consumo total acumulado, em kWh (Codigo 06).
     */
    private double CONS;
    /**
     * Valor acumulado do fornecimento.
     */
    private double VL_FORN;
    /**
     * Valor acumulado dos servicos nao-tributados pelo ICMS.
     */
    private double VL_SERV_NT;
    /**
     * Valores cobrados em nome de terceiros.
     */
    private double VL_TERC;
    /**
     * Valor acumulado das despesas acessorias.
     */
    private double VL_DA;
    /**
     * Valor acumulado da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Valor acumulado do ICMS.
     */
    private double VL_ICMS;
    /**
     * Valor acumulado da base de calculo do ICMS substituicao tributaria.
     */
    private double VL_BC_ICMS_ST;
    /**
     * Valor acumulado do ICMS retido por substituicao tributaria.
     */
    private double VL_ICMS_ST;
    /**
     * Valor acumulado do PIS.
     */
    private double VL_PIS;
    /**
     * Valor acumulado COFINS.
     */
    private double VL_COFINS;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Documentos cancelados - consolidacao diaria de notas fiscais/contas de energia
     * eletrica (codigo 06), nota fiscal/conta de forneciemnto de agua canalizada (codigo 29)
     * e nota fiscal/conta de fornecimento de gas (codigo 28).
     * @return the registroC601
     */
    public Collection<RegistroC601> getRegistroC601() {
        return registroC601;
    }

    /**
     * Itens do documento consolidado notas fiscais/contas de energia eletrica
     * (codigo 06), nota fiscal/conta de fornecimento de agua canalizada (codigo 29)
     * e nota fiscal/conta de fornecimento de gas (codigo 28)
     * (empresas nao obrigadas ao convenio ICMS 115/03).
     * @return the registroC610
     */
    public Collection<RegistroC610> getRegistroC610() {
        return registroC610;
    }

    /**
     * Registro analitico dos documentos (notas fiscais/contas de energia eletrica)
     * (codigo 06), nota fiscal/conta de fornecimento de agua canalizada (codigo 29)
     * e nota fisscal/conta de fornecimento de gas (codigo 28).
     * @return the registroC690
     */
    public Collection<RegistroC690> getRegistroC690() {
        return registroC690;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1 .
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1 .
     * @param COD_MOD the COD_MOD to set
     */
    public void setCOD_MOD(String COD_MOD) {
        this.COD_MOD = COD_MOD;
    }

    /**
     * Codigo do municipio dos pontos de CONS, conforme a tabela IBGE.
     * @return the COD_MUN
     */
    public String getCOD_MUN() {
        return COD_MUN;
    }

    /**
     * Codigo do municipio dos pontos de CONS, conforme a tabela IBGE.
     * @param COD_MUN the COD_MUN to set
     */
    public void setCOD_MUN(String COD_MUN) {
        this.COD_MUN = COD_MUN;
    }

    /**
     * Serie do documento fiscal.
     * @return the SER
     */
    public String getSER() {
        return SER;
    }

    /**
     * Serie do documento fiscal.
     * @param SER the SER to set
     */
    public void setSER(String SER) {
        this.SER = SER;
    }

    /**
     * Subserie do documento fiscal.
     * @return the SUB
     */
    public String getSUB() {
        return SUB;
    }

    /**
     * Subserie do documento fiscal.
     * @param SUB the SUB to set
     */
    public void setSUB(String SUB) {
        this.SUB = SUB;
    }

    /**
     * Codigo de classe de CONS de energia eletrica ou gas.
     * @return the COD_CONS
     */
    public String getCOD_CONS() {
        return COD_CONS;
    }

    /**
     * Codigo de classe de CONS de energia eletrica ou gas.
     * @param COD_CONS the COD_CONS to set
     */
    public void setCOD_CONS(String COD_CONS) {
        this.COD_CONS = COD_CONS;
    }

    /**
     * Quantidade de documentos consolidados neste registro.
     * @return the QTD_CONS
     */
    public double getQTD_CONS() {
        return QTD_CONS;
    }

    /**
     * Quantidade de documentos consolidados neste registro.
     * @param QTD_CONS the QTD_CONS to set
     */
    public void setQTD_CONS(double QTD_CONS) {
        this.QTD_CONS = QTD_CONS;
    }

    /**
     * Quantidade de documentos cancelados.
     * @return the QTD_CANC
     */
    public double getQTD_CANC() {
        return QTD_CANC;
    }

    /**
     * Quantidade de documentos cancelados.
     * @param QTD_CANC the QTD_CANC to set
     */
    public void setQTD_CANC(double QTD_CANC) {
        this.QTD_CANC = QTD_CANC;
    }

    /**
     * Data dos documentos consolidados.
     * @return the DT_DOC
     */
    public Date getDT_DOC() {
        return DT_DOC;
    }

    /**
     * Data dos documentos consolidados.
     * @param DT_DOC the DT_DOC to set
     */
    public void setDT_DOC(Date DT_DOC) {
        this.DT_DOC = DT_DOC;
    }

    /**
     * Valor total dos documentos.
     * @return the VL_DOC
     */
    public double getVL_DOC() {
        return VL_DOC;
    }

    /**
     * Valor total dos documentos.
     * @param VL_DOC the VL_DOC to set
     */
    public void setVL_DOC(double VL_DOC) {
        this.VL_DOC = VL_DOC;
    }

    /**
     * Valor acumulado dos descontos.
     * @return the VL_DESC
     */
    public double getVL_DESC() {
        return VL_DESC;
    }

    /**
     * Valor acumulado dos descontos.
     * @param VL_DESC the VL_DESC to set
     */
    public void setVL_DESC(double VL_DESC) {
        this.VL_DESC = VL_DESC;
    }

    /**
     * Consumo total acumulado, em kWh (Codigo 06).
     * @return the CONS
     */
    public double getCONS() {
        return CONS;
    }

    /**
     * Consumo total acumulado, em kWh (Codigo 06).
     * @param CONS the CONS to set
     */
    public void setCONS(double CONS) {
        this.CONS = CONS;
    }

    /**
     * Valor acumulado do fornecimento.
     * @return the VL_FORN
     */
    public double getVL_FORN() {
        return VL_FORN;
    }

    /**
     * Valor acumulado do fornecimento.
     * @param VL_FORN the VL_FORN to set
     */
    public void setVL_FORN(double VL_FORN) {
        this.VL_FORN = VL_FORN;
    }

    /**
     * Valor acumulado dos servicos nao-tributados pelo ICMS.
     * @return the VL_SERV_NT
     */
    public double getVL_SERV_NT() {
        return VL_SERV_NT;
    }

    /**
     * Valor acumulado dos servicos nao-tributados pelo ICMS.
     * @param VL_SERV_NT the VL_SERV_NT to set
     */
    public void setVL_SERV_NT(double VL_SERV_NT) {
        this.VL_SERV_NT = VL_SERV_NT;
    }

    /**
     * Valores cobrados em nome de terceiros.
     * @return the VL_TERC
     */
    public double getVL_TERC() {
        return VL_TERC;
    }

    /**
     * Valores cobrados em nome de terceiros.
     * @param VL_TERC the VL_TERC to set
     */
    public void setVL_TERC(double VL_TERC) {
        this.VL_TERC = VL_TERC;
    }

    /**
     * Valor acumulado das despesas acessorias.
     * @return the VL_DA
     */
    public double getVL_DA() {
        return VL_DA;
    }

    /**
     * Valor acumulado das despesas acessorias.
     * @param VL_DA the VL_DA to set
     */
    public void setVL_DA(double VL_DA) {
        this.VL_DA = VL_DA;
    }

    /**
     * Valor acumulado da base de calculo do ICMS.
     * @return the VL_BC_ICMS
     */
    public double getVL_BC_ICMS() {
        return VL_BC_ICMS;
    }

    /**
     * Valor acumulado da base de calculo do ICMS.
     * @param VL_BC_ICMS the VL_BC_ICMS to set
     */
    public void setVL_BC_ICMS(double VL_BC_ICMS) {
        this.VL_BC_ICMS = VL_BC_ICMS;
    }

    /**
     * Valor acumulado do ICMS.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor acumulado do ICMS.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }

    /**
     * Valor acumulado da base de calculo do ICMS substituicao tributaria.
     * @return the VL_BC_ICMS_ST
     */
    public double getVL_BC_ICMS_ST() {
        return VL_BC_ICMS_ST;
    }

    /**
     * Valor acumulado da base de calculo do ICMS substituicao tributaria.
     * @param VL_BC_ICMS_ST the VL_BC_ICMS_ST to set
     */
    public void setVL_BC_ICMS_ST(double VL_BC_ICMS_ST) {
        this.VL_BC_ICMS_ST = VL_BC_ICMS_ST;
    }

    /**
     * Valor acumulado do ICMS retido por substituicao tributaria.
     * @return the VL_ICMS_ST
     */
    public double getVL_ICMS_ST() {
        return VL_ICMS_ST;
    }

    /**
     * Valor acumulado do ICMS retido por substituicao tributaria.
     * @param VL_ICMS_ST the VL_ICMS_ST to set
     */
    public void setVL_ICMS_ST(double VL_ICMS_ST) {
        this.VL_ICMS_ST = VL_ICMS_ST;
    }

    /**
     * Valor acumulado do PIS.
     * @return the VL_PIS
     */
    public double getVL_PIS() {
        return VL_PIS;
    }

    /**
     * Valor acumulado do PIS.
     * @param VL_PIS the VL_PIS to set
     */
    public void setVL_PIS(double VL_PIS) {
        this.VL_PIS = VL_PIS;
    }

    /**
     * Valor acumulado COFINS.
     * @return the VL_COFINS
     */
    public double getVL_COFINS() {
        return VL_COFINS;
    }

    /**
     * Valor acumulado COFINS.
     * @param VL_COFINS the VL_COFINS to set
     */
    public void setVL_COFINS(double VL_COFINS) {
        this.VL_COFINS = VL_COFINS;
    }
    // </editor-fold>
    
}