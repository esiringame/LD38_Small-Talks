using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public float WalkingSpeed = 0.8f;
    public Vector3 Direction = Vector3.left;

    public GameObject Player;
    public float TriggerDistance = 3.0f;

    public bool Triggered = false;

    private Transform _transform;
    private Transform _playerTransform;

	// Use this for initialization
	void Start () {
	    _transform = GetComponent<Transform>();
        _playerTransform = Player.GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
        // Triggered ?
        Vector2 heading = _transform.position - _playerTransform.position;
        float playerDistance = heading.magnitude;
        Triggered = playerDistance < TriggerDistance;
        Debug.Log("Distance: " + playerDistance);

        // Walk
        Vector3 oneDirection = Direction;
        if (Triggered) 
            oneDirection = - heading / playerDistance;
        
		_transform.localPosition += oneDirection * WalkingSpeed * Time.deltaTime;

	}
}
