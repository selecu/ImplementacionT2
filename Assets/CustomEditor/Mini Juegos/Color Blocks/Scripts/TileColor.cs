using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColor : MonoBehaviour {
	
	public int tileColor;
	public Color color;

	void Start () {
		tileColor = Random.Range(0, Vars.color);
		if(tileColor == 0) {
			color = new Color(0.2f,0.7f,0.9f);
		}else if(tileColor == 1) {
			color = new Color(0.6f,0.8f,0);
		}else if(tileColor == 2){
			color = new Color(1,0.26f,0.26f);
		}else if(tileColor == 3){
			color = new Color(1,0.73f,0.2f);
		} else {
			color = new Color(0.6f,0.4f,0.8f);
		}
		GetComponent<SpriteRenderer> ().color = color;
	}
}
