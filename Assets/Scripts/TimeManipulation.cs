using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManipulation : MonoBehaviour {

    public float elapsedTime = 0.0f;
    public float timeStep = 0.01f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
            elapsedTime -= timeStep;
        if (Input.GetKey(KeyCode.RightArrow))
            elapsedTime += timeStep;
    }
}
