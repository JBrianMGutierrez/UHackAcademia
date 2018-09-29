using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{

    public Button[] buttons;
    public Text scoreText;
    bool gameOver;
    int timer;


    // Use this for initialization
    void Start()
    {
        gameOver = false;
        timer = 0;
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Timer: " + timer;
    }

    void scoreUpdate()
    {
        if (gameOver == false)
        {
            timer += 1;
        }
    }

    public void gameOverActivated()
    {
        gameOver = true;
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Character Screen");
    }

    public void Pause()
    {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;

        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void Menu()
    {

        SceneManager.LoadScene("menu scene");
    }
    public void Exit()
    {
        Application.Quit();
    }


}
