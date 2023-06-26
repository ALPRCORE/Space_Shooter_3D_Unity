using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;
    public static int score;
    public int levelIndex;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        scoreText.text = "Score \n " + score.ToString();

        if (score == 10)
        {
            SceneManager.LoadScene("Game_2");
            score = 11;
        }
        if (score == 16)
        {
            SceneManager.LoadScene("Game_3");
            score = 17;
        }
        if (score == 25)
        {
            SceneManager.LoadScene("Credits");
            score = 26;
        }
    }
}
