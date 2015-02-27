using UnityEngine;
using System.Collections;

public class InGameBgSoundScript : MonoBehaviour
{
    public bool resultBgSound = false;
    public AudioClip BGM;
    void Awake()
    {
        if (ValueDeliverScript.isBgSound == false)
        {
            GetComponent<AudioSource>().volume = 0f;
            GetComponent<AudioSource>().clip = BGM;
        }
        else
        {
            GetComponent<AudioSource>().volume = 1f;
            GetComponent<AudioSource>().clip = BGM;

            if (resultBgSound == true)
            {
                if (ValueDeliverScript.isResultToHanger == true)
                    GetComponent<AudioSource>().Play();
            }
            else if (resultBgSound == false)
            {
                if (ValueDeliverScript.isResultToHanger == false)
                    GetComponent<AudioSource>().Play();
            }
            if (Application.loadedLevel == 2)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
