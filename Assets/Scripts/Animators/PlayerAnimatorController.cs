using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

    PlayerArck.State state;
    Animator animator;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        state = transform.GetComponent<PlayerArck>().getState();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        state = transform.GetComponent<PlayerArck>().getState();
		if(state == PlayerArck.State.Walking)
        {
            animator.SetBool("isWalking", true);
            if(!audio.isPlaying)
            {
                Debug.Log("oui");
                audio.Play();
            }
        } else
        {
            animator.SetBool("isWalking", false);
        }
	}
}
