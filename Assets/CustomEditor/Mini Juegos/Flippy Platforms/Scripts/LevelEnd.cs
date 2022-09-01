using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		GameObject.Find("Ball").GetComponent<Rigidbody2D>().isKinematic  = true;
		GameObject.Find("Ball").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		GameObject.Find("GameManager").GetComponent<GameMenus> ().LevelCompleted(); 
    }
}
