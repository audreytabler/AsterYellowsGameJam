using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommandLine : MonoBehaviour
{
    public TMP_Text[] texts;
    public FileManager fileManager;
    public PuzzleManager puzzleManager;
    public WindowManager textWindow;
    public bool ifHasBin = false;
    private int textAmount = 0;
    private string text;

    public void SetText(GameObject textInput)
    {
        text = textInput.GetComponent<TMP_InputField>().text;
        text = text.ToLower();

        if (textAmount < texts.Length)
        {
            texts[textAmount].text = text;
            textAmount++;
        }
        else
        {
            ShiftText(text);
        }

        CheckText(text);
        textInput.GetComponent<TMP_InputField>().text = "";
    }

    private void CheckText(string text)
    {
        if (text.Equals("del corruptedfile"))
        {
            fileManager.DeleteCorruptedFiles();
            ShiftText("deleting files...");
        }
        else if (text.Equals("help"))
        {
            ShiftText("del 'fileName'");
            ShiftText("open 'fileName'");
            ShiftText("RecycleBinFolder");
        }
        else if (text.Equals("open text") || text.Equals("open text.txt"))
        {
            if (textWindow != null)
            {
                ShiftText("opening file...");
                textWindow.OpenWindow();
            }
        }
        else if (text.Equals("recyclebinfolder"))
        {
            if (ifHasBin)
            {
                ShiftText("retrieving file...");
                int i = fileManager.FindOpenPosition(0);
                fileManager.files[0].array[i] = 2;
                ifHasBin = false;
            }
            else
            {
                ShiftText("ERROR");
            }
        }
        else
        {
            ShiftText("ERROR");
        }
    }

    private void ShiftText(string newText)
    {
        texts[0].text = texts[1].text;
        texts[1].text = texts[2].text;
        texts[2].text = texts[3].text;
        texts[3].text = newText;
        textAmount++;
    }
}
