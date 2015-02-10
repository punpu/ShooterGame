using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{

	public int hitPoints_;
	public float moveSpeed_;
	public GameObject gameManager_;

	
	public virtual void takeDamage (int amount)
	{
		Debug.Log("Enemy took damage");
		hitPoints_ -= amount;
	}



	// Use this for initialization
	public virtual void Start () 
	{
		gameManager_ = GameObject.FindGameObjectWithTag("GameController");
	}
	// Update is called once per frame
	public virtual void Update () {}


}
