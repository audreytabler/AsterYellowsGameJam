using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    private void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void StartGame()
    {
        ChangeScene("MiniGame");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
