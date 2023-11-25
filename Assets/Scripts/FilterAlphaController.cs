using UnityEngine;

public class FilterAlphaController : MonoBehaviour
{
    private SpriteRenderer filterRenderer;

    private void Start()
    {
        filterRenderer = GetComponent<SpriteRenderer>();
    }

    public void IncreaseAlpha(float amount)
    {
        float newAlpha = filterRenderer.color.a + amount;

       // newAlpha = Mathf.Clamp01(newAlpha);

        Color newColor = new Color(filterRenderer.color.r, filterRenderer.color.g, filterRenderer.color.b, newAlpha);

        filterRenderer.color = newColor;
    }
}
