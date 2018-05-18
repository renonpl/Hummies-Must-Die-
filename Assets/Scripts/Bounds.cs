using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {

    private BoxCollider2D bounds;
    private CameraControl theCamera;

	// Use this for initialization
	void Start () {
        bounds = GetComponent<BoxCollider2D>();
        theCamera = FindObjectOfType<CameraControl>();
        theCamera.SetBounds(bounds);
	}
	
}
