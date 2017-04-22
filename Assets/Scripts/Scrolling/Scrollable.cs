using UnityEngine;

public class Scrollable : MonoBehaviour
{
    private ScrollingManager _scrollingManager;
    
	void Start()
	{
	    _scrollingManager = GetComponentInParent<ScrollingManager>();
	}
	
	void Update()
    {
		transform.localPosition += Vector3.left * _scrollingManager.Speed * Time.deltaTime;
	}
}
