using UnityEngine;

public class Scrollable : MonoBehaviour
{
    private ScrollingManager _scrollingManager;
    private Transform _transform;
    
	void Start()
	{
	    _transform = GetComponent<Transform>();
	    _scrollingManager = GetComponentInParent<ScrollingManager>();
	}
	
	void Update()
    {
		_transform.localPosition += Vector3.left * _scrollingManager.Speed * Time.deltaTime;
	}
}
