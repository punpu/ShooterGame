using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//Screen.SetResolution( 1024, 1024, false );
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	}


	void OnGUI()
	{

		GUI.Box (new Rect ( Screen.width / 2 - 60, Screen.height / 2 - 150, 120, 130), "Shooter Game!");

		if (GUI.Button (new Rect (Screen.width / 2 - 40, Screen.height / 2 - 100, 80, 20), "Start")) {
			Application.LoadLevel (1);
			return;
		}

		// Info about controls
		GUI.Box (new Rect ( Screen.width / 2 + 180, Screen.height / 2 - 150, 235, 130), "Controls:");
		GUI.Label (new Rect ( Screen.width / 2 + 200, Screen.height / 2 - 120, 220, 130), 
		         "WASD: movement\n" +
		         "Left mouse button: fire Machinegun\n" +
		         "Right mouse button: fire Scattergun\n" +
		         "E: Teleport\n" +
		         "Q: Forcefield");

	}

}
