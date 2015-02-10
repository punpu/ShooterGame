using UnityEngine;
using System.Collections;

public class Railgun : Weapon 
{


	public override void Start()
	{
		base.Start();
		
		//ProjectileBehaviour projectile = (ProjectileBehaviour) bullet_.GetComponent<ProjectileBehaviour>();
		//projectile.setDamage( 1 );
		
		damage_ = 2;
		range_ = 10f;
		fullAuto_ = false;
	}
	
	
	public override void shoot()
	{
		
		Vector3 screenPoint = Input.mousePosition;
		screenPoint.z = 20f; //distance of the plane from the camera
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(screenPoint);
		
		Vector3 origin = player_.transform.position;
		Vector3 direction = (mousePos - origin).normalized;
		
		
		Ray ray = new Ray (origin, direction);
		
		RaycastHit hit = new RaycastHit();
		
		Debug.Log ("shot");
		
		if (Physics.Raycast (ray, out hit, 100f)) 
		{
			Debug.Log( "Hit something" );
			Debug.DrawLine (ray.origin, hit.point, Color.red, 100f);
		}
		
		
		
	}

}
