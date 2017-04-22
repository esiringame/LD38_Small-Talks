using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimatorController : MonoBehaviour {


    NPC.State state;
    Animator animator;
	// Use this for initialization
	void Start () {
        state = GetComponent<NPC>().getState();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        state = GetComponent<NPC>().getState();
        if (state == NPC.State.caught || state == NPC.State.idle)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
    }
}
