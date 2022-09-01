using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

	public float backgroundMovementSpeed = 0.005f;
	public GameObject[] backgrounds;
	private Transform[] backgroundsTransform = new Transform[2];

	void Start() {
		backgroundsTransform [0] = backgrounds [0].GetComponent<Transform> ();
		backgroundsTransform [1] = backgrounds [1].GetComponent<Transform> ();
	}

	void Update () {
		backgroundsTransform [0].position = new Vector2 (0, backgroundsTransform [0].position.y + backgroundMovementSpeed);
		backgroundsTransform [1].position = new Vector2 (0, backgroundsTransform [1].position.y + backgroundMovementSpeed);

		if (backgroundsTransform [0].position.y > 12) {
			backgroundsTransform [0].position = new Vector2 (0, backgroundsTransform [1].position.y - 12.8f);
		}
		if (backgroundsTransform [1].position.y > 12) {
			backgroundsTransform [1].position = new Vector2 (0, backgroundsTransform [0].position.y - 12.8f);
		}
	}
}
