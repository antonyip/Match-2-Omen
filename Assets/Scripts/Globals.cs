using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void GoToScene(string scene)
	{
		Application.LoadLevel(scene);
	}

}
