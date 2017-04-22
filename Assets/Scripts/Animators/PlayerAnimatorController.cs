using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

    PlayerBehaviour.State state;
    Animator animator;
    AudioSource audio;

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
        state = GetComponent<Player>().getState();
=======
        state = transform.GetComponent<PlayerBehaviour>().GetState();
>>>>>>> ff46afe25e1cfc6f8185ce6f47ba2e08a6bbbe1d
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        state = GetComponent<Player>().getState();
		if(state == Player.State.Walking)
=======
        state = transform.GetComponent<PlayerBehaviour>().GetState();
		if(state == PlayerBehaviour.State.Walking)
>>>>>>> ff46afe25e1cfc6f8185ce6f47ba2e08a6bbbe1d
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
