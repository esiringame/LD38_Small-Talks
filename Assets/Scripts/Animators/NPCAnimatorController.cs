using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimatorController : MonoBehaviour
{
    NPCBehaviour _behaviour;
    Animator _animator;
    SpriteRenderer _renderer;

    // Use this for initialization
    void Start () {
        _behaviour = GetComponent<NPCBehaviour>();
        _animator = GetComponent<Animator>();
	    _renderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        _renderer.flipX = !_behaviour.GetIsFacingRight();
        NPCBehaviour.State state = _behaviour.GetState();
        if (state == NPCBehaviour.State.caught || state == NPCBehaviour.State.idle)
        {
            _animator.SetBool("isWalking", false);
        }
        else
        {
            _animator.SetBool("isWalking", true);
        }
    }
}
