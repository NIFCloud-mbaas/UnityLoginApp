using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITestSettings
{
	private static bool _callbackFlag = false;

	public static bool CallbackFlag {
		get {
			return _callbackFlag;
		}
		set {
			_callbackFlag = value;
		}
	}

	public static IEnumerator AwaitAsync ()
	{
		while (CallbackFlag == false) {
			yield return new WaitForSeconds (0.2f); 
		}
		yield break;
	}
}