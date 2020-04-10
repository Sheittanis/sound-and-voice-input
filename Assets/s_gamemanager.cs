using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_gamemanager : MonoBehaviour
{
    public bool paused;
	// Use this for initialization
	void Start ()
    {
        paused = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                paused = false;
            else
                paused = true;
        }


        if (paused == true)
        {
            Time.timeScale = 0.0f;
        }
        else if
        (paused == false)
        {
            Time.timeScale = 1.0f;
        }

    }
}
