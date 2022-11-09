using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LinternController : MonoBehaviour
{
    public GameObject backgroundTarget;
    public Vector3 startBackgroundPosition;
    public Vector3 startBackgroundScale;
    private void Start() =>
        SetBackgroundProperties();

    private void Update() =>
        UploadBackgroundProperties();

    public void SetBackgroundProperties()
    {
        startBackgroundPosition = backgroundTarget.transform.position;
        startBackgroundScale = backgroundTarget.transform.localScale;
    }

    public void UploadBackgroundProperties()
    {
        backgroundTarget.transform.position = startBackgroundPosition;
        backgroundTarget.transform.localScale = startBackgroundScale;
    }
}
