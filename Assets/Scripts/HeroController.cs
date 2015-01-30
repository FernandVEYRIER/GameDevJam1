using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

	public Transform groundCheck;
	public float Velocity = 10f;

	bool isGrounded;
	int walkAnim;
	int idleAnim;
	Animator anim;

	void Start () 
	{
		anim = this.GetComponent<Animator>();
		walkAnim = Animator.StringToHash("Velocity");
		idleAnim = Animator.StringToHash("Idle");
	}

	void Update () 
	{
		this.rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * Velocity, 0);

		if (this.rigidbody2D.velocity.x != 0)
		{
			this.transform.localScale = new Vector3((this.rigidbody2D.velocity.x > 0) ? -1 : 1, 1, 1);
		}

		anim.SetFloat(walkAnim, Mathf.Abs(Input.GetAxis("Horizontal")));
		Debug.Log(Input.GetAxis("Horizontal"));
	}
}
