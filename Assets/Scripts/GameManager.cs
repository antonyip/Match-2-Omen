using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum GAMESTATE
{
	WAITING = 0,
	FIRSTCARDPICKED,
	SECONDCARDPICKED,
	GAMEOVER,
}

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameBoard gameBoard;
	public VictoryScreenScript VictoryScreen;
	public GAMESTATE gameState;

	public Sprite[] CardImages;

	float timer;

	int firstCardPos = -1;
	int secondCardPos = -1;

	int correctCards = 0;


	// Use this for initialization
	void Awake () {
		instance = this;
	}

	void Start()
	{
		StartGame();
	}

	void StartGame()
	{
		correctCards = 0;
		gameState = GAMESTATE.WAITING;
		ResetTimer();
		gameBoard.StartNewGame();
	}

	public void ResetGame ()
	{
		StartGame();
	}

	void GameOver()
	{
		gameState = GAMESTATE.GAMEOVER;
		VictoryScreen.victory(timer);
		LogHighscore();

	}

	void ResetTimer()
	{
		timer = 0;
	}

	void LogHighscore()
	{

	}
	
	// Update is called once per frame
	void Update () {

		if (gameState != GAMESTATE.GAMEOVER)
		{
			timer += Time.deltaTime;
		}


	}

	public void CardClicked (int id)
	{
		Debug.Log(id);

		switch (gameState)
		{
		case GAMESTATE.WAITING:
			firstCardPos = id;
			gameBoard.OpenCard(id);
			gameBoard.Cards[id].GetComponent<Button>().interactable = false;
			gameState = GAMESTATE.FIRSTCARDPICKED;
			Invoke("TimeOut",5.0f);
			break;

		case GAMESTATE.FIRSTCARDPICKED:
			CancelInvoke("TimeOut");
			gameBoard.OpenCard(id);
			secondCardPos = id;
			gameBoard.Cards[id].GetComponent<Button>().interactable = false;
			gameState = GAMESTATE.SECONDCARDPICKED;
			Invoke("VerifyCards",1.5f);
			break;

		default:
			Debug.Log("Waiting For Animation");
			break;
		}
	}

	void TimeOut()
	{
		gameBoard.CloseCard(firstCardPos);
		gameState = GAMESTATE.WAITING;
	}

	void VerifyCards()
	{
		if (gameState == GAMESTATE.SECONDCARDPICKED)
		{
			// if the cards are the same
			if (gameBoard.Cards[firstCardPos].GetComponent<Card>().GetCardID() == gameBoard.Cards[secondCardPos].GetComponent<Card>().GetCardID())
			{
				correctCards += 2;
				SoundManager.PlaySFX("chimeVictory");
				if (correctCards == gameBoard.Cards.Length)
					GameOver();
			}
			else
			{

				gameBoard.CloseCards(firstCardPos, secondCardPos);
			}
			gameState = GAMESTATE.WAITING;
		}
	}
}
