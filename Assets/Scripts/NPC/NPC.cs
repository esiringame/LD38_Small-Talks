using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public bool DoesHeKnowUPR = true;
    public Vector3 Direction = Vector3.left;
    public float WalkingSpeed = 0.8f;
    public float MaxSpeed = 99.99f;
    public float Acceleration = .1f;
    private float _walkingSpeed;

    private GameObject _player;

    public float TriggerDistance = 3.0f;
    public float CatchDistance = .2f;

    private Transform _transform;
    private Transform _playerTransform;
    private int _indexNPC = 1;
    private State _stateNPC;

    public enum State
    {
        walking, // ignore player
        triggered, // walking to player
        caught, // triggers dialog
        idle, // during dialog state
        flee // ignore player (after dialog)
    };

    // Use this for initialization
    void Start () {
        _player = GameObject.FindWithTag("Player");
	    _transform = GetComponent<Transform>();
        _playerTransform = _player.GetComponent<Transform>();
        _stateNPC = State.walking;
        _walkingSpeed = WalkingSpeed;
	}

    void updateState()
    {
        // Player distance
        Vector2 heading = _transform.position - _playerTransform.position;
        float playerDistance = heading.magnitude;


        if (playerDistance > TriggerDistance && _stateNPC == State.triggered)
        {
            _stateNPC = State.walking;
        }
        else if (playerDistance < TriggerDistance && _stateNPC == State.walking && DoesHeKnowUPR)
        {
            _stateNPC = State.triggered;
        }
        else if (playerDistance < CatchDistance && _stateNPC == State.triggered)
        {
            _stateNPC = State.caught;
        }
        else if (_stateNPC == State.caught)
        {
            _stateNPC = State.idle;
        }
        else if ((_stateNPC == State.idle && _player.GetComponent<PlayerBehaviour>().GetState() != global::PlayerBehaviour.State.Talking) || (_stateNPC == State.triggered && _player.GetComponent<PlayerBehaviour>().GetState() == global::PlayerBehaviour.State.Talking))
        {
            _stateNPC = State.flee;
        }
    }

    void triggered()
    {
        // Player distance
        Vector2 heading = _transform.position - _playerTransform.position;
        float playerDistance = heading.magnitude;
        Vector3 oneDirection = -heading / playerDistance;
        _walkingSpeed += Acceleration * Time.deltaTime;
 
        if (_walkingSpeed > MaxSpeed)
            _walkingSpeed = MaxSpeed;

        _transform.localPosition += oneDirection * _walkingSpeed * Time.deltaTime;
    }

    void walking()
    {
        _transform.localPosition += Direction * WalkingSpeed * Time.deltaTime;
    }

    void caught()
    {
        _player.GetComponent<PlayerBehaviour>().OnTrigger(_indexNPC);
    }


    void idle()
    {
        return;
    }


    // Update is called once per frame
    void Update () {
        updateState();

        switch (_stateNPC)
        {
            case State.walking:
                walking();
                break;
            case State.triggered:
                triggered();
                break;
            case State.caught:
                caught();
                break;
            case State.idle:
                idle();
                break;
            case State.flee:
                walking();
                break;
        } 
    }    
}
