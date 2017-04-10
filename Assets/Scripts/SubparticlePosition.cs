using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubparticlePosition : MonoBehaviour {

	public int blobID;

	private MCBlob blobs;
	private Vector3 position;
	private Vector3 breakPosition;
	public float disappearAfter = 0.0f;
	public bool shouldDisappear = false;

	// Use this for initialization
	void Start () {
		GameObject blobGameObject = transform.parent.gameObject;
		blobs = blobGameObject.GetComponent<MCBlob>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!blobs.isBroken) {
			transform.localPosition = blobs.blobsPos [blobID];
		} else {
			transform.position = blobs.blobsPos [blobID];
		}
	}
}
