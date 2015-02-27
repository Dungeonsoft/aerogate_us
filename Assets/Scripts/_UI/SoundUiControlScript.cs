using UnityEngine;
using System.Collections;

public class SoundUiControlScript : MonoBehaviour
{
    ObjectPoolScript objPool;
    CharacterSpeakManagerScript characterSpeakManagerScript;
    //GameObject flight;

    void Awake()
    {
        objPool = GameObject.Find("GameManager").GetComponent<ObjectPoolScript>();
        GetComponent<AudioSource>().volume = ValueDeliverScript.fxSound;

        characterSpeakManagerScript = GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>();
    }

    void Start()
    {
        //flight = GameObject.Find("Flight");

        if (ValueDeliverScript.isTutComplete == 0) return;
        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterSpeak(0);    //인게임 실행시 캐릭터가 시작을 알림.
        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterMessageShow(7);
    }

    //각종 효과음 재생.
    public void PcExplo() //아군 기체 파괴시.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.pcExplo);
    }

    public void UfoAttacked() //개틀링 탄환이 적UFO(웜홀제외)에 적중시.
    {
        //if (flight.activeSelf == true)
        {
        }
        //		audio.PlayOneShot(objPool.ufoAttacked);
    }

    void SkillFull() //스킬게이지가 가득찼을 때.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.skillFull);
    }

    public void SkilShot() //스킬발사시 재생.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.skilShot);
    }

    public void UfoExplo() //ufo파괴시.    
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.ufoExplo);
    }


    public void WormholeAttacked() //웜홀이 탄환에 적중시.
    {
        //		audio.PlayOneShot(objPool.warmholeAttacked);
    }

    public void CoinGet() //코인 획득시.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.coinGet);
    }

    public void ItemGet() //아이템 획득시.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.itemGet);
    }

    public void BombHole()
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.bombHole);
    }

    public void CountSound()
    {
        //if (flight.activeSelf == true)
            StartCoroutine(IeCountSound());

    }

    IEnumerator IeCountSound()
    {
        //만약 캐릭터가 에이단이면 말할게 하나 더 있다//
        int chNum = ValueDeliverScript.activeOper;
        //if (chNum == 2)
        //{
        //    characterSpeakManagerScript.Count6();
        //}
        //만약 캐릭터가 에이단이면 말할게 하나 더 있다//중국버전에서 쓰이던것//
        //카운트다운 음성이 중국버전은 에이단에서 문제가 있어 이렇게 추가를 한것//



        yield return new WaitForSeconds(1f);


        //if (flight.activeSelf == true)
            characterSpeakManagerScript.CharacterSpeak(13);
        characterSpeakManagerScript.CharacterMessageShow(17);
        yield return new WaitForSeconds(1f);
        //if (flight.activeSelf == true)
            characterSpeakManagerScript.CharacterSpeak(14);
        characterSpeakManagerScript.CharacterMessageShow(18);
        yield return new WaitForSeconds(1f);
        //if (flight.activeSelf == true)
            characterSpeakManagerScript.CharacterSpeak(15);
        characterSpeakManagerScript.CharacterMessageShow(19);
        yield return new WaitForSeconds(1f);
        //if (flight.activeSelf == true)
            characterSpeakManagerScript.CharacterSpeak(16);
        characterSpeakManagerScript.CharacterMessageShow(20);
        yield return new WaitForSeconds(1f);
        //if (flight.activeSelf == true)
            characterSpeakManagerScript.CharacterSpeak(17);
        characterSpeakManagerScript.CharacterMessageShow(21);
        yield return new WaitForSeconds(1f);
        //if (flight.activeSelf == true)
            characterSpeakManagerScript.CharacterSpeak(18);
        characterSpeakManagerScript.CharacterMessageShow(22);
    }
    //8월30일.
    public void PcAcceleration()
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.pcAcceleration);
    }

    public void PcChange()
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.pcChange);
    }

    public void BombShot()
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.bombShot);
    }

    public void BtnTouchPhysical()
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.btnTouchPhysical);
    }

    public void BtnTouchDigital()
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.btnTouchDigital);
    }

    public void FriendDrop()
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.friendDrop);
    }

    public void UfoLargeExplo()
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.ufoLargeExplo);
    }

    public void PopupClose()
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.popupClose);
    }

    public void PopupDisplay()
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.popupDisplay);
    }


    //9월5일.
    public void FokkerSkillShot()   //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.fokkerSkillShot);
    }

    public void ComancheSkilshot()   //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.comancheSkilshot);
    }

    public void PhantomSkillShot()   //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.phantomSkillShot);
    }

    public void FriendsAircraftAppear()   //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.friendsAircraftAppear);
    }

    public void FriendsDrop()   //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.friendsDrop);
    }

    public void FriendHelp()   //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.friendHelp);
    }

    public void GetEnergy()   //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.getEnergy);
    }

    public void InstantMissionCheck()   //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.instantMissionCheck);
        characterSpeakManagerScript.CharacterSpeak(12);
        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterMessageShow(23);
    }

    public void LevelPopupDisplay()    //격납고에서 사용됨.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.levelPopupDisplay);
    }

    public void PlasmaWaveShot()   //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.plasmaWaveShot);
    }

    public void SkinSelect()    //격납고에서 사용됨.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.skinSelect);
    }

    public void SocialReward()  //차후 사용예정.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.socialReward);
    }

    public void Sortie()    //격납고에서 사용됨.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.sortie);
    }

    public void WingboxAppear()     //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.wingboxAppear);
    }

    public void WingboxItemDrop()   //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.wingboxItemDrop);
    }

    public void WingboxItemGet()   //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.wingboxItemGet);
    }

    public void WormholeAppear()   //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.wormholeAppear);
    }

    public void WormholeEvolution()   //완.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.wormholeEvolution);
    }


    public void EffectComancheMissileShot() //코만치 미사일 발사음.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.effectComancheMissileShot);
    }
    public void EffectHitComancheMissile()  //코만치 미사일 격추음.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.effectHitComancheMissile);
    }
    public void EffectPhantomMissileShot()  //팬텀 미사일 발사음.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.effectPhantomMissileShot);
    }
    public void EffectHitPhantomMissile()   //팬텀 미사일 격추음.
    {
        //if (flight.activeSelf == true)
            audio.PlayOneShot(objPool.effectHitPhantomMissile);
    }

    public void EffectLaseBeam()   //레이져 빔 격추음.
    {
        Debug.Log("레이져 빔");
        audio.PlayOneShot(objPool.laserBeam);
    }

    public void EffectWarningVoice()
    {
        Debug.Log("워낭소리~");
        audio.PlayOneShot(objPool.warningVoice);
    }


    //public void CharacterSpeak(int scriptNum)
    //{
    //    StartCoroutine(PlaySpeak(scriptNum));
    //}

    //IEnumerator PlaySpeak(int scriptNum)
    //{

    //    if (ValueDeliverScript.isCharacterSound == false)
    //    {
    //        ValueDeliverScript.isCharacterSound = true;
    //        AudioClip sound = objPool.characterSoundSet[scriptNum];
    //        audio.PlayOneShot(sound);
    //        yield return new WaitForSeconds(sound.length);
    //        ValueDeliverScript.isCharacterSound = false;
    //    }
    //    yield return null;
    //}

    //public void CharacterSpeakNormal(int scriptNum)
    //{
    //    audio.PlayOneShot(objPool.characterSoundSet[scriptNum]);
    //}


    //각종 효과음 재생 끝.
}