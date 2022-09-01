using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NearbyTilesWithSameColor : MonoBehaviour {

	private float radius = 0f;
	private AudioSource tileExplosion;
	private bool isTileActive = true;

	void Start() {
		tileExplosion = GameObject.Find("ExplosionSound").GetComponent<AudioSource>();
	}

	void OnMouseDown(){
		Vars.restart = 0;
		if(Vars.pause == 1) {
			return;
		}
		if(!Vars.canDestoryTiles) return;
		Vars.canDestoryTiles = false;
        CheckNearbyTiles();
		GameObject[] tiles = GameObject.FindGameObjectsWithTag("tile");
		for(int i = 0; i < tiles.Length; i++) {
			tiles[i].GetComponent<NearbyTilesWithSameColor> ().MoveTileDown();
		}

		if(Vars.mode == 1) {
			GameObject.Find("GameManager").GetComponent<AddNewTiles> ().NewTiles();
		}
		GameObject.Find("GameManager").GetComponent<ArrangeColumns> ().MoveColumns();
		GameObject.Find("GameManager").GetComponent<Score> ().ShowScore(Input.mousePosition.x, Input.mousePosition.y);
    }
	
	public void CheckNearbyTiles () {//This method will check if there is a nearby tile with the same color on the left, right, bottom and top of the clicked or destroyed tile
		Collider2D leftTile = Physics2D.OverlapCircle(new Vector2(transform.position.x - 1, transform.position.y), radius, 1);
		CheckTheColors(leftTile);

		Collider2D rightTile = Physics2D.OverlapCircle(new Vector2(transform.position.x + 1, transform.position.y), radius, 1);
		CheckTheColors(rightTile);

		Collider2D upperTile = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + 1), radius, 1);
		CheckTheColors(upperTile);

		Collider2D bottomTile = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 1), radius, 1);
		CheckTheColors(bottomTile);
	}

	public void MoveTileDown() {
		Invoke("Move", 0.25f);
	}

	private void Move() {
		Collider2D[] bottomTile = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 1), radius, 1);
		while(bottomTile.Length == 0) {
			bottomTile = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 1), radius, 1);
			if(bottomTile.Length != 0) break;
			transform.position = new Vector2(transform.position.x, transform.position.y - 1);
		}
		Vars.canDestoryTiles = true;

		if(Vars.combo > 0) {
			Vars.score += Vars.combo * Vars.combo;
			GameObject.Find("ScoreText").GetComponent<Text> (). text = "SCORE: " + Vars.score;
			Vars.combo = 0;

			if(Vars.mode == 0) {
				if(Vars.score > PlayerPrefs.GetInt("bestScoreStandard")) {
					PlayerPrefs.SetInt("bestScoreStandard" , Vars.score);
				}
			}else if(Vars.mode == 1) {
				if(Vars.score > PlayerPrefs.GetInt("bestScoreTime")) {
					PlayerPrefs.SetInt("bestScoreTime" , Vars.score);
				}
			}

		}
	}

	private void CheckTheColors(Collider2D col) {
		if(col == null || col.gameObject.name.Equals("bottomCollider")) return;
		if(GetComponent<TileColor> ().tileColor == col.GetComponent<TileColor> ().tileColor) {

			if(col.gameObject.transform.Find("explosion") != null) {
				GameObject expl = col.gameObject.transform.Find("explosion").gameObject;
				expl.transform.parent = null;
				ParticleSystem ps = expl.GetComponent<ParticleSystem>();
				var main = ps.main;
				main.startColor = col.GetComponent<TileColor> ().color;
				expl.SetActive(true);	
			}
				
			if(this.gameObject.transform.Find("explosion") != null) {
				GameObject expl = this.gameObject.transform.Find("explosion").gameObject;
				expl.transform.parent = null;
				ParticleSystem ps = expl.GetComponent<ParticleSystem>();
				var main = ps.main;
				main.startColor = col.GetComponent<TileColor> ().color;
				expl.SetActive(true);
			}

			Destroy(col.gameObject);

			if(isTileActive) {
				isTileActive = false;
				if(!tileExplosion.isPlaying) {
					tileExplosion.Play();
				}
				Destroy(this.gameObject);
			}
		}
	}

	void OnDestroy() {
		if(Vars.restart == 1) return;
		Vars.combo++;
		Vars.numberOfTiles--;
		if(GameObject.Find("LevelIndicatorSlider") != null) {
			Slider slider = GameObject.Find("LevelIndicatorSlider").GetComponent<Slider>();
			float sliderMaxValue = slider.maxValue;
			slider.value = sliderMaxValue - Vars.numberOfTiles;
		}
	
        GetComponent<NearbyTilesWithSameColor> ().CheckNearbyTiles();		
    }
}