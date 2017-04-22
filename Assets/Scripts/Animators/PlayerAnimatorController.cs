using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

    PlayerArck.State state;
    Animator animator;

	// Use this for initialization
	void Start () {
        state = transform.GetComponent<PlayerArck>().getState();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        state = transform.GetComponent<PlayerArck>().getState();
        Debug.Log(state);
		if(state == PlayerArck.State.Walking)
        {
            Debug.Log("WL" + state);
            animator.SetBool("isWalking", true);
        } else
        {
            animator.SetBool("isWalking", false);
        }
	}
}
