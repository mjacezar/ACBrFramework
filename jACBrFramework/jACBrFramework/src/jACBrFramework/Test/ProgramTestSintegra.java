package jACBrFramework.Test;

import jACBrFramework.ACBrException;
import jACBrFramework.sintegra.*;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * Teste da geracao do arquivo do sintegra.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/11/2013 11:02:49, revisao: $Id$
 */
public class ProgramTestSintegra {

    public static void main(String[] args) {
        try {
            ACBrSintegra lAcbrSintegra = new ACBrSintegra(Charset.forName("cp1252"));    
            
            System.out.println("\nAtivo: " + lAcbrSintegra.isAtivo());
            System.out.print("setAtivo -> ");
            lAcbrSintegra.setAtivo(true);
            System.out.println(lAcbrSintegra.isAtivo());
            
//            System.out.println("Informa88C: " + lAcbrSintegra.isInforma88C());
//            System.out.print("setInforma88C -> ");
//            lAcbrSintegra.setInforma88C(true);
//            System.out.println(lAcbrSintegra.isInforma88C());   
//            
//            System.out.println("Informa88EAN: " + lAcbrSintegra.isInforma88EAN());
//            System.out.print("setInforma88EAN -> ");
//            lAcbrSintegra.setInforma88EAN(true);
//            System.out.println(lAcbrSintegra.isInforma88EAN());   
//            
//            System.out.println("Informa88SME: " + lAcbrSintegra.isInforma88SME());
//            System.out.print("setInforma88SME -> ");
//            lAcbrSintegra.setInforma88SME(true);
//            System.out.println(lAcbrSintegra.isInforma88SME());         
//            
//            System.out.println("Informa88SMS: " + lAcbrSintegra.isInforma88SMS());
//            System.out.print("setInforma88SMS -> ");
//            lAcbrSintegra.setInforma88SMS(true);
//            System.out.println(lAcbrSintegra.isInforma88SMS());              
//            
//            System.out.println("InformaSapiMG: " + lAcbrSintegra.isInformaSapiMG());
//            System.out.print("setInformaSapiMG -> ");
//            lAcbrSintegra.setInformaSapiMG(true);
//            System.out.println(lAcbrSintegra.isInformaSapiMG());     
           
            System.out.println("Versao: " + lAcbrSintegra.getVersao());
            
//            System.out.println("Versao do Validador: " + lAcbrSintegra.getVersaoValidador());
//            System.out.print("setVersaoValidador -> ");
//            lAcbrSintegra.setVersaoValidador(VersaoValidador.V524);
//            System.out.println(lAcbrSintegra.getVersaoValidador());  
            
            System.out.println("Nome Arquivo: " + lAcbrSintegra.getNomeArquivo());
            System.out.print("setNomeArquivo -> ");
            lAcbrSintegra.setNomeArquivo("teste.txt");
            System.out.println(lAcbrSintegra.getNomeArquivo());               
            
            System.out.println("Setando registro 10.");
            lAcbrSintegra.setRegistro10(criaRegistro10());
            
            System.out.println("Setando registro 11.");
            lAcbrSintegra.setRegistro11(criaRegistro11());
            
            System.out.println("Setando registro 50.");
            lAcbrSintegra.setRegistros50(criaRegistros50(5));

            System.out.println("Setando registro 51");
            lAcbrSintegra.setRegistros51(criaRegistros51(2));

            System.out.println("Setando registro 53");
            lAcbrSintegra.setRegistros53(criaRegistros53(3));

            System.out.println("Setando registro 54");
            lAcbrSintegra.setRegistros54(criaRegistros54(4));
            
            System.out.println("Setando registro 55");
            lAcbrSintegra.setRegistros55(criaRegistros55(2));

            //TODO Ver
//            System.out.println("Setando registro 56");
//            lAcbrSintegra.setRegistros56(criaRegistros56(1));

            System.out.println("Setando registro 60M");
            lAcbrSintegra.setRegistros60M(criaRegistros60M(3));
            
            System.out.println("Setando registro 60A");
            lAcbrSintegra.setRegistros60A(criaRegistros60A(3));            

            System.out.println("Setando registro 60D");
            lAcbrSintegra.setRegistros60D(criaRegistros60D(3));            
            
            System.out.println("Setando registro 60I");
            lAcbrSintegra.setRegistros60I(criaRegistros60I(2));    

            System.out.println("Setando registro 60R");
            lAcbrSintegra.setRegistros60R(criaRegistros60R(4));    
//
//            System.out.println("Setando registro 61");
//            lAcbrSintegra.setRegistros61(criaRegistros61(2));    
//
//            System.out.println("Setando registro 61R");
//            lAcbrSintegra.setRegistros61R(criaRegistros61R(2));    

//            System.out.println("Setando registro 70");
//            lAcbrSintegra.setRegistros70(criaRegistros70(2));    
//
//            System.out.println("Setando registro 71");
//            lAcbrSintegra.setRegistros71(criaRegistros71(2));    
//
//            System.out.println("Setando registro 74");
//            lAcbrSintegra.setRegistros74(criaRegistros74(1));    
//            
            System.out.println("Setando registro 75");
            lAcbrSintegra.setRegistros75(criaRegistros75(3));

//            System.out.println("Setando registro 76");
//            lAcbrSintegra.setRegistros76(criaRegistros76(4));
//
            System.out.println("Setando registro 77");
            lAcbrSintegra.setRegistros77(criaRegistros77(2));

//            System.out.println("Setando registro 85");
//            lAcbrSintegra.setRegistros85(criaRegistros85(3));
//
//            System.out.println("Setando registro 86");
//            lAcbrSintegra.setRegistros86(criaRegistros86(2));
            
            System.out.println("Gerando arquivo: " + lAcbrSintegra.getNomeArquivo());
            lAcbrSintegra.geraArquivo();
            
            System.out.println("Limpando os registros.");
            lAcbrSintegra.limparRegistros();            
        } catch (ACBrException ex) {
            Logger.getLogger(ProgramTestSintegra.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    private static SintegraRegistro10 criaRegistro10() {
        SintegraRegistro10 lRegistro = new SintegraRegistro10();
        lRegistro.setCidade("Barbacena");
        lRegistro.setCnpj("81472412000126");
        lRegistro.setConvenio(Convenio.ICMS_57_95_CONV_76_03);
        lRegistro.setDataInicial(getData(true));
        lRegistro.setDataFinal(getData(false));
        lRegistro.setEstado("MG");
        lRegistro.setFinalidadeArquivo(FinalidadeArquivo.NORMAL);
        lRegistro.setInscricao("0669755134670");
        lRegistro.setNaturezaInformacao(NaturezaInformacao.TOTALIDADE_DAS_OPERACOES);
        lRegistro.setRazaoSocial("Empresa Teste jAcbrFramework.");
        lRegistro.setTelefone("321234789");
        return lRegistro;        
    }
    
    private static SintegraRegistro11 criaRegistro11() {
        SintegraRegistro11 lRegistro = new SintegraRegistro11();
        lRegistro.setBairro("Centro");
        lRegistro.setCep("362000");
        lRegistro.setComplemento("Complemento");
        lRegistro.setEndereco("Rua Teste");
        lRegistro.setNumero("12");
        lRegistro.setResponsavel("Acbr");
        lRegistro.setTelefone("321234789");
        return lRegistro;
    }
    
    private static ArrayList<SintegraRegistro50> criaRegistros50(int pQuantidade) {
        ArrayList<SintegraRegistro50> lRegistros50 = new ArrayList<SintegraRegistro50>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro50 lRegistro = new SintegraRegistro50();
            lRegistro.setAliquota(18);
            lRegistro.setBaseCalculo(100);
            lRegistro.setCfop("5102");
            lRegistro.setCpfCnpj("77606231357750");
            lRegistro.setDataDocumento(getData(true));
            lRegistro.setEmissorDocumento(TipoEmitenteNotaFiscal.PROPRIO);
            lRegistro.setIcms(1.80);
            lRegistro.setInscricao("0682237314976");
            lRegistro.setIsentas(1);
            lRegistro.setModelo("55");
            lRegistro.setNumero(String.valueOf(i));
            lRegistro.setOutras(2);
            lRegistro.setSerie("1");
            lRegistro.setSituacao("N");
            lRegistro.setUf("MG");
            lRegistro.setValorContabil(13);
            lRegistros50.add(lRegistro);
        }
        return lRegistros50;
    }
    
    private static ArrayList<SintegraRegistro51> criaRegistros51(int pQuantidade) {
        ArrayList<SintegraRegistro51> lRegistros51 = new ArrayList<SintegraRegistro51>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro51 lRegistro = new SintegraRegistro51();
            lRegistro.setCfop("5102");
            lRegistro.setCpfCnpj("77606231357750");
            lRegistro.setDataDocumento(getData(true));
            lRegistro.setEstado("MG");
            lRegistro.setInscricao("0682237314976");
            lRegistro.setNumero(String.valueOf(i));
            lRegistro.setSerie("1");
            lRegistro.setSituacao("N");
            lRegistro.setValorContabil(200);
            lRegistro.setValorIpi(10);
            lRegistro.setValorIsentas(5);
            lRegistro.setValorOutras(8);
            lRegistros51.add(lRegistro);
        }   
        return lRegistros51;
    }   
    
    private static ArrayList<SintegraRegistro53> criaRegistros53(int pQuantidade) {
        ArrayList<SintegraRegistro53> lRegistros53 = new ArrayList<SintegraRegistro53>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro53 lRegistro = new SintegraRegistro53();
            lRegistro.setBaseST(200);
            lRegistro.setCfop("5102");
            lRegistro.setCodigoAntecipacao("1");
            lRegistro.setCpfCnpj("77606231357750");
            lRegistro.setDataDocumento(getData(true));
            lRegistro.setDespesas(1);
            lRegistro.setEmitente(TipoEmitenteNotaFiscal.PROPRIO);
            lRegistro.setEstado("MG");
            lRegistro.setIcmsRetido(10);
            lRegistro.setInscricao("0682237314976");
            lRegistro.setModelo("55");
            lRegistro.setNumero(String.valueOf(i));
            lRegistro.setSerie("1");
            lRegistro.setSituacao("N");
            lRegistros53.add(lRegistro);
        }   
        return lRegistros53;
    }   
    
    private static ArrayList<SintegraRegistro54> criaRegistros54(int pQuantidade) {
        ArrayList<SintegraRegistro54> lRegistros54 = new ArrayList<SintegraRegistro54>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro54 lRegistro = new SintegraRegistro54();
            lRegistro.setAliquota(18);
            lRegistro.setBaseCalculo(100);
            lRegistro.setBaseST(200);
            lRegistro.setCfop("5102");
            lRegistro.setCodigo("88");
            lRegistro.setCpfCnpj("77606231357750");
            lRegistro.setCst("010");
            lRegistro.setModelo("55");
            lRegistro.setNumero(String.valueOf(i));
            lRegistro.setNumeroItem(1);
            lRegistro.setQuantidade(3);
            lRegistro.setSerie("1");
            lRegistro.setValor(4);
            lRegistro.setValorDescontoDespesa(8);
            lRegistro.setValorIpi(0.5);
            lRegistros54.add(lRegistro);
        }   
        return lRegistros54;
    }  

    private static ArrayList<SintegraRegistro55> criaRegistros55(int pQuantidade) {
        ArrayList<SintegraRegistro55> lRegistros55 = new ArrayList<SintegraRegistro55>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro55 lRegistro = new SintegraRegistro55();
            lRegistro.setAgencia(1645);
            lRegistro.setBanco(1);
            lRegistro.setCnpj("81472412000126");
            lRegistro.setDataPagamento(getData(true));
            lRegistro.setInscricao("0669755134670");
            lRegistro.setMesAno("102013");
            lRegistro.setNumero(String.valueOf(i));
            lRegistro.setNumeroConvenio("8");
            lRegistro.setUf("MG");
            lRegistro.setValor(23);
            lRegistro.setVencimento(getData(false));
            lRegistros55.add(lRegistro);
        }   
        return lRegistros55;
    }  

    private static ArrayList<SintegraRegistro56> criaRegistros56(int pQuantidade) {
        ArrayList<SintegraRegistro56> lRegistros56 = new ArrayList<SintegraRegistro56>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro56 lRegistro = new SintegraRegistro56();
            lRegistro.setCfop("5102");
            lRegistro.setChassi("8A9ZZ");
            lRegistro.setCnpj("81472412000126");
            lRegistro.setCnpjConcessionaria("77983530484730");
            lRegistro.setCodigo("88");
            lRegistro.setCst("070");
            lRegistro.setModelo("08");
            lRegistro.setNumero(String.valueOf(i));
            lRegistro.setNumeroItem(i);
            lRegistro.setSerie("9");
            lRegistro.setTipoOperacao(TipoOperacao.OUTRAS);
            lRegistros56.add(lRegistro);
        }   
        return lRegistros56;
    }  
    
    private static ArrayList<SintegraRegistro60M> criaRegistros60M(int pQuantidade) {
        ArrayList<SintegraRegistro60M> lRegistros60M = new ArrayList<SintegraRegistro60M>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro60M lRegistro = new SintegraRegistro60M();
            lRegistro.setCooFinal(10);
            lRegistro.setCooInicial(1);
            lRegistro.setCro(3);
            lRegistro.setCrz(2);
            lRegistro.setEmissao(getData(true));
            lRegistro.setModeloDoc("2C");
            lRegistro.setNumOrdem(i);
            lRegistro.setNumSerie(String.valueOf(i + 1));
            lRegistro.setValorGT(300);
            lRegistro.setVendaBruta(90);
            lRegistros60M.add(lRegistro);
        }   
        return lRegistros60M;
    }  
    
    private static ArrayList<SintegraRegistro60A> criaRegistros60A(int pQuantidade) {
        ArrayList<SintegraRegistro60A> lRegistros60A = new ArrayList<SintegraRegistro60A>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro60A lRegistro = new SintegraRegistro60A();
            lRegistro.setAliquota("I");
            lRegistro.setEmissao(getData(true));
            lRegistro.setNumSerie(String.valueOf(i + 1));
            lRegistro.setValor(90);
            lRegistros60A.add(lRegistro);
        }   
        return lRegistros60A;
    }      

    private static ArrayList<SintegraRegistro60D> criaRegistros60D(int pQuantidade) {
        ArrayList<SintegraRegistro60D> lRegistros60D = new ArrayList<SintegraRegistro60D>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro60D lRegistro = new SintegraRegistro60D();
            lRegistro.setBaseCalculo(100);
            lRegistro.setCodigo("88");
            lRegistro.setEmissao(getData(true));
            lRegistro.setNumSerie(String.valueOf(i + 1));
            lRegistro.setQuantidade(2);
            lRegistro.setStAliquota("I");            
            lRegistro.setValor(90);
            lRegistro.setValorIcms(1);
            lRegistros60D.add(lRegistro);
        }   
        return lRegistros60D;
    }      
    
    private static ArrayList<SintegraRegistro60I> criaRegistros60I(int pQuantidade) {
        ArrayList<SintegraRegistro60I> lRegistros60I = new ArrayList<SintegraRegistro60I>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro60I lRegistro = new SintegraRegistro60I();
            lRegistro.setBaseCalculo(100);
            lRegistro.setCodigo("88");
            lRegistro.setCupom("123");
            lRegistro.setEmissao(getData(true));
            lRegistro.setItem(1);
            lRegistro.setModeloDoc("2C");
            lRegistro.setNumSerie(String.valueOf(i + 1));
            lRegistro.setQuantidade(2);
            lRegistro.setStAliquota("I");            
            lRegistro.setValor(90);
            lRegistro.setValorIcms(0.5);
            lRegistros60I.add(lRegistro);
        }   
        return lRegistros60I;
    }      
    
    private static ArrayList<SintegraRegistro60R> criaRegistros60R(int pQuantidade) {
        ArrayList<SintegraRegistro60R> lRegistros60R = new ArrayList<SintegraRegistro60R>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro60R lRegistro = new SintegraRegistro60R();
            lRegistro.setAliquota("I");
            lRegistro.setBaseCalculo(100);
            lRegistro.setCodigo("88");
            lRegistro.setMesAno("102013");
            lRegistro.setQtd(3);
            lRegistro.setValor(90);
            lRegistros60R.add(lRegistro);
        }   
        return lRegistros60R;
    }      

    private static ArrayList<SintegraRegistro61> criaRegistros61(int pQuantidade) {
        ArrayList<SintegraRegistro61> lRegistros61 = new ArrayList<SintegraRegistro61>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro61 lRegistro = new SintegraRegistro61();
            lRegistro.setAliquota(7);
            lRegistro.setBaseCalculo(100);
            lRegistro.setEmissao(getData(true));
            lRegistro.setIsentas(3);
            lRegistro.setModelo("15");
            lRegistro.setNumOrdemFinal(3);
            lRegistro.setNumOrdemInicial(1);
            lRegistro.setOutras(4);
            lRegistro.setSerie("D");
            lRegistro.setSubSerie("1");
            lRegistro.setValor(87);
            lRegistro.setValorIcms(9);
            lRegistros61.add(lRegistro);
        }   
        return lRegistros61;
    }      

    private static ArrayList<SintegraRegistro61R> criaRegistros61R(int pQuantidade) {
        ArrayList<SintegraRegistro61R> lRegistros61R = new ArrayList<SintegraRegistro61R>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro61R lRegistro = new SintegraRegistro61R();
            lRegistro.setAliquota(7);
            lRegistro.setBaseCalculo(100);
            lRegistro.setCodigo("88");
            lRegistro.setMesAno("102013");
            lRegistro.setQtd(1);
            lRegistro.setValor(87);
            lRegistros61R.add(lRegistro);
        }   
        return lRegistros61R;
    }      

    private static ArrayList<SintegraRegistro70> criaRegistros70(int pQuantidade) {
        ArrayList<SintegraRegistro70> lRegistros70 = new ArrayList<SintegraRegistro70>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro70 lRegistro = new SintegraRegistro70();
            lRegistro.setBaseCalculo(100);
            lRegistro.setCfop("1354");
            lRegistro.setCifFobOutros(ModalidadeFrete.FOB);
            lRegistro.setCpfCnpj("77528320766731");
            lRegistro.setDataDocumento(getData(true));
            lRegistro.setIcms(16);
            lRegistro.setInscricao("0667666215290");
            lRegistro.setIsentas(1);
            lRegistro.setModelo("10");
            lRegistro.setNumero(String.valueOf(i));
            lRegistro.setOutras(3);
            lRegistro.setSerie("B");
            lRegistro.setSubSerie("4");
            lRegistro.setSituacao("N");
            lRegistro.setUf("MG");
            lRegistro.setValorContabil(20);
            lRegistros70.add(lRegistro);
        }   
        return lRegistros70;
    }      
    
    private static ArrayList<SintegraRegistro71> criaRegistros71(int pQuantidade) {
        ArrayList<SintegraRegistro71> lRegistros71 = new ArrayList<SintegraRegistro71>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro71 lRegistro = new SintegraRegistro71();
            lRegistro.setCpfCnpj("77528320766731");
            lRegistro.setCpfCnpjNF("77717491584783");
            lRegistro.setDataDocumento(getData(true));
            lRegistro.setDataNF(getData(false));
            lRegistro.setInscricao("0671586432620");
            lRegistro.setInscricaoNF("0673385169258");
            lRegistro.setModelo("10");
            lRegistro.setModeloNF("01");
            lRegistro.setNumero(String.valueOf(i));
            lRegistro.setNumeroNF(String.valueOf(i + 1));
            lRegistro.setSerie("B");
            lRegistro.setSerieNF("1");
            lRegistro.setSubSerie("4");
            lRegistro.setUf("MG");
            lRegistro.setUfNF("MG");
            lRegistro.setValorNF(20);
            lRegistros71.add(lRegistro);
        }   
        return lRegistros71;
    }      

    private static ArrayList<SintegraRegistro74> criaRegistros74(int pQuantidade) {
        ArrayList<SintegraRegistro74> lRegistros74 = new ArrayList<SintegraRegistro74>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro74 lRegistro = new SintegraRegistro74();
            lRegistro.setCnpjPossuidor("81472412000126");
            lRegistro.setCodigo("88");
            lRegistro.setCodigoPosse("1");
            lRegistro.setData(getData(true));
            //lRegistro.setInscricaoPossuidor("0635420060719");
            lRegistro.setQuantidade(3);
            lRegistro.setUfPossuidor("MG");
            lRegistro.setValorProduto(8);
            lRegistros74.add(lRegistro);
        }   
        return lRegistros74;
    }      
    
    private static ArrayList<SintegraRegistro75> criaRegistros75(int pQuantidade) {
        ArrayList<SintegraRegistro75> lRegistros75 = new ArrayList<SintegraRegistro75>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro75 lRegistro = new SintegraRegistro75();
            lRegistro.setAliquotaICMS(18);
            lRegistro.setAliquotaIpi(5);
            lRegistro.setBaseST(200);
            lRegistro.setCodigo("88");
            lRegistro.setDataFinal(getData(false));
            lRegistro.setDataInicial(getData(true));
            lRegistro.setDescricao("Descrição do item maior que o permitido para realizar teste de quebra!!!!!!!");
            lRegistro.setNcm("69106000");
            lRegistro.setReducao(80);
            lRegistro.setUnidade("UN");
            lRegistros75.add(lRegistro);
        }   
        return lRegistros75;
    }  

    private static ArrayList<SintegraRegistro76> criaRegistros76(int pQuantidade) {
        ArrayList<SintegraRegistro76> lRegistros76 = new ArrayList<SintegraRegistro76>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro76 lRegistro = new SintegraRegistro76();
            lRegistro.setAliquota(12);
            lRegistro.setBaseCalculo(100);
            lRegistro.setCfop("1302");
            lRegistro.setCpfCnpj("81472412000126");
            lRegistro.setDataDocumento(getData(true));
            lRegistro.setIcms(5);
            lRegistro.setInscricao("0659121090814");
            lRegistro.setIsentas(1);
            lRegistro.setModelo(22);
            lRegistro.setNumero(123456);
            lRegistro.setOutras(2);
            lRegistro.setSerie("9");
            lRegistro.setSituacao("N");
            lRegistro.setSubSerie("3");
            lRegistro.setTipoReceita(2);
            lRegistro.setUf("MG");
            lRegistro.setValorTotal(10);            
            lRegistros76.add(lRegistro);
        }   
        return lRegistros76;
    }  

    private static ArrayList<SintegraRegistro77> criaRegistros77(int pQuantidade) {
        ArrayList<SintegraRegistro77> lRegistros77 = new ArrayList<SintegraRegistro77>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro77 lRegistro = new SintegraRegistro77();
            lRegistro.setAliquota(12);
            lRegistro.setBaseCalculo(100);
            lRegistro.setCfop("1302");
            lRegistro.setCnpjMF("81472412000126");
            lRegistro.setCodigo("8");
            lRegistro.setCpfCnpj("77814543426743");
            lRegistro.setModelo(22);
            lRegistro.setNumero(123456);
            lRegistro.setNumeroItem(1);
            lRegistro.setNumeroTerminal(2);
            lRegistro.setQuantidade(3);
            lRegistro.setSerie("9");
            lRegistro.setSubSerie("3");
            lRegistro.setTipoReceita(2);
            lRegistro.setValorDesconto(4);
            lRegistro.setValorServico(45);
            lRegistros77.add(lRegistro);
        }   
        return lRegistros77;
    }  
    
    private static ArrayList<SintegraRegistro85> criaRegistros85(int pQuantidade) {
        ArrayList<SintegraRegistro85> lRegistros85 = new ArrayList<SintegraRegistro85>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro85 lRegistro = new SintegraRegistro85();
            lRegistro.setConhecimento("123");
            lRegistro.setDataAverbacao(getData(false));
            lRegistro.setDataConhecimento(getData(true));
            lRegistro.setDataDeclaracao(getData(true));
            lRegistro.setDataNotaFiscal(getData(false));
            lRegistro.setDataRegistro(getData(true));
            lRegistro.setDeclaracao(" 611/2006");
            lRegistro.setModelo("1");
            lRegistro.setNaturezaExportacao(NaturezaExportacao.DIRETA);
            lRegistro.setNumeroNotaFiscal("777");
            lRegistro.setPais("1058");
            lRegistro.setRegistroExportacao("999");
            lRegistro.setSerie("9");
            lRegistro.setTipoConhecimento("1");
            lRegistros85.add(lRegistro);
        }   
        return lRegistros85;
    }  

    private static ArrayList<SintegraRegistro86> criaRegistros86(int pQuantidade) {
        ArrayList<SintegraRegistro86> lRegistros86 = new ArrayList<SintegraRegistro86>();
        for (int i = 1; i <= pQuantidade; i++) {
            SintegraRegistro86 lRegistro = new SintegraRegistro86();
            lRegistro.setCodigo("123");
            lRegistro.setCpfCnpj("77058992102725");
            lRegistro.setDataDocumento(getData(true));
            lRegistro.setDataRegistro(getData(false));
            lRegistro.setInscricao("0659121090814");
            lRegistro.setModelo("1");
            lRegistro.setNumeroNotaFiscal("777");
            lRegistro.setQuantidade(8);
            lRegistro.setRegistroExportacao("999");
            lRegistro.setRelacionamento("3");
            lRegistro.setSerie("9");
            lRegistro.setUf("MG");
            lRegistro.setValorTotalProduto(80);
            lRegistro.setValorUnitario(10);
            lRegistros86.add(lRegistro);
        }   
        return lRegistros86;
    }  
    
    private static Date getData(boolean pEhDataInicial) {
        Calendar lCalendar = Calendar.getInstance();
        if (pEhDataInicial) {
            lCalendar.set(Calendar.DAY_OF_MONTH, 1);
            lCalendar.set(Calendar.MONTH, 9);
            lCalendar.set(Calendar.YEAR, 2013);
        } else {
            lCalendar.set(Calendar.DAY_OF_MONTH, 31);
            lCalendar.set(Calendar.MONTH, 9);
            lCalendar.set(Calendar.YEAR, 2013);            
        }
        return lCalendar.getTime();
    }
}