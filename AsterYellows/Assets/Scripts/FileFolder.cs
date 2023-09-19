using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileFolder : MonoBehaviour
{
    public int arrayX;
    [SerializeField] private FileManager fileManager;

    private void Awake()
    {
        fileManager = GetComponentInParent<FileManager>();
    }
    public void OpenFolder()
    {
        if (fileManager != null)
        {
            fileManager.currentFile = arrayX;
            fileManager.DisplayFiles();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("File"))
        {
            var file = other.GetComponent<File>();
            file.newFolder = this.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("File"))
        {
            var file = other.GetComponent<File>();
            file.newFolder = null;
        }
    }
}
