using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

    PlayerBehaviour _player;
    Animator _animator;
    AudioSource _audio;
    SpriteRenderer _renderer;

    private bool _contact;

	// Use this for initialization
	void Start () {
        _player = transform.GetComponent<PlayerBehaviour>();
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        _renderer.flipX = !_player.GetIsFacingRight();
		if(_player.GetState() == PlayerBehaviour.State.Walking || _contact && _player.GetState() == PlayerBehaviour.State.Idle)
        {
            _animator.SetBool("isWalking", true);
            if(!_audio.isPlaying)
            {
                //_audio.Play();
            }
        } else
        {
            _animator.SetBool("isWalking", false);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        _contact = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        _contact = false;
    }
}
