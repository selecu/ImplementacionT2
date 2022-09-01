using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBalls : MonoBehaviour {

	private float ballWaveTimer = 1.5f;
	private int waveCounter = 0;
	private int increaseBallSpeedEveryThisAmountOfWaves = 3;
	private float ballSpeed = 0.1f;
	private float timer = 0;

	void Update () {
		timer += Time.deltaTime;
		if (timer >= (ballWaveTimer - Random.Range(0,0.5f))) {
			waveCounter++;
			timer = 0;
			if (ballWaveTimer > 0.55f) {
				ballWaveTimer -= 0.005f;
			}

			if (waveCounter % increaseBallSpeedEveryThisAmountOfWaves == 0) {
				ballSpeed += 0.01f;
			}

			GameObject ball = (GameObject)Resources.Load ("ball");
			ball.GetComponent<Rigidbody2D> ().gravityScale = ballSpeed;
			ball.GetComponent<CircleCollider2D>().isTrigger = true;
			Instantiate (ball, new Vector2 (Random.Range(-2f,2f), 7), Quaternion.identity);
		}
	}

	public void reset() {
		ballWaveTimer = 1.5f;
		waveCounter = 0;
		increaseBallSpeedEveryThisAmountOfWaves = 3;
		ballSpeed = 0.1f;
		timer = 0;
	}
}
