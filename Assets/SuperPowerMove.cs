using UnityEngine;
using System.Collections;

public class SuperPowerMove : MonoBehaviour
{
    public int lineMoveSpeed = 7;

    AddedChSpeakScript addedChSpeakScript;
    SuperPowerControlScript superPowerControlScript;

    // Use this for initialization
    void Awake()
    {
        addedChSpeakScript = GameObject.Find("CharacterSpeakManager").GetComponent<AddedChSpeakScript>();
        superPowerControlScript = GameObject.Find("GameManager").GetComponent<SuperPowerControlScript>();
    }

    // Update is called once per frame
    void Update()
    {
        { // 단순 한축 이동 여부 결정.
            transform.Translate(0, 0, -Time.deltaTime * lineMoveSpeed);
        }

        if (transform.position.z < -5)
        { // 일정위치 이하로 내려가면 death.
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "PC" || col.name == "ExtendPlayerBound")
        {
            //슈퍼파워 캐릭터 목소리//
            addedChSpeakScript.ChSpeak(1);
            superPowerControlScript.OnLaserBeam();
            gameObject.SetActive(false);
        }
    }
}
