using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTiles : MonoBehaviour {

	public Sprite tileSprite;
	public GameObject tilesLeftIndicatiorSlider;
	private int startPosRows;
	private int startPosColumn;
	private int oddNumber = 0;
	private int oddNumberColumn = 0;
	GameObject[] columns;
	GameObject instance;
	float borderAddXPosition = 0;
	float borderAddYPosition = 0;
    public GameObject tablero;

    public void Init(int numberOfRows, int numberOfColumns) {
		borderAddXPosition = 0;
		borderAddYPosition = 0;
		oddNumber = 0;
		oddNumberColumn = 0;

		if(numberOfRows / 2 > numberOfColumns) {
			Camera.main.orthographicSize = numberOfRows / 2 + 1;
		}else {
			Camera.main.orthographicSize = numberOfColumns + 1;
		}

		if(numberOfRows % 2 == 0) {
			oddNumber = 0;
			startPosRows = numberOfRows / 2;
			borderAddYPosition = 0.5f;
		}else {
			oddNumber = 1;
			startPosRows = (numberOfRows -1) / 2;	
		}

		if(numberOfColumns % 2 == 0) {
			oddNumberColumn = 0;
			startPosColumn = numberOfColumns / 2;
			Camera.main.transform.position = new Vector3(-0.5f, 0, -10);
			borderAddXPosition = 0.5f;
		}else {
			oddNumberColumn = 1;
			startPosColumn = (numberOfColumns -1) / 2;
			Camera.main.transform.position = new Vector3(0, 0, -10);	
		}


		columns = new GameObject[numberOfColumns + 1];
		
		
		Vars.numberOfTiles = 0;

		for(int x = -startPosColumn; x < startPosColumn + oddNumberColumn; x++) {
			columns[(x + startPosColumn)] = new GameObject("column" + (x + startPosColumn)) ;
			columns[(x + startPosColumn)].gameObject.tag = "column";
			for(int y = -startPosRows; y < startPosRows + oddNumber; y++) {
				instance = Instantiate(Resources.Load("tile", typeof(GameObject))) as GameObject;
				instance.transform.position = new Vector2(x, y);
				instance.transform.parent = columns[(x + startPosColumn)].transform;
				Vars.numberOfTiles++;
				columns[(x + startPosColumn)].transform.transform.parent = tablero.transform;
			}
		}
		tilesLeftIndicatiorSlider.GetComponent<Slider>().maxValue = Vars.numberOfTiles;
		tilesLeftIndicatiorSlider.GetComponent<Slider>().value = 0;

		GameObject bottomCollider = Instantiate(Resources.Load("bottomCollider", typeof(GameObject))) as GameObject;
		bottomCollider.transform.position = new Vector2(0, -startPosRows-1);
		bottomCollider.gameObject.name = "bottomCollider";
		bottomCollider.transform.parent = tablero.transform;

		//Code below will create borders
		instance = Instantiate(Resources.Load("border", typeof(GameObject))) as GameObject;
		instance.transform.localScale  = new Vector2(numberOfColumns, numberOfColumns * 10);
		instance.transform.position = new Vector2(numberOfColumns - borderAddXPosition, 0);
		instance.tag = "border";
		instance.name = "borderRight";
		instance.transform.parent = tablero.transform;

		instance = Instantiate(Resources.Load("border", typeof(GameObject))) as GameObject;
		instance.transform.localScale  = new Vector2(numberOfColumns, numberOfColumns * 10);
		instance.transform.position = new Vector2(-numberOfColumns - borderAddXPosition, 0);
		instance.tag = "border";
		instance.name = "borderLeft";
		instance.transform.parent = tablero.transform;

		instance = Instantiate(Resources.Load("border", typeof(GameObject))) as GameObject;
		instance.transform.localScale  = new Vector2(numberOfRows * 10 , numberOfRows);
		instance.transform.position = new Vector2(0, numberOfRows - borderAddYPosition);
		instance.tag = "border";
		instance.name = "borderTop";
		instance.transform.parent = tablero.transform;

		instance = Instantiate(Resources.Load("border", typeof(GameObject))) as GameObject;
		instance.transform.localScale  = new Vector2(numberOfRows * 10, numberOfRows);
		instance.transform.position = new Vector2(0, -numberOfRows - borderAddYPosition);
		instance.tag = "border";
		instance.name = "borderBottom";
		instance.transform.parent = tablero.transform;
	}
}
