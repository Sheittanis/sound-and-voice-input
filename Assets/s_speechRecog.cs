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
        Debug.Log(PhraseRecognitionSystem.Status);//Status Check
        //
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

        //Initiate Recognizer
        keywordRecognizer = new KeywordRecognizer(Keyword);
        keywordRecognizer.OnPhraseRecognized += PhraseRecognized; //each time something is called

        //Initiate Dictation
        dictationRecognizer = new DictationRecognizer();
        //dictationRecognizer.Start();

        //Start the recognizer
       // keywordRecognizer.Start();

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
            keywordRecognizer.Start();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           // keywordRecognizer.Stop();
            dictationRecognizer.Start();

            //https://forum.unity3d.com/threads/error-succeeded-hr.431300/#post-2789217
            //http://gyanendushekhar.com/2016/10/11/speech-recognition-in-unity3d-windows-speech-api/
            //REQUIRES Dictation enabled on your system! (Windows Privacy Settings - Get to know me)
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

           // dictationRecognizer.Stop();
            //keywordRecognizer.Stop();
            PhraseRecognitionSystem.Shutdown();
        }


        if (Input.GetKey(KeyCode.R))
        {
            PhraseRecognitionSystem.Restart();

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
        commands.Dir = Vector3.zero;
        commands.Dir = Vector3.left;
        print("Moving left");
    }


    void RightCalled()
    {
        commands.Dir = Vector3.zero;
        commands.Dir = Vector3.right;
        print("Moving right");
    }

    void ForwardCalled()
    {
        commands.Dir = Vector3.zero;
        commands.Dir = Vector3.forward;
        print("Moving forward");
    }

    void BackCalled()
    {
        commands.Dir = Vector3.zero;
        commands.Dir = Vector3.back;
        print("Moving back");
    }
}

//https://developer.microsoft.com/en-us/windows/holographic/voice_input_in_unity