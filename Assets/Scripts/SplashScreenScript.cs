using UnityEngine;
using System.Collections;

public class SplashScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("SwitchToMain",5.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SwitchToMain()
	{
		Globals.GoToScene("Menu");
	}
}
