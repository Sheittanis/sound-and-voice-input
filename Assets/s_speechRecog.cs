using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//speech
using UnityEngine.UI;//text
using UnityEngine.Windows.Speech;
using System.Linq;//


/// <summary>
/////https://www.youtube.com/watch?v=HwT6QyOA80E
/// </summary>

public class s_speechRecog : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer; //recognizes a particular word (from a dictionary)
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public string[] Keyword;
    private string word;
    public Text wordspoken;

    public GameObject enemy;
    public GameObject player;

    public s_AIMovement AItriggers;
    public s_Player commands;
    // Use this for initialization
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        player = GameObject.Find("Player");
        AItriggers = enemy.GetComponent<s_AIMovement>();
        commands = player.GetComponent<s_Player>();
        //Status Check
        print(PhraseRecognitionSystem.isSupported);

        //
        //List
        Keyword = new string[6];
        Keyword[0] = "Chase";
        Keyword[1] = "Stop";
        Keyword[2] = "Forward";
        Keyword[3] = "Left";
        Keyword[4] = "Right";
        Keyword[5] = "up";
        //

        //Initiate Recognizer
        keywordRecognizer = new KeywordRecognizer(Keyword);
        keywordRecognizer.OnPhraseRecognized += PhraseRecognized; //each time something is called

        //Start the recognizer
        keywordRecognizer.Start();
        print(PhraseRecognitionSystem.Status);//Status Check


        if (Input.GetKey(KeyCode.A))
        {
            PhraseRecognitionSystem.Restart();
        }//Restarts phrase recognizer in case of failure

    }

    void PhraseRecognized(PhraseRecognizedEventArgs args)
    {
       // System.Action keywordAction;
      // if (keywords.TryGetValue(args.text, out keywordAction))
       // {
            //keywordAction.Invoke();
            Debug.Log("Duration:" + args.phraseDuration); //duration of the phrase
            Debug.Log("Keyword:" + args.text);
            Debug.Log("Confidence Level" + args.confidence);//From API
      //  }
        word = args.text;
        wordspoken.text = "What you said: " + word;
    }


    void Update()
    {
        switch(word)
        {
            case "Chase":
                GoCalled();
                break;
            case "Stop":
                StopCalled();
                break;
            case "Left":
                LeftCalled();
                break;
            case "Right":
                RightCalled();
                break;
            case "Forward":
                ForwardCalled();
                break;
            case "up": //back doesnt work?!
                BackCalled();
                break;
                
        }


        Debug.Log(PhraseRecognitionSystem.Status);//Status Check
    }


    void GoCalled()
    {
        print("Chasing");
        AItriggers.triggered = true;
        //aiMovement.triggered = true;
    }
    void StopCalled()
    {
        AItriggers.triggered = false;
        print("Stopped Chasing");
    }

    void LeftCalled()
    {
        commands.Left();
        print("Moving left");
    }


    void RightCalled()
    {
        commands.Right();
        print("Moving right");
    }

    void ForwardCalled()
    {
        commands.Forward();
        print("Moving forward");
    }

    void BackCalled()
    {
        commands.Back();
        print("Moving back");
    }
}