using UnityEngine;
using System.Collections;

public class Copter_script : MonoBehaviour {
	
	public GameObject	munition;
	public GameObject	unit;
	public float		speed;
	public float		speed_unit;
	public GameObject	spawn_unit;
	public float		lim_left;
	public float		lim_right;
	private float		size_y;
	private bool		activate = false;
	private bool		right;
	// Use this for initialization
	void Start ()
	{
		float rand = Random.value;
		if (rand >= 0.5)
			right = true;
		else
			right = false;
		if (!right)
			transform.localScale = new Vector3(-1, 1, 1);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.x < lim_left || transform.position.x > lim_right)
		{
			Destroy(gameObject);
		}
		if (right)
			transform.Translate (-1 * speed * Time.deltaTime, 0, 0);
		else
			transform.Translate (1 * speed * Time.deltaTime, 0, 0);
		if (activate == false)
			StartCoroutine("time");
	}
	IEnumerator time ()
	{
		activate = true;
		GameObject tmpunit = (GameObject)Instantiate (unit, spawn_unit.transform.position, spawn_unit.transform.rotation);
		if(right)
			tmpunit.rigidbody2D.velocity = new Vector2(speed, 0);
		else
			tmpunit.rigidbody2D.velocity = new Vector2(-speed, 0);
		yield return new WaitForSeconds (Random.Range(1f, speed_unit));
		activate = false;
	}
}
