using UnityEngine;
using System.Collections;
using System.IO;

public class CharacterMsgSndConScript : MonoBehaviour {

    public AudioClip[] loadingBirth;
    public AudioClip[] loadingGame;
    public AudioClip[] loadingEvent;
    public AudioClip[] breakGame;
    public AudioClip[] touch01;
    public AudioClip[] touch02; 
    public AudioClip[] touch03;
    public AudioClip[] touch04;
    public AudioClip[] touch05;
    public AudioClip[] selectStore;
    public AudioClip[] buyCharacter;
    public AudioClip[] buyFlight;
    public AudioClip[] sortieNoBomb;
    public AudioClip[] coinShort;
    public AudioClip[] medalShort;
    public AudioClip[] rankNo3;
    public AudioClip[] skinUnlock;
    public AudioClip[] mailTab;

    void Awake()
    {
        if (ValueDeliverScript.isBgSound == false)
            GetComponent<AudioSource>().volume = 0f;
        else
            GetComponent<AudioSource>().volume = 1f;
    }

    public void LoadingBirth(int CharNum)
    {
        if (ValueDeliverScript.isTutComplete == 2)
        {
            audio.Stop();
            audio.PlayOneShot(loadingBirth[CharNum - 1]);
        }
    }

    public void LoadingGame(int CharNum)
    {
        if (ValueDeliverScript.isTutComplete == 2)
        {
            audio.Stop();
            audio.PlayOneShot(loadingGame[CharNum - 1]);
        }
    }

    public void LoadingEvent(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(loadingEvent[CharNum-1]);
    }

    public void BreakGame(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(breakGame[CharNum-1]);
    }

    public void Touch01(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(touch01[CharNum - 1]);
    }

    public void Touch02(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(touch02[CharNum - 1]);
    }

    public void Touch03(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(touch03[CharNum - 1]);
    }

    public void Touch04(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(touch04[CharNum - 1]);
    }

    public void Touch05(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(touch05[CharNum - 1]);
    }

    public void SelectStore(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(selectStore[CharNum - 1]);
    }

    public void BuyCharacter(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(buyCharacter[CharNum - 1]);
    }

    public void BuyFlight(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(buyFlight[CharNum - 1]);
    }

    public void SortieNoBomb(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(sortieNoBomb[CharNum - 1]);
    }

    public void CoinShort(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(coinShort[CharNum - 1]);
    }

    public void MedalShort(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(medalShort[CharNum - 1]);
    }

    public void RankNo3(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(rankNo3[CharNum - 1]);
    }

    public void SkinUnlock(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(skinUnlock[CharNum - 1]);
    }

    public void MailTab(int CharNum)
    {
        audio.Stop();
        audio.PlayOneShot(mailTab[CharNum - 1]);
    }


}
