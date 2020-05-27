using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Lives=0;
    public GameObject titleScreen;
    public GameObject Settings;
    public TextMeshProUGUI LivesText;
    public Button restartButton;
    public bool GameOver;
    public TextMeshProUGUI GameOverText;
    // Start is called before the first frame update
    void Start()
    {
        GameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        Gameover();
    }
    public void UpdateLives(int lives)
    {
        Lives += lives;
        LivesText.text = "Lives: " + Lives;
    }
    public void Gameover()
    {
        if (Lives == 0)
        {
            GameOver = true;
            restartButton.gameObject.SetActive(true);
            GameOverText.gameObject.SetActive(true);
        }
    }
    public void CheatGame()
    {
        GameOver = false;
        Lives = 999;
        UpdateLives(00);
        titleScreen.gameObject.SetActive(false);
        LivesText.gameObject.SetActive(true);
    }
    public void StartGame()
    {
        GameOver = false;
        Lives = 3;
        UpdateLives(0);
        titleScreen.gameObject.SetActive(false);
        LivesText.gameObject.SetActive(true);
       
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartLevel1()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    public void MainMenuControll()
    {
        titleScreen.gameObject.SetActive(false);
        Settings.gameObject.SetActive(true);
    }
    public void GoToMainMenu()
    {
        titleScreen.gameObject.SetActive(true);
        Settings.gameObject.SetActive(false);
    }
}
