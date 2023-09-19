using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public int currentFile;
    public Transform[] positions;
    public MultiDimensional[] files;
    public GameObject[] fileTypes; // -1 = free Space, 0 = blank file, 1 = folder to 1 , 2 = solution folder, 3 = corrupted folder
    private GameObject[] activeFiles = new GameObject[6];

    public void Awake()
    {
        DisplayFiles();
    }

    public void DisplayFiles()
    {
        for (int i = 0; i < files[currentFile].array.Length; i++)
        {
            if (activeFiles[i] != null)
            {
                Destroy(activeFiles[i]);
            }
            
            if (files[currentFile].array[i] != -1)
            {
                GameObject file = Instantiate(fileTypes[files[currentFile].array[i]], positions[i]);
                file.transform.SetParent(positions[i]);
                file.GetComponent<File>().SetData(currentFile, i, this.gameObject);
                activeFiles[i] = file;
            }
        }
    }

    public void ChangeFilePosition(int startingX, int startingY, int newX)
    {
        int openPosition = FindOpenPosition(newX);
        if (openPosition != -1)
        {
            files[newX].array[openPosition] = files[startingX].array[startingY];
            files[startingX].array[startingY] = -1;
        }
    }
    private int FindOpenPosition(int x)
    {
        for (int i = 0; i < files[currentFile].array.Length; i++)
        {
            if (files[x].array[i] == -1)
            {
                return i;
            }
        }
        return -1;
    }
    public void DeleteCorruptedFiles()
    {
        for (int i = 0; i < files.Length; i++)
        {
            for (int j = 0; j < files[i].array.Length; j++)
            {
                if (files[i].array[j] == 3)
                {
                    files[i].array[j] = -1;
                }
            }
        }
    }
}



[System.Serializable]
public class MultiDimensional
{
    public int[] array;
}
