using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

	public GameObject mainMenuUI;
	public GameObject gameplayUI;
	public GameObject scoreMenu;
	public GameObject timer;
	public GameObject levelIndicatorSlider;
	public GameObject pauseMenu;
	public GameObject GameOverMenu;
	public GameObject Timer;
	public GameObject transitionAnimation;
	private AudioSource buttonClick;

	void Start() {
		Vars.restart = 0;
		buttonClick = GameObject.Find("ButtonClickSound").GetComponent<AudioSource>();
		Application.targetFrameRate = 300;
	}

	public void StandardMode() {
		Vars.mode = 0;
		Vars.score = 0;
		levelIndicatorSlider.SetActive(true);
		timer.SetActive(false);
		StartTheGameAnimation();
	}

	public void TimeMode() {
		Vars.mode = 1;
		Vars.score = 0;
		levelIndicatorSlider.SetActive(false);
		timer.SetActive(true);
		StartTheGameAnimation();
	}

	private void StartTheGameAnimation() {
		transitionAnimation.SetActive(true);
		Vars.currentMenu = 1;
	}

	public void StartTheGame() {
		mainMenuUI.SetActive(false);
		gameplayUI.SetActive(true);
		Vars.numberOfRows = 20;
		Vars.numberOfColumns = 10;
		GameObject.Find("GameManager").GetComponent<CreateTiles> ().Init(Vars.numberOfRows, Vars.numberOfColumns);
		if(Vars.mode == 1) {
			timer.SetActive(true);
			timer.GetComponent<TimeModeTimer> ().timer = 61;
		}
	}

	public void ShowHighScoreMenu() {
		buttonClick.Play();
		scoreMenu.SetActive(true);
		scoreMenu.transform.Find("Dialog").transform.Find("StandardMode").GetComponent<Text> ().text = "STANDARD MODE: " + PlayerPrefs.GetInt("bestScoreStandard");
		scoreMenu.transform.Find("Dialog").transform.Find("TimeMode").GetComponent<Text> ().text = "TIME MODE: " + PlayerPrefs.GetInt("bestScoreTime");
	}

	public void HideHighScoreMenu() {
		buttonClick.Play();
		scoreMenu.SetActive(false);
	}

	public void ShowPauseMenu() {
		buttonClick.Play();
		Vars.pause = 1;
		Time.timeScale = 0;
		pauseMenu.SetActive(true);
	}

	public void HidePauseMenu() {
		buttonClick.Play();
		Vars.pause = 0;
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
	}

	public void ReplayTransition() {
		buttonClick.Play();
		transitionAnimation.SetActive(true);
		Vars.currentMenu = 2;
	}

	public void Replay (){
		GameOverMenu.SetActive(false);
		Vars.RestartVariables();
		Vars.restart = 1;
		Vars.pause = 0;
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
		ClearTheScene();
		GameObject.Find("ScoreText").GetComponent<Text> (). text = "SCORE: " + Vars.score;
		StartTheGame();
	}

	public void BackToMainMenuTransition() {
		buttonClick.Play();
		transitionAnimation.SetActive(true);
		Vars.currentMenu = 0;
	}

	public void BackToMainMenu() {
		GameOverMenu.SetActive(false);
		Vars.RestartVariables();
		Vars.restart = 1;
		Vars.pause = 0;
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
		ClearTheScene();
		GameObject.Find("ScoreText").GetComponent<Text> (). text = "SCORE: " + Vars.score;
		mainMenuUI.SetActive(true);
		gameplayUI.SetActive(false);
	}

	public void ExitTheGame() {
		buttonClick.Play();
		Application.Quit();
	}

	public void ClearTheScene() {
		GameObject[] tiles = GameObject.FindGameObjectsWithTag("tile");
		for(int i = 0; i < tiles.Length; i++) {
			Destroy(tiles[i]);
		}

		GameObject[] columns = GameObject.FindGameObjectsWithTag("column");
		for(int i = 0; i < columns.Length; i++) {
			Destroy(columns[i]);
		}

		GameObject[] borders = GameObject.FindGameObjectsWithTag("border");
		for(int i = 0; i < borders.Length; i++) {
			Destroy(borders[i]);
		}

		GameObject[] score = GameObject.FindGameObjectsWithTag("score");
		for(int i = 0; i < score.Length; i++) {
			Destroy(score[i]);
		}

		Destroy(GameObject.Find("bottomCollider"));
	}

	void OnApplicationQuit(){
      GameObject[] allTiles = GameObject.FindGameObjectsWithTag("tile");
      for(int i = 0; i < allTiles.Length; i++) {
        Destroy(allTiles[i]);
      }
  	}

}
