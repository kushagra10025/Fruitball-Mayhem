using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject informationPanel;
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleInfoPanel(int i)
    {
        if (i == 1)
        {
            informationPanel.SetActive(true);
        }

        if (i == 0)
        {
            informationPanel.SetActive(false);
        }
    }
}
