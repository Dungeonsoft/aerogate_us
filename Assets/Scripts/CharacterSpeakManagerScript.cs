using UnityEngine;
using System.Collections;

public class CharacterSpeakManagerScript : MonoBehaviour {

    ObjectPoolScript objPool;
    GameObject characterMessageUI;
    string[] itemGetScript;

    bool isCountDown = false;

    GameObject flight;

    AudioClip soundSix;

    void Awake()
    {
        if (ValueDeliverScript.isBgSound == false)
        {
            GetComponent<AudioSource>().volume = 0f;
        }
        else
        {
            GetComponent<AudioSource>().volume = 1f;
        }

        //GetComponent<AudioSource>().volume = ValueDeliverScript.fxSound*3f;
        //Debug.Log("GetComponent<AudioSource>().volume" + GetComponent<AudioSource>().volume);
        objPool = GameObject.Find("GameManager").GetComponent<ObjectPoolScript>();
        characterMessageUI = GameObject.Find("CharacterMessageUI");

        GetComponent<AudioSource>().volume = ValueDeliverScript.characterSound;

        soundSix = GameObject.Find("GameManager").GetComponent<ObjectPoolScript>().countDown6Ai;
    }
    void Start()
    {
        itemGetScript = GameObject.Find("GameManager").GetComponent<ObjectPoolScript>().itemGetScript;
        flight = GameObject.Find("Flight");
    }

    public void CharacterSpeak(int scriptNum)   //캐릭터 음성 호출용 함수.
    {
        if (flight.activeSelf == true)
            StartCoroutine(PlaySpeak(scriptNum));
    }

    IEnumerator PlaySpeak(int scriptNum)
    {
        if (flight.activeSelf == true)
        {
            AudioClip sound = objPool.characterSoundSet[scriptNum];

            if ((scriptNum > 13 && scriptNum < 19) || (scriptNum > 1 && scriptNum < 8))  //카운트 다운 범위
            {
                //Debug.Log("CountDown Ready" + scriptNum);
                audio.Stop();
                if (flight.activeSelf == true)
                    audio.PlayOneShot(sound);
            }

            else if (!isCountDown)
            {
                if (ValueDeliverScript.isCharacterSound == false)
                {
                    if (flight.activeSelf == true)
                    {
                        ValueDeliverScript.isCharacterSound = true;
                        audio.PlayOneShot(sound);
                        if (sound != null) yield return new WaitForSeconds(sound.length);
                        ValueDeliverScript.isCharacterSound = false;
                    }
                }
            }
        }
    }

    public void CharacterMessageShow(int scriptNum) //캐릭터 대사창 호출용 함수.
    {
        if (flight.activeSelf == true)
        {
            if (scriptNum > 8 && scriptNum < 15)
            {
                characterMessageUI.animation.Play("CharSpeakLabelAnim01");
                characterMessageUI.transform.FindChild("Label").GetComponent<UILabel>().text = itemGetScript[scriptNum];
            }

            else if (scriptNum > 16 && scriptNum < 23)   //카운트 다운 범위
            {
                if (!isCountDown) characterMessageUI.animation.Play("CharSpeakLabelAnim02");

                isCountDown = true;
                //Debug.Log("isCountDown is " + isCountDown);

                characterMessageUI.transform.FindChild("Label").GetComponent<UILabel>().text = itemGetScript[scriptNum];
                if (scriptNum == 22) StartCoroutine(CountDownEnd(itemGetScript[scriptNum].Length));
            }

            else if (isCountDown)   //카운트 다운일경우 다른 대사를 처리하지 않는다.
            {
                return;
            }
            else if (!isCountDown)
            {
                //Debug.Log("Present Position is End IF!!! \n isCountDown is " + isCountDown);

                characterMessageUI.animation.Play("CharSpeakLabelAnim01");
                characterMessageUI.transform.FindChild("Label").GetComponent<UILabel>().text = itemGetScript[scriptNum];
            }
        }
    }

    IEnumerator CountDownEnd(float speakLenth)
    {
        if (flight.activeSelf == true)
        {
            yield return new WaitForSeconds(speakLenth);
            isCountDown = false;
            //Debug.Log("isCountDown is " + isCountDown);
        }
    }

    public void Count6()
    {
        
        audio.PlayOneShot(soundSix);
    }
}
