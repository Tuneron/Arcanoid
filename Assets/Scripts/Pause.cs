using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPause(int value)
    {
        Debug.Log("Pause delay is start");
        StartCoroutine(StartPause(value));
        Debug.Log("Pause delay is over");
    }

    private IEnumerator StartPause(int value)
    {
        yield return new WaitForSeconds(value);
    }
}
