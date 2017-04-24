using UnityEngine;

public class ScrollableRigidbody : ScrollableBase
{
    public Vector2 MoveVector { get; set; }
    private Rigidbody2D _rigidbody2D;

    protected override void Start()
    {
        base.Start();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public override void ScrollFixed(Vector2 scroll)
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + scroll + MoveVector * Time.fixedDeltaTime);
    }
}
