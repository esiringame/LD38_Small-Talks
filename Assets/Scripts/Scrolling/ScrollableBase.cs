using UnityEngine;

public abstract class ScrollableBase : MonoBehaviour
{
    private ScrollingManager _scrollingManager;
    
	private void Start()
	{
	    _scrollingManager = GetComponentInParent<ScrollingManager>();
	    if (_scrollingManager != null)
            _scrollingManager.RegisterScrollable(this);
    }

    public virtual void Scroll(Vector3 scroll)
    {
    }

    public virtual void ScrollFixed(Vector2 scroll)
    {
    }

    private void OnDestroy()
    {
        if (_scrollingManager != null)
            _scrollingManager.UnregisterScrollable(this);
    }
}
