using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

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
    void Start()
    {
        state = State.Idle;
        Up = transform.up;
        Down = -transform.up;
        Right = transform.right;
        Left = -transform.right;
    }

    void Movement()
    {
        if (state == State.Idle || state == State.Walking)
        {
            Vector3 move = Vector3.zero;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
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
            if (move != Vector3.zero)
            {
                state = State.Walking;
                transform.position += (move * Time.deltaTime);
            }
            else
            {
                state = State.Idle;
            }
        }
    }
    void Action()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Action();
        Movement();
    }
}
