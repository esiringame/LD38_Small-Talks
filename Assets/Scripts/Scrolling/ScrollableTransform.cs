using UnityEngine;

public class ScrollableTransform : ScrollableBase
{
    public override void Scroll(Vector3 scroll)
    {
        transform.localPosition += scroll;
    }
}
