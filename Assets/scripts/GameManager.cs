using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public int score_ = 0;
	public bool gamePaused_ = false;
	public bool gameOver_ = false;


	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetKeyDown( KeyCode.Escape ) )
		{
			togglePause();
		}
	
	}

	public void togglePause()
	{
		if( ! gamePaused_ && ! gameOver_ )
		{
			Time.timeScale = 0f;
			gamePaused_ = true;
		}
		else if( gamePaused_ && ! gameOver_ )
		{
			Time.timeScale = 1f;
			gamePaused_ = false;
		}
	}

	public void playerDied()
	{
		gameOver_ = true;
		Time.timeScale = 0f;
	}


	void addScore( int amount )
	{
		score_ += amount;
	}

	void OnGUI()
	{
		// Player score
		GUI.Box( new Rect( 50, 50, 100, 25 ), "Score: " + score_.ToString() );

		// show pause menu
		if( gamePaused_ && ! gameOver_ )
		{
			int boxPosX = Screen.width / 2 - 75;
			int boxPosY = Screen.height / 2 - 150;

			GUI.Box (new Rect ( boxPosX, boxPosY, 150, 150), "Game paused");
			
			if (GUI.Button (new Rect ( boxPosX + 15, boxPosY + 50, 120, 20), "Continue")) {
				togglePause();
			}
			
			// Make the second button.
			if (GUI.Button (new Rect ( boxPosX + 15, boxPosY + 85, 120, 20), "Quit to Main Menu")) {
				Application.LoadLevel (0);
				return;
			}
		}

		// show gameover menu
		if( gameOver_ )
		{
			int boxPosX = Screen.width / 2 - 100;
			int boxPosY = Screen.height / 2 - 75;

			GUI.Box( new Rect( boxPosX, boxPosY, 200, 130 ), "You died!\n\nScore: " + score_ );

			if (GUI.Button (new Rect (boxPosX + 30, boxPosY + 55, 140, 20), "Restart")) {
				Time.timeScale = 1.0f;
				Application.LoadLevel (1);
				return;
			}

			if (GUI.Button (new Rect (boxPosX + 30, boxPosY + 90, 140, 20), "Return to Main Menu")) {
				Application.LoadLevel (0);
				return;
			}

		}
	}

	void getHighScores()
	{
		Application.ExternalCall( "SayHello", "game says lol" );
	}

	void HelloFromHTML( string param )
	{
		Debug.Log( param );
	}


}
