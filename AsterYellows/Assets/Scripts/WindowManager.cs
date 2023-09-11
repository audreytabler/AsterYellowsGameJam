using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowManager : MonoBehaviour, IPointerDownHandler
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    //Methods for showing and hiding the window
    public void OpenWindow()
    {
        this.gameObject.SetActive(true);
        rectTransform.anchoredPosition = Vector3.zero;
        rectTransform.SetAsLastSibling();
    }
    public void CloseWindow()
    {
        this.gameObject.SetActive(false);
    }

    //places the window infront of other windows when clicked on
    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransform.SetAsLastSibling();
    }
}
