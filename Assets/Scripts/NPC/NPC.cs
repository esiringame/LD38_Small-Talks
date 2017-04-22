using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public float WalkingSpeed = 1.0f;
    public Vector3 Direction = Vector3.left;
    private Transform _transform;

	// Use this for initialization
	void Start () {
	    _transform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		_transform.localPosition += Direction * WalkingSpeed * Time.deltaTime;
	}
}
