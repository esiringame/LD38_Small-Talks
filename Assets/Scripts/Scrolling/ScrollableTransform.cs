using UnityEngine;

public class ScrollableTransform : ScrollableBase
{
    public float ParallaxEffect = 1.0f;

    public override void Scroll(Vector3 scroll)
    {
        transform.localPosition += scroll * ParallaxEffect;
    }
}
