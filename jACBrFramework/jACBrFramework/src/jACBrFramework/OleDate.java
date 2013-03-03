package jACBrFramework;

//<editor-fold defaultstate="collapsed" desc="Disclaimer">
// OleDate.java
//
// Written by Sridhar S Madhugiri
// of Microsoft Technical Support, Developer Support
// Copyright (c) 1997 Microsoft Corporation. All rights reserved.
//
// this class extends Date to convert support Conversion from/to
// OLE Data type DATE
//
// OleData type DATE is actually represented as a double.
//
// To convert from DATE to Date call the setDate(double) member.
// This function does not do a lot of error checking about valid ranges.
// It converts the value passed in to year, month, date, hour,
// minute, second and calls the Date functions to set the values in
// the object.
//
// To convert from Date to DATE call toDouble() member. This returns
// a double that has the date value in the correct format.
//
// http://support.microsoft.com/kb/169795
//</editor-fold>

import java.util.Date;

@SuppressWarnings({"unused", "deprecation"})
public class OleDate extends Date
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	
	// source code copied from MFC 4.21 and modified
	private static double HALF_SECOND = (1.0 / 172800.0);
	
	// source code copied from MFC 4.21 and modified
	private static int rgMonthDays[] = {0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365};
	
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	
	public OleDate(Date date)
	{
		super(date.getTime());
	}
	
	public OleDate(double date)
	{
		setDate(date);
	}
	
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Methods">
	
	//<editor-fold defaultstate="collapsed" desc="Static Methods">
	
	public static double toOADate(Date date)
	{
		OleDate oleDate = new OleDate(date);
		return oleDate.toDouble();
	}
	
	public static Date fromOADate(double value)
	{
		OleDate oleDate = new OleDate(value);
		return oleDate.toDate();
	}
	
	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="OleDate Conversion Methods">
	
	private void setDate(double dtSrc)
	{
		// source code copied from MFC 4.21 and modified
		
		long nDays;         // Number of days since Dec. 30, 1899
		long nDaysAbsolute; // Number of days since 1/1/0
		long nSecsInDay;    // Time in seconds since midnight
		long nMinutesInDay; // Minutes in day
		long n400Years;     // Number of 400 year increments since 1/1/0
		long n400Century;   // Century within 400 year block (0,1,2 or 3)
		long n4Years;       // Number of 4 year increments since 1/1/0
		long n4Day;         // Day within 4 year block
		//  (0 is 1/1/yr1, 1460 is 12/31/yr4)
		long n4Yr;          // Year within 4 year block (0,1,2 or 3)
		boolean bLeap4 = true; // TRUE if 4 year block includes leap year
		
		// values in terms of year month date.
		int tm_sec;
		int tm_min;
		int tm_hour;
		int tm_mday;
		int tm_mon;
		int tm_year;
		int tm_wday;
		int tm_yday;
		
		double dblDate = dtSrc; // temporary serial date
		
		// If a valid date, then this conversion should not overflow
		nDays = (long) dblDate;
		
		// Round to the second
		dblDate += ((dtSrc > 0.0) ? HALF_SECOND : -HALF_SECOND);
		
		// Add days from 1/1/0 to 12/30/1899
		nDaysAbsolute = (long) dblDate + 693959L;
		dblDate = Math.abs(dblDate);
		nSecsInDay = (long) ((dblDate - Math.floor(dblDate)) * 86400.);
		
		// Leap years every 4 yrs except centuries not multiples of 400.
		n400Years = (long) (nDaysAbsolute / 146097L);
		// Set nDaysAbsolute to day within 400-year block
		
		nDaysAbsolute %= 146097L;
		// -1 because first century has extra day
		n400Century = (long) ((nDaysAbsolute - 1) / 36524L);
		// Non-leap century
		
		
		if (n400Century != 0) {
			
			// Set nDaysAbsolute to day within centurY
			nDaysAbsolute = (nDaysAbsolute - 1) % 36524L;
			
			// +1 because 1st 4 year increment has 1460 days
			n4Years = (long) ((nDaysAbsolute + 1) / 1461L);
			
			if (n4Years != 0) {
				n4Day = (long) ((nDaysAbsolute + 1) % 1461L);
			}
			else {
				bLeap4 = false;
				n4Day = (long) nDaysAbsolute;
			}
		}
		else {
			// Leap century - not special case!
			n4Years = (long) (nDaysAbsolute / 1461L);
			n4Day = (long) (nDaysAbsolute % 1461L);
		}
		
		if (bLeap4) {
			// -1 because first year has 366 days
			n4Yr = (n4Day - 1) / 365;
			
			if (n4Yr != 0) {
				n4Day = (n4Day - 1) % 365;
			}
		}
		else {
			n4Yr = n4Day / 365;
			n4Day %= 365;
		}
		
		tm_year = (int) (n400Years * 400 + n400Century * 100
			+ n4Years * 4 + n4Yr);
		
		// Handle leap year: before, on, and after Feb. 29.
		if (n4Yr == 0 && bLeap4 && n4Day == 59) {
			/* Feb. 29 */
			tm_mon = 2;
			tm_mday = 29;
		}
		else {
			if (n4Yr == 0 && bLeap4 && n4Day >= 59) {
				--n4Day;
			}
			
			// Make n4DaY a 1-based day of non-leap year and compute
			
			//  month/day for everything but Feb. 29.
			++n4Day;
			
			// Month number always >= n/32, so save some loop time */
			/*
			 * for (tm_mon = (int)((n4Day >> 5) + 1);
			 * n4Day > rgMonthDays[tm_mon]; tm_mon++);
			 */
			
			for (tm_mon = (int) ((n4Day % 5) + 1);
				n4Day > rgMonthDays[tm_mon]; tm_mon++);
			
			tm_mday = (int) (n4Day - rgMonthDays[tm_mon - 1]);
		}
		
		if (nSecsInDay == 0) {
			tm_hour = tm_min = tm_sec = 0;
		}
		else {
			tm_sec = (int) (nSecsInDay % 60L);
			nMinutesInDay = nSecsInDay / 60L;
			tm_min = (int) (nMinutesInDay % 60);
			tm_hour = (int) (nMinutesInDay / 60);
		}
		
		setYear(tm_year - 1900);
		setMonth(tm_mon - 1);
		super.setDate(tm_mday); // resolves ambiguity
		// between OleDate.setDate and
		// java.util.Date.setDate
		setHours(tm_hour);
		setMinutes(tm_min);
		setSeconds(tm_sec);
		
	}
	
	public Date toDate()
	{
		Date date = new Date();
		date.setTime(this.getTime());
		return date;
	}
	
	public double toDouble()
	{
		// source code copied from MFC 4.21 and modified.
		
		int wYear = getYear() + 1900;
		int wMonth = getMonth() + 1;
		int wDay = getDate();
		int wHour = getHours();
		int wMinute = getMinutes();
		int wSecond = getSeconds();
		
		//  Check for leap year and set the number of days in the month
		boolean bLeapYear = ((wYear & 3) == 0)
			&& ((wYear % 100) != 0 || (wYear % 400) == 0);
		
		int nDaysInMonth =
			rgMonthDays[wMonth] - rgMonthDays[wMonth - 1]
			+ ((bLeapYear && wDay == 29 && wMonth == 2) ? 1 : 0);
		
		// Cache the date in days and time in fractional days
		long nDate;
		double dblTime;
		
		//It is a valid date; make Jan 1, 1AD be 1
		nDate = wYear * 365L + wYear / 4 - wYear / 100 + wYear / 400
			+ rgMonthDays[wMonth - 1] + wDay;
		
		//  If leap year and it's before March, subtract 1:
		if (wMonth >= 2 && bLeapYear) {
			--nDate;
		}
		
		//  Offset so that 12/30/1899 is 0
		nDate -= 693959L;
		
		dblTime = (((long) wHour * 3600L) + // hrs in seconds
			((long) wMinute * 60L) + // mins in seconds
			((long) wSecond)) / 86400.;
		
		double dtDest = (double) nDate
			+ ((nDate >= 0) ? dblTime : -dblTime);
		
		return dtDest;
		
	}
	//</editor-fold>
	
	//</editor-fold>
}