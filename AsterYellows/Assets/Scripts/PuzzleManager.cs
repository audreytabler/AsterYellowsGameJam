using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public bool[] puzzleProgress;
    public WindowManager errorMessage;
    public string textAnswer;
    private int i = 0;
    

    public void ShowError()
    {
        errorMessage.OpenWindow();
    }
    public void UpdateProgress()
    {
        puzzleProgress[i] = true;
        i++;
    }
    public void CheckText(GameObject textInput)
    {
        textInput.GetComponent<TMP_InputField>().text = "";

        if (textAnswer == textInput.GetComponent<TMP_InputField>().text)
        {
            UpdateProgress();
        }
    }
}
