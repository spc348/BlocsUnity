using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
	Transform InitialParent;
	Vector3 InitialPosition;
	Camera Camera_Main;
	int Row;
	public Sprite EmptySprite;
	public bool Relocated;

	void Start ()
	{
		InitialParent = transform.parent;
		InitialPosition = transform.position;
		Camera_Main = Camera.main;
		Relocated = false;
	}

	void OnMouseDown ()
	{
		Row = GetComponentInParent<TileParent> ().Row;
		transform.SetParent (null);
	}

	void OnMouseDrag ()
	{
		if (!Relocated) {
			transform.position = Camera_Main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x,
				Input.mousePosition.y, Camera_Main.nearClipPlane));
		}
	}

	void OnMouseUp ()
	{
		if (!Relocated) {
			transform.SetParent (InitialParent);
			transform.position = InitialPosition;
		} else {
			GameObject Replacement = new GameObject ();
			Replacement.transform.SetParent (InitialParent);
			Replacement.transform.position = InitialPosition;
			Replacement.AddComponent<SpriteRenderer> ();
			Replacement.GetComponent<SpriteRenderer> ().sprite = EmptySprite;
			Replacement.transform.localScale = new Vector3 (5, 5);
			Replacement.AddComponent<ReplacementTile> ();

			Relocated = false;
		}
	}

}
