package jACBrFramework.sped.blocoC;

import jACBrFramework.sped.ApuracaoIPI;
import jACBrFramework.sped.MovimentacaoFisica;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Itens do documento (codigo 01, 1B, 04 e 55).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 14:41:44, revisao: $Id$
 */
public class RegistroC170 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Armazenamento de combustiveis (codigo 01, 55)
     */
    private Collection<RegistroC171> registroC171 = new ArrayList<RegistroC171>();
    /**
     * Operacoes com ISSQN (codigo 01)
     */
    private Collection<RegistroC172> registroC172 = new ArrayList<RegistroC172>();
    /**
     * Operacoes com medicamentos (codigo 01, 55)
     */
    private Collection<RegistroC173> registroC173 = new ArrayList<RegistroC173>();
    /**
     * Operacoes com armas de fogo (codigo 01)
     */
    private Collection<RegistroC174> registroC174 = new ArrayList<RegistroC174>();
    /**
     * Operacoes com veiculos novos (codigo 01, 55)
     */
    private Collection<RegistroC175> registroC175 = new ArrayList<RegistroC175>();
    /**
     * Complemento de Item - Ressarcimento de ICMS em operacoes com Substituicao 
     * Tributaria (codigo 01,55) nas operacoes de entradas.
     */
    private Collection<RegistroC176> registroC176 = new ArrayList<RegistroC176>();
    /**
     * Operacoes com produtos sujeitos a selo de controle IPI.
     */
    private Collection<RegistroC177> registroC177 = new ArrayList<RegistroC177>();
    /**
     * Operacoes com produtos sujeitos a tributacao de IPI por UNID ou quantidade de produto. 
     */
    private Collection<RegistroC178> registroC178 = new ArrayList<RegistroC178>();
    /**
     * Informacoes complementares ST (codigo 01).
     */
    private Collection<RegistroC179> registroC179 = new ArrayList<RegistroC179>();
    /**
     * Numero sequencial do item no documento fiscal.
     */
    private String NUM_ITEM;
    /**
     * Codigo do item (campo 02 do Registro 0200).
     */
    private String COD_ITEM;
    /**
     * Descricao complementar do item como adotado no documento fiscal.
     */
    private String DESCR_COMPL;
    /**
     * Quantidade do item.
     */
    private double QTD;
    /**
     * Unidade do item(Campo 02 do registro 0190).
     */
    private String UNID;
    /**
     * Valor total do item (mercadorias ou servicos).
     */
    private double VL_ITEM;
    /**
     * Valor do desconto comercial.
     */
    private double VL_DESC;
    /**
     * Movimentacao fisica do ITEM/PRODUTO.
     */
    private MovimentacaoFisica IND_MOV;
    /**
     * Codigo da Situacao Tributaria referente ao ICMS, conforme a Tabela indicada no item 4.3.1.
     */
    private String CST_ICMS;
    /**
     * Codigo Fiscal de Operacao e Prestacao.
     */
    private String CFOP;
    /**
     * Codigo da natureza da operacao (campo 02 do Registro 0400).
     */
    private String COD_NAT;
    /**
     * Valor da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Aliquota do ICMS.
     */
    private double ALIQ_ICMS;
    /**
     * Valor do ICMS creditado/debitado.
     */
    private double VL_ICMS;
    /**
     * Valor da base de calculo referente a substituicao tributaria.
     */
    private double VL_BC_ICMS_ST;
    /**
     * Aliquota do ICMS da substituicao tributaria na UNID da federacao de destino.
     */
    private double ALIQ_ST;
    /**
     * Valor do ICMS referente a substituicao tributaria.
     */
    private double VL_ICMS_ST;
    /**
     * Indicador de periodo de apuracao do IPI;
     */
    private ApuracaoIPI IND_APUR;
    /**
     * Codigo da Situacao Tributaria referente ao IPI, conforme a Tabela indicada no item 4.3.2.
     */
    private String CST_IPI;
    /**
     * Codigo de enquadramento legal do IPI, conforme tabela indicada no item 4.5.3.
     */
    private String COD_ENQ;
    /**
     * Valor da base de calculo do IPI.
     */
    private double VL_BC_IPI;
    /**
     * Aliquota do IPI.
     */
    private double ALIQ_IPI;
    /**
     * Valor do IPI creditado/debitado.
     */
    private double VL_IPI;
    /**
     * Codigo da Situacao Tributaria referente ao PIS.
     */
    private String CST_PIS;
    /**
     * Valor da base de calculo do PIS.
     */
    private double VL_BC_PIS;
    /**
     * Aliquota do PIS (em percentual).
     */
    private double ALIQ_PIS_PERC;
    /**
     * Quantidade - Base de calculo PIS.
     */
    private double QUANT_BC_PIS;
    /**
     * Aliquota do PIS (em reais).
     */
    private double ALIQ_PIS_R;
    /**
     * Valor do PIS.
     */
    private double VL_PIS;
    /**
     * Codigo da Situacao Tributaria referente ao COFINS.
     */
    private String CST_COFINS;
    /**
     * Valor da base de calculo da COFINS.
     */
    private double VL_BC_COFINS;
    /**
     * Aliquota do COFINS (em percentual).
     */
    private double ALIQ_COFINS_PERC;
    /**
     * Quantidade - Base de calculo COFINS.
     */
    private double QUANT_BC_COFINS;
    /**
     * Aliquota da COFINS (em reais).
     */
    private double ALIQ_COFINS_R;
    /**
     * Valor da COFINS.
     */
    private double VL_COFINS;
    /**
     * Codigo da conta analitica contabil debitada/creditada.
     */
    private String COD_CTA;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Armazenamento de combustiveis (codigo 01, 55)
     * @return the registroC171
     */
    public Collection<RegistroC171> getRegistroC171() {
        return registroC171;
    }

    /**
     * Operacoes com ISSQN (codigo 01)
     * @return the registroC172
     */
    public Collection<RegistroC172> getRegistroC172() {
        return registroC172;
    }

    /**
     * Operacoes com medicamentos (codigo 01, 55)
     * @return the registroC173
     */
    public Collection<RegistroC173> getRegistroC173() {
        return registroC173;
    }

    /**
     * Operacoes com armas de fogo (codigo 01)
     * @return the registroC174
     */
    public Collection<RegistroC174> getRegistroC174() {
        return registroC174;
    }

    /**
     * Operacoes com veiculos novos (codigo 01, 55)
     * @return the registroC175
     */
    public Collection<RegistroC175> getRegistroC175() {
        return registroC175;
    }

    /**
     * Complemento de Item - Ressarcimento de ICMS em operacoes com Substituicao
     * Tributaria (codigo 01,55) nas operacoes de entradas.
     * @return the registroC176
     */
    public Collection<RegistroC176> getRegistroC176() {
        return registroC176;
    }

    /**
     * Operacoes com produtos sujeitos a selo de controle IPI.
     * @return the registroC177
     */
    public Collection<RegistroC177> getRegistroC177() {
        return registroC177;
    }

    /**
     * Operacoes com produtos sujeitos a tributacao de IPI por UNID ou quantidade de produto.
     * @return the registroC178
     */
    public Collection<RegistroC178> getRegistroC178() {
        return registroC178;
    }

    /**
     * Informacoes complementares ST (codigo 01).
     * @return the registroC179
     */
    public Collection<RegistroC179> getRegistroC179() {
        return registroC179;
    }

    /**
     * Numero sequencial do item no documento fiscal.
     * @return the NUM_ITEM
     */
    public String getNUM_ITEM() {
        return NUM_ITEM;
    }

    /**
     * Numero sequencial do item no documento fiscal.
     * @param NUM_ITEM the NUM_ITEM to set
     */
    public void setNUM_ITEM(String NUM_ITEM) {
        this.NUM_ITEM = NUM_ITEM;
    }

    /**
     * Codigo do item (campo 02 do Registro 0200).
     * @return the COD_ITEM
     */
    public String getCOD_ITEM() {
        return COD_ITEM;
    }

    /**
     * Codigo do item (campo 02 do Registro 0200).
     * @param COD_ITEM the COD_ITEM to set
     */
    public void setCOD_ITEM(String COD_ITEM) {
        this.COD_ITEM = COD_ITEM;
    }

    /**
     * Descricao complementar do item como adotado no documento fiscal.
     * @return the DESCR_COMPL
     */
    public String getDESCR_COMPL() {
        return DESCR_COMPL;
    }

    /**
     * Descricao complementar do item como adotado no documento fiscal.
     * @param DESCR_COMPL the DESCR_COMPL to set
     */
    public void setDESCR_COMPL(String DESCR_COMPL) {
        this.DESCR_COMPL = DESCR_COMPL;
    }

    /**
     * Quantidade do item.
     * @return the QTD
     */
    public double getQTD() {
        return QTD;
    }

    /**
     * Quantidade do item.
     * @param QTD the QTD to set
     */
    public void setQTD(double QTD) {
        this.QTD = QTD;
    }

    /**
     * Unidade do item(Campo 02 do registro 0190).
     * @return the UNID
     */
    public String getUNID() {
        return UNID;
    }

    /**
     * Unidade do item(Campo 02 do registro 0190).
     * @param UNID the UNID to set
     */
    public void setUNID(String UNID) {
        this.UNID = UNID;
    }

    /**
     * Valor total do item (mercadorias ou servicos).
     * @return the VL_ITEM
     */
    public double getVL_ITEM() {
        return VL_ITEM;
    }

    /**
     * Valor total do item (mercadorias ou servicos).
     * @param VL_ITEM the VL_ITEM to set
     */
    public void setVL_ITEM(double VL_ITEM) {
        this.VL_ITEM = VL_ITEM;
    }

    /**
     * Valor do desconto comercial.
     * @return the VL_DESC
     */
    public double getVL_DESC() {
        return VL_DESC;
    }

    /**
     * Valor do desconto comercial.
     * @param VL_DESC the VL_DESC to set
     */
    public void setVL_DESC(double VL_DESC) {
        this.VL_DESC = VL_DESC;
    }

    /**
     * Movimentacao fisica do ITEM/PRODUTO.
     * @return the IND_MOV
     */
    public MovimentacaoFisica getIND_MOV() {
        return IND_MOV;
    }

    /**
     * Movimentacao fisica do ITEM/PRODUTO.
     * @param IND_MOV the IND_MOV to set
     */
    public void setIND_MOV(MovimentacaoFisica IND_MOV) {
        this.IND_MOV = IND_MOV;
    }

    /**
     * Codigo da Situacao Tributaria referente ao ICMS, conforme a Tabela indicada no item 4.3.1.
     * @return the CST_ICMS
     */
    public String getCST_ICMS() {
        return CST_ICMS;
    }

    /**
     * Codigo da Situacao Tributaria referente ao ICMS, conforme a Tabela indicada no item 4.3.1.
     * @param CST_ICMS the CST_ICMS to set
     */
    public void setCST_ICMS(String CST_ICMS) {
        this.CST_ICMS = CST_ICMS;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao.
     * @return the CFOP
     */
    public String getCFOP() {
        return CFOP;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao.
     * @param CFOP the CFOP to set
     */
    public void setCFOP(String CFOP) {
        this.CFOP = CFOP;
    }

    /**
     * Codigo da natureza da operacao (campo 02 do Registro 0400).
     * @return the COD_NAT
     */
    public String getCOD_NAT() {
        return COD_NAT;
    }

    /**
     * Codigo da natureza da operacao (campo 02 do Registro 0400).
     * @param COD_NAT the COD_NAT to set
     */
    public void setCOD_NAT(String COD_NAT) {
        this.COD_NAT = COD_NAT;
    }

    /**
     * Valor da base de calculo do ICMS.
     * @return the VL_BC_ICMS
     */
    public double getVL_BC_ICMS() {
        return VL_BC_ICMS;
    }

    /**
     * Valor da base de calculo do ICMS.
     * @param VL_BC_ICMS the VL_BC_ICMS to set
     */
    public void setVL_BC_ICMS(double VL_BC_ICMS) {
        this.VL_BC_ICMS = VL_BC_ICMS;
    }

    /**
     * Aliquota do ICMS.
     * @return the ALIQ_ICMS
     */
    public double getALIQ_ICMS() {
        return ALIQ_ICMS;
    }

    /**
     * Aliquota do ICMS.
     * @param ALIQ_ICMS the ALIQ_ICMS to set
     */
    public void setALIQ_ICMS(double ALIQ_ICMS) {
        this.ALIQ_ICMS = ALIQ_ICMS;
    }

    /**
     * Valor do ICMS creditado/debitado.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor do ICMS creditado/debitado.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }

    /**
     * Valor da base de calculo referente a substituicao tributaria.
     * @return the VL_BC_ICMS_ST
     */
    public double getVL_BC_ICMS_ST() {
        return VL_BC_ICMS_ST;
    }

    /**
     * Valor da base de calculo referente a substituicao tributaria.
     * @param VL_BC_ICMS_ST the VL_BC_ICMS_ST to set
     */
    public void setVL_BC_ICMS_ST(double VL_BC_ICMS_ST) {
        this.VL_BC_ICMS_ST = VL_BC_ICMS_ST;
    }

    /**
     * Aliquota do ICMS da substituicao tributaria na UNID da federacao de destino.
     * @return the ALIQ_ST
     */
    public double getALIQ_ST() {
        return ALIQ_ST;
    }

    /**
     * Aliquota do ICMS da substituicao tributaria na UNID da federacao de destino.
     * @param ALIQ_ST the ALIQ_ST to set
     */
    public void setALIQ_ST(double ALIQ_ST) {
        this.ALIQ_ST = ALIQ_ST;
    }

    /**
     * Valor do ICMS referente a substituicao tributaria.
     * @return the VL_ICMS_ST
     */
    public double getVL_ICMS_ST() {
        return VL_ICMS_ST;
    }

    /**
     * Valor do ICMS referente a substituicao tributaria.
     * @param VL_ICMS_ST the VL_ICMS_ST to set
     */
    public void setVL_ICMS_ST(double VL_ICMS_ST) {
        this.VL_ICMS_ST = VL_ICMS_ST;
    }

    /**
     * Indicador de periodo de apuracao do IPI;
     * @return the IND_APUR
     */
    public ApuracaoIPI getIND_APUR() {
        return IND_APUR;
    }

    /**
     * Indicador de periodo de apuracao do IPI;
     * @param IND_APUR the IND_APUR to set
     */
    public void setIND_APUR(ApuracaoIPI IND_APUR) {
        this.IND_APUR = IND_APUR;
    }

    /**
     * Codigo da Situacao Tributaria referente ao IPI, conforme a Tabela indicada no item 4.3.2.
     * @return the CST_IPI
     */
    public String getCST_IPI() {
        return CST_IPI;
    }

    /**
     * Codigo da Situacao Tributaria referente ao IPI, conforme a Tabela indicada no item 4.3.2.
     * @param CST_IPI the CST_IPI to set
     */
    public void setCST_IPI(String CST_IPI) {
        this.CST_IPI = CST_IPI;
    }

    /**
     * Codigo de enquadramento legal do IPI, conforme tabela indicada no item 4.5.3.
     * @return the COD_ENQ
     */
    public String getCOD_ENQ() {
        return COD_ENQ;
    }

    /**
     * Codigo de enquadramento legal do IPI, conforme tabela indicada no item 4.5.3.
     * @param COD_ENQ the COD_ENQ to set
     */
    public void setCOD_ENQ(String COD_ENQ) {
        this.COD_ENQ = COD_ENQ;
    }

    /**
     * Valor da base de calculo do IPI.
     * @return the VL_BC_IPI
     */
    public double getVL_BC_IPI() {
        return VL_BC_IPI;
    }

    /**
     * Valor da base de calculo do IPI.
     * @param VL_BC_IPI the VL_BC_IPI to set
     */
    public void setVL_BC_IPI(double VL_BC_IPI) {
        this.VL_BC_IPI = VL_BC_IPI;
    }

    /**
     * Aliquota do IPI.
     * @return the ALIQ_IPI
     */
    public double getALIQ_IPI() {
        return ALIQ_IPI;
    }

    /**
     * Aliquota do IPI.
     * @param ALIQ_IPI the ALIQ_IPI to set
     */
    public void setALIQ_IPI(double ALIQ_IPI) {
        this.ALIQ_IPI = ALIQ_IPI;
    }

    /**
     * Valor do IPI creditado/debitado.
     * @return the VL_IPI
     */
    public double getVL_IPI() {
        return VL_IPI;
    }

    /**
     * Valor do IPI creditado/debitado.
     * @param VL_IPI the VL_IPI to set
     */
    public void setVL_IPI(double VL_IPI) {
        this.VL_IPI = VL_IPI;
    }

    /**
     * Codigo da Situacao Tributaria referente ao PIS.
     * @return the CST_PIS
     */
    public String getCST_PIS() {
        return CST_PIS;
    }

    /**
     * Codigo da Situacao Tributaria referente ao PIS.
     * @param CST_PIS the CST_PIS to set
     */
    public void setCST_PIS(String CST_PIS) {
        this.CST_PIS = CST_PIS;
    }

    /**
     * Valor da base de calculo do PIS.
     * @return the VL_BC_PIS
     */
    public double getVL_BC_PIS() {
        return VL_BC_PIS;
    }

    /**
     * Valor da base de calculo do PIS.
     * @param VL_BC_PIS the VL_BC_PIS to set
     */
    public void setVL_BC_PIS(double VL_BC_PIS) {
        this.VL_BC_PIS = VL_BC_PIS;
    }

    /**
     * Aliquota do PIS (em percentual).
     * @return the ALIQ_PIS_PERC
     */
    public double getALIQ_PIS_PERC() {
        return ALIQ_PIS_PERC;
    }

    /**
     * Aliquota do PIS (em percentual).
     * @param ALIQ_PIS_PERC the ALIQ_PIS_PERC to set
     */
    public void setALIQ_PIS_PERC(double ALIQ_PIS_PERC) {
        this.ALIQ_PIS_PERC = ALIQ_PIS_PERC;
    }

    /**
     * Quantidade - Base de calculo PIS.
     * @return the QUANT_BC_PIS
     */
    public double getQUANT_BC_PIS() {
        return QUANT_BC_PIS;
    }

    /**
     * Quantidade - Base de calculo PIS.
     * @param QUANT_BC_PIS the QUANT_BC_PIS to set
     */
    public void setQUANT_BC_PIS(double QUANT_BC_PIS) {
        this.QUANT_BC_PIS = QUANT_BC_PIS;
    }

    /**
     * Aliquota do PIS (em reais).
     * @return the ALIQ_PIS_R
     */
    public double getALIQ_PIS_R() {
        return ALIQ_PIS_R;
    }

    /**
     * Aliquota do PIS (em reais).
     * @param ALIQ_PIS_R the ALIQ_PIS_R to set
     */
    public void setALIQ_PIS_R(double ALIQ_PIS_R) {
        this.ALIQ_PIS_R = ALIQ_PIS_R;
    }

    /**
     * Valor do PIS.
     * @return the VL_PIS
     */
    public double getVL_PIS() {
        return VL_PIS;
    }

    /**
     * Valor do PIS.
     * @param VL_PIS the VL_PIS to set
     */
    public void setVL_PIS(double VL_PIS) {
        this.VL_PIS = VL_PIS;
    }

    /**
     * Codigo da Situacao Tributaria referente ao COFINS.
     * @return the CST_COFINS
     */
    public String getCST_COFINS() {
        return CST_COFINS;
    }

    /**
     * Codigo da Situacao Tributaria referente ao COFINS.
     * @param CST_COFINS the CST_COFINS to set
     */
    public void setCST_COFINS(String CST_COFINS) {
        this.CST_COFINS = CST_COFINS;
    }

    /**
     * Valor da base de calculo da COFINS.
     * @return the VL_BC_COFINS
     */
    public double getVL_BC_COFINS() {
        return VL_BC_COFINS;
    }

    /**
     * Valor da base de calculo da COFINS.
     * @param VL_BC_COFINS the VL_BC_COFINS to set
     */
    public void setVL_BC_COFINS(double VL_BC_COFINS) {
        this.VL_BC_COFINS = VL_BC_COFINS;
    }

    /**
     * Aliquota do COFINS (em percentual).
     * @return the ALIQ_COFINS_PERC
     */
    public double getALIQ_COFINS_PERC() {
        return ALIQ_COFINS_PERC;
    }

    /**
     * Aliquota do COFINS (em percentual).
     * @param ALIQ_COFINS_PERC the ALIQ_COFINS_PERC to set
     */
    public void setALIQ_COFINS_PERC(double ALIQ_COFINS_PERC) {
        this.ALIQ_COFINS_PERC = ALIQ_COFINS_PERC;
    }

    /**
     * Quantidade - Base de calculo COFINS.
     * @return the QUANT_BC_COFINS
     */
    public double getQUANT_BC_COFINS() {
        return QUANT_BC_COFINS;
    }

    /**
     * Quantidade - Base de calculo COFINS.
     * @param QUANT_BC_COFINS the QUANT_BC_COFINS to set
     */
    public void setQUANT_BC_COFINS(double QUANT_BC_COFINS) {
        this.QUANT_BC_COFINS = QUANT_BC_COFINS;
    }

    /**
     * Aliquota da COFINS (em reais).
     * @return the ALIQ_COFINS_R
     */
    public double getALIQ_COFINS_R() {
        return ALIQ_COFINS_R;
    }

    /**
     * Aliquota da COFINS (em reais).
     * @param ALIQ_COFINS_R the ALIQ_COFINS_R to set
     */
    public void setALIQ_COFINS_R(double ALIQ_COFINS_R) {
        this.ALIQ_COFINS_R = ALIQ_COFINS_R;
    }

    /**
     * Valor da COFINS.
     * @return the VL_COFINS
     */
    public double getVL_COFINS() {
        return VL_COFINS;
    }

    /**
     * Valor da COFINS.
     * @param VL_COFINS the VL_COFINS to set
     */
    public void setVL_COFINS(double VL_COFINS) {
        this.VL_COFINS = VL_COFINS;
    }

    /**
     * Codigo da conta analitica contabil debitada/creditada.
     * @return the COD_CTA
     */
    public String getCOD_CTA() {
        return COD_CTA;
    }

    /**
     * Codigo da conta analitica contabil debitada/creditada.
     * @param COD_CTA the COD_CTA to set
     */
    public void setCOD_CTA(String COD_CTA) {
        this.COD_CTA = COD_CTA;
    }
    // </editor-fold>    
    
}