using UnityEngine;
using System.Collections;

public class Logger {

	public static void Log(string format, params object[] args)
	{
		Debug.Log(string.Format(format, args));
	}

	public static void Log(object arg)
	{
		Debug.Log(arg);
	}
}
