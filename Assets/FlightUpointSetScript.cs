using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlightUpointSetScript : MonoBehaviour {

    public UILabel[] flight00;
    public UILabel[] flight01;
    public UILabel[] flight02;

    public UIFilledSprite[] flight00BaseGage;
    public UIFilledSprite[] flight01BaseGage;
    public UIFilledSprite[] flight02BaseGage;

    public UIFilledSprite[] flight00AddGage;
    public UIFilledSprite[] flight01AddGage;
    public UIFilledSprite[] flight02AddGage;

    public UILabel[] flight00AddLabel;
    public UILabel[] flight01AddLabel;
    public UILabel[] flight02AddLabel;

    public GameObject[] statePercent;
    public GameObject[] upgradeState;

    public UILabel[] flight00PerLabel;
    public UILabel[] flight01PerLabel;
    public UILabel[] flight02PerLabel;

    public UILabel remainPointlabel;

    public GameObject resetPointWindow;
    public UILabel forResetPoint;
    public UILabel forResetCoin;

    public GameObject halfBLKPanel;

    public int flightCount = 3;

    public int[] coinForPointReset;

    public GameObject coinShortageWindow;

    int F00ResultPoint0;
    int F00ResultPoint1;
    int F00ResultPoint2;
    int F00ResultPoint3;

    int F01ResultPoint0;
    int F01ResultPoint1;
    int F01ResultPoint2;
    int F01ResultPoint3;

    int F02ResultPoint0;
    int F02ResultPoint1;
    int F02ResultPoint2;
    int F02ResultPoint3;

    public int remainPoint;

    public GameObject prepareReady;

    bool gameEndResult;

    void Awake()
    {
        ResultPointCal();   //가장먼저 실행되어야 될 함수.
        ResultPoint();
        BaseGageSet();
        AddGageSet();
        AddLabelSet();
        CalRemainPoint();
        //IsBtnAnimationFirst();
        RemainPointLabel();

        StatePerSet();
        //Debug.Log("::::::::::::::::::::::::::: SpecialMessage is " + prepareReady.transform.FindChild("OperMessage/SpecialMessage").gameObject.activeSelf);
    }

    void Start()
    {
        Debug.Log("여기서 비행기별 강화포인트 상태를 어떻게 보여줄지를 결정하는 메서드를 호출한다.");
        IsBtnAnimationFirst();
    }

    //각각의 강화되는 스탯을 보여줄 용도로 계산하는 부분. 실 적용은 다른 함수에서 실행.
    public void ResultPointCal()
    {
        F00ResultPoint0 = ValueDeliverScript.pointF00P01 + ValueDeliverScript.upgradePointF00P01;
        F00ResultPoint1 = ValueDeliverScript.pointF00P02 + ValueDeliverScript.upgradePointF00P02;
        F00ResultPoint2 = ValueDeliverScript.pointF00P03 + ValueDeliverScript.upgradePointF00P03;
        F00ResultPoint3 = ValueDeliverScript.pointF00P04 + ValueDeliverScript.upgradePointF00P04;

        F01ResultPoint0 = ValueDeliverScript.pointF01P01 + ValueDeliverScript.upgradePointF01P01;
        F01ResultPoint1 = ValueDeliverScript.pointF01P02 + ValueDeliverScript.upgradePointF01P02;
        F01ResultPoint2 = ValueDeliverScript.pointF01P03 + ValueDeliverScript.upgradePointF01P03;
        F01ResultPoint3 = ValueDeliverScript.pointF01P04 + ValueDeliverScript.upgradePointF01P04;

        F02ResultPoint0 = ValueDeliverScript.pointF02P01 + ValueDeliverScript.upgradePointF02P01;
        F02ResultPoint1 = ValueDeliverScript.pointF02P02 + ValueDeliverScript.upgradePointF02P02;
        F02ResultPoint2 = ValueDeliverScript.pointF02P03 + ValueDeliverScript.upgradePointF02P03;
        F02ResultPoint3 = ValueDeliverScript.pointF02P04 + ValueDeliverScript.upgradePointF02P04;
    }

    //ResultPointCal()함수에서 계산한 부분을 실제 적용하는 부분.
    public void ResultPoint()
    {
        flight00[0].text = F00ResultPoint0.ToString() + "/" + ValueDeliverScript.pointF00P01Max;
        flight00[1].text = F00ResultPoint1.ToString() + "/" + ValueDeliverScript.pointF00P02Max;
        flight00[2].text = F00ResultPoint2.ToString() + "/" + ValueDeliverScript.pointF00P03Max;
        flight00[3].text = F00ResultPoint3.ToString() + "/" + ValueDeliverScript.pointF00P04Max;

        flight01[0].text = F01ResultPoint0.ToString() + "/" + ValueDeliverScript.pointF01P01Max;
        flight01[1].text = F01ResultPoint1.ToString() + "/" + ValueDeliverScript.pointF01P02Max;
        flight01[2].text = F01ResultPoint2.ToString() + "/" + ValueDeliverScript.pointF01P03Max;
        flight01[3].text = F01ResultPoint3.ToString() + "/" + ValueDeliverScript.pointF01P04Max;

        flight02[0].text = F02ResultPoint0.ToString() + "/" + ValueDeliverScript.pointF02P01Max;
        flight02[1].text = F02ResultPoint1.ToString() + "/" + ValueDeliverScript.pointF02P02Max;
        flight02[2].text = F02ResultPoint2.ToString() + "/" + ValueDeliverScript.pointF02P03Max;
        flight02[3].text = F02ResultPoint3.ToString() + "/" + ValueDeliverScript.pointF02P04Max;
    }

    public void StatePerSet()
    {
        flight00PerLabel[0].text = Mathf.RoundToInt(F00ResultPoint0 * 100 / ValueDeliverScript.pointF00P01Max).ToString() + "%";
        flight00PerLabel[1].text = Mathf.RoundToInt(F00ResultPoint1 * 100 / ValueDeliverScript.pointF00P01Max).ToString() + "%";
        flight00PerLabel[2].text = Mathf.RoundToInt(F00ResultPoint2 * 100 / ValueDeliverScript.pointF00P01Max).ToString() + "%";
        flight00PerLabel[3].text = Mathf.RoundToInt(F00ResultPoint3 * 100 / ValueDeliverScript.pointF00P01Max).ToString() + "%";

        flight01PerLabel[0].text = Mathf.RoundToInt(F01ResultPoint0 * 100 / ValueDeliverScript.pointF00P01Max).ToString() + "%";
        flight01PerLabel[1].text = Mathf.RoundToInt(F01ResultPoint1 * 100 / ValueDeliverScript.pointF00P01Max).ToString() + "%";
        flight01PerLabel[2].text = Mathf.RoundToInt(F01ResultPoint2 * 100 / ValueDeliverScript.pointF00P01Max).ToString() + "%";
        flight01PerLabel[3].text = Mathf.RoundToInt(F01ResultPoint3 * 100 / ValueDeliverScript.pointF00P01Max).ToString() + "%";

        flight02PerLabel[0].text = Mathf.RoundToInt(F02ResultPoint0 * 100 / ValueDeliverScript.pointF00P01Max).ToString() + "%";
        flight02PerLabel[1].text = Mathf.RoundToInt(F02ResultPoint1 * 100 / ValueDeliverScript.pointF00P01Max).ToString() + "%";
        flight02PerLabel[2].text = Mathf.RoundToInt(F02ResultPoint2 * 100 / ValueDeliverScript.pointF00P01Max).ToString() + "%";
        flight02PerLabel[3].text = Mathf.RoundToInt(F02ResultPoint3 * 100 / ValueDeliverScript.pointF00P01Max).ToString() + "%";
    }


    //각각의 비행기별로 가지고 있는 기본 스탯을 찍어주는 부분.
    //시작시 한번만 계산하고 더이상 계산할 필요가 없는 부분.
    public void BaseGageSet()
    {
        flight00BaseGage[0].fillAmount = (float)ValueDeliverScript.pointF00P01 / ValueDeliverScript.pointF00P01Max;
        flight00BaseGage[1].fillAmount = (float)ValueDeliverScript.pointF00P02 / ValueDeliverScript.pointF00P02Max;
        flight00BaseGage[2].fillAmount = (float)ValueDeliverScript.pointF00P03 / ValueDeliverScript.pointF00P03Max;
        flight00BaseGage[3].fillAmount = (float)ValueDeliverScript.pointF00P04 / ValueDeliverScript.pointF00P04Max;

        flight01BaseGage[0].fillAmount = (float)ValueDeliverScript.pointF01P01 / ValueDeliverScript.pointF01P01Max;
        flight01BaseGage[1].fillAmount = (float)ValueDeliverScript.pointF01P02 / ValueDeliverScript.pointF01P02Max;
        flight01BaseGage[2].fillAmount = (float)ValueDeliverScript.pointF01P03 / ValueDeliverScript.pointF01P03Max;
        flight01BaseGage[3].fillAmount = (float)ValueDeliverScript.pointF01P04 / ValueDeliverScript.pointF01P04Max;

        flight02BaseGage[0].fillAmount = (float)ValueDeliverScript.pointF02P01 / ValueDeliverScript.pointF02P01Max;
        flight02BaseGage[1].fillAmount = (float)ValueDeliverScript.pointF02P02 / ValueDeliverScript.pointF02P02Max;
        flight02BaseGage[2].fillAmount = (float)ValueDeliverScript.pointF02P03 / ValueDeliverScript.pointF02P03Max;
        flight02BaseGage[3].fillAmount = (float)ValueDeliverScript.pointF02P04 / ValueDeliverScript.pointF02P04Max;
    }

    //추가된 스탯양을 게이지바로 보여주기 위해 사용하는 함수.
    public void AddGageSet()
    {
        flight00AddGage[0].fillAmount = (float)F00ResultPoint0 / ValueDeliverScript.pointF00P01Max;
        flight00AddGage[1].fillAmount = (float)F00ResultPoint1 / ValueDeliverScript.pointF00P02Max;
        flight00AddGage[2].fillAmount = (float)F00ResultPoint2 / ValueDeliverScript.pointF00P03Max;
        flight00AddGage[3].fillAmount = (float)F00ResultPoint3 / ValueDeliverScript.pointF00P04Max;

        flight01AddGage[0].fillAmount = (float)F01ResultPoint0 / ValueDeliverScript.pointF01P01Max;
        flight01AddGage[1].fillAmount = (float)F01ResultPoint1 / ValueDeliverScript.pointF01P02Max;
        flight01AddGage[2].fillAmount = (float)F01ResultPoint2 / ValueDeliverScript.pointF01P03Max;
        flight01AddGage[3].fillAmount = (float)F01ResultPoint3 / ValueDeliverScript.pointF01P04Max;

        flight02AddGage[0].fillAmount = (float)F02ResultPoint0 / ValueDeliverScript.pointF02P01Max;
        flight02AddGage[1].fillAmount = (float)F02ResultPoint1 / ValueDeliverScript.pointF02P02Max;
        flight02AddGage[2].fillAmount = (float)F02ResultPoint2 / ValueDeliverScript.pointF02P03Max;
        flight02AddGage[3].fillAmount = (float)F02ResultPoint3 / ValueDeliverScript.pointF02P04Max;
    }

    //추가된 스탯이 몇포인트인지 수치로 표현(기본이 0이고 추가된 양이 있으면 1씩 증가)
    public void AddLabelSet()
    {
        flight00AddLabel[0].text = "+" + ValueDeliverScript.upgradePointF00P01;
        flight00AddLabel[1].text = "+" + ValueDeliverScript.upgradePointF00P02;
        flight00AddLabel[2].text = "+" + ValueDeliverScript.upgradePointF00P03;
        flight00AddLabel[3].text = "+" + ValueDeliverScript.upgradePointF00P04;

        flight01AddLabel[0].text = "+" + ValueDeliverScript.upgradePointF01P01;
        flight01AddLabel[1].text = "+" + ValueDeliverScript.upgradePointF01P02;
        flight01AddLabel[2].text = "+" + ValueDeliverScript.upgradePointF01P03;
        flight01AddLabel[3].text = "+" + ValueDeliverScript.upgradePointF01P04;

        flight02AddLabel[0].text = "+" + ValueDeliverScript.upgradePointF02P01;
        flight02AddLabel[1].text = "+" + ValueDeliverScript.upgradePointF02P02;
        flight02AddLabel[2].text = "+" + ValueDeliverScript.upgradePointF02P03;
        flight02AddLabel[3].text = "+" + ValueDeliverScript.upgradePointF02P04;
    }

    //내가 보유한 강화포인트가 현재 사용되고 난 후 얼마나 남아있는지 계산하는 부분.
    public void CalRemainPoint()
    {
        int usePoint00 = ValueDeliverScript.upgradePointF00P01 + ValueDeliverScript.upgradePointF00P02 + ValueDeliverScript.upgradePointF00P03 + ValueDeliverScript.upgradePointF00P04;
        int usePoint01 = ValueDeliverScript.upgradePointF01P01 + ValueDeliverScript.upgradePointF01P02 + ValueDeliverScript.upgradePointF01P03 + ValueDeliverScript.upgradePointF01P04;
        int usePoint02 = ValueDeliverScript.upgradePointF02P01 + ValueDeliverScript.upgradePointF02P02 + ValueDeliverScript.upgradePointF02P03 + ValueDeliverScript.upgradePointF02P04;

        remainPoint = ValueDeliverScript.upgradePoint - (usePoint00 + usePoint01 + usePoint02);
    }

    //각 비행기 별로 강화포인트가 남아있으면 강화포인트 사용 가능 상태로 변경해주기 위한 함수.
    public void IsBtnAnimationFirst()
    {
        Debug.Log("비행기 넘버 ::: " + ValueDeliverScript.flightNumber);
        int fNumber = ValueDeliverScript.flightNumber;
        int flightLockOff = 0;
        switch (fNumber)
        {
            case 0: flightLockOff = ValueDeliverScript.FlightLockOff000; break;
            case 1: flightLockOff = ValueDeliverScript.FlightLockOff001; break;
            case 2: flightLockOff = ValueDeliverScript.FlightLockOff002; break;
        }

        Debug.Log("Flight Lock Off ::: " + flightLockOff);

        if (upgradeState[fNumber].activeSelf == true)
            upgradeState[fNumber].GetComponent<StartGlowScript>().ShowGlow();



        if (remainPoint > 0 && flightLockOff == 2)
        {
            statePercent[fNumber].SetActive(false);
            upgradeState[fNumber].SetActive(true);

            prepareReady.transform.FindChild("OperMessage/UpgradePointMessage").gameObject.SetActive(true);
            prepareReady.transform.FindChild("OperMessage/SpecialMessage").gameObject.SetActive(false);
            //강화포인트가 얼마나 있는지 보여주는 정보창을 보이게 설정하는 부분.
        }
        else
        {
            StatePerSet();
            statePercent[fNumber].SetActive(true);
            upgradeState[fNumber].SetActive(false);

            prepareReady.transform.FindChild("OperMessage/UpgradePointMessage").gameObject.SetActive(false);

            if (ValueDeliverScript.isSpecialAttackComplete == 1 && ValueDeliverScript.gameEndResult == false)
            {
                prepareReady.transform.FindChild("OperMessage/SpecialAttackOn").gameObject.SetActive(true);
                prepareReady.transform.FindChild("OperMessage/SpecialMessage").gameObject.SetActive(false);
            }
            else
            {
                prepareReady.transform.FindChild("OperMessage/SpecialAttackOn").gameObject.SetActive(false);
                prepareReady.transform.FindChild("OperMessage/SpecialMessage").gameObject.SetActive(true);
            }
            ValueDeliverScript.gameEndResult = false;
        }
    }


    public void IsBtnAnimation()
    {

        //Debug.Log("IsBtnAnimation1");
        int fNumber = ValueDeliverScript.flightWindowPosition;
        int flightLockOff = 0;
        switch (fNumber)
        {
            case 0: flightLockOff = ValueDeliverScript.FlightLockOff000; break;
            case 1: flightLockOff = ValueDeliverScript.FlightLockOff001; break;
            case 2: flightLockOff = ValueDeliverScript.FlightLockOff002; break;
        }

        if (remainPoint > 0 && flightLockOff == 2)
        {
            statePercent[fNumber].SetActive(false);
            upgradeState[fNumber].SetActive(true);

            bool isPointMessageActive = prepareReady.transform.FindChild("OperMessage/UpgradePointMessage").gameObject.activeSelf;
            float flightPositionX = GameObject.Find("GameManager").GetComponent<HangarManager>().flights.transform.localPosition.x;

            if (isPointMessageActive == false && flightPositionX == 0)
            {
                Debug.Log("PrepareReadyAnim03_6");
                prepareReady.animation.Play("PrepareReadyAnim03_6");
            }
            //강화포인트가 얼마나 있는지 보여주는 정보창을 보이게 설정하는 부분.
        }
        else
        {
            StatePerSet();

            statePercent[fNumber].SetActive(true);
            upgradeState[fNumber].SetActive(false);

            upgradeState[fNumber].transform.FindChild("GlowBtn").GetComponent<BtnGlowScript>().isAnim = false;

            //업그레이드 포인트가 지급되고 게임엔드리절트가 폴스일때(인게임을 마치고 돌아온 상황이 아닐때)만 바로 아래 내용을 실행한다//
            if (prepareReady.transform.FindChild("OperMessage/UpgradePointMessage").gameObject.activeSelf == true
                &&
                ValueDeliverScript.gameEndResult ==false)
            {
                Debug.Log("PrepareReadyAnim03_7");

                prepareReady.animation.Play("PrepareReadyAnim03_7");
            }
        }

        if (upgradeState[fNumber].activeSelf == true)
            upgradeState[fNumber].GetComponent<StartGlowScript>().ShowGlow();

    }

    //강화포인트 리셋을 경고해주는 창을 띄운다.
    void ResetWindow()
    {
        int upgradePoint = ValueDeliverScript.upgradePoint;
        int pointResetCount = ValueDeliverScript.pointResetCount;
        //포인트 리셋을 할지 여부를 알려줄 창을 띄워줌.
        if (upgradePoint != remainPoint)
        {
            forResetPoint.text = (upgradePoint - remainPoint).ToString();
            forResetCoin.text = coinForPointReset[pointResetCount].ToString();
            GameObject.Find("GameManager").GetComponent<HangarPopupController>().AddPopWin(resetPointWindow, 0);

            //resetPointWindow.SetActive(true);
            //halfBLKPanel.SetActive(true);
            //halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, resetPointWindow.transform.localPosition.z + 5);
        }
        else
        {

        }
    }


    //각 비행기의 포인트를 리셋하고 싶을때 사용하는 함수//
    void ResetPointFlight()
    {
        int coinRest = ValueDeliverScript.coinRest;
        int pointResetCount = ValueDeliverScript.pointResetCount;

        if (coinRest >= coinForPointReset[pointResetCount])
        {
            ValueDeliverScript.upgradePointF00P01 = 0;
            ValueDeliverScript.upgradePointF00P02 = 0;
            ValueDeliverScript.upgradePointF00P03 = 0;
            ValueDeliverScript.upgradePointF00P04 = 0;

            ValueDeliverScript.upgradePointF01P01 = 0;
            ValueDeliverScript.upgradePointF01P02 = 0;
            ValueDeliverScript.upgradePointF01P03 = 0;
            ValueDeliverScript.upgradePointF01P04 = 0;

            ValueDeliverScript.upgradePointF02P01 = 0;
            ValueDeliverScript.upgradePointF02P02 = 0;
            ValueDeliverScript.upgradePointF02P03 = 0;
            ValueDeliverScript.upgradePointF02P04 = 0;

            GameObject.Find("GameManager").GetComponent<HangarPopupController>().CloseWindow();
            //resetPointWindow.SetActive(false);
            //halfBLKPanel.SetActive(false);

            coinRest -= coinForPointReset[pointResetCount];   //초기화 비용을 차감한다.
            ValueDeliverScript.coinRest = coinRest;


            if (pointResetCount < 9)
                pointResetCount++;   //초기화 한 횟수를 기록한다.

            ValueDeliverScript.pointResetCount = pointResetCount;

            RedrawStatePoint(); //화면에 보이는 게이지들을 재계산하여 바뀐 상황에 맞게 표시해줌.
            GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.
        }
        else
        {
            //GameObject.Find("GameManager").GetComponent<HangarPopupController>().CloseWindow();
            //resetPointWindow.SetActive(false);
            GoToCoinShortageWindow();
        }

        //포인트 리셋시는 저장하여 준다//
        ValueDeliverScript.SaveGameData();
    }

    void ResetPointFlightCancel()
    {

        GameObject.Find("GameManager").GetComponent<HangarPopupController>().CloseWindow();

        //resetPointWindow.SetActive(false);
        //halfBLKPanel.SetActive(false);
    }

    public void GoToCoinShortageWindow()
    {
        //halfBLKPanel.SetActive(true);
        //CoinShortageWindow.SetActive(true);
        //halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, CoinShortageWindow.transform.localPosition.z + 5);


        GameObject.Find("GameManager").GetComponent<HangarPopupController>().AddPopWin(coinShortageWindow, -1, MCoinShortageWindowMethod, isClosePop: true);
    }

    void MCoinShortageWindowMethod()
    {
        StartCoroutine(CoinCharSound());
    }

    IEnumerator CoinCharSound()
    {
        int activeOper = ValueDeliverScript.activeOper;
        yield return new WaitForSeconds(0.5f);
        CharacterMsgSndConScript characterMsgSndCon;
        characterMsgSndCon = GameObject.Find("CharacterMsgSndCon").GetComponent<CharacterMsgSndConScript>();
        characterMsgSndCon.CoinShort(activeOper);
    }

    //각 비행기의 포인트를 리셋하고 싶을때 사용하는 함수//




    //포커 강화포인트//
    void UpgradePointF00P01Add()
    {
        //Debug.Log("remainPoint" + remainPoint);
        //Debug.Log("F00ResultPoint[0]" + F00ResultPoint0);
        CalRemainPoint();
        //Debug.Log("End CalRemainPoint");
        if (remainPoint > 0 && F00ResultPoint0 < ValueDeliverScript.pointF00P01Max)
        {
            ValueDeliverScript.upgradePointF00P01 += 1;
            RedrawStatePoint();

            //ValueDeliverScript.SaveGameData();
        }
    }
    void UpgradePointF00P02Add()
    {
        //Debug.Log("remainPoint" + remainPoint);
        CalRemainPoint();
        if (remainPoint > 0 && F00ResultPoint1 < ValueDeliverScript.pointF00P02Max)
        {
            ValueDeliverScript.upgradePointF00P02 += 1;
            RedrawStatePoint();

            //ValueDeliverScript.SaveGameData();
        }
    }
    void UpgradePointF00P03Add()
    {
        //Debug.Log("remainPoint" + remainPoint);
        CalRemainPoint();
        if (remainPoint > 0 && F00ResultPoint2 < ValueDeliverScript.pointF00P03Max)
        {
            ValueDeliverScript.upgradePointF00P03 += 1;
            RedrawStatePoint();

            //ValueDeliverScript.SaveGameData();
        }
    }
    void UpgradePointF00P04Add()
    {
        //Debug.Log("remainPoint" + remainPoint);
        CalRemainPoint();
        if (remainPoint > 0 && F00ResultPoint3 < ValueDeliverScript.pointF00P04Max)
        {
            ValueDeliverScript.upgradePointF00P04 += 1;
            RedrawStatePoint();

            //ValueDeliverScript.SaveGameData();
        }
    }
    //포커 강화포인트//



    //코만치 강화포인트//
    void UpgradePointF01P01Add()
    {
        //Debug.Log("remainPoint" + remainPoint);
        CalRemainPoint();
        if (remainPoint > 0 && F01ResultPoint0 < ValueDeliverScript.pointF01P01Max)
        {
            ValueDeliverScript.upgradePointF01P01 += 1;
            RedrawStatePoint();

            //ValueDeliverScript.SaveGameData();
        }
    }
    void UpgradePointF01P02Add()
    {
        //Debug.Log("remainPoint" + remainPoint);
        CalRemainPoint();
        if (remainPoint > 0 && F01ResultPoint1 < ValueDeliverScript.pointF01P02Max)
        {
            ValueDeliverScript.upgradePointF01P02 += 1;
            RedrawStatePoint();

            //ValueDeliverScript.SaveGameData();
        }
    }
    void UpgradePointF01P03Add()
    {
        //Debug.Log("remainPoint" + remainPoint);
        CalRemainPoint();
        if (remainPoint > 0 && F01ResultPoint2 < ValueDeliverScript.pointF01P03Max)
        {
            ValueDeliverScript.upgradePointF01P03 += 1;
            RedrawStatePoint();

            //ValueDeliverScript.SaveGameData();
        }
    }
    void UpgradePointF01P04Add()
    {
        //Debug.Log("remainPoint" + remainPoint);
        CalRemainPoint();
        if (remainPoint > 0 && F01ResultPoint3 < ValueDeliverScript.pointF01P04Max)
        {
            ValueDeliverScript.upgradePointF01P04 += 1;
            RedrawStatePoint();

            //ValueDeliverScript.SaveGameData();
        }
    }
    //코만치 강화포인트//



    //팬텀 강화포인트//
    void UpgradePointF02P01Add()
    {
        //Debug.Log("remainPoint" + remainPoint);
        CalRemainPoint();
        if (remainPoint > 0 && F02ResultPoint0 < ValueDeliverScript.pointF02P01Max)
        {
            ValueDeliverScript.upgradePointF02P01 += 1;
            RedrawStatePoint();

            //ValueDeliverScript.SaveGameData();
        }
    }
    void UpgradePointF02P02Add()
    {
        //Debug.Log("remainPoint" + remainPoint);
        CalRemainPoint();
        if (remainPoint > 0 && F02ResultPoint1 < ValueDeliverScript.pointF02P02Max)
        {
            ValueDeliverScript.upgradePointF02P02 += 1;
            RedrawStatePoint();

            //ValueDeliverScript.SaveGameData();
        }
    }
    void UpgradePointF02P03Add()
    {
        //Debug.Log("remainPoint" + remainPoint);
        CalRemainPoint();
        if (remainPoint > 0 && F02ResultPoint2 < ValueDeliverScript.pointF02P03Max)
        {
            ValueDeliverScript.upgradePointF02P03 += 1;
            RedrawStatePoint();

            //ValueDeliverScript.SaveGameData();
        }
    }
    void UpgradePointF02P04Add()
    {
        //Debug.Log("remainPoint" + remainPoint);
        CalRemainPoint();
        if (remainPoint > 0 && F02ResultPoint3 < ValueDeliverScript.pointF02P04Max)
        {
            ValueDeliverScript.upgradePointF02P04 += 1;
            RedrawStatePoint();

            //ValueDeliverScript.SaveGameData();
        }
    }
    //팬텀 강화포인트//

    public void RedrawStatePoint()
    {

        ResultPointCal();   //가장먼저 실행되어야 될 함수.
        CalRemainPoint();
        ResultPoint();
        AddGageSet();
        AddLabelSet();
        IsBtnAnimation();   //강화포인트가 지급되었을때 최초 지급인지 아닌지에 따라 하단 정보창의 애니메이션 처리 여부를 결정함.
        RemainPointLabel();
    }

    public void RemainPointLabel()
    {
        remainPointlabel.text = remainPoint.ToString();
    }
}
