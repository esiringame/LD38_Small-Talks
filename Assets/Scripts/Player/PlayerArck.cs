﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player1
{
    public class PlayerArck : MonoBehaviour
    {

        [SerializeField]
        float horSpeed, verSpeed;
        Vector3 Up, Down, Right, Left;
        [SerializeField]
        bool nearNPC, nearHideout,dialogOn;
        [SerializeField]
        TextBoxManager dialog;

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
            horSpeed = 1;
            verSpeed = 1;
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
            if (Input.GetButtonDown("Action"))
            {
                if (state == State.Idle || state == State.Walking)
                {
                    if (nearHideout)
                    {
                        Hide();
                    }
                    else if (nearNPC)
                    {
                        dialogOn = true;
                        Talk();
                    }
                }
                else if (state == State.Hidding)
                {
                    Unhide();
                }
                else
                {
                    Talk();
                }
            }
        }

        void Talk()
        {
            if (dialogOn)//dialog.isOn())
            {
                Debug.Log("Bah là on parle tu vois");
                state = State.Talking;
            }
            else
            {
                Debug.Log("Bah là on parle pas tu vois");
                state = State.Idle;
            }
        }

        void Hide()
        {
            Debug.Log("Bah là on cache tu vois");
            state = State.Hidding;
        }

        void Unhide()
        {
            Debug.Log("Bah là on décache tu vois");
            state = State.Idle;
        }

        // Update is called once per frame
        void Update()
        {
            Action();
            Movement();
        }
    }
}
