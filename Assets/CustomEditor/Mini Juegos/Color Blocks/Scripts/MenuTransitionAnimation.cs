using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTransitionAnimation : MonoBehaviour {

	private Image transitionImage;
	private float color = 0;
	private float timer = 0;
	private bool up = true;

	// Use this for initialization
	void Start () {
		transitionImage = GetComponent<Image>();
	}

	void OnEnable() {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		timer+= Time.deltaTime;
		if(timer >= 0.01f) {
			timer = 0;
			if(up) {	
				color+=0.05f;
				if(color >= 1f) {
					up = false;
					ChangeMenu();
				}
			}else {
				color-=0.05f;
				if(color <= 0) {
					up = true;
					this.gameObject.SetActive(false);
				}
			}
			transitionImage.color = new Color(0, 0, 0, color);
		}
	}

	private void ChangeMenu() {
		if(Vars.currentMenu == 0) {
			GameObject.Find("GameManager").GetComponent<Menus> ().BackToMainMenu();
		}else if(Vars.currentMenu == 1) {
			GameObject.Find("GameManager").GetComponent<Menus> ().StartTheGame();
		}else if(Vars.currentMenu == 2) {
			GameObject.Find("GameManager").GetComponent<Menus> ().Replay();
		}
	}
}
