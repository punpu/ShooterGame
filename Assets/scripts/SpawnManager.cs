using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {


	public float spawnFrequencyLair_ = 5f;
	public float timeSinceSpawn_ = 0f;

	// Asetetaan inspectorilla
	public GameObject spawnedLair_;

	// Use this for initialization
	void Start () 
	{

		InvokeRepeating( "spawnLair", 2f, spawnFrequencyLair_ );

	}
	
	// Update is called once per frame
	void Update () 
	{
		timeSinceSpawn_ += Time.deltaTime;

		if( timeSinceSpawn_ > spawnFrequencyLair_ )
		{
			spawnLair();
			timeSinceSpawn_ = 0f;

			if( spawnFrequencyLair_ > 1f )
			{
				spawnFrequencyLair_ -= 0.1f;
			}
		}
	}



	void spawnLair()
	{
		Vector3 position = new Vector3( Random.Range( 0f, 30f ), 0.1f, Random.Range ( 0f, 30f ) );

		GameObject.Instantiate( spawnedLair_, position, new Quaternion() );
	}


}
