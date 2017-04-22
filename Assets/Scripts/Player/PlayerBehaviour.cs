using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    
    public GameObject TextBoxManager;

  
    [SerializeField]
    float horSpeed, verSpeed;
    Vector3 Up, Down, Right, Left;
    [SerializeField]
    bool nearNPC, nearHideout, dialogOn;
 
    [SerializeField]
    HideoutBehaviour hideout;
    [SerializeField]
    private State state;

    public enum State
    {
        Idle,
        Walking,
        Hidding,
        Talking
    }

    public State GetState()
    {
        return state;
    }
    // Use this for initialization
    void Start () {
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
                move += Up;
            }
            else if (vertical < 0)
            {
                move += Down;
            }
            if (horizontal > 0)
            {
                move += Right;
            }
            else if (horizontal < 0)
            {
                move += Left;
            }
            if (move != Vector3.zero)
            {
                state = State.Walking;
                move = move.normalized;
                move.Scale(new Vector3(horSpeed, verSpeed, 1) * Time.deltaTime);
                transform.position += move;
            }
            else
            {
                state = State.Idle;
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
        state = State.Idle;
    }

    public void OnTrigger(int indexEnemy)
    {
        TextBoxManager.GetComponent<TextBoxManager>().talkTriggered(indexEnemy);
        state = State.Talking;
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
                    OnTrigger(1);
                }
            }
            else if (state == State.Hidding)
            {
                Unhide();
            }
            else
            {
                OnTrigger(1);
            }
        }
    }

    void Hide()
    {
        Debug.Log("Bah là on cache tu vois");
        hideout.OnHide();
        GetComponent<SpriteRenderer>().enabled = false;
        state = State.Hidding;
    }

    void Unhide()
    {
        Debug.Log("Bah là on décache tu vois");
        hideout.OnUnhide();
        GetComponent<SpriteRenderer>().enabled = true;
        state = State.Idle;
    }

}
