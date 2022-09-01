using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour {

	public GameObject explosionParticle;

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.name.Equals("GameOverZone")) {
			explosionParticle.transform.parent = null;
			explosionParticle.SetActive(true);
			GameObject.Find("GameManager").GetComponent<GameMenus> ().GameOver();
			Destroy(this.gameObject);
		}
    }
}
