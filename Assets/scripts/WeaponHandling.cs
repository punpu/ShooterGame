using UnityEngine;
using System.Collections;

public class WeaponHandling : MonoBehaviour {

	public Weapon weapon1_;
	public Weapon weapon2_;

	// Use this for initialization
	void Start () 
	{
		weapon1_ = GameObject.FindGameObjectWithTag("Player").GetComponent<MachineGun>();
		weapon2_ = GameObject.FindGameObjectWithTag("Player").GetComponent<Scattergun>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if ( Input.GetMouseButtonDown(0) && weapon1_.fullAuto_ == false ) 
		{
			weapon1_.shoot();
		}
		// Full auto-ase ampuu jatkuvasti kun hiirennappi pohjassa
		else if( Input.GetMouseButton(0) && weapon1_.fullAuto_ )
		{
			weapon1_.shoot();
		}

		if ( Input.GetMouseButtonDown(1) && weapon2_.fullAuto_ == false ) 
		{
			weapon2_.shoot();
		}
		// Full auto-ase ampuu jatkuvasti kun hiirennappi pohjassa
		else if( Input.GetMouseButton(1) && weapon2_.fullAuto_ )
		{
			weapon2_.shoot();
		}

			
	}
}
