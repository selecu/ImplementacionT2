using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeModeTimer : MonoBehaviour {

	public GameObject gameOverMenu;
	public float timer = 61;
	private Text timerText;

	void OnEnable() {
		timer = 61;
		timerText = GetComponent<Text>();
	}
	
	void Update () {
		timer -= Time.deltaTime;
		timerText.text = "" + (int)timer;
		if(timer <= 0) {
			GameObject.Find("GameManager").GetComponent<Menus>().ClearTheScene();
			gameOverMenu.SetActive(true);
			gameOverMenu.transform.Find("Score").GetComponent<Text> ().text = "YOUR SCORE: " + Vars.score;
			gameOverMenu.transform.Find("BestScore").GetComponent<Text> ().text = "BEST SCORE: " + PlayerPrefs.GetInt("bestScoreTime");
			GameObject.Find("GameManager").GetComponent<Menus> ().ClearTheScene(); 
			this.gameObject.SetActive(false);
		}
	}
}
