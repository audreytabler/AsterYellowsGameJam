using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public bool[] puzzleProgress;
    public WindowManager errorMessage;
    public FileManager fileManager;
    public string textAnswer;
    public string nextScene;
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
    public void CheckPuzzle()
    {
        if (!CheckFiles())
        {
            ShowError();
            return;
        }
        if (!CheckForCorupt())
        {
            ShowError();
            return;
        }

        ChangeScene();
    }
    private bool CheckFiles()
    {
        for (int i = 0; i < fileManager.files[1].array.Length; i++)
        {
            if (fileManager.files[1].array[i] == 2)
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckForCorupt()
    {
        for (int i = 0; i < fileManager.files.Length; i++)
        {
            for (int j = 0; j < fileManager.files[i].array.Length; j++)
            {
                if (fileManager.files[i].array[j] == 3)
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
