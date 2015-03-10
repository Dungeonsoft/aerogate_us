using UnityEngine;
using System.Collections;

public class FlightSelectBtnScript : MonoBehaviour
{

    public Transform flights;
    public Transform flightsMove;
    public Transform EquipWindows;
    Transform EquipItem;
    Vector3 flightNextPosition;
    Vector3 equipNextPosition;
    float LerpValue = 1;
    public GameObject GameTip;

    bool startBtnCick = false;

    public GameObject pageMoveRight;
    public GameObject pageMoveLeft;

    public GameObject equipPageMoveRight;
    public GameObject equipPageMoveLeft;


    string flightSkinName;

    public GameObject duraBuyAlarmWindow;

    bool reinforFirstClick = false;

    public FlightUpointSetScript flightUpointSetScript;

    public GameObject noTouchPanel;

    void Start()
    {
        EquipItem = EquipWindows.FindChild("EquipReinforceTab").FindChild("Item");
        flightNextPosition = new Vector3(0, 0, 0);
        equipNextPosition = new Vector3(0, 0, 0);

        GameTip.SetActive(false);
        //ValueDeliverScript.SaveGameData();

        if (ValueDeliverScript.flightNumber >= 2)
        {
            pageMoveLeft.SetActive(true);
            pageMoveRight.SetActive(false);

        }
        else if (ValueDeliverScript.flightNumber <= 0)
        {
            pageMoveLeft.SetActive(false);
            pageMoveRight.SetActive(true);
        }

        //StartCoroutine(FNtest());
    }


    IEnumerator FNtest()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Debug.Log("비행기 번호 ::: " + ValueDeliverScript.flightNumber);
        }
    }


    void Update()
    {
        ///////////////////////////////////

    }

    public void OffLeftBtn()   //왼쪽버튼 끄기.
    {
        pageMoveLeft.SetActive(false);
        pageMoveRight.SetActive(true);
    }

    public void OffRightBtn()  //오른쪽 버튼 끄기.
    {
        pageMoveLeft.SetActive(true);
        pageMoveRight.SetActive(false);
    }

    public void OnBtn()    //양쪽 버튼 모두 켜기.
    {
        pageMoveLeft.SetActive(true);
        pageMoveRight.SetActive(true);
    }

    public void EquipOffLeftBtn()   //왼쪽버튼 끄기.
    {
        equipPageMoveLeft.SetActive(false);
        equipPageMoveRight.SetActive(true);
    }

    public void EquipOffRightBtn()  //오른쪽 버튼 끄기.
    {
        equipPageMoveLeft.SetActive(true);
        equipPageMoveRight.SetActive(false);
    }


    public void EquipOffBtn()    //양쪽 버튼 모두 끄기.
    {
        equipPageMoveLeft.SetActive(false);
        equipPageMoveRight.SetActive(false);
    }


    IEnumerator FlightTabMove()
    {
        noTouchPanel.SetActive(true);
        Transform flightLockMove = GameObject.Find("FlightLock/FlightLockMove").transform;
        pageMoveLeft.GetComponent<Collider>().enabled = false;
        pageMoveRight.GetComponent<Collider>().enabled = false;

        Vector3 firstPosition = flightsMove.localPosition;
        while (LerpValue <= 1)
        {
            flightsMove.localPosition = Vector3.Lerp(firstPosition, flightNextPosition, LerpValue);
            flightLockMove.localPosition = flightsMove.localPosition;
            yield return null;
            LerpValue += Time.deltaTime * 2;
        }
        flightLockMove.localPosition = flightsMove.localPosition = flightNextPosition;

        yield return new WaitForSeconds(0.5f);

        pageMoveLeft.GetComponent<Collider>().enabled = true;
        pageMoveRight.GetComponent<Collider>().enabled = true;
        noTouchPanel.SetActive(false);

        int flightLockOff = 0;

        switch (ValueDeliverScript.flightWindowPosition)
        {
            case 0: flightLockOff = ValueDeliverScript.FlightLockOff000; break;
            case 1: flightLockOff = ValueDeliverScript.FlightLockOff001; break;
            case 2: flightLockOff = ValueDeliverScript.FlightLockOff002; break;
        }
        if (flightLockOff == 2) flights.GetComponent<UpgradeAlarmShow>().upParentShow();

    }

    void FlightPressLeft()  //디폴드 상태인 비행기 선택창이 활성화 ~
    {
        flights.GetComponent<UpgradeAlarmShow>().upParentHide();
        if (ValueDeliverScript.flightWindowPosition > 0)
        {
            ValueDeliverScript.flightWindowPosition--;  //현재 어느 비행기 창을 보고 있는지 표시.


            if (ValueDeliverScript.flightWindowPosition == 0)
            {
                GameObject.Find("MoveTF").GetComponent<UIPanel>().alpha = 1f;
            }
            //Debug.Log("ValueDeliverScript.flightWindowPosition is" + ValueDeliverScript.flightWindowPosition);
            if (ValueDeliverScript.flightWindowPosition != 0)
            {
                int FlightLockOff = 0;
                switch (ValueDeliverScript.flightWindowPosition)
                {
                    case 0: FlightLockOff = ValueDeliverScript.FlightLockOff000; break;
                    case 1: FlightLockOff = ValueDeliverScript.FlightLockOff001; break;
                    case 2: FlightLockOff = ValueDeliverScript.FlightLockOff002; break;
                }
                if (FlightLockOff == 2)
                {
                    ValueDeliverScript.flightNumber = ValueDeliverScript.flightWindowPosition;   //비행기 락이 풀려있으면 비행기가 현재 선택되어있다고(출격가능) 표시.
                    if (ValueDeliverScript.flightNumber != 0)
                    {
                        GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet" + ValueDeliverScript.flightNumber.ToString("00")).gameObject.SetActive(false);
                        //GameObject.Find("FlightTag" + ValueDeliverScript.flightNumber.ToString("00")).transform.FindChild("_Tag").GetComponent<UIPanel>().alpha = 1f;
                        GameObject.Find("MoveTF").GetComponent<UIPanel>().alpha = 1f;
                    }
                }
                else
                {
                    GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet" + ValueDeliverScript.flightWindowPosition.ToString("00")).gameObject.SetActive(true);
                    GameObject.Find("MoveTF").GetComponent<UIPanel>().alpha = 0.5f;

                }
            }
            else
            {
                ValueDeliverScript.flightNumber = ValueDeliverScript.flightWindowPosition;
            }

            flightNextPosition = flightsMove.localPosition + new Vector3(1000, 0, 0);
            LerpValue = 0;
        }
        StartCoroutine(FlightTabMove());

        if (ValueDeliverScript.flightWindowPosition <= 0)
        {
            OffLeftBtn();
        }
        else
        {
            OnBtn();
        }

        flightUpointSetScript.RedrawStatePoint();

        switch(ValueDeliverScript.flightNumber)
        {
            case 0: ValueDeliverScript.skinNumber = ValueDeliverScript.flight000Skin; break;
            case 1: ValueDeliverScript.skinNumber = ValueDeliverScript.flight001Skin; break;
            case 2: ValueDeliverScript.skinNumber = ValueDeliverScript.flight002Skin; break;
        }
        //ValueDeliverScript.SaveGameData();
    }

    void FlightPressRight() //디폴드 상태인 비행기 선택창이 활성화 ~
    {

        flights.GetComponent<UpgradeAlarmShow>().upParentHide();

        if (ValueDeliverScript.flightWindowPosition < 2)
        {
            ValueDeliverScript.flightWindowPosition++;  //현재 어느 비행기 창을 보고 있는지 표시.
           

            if (ValueDeliverScript.flightWindowPosition == 0)
            {
                GameObject.Find("MoveTF").GetComponent<UIPanel>().alpha = 1f;
            }

            int FlightLockOff = 0;

            Debug.Log("ValueDeliverScript.flightWindowPosition ::: " + ValueDeliverScript.flightWindowPosition);

            switch (ValueDeliverScript.flightWindowPosition)
            {
                case 0: FlightLockOff = ValueDeliverScript.FlightLockOff000; break;
                case 1: FlightLockOff = ValueDeliverScript.FlightLockOff001; break;
                case 2: FlightLockOff = ValueDeliverScript.FlightLockOff002; break;
            }
            Debug.Log("FlightLockOff ::: " + FlightLockOff);
            if (FlightLockOff == 2)
            {
                //비행기 락이 풀려있으면 비행기가 현재 선택되어있다고(출격가능) 표시.
                ValueDeliverScript.flightNumber = ValueDeliverScript.flightWindowPosition;
                if (ValueDeliverScript.flightNumber != 0)
                {
                    GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet" + ValueDeliverScript.flightNumber.ToString("00")).gameObject.SetActive(false);
                    GameObject.Find("MoveTF").GetComponent<UIPanel>().alpha = 1f;
                }
            }
            else
            {
                GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet" + ValueDeliverScript.flightWindowPosition.ToString("00")).gameObject.SetActive(true);
                GameObject.Find("MoveTF").GetComponent<UIPanel>().alpha = 0.5f;
            }

            flightNextPosition = flightsMove.localPosition + new Vector3(-1000, 0, 0);
            LerpValue = 0;
        }

        StartCoroutine(FlightTabMove());

        if (ValueDeliverScript.flightWindowPosition >= 2)
        {
            OffRightBtn();
        }
        else
        {
            OnBtn();
        }


        //Debug.Log("ValueDeliverScript.flightWindowPosition  is " + ValueDeliverScript.flightWindowPosition);
        //Debug.Log("ValueDeliverScript.flightNumber   is " + ValueDeliverScript.flightNumber);

        flightUpointSetScript.RedrawStatePoint();


        switch (ValueDeliverScript.flightNumber)
        {
            case 0: ValueDeliverScript.skinNumber = ValueDeliverScript.flight000Skin; break;
            case 1: ValueDeliverScript.skinNumber = ValueDeliverScript.flight001Skin; break;
            case 2: ValueDeliverScript.skinNumber = ValueDeliverScript.flight002Skin; break;
        }
        //ValueDeliverScript.SaveGameData();
    }

    IEnumerator MoveEquipIcon()
    {
        equipPageMoveLeft.GetComponent<BoxCollider>().enabled = false;
        equipPageMoveRight.GetComponent<BoxCollider>().enabled = false;

        while (LerpValue <= 1f)
        {
            EquipItem.localPosition = Vector3.Lerp(EquipItem.localPosition, equipNextPosition, LerpValue);
            LerpValue += Time.deltaTime * 2;
            yield return null;
        }
        EquipItem.localPosition = Vector3.Lerp(EquipItem.localPosition, equipNextPosition, 1);

        equipPageMoveLeft.GetComponent<BoxCollider>().enabled = true;
        equipPageMoveRight.GetComponent<BoxCollider>().enabled = true;
    }

    void EquipPressLeft()
    {
        if (EquipWindows.FindChild("EquipBombTab").gameObject.activeSelf == true)
        {
            //Debug.Log("Enter Bomb!");
            EquipOffBtn();
        }
        else if (EquipWindows.FindChild("EquipReinforceTab").gameObject.activeSelf == true)
        {
            EquipItem = EquipWindows.FindChild("EquipReinforceTab").FindChild("Item");
            equipNextPosition = EquipItem.localPosition + new Vector3(1780, 0, 0);
            LerpValue = 0;
            EquipOffLeftBtn();
        }

        //else if (EquipWindows.FindChild("EquipAssistTab").gameObject.activeSelf == true)
        //{
        //    EquipItem = EquipWindows.FindChild("EquipAssistTab").FindChild("Item");
        //    equipNextPosition = EquipItem.localPosition + new Vector3(1780, 0, 0);
        //    LerpValue = 0;
        //    EquipOffLeftBtn();
        //}
        StartCoroutine(MoveEquipIcon());
    }

    void EquipPressRight()
    {
        if (EquipWindows.FindChild("EquipBombTab").gameObject.activeSelf == true)
        {
            EquipOffBtn();
        }
        else if (EquipWindows.FindChild("EquipReinforceTab").gameObject.activeSelf == true)
        {
            EquipItem = EquipWindows.FindChild("EquipReinforceTab").FindChild("Item");
            equipNextPosition = EquipItem.localPosition + new Vector3(-1780, 0, 0);
            LerpValue = 0;
            EquipOffRightBtn();
        }
        //else if (EquipWindows.FindChild("EquipAssistTab").gameObject.activeSelf == true)
        //{
        //    EquipItem = EquipWindows.FindChild("EquipAssistTab").FindChild("Item");
        //    equipNextPosition = EquipItem.localPosition + new Vector3(-1780, 0, 0);
        //    LerpValue = 0;
        //    EquipOffRightBtn();
        //}
        StartCoroutine(MoveEquipIcon());
    }


    public GameObject noBombWindow;
    public GameObject halfBLKPanel;
    bool isStart = false;
    CharacterMsgSndConScript characterMsgSndCon;

    void GotoNoBombWindowV()
    {
        StartCoroutine(GotoNoBombWindow());
    }

    IEnumerator GotoNoBombWindow()
    {
        characterMsgSndCon = GameObject.Find("CharacterMsgSndCon").GetComponent<CharacterMsgSndConScript>();

        halfBLKPanel.SetActive(true);
        noBombWindow.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, noBombWindow.transform.localPosition.z + 10);
        yield return new WaitForSeconds(0.5f);
        int activeOper = ValueDeliverScript.activeOper;
        characterMsgSndCon.SortieNoBomb(activeOper);
    }

    void GameStartByForce()
    {
        GetComponent<HangarPopupController>().CloseWindow();
        //halfBLKPanel.SetActive(false);
        //noBombWindow.SetActive(false);
        isStart = true;
        GameStart();
    }

    public void GameStart()
    {
        //아래 주석처리된 내용들은 원래 게임이 정상적으로 실행이 되려면 꼭 필요한 것들//
        //현재는 스페셜 출격 테스트를 위해서 강제로 주석처리 한 것//
        if (ValueDeliverScript.isSpecialAttackComplete == 0)
        {
            ValueDeliverScript.isSelectSpecial = false;
            GameStart2();
        }
        else
        {
            GameObject SpecialSelectWin = GetComponent<HangarManager>().SpecialSelectWin;
            GetComponent<HangarPopupController>().AddPopWin(SpecialSelectWin, 0);
        }

    }

    int gasUsed = 1;
    public void GameStartInNormal()
    {
        gasUsed = 1;
        ValueDeliverScript.isSelectSpecial = false;
        GetComponent<HangarPopupController>().CloseWindow(GameStart2);
    }

    public void GameStartInSpecial()
    {
        gasUsed = 2;
        ValueDeliverScript.isSelectSpecial = true;
        GetComponent<HangarPopupController>().CloseWindow(GameStart2);
    }

    void GameStartCancel()
    {
        GetComponent<HangarPopupController>().CloseWindow();
    }

    void GameStart2()    //AttackBtn/GameStart 오브젝트(버튼)을 누르면 이함수가 실행되도록 UIButtonMessage를 통하여 연결되어있음.
    {
        int activeBomb = ValueDeliverScript.activeBomb;

        int isBomb = activeBomb;
        if (isBomb == 0 && isStart == false && ValueDeliverScript.isTutComplete != 0)
        {
            GetComponent<HangarPopupController>().AddPopWin(noBombWindow, 0, GotoNoBombWindowV);
            //StartCoroutine(GotoNoBombWindow());
            return;
        }
        isStart = false;

        int skinDura = 0;
        //"FlightDura" + ValueDeliverScript.flightNumber.ToString("D3") + "Skin" + ValueDeliverScript.skinNumber.ToString("D3");

        switch (ValueDeliverScript.flightNumber)
        {
            case 0: switch (ValueDeliverScript.skinNumber)
                {
                    case 1: skinDura = ValueDeliverScript.FlightDura000Skin001; break;
                    case 2: skinDura = ValueDeliverScript.FlightDura000Skin002; break;
                    case 3: skinDura = ValueDeliverScript.FlightDura000Skin003; break;
                    case 4: skinDura = ValueDeliverScript.FlightDura000Skin004; break;
                    case 5: skinDura = ValueDeliverScript.FlightDura000Skin005; break;
                } break;
            case 1: switch (ValueDeliverScript.skinNumber)
                {
                    case 1: skinDura = ValueDeliverScript.FlightDura001Skin001; break;
                    case 2: skinDura = ValueDeliverScript.FlightDura001Skin002; break;
                    case 3: skinDura = ValueDeliverScript.FlightDura001Skin003; break;
                    case 4: skinDura = ValueDeliverScript.FlightDura001Skin004; break;
                    case 5: skinDura = ValueDeliverScript.FlightDura001Skin005; break;
                } break;
            case 2: switch (ValueDeliverScript.skinNumber)
                {
                    case 1: skinDura = ValueDeliverScript.FlightDura002Skin001; break;
                    case 2: skinDura = ValueDeliverScript.FlightDura002Skin002; break;
                    case 3: skinDura = ValueDeliverScript.FlightDura002Skin003; break;
                    case 4: skinDura = ValueDeliverScript.FlightDura002Skin004; break;
                    case 5: skinDura = ValueDeliverScript.FlightDura002Skin005; break;
                } break;
        }
        if (ValueDeliverScript.skinNumber != 0)
        {
            if (skinDura <= 0)
            {
                //스킨 내구도가 0이하로 떨어지면 이 부분을 실행!
                //스킨 내구도 복구 유도 창을 띄운다.
                GetComponent<HangarPopupController>().AddPopWin(duraBuyAlarmWindow, 0);
                return;
            }
        }

        if (startBtnCick || ValueDeliverScript.flightNumber == 3 || ValueDeliverScript.flightNumber == 4)
            return;


        int gasRest = ValueDeliverScript.gasRest;

        if (gasRest < gasUsed && ValueDeliverScript.isTutComplete != 0)
        {
            gasShortageWindow = GameObject.Find("GameManager").GetComponent<HangarManager>().gasShortageWindow;
            //연료가 바닥 났으므로 구매유도 팝업을 띄운다.
            GetComponent<HangarPopupController>().AddPopWin(gasShortageWindow, 0, GasShortageWindowAdsAble);
        }
        else
        {
            GameStart3();
        }
    }

    GameObject gasShortageWindow;

    void GasShortageWindowAdsAble()
    {
        bool isReady = UnityEngine.Advertisements.Advertisement.isReady();

        if (isReady == false)
        {
            gasShortageWindow.transform.FindChild("FreeFuelBtn").gameObject.SetActive(false);
            gasShortageWindow.transform.FindChild("TapBar").localPosition = new Vector3(0, -80, 0);
            gasShortageWindow.transform.FindChild("warning2").localPosition = new Vector3(0, -40, 0);
        }
        else
        {
            gasShortageWindow.transform.FindChild("FreeFuelBtn").gameObject.SetActive(true);
            gasShortageWindow.transform.FindChild("TapBar").localPosition = new Vector3(0, 5, 0);
            gasShortageWindow.transform.FindChild("warning2").localPosition = new Vector3(0, 45, 0);
        }
    }
    
    public void GameStart3()
    {
        DefaultVaue();
        GameTip.SetActive(true);    //게임팁 보임.
        startBtnCick = true;	//버튼을 한번만 클릭하게 만들어준다.
        StartCoroutine(LoadInGame01());
    }

    void AdsFailed()
    {
        gasShortageWindow = GameObject.Find("GameManager").GetComponent<HangarManager>().gasShortageWindow;

        gasShortageWindow.transform.FindChild("FreeFuelBtn").gameObject.SetActive(false);
        gasShortageWindow.transform.FindChild("TapBar").localPosition = new Vector3(0, -80, 0);
        gasShortageWindow.transform.FindChild("warning2").localPosition = new Vector3(0, -40, 0);
    }

    public void GetFreeFuel()
    {
        GetComponent<UnityAdsManager>().AbleAds(GameStart3, AdsFailed);
    }


    IEnumerator LoadInGame01()
    {
        int gasRest = ValueDeliverScript.gasRest;

        //연료차감부분.   //새로운방식.
        if (ValueDeliverScript.isTutComplete != 0)
        {
            if (gasRest >= gasUsed) gasRest -= gasUsed;
            ValueDeliverScript.gasRest = gasRest;
        }
        //연료차감부분.

        yield return null;

        //행거에서 출격 직전에 한번 저장//
        nextF =  new MyDelegateNS.NextFunc(LoadInGame02);
        ValueDeliverScript.SaveGameData(LoadInGame02);
        //StartCoroutine(LoadInGame02());
    }

    MyDelegateNS.NextFunc nextF;

    void LoadInGame02()
    {
        Application.LoadLevel("InGame01");
    }

    void DefaultVaue()	//게임시작시 들어가는 값.인게임에 들어가기전에 이부분이 샐행되어 초기화 되어야 될 값들을 초기화 시켜줌.
    {
        int flight000Bullet = ValueDeliverScript.flight000Bullet;
        int flight001Bullet = ValueDeliverScript.flight001Bullet;
        int flight002Bullet = ValueDeliverScript.flight002Bullet;
        int flight000Skill = ValueDeliverScript.flight000Skill;
        int flight001Skill = ValueDeliverScript.flight001Skill;
        int flight002Skill = ValueDeliverScript.flight002Skill;


        //이부분에서 각 비행기별 총알 레벨을 각 기체에 기록하고 현재 어떤 기체를 선택하였는가에 따라 실제 게임에서 보이는 총알을 규정해준다.
        ArrayList bulletLevelByFlight = new ArrayList();
        bulletLevelByFlight.Add(flight000Bullet);
        bulletLevelByFlight.Add(flight001Bullet);
        bulletLevelByFlight.Add(flight002Bullet);

        ArrayList skillLevelByFlight = new ArrayList();
        skillLevelByFlight.Add(flight000Skill);
        skillLevelByFlight.Add(flight001Skill);
        skillLevelByFlight.Add(flight002Skill);

        if (ValueDeliverScript.isTutComplete == 0)
        {
            ValueDeliverScript.flightNumber = 0;
            ValueDeliverScript.skinNumber = 0;

            ValueDeliverScript.bulletLevel = 5;
            ValueDeliverScript.skillLevel = 2;
        }
        else
        {
            ValueDeliverScript.bulletLevel = (int)bulletLevelByFlight[ValueDeliverScript.flightNumber];
            ValueDeliverScript.skillLevel = (int)skillLevelByFlight[ValueDeliverScript.flightNumber];
        }

        Time.timeScale = 1;

        ValueDeliverScript.scorePlay = 0;
        ValueDeliverScript.scoreResult = 0;

        ValueDeliverScript.coinPlay = 0;

        ValueDeliverScript.dartApearPer = 2500; //2500
        ValueDeliverScript.dustApearPer = 5000; //5000
        ValueDeliverScript.spinballApearPer = 7500; //7500

        ValueDeliverScript.flightAttackPower = 0f;
        ValueDeliverScript.flightAttackSpeed = 0f;
        ValueDeliverScript.targetUfoType = 0;
        ValueDeliverScript.isCriticalExel = false;

        ValueDeliverScript.itemReinforce08Effect = 0f;

        int fNum = ValueDeliverScript.flightNumber;
        int skinNumber = ValueDeliverScript.skinNumber;
       
        switch (fNum)
        {
            case 0: switch (skinNumber)
                {
                    case 1: ValueDeliverScript.FlightDura000Skin001--; break;
                    case 2: ValueDeliverScript.FlightDura000Skin002--; break;
                    case 3: ValueDeliverScript.FlightDura000Skin003--; break;
                    case 4: ValueDeliverScript.FlightDura000Skin004--; break;
                    case 5: ValueDeliverScript.FlightDura000Skin005--; break;
                } break;
            case 1: switch (skinNumber)
                {
                    case 1: ValueDeliverScript.FlightDura001Skin001--; break;
                    case 2: ValueDeliverScript.FlightDura001Skin002--; break;
                    case 3: ValueDeliverScript.FlightDura001Skin003--; break;
                    case 4: ValueDeliverScript.FlightDura001Skin004--; break;
                    case 5: ValueDeliverScript.FlightDura001Skin005--; break;
                } break;
            case 2: switch (skinNumber)
                {
                    case 1: ValueDeliverScript.FlightDura002Skin001--; break;
                    case 2: ValueDeliverScript.FlightDura002Skin002--; break;
                    case 3: ValueDeliverScript.FlightDura002Skin003--; break;
                    case 4: ValueDeliverScript.FlightDura002Skin004--; break;
                    case 5: ValueDeliverScript.FlightDura002Skin005--; break;
                } break;
        }


        //스킨관련 변수들 초기화. 값을 대입하는것은 인게임들어가서 처리됨.
        ValueDeliverScript.addFlightExp = 0;

        ValueDeliverScript.addAttackAbility = 0;

        ValueDeliverScript.increaseBombAttackPercent = 0f;
        ValueDeliverScript.increaseBombAttackPercentInGame = 0f;
        ValueDeliverScript.increaseBombAttackTime = 0;
        ValueDeliverScript.isIncreaseBombAttackPercent = false;

        ValueDeliverScript.increaseScorePercent = 0f;
        ValueDeliverScript.isIncreaseScorePercent = false;
        ValueDeliverScript.shieldDestroyAddScorePercent = 0f;

        ValueDeliverScript.powerUpDropChance = 0;	// 1/10000 확률료 표시할것.
        ValueDeliverScript.powerUpAttackIncreaseTime = 0f;
        ValueDeliverScript.AttackPowerPercent = 0f;
        ValueDeliverScript.AttackPowerPercentTemp = 0f;

        ValueDeliverScript.isdamageAddChance = false;
        ValueDeliverScript.damageAddChance = 0;	// 1/10000 확률료 표시할것.
        ValueDeliverScript.damageAddPercent = 0f;

        ValueDeliverScript.coinAddChance = 0; // 1/10000 확률료 표시할것.
        ValueDeliverScript.coinAddNumber = 1;

        ValueDeliverScript.rechargeEnergy = 0;

        ValueDeliverScript.isBombRechargeDecrease = false;
        ValueDeliverScript.isBombRechargeDecreaseTemp = false;
        ValueDeliverScript.isBombToSkillGageIncrease = false;
        ValueDeliverScript.bombRechargeDecrease = 0f;	//시간(초).
        ValueDeliverScript.addSkillGagePercent = 0;	// 1/10000 확률료 표시할것.

        ValueDeliverScript.scoreIncreasePercent = 0f;
        ValueDeliverScript.comancheDeveilBreathAddSpeed = 0f;

        ValueDeliverScript.spinballDamagePercent = 0f;

        ValueDeliverScript.specialBombRechargeDecrease = 0f;	//시간(초).

        ValueDeliverScript.wingboxAddtime = 0f;

        ValueDeliverScript.friendFlightAddTime = 0f;

        ValueDeliverScript.applyPortalLevel = 0;
        ValueDeliverScript.bombTimeDecrease = 0f;
        ValueDeliverScript.nowPortalLevel = 1;

        //포커로 출격시 출격횟수 기록//
        if (ValueDeliverScript.flightNumber == 0 && ValueDeliverScript.isTutComplete !=0)
        {
            int flight000SortieNumber = ValueDeliverScript.flight000SortieNumber;

            flight000SortieNumber++;
            ValueDeliverScript.flight000SortieNumber = flight000SortieNumber;
        }

        //ValueDeliverScript.gameEndResult = false;

        ValueDeliverScript.isCharacterSound = false;
        ValueDeliverScript.skin00_04Effect = 0;
        ValueDeliverScript.itemMagnetEffect = 0f;
        ValueDeliverScript.skin02_03Effect = 1f;
        ValueDeliverScript.skin02_04Effect = 0f;
        ValueDeliverScript.skin02_05Effect1 = 0f;
        ValueDeliverScript.skin02_05Effect2 = 1f;
    }
}