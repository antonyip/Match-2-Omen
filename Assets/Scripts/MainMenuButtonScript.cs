using UnityEngine;
using System.Collections;

public class MainMenuButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnStartPlayButtonPressed()
	{
		Globals.GoToScene("Game");
	}

	public void OnQuitButtonPressed()
	{
		Globals.GoToScene("Menu");
	}

	public void OnQuitGameButtonPressed()
	{
		Application.Quit();
	}
}
