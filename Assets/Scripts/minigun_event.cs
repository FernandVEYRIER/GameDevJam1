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

	void Start ()
	{
		col = gameObject.GetComponent<SpriteRenderer> ().material.color;
		StartCoroutine(changeAlpha());
	}
	
	IEnumerator changeAlpha()
	{
		bool decrease = true;
		float alpha = 1;
		while (true)
		{
			gameObject.GetComponent<SpriteRenderer> ().material.color = new Color(col.r, col.g, col.b, alpha);
			if (decrease)
				alpha -= 0.05f;
			else
				alpha += 0.05f;
			if (alpha <= 0)
				decrease = false;
			if (alpha >= 1)
				decrease = true;
			yield return new WaitForSeconds(0.01f);
		}
	}
}
