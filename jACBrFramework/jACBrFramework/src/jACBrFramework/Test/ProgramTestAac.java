package jACBrFramework.Test;

import jACBrFramework.ACBrException;
import jACBrFramework.aac.ACBrAAC;
import jACBrFramework.aac.ArquivoListaAutenticados;
import jACBrFramework.aac.Empresa;
import jACBrFramework.aac.IdenticacaoPaf;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 17:40:37, revisao: $Id$
 */
public class ProgramTestAac {

   public static void main(String[] args) {
        try {
            ACBrAAC lAcbr = new ACBrAAC(); 
            IdenticacaoPaf paf = lAcbr.getIdentPaf();
            Empresa emp = paf.getEmpresa();
            ArquivoListaAutenticados lstAut = paf.getArquivoListaAutenticados();
            
            System.out.println("\nLaudo: " + paf.getNumeroLaudo());
            System.out.print("setNumeroLaudo -> ");
            paf.setNumeroLaudo("Laudo");
            System.out.println(paf.getNumeroLaudo());   
            
            System.out.println("Versão ER: " + paf.getVersaoER());
            System.out.print("setVersaoER -> ");
            paf.setVersaoER("Versao");
            System.out.println(paf.getVersaoER());             

            System.out.println("MD5: " + lstAut.getMD5());
            System.out.print("setMD5 -> ");
            lstAut.setMD5("MD5");
            System.out.println(lstAut.getMD5());             
            
            System.out.println("Nome: " + lstAut.getNome());
            System.out.print("setNome -> ");
            lstAut.setNome("Nome");
            System.out.println(lstAut.getNome());    
            
            System.out.println("Razão Social: " + emp.getRazaoSocial());
            System.out.print("setRazaoSocial -> ");
            emp.setRazaoSocial("Razão Social");
            System.out.println(emp.getRazaoSocial());             
            
        } catch (ACBrException ex) {
            Logger.getLogger(ProgramTestAac.class.getName()).log(Level.SEVERE, null, ex);
        }
    }         
}