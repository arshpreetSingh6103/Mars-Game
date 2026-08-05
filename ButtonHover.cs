using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScale : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    ISelectHandler,
    IDeselectHandler
{
    public float selectedScale = 1.15f;
    public float scaleSpeed = 10f;

    private Vector3 originalScale;
    private Vector3 targetScale;

    private bool isHovered = false;
    private bool isSelected = false;

    void Awake()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            scaleSpeed * Time.unscaledDeltaTime
        );
    }

    void UpdateTargetScale()
    {
        if (isHovered || isSelected)
            targetScale = originalScale * selectedScale;
        else
            targetScale = originalScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        UpdateTargetScale();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        UpdateTargetScale();
    }

    public void OnSelect(BaseEventData eventData)
    {
        isSelected = true;
        UpdateTargetScale();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
        UpdateTargetScale();
    }
}
