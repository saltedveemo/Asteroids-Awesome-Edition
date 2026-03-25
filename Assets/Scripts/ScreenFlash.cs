using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    public float flashDuration = 0.35f;
    private Image flashImage;
    private Color imageColor;

    private void Start()
    {
        flashImage = GetComponent<Image>();
        imageColor = flashImage.color;
    }

    private IEnumerator FlashRoutine()
    {
        float timer = 0f;
        float t = 0f;
        float alphaFrom = 0.01f;
        float alphaTO = 0f;

        while(t < 1f)
        {
            timer += Time.deltaTime;
            t = Mathf.Clamp01(timer / flashDuration);
            float alpha = Mathf.Lerp(alphaFrom, alphaTO, t);
            Color col = imageColor;
            col.a = alpha;
            flashImage.color = col;
            yield return new WaitForEndOfFrame();
        }
    }

    public void Flash()
    {
        StartCoroutine(FlashRoutine());
        Debug.Log("flash");
    }
}
