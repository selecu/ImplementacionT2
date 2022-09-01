using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewTiles : MonoBehaviour {

	public void NewTiles() {
		Invoke("InstantiateNewTiles", 0.25f);
	}

	private void InstantiateNewTiles() {
		GameObject[] column = GameObject.FindGameObjectsWithTag("column");
		for(int i = 0; i < column.Length; i++) {
			while(column[i].transform.childCount < Vars.numberOfRows + Vars.level) {
				GameObject instance = Instantiate(Resources.Load("tile", typeof(GameObject))) as GameObject;
				int oddNumberOfRows = Vars.numberOfRows % 2 != 0? 1 : 0; 
				instance.transform.position = new Vector2(i - column.Length / 2 , (Vars.numberOfRows + oddNumberOfRows + Vars.level) / 2 - (Vars.numberOfRows + Vars.level - column[i].transform.childCount));
				instance.transform.parent = column[i].transform;
			}
		}	
	}
}
