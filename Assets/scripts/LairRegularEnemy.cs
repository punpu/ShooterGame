using UnityEngine;
using System.Collections;

public class LairRegularEnemy : Enemy 
{

	public GameObject spawnedEnemy_;

	// Use this for initialization
	public override void Start () 
	{
		base.Start();

		// Tämän sijaan asetetaan spawnattava vihu inspectorissa
		//GameObject spawnedEnemy = (GameObject) Resources.Load ("RegularEnemy");

		hitPoints_ = 1;
		moveSpeed_ = 0f;

		InvokeRepeating( "spawnEnemy", 2f, 1f );
		Destroy (gameObject, 6.5f);
	}
	
	// Update is called once per frame
	public override void Update () 
	{

	}



	public void spawnEnemy()
	{
		Vector3 position = transform.position;
		position.y += 1f;

		GameObject.Instantiate( spawnedEnemy_, position, transform.rotation );
	}

}
