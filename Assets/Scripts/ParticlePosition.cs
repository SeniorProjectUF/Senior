using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePosition : MonoBehaviour {

	public float[] xPosPoly;
	public float[] yPosPoly;
	public float[] zPosPoly;
    public float xPosShift;
    public float yPosShift;
    public float zPosShift;
    public float disappearAfter = 0.0f;
    public bool shouldDisappear = false;
    public float appearAfter = 0.0f;
    public bool shouldAppear = false;

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

		transform.position = new Vector3(calculatePositionWithPolyAndTime(xPosPoly, xPosShift, time), calculatePositionWithPolyAndTime(yPosPoly, yPosShift, time), calculatePositionWithPolyAndTime(zPosPoly, zPosShift, time));

	}

	float calculatePositionWithPolyAndTime(float[] poly, float shift, float time){
		float position = 0;
		for (int i = 0; i < poly.Length; i++) {
			position += poly [i] * Mathf.Pow (time - shift, i);
		}
		return position;
	}
}
