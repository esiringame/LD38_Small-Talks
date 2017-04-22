using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanAnimatorController : MonoBehaviour {

    Animator animator;
    public bool isEmpty = true;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetBool("isEmpty", isEmpty);
	}

}
