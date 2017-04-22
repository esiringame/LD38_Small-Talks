using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

    Player.State state;
    Animator animator;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        state = GetComponent<Player>().getState();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        state = GetComponent<Player>().getState();
		if(state == Player.State.Walking)
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
