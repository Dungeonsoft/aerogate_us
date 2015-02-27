using UnityEngine;
using System.Collections;

public class LoadingOpenCloseSoundScript : MonoBehaviour
{

    public AudioClip popupDisplay;

    void OnEnable()
    {
        audio.PlayOneShot(popupDisplay, 1);
    }

}


//게임을 계속 진행하려면\n최신버전으로 업데이트 해야 합니다. 종료
