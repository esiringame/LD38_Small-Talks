using UnityEngine;

public class HideoutBehaviour : MonoBehaviour
{
    public Sprite FullSprite;
    public Sprite EmptySprite;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = EmptySprite;
    }

    public void Fill()
    {
        _spriteRenderer.sprite = FullSprite;
    }

    public void Empty()
    {
        _spriteRenderer.sprite = EmptySprite;
    }
}
