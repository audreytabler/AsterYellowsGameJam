using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowManager : MonoBehaviour, IPointerDownHandler
{
    private RectTransform rectTransform;
    public bool isBlocked;
    public int puzzleProgressNumber;
    [SerializeField] PuzzleManager puzzleManager;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    //Methods for showing and hiding the window
    public void OpenWindow()
    {
        if (!isBlocked)
        {
            this.gameObject.SetActive(true);
            rectTransform.anchoredPosition = Vector3.zero;
            rectTransform.SetAsLastSibling();
        }
        else if(puzzleManager.puzzleProgress[puzzleProgressNumber])
        {
            this.gameObject.SetActive(true);
            rectTransform.anchoredPosition = Vector3.zero;
            rectTransform.SetAsLastSibling();
        }
        else
        {
            puzzleManager.ShowError();
        }
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
