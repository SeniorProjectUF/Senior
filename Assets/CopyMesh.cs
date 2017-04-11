using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMesh : MonoBehaviour {

	public GameObject copyObject;
	public Mesh mesh2;
	private MCBlob blobsScript;
	public Vector3[] blobsPos;
	// Use this for initialization
	void Start () {
		blobsScript = copyObject.GetComponent<MCBlob>();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<MeshFilter>().sharedMesh = copyObject.GetComponent<MeshFilter> ().mesh;

		blobsPos = blobsScript.blobsPos;
	}
}
