using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject GM;
    public void PlayGame()
    {
        SceneManager.LoadScene("Game_1");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("�al��t�");

    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("UiMenu");
        Debug.Log("�al��t�");
        DestroyImmediate(GM);

    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
