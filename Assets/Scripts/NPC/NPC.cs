using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public float WalkingSpeed = 0.8f;
    public Vector3 Direction = Vector3.left;

    public GameObject Player;

    public float TriggerDistance = 3.0f;
    public float CatchDistance = .2f;

    public bool Triggered = false;
    public bool Caught = false;

    private Transform _transform;
    private Transform _playerTransform;
    private int indexNPC = 1;

    // Use this for initialization
    void Start () {
	    _transform = GetComponent<Transform>();
        _playerTransform = Player.GetComponent<Transform>();
    }

	// Update is called once per frame
	void Update () {
        if (Player.GetComponent<Player>().isTalking)
        {
            // Walk
            Vector3 oneDirection = Direction;
            _transform.localPosition += oneDirection * WalkingSpeed * Time.deltaTime;
        }
        else // Player is 'open' to talk
        {
            // Player distance
            Vector2 heading = _transform.position - _playerTransform.position;
            float playerDistance = heading.magnitude;

            Triggered = playerDistance < TriggerDistance;
            // Catch Player 
            Caught = playerDistance < CatchDistance;

            // Walk
            Vector3 oneDirection = Direction;

            if (Triggered)
                oneDirection = -heading / playerDistance;
            _transform.localPosition += oneDirection * WalkingSpeed * Time.deltaTime;

            if (Caught)
            {
                if (Player.GetComponent<Player>().triggered(indexNPC)) ;
                    //_transform.localPosition = Player.GetComponent<Player>().transform.localPosition;
            }
            
        } 
    }    
}
