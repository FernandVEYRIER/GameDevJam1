using UnityEngine;
using System.Collections;

public class Copter_script : MonoBehaviour {

	public GameObject explosionPrefab;
	public AudioClip explosionSound;
	public GameObject	munition;
	public int			life;
	public GameObject	unit;
	public float		speed;
	public float		speed_unit;
	public GameObject	spawn_unit;
	public float		lim_left;
	public float		lim_right;
	private float		size_y;
	private bool		activate = false;
	private bool		activate_boom = false;
	private bool		right;
	private bool		anim = false;
	[HideInInspector]
	public bool			death = false;
	// Use this for initialization
	void Awake ()
	{
		death = false;
		float rand = Random.value;
		if (rand >= 0.5)
			right = true;
		else
			right = false;
		if (!right)
		{
			transform.localScale = new Vector3 (-1, 1, 1);
			transform.position = new Vector3 (lim_left, transform.position.y, transform.position.z);
		}
		else
			transform.position = new Vector3 (lim_right, transform.position.y, transform.position.z);

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
		if (activate_boom == false)
			StartCoroutine ("time_boom");
	}
	IEnumerator time ()
	{
		activate = true;
		GameObject tmpunit = (GameObject)Instantiate (unit, spawn_unit.transform.position, spawn_unit.transform.rotation);
		if (right)
			tmpunit.rigidbody2D.velocity = new Vector2 (speed, 0);
		else 
		{
			tmpunit.transform.localScale = new Vector3(-1, 1, 1);
			tmpunit.rigidbody2D.velocity = new Vector2(-speed, 0);
		}
		yield return new WaitForSeconds (Random.Range(1f, speed_unit));
		activate = false;
	}
	IEnumerator time_boom ()
	{
		activate_boom = true;
		GameObject tmpunit = (GameObject)Instantiate (munition, new Vector3(spawn_unit.transform.position.x + 0.5f, spawn_unit.transform.position.y, spawn_unit.transform.position.z), spawn_unit.transform.rotation);
		if (!right)
			tmpunit.transform.localScale = new Vector3(-1, 1, 1);
		yield return new WaitForSeconds (Random.Range(5f, 8f));
		activate_boom = false;
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.collider2D.name == "Bullet(Clone)" && anim == false))
        {
            StartCoroutine (changeColor ());
			RemoveLife();
        }
		if ((col.collider2D.name == "rocket_rpg(Clone)" && anim == false))
		{
			Debug.Log("here");
			StartCoroutine (changeColor ());
			RemoveLife2();
		}
    }
	void RemoveLife()
	{
		if (life > 0)
		{
			life--;
		}
		if (life <= 0)
		{
			StartCoroutine (explosions ());
			GameManager.score += 1000;
		}
	}
	void RemoveLife2()
	{
		if (life > 0)
		{
			life -= 4;
		}
		if (life <= 0)
		{
			StartCoroutine (explosions ());
			GameManager.score += 1000;
		}
	}
    IEnumerator changeColor()
    {
		anim = true;
		gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		yield return new WaitForSeconds (0.1f);
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		anim = false;
    }
	IEnumerator explosions()
	{
		for (int i = 0; i < 80; i++)
		{
			GameObject go = (GameObject) Instantiate(explosionPrefab, (Vector2)transform.position +  Random.insideUnitCircle, Quaternion.identity);
			audio.PlayOneShot(explosionSound, 0.1f);
			Destroy(go, 2f);
			go.transform.SetParent(this.transform);
			yield return new WaitForSeconds(0.01f);
		}
		gameObject.transform.position = new Vector3 (0, 1000, 0);
		audio.Stop ();
		Destroy(gameObject, Random.Range(5, 8));
		Destroy(GameObject.Find("Explosion(Clone)"));
	}
}
