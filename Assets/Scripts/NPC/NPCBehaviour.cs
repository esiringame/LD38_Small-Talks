using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    public Vector3 Direction = Vector3.left;
    public float WalkingSpeed = 0.8f;
    public float MaxSpeed = 99.99f;
    public float Acceleration = .1f;
    private float _walkingSpeed;
  
    private GameObject _player;

    public float TriggerDistance = 3.0f;
    public float CatchDistance = .2f;

    private Transform _playerTransform;
    private State _stateNPC;
    private bool isFacingRight;

    public enum State
    {
        walking, // ignore player
        triggered, // walking to player
        caught, // triggers dialog
        idle, // during dialog state
        flee // ignore player (after dialog)
    };

    public State GetState()
    {
        return _stateNPC;
    }

    public bool GetIsFacingRight()
    {
        return isFacingRight;
    }

    public PedestrianDescriptor Descriptor { get; set; }

    // Use this for initialization
    void Start () {
        _player = GameObject.FindWithTag("Player");
        _playerTransform = _player.GetComponent<Transform>();
        _stateNPC = State.walking;
        _walkingSpeed = WalkingSpeed;
	}

    void UpdateState()
    {
        // Player distance
        Vector2 heading = transform.position - _playerTransform.position;
        float playerDistance = heading.magnitude;


        if (playerDistance > TriggerDistance && _stateNPC == State.triggered)
        {
            _stateNPC = State.walking;
        }
        else if (playerDistance < TriggerDistance && _stateNPC == State.walking && Descriptor.KnowPlayer && _player.GetComponent<PlayerBehaviour>().GetState() != PlayerBehaviour.State.Hidding)
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
        else if ((_stateNPC == State.idle && _player.GetComponent<PlayerBehaviour>().GetState() != PlayerBehaviour.State.Talking) || (_stateNPC == State.triggered && _player.GetComponent<PlayerBehaviour>().GetState() == PlayerBehaviour.State.Talking))
        {
            _stateNPC = State.flee;
        }
    }

    void Triggered()
    {
        // Player distance
        Vector2 heading = transform.position - _playerTransform.position;
        float playerDistance = heading.magnitude;
        Vector3 oneDirection = -heading / playerDistance;
        _walkingSpeed += Acceleration * Time.deltaTime;
 
        if (_walkingSpeed > MaxSpeed)
            _walkingSpeed = MaxSpeed;

        isFacingRight = oneDirection.x > 0;

        transform.localPosition += oneDirection * _walkingSpeed * Time.deltaTime;
    }

    void Walking()
    {
        transform.localPosition += Direction * WalkingSpeed * Time.deltaTime;
        isFacingRight = false;
    }

    void Caught()
    {
        _player.GetComponent<PlayerBehaviour>().OnTrigger(Descriptor.CharacterId, Descriptor.EncounterCounter);
        Descriptor.EncounterCounter++;
    }


    void Idle()
    {
        return;
    }


    // Update is called once per frame
    void Update () {
        UpdateState();

        switch (_stateNPC)
        {
            case State.walking:
                Walking();
                break;
            case State.triggered:
                Triggered();
                break;
            case State.caught:
                Caught();
                break;
            case State.idle:
                Idle();
                break;
            case State.flee:
                Walking();
                break;
        } 
    }    
}
