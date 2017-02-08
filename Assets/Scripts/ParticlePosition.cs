using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePosition : MonoBehaviour {

	public float[] xPosPoly;
	public float[] yPosPoly;
	public float[] zPosPoly;

	private TimeManipulation timeMan;
	private float time;

	// Use this for initialization
	void Start () {
		GameObject mainCamera = GameObject.Find("Main Camera");
		timeMan = mainCamera.GetComponent<TimeManipulation>();
	}
	
	// Update is called once per frame
	void Update () {

		time = timeMan.elapsedTime;

		print (calculatePositionWithPolyAndTime(xPosPoly, time));
		print (calculatePositionWithPolyAndTime(yPosPoly, time));
		print (calculatePositionWithPolyAndTime(zPosPoly, time));

		transform.position = new Vector3(calculatePositionWithPolyAndTime(xPosPoly, time), calculatePositionWithPolyAndTime(yPosPoly, time), calculatePositionWithPolyAndTime(zPosPoly, time));

	}

	float calculatePositionWithPolyAndTime(float[] poly, float time){
		float position = 0;
		for (int i = 0; i < poly.Length; i++) {
			position += poly [i] * Mathf.Pow (time, i);
		}
		return position;
	}
}
