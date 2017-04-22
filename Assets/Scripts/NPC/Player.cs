using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float WalkingSpeed = 1.0f;
    public Vector3 Direction = Vector3.left;
    private Transform _transform;
    public GameObject TextBoxManager;
    public bool isTalking = false;

    // Use this for initialization
    void Start () {
	    _transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		_transform.localPosition += Direction * WalkingSpeed * Time.deltaTime;
	}

    public bool triggered(int indexEnemy)
    {
        TextBoxManager.GetComponent<TextBoxManager>().talkTriggered(indexEnemy);
        isTalking = true;
        return isTalking;
    }
}
