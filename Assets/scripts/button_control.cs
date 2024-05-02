using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button_control : MonoBehaviour
{
    public Image play, stop;
    public Button game, home, restart;
    private bool isplaying = true, restartt = false, restartButtonPressed = false;

    private void Start()
    {
        AudioListener.pause = false;
        restartt = false;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            game_control();
        }
    }

    public void game_control()
    {
        if (isplaying)
        {
            Time.timeScale = 0f;
            isplaying = false;
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1f;
            isplaying = true;
            AudioListener.pause = false;
        }

        image_control();
    }

    public void image_control()
    {
        if (!isplaying)
        {
            play.enabled = true;
            stop.enabled = false;
        }
        else
        {
            play.enabled = false;
            stop.enabled = true;
        }
    }

    public void restart_game()
    {
        restartButtonPressed = true;
        isplaying = false;
        Start();

        SceneManager.LoadScene(1);
    }

    public void homee()
    {
        SceneManager.LoadScene(0);
    }
}
