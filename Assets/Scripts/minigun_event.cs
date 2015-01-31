using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class minigun_event : MonoBehaviour {
	
	private float		alpha = 255;
	private Color		col;

	void Start ()
	{
		col = this.gameObject.GetComponent<SpriteRenderer> ().material.color;
		StartCoroutine(changeAlpha());
		Destroy(gameObject, 3f);
	}
	
	IEnumerator changeAlpha()
	{
		bool decrease = true;
		float alpha = 1;
		while (true)
		{
			this.gameObject.GetComponent<SpriteRenderer> ().material.color = new Color(col.r, col.g, col.b, alpha);
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
