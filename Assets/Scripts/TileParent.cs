using UnityEngine;
using System.Collections;

public class TileParent : MonoBehaviour
{

	Transform[] Children;
	public int Row;
    
	void Start ()
	{
		Children = new Transform[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) {
			Children [i] = transform.GetChild (i);
		}

		switch (name) {
		case "Top":
			Row = 0;
			foreach (var child in Children) {
				child.gameObject.GetComponent<SpriteRenderer> ().material.color = Color.yellow;
			}                                 
			break;                            
		case "Middle":                        
			Row = 1;                          
			foreach (var child in Children) {                                 
				child.gameObject.GetComponent<SpriteRenderer> ().material.color = Color.green;
			}                                 
			break;                            
		case "Bottom":                        
			Row = 2;                          
			foreach (var child in Children) {                                 
				child.gameObject.GetComponent<SpriteRenderer> ().material.color = Color.red;
			}
			break;
		default:
			break;
		}
	}
}
