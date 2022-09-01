using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameMenus : MonoBehaviour {

	public GameObject LevelCompletedDialog;
	public GameObject Wheel;
	public GameObject PauseButton;
	public GameObject PauseMenu;
	public GameObject GameOverMenu;
	private AudioSource buttonClickSound;
	public GameObject MainMenu;
	public GameObject LevelSelectMenu;
	public GameObject SoundOffImage;

	void Start() {
		Application.targetFrameRate = 300;
		buttonClickSound = GameObject.Find("buttonClickSound").GetComponent<AudioSource>();
		SteeringWheel.axis = 0;

		if(SceneManager.GetActiveScene().name.Equals("mainMenu")) {
			if(AudioListener.volume == 1) {
			 	SoundOffImage.SetActive(false);
			}else{
				SoundOffImage.SetActive(true);
			}
		}
	}

	public void ShowMainMenu() {
		buttonClickSound.Play();
		MainMenu.SetActive(true);
		LevelSelectMenu.SetActive(false);
	}

	public void ShowLevelSelectMenu() {
		buttonClickSound.Play();
		MainMenu.SetActive(false);
		LevelSelectMenu.SetActive(true);
	}

	public void SoundOnOff() {
		if(AudioListener.volume == 1) {
			 AudioListener.volume = 0;
			 SoundOffImage.SetActive(true);
		}else{
			AudioListener.volume = 1;
			 SoundOffImage.SetActive(false);
		}
		buttonClickSound.Play();
	}

	public void LoadLevel() {
		buttonClickSound.Play();
		SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name);
	}
	public void NextLevel() {
		buttonClickSound.Play();
		string nextLevelNumber = (Int32.Parse(SceneManager.GetActiveScene().name) + 1).ToString();
		SceneManager.LoadScene(nextLevelNumber);
	}

	public void ExitToMainMenu() {
		buttonClickSound.Play();
		Time.timeScale = 1;
		SceneManager.LoadScene("mainMenu");
	}

	public void LevelCompleted() {
		int currLevel = Int32.Parse(SceneManager.GetActiveScene().name);
		if(PlayerPrefs.GetInt("levelUnlock", 0) < currLevel) {
			PlayerPrefs.SetInt("levelUnlock", currLevel + 1);
		}
		Invoke("ShowLevelCompleteDialog", 0.7f);
	}

	private void ShowLevelCompleteDialog() {
		LevelCompletedDialog.SetActive(true);
		Wheel.SetActive(false);
		PauseButton.SetActive(false);
		GameObject.Find("levelCompleteSound").GetComponent<AudioSource>().Play();
	}

	public void GameOver() {
		GameObject.Find("ballSplatSound").GetComponent<AudioSource>().Play();
		Wheel.SetActive(false);
		PauseButton.SetActive(false);
		Invoke("ShowGameOverMenu", 1.2f);
	}

	private void ShowGameOverMenu() {
		GameOverMenu.SetActive(true);
	}

	public void ShowPauseMenu() {
		GameObject.Find("pauseSound").GetComponent<AudioSource>().Play();
		PauseMenu.SetActive(true);
		PauseButton.SetActive(false);
		Time.timeScale = 0;
	}

	public void HidePauseMenu() {
		buttonClickSound.Play();
		PauseMenu.SetActive(false);
		PauseButton.SetActive(true);
		Time.timeScale = 1;
	}
	public void Reply() {
		buttonClickSound.Play();
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void Exit() {
		buttonClickSound.Play();
		Application.Quit();
	}
}
