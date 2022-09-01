using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	float x;
	float y;

	public void ShowScore(float x, float y) {
		this.x = x;
		this.y = y;
		Invoke("InstantiateScoreGameObject", 0.1f);
	}

	private void InstantiateScoreGameObject() {
		if(Vars.combo == 0) return;
		Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 9));
		GameObject scoreTxt = Instantiate(Resources.Load("ScoreTxt", typeof(GameObject))) as GameObject;
		scoreTxt.transform.position = point;
		scoreTxt.tag = "score";
		scoreTxt.GetComponent<TextMesh>().text = "+" + Vars.combo * Vars.combo;
		//Vars.combo = 0;
	}
}
