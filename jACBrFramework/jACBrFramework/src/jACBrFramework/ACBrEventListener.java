package jACBrFramework;

import java.util.EventListener;
import java.util.EventObject;

public interface ACBrEventListener<T extends EventObject> extends EventListener
{
	//<editor-fold defaultstate="collapsed" desc="Methods">
	
	void notification(T e);
	
	//</editor-fold>
}
