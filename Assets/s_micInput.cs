using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //?


public class s_micInput : MonoBehaviour
{

    //Tutorial
    //http://www.kaappine.fi/tutorials/using-microphone-input-in-unity3d/
    //

    public GameObject audioInput;
    public float sensitivity = 100;
    public float loudness = 0;

    AudioSource audio;

    void Start()
    {
        //Unity API
        audio = GetComponent<AudioSource>();
        //Starts the microphone, sets the recording of it as a clip in the audio source
        audio.clip = Microphone.Start(null, true, 10, 44100); //Device, Looping boolean, length, Sample Rate.

        //
        audio.loop = true;
        audio.mute = true; //Mute it. Unmmute for feedback?
        Debug.Log(audio.loop);

        audio.Play();


    }

    void Update()
    {
        loudness = Volume() * sensitivity;
        Debug.Log(loudness);
    }

    public float Volume() //????//http://www.kaappine.fi/tutorials/using-microphone-input-in-unity3d/
    {
        float average = 0;
        float[] data = new float[256];
        audio.clip.GetData(data, 0);
        foreach(float s in data)
        {
            average += Mathf.Abs(s);
            //Debug.Log(average); //RIP CPU.
        }
        return average / 256;
    }/////// http://answers.unity3d.com/questions/1113690/microphone-input-in-unity-5x.html //said he has issues with it not working, seems fine to me?
}

//ALTERNATIVES/

//http://answers.unity3d.com/questions/479064/microphone-detect-speech-start-end.html
//http://stackoverflow.com/questions/37443851/unity3d-check-microphone-input-volume
//http://answers.unity3d.com/questions/394158/real-time-microphone-line-input-fft-analysis.html
