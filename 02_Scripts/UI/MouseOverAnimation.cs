using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MouseOverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scaleFactor = 1.2f; 
    public float animationDuration = 0.2f; 

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(originalScale * scaleFactor, animationDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(originalScale, animationDuration);
    }
}