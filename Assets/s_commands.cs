using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_commands : MonoBehaviour
{
    public string[] Keyword;
    public GameObject GameManager;
    public GameObject commandscanvas;

    public InputField Chase;
    public InputField Stop;
    public InputField Forward;
    public InputField Left;
    public InputField Right;
    public InputField Up;
    public InputField Back;

    public s_speechRecog speechRecog;
    public s_gamemanager gamemanager;
    // Use this for initialization
    public void Start ()
    {
        GameManager = GameObject.Find("GameManager");
        speechRecog = GameManager.GetComponent<s_speechRecog>();
        gamemanager = GameManager.GetComponent<s_gamemanager>();

        //List
        Keyword = new string[7];
        Keyword[0] = "Chase";
        Keyword[1] = "Stop";
        Keyword[2] = "Forward";
        Keyword[3] = "Left";
        Keyword[4] = "Right";
        Keyword[5] = "Up";
        Keyword[6] = "Back";
        //

    }


    // Update is called once per frame
    void Update ()
    {
      
        //Debug.Log(leftDir.text);
        //Debug.Log(Keyword[3]);
    }

    public void ChangeControls()
    {
        
        Keyword[0] = Chase.text;
        Keyword[1] = Stop.text;
        Keyword[2] = Forward.text;
        Keyword[3] = Left.text;
        Keyword[4] = Right.text;
        Keyword[5] = Up.text;
        Keyword[6] = Back.text;
        speechRecog.RestartRecog();
    }
}
