using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour {

	public GameObject mainMenuGUI;
	public GameObject gameplayGUI;
	public GameObject gameoverMenu;
	public GameObject pauseMenu;
	public GameObject player;
	public GameObject scoreText;
	public LoadBalls balls;

	public void mainMenu() {
		mainMenuGUI.SetActive (true);
		gameplayGUI.SetActive (false);
		player.SetActive (false);
		gameoverMenu.SetActive (false);
		continueGame ();
		balls.enabled = false;
		balls.reset ();
		Player.score = 0;
		scoreText.GetComponent<Text>().text = "SCORE: 0";
		destroyBalls ();
	}
	public void replay() {
		mainMenuGUI.SetActive (false);
		gameplayGUI.SetActive (true);
		player.SetActive (true);
		gameoverMenu.SetActive (false);
		continueGame ();
		balls.enabled = true;
		balls.reset ();
		Player.score = 0;
		scoreText.GetComponent<Text>().text = "SCORE: 0";
		destroyBalls ();
	}
	public void startTheGame() {
		GameObject.Find ("buttonClick").GetComponent<AudioSource> ().Play ();
		balls.enabled = true;
		mainMenuGUI.SetActive (false);
		gameplayGUI.SetActive (true);
		player.SetActive (true);
	}
	public void pauseGame() {
		GameObject.Find ("buttonClick").GetComponent<AudioSource> ().Play ();
		Time.timeScale = 0;
		pauseMenu.SetActive (true);
		player.GetComponent<Player> ().enabled = false;
	}
	public void continueGame() {
		GameObject.Find ("buttonClick").GetComponent<AudioSource> ().Play ();
		Time.timeScale = 1;
		player.GetComponent<Player> ().enabled = true;
		pauseMenu.SetActive (false);
	}
	private void destroyBalls() {
		GameObject[] gameBalls = GameObject.FindGameObjectsWithTag ("ball");
		for (int i = 0; i < gameBalls.Length; i++) {
			Destroy (gameBalls [i]);
		}
	}
}
