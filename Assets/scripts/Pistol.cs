using UnityEngine;
using System.Collections;

public class Pistol : Weapon {

	// Asetetaan arvo inspectorilla
	public GameObject bullet_;
	public float spreadDegrees_ = 0.5f;

	// Pistooli: dmg: 1, lipas: 5, range: 10f, fullAuto: false
	public override void Start()
	{
		base.Start();
		
		ProjectileBehaviour projectile = (ProjectileBehaviour) bullet_.GetComponent<ProjectileBehaviour>();
		projectile.setDamage( 1 );
		
		damage_ = 2;
		range_ = 10f;
		fullAuto_ = false;
	}


	public override void shoot()
	{
		Vector3 origin = player_.transform.position;

		GameObject bullet = (GameObject) GameObject.Instantiate( bullet_, origin, player_.transform.rotation);

		bullet.transform.Rotate( 0f, Random.Range( -spreadDegrees_, spreadDegrees_ ), 0f );

		Physics.IgnoreCollision( bullet.collider, player_.collider );
	}


}
