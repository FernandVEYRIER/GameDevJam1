using UnityEngine;
using System.Collections;

public class minigun_event : MonoBehaviour {

	public float	 	delay_warning;
	public GameObject	origin_event;
	public Sprite		sprite;		
	private bool		activate = true;
	private float		alpha = 255;
	private Color		col;
	private float		timer;
	// Use this for initialization
	void Start ()
	{
		col = gameObject.GetComponent<SpriteRenderer> ().material.color;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if (timer == 0)
			gameObject.GetComponent<SpriteRenderer> ().material.color = Color.Lerp(col, new Color(col.r, col.g, col.b, 0), delay_warning);
		if (timer >= delay_warning)
			gameObject.GetComponent<SpriteRenderer> ().material.color = Color.Lerp(new Color(col.r, col.g, col.b, 0), col, delay_warning);
		if (timer >= delay_warning)
		{
			activate = false;
		}
		if (timer == 0)
			activate = true;
	}
}
