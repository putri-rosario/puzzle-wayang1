using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;

public class ScaleOnEnable : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ScaleWithTween());
    }

    private Vector3 originalScale;
    public float targetScale = 1.5f;
    public float duration = 2.0f;
    public float fadeValue = 0.5f;
    public float fadeDuration = 1.0f;

    void OnEnable()
    {
        originalScale = transform.localScale;
        StartCoroutine(ScaleWithTween());
    }

    IEnumerator ScaleWithTween()
    {
        // Tweening scale menggunakan DOTween
        transform.DOScale(originalScale * targetScale, duration);

        // Tunggu hingga tweening selesai
        yield return new WaitForSeconds(duration);

        // Selama waktu tunggu, Anda juga dapat menerapkan tweening alpha
        Image image = GetComponent<Image>();
        if (image != null)
        {
            image.DOFade(fadeValue, fadeDuration);

            // Tunggu hingga tweening alpha selesai
            yield return new WaitForSeconds(fadeDuration);
        }

        // Setelah selesai, Anda dapat melakukan tindakan lain (jika diperlukan)

        // Misalnya, Anda dapat menghilangkan objek jika diperlukan
        gameObject.SetActive(false);
    }
}