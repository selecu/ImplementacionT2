using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBook : MonoBehaviour
{

    public GameObject check;
    // Start is called before the first frame update
    void Start()
    {
        check.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(15);
        check.SetActive(true);
        StopCoroutine(wait());
    }
}
