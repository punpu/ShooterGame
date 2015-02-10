using UnityEngine;
using System.Collections;

public class Gadgets : MonoBehaviour {


	public float gadgetEnergy_ = 100f;
	public float gadgetMaxEnergy_ = 100f;
	public float gadgetEnergyRecharge_ = 10f;

	Vector2 energyBarPos = new Vector2( 140f, Screen.height - 50f );
	Vector2 energyBarSize = new Vector2( 200, 25 );
	public Texture2D energyBarEmpty;
	public Texture2D energyBarFull;
	public GameObject forceField_;

	public float mapBoundary1 = 0.5f;
	public float mapBoundary2 = 30.5f;

	void Start () 
	{
	
	}

	void Update () 
	{
		if( Input.GetKeyDown( KeyCode.E ) )
		{
			teleport();
		}

		if( Input.GetKeyDown( KeyCode.Q ) )
		{
			forceField();
		}

		if( gadgetEnergy_ < gadgetMaxEnergy_ )
		{
			gadgetEnergy_ += Time.deltaTime * gadgetEnergyRecharge_;

			if( gadgetEnergy_ > gadgetMaxEnergy_ )
			{
				gadgetEnergy_ = gadgetMaxEnergy_;
			}
		}

		
	}
	
	void OnGUI()
	{
		GUI.DrawTexture( new Rect( energyBarPos.x, energyBarPos.y, energyBarSize.x, energyBarSize.y ), energyBarEmpty);
		GUI.DrawTexture( new Rect( energyBarPos.x, energyBarPos.y, energyBarSize.x * Mathf.Clamp01( gadgetEnergy_ / 100f ), energyBarSize.y), energyBarFull);
	} 


	void teleport() 
	{
		if( gadgetEnergy_ < 40f )
		{
			return;
		}

		gadgetEnergy_ -= 40f;


		Vector3 destination = getMousePosition();

		transform.position = destination;
	}

	void forceField()
	{
		if( gadgetEnergy_ < 40f )
		{
			return;
		}
		
		gadgetEnergy_ -= 40f;

		Vector3 destination = getMousePosition();

		GameObject forcefield =  (GameObject) GameObject.Instantiate( forceField_, destination, transform.rotation );
		forcefield.transform.Rotate( 0f, 90f, 0f );

		Destroy ( forcefield, 3.7f );
	}

	Vector3 getMousePosition()
	{
		Vector3 screenPoint = Input.mousePosition;
		float distanceToCamera = 28f - transform.position.y - 0.1f; // Ei haluta tippua maan läpi vahingossa
		screenPoint.z = distanceToCamera; // Kameran etäisyys maasta

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(screenPoint);

		// move mouse pos to be inside game area
		if( mousePos.x > mapBoundary2 )
		{
			mousePos.x = mapBoundary2;
		}
		if( mousePos.z > mapBoundary2 )
		{
			mousePos.z = mapBoundary2;
		}
		if( mousePos.x < mapBoundary1 )
		{
			mousePos.x = mapBoundary1;
		}
		if( mousePos.z < mapBoundary1 )
		{
			mousePos.z = mapBoundary1;
		}

		return mousePos;
	}



}
