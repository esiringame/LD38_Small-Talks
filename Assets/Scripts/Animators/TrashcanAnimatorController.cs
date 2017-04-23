using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanAnimatorController : MonoBehaviour
{
    Animator _animator;
    public bool IsEmpty = true;
    private PlayerBehaviour _player;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        _animator.SetBool("isEmpty", IsEmpty);
	}

    public void OnHide(PlayerBehaviour player)
    {
        IsEmpty = false;
        _player = player;
    }

    public void OnUnhide()
    {
        IsEmpty = true;
        _player = null;
    }

    private void OnDestroy()
    {
        if (_player != null)
            _player.ForceUnhide();
    }
}
