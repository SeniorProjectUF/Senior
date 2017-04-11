using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeSubparticlePosition : MonoBehaviour {

	public int blobID;
	private CopyMesh blobs;

	// Use this for initialization
	void Start () {

		GameObject blobGameObject = transform.parent.gameObject;
		blobs = blobGameObject.GetComponent<CopyMesh>();
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = blobs.blobsPos [blobID];
	}
}
