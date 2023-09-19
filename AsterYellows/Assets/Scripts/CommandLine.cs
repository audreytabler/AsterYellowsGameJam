using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommandLine : MonoBehaviour
{
    public TMP_Text[] texts;
    public FileManager fileManager;
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
        }
        else if (text.Equals("help"))
        {
            if (textAmount < texts.Length)
            {
                texts[textAmount].text = "del 'fileName'";
                textAmount++;
            }
            else
            {
                ShiftText("del 'fileName'");
            }
        }
    }

    private void ShiftText(string newText)
    {
        texts[0].text = texts[1].text;
        texts[1].text = texts[2].text;
        texts[2].text = texts[3].text;
        texts[3].text = newText;
    }
}
