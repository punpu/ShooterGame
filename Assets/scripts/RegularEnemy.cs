using UnityEngine;
using System.Collections;

public class RegularEnemy : Enemy {



	public Transform player_;
	public CharacterController controller_;
	public float gravity_ = 0f;

	public Color[] colorsWhenWounded_ = new Color[3]; 

	// Use this for initialization
	public override void Start () 
	{
		base.Start();

		player_ = GameObject.FindGameObjectWithTag("Player").transform;
		controller_ = (CharacterController) gameObject.GetComponent<CharacterController>();
	}


	// Update is called once per frame
	public override void Update () 
	{
		base.Update();
		
		move();
	}


	public void move()
	{
		transform.LookAt( player_ );

		gravity_ -= 9.81f * Time.deltaTime;
		if ( controller_.isGrounded )
		{
			gravity_ = 0f;
		}

		Vector3 movementVector = transform.TransformDirection(Vector3.forward) * moveSpeed_;

		movementVector.Set( movementVector.x, gravity_, movementVector.z );

		controller_.Move( movementVector * Time.deltaTime );

	}


	public override void takeDamage (int amount)
	{
		base.takeDamage ( amount );

		if( hitPoints_ < 1 )
		{
			gameManager_.SendMessage( "addScore", 1 );
			Destroy( gameObject );
		}
		else
		{
			gameObject.GetComponent<MeshRenderer>().material.color = colorsWhenWounded_[hitPoints_ - 1 ];
		}

	}



}
