using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour {

	int id;
	int cardID;

	public Image face;
	public Image back;

	void Awake()
	{
		id = int.Parse(name.Split(' ')[1]);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int GetCardID()
	{
		return cardID;
	}

	public void SetCardID(int id)
	{
		cardID = id;
		face.sprite = GameManager.instance.CardImages[id];
	}

	public void CardClicked()
	{
		GameManager.instance.CardClicked(id);
	}

	public void Open()
	{
		back.CrossFadeAlpha(0,0.5f,true);
		SoundManager.PlaySFX("Ding");
	}

	public void Close()
	{
		back.CrossFadeAlpha(1.0f,0.5f,true);
		SoundManager.PlaySFX("page-flip");
	}
}
