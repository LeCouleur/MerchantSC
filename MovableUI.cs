using UnityEngine;
using UnityEngine.EventSystems;

public class MovableUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform rectTransform;
    private bool isDragging;
    private Vector2 offset;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Set the offset to maintain the relative position of the click point inside the UI element
        offset = rectTransform.anchoredPosition - eventData.position;
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            // Update the anchored position based on the pointer position and the offset
            rectTransform.anchoredPosition = eventData.position + offset;
        }
    }
}
