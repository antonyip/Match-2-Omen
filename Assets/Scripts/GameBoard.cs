using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameBoard : MonoBehaviour {

	public GameObject[] Cards;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartNewGame ()
	{
		//int NoOfCards = Cards.Length / 2;
		List<int> TempList = new List<int>();

		for (int i = 0; i < Cards.Length; ++i)
		{
			TempList.Add(i/2);
		}

		for (int i = 0; i < Cards.Length; i++)
		{
			int pos = Random.Range(0, TempList.Count);
			Cards[i].GetComponent<Card>().SetCardID(TempList[pos]);
			TempList.RemoveAt(pos);
		}

		for (int i = 0; i < Cards.Length; i++)
		{
			Cards[i].GetComponent<Button>().interactable = true;
		}
	}

	public void OpenCard(int cardPos)
	{
		Cards[cardPos].GetComponent<Card>().Open();
	}

	public void CloseCards (int firstCardPos, int secondCardPos)
	{
		CloseCard(firstCardPos);
		CloseCard(secondCardPos);
	}

	public void CloseCard (int cardPos)
	{
		Cards[cardPos].GetComponent<Button>().interactable = true;
		Cards[cardPos].GetComponent<Card>().Close();
	}
}
