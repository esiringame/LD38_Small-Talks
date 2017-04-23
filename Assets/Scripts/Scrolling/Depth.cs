using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour {
    private Transform _transform;
    private Transform _cameraTransform;
    private float depth;

	// Use this for initialization
	void Start () {
	    _transform = GetComponent<Transform>();
	    //_cameraTransform = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        _transform.localPosition = new Vector3(_transform.localPosition.x, _transform.localPosition.y, _transform.localPosition.y * 1 + 20);
	}
}
