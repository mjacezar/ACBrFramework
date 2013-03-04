package jACBrFramework;

import java.util.ArrayList;
import java.util.EventObject;
import java.util.HashMap;
import java.util.Iterator;

public abstract class ACBrClass extends ACBrInteropBase
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	
	private int handle;
	
	private HashMap<String, ArrayList<ACBrEventListener>> eventListeners = new HashMap<>();
	
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	
	protected ACBrClass() throws ACBrException
	{
		onInitialize();
	}
	
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Methods">
	
	@Override
	protected void finalize() throws Throwable
	{
		onFinalize();
		setHandle(0);
		super.finalize();
	}
	
	@Override
	public int getHandle()
	{
		return this.handle;
	}
	
	protected void setHandle(int value)
	{
		this.handle = value;
	}
	
	protected void onInitialize() throws ACBrException
	{
	}
	
	protected void onFinalize() throws ACBrException
	{
	}
	
	@Override
	protected abstract void checkResult(int result) throws ACBrException;
	
	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Listeners methods">
	
	protected synchronized void addListener(String key, ACBrEventListener listener)
	{
		ArrayList<ACBrEventListener> list = eventListeners.get(key);
		if (list == null)
		{
			list = new ArrayList<>();
			eventListeners.put(key, list);
		}
		
		list.add(listener);
	}
	
	protected synchronized void removeListener(String key, ACBrEventListener listener)
	{
		ArrayList<ACBrEventListener> list = eventListeners.get(key);
		if (list != null)
		{
			list.remove(listener);
		}
	}
	
	protected synchronized boolean hasListeners(String key)
	{
		ArrayList<ACBrEventListener> list = eventListeners.get(key);
		if (list != null)
		{
			return list.isEmpty();
		}
		
		return false;
	}
	
	protected synchronized void notifyListeners(String key, EventObject e)
	{
		ArrayList<ACBrEventListener> list = eventListeners.get(key);
		if (list != null)
		{
			Iterator<ACBrEventListener> iterator = list.iterator();
			while(iterator.hasNext())
			{
				ACBrEventListener listener = iterator.next();
				listener.notification(e);
			}
		}
	}
	
	//</editor-fold>
	
	
}
