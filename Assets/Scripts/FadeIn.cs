using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public CanvasGroup mainUICanvasGroup;
    public RectTransform mainUIRectTransform;
    public float fadeDuration = 2.0f;

    [SerializeField]
    public float startY;
    public float MoveSpeed = 2;
    public float endY = 0;

    private void Start()
    {
        mainUIRectTransform.anchoredPosition = new Vector2(mainUIRectTransform.anchoredPosition.x, startY);
        StartCoroutine(FadeInMainUICoroutine());
    }

    private IEnumerator FadeInMainUICoroutine()
    {
        float elapsedTime = 0f;
        float moveTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            moveTime += MoveSpeed * Time.deltaTime;

            mainUICanvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);

            float newY = Mathf.Lerp(startY, endY, moveTime / fadeDuration);
            mainUIRectTransform.anchoredPosition = new Vector2(mainUIRectTransform.anchoredPosition.x, newY);

            yield return null;
        }

        mainUICanvasGroup.alpha = 1;
        mainUIRectTransform.anchoredPosition = new Vector2(mainUIRectTransform.anchoredPosition.x, endY);
    }
}
