using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("UiMenu");
        Debug.Log("�al��t�");
    }
}
