using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    [SerializeField]
    float horSpeed, verSpeed;
    [SerializeField]
    Vector3 Up, Down, Right, Left;

    private enum State
    {
        Idle,
        Walking,
        Hidding,
        Talking
    }

    private State state;

	// Use this for initialization
	void Start () {
        state = State.Idle;
        Up = transform.up;
        Down = -transform.up;
        Right = transform.right;
        Left = -transform.right;
	}
	
	// Update is called once per frame
	void Update () {
        switch(state)
        {
            case State.Idle:
                break;
            case State.Walking:
                break;
            case State.Talking:
                break;
            case State.Hidding:
                break;
        }

        Vector3 move = Vector3.zero;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (state != State.Hidding && state != State.Talking)
        {
            if (vertical > 0)
            {
                move += Up * horSpeed;
            }
            else if (vertical < 0)
            {
                move += Down * horSpeed;
            }
            if (horizontal > 0)
            {
                move += Right * verSpeed;
            }
            else if (horizontal < 0)
            {
                move += Left * verSpeed;
            }
            transform.position += (move * Time.deltaTime);
        }

        if (Input.GetButtonDown("Action"))
        {
            /*if (binNear)
            {

            }*/
        }
    }
}
