using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {

	public int shotAbsorbed = 5;

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log(col.GetComponent<Collider2D>().tag);
		if (col.GetComponent<Collider2D>().tag == "Enemy" || col.GetComponent<Collider2D>().tag == "EnemyBullet")
		{
			StartCoroutine(shotAnim());
			shotAbsorbed -= 1;
			Destroy(col.gameObject);
		}
		if (shotAbsorbed <= 0)
		{
			Destroy(this.gameObject);
		}
	}

	IEnumerator shotAnim()
	{
		Color blue = new Color(0, 0.6f, 1, 0.4f);
		Color red = new Color(1, 0, 0, 0.4f);

		for(int i = 0; i < 6; i++)
		{
			this.GetComponent<SpriteRenderer>().color = red;
			yield return new WaitForSeconds(0.05f);
			this.GetComponent<SpriteRenderer>().color = blue;
			yield return new WaitForSeconds(0.05f);
		}
	}
}
