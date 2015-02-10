using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
	public GameObject player_;
	public int damage_;
	public float range_;
	public bool fullAuto_;
	

	public abstract void shoot();


	public virtual void Start()
	{
		player_ = GameObject.FindGameObjectWithTag("Player");
	}

	public virtual void Update(){}




}
