using UnityEngine;
using System.Collections;

public class shoot_minigun : MonoBehaviour {
	
	public GameObject	munition;
	public GameObject 	origin_spawn;
	public GameObject 	origin_spawn1;
	public GameObject	minigun;
	public float		speed_bullet;
	public float		up;
	public float		speed_attack;
	private bool		activate = false;
	private bool		stop;
	private Vector3		save_vec;
	// Use this for initialization
	void Awake () 
	{
		stop = false;
		save_vec = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (transform.position.y <= up && stop == false)
						transform.Translate (Vector3.up * Time.deltaTime * speed_attack);
		if (transform.position.y >= up && stop == false)
		{
			StartCoroutine("delay");
			transform.position = save_vec;
		}
		if (activate == false && stop == false)
			StartCoroutine ("time");
	}
	IEnumerator delay ()
	{
		stop = true;
		GameObject eventm = (GameObject)Instantiate ( minigun, new Vector3(8.5f, 3.5f, 0), transform.rotation);
		yield return new WaitForSeconds (Random.Range(8, 15));
		stop = false;
	}
	IEnumerator time ()
	{
		activate = true;
		GameObject tmpobj = (GameObject)Instantiate (munition , origin_spawn.transform.position, origin_spawn.transform.rotation);
		tmpobj.rigidbody2D.velocity = new Vector2(-3,-2);
		GameObject tmpobj1 = (GameObject)Instantiate (munition , origin_spawn1.transform.position, origin_spawn1.transform.rotation);
		tmpobj1.rigidbody2D.velocity = new Vector2(-3, -2);
		yield return new WaitForSeconds (speed_bullet);
        activate = false;
    }
}
