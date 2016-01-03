using UnityEngine;
using System.Collections;

public class BlankTile : MonoBehaviour
{
	Color InitialColor;

	void Start ()
	{
		InitialColor = GetComponent<Renderer> ().material.color;
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.CompareTag ("Tile")) {
			other.GetComponent<Tile> ().Relocated = true;
			other.transform.SetParent (transform);
			other.transform.localScale = new Vector3 (.5f, .5f);
			other.transform.localPosition = Vector3.zero;
		}
	}
}
