using UnityEngine;
using System.Collections;
using System;


public class UiShow : MonoBehaviour
{
    public GameObject pauseMessage;
    public GameObject pauseMessageWarning;
    public GameObject forPause; //오브젝트인 ForPose를 가리키기 위한 것.
    public GameObject oneMoreWin;
    public GameObject pauseShield;
    public GameObject CountShield;
    public GameObject buyDiamondWin;

    ScoreCoinCount scoreCoinCount;

    SoundUiControlScript soundUiControlScript;

    bool isPose = true;

    float alphaValue = 0;

    GameObject flight;
    GameObject centerBlack;

    UIFilledSprite bombButton01UIFilledSprite;
    CharacterSpeakManagerScript characterSpeakManager;

    AudioSource bgAudioSource;
    float bgVolume;

    void Awake()
    {
        CountShield.SetActive(false);
        flight = GameObject.Find("Flight");
        centerBlack = GameObject.Find("BlackPanel").transform.FindChild("BlackBezel/CenterBack").gameObject;

        bombButton01UIFilledSprite = GameObject.Find("BombButton01").GetComponent<UIFilledSprite>();
        characterSpeakManager = GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>();

        //pauseMessage = GameObject.Find("PauseMessage");
        //pauseMessageWarning = GameObject.Find("PauseMessageWarning");
        //forPause = GameObject.Find("ForPauseGreyShield");
        //pauseMessage.SetActive(false);
        //pauseMessageWarning.SetActive(false);
        //forPause.SetActive(false);

        soundUiControlScript = GameObject.Find("GameManager").GetComponent<SoundUiControlScript>();
        oneMoreWin.SetActive(false);

        bgAudioSource = GameObject.Find("BgSoundObject").GetComponent<AudioSource>();
        bgVolume = bgAudioSource.volume;

    }

    void Start()
    {
        scoreCoinCount = GameObject.Find("GameManager").GetComponent<ScoreCoinCount>();
    }

    public void GameEnd() //포즈버튼 눌렀을때 처음 나오는 창.
    {
        Everyplay.PauseRecording();
        //Debug.Log("GameEnd::::");
        soundUiControlScript.PopupDisplay();
        pauseMessage.SetActive(true);
        StartCoroutine(NonTimeAniPlay());
        forPause.SetActive(true);
    }

    IEnumerator NonTimeAniPlay()
    {
        float aniLength = pauseMessage.animation["UiPopUpAni_Pause"].length;
        
        pauseMessage.animation.Play("UiPopUpAni_Pause");

        for (float i = 0; i <= aniLength; i += 0.02f)
        {
            pauseMessage.animation["UiPopUpAni_Pause"].time = i;
            //						pauseMessage.animation.Play ("UiPopUpAni_Pause");
            yield return null;
        }

    }



    public void GameEnd2() //격납고로 이동하려고 할때 나오는 재차 확인창.
    {
        Debug.Log("GameEnd2");
        soundUiControlScript.PopupClose();
        pauseMessage.SetActive(false);
        pauseMessageWarning.SetActive(true);
    }

    public void GameEnd3()
    {
        //여기서 코드를 삽입하면 비행기가 파괴되고 추가로 비행기를 불러서 게임을 계속할지 여부를 결정하는 것을 할 수 있음.
        if (ValueDeliverScript.isTutComplete == 0)
        {
            //여긴 튜토리얼 모드에서 들어오는쪽.
            StartCoroutine(TutMode());
        }
        else
        {
            ValueDeliverScript.isNoEnd = true;
            StartCoroutine(OneMoreAction());

            //여긴 정상 모드에서 들어오는 쪽.
            //StartCoroutine(GameEnd4());
        }
    }

    int rebirthCount = 0;
    IEnumerator OneMoreAction()
    {
        yield return new WaitForSeconds(1f);    //바로 어두워지지 않고 1초후에 어두워지는 것이 시작되도록 바꿈.

        AudioSource bgAudioSource = GameObject.Find("BgSoundObject").GetComponent<AudioSource>();
        float bgVolume = bgAudioSource.volume;
        centerBlack.SetActive(true);

        //점점 어두워짐.인게임 끝나는 부분에서 작동.
        while (true)
        {
            centerBlack.GetComponent<UITexture>().material.SetColor("_TintColor", new Color(0f, 0f, 0f, alphaValue));
            bgAudioSource.volume -= alphaValue * 4;
            if (alphaValue <= 0.25f)
            {
                alphaValue += Time.deltaTime * 0.5f;
                yield return null;
            }
            else
            {

                if (rebirthCount < 3)
                {

                    ValueDeliverScript.isOneMoreWin = true;
                    oneMoreWin.SetActive(true);
                    //시간을 흐르게 해주는 변수//
                    GameObject.Find("OneMoreWin").transform.FindChild("OneMoreCount").GetComponent<OneMoreCount>().isIntoShop = false;

                    if (UnityEngine.Advertisements.Advertisement.isReady() == true)
                    {
                        oneMoreWin.transform.FindChild("FreeFuelButton").gameObject.SetActive(true);
                        oneMoreWin.transform.FindChild("DiamondButton").localPosition = new Vector3(-194.5f, -263, 0);
                    }
                    else
                    {
                        oneMoreWin.transform.FindChild("FreeFuelButton").gameObject.SetActive(false);
                        oneMoreWin.transform.FindChild("DiamondButton").localPosition = new Vector3(0, -263, 0);
                    }
                    oneMoreWin.GetComponent<OneMorePriceSetScript>().Activate();
                    yield break;
                }
                else
                {
                    //부활 3회가 넘으면 그냥 게임을 종료한다//
                    StartCoroutine(GameEnd4());
                    yield break;
                }
            }
        }


    }

    void OneMoreDia()   //다이아로 이어하기 구매.
    {
        GameObject OneMoreWin = GameObject.Find("OneMoreWin");
        int requiredPrice = OneMoreWin.GetComponent<OneMorePriceSetScript>().diamondPrice;

        if (ValueDeliverScript.medalRest >= requiredPrice)
        {
            Debug.Log("다이어로 이어하기 성공");
            ValueDeliverScript.medalRest -= requiredPrice;
            ValueDeliverScript.SaveGameData();
            GameObject.Find("OneMoreCount").GetComponent<OneMoreCount>().CountReset();
            OneMoreActionYes();
        }
        else
        {
            Debug.Log("다이어로 이어하기 실패");
            StartCoroutine(ShowBuyDiamondWin());
            buyDiamondWin.GetComponent<BuyDiamondWin>().DiaTxt.GetComponent<UILabel>().text = ValueDeliverScript.medalRest + "";
        }
    }

    void AdsFailed()
    {
        oneMoreWin.transform.FindChild("FreeFuelButton").gameObject.SetActive(false);
        oneMoreWin.transform.FindChild("DiamondButton").localPosition = new Vector3(0, -263, 0);
    }

    public void GetFreeFuel()
    {
        GameObject.Find("OneMoreCount").GetComponent<OneMoreCount>().isIntoShop = true;
        GetComponent<UnityAdsManager>().AbleAds(OneMoreActionYes, AdsFailed);
    }

    public void ViewCMFailed()
    {
        GameObject.Find("OneMoreCount").GetComponent<OneMoreCount>().isIntoShop = false;
    }



    IEnumerator ShowBuyDiamondWin()
    {
        GameObject.Find("OneMoreCount").GetComponent<OneMoreCount>().isIntoShop = true;

        buyDiamondWin.transform.FindChild("CloseBtn").GetComponent<UIButtonMessage>().target = GameObject.Find("GameManager");

        if (oneMoreWin.GetComponent<TweenScale>() == null)
        {
            oneMoreWin.AddComponent<TweenScale>();
        }
        oneMoreWin.GetComponent<TweenScale>().from = Vector3.one;
        oneMoreWin.GetComponent<TweenScale>().to = Vector3.zero;
        oneMoreWin.GetComponent<TweenScale>().method = UITweener.Method.BounceOut;
        oneMoreWin.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        oneMoreWin.GetComponent<TweenScale>().enabled = true;
        yield return null;
        oneMoreWin.GetComponent<TweenScale>().style = UITweener.Style.Once;

        yield return new WaitForSeconds(0.4f);

        if (buyDiamondWin.GetComponent<TweenScale>() == null)
        {
            buyDiamondWin.AddComponent<TweenScale>();
        }
        buyDiamondWin.GetComponent<TweenScale>().from = Vector3.zero;
        buyDiamondWin.GetComponent<TweenScale>().to = Vector3.one;
        buyDiamondWin.GetComponent<TweenScale>().method = UITweener.Method.BounceIn;
        buyDiamondWin.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        buyDiamondWin.GetComponent<TweenScale>().enabled = true;
        yield return null;
        buyDiamondWin.GetComponent<TweenScale>().style = UITweener.Style.Once;
    }

    IEnumerator BuyDiamondWinClose()
    {
        GameObject.Find("OneMoreCount").GetComponent<OneMoreCount>().isIntoShop = false;

        if (buyDiamondWin.GetComponent<TweenScale>() == null)
        {
            buyDiamondWin.AddComponent<TweenScale>();
        }
        buyDiamondWin.GetComponent<TweenScale>().from = Vector3.one;
        buyDiamondWin.GetComponent<TweenScale>().to = Vector3.zero;
        buyDiamondWin.GetComponent<TweenScale>().method = UITweener.Method.BounceOut;
        buyDiamondWin.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        buyDiamondWin.GetComponent<TweenScale>().duration = 0.4f;
        buyDiamondWin.GetComponent<TweenScale>().enabled = true;
        yield return null;
        buyDiamondWin.GetComponent<TweenScale>().style = UITweener.Style.Once;


        yield return new WaitForSeconds(0.4f);

        if (this.GetComponent<TweenScale>() == null)
        {
            this.gameObject.AddComponent<TweenScale>();
        }
        oneMoreWin.GetComponent<TweenScale>().from = Vector3.zero;
        oneMoreWin.GetComponent<TweenScale>().to = Vector3.one;
        oneMoreWin.GetComponent<TweenScale>().method = UITweener.Method.BounceIn;
        oneMoreWin.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        oneMoreWin.GetComponent<TweenScale>().duration = 0.4f;
        oneMoreWin.GetComponent<TweenScale>().enabled = true;
        yield return null;
        oneMoreWin.GetComponent<TweenScale>().style = UITweener.Style.Once;

        yield return new WaitForSeconds(0.4f);
    }


    void OnBillingResult(String result)
    {
        Debug.Log("여기오냐?돈?");
        Debug.Log("BillingResult=" + result);

        String[] results = result.Split('|');
        //if (CmBillingAndroid.BillingResult.CANCELLED == results[1])
        //{
        //    CmBillingAndroid.Instance.ExitWithUI();
        //    return;
        //}

        //if (CmBillingAndroid.BillingResult.SUCCESS == results[1])
        //{
        //    OneMoreActionYes();
        //}
    }

    void OneMoreActionYes()
    {
        rebirthCount++;
        GameObject.Find("FuelSlider").GetComponent<FuelSliderScript>().isFuel = false;
        bgAudioSource.volume = bgVolume;
        StartCoroutine(YesAction());
    }

    public void OneMoreActionCancel()
    {
        Everyplay.StopRecording();
        Everyplay.SetMetadata("gamename", "AeroGate");
        Everyplay.SetMetadata("name", ValueDeliverScript.Nick);
        GameObject.Find("Anchor").transform.FindChild("LoadingPanel").gameObject.SetActive(true);
        StartCoroutine(GameEnd4());
    }

    IEnumerator YesAction()
    {
        ValueDeliverScript.isPcExplo = false;

        oneMoreWin.SetActive(false);
        //연료바가 모두 참//
        StartCoroutine(FuelRecharge());

        yield return new WaitForSeconds(0.7f);
        centerBlack.SetActive(false);

        StartCoroutine(GameObject.Find("PC").GetComponent<PlayerMoveScript>().Rebirth());

        GetComponent<BombSkillGageScript>().AddSkillGageValue(100000);
        bombButton01UIFilledSprite.fillAmount = 1; //핵폭탄게이지 모두 차고 시간 초기화.
        characterSpeakManager.CharacterMessageShow(1);
    }

    //다이아를 구매하고 게임을 계속 할 경우//
    IEnumerator FuelRecharge()
    {
        ValueDeliverScript.isPcExplo = false;
        FuelSliderScript fuelSliderScript = GameObject.Find("FuelSlider").GetComponent<FuelSliderScript>();
        fuelSliderScript.FuelGageSettingVoid();
        yield return new WaitForSeconds(3f);
        fuelSliderScript.GageReduceVoid();
    }


    IEnumerator TutMode()
    {
        yield return new WaitForSeconds(6f);
        //결과창 표시여부 결정//
        ValueDeliverScript.gameEndResult = true;	//이 값이 true면 결과창을 출력한다.
        ValueDeliverScript.isResultToHanger = true;
        Time.timeScale = 1;
        ValueDeliverScript.isTutComplete = 1;
        PlayerPrefs.SetInt("isTutComplete", 1);
        Application.LoadLevel(1);
    }

    //	void RestartClick ()//재시작버튼.
    //	{
    //		ValueDeliverScript.dartCount 
    //			= ValueDeliverScript.dustCount 
    //				= ValueDeliverScript.shieldCount 
    //				= ValueDeliverScript.spinballCount
    //				= 0;
    //		
    //		ValueDeliverScript.scorePlay
    //			= ValueDeliverScript.coinPlay 
    //				= 0;
    //		
    //		Time.timeScale = 1f;
    //		
    //		Application.LoadLevel("InGame01");
    //	}

    void EndClick()//종료버튼.
    {
        Application.Quit();
    }

    void OnGoToMain() //PauseMessageWarning 오브젝트의 이동(Yes) 버튼을 누르면 실행.
    {
        ValueDeliverScript.isBreakGame = true;
        soundUiControlScript.PopupClose();
        //Time.timeScale = 1;
        //GameObject.Find("GetUserInfoManager").SendMessage("GetGameInfo2");  //게임데이터를 로딩하는 부분인데... 속도를 많이 늦추니 우선은 주석처리.
        Application.LoadLevel("Hangar");    //바로 윗줄이 활성화 되면 주석처리.
    }

    public void OnPose() //일시정지 버튼.
    {
        if (ValueDeliverScript.isTutComplete == 0 || ValueDeliverScript.isPcExplo == true) return;

        if (isPose) //버튼 눌러 멈출때//
        {
            Debug.Log("여기 멈추냐? ::: 1");
            pauseShield.SetActive(true);
            CountShield.SetActive(true);
            Time.timeScale = 0;
            isPose = false;
            GameEnd();
        }
        else
        {
            Debug.Log("여기 멈추냐? ::: 2");
            soundUiControlScript.PopupClose();
            isPose = true;
            pauseMessage.SetActive(false);
            pauseMessageWarning.SetActive(false);
            forPause.SetActive(false);
            StartCoroutine(NonTimeAniCountPlay());
            //StartCoroutine(PauseShieldDelay());
        }
    }

    //IEnumerator PauseShieldDelay()
    //{
    //    yield return new WaitForSeconds(4f);
    //    pauseShield.SetActive(false);
    //}

    IEnumerator NonTimeAniCountPlay()
    {
        GameObject count = GameObject.Find("Count");
        float aniLength = count.animation["CountAnim01"].length;
        count.animation.Play("CountAnim01");
        for (float i = 0; i <= aniLength; i += 0.02f)
        {
            count.animation["CountAnim01"].time = i;
            yield return null;

            if (isPauseUi)
            {
                count.animation["CountAnim01"].time = 0;
                isPauseUi = false;
                yield break;
            }
        }

        Everyplay.ResumeRecording();
        Time.timeScale = 1;
        CountShield.SetActive(false);
        pauseShield.SetActive(false);
    }


    bool isPauseUi;
    void OnApplicationPause(bool pauseSt)
    {
        isPauseUi = pauseSt;
    }


    IEnumerator GameEnd4()		//게임이 끝나고 결과창을 보여줄지 여부를 결정하는 부분.
    {
        int userExp = ValueDeliverScript.userExp;
        int coinRest = ValueDeliverScript.coinRest; //이번 게임 직적까지 보유하고 있던 코인의 양//
        int dartCount = ValueDeliverScript.dartCount;
        int dustCount = ValueDeliverScript.dustCount;
        int spinballCount = ValueDeliverScript.spinballCount;
        int shieldCount = ValueDeliverScript.shieldCount;

        int flight000BombUseNumber = ValueDeliverScript.flight000BombUseNumber;
        int flight001EnemyKill = ValueDeliverScript.flight001EnemyKill;
        int flight001GetCoin = ValueDeliverScript.flight001GetCoin;
        int flight001UseSkill = ValueDeliverScript.flight001UseSkill;
        int flight001GetPowerItem = ValueDeliverScript.flight001GetPowerItem;
        int flight002KillSpinball = ValueDeliverScript.flight002KillSpinball;
        int flight002CompleteInstanceMission = ValueDeliverScript.flight002CompleteInstanceMission;
        int flight002RescueFriend = ValueDeliverScript.flight002RescueFriend;
        int flight000ScoreHigh = ValueDeliverScript.flight000ScoreHigh;
        int flight002SpecialAttack = ValueDeliverScript.flight002SpecialAttack;
        int flight002WormLevel5 = ValueDeliverScript.flight002WormLevel5;

        int activeOper = ValueDeliverScript.activeOper;

        //유저 경험치를 기록//
        float exp = (Time.timeSinceLevelLoad / 4f) + 50 + ValueDeliverScript.addFlightExp;
        userExp += (int)Mathf.Round(exp);
        Debug.Log("Flight Experience_________________________________" + userExp);
        Debug.Log("Flight coinRest_________________________________" + coinRest);
        Debug.Log("Flight coinPlay_________________________________" + ValueDeliverScript.coinPlay);
        Debug.Log("Flight destinyCardNumber_________________________________" + ValueDeliverScript.destinyCardNumber);

        //유저 경험치를 기록//


        #region 캐릭터 선택시 발동되는 기능들을 적용한다.
        //에이단(2)이 선택되었을때 스킨 경험치를 50% 추가 지급한다.
        if (activeOper == 2)
            ValueDeliverScript.skinExp = (int)(ValueDeliverScript.skinExp * 1.5f);

        //댄모렌(3)이 선택되었을때 유저 경험치를 50% 추가 지급한다.
        if (activeOper == 3)
            exp = exp * 1.5f;

        //레이첼가 선택되었을때 코인 획득량을 100% 추가지급한다.
        if (activeOper == 4)
            ValueDeliverScript.coinPlay = (int)(ValueDeliverScript.coinPlay * 2f);
        #endregion

        yield return new WaitForSeconds(2f);

        coinRest += ValueDeliverScript.coinPlay;	//게임 종료후 획득 동전 동전스코어(coinRest)에 적용.
        AddSkinExp(1f);

        //스페셜 출격시 적기 격추량을 임시로 모아놓은 것을 실제 적용 데이터로 옮기는 부분.//
        dartCount += ValueDeliverScript.dartCountTemp;
        dustCount += ValueDeliverScript.dustCountTemp;
        spinballCount += ValueDeliverScript.spinballCountTemp;
        shieldCount += ValueDeliverScript.shieldCountTemp;

        //스페셜 출격시 적기 격추량을 임시로 모아놓은 것을 실제 적용 데이터로 옮기는 부분.//

        //스페셜출격 임시 격추량을 초기화//
        ValueDeliverScript.dartCountTemp = ValueDeliverScript.dustCountTemp = ValueDeliverScript.spinballCountTemp = ValueDeliverScript.shieldCountTemp = 0;
        //스페셜출격 임시 격추량을 초기화//

        //디텍터초기화//
        ValueDeliverScript.detectorType = -1;
        //디텍터초기화//

        //더블윙박스초기화//
        ValueDeliverScript.wingboxDouble = false;
        //더블윙박스초기화//


        //결과창 표시여부 결정//
        ValueDeliverScript.gameEndResult = true;	//이 값이 true면 결과창을 출력한다.
        ValueDeliverScript.isResultToHanger = true;
        Time.timeScale = 1;

        //우리쪽 서버에만 저장하도록 만든것. 현재는 카톡에 저장이 되니 사용필요가 없음.
        yield return null;
        Debug.Log("Score Play ::: In Game ::: " + ValueDeliverScript.scorePlay);
        Debug.Log("Score Play ::: In Game ::: " + userExp);
        //결과창 표시여부 결정//

        //Debug.Log("My Season Score is :::: " + KakaoGameUserInfo.Instance.scores[0].season_score);
        //if(true)
        Debug.Log("Into IF");

        //이부분은 어떤 카드가 선택되었는가를 기준으로 새롭게 작성하여야 된다//
        //참고 변수는 ValueDeliverScript.destinyCardNumber//
        //스페셜 출격 미션 완료시 효과.
        if (ValueDeliverScript.isSelectSpecial)
        {
            switch (ValueDeliverScript.destinyCardNumber)
            {
                case 0:
                    ValueDeliverScript.scorePlay += Mathf.FloorToInt(ValueDeliverScript.scorePlay * 0.1f);
                    break;
                case 1:
                    ValueDeliverScript.scorePlay += Mathf.FloorToInt(ValueDeliverScript.scorePlay * 0.2f);
                    break;
                case 2:
                    ValueDeliverScript.scorePlay += Mathf.FloorToInt(ValueDeliverScript.scorePlay * 0.3f);
                    break;
                case 3:
                    coinRest += Mathf.RoundToInt(ValueDeliverScript.coinPlay * 0.5f);
                    break;
                case 4:
                    coinRest += Mathf.RoundToInt(ValueDeliverScript.coinPlay * 0.75f);
                    break;
                case 5:
                    coinRest += ValueDeliverScript.coinPlay;
                    break;
                case 6:
                    userExp += Mathf.RoundToInt(exp * 0.5f);
                    break;
                case 7:
                    userExp += Mathf.RoundToInt(exp * 0.75f);
                    break;
                case 8:
                    userExp += Mathf.RoundToInt(exp);
                    break;
                case 9:
                    AddSkinExp(0.5f);
                    break;
                case 10:
                    AddSkinExp(0.75f);
                    break;
                case 11:
                    AddSkinExp(1f);
                    break;
                case 12:
                    ValueDeliverScript.scorePlay += Mathf.FloorToInt(ValueDeliverScript.scorePlay * 0.2f);
                    coinRest += Mathf.RoundToInt(ValueDeliverScript.coinPlay * 0.2f);
                    break;
                case 13:
                    ValueDeliverScript.scorePlay += Mathf.FloorToInt(ValueDeliverScript.scorePlay * 0.2f);
                    userExp += Mathf.RoundToInt(exp * 0.2f);
                    break;
                case 14:
                    ValueDeliverScript.scorePlay += Mathf.FloorToInt(ValueDeliverScript.scorePlay * 0.2f);
                    AddSkinExp(0.3f);
                    break;
                case 15:
                    ValueDeliverScript.scorePlay += Mathf.FloorToInt(ValueDeliverScript.scorePlay * 0.3f);
                    coinRest += Mathf.RoundToInt(ValueDeliverScript.coinPlay * 0.3f);
                    break;
                case 16:
                    ValueDeliverScript.scorePlay += Mathf.FloorToInt(ValueDeliverScript.scorePlay * 0.3f);
                    userExp += Mathf.RoundToInt(exp * 0.3f);
                    break;
                case 17:
                    ValueDeliverScript.scorePlay += Mathf.FloorToInt(ValueDeliverScript.scorePlay * 0.3f);
                    AddSkinExp(0.3f);
                    break;
            }
        }
        ValueDeliverScript.skinExp = 0;


        //Debug.Log("여기오냐?1");

        //포커로 출격시 사용한 폭탄의 수를 기록.
        flight000BombUseNumber += ValueDeliverScript.flight000BombUseNumberTemp;
        ValueDeliverScript.flight000BombUseNumberTemp = 0;
        //Debug.Log("여기오냐?2");
        //코만치로 출격시 처치한 적의 수를 기록.
        flight001EnemyKill += ValueDeliverScript.flight001EnemyKillTemp;
        ValueDeliverScript.flight001EnemyKillTemp = 0;
        //Debug.Log("여기오냐?3");
        //코만치로 출격시 획득한 동전 수를 기록.
        flight001GetCoin += ValueDeliverScript.flight001GetCoinTemp;
        ValueDeliverScript.flight001GetCoinTemp = 0;
        //Debug.Log("여기오냐?4");
        //코만치로 출격시 사용한 스킬 수를 기록.
        flight001UseSkill += ValueDeliverScript.flight001UseSkillTemp;
        ValueDeliverScript.flight001UseSkillTemp = 0;
        //Debug.Log("여기오냐?5");
        //코만치로 출격시 획득한 파워아이템의 수를 기록.
        flight001GetPowerItem += ValueDeliverScript.flight001GetPowerItemTemp;
        ValueDeliverScript.flight001GetPowerItemTemp = 0;
        //Debug.Log("여기오냐?6");
        //팬텀으로 출격시 스핀볼 처치 수를 기록.
        flight002KillSpinball += ValueDeliverScript.flight002KillSpinballTemp;
        ValueDeliverScript.flight002KillSpinballTemp = 0;
        //Debug.Log("여기오냐?7");
        //팬텀으로 출격시 완수한 인스턴스 미션의 수를 기록.
        flight002CompleteInstanceMission += ValueDeliverScript.flight002CompleteInstanceMissionTemp;
        ValueDeliverScript.flight002CompleteInstanceMissionTemp = 0;
        //Debug.Log("여기오냐?8");
        //팬텀으로 출격시 구출한 친구의 수를 기록.
        flight002RescueFriend += ValueDeliverScript.flight002RescueFriendTemp;
        ValueDeliverScript.flight002RescueFriendTemp = 0;
        //Debug.Log("여기오냐?9");
        //포커로 출격시 획득한 점수가 얼마인지 기록.
        if (ValueDeliverScript.flightNumber == 0)
        {
            if (ValueDeliverScript.scorePlay > flight000ScoreHigh)
            {
                flight000ScoreHigh = ValueDeliverScript.scorePlay;
            }
        }
        //Debug.Log("여기오냐?10");
        //팬텀으로 출격시 스페셜 출격미션을 완수한 상태이면 스페셜 출격한 횟수를 더함.
        if (ValueDeliverScript.isSelectSpecial && ValueDeliverScript.flightNumber == 2)
        {
            flight002SpecialAttack++;
        }
        //Debug.Log("여기오냐?11");
        //팬텀으로 출격시 웜홀 레벨이 6이상을 넘겼는지를 기록.
        if (ValueDeliverScript.flightNumber == 2)
        {
            if (GameObject.Find("GameManager").GetComponent<PortalControlScript>().portalLevel >= 6)
            {
                flight002WormLevel5 = 1;
            }
        }
        //Debug.Log("여기오냐?12");
        ValueDeliverScript.bombRechargeDecrease = 0f; //핵폭탄 사용시간 감소를 정하는 값을 초기화.
        ValueDeliverScript.plasmaWaveCoolTime = 0f;

        //Debug.Log("여기오냐?13");


        ValueDeliverScript.userExp = userExp;
        ValueDeliverScript.coinRest = coinRest;
        ValueDeliverScript.dartCount = dartCount;
        ValueDeliverScript.dustCount = dustCount;
        ValueDeliverScript.spinballCount = spinballCount;
        ValueDeliverScript.shieldCount = shieldCount;

        ValueDeliverScript.flight000BombUseNumber = flight000BombUseNumber;
        ValueDeliverScript.flight001EnemyKill = flight001EnemyKill;
        ValueDeliverScript.flight001GetCoin = flight001GetCoin;
        ValueDeliverScript.flight001UseSkill = flight001UseSkill;
        ValueDeliverScript.flight001GetPowerItem = flight001GetPowerItem;
        ValueDeliverScript.flight002KillSpinball = flight002KillSpinball;
        ValueDeliverScript.flight002CompleteInstanceMission = flight002CompleteInstanceMission;
        ValueDeliverScript.flight002RescueFriend = flight002RescueFriend;
        ValueDeliverScript.flight000ScoreHigh = flight000ScoreHigh;
        ValueDeliverScript.flight002SpecialAttack = flight002SpecialAttack;
        ValueDeliverScript.flight002WormLevel5 = flight002WormLevel5;

        scoreCoinCount.HighScore();	//최종점수를 하이스코어랑 비교하여 높은점수를 보여주도록 처리하는 함수.
        ValueDeliverScript.SaveGameData(NextF);
    }

    void NextF()
    {
        Application.LoadLevel("Hangar");
    }


    void AddSkinExp(float multiValue = 0)
    {
        if (ValueDeliverScript.skinNumber == 0) return;

        int addExp = Mathf.RoundToInt(ValueDeliverScript.skinExp * multiValue);
        switch (ValueDeliverScript.flightNumber)
        {
            case 0: switch (ValueDeliverScript.skinNumber)
                {
                    case 1:
                        ValueDeliverScript.FlightExp000Skin001 += addExp;
                        if (ValueDeliverScript.FlightExp000Skin001 > 100000000) 
                            ValueDeliverScript.FlightExp000Skin001 = 100000000;
                        break;
                    case 2:
                        ValueDeliverScript.FlightExp000Skin002 += addExp;
                        if (ValueDeliverScript.FlightExp000Skin002 > 100000000) 
                            ValueDeliverScript.FlightExp000Skin002 = 100000000;
                        break;
                    case 3:
                        ValueDeliverScript.FlightExp000Skin003 += addExp;
                        if (ValueDeliverScript.FlightExp000Skin003 > 100000000)
                            ValueDeliverScript.FlightExp000Skin003 = 100000000;
                        break;
                    case 4:
                        ValueDeliverScript.FlightExp000Skin004 += addExp;
                        if (ValueDeliverScript.FlightExp000Skin004 > 100000000) 
                            ValueDeliverScript.FlightExp000Skin004 = 100000000;
                        break;
                    case 5:
                        ValueDeliverScript.FlightExp000Skin005 += addExp;
                        if (ValueDeliverScript.FlightExp000Skin005 > 100000000)
                            ValueDeliverScript.FlightExp000Skin005 = 100000000;
                        break;
                } break;
            case 1: switch (ValueDeliverScript.skinNumber)
                {
                    case 1:
                        ValueDeliverScript.FlightExp001Skin001 += addExp;
                        if (ValueDeliverScript.FlightExp001Skin001 > 100000000) 
                            ValueDeliverScript.FlightExp001Skin001 = 100000000;
                        break;
                    case 2:
                        ValueDeliverScript.FlightExp001Skin002 += addExp;
                        if (ValueDeliverScript.FlightExp001Skin002 > 100000000) 
                            ValueDeliverScript.FlightExp001Skin002 = 100000000;
                        break;
                    case 3:
                        ValueDeliverScript.FlightExp001Skin003 += addExp;
                        if (ValueDeliverScript.FlightExp001Skin003 > 100000000)
                            ValueDeliverScript.FlightExp001Skin003 = 100000000;
                        break;
                    case 4:
                        ValueDeliverScript.FlightExp001Skin004 += addExp;
                        if (ValueDeliverScript.FlightExp001Skin004 > 100000000)
                            ValueDeliverScript.FlightExp001Skin004 = 100000000;
                        break;
                    case 5:
                        ValueDeliverScript.FlightExp001Skin005 += addExp;
                        if (ValueDeliverScript.FlightExp001Skin005 > 100000000) 
                            ValueDeliverScript.FlightExp001Skin005 = 100000000;
                        break;
                } break;
            case 2: switch (ValueDeliverScript.skinNumber)
                {
                    case 1:
                        ValueDeliverScript.FlightExp002Skin001 += addExp;
                        if (ValueDeliverScript.FlightExp002Skin001 > 100000000) 
                            ValueDeliverScript.FlightExp002Skin001 = 100000000;
                        break;
                    case 2:
                        ValueDeliverScript.FlightExp002Skin002 += addExp;
                        if (ValueDeliverScript.FlightExp002Skin002 > 100000000) 
                            ValueDeliverScript.FlightExp002Skin002 = 100000000;
                        break;
                    case 3:
                        ValueDeliverScript.FlightExp002Skin003 += addExp;
                        if (ValueDeliverScript.FlightExp002Skin003 > 100000000)
                            ValueDeliverScript.FlightExp002Skin003 = 100000000;
                        break;
                    case 4:
                        ValueDeliverScript.FlightExp002Skin004 += addExp;
                        if (ValueDeliverScript.FlightExp002Skin004 > 100000000) 
                            ValueDeliverScript.FlightExp002Skin004 = 100000000;
                        break;
                    case 5:
                        ValueDeliverScript.FlightExp002Skin005 += addExp;
                        if (ValueDeliverScript.FlightExp002Skin005 > 100000000)
                            ValueDeliverScript.FlightExp002Skin005 = 100000000;
                        break;
                } break;
        }
    }

}

