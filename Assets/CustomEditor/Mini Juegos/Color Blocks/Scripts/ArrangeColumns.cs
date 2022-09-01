using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangeColumns : MonoBehaviour
{

    public void MoveColumns() {
        Invoke("MoveCol", 0.25f);
    }

    private void MoveCol() {
        GameObject[] allColumns = GameObject.FindGameObjectsWithTag("column");
        for(int i = 0; i < allColumns.Length; i++) {
            if(allColumns[i].transform.childCount == 0) {
                Destroy(allColumns[i].gameObject);
                for(int j = i; j < allColumns.Length; j++) {
                    allColumns[j].transform.position = new Vector2(allColumns[j].transform.position.x - 1, allColumns[j].transform.position.y);
                }
            }
        }
        GameObject.Find("GameManager").GetComponent<AvailableMoves> ().Moves();
    }
}
