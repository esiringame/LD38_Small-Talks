﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    private TextBoxManager _textBoxManager;

    [SerializeField]
    float _horSpeed, _verSpeed;
    Vector3 _up, _down, _right, _left;
    [SerializeField]
    bool _nearNPC, _nearHideout;
 
    [SerializeField]
    TrashcanAnimatorController _hideout;
    [SerializeField]
    private State _state;

    public bool isFacingRight;

    private ScrollingManager _scrollingManager;

    public enum State
    {
        Idle,
        Walking,
        Hidding,
        Talking
    }

    public State GetState()
    {
        return _state;
    }
    // Use this for initialization
    void Start () {
        _state = State.Idle;
        _up = transform.up;
        _down = -transform.up;
        _right = transform.right;
        _left = -transform.right;

        isFacingRight = true;

        _scrollingManager = GetComponentInParent<ScrollingManager>();
    }

    void Movement()
    {
        if (_state == State.Idle || _state == State.Walking)
        {
            Vector3 move = Vector3.zero;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            isFacingRight = horizontal >= 0;
            if (vertical > 0)
            {
                move += _up;
            }
            else if (vertical < 0)
            {
                move += _down;
            }
            if (horizontal > 0)
            {
                move += _right;
                 
            }
            else if (horizontal < 0)
            {
                move += _left;
            }
            if (move != Vector3.zero)
            {
                _state = State.Walking;
                move = move.normalized;
                move.Scale(new Vector3(_horSpeed, _verSpeed, 1) * Time.deltaTime);
                GetComponent<Rigidbody2D>().MovePosition(transform.position + move);
                //transform.position += move;
            }
            else
            {
                _state = State.Idle;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        Action();
        Movement();
    }

    public void OnRelease()
    {
        _scrollingManager.enabled = true;
        _state = State.Idle;
    }

    public void OnTrigger(int indexEnemy)
    {
        _scrollingManager.enabled = false;
        _textBoxManager.talkTriggered(indexEnemy);
        _state = State.Talking;
    }

    void Action()
    {
        if (Input.GetButtonDown("Action"))
        {
            if (_state == State.Idle || _state == State.Walking)
            {
                if (_nearHideout)
                {
                    Hide();
                }
            }
            else if (_state == State.Hidding)
            {
                Unhide();
            }
        }
    }

    void Hide()
    {
        Debug.Log("Bah là on cache tu vois");
        _hideout.OnHide();
        GetComponent<SpriteRenderer>().enabled = false;
        _state = State.Hidding;
    }

    void Unhide()
    {
        Debug.Log("Bah là on décache tu vois");
        _hideout.OnUnhide();
        GetComponent<SpriteRenderer>().enabled = true;
        _state = State.Idle;
    }

    float Distance(Transform a, Transform b)
    {
        return 0;
    }

    GameObject GetNearestNeighbour(IEnumerable<GameObject> list)
    {
        GameObject result=null;
        float distance = float.PositiveInfinity;
        foreach(GameObject go in list)
        {
            float dist = Distance(go.transform, transform);
            if(dist<=distance)
            {
                distance = dist;
                result = go;
            }
        }
        return result;
    }

}
