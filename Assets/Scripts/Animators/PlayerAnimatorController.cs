using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

    PlayerBehaviour.State state;
    Animator animator;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        state = transform.GetComponent<PlayerBehaviour>().GetState();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        state = transform.GetComponent<PlayerBehaviour>().GetState();
		if(state == PlayerBehaviour.State.Walking)
        {
            animator.SetBool("isWalking", true);
            if(!audio.isPlaying)
            {
                audio.Play();
            }
        } else
        {
            animator.SetBool("isWalking", false);
        }
	}
}
