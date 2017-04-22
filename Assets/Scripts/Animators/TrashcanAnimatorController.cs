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

    private void Fill()
    {
        isEmpty = false;
        Debug.Log("Ou pas faut voir");
    }

    private void Empty()
    {
        isEmpty = true;
    }

    public void OnHide()
    {
        Debug.Log("C'est caché");
        Fill();
    }

    public void OnUnhide()
    {
        Empty();
    }

}
