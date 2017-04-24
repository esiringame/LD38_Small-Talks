using System.Collections.Generic;
using UnityEngine;

public class ScrollingManager : MonoBehaviour
{
    public float Speed;
    private readonly List<ScrollableBase> _registry = new List<ScrollableBase>();

    private void FixedUpdate()
    {
        Vector2 scroll = Vector2.left * Speed * Time.fixedDeltaTime;
        foreach (ScrollableBase scrollableBase in _registry)
            scrollableBase.ScrollFixed(scroll);
    }

    private void Update()
    {
        Vector3 scroll = Vector3.left * Speed * Time.deltaTime;
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
