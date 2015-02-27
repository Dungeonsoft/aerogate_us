using UnityEngine;
using System.Collections;

public class AddedChSpeakScript : MonoBehaviour {

    public AudioClip[] ch01Speak;
    public AudioClip[] ch02Speak;
    public AudioClip[] ch03Speak;
    public AudioClip[] ch04Speak;


    AudioClip[] chSpeakSet;



    void Awake()
    {
        int activeOper = ValueDeliverScript.activeOper;

        switch (activeOper)
        {
            case 1: chSpeakSet = ch01Speak; break;

            case 2: chSpeakSet = ch02Speak; break;

            case 3: chSpeakSet = ch03Speak; break;

            case 4: chSpeakSet = ch04Speak; break;
        }

    }


    public void ChSpeak(int speakNum)
    {
        audio.PlayOneShot(chSpeakSet[speakNum]);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
