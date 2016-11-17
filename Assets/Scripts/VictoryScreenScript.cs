using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VictoryScreenScript : MonoBehaviour {


	public Text finalText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EndButtonPressed()
	{
		Globals.GoToScene("Menu");
	}

	public void PlayAgainButtonPressed()
	{
		GameManager.instance.ResetGame();
	}

	public void victory (float timer)
	{
		SoundManager.PlaySFX("memory2");
		gameObject.SetActive(true);
		finalText.text = "Congrats! You solved it in " + timer.ToString("0.0") + " seconds!";
	}
}
