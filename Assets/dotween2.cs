using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dotween2 : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ScaleWithTween());
    }

    private Vector3 originalScale;
    public float targetScale = 1.5f;
    public float duration = 2.0f;

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

    }
}
