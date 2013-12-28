package jACBrFramework.Test;

import jACBrFramework.ACBrException;
import jACBrFramework.ead.ACBrEAD;
import jACBrFramework.ead.Chaves;
import jACBrFramework.ead.EADDigest;
import jACBrFramework.ead.ModuloExpoente;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 26/12/2013 10:12:34, revisao: $Id$
 */
public class ProgramTestEad {
    
    public static void main(String[] args) {
        try {
            ACBrEAD lAcbr = new ACBrEAD();             
            System.out.println("\nMD5FromFile: " + lAcbr.MD5FromFile("teste.txt"));
            System.out.println("MD5FromString: " + lAcbr.MD5FromString("jACBrFramework"));
            System.out.println("assinarArquivoComEAD: " + lAcbr.assinarArquivoComEAD("teste.txt", false));
            System.out.println("calcularChavePublica:\n " + lAcbr.calcularChavePublica());
            //TODO Verificar no ACBrFramework uma forma de especificar o tamanho do vetor.
            //ArrayList<String> lStrings = new ArrayList<String>();
            //lStrings.add("Framework");
            //lStrings.add("jACBrFramework");
            //System.out.println("calcularEAD: " + lAcbr.calcularEAD(lStrings));
            //System.out.println("calcularEAD: " + lAcbr.calcularEAD(lStrings.toArray(new String[lStrings.size()])));
            System.out.println("calcularEADArquivo: " + lAcbr.calcularEADArquivo("teste.txt"));
            System.out.println("calcularHash: " + lAcbr.calcularHash("jACBrFramework", EADDigest.SHA1));
            System.out.println("calcularHashArquivo: " + lAcbr.calcularHashArquivo("teste.txt", EADDigest.SHA));
            System.out.println("getAbout: " + lAcbr.getAbout());
            System.out.println("getOpenSSL_Version: " + lAcbr.getOpenSSL_Version());
            
            Chaves lChaves = lAcbr.gerarChaves();
            System.out.println("gerarChaves.getChavePrivada(): \n" + lChaves.getChavePrivada());
            System.out.println("gerarChaves.getChavePublica(): \n" + lChaves.getChavePublica());
            lAcbr.setChavePrivada(lChaves.getChavePrivada());
            lAcbr.setChavePublica(lChaves.getChavePublica());

            System.out.println("Gerando gerarXMLeECFc");
            lAcbr.gerarXMLeECFc("Empresa Teste");
            
            ModuloExpoente lModExp = lAcbr.calcularModuloeExpoente();
            System.out.println("calcularModuloeExpoente.getModulo(): \n" + lModExp.getModulo());
            System.out.println("calcularModuloeExpoente.getExpoente(): \n" + lModExp.getExpoente());
            System.out.println("converteXMLeECFcParaOpenSSL: \n" + lAcbr.converteXMLeECFcParaOpenSSL("Empresa Teste.xml"));
        } catch (ACBrException ex) {
            Logger.getLogger(ProgramTestEad.class.getName()).log(Level.SEVERE, null, ex);
        }
    }       
}