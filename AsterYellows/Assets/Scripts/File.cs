using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class File : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform dragRectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject fileManager;
    public int arrayX;
    public int arrayY;
    public GameObject newFolder;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Awake()
    {
        dragRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        startingPosition = transform.position;
    }

    public void SetData(int arrayX, int arrayY, GameObject fileManager)
    {
        this.arrayX = arrayX;
        this.arrayY = arrayY;
        this.fileManager = fileManager;
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (newFolder != null)
        {
            fileManager.GetComponent<FileManager>().ChangeFilePosition(arrayX, arrayY, newFolder.GetComponent<FileFolder>().arrayX);
            Destroy(gameObject);
        }
        else
        {
            gameObject.transform.position = startingPosition;
        }
    }
}
