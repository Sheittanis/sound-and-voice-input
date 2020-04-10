using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_pausemanager : MonoBehaviour
{
    public GameObject pausecanvas;
    public GameObject GameManager;

    public s_gamemanager gamemanager;
    // Use this for initialization
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        gamemanager = GameManager.GetComponent<s_gamemanager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //stops the in game time and activates the pause menu
            Time.timeScale = 0;
            pausecanvas.SetActive(true);
            gamemanager.paused = true;
        }
    }

    public void Continue()
    {
        //resets the in game time and disables the pause menu
        Time.timeScale = 1;
        pausecanvas.SetActive(false);
        gamemanager.paused = false;
    }


    public void ExitGame()
    {
        //quits the the application
        Application.Quit();
    }
}
