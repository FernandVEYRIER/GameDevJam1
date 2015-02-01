using UnityEngine;
using System.Collections;

public class AmmoCrate : MonoBehaviour {

	public RuntimeAnimatorController	anim;
	public Sprite						sprite;
	public float 						persistence = 10f;
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.collider2D.tag == "Player")
		{
			col.collider2D.GetComponent<Animator>().runtimeAnimatorController = anim;
			col.collider2D.GetComponent<SpriteRenderer>().sprite = sprite;
			Destroy(this.gameObject);
		}
		if (col.collider2D.tag == "Ground")
		{
			this.rigidbody2D.isKinematic = true;
			this.collider2D.isTrigger  = true;
			Destroy(GameObject.Find("Parachute_0"));
			Destroy(this.gameObject, persistence);
		}
	}
}
