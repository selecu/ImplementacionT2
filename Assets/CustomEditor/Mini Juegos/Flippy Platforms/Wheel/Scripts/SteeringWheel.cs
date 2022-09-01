using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SteeringWheel : MonoBehaviour {

	public GameObject steeringWheel;

	public static float zRot;
	[Range(100, 1000)]
	private float angle;
	public static float axis;
	[HideInInspector]
	public float rotation = 0;
	float previousRotation;

	public void OnPointerDown(BaseEventData data) {
		PointerEventData pointerData = data as PointerEventData;

		angle = Mathf.Atan2(steeringWheel.transform.position.x - pointerData.position.x, steeringWheel.transform.position.y - pointerData.position.y);
		zRot = steeringWheel.transform.eulerAngles.z - (Mathf.Rad2Deg * -angle);
		steeringWheel.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * -angle + zRot, Vector3.forward);
	}


	public void RotateWheel(BaseEventData data) {
		
		PointerEventData pointerData = data as PointerEventData;

		previousRotation = steeringWheel.transform.eulerAngles.z;
		angle = Mathf.Atan2(steeringWheel.transform.position.x - pointerData.position.x, steeringWheel.transform.position.y - pointerData.position.y);
		rotation += Mathf.DeltaAngle(Mathf.Rad2Deg * -angle + zRot, previousRotation);

		steeringWheel.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * -angle + zRot, Vector3.forward);

		zRot = steeringWheel.transform.eulerAngles.z - (Mathf.Rad2Deg * -angle);

		axis = steeringWheel.transform.eulerAngles.z;
	}
}
