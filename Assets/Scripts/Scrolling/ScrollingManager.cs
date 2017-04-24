using System.Collections.Generic;
using UnityEngine;

public class ScrollingManager : MonoBehaviour
{
    public float Speed;
    private readonly List<ScrollableBase> _registry = new List<ScrollableBase>();
    [SerializeField]
    private ScrollingManager _parent;

    private void Start() {
        ScrollingManager[] parents = GetComponentsInParent<ScrollingManager>();
        if (parents.Length > 1) 
            _parent = parents[1];
    }

    private void FixedUpdate()
    {
        Vector2 scroll;
        if (_parent != null) {
            if (! _parent.isActiveAndEnabled)
                return;
            scroll = Vector2.left * Speed * _parent.Speed * Time.fixedDeltaTime;
        }
        else
            scroll = Vector2.left * Speed * Time.fixedDeltaTime;
        foreach (ScrollableBase scrollableBase in _registry)
            scrollableBase.ScrollFixed(scroll);
    }

    private void Update()
    {
        Vector3 scroll;
        if (_parent != null)
        {
            if (! _parent.isActiveAndEnabled)
                return;
            scroll = Vector2.left * Speed * _parent.Speed * Time.deltaTime;
        }
        else
            scroll = Vector2.left * Speed * Time.deltaTime;
        foreach (ScrollableBase scrollableBase in _registry)
            scrollableBase.Scroll(scroll);
    }

    public void RegisterScrollable(ScrollableBase scrollable)
    {
        _registry.Add(scrollable);
    }

    public void UnregisterScrollable(ScrollableBase scrollable)
    {
        _registry.Remove(scrollable);
    }
}
