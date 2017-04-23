using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanAnimatorController : MonoBehaviour {

    Animator _animator;
    public bool IsEmpty = true;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        _animator.SetBool("isEmpty", IsEmpty);
	}

    private void Fill()
    {
        IsEmpty = false;
        Debug.Log("Ou pas faut voir");
    }

    private void Empty()
    {
        IsEmpty = true;
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
