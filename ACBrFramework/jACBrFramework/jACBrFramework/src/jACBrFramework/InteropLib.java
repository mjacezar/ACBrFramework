package jACBrFramework;

import com.sun.jna.Library;
import com.sun.jna.NativeLibrary;

public interface InteropLib extends Library {
	public static final String JNA_LIBRARY_NAME = PegarDLLpelaArqSO.pegarArq();
	public static final NativeLibrary JNA_NATIVE_LIB = NativeLibrary.getInstance(InteropLib.JNA_LIBRARY_NAME);

    /**
     * Classe auxiliar para obtencao do nome da lib a ser carregada pelo framework.
     * 
      * @see <a href="http://www.projetoacbr.com.br/forum/index.php?/topic/15333-pegar-dll-autom%C3%A1ticamente-32-ou-64/#entry94370">
      * Contribuicao
      * </a>
     */
    class PegarDLLpelaArqSO {
        private static String library = "";
        public static String pegarArq() {
            if (library.isEmpty()) {                
                library = System.getProperty("sun.arch.data.model").equals("64") 
                        ? "ACBrFramework64" : "ACBrFramework32";
            }
            return library;
        }
    }
}