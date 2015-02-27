using UnityEngine;
using System.Collections;

public class PositionSkinSendScript : MonoBehaviour
{

    public GameObject target;
    public int flightNumber;    //비행기번호.
    public int skinNumber;      //스킨 번호.
    public string skinKoreaName;     //스킨이름.
    public string[] skinScript;  //스킨 세부 내용 서술.
    public int[] skinLevelExp;    //스킨 경험치.
    [System.NonSerialized]
    public int skinLevel = 1;
    int skinLevelExpRest;

    public string lockOffCondition;

    public GameObject duraLabel;

    string skinName;

    public GameObject BtnStatus;


    void Awake()
    {
        skinName = "Flight" + flightNumber.ToString("D3") + "Skin" + skinNumber.ToString("D3");

        //스킨 내구도 관련 세팅.
    }


    public void PositionSend()  //스킨 아이콘을 클릭하면 실행되는 부분.
    {
        transform.parent.parent.FindChild("Flight").GetComponent<FlightStatusShowScript>().tempSkinNum = skinNumber;

        InsertNameLevel();
        switch (ValueDeliverScript.flightNumber)
        {
            case 0:
                GameObject.Find("GameManager").GetComponent<HangarManager>().Flight000Skin(skinNumber, skinLevel);
                break;
            case 1:
                GameObject.Find("GameManager").GetComponent<HangarManager>().Flight001Skin(skinNumber, skinLevel);
                break;
            case 2:
                GameObject.Find("GameManager").GetComponent<HangarManager>().Flight002Skin(skinNumber, skinLevel);
                break;
        }
        string duraCost = "Flight" + flightNumber.ToString("D3") + "Skin" + skinNumber.ToString("D3") + "Level" + skinLevel.ToString("D3");
        if (skinNumber != 0)
        {
            transform.parent.parent.FindChild("Dura").FindChild("DuraOffGoldlNum").GetComponent<UILabel>().text = ValueDeliverScript.duraCost[duraCost].ToString(); //스킨 레벨별 내구도 수리비 입력.
        }
        else
        {
            //
        }

        //스킨 락 여부 결정후 장비 해제 아이콘 보이게 할지 결정.
        if (skinNumber != 0)
        {

            int skinVal = 0;
            switch (flightNumber)
            {
                case 0: switch (skinNumber)
                    {
                        case 1: skinVal = ValueDeliverScript.FlightLock000Skin001; break;
                        case 2: skinVal = ValueDeliverScript.FlightLock000Skin002; break;
                        case 3: skinVal = ValueDeliverScript.FlightLock000Skin003; break;
                        case 4: skinVal = ValueDeliverScript.FlightLock000Skin004; break;
                        case 5: skinVal = ValueDeliverScript.FlightLock000Skin005; break;
                    } break;
                case 1: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: skinVal = ValueDeliverScript.FlightLock001Skin001; break;
                        case 2: skinVal = ValueDeliverScript.FlightLock001Skin002; break;
                        case 3: skinVal = ValueDeliverScript.FlightLock001Skin003; break;
                        case 4: skinVal = ValueDeliverScript.FlightLock001Skin004; break;
                        case 5: skinVal = ValueDeliverScript.FlightLock001Skin005; break;
                    } break;
                case 2: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: skinVal = ValueDeliverScript.FlightLock002Skin001; break;
                        case 2: skinVal = ValueDeliverScript.FlightLock002Skin002; break;
                        case 3: skinVal = ValueDeliverScript.FlightLock002Skin003; break;
                        case 4: skinVal = ValueDeliverScript.FlightLock002Skin004; break;
                        case 5: skinVal = ValueDeliverScript.FlightLock002Skin005; break;
                    } break;
            }




            if (skinVal == 0)
            {
                skinName = "Flight" + flightNumber.ToString("D3") + "Skin" + skinNumber.ToString("D3");

                transform.parent.parent.FindChild("Lock").gameObject.SetActive(true);
                transform.parent.parent.FindChild("Lock").FindChild("LockOffMedallNum").GetComponent<UILabel>().text = ValueDeliverScript.skinMedalCost[skinName].ToString(); //스킨 입력.
                transform.parent.parent.FindChild("Lock").FindChild("LockOffCondition").GetComponent<UILabel>().text = lockOffCondition;
                if (skinNumber == 4)
                {
                    transform.parent.parent.FindChild("Lock").FindChild("LockOffGoldBG").GetComponent<UISprite>().spriteName = "base_deco_count";
                }
                else
                {
                    transform.parent.parent.FindChild("Lock").FindChild("LockOffGoldBG").GetComponent<UISprite>().spriteName = "base_gold_count";
                }
                insertSkinScript(true);

            }
            else
            {
                transform.parent.parent.FindChild("Lock").gameObject.SetActive(false);
                insertSkinScript(false);

            }
            Debug.Log("Level Check Start!!!");
            LevelCheck();//여기서 먼저 레벨이 얼마인지 알아보고.
            Debug.Log("Level Check Finish!!!");
            InsertNameLevel(); // 여기서 항상 게이지를 리프레쉬해주면 항상 새로운 스킨 레벨 정보를 볼수 있다.
            Debug.Log("InsertNameLevel Finish!!!");

            //디폴트 스킨이 아니면 레벨 정보를 보이게 함.
            transform.parent.parent.FindChild("Flight/Level").gameObject.SetActive(true);
            transform.parent.parent.FindChild("Flight/LevelGage").gameObject.SetActive(true);
            transform.parent.parent.FindChild("Flight/LevelGageBar").gameObject.SetActive(true);
            transform.parent.parent.FindChild("Flight/LevelNum").gameObject.SetActive(true);
            transform.parent.parent.FindChild("Flight/LevelPerNum").gameObject.SetActive(true);
            transform.parent.parent.FindChild("Flight/PerString").gameObject.SetActive(true);
        }

        else if (skinNumber == 0)
        {
            //디폴트 스킨이 선택되었을때 레벨 정보가 없기때문에 안보이게 함.
            transform.parent.parent.FindChild("Flight/Level").gameObject.SetActive(false);
            transform.parent.parent.FindChild("Flight/LevelGage").gameObject.SetActive(false);
            transform.parent.parent.FindChild("Flight/LevelGageBar").gameObject.SetActive(false);
            transform.parent.parent.FindChild("Flight/LevelNum").gameObject.SetActive(false);
            transform.parent.parent.FindChild("Flight/LevelPerNum").gameObject.SetActive(false);
            transform.parent.parent.FindChild("Flight/PerString").gameObject.SetActive(false);

            transform.parent.parent.FindChild("Lock").gameObject.SetActive(false);
            transform.parent.parent.FindChild("Dura").gameObject.SetActive(false);

            GameObject BG = transform.parent.parent.FindChild("Flight/BG").gameObject;
            BG.transform.localScale = new Vector3(220, 68, 1);

            GameObject skinScriptG = transform.parent.parent.GetComponent<SkinHilightScript>().skinScript;
            skinScriptG.GetComponent<UILabel>().text = "";

            BtnStatus.GetComponent<UISprite>().spriteName = "Btn_AircraftInfoOn_00";
            BtnStatus.GetComponent<UIImageButton>().normalSprite = "Btn_AircraftInfoOn_00";
            BtnStatus.GetComponent<UIImageButton>().hoverSprite = "Btn_AircraftInfoOn_00";
            BtnStatus.GetComponent<UIImageButton>().pressedSprite = "Btn_AircraftInfoOn_01";
        }

        transform.parent.parent.GetComponent<SkinHilightScript>().HilightIconAct();//내구도 수리 아이콘 보이게 할지도 같이 결정.
    }

    public void insertSkinScript(bool isOpen)
    {
        GameObject skinScriptG = transform.parent.parent.GetComponent<SkinHilightScript>().skinScript;
        Debug.Log("skin");
        Debug.Log("스킨정보 :: " + skinScriptG.GetComponent<UILabel>().text);

        //skinScriptG.transform.localPosition = new Vector3(skinScriptG.transform.localPosition.x, yPos, skinScriptG.transform.localPosition.z);//위치지정 -25는 기본.//

        GameObject BG = transform.parent.parent.FindChild("Flight/BG").gameObject;

        if (isOpen)
        {
            Debug.Log("열림");
            skinScriptG.transform.localScale = new Vector3(25,25,1);
            skinScriptG.GetComponent<UILabel>().text = skinScript[skinLevel - 1];     //스킨 세부 내용 표시.
            BG.animation.Stop("FlightStatusBg01");
            BG.animation.Stop("FlightStatusBg02");
            BG.transform.localScale = new Vector3(220, 186, 1);

            BtnStatus.GetComponent<UISprite>().spriteName = "Btn_AircraftInfoOff_00";
            BtnStatus.GetComponent<UIImageButton>().normalSprite = "Btn_AircraftInfoOff_00";
            BtnStatus.GetComponent<UIImageButton>().hoverSprite = "Btn_AircraftInfoOff_00";
            BtnStatus.GetComponent<UIImageButton>().pressedSprite = "Btn_AircraftInfoOff_01";

        }
        else
        {
            Debug.Log("닫힘");
            skinScriptG.GetComponent<UILabel>().text = "";
            Debug.Log("스킨정보 :: " + skinScriptG.GetComponent<UILabel>().text);
            BG.animation.Stop("FlightStatusBg01");
            BG.animation.Stop("FlightStatusBg02");
            BG.transform.localScale = new Vector3(220, 68, 1);

            BtnStatus.GetComponent<UISprite>().spriteName = "Btn_AircraftInfoOn_00";
            BtnStatus.GetComponent<UIImageButton>().normalSprite = "Btn_AircraftInfoOn_00";
            BtnStatus.GetComponent<UIImageButton>().hoverSprite = "Btn_AircraftInfoOn_00";
            BtnStatus.GetComponent<UIImageButton>().pressedSprite = "Btn_AircraftInfoOn_01";

        }
    }

    public void InsertNameLevel()
    {
        float gageFraction = 0;

        //if (skinNumber != 0)
        //LevelCheck();

        transform.parent.parent.GetComponent<SkinHilightScript>().skinName01.GetComponent<UILabel>().text = skinKoreaName;
        transform.parent.parent.GetComponent<SkinHilightScript>().skinName02.GetComponent<UILabel>().text = skinKoreaName;
        transform.parent.parent.GetComponent<SkinHilightScript>().skinLevelLabel.GetComponent<UILabel>().text = skinLevel.ToString("D2");
        //transform.parent.parent.GetComponent<SkinHilightScript>().skinScript.GetComponent<UILabel>().text = skinScript[skinLevel - 1];

        if (skinNumber != 0)
        {
            if (skinLevel < 1 || skinLevel >= 10)
            {
                gageFraction = 0;
            }
            else
            {
                gageFraction = (float)skinLevelExpRest / (float)skinLevelExp[skinLevel - 1];

                //Debug.Log("skinLevelExpRest" + skinLevelExpRest);
                //Debug.Log("skinLevelExp [level - 1]" + skinLevelExp[skinLevel - 1]);
                //Debug.Log("gageFraction" + gageFraction);
            }
        }

        transform.parent.parent.GetComponent<SkinHilightScript>().skinLevelGageBar.GetComponent<UIFilledSprite>().fillAmount = gageFraction;
        transform.parent.parent.GetComponent<SkinHilightScript>().skinLevelPerNum.GetComponent<UILabel>().text = ((int)(gageFraction * 100)).ToString();

    }

    public void LevelCheck()
    {
        
        int fNum = ValueDeliverScript.flightNumber;
        //string flightSkinName = "FlightExp" + fNum.ToString("D3") + "Skin" + skinNumber.ToString("D3");


        int skinExp = 0;
        switch (fNum)
        {
            case 0: switch (skinNumber)
                {
                    case 1: skinExp = ValueDeliverScript.FlightExp000Skin001; break;
                    case 2: skinExp = ValueDeliverScript.FlightExp000Skin002; break;
                    case 3: skinExp = ValueDeliverScript.FlightExp000Skin003; break;
                    case 4: skinExp = ValueDeliverScript.FlightExp000Skin004; break;
                    case 5: skinExp = ValueDeliverScript.FlightExp000Skin005; break;
                } break;
            case 1: switch (skinNumber)
                {
                    case 1: skinExp = ValueDeliverScript.FlightExp001Skin001; break;
                    case 2: skinExp = ValueDeliverScript.FlightExp001Skin002; break;
                    case 3: skinExp = ValueDeliverScript.FlightExp001Skin003; break;
                    case 4: skinExp = ValueDeliverScript.FlightExp001Skin004; break;
                    case 5: skinExp = ValueDeliverScript.FlightExp001Skin005; break;
                } break;
            case 2: switch (skinNumber)
                {
                    case 1: skinExp = ValueDeliverScript.FlightExp002Skin001; break;
                    case 2: skinExp = ValueDeliverScript.FlightExp002Skin002; break;
                    case 3: skinExp = ValueDeliverScript.FlightExp002Skin003; break;
                    case 4: skinExp = ValueDeliverScript.FlightExp002Skin004; break;
                    case 5: skinExp = ValueDeliverScript.FlightExp002Skin005; break;
                } break;
        }


        Debug.Log("skinLevelExpInput" + skinExp);

        for (int levelNum = 0; levelNum < 9; levelNum++)
        {
            if (skinExp > skinLevelExp[levelNum])
            {
                skinExp -= skinLevelExp[levelNum];
                skinLevel = levelNum + 2;
            }
            else
            {
                break;
            }
        }

        #region //바로 위For문을 구성하기전에 해놨던 좀 단순하고 긴코드.
        #endregion
        string flightSkinName = "FlightLev" + fNum.ToString("D3") + "Skin" + skinNumber.ToString("D3");

        switch (fNum)
        {
            case 0: switch (skinNumber)
                {
                    case 1: ValueDeliverScript.FlightLev000Skin001 = skinLevel; break;
                    case 2: ValueDeliverScript.FlightLev000Skin002 = skinLevel; break;
                    case 3: ValueDeliverScript.FlightLev000Skin003 = skinLevel; break;
                    case 4: ValueDeliverScript.FlightLev000Skin004 = skinLevel; break;
                    case 5: ValueDeliverScript.FlightLev000Skin005 = skinLevel; break;
                } break;
            case 1: switch (skinNumber)
                {
                    case 1: ValueDeliverScript.FlightLev001Skin001 = skinLevel; break;
                    case 2: ValueDeliverScript.FlightLev001Skin002 = skinLevel; break;
                    case 3: ValueDeliverScript.FlightLev001Skin003 = skinLevel; break;
                    case 4: ValueDeliverScript.FlightLev001Skin004 = skinLevel; break;
                    case 5: ValueDeliverScript.FlightLev001Skin005 = skinLevel; break;
                } break;
            case 2: switch (skinNumber)
                {
                    case 1: ValueDeliverScript.FlightLev002Skin001 = skinLevel; break;
                    case 2: ValueDeliverScript.FlightLev002Skin002 = skinLevel; break;
                    case 3: ValueDeliverScript.FlightLev002Skin003 = skinLevel; break;
                    case 4: ValueDeliverScript.FlightLev002Skin004 = skinLevel; break;
                    case 5: ValueDeliverScript.FlightLev002Skin005 = skinLevel; break;
                } break;
        }


        skinLevelExpRest = skinExp;
        Debug.Log("skinLevelExpRest" + skinLevelExpRest);
        Debug.Log("Level" + skinLevel);
  
        
        #region Dara Label Update
        //Dara Label Update.
        duraLabel = transform.FindChild("DuraLabel").gameObject;

        flightSkinName = "FlightDura" + fNum.ToString("D3") + "Skin" + skinNumber.ToString("D3");

        int duraValue = 0;
        switch (fNum)
        {
            case 0: switch (skinNumber)
                {
                    case 1: duraValue = ValueDeliverScript.FlightDura000Skin001; break;
                    case 2: duraValue = ValueDeliverScript.FlightDura000Skin002; break;
                    case 3: duraValue = ValueDeliverScript.FlightDura000Skin003; break;
                    case 4: duraValue = ValueDeliverScript.FlightDura000Skin004; break;
                    case 5: duraValue = ValueDeliverScript.FlightDura000Skin005; break;
                } break;
            case 1: switch (skinNumber)
                {
                    case 1: duraValue = ValueDeliverScript.FlightDura001Skin001; break;
                    case 2: duraValue = ValueDeliverScript.FlightDura001Skin002; break;
                    case 3: duraValue = ValueDeliverScript.FlightDura001Skin003; break;
                    case 4: duraValue = ValueDeliverScript.FlightDura001Skin004; break;
                    case 5: duraValue = ValueDeliverScript.FlightDura001Skin005; break;
                } break;
            case 2: switch (skinNumber)
                {
                    case 1: duraValue = ValueDeliverScript.FlightDura002Skin001; break;
                    case 2: duraValue = ValueDeliverScript.FlightDura002Skin002; break;
                    case 3: duraValue = ValueDeliverScript.FlightDura002Skin003; break;
                    case 4: duraValue = ValueDeliverScript.FlightDura002Skin004; break;
                    case 5: duraValue = ValueDeliverScript.FlightDura002Skin005; break;
                } break;
        }

        duraLabel.GetComponent<UILabel>().text = duraValue + "/10";
        Debug.Log("Dara Label Update.");
        #endregion

        if (skinNumber > 0 && skinNumber < 6)
        {
            flightSkinName = "FlightDura" + fNum.ToString("D3") + "Skin" + skinNumber.ToString("D3");

            transform.FindChild("DuraLabel").GetComponent<UILabel>().text = duraValue + "/10";


            if (duraValue <= 0)
            {
                transform.FindChild("RefairIcon").gameObject.SetActive(true);
                transform.FindChild("SkinIcon").gameObject.GetComponent<UISprite>().alpha = 0.5f;
            }

            flightSkinName = "FlightLock" + fNum.ToString("D3") + "Skin" + skinNumber.ToString("D3");

            int lockValue = 0;
            switch (fNum)
            {
                case 0: switch (skinNumber)
                    {
                        case 1: lockValue = ValueDeliverScript.FlightLock000Skin001; break;
                        case 2: lockValue = ValueDeliverScript.FlightLock000Skin002; break;
                        case 3: lockValue = ValueDeliverScript.FlightLock000Skin003; break;
                        case 4: lockValue = ValueDeliverScript.FlightLock000Skin004; break;
                        case 5: lockValue = ValueDeliverScript.FlightLock000Skin005; break;
                    } break;
                case 1: switch (skinNumber)
                    {
                        case 1: lockValue = ValueDeliverScript.FlightLock001Skin001; break;
                        case 2: lockValue = ValueDeliverScript.FlightLock001Skin002; break;
                        case 3: lockValue = ValueDeliverScript.FlightLock001Skin003; break;
                        case 4: lockValue = ValueDeliverScript.FlightLock001Skin004; break;
                        case 5: lockValue = ValueDeliverScript.FlightLock001Skin005; break;
                    } break;
                case 2: switch (skinNumber)
                    {
                        case 1: lockValue = ValueDeliverScript.FlightLock002Skin001; break;
                        case 2: lockValue = ValueDeliverScript.FlightLock002Skin002; break;
                        case 3: lockValue = ValueDeliverScript.FlightLock002Skin003; break;
                        case 4: lockValue = ValueDeliverScript.FlightLock002Skin004; break;
                        case 5: lockValue = ValueDeliverScript.FlightLock002Skin005; break;
                    } break;
            }

            if (lockValue == 0)
            {
                transform.FindChild("LockIcon").gameObject.SetActive(true);
                transform.FindChild("SkinIcon").gameObject.GetComponent<UISprite>().alpha = 0.5f;
            }
        }
        //ValueDeliverScript.SaveGameData();
        //PositionSend();
        //결과창에 스킨레벨 표시.
        GameObject.Find("Windows").transform.FindChild("ResultPanel/ResultPanelLeft/LevelBox/SkinLevel/SkinLevelLabel").GetComponent<UILabel>().text = skinLevel.ToString();
        //결과창에 스킨 게이지바 표시
        GameObject.Find("Windows").transform.FindChild("ResultPanel/ResultPanelLeft/LevelBox/SkinLevel/SkinLevelGageBar").GetComponent<UIFilledSprite>().fillAmount = (float)skinLevelExpRest / (float)skinLevelExp[skinLevel - 1];
        //결과창에 스킨 게이지바 퍼세트를 표시
        GameObject.Find("Windows").transform.FindChild("ResultPanel/ResultPanelLeft/LevelBox/SkinLevel/SkinLevelGageBarPercentLabel").GetComponent<UILabel>().text = ((int)(((float)skinLevelExpRest / (float)skinLevelExp[skinLevel - 1]) * 100)).ToString() + "%";
    }



    //void OnEnable()
    //{
    //    UpdateSkinInfo();
    //}

    //스킨 셀렉트 창이 열릴때마다 호출하여 각각의 스킨의 내구도 표시와 락오프 여부를 표시해준다.
    public void UpdateSkinInfo()
    {
        string skinDura = "FlightDura" + flightNumber.ToString("D3") + "Skin" + skinNumber.ToString("D3");


        int duraValue = 0;
        switch (flightNumber)
        {
            case 0: switch (skinNumber)
                {
                    case 1: duraValue = ValueDeliverScript.FlightDura000Skin001; break;
                    case 2: duraValue = ValueDeliverScript.FlightDura000Skin002; break;
                    case 3: duraValue = ValueDeliverScript.FlightDura000Skin003; break;
                    case 4: duraValue = ValueDeliverScript.FlightDura000Skin004; break;
                    case 5: duraValue = ValueDeliverScript.FlightDura000Skin005; break;
                } break;
            case 1: switch (skinNumber)
                {
                    case 1: duraValue = ValueDeliverScript.FlightDura001Skin001; break;
                    case 2: duraValue = ValueDeliverScript.FlightDura001Skin002; break;
                    case 3: duraValue = ValueDeliverScript.FlightDura001Skin003; break;
                    case 4: duraValue = ValueDeliverScript.FlightDura001Skin004; break;
                    case 5: duraValue = ValueDeliverScript.FlightDura001Skin005; break;
                } break;
            case 2: switch (skinNumber)
                {
                    case 1: duraValue = ValueDeliverScript.FlightDura002Skin001; break;
                    case 2: duraValue = ValueDeliverScript.FlightDura002Skin002; break;
                    case 3: duraValue = ValueDeliverScript.FlightDura002Skin003; break;
                    case 4: duraValue = ValueDeliverScript.FlightDura002Skin004; break;
                    case 5: duraValue = ValueDeliverScript.FlightDura002Skin005; break;
                } break;
        }

        if (skinNumber > 0 && skinNumber < 6)
        {
            transform.FindChild("DuraLabel").GetComponent<UILabel>().text = duraValue + "/10";


            //내구도 관한 내용.
            if (duraValue <= 0)
            {
                transform.FindChild("RefairIcon").gameObject.SetActive(true);
                transform.FindChild("SkinIcon").gameObject.GetComponent<UISprite>().alpha = 0.5f;
                transform.parent.parent.FindChild("Dura").gameObject.SetActive(true);

            }
            else
            {
                transform.FindChild("RefairIcon").gameObject.SetActive(false);
                transform.FindChild("SkinIcon").gameObject.GetComponent<UISprite>().alpha = 1f;
            }

            string  skinLock = "FlightLock" + flightNumber.ToString("D3") + "Skin" + skinNumber.ToString("D3");
            //락오프 관한 내용.

            int lockValue = 0;
            switch (flightNumber)
            {
                case 0: switch (skinNumber)
                    {
                        case 1: lockValue = ValueDeliverScript.FlightLock000Skin001; break;
                        case 2: lockValue = ValueDeliverScript.FlightLock000Skin002; break;
                        case 3: lockValue = ValueDeliverScript.FlightLock000Skin003; break;
                        case 4: lockValue = ValueDeliverScript.FlightLock000Skin004; break;
                        case 5: lockValue = ValueDeliverScript.FlightLock000Skin005; break;
                    } break;
                case 1: switch (skinNumber)
                    {
                        case 1: lockValue = ValueDeliverScript.FlightLock001Skin001; break;
                        case 2: lockValue = ValueDeliverScript.FlightLock001Skin002; break;
                        case 3: lockValue = ValueDeliverScript.FlightLock001Skin003; break;
                        case 4: lockValue = ValueDeliverScript.FlightLock001Skin004; break;
                        case 5: lockValue = ValueDeliverScript.FlightLock001Skin005; break;
                    } break;
                case 2: switch (skinNumber)
                    {
                        case 1: lockValue = ValueDeliverScript.FlightLock002Skin001; break;
                        case 2: lockValue = ValueDeliverScript.FlightLock002Skin002; break;
                        case 3: lockValue = ValueDeliverScript.FlightLock002Skin003; break;
                        case 4: lockValue = ValueDeliverScript.FlightLock002Skin004; break;
                        case 5: lockValue = ValueDeliverScript.FlightLock002Skin005; break;
                    } break;
            }


            if (lockValue == 0)
            {
                transform.FindChild("LockIcon").gameObject.SetActive(true);
                transform.FindChild("SkinIcon").gameObject.GetComponent<UISprite>().alpha = 0.5f;
                Debug.Log("skinNumber :: " + skinNumber + transform.FindChild("LockIcon").gameObject.activeSelf);
            }
            else
            {
                Debug.Log("transform.FindChild(LockIcon).gameObject.SetActive(false);");
                transform.FindChild("LockIcon").gameObject.SetActive(false);
                transform.FindChild("SkinIcon").gameObject.GetComponent<UISprite>().alpha = 1f;
                Debug.Log("skinNumber :: " + skinNumber + transform.FindChild("LockIcon").gameObject.activeSelf);
            }
        }
    }
}