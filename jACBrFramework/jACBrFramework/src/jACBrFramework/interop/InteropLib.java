package jACBrFramework.interop;

import com.sun.jna.Library;
import com.sun.jna.Native;
import com.sun.jna.NativeLibrary;
import com.sun.jna.Pointer;
import java.nio.ByteBuffer;

public interface InteropLib extends Library {
	public static final String JNA_LIBRARY_NAME = "ACBrFramework32";
	public static final NativeLibrary JNA_NATIVE_LIB = NativeLibrary.getInstance(InteropLib.JNA_LIBRARY_NAME);
}
