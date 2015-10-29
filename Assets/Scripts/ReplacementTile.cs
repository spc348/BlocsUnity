using UnityEngine;
using System.Collections;

public class ReplacementTile : MonoBehaviour
{
	BoxCollider2D box;
	Rigidbody2D body;

	void OnEnable ()
	{
		gameObject.AddComponent<BoxCollider2D> ();
		gameObject.AddComponent<Rigidbody2D> ();
		box = gameObject.GetComponent<BoxCollider2D> ();
		body = gameObject.GetComponent<Rigidbody2D> ();

		box.isTrigger = true;
		box.size = new Vector2 (.1f, .1f);

		body.isKinematic = true;
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.CompareTag ("Tile")) {
			other.GetComponent<Tile> ().Relocated = true;
			other.transform.SetParent (this.transform);
			other.transform.localScale = new Vector3 (1.5f, 1.5f);
			other.transform.localPosition = Vector3.zero;
		}
	}
}
