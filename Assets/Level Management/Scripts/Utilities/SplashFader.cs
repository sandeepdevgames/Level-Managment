using UnityEngine;
using UnityEngine.UI;

public class SplashFader : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float clearAlpha = 0f;
    [SerializeField] float solidAlpha = 1f;
    [SerializeField] float fadeDuration = 2f;

    [Header("UI")]
    [SerializeField] MaskableGraphic[] graphicsToFader;

    public float FadeDuration { get => fadeDuration; }

    private void SetAlpha (float alpha)
    {
        foreach (MaskableGraphic graphic in graphicsToFader)
        {
            if(graphic != null)
            {
                graphic.canvasRenderer.SetAlpha(alpha);
            }
        }
    }

    private void Fade (float alpha, float duration)
    {
        foreach (MaskableGraphic graphic in graphicsToFader)
        {
            if (graphic != null)
            {
                graphic.CrossFadeAlpha(alpha, duration, true);
            }
        }
    }

    public void FadeOff()
    {
        SetAlpha(solidAlpha);
        Fade(clearAlpha, fadeDuration);
    }

    public void FadeOn()
    {
        SetAlpha(clearAlpha);
        Fade(solidAlpha, fadeDuration);
    }
}
