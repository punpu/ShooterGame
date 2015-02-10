using UnityEngine;
using System.Collections;

public class Scattergun : Weapon {
	
	public GameObject bullet_;
	public float spreadDegrees_ = 15f;
	public float cooldownBetweenShots_ = 4f;
	public float cooldownRemaining_ = 0f;
	public int numberOfShells_ = 20;
	
	
	public override void Start()
	{
		base.Start();
		
		ProjectileBehaviour projectile = (ProjectileBehaviour) bullet_.GetComponent<ProjectileBehaviour>();
		projectile.setDamage( 1 );
		
		damage_ = 1;
		range_ = 10f;
		fullAuto_ = false;
	}
	
	
	public override void Update()
	{
		if( cooldownRemaining_ >= 0 )
		{
			cooldownRemaining_ -= Time.deltaTime;
		}
		
	}
	
	public override void shoot()
	{
		if( cooldownRemaining_ > 0f )
		{
			return;
		}
		


		for( int i = 0; i < numberOfShells_; ++i  )
		{

			Vector3 origin = player_.transform.position;
			origin.x += Random.Range( -0.5f, 0.5f );
			origin.z += Random.Range( -0.5f, 0.5f );

			GameObject bullet = (GameObject) GameObject.Instantiate( bullet_, origin, player_.transform.rotation);

			// scattergunilla on spreadia, käännetään luotia y-akselin suhteessa
			bullet.transform.Rotate( 0f, Random.Range( -spreadDegrees_, spreadDegrees_ ), 0f );
			
			Physics.IgnoreCollision( bullet.collider, player_.collider );
		}

		cooldownRemaining_ = cooldownBetweenShots_;
	}

	
}
