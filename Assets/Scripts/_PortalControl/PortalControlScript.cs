using UnityEngine;
using System.Collections;

public class PortalControlScript : MonoBehaviour
{

    ActivateScript Activate;

    float portalRateTime;
    public float[] specialMinimumRateTime;
    public float[] portalMinimumRateTime;   // 포털과 포털이 나타나면서 시간이 점점 줄어드는데 그 줄어드는 가장 최소의 시간. 이시간 이후의 보다 더 빨리 포털이 나타나진 않는다.
    public float[] portalRateTimeInput;	// 기본 등장 속도 텀.워프후 첫 나타는 포털과 다음 포털간의 발생 시간 차이.
    public float portalRateTimeFirstInput = 1f;	// 2레벨부터 처음 등장 속도.
    //public int rateWeight = 4;	//rateWeight는 등장속도 가중치를 줌. 
    public float rateWeight = 0.03f;	//rateWeight는 등장속도 가중치를 줌. 

    //int portalTotalCount;
    public int[] portalLevelUpTime;

    public int[] portallevelUpScore;

    public GameObject levelChangeBombFirst;
    public GameObject levelChangeBomb;
    public GameObject levelChangeBombShadow;
    public GameObject lightSpeedPlan;

    public GameObject speedEffectTF;
    public GameObject speedEffect01;
    public GameObject speedEffect02;

    public GameObject[] bgObject;

    public GameObject mainCam;

    public int portalLevel = 1;
    int strongWormhole;

    public Color[] portalFogColor;

    GameObject flight;

    SoundUiControlScript soundUiControlScript;
    LevelChangePlanShowHide levelChangePlanShowHide;

    int detectorType;
    public float detectorTime = 10f;

    int portalUpLevel = 0;  //포탈 이동시 나오는 캐릭터대사를 불러오기위해 필요한 배열의 첨가 수.

    //포탈 SetStart()가 실행되고 나서 지나간 시간을 기록하기 위한 변수.
    float spendTime;

    public GameObject[] BGs;
    bool isShowBG = false;
    string usedBgNum = "";
    int countBgChange = 0;

    public GameObject CountObj;

    bool isPortalLevelUpScore = false;
    bool isPortalLevelUpTime = false;

    float remainTime;

    GameObject oneMoreWin;

    float rateTime;

    public GameObject PauseShield;

    //일반모드일때 포털이 계속 나올지 여부를 결정하는 불린 변수// 이값이 트루면 더이상 포털이 생성되지 않는다//
    bool isStopPortal = false;


    public void Awake()
    {
        ShowBG();
        oneMoreWin = GameObject.Find("Anchor").transform.FindChild("OneMoreWin").gameObject;

        PauseShield.SetActive(true);

    }

    void ShowBG()
    {

        if (countBgChange > 3)
        {
            countBgChange = 0;
            usedBgNum = "";
        }

        int rndBG = 0;
        foreach (var BG in BGs)
        {
            BG.SetActive(false);
        }

        while (true)
        {
            rndBG = Random.Range(0, BGs.Length);

            if (!usedBgNum.Contains(rndBG.ToString()))
            {
                usedBgNum += rndBG.ToString();
                break;
            }
        }
        BGs[rndBG].SetActive(true);
        countBgChange++;
    }

    public void SetStart()
    {
        ValueDeliverScript.portalUpLevel = portalUpLevel;
        soundUiControlScript = GameObject.Find("GameManager").GetComponent<SoundUiControlScript>();

        flight = GameObject.Find("Flight");
        Activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();
        portalRateTime = portalRateTimeInput[portalLevel - 1];


        //RenderSettings.fogColor = portalFogColor[0];
        StartCoroutine(ChangeFogColor());

        levelChangePlanShowHide = lightSpeedPlan.GetComponent<LevelChangePlanShowHide>();

        detectorType = ValueDeliverScript.detectorType;

        if (detectorType >= 0)
        {
            StartCoroutine(detectorPortal());
        }

        //isSetStart = true;

        StartCoroutine(CountStart());
        GameObject.Find("FuelSlider").GetComponent<FuelSliderScript>().FuelGageSettingVoid();
    }

    void EveryPlayStart()
    {
        Debug.Log("레코딩을 시작한다");
        Everyplay.StartRecording();
        StartCoroutine(SshotEveryPlay());
    }

    IEnumerator SshotEveryPlay()
    {
        Debug.Log("첫번째 스샷을 찍는다.");
        Everyplay.TakeThumbnail();
        yield return new WaitForSeconds(30f);
        Debug.Log("두번째 스샷을 찍는다.");
        Everyplay.TakeThumbnail();
    }

    IEnumerator CountStart()
    {
        ///////////////////////////////////////
        //3,2,1,Start 표현할 오브젝트 애니메이션 호출./////////
        //에브리 플레이 동시 호출///////////////
        ///////////////////////////////////////

        //에브리 플레이 실행부//////////////////
        EveryPlayStart();
        //에브리 플레이 실행부//////////////////

        //카운트 애니메이션 시작 3.2.1!!!!
        CountObj.animation.Play("CountAnim01");

        yield return new WaitForSeconds(4f);

        //친구 아이콘(화면우측)이 나타나게 한다.(중국버전으로 만든 스크립트)
        GetComponent<FriendRescueScript>().AnimIn();

        GameObject.Find("FuelSlider").GetComponent<FuelSliderScript>().GageReduceVoid();


        ShowStageNumber();

        ////스페셜 출격 테스트 임시 변수 변경//
        //ValueDeliverScript.isSelectSpecial = true;
        ////스페셜 출격 테스트 임시 변수 변경//
        if (ValueDeliverScript.isSelectSpecial == true)
        {
            StartCoroutine(SpecialPortalControl(0));   // 스페셜 포털 시작//
        }
        else
        {
            StartCoroutine(PortalControl(portalUpLevel));   // 첫포탈의 시작//
        }
        //캐논 발사 준비//
        CannonPreActivate(portalUpLevel);

        yield return new WaitForSeconds(1f);
        PauseShield.SetActive(false);
    }

    //여기서 방해물 생성 시작 신호를 보냄//
    void CannonPreActivate(int portalUpLevel)
    {
        //Debug.Log("데브리 시작01");
        GetComponent<OpstacleControlScript>().Activate(portalUpLevel); 
    }


    //여기서 스테이지를 알려주는 UI와 디스트로이어 발생을 준비시키는 메서드를 실행시킨다//
    void ShowStageNumber()
    {
        GameObject.Find("S" + portalLevel.ToString("00")).GetComponent<Animator>().SetBool("Run", true);
        //GameObject.Find("DestroyBirthPoint").GetComponent<DestroyCreaterScript>().Activate(portalLevel-1);
    }
    //아이템 효과에 의해 특정 UFO가 더 많이 출현하도록 해준다.
    IEnumerator detectorPortal()
    {
        //Debug.Log("Portal Start AAA !!!");
        //Debug.Log("Detector Time is " + detectorTime + " :::");
        System.DateTime d1 = System.DateTime.Now;

        yield return new WaitForSeconds(detectorTime + 3);  //최초시작시부터 적용되는 기능이기때문에 시작시 공백시간만큼 빈 시간을 입력해주어야한다. 이만큼의 시간이 지나고 나서야 아이템의 기능이 적용되어 추가 포털이 생성된다.

        System.DateTime d2 = System.DateTime.Now;
        System.TimeSpan d3 = d2 - d1;
        int spendTimeD = (int)(d3.TotalSeconds);

        //Debug.Log("Spend Time is "+spendTimeD+" ::::");

        while (true)
        {
            Activate.PortalActivate(portalLevel + strongWormhole, detectorType);
            yield return new WaitForSeconds(detectorTime);
        }
    }

    public void ActiveBoost02(int AddWormHoleLevel)
    {
        strongWormhole = AddWormHoleLevel;
    }

    //스페셜 출격 상태일때 시작하는 포털컨트롤 메소드//
    IEnumerator SpecialPortalControl(int portalNum)
    {
        isPortalLevelUpTime = false;
        ValueDeliverScript.portalUpScore = 0;

        //Debug.Log("Into Portal Control Function1 !!");
        rateTime = portalRateTimeInput[portalNum];

        yield return new WaitForSeconds(1f);

        float t1 = 0;
        float t2 = 0;


        remainTime = portalLevelUpTime[portalNum];

        while (true)
        {
            if (flight.activeSelf == false || oneMoreWin.activeSelf == true)
            {
                yield return new WaitForSeconds(0.1f); continue;
            }

            t1 = Time.time; //A지점.
            //Debug.Log("Into Portal Control Function5 !!");

            soundUiControlScript.WormholeAppear();	//웜홀 등장 사운드.	
            //Debug.Log("portalNum :: " + portalNum + ":: strongWormhole :: " + strongWormhole);
            Activate.PortalActivate(portalNum + strongWormhole + 1);  //포털 생성.
            //Debug.Log("Into Portal Control Function6 !!");
            //다음 포털 생성시까지 기다리는 시간.
            yield return new WaitForSeconds(rateTime);
            //Debug.Log("Portal Wait Time :: " + rateTime);
            //포탈 등장 시간을 점점 줄여줌.
            rateTime -= rateWeight;
            if (rateTime < specialMinimumRateTime[portalNum])
                rateTime = specialMinimumRateTime[portalNum];
            //포탈 등장 시간을 점점 줄여줌.

            //스테이지 유지 시간 관련.
            if (remainTime <= 0)
            {
                ValueDeliverScript.portalUpScore = 0;
                portalNum++;
                portalLevel++;

                //스테이지가바뀌면서 포털유지시간 초기화//
                remainTime = portalLevelUpTime[portalNum];
                //포그색 변경//
                StartCoroutine(ChangeFogColor(false));
                //방해물 변경//
                CannonPreActivate(portalNum);
                continue;
            }
            //스테이지 유지 시간 관련.
            t2 = Time.time;     //B지점.

            remainTime -= t2 - t1;        //A지점에서 B지점까지 흐른시간을 계산해서 레벨이 존재하는 시간에서 차감시킨다.
        }

    }


    //일반 출격 상태일때 시작하는 포털컨트롤 메소드//
    IEnumerator PortalControl(int portalNum)
    {
        isStopPortal = false;
        isPortalLevelUpTime = false;
        ValueDeliverScript.portalUpScore = 0;

        //Debug.Log("Into Portal Control Function1 !!");
        rateTime = portalRateTimeInput[portalNum];


        yield return new WaitForSeconds(1f);
        float t1;
        float t2;


        remainTime = portalLevelUpTime[portalNum];

        while (isStopPortal == false)
        {
            if (flight.activeSelf == false || oneMoreWin.activeSelf == true)
            {
                yield return new WaitForSeconds(0.1f); continue;
            }

            t1 = Time.time; //A지점.
            //Debug.Log("Into Portal Control Function5 !!");

            soundUiControlScript.WormholeAppear();	//웜홀 등장 사운드.	
            Activate.PortalActivate(portalLevel + strongWormhole);  //포털 생성.
            //Debug.Log("Into Portal Control Function6 !!");
            //다음 포털 생성시까지 기다리는 시간.
            yield return new WaitForSeconds(rateTime);

            //포탈 등장 시간을 점점 줄여줌.
            rateTime -= rateWeight * (8 + portalNum);
            if (rateTime < portalMinimumRateTime[portalNum])
                rateTime = portalMinimumRateTime[portalNum];
            //포탈 등장 시간을 점점 줄여줌.

            //스테이지 유지 시간 관련.
            if (isPortalLevelUpScore == false && remainTime > 11 && ValueDeliverScript.portalUpScore > portallevelUpScore[portalNum])
            {
                Debug.Log("Portal Score Pull!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!111");
                isPortalLevelUpScore = true;
                isPortalLevelUpTime = true;
                remainTime = 10f;
                StartCoroutine(CountDown(5));
            }
            else if (isPortalLevelUpTime == false && remainTime < 6)
            {
                isPortalLevelUpTime = true;
                StartCoroutine(CountDown(0));
            }

            //스테이지 유지 시간 관련.
            t2 = Time.time;     //B지점.

            remainTime -= (t2 - t1);        //A지점에서 B지점까지 흐른시간을 계산해서 레벨이 존재하는 시간에서 차감시킨다.
        }
    }

    IEnumerator CountDown(int waitTime)
    {
        if (flight.activeSelf == true)
        {
            //레벨이 유지되는 총시간보다 5초 먼저부터 해서 카운트 다운이 시작된다.(실제론 4초)
            //float waitTime = portalLevelUpTime[portalNum]-4;    
            yield return new WaitForSeconds(waitTime);

            //여기서 더이상 방해물(옵스터클)이 나오지 않도록 불린값을 변경한다.//
            GetComponent<OpstacleControlScript>().IsShowChange();


            if (flight.activeSelf == true)
                GameObject.Find("GameManager").GetComponent<SoundUiControlScript>().CountSound();   //카운트다운 사운드 발동.
            yield return new WaitForSeconds(5);
            if (flight.activeSelf == true)
            {
                isStopPortal = true;    //일반모드일때 포털이 계속 나올지 여부를 결정하는 불린 변수// 이값이 트루면 더이상 포털이 생성되지 않는다//
                StartCoroutine(LevelChangeBombFunction());  //융단폭격 함수 호출.
            }
        }
    }

    public IEnumerator LevelChangeBombFunction()
    {
        //포털값을 -1을 주어서 포털이 생성되지 않게 한다.
        //GameObject.Find("DestroyBirthPoint").GetComponent<DestroyCreaterScript>().Activate(-1);


        if (flight.activeSelf == false) yield break;
        Instantiate(levelChangeBombShadow); //폭격기 그림자 지나가고.
        yield return new WaitForSeconds(0.5f);  //잠시 쉬었다가.
        //if (flight.activeSelf == false) yield break;
        Instantiate(levelChangeBombFirst);  //가짜융단폭격 지나간다.
        yield return new WaitForSeconds(1f);    //잠시 쉬었다가.
        //if (flight.activeSelf == false) yield break;
        Camera.main.GetComponent<CameraShakeScript>().NowTime(4f, false, false);  // 가짜 융단폭격후 카메라 쉐이크.
        //if (flight.activeSelf == false) yield break;
        Instantiate(levelChangeBomb);   //진짜폭격이 지나가면서 적UFO를 파괴한다.
        yield return new WaitForSeconds(2f);    //잠시쉬었다가.
        lightSpeedPlan.SetActive(true);     //빛줄기 오브젝트를 보이게 하고.
        levelChangePlanShowHide.Activate(); //빛줄기 오브젝트를 빠르게 움직여서 워프를 하는것 처럼 보이게 만든다.

        soundUiControlScript.PcAcceleration();  //비행기 가속하는 소리를 발생시킨다.
        mainCam.GetComponent<CamFovControl>().Activate();   //카메라가 워프현상으로 인한 왜곡을 일으킨다.


        //비행기 뒤에서 발생되는 가속효과 빛줄기를 보여준다.
        speedEffect01.SetActive(true);
        speedEffect02.SetActive(true);

        speedEffectTF.GetComponent<SpeedEffectTFScript>().Activate();
        speedEffect01.GetComponent<LevelChangePlanShowHide>().Activate();
        speedEffect02.GetComponent<LevelChangePlanShowHide>().Activate();
        //비행기 뒤에서 발생되는 가속효과 빛줄기를 보여준다.

        //배경이 움직이는 속도를 증가시킨다.
        for (int i = 0; i < bgObject.Length; i++)
        {
            if (bgObject[i] !=null && bgObject[i].activeSelf == true)
                bgObject[i].GetComponent<BgMove>().SpeedUp();
        }
        //배경이 움직이는 속도를 증가시킨다.

        yield return new WaitForSeconds(1f);    //잠시쉰다.

        Debug.Log("CharacterMessageShow :: Portal Up Level is ::" + portalUpLevel);

        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterSpeak(2 + portalUpLevel);
        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterMessageShow(9 + portalUpLevel);

        portalUpLevel++;
        portalLevel++;
        StartCoroutine(ChangeFogColor());
        yield return new WaitForSeconds(4f);
        ShowStageNumber();
        yield return new WaitForSeconds(1f);
        //일반 공격 첫포탈 시작이후 일반 출격 상태에서 접근할때 쓰이는 포털메소드 호출 부분//
        StartCoroutine(PortalControl(portalUpLevel));

        //캐논 발사 준비//
        CannonPreActivate(portalUpLevel);



    }   //포털 레벨이 바뀌면서 융단 폭격을 해주는 함수.

    IEnumerator ChangeFogColor(bool isChangeBG = true)    //포털이 바뀌면서 배경의 포그 컬러도 같이 바뀐다.
    {
        if (flight.activeSelf == false) yield break;

        for (float lerpTme = 0; lerpTme < 1; lerpTme += Time.deltaTime)
        {
            RenderSettings.fogColor = Color.Lerp(portalFogColor[portalLevel - 1], portalFogColor[portalLevel], lerpTme);
            yield return null;
        }
        RenderSettings.fogColor = portalFogColor[portalLevel];

        if (isChangeBG == true)
        {
            if (isShowBG == true)
            {
                ShowBG();
            }
        }
        isShowBG = true;
    }
}
