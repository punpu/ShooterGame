using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour {

	public float moveSpeed_ = 70f;
	public float timeToLive_ = 1f;
	public int damage_ = 1;


	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, timeToLive_);
	}
	
	// Update is called once per frame
	void Update () 
	{

		Vector3 movementVector = Vector3.forward * moveSpeed_ * Time.deltaTime;
		float distance = movementVector.magnitude;
		Vector3 forwardWorldSpace = transform.TransformDirection( Vector3.forward );

		RaycastHit hit;

		Physics.Raycast( gameObject.transform.position, forwardWorldSpace, out hit, distance );

		Debug.DrawRay( gameObject.transform.position, forwardWorldSpace, Color.red, 1f );

		// Ettei luoti tunneloi vihollisten ohi. Jos luodin lähellä edessä jotain, siirrytään vain siihen asti
		if( hit.distance < distance && hit.collider != null )
		{
			if( hit.collider.tag == "Enemy" )
			{
				movementVector = Vector3.ClampMagnitude( movementVector, hit.distance );
			}

		}

		transform.Translate( movementVector );

	}

	// Called when the projectile hits an enemy
	void OnTriggerEnter (Collider other) 
	{
		Debug.Log("Projectile hit something");

		other.gameObject.SendMessage( "takeDamage", damage_ );

		Destroy( gameObject );
	}


	public void setDamage( int damage )
	{
		damage_ = damage;
	}

	public void setTimeToLive( float timeToLive )
	{
		timeToLive_ = timeToLive;
	}

	public void setMoveSpeed( float moveSpeed )
	{
		moveSpeed_ = moveSpeed;
	}

}
