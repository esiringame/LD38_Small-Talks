using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimatorController : MonoBehaviour {


    NPCBehaviour.State _state;
    Animator _animator;
	// Use this for initialization
	void Start () {
        _state = GetComponent<NPCBehaviour>().GetState();
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        _state = GetComponent<NPCBehaviour>().GetState();
        if (_state == NPCBehaviour.State.caught || _state == NPCBehaviour.State.idle)
        {
            _animator.SetBool("isWalking", false);
        }
        else
        {
            _animator.SetBool("isWalking", true);
        }
    }
}
