using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public Vector3 Direction = Vector3.left;
    public float WalkingSpeed = 0.8f;
    public float MaxSpeed = 99.99f;
    public float Acceleration = .1f;
    private float _walkingSpeed;

    public GameObject Player;
    public float TriggerDistance = 3.0f;
    public float CatchDistance = .2f;

    public bool Triggered = false;
    public bool Caught = false;

    private Transform _transform;
    private Transform _playerTransform;

	// Use this for initialization
	void Start () {
	    _transform = GetComponent<Transform>();
        _playerTransform = Player.GetComponent<Transform>();
        _walkingSpeed = WalkingSpeed;
	}

	// Update is called once per frame
	void Update () {
        // Player distance
        Vector2 heading = _transform.position - _playerTransform.position;
        float playerDistance = heading.magnitude;
        Triggered = playerDistance < TriggerDistance;

        // Catch Player ?
        Caught = playerDistance < CatchDistance;
        if (Caught) {
            Debug.Log("Got it!");
            //Player.caught()
        }

        // Walk
        Vector3 oneDirection = Direction;
        float   oneWalkingSpeed = WalkingSpeed;
        if (Triggered) {
            _walkingSpeed += Acceleration * Time.deltaTime;
            oneDirection    = - heading / playerDistance;
            oneWalkingSpeed = _walkingSpeed;
            if (oneWalkingSpeed > MaxSpeed) 
                oneWalkingSpeed = MaxSpeed;
        } else {
            _walkingSpeed = WalkingSpeed;
        }
        
		_transform.localPosition += oneDirection * oneWalkingSpeed * Time.deltaTime;

	}
}
