using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour 
{

	public int health_ = 5;
	public float moveSpeed_ = 7.0f;
	public float gravity_ = 0f;
	public CharacterController controller_;
	public GameManager gameManager_;

	// Use this for initialization
	void Start () 
	{
		controller_ = (CharacterController) gameObject.GetComponent<CharacterController>();

		gameManager_ = (GameManager) GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>(); 
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( health_ < 1 )
		{
			Destroy( gameObject );
			gameManager_.playerDied();
		}

		moveAccordingToInput();
		lookAtMouse();
	}

	void lookAtMouse()
	{
		if( gameManager_.gamePaused_ )
		{
			return;
		}

		Vector3 screenPoint = Input.mousePosition;
		float distanceToCamera = 28f - transform.position.y;
		screenPoint.z = distanceToCamera; //distance of the plane from the camera
		transform.LookAt( Camera.main.ScreenToWorldPoint(screenPoint) );
	}

	void moveAccordingToInput()
	{

		float xAxis = Input.GetAxis("Horizontal");
		float zAxis = Input.GetAxis("Vertical");

		// Basic movement directions multiplied with the input axis values
		Vector3 right = transform.TransformDirection(Vector3.right);
		Vector3 forward = transform.TransformDirection(Vector3.forward);

		Vector3 xVector = right * xAxis;
		Vector3 zVector = forward * zAxis;

		// movement directions transformed from world coordinates to local coordinates
		xVector = transform.InverseTransformDirection( xVector );
		zVector = transform.InverseTransformDirection( zVector );

		Vector3 rawMovementVector = xVector + zVector;

		// Ettei viistoon liikuta nopeammin kuin suoraan
		if (rawMovementVector.sqrMagnitude > Vector3.forward.sqrMagnitude) 
		{
			rawMovementVector = Vector3.ClampMagnitude( rawMovementVector, 1f );
		}

	    gravity_ -= 9.81f * Time.deltaTime;
		if ( controller_.isGrounded )
		{
			gravity_ = 0f;
		}

		Vector3 finalMovementVector = rawMovementVector * moveSpeed_;

		// Lisätään painovoima vertikaaliseksi nopeudeksi
		finalMovementVector.Set( finalMovementVector.x, gravity_, finalMovementVector.z );

		controller_.Move( finalMovementVector * Time.deltaTime );

	}


	void OnTriggerEnter (Collider other)
	{
		if( other.tag == "Enemy" )
		{
			Debug.Log("osu vihuun");
			health_ -= 1;
			Destroy( other.gameObject );
		}
	}


	void OnGUI()
	{
		GUI.Box( new Rect( 50, Screen.height - 50, 80, 25 ), "Health: " + health_.ToString() );
	}

}