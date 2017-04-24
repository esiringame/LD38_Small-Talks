using UnityEngine;

public class ScrollableRigidbody : ScrollableBase
{
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public override void ScrollFixed(Vector2 scroll)
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + scroll);
    }
}