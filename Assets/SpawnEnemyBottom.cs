using UnityEngine;
using System.Collections;

public class SpawnEnemyBottom : MonoBehaviour {

	public GameObject enemyToSpawn;
	public float spawnDelay = 4f;
	float lastSpawn = -1;
	public bool isLeft = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		lastSpawn -= Time.deltaTime;
		if (lastSpawn < 0)
		{
			lastSpawn = spawnDelay;
			GameObject go = (GameObject) Instantiate(enemyToSpawn, this.transform.position, Quaternion.identity);
			if (!isLeft)
				go.rigidbody2D.AddForce(this.transform.up * 600);
			else
				go.rigidbody2D.velocity = new Vector2(-100, 10);
			Debug.Log(this.transform.up);
		}
	}
}
