using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableMoves : MonoBehaviour{

    public GameObject GameOverMenu;

    bool hasAvailableMove = false;
    public void Moves() {
        hasAvailableMove = false;
        GameObject[] allTiles = GameObject.FindGameObjectsWithTag("tile");
        for(int i = 0; i < allTiles.Length; i++) {
            Collider2D leftTile = Physics2D.OverlapCircle(new Vector2(allTiles[i].transform.position.x - 1, allTiles[i].transform.position.y), 0, 1);
            CheckAvailableMoves(allTiles[i], leftTile);
             if(hasAvailableMove) break;
            Collider2D rightTile = Physics2D.OverlapCircle(new Vector2(allTiles[i].transform.position.x + 1, allTiles[i].transform.position.y), 0, 1);
            CheckAvailableMoves(allTiles[i], rightTile);
             if(hasAvailableMove) break;
            Collider2D upperTile = Physics2D.OverlapCircle(new Vector2(allTiles[i].transform.position.x, allTiles[i].transform.position.y + 1), 0, 1);
            CheckAvailableMoves(allTiles[i], upperTile);
             if(hasAvailableMove) break;
            Collider2D bottomTile = Physics2D.OverlapCircle(new Vector2(allTiles[i].transform.position.x, allTiles[i].transform.position.y - 1), 0, 1);
            CheckAvailableMoves(allTiles[i], bottomTile);
             if(hasAvailableMove) break;
        }
        if(!hasAvailableMove) {
          if(GameObject.FindGameObjectsWithTag("tile").Length > 0) {
              Invoke("GameOverSound", 0.5f);
              Invoke("ShowGameOverMenu", 1f);
          }else {
              Vars.level++;
              if(Vars.level == 5) {
                Vars.color = 4;
              }else if(Vars.level == 10) {
                Vars.color = 5;
              }
              Vars.canDestoryTiles = true;
              Destroy(GameObject.Find("borderLeft"));
              Destroy(GameObject.Find("borderRight"));
              Destroy(GameObject.Find("borderTop"));
              Destroy(GameObject.Find("borderBottom"));
              Destroy(GameObject.Find("bottomCollider"));
              GameObject.Find("GameManager").GetComponent<CreateTiles> ().Init(20 + Vars.level, 10 + Vars.level);
              GameObject.Find("LevelClearSound").GetComponent<AudioSource> ().Play();
          }
		    	
		    }
    }
    

  private void CheckAvailableMoves(GameObject tile, Collider2D col) {
			if(col == null || col.gameObject.name.Equals("bottomCollider")) return;
			if(tile.GetComponent<TileColor> ().tileColor == col.GetComponent<TileColor> ().tileColor) {
			    hasAvailableMove = true;
			    return;
			}
	}

  private void GameOverSound() {
      GameObject.Find("GameOverSound").GetComponent<AudioSource> ().Play();
  }

  private void ShowGameOverMenu() {
      GameOverMenu.SetActive(true);
      GameOverMenu.transform.Find("Score").GetComponent<Text> ().text = "YOUR SCORE: " + Vars.score;
      GameOverMenu.transform.Find("BestScore").GetComponent<Text> ().text = "BEST SCORE: " + PlayerPrefs.GetInt("bestScoreStandard");
      GameObject.Find("GameManager").GetComponent<Menus> ().ClearTheScene(); 
  }
}
