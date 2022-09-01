using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsRotation : MonoBehaviour {

	void Update () {
		
		Quaternion rotation = Quaternion.Euler(0, 0, SteeringWheel.axis);
		transform.rotation = rotation;
	}
}
