using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject player;
	public Text scoreText;
	public static int score = 0;

	void Update () {
		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (pos.x > -1.9f && pos.x < 1.9) {
			player.transform.position = new Vector2 (pos.x, -4.35f);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject.Find ("ballSound").GetComponent<AudioSource> ().Play ();
		Destroy (col.gameObject);
		score++;
		scoreText.text = "SCORE: " + score;
	}
}
