using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public GameObject gameOverMenu;
	public GameObject player;
	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject.Find ("loseSound").GetComponent<AudioSource> ().Play ();
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("ball");
		for (int i = 0; i < balls.Length; i++) {
			Destroy (balls [i]);
		}
		gameOverMenu.SetActive (true);
		GameObject.Find ("Canvas").GetComponent<LoadBalls> ().enabled = false;
		player.SetActive (false);
	}
}
