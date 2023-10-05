using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ButtonsManager : MonoBehaviour
{
    public Image imageToScale;
    public Image imageToFlip;
    private bool isZoomOut = false, isFadeOut = true, isFlipOut = false, isFlyOut = true;
    private Vector3 originalPosition = new Vector3(0, 250, 0);

    public void Zoom()
    {
        float zoomVal = 0;
        float targetScale = isZoomOut ? 80 : zoomVal;
        imageToScale.transform.DOScale(targetScale, 0.25f);
        isZoomOut = !isZoomOut;
    }

    public void Fade()
    {
        float fadeValue = 1f;
        float targetFade = isFadeOut ? 0f : fadeValue;
        imageToScale.DOFade(targetFade, 0.25f);
        isFadeOut = !isFadeOut;
    }

    public void Shake()
    {
        imageToScale.transform.DOShakePosition(0.50f, new Vector3(15, 0, 0), 10, 90.0f, false, false, ShakeRandomnessMode.Harmonic);
        imageToScale.transform.DOLocalMove(originalPosition, 0.2f);
    }

    public void Fly()
    {
        float MoveValue = 0;
        float targetMove = isFlyOut ? 60 : MoveValue;
        Sequence mySequence = DOTween.Sequence();
        imageToScale.transform.DOMoveX(targetMove, 0.25f);
        isFlyOut = !isFlyOut;
    }
    public void Flip()
    {
        imageToFlip.rectTransform.localScale = new Vector3(-imageToFlip.rectTransform.localScale.x, imageToFlip.rectTransform.localScale.y, imageToFlip.rectTransform.localScale.z);
    }
    public void Flash()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(imageToScale.DOFade(0f, 0.25f));
        mySequence.Append(imageToScale.DOFade(1f, 0.25f));
        mySequence.Append(imageToScale.DOFade(0f, 0.25f));
        mySequence.Append(imageToScale.DOFade(1f, 0.25f));
    }
}
