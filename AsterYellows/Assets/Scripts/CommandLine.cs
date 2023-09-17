using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommandLine : MonoBehaviour
{
    public TMP_Text[] texts;
    private int textAmount = 0;

    public void SetText(GameObject textInput)
    {
        Debug.Log("text");

        if (textAmount < texts.Length)
        {
            texts[textAmount].text = textInput.GetComponent<TMP_InputField>().text;
            textAmount++;
        }
        else
        {
            ShiftText(textInput.GetComponent<TMP_InputField>().text);
        }

        CheckText(textInput.GetComponent<TMP_InputField>().text);
        textInput.GetComponent<TMP_InputField>().text = "";
    }

    private void CheckText(string text)
    {
        switch(text)
        {
            //What the test does
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
