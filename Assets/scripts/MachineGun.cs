using UnityEngine;
using System.Collections;

public class MachineGun : Weapon {

	public GameObject bullet_;
	public float spreadDegrees_;
	public float cooldownBetweenShots_;
	public float cooldownRemaining_ = 0f;
	

	public override void Start()
	{
		base.Start();

		ProjectileBehaviour projectile = (ProjectileBehaviour) bullet_.GetComponent<ProjectileBehaviour>();
		projectile.setDamage( damage_ );

		fullAuto_ = true;
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

		Vector3 origin = player_.transform.position;

		GameObject bullet = (GameObject) GameObject.Instantiate( bullet_, origin, player_.transform.rotation);

		// MachineGunilla on spreadia, käännetään luotia y-akselin suhteessa
		bullet.transform.Rotate( 0f, Random.Range( -spreadDegrees_, spreadDegrees_ ), 0f );
		
		Physics.IgnoreCollision( bullet.collider, player_.collider );

		cooldownRemaining_ = cooldownBetweenShots_;
	}


}
