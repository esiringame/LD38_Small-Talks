using UnityEngine;

public class Scrollable : MonoBehaviour
{
    private ScrollingManager _scrollingManager;
    private Rigidbody2D _rigidbody2D;
    
	void Start()
	{
	    _scrollingManager = GetComponentInParent<ScrollingManager>();
	    _rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update()
	{
	    if (!_scrollingManager.enabled)
	        return;

	    Vector3 move = Vector3.left * _scrollingManager.Speed * Time.deltaTime;

	    if (_rigidbody2D != null)
	    {
	        Vector2 move2D = move;
	        _rigidbody2D.MovePosition(_rigidbody2D.position + move2D);
        }
        else
		    transform.localPosition += move;
	}
}
