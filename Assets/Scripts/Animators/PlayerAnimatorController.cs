using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

    PlayerBehaviour.State _state;
    Animator _animator;
    AudioSource _audio;

	// Use this for initialization
	void Start () {
        _state = transform.GetComponent<PlayerBehaviour>().GetState();
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        _state = transform.GetComponent<PlayerBehaviour>().GetState();
		if(_state == PlayerBehaviour.State.Walking)
        {
            _animator.SetBool("isWalking", true);
            if(!_audio.isPlaying)
            {
                _audio.Play();
            }
        } else
        {
            _animator.SetBool("isWalking", false);
        }
	}
}
