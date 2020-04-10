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


//only functions in win10///

public class s_speechRecog : MonoBehaviour
{

    DictationRecognizer dictationRecognizer;
    KeywordRecognizer keywordRecognizer; //recognizes a particular word (from a dictionary)
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();


    private string word;
    public Text wordspoken;

    public GameObject enemy;
    public GameObject player;
    public GameObject gamemanager;

    public s_AIMovement AItriggers;
    public s_Player playerCommands;
    public s_commands inputCommands;
    // Use this for initialization
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        player = GameObject.Find("Player");
        gamemanager = GameObject.Find("GameManager");

        AItriggers = enemy.GetComponent<s_AIMovement>();
        playerCommands = player.GetComponent<s_Player>();
        inputCommands = gamemanager.GetComponent<s_commands>();
        //Status Check
        print(PhraseRecognitionSystem.isSupported);
        //

        //Initiate Recognizer
        inputCommands.Start();
        keywordRecognizer = new KeywordRecognizer(inputCommands.Keyword);
        keywordRecognizer.OnPhraseRecognized += PhraseRecognized; //each time something is called

        //Initiate Dictation
        dictationRecognizer = new DictationRecognizer();
        //dictationRecognizer.Start();

        //Start the recognizer
        keywordRecognizer.Start();

    }

    public void RestartRecog()
    {
        keywordRecognizer.Stop();
        keywordRecognizer.OnPhraseRecognized -= PhraseRecognized;
        Debug.Log(inputCommands.Keyword);
        //keywordRecognizer = new KeywordRecognizer(inputCommands.Keyword);

        KeywordRecognizer temp = new KeywordRecognizer(inputCommands.Keyword);
        keywordRecognizer = temp;
        keywordRecognizer.OnPhraseRecognized += PhraseRecognized; //each time something is called
        keywordRecognizer.Start();
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
            case "Up": //back doesnt work?!
                BackCalled();
                break;
            case "Back": //back doesnt work?!
                BackCalled();
                break;

        }

        //http://stackoverflow.com/questions/36489077/microsoft-speech-recognition-engine-switching-between-grammars GOod read

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           // dictationRecognizer.Stop();
            //keywordRecognizer.Start();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           // keywordRecognizer.Stop();
            //dictationRecognizer.Start();

            //https://forum.unity3d.com/threads/error-succeeded-hr.431300/#post-2789217
            //http://gyanendushekhar.com/2016/10/11/speech-recognition-in-unity3d-windows-speech-api/
            //REQUIRES Dictation enabled on your system! (Windows Privacy Settings - Get to know me)
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

           // dictationRecognizer.Stop();
            //keywordRecognizer.Stop();
            //PhraseRecognitionSystem.Shutdown();
        }


        if (Input.GetKey(KeyCode.R))
        {
            //PhraseRecognitionSystem.Restart();

        }//Restarts phrase recognizer in case of failure

        Debug.Log(PhraseRecognitionSystem.Status); //Re-enable to check

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
        playerCommands.Dir = Vector3.zero;
        playerCommands.Dir = Vector3.left;
        print("Moving left");
    }


    void RightCalled()
    {
        playerCommands.Dir = Vector3.zero;
        playerCommands.Dir = Vector3.right;
        print("Moving right");
    }

    void ForwardCalled()
    {
        playerCommands.Dir = Vector3.zero;
        playerCommands.Dir = Vector3.forward;
        print("Moving forward");
    }

    void BackCalled()
    {
        playerCommands.Dir = Vector3.zero;
        playerCommands.Dir = Vector3.back;
        print("Moving back");
    }
}

//https://developer.microsoft.com/en-us/windows/holographic/voice_input_in_unity