using System;
using System.Collections;
using MyDelegateNS;
using UnityEngine;

public class HangarManager : MonoBehaviour
{

    #region Variables

    //////여긴 행거 스크립트에서 가지고 온것
    #region 팝업 창 모음
    public GameObject allBuyWindow;
    public GameObject buddyPoint100;
    public GameObject coinShortageWindow;
    public GameObject duraBuyAlarmWindow;
    public GameObject everyPlayWindow;
    public GameObject firstAccessWindow;
    public GameObject friendInfoWindow;
    public GameObject friendInvite;
    public GameObject fuelSend;
    public GameObject gasOverWindow;
    public GameObject gasShortageWindow;
    public GameObject loginEventWin;
    public GameObject medalShortageWindow;
    public GameObject msgItemGet;
    public GameObject pilotLevelUpWindow;
    public GameObject reviewRequest;
    public GameObject rewardFBOff;
    public GameObject rewardFBOn;
    public GameObject rewardWDOff;
    public GameObject rewardWDOn;
    public GameObject skinLockOffWindow;
    public GameObject SpecialSelectWin;
    public GameObject uiInfo01Window;
    public GameObject uiInfo02Window;
    public GameObject uiInfo03Window;
    public GameObject upgradePointWindow;
    public GameObject noFbLoginWindow;
    #endregion

    public GameObject flights;

    public GameObject friendMailTab;
    public GameObject friendWindow;
    public GameObject friendWeekTab;
    public GameObject halfBLKPanel;
    public GameObject mountIconTemp;
    public GameObject ResultPanel;
    public GameObject purchaseConfirmWindow;
    public GameObject prepareReady;
    public GameObject skinSelectWindow00;
    public GameObject skinSelectWindow01;
    public GameObject skinSelectWindow02;
    public GameObject storeWindow;
    public GameObject soundControlWindow;
    public GameObject wRankab;

    public GameObject attackReady;
    public GameObject equipWindows;
    public GameObject equipBombTab;
    public GameObject equipReinforceTab;
    public GameObject equipAssistanceTab;
    public GameObject equipOperTab;
    public GameObject spIcon01;
    public GameObject spIcon02;

    public Vector3 mountIconPositionTemp;

    private string[] bombSpriteName;
    private string[] reinforceSpriteName;
    private string[] assistSpriteName;
    private string[] operSpriteName;

    public GameObject[] specialAttackIcon;
    public GameObject[] specialAttackText;
    public string[] specialAttackName;

    private DateTime specialEndTime;

    private int specialRestTimeText;

    public GameObject specialRestTimeLabel01;
    //public GameObject specialRestTimeLabel02;

    public int specialDart = 1000;  //원래 1000.
    public int specialSpinball = 1500;  //원래 1500.
    public int specialDust = 2000;  //원래 2000.
    public int specialSeed = 300; //원래 300.

    public AudioClip popupClose;
    public AudioClip popupDisplay;

    public AudioClip levelPopupDisplay; //레벨업창 나타날때.

    private GameObject winMove;

    private GameObject windows;

    private string testString;

    private bool equipToStoreOn = false;
    private bool skin00ToStoreOn = false;
    private bool skin01ToStoreOn = false;
    private bool skin02ToStoreOn = false;
    private bool storeToFriendOn = false;
    private bool resultToStoreOn = false;
    private bool mainToFriendOn = false;

    public GameObject equipItemName;
    public GameObject equipItemScript;
    public GameObject equipItemPrice;

    public GameObject bgTop;
    public GameObject bgBottom;

    public FlightUpointSetScript flightUpointSetScript;


    [NonSerialized]
    public bool isSkinFullLevel = false;

    public GameObject noTouchPanel;

    private bool gameEndResult;

    private int resultSkinNumber;
    private int resultSkinName;

    private int billingResult = 0;



    //////여기는 퍼스트 로드 데이터 스크립트에서 가지고 온것/////
    public GameObject userLevelG;
    public GameObject userLevelGage;
    public GameObject userLevelGageLabel;

    public GameObject flight000;
    public Texture[] flight000Skin;
    public GameObject flight000Bullet;
    public GameObject flight000BulletLabel;
    public GameObject flight000SkillLabel;

    public GameObject flight001;
    public Texture[] flight001Skin;
    public GameObject flight001Bullet;
    public GameObject flight001BulletLabel;
    public GameObject flight001SkillLabel;


    public GameObject flight002;
    public Texture[] flight002Skin;
    public GameObject flight002Bullet;
    public GameObject flight002BulletLabel;
    public GameObject flight002SkillLabel;

    public GameObject[] skinNameTag;
    public GameObject[] skinLockOffTag;
    public GameObject[] skinLevel;
    public GameObject[] skinlevelGage;


    //랭킹 표시를 위한 인스턴스 풀 생성//
    public GameObject friendRank;
    public int friendRankCount;
    //랭킹 표시를 위한 인스턴스 풀 생성//

    //받은 메세지 표시를 위한 인스턴스 풀 생성//
    public GameObject friendMessage;
    public int friendMessageCount;
    //받은 메세지 표시를 위한 인스턴스 풀 생성//


    int oldUserLevel;
    int addMedal = 0;
    int addCoin = 0;



    //플레이어 레벨이 오르는데 필요한 경험치.
    int[] userLevelpoint = { 120, 213, 317, 432, 560, 702, 860, 1036, 1231, 1448, 1689, 1957, 2254, 2584, 2951, 3359, 3812, 4316, 4876, 5498, 6189, 6957, 7810, 8758, 9811, 10981, 12281, 13726, 15331, 17114, 19096, 21298, 23744, 26462, 29482, 32838, 36567, 40710, 45313, 50428, 56111, 62426, 69442, 77238, 85900, 95524, 106218, 118100, 131302, 145971 };
    //플레이어의 레벨이 오를시 지급되는 보너스 코인양.
    int[] addCoinPerLevel = { 0, 400, 600, 800, 1000, 1200, 1400, 1600, 1800, 2000, 2200, 2400, 2600, 2800, 3000, 3200, 3400, 3600, 3800, 4000, 4200, 4400, 4600, 4800, 5000, 5200, 5400, 5600, 5800, 6000, 6200, 6400, 6600, 6800, 7000, 7200, 7400, 7600, 7800, 8000, 8200, 8400, 8600, 8800, 9000, 9200, 9400, 9600, 9800, 10000 };

    int flightExperienceTemp;

    public CharacterMsgSndConScript characterMsgSndCon;

    public int[] F00skinFullLevel;
    public int[] F01skinFullLevel;
    public int[] F02skinFullLevel;

    Hashtable skinFullLevel;

    public TutManagerScript tutManagerScript;
    private bool isRLowTabAnim = false;

    public GameObject purchaseBtn;
    public GameObject purchaseBtnlabel;

    public GameObject NoSelectFriendWindow;
    public GameObject BlockMessageFriendWindow;

    private int gasPrice = 0;
    private int gasPriceNum = 0;
    private int itemNumberF = 0;

    public GameObject[] rescueFriendPicObj; //결과창에 나오는 구출친구 이미지 표시하는 부분.
    string[] rescueFriend;
    public GameObject rescueFriendTab;
    GameObject picObj;
    private string friendUserId;
    private GameObject fuelSendWindow;
    private GameObject friendTab;
    private string RequestUserId;
    Texture fTex;
    int fLength;
    //게임친구탭에 쓰일 변수들만 따로 모음//
    GameFriendTabScript gFrndScript;
    string reinforceS = "Icn_AP";
    string diamondS = "icon_deco";
    string coinS = "icon_gold";
    //게임친구탭에 쓰일 변수들만 따로 모음//

    #endregion Variables
    //바로 위까지는 변수들 선언//
    //바로 위까지는 변수들 선언//
    //바로 위까지는 변수들 선언//
    //바로 위까지는 변수들 선언//


    //가격표의 생성//
    //가격표의 생성//
    //가격표의 생성//
    //가격표의 생성//

    //public void ShowEveryPlay()
    //{
    //    if (ValueDeliverScript.gameEndResult == true && ValueDeliverScript.isHigh == true)
    //    {
    //        GetComponent<HangarPopupController>().AddPopWin(everyPlayWindow, -1);
    //    }
    //    ValueDeliverScript.isHigh = false;
    //}

    private void Awake()
    {
        ValueDeliverScript.resultSkinnumber = resultSkinNumber = ValueDeliverScript.skinNumber;
        //resultSkinName = "FlightDura" + ValueDeliverScript.flightNumber.ToString("D3") + "Skin" + ValueDeliverScript.skinNumber.ToString("D3");

        switch (ValueDeliverScript.flightNumber)
        {
            case 0: switch (ValueDeliverScript.skinNumber)
                {
                    case 1: resultSkinName = ValueDeliverScript.FlightDura000Skin001; break;
                    case 2: resultSkinName = ValueDeliverScript.FlightDura000Skin002; break;
                    case 3: resultSkinName = ValueDeliverScript.FlightDura000Skin003; break;
                    case 4: resultSkinName = ValueDeliverScript.FlightDura000Skin004; break;
                    case 5: resultSkinName = ValueDeliverScript.FlightDura000Skin005; break;
                } break;
            case 1: switch (ValueDeliverScript.skinNumber)
                {
                    case 1: resultSkinName = ValueDeliverScript.FlightDura001Skin001; break;
                    case 2: resultSkinName = ValueDeliverScript.FlightDura001Skin002; break;
                    case 3: resultSkinName = ValueDeliverScript.FlightDura001Skin003; break;
                    case 4: resultSkinName = ValueDeliverScript.FlightDura001Skin004; break;
                    case 5: resultSkinName = ValueDeliverScript.FlightDura001Skin005; break;
                } break;
            case 2: switch (ValueDeliverScript.skinNumber)
                {
                    case 1: resultSkinName = ValueDeliverScript.FlightDura002Skin001; break;
                    case 2: resultSkinName = ValueDeliverScript.FlightDura002Skin002; break;
                    case 3: resultSkinName = ValueDeliverScript.FlightDura002Skin003; break;
                    case 4: resultSkinName = ValueDeliverScript.FlightDura002Skin004; break;
                    case 5: resultSkinName = ValueDeliverScript.FlightDura002Skin005; break;
                } break;
        }

        gameEndResult = ValueDeliverScript.gameEndResult;
        everyPlayWindow.gameObject.SetActive(false);
        if (gameEndResult == true)  // 결과창 사운드 결과창 사운드인지 일반 싸운드 인지 결정하는 부분.
        {
            if (ValueDeliverScript.bgSound == 0.5f)
            {
                GameObject.Find("ResultSoundManager").GetComponent<AudioSource>().volume = 1f;
                GameObject.Find("BgSoundManager").GetComponent<AudioSource>().volume = 0f;
            }

            if (ValueDeliverScript.isHigh == true)
            {
                GetComponent<HangarPopupController>().AddPopWin(everyPlayWindow, -1);
            }
        }

        Time.timeScale = 1f;

        winMove = GameObject.Find("WinMove");
        windows = GameObject.Find("Windows");

        #region 스페셜 출격 관련 비행기 처치 수 서버에서 가져옴.

        specialDart = ValueDeliverScript.specialDart;
        specialSpinball = ValueDeliverScript.specialSpinball;
        specialDust = ValueDeliverScript.specialDust;
        specialSeed = ValueDeliverScript.specialSeed;

        #endregion 스페셜 출격 관련 비행기 처치 수 서버에서 가져옴.

        #region 각종 창들 안보이게 액티브 끔.

        halfBLKPanel.SetActive(false);
        soundControlWindow.SetActive(false);
        allBuyWindow.SetActive(false);
        pilotLevelUpWindow.SetActive(false);

        storeWindow.SetActive(false);
        friendWindow.SetActive(false);
        gasShortageWindow.SetActive(false);

        purchaseConfirmWindow.SetActive(false);
        duraBuyAlarmWindow.SetActive(false);

        spIcon01.SetActive(false);
        spIcon02.SetActive(false);

        specialRestTimeLabel01.SetActive(false);

        #endregion 각종 창들 안보이게 액티브 끔.

        #region 스킨 잠금 해제 가격 세팅.해쉬테이블에 오브젝트(변수) 생성.

        if (!ValueDeliverScript.isSkinMedalCostLoad)
        {
            ValueDeliverScript.skinMedalCost.Add("Flight000Skin001", 10000);
            ValueDeliverScript.skinMedalCost.Add("Flight000Skin002", 15000);
            ValueDeliverScript.skinMedalCost.Add("Flight000Skin003", 25000);
            ValueDeliverScript.skinMedalCost.Add("Flight000Skin004", 45);
            ValueDeliverScript.skinMedalCost.Add("Flight000Skin005", 35000);

            ValueDeliverScript.skinMedalCost.Add("Flight001Skin001", 22000);
            ValueDeliverScript.skinMedalCost.Add("Flight001Skin002", 37000);
            ValueDeliverScript.skinMedalCost.Add("Flight001Skin003", 47000);
            ValueDeliverScript.skinMedalCost.Add("Flight001Skin004", 80);
            ValueDeliverScript.skinMedalCost.Add("Flight001Skin005", 57000);

            ValueDeliverScript.skinMedalCost.Add("Flight002Skin001", 35000);
            ValueDeliverScript.skinMedalCost.Add("Flight002Skin002", 50000);
            ValueDeliverScript.skinMedalCost.Add("Flight002Skin003", 80000);
            ValueDeliverScript.skinMedalCost.Add("Flight002Skin004", 120);
            ValueDeliverScript.skinMedalCost.Add("Flight002Skin005", 150000);

            ValueDeliverScript.isSkinMedalCostLoad = true;
        }

        #endregion 스킨 잠금 해제 가격 세팅.해쉬테이블에 오브젝트(변수) 생성.

        #region 내구도가격 ::: 스킨,레벨별 세팅.해쉬테이블에 오브젝트(변수) 생성.

        if (!ValueDeliverScript.isDuraCostLoad)
        {
            ValueDeliverScript.duraCost.Add("Flight000Skin001Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight000Skin001Level002", 400);
            ValueDeliverScript.duraCost.Add("Flight000Skin001Level003", 500);
            ValueDeliverScript.duraCost.Add("Flight000Skin001Level004", 600);
            ValueDeliverScript.duraCost.Add("Flight000Skin001Level005", 700);
            ValueDeliverScript.duraCost.Add("Flight000Skin001Level006", 800);
            ValueDeliverScript.duraCost.Add("Flight000Skin001Level007", 900);
            ValueDeliverScript.duraCost.Add("Flight000Skin001Level008", 1000);
            ValueDeliverScript.duraCost.Add("Flight000Skin001Level009", 1100);
            ValueDeliverScript.duraCost.Add("Flight000Skin001Level010", 1200);

            ValueDeliverScript.duraCost.Add("Flight000Skin002Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight000Skin002Level002", 400);
            ValueDeliverScript.duraCost.Add("Flight000Skin002Level003", 500);
            ValueDeliverScript.duraCost.Add("Flight000Skin002Level004", 600);
            ValueDeliverScript.duraCost.Add("Flight000Skin002Level005", 700);
            ValueDeliverScript.duraCost.Add("Flight000Skin002Level006", 800);
            ValueDeliverScript.duraCost.Add("Flight000Skin002Level007", 900);
            ValueDeliverScript.duraCost.Add("Flight000Skin002Level008", 1000);
            ValueDeliverScript.duraCost.Add("Flight000Skin002Level009", 1100);
            ValueDeliverScript.duraCost.Add("Flight000Skin002Level010", 1200);

            ValueDeliverScript.duraCost.Add("Flight000Skin003Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight000Skin003Level002", 400);
            ValueDeliverScript.duraCost.Add("Flight000Skin003Level003", 500);
            ValueDeliverScript.duraCost.Add("Flight000Skin003Level004", 600);
            ValueDeliverScript.duraCost.Add("Flight000Skin003Level005", 700);
            ValueDeliverScript.duraCost.Add("Flight000Skin003Level006", 800);
            ValueDeliverScript.duraCost.Add("Flight000Skin003Level007", 900);
            ValueDeliverScript.duraCost.Add("Flight000Skin003Level008", 1000);
            ValueDeliverScript.duraCost.Add("Flight000Skin003Level009", 1100);
            ValueDeliverScript.duraCost.Add("Flight000Skin003Level010", 1200);

            ValueDeliverScript.duraCost.Add("Flight000Skin004Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight000Skin004Level002", 400);
            ValueDeliverScript.duraCost.Add("Flight000Skin004Level003", 500);
            ValueDeliverScript.duraCost.Add("Flight000Skin004Level004", 600);
            ValueDeliverScript.duraCost.Add("Flight000Skin004Level005", 700);
            ValueDeliverScript.duraCost.Add("Flight000Skin004Level006", 800);
            ValueDeliverScript.duraCost.Add("Flight000Skin004Level007", 900);
            ValueDeliverScript.duraCost.Add("Flight000Skin004Level008", 1000);
            ValueDeliverScript.duraCost.Add("Flight000Skin004Level009", 1100);
            ValueDeliverScript.duraCost.Add("Flight000Skin004Level010", 1200);

            ValueDeliverScript.duraCost.Add("Flight000Skin005Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight000Skin005Level002", 400);
            ValueDeliverScript.duraCost.Add("Flight000Skin005Level003", 500);
            ValueDeliverScript.duraCost.Add("Flight000Skin005Level004", 600);
            ValueDeliverScript.duraCost.Add("Flight000Skin005Level005", 700);
            ValueDeliverScript.duraCost.Add("Flight000Skin005Level006", 800);
            ValueDeliverScript.duraCost.Add("Flight000Skin005Level007", 900);
            ValueDeliverScript.duraCost.Add("Flight000Skin005Level008", 1000);
            ValueDeliverScript.duraCost.Add("Flight000Skin005Level009", 1100);
            ValueDeliverScript.duraCost.Add("Flight000Skin005Level010", 1200);

            ValueDeliverScript.duraCost.Add("Flight001Skin001Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight001Skin001Level002", 450);
            ValueDeliverScript.duraCost.Add("Flight001Skin001Level003", 600);
            ValueDeliverScript.duraCost.Add("Flight001Skin001Level004", 750);
            ValueDeliverScript.duraCost.Add("Flight001Skin001Level005", 900);
            ValueDeliverScript.duraCost.Add("Flight001Skin001Level006", 1050);
            ValueDeliverScript.duraCost.Add("Flight001Skin001Level007", 1200);
            ValueDeliverScript.duraCost.Add("Flight001Skin001Level008", 1350);
            ValueDeliverScript.duraCost.Add("Flight001Skin001Level009", 1500);
            ValueDeliverScript.duraCost.Add("Flight001Skin001Level010", 1650);
            ValueDeliverScript.duraCost.Add("Flight001Skin002Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight001Skin002Level002", 450);
            ValueDeliverScript.duraCost.Add("Flight001Skin002Level003", 600);
            ValueDeliverScript.duraCost.Add("Flight001Skin002Level004", 750);
            ValueDeliverScript.duraCost.Add("Flight001Skin002Level005", 900);
            ValueDeliverScript.duraCost.Add("Flight001Skin002Level006", 1050);
            ValueDeliverScript.duraCost.Add("Flight001Skin002Level007", 1200);
            ValueDeliverScript.duraCost.Add("Flight001Skin002Level008", 1350);
            ValueDeliverScript.duraCost.Add("Flight001Skin002Level009", 1500);
            ValueDeliverScript.duraCost.Add("Flight001Skin002Level010", 1650);

            ValueDeliverScript.duraCost.Add("Flight001Skin003Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight001Skin003Level002", 450);
            ValueDeliverScript.duraCost.Add("Flight001Skin003Level003", 600);
            ValueDeliverScript.duraCost.Add("Flight001Skin003Level004", 750);
            ValueDeliverScript.duraCost.Add("Flight001Skin003Level005", 900);
            ValueDeliverScript.duraCost.Add("Flight001Skin003Level006", 1050);
            ValueDeliverScript.duraCost.Add("Flight001Skin003Level007", 1200);
            ValueDeliverScript.duraCost.Add("Flight001Skin003Level008", 1350);
            ValueDeliverScript.duraCost.Add("Flight001Skin003Level009", 1500);
            ValueDeliverScript.duraCost.Add("Flight001Skin003Level010", 1650);

            ValueDeliverScript.duraCost.Add("Flight001Skin004Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight001Skin004Level002", 450);
            ValueDeliverScript.duraCost.Add("Flight001Skin004Level003", 600);
            ValueDeliverScript.duraCost.Add("Flight001Skin004Level004", 750);
            ValueDeliverScript.duraCost.Add("Flight001Skin004Level005", 900);
            ValueDeliverScript.duraCost.Add("Flight001Skin004Level006", 1050);
            ValueDeliverScript.duraCost.Add("Flight001Skin004Level007", 1200);
            ValueDeliverScript.duraCost.Add("Flight001Skin004Level008", 1350);
            ValueDeliverScript.duraCost.Add("Flight001Skin004Level009", 1500);
            ValueDeliverScript.duraCost.Add("Flight001Skin004Level010", 1650);

            ValueDeliverScript.duraCost.Add("Flight001Skin005Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight001Skin005Level002", 450);
            ValueDeliverScript.duraCost.Add("Flight001Skin005Level003", 600);
            ValueDeliverScript.duraCost.Add("Flight001Skin005Level004", 750);
            ValueDeliverScript.duraCost.Add("Flight001Skin005Level005", 900);
            ValueDeliverScript.duraCost.Add("Flight001Skin005Level006", 1050);
            ValueDeliverScript.duraCost.Add("Flight001Skin005Level007", 1200);
            ValueDeliverScript.duraCost.Add("Flight001Skin005Level008", 1350);
            ValueDeliverScript.duraCost.Add("Flight001Skin005Level009", 1500);
            ValueDeliverScript.duraCost.Add("Flight001Skin005Level010", 1650);

            ValueDeliverScript.duraCost.Add("Flight002Skin001Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight002Skin001Level002", 500);
            ValueDeliverScript.duraCost.Add("Flight002Skin001Level003", 700);
            ValueDeliverScript.duraCost.Add("Flight002Skin001Level004", 900);
            ValueDeliverScript.duraCost.Add("Flight002Skin001Level005", 1100);
            ValueDeliverScript.duraCost.Add("Flight002Skin001Level006", 1300);
            ValueDeliverScript.duraCost.Add("Flight002Skin001Level007", 1500);
            ValueDeliverScript.duraCost.Add("Flight002Skin001Level008", 1700);
            ValueDeliverScript.duraCost.Add("Flight002Skin001Level009", 1900);
            ValueDeliverScript.duraCost.Add("Flight002Skin001Level010", 2100);

            ValueDeliverScript.duraCost.Add("Flight002Skin002Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight002Skin002Level002", 500);
            ValueDeliverScript.duraCost.Add("Flight002Skin002Level003", 700);
            ValueDeliverScript.duraCost.Add("Flight002Skin002Level004", 900);
            ValueDeliverScript.duraCost.Add("Flight002Skin002Level005", 1100);
            ValueDeliverScript.duraCost.Add("Flight002Skin002Level006", 1300);
            ValueDeliverScript.duraCost.Add("Flight002Skin002Level007", 1500);
            ValueDeliverScript.duraCost.Add("Flight002Skin002Level008", 1700);
            ValueDeliverScript.duraCost.Add("Flight002Skin002Level009", 1900);
            ValueDeliverScript.duraCost.Add("Flight002Skin002Level010", 2100);

            ValueDeliverScript.duraCost.Add("Flight002Skin003Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight002Skin003Level002", 500);
            ValueDeliverScript.duraCost.Add("Flight002Skin003Level003", 700);
            ValueDeliverScript.duraCost.Add("Flight002Skin003Level004", 900);
            ValueDeliverScript.duraCost.Add("Flight002Skin003Level005", 1100);
            ValueDeliverScript.duraCost.Add("Flight002Skin003Level006", 1300);
            ValueDeliverScript.duraCost.Add("Flight002Skin003Level007", 1500);
            ValueDeliverScript.duraCost.Add("Flight002Skin003Level008", 1700);
            ValueDeliverScript.duraCost.Add("Flight002Skin003Level009", 1900);
            ValueDeliverScript.duraCost.Add("Flight002Skin003Level010", 2100);

            ValueDeliverScript.duraCost.Add("Flight002Skin004Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight002Skin004Level002", 500);
            ValueDeliverScript.duraCost.Add("Flight002Skin004Level003", 700);
            ValueDeliverScript.duraCost.Add("Flight002Skin004Level004", 900);
            ValueDeliverScript.duraCost.Add("Flight002Skin004Level005", 1100);
            ValueDeliverScript.duraCost.Add("Flight002Skin004Level006", 1300);
            ValueDeliverScript.duraCost.Add("Flight002Skin004Level007", 1500);
            ValueDeliverScript.duraCost.Add("Flight002Skin004Level008", 1700);
            ValueDeliverScript.duraCost.Add("Flight002Skin004Level009", 1900);
            ValueDeliverScript.duraCost.Add("Flight002Skin004Level010", 2100);

            ValueDeliverScript.duraCost.Add("Flight002Skin005Level001", 300);
            ValueDeliverScript.duraCost.Add("Flight002Skin005Level002", 500);
            ValueDeliverScript.duraCost.Add("Flight002Skin005Level003", 700);
            ValueDeliverScript.duraCost.Add("Flight002Skin005Level004", 900);
            ValueDeliverScript.duraCost.Add("Flight002Skin005Level005", 1100);
            ValueDeliverScript.duraCost.Add("Flight002Skin005Level006", 1300);
            ValueDeliverScript.duraCost.Add("Flight002Skin005Level007", 1500);
            ValueDeliverScript.duraCost.Add("Flight002Skin005Level008", 1700);
            ValueDeliverScript.duraCost.Add("Flight002Skin005Level009", 1900);
            ValueDeliverScript.duraCost.Add("Flight002Skin005Level010", 2100);

            ValueDeliverScript.isDuraCostLoad = true;
        }

        #endregion 내구도가격 ::: 스킨,레벨별 세팅.해쉬테이블에 오브젝트(변수) 생성.

        #region 골드구매가격 세팅.해쉬테이블에 오브젝트(변수) 생성.

        if (!ValueDeliverScript.isGoldPriceLoad)
        {
            ValueDeliverScript.goldPrice.Add("GoldPrice001", 10);
            ValueDeliverScript.goldPrice.Add("GoldPrice002", 29);
            ValueDeliverScript.goldPrice.Add("GoldPrice003", 49);
            ValueDeliverScript.goldPrice.Add("GoldPrice004", 79);
            ValueDeliverScript.goldPrice.Add("GoldPrice005", 129);

            ValueDeliverScript.goldPrice.Add("GoldPrice001Num", 7000);
            ValueDeliverScript.goldPrice.Add("GoldPrice002Num", 21000 + 2100);
            ValueDeliverScript.goldPrice.Add("GoldPrice003Num", 35000 + 5300);
            ValueDeliverScript.goldPrice.Add("GoldPrice004Num", 56000 + 11200);
            ValueDeliverScript.goldPrice.Add("GoldPrice005Num", 91000 + 27300);

            ValueDeliverScript.isGoldPriceLoad = true;
        }

        #endregion 골드구매가격 세팅.해쉬테이블에 오브젝트(변수) 생성.

        #region 가스(연료)구매가격 세팅.해쉬테이블에 오브젝트(변수) 생성.

        if (!ValueDeliverScript.isGasPriceLoad)
        {
            ValueDeliverScript.gasPrice.Add("GasPrice001", 5);
            ValueDeliverScript.gasPrice.Add("GasPrice002", 10);
            ValueDeliverScript.gasPrice.Add("GasPrice003", 30);
            ValueDeliverScript.gasPrice.Add("GasPrice004", 50);
            ValueDeliverScript.gasPrice.Add("GasPrice005", 100);

            ValueDeliverScript.gasPrice.Add("GasPrice001Num", 5);
            ValueDeliverScript.gasPrice.Add("GasPrice002Num", 10 + 1);
            ValueDeliverScript.gasPrice.Add("GasPrice003Num", 30 + 5);
            ValueDeliverScript.gasPrice.Add("GasPrice004Num", 50 + 8);
            ValueDeliverScript.gasPrice.Add("GasPrice005Num", 100 + 25);

            ValueDeliverScript.isGasPriceLoad = true;
        }

        #endregion 가스(연료)구매가격 세팅.해쉬테이블에 오브젝트(변수) 생성.

        #region 메달구매가격 세팅.해쉬테이블에 오브젝트(변수) 생성.

        if (!ValueDeliverScript.isMedalPriceLoad)
        {
            ValueDeliverScript.medalPrice.Add("MedalPrice001", 1.99);
            ValueDeliverScript.medalPrice.Add("MedalPrice002", 4.99);
            ValueDeliverScript.medalPrice.Add("MedalPrice003", 9.99);
            ValueDeliverScript.medalPrice.Add("MedalPrice004", 29.99);
            ValueDeliverScript.medalPrice.Add("MedalPrice005", 99.99);

            ValueDeliverScript.medalPrice.Add("MedalPrice001Num", 20);
            ValueDeliverScript.medalPrice.Add("MedalPrice002Num", 50 + 5);
            ValueDeliverScript.medalPrice.Add("MedalPrice003Num", 100 + 15);
            ValueDeliverScript.medalPrice.Add("MedalPrice004Num", 300 + 50);
            ValueDeliverScript.medalPrice.Add("MedalPrice005Num", 1000 + 200);

            ValueDeliverScript.isMedalPriceLoad = true;
        }

        #endregion 메달구매가격 세팅.해쉬테이블에 오브젝트(변수) 생성.

        #region 오퍼레이터 락오프 세팅.해쉬테이블에 오브젝트(변수) 생성.

            ValueDeliverScript.operaterLockOff["Operater000"] = true;
            ValueDeliverScript.operaterLockOff["Operater001"] = false;
            ValueDeliverScript.operaterLockOff["Operater002"] = false;
            ValueDeliverScript.operaterLockOff["Operater003"] = false;

        #endregion 오퍼레이터 락오프 세팅.해쉬테이블에 오브젝트(변수) 생성.

        #region 총알 가격과 스킬 가격을 창에서 제대로 보이게 세팅.

        // 총알 가격과 스킬 가격을 창에서 제대로 보이게 세팅.

        int flight000Bullet = 1;
        int flight001Bullet = 1;
        int flight002Bullet = 1;

        int flight000Skill = 1;
        int flight001Skill = 1;
        int flight002Skill = 1;

        flight000Bullet = ValueDeliverScript.flight000Bullet;
        flight001Bullet = ValueDeliverScript.flight001Bullet;
        flight002Bullet = ValueDeliverScript.flight002Bullet;

        flight000Skill = ValueDeliverScript.flight000Skill;
        flight001Skill = ValueDeliverScript.flight001Skill;
        flight002Skill = ValueDeliverScript.flight002Skill;

        GameObject.Find("FlightTag00/_Tag/BulletUpCost").GetComponent<UILabel>().text = ValueDeliverScript.flight000BulletUpCoin[flight000Bullet + 1].ToString();
        GameObject.Find("FlightTag01/_Tag/BulletUpCost").GetComponent<UILabel>().text = ValueDeliverScript.flight001BulletUpCoin[flight001Bullet + 1].ToString();
        GameObject.Find("FlightTag02/_Tag/BulletUpCost").GetComponent<UILabel>().text = ValueDeliverScript.flight002BulletUpCoin[flight002Bullet + 1].ToString();

        GameObject.Find("FlightTag00/_Tag/SkillUpCost").GetComponent<UILabel>().text = ValueDeliverScript.flight000SkillUpCoin[flight000Skill + 1].ToString();
        GameObject.Find("FlightTag01/_Tag/SkillUpCost").GetComponent<UILabel>().text = ValueDeliverScript.flight001SkillUpCoin[flight001Skill + 1].ToString();
        GameObject.Find("FlightTag02/_Tag/SkillUpCost").GetComponent<UILabel>().text = ValueDeliverScript.flight002SkillUpCoin[flight002Skill + 1].ToString();
        // 총알 가격과 스킬 가격을 창에서 제대로 보이게 세팅.

        #endregion 총알 가격과 스킬 가격을 창에서 제대로 보이게 세팅.
        #region 이큅 아이템 이름과 그에 맞는 스프라이트의 이름을 묶어준다.

        ValueDeliverScript.equipSpriteName.Set("Bomb01", "icon_equip_bomb_big_2");//플라즈마웨이브.
        ValueDeliverScript.equipSpriteName.Set("Bomb02", "");
        ValueDeliverScript.equipSpriteName.Set("Bomb03", "");
        ValueDeliverScript.equipSpriteName.Set("Bomb04", "");
        ValueDeliverScript.equipSpriteName.Set("Bomb05", "icon_equip_bomb_big_6");//블랙홀.
        ValueDeliverScript.equipSpriteName.Set("Bomb06", "");
        ValueDeliverScript.equipSpriteName.Set("Bomb07", "");
        ValueDeliverScript.equipSpriteName.Set("Bomb08", "");
        ValueDeliverScript.equipSpriteName.Set("Bomb09", "");
        ValueDeliverScript.equipSpriteName.Set("Bomb10", "");
        ValueDeliverScript.equipSpriteName.Set("Bomb11", "");
        ValueDeliverScript.equipSpriteName.Set("Bomb12", "");

        ValueDeliverScript.equipSpriteName.Set("Reinforce01", "icon_equip_force_big_1");//싱글증폭기.
        ValueDeliverScript.equipSpriteName.Set("Reinforce02", "icon_equip_force_big_2");//듀얼증폭기.
        ValueDeliverScript.equipSpriteName.Set("Reinforce03", "icon_equip_force_big_3");//스핀볼탐지증폭기.
        ValueDeliverScript.equipSpriteName.Set("Reinforce04", "icon_equip_force_big_4");//다트탐지증폭기.
        ValueDeliverScript.equipSpriteName.Set("Reinforce05", "icon_equip_force_big_5");//더스트탐지증폭기.
        ValueDeliverScript.equipSpriteName.Set("Reinforce06", "icon_equip_force_big_6");//실드탐지증폭기.
        ValueDeliverScript.equipSpriteName.Set("Reinforce07", "icon_equip_force_big_7");//크리티컬엑셀레이터.
        ValueDeliverScript.equipSpriteName.Set("Reinforce08", "icon_equip_boost_big_1");//파이널파워업.
        ValueDeliverScript.equipSpriteName.Set("Reinforce09", "");
        ValueDeliverScript.equipSpriteName.Set("Reinforce10", "");
        ValueDeliverScript.equipSpriteName.Set("Reinforce11", "");
        ValueDeliverScript.equipSpriteName.Set("Reinforce12", "");

        ValueDeliverScript.equipSpriteName.Set("Assist01", "icon_equip_sub_big_1");//보호막.(쉴드)
        ValueDeliverScript.equipSpriteName.Set("Assist02", "icon_equip_sub_big_2");//자석.
        ValueDeliverScript.equipSpriteName.Set("Assist03", "icon_equip_sub_big_3");//빠른핵폭탄.(숏봄)
        ValueDeliverScript.equipSpriteName.Set("Assist04", "icon_equip_sub_big_4");//스킬드레인.(에너지드레인)
        ValueDeliverScript.equipSpriteName.Set("Assist05", "icon_equip_boost_big_7");//더블윙박스.
        ValueDeliverScript.equipSpriteName.Set("Assist06", "icon_equip_boost_big_6");//스트롱웜홀.
        ValueDeliverScript.equipSpriteName.Set("Assist07", "");
        ValueDeliverScript.equipSpriteName.Set("Assist08", "");
        ValueDeliverScript.equipSpriteName.Set("Assist09", "");
        ValueDeliverScript.equipSpriteName.Set("Assist10", "");
        ValueDeliverScript.equipSpriteName.Set("Assist11", "");
        ValueDeliverScript.equipSpriteName.Set("Assist12", "");

        #endregion 이큅 아이템 이름과 그에 맞는 스프라이트의 이름을 묶어준다.

        #region 이큅 아이템 이름과 그에 맞는 아이템의 이름을 묶어준다.

        ValueDeliverScript.equipItemName.Set("Bomb01", "플라즈마웨이브");//플라즈마웨이브.
        ValueDeliverScript.equipItemName.Set("Bomb02", "");
        ValueDeliverScript.equipItemName.Set("Bomb03", "");
        ValueDeliverScript.equipItemName.Set("Bomb04", "");
        ValueDeliverScript.equipItemName.Set("Bomb05", "블랙홀");//블랙홀.
        ValueDeliverScript.equipItemName.Set("Bomb06", "");
        ValueDeliverScript.equipItemName.Set("Bomb07", "");
        ValueDeliverScript.equipItemName.Set("Bomb08", "");
        ValueDeliverScript.equipItemName.Set("Bomb09", "");
        ValueDeliverScript.equipItemName.Set("Bomb10", "");
        ValueDeliverScript.equipItemName.Set("Bomb11", "");
        ValueDeliverScript.equipItemName.Set("Bomb12", "");

        ValueDeliverScript.equipItemName.Set("Reinforce01", "싱글증폭기");//싱글증폭기.
        ValueDeliverScript.equipItemName.Set("Reinforce02", "듀얼증폭기");//듀얼증폭기.
        ValueDeliverScript.equipItemName.Set("Reinforce03", "스핀볼탐지증폭기");//스핀볼탐지증폭기.
        ValueDeliverScript.equipItemName.Set("Reinforce04", "다트탐지증폭기");//다트탐지증폭기.
        ValueDeliverScript.equipItemName.Set("Reinforce05", "더스트탐지증폭기");//더스트탐지증폭기.
        ValueDeliverScript.equipItemName.Set("Reinforce06", "실드탐지증폭기");//실드탐지증폭기.
        ValueDeliverScript.equipItemName.Set("Reinforce07", "크리티컬엑셀레이터");//크리티컬엑셀레이터.
        ValueDeliverScript.equipItemName.Set("Reinforce08", "파이널파워업");//파이널파워업.
        ValueDeliverScript.equipItemName.Set("Reinforce09", "");
        ValueDeliverScript.equipItemName.Set("Reinforce10", "");
        ValueDeliverScript.equipItemName.Set("Reinforce11", "");
        ValueDeliverScript.equipItemName.Set("Reinforce12", "");

        ValueDeliverScript.equipItemName.Set("Assist01", "쉴드");//보호막.(쉴드)
        ValueDeliverScript.equipItemName.Set("Assist02", "자석");//자석.
        ValueDeliverScript.equipItemName.Set("Assist03", "빠른핵폭탄");//빠른핵폭탄.(숏봄)
        ValueDeliverScript.equipItemName.Set("Assist04", "스킬드레인");//스킬드레인.(에너지드레인)
        ValueDeliverScript.equipItemName.Set("Assist05", "더블윙박스");//더블윙박스.
        ValueDeliverScript.equipItemName.Set("Assist06", "스트롱웜홀");//스트롱웜홀.
        ValueDeliverScript.equipItemName.Set("Assist07", "");
        ValueDeliverScript.equipItemName.Set("Assist08", "");
        ValueDeliverScript.equipItemName.Set("Assist09", "");
        ValueDeliverScript.equipItemName.Set("Assist10", "");
        ValueDeliverScript.equipItemName.Set("Assist11", "");
        ValueDeliverScript.equipItemName.Set("Assist12", "");

        #endregion 이큅 아이템 이름과 그에 맞는 아이템의 이름을 묶어준다.

        #region 이큅 아이템 이름과 그에 맞는 아이템의 가격을 묶어준다.

        ValueDeliverScript.equipItemPrice.Set("Bomb01", "500");//플라즈마웨이브.
        ValueDeliverScript.equipItemPrice.Set("Bomb02", "");
        ValueDeliverScript.equipItemPrice.Set("Bomb03", "");
        ValueDeliverScript.equipItemPrice.Set("Bomb04", "");
        ValueDeliverScript.equipItemPrice.Set("Bomb05", "1500");//블랙홀.
        ValueDeliverScript.equipItemPrice.Set("Bomb06", "");
        ValueDeliverScript.equipItemPrice.Set("Bomb07", "");
        ValueDeliverScript.equipItemPrice.Set("Bomb08", "");
        ValueDeliverScript.equipItemPrice.Set("Bomb09", "");
        ValueDeliverScript.equipItemPrice.Set("Bomb10", "");
        ValueDeliverScript.equipItemPrice.Set("Bomb11", "");
        ValueDeliverScript.equipItemPrice.Set("Bomb12", "");

        ValueDeliverScript.equipItemPrice.Set("Reinforce01", "1200");//싱글증폭기.
        ValueDeliverScript.equipItemPrice.Set("Reinforce02", "1500");//듀얼증폭기.
        ValueDeliverScript.equipItemPrice.Set("Reinforce03", "1900");//스핀볼탐지증폭기.
        ValueDeliverScript.equipItemPrice.Set("Reinforce04", "1900");//다트탐지증폭기.
        ValueDeliverScript.equipItemPrice.Set("Reinforce05", "1900");//더스트탐지증폭기.
        ValueDeliverScript.equipItemPrice.Set("Reinforce06", "1900");//실드탐지증폭기.
        ValueDeliverScript.equipItemPrice.Set("Reinforce07", "2500");//크리티컬엑셀레이터.
        ValueDeliverScript.equipItemPrice.Set("Reinforce08", "1200");//파이널파워업.
        ValueDeliverScript.equipItemPrice.Set("Reinforce09", "");
        ValueDeliverScript.equipItemPrice.Set("Reinforce10", "");
        ValueDeliverScript.equipItemPrice.Set("Reinforce11", "");
        ValueDeliverScript.equipItemPrice.Set("Reinforce12", "");

        ValueDeliverScript.equipItemPrice.Set("Assist01", "1500");//보호막.(쉴드)
        ValueDeliverScript.equipItemPrice.Set("Assist02", "900");//자석.
        ValueDeliverScript.equipItemPrice.Set("Assist03", "2500");//빠른핵폭탄.(숏봄)
        ValueDeliverScript.equipItemPrice.Set("Assist04", "2500");//스킬드레인.(에너지드레인)
        ValueDeliverScript.equipItemPrice.Set("Assist05", "3000");//더블윙박스.
        ValueDeliverScript.equipItemPrice.Set("Assist06", "1500");//스트롱웜홀.
        ValueDeliverScript.equipItemPrice.Set("Assist07", "");
        ValueDeliverScript.equipItemPrice.Set("Assist08", "");
        ValueDeliverScript.equipItemPrice.Set("Assist09", "");
        ValueDeliverScript.equipItemPrice.Set("Assist10", "");
        ValueDeliverScript.equipItemPrice.Set("Assist11", "");
        ValueDeliverScript.equipItemPrice.Set("Assist12", "");

        #endregion 이큅 아이템 이름과 그에 맞는 아이템의 가격을 묶어준다.
        if (PlayerPrefs.HasKey("isTutComplete") == false && ValueDeliverScript.userExp == 0)
        {
            PlayerPrefs.SetInt("isTutComplete", 0);
        }
        else
        {
            PlayerPrefs.SetInt("isTutComplete", 2);
        }

        ValueDeliverScript.isTutComplete = PlayerPrefs.GetInt("isTutComplete");


        //인게임을 하고 들어온건지 아닌지 체크하는 변수 값 이 값이 true가 되어야만 결과창이 나오게 세팅이 됨.//
        gameEndResult = ValueDeliverScript.gameEndResult;
        skinFullLevel = new Hashtable();
        //스킨최고레벨 포인트 입력.
        {
            skinFullLevel.Add("Flight000Skin001", F00skinFullLevel[0]);
            skinFullLevel.Add("Flight000Skin002", F00skinFullLevel[1]);
            skinFullLevel.Add("Flight000Skin003", F00skinFullLevel[2]);
            skinFullLevel.Add("Flight000Skin004", F00skinFullLevel[3]);
            skinFullLevel.Add("Flight000Skin005", F00skinFullLevel[4]);
            skinFullLevel.Add("Flight001Skin001", F01skinFullLevel[0]);
            skinFullLevel.Add("Flight001Skin002", F01skinFullLevel[1]);
            skinFullLevel.Add("Flight001Skin003", F01skinFullLevel[2]);
            skinFullLevel.Add("Flight001Skin004", F01skinFullLevel[3]);
            skinFullLevel.Add("Flight001Skin005", F01skinFullLevel[4]);
            skinFullLevel.Add("Flight002Skin001", F02skinFullLevel[0]);
            skinFullLevel.Add("Flight002Skin002", F02skinFullLevel[1]);
            skinFullLevel.Add("Flight002Skin003", F02skinFullLevel[2]);
            skinFullLevel.Add("Flight002Skin004", F02skinFullLevel[3]);
            skinFullLevel.Add("Flight002Skin005", F02skinFullLevel[4]);
        }




        #region 경험치 누적을 통한 코인과 플레이어 레벨, 가스, 메탈의 증가를 계산하는 부분//
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////경험치 누적을 통한 코인과 플레이어 레벨, 가스, 메탈의 증가를 계산하는 부분/////////////

        int userExp = ValueDeliverScript.userExp;
        int userLevel = ValueDeliverScript.userLevel;
        int coinRest = ValueDeliverScript.coinRest;
        int medalRest = ValueDeliverScript.medalRest;
        int gasRest = ValueDeliverScript.gasRest;


        flightExperienceTemp = userExp;
        oldUserLevel = userLevel;

        //현재 나의 레벨이 얼마인지 파악하는 부분.
        for (int i = 0; i < userLevelpoint.Length; i++)
        {
            if (flightExperienceTemp - userLevelpoint[i] < 0)
            {
                ValueDeliverScript.userLevel = i + 1;
                userLevel = i + 1;
                break;
            }
            else if (flightExperienceTemp - userLevelpoint[i] > 0)
            {
                ValueDeliverScript.userLevel = i + 1;
                userLevel = i + 1;
            }
            flightExperienceTemp -= userLevelpoint[i];
        }
        //현재 나의 레벨이 얼마인지 파악하는 부분.


        SkinFullLevelUpCheck(); //스킨의 레벨이 다 차서 더이상 오를수 있는지 아닌지 판별.

        if (gameEndResult && oldUserLevel < userLevel)    //레벨업을 했으면~
        {
            while (oldUserLevel < userLevel)
            {

                //여기 들어오는지 확인할것.

                //Debug.Log("여기에 들어오면 레벨업과 메달(다이아몬드)과 코인을 증가시켜준다.");

                //Debug.Log("증가전 코인 ::: " + coinRest);
                //Debug.Log("증가전 다이아몬드 ::: " + medalRest);

                oldUserLevel++;
                addMedal++;
                addCoin += addCoinPerLevel[oldUserLevel];

                
            }

            Debug.Log("앱리뷰할까? reviewApp 키 있어? " + PlayerPrefs.HasKey("reviewApp"));
            //앱리뷰를 한적이 없으면 3레벨 이후부터 무조건 앱리뷰팝업창이 뜨게 만든다//
            if (userLevel > 2 && PlayerPrefs.HasKey("reviewApp") == false)
            {
                HangarPopupController hpController = GameObject.Find("GameManager").GetComponent<HangarPopupController>();
                hpController.AddPopWin(reviewRequest, 2);
            }

            coinRest += addCoin;
            medalRest += addMedal;
            //Debug.Log("증가후 코인 ::: " + coinRest);
            //Debug.Log("증가후 다이아몬드 ::: " + medalRest);

            GameObject.Find("ResultPanel").GetComponent<ResultEnableScript>().AddMedalFromLevelUp(1);

            //Debug.Log("AddMedalLabel   ::::   " + GameObject.Find("ResultPanel").transform.FindChild("ResultPanelLeft/LevelBox/AddMedalLabel").GetComponent<UILabel>().text);

            if (gasRest < 5)
            {
                GameObject.Find("GameManager").GetComponent<GasTimeScript>().isChangeFuel = true;
                GameObject.Find("GameManager").GetComponent<GasTimeScript>().gasTimeUi.GetComponent<UILabel>().text = "0:00";
                //에너지가 다 찼음을 알려주는 메세지 띄움.
            }

            ValueDeliverScript.coinRest = coinRest;
            ValueDeliverScript.medalRest = medalRest;
            ValueDeliverScript.upgradePoint++;

            //GameObject.Find("GasRestLabel").GetComponent<GasRestLabelScript>().GasRest(5, true);   //입력된 추가 연료 갯수를 화면에 표시하기 위한 함수 호출.
            GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //코인 카운트 변화 업뎃.
            GameObject.Find("GameManager").GetComponent<GasTimeScript>().MedalRecount();
            //레벨업 축하창&보상창 띄움.
            //여기에 보상창을 띄우면 됨.



            Debug.Log(" ::: Before GoToPilotLevelUpWindow ::: ");
            GoToPilotLevelUpWindow();
            //StartCoroutine(HalfBLKPanelShow());

            pilotLevelUpWindow.GetComponent<PilotLevelUpWindowScript>().Activate(addCoin, addMedal);
            pilotLevelUpWindow.transform.localPosition = new Vector3(0, 0, -1100);
            StartCoroutine(TouchFalse());
            //기본 결과창에 레벨업 아이콘을 표시하여 준다..
            GameObject.Find("Windows").transform.FindChild("ResultPanel/ResultPanelLeft/LevelBox/PilotLevel/LevelUpIcon").gameObject.SetActive(true);
            addMedal = 0;
            addCoin = 0;

        }
        else
        {
            if (isSkinFullLevel)   //스킬의 레벨이 올라서 꽉 찾는지 검사해서 꽉 찾으면 보상을 줌.
            {
                ValueDeliverScript.upgradePoint += 2;
                upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 2";
                flightUpointSetScript.RedrawStatePoint();
                ShowUpgradePointWindow();
            }
        }


        //결과창에 유저레벨 표시.

        ResultPanel.transform.FindChild("ResultPanelLeft/LevelBox/PilotLevel/UserLevelLabel").GetComponent<UILabel>().text = userLevel.ToString("00");

        ///////////////경험치 누적을 통한 코인과 플레이어 레벨, 가스, 메탈의 증가를 계산하는 부분/////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion


        StartCoroutine(RescueFriendLoad());   //임시로 친구 구출 인원 표시되도록 만드는것 후에 이와 연결된 함수를 구성해서 연결시켜야함.


    }//Awake 끝.

    private void Start()
    {
        #region 비행기의 락 해제 가격을 제대로 보이게 세팅.//

        int userLevel = 1;

        userLevel = ValueDeliverScript.userLevel;
        Debug.Log("User Level :: " + userLevel + " :: FlightLockOff001 :: " + ValueDeliverScript.FlightLockOff001);
        //Debug.LogError("레벨정보확인 멈춤");

        if (userLevel >= 6 && ValueDeliverScript.FlightLockOff001 <= 1) //코만치 락 해제되어 코인으로 살수 있는 조건.
        {
            ValueDeliverScript.FlightLockOff001 = 1;
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet01/PriceLabel").GetComponent<UILabel>().text = ValueDeliverScript.FlightLockOff001Coin + "";
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet01/CoinIcon").GetComponent<UISprite>().spriteName = "icon_small_gold";
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet01/CoinIcon").GetComponent<UISprite>().MakePixelPerfect();
        }
        else if (userLevel < 6 && ValueDeliverScript.FlightLockOff001 == 0) //코만치 락 해제되어 코인으로 살수 있는 조건.
        {
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet01/PriceLabel").GetComponent<UILabel>().text = ValueDeliverScript.FlightLockOff001Medal + "";
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet01/CoinIcon").GetComponent<UISprite>().spriteName = "icon_deco";
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet01/CoinIcon").GetComponent<UISprite>().MakePixelPerfect();
        }

        if (userLevel >= 12 && ValueDeliverScript.FlightLockOff002 <= 1) //팬텀 락 해제되어 코인으로 살수 있는 조건.
        {
            ValueDeliverScript.FlightLockOff002 = 1;
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet02/PriceLabel").GetComponent<UILabel>().text = ValueDeliverScript.FlightLockOff002Coin + "";
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet02/CoinIcon").GetComponent<UISprite>().spriteName = "icon_small_gold";
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet02/CoinIcon").GetComponent<UISprite>().MakePixelPerfect();
        }
        else if (userLevel < 12 && ValueDeliverScript.FlightLockOff002 == 0)
        {
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet02/PriceLabel").GetComponent<UILabel>().text = ValueDeliverScript.FlightLockOff002Medal + "";
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet02/CoinIcon").GetComponent<UISprite>().spriteName = "icon_deco";
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet02/CoinIcon").GetComponent<UISprite>().MakePixelPerfect();
        }

        #endregion 비행기의 락 해제 가격을 제대로 보이게 세팅.//

        #region //행거시작시 튜토리얼을 시작할지 본 게임을 시작할지 결정하는 부분.

        if (ValueDeliverScript.isTutComplete == 2)
        {
            SpecialAttack1();   // 스페셜 어택 설정과 실행중인지 확인하고 안되어있으면 되도록 만드는 함수.
            SkinWindowClose();  //스킨 관련된 정보를 처음에 제대로 처리를 해서 창에 정보를 심어 제대로 보이게 만드는 함수.
        }

        if (ValueDeliverScript.isTutComplete == 0)
        {
            tutManagerScript.ActivateHanger();
            tutManagerScript.centerBlack.GetComponent<UITexture>().material.SetColor("_TintColor", new Color(0, 0, 0, 1));
            tutManagerScript.centerBlack.SetActive(true);
        }
        else if (ValueDeliverScript.isTutComplete == 1)
        {
            tutManagerScript.ActivateResult();
        }

        #endregion //행거시작시 튜토리얼을 시작할지 본 게임을 시작할지 결정하는 부분.

        ValueDeliverScript.flightWindowPosition = ValueDeliverScript.flightNumber;
        flights.transform.FindChild("MoveTF/FlightsMove").localPosition = new Vector3(ValueDeliverScript.flightNumber * -1000, 0, 0);

        LoadEquip();

        #region 게임 시작하고 처음 보이는 스페셜 어택 정보를 강제로 로딩해서 첫화면에 제대로 보여지게 하기 위해 삽입하는 코드

        Transform specialMessage = prepareReady.transform.FindChild("OperMessage/SpecialMessage");
        specialMessage.FindChild("AttackedUfoText");
        specialMessage.FindChild("AttackWishUfoText");
        specialMessage.FindChild("SpecialAttackIcon");
        specialMessage.FindChild("UfoNameText");

        #endregion 게임 시작하고 처음 보이는 스페셜 어택 정보를 강제로 로딩해서 첫화면에 제대로 보여지게 하기 위해 삽입하는 코드

        EquipStartSetting();
        if (gameEndResult)
        {
            StartCoroutine(FirstResultRoad());  //결과창이 보여지도록 해주는 함수를 호출한다.
        }
        else
        {
            if (pilotLevelUpWindow.activeSelf == true)
            {
                flights.transform.localPosition = new Vector3(-1200, 0, 0);
                prepareReady.transform.FindChild("OperMessage").localPosition = new Vector3(-1200, 0, 0);
                prepareReady.transform.FindChild("PrepareBtn").localPosition = new Vector3(-1200, 0, 0);
                prepareReady.transform.FindChild("RankFriendTF").localPosition = new Vector3(-1200, 0, 0);
            }
            else
            {
                StartCoroutine(FirstLoad());
            }
        }
        gameObject.GetComponent<WhiteFadeScript>().Activate(); // 격납고 시작시 블랙에서 화이트로 페이드인 해줌.
        if (!gameEndResult)
        {
            SkinWindowClose();
        }





        StartCoroutine(FirstSoundPlay());
        #region when Comming In Hanger From InGame, Checking Function about Skin Lock.
        //아래 함수는 게임 시작하면  또는 인게임에서 격납고로 돌아왔을때 스킨 락을 해제 할것이 없는가 체크하는 부분.//단 한번만 실행해야 되니 또 다른 곳에서 실행하지 않게 할것.
        FlightLockOffCheck();
        #endregion

        int userLevelVal = ValueDeliverScript.userLevel;

        int flight000SkinVal = ValueDeliverScript.flight000Skin;
        int flight000BulletVal = ValueDeliverScript.flight000Bullet;
        int flight000SkillVal = ValueDeliverScript.flight000Skill;

        int flight001SkinVal = ValueDeliverScript.flight001Skin;
        int flight001BulletVal = ValueDeliverScript.flight001Bullet;
        int flight001SkillVal = ValueDeliverScript.flight001Skill;

        int flight002SkinVal = ValueDeliverScript.flight002Skin;
        int flight002BulletVal = ValueDeliverScript.flight002Bullet;
        int flight002SkillVal = ValueDeliverScript.flight002Skill;

        userLevelG.GetComponent<UILabel>().text = userLevelVal.ToString("00");

        //지정한 유저 이름(Name)을 표시한다.
        GameObject.Find("NameTag/Name").GetComponent<UILabel>().text = ValueDeliverScript.Nick;

        //유저경험치를 화면내 게이지에 표시하여 준다.
        ResultPanel.transform.FindChild("ResultPanelLeft/LevelBox/PilotLevel/UserLevelGageBar").GetComponent<UIFilledSprite>().fillAmount =    //결과창에 나오는 파일럿 레벨게이지바의 표시를 위해 삽입한 문장.

        userLevelGage.GetComponent<UIFilledSprite>().fillAmount = (float)flightExperienceTemp / userLevelpoint[userLevelVal - 1];

        ResultPanel.transform.FindChild("ResultPanelLeft/LevelBox/PilotLevel/UserLevelGageBarPercentLabel").GetComponent<UILabel>().text =      //결과창에 나오는 파일럿 레벨게이지바 퍼센트의 표시를 위해 삽입한 문장.
        userLevelGageLabel.GetComponent<UILabel>().text = ((int)(((float)flightExperienceTemp / userLevelpoint[userLevelVal - 1]) * 100)).ToString("D2") + "%";

        flight000.renderer.material.mainTexture = flight000Skin[flight000SkinVal];
        flight000Bullet.GetComponent<UISprite>().spriteName = "Bullet00_" + flight000BulletVal.ToString("D3");
        flight000Bullet.GetComponent<UISprite>().MakePixelPerfect();
        //flight000Bullet.transform.localScale = new Vector3(flight000Bullet.transform.localScale.x * 0.4f, flight000Bullet.transform.localScale.y * 0.4f, flight000Bullet.transform.localScale.z);

        string lavelVal;
        if (flight000BulletVal < 15) lavelVal = flight000BulletVal.ToString("D2"); else lavelVal = "MAX";
        flight000BulletLabel.GetComponent<UILabel>().text = lavelVal;
        if (flight000SkillVal < 5) lavelVal = flight000SkillVal.ToString("D2"); else lavelVal = "MAX";
        flight000SkillLabel.GetComponent<UILabel>().text = lavelVal;

        flight001.renderer.material.mainTexture = flight001Skin[flight001SkinVal];
        flight001Bullet.GetComponent<UISprite>().spriteName = "Bullet01_" + flight001BulletVal.ToString("D3");
        flight001Bullet.GetComponent<UISprite>().MakePixelPerfect();
        //flight001Bullet.transform.localScale = new Vector3(flight001Bullet.transform.localScale.x * 0.4f, flight001Bullet.transform.localScale.y * 0.4f, flight001Bullet.transform.localScale.z);

        if (flight001BulletVal < 15) lavelVal = flight001BulletVal.ToString("D2"); else lavelVal = "MAX";
        flight001BulletLabel.GetComponent<UILabel>().text = lavelVal;
        if (flight001SkillVal < 5) lavelVal = flight001SkillVal.ToString("D2"); else lavelVal = "MAX";
        flight001SkillLabel.GetComponent<UILabel>().text = lavelVal;

        flight002.renderer.material.mainTexture = flight002Skin[flight002SkinVal];
        flight002Bullet.GetComponent<UISprite>().spriteName = "Bullet02_" + flight002BulletVal.ToString("D3");
        flight002Bullet.GetComponent<UISprite>().MakePixelPerfect();
        //flight002Bullet.transform.localScale = new Vector3(flight002Bullet.transform.localScale.x * 0.4f, flight002Bullet.transform.localScale.y * 0.4f, flight002Bullet.transform.localScale.z);

        if (flight002BulletVal < 15) lavelVal = flight002BulletVal.ToString("D2"); else lavelVal = "MAX";
        flight002BulletLabel.GetComponent<UILabel>().text = lavelVal;
        if (flight002SkillVal < 5) lavelVal = flight002SkillVal.ToString("D2"); else lavelVal = "MAX";
        flight002SkillLabel.GetComponent<UILabel>().text = lavelVal;

        //기본 비행기 선택창에 선택된 스킨의 이름 표시.

        skinNameTag[0].GetComponent<UILabel>().text = skinSelectWindow00.transform.FindChild("Skin/Skin" + flight000SkinVal.ToString("00")).GetComponent<PositionSkinSendScript>().skinKoreaName;
        skinNameTag[1].GetComponent<UILabel>().text = skinSelectWindow01.transform.FindChild("Skin/Skin" + flight001SkinVal.ToString("00")).GetComponent<PositionSkinSendScript>().skinKoreaName;
        skinNameTag[2].GetComponent<UILabel>().text = skinSelectWindow02.transform.FindChild("Skin/Skin" + flight002SkinVal.ToString("00")).GetComponent<PositionSkinSendScript>().skinKoreaName;
        //기본 비행기 선택창에 선택된 스킨의 이름 표시.

        SkinlockOffCount();//소유 스킨 갯수 표시.

        if (ValueDeliverScript.skinNumber == 0) //디폴트스킨이면 결과창에 스킨 레벨 관련 데이터 안보이게 함.
        {
            GameObject.Find("Windows").transform.FindChild("ResultPanel/ResultPanelLeft/LevelBox/SkinLevel").gameObject.SetActive(false);
        }

        //랭킹 탭 정보 표시
        if (ValueDeliverScript.isTutComplete == 2)
        {
            //Debug.Log("isTutComplete ::: 2");
            //매일 출석 보상
            LoginEvent();

            //랭크 등수 정렬//페이스북 아이디가 있을경우만 친구 랭킹을 표시해준다.
            if (ValueDeliverScript.myFBid != "")
            {
                Debug.Log("::: FaceBook Lank Data");
                Debug.Log("::: FaceBook Lank Data");
                Debug.Log("::: FaceBook Lank Data");
                Debug.Log("FaceBook Lank Data Length:::" + ValueDeliverScript.rankDataFB.Length);
                foreach (var ddd in ValueDeliverScript.rankDataFB)
                {
                    Debug.Log("유저이름 :: " + ddd.NickName);
                    Debug.Log("유저점수 :: " + ddd.BestScore);
                }
                Debug.Log("::: FaceBook Lank Data");

                FriendRankTabSetting(friendData: ValueDeliverScript.rankDataFB, parentT: friendWeekTab.transform, isFB: true);
            }

            //페이스북에 관계 없이 게임의 월드 랭킹을 표시해주기 위한 리더보드 구성.
            FriendRankTabSetting(friendData: ValueDeliverScript.worldRank, parentT: wRankab.transform, isFB: false);
        }

        //받은 메세지 표시//
        MessageTabSetting();
    }


    /////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////

    //여기서부터 일반 메소드들/////////////////////////////////////////////////////////////////////////
    #region 이큅 윈도우들 안에 세팅되어있는 아이템들을 찾아서 목록화시키고 그것들을 유사 스프라이트 이름들을 저장하여 다른곳에서도 쓸 수 있게 만들기 위한부분//

    //행거컨트롤 start에서 불러 들여 행거가 시작될때마다 아이템의 세팅이 제대로 되어있는지 검사하고 정리를 해준다.

    public void LoadEquip()
    {
        int findMountitem = 0; //마운드 아이템은 배열에 저장되지 않게 하기 위해 만들어 놓은 불린 변수.
        int findHighlightItem = 0;
        //이큅내의 각각의 탭에서 아이템의 갯수를 헤아려 배열의 길이를 정한다. 이렇게 하면 앞으로 아이템을 각각 따로 검색하지 않고 배열에서 불러내기만 하면 된다.
        //2를 빼는 것은 아이템박스가 아닌 오브젝트는 배열수에서 제외하기 위함이다.
        GameObject[] equipBombItem = new GameObject[equipBombTab.transform.FindChild("Item").childCount - 2];   //-2를 하는 것은 차일드중에 마우스아이템과 하일라이트 아이템이 있기때문. 이것은 이큅 아이템이 아니다.
        GameObject[] equipReinforceItem = new GameObject[equipReinforceTab.transform.FindChild("Item").childCount - 2];
        GameObject[] equipAssistanceItem = new GameObject[equipAssistanceTab.transform.FindChild("Item").childCount - 2];
        GameObject[] equipOperItem = new GameObject[equipOperTab.transform.FindChild("Item").childCount - 2];

        //Debug.Log("::: Equip collection Lenth :::");
        //Debug.Log("equipBombItem"+equipBombItem.Length);
        //Debug.Log("equipReinforceItem"+equipReinforceItem.Length);
        //Debug.Log("equipAssistanceItem"+equipAssistanceItem.Length);
        //Debug.Log("equipOperItem" + equipOperItem.Length);

        #region 이큅 아이템들을 배열에 넣어서 보관해놓는다. 이렇게 하면 언제든 불러 쓸수 있다.

        for (int i = 0; i < equipBombTab.transform.FindChild("Item").childCount; i++)
        {
            GameObject tempItem = equipBombTab.transform.FindChild("Item").GetChild(i).gameObject;
            //Debug.Log("tempItem ::: " + tempItem.name);

            if (tempItem.name == "MountItem")
            { findMountitem = 1; continue; }

            if (tempItem.name == "HilightItem")
            { findHighlightItem = 1; continue; }

            equipBombItem[i - findMountitem - findHighlightItem] = tempItem;
            //Debug.Log("equipBombItem[" + (i - findMountitem - findHighlightItem) + "] ::: " + equipBombItem[i - findMountitem - findHighlightItem].name);
        }

        findMountitem = 0;
        findHighlightItem = 0;
        for (int i = 0; i < equipReinforceTab.transform.FindChild("Item").childCount; i++)
        {
            GameObject tempItem = equipReinforceTab.transform.FindChild("Item").GetChild(i).gameObject;

            if (tempItem.name == "MountItem")
            { findMountitem = 1; continue; }

            if (tempItem.name == "HilightItem")
            { findHighlightItem = 1; continue; }

            equipReinforceItem[i - findMountitem - findHighlightItem] = tempItem;
        }

        findMountitem = 0;
        findHighlightItem = 0;
        for (int i = 0; i < equipAssistanceTab.transform.FindChild("Item").childCount; i++)
        {
            GameObject tempItem = equipAssistanceTab.transform.FindChild("Item").GetChild(i).gameObject;

            if (tempItem.name == "MountItem")
            { findMountitem = 1; continue; }

            if (tempItem.name == "HilightItem")
            { findHighlightItem = 1; continue; }

            equipAssistanceItem[i - findMountitem - findHighlightItem] = tempItem;
        }

        findMountitem = 0;
        findHighlightItem = 0;
        for (int i = 0; i < equipOperTab.transform.FindChild("Item").childCount; i++)
        {
            //Debug.Log("::: equipOperTab ChildCount is " + equipOperTab.transform.FindChild("Item").childCount + " :::");
            GameObject tempItem = equipOperTab.transform.FindChild("Item").GetChild(i).gameObject;

            if (tempItem.name == "MountItem")
            { findMountitem = 1; continue; }

            if (tempItem.name == "HilightItem")
            { findHighlightItem = 1; continue; }

            equipOperItem[i - findMountitem - findHighlightItem] = tempItem;
        }
        //여기까지해서 아이템박스 오브젝트들을 배열화하여 임시저장.

        #endregion 이큅 아이템들을 배열에 넣어서 보관해놓는다. 이렇게 하면 언제든 불러 쓸수 있다.

        //각각의 이큅 아이템들의 이름을 받아올 준비를 해놓는다. 첫번째 0번은 단순 점 이미지가 들어가야 되기에 배열의 크기를 하나더 크게한다.
        bombSpriteName = new string[equipBombItem.Length + 1];
        reinforceSpriteName = new string[equipReinforceItem.Length + 1];
        assistSpriteName = new string[equipAssistanceItem.Length + 1];
        operSpriteName = new string[equipOperItem.Length + 1];

        //각각의 아이템이름이 들어가는 배열에 첫번째는 비어있다는 뜻으로 쓰일 이미지의 이름을 넣어놓는다.
        bombSpriteName[0] = "base_result_black";
        reinforceSpriteName[0] = "base_result_black";
        assistSpriteName[0] = "base_result_black";
        operSpriteName[0] = "base_result_black";

        //이큅의 각각 탭에서 각각의 아이템들이 이름을 검색해서 스트링 배열에 넣어서 저장해놓는다.
        for (int i = 0; i < equipBombItem.Length; i++)
        {
            //Debug.Log("equipBombItem ::: " + i + " ::: name ::: " + equipBombItem[i].name);
            int itemNumber;
            if (equipBombItem[i].GetComponent<ItemKeyValueScript>())
            {
                itemNumber = equipBombItem[i].GetComponent<ItemKeyValueScript>().itemNumber;
                if (itemNumber > 0)
                {
                    int labelBomb = 0;
                    switch (itemNumber)
                    {
                        case 1: labelBomb = ValueDeliverScript.EquipBomb01; break;
                        case 2: labelBomb = ValueDeliverScript.EquipBomb02; break;
                        case 3: labelBomb = ValueDeliverScript.EquipBomb03; break;
                        case 4: labelBomb = ValueDeliverScript.EquipBomb04; break;
                        case 5: labelBomb = ValueDeliverScript.EquipBomb05; break;
                        case 6: labelBomb = ValueDeliverScript.EquipBomb06; break;
                        case 7: labelBomb = ValueDeliverScript.EquipBomb07; break;
                        case 8: labelBomb = ValueDeliverScript.EquipBomb08; break;
                        case 9: labelBomb = ValueDeliverScript.EquipBomb09; break;
                        case 10: labelBomb = ValueDeliverScript.EquipBomb10; break;
                        case 11: labelBomb = ValueDeliverScript.EquipBomb11; break;
                        case 12: labelBomb = ValueDeliverScript.EquipBomb12; break;
                    }
                    equipBombItem[i].transform.FindChild("Label").GetComponent<UILabel>().text = labelBomb + "";   //구매되어 있는 아이템의 갯수를 입력한다.
                    bombSpriteName[itemNumber] = equipBombItem[i].transform.FindChild("Item").GetComponent<UISprite>().spriteName;
                    ValueDeliverScript.bombSpriteName = bombSpriteName;
                }
            }
        }

        for (int i = 0; i < equipReinforceItem.Length; i++)
        {
            int itemNumber;
            if (equipReinforceItem[i].GetComponent<ItemKeyValueScript>())
            {
                itemNumber = equipReinforceItem[i].GetComponent<ItemKeyValueScript>().itemNumber;
                if (itemNumber > 0)
                {
                    int labelRein = 0;
                    switch (itemNumber)
                    {
                        case 1: labelRein = ValueDeliverScript.EquipReinforce01; break;
                        case 2: labelRein = ValueDeliverScript.EquipReinforce02; break;
                        case 3: labelRein = ValueDeliverScript.EquipReinforce03; break;
                        case 4: labelRein = ValueDeliverScript.EquipReinforce04; break;
                        case 5: labelRein = ValueDeliverScript.EquipReinforce05; break;
                        case 6: labelRein = ValueDeliverScript.EquipReinforce06; break;
                        case 7: labelRein = ValueDeliverScript.EquipReinforce07; break;
                        case 8: labelRein = ValueDeliverScript.EquipReinforce08; break;
                        case 9: labelRein = ValueDeliverScript.EquipReinforce09; break;
                        case 10: labelRein = ValueDeliverScript.EquipReinforce10; break;
                        case 11: labelRein = ValueDeliverScript.EquipReinforce11; break;
                        case 12: labelRein = ValueDeliverScript.EquipReinforce12; break;
                    }
                    equipReinforceItem[i].transform.FindChild("Label").GetComponent<UILabel>().text = labelRein + "";   //구매되어 있는 아이템의 갯수를 입력한다.
                    reinforceSpriteName[itemNumber] = equipReinforceItem[i].transform.FindChild("Item").GetComponent<UISprite>().spriteName;
                    ValueDeliverScript.reinforceSpriteName = reinforceSpriteName;
                }
            }
        }

        for (int i = 0; i < equipAssistanceItem.Length; i++)
        {
            int itemNumber;
            if (equipAssistanceItem[i].GetComponent<ItemKeyValueScript>())
            {
                itemNumber = equipAssistanceItem[i].GetComponent<ItemKeyValueScript>().itemNumber;
                if (itemNumber > 0)
                {
                    int labelAssi = 0;
                    switch (itemNumber)
                    {
                        case 1: labelAssi = ValueDeliverScript.EquipAssist01; break;
                        case 2: labelAssi = ValueDeliverScript.EquipAssist02; break;
                        case 3: labelAssi = ValueDeliverScript.EquipAssist03; break;
                        case 4: labelAssi = ValueDeliverScript.EquipAssist04; break;
                        case 5: labelAssi = ValueDeliverScript.EquipAssist05; break;
                        case 6: labelAssi = ValueDeliverScript.EquipAssist06; break;
                        case 7: labelAssi = ValueDeliverScript.EquipAssist07; break;
                        case 8: labelAssi = ValueDeliverScript.EquipAssist08; break;
                        case 9: labelAssi = ValueDeliverScript.EquipAssist09; break;
                        case 10: labelAssi = ValueDeliverScript.EquipAssist10; break;
                        case 11: labelAssi = ValueDeliverScript.EquipAssist11; break;
                        case 12: labelAssi = ValueDeliverScript.EquipAssist12; break;
                    }

                    equipAssistanceItem[i].transform.FindChild("Label").GetComponent<UILabel>().text = labelAssi + "";   //구매되어 있는 아이템의 갯수를 입력한다.
                    assistSpriteName[itemNumber] = equipAssistanceItem[i].transform.FindChild("Item").GetComponent<UISprite>().spriteName;
                    ValueDeliverScript.assistSpriteName = assistSpriteName;
                }
            }
        }

        for (int i = 0; i < equipOperItem.Length; i++)
        {
            int itemNumber;
            if (equipOperItem[i].GetComponent<ItemKeyValueScript>())
            {
                itemNumber = equipOperItem[i].GetComponent<ItemKeyValueScript>().itemNumber;
                if (itemNumber > 0)
                {
                    int labelOper = 0;
                    switch (itemNumber)
                    {
                        case 1: labelOper = ValueDeliverScript.EquipOper01; break;
                        case 2: labelOper = ValueDeliverScript.EquipOper02; break;
                        case 3: labelOper = ValueDeliverScript.EquipOper03; break;
                        case 4: labelOper = ValueDeliverScript.EquipOper04; break;
                        case 5: labelOper = ValueDeliverScript.EquipOper05; break;
                        case 6: labelOper = ValueDeliverScript.EquipOper06; break;
                        case 7: labelOper = ValueDeliverScript.EquipOper07; break;
                        case 8: labelOper = ValueDeliverScript.EquipOper08; break;
                        case 9: labelOper = ValueDeliverScript.EquipOper09; break;
                        case 10: labelOper = ValueDeliverScript.EquipOper10; break;
                        case 11: labelOper = ValueDeliverScript.EquipOper11; break;
                        case 12: labelOper = ValueDeliverScript.EquipOper12; break;
                    }

                    equipOperItem[i].transform.FindChild("Label").GetComponent<UILabel>().text = labelOper + "";  //구매되어 있는 아이템의 갯수를 입력한다.
                    operSpriteName[itemNumber] = equipOperItem[i].transform.FindChild("Item").GetComponent<UISprite>().spriteName;
                    ValueDeliverScript.operSpriteName = operSpriteName;
                }
            }
        }
        //이큅의 각각 탭에서 각각의 아이템들이 이름을 검색해서 스트링 배열에 넣어서 저장해놓는다.
    }

    //LoadEquip()의 마지막

    #endregion 이큅 윈도우들 안에 세팅되어있는 아이템들을 찾아서 목록화시키고 그것들을 유사 스프라이트 이름들을 저장하여 다른곳에서도 쓸 수 있게 만들기 위한부분//


    private IEnumerator ResultPanelShowAll()
    {
        ResultPanel.transform.FindChild("ResultPanelRight").animation.Play("ResultPanelRightAnim01");
        ResultPanel.transform.FindChild("ResultPanelLeft").animation.Play("ResultPanelLeftAnim02");

        yield return new WaitForSeconds(0.5f);
        ResultPanel.transform.FindChild("ResultLowTab").animation.Play("ResultLowTabAnim01");
        yield return new WaitForSeconds(ResultPanel.transform.FindChild("ResultLowTab").animation["ResultLowTabAnim01"].clip.length);
        isRLowTabAnim = true;
    }

    private IEnumerator FirstResultRoad()
    {
        bgTop.animation.Play("BGMainTopAnim01");
        bgBottom.animation.Play("BGMainBottomAnim01");
        yield return new WaitForSeconds(1f);

        flights.transform.localPosition = new Vector3(-1200, 0, 0);
        ResultPanel.transform.FindChild("ResultPanelLeft").localPosition = new Vector3(-850, 0, 6);
        ResultPanel.transform.FindChild("ResultPanelLeft").animation.Play("ResultPanelLeftAnim01");
        yield return new WaitForSeconds(0.5f);

        if (pilotLevelUpWindow.activeSelf == false)
            StartCoroutine(ResultPanelShowAll());
        else
            noTouchPanel.SetActive(false);
    }

    private IEnumerator FirstLoad() //처음 실행했을때 비행기의 위치를 이전 마지막 선택된 비행기 위치로 바꾸어줌.
    {
        bgTop.animation.Play("BGMainTopAnim01");

        bgBottom.animation.Play("BGMainBottomAnim01");
        yield return new WaitForSeconds(1f);

        flights.animation.Play("FlightsPanelAnim01");

        prepareReady.transform.FindChild("RankFriendTF").gameObject.SetActive(true);
        Debug.Log("PrepareReadyAnim01");

        //메세지 유무 여부에 따라 깜박이 보이게 할지 안보이게 할지 결정//
        if (ValueDeliverScript.messageData.Length != 0) GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(true);
        else GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(false);

        prepareReady.animation.Play("PrepareReadyAnim01");
        flights.transform.FindChild("MoveTF/FlightsMove").localPosition = new Vector3(ValueDeliverScript.flightNumber * -1000, 0, 0);
        GameObject.Find("FlightLock/FlightLockMove").transform.localPosition = flights.transform.FindChild("MoveTF/FlightsMove").localPosition;

        //선택된 비행기가 락이 걸려있는지 여부를 알아보고 락이 걸려있으면 락 걸려있음을 표시.

        if (ValueDeliverScript.flightNumber != 0)
        {
            int flightLock = 0;
            switch (ValueDeliverScript.flightWindowPosition)
            {
                case 0: flightLock = ValueDeliverScript.FlightLockOff000; break;
                case 1: flightLock = ValueDeliverScript.FlightLockOff001; break;
                case 2: flightLock = ValueDeliverScript.FlightLockOff002; break;
            }

            if (flightLock == 2)
            {
                GameObject.Find("MoveTF").GetComponent<UIPanel>().alpha = 1f;
                GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet" + ValueDeliverScript.flightNumber.ToString("00")).gameObject.SetActive(false);
            }
            else if (flightLock != 2)
            {
                GameObject.Find("MoveTF").GetComponent<UIPanel>().alpha = 0.5f;
                GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet" + ValueDeliverScript.flightNumber.ToString("00")).gameObject.SetActive(true);
            }
        }
    }

    private void SpecialAttack1()
    {
        if (ValueDeliverScript.isTutComplete != 2) return;        // 아직 튜토리얼이 끝나지 않았으면 스페셜 어택 관련된 것을 실행하지 않는다.

        //미션이 완성된 기록이 있는가 먼저 검사한다.201년 3월 12일 코딩중 중단. 3월 13일 아침에 와서 해결할것. 어떤 변수가 미션 완료를 기록하는 것인지 먼저 찾아야 됨.
        //유니티 최신 버전으로 업데이트 할것. 현 프로젝트는 백업.

        int isSpecialAttackMissionSelect = 1;

        isSpecialAttackMissionSelect = ValueDeliverScript.isSpecialAttackMissionSelect;

        if (ValueDeliverScript.isSpecialAttackComplete == 0 && isSpecialAttackMissionSelect == 0)    //스페셜 어택 미션 컴플릿도 안되어있고 스페셜 어택 미션이 발동이 안되어있으면~
        {
            int rndVal = UnityEngine.Random.Range(0, 400);              //스페셜 어택 미션 랜덤 선택.
            if (rndVal < 100)
                ValueDeliverScript.specialAttackType = 0;       //specialSpinball
            else if (rndVal < 200)
                ValueDeliverScript.specialAttackType = 1;       //specialDart
            else if (rndVal < 300)
                ValueDeliverScript.specialAttackType = 2;       //specialDust
            else
                ValueDeliverScript.specialAttackType = 3;       //specialShield
            ValueDeliverScript.isSpecialAttackMissionSelect = 1;      //스페셜 어택이 발동되었음을 기록함.
        }

        if (ValueDeliverScript.isSpecialAttackComplete == 0)             // 스페셜 어택 미션을 아직 달성하지 못했으면~ 여기는
        {
            SpecialAttackNotComplete();                               //스페셜 어택2 함수를 실행함.
        }
        else if (ValueDeliverScript.isSpecialAttackComplete == 1)             // 이미 스페셜 어택 미션을 컴플릿 했으면... 지금 막 게임에서 돌아와서 검사할때는 기본이 무조건 낫 컴플릿이기 때문에 이곳으로 오질 못함.
        {
            GameObject.Find("SpecialAttackInfo").transform.localScale = new Vector3(1, 0, 1);   //스페셜 어택 기본 정보를 스케일을 줄여서 안보이게 처리
            GameObject.Find("SpecialInfo/SpecialAttackOn").transform.localScale = new Vector3(1, 1, 1);   //스페셜 어택 발동 문자 스케일 키워서 표시.

            GameObject.Find("SpecialAttackOnText").transform.localScale = new Vector3(31, 31, 1);   //스페셜 어택 발동 문자 스케일 키워서 표시.
            GameObject.Find("GameSpecialStart").transform.localPosition = new Vector3(389, -281, 0);
            GameObject.Find("ResultLowTab/AttackBtn/GameStart").GetComponent<UISprite>().enabled = false;

            GameObject.Find("PrepareBtn/GameStart").GetComponent<UISprite>().spriteName = "Btn_SpecialGameReady_00";
            GameObject.Find("PrepareBtn/GameStart").GetComponent<UIImageButton>().normalSprite = "Btn_SpecialGameReady_00";
            GameObject.Find("PrepareBtn/GameStart").GetComponent<UIImageButton>().hoverSprite = "Btn_SpecialGameReady_00";
            GameObject.Find("PrepareBtn/GameStart").GetComponent<UIImageButton>().pressedSprite = "Btn_SpecialGameReady_01";

            GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UISprite>().spriteName = "Btn_SpecialGame_00";
            GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().normalSprite = "Btn_SpecialGame_00";
            GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().hoverSprite = "Btn_SpecialGame_00";
            GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().pressedSprite = "Btn_SpecialGame_01";

            int tempIconNum = 0;

            int specialAttackType = ValueDeliverScript.specialAttackType;

            switch (specialAttackType)
            {
                case 0:
                    tempIconNum = 1;
                    break;

                case 1:
                    tempIconNum = 3;
                    break;

                case 2:
                    tempIconNum = 2;
                    break;

                case 3:
                    tempIconNum = 4;
                    break;
            }
            for (int i = 0; i < specialAttackIcon.Length; i++)                   //이부분에서 아이콘을 표시하여준다. 에어로게이트 아틀라스 사용.
            {
                specialAttackIcon[i].GetComponent<UISprite>().spriteName = "item_icon" + tempIconNum;
                specialAttackIcon[i].GetComponent<UISprite>().MakePixelPerfect();

                ValueDeliverScript.specialAttackItemName = "item_icon" + tempIconNum;
            }

            StartCoroutine(SpecialAttackTime());        //스페셜 어택 미션을 달성했으면 바로 시간을 재는 함수를 실행함.
        }
        //ValueDeliverScript.SaveGameData();
    }

    private void SpecialAttackNotComplete()
    {
        int spinballCount = ValueDeliverScript.spinballCount;
        int isSpecialAttackComplete = ValueDeliverScript.isSpecialAttackComplete;

        int dartCount = ValueDeliverScript.dartCount;
        int dustCount = ValueDeliverScript.dustCount;
        int shieldCount = ValueDeliverScript.shieldCount;

        switch (ValueDeliverScript.specialAttackType)
        {
            case 0:
                if (spinballCount >= specialSpinball)             //현재 잡은 스핀볼이 제시기준보다 더 많으면~
                {
                    ValueDeliverScript.specialAttackItemMaxNumber = specialSpinball;
                    ValueDeliverScript.spinballCount = specialSpinball;              //잡은 스핀볼을 제시기준하고 똑같은 수치로 먼저 변환.
                    ResultSpecialAttackOnAnimation();

                    if (isSpecialAttackComplete == 0)
                    {
                        ValueDeliverScript.isSpecialAttackComplete = 1;                       //스페셜 어택 미션을 달성했음을 기록.
                        SpecialAttackTimeSet(ValueDeliverScript.specialAttackAddTime);   //스페셜 어택 유지 시간을 정하기 위해 함수를 호출.
                    }
                }

                for (int i = 0; i < specialAttackIcon.Length; i++)                   //이부분에서 아이콘을 표시하여준다.
                {
                    specialAttackIcon[i].GetComponent<UISprite>().spriteName = "item_icon1";
                    specialAttackIcon[i].GetComponent<UISprite>().MakePixelPerfect();
                    ValueDeliverScript.specialAttackItemName = "item_icon1";
                }
                specialAttackText[0].GetComponent<UILabel>().text = "/ " + specialSpinball;
                specialAttackText[1].GetComponent<UILabel>().text = specialAttackName[0];
                specialAttackText[2].GetComponent<UILabel>().text = ValueDeliverScript.spinballCount + "";
                specialAttackText[3].GetComponent<UILabel>().text = "/ " + specialSpinball;
                specialAttackText[4].GetComponent<UILabel>().text = ValueDeliverScript.spinballCount + "";

                specialAttackText[5].GetComponent<UILabel>().text = specialAttackName[0];
                specialAttackText[6].GetComponent<UILabel>().text = ValueDeliverScript.spinballCount + "";
                specialAttackText[7].GetComponent<UILabel>().text = "/ " + specialSpinball;

                break;

            case 1:
                if (dartCount >= specialDart)
                {
                    ValueDeliverScript.specialAttackItemMaxNumber = specialDart;
                    ValueDeliverScript.dartCount = specialDart;
                    ResultSpecialAttackOnAnimation();

                    if (isSpecialAttackComplete == 0)
                    {
                        ValueDeliverScript.isSpecialAttackComplete = 1;                       //스페셜 어택 미션을 달성했음을 기록.
                        SpecialAttackTimeSet(ValueDeliverScript.specialAttackAddTime);   //스페셜 어택 유지 시간을 정하기 위해 함수를 호출.
                    }
                }

                for (int i = 0; i < specialAttackIcon.Length; i++)
                {
                    specialAttackIcon[i].GetComponent<UISprite>().spriteName = "item_icon3";
                    specialAttackIcon[i].GetComponent<UISprite>().MakePixelPerfect();
                    ValueDeliverScript.specialAttackItemName = "item_icon3";
                }
                specialAttackText[0].GetComponent<UILabel>().text = "/ " + specialDart;
                specialAttackText[1].GetComponent<UILabel>().text = specialAttackName[1];
                specialAttackText[2].GetComponent<UILabel>().text = ValueDeliverScript.dartCount.ToString();
                specialAttackText[3].GetComponent<UILabel>().text = "/ " + specialDart;
                specialAttackText[4].GetComponent<UILabel>().text = ValueDeliverScript.dartCount.ToString();

                specialAttackText[5].GetComponent<UILabel>().text = specialAttackName[1];
                specialAttackText[6].GetComponent<UILabel>().text = ValueDeliverScript.dartCount.ToString();
                specialAttackText[7].GetComponent<UILabel>().text = "/ " + specialDart;

                break;

            case 2:
                if (dustCount >= specialDust)
                {
                    ValueDeliverScript.specialAttackItemMaxNumber = specialDust;
                    ValueDeliverScript.dustCount = specialDust;
                    ResultSpecialAttackOnAnimation();

                    if (isSpecialAttackComplete == 0)
                    {
                        ValueDeliverScript.isSpecialAttackComplete = 1;                       //스페셜 어택 미션을 달성했음을 기록.
                        SpecialAttackTimeSet(ValueDeliverScript.specialAttackAddTime);   //스페셜 어택 유지 시간을 정하기 위해 함수를 호출.
                    }
                }

                for (int i = 0; i < specialAttackIcon.Length; i++)
                {
                    specialAttackIcon[i].GetComponent<UISprite>().spriteName = "item_icon2";
                    specialAttackIcon[i].GetComponent<UISprite>().MakePixelPerfect();
                    ValueDeliverScript.specialAttackItemName = "item_icon2";
                }
                specialAttackText[0].GetComponent<UILabel>().text = "/ " + specialDust;
                specialAttackText[1].GetComponent<UILabel>().text = specialAttackName[2];
                specialAttackText[2].GetComponent<UILabel>().text = ValueDeliverScript.dustCount.ToString();
                specialAttackText[3].GetComponent<UILabel>().text = "/ " + specialDust;
                specialAttackText[4].GetComponent<UILabel>().text = ValueDeliverScript.dustCount.ToString();

                specialAttackText[5].GetComponent<UILabel>().text = specialAttackName[2];
                specialAttackText[6].GetComponent<UILabel>().text = ValueDeliverScript.dustCount.ToString();
                specialAttackText[7].GetComponent<UILabel>().text = "/ " + specialDust;

                break;

            case 3:
                if (shieldCount >= specialSeed)
                {
                    ValueDeliverScript.specialAttackItemMaxNumber = specialSeed;
                    ValueDeliverScript.shieldCount = specialSeed;
                    ResultSpecialAttackOnAnimation();

                    if (isSpecialAttackComplete == 0)
                    {
                        ValueDeliverScript.isSpecialAttackComplete = 1;                       //스페셜 어택 미션을 달성했음을 기록.
                        SpecialAttackTimeSet(ValueDeliverScript.specialAttackAddTime);   //스페셜 어택 유지 시간을 정하기 위해 함수를 호출.
                    }
                }

                for (int i = 0; i < specialAttackIcon.Length; i++)
                {
                    specialAttackIcon[i].GetComponent<UISprite>().spriteName = "item_icon4";
                    specialAttackIcon[i].GetComponent<UISprite>().MakePixelPerfect();
                    ValueDeliverScript.specialAttackItemName = "item_icon4";
                }
                specialAttackText[0].GetComponent<UILabel>().text = "/ " + specialSeed;
                specialAttackText[1].GetComponent<UILabel>().text = specialAttackName[3];
                specialAttackText[2].GetComponent<UILabel>().text = ValueDeliverScript.shieldCount.ToString();
                specialAttackText[3].GetComponent<UILabel>().text = "/ " + specialSeed;
                specialAttackText[4].GetComponent<UILabel>().text = ValueDeliverScript.shieldCount.ToString();

                specialAttackText[5].GetComponent<UILabel>().text = specialAttackName[3];
                specialAttackText[6].GetComponent<UILabel>().text = ValueDeliverScript.shieldCount.ToString();
                specialAttackText[7].GetComponent<UILabel>().text = "/ " + specialSeed;

                break;
        }
    }

    private void SpecialAttackTimeSet(int specialTime = 30)
    {
        ValueDeliverScript.specialEndTime = System.DateTime.Now.AddMinutes(specialTime).ToBinary().ToString();  //시간을 저장한다. 이값은 밸류딜리버스크립트에 저장된다.

        specialRestTimeLabel01.SetActive(true);
        StartCoroutine(SpecialAttackTime());
        ValueDeliverScript.SaveGameData();
    }

    private IEnumerator SpecialAttackTime()         //이 코루틴 함수에서 시간을 재서 표시하는 역할을 함.
    {
        for (int i = 0; i < specialAttackIcon.Length; i++)//스페셜 어택 온 된 아이콘(적 유에프오 표시)를 한다.
        {
            specialAttackIcon[i].GetComponent<UISprite>().spriteName = ValueDeliverScript.specialAttackItemName.ToString();    //스프라이트에 지정된 아이콘을 표시한다.
            specialAttackIcon[i].GetComponent<UISprite>().MakePixelPerfect();   //찌그러짐을 방지하기 위해 메이크 픽셀 퍼펙트를 실행한다.
        }

        //Debug.Log("====Special Attack Time Label Show====");
        specialRestTimeLabel01.SetActive(true);                           //남은 시간을 표시하는 숫자를 보이게 만듬.

        specialEndTime = DateTime.FromBinary(Convert.ToInt64(double.Parse(ValueDeliverScript.specialEndTime.ToString())));   //밸류딜리버스크립트에 저장된 시간을 불러온다.

        specialRestTimeText = specialEndTime.Subtract(System.DateTime.Now).Seconds;                //+1을 해주는 것은 남은 시간을 무조건 올림값으로 처리하기 위해서. 기본적으로 버림값을 취함. 현재 시간과 스페셜 출격이 끝날 시간의 차이를 계산하여 그값을 정수로 돌려준다.

        while (specialRestTimeText > -1)                                                                    //아직 스페셜 출격타임이 끝나지 않았으면
        {
            specialRestTimeText = specialEndTime.Subtract(System.DateTime.Now).Minutes;
            specialRestTimeLabel01.GetComponent<UILabel>().text = (1 + (specialRestTimeText)).ToString("D2") + "m!"; //출격 아이콘 위에 스페셜 출격 표시하는 부분에 시간을 적어준다.
            yield return new WaitForSeconds(1f);
        }

        //이부분은 바로 위의 while 루프가 끝나면 실행이 되는 부분이다. 아직 스페셜 미션 완료 보상 시간이 남아있으면 이부분으로 들어오질 못한다.
        //스페셜 출격 시간이 모두 지나면 아래 부분이 실행이 된다.

        ValueDeliverScript.isSpecialAttackComplete = 0; //스페셜 어택 미션 완료 여부가 미완으로~
        ValueDeliverScript.isSpecialAttackMissionSelect = 0; //스페셜 어택 미션 종류 지정 여부가 미완으로~
        ValueDeliverScript.spinballCount = ValueDeliverScript.dustCount = ValueDeliverScript.dartCount = ValueDeliverScript.shieldCount = 0;    //지금까지 파괴했던 각각의 ufo 갯수를 초기화.

        specialRestTimeLabel01.SetActive(false);      //출격하기 버튼 위에 보이던 스페셜 어택 관련 글씨(숫자) 아이콘을 숨김.

        SpecialAttack1();   //스페셜 어택 미션 지정을 위해 함수 호출.
        GameObject.Find("SpecialAttackInfo").transform.localScale = new Vector3(1, 1, 1);   //스페셜 어택 기본 정보를 스케일을 줄여서 안보이게 처리
        GameObject.Find("SpecialInfo/SpecialAttackOn").transform.localScale = new Vector3(1, 0, 1);   //스페셜 어택 발동 문자 스케일 키워서 표시.
        GameObject.Find("SpecialAttackOnText").transform.localScale = new Vector3(46, 46, 1);   //스페셜 어택 발동 문자 스케일 키워서 표시.
        GameObject.Find("GameSpecialStart").transform.localPosition = new Vector3(1500, -281, 0);
        GameObject.Find("GameSpecialStart").GetComponent<UISprite>().enabled = false;
        GameObject.Find("ResultLowTab/AttackBtn/GameStart").GetComponent<UISprite>().enabled = true;
        GameObject.Find("ResultLowTab/AttackBtn/GameStart").transform.localPosition = new Vector3(389, -281, 0);

        GameObject.Find("PrepareBtn/GameStart").GetComponent<UISprite>().spriteName = "bt_gameready_n";
        GameObject.Find("PrepareBtn/GameStart").GetComponent<UIImageButton>().normalSprite = "bt_gameready_n";
        GameObject.Find("PrepareBtn/GameStart").GetComponent<UIImageButton>().hoverSprite = "bt_gameready_n";
        GameObject.Find("PrepareBtn/GameStart").GetComponent<UIImageButton>().pressedSprite = "bt_gameready_o";

        GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UISprite>().spriteName = "bt_gamestart_n";
        GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().normalSprite = "bt_gamestart_n";
        GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().hoverSprite = "bt_gamestart_n";
        GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().pressedSprite = "bt_gamestart_o";
        ValueDeliverScript.SaveGameData();
    }

    //이큅세팅창에(하단바 좌측에 나오는 아이템 세개 들어가는 창) 구매한 이큅 아이템이 보이도록 만들어준다.
    public void EquipStartSetting()
    {
        int activeBomb = ValueDeliverScript.activeBomb;
        int activeReinforce = ValueDeliverScript.activeReinforce;
        int activeAssist = ValueDeliverScript.activeAssist;

        GameObject equipSetting = GameObject.Find("Equippart").gameObject;

        GameObject bombIcon = equipSetting.transform.FindChild("BombIcon").gameObject;
        EquipIconSetting(bombIcon, activeBomb, "Bomb", bombSpriteName);  //1208번줄 EquipIconSetting()함수 실행.

        GameObject reinforceIcon = equipSetting.transform.FindChild("ReinforceIcon").gameObject;
        EquipIconSetting(reinforceIcon, activeReinforce, "Reinforce", reinforceSpriteName);  //1208번줄 EquipIconSetting()함수 실행.

        GameObject assistIcon = equipSetting.transform.FindChild("AssistanceIcon").gameObject;
        EquipIconSetting(assistIcon, activeAssist, "Assist", assistSpriteName);  //1208번줄 EquipIconSetting()함수 실행.
    }

    public void EquipIconSetting(GameObject Icon, int activeIconNum, string equipName, string[] getSpriteName)
    {
        GameObject equipTabItems = null;   //선택창에서 현재 활성화된 탭을 받아둘 변수를 미리 선언한다.
        if (equipName == "Bomb") equipTabItems = GameObject.Find("EquipWindows").transform.FindChild("EquipBombTab/Item").gameObject;
        else if (equipName == "Reinforce") equipTabItems = GameObject.Find("EquipWindows").transform.FindChild("EquipReinforceTab/Item").gameObject;
        else if (equipName == "Assist") equipTabItems = GameObject.Find("EquipWindows").transform.FindChild("EquipAssistTab/Item").gameObject;

        //활성화된 아이템이 기록되어 있고 그 아이템이 한개이상 있을경우.
        int activeItem = 0;
        switch (equipName)
        {
            case "Bomb": switch (activeIconNum)
                {
                    case 1: activeItem = ValueDeliverScript.EquipBomb01; break;
                    case 2: activeItem = ValueDeliverScript.EquipBomb02; break;
                    case 3: activeItem = ValueDeliverScript.EquipBomb03; break;
                    case 4: activeItem = ValueDeliverScript.EquipBomb04; break;
                    case 5: activeItem = ValueDeliverScript.EquipBomb05; break;
                    case 6: activeItem = ValueDeliverScript.EquipBomb06; break;
                    case 7: activeItem = ValueDeliverScript.EquipBomb07; break;
                    case 8: activeItem = ValueDeliverScript.EquipBomb08; break;
                    case 9: activeItem = ValueDeliverScript.EquipBomb09; break;
                    case 10: activeItem = ValueDeliverScript.EquipBomb10; break;
                    case 11: activeItem = ValueDeliverScript.EquipBomb11; break;
                    case 12: activeItem = ValueDeliverScript.EquipBomb12; break;
                } break;
            case "Reinforce": switch (activeIconNum)
                {
                    case 1: activeItem = ValueDeliverScript.EquipReinforce01; break;
                    case 2: activeItem = ValueDeliverScript.EquipReinforce02; break;
                    case 3: activeItem = ValueDeliverScript.EquipReinforce03; break;
                    case 4: activeItem = ValueDeliverScript.EquipReinforce04; break;
                    case 5: activeItem = ValueDeliverScript.EquipReinforce05; break;
                    case 6: activeItem = ValueDeliverScript.EquipReinforce06; break;
                    case 7: activeItem = ValueDeliverScript.EquipReinforce07; break;
                    case 8: activeItem = ValueDeliverScript.EquipReinforce08; break;
                    case 9: activeItem = ValueDeliverScript.EquipReinforce09; break;
                    case 10: activeItem = ValueDeliverScript.EquipReinforce10; break;
                    case 11: activeItem = ValueDeliverScript.EquipReinforce11; break;
                    case 12: activeItem = ValueDeliverScript.EquipReinforce12; break;
                } break;
            case "Assist": switch (activeIconNum)
                {
                    case 1: activeItem = ValueDeliverScript.EquipAssist01; break;
                    case 2: activeItem = ValueDeliverScript.EquipAssist02; break;
                    case 3: activeItem = ValueDeliverScript.EquipAssist03; break;
                    case 4: activeItem = ValueDeliverScript.EquipAssist04; break;
                    case 5: activeItem = ValueDeliverScript.EquipAssist05; break;
                    case 6: activeItem = ValueDeliverScript.EquipAssist06; break;
                    case 7: activeItem = ValueDeliverScript.EquipAssist07; break;
                    case 8: activeItem = ValueDeliverScript.EquipAssist08; break;
                    case 9: activeItem = ValueDeliverScript.EquipAssist09; break;
                    case 10: activeItem = ValueDeliverScript.EquipAssist10; break;
                    case 11: activeItem = ValueDeliverScript.EquipAssist11; break;
                    case 12: activeItem = ValueDeliverScript.EquipAssist12; break;
                } break;
            case "Oper": switch (activeIconNum)
                {
                    case 1: activeItem = ValueDeliverScript.EquipOper01; break;
                    case 2: activeItem = ValueDeliverScript.EquipOper02; break;
                    case 3: activeItem = ValueDeliverScript.EquipOper03; break;
                    case 4: activeItem = ValueDeliverScript.EquipOper04; break;
                    case 5: activeItem = ValueDeliverScript.EquipOper05; break;
                    case 6: activeItem = ValueDeliverScript.EquipOper06; break;
                    case 7: activeItem = ValueDeliverScript.EquipOper07; break;
                    case 8: activeItem = ValueDeliverScript.EquipOper08; break;
                    case 9: activeItem = ValueDeliverScript.EquipOper09; break;
                    case 10: activeItem = ValueDeliverScript.EquipOper10; break;
                    case 11: activeItem = ValueDeliverScript.EquipOper11; break;
                    case 12: activeItem = ValueDeliverScript.EquipOper12; break;
                } break;
        }

        if (activeIconNum > 0 && activeItem > 0)
        {
            equipTabItems.transform.FindChild("MountItem").gameObject.SetActive(true);  //마운트 아이콘을 활성화 한다.

            // 1.먼저 이큅세팅창에 활성화된 아이콘을 표시한다.
            Icon.GetComponent<UISprite>().spriteName = getSpriteName[activeIconNum].Replace("big", "med");
            Icon.GetComponent<UISprite>().MakePixelPerfect();
            //Icon.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);

            // 2.활성화된 아이템변수와 컴포넌트에 같은 번호를 가진 아이템을 찾는다.
            int itemCount = equipTabItems.transform.childCount;    //탭내의 아이템의 갯수를 센다.
            for (int i = 0; i < itemCount; i++)
            {
                ItemKeyValueScript itemKeyValueScript = equipTabItems.transform.GetChild(i).GetComponent<ItemKeyValueScript>();
                //먼저 아이템인지 확인.
                if (itemKeyValueScript && itemKeyValueScript.itemNumber > 0 && itemKeyValueScript.itemNumber == activeIconNum)
                {
                    //마운트 아이템의 위치를 아이템과 같은 위치가 되도록 한다.
                    equipTabItems.transform.FindChild("MountItem").localPosition = equipTabItems.transform.GetChild(i).localPosition + new Vector3(-1, 3, -1) - equipTabItems.transform.localPosition;
                    equipTabItems.transform.GetChild(i).transform.FindChild("Label").GetComponent<UILabel>().text = activeItem.ToString();
                    break;
                }
            }
        }

        //활성화 되어 있는 아이템이 없으면 구매된 아이템이 있는지 검사.
        else
        {
            // 0.어느 아이템도 활성화되어 있지 않게 바꾸어준다.
            if (equipName == "Bomb") ValueDeliverScript.activeBomb = 0;
            else if (equipName == "Reinforce") ValueDeliverScript.activeReinforce = 0;
            else if (equipName == "Assist") ValueDeliverScript.activeAssist = 0;

            // 1.먼저 이큅세팅창에 활성화된 아이콘을 표시한다.
            for (int i = 1; i < getSpriteName.Length; i++)
            {
                //여기서 i 값은 각각의 아이템의 아이템넘버값과 동일함. 바로 위의 액티브 아이콘 값과도 값은 결과를 내는 값임.
                switch (equipName)
                {
                    case "Bomb": switch (i)
                        {
                            case 1: activeItem = ValueDeliverScript.EquipBomb01; break;
                            case 2: activeItem = ValueDeliverScript.EquipBomb02; break;
                            case 3: activeItem = ValueDeliverScript.EquipBomb03; break;
                            case 4: activeItem = ValueDeliverScript.EquipBomb04; break;
                            case 5: activeItem = ValueDeliverScript.EquipBomb05; break;
                            case 6: activeItem = ValueDeliverScript.EquipBomb06; break;
                            case 7: activeItem = ValueDeliverScript.EquipBomb07; break;
                            case 8: activeItem = ValueDeliverScript.EquipBomb08; break;
                            case 9: activeItem = ValueDeliverScript.EquipBomb09; break;
                            case 10: activeItem = ValueDeliverScript.EquipBomb10; break;
                            case 11: activeItem = ValueDeliverScript.EquipBomb11; break;
                            case 12: activeItem = ValueDeliverScript.EquipBomb12; break;
                        } break;
                    case "Reinforce": switch (i)
                        {
                            case 1: activeItem = ValueDeliverScript.EquipReinforce01; break;
                            case 2: activeItem = ValueDeliverScript.EquipReinforce02; break;
                            case 3: activeItem = ValueDeliverScript.EquipReinforce03; break;
                            case 4: activeItem = ValueDeliverScript.EquipReinforce04; break;
                            case 5: activeItem = ValueDeliverScript.EquipReinforce05; break;
                            case 6: activeItem = ValueDeliverScript.EquipReinforce06; break;
                            case 7: activeItem = ValueDeliverScript.EquipReinforce07; break;
                            case 8: activeItem = ValueDeliverScript.EquipReinforce08; break;
                            case 9: activeItem = ValueDeliverScript.EquipReinforce09; break;
                            case 10: activeItem = ValueDeliverScript.EquipReinforce10; break;
                            case 11: activeItem = ValueDeliverScript.EquipReinforce11; break;
                            case 12: activeItem = ValueDeliverScript.EquipReinforce12; break;
                        } break;
                    case "Assist": switch (i)
                        {
                            case 1: activeItem = ValueDeliverScript.EquipAssist01; break;
                            case 2: activeItem = ValueDeliverScript.EquipAssist02; break;
                            case 3: activeItem = ValueDeliverScript.EquipAssist03; break;
                            case 4: activeItem = ValueDeliverScript.EquipAssist04; break;
                            case 5: activeItem = ValueDeliverScript.EquipAssist05; break;
                            case 6: activeItem = ValueDeliverScript.EquipAssist06; break;
                            case 7: activeItem = ValueDeliverScript.EquipAssist07; break;
                            case 8: activeItem = ValueDeliverScript.EquipAssist08; break;
                            case 9: activeItem = ValueDeliverScript.EquipAssist09; break;
                            case 10: activeItem = ValueDeliverScript.EquipAssist10; break;
                            case 11: activeItem = ValueDeliverScript.EquipAssist11; break;
                            case 12: activeItem = ValueDeliverScript.EquipAssist12; break;
                        } break;
                    case "Oper": switch (i)
                        {
                            case 1: activeItem = ValueDeliverScript.EquipOper01; break;
                            case 2: activeItem = ValueDeliverScript.EquipOper02; break;
                            case 3: activeItem = ValueDeliverScript.EquipOper03; break;
                            case 4: activeItem = ValueDeliverScript.EquipOper04; break;
                            case 5: activeItem = ValueDeliverScript.EquipOper05; break;
                            case 6: activeItem = ValueDeliverScript.EquipOper06; break;
                            case 7: activeItem = ValueDeliverScript.EquipOper07; break;
                            case 8: activeItem = ValueDeliverScript.EquipOper08; break;
                            case 9: activeItem = ValueDeliverScript.EquipOper09; break;
                            case 10: activeItem = ValueDeliverScript.EquipOper10; break;
                            case 11: activeItem = ValueDeliverScript.EquipOper11; break;
                            case 12: activeItem = ValueDeliverScript.EquipOper12; break;
                        } break;
                }

                if (activeItem > 0 && getSpriteName[i] != null)
                {
                    Icon.GetComponent<UISprite>().spriteName = getSpriteName[i].Replace("big", "med");
                    Icon.GetComponent<UISprite>().MakePixelPerfect();
                    //Icon.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);	//콜라이더의 크기를 적당한 크기로 조정하여 터치 오류를 줄이기 위한 부분.

                    activeIconNum = i;
                    //활성아이템 표시 액티브 변수에 기록.//////////////////////////////////////////////////////////////////////////////
                    if (equipName == "Bomb") ValueDeliverScript.activeBomb = i;																		///
                    else if (equipName == "Reinforce") ValueDeliverScript.activeReinforce = i;																	///
                    else if (equipName == "Assist") ValueDeliverScript.activeAssist = i;																	///
                    break;
                }
                else if (i + 1 >= getSpriteName.Length)
                {
                    if (equipName == "Bomb") ValueDeliverScript.activeBomb = 0;
                    else if (equipName == "Reinforce") ValueDeliverScript.activeReinforce = 0;
                    else if (equipName == "Assist") ValueDeliverScript.activeAssist = 0;
                }	//if끝.
            }	//for끝.

            // 2.이큅아이템 선택창에 장착중 아이콘을 표시준비를 한다.한개이상 구매한 아이템이 있는지 검사한다.
            int itemCount = equipTabItems.transform.childCount;   //탭내의 아이템의 갯수를 센다.
            GameObject[] items = new GameObject[itemCount];

            // 4.정렬을 하기 위해 아이템들을 임시 배열 오브젝트에 모은다.
            for (int i = 0; i < itemCount; i++)
            {
                items[i] = equipTabItems.transform.GetChild(i).gameObject;
            }

            // 5.버블 정렬을 실행한다. 위치번호를 기반으로 배열을 재정렬하여준다.
            GameObject[] sortItems = new GameObject[itemCount];
            sortItems = BubbleSort(items, itemCount);

            // 6.재정렬된 아이템들을 각각 조사하여 적어도 한개이상 있는지 구매되어 있는지 조사한다.
            for (int i = 0; i < itemCount; i++)
            {
                if (!sortItems[i].GetComponent<ItemKeyValueScript>()) continue;
                int itemNum = sortItems[i].GetComponent<ItemKeyValueScript>().itemNumber;

                switch (equipName)
                {
                    case "Bomb": switch (itemNum)
                        {
                            case 1: activeItem = ValueDeliverScript.EquipBomb01; break;
                            case 2: activeItem = ValueDeliverScript.EquipBomb02; break;
                            case 3: activeItem = ValueDeliverScript.EquipBomb03; break;
                            case 4: activeItem = ValueDeliverScript.EquipBomb04; break;
                            case 5: activeItem = ValueDeliverScript.EquipBomb05; break;
                            case 6: activeItem = ValueDeliverScript.EquipBomb06; break;
                            case 7: activeItem = ValueDeliverScript.EquipBomb07; break;
                            case 8: activeItem = ValueDeliverScript.EquipBomb08; break;
                            case 9: activeItem = ValueDeliverScript.EquipBomb09; break;
                            case 10: activeItem = ValueDeliverScript.EquipBomb10; break;
                            case 11: activeItem = ValueDeliverScript.EquipBomb11; break;
                            case 12: activeItem = ValueDeliverScript.EquipBomb12; break;
                        } break;
                    case "Reinforce": switch (itemNum)
                        {
                            case 1: activeItem = ValueDeliverScript.EquipReinforce01; break;
                            case 2: activeItem = ValueDeliverScript.EquipReinforce02; break;
                            case 3: activeItem = ValueDeliverScript.EquipReinforce03; break;
                            case 4: activeItem = ValueDeliverScript.EquipReinforce04; break;
                            case 5: activeItem = ValueDeliverScript.EquipReinforce05; break;
                            case 6: activeItem = ValueDeliverScript.EquipReinforce06; break;
                            case 7: activeItem = ValueDeliverScript.EquipReinforce07; break;
                            case 8: activeItem = ValueDeliverScript.EquipReinforce08; break;
                            case 9: activeItem = ValueDeliverScript.EquipReinforce09; break;
                            case 10: activeItem = ValueDeliverScript.EquipReinforce10; break;
                            case 11: activeItem = ValueDeliverScript.EquipReinforce11; break;
                            case 12: activeItem = ValueDeliverScript.EquipReinforce12; break;
                        } break;
                    case "Assist": switch (itemNum)
                        {
                            case 1: activeItem = ValueDeliverScript.EquipAssist01; break;
                            case 2: activeItem = ValueDeliverScript.EquipAssist02; break;
                            case 3: activeItem = ValueDeliverScript.EquipAssist03; break;
                            case 4: activeItem = ValueDeliverScript.EquipAssist04; break;
                            case 5: activeItem = ValueDeliverScript.EquipAssist05; break;
                            case 6: activeItem = ValueDeliverScript.EquipAssist06; break;
                            case 7: activeItem = ValueDeliverScript.EquipAssist07; break;
                            case 8: activeItem = ValueDeliverScript.EquipAssist08; break;
                            case 9: activeItem = ValueDeliverScript.EquipAssist09; break;
                            case 10: activeItem = ValueDeliverScript.EquipAssist10; break;
                            case 11: activeItem = ValueDeliverScript.EquipAssist11; break;
                            case 12: activeItem = ValueDeliverScript.EquipAssist12; break;
                        } break;
                    case "Oper": switch (itemNum)
                        {
                            case 1: activeItem = ValueDeliverScript.EquipOper01; break;
                            case 2: activeItem = ValueDeliverScript.EquipOper02; break;
                            case 3: activeItem = ValueDeliverScript.EquipOper03; break;
                            case 4: activeItem = ValueDeliverScript.EquipOper04; break;
                            case 5: activeItem = ValueDeliverScript.EquipOper05; break;
                            case 6: activeItem = ValueDeliverScript.EquipOper06; break;
                            case 7: activeItem = ValueDeliverScript.EquipOper07; break;
                            case 8: activeItem = ValueDeliverScript.EquipOper08; break;
                            case 9: activeItem = ValueDeliverScript.EquipOper09; break;
                            case 10: activeItem = ValueDeliverScript.EquipOper10; break;
                            case 11: activeItem = ValueDeliverScript.EquipOper11; break;
                            case 12: activeItem = ValueDeliverScript.EquipOper12; break;
                        } break;
                }

                if (itemNum != 0 && activeItem > 0)
                {
                    equipTabItems.transform.FindChild("MountItem").gameObject.SetActive(true);  //마운트 아이콘을 활성화 한다.
                    // 7.한개이상 구매되어 있을경우 해당아이템의 위치에 장착중 아이콘을 표시하여준다.
                    equipTabItems.transform.FindChild("MountItem").localPosition = sortItems[i].transform.localPosition + new Vector3(-1, 3, -1);

                    //어떤 아이템이 장착되었는지 활성화 여부를 알려준다.
                    if (equipName == "Bomb") ValueDeliverScript.activeBomb = itemNum;
                    else if (equipName == "Reinforce") ValueDeliverScript.activeReinforce = itemNum;
                    else if (equipName == "Assist") ValueDeliverScript.activeAssist = itemNum;
                    break;
                }
            }
        }
        //ValueDeliverScript.SaveGameData();
    }//EquipIconSetting함수 끝.

    private GameObject[] BubbleSort(GameObject[] items, int itemCount)
    {
        GameObject tempItem = null;
        for (int j = 0; j < itemCount - 1; j++)
        {
            for (int i = 0; i < itemCount - 1; i++)
            {
                ////Debug.Log(":::::: 버블 정렬 현재 반복 횟수 :: J :: " + j + " :: i :: " + i + " ::::::");
                if (!items[i].GetComponent<ItemKeyValueScript>())   //아이템이 아닌 오브젝트일 경우 배열의 맨끝으로 이동시켜 준다.
                {
                    tempItem = items[i];
                    for (int k = i; k < itemCount - 1; k++)
                    {
                        items[k] = items[k + 1];
                    }
                    items[itemCount - 1] = tempItem;
                    continue;
                }

                if (items[i].GetComponent<ItemKeyValueScript>() && items[i + 1].GetComponent<ItemKeyValueScript>())
                {
                    if (items[i].GetComponent<ItemKeyValueScript>().itemPositionNumber > items[i + 1].GetComponent<ItemKeyValueScript>().itemPositionNumber)
                    {
                        tempItem = items[i + 1];
                        items[i + 1] = items[i];
                        items[i] = tempItem;
                    }
                }
            }
        }
        return items;
    }

    private IEnumerator GoToGarage()
    {
        if (ValueDeliverScript.bgSound == 0.5f) //소리가 켜져있을경우 결과창 BGM에서 격납고 BGM으로 변경.
        {
            AudioSource resultSound = GameObject.Find("ResultSoundManager").GetComponent<AudioSource>();
            AudioSource bgSound = GameObject.Find("BgSoundManager").GetComponent<AudioSource>();
            resultSound.volume = 1f;
            bgSound.volume = 0f;

            while (resultSound.volume > 0)
            {
                resultSound.volume -= Time.deltaTime * 4;
                bgSound.volume += Time.deltaTime * 4;
                yield return null;
            }
        }

        if (storeWindow.transform.localPosition.x == 40)
        {
            storeWindow.animation.Play("StoreWindowAnim02");
        }
        else
        {
            ResultPanel.transform.FindChild("ResultPanelLeft").animation.Play("ResultPanelLeftAnim03");
            ResultPanel.transform.FindChild("ResultPanelRight").animation.Play("ResultPanelRightAnim02");
        }
        ResultPanel.transform.FindChild("ResultLowTab").animation.Play("ResultLowTabAnim02");

        yield return new WaitForSeconds(1f);
        flights.animation.Play("FlightsPanelAnim01");

        prepareReady.transform.FindChild("RankFriendTF").gameObject.SetActive(true);
        Debug.Log("PrepareReadyAnim01");

        //메세지 유무 여부에 따라 깜박이 보이게 할지 안보이게 할지 결정//
        if (ValueDeliverScript.messageData.Length != 0) GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(true);
        else GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(false);

        prepareReady.animation.Play("PrepareReadyAnim01");
        flights.transform.FindChild("MoveTF/FlightsMove").localPosition = new Vector3(ValueDeliverScript.flightNumber * -1000, 0, 0);
        ///*
        ///

        //resultSkinName = "FlightDura" + ValueDeliverScript.flightNumber.ToString("D3") + "Skin" + ValueDeliverScript.skinNumber.ToString("D3");

        if (resultSkinNumber != 0 && resultSkinName <= 0)
        {
            Debug.Log("SkinDuraShot!!!!");
            //스킨 내구도가 0이하로 떨어지면 이 부분을 실행!
            //스킨 내구도 복구 유도 창을 띄운다.

            GetComponent<HangarPopupController>().AddPopWin(duraBuyAlarmWindow, 0);
            //duraBuyAlarmWindow.SetActive(true);
            //halfBLKPanel.SetActive(true);
            //halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, duraBuyAlarmWindow.transform.localPosition.z + 5);
        }
        else
        {
            flights.SetActive(true);
            ResultPanel.SetActive(false);
        }
        //*/
    }

    //랭크탭이 있는 곳으로 이동한다//
    private IEnumerator GoToGarage2()
    {
        Debug.Log("여기?");
        noTouchPanel.SetActive(true);
        ValueDeliverScript.rescueArlamFriendId = "";

        if (ValueDeliverScript.isBgSound == true) //소리가 켜져있을경우 결과창 BGM에서 격납고 BGM으로 변경.
        {
            AudioSource resultSound = GameObject.Find("ResultSoundManager").GetComponent<AudioSource>();
            AudioSource bgSound = GameObject.Find("BgSoundManager").GetComponent<AudioSource>();
            resultSound.volume = 1f;
            bgSound.volume = 0f;
            bgSound.Play();

            while (resultSound.volume > 0)
            {
                resultSound.volume -= Time.deltaTime * 4;
                bgSound.volume += Time.deltaTime * 4;
                yield return null;
            }
        }

        if (storeWindow.transform.localPosition.x == 40)
            storeWindow.animation.Play("StoreWindowAnim02");
        else
        {
            ResultPanel.transform.FindChild("ResultPanelLeft").animation.Play("ResultPanelLeftAnim03");
            ResultPanel.transform.FindChild("ResultPanelRight").animation.Play("ResultPanelRightAnim02");
        }

        ResultPanel.transform.FindChild("ResultLowTab").animation.Play("ResultLowTabAnim02");
        bgTop.animation.Play("BGMainTopAnim02");
        yield return new WaitForSeconds(1f);

        /////////
        friendWindow.SetActive(true);

        friendWindow.transform.FindChild("TapSprits/RankTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_00";
        friendWindow.transform.FindChild("TapSprits/MailTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_01";

        friendWeekTab.GetComponent<UIPanel>().alpha = 1;
        friendWeekTab.SetActive(true);

        wRankab.GetComponent<UIPanel>().alpha = 0;
        wRankab.SetActive(false);

        friendMailTab.GetComponent<UIPanel>().alpha = 0;
        friendMailTab.SetActive(false);

        //friendWindow.transform.FindChild("RankGrid").GetComponent<UIPanel>().alpha = 1;
        //friendWindow.transform.FindChild("RankGrid").gameObject.SetActive(true);

        //friendWindow.transform.FindChild("MessageGrid").GetComponent<UIPanel>().alpha = 0;
        //friendWindow.transform.FindChild("MessageGrid").gameObject.SetActive(false);

        //friendWindow.transform.FindChild("WRankGrid").GetComponent<UIPanel>().alpha = 0;
        //friendWindow.transform.FindChild("WRankGrid").gameObject.SetActive(false);

        prepareReady.transform.FindChild("RankFriendTF").gameObject.SetActive(true);
        Debug.Log("PrepareReadyAnim01_1");

        prepareReady.animation.Play("PrepareReadyAnim01_1");
        friendWindow.animation.Play("FriendWindowAnim01");
        yield return new WaitForSeconds(0.5f);
        friendWindow.transform.FindChild("BackBtn").gameObject.SetActive(true);
        /////////

        if (resultSkinNumber != 0 && resultSkinName <= 0)
        {
            Debug.Log("SkinDuraShot!!!!");
            //스킨 내구도가 0이하로 떨어지면 이 부분을 실행!
            //스킨 내구도 복구 유도 창을 띄운다.

            GetComponent<HangarPopupController>().AddPopWin(duraBuyAlarmWindow, 0);

            //duraBuyAlarmWindow.SetActive(true);
            //halfBLKPanel.SetActive(true);
            //halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, duraBuyAlarmWindow.transform.localPosition.z + 5);
        }
        noTouchPanel.SetActive(false);

        //시간을 계산하여 앞으로 초기화가 얼마나 남았는지 알아내는 코드//
        //남은시간을 상단 텍스트 표시부분에 반영하여 얼마가 남았는지 알려준다//
        DayOfWeek todayWeek = DateTime.UtcNow.AddHours(7).DayOfWeek;
        int dayCount = (int)todayWeek;
        int remainDays = 7 - dayCount;
        if (dayCount == 0) remainDays = 0;

        int remainHours = 23 - Mathf.FloorToInt((float)DateTime.UtcNow.AddHours(7).TimeOfDay.TotalHours);

        string dayString;

        if (remainDays > 1)
        {
            dayString = "Days";
        }
        else
        {
            dayString = "Day";
        }

        string hourString;

        if (remainHours > 1)
        {
            hourString = "Hours";
        }
        else
        {
            hourString = "Hour";
        }
        //Reset after N days and N hours
        friendWindow.transform.FindChild("Script03").GetComponent<UILabel>().text = "Reset after" + remainDays + " " + dayString + ", " + remainHours + " " + hourString;
        //시간을 계산하여 앞으로 초기화가 얼마나 남았는지 알아내는 코드//
        //남은시간을 상단 텍스트 표시부분에 반영하여 얼마가 남았는지 알려준다//
    }

    private void NoSelectFriend()
    {
        NoSelectFriendWindow.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, NoSelectFriendWindow.transform.localPosition.z + 5);
    }

    private void CloseNoSelectFriend()
    {
        NoSelectFriendWindow.SetActive(false);
        halfBLKPanel.SetActive(false);
    }

    private void BlockMessageFriend()
    {
        BlockMessageFriendWindow.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, BlockMessageFriendWindow.transform.localPosition.z + 5);
    }

    private void CloseBlockMessageFriend()
    {
        BlockMessageFriendWindow.SetActive(false);
        halfBLKPanel.SetActive(false);
    }

    public void GoToSoundWindow()
    {
        halfBLKPanel.SetActive(true);

        soundControlWindow.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, soundControlWindow.transform.localPosition.z + 5);
    }

    public void SoundWindowClose()
    {
        halfBLKPanel.SetActive(false);
        soundControlWindow.SetActive(false);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, -166);
    }

    public void GoToAllBuyWindow()
    {
        int coinRest = ValueDeliverScript.coinRest;
        if (coinRest < ValueDeliverScript.salePriceInt)
        {
            //돈이 부족할때//
            //이 메소드가 호출되면서 실행되어야 할 다음 팝업창을 지정하고 순서상 제일 앞으로 지정(-1)
            //창이 실행되서 실행되어할 메소드(CoinShortageWindowMethod)을 적어 넣어준다//
            //여기서는 먼저 실행된 창이 있어서 꺼야 되기 때문에 그 창을 꺼준다는 의미로//
            //isClosePop: true 넣어줘서 이전창이 꺼지도록 만들어 준다.//
            GetComponent<HangarPopupController>().AddPopWin(coinShortageWindow, -1, MCoinShortageWindowMethod, isClosePop: false);
        }
        else
        {
            //돈이 충분할때//
            GetComponent<HangarPopupController>().AddPopWin(allBuyWindow, 0);
        }
    }

    //코인 부족.구매 유도창 관련 열고 닫기.
    public void GoToCoinShortageWindow()
    {
    }

    private void AddEquip(string item)
    {
        item = "Equip" + item;
        switch (item)
        {
            case "EquipBomb01": ValueDeliverScript.EquipBomb01++; break;
            case "EquipBomb02": ValueDeliverScript.EquipBomb02++; break;
            case "EquipBomb03": ValueDeliverScript.EquipBomb03++; break;
            case "EquipBomb04": ValueDeliverScript.EquipBomb04++; break;
            case "EquipBomb05": ValueDeliverScript.EquipBomb05++; break;
            case "EquipBomb06": ValueDeliverScript.EquipBomb06++; break;
            case "EquipBomb07": ValueDeliverScript.EquipBomb07++; break;
            case "EquipBomb08": ValueDeliverScript.EquipBomb08++; break;
            case "EquipBomb09": ValueDeliverScript.EquipBomb09++; break;
            case "EquipBomb10": ValueDeliverScript.EquipBomb10++; break;
            case "EquipBomb11": ValueDeliverScript.EquipBomb11++; break;
            case "EquipBomb12": ValueDeliverScript.EquipBomb12++; break;

            case "EquipReinforce01": ValueDeliverScript.EquipReinforce01++; break;
            case "EquipReinforce02": ValueDeliverScript.EquipReinforce02++; break;
            case "EquipReinforce03": ValueDeliverScript.EquipReinforce03++; break;
            case "EquipReinforce04": ValueDeliverScript.EquipReinforce04++; break;
            case "EquipReinforce05": ValueDeliverScript.EquipReinforce05++; break;
            case "EquipReinforce06": ValueDeliverScript.EquipReinforce06++; break;
            case "EquipReinforce07": ValueDeliverScript.EquipReinforce07++; break;
            case "EquipReinforce08": ValueDeliverScript.EquipReinforce08++; break;
            case "EquipReinforce09": ValueDeliverScript.EquipReinforce09++; break;
            case "EquipReinforce10": ValueDeliverScript.EquipReinforce10++; break;
            case "EquipReinforce11": ValueDeliverScript.EquipReinforce11++; break;
            case "EquipReinforce12": ValueDeliverScript.EquipReinforce12++; break;

            case "EquipAssist01": ValueDeliverScript.EquipAssist01++; break;
            case "EquipAssist02": ValueDeliverScript.EquipAssist02++; break;
            case "EquipAssist03": ValueDeliverScript.EquipAssist03++; break;
            case "EquipAssist04": ValueDeliverScript.EquipAssist04++; break;
            case "EquipAssist05": ValueDeliverScript.EquipAssist05++; break;
            case "EquipAssist06": ValueDeliverScript.EquipAssist06++; break;
            case "EquipAssist07": ValueDeliverScript.EquipAssist07++; break;
            case "EquipAssist08": ValueDeliverScript.EquipAssist08++; break;
            case "EquipAssist09": ValueDeliverScript.EquipAssist09++; break;
            case "EquipAssist10": ValueDeliverScript.EquipAssist10++; break;
            case "EquipAssist11": ValueDeliverScript.EquipAssist11++; break;
            case "EquipAssist12": ValueDeliverScript.EquipAssist12++; break;

            case "EquipOper01": ValueDeliverScript.EquipOper01++; break;
            case "EquipOper02": ValueDeliverScript.EquipOper02++; break;
            case "EquipOper03": ValueDeliverScript.EquipOper03++; break;
            case "EquipOper04": ValueDeliverScript.EquipOper04++; break;
            case "EquipOper05": ValueDeliverScript.EquipOper05++; break;
            case "EquipOper06": ValueDeliverScript.EquipOper06++; break;
            case "EquipOper07": ValueDeliverScript.EquipOper07++; break;
            case "EquipOper08": ValueDeliverScript.EquipOper08++; break;
            case "EquipOper09": ValueDeliverScript.EquipOper09++; break;
            case "EquipOper10": ValueDeliverScript.EquipOper10++; break;
            case "EquipOper11": ValueDeliverScript.EquipOper11++; break;
            case "EquipOper12": ValueDeliverScript.EquipOper12++; break;
        }
    }

    public void AllBuyWindowBuy()
    {
        GetComponent<HangarPopupController>().CloseWindow(AllBuyWindowBuy02);
    }

    void AllBuyWindowBuy02()
    {
        //halfBLKPanel.SetActive(false);
        //allBuyWindow.SetActive(false);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, -166);

        AddEquip(ValueDeliverScript.saleItem01);
        AddEquip(ValueDeliverScript.saleItem02);
        AddEquip(ValueDeliverScript.saleItem03);

        ValueDeliverScript.activeBomb = int.Parse(ValueDeliverScript.saleItem01.Replace("Bomb", ""));
        ValueDeliverScript.activeReinforce = int.Parse(ValueDeliverScript.saleItem02.Replace("Reinforce", ""));
        ValueDeliverScript.activeAssist = int.Parse(ValueDeliverScript.saleItem03.Replace("Assist", ""));

        ValueDeliverScript.coinRest = ValueDeliverScript.coinRest - ValueDeliverScript.salePriceInt;

        GameObject.Find("GameManager").GetComponent<GasTimeScript>().MedalRecount(); //화면에 표시되는 메달양을 다시 계산하여 재표시하여줌.
        GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.

        EquipStartSetting();  //1173번줄에 있는 이큅스타트세팅 함수를 호출.
        ValueDeliverScript.SaveGameData();
    }

    public void AllBuyWindowCancel()
    {
        GetComponent<HangarPopupController>().CloseWindow(AllBuyWindowBuy02);

        //구매 캔슬 코드. 굳이 필요없음.
        //halfBLKPanel.SetActive(false);
        //allBuyWindow.SetActive(false);
        //halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, -166);
    }

    public void GoToPilotLevelUpWindow()
    {
        GetComponent<HangarPopupController>().AddPopWin(pilotLevelUpWindow, 0, GoToPilotLevelUpWindow01);
    }
    public void GoToPilotLevelUpWindow01()
    {
        //halfBLKPanel.SetActive(true);
        //Debug.Log("halfBLKPanel.SetActive(true)");
        //pilotLevelUpWindow.SetActive(true);
        //halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, pilotLevelUpWindow.transform.localPosition.z + 5);

        int userLevel = ValueDeliverScript.userLevel;
        int upgradePoint = ValueDeliverScript.upgradePoint;

        ValueDeliverScript.upgradePoint = ValueDeliverScript.upgradePoint + 1;

        if (isSkinFullLevel && userLevel == 10 && userLevel == 20)
        {
            ValueDeliverScript.upgradePoint = upgradePoint + 5;
            upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 6";
        }
        else if (userLevel == 10 && userLevel == 20)
        {
            ValueDeliverScript.upgradePoint = upgradePoint + 3;
            upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 4";
        }
        else
        {
            upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 1";
        }

        flightUpointSetScript.RedrawStatePoint();
        ValueDeliverScript.SaveGameData();
    }

    public void PilotLevelUpWindowClose()
    {
        GetComponent<HangarPopupController>().AddPopWin(upgradePointWindow, -1, null, isClosePop: true);
    }

    public void FirstAccessOpen()
    {
        GetComponent<HangarPopupController>().AddPopWin(firstAccessWindow, 0);
    }

    public void FirstAccessClose()
    {
        firstAccessWindow.gameObject.SetActive(false);
        GetComponent<HangarPopupController>().CloseWindow(FirstAccessClose2);
    }

    public void FirstAccessClose2()
    {
        StartCoroutine(GameObject.Find("TutManager").GetComponent<TutManagerScript>().TutEnd());
    }

    //기본스토어관련창
    private IEnumerator TransChange(GameObject go, float TransValue)   //지정한 탭(내용물들)이 점점 사라지게 할지 보이게 할지 결정하는 함수. 0이면 사라지고 1이면 보임.
    {
        go.SetActive(true);
        float lValue = 0;
        float firstValue = go.GetComponent<UIPanel>().alpha;
        while (lValue <= 1)
        {
            go.GetComponent<UIPanel>().alpha = Mathf.Lerp(firstValue, TransValue, lValue);
            lValue += Time.deltaTime * 3;
            yield return null;
        }
        go.GetComponent<UIPanel>().alpha = Mathf.Lerp(firstValue, TransValue, 1);

        if (TransValue == 0)
        {
            go.SetActive(false);
        }
    }

    void StoreCoinWindowM()
    {
        GetComponent<HangarPopupController>().CloseWindow(GoToStoreCoinWindowV);
    }

    void GoToStoreCoinWindowV()
    {
        StartCoroutine(GoToStoreCoinWindow());
    }
    private IEnumerator GoToStoreCoinWindow()
    {
        //noTouchPanel.SetActive(true);
        //coinShortageWindow.SetActive(false);
        //halfBLKPanel.SetActive(false);
        //pilotLevelUpWindow.SetActive(false);
        //duraBuyAlarmWindow.SetActive(false);

        storeWindow.SetActive(true);

        if (storeWindow.transform.localPosition.x == 40)    //이미 스토어창이 보이는 상태이면(스토어창이 보이는 위치는 x값이 40이다)
        {
            StartCoroutine(TransChange(storeWindow.transform.FindChild("TabCoin").gameObject, 1));
            StartCoroutine(TransChange(storeWindow.transform.FindChild("TabGas").gameObject, 0));
            StartCoroutine(TransChange(storeWindow.transform.FindChild("TabMedal").gameObject, 0));

            //지정된 탭(여기서는 코인) 활성화 이미지로 변경.
            storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_n";
            storeWindow.transform.FindChild("Base/TabGasIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
            storeWindow.transform.FindChild("Base/TabMedalIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";

            //이미지가 변경되면서 왜곡된 이미지를 정상크기와 위치로 맞춰줌.
            storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().MakePixelPerfect();
            storeWindow.transform.FindChild("Base/TabGasIcon").GetComponent<UISprite>().MakePixelPerfect();
            storeWindow.transform.FindChild("Base/TabMedalIcon").GetComponent<UISprite>().MakePixelPerfect();
            noTouchPanel.SetActive(false);
        }
        else
        {
            //스토어창이 보이지 않는 상태이면 탭이미지들을 변경하고 스토어의 백버튼을 활성화한다.
            storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_n";
            storeWindow.transform.FindChild("Base/TabGasIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
            storeWindow.transform.FindChild("Base/TabMedalIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";

            storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().MakePixelPerfect();
            storeWindow.transform.FindChild("Base/TabGasIcon").GetComponent<UISprite>().MakePixelPerfect();
            storeWindow.transform.FindChild("Base/TabMedalIcon").GetComponent<UISprite>().MakePixelPerfect();

            storeWindow.transform.FindChild("TabCoin").gameObject.SetActive(true);
            storeWindow.transform.FindChild("TabCoin").GetComponent<UIPanel>().alpha = 1;

            storeWindow.transform.FindChild("TabGas").GetComponent<UIPanel>().alpha = 0;
            storeWindow.transform.FindChild("TabGas").gameObject.SetActive(false);

            storeWindow.transform.FindChild("TabMedal").GetComponent<UIPanel>().alpha = 0;
            storeWindow.transform.FindChild("TabMedal").gameObject.SetActive(false);

            if (equipWindows.transform.localPosition.x == 40)
            {
                equipToStoreOn = true;
                equipWindows.animation.Play("StoreWindowAnim03");
                equipWindows.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
            }
            else if (ResultPanel.transform.FindChild("ResultPanelLeft").localPosition.x == 0)
            {
                resultToStoreOn = true;
                ResultPanel.transform.FindChild("ResultPanelLeft").animation.Play("ResultPanelLeftAnim03");
                ResultPanel.transform.FindChild("ResultPanelRight").animation.Play("ResultPanelRightAnim02");

                yield return new WaitForSeconds(1f);
            }
            else if (skinSelectWindow00.transform.localPosition.x == 40)
            {
                skin00ToStoreOn = true;
                skinSelectWindow00.animation.Play("SkinSelectWindowAnim03");
                skinSelectWindow00.transform.FindChild("BackBtn").gameObject.SetActive(false);
            }
            else if (skinSelectWindow01.transform.localPosition.x == 40)
            {
                skin01ToStoreOn = true;
                skinSelectWindow01.animation.Play("SkinSelectWindowAnim03");
                skinSelectWindow01.transform.FindChild("BackBtn").gameObject.SetActive(false);
            }
            else if (skinSelectWindow02.transform.localPosition.x == 40)
            {
                skin02ToStoreOn = true;
                skinSelectWindow02.animation.Play("SkinSelectWindowAnim03");
                skinSelectWindow02.transform.FindChild("BackBtn").gameObject.SetActive(false);
            }
            else
            {
                noTouchPanel.SetActive(true);
                flights.animation.Play("FlightsPanelAnim02");
            }
            //실제 스토어 윈도우가 나타는 애니메이션을 플레이 해준다.
            storeWindow.animation.Play("StoreWindowAnim01");
            yield return new WaitForSeconds(0.5f);
            //백버튼 활성화.
            storeWindow.transform.FindChild("Base/BackBtn").gameObject.SetActive(true);
        }
    }

    private IEnumerator GoToStoreGasWindow()
    {
        GetComponent<HangarPopupController>().CloseWindow();

        storeWindow.SetActive(true);

        if (storeWindow.transform.localPosition.x == 40)
        {
            StartCoroutine(TransChange(storeWindow.transform.FindChild("TabCoin").gameObject, 0));
            StartCoroutine(TransChange(storeWindow.transform.FindChild("TabGas").gameObject, 1));
            StartCoroutine(TransChange(storeWindow.transform.FindChild("TabMedal").gameObject, 0));

            storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
            storeWindow.transform.FindChild("Base/TabGasIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_n";
            storeWindow.transform.FindChild("Base/TabMedalIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
            noTouchPanel.SetActive(false);
        }
        else
        {
            storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
            storeWindow.transform.FindChild("Base/TabGasIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_n";
            storeWindow.transform.FindChild("Base/TabMedalIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";

            storeWindow.transform.FindChild("TabCoin").GetComponent<UIPanel>().alpha = 0;
            storeWindow.transform.FindChild("TabCoin").gameObject.SetActive(false);

            storeWindow.transform.FindChild("TabGas").gameObject.SetActive(true);
            storeWindow.transform.FindChild("TabGas").GetComponent<UIPanel>().alpha = 1;

            storeWindow.transform.FindChild("TabMedal").GetComponent<UIPanel>().alpha = 0;
            storeWindow.transform.FindChild("TabMedal").gameObject.SetActive(false);

            if (equipWindows.transform.localPosition.x == 40)
            {
                equipToStoreOn = true;
                equipWindows.animation.Play("StoreWindowAnim03");
                equipWindows.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
            }
            else if (ResultPanel.transform.FindChild("ResultPanelLeft").transform.localPosition.x == 0)
            {
                resultToStoreOn = true;
                ResultPanel.transform.FindChild("ResultPanelLeft").animation.Play("ResultPanelLeftAnim03");
                ResultPanel.transform.FindChild("ResultPanelRight").animation.Play("ResultPanelRightAnim02");
                yield return new WaitForSeconds(1f);
            }
            else if (skinSelectWindow00.transform.localPosition.x == 40)
            {
                skin00ToStoreOn = true;
                skinSelectWindow00.animation.Play("SkinSelectWindowAnim03");
                skinSelectWindow00.transform.FindChild("BackBtn").gameObject.SetActive(false);
            }
            else if (skinSelectWindow01.transform.localPosition.x == 40)
            {
                skin01ToStoreOn = true;
                skinSelectWindow01.animation.Play("SkinSelectWindowAnim03");
                skinSelectWindow01.transform.FindChild("BackBtn").gameObject.SetActive(false);
            }
            else if (skinSelectWindow02.transform.localPosition.x == 40)
            {
                skin02ToStoreOn = true;
                skinSelectWindow02.animation.Play("SkinSelectWindowAnim03");
                skinSelectWindow02.transform.FindChild("BackBtn").gameObject.SetActive(false);
            }
            else if (equipWindows.transform.localPosition.x == 40)
            {
                equipToStoreOn = true;
                equipWindows.animation.Play("StoreWindowAnim03");
                equipWindows.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
            }
            else
            {
                noTouchPanel.SetActive(true);
                flights.animation.Play("FlightsPanelAnim02");
            }
            storeWindow.animation.Play("StoreWindowAnim01");
            yield return new WaitForSeconds(0.5f);
            storeWindow.transform.FindChild("Base/BackBtn").gameObject.SetActive(true);
        }

        storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().MakePixelPerfect();
        storeWindow.transform.FindChild("Base/TabGasIcon").GetComponent<UISprite>().MakePixelPerfect();
        storeWindow.transform.FindChild("Base/TabMedalIcon").GetComponent<UISprite>().MakePixelPerfect();
    }


    void GoToStoreMedalWindowDirect()
    {
        GetComponent<HangarPopupController>().CloseWindow();
        StartCoroutine(GoToStoreMedalWindowI());
    }

    void GoToStoreMedalWindow()
    {
        GetComponent<HangarPopupController>().CloseWindow(GoToStoreMedalWindowV);
    }

    void GoToStoreMedalWindowV()
    {
        StartCoroutine(GoToStoreMedalWindowI());
    }

    private IEnumerator GoToStoreMedalWindowI()
    {

        storeWindow.SetActive(true);

        if (storeWindow.transform.localPosition.x == 40)
        {
            StartCoroutine(TransChange(storeWindow.transform.FindChild("TabCoin").gameObject, 0));
            StartCoroutine(TransChange(storeWindow.transform.FindChild("TabGas").gameObject, 0));
            StartCoroutine(TransChange(storeWindow.transform.FindChild("TabMedal").gameObject, 1));

            storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
            storeWindow.transform.FindChild("Base/TabGasIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
            storeWindow.transform.FindChild("Base/TabMedalIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_n";
            noTouchPanel.SetActive(false);
        }
        else
        {
            storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
            storeWindow.transform.FindChild("Base/TabGasIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
            storeWindow.transform.FindChild("Base/TabMedalIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_n";

            storeWindow.transform.FindChild("TabCoin").GetComponent<UIPanel>().alpha = 0;
            storeWindow.transform.FindChild("TabCoin").gameObject.SetActive(false);

            storeWindow.transform.FindChild("TabGas").GetComponent<UIPanel>().alpha = 0;
            storeWindow.transform.FindChild("TabGas").gameObject.SetActive(false);

            storeWindow.transform.FindChild("TabMedal").gameObject.SetActive(true);
            storeWindow.transform.FindChild("TabMedal").GetComponent<UIPanel>().alpha = 1;

            if (equipWindows.transform.localPosition.x == 40)
            {
                equipToStoreOn = true;
                equipWindows.animation.Play("StoreWindowAnim03");
                equipWindows.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
            }
            else if (ResultPanel.transform.FindChild("ResultPanelLeft").transform.localPosition.x == 0)
            {
                resultToStoreOn = true;
                ResultPanel.transform.FindChild("ResultPanelLeft").animation.Play("ResultPanelLeftAnim03");
                ResultPanel.transform.FindChild("ResultPanelRight").animation.Play("ResultPanelRightAnim02");
                yield return new WaitForSeconds(1f);
            }
            else if (skinSelectWindow00.transform.localPosition.x == 40)
            {
                skin00ToStoreOn = true;
                skinSelectWindow00.animation.Play("SkinSelectWindowAnim03");
                skinSelectWindow00.transform.FindChild("BackBtn").gameObject.SetActive(false);
            }
            else if (skinSelectWindow01.transform.localPosition.x == 40)
            {
                skin01ToStoreOn = true;
                skinSelectWindow01.animation.Play("SkinSelectWindowAnim03");
                skinSelectWindow01.transform.FindChild("BackBtn").gameObject.SetActive(false);
            }
            else if (skinSelectWindow02.transform.localPosition.x == 40)
            {
                skin02ToStoreOn = true;
                skinSelectWindow02.animation.Play("SkinSelectWindowAnim03");
                skinSelectWindow02.transform.FindChild("BackBtn").gameObject.SetActive(false);
            }
            else
            {
                noTouchPanel.SetActive(true);
                flights.animation.Play("FlightsPanelAnim02");
            }
            storeWindow.animation.Play("StoreWindowAnim01");
            yield return new WaitForSeconds(0.5f);
            storeWindow.transform.FindChild("Base/BackBtn").gameObject.SetActive(true);
        }

        storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().MakePixelPerfect();
        storeWindow.transform.FindChild("Base/TabGasIcon").GetComponent<UISprite>().MakePixelPerfect();
        storeWindow.transform.FindChild("Base/TabMedalIcon").GetComponent<UISprite>().MakePixelPerfect();
    }

    //친구관련창.
    private IEnumerator GoToFriendRankTab()
    {
        prepareReady.transform.FindChild("FriendPointBtn").gameObject.SetActive(true);

        ValueDeliverScript.AllMessageCount = 0;

        noTouchPanel.SetActive(true);

        GetComponent<HangarPopupController>().CloseWindow();


        //게임종료후 결과창에서 친구 정보창으로 이동할때만 작동하는 코드이다//
        if (ResultPanel.transform.FindChild("ResultPanelLeft").transform.localPosition.x == 0)
        {
            Debug.Log("PrepareReadyAnim01");
            ResultPanel.transform.FindChild("ResultPanelLeft").animation.Play("ResultPanelLeftAnim03");
            ResultPanel.transform.FindChild("ResultPanelRight").animation.Play("ResultPanelRightAnim02");
            ResultPanel.transform.FindChild("ResultLowTab").animation.Play("ResultLowTabAnim02");
            yield return new WaitForSeconds(1f);

            prepareReady.transform.FindChild("RankFriendTF").gameObject.SetActive(true);
            Debug.Log("PrepareReadyAnim01");

            //메세지 유무 여부에 따라 깜박이 보이게 할지 안보이게 할지 결정//
            if (ValueDeliverScript.messageData.Length != 0) GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(true);
            else GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(false);

            prepareReady.animation.Play("PrepareReadyAnim01");
            bgTop.animation.Play("BGMainTopAnim02");
            yield return new WaitForSeconds(0.4f);
            friendWindow.animation.Play("FriendWindowAnim01");
            yield return new WaitForSeconds(0.5f);
            friendWindow.transform.FindChild("BackBtn").gameObject.SetActive(true);

            yield break;
        }
        //게임종료후 결과창에서 친구 정보창으로 이동할때만 작동하는 코드이다//

        //하단의 정보창에서 정보를 어떻게 보여줄 것인가를 결정하고 그에 따른 다른 애니메이션을 작동하게 하는것//
        //친구포인트가 100이상이면 친구 보상을 받을수 있게 버튼을 보여주고//
        //그렇지 않으면 보상 버튼을 보이지 않게 하는 애니메이션을 실행한다//
        else if (ValueDeliverScript.buddyPoint < 100)
        {
            Debug.Log("PrepareReadyAnim03");
            prepareReady.animation.Play("PrepareReadyAnim03");
        }
        else
        {
            Debug.Log("PrepareReadyAnim03_1");
            prepareReady.animation.Play("PrepareReadyAnim03_1");
        }
        //하단의 정보창에서 정보를 어떻게 보여줄 것인가를 결정하고 그에 따른 다른 애니메이션을 작동하게 하는것//

        //friendWindow는 친구 랭킹이 표시되는 창을 뜻한다//
        friendWindow.SetActive(true);
        friendWindow.transform.FindChild("Script01").GetComponent<UILabel>().text = "Touch Friends Tab to see More Info.";
        friendWindow.transform.FindChild("Script02").GetComponent<UILabel>().text = "Send Fuels to Get Buddy Points.";
        friendWindow.transform.FindChild("AllMessageBtn").gameObject.SetActive(false);   //메세지 전부 받기 버튼은 활성화 되어 있다면 무저건 꺼준다.

        //메세지가 한개이상 있으면 뉴 아이콘을 켜준다//
        if (ValueDeliverScript.messageData.Length == 0) friendWindow.transform.FindChild("NewIcn").gameObject.SetActive(false);
        else friendWindow.transform.FindChild("NewIcn").gameObject.SetActive(true);

        //시간을 계산하여 앞으로 초기화가 얼마나 남았는지 알아내는 코드//
        //남은시간을 상단 텍스트 표시부분에 반영하여 얼마가 남았는지 알려준다//
        DayOfWeek todayWeek = DateTime.UtcNow.AddHours(7).DayOfWeek;
        int dayCount = (int)todayWeek;
        int remainDays = 7 - dayCount;
        if (dayCount == 0) remainDays = 0;

        int remainHours = 23 - Mathf.FloorToInt((float)DateTime.UtcNow.AddHours(7).TimeOfDay.TotalHours);

        string dayString;

        if (remainDays > 1)
        {
            dayString = "Days";
        }
        else
        {
            dayString = "Day";
        }

        string hourString;

        if (remainHours > 1)
        {
            hourString = "Hours";
        }
        else
        {
            hourString = "Hour";
        }
        //Reset after N days and N hours
        friendWindow.transform.FindChild("Script03").GetComponent<UILabel>().text = "Reset after" + remainDays + " " + dayString + ", " + remainHours + " " + hourString;
        //시간을 계산하여 앞으로 초기화가 얼마나 남았는지 알아내는 코드//
        //남은시간을 상단 텍스트 표시부분에 반영하여 얼마가 남았는지 알려준다//

        if (friendWindow.transform.localPosition.x == 40)
        {
            StartCoroutine(TransChange(friendWeekTab, 1));
            StartCoroutine(TransChange(wRankab, 0));
            StartCoroutine(TransChange(friendMailTab, 0));
            friendWindow.transform.FindChild("TapSprits/RankTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_00";
            friendWindow.transform.FindChild("TapSprits/WRankTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_01";
            friendWindow.transform.FindChild("TapSprits/MailTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_01";
        }
        else
        {
            friendWindow.transform.FindChild("TapSprits/RankTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_00";
            friendWindow.transform.FindChild("TapSprits/WRankTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_01";
            friendWindow.transform.FindChild("TapSprits/MailTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_01";

            friendWeekTab.GetComponent<UIPanel>().alpha = 1;
            friendWeekTab.SetActive(true);

            wRankab.GetComponent<UIPanel>().alpha = 0;
            wRankab.SetActive(false);

            friendMailTab.GetComponent<UIPanel>().alpha = 0;
            friendMailTab.SetActive(false);

            if (equipWindows.transform.localPosition.x == 40)
            {
                equipToStoreOn = true;
                equipWindows.animation.Play("StoreWindowAnim03");
                equipWindows.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
            }
            else if (skinSelectWindow00.transform.localPosition.x == 40)
            {
                skin00ToStoreOn = true;
                skinSelectWindow00.animation.Play("SkinSelectWindowAnim03");
                skinSelectWindow00.transform.FindChild("BackBtn").gameObject.SetActive(false);
            }
            else if (skinSelectWindow01.transform.localPosition.x == 40)
            {
                skin01ToStoreOn = true;
                skinSelectWindow01.animation.Play("SkinSelectWindowAnim03");
                skinSelectWindow01.transform.FindChild("BackBtn").gameObject.SetActive(false);
            }
            else if (skinSelectWindow02.transform.localPosition.x == 40)
            {
                skin02ToStoreOn = true;
                skinSelectWindow02.animation.Play("SkinSelectWindowAnim03");
                skinSelectWindow02.transform.FindChild("BackBtn").gameObject.SetActive(false);
            }
            else if (storeWindow.transform.localPosition.x == 40)
            {
                storeToFriendOn = true;
                storeWindow.animation.Play("StoreWindowAnim03");
                storeWindow.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
            }
            else if (flights.transform.localPosition.x == 0)
            {
                mainToFriendOn = true;
                flights.animation.Play("FlightsPanelAnim02");
            }
            bgTop.animation.Play("BGMainTopAnim02");
            yield return new WaitForSeconds(0.4f);
            friendWindow.animation.Play("FriendWindowAnim01");
            yield return new WaitForSeconds(0.5f);
            friendWindow.transform.FindChild("BackBtn").gameObject.SetActive(true);
        }


        //페북 로그인을 하지 않은 유저는 페북 랭킹창을 볼 수 없게 만든다//
        if (ValueDeliverScript.myFBid == "" || ValueDeliverScript.myFBid == null)
        {
            GoToWorldRankTab(true);
        }
    }

    private IEnumerator EscapeFriendWindow()
    {
        friendWindow.transform.FindChild("AllMessageBtn").gameObject.SetActive(false);
        friendWindow.SetActive(true);

        friendWeekTab.GetComponent<RankViewControl>().IsAbleF();
        friendMailTab.GetComponent<RankViewControl>().IsAbleF();
        bgTop.animation.Play("BGMainTopAnim01");

        if (equipToStoreOn)
        {
            Debug.Log("equipToStoreOn");
            equipWindows.animation.Play("StoreWindowAnim01");
            equipToStoreOn = false;

            friendWindow.transform.FindChild("BackBtn").gameObject.SetActive(false);
            friendWindow.animation.Play("FriendWindowAnim02");

            yield return new WaitForSeconds(0.5f);
            equipWindows.transform.FindChild("Base/BackBtn").gameObject.SetActive(true);
        }
        else if (skin00ToStoreOn)
        {
            Debug.Log("skin00ToStoreOn");
            skinSelectWindow00.animation.Play("SkinSelectWindowAnim01");
            skin00ToStoreOn = false;

            friendWindow.transform.FindChild("BackBtn").gameObject.SetActive(false);
            friendWindow.animation.Play("FriendWindowAnim03");

            yield return new WaitForSeconds(0.5f);
            skinSelectWindow00.transform.FindChild("BackBtn").gameObject.SetActive(true);
        }
        else if (skin01ToStoreOn)
        {
            Debug.Log("skin01ToStoreOn");
            skinSelectWindow01.animation.Play("SkinSelectWindowAnim01");
            skin01ToStoreOn = false;

            friendWindow.transform.FindChild("BackBtn").gameObject.SetActive(false);
            friendWindow.animation.Play("FriendWindowAnim03");

            yield return new WaitForSeconds(0.5f);
            skinSelectWindow01.transform.FindChild("BackBtn").gameObject.SetActive(true);
        }
        else if (skin02ToStoreOn)
        {
            Debug.Log("skin02ToStoreOn");
            skinSelectWindow02.animation.Play("SkinSelectWindowAnim01");
            skin02ToStoreOn = false;

            friendWindow.transform.FindChild("BackBtn").gameObject.SetActive(false);
            friendWindow.animation.Play("FriendWindowAnim03");

            yield return new WaitForSeconds(0.5f);
            skinSelectWindow02.transform.FindChild("BackBtn").gameObject.SetActive(true);
        }
        else if (storeToFriendOn)
        {
            Debug.Log("storeToFriendOn");
            storeWindow.animation.Play("StoreWindowAnim01");
            storeToFriendOn = false;

            friendWindow.transform.FindChild("BackBtn").gameObject.SetActive(false);
            friendWindow.animation.Play("FriendWindowAnim03");

            yield return new WaitForSeconds(0.5f);
            storeWindow.transform.FindChild("Base/BackBtn").gameObject.SetActive(true);
        }
        else if (mainToFriendOn)
        {
            Debug.Log("mainToFriendOn");
            mainToFriendOn = false;
            flights.animation.Play("FlightsPanelAnim01");
            friendWindow.transform.FindChild("BackBtn").gameObject.SetActive(false);
            friendWindow.animation.Play("FriendWindowAnim02");
            flightUpointSetScript.CalRemainPoint();
            flightUpointSetScript.IsBtnAnimationFirst();
            flightUpointSetScript.RemainPointLabel();
        }
        else
        {
            Debug.Log("Null");
            flights.animation.Play("FlightsPanelAnim01");
            friendWindow.transform.FindChild("BackBtn").gameObject.SetActive(false);
            friendWindow.animation.Play("FriendWindowAnim02");
        }

        //하단 버튼과 정보창에 대한 애니메이션을 해준다.
        if (prepareReady.transform.FindChild("FriendPointBtn").localPosition.x != 0)
        {
            Debug.Log("No 0");
            Debug.Log("PrepareReadyAnim03_4");

            //메세지 유무 여부에 따라 깜박이 보이게 할지 안보이게 할지 결정//
            if (ValueDeliverScript.messageData.Length != 0) GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(true);
            else GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(false);

            prepareReady.animation.Play("PrepareReadyAnim03_4");
        }
        else
        {
            Debug.Log("Yes 0");
            Debug.Log("PrepareReadyAnim03_3");

            //메세지 유무 여부에 따라 깜박이 보이게 할지 안보이게 할지 결정//
            if (ValueDeliverScript.messageData.Length != 0) GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(true);
            else GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(false);

            prepareReady.animation.Play("PrepareReadyAnim03_3");
        }

        yield return new WaitForSeconds(0.2f);

        if (ValueDeliverScript.isResultToHanger)
        {
            Debug.Log("isResultToHanger");

            if (resultSkinNumber != 0 && resultSkinName <= 0)
            {
                //스킨 내구도가 0이하로 떨어지면 이 부분을 실행!
                //스킨 내구도 복구 유도 창을 띄운다.

                GetComponent<HangarPopupController>().AddPopWin(duraBuyAlarmWindow, 0);

                //duraBuyAlarmWindow.SetActive(true);
                //halfBLKPanel.SetActive(true);
                //halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, duraBuyAlarmWindow.transform.localPosition.z + 5);
            }

            ValueDeliverScript.isResultToHanger = false;
        }
    }






    //BuddyPoint Over 100 팝업이 생길수 있는 상황과 관련된 메소드 모음//
    //BuddyPoint Over 100 팝업이 생길수 있는 상황과 관련된 메소드 모음//
    //BuddyPoint Over 100 팝업이 생길수 있는 상황과 관련된 메소드 모음//
    #region BuddyPoint Over 100 팝업이 생길수 있는 상황과 관련된 메소드 모음//
    Action buddy100LaterNextF;
    Action buddy100GetNextF;
    //일반 상황에서 이큅창(준비하기)으로 이동할때 호출되는 메소드//
    void GotoEquipWindowsReady01()
    {
        int buddyPoint = ValueDeliverScript.buddyPoint;
        //buddyPoint = 100;   //임시//
        if (buddyPoint >= 100)
        {
            GetComponent<HangarPopupController>().AddPopWin(buddyPoint100, -1);
            buddy100GetNextF = new Action(Buddy100GetRank1);    //Get를 선택했을때 작동할 메소드를 지정한다//
            buddy100LaterNextF = new Action(Buddy100LaterFEquip1);  //Later을 선택했을때 작동할 메소드를 지정한다//
        }
        else
        {
            StartCoroutine(GotoEquipWindows());
        }
    }

    //결과창에서 바로 이큅창(준비하기)으로 이동할때 호출되는 메소드//
    void GotoEquipWindowsReady02()
    {
        int buddyPoint = ValueDeliverScript.buddyPoint;
        //buddyPoint = 100;   //임시//
        if (buddyPoint >= 100)
        {
            GetComponent<HangarPopupController>().AddPopWin(buddyPoint100, -1);
            buddy100GetNextF = new Action(Buddy100GetRank2);    //Get를 선택했을때 작동할 메소드를 지정한다//
            buddy100LaterNextF = new Action(Buddy100LaterFEquip2);  //Later을 선택했을때 작동할 메소드를 지정한다//
        }
        else
        {
            StartCoroutine(GotoEquipWindows2());
        }
    }

    //100point 창에서 Get을 선택했을때 랭크창으로 이동할때 실행되는 메소드
    void CloseBuddyPoint100WindowGet()
    {
        GetComponent<HangarPopupController>().CloseWindow();
        buddy100GetNextF();
    }

    //100point 창에서 Later을 선택했을때 랭크창으로 이동할때 실행되는 메소드
    void CloseBuddyPoint100WindowLater()
    {
        GetComponent<HangarPopupController>().CloseWindow();
        buddy100LaterNextF();
    }


    //Get
    void Buddy100GetRank1()
    {
        StartCoroutine(GoToFriendRankTab());
    }
    void Buddy100GetRank2()
    {
        StartCoroutine(GoToGarage2());
    }

    //Later
    void Buddy100LaterFEquip1()
    {
        StartCoroutine(GotoEquipWindows());
    }
    void Buddy100LaterFEquip2()
    {
        StartCoroutine(GotoEquipWindows2());
    }
    #endregion
    //BuddyPoint Over 100 팝업이 생길수 있는 상황과 관련된 메소드 모음//
    //BuddyPoint Over 100 팝업이 생길수 있는 상황과 관련된 메소드 모음//
    //BuddyPoint Over 100 팝업이 생길수 있는 상황과 관련된 메소드 모음//









    //장비구매창.
    public IEnumerator GotoEquipWindows()  //최초 이큅 윈도우를 열때 작동하는 함수.
    {
        prepareReady.transform.FindChild("FriendPointBtn").gameObject.SetActive(false);
        prepareReady.transform.FindChild("RankFriendTF").gameObject.SetActive(false);

        noTouchPanel.SetActive(true);
        GetComponent<FlightSelectBtnScript>().EquipOffBtn();

        #region 어떤 창이 현재 활성화 되어있는지 확인하여 그 확인된 창을 감추는 애니메이션을 실행

        if (storeWindow.transform.localPosition.x == 40)    //스토어(연료,돈,메달)
        {
            storeWindow.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
            storeWindow.animation.Play("StoreWindowAnim03");
        }
        else if (skinSelectWindow00.transform.localPosition.x == 40)    //포커스킨.
        {
            skinSelectWindow00.transform.FindChild("BackBtn").gameObject.SetActive(false);
            skinSelectWindow00.animation.Play("SkinSelectWindowAnim03");
            SkinWindowClose();
        }
        else if (skinSelectWindow01.transform.localPosition.x == 40)    //코만치스킨.
        {
            skinSelectWindow01.transform.FindChild("BackBtn").gameObject.SetActive(false);
            skinSelectWindow01.animation.Play("SkinSelectWindowAnim03");
            SkinWindowClose();
        }
        else if (skinSelectWindow02.transform.localPosition.x == 40)    //팬텀스킨.
        {
            skinSelectWindow02.transform.FindChild("BackBtn").gameObject.SetActive(false);
            skinSelectWindow02.animation.Play("SkinSelectWindowAnim03");
            SkinWindowClose();
        }
        else if (friendWindow.transform.localPosition.x == 40)   //친구목록(랭킹).
        {
            friendWindow.transform.FindChild("BackBtn").gameObject.SetActive(false);
            friendWindow.animation.Play("FriendWindowAnim03");
            bgTop.animation.Play("BGMainTopAnim01");
            if (ValueDeliverScript.buddyPoint < 100)
            {
                Debug.Log("PrepareReadyAnim02_2");
                prepareReady.animation.Play("PrepareReadyAnim02_2");
            }
            else
            {
                Debug.Log("PrepareReadyAnim02_1");
                prepareReady.animation.Play("PrepareReadyAnim02_1");
            }
        }
        else
        {
            flights.animation.Play("FlightsPanelAnim02");   //비행기 선택.
        }

        #endregion 어떤 창이 현재 활성화 되어있는지 확인하여 그 확인된 창을 감추는 애니메이션을 실행

        #region 최초 이큅창이 열릴때의 세팅을 함.

        #region 이큅창에서 처음 나오는 탭의 맨 좌측 아이템을 셀렉트 해서 하단 메세지 부분에 아이템의 이름과 성격 가격등을 보여준다.

        ItemKeyValueScript firstItem = equipBombTab.transform.FindChild("Item/ItemBox01").GetComponent<ItemKeyValueScript>();

        equipItemName.GetComponent<UILabel>().text = firstItem.itemName;
        equipItemPrice.GetComponent<UILabel>().text = firstItem.itemCoinCost.ToString();
        equipItemScript.GetComponent<UILabel>().text = firstItem.itemScript;

        #endregion 이큅창에서 처음 나오는 탭의 맨 좌측 아이템을 셀렉트 해서 하단 메세지 부분에 아이템의 이름과 성격 가격등을 보여준다.

        #region 셀렉트 표시를 창을 열었을때는 항상 최좌측에 위치하도록 함.

        equipBombTab.transform.FindChild("Item/HilightItem").localPosition = new Vector3(-326, 68, 6);

        #endregion 셀렉트 표시를 창을 열었을때는 항상 최좌측에 위치하도록 함.

        #region 내부적으로 최초 창(탭)을 열었을때는 최좌측 아이템이 내부적으로도 선택되어 있는 것으로 기록하도록 함.

        ValueDeliverScript.SelectedItem = equipBombTab.transform.FindChild("Item/ItemBox01").gameObject;
        ValueDeliverScript.purchaseCharge = equipBombTab.transform.FindChild("Item/ItemBox01").GetComponent<ItemKeyValueScript>().itemCoinCost;
        ValueDeliverScript.SelectedItemSprite = equipBombTab.transform.FindChild("Item/ItemBox01/Item").GetComponent<UISprite>().spriteName;
        mountIconTemp = equipBombTab.transform.FindChild("Item/MountItem").gameObject;

        #endregion 내부적으로 최초 창(탭)을 열었을때는 최좌측 아이템이 내부적으로도 선택되어 있는 것으로 기록하도록 함.

        #endregion 최초 이큅창이 열릴때의 세팅을 함.

        GoToEquipBombTab();

        //이큅윈도우가 보이는 애니메이션을 실행.
        equipWindows.animation.Play("StoreWindowAnim01");

        if (friendWindow.transform.localPosition.x != 40)
            //하단 바의 준비 아이콘들이 들어가는 애니메이션을 실행.
            Debug.Log("PrepareReadyAnim02");
        prepareReady.animation.Play("PrepareReadyAnim02");

        //0.5초 쉼.
        yield return new WaitForSeconds(0.5f);
        //이큅창을 사라지게 하고 이전 창으로 돌릴수 있는 백버튼을 보이게함.
        equipWindows.transform.FindChild("Base/BackBtn").gameObject.SetActive(true);
        //0.5초 쉼.
        yield return new WaitForSeconds(0.5f);
        //하단 바의 출격 아이콘들이 나오는 애니메이션을 실행.
        attackReady.animation.Play("AttackReadyAnim01");
    }


    private IEnumerator GotoEquipWindows2()
    {
        noTouchPanel.SetActive(true);
        if (ValueDeliverScript.isBgSound == true) //소리가 켜져있을경우 결과창 BGM에서 격납고 BGM으로 변경.
        {
            AudioSource resultSound = GameObject.Find("ResultSoundManager").GetComponent<AudioSource>();
            AudioSource bgSound = GameObject.Find("BgSoundManager").GetComponent<AudioSource>();
            resultSound.volume = 1f;
            bgSound.volume = 0f;
            bgSound.Play();

            while (resultSound.volume > 0)
            {
                resultSound.volume -= Time.deltaTime * 4;
                bgSound.volume += Time.deltaTime * 4;
                yield return null;
            }
        }

        if (storeWindow.transform.localPosition.x == 40)
        {
            storeWindow.animation.Play("StoreWindowAnim02");
        }
        else
        {
            ResultPanel.transform.FindChild("ResultPanelLeft").animation.Play("ResultPanelLeftAnim03");
            ResultPanel.transform.FindChild("ResultPanelRight").animation.Play("ResultPanelRightAnim02");
        }
        ResultPanel.transform.FindChild("ResultLowTab").animation.Play("ResultLowTabAnim02");

        yield return new WaitForSeconds(1f);
        ////////////////////////////////////////
        ////////////////////////////////////////

        #region 최초 이큅창이 열릴때의 세팅을 함.

        #region 이큅창에서 처음 나오는 탭의 맨 좌측 아이템을 셀렉트 해서 하단 메세지 부분에 아이템의 이름과 성격 가격등을 보여준다.

        ItemKeyValueScript firstItem = equipBombTab.transform.FindChild("Item/ItemBox01").GetComponent<ItemKeyValueScript>();

        equipItemName.GetComponent<UILabel>().text = firstItem.itemName;
        equipItemPrice.GetComponent<UILabel>().text = firstItem.itemCoinCost.ToString();
        equipItemScript.GetComponent<UILabel>().text = firstItem.itemScript;

        #endregion 이큅창에서 처음 나오는 탭의 맨 좌측 아이템을 셀렉트 해서 하단 메세지 부분에 아이템의 이름과 성격 가격등을 보여준다.

        #region 셀렉트 표시를 창을 열었을때는 항상 최좌측에 위치하도록 함.

        equipBombTab.transform.FindChild("Item/HilightItem").localPosition = new Vector3(-326, 68, 6);

        #endregion 셀렉트 표시를 창을 열었을때는 항상 최좌측에 위치하도록 함.

        #region 내부적으로 최초 창(탭)을 열었을때는 최좌측 아이템이 내부적으로도 선택되어 있는 것으로 기록하도록 함.

        ValueDeliverScript.SelectedItem = equipBombTab.transform.FindChild("Item/ItemBox01").gameObject;
        ValueDeliverScript.purchaseCharge = equipBombTab.transform.FindChild("Item/ItemBox01").GetComponent<ItemKeyValueScript>().itemCoinCost;
        ValueDeliverScript.SelectedItemSprite = equipBombTab.transform.FindChild("Item/ItemBox01/Item").GetComponent<UISprite>().spriteName;
        mountIconTemp = equipBombTab.transform.FindChild("Item/MountItem").gameObject;

        #endregion 내부적으로 최초 창(탭)을 열었을때는 최좌측 아이템이 내부적으로도 선택되어 있는 것으로 기록하도록 함.

        #endregion 최초 이큅창이 열릴때의 세팅을 함.

        //위큅윈도우가 보이는 애니메이션을 실행.
        equipWindows.animation.Play("StoreWindowAnim01");
        //하단 바의 준비 아이콘들이 들어가는 애니메이션을 실행.
        //prepareReady.animation.Play("PrepareReadyAnim02");
        //0.5초 쉼.
        //yield return new WaitForSeconds(0.5f);
        //이큅창을 사라지게 하고 이전 창으로 돌릴수 있는 백버튼을 보이게함.
        equipWindows.transform.FindChild("Base/BackBtn").gameObject.SetActive(true);
        //0.5초 쉼.
        yield return new WaitForSeconds(0.5f);
        //하단 바의 출격 아이콘들이 나오는 애니메이션을 실행.
        attackReady.animation.Play("AttackReadyAnim01");

        noTouchPanel.SetActive(false);
    }

    private IEnumerator ShowAttackButton()
    {
        StartCoroutine(PrepareReady());
        yield return new WaitForSeconds(0.25f);
        yield return StartCoroutine(AttackReady());

        if (skinSelectWindow00.transform.parent.name == "WinMove")
        {
            skinSelectWindow00.transform.parent = windows.transform;
            skinSelectWindow00.transform.localPosition = new Vector3(1540, 0, 0);
        }
        if (skinSelectWindow01.transform.parent.name == "WinMove")
        {
            skinSelectWindow01.transform.parent = windows.transform;
            skinSelectWindow01.transform.localPosition = new Vector3(1540, 0, 0);
        }
        if (skinSelectWindow02.transform.parent.name == "WinMove")
        {
            skinSelectWindow02.transform.parent = windows.transform;
            skinSelectWindow02.transform.localPosition = new Vector3(1540, 0, 0);
        }
    }

    private IEnumerator WindowsMove()
    {
        Vector3 firstPosition = winMove.transform.localPosition;
        Vector3 secondPosition = firstPosition + new Vector3(-1500, 0, 0);
        float lValue = 0;

        while (lValue <= 1)
        {
            winMove.transform.localPosition = Vector3.Lerp(firstPosition, secondPosition, lValue);
            lValue += Time.deltaTime * 2f;
            yield return null;
        }
        winMove.transform.localPosition = secondPosition;
    }

    private IEnumerator WindowsMoveReverse(GameObject subWin)
    {
        Vector3 firstPosition = winMove.transform.localPosition;
        Vector3 secondPosition = firstPosition + new Vector3(1500, 0, 0);
        float lValue = 0;

        while (lValue <= 1)
        {
            winMove.transform.localPosition = Vector3.Lerp(firstPosition, secondPosition, lValue);
            lValue += Time.deltaTime * 2f;
            yield return null;
        }
        winMove.transform.localPosition = secondPosition;

        //Debug.Log(subWin.name);
        //Debug.Log(subWin.transform.parent);
        subWin.transform.parent = windows.transform;
        subWin.transform.localPosition = new Vector3(1540, 0, 0);
        //Debug.Log(subWin.transform.parent);
    }

    private IEnumerator PrepareReady()
    {
        Vector3 attackOldPosition = prepareReady.transform.localPosition;

        float lValue = 0;
        while (lValue <= 1)
        {
            prepareReady.transform.localPosition = Vector3.Lerp(attackOldPosition, new Vector3(-1100, 0, 0), lValue);

            lValue += Time.deltaTime * 4;
            yield return null;
        }
        prepareReady.transform.localPosition = new Vector3(-1100, 0, 0);
    }

    private IEnumerator AttackReady()
    {
        GameObject attackReady = GameObject.Find("AttackReady");
        Vector3 prepareOldPosition = attackReady.transform.localPosition;
        yield return null;
        float lValue = 0;
        while (lValue <= 1)
        {
            attackReady.transform.localPosition = Vector3.Lerp(prepareOldPosition, new Vector3(0, 0, 0), lValue);

            lValue += Time.deltaTime * 4;
            yield return null;
        }
        attackReady.transform.localPosition = new Vector3(0, 0, 0);
    }

    private IEnumerator PrepareReadyReverse()
    {
        Vector3 attackOldPosition = prepareReady.transform.localPosition;

        float lValue = 0;
        while (lValue <= 1)
        {
            prepareReady.transform.localPosition = Vector3.Lerp(attackOldPosition, new Vector3(0, 0, 0), lValue);

            lValue += Time.deltaTime * 4;
            yield return null;
        }
        prepareReady.transform.localPosition = new Vector3(0, 0, 0);
    }

    private IEnumerator AttackReadyReverse()
    {
        GameObject attackReady = GameObject.Find("AttackReady");
        Vector3 prepareOldPosition = attackReady.transform.localPosition;
        yield return null;
        float lValue = 0;
        while (lValue <= 1)
        {
            attackReady.transform.localPosition = Vector3.Lerp(prepareOldPosition, new Vector3(-1100, 0, 0), lValue);

            lValue += Time.deltaTime * 4;
            yield return null;
        }
        attackReady.transform.localPosition = new Vector3(-1100, 0, 0);
    }

    public void GoToEquipBombTab()
    {
        GameObject.Find("EquipWindows").transform.FindChild("Base/CoinAbleLabel").GetComponent<UILabel>().text = "";

        purchaseBtn.SetActive(true);
        purchaseBtnlabel.SetActive(true);

        StartCoroutine(TransChange(equipBombTab, 1));
        StartCoroutine(TransChange(equipReinforceTab, 0));
        StartCoroutine(TransChange(equipAssistanceTab, 0));
        StartCoroutine(TransChange(equipOperTab, 0));

        equipWindows.transform.FindChild("Base/TabBomb").GetComponent<UISprite>().spriteName = "bt_blue_t_top_n";
        equipWindows.transform.FindChild("Base/TabReinforce").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
        equipWindows.transform.FindChild("Base/TabAssistance").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
        equipWindows.transform.FindChild("Base/TabOper").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";

        equipWindows.transform.FindChild("Base/TabBomb").GetComponent<UISprite>().MakePixelPerfect();
        equipWindows.transform.FindChild("Base/TabReinforce").GetComponent<UISprite>().MakePixelPerfect();
        equipWindows.transform.FindChild("Base/TabAssistance").GetComponent<UISprite>().MakePixelPerfect();
        equipWindows.transform.FindChild("Base/TabOper").GetComponent<UISprite>().MakePixelPerfect();

        ValueDeliverScript.SelectedItem = null;

        GetComponent<FlightSelectBtnScript>().EquipOffBtn();

        ItemKeyValueScript firstItem = equipBombTab.transform.FindChild("Item/ItemBox01").GetComponent<ItemKeyValueScript>();

        equipWindows.transform.FindChild("Base/GoldIcon").gameObject.SetActive(true);
        equipWindows.transform.FindChild("Base/GoldIcon").GetComponent<UISprite>().spriteName = "icon_small_gold";
        equipItemName.GetComponent<UILabel>().text = firstItem.itemName;
        equipItemPrice.GetComponent<UILabel>().text = firstItem.itemCoinCost.ToString();
        equipItemScript.GetComponent<UILabel>().text = firstItem.itemScript;

        equipBombTab.transform.FindChild("Item/HilightItem").localPosition = new Vector3(-326, 68, 6);

        ValueDeliverScript.SelectedItem = equipBombTab.transform.FindChild("Item/ItemBox01").gameObject;
        ValueDeliverScript.purchaseCharge = equipBombTab.transform.FindChild("Item/ItemBox01").GetComponent<ItemKeyValueScript>().itemCoinCost;
        ValueDeliverScript.SelectedItemSprite = equipBombTab.transform.FindChild("Item/ItemBox01/Item").GetComponent<UISprite>().spriteName;
        mountIconTemp = equipBombTab.transform.FindChild("Item/MountItem").gameObject;
    }

    public void GoToEquipReinforceTab()
    {
        GameObject.Find("EquipWindows").transform.FindChild("Base/CoinAbleLabel").GetComponent<UILabel>().text = "";

        purchaseBtn.SetActive(true);
        purchaseBtnlabel.SetActive(true);

        StartCoroutine(TransChange(equipBombTab, 0));
        StartCoroutine(TransChange(equipReinforceTab, 1));
        StartCoroutine(TransChange(equipAssistanceTab, 0));
        StartCoroutine(TransChange(equipOperTab, 0));

        equipWindows.transform.FindChild("Base/TabBomb").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
        equipWindows.transform.FindChild("Base/TabReinforce").GetComponent<UISprite>().spriteName = "bt_blue_t_top_n";
        equipWindows.transform.FindChild("Base/TabAssistance").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
        equipWindows.transform.FindChild("Base/TabOper").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";

        equipWindows.transform.FindChild("Base/TabBomb").GetComponent<UISprite>().MakePixelPerfect();
        equipWindows.transform.FindChild("Base/TabReinforce").GetComponent<UISprite>().MakePixelPerfect();
        equipWindows.transform.FindChild("Base/TabAssistance").GetComponent<UISprite>().MakePixelPerfect();
        equipWindows.transform.FindChild("Base/TabOper").GetComponent<UISprite>().MakePixelPerfect();

        ValueDeliverScript.SelectedItem = null;

        Transform item = equipWindows.transform.FindChild("EquipReinforceTab/Item");
        item.localPosition = new Vector3(0, item.localPosition.y, item.localPosition.z);
        GetComponent<FlightSelectBtnScript>().EquipOffLeftBtn();

        ItemKeyValueScript firstItem = equipReinforceTab.transform.FindChild("Item/ItemBox01").GetComponent<ItemKeyValueScript>();

        equipWindows.transform.FindChild("Base/GoldIcon").gameObject.SetActive(true);
        equipWindows.transform.FindChild("Base/GoldIcon").GetComponent<UISprite>().spriteName = "icon_small_gold";
        equipItemName.GetComponent<UILabel>().text = firstItem.itemName;
        equipItemPrice.GetComponent<UILabel>().text = firstItem.itemCoinCost.ToString();
        equipItemScript.GetComponent<UILabel>().text = firstItem.itemScript;

        equipReinforceTab.transform.FindChild("Item/HilightItem").localPosition = new Vector3(-326, 68, 6);

        ValueDeliverScript.SelectedItem = equipReinforceTab.transform.FindChild("Item/ItemBox01").gameObject;
        ValueDeliverScript.purchaseCharge = equipReinforceTab.transform.FindChild("Item/ItemBox01").GetComponent<ItemKeyValueScript>().itemCoinCost;
        ValueDeliverScript.SelectedItemSprite = equipReinforceTab.transform.FindChild("Item/ItemBox01/Item").GetComponent<UISprite>().spriteName;
        mountIconTemp = equipReinforceTab.transform.FindChild("Item/MountItem").gameObject;
    }

    public void GoToEquipAssistanceTab()
    {
        GameObject.Find("EquipWindows").transform.FindChild("Base/CoinAbleLabel").GetComponent<UILabel>().text = "";

        purchaseBtn.SetActive(true);
        purchaseBtnlabel.SetActive(true);

        StartCoroutine(TransChange(equipBombTab, 0));
        StartCoroutine(TransChange(equipReinforceTab, 0));
        StartCoroutine(TransChange(equipAssistanceTab, 1));
        StartCoroutine(TransChange(equipOperTab, 0));

        equipWindows.transform.FindChild("Base/TabBomb").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
        equipWindows.transform.FindChild("Base/TabReinforce").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
        equipWindows.transform.FindChild("Base/TabAssistance").GetComponent<UISprite>().spriteName = "bt_blue_t_top_n";
        equipWindows.transform.FindChild("Base/TabOper").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";

        equipWindows.transform.FindChild("Base/TabBomb").GetComponent<UISprite>().MakePixelPerfect();
        equipWindows.transform.FindChild("Base/TabReinforce").GetComponent<UISprite>().MakePixelPerfect();
        equipWindows.transform.FindChild("Base/TabAssistance").GetComponent<UISprite>().MakePixelPerfect();
        equipWindows.transform.FindChild("Base/TabOper").GetComponent<UISprite>().MakePixelPerfect();

        ValueDeliverScript.SelectedItem = null;
        GetComponent<FlightSelectBtnScript>().EquipOffBtn();

        ItemKeyValueScript firstItem = equipAssistanceTab.transform.FindChild("Item/ItemBox01").GetComponent<ItemKeyValueScript>();

        equipWindows.transform.FindChild("Base/GoldIcon").gameObject.SetActive(true);
        equipWindows.transform.FindChild("Base/GoldIcon").GetComponent<UISprite>().spriteName = "icon_small_gold";
        equipItemName.GetComponent<UILabel>().text = firstItem.itemName;
        equipItemPrice.GetComponent<UILabel>().text = firstItem.itemCoinCost.ToString();
        equipItemScript.GetComponent<UILabel>().text = firstItem.itemScript;

        equipAssistanceTab.transform.FindChild("Item/HilightItem").localPosition = new Vector3(-326, 68, 6);

        ValueDeliverScript.SelectedItem = equipAssistanceTab.transform.FindChild("Item/ItemBox01").gameObject;
        ValueDeliverScript.purchaseCharge = equipAssistanceTab.transform.FindChild("Item/ItemBox01").GetComponent<ItemKeyValueScript>().itemCoinCost;
        ValueDeliverScript.SelectedItemSprite = equipAssistanceTab.transform.FindChild("Item/ItemBox01/Item").GetComponent<UISprite>().spriteName;
        mountIconTemp = equipAssistanceTab.transform.FindChild("Item/MountItem").gameObject;
    }

    public void GoToEquipOperTab()
    {
        //코인구매가능 글씨 감춤.
        GameObject.Find("EquipWindows").transform.FindChild("Base/CoinAbleLabel").GetComponent<UILabel>().text = "";

        purchaseBtn.SetActive(false);
        purchaseBtnlabel.SetActive(false);

        StartCoroutine(TransChange(equipBombTab, 0));
        StartCoroutine(TransChange(equipReinforceTab, 0));
        StartCoroutine(TransChange(equipAssistanceTab, 0));
        StartCoroutine(TransChange(equipOperTab, 1));

        equipWindows.transform.FindChild("Base/TabBomb").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
        equipWindows.transform.FindChild("Base/TabReinforce").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
        equipWindows.transform.FindChild("Base/TabAssistance").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
        equipWindows.transform.FindChild("Base/TabOper").GetComponent<UISprite>().spriteName = "bt_blue_t_top_n";

        equipWindows.transform.FindChild("Base/TabBomb").GetComponent<UISprite>().MakePixelPerfect();
        equipWindows.transform.FindChild("Base/TabReinforce").GetComponent<UISprite>().MakePixelPerfect();
        equipWindows.transform.FindChild("Base/TabAssistance").GetComponent<UISprite>().MakePixelPerfect();
        equipWindows.transform.FindChild("Base/TabOper").GetComponent<UISprite>().MakePixelPerfect();

        ValueDeliverScript.SelectedItem = null;
        GetComponent<FlightSelectBtnScript>().EquipOffBtn();

        ItemKeyValueScript firstItem = equipOperTab.transform.FindChild("Item/ItemBox01").GetComponent<ItemKeyValueScript>();

        equipItemName.GetComponent<UILabel>().text = firstItem.itemName;
        equipItemPrice.GetComponent<UILabel>().text = "";
        equipItemScript.GetComponent<UILabel>().text = firstItem.itemScript;
        equipOperTab.transform.FindChild("Item/HilightItem").localPosition = new Vector3(-326, 68, 6);

        equipWindows.transform.FindChild("Base/GoldIcon").gameObject.SetActive(false);

        ValueDeliverScript.SelectedItem = equipOperTab.transform.FindChild("Item/ItemBox01").gameObject;
        ValueDeliverScript.purchaseCharge = equipOperTab.transform.FindChild("Item/ItemBox01").GetComponent<ItemKeyValueScript>().itemCoinCost;
        ValueDeliverScript.SelectedItemSprite = equipOperTab.transform.FindChild("Item/ItemBox01/Item").GetComponent<UISprite>().spriteName;
        mountIconTemp = equipOperTab.transform.FindChild("Item/MountItem").gameObject;

        string itemNumName = "Item/ItemBox" + ValueDeliverScript.activeOper.ToString("00");
        mountIconTemp.transform.localPosition = equipOperTab.transform.FindChild(itemNumName).localPosition + new Vector3(-1, 3, -1);
    }

    public void GoToFriendWeekTab()
    {
        if (ValueDeliverScript.myFBid == "" || ValueDeliverScript.myFBid == null)
        {
            GetComponent<HangarPopupController>().AddPopWin(noFbLoginWindow, 0);

            return;
        }


        Debug.Log("ValueDeliverScript.rankDataFB.Length :: " + ValueDeliverScript.rankDataFB.Length);
        prepareReady.transform.FindChild("FriendPointBtn").gameObject.SetActive(true);
        friendWindow.transform.FindChild("AllMessageBtn").gameObject.SetActive(false);
        StartCoroutine(TransChange(friendWeekTab, 1));
        StartCoroutine(TransChange(wRankab, 0));
        StartCoroutine(TransChange(friendMailTab, 0));

        friendWindow.transform.FindChild("TapSprits/RankTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_00";
        friendWindow.transform.FindChild("TapSprits/WRankTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_01";
        friendWindow.transform.FindChild("TapSprits/MailTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_01";

        friendWindow.transform.FindChild("TapSprits/RankTab").GetComponent<UISprite>().MakePixelPerfect();
        friendWindow.transform.FindChild("TapSprits/WRankTab").GetComponent<UISprite>().MakePixelPerfect();
        friendWindow.transform.FindChild("TapSprits/MailTab").GetComponent<UISprite>().MakePixelPerfect();

        friendWeekTab.GetComponent<RankViewControl>().IsAbleT();
        friendMailTab.GetComponent<RankViewControl>().IsAbleF();

        friendWindow.transform.FindChild("Script01").GetComponent<UILabel>().text = "Touch Friends Tab to see More Info.";
        friendWindow.transform.FindChild("Script02").GetComponent<UILabel>().text = "Send Fuels to Get Buddy Points.";
    }

    public void GoToWorldRankTabNoBool()
    {
        GoToWorldRankTab();
    }
    public void GoToWorldRankTab(bool noFb =false)
    {
        prepareReady.transform.FindChild("FriendPointBtn").gameObject.SetActive(true);
        friendWindow.transform.FindChild("AllMessageBtn").gameObject.SetActive(false);

        if (noFb == false)
        {
            StartCoroutine(TransChange(friendWeekTab, 0));
            StartCoroutine(TransChange(wRankab, 1));
            StartCoroutine(TransChange(friendMailTab, 0));
        }
        else
        {
            friendWeekTab.GetComponent<UIPanel>().alpha = 0;
            wRankab.GetComponent<UIPanel>().alpha = 1;
            friendMailTab.GetComponent<UIPanel>().alpha = 0;
        }

        friendWindow.transform.FindChild("TapSprits/RankTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_01";
        friendWindow.transform.FindChild("TapSprits/WRankTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_00";
        friendWindow.transform.FindChild("TapSprits/MailTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_01";

        friendWindow.transform.FindChild("TapSprits/RankTab").GetComponent<UISprite>().MakePixelPerfect();
        friendWindow.transform.FindChild("TapSprits/WRankTab").GetComponent<UISprite>().MakePixelPerfect();
        friendWindow.transform.FindChild("TapSprits/MailTab").GetComponent<UISprite>().MakePixelPerfect();

        friendWeekTab.GetComponent<RankViewControl>().IsAbleF();
        friendMailTab.GetComponent<RankViewControl>().IsAbleF();

        friendWindow.transform.FindChild("Script01").GetComponent<UILabel>().text = "Touch Friends Tab to see More Info.";
        friendWindow.transform.FindChild("Script02").GetComponent<UILabel>().text = "When you get the Ranker, you will get rewards";
    }

    public void FriendInviteTabTextRefresh()
    {
        int remainHour = 23 - System.DateTime.Now.Hour;
        int remainMinute = 60 - System.DateTime.Now.Minute;

        string script = "Ability to Invite Up to " + (30 - ValueDeliverScript.FriendRequestCount) + " People";
        if (ValueDeliverScript.FriendRequestCount >= 30)
        {
            script = " The Max limit Excess";
        }

        friendWindow.transform.FindChild("Script01").GetComponent<UILabel>().text = "";
        friendWindow.transform.FindChild("Script02").GetComponent<UILabel>().text = "Send Fuels to Get Buddy Points.";
    }

    public void GoToFriendMailTab()
    {
        if (GameObject.Find("TapSprits").transform.FindChild("MailTab").GetComponent<UISprite>().spriteName == "Btn_TapRight_00") return;
        prepareReady.transform.FindChild("FriendPointBtn").gameObject.SetActive(true);
        StartCoroutine(IeGoToFriendMailTab());

        friendWindow.transform.FindChild("Script01").GetComponent<UILabel>().text = "Available Max 50 Msgs";
        friendWindow.transform.FindChild("Script02").GetComponent<UILabel>().text = "";
    }

    private IEnumerator IeGoToFriendMailTab()   //바로 위 GoToFriendMailTab 메소드의 실 작동부.
    {
        Debug.Log("::::: GoToFriendMailTab IE :::::");

        //기존 메세지탭들을 우선 삭제//
        int messageCount = friendMailTab.transform.childCount;
        GameObject[] MessageTab;

        MessageTab = new GameObject[messageCount];

        for (int i = 0; i < messageCount; i++)
        {
            MessageTab[i] = friendMailTab.transform.GetChild(i).gameObject;
        }

        for (int j = 0; j < messageCount; j++)
        {
            Destroy(MessageTab[j]);
        }
        //기존 메세지탭들을 우선 삭제//

        //메세지를 재생성하고 재 배치//
        MessageTabSetting();
        friendMailTab.GetComponent<UIGrid>().repositionNow = true;
        //메세지를 재생성하고 재 배치//



        yield return null;
        StartCoroutine(TransChange(friendWeekTab, 0));
        StartCoroutine(TransChange(wRankab, 0));
        StartCoroutine(TransChange(friendMailTab, 1));

        friendWindow.transform.FindChild("TapSprits/RankTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_01";
        friendWindow.transform.FindChild("TapSprits/WRankTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_01";
        friendWindow.transform.FindChild("TapSprits/MailTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_00";

        friendWindow.transform.FindChild("TapSprits/RankTab").GetComponent<UISprite>().MakePixelPerfect();
        friendWindow.transform.FindChild("TapSprits/WRankTab").GetComponent<UISprite>().MakePixelPerfect();
        friendWindow.transform.FindChild("TapSprits/MailTab").GetComponent<UISprite>().MakePixelPerfect();

        friendWeekTab.GetComponent<RankViewControl>().IsAbleF();
        friendMailTab.GetComponent<RankViewControl>().IsAbleT();

        int childCount = friendMailTab.transform.childCount;
        if (childCount > 0)
        {
            friendWindow.transform.FindChild("AllMessageBtn").gameObject.SetActive(true);
        }
    }

    public void GoToEventTab()
    {
        friendWindow.transform.FindChild("AllMessageBtn").gameObject.SetActive(false);

        friendWeekTab.GetComponent<UIPanel>().alpha = 0;
        friendWeekTab.SetActive(false);

        friendMailTab.GetComponent<UIPanel>().alpha = 0;
        friendMailTab.SetActive(false);

        friendWindow.transform.FindChild("TapSprits/RankTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_01";
        friendWindow.transform.FindChild("TapSprits/MailTab").GetComponent<UISprite>().spriteName = "Btn_TapRight_01";

        friendWindow.transform.FindChild("TapSprits/RankTab").GetComponent<UISprite>().MakePixelPerfect();
        friendWindow.transform.FindChild("TapSprits/MailTab").GetComponent<UISprite>().MakePixelPerfect();

        friendWeekTab.GetComponent<RankViewControl>().IsAbleF();
        friendMailTab.GetComponent<RankViewControl>().IsAbleF();

        FriendInviteTabTextRefresh();
        friendWindow.transform.FindChild("Script01").GetComponent<UILabel>().text = "Events List";
        friendWindow.transform.FindChild("Script02").GetComponent<UILabel>().text = "Send Fuels to Get Buddy Points.";
    }

    public void EquipWindowClose()
    {
        halfBLKPanel.SetActive(false);
        equipBombTab.SetActive(false);
        equipReinforceTab.SetActive(false);
        equipAssistanceTab.SetActive(false);
        equipOperTab.SetActive(false);
    }

    //비행기스킨 윈도우.

    private IEnumerator GoToSkinSelectWindow000()  //0번 비행기 스킨 셀렉트 창을 여는 함수
    {
        int childCount = skinSelectWindow00.transform.FindChild("Skin").childCount;

        for (int skinNum = 1; skinNum < childCount; skinNum++)
        {
            skinSelectWindow00.transform.FindChild("Skin/Skin" + skinNum.ToString("00")).GetComponent<PositionSkinSendScript>().UpdateSkinInfo();
        }

        flights.animation.Play("FlightsPanelAnim02");
        skinSelectWindow00.animation.Play("SkinSelectWindowAnim01");
        yield return new WaitForSeconds(0.5f);
        skinSelectWindow00.transform.FindChild("BackBtn").gameObject.SetActive(true);
        skinSelectWindow00.GetComponent<SkinHilightScript>().Activate();            // 이부분을 이용하면 스킨레벨과 게이지가 얼마나 차 있는지 정의할수 있음.
        //prepareReady.transform.FindChild("OperMessage/SpecialMessage").gameObject.SetActive(false);
        //prepareReady.transform.FindChild("OperMessage/UpgradePointMessage").gameObject.SetActive(false);
        //prepareReady.transform.FindChild("OperMessage/OperMessageLabel").gameObject.SetActive(true);

        if (ValueDeliverScript.skinNumber > 0)
        {
            prepareReady.transform.FindChild("OperMessage/SpecialAttackOn").gameObject.SetActive(false);
        }

        int isFlightLock = 1;
        if (ValueDeliverScript.skinNumber != 0)
        {
            switch (ValueDeliverScript.skinNumber)
            {
                case 1: isFlightLock = ValueDeliverScript.FlightLock000Skin001; break;
                case 2: isFlightLock = ValueDeliverScript.FlightLock000Skin002; break;
                case 3: isFlightLock = ValueDeliverScript.FlightLock000Skin003; break;
                case 4: isFlightLock = ValueDeliverScript.FlightLock000Skin004; break;
                case 5: isFlightLock = ValueDeliverScript.FlightLock000Skin005; break;
            }
        }

        if (isFlightLock == 1)
        {
            skinSelectWindow00.transform.FindChild("Lock").gameObject.SetActive(false);
        }
        else
        {
            skinSelectWindow00.transform.FindChild("Lock").gameObject.SetActive(true);
        }

        noTouchPanel.SetActive(false);
    }

    private IEnumerator GoToSkinSelectWindow001()  //1번 비행기 스킨 셀렉트 창을 여는 함수
    {
        int childCount = skinSelectWindow00.transform.FindChild("Skin").childCount;

        for (int skinNum = 1; skinNum < childCount; skinNum++)
        {
            skinSelectWindow01.transform.FindChild("Skin/Skin" + skinNum.ToString("00")).GetComponent<PositionSkinSendScript>().UpdateSkinInfo();
        }

        flights.animation.Play("FlightsPanelAnim02");
        skinSelectWindow01.animation.Play("SkinSelectWindowAnim01");
        yield return new WaitForSeconds(0.5f);
        skinSelectWindow01.transform.FindChild("BackBtn").gameObject.SetActive(true);
        skinSelectWindow01.GetComponent<SkinHilightScript>().Activate();
        //prepareReady.transform.FindChild("OperMessage/SpecialMessage").gameObject.SetActive(false);
        //prepareReady.transform.FindChild("OperMessage/UpgradePointMessage").gameObject.SetActive(false);
        //prepareReady.transform.FindChild("OperMessage/OperMessageLabel").gameObject.SetActive(true);

        if (ValueDeliverScript.skinNumber > 0)
        {
            prepareReady.transform.FindChild("OperMessage/SpecialAttackOn").gameObject.SetActive(false);
        }

        int isFlightLock = 1;
        if (ValueDeliverScript.skinNumber != 0)
        {
            switch (ValueDeliverScript.skinNumber)
            {
                case 1: isFlightLock = ValueDeliverScript.FlightLock001Skin001; break;
                case 2: isFlightLock = ValueDeliverScript.FlightLock001Skin002; break;
                case 3: isFlightLock = ValueDeliverScript.FlightLock001Skin003; break;
                case 4: isFlightLock = ValueDeliverScript.FlightLock001Skin004; break;
                case 5: isFlightLock = ValueDeliverScript.FlightLock001Skin005; break;
            }
        }
        if (isFlightLock == 1)
        {
            skinSelectWindow01.transform.FindChild("Lock").gameObject.SetActive(false);
        }
        else
        {
            skinSelectWindow01.transform.FindChild("Lock").gameObject.SetActive(true);
        }

        noTouchPanel.SetActive(false);
    }

    private IEnumerator GoToSkinSelectWindow002()  //2번 비행기 스킨 셀렉트 창을 여는 함수
    {
        int childCount = skinSelectWindow00.transform.FindChild("Skin").childCount;

        for (int skinNum = 1; skinNum < childCount; skinNum++)
        {
            skinSelectWindow02.transform.FindChild("Skin/Skin" + skinNum.ToString("00")).GetComponent<PositionSkinSendScript>().UpdateSkinInfo();
        }

        flights.animation.Play("FlightsPanelAnim02");
        skinSelectWindow02.animation.Play("SkinSelectWindowAnim01");
        yield return new WaitForSeconds(0.5f);
        skinSelectWindow02.transform.FindChild("BackBtn").gameObject.SetActive(true);
        skinSelectWindow02.GetComponent<SkinHilightScript>().Activate();
        //prepareReady.transform.FindChild("OperMessage/SpecialMessage").gameObject.SetActive(false);
        //prepareReady.transform.FindChild("OperMessage/UpgradePointMessage").gameObject.SetActive(false);
        //prepareReady.transform.FindChild("OperMessage/OperMessageLabel").gameObject.SetActive(true);

        if (ValueDeliverScript.skinNumber > 0)
        {
            prepareReady.transform.FindChild("OperMessage/SpecialAttackOn").gameObject.SetActive(false);
        }

        int isFlightLock = 1;
        if (ValueDeliverScript.skinNumber != 0)
            switch (ValueDeliverScript.skinNumber)
            {
                case 1: isFlightLock = ValueDeliverScript.FlightLock002Skin001; break;
                case 2: isFlightLock = ValueDeliverScript.FlightLock002Skin002; break;
                case 3: isFlightLock = ValueDeliverScript.FlightLock002Skin003; break;
                case 4: isFlightLock = ValueDeliverScript.FlightLock002Skin004; break;
                case 5: isFlightLock = ValueDeliverScript.FlightLock002Skin005; break;
            }

        if (isFlightLock == 1)
        {
            skinSelectWindow02.transform.FindChild("Lock").gameObject.SetActive(false);
        }
        else
        {
            skinSelectWindow02.transform.FindChild("Lock").gameObject.SetActive(true);
        }

        noTouchPanel.SetActive(false);
    }

    public void BackToFlight000()
    {
        skinSelectWindow00.transform.FindChild("BackBtn").gameObject.SetActive(false);
        skinSelectWindow00.animation.Play("SkinSelectWindowAnim02");
        flights.animation.Play("FlightsPanelAnim01");
        //prepareReady.transform.FindChild("OperMessage/OperMessageLabel").GetComponent<UILabel>().text = "";
        flightUpointSetScript.RedrawStatePoint();

        if (flightUpointSetScript.remainPoint <= 0)
        {
            if (ValueDeliverScript.isSpecialAttackComplete == 1)
            {
                prepareReady.transform.FindChild("OperMessage/SpecialAttackOn").gameObject.SetActive(true);
                prepareReady.transform.FindChild("OperMessage/SpecialMessage").gameObject.SetActive(false);
            }
            else
            {
                prepareReady.transform.FindChild("OperMessage/SpecialAttackOn").gameObject.SetActive(false);
                prepareReady.transform.FindChild("OperMessage/SpecialMessage").gameObject.SetActive(true);
            }
        }
    }

    public void BackToFlight001()
    {
        skinSelectWindow01.transform.FindChild("BackBtn").gameObject.SetActive(false);
        skinSelectWindow01.animation.Play("SkinSelectWindowAnim02");
        flights.animation.Play("FlightsPanelAnim01");
        //prepareReady.transform.FindChild("OperMessage/OperMessageLabel").GetComponent<UILabel>().text = "";
        flightUpointSetScript.RedrawStatePoint();

        if (flightUpointSetScript.remainPoint <= 0)
        {
            if (ValueDeliverScript.isSpecialAttackComplete == 1)
            {
                prepareReady.transform.FindChild("OperMessage/SpecialAttackOn").gameObject.SetActive(true);
                prepareReady.transform.FindChild("OperMessage/SpecialMessage").gameObject.SetActive(false);
            }
            else
            {
                prepareReady.transform.FindChild("OperMessage/SpecialAttackOn").gameObject.SetActive(false);
                prepareReady.transform.FindChild("OperMessage/SpecialMessage").gameObject.SetActive(true);
            }
        }
    }

    public void BackToFlight002()
    {
        skinSelectWindow02.transform.FindChild("BackBtn").gameObject.SetActive(false);
        skinSelectWindow02.animation.Play("SkinSelectWindowAnim02");
        flights.animation.Play("FlightsPanelAnim01");
        //prepareReady.transform.FindChild("OperMessage/OperMessageLabel").GetComponent<UILabel>().text = "";
        flightUpointSetScript.RedrawStatePoint();

        if (flightUpointSetScript.remainPoint <= 0)
        {
            if (ValueDeliverScript.isSpecialAttackComplete == 1)
            {
                prepareReady.transform.FindChild("OperMessage/SpecialAttackOn").gameObject.SetActive(true);
                prepareReady.transform.FindChild("OperMessage/SpecialMessage").gameObject.SetActive(false);
            }
            else
            {
                prepareReady.transform.FindChild("OperMessage/SpecialAttackOn").gameObject.SetActive(false);
                prepareReady.transform.FindChild("OperMessage/SpecialMessage").gameObject.SetActive(true);
            }
        }
    }

    private IEnumerator BackToFlightFromStore()
    {
        if (equipToStoreOn)
        {
            equipWindows.animation.Play("StoreWindowAnim01");
            equipToStoreOn = false;

            storeWindow.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
            storeWindow.animation.Play("StoreWindowAnim03");

            yield return new WaitForSeconds(0.5f);
            equipWindows.transform.FindChild("Base/BackBtn").gameObject.SetActive(true);
        }
        else if (skin00ToStoreOn)
        {
            skinSelectWindow00.animation.Play("SkinSelectWindowAnim01");
            skin00ToStoreOn = false;

            storeWindow.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
            storeWindow.animation.Play("StoreWindowAnim03");

            yield return new WaitForSeconds(0.5f);
            skinSelectWindow00.transform.FindChild("BackBtn").gameObject.SetActive(true);
        }
        else if (skin01ToStoreOn)
        {
            skinSelectWindow01.animation.Play("SkinSelectWindowAnim01");
            skin01ToStoreOn = false;

            storeWindow.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
            storeWindow.animation.Play("StoreWindowAnim03");

            yield return new WaitForSeconds(0.5f);
            skinSelectWindow01.transform.FindChild("BackBtn").gameObject.SetActive(true);
        }
        else if (skin02ToStoreOn)
        {
            skinSelectWindow02.animation.Play("SkinSelectWindowAnim01");
            skin02ToStoreOn = false;

            storeWindow.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
            storeWindow.animation.Play("StoreWindowAnim03");

            yield return new WaitForSeconds(0.5f);
            skinSelectWindow02.transform.FindChild("BackBtn").gameObject.SetActive(true);
        }
        else if (resultToStoreOn)
        {
            storeWindow.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
            storeWindow.animation.Play("StoreWindowAnim03");
            resultToStoreOn = false;
            yield return new WaitForSeconds(0.5f);
            ResultPanel.transform.FindChild("ResultPanelLeft").animation.Play("ResultPanelLeftAnim01");
            yield return new WaitForSeconds(0.5f);
            ResultPanel.transform.FindChild("ResultPanelLeft").animation.Play("ResultPanelLeftAnim02");
            ResultPanel.transform.FindChild("ResultPanelRight").animation.Play("ResultPanelRightAnim01");
            yield return new WaitForSeconds(0.5f);
            noTouchPanel.SetActive(false);
        }
        else
        {
            flights.animation.Play("FlightsPanelAnim01");
            storeWindow.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
            storeWindow.animation.Play("StoreWindowAnim02");
            flightUpointSetScript.RedrawStatePoint();
        }
    }

    private IEnumerator BackToFlight()
    {
        equipWindows.transform.FindChild("Base/BackBtn").gameObject.SetActive(false);
        equipWindows.animation.Play("StoreWindowAnim02");
        flights.animation.Play("FlightsPanelAnim01");

        attackReady.animation.Play("AttackReadyAnim02");
        yield return new WaitForSeconds(0.7f);

        prepareReady.transform.FindChild("RankFriendTF").gameObject.SetActive(true);

        prepareReady.transform.FindChild("RankFriendTF").gameObject.SetActive(true);
        Debug.Log("PrepareReadyAnim01");

        //메세지 유무 여부에 따라 깜박이 보이게 할지 안보이게 할지 결정//
        if (ValueDeliverScript.messageData.Length != 0) GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(true);
        else GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(false);

        prepareReady.animation.Play("PrepareReadyAnim01");

        yield return new WaitForSeconds(0.2f);

        string skinName = "Flight" + ValueDeliverScript.flightNumber.ToString("D3") + "Skin" + ValueDeliverScript.skinNumber.ToString("D3");
        if (ValueDeliverScript.isResultToHanger)
        {
            if (resultSkinNumber != 0 && resultSkinName <= 0)
            {
                //스킨 내구도가 0이하로 떨어지면 이 부분을 실행!
                //스킨 내구도 복구 유도 창을 띄운다.

                GetComponent<HangarPopupController>().AddPopWin(duraBuyAlarmWindow, 0);

                //duraBuyAlarmWindow.SetActive(true);
                //halfBLKPanel.SetActive(true);
                //halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, duraBuyAlarmWindow.transform.localPosition.z + 5);
            }

            ValueDeliverScript.isResultToHanger = false;
        }
    }

    private IEnumerator BacktoFlight2()
    {
        StartCoroutine(AttackReadyReverse());
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(PrepareReadyReverse());
    }

    public void SkinWindowClose()
    {
        SkinlockOffCount(); //소유 스킨 갯수 표시.
        if (ValueDeliverScript.skinNumber != 0)
        {
            string selectSkinName = "FlightDura" + ValueDeliverScript.flightNumber.ToString("D3") + "Skin" + ValueDeliverScript.skinNumber.ToString("D3");

            //내구도가 0일때 기본 스킨으로 돌리는 방법.
            int selectSkinDuraValue = 0;

            switch (ValueDeliverScript.flightNumber)
            {
                case 0: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: selectSkinDuraValue = ValueDeliverScript.FlightDura000Skin001; break;
                        case 2: selectSkinDuraValue = ValueDeliverScript.FlightDura000Skin002; break;
                        case 3: selectSkinDuraValue = ValueDeliverScript.FlightDura000Skin003; break;
                        case 4: selectSkinDuraValue = ValueDeliverScript.FlightDura000Skin004; break;
                        case 5: selectSkinDuraValue = ValueDeliverScript.FlightDura000Skin005; break;
                    } break;
                case 1: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: selectSkinDuraValue = ValueDeliverScript.FlightDura001Skin001; break;
                        case 2: selectSkinDuraValue = ValueDeliverScript.FlightDura001Skin002; break;
                        case 3: selectSkinDuraValue = ValueDeliverScript.FlightDura001Skin003; break;
                        case 4: selectSkinDuraValue = ValueDeliverScript.FlightDura001Skin004; break;
                        case 5: selectSkinDuraValue = ValueDeliverScript.FlightDura001Skin005; break;
                    } break;
                case 2: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: selectSkinDuraValue = ValueDeliverScript.FlightDura002Skin001; break;
                        case 2: selectSkinDuraValue = ValueDeliverScript.FlightDura002Skin002; break;
                        case 3: selectSkinDuraValue = ValueDeliverScript.FlightDura002Skin003; break;
                        case 4: selectSkinDuraValue = ValueDeliverScript.FlightDura002Skin004; break;
                        case 5: selectSkinDuraValue = ValueDeliverScript.FlightDura002Skin005; break;
                    } break;
            }

            if (selectSkinDuraValue <= 0)
            {
                ValueDeliverScript.skinNumber = 0;
                switch (ValueDeliverScript.flightNumber)
                {
                    case 00:
                        Flight000Skin(ValueDeliverScript.skinNumber, ValueDeliverScript.skinLevel);
                        skinSelectWindow00.transform.FindChild("Skin/Skin00").GetComponent<PositionSkinSendScript>().InsertNameLevel();
                        skinSelectWindow00.transform.FindChild("HilightItem").transform.localPosition = new Vector3(78, 68, -2);
                        skinSelectWindow00.transform.FindChild("Dura").gameObject.SetActive(false);
                        break;

                    case 01:
                        Flight001Skin(ValueDeliverScript.skinNumber, ValueDeliverScript.skinLevel);
                        skinSelectWindow01.transform.FindChild("Skin/Skin00").GetComponent<PositionSkinSendScript>().InsertNameLevel();
                        skinSelectWindow01.transform.FindChild("HilightItem").transform.localPosition = new Vector3(78, 68, -2);
                        skinSelectWindow01.transform.FindChild("Dura").gameObject.SetActive(false);
                        break;

                    case 02:
                        Flight002Skin(ValueDeliverScript.skinNumber, ValueDeliverScript.skinLevel);
                        skinSelectWindow02.transform.FindChild("Skin/Skin00").GetComponent<PositionSkinSendScript>().InsertNameLevel();
                        skinSelectWindow02.transform.FindChild("HilightItem").transform.localPosition = new Vector3(78, 68, -2);
                        skinSelectWindow02.transform.FindChild("Dura").gameObject.SetActive(false);
                        break;
                }
            }//내구도가 0일때 기본 스킨으로 돌리는 방법.

            //스킨 락이 해제되지 않았을때 기본 스킨으로 돌리는 방법.
            int selectskinLockOff = 0;

            switch (ValueDeliverScript.flightNumber)
            {
                case 0: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: selectskinLockOff = ValueDeliverScript.FlightLock000Skin001; break;
                        case 2: selectskinLockOff = ValueDeliverScript.FlightLock000Skin002; break;
                        case 3: selectskinLockOff = ValueDeliverScript.FlightLock000Skin003; break;
                        case 4: selectskinLockOff = ValueDeliverScript.FlightLock000Skin004; break;
                        case 5: selectskinLockOff = ValueDeliverScript.FlightLock000Skin005; break;
                    } break;
                case 1: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: selectskinLockOff = ValueDeliverScript.FlightLock001Skin001; break;
                        case 2: selectskinLockOff = ValueDeliverScript.FlightLock001Skin002; break;
                        case 3: selectskinLockOff = ValueDeliverScript.FlightLock001Skin003; break;
                        case 4: selectskinLockOff = ValueDeliverScript.FlightLock001Skin004; break;
                        case 5: selectskinLockOff = ValueDeliverScript.FlightLock001Skin005; break;
                    } break;
                case 2: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: selectskinLockOff = ValueDeliverScript.FlightLock002Skin001; break;
                        case 2: selectskinLockOff = ValueDeliverScript.FlightLock002Skin002; break;
                        case 3: selectskinLockOff = ValueDeliverScript.FlightLock002Skin003; break;
                        case 4: selectskinLockOff = ValueDeliverScript.FlightLock002Skin004; break;
                        case 5: selectskinLockOff = ValueDeliverScript.FlightLock002Skin005; break;
                    } break;
            }

            if (selectskinLockOff == 0)
            {
                ValueDeliverScript.skinNumber = 0;
                switch (ValueDeliverScript.flightNumber)
                {
                    case 00:
                        Flight000Skin(ValueDeliverScript.skinNumber, ValueDeliverScript.skinLevel);
                        skinSelectWindow00.transform.FindChild("Skin/Skin00").GetComponent<PositionSkinSendScript>().InsertNameLevel();
                        skinSelectWindow00.transform.FindChild("HilightItem").transform.localPosition = new Vector3(78, 68, 2);
                        skinSelectWindow00.transform.FindChild("Lock").gameObject.SetActive(false);
                        break;

                    case 01:
                        Flight001Skin(ValueDeliverScript.skinNumber, ValueDeliverScript.skinLevel);
                        skinSelectWindow01.transform.FindChild("Skin/Skin00").GetComponent<PositionSkinSendScript>().InsertNameLevel();
                        skinSelectWindow01.transform.FindChild("HilightItem").transform.localPosition = new Vector3(78, 68, 2);
                        skinSelectWindow01.transform.FindChild("Lock").gameObject.SetActive(false);
                        break;

                    case 02:
                        Flight002Skin(ValueDeliverScript.skinNumber, ValueDeliverScript.skinLevel);
                        skinSelectWindow02.transform.FindChild("Skin/Skin00").GetComponent<PositionSkinSendScript>().InsertNameLevel();
                        skinSelectWindow02.transform.FindChild("HilightItem").transform.localPosition = new Vector3(78, 68, 2);
                        skinSelectWindow02.transform.FindChild("Lock").gameObject.SetActive(false);
                        break;
                }
            }//스킨 락이 해제되지 않았을때 기본 스킨으로 돌리는 방법.
        }
        halfBLKPanel.SetActive(false);
    }

    void MCoinShortageWindowMethod()
    {
        StartCoroutine(CoinCharSound());
    }

    private IEnumerator CoinCharSound()
    {
        int activeOper = ValueDeliverScript.activeOper;
        yield return new WaitForSeconds(0.5f);
        CharacterMsgSndConScript characterMsgSndCon;
        characterMsgSndCon = GameObject.Find("CharacterMsgSndCon").GetComponent<CharacterMsgSndConScript>();
        characterMsgSndCon.CoinShort(activeOper);
    }

    public void CoinShortageWindowClose()
    {
        GetComponent<HangarPopupController>().CloseWindow();
    }

    //메달 부족.구매 유도창 관련 열고 닫기.
    public void GoToMedalShortageWindow()
    {
        GetComponent<HangarPopupController>().AddPopWin(medalShortageWindow, -1, MedalCharSoundV);
        //halfBLKPanel.SetActive(true);
        //medalShortageWindow.SetActive(true);
        //halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, medalShortageWindow.transform.localPosition.z + 5);
    }

    void MedalCharSoundV()
    {
        StartCoroutine(MedalCharSound());
    }

    private IEnumerator MedalCharSound()
    {
        int activeOper = ValueDeliverScript.activeOper;
        yield return new WaitForSeconds(0.5f);
        CharacterMsgSndConScript characterMsgSndCon;
        characterMsgSndCon = GameObject.Find("CharacterMsgSndCon").GetComponent<CharacterMsgSndConScript>();
        characterMsgSndCon.MedalShort(activeOper);
    }

    public void MedalShortageWindowClose()
    {
        GetComponent<HangarPopupController>().CloseWindow();
        //halfBLKPanel.SetActive(false);
        //medalShortageWindow.SetActive(false);
        //halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, -166);
    }

    void MedalShortageWindowYes()
    {
        GetComponent<HangarPopupController>().CloseWindow(MedalShortageWindowYes01);
    }

    public void MedalShortageWindowYes01()
    {
        //medalShortageWindow.SetActive(false);
        //halfBLKPanel.SetActive(false);

        StartCoroutine(TransChange(storeWindow.transform.FindChild("TabCoin").gameObject, 1));
        StartCoroutine(TransChange(storeWindow.transform.FindChild("TabGas").gameObject, 0));
        StartCoroutine(TransChange(storeWindow.transform.FindChild("TabMedal").gameObject, 0));

        storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_n";
        storeWindow.transform.FindChild("Base/TabGasIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";
        storeWindow.transform.FindChild("Base/TabMedalIcon").GetComponent<UISprite>().spriteName = "bt_blue_t_top_o";

        storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().MakePixelPerfect();
        storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().MakePixelPerfect();
        storeWindow.transform.FindChild("Base/TabCoinIcon").GetComponent<UISprite>().MakePixelPerfect();

        storeWindow.transform.FindChild("TabCoin").GetComponent<UIPanel>().alpha = 1;
        storeWindow.transform.FindChild("TabCoin").gameObject.SetActive(true);

        storeWindow.transform.FindChild("TabGas").GetComponent<UIPanel>().alpha = 0;
        storeWindow.transform.FindChild("TabGas").gameObject.SetActive(false);

        storeWindow.transform.FindChild("TabMedal").GetComponent<UIPanel>().alpha = 0;
        storeWindow.transform.FindChild("TabMedal").gameObject.SetActive(false);

        storeWindow.transform.parent = winMove.transform;
        StartCoroutine(WindowsMove());
    }

    public void GoToPurchaseConfirmWindow()
    {
        ItemKeyValueScript itemScript = ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>();
        int itemAmount = int.Parse(ValueDeliverScript.SelectedItem.transform.FindChild("Label").GetComponent<UILabel>().text);

        //캐릭터(오퍼레이터)를 구매시 한번이상 구매하지 못하도록 해준다. 하나이상 있으면 아무것도 하지 않고 그냥 리턴한다.
        if (itemScript.itemKey.Contains("Oper") && itemAmount > 0)
            return;

        string infoMessage; //구매시 나오는 멘트를 담는 스트링 변수.바로 아랫줄부터 이와 관련된 코딩이 됨.
        if (itemScript.itemKey.Contains("Oper"))
        {
            infoMessage = "You purchased items.";
            equipWindows.transform.FindChild("Base/ItemBuyBtn").gameObject.SetActive(false);
            equipWindows.transform.FindChild("Base/LabelGet").gameObject.SetActive(false);
            equipWindows.transform.FindChild("Base/GoldIcon").gameObject.SetActive(false);
            equipWindows.transform.FindChild("Base/ItemPrice").GetComponent<UILabel>().text = "";
            equipWindows.transform.FindChild("Base/CoinAbleLabel").GetComponent<UILabel>().text = "";
        }
        else
        {
            infoMessage = "You purchased items.";
        }

        int medalRest = ValueDeliverScript.medalRest;
        int coinRest = ValueDeliverScript.coinRest;

        if (itemScript.itemKey.Contains("Oper") && itemScript.isMedalPurchase == true)
        {
            if (medalRest >= ValueDeliverScript.purchaseCharge)
            {
                purchaseConfirmWindow.SetActive(true);
                purchaseConfirmWindow.transform.FindChild("purchaseItem").gameObject.GetComponent<UISprite>().spriteName = ValueDeliverScript.SelectedItemSprite;
                purchaseConfirmWindow.transform.FindChild("purchaseItem").gameObject.GetComponent<UISprite>().MakePixelPerfect();
                purchaseConfirmWindow.transform.FindChild("Script01").GetComponent<UILabel>().text = infoMessage; //가스 이미지를 아이템에 맞게 보여준다.

                GameObject.Find("GameManager").GetComponent<GasTimeScript>().MedalRecount(); //화면에 표시되는 메달양을 다시 계산하여 재표시하여줌.
                GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.

                purchaseConfirmWindow.GetComponent<purchaseScript>().Activate();    //정해진 시간이 지나면 자동으로 창이 꺼지는 코드가 작동하는 함수 호출.

                PurchaseConfirmWindowCloseYes(); //구매처리가 이루어지는 부분.
            }
            else
            {
                GoToMedalShortageWindow();
                purchaseConfirmWindow.SetActive(false);
            }
        }
        else if (ValueDeliverScript.SelectedItem != null && coinRest >= ValueDeliverScript.purchaseCharge)
        {
            Debug.Log("물건사러 들어오냐?");
            purchaseConfirmWindow.SetActive(true);
            purchaseConfirmWindow.transform.FindChild("purchaseItem").gameObject.GetComponent<UISprite>().spriteName = ValueDeliverScript.SelectedItemSprite;
            purchaseConfirmWindow.transform.FindChild("purchaseItem").gameObject.GetComponent<UISprite>().MakePixelPerfect();
            purchaseConfirmWindow.transform.FindChild("Script01").GetComponent<UILabel>().text = infoMessage; //가스 이미지를 아이템에 맞게 보여준다.

            GameObject.Find("GameManager").GetComponent<GasTimeScript>().MedalRecount(); //화면에 표시되는 메달양을 다시 계산하여 재표시하여줌.
            GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.

            purchaseConfirmWindow.GetComponent<purchaseScript>().Activate();    //정해진 시간이 지나면 자동으로 창이 꺼지는 코드가 작동하는 함수 호출.

            PurchaseConfirmWindowCloseYes(); //구매처리가 이루어지는 부분.
        }
        //돈이 모자라면 구매창을 띄운다//
        else if (ValueDeliverScript.SelectedItem != null && coinRest < ValueDeliverScript.purchaseCharge)
        {
            GoToCoinShortageWindow();
            purchaseConfirmWindow.SetActive(false);
        }
    }

    public void PurchaseConfirmWindowClose()
    {
        purchaseConfirmWindow.SetActive(false);
    }

    public void PurchaseConfirmWindowCloseYes() //구매확인창. 처리 내용들.
    {
        int medalRest = ValueDeliverScript.medalRest;
        int coinRest = ValueDeliverScript.coinRest;

        Vector3 hilightItemPosition = new Vector3(0, 0, 0);

        if (ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().isMedalPurchase == true)
        {
            ValueDeliverScript.medalRest = medalRest - ValueDeliverScript.purchaseCharge;
        }
        else
        {
            ValueDeliverScript.coinRest = coinRest - ValueDeliverScript.purchaseCharge;
        }

        GameObject.Find("GameManager").GetComponent<GasTimeScript>().MedalRecount(); //화면에 표시되는 메달양을 다시 계산하여 재표시하여줌.
        GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.

        string htKey = (ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemKey).ToString();

        Debug.Log("HTKey ::: " + htKey + " :::");
        int itemVal = 0;
        switch (htKey)
        {
            case "Bomb01": itemVal = ValueDeliverScript.EquipBomb01 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Bomb02": itemVal = ValueDeliverScript.EquipBomb02 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Bomb03": itemVal = ValueDeliverScript.EquipBomb03 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Bomb04": itemVal = ValueDeliverScript.EquipBomb04 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Bomb05": itemVal = ValueDeliverScript.EquipBomb05 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Bomb06": itemVal = ValueDeliverScript.EquipBomb06 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Bomb07": itemVal = ValueDeliverScript.EquipBomb07 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Bomb08": itemVal = ValueDeliverScript.EquipBomb08 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Bomb09": itemVal = ValueDeliverScript.EquipBomb09 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Bomb10": itemVal = ValueDeliverScript.EquipBomb10 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Bomb11": itemVal = ValueDeliverScript.EquipBomb11 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Bomb12": itemVal = ValueDeliverScript.EquipBomb12 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;

            case "Reinforce01": itemVal = ValueDeliverScript.EquipReinforce01 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Reinforce02": itemVal = ValueDeliverScript.EquipReinforce02 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Reinforce03": itemVal = ValueDeliverScript.EquipReinforce03 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Reinforce04": itemVal = ValueDeliverScript.EquipReinforce04 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Reinforce05": itemVal = ValueDeliverScript.EquipReinforce05 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Reinforce06": itemVal = ValueDeliverScript.EquipReinforce06 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Reinforce07": itemVal = ValueDeliverScript.EquipReinforce07 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Reinforce08": itemVal = ValueDeliverScript.EquipReinforce08 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Reinforce09": itemVal = ValueDeliverScript.EquipReinforce09 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Reinforce10": itemVal = ValueDeliverScript.EquipReinforce10 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Reinforce11": itemVal = ValueDeliverScript.EquipReinforce11 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Reinforce12": itemVal = ValueDeliverScript.EquipReinforce12 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;

            case "Assist01": itemVal = ValueDeliverScript.EquipAssist01 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Assist02": itemVal = ValueDeliverScript.EquipAssist02 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Assist03": itemVal = ValueDeliverScript.EquipAssist03 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Assist04": itemVal = ValueDeliverScript.EquipAssist04 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Assist05": itemVal = ValueDeliverScript.EquipAssist05 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Assist06": itemVal = ValueDeliverScript.EquipAssist06 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Assist07": itemVal = ValueDeliverScript.EquipAssist07 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Assist08": itemVal = ValueDeliverScript.EquipAssist08 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Assist09": itemVal = ValueDeliverScript.EquipAssist09 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Assist10": itemVal = ValueDeliverScript.EquipAssist10 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Assist11": itemVal = ValueDeliverScript.EquipAssist11 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Assist12": itemVal = ValueDeliverScript.EquipAssist12 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;

            case "Oper01": itemVal = ValueDeliverScript.EquipOper01 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Oper02": itemVal = ValueDeliverScript.EquipOper02 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Oper03": itemVal = ValueDeliverScript.EquipOper03 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Oper04": itemVal = ValueDeliverScript.EquipOper04 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Oper05": itemVal = ValueDeliverScript.EquipOper05 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Oper06": itemVal = ValueDeliverScript.EquipOper06 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Oper07": itemVal = ValueDeliverScript.EquipOper07 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Oper08": itemVal = ValueDeliverScript.EquipOper08 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Oper09": itemVal = ValueDeliverScript.EquipOper09 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Oper10": itemVal = ValueDeliverScript.EquipOper10 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Oper11": itemVal = ValueDeliverScript.EquipOper11 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
            case "Oper12": itemVal = ValueDeliverScript.EquipOper12 += ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue; break;
        }
        Debug.Log("Selected the Item Name :: " + ValueDeliverScript.SelectedItem.name);
        Debug.Log("Selected the Item Value :: " + ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemValue);
        Debug.Log("Item Value ::: " + itemVal);

        ValueDeliverScript.SelectedItem.transform.FindChild("Label").gameObject.GetComponent<UILabel>().text = itemVal.ToString();

        //활성화된 아이템(캐릭터)를 기록한다.
        if (ValueDeliverScript.SelectedItem.transform.FindChild("Label").GetComponent<UILabel>().text != "0")
        {
            if (equipBombTab.activeSelf == true)
            {
                ValueDeliverScript.activeBomb = ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemNumber;
                hilightItemPosition = equipBombTab.transform.FindChild("Item/HilightItem").transform.localPosition;
            }
            else if (equipReinforceTab.activeSelf == true)
            {
                ValueDeliverScript.activeReinforce = ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemNumber;
                hilightItemPosition = equipReinforceTab.transform.FindChild("Item/HilightItem").transform.localPosition;
            }
            else if (equipAssistanceTab.activeSelf == true)
            {
                ValueDeliverScript.activeAssist = ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemNumber;
                hilightItemPosition = equipAssistanceTab.transform.FindChild("Item/HilightItem").transform.localPosition;
            }
            else if (equipOperTab.activeSelf == true)
            {
                ValueDeliverScript.activeOper = ValueDeliverScript.SelectedItem.GetComponent<ItemKeyValueScript>().itemNumber;
                hilightItemPosition = equipOperTab.transform.FindChild("Item/HilightItem").transform.localPosition;
                //지금 구매한 캐릭터로 이미지를 변경한다.
                equipWindows.transform.FindChild("Base/GoldIcon").gameObject.SetActive(false);
                equipWindows.transform.FindChild("Base/ItemPrice").GetComponent<UILabel>().text = "";

                CharacterMsgSndConScript characterMsgSndCon;
                characterMsgSndCon = GameObject.Find("CharacterMsgSndCon").GetComponent<CharacterMsgSndConScript>();
                characterMsgSndCon.BuyCharacter(ValueDeliverScript.activeOper);
                ChangeImage();
            }
        }

        mountIconTemp.SetActive(true);
        mountIconTemp.transform.localPosition = hilightItemPosition; //마운드 아이콘 표시해줌.

        //여기까지가 구매 확인창을 띄워서 확인을 잠깐 보여주고 물밑작업으로 어떤 아이템이 구매가 되고 돈이 차감되는지를 구현.
        EquipStartSetting();  //1173번줄에 있는 이큅스타트세팅 함수를 호출.
    
        ValueDeliverScript.SaveGameData();
    }

    private void ChangeImage()
    {
        int CharNum = ValueDeliverScript.activeOper;
        GameObject CharacterLeftImage = GameObject.Find("CharImg");
        GameObject CharacterLabel = GameObject.Find("CharName");
        switch (CharNum)
        {
            case 1:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator1_01";
                CharacterLabel.GetComponent<UISprite>().spriteName = "text_operator_name1";
                break;

            case 2:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator2_01";
                CharacterLabel.GetComponent<UISprite>().spriteName = "text_operator_name4";
                break;

            case 3:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator3_01";
                CharacterLabel.GetComponent<UISprite>().spriteName = "text_operator_name2";
                break;

            case 4:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator4_01";
                CharacterLabel.GetComponent<UISprite>().spriteName = "text_operator_name3";
                break;
        }
        CharacterLeftImage.GetComponent<UISprite>().MakePixelPerfect();
        CharacterLabel.GetComponent<UISprite>().MakePixelPerfect();
    }

    public void SkinLockOffWindowClose()
    {
        Debug.Log("SkinLockOffWindowClose");
        //GetComponent<HangarPopupController>().CloseWindow();
        GetComponent<HangarPopupController>().AddPopWin(upgradePointWindow, -1, AddReinforcePoint, true);
    }

    public void AddReinforcePoint()
    {
        upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 1";
    }

    //BulletUp!!!!!!!!!!!!!!!!!!!!

    public void Flight000BulletUp()
    {
        int flight000BulletInt = ValueDeliverScript.flight000Bullet;
        int coinRest = ValueDeliverScript.coinRest;
        if (coinRest < ValueDeliverScript.flight000BulletUpCoin[flight000BulletInt + 1])
        {
            GoToCoinShortageWindow();
            return;
        }

        if (ValueDeliverScript.flight000Bullet >= 15) return;
        GetComponent<HangarPopupController>().AddPopWin(upgradePointWindow, 0, Flight000BulletUp01);
    }
    public void Flight000BulletUp01()
    {
        int flight000BulletInt = ValueDeliverScript.flight000Bullet;
        int coinRest = ValueDeliverScript.coinRest;
        int upgradePoint = ValueDeliverScript.upgradePoint;

        if (flight000BulletInt < 15)
        {
            if (coinRest < ValueDeliverScript.flight000BulletUpCoin[flight000BulletInt + 1])
            {
                GoToCoinShortageWindow();
                return;
            }
            else
            {
                flight000BulletInt++;
                ValueDeliverScript.flight000Bullet = flight000BulletInt;
                string levelNum = flight000BulletInt.ToString("00");
                if (flight000BulletInt >= 15) levelNum = "MAX";
                flight000BulletLabel.GetComponent<UILabel>().text = levelNum;
                flight000Bullet.GetComponent<UISprite>().spriteName = "Bullet" + "00_" + flight000BulletInt.ToString("D3");
                flight000Bullet.GetComponent<UISprite>().MakePixelPerfect();

                ValueDeliverScript.coinRest = coinRest - ValueDeliverScript.flight000BulletUpCoin[flight000BulletInt];
                GameObject.Find("FlightTag00/_Tag/BulletUpCost").GetComponent<UILabel>().text = ValueDeliverScript.flight000BulletUpCoin[flight000BulletInt + 1].ToString();
                GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.

                ValueDeliverScript.upgradePoint = upgradePoint + 1;
                FlightLockOffCheck();   //총알을 업뎃하면 확인해서 스킨 락을 풀지 여부를 결정하는 부분.
                flightUpointSetScript.RedrawStatePoint();

                upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 1";
                //StartCoroutine(WaitFirstThing("X 1"));
            }
            SkinlockOffCount(); //비행기기본창에서 스킨이 몇개 활성화 되어있는지 보이게 하는 함수.
        }
        if (ValueDeliverScript.flight000Bullet >= 15)
            GameObject.Find("WinMove").transform.FindChild("Flights/UpParent").gameObject.SetActive(false);
        else
            GameObject.Find("WinMove").transform.FindChild("Flights/UpParent").gameObject.SetActive(true);
        
        ValueDeliverScript.SaveGameData();
    }

    public void Flight001BulletUp()
    {
        int flight001BulletInt = ValueDeliverScript.flight001Bullet;
        int coinRest = ValueDeliverScript.coinRest;

        if (coinRest < ValueDeliverScript.flight001BulletUpCoin[flight001BulletInt + 1])
        {
            GoToCoinShortageWindow();
            return;
        }


        if (ValueDeliverScript.flight001Bullet >= 15) return;
        GetComponent<HangarPopupController>().AddPopWin(upgradePointWindow, 0, Flight001BulletUp01);
    }
    public void Flight001BulletUp01()
    {
        int flight001BulletInt = ValueDeliverScript.flight001Bullet;
        int coinRest = ValueDeliverScript.coinRest;
        int upgradePoint = ValueDeliverScript.upgradePoint;

        if (flight001BulletInt < 15)
        {
            if (coinRest < ValueDeliverScript.flight001BulletUpCoin[flight001BulletInt + 1])
            {
                GoToCoinShortageWindow();
                return;
            }
            else
            {
                flight001BulletInt++;
                ValueDeliverScript.flight001Bullet = flight001BulletInt;
                string levelNum = flight001BulletInt.ToString("00");
                if (flight001BulletInt >= 15) levelNum = "MAX";
                flight001BulletLabel.GetComponent<UILabel>().text = levelNum;
                flight001Bullet.GetComponent<UISprite>().spriteName = "Bullet" + "01_" + flight001BulletInt.ToString("D3");
                flight001Bullet.GetComponent<UISprite>().MakePixelPerfect();

                ValueDeliverScript.coinRest = coinRest - ValueDeliverScript.flight001BulletUpCoin[flight001BulletInt];
                GameObject.Find("FlightTag01/_Tag/BulletUpCost").GetComponent<UILabel>().text = ValueDeliverScript.flight001BulletUpCoin[flight001BulletInt + 1].ToString();
                GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.

                ValueDeliverScript.upgradePoint = upgradePoint + 1;
                FlightLockOffCheck();   //총알을 업뎃하면 확인해서 스킨 락을 풀지 여부를 결정하는 부분.
                flightUpointSetScript.RedrawStatePoint();

                upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 1";
                //StartCoroutine(WaitFirstThing("X 1"));
            }
            SkinlockOffCount(); //비행기기본창에서 스킨이 몇개 활성화 되어있는지 보이게 하는 함수.
        }
        if (ValueDeliverScript.flight000Bullet >= 15)
            GameObject.Find("WinMove").transform.FindChild("Flights/UpParent").gameObject.SetActive(false);
        else
            GameObject.Find("WinMove").transform.FindChild("Flights/UpParent").gameObject.SetActive(true);
      
        ValueDeliverScript.SaveGameData();
    }

    public void Flight002BulletUp()
    {
        int flight002BulletInt = ValueDeliverScript.flight002Bullet;
        int coinRest = ValueDeliverScript.coinRest;

        if (coinRest < ValueDeliverScript.flight002BulletUpCoin[flight002BulletInt + 1])
        {
            GoToCoinShortageWindow();
            return;
        }

        if (ValueDeliverScript.flight002Bullet >= 15) return;
        GetComponent<HangarPopupController>().AddPopWin(upgradePointWindow, 0, Flight002BulletUp01);
    }
    public void Flight002BulletUp01()
    {
        int flight002BulletInt = ValueDeliverScript.flight002Bullet;
        int coinRest = ValueDeliverScript.coinRest;
        int upgradePoint = ValueDeliverScript.upgradePoint;

        if (flight002BulletInt < 15)
        {
            if (coinRest < ValueDeliverScript.flight002BulletUpCoin[flight002BulletInt + 1])
            {
                GoToCoinShortageWindow();
                return;
            }
            else
            {
                flight002BulletInt++;
                ValueDeliverScript.flight002Bullet = flight002BulletInt;
                string levelNum = flight002BulletInt.ToString("00");
                if (flight002BulletInt >= 15) levelNum = "MAX";
                flight002BulletLabel.GetComponent<UILabel>().text = levelNum;
                flight002Bullet.GetComponent<UISprite>().spriteName = "Bullet" + "02_" + flight002BulletInt.ToString("D3");
                flight002Bullet.GetComponent<UISprite>().MakePixelPerfect();

                ValueDeliverScript.coinRest = coinRest - ValueDeliverScript.flight001BulletUpCoin[flight002BulletInt];
                GameObject.Find("FlightTag02/_Tag/BulletUpCost").GetComponent<UILabel>().text = ValueDeliverScript.flight002BulletUpCoin[flight002BulletInt + 1].ToString();
                GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.

                ValueDeliverScript.upgradePoint = upgradePoint + 1;
                FlightLockOffCheck();   //총알을 업뎃하면 확인해서 스킨 락을 풀지 여부를 결정하는 부분.
                flightUpointSetScript.RedrawStatePoint();

                upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 1";
                //StartCoroutine(WaitFirstThing("X 1"));
            }
            SkinlockOffCount(); //비행기기본창에서 스킨이 몇개 활성화 되어있는지 보이게 하는 함수.
        }
        if (ValueDeliverScript.flight000Bullet >= 15)
            GameObject.Find("WinMove").transform.FindChild("Flights/UpParent").gameObject.SetActive(false);
        else
            GameObject.Find("WinMove").transform.FindChild("Flights/UpParent").gameObject.SetActive(true);

        ValueDeliverScript.SaveGameData();
    }

    //SkillUp!!!!!!!!!!!!
    public void Flight000SkillUp()
    {
        int flight000Skill = ValueDeliverScript.flight000Skill;
        int coinRest = ValueDeliverScript.coinRest;
        int upgradePoint = ValueDeliverScript.upgradePoint;

        if (flight000Skill < 5)
        {
            if (coinRest < ValueDeliverScript.flight000SkillUpCoin[flight000Skill + 1])
            {
                GoToCoinShortageWindow();
                return;
            }
            else
            {
                flight000Skill++;
                ValueDeliverScript.flight000Skill = flight000Skill;
                string lavel = "01";
                if (flight000Skill < 5) lavel = flight000Skill.ToString("D2"); else lavel = "MAX";
                flight000SkillLabel.GetComponent<UILabel>().text = lavel;
                ValueDeliverScript.coinRest = coinRest - ValueDeliverScript.flight000SkillUpCoin[flight000Skill];
                GameObject.Find("FlightTag00/_Tag/SkillUpCost").GetComponent<UILabel>().text = ValueDeliverScript.flight000SkillUpCoin[ValueDeliverScript.flight000Skill + 1].ToString();
                GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.
                ValueDeliverScript.upgradePoint = upgradePoint + 1;
                upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 1";
                ShowUpgradePointWindow();

                flightUpointSetScript.RedrawStatePoint();
            }
        }
        ValueDeliverScript.SaveGameData();
    }

    public void Flight001SkillUp()
    {
        int flight001Skill = ValueDeliverScript.flight001Skill;
        int coinRest = ValueDeliverScript.coinRest;
        int upgradePoint = ValueDeliverScript.upgradePoint;

        if (flight001Skill < 5)
        {
            if (coinRest < ValueDeliverScript.flight001SkillUpCoin[flight001Skill + 1])
            {
                GoToCoinShortageWindow();
                return;
            }
            else
            {
                flight001Skill++;
                ValueDeliverScript.flight001Skill = flight001Skill;
                string label = "01";
                if (flight001Skill < 5) label = flight001Skill.ToString("D2"); else label = "MAX";
                flight001SkillLabel.GetComponent<UILabel>().text = label;
                ValueDeliverScript.coinRest = coinRest - ValueDeliverScript.flight001SkillUpCoin[flight001Skill];
                GameObject.Find("FlightTag01/_Tag/SkillUpCost").GetComponent<UILabel>().text = ValueDeliverScript.flight001SkillUpCoin[flight001Skill + 1].ToString();
                GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.
                ValueDeliverScript.upgradePoint = upgradePoint + 1;
                upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 1";
                ShowUpgradePointWindow();

                flightUpointSetScript.RedrawStatePoint();
            }
        }
        ValueDeliverScript.SaveGameData();
    }

    public void Flight002SkillUp()
    {
        int flight002Skill = ValueDeliverScript.flight002Skill;
        int coinRest = ValueDeliverScript.coinRest;
        int upgradePoint = ValueDeliverScript.upgradePoint;

        if (flight002Skill < 5)
        {
            if (coinRest < ValueDeliverScript.flight002SkillUpCoin[flight002Skill + 1])
            {
                GoToCoinShortageWindow();
                return;
            }
            else
            {
                flight002Skill++;
                ValueDeliverScript.flight002Skill = flight002Skill;
                string lavel = "01";
                if (flight002Skill < 5) lavel = flight002Skill.ToString("D2"); else lavel = "MAX";
                flight002SkillLabel.GetComponent<UILabel>().text = lavel;
                ValueDeliverScript.coinRest = coinRest - ValueDeliverScript.flight002SkillUpCoin[flight002Skill];
                GameObject.Find("FlightTag02/_Tag/SkillUpCost").GetComponent<UILabel>().text = ValueDeliverScript.flight002SkillUpCoin[flight002Skill + 1].ToString();
                GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.
                ValueDeliverScript.upgradePoint = upgradePoint + 1;
                upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 1";
                ShowUpgradePointWindow();

                flightUpointSetScript.RedrawStatePoint();
            }
        }
        ValueDeliverScript.SaveGameData();
    }

    public void DuraRecharge() //수리하기 버튼을 누르면 작동하는 함수. 위치는 SkinSelectWindow  >> Dura //
    {
        string duraCostS = "Flight" + ValueDeliverScript.flightNumber.ToString("D3") + "Skin" + ValueDeliverScript.skinNumber.ToString("D3") + "Level" + ValueDeliverScript.skinLevel.ToString("D3");
        int duraCostI = int.Parse(ValueDeliverScript.duraCost[duraCostS].ToString());
        int coinRest = ValueDeliverScript.coinRest;

        if (duraCostI > coinRest)
        {
            GoToCoinShortageWindow();
            return;
        }
        else
        {
            ValueDeliverScript.coinRest = coinRest - duraCostI;
            GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.
            GameObject.Find("Dura").SetActive(false);

            switch (ValueDeliverScript.flightNumber)
            {
                case 0: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: ValueDeliverScript.FlightDura000Skin001 = 10; break;
                        case 2: ValueDeliverScript.FlightDura000Skin002 = 10; break;
                        case 3: ValueDeliverScript.FlightDura000Skin003 = 10; break;
                        case 4: ValueDeliverScript.FlightDura000Skin004 = 10; break;
                        case 5: ValueDeliverScript.FlightDura000Skin005 = 10; break;
                    } break;
                case 1: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: ValueDeliverScript.FlightDura001Skin001 = 10; break;
                        case 2: ValueDeliverScript.FlightDura001Skin002 = 10; break;
                        case 3: ValueDeliverScript.FlightDura001Skin003 = 10; break;
                        case 4: ValueDeliverScript.FlightDura001Skin004 = 10; break;
                        case 5: ValueDeliverScript.FlightDura001Skin005 = 10; break;
                    } break;
                case 2: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: ValueDeliverScript.FlightDura002Skin001 = 10; break;
                        case 2: ValueDeliverScript.FlightDura002Skin002 = 10; break;
                        case 3: ValueDeliverScript.FlightDura002Skin003 = 10; break;
                        case 4: ValueDeliverScript.FlightDura002Skin004 = 10; break;
                        case 5: ValueDeliverScript.FlightDura002Skin005 = 10; break;
                    } break;
            }

            GameObject SelectedSkin = GameObject.Find("SkinSelectWindow" + ValueDeliverScript.flightNumber.ToString("D2")).transform.FindChild("Skin").FindChild("Skin" + ValueDeliverScript.skinNumber.ToString("D2")).gameObject;
            SelectedSkin.transform.FindChild("SkinIcon").GetComponent<UISprite>().alpha = 1f;
            SelectedSkin.transform.FindChild("RefairIcon").gameObject.SetActive(false);
            SelectedSkin.transform.FindChild("DuraLabel").GetComponent<UILabel>().text = "10/10";
        }
        ValueDeliverScript.SaveGameData();
    }

    private void SkinLockOffMessage()
    {
        GameObject.Find("SkinSelectWindow00/Skin/Skin01").GetComponent<PositionSkinSendScript>().lockOffCondition = ValueDeliverScript.flight000SortieNumber + "/100 Times Sortie";
        GameObject.Find("SkinSelectWindow00/Skin/Skin02").GetComponent<PositionSkinSendScript>().lockOffCondition = "Reached Pilot Level " + ValueDeliverScript.userLevel + "/5";
        GameObject.Find("SkinSelectWindow00/Skin/Skin03").GetComponent<PositionSkinSendScript>().lockOffCondition = ValueDeliverScript.flight000BombUseNumber + "/300 Times Nuke Bomb Used";
        GameObject.Find("SkinSelectWindow00/Skin/Skin04").GetComponent<PositionSkinSendScript>().lockOffCondition = "Score" + ValueDeliverScript.flight000ScoreHigh + "/2500000 Accomplished";
        GameObject.Find("SkinSelectWindow00/Skin/Skin05").GetComponent<PositionSkinSendScript>().lockOffCondition = "Bullet Upgrade: Level" + ValueDeliverScript.flight000Bullet + "/15";

        GameObject.Find("SkinSelectWindow01/Skin/Skin01").GetComponent<PositionSkinSendScript>().lockOffCondition = ValueDeliverScript.flight001EnemyKill + "/50000 Enemies Destroyed";
        GameObject.Find("SkinSelectWindow01/Skin/Skin02").GetComponent<PositionSkinSendScript>().lockOffCondition = ValueDeliverScript.flight001GetCoin + "/100000 Coins Obtained";
        GameObject.Find("SkinSelectWindow01/Skin/Skin03").GetComponent<PositionSkinSendScript>().lockOffCondition = ValueDeliverScript.flight001UseSkill + "/500 Times Skill Used";
        GameObject.Find("SkinSelectWindow01/Skin/Skin04").GetComponent<PositionSkinSendScript>().lockOffCondition = ValueDeliverScript.flight001GetPowerItem + "/3000 PowerUp Acquired";
        GameObject.Find("SkinSelectWindow01/Skin/Skin05").GetComponent<PositionSkinSendScript>().lockOffCondition = "Bullet Upgrade: Level " + ValueDeliverScript.flight001Bullet + "/15";

        GameObject.Find("SkinSelectWindow02/Skin/Skin01").GetComponent<PositionSkinSendScript>().lockOffCondition = ValueDeliverScript.flight002KillSpinball + "/50000 Spinballs Destroyed";
        GameObject.Find("SkinSelectWindow02/Skin/Skin02").GetComponent<PositionSkinSendScript>().lockOffCondition = ValueDeliverScript.flight002SpecialAttack + "/100 Times of Special Sortie";
        GameObject.Find("SkinSelectWindow02/Skin/Skin03").GetComponent<PositionSkinSendScript>().lockOffCondition = ValueDeliverScript.flight002CompleteInstanceMission + "/1000 Instant Missions Completed";
        GameObject.Find("SkinSelectWindow02/Skin/Skin04").GetComponent<PositionSkinSendScript>().lockOffCondition = ValueDeliverScript.flight002RescueFriend + "/5000 Friends Rescued";
        GameObject.Find("SkinSelectWindow02/Skin/Skin05").GetComponent<PositionSkinSendScript>().lockOffCondition = "Level 5 Accomplished";
    }

    //비행기 스킨별로 락 해제 조건 검사하고 결과를 알려주는 함수//
    public bool SkinLockCheck(int flightNumber, int skinNumber)
    {
        SkinLockOffMessage();
        bool check = false;
        string skinName = "FlightLock" + flightNumber.ToString("D3") + "Skin" + skinNumber.ToString("D3");
        int skinNameVal = 0;
        switch (flightNumber)
        {
            case 0: switch (skinNumber)
                {
                    case 1: skinNameVal = ValueDeliverScript.FlightLock000Skin001; break;
                    case 2: skinNameVal = ValueDeliverScript.FlightLock000Skin002; break;
                    case 3: skinNameVal = ValueDeliverScript.FlightLock000Skin003; break;
                    case 4: skinNameVal = ValueDeliverScript.FlightLock000Skin004; break;
                    case 5: skinNameVal = ValueDeliverScript.FlightLock000Skin005; break;
                } break;
            case 1: switch (skinNumber)
                {
                    case 1: skinNameVal = ValueDeliverScript.FlightLock001Skin001; break;
                    case 2: skinNameVal = ValueDeliverScript.FlightLock001Skin002; break;
                    case 3: skinNameVal = ValueDeliverScript.FlightLock001Skin003; break;
                    case 4: skinNameVal = ValueDeliverScript.FlightLock001Skin004; break;
                    case 5: skinNameVal = ValueDeliverScript.FlightLock001Skin005; break;
                } break;
            case 2: switch (skinNumber)
                {
                    case 1: skinNameVal = ValueDeliverScript.FlightLock002Skin001; break;
                    case 2: skinNameVal = ValueDeliverScript.FlightLock002Skin002; break;
                    case 3: skinNameVal = ValueDeliverScript.FlightLock002Skin003; break;
                    case 4: skinNameVal = ValueDeliverScript.FlightLock002Skin004; break;
                    case 5: skinNameVal = ValueDeliverScript.FlightLock002Skin005; break;
                } break;
        }

        switch (skinName)
        {
            //포커 락해제 조건//
            case "FlightLock000Skin001":
                if (ValueDeliverScript.flight000SortieNumber >= 100 && skinNameVal == 0)    //100회 출격//(완)
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock000Skin001 = 1;
                    check = true;
                }
                break;

            case "FlightLock000Skin002":
                if (ValueDeliverScript.userLevel >= 5 && skinNameVal == 0)  //파일럿 5레벨도달//(완)
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock000Skin002 = 1;
                    check = true;
                }
                break;

            case "FlightLock000Skin003":
                if (ValueDeliverScript.flight000BombUseNumber >= 300 && skinNameVal == 0)   //핵폭탄 300회 사용//(완)
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock000Skin003 = 1;
                    check = true;
                }
                break;

            case "FlightLock000Skin004":
                if (ValueDeliverScript.flight000ScoreHigh >= 2500000 && skinNameVal == 0)    //250만점 달성//(완)
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock000Skin004 = 1;
                    check = true;
                }
                break;

            case "FlightLock000Skin005":
                if (ValueDeliverScript.flight000Bullet >= 15 && skinNameVal == 0)   //기체 탄환 15단계 업그레이드//(완)
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock000Skin005 = 1;
                    check = true;
                }
                break;

            //코만치 락해제 조건//
            case "FlightLock001Skin001":
                if (ValueDeliverScript.flight001EnemyKill >= 50000 && skinNameVal == 0) //적 50000대 파괴//(완)
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock001Skin001 = 1;
                    check = true;
                }
                break;

            case "FlightLock001Skin002":
                if (ValueDeliverScript.flight001GetCoin >= 100000 && skinNameVal == 0)  //100000코인 획득//(완)
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock001Skin002 = 1;
                    check = true;
                }
                break;

            case "FlightLock001Skin003":
                if (ValueDeliverScript.flight001UseSkill >= 500 && skinNameVal == 0)    //스킬 500회 사용//(완)
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock001Skin003 = 1;
                    check = true;
                }
                break;

            case "FlightLock001Skin004":
                if (ValueDeliverScript.flight001GetPowerItem >= 3000 && skinNameVal == 0)   //파워아이템 3000개 획득//
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock001Skin004 = 1;
                    check = true;
                }
                break;

            case "FlightLock001Skin005":
                if (ValueDeliverScript.flight001Bullet >= 15 && skinNameVal == 0)   //기체 탄환 15단계 업그레이드//
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock001Skin005 = 1;
                    check = true;
                }
                break;

            //팬텀 락해제 조건//
            case "FlightLock002Skin001":
                if (ValueDeliverScript.flight002KillSpinball >= 50000 && skinNameVal == 0)    //스핀볼 50000대 파괴//
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock002Skin001 = 1;
                    check = true;
                }
                break;

            case "FlightLock002Skin002":
                if (ValueDeliverScript.flight002SpecialAttack >= 100 && skinNameVal == 0)    //스페셜출격 100회//
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock002Skin002 = 1;
                    check = true;
                }
                break;

            case "FlightLock002Skin003":
                if (ValueDeliverScript.flight002CompleteInstanceMission >= 1000 && skinNameVal == 0) //인스턴트미션 1000회 완료//
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock002Skin003 = 1;
                    check = true;
                }
                break;

            case "FlightLock002Skin004":
                if (ValueDeliverScript.flight002RescueFriend >= 5000 && skinNameVal == 0)    //친구 5000명 구출//
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock002Skin004 = 1;
                    check = true;
                }
                break;

            case "FlightLock002Skin005":
                if (ValueDeliverScript.flight002WormLevel5 == 1 && skinNameVal == 0)     //6단계 도달//
                {
                    IsOpenLockOffWindow(skinName, 0);
                    ValueDeliverScript.FlightLock002Skin005 = 1;
                    check = true;
                }
                break;
        }

        //ValueDeliverScript.SaveGameData();
        return check;
    }

    //새로이 스킨 락이 해제 되었을때 실행되는 알림창을 열어준다//
    private void IsOpenLockOffWindow(string skinName, int val)
    {
        if (skinSelectWindow00.transform.localPosition.x == 40 || skinSelectWindow01.transform.localPosition.x == 40 || skinSelectWindow02.transform.localPosition.x == 40)
        {
            return;
        }
        ValueDeliverScript.upgradePoint++;
        //락오프 한적이 없었다면 첨이자 마지막으로 락오프가 되는 것이니 비행기가 락이 풀렸다고 창을 띄워 알려줌.
        if (val == 0)
        {
            Debug.Log("skinName ::: " + skinName);

            if (skinName.Contains("FlightLock000"))
            {
                int num = int.Parse(skinName.Replace("FlightLock000Skin", "")) + 1;
                skinName = "Fokker" + num.ToString("000");
            }
            else if (skinName.Contains("FlightLock001"))
            {
                int num = int.Parse(skinName.Replace("FlightLock001Skin", "")) + 1;
                skinName = "Fokker" + num.ToString("000");
            }
            else if (skinName.Contains("FlightLock002"))
            {
                int num = int.Parse(skinName.Replace("FlightLock002Skin", "")) + 1;
                skinName = "Fokker" + num.ToString("000");
            }
            skinLockOffWindow.transform.FindChild("Item001").FindChild("Icon").GetComponent<UISprite>().spriteName = skinName + "Fix";
        }
        ValueDeliverScript.SaveGameData();
        IsOpenLockOffWindow01();
    }

    void IsOpenLockOffWindow01()
    {
        GetComponent<HangarPopupController>().AddPopWin(skinLockOffWindow, 0);
    }

    private IEnumerator WaitShowWindow(GameObject[] userWindow01, NextFunc func)
    {
        while (true)
        {
            //우선은 열려있는 창이 몇개인지 확인한다//창은 userWindow01 값에 배열로 들어가 있다//
            int winOff = 0;
            foreach (var win in userWindow01)
            {
                if (win.activeSelf == true)
                    winOff++;
            }

            if (winOff == 0) { func(); yield break; }
            else
            {
                yield return null;
            }
        }

        //열려 있는 창이 없으면 다음에 실행될 메소드로 지정된 메소드를 실행한다//
        func();
    }

    public void FlightSkinLockOff() // 스킨 잠금 해제 버튼 눌렀을때 실행되는 함수.
    {
        string skinName = "Flight" + ValueDeliverScript.flightNumber.ToString("D3") + "Skin" + ValueDeliverScript.skinNumber.ToString("D3");  //해쉬테이블에서 스킨별 메달코스트를 가지고 올수 있게 비행기 넘버와 스킨 넘버를 이용하여 스킨 이름을 생성.
        Debug.Log("skinName ::: " + skinName);
        int skinMedalCostI = int.Parse(ValueDeliverScript.skinMedalCost[skinName].ToString()); //락 해제 가격(다이아몬드, 코인)을 가져와 int 형으로 변환하여 사용가능하게 만듬.
        int medalRest = ValueDeliverScript.medalRest; //현재의 메달량을 Int 형으로 변환하여 가져온다.
        int coinRest = ValueDeliverScript.coinRest;   //현재의 코인량을  int 형으로 변환하여 가져온다.
        int upgradePoint = ValueDeliverScript.upgradePoint;

        if (ValueDeliverScript.skinNumber != 4)
        {
            if (skinMedalCostI > coinRest)   //코인이 부족하면 메달 구매창을 띄움.
            {
                GoToCoinShortageWindow();
                return;
            }
            else
            {
                GameObject SelectedSkin = GameObject.Find("SkinSelectWindow" + ValueDeliverScript.flightNumber.ToString("D2")).transform.FindChild("Skin").FindChild("Skin" + ValueDeliverScript.skinNumber.ToString("D2")).gameObject;
                coinRest -= skinMedalCostI;
                ValueDeliverScript.coinRest = coinRest; //사용메달 차감.
                GameObject.Find("GoldRestLabel").GetComponent<UILabel>().text = coinRest.ToString(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.
                SelectedSkin.transform.parent.parent.FindChild("Lock").gameObject.SetActive(false);   //스킨락 버튼이랑 내용들 숨김.

                //string skinName = "FlightLock" + flightNumber.ToString("D3") + "Skin" + skinNumber.ToString("D3");
                skinName = "FlightLock" + ValueDeliverScript.flightNumber.ToString("D3") + "Skin" + ValueDeliverScript.skinNumber.ToString("D3");  //해쉬테이블에서 스킨별 메달코스트를 가지고 올수 있게 비행기 넘버와 스킨 넘버를 이용하여 스킨 이름을 생성.
                //Skin Name Sample ::: FlightLock000Skin001 :::

                switch (ValueDeliverScript.flightNumber)
                {
                    case 0: switch (ValueDeliverScript.skinNumber)
                        {
                            case 1: ValueDeliverScript.FlightLock000Skin001 = 1; break;
                            case 2: ValueDeliverScript.FlightLock000Skin002 = 1; break;
                            case 3: ValueDeliverScript.FlightLock000Skin003 = 1; break;
                            case 4: ValueDeliverScript.FlightLock000Skin004 = 1; break;
                            case 5: ValueDeliverScript.FlightLock000Skin005 = 1; break;
                        } break;
                    case 1: switch (ValueDeliverScript.skinNumber)
                        {
                            case 1: ValueDeliverScript.FlightLock001Skin001 = 1; break;
                            case 2: ValueDeliverScript.FlightLock001Skin002 = 1; break;
                            case 3: ValueDeliverScript.FlightLock001Skin003 = 1; break;
                            case 4: ValueDeliverScript.FlightLock001Skin004 = 1; break;
                            case 5: ValueDeliverScript.FlightLock001Skin005 = 1; break;
                        } break;
                    case 2: switch (ValueDeliverScript.skinNumber)
                        {
                            case 1: ValueDeliverScript.FlightLock002Skin001 = 1; break;
                            case 2: ValueDeliverScript.FlightLock002Skin002 = 1; break;
                            case 3: ValueDeliverScript.FlightLock002Skin003 = 1; break;
                            case 4: ValueDeliverScript.FlightLock002Skin004 = 1; break;
                            case 5: ValueDeliverScript.FlightLock002Skin005 = 1; break;
                        } break;
                }

                SelectedSkin.transform.FindChild("SkinIcon").GetComponent<UISprite>().alpha = 1f;
                SelectedSkin.transform.FindChild("LockIcon").gameObject.SetActive(false);

                upgradePoint += 1;
                ValueDeliverScript.upgradePoint = upgradePoint;
                upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 1";
                ShowUpgradePointWindow();

                flightUpointSetScript.RedrawStatePoint();
                StartCoroutine(SkinLockOffCharSound());
            }
        }
        else
        {
            if (skinMedalCostI > medalRest)   //메달이 부족하면 메달 구매창을 띄움.
            {
                GoToMedalShortageWindow();
                return;
            }
            else
            {
                GameObject SelectedSkin = GameObject.Find("SkinSelectWindow" + ValueDeliverScript.flightNumber.ToString("D2")).transform.FindChild("Skin").FindChild("Skin" + ValueDeliverScript.skinNumber.ToString("D2")).gameObject;
                medalRest -= skinMedalCostI;
                ValueDeliverScript.medalRest = medalRest; //사용금화 차감.
                GameObject.Find("MedalRestLabel").GetComponent<UILabel>().text = medalRest.ToString(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.
                SelectedSkin.transform.parent.parent.FindChild("Lock").gameObject.SetActive(false);   //스킨락 버튼이랑 내용들 숨김.

                //string skinName = "FlightLock" + flightNumber.ToString("D3") + "Skin" + skinNumber.ToString("D3");
                skinName = "FlightLock" + ValueDeliverScript.flightNumber.ToString("D3") + "Skin" + ValueDeliverScript.skinNumber.ToString("D3");  //해쉬테이블에서 스킨별 메달코스트를 가지고 올수 있게 비행기 넘버와 스킨 넘버를 이용하여 스킨 이름을 생성.
                //Skin Name Sample ::: FlightLock000Skin001 :::
                switch (ValueDeliverScript.flightNumber)
                {
                    case 0: switch (ValueDeliverScript.skinNumber)
                        {
                            case 1: ValueDeliverScript.FlightLock000Skin001 = 1; break;
                            case 2: ValueDeliverScript.FlightLock000Skin002 = 1; break;
                            case 3: ValueDeliverScript.FlightLock000Skin003 = 1; break;
                            case 4: ValueDeliverScript.FlightLock000Skin004 = 1; break;
                            case 5: ValueDeliverScript.FlightLock000Skin005 = 1; break;
                        } break;
                    case 1: switch (ValueDeliverScript.skinNumber)
                        {
                            case 1: ValueDeliverScript.FlightLock001Skin001 = 1; break;
                            case 2: ValueDeliverScript.FlightLock001Skin002 = 1; break;
                            case 3: ValueDeliverScript.FlightLock001Skin003 = 1; break;
                            case 4: ValueDeliverScript.FlightLock001Skin004 = 1; break;
                            case 5: ValueDeliverScript.FlightLock001Skin005 = 1; break;
                        } break;
                    case 2: switch (ValueDeliverScript.skinNumber)
                        {
                            case 1: ValueDeliverScript.FlightLock002Skin001 = 1; break;
                            case 2: ValueDeliverScript.FlightLock002Skin002 = 1; break;
                            case 3: ValueDeliverScript.FlightLock002Skin003 = 1; break;
                            case 4: ValueDeliverScript.FlightLock002Skin004 = 1; break;
                            case 5: ValueDeliverScript.FlightLock002Skin005 = 1; break;
                        } break;
                }

                SelectedSkin.transform.FindChild("SkinIcon").GetComponent<UISprite>().alpha = 1f;
                SelectedSkin.transform.FindChild("LockIcon").gameObject.SetActive(false);

                upgradePoint += 1;
                ValueDeliverScript.upgradePoint = upgradePoint;
                upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 1";
                ShowUpgradePointWindow();

                flightUpointSetScript.RedrawStatePoint();
                StartCoroutine(SkinLockOffCharSound());
            }
        }
        ValueDeliverScript.SaveGameData();
    }

    private IEnumerator SkinLockOffCharSound()
    {
        int activeOper = ValueDeliverScript.activeOper;
        yield return new WaitForSeconds(0.5f);
        CharacterMsgSndConScript characterMsgSndCon;
        characterMsgSndCon = GameObject.Find("CharacterMsgSndCon").GetComponent<CharacterMsgSndConScript>();
        characterMsgSndCon.SkinUnlock(activeOper);
    }

    public void OpenSound()
    {
        audio.PlayOneShot(popupDisplay, ValueDeliverScript.fxSound);
    }

    public void LevelPopupDisplay()
    {
        audio.PlayOneShot(levelPopupDisplay, ValueDeliverScript.fxSound);
    }

    public void CloseSound()
    {
    }

    public void GoldPurchaseWindow(int itemNumber)
    {
        int goldPrice = int.Parse((ValueDeliverScript.goldPrice["GoldPrice" + itemNumber.ToString("000")]).ToString());     //아이템 메달가격을 알아온다.
        int goldPriceNum = int.Parse((ValueDeliverScript.goldPrice["GoldPrice" + itemNumber.ToString("000") + "Num"]).ToString());     //아이템별 구매시 지급되는 골드의 갯수를 알아온다.
        int medalRest = ValueDeliverScript.medalRest;
        int coinRest = ValueDeliverScript.coinRest;

        if (goldPrice > medalRest)
        {
            GoToMedalShortageWindow();
            return;
        }
        medalRest -= goldPrice;
        coinRest += goldPriceNum;

        ValueDeliverScript.medalRest = medalRest;
        ValueDeliverScript.coinRest = coinRest;
        purchaseConfirmWindow.SetActive(true);
        purchaseConfirmWindow.GetComponent<purchaseScript>().Activate();
        purchaseConfirmWindow.transform.FindChild("purchaseItem").GetComponent<UISprite>().spriteName = "icon_gold_" + itemNumber; //골드 이미지를 아이템에 맞게 보여준다.
        purchaseConfirmWindow.transform.FindChild("purchaseItem").GetComponent<UISprite>().MakePixelPerfect(); //가스 이미지를 아이템에 맞게 보여준다.
        purchaseConfirmWindow.transform.FindChild("Script01").GetComponent<UILabel>().text = "You purchased Coins."; //골드 이미지를 아이템에 맞게 보여준다.
        GameObject.Find("GameManager").GetComponent<GasTimeScript>().MedalRecount(); //화면에 표시되는 메달양을 다시 계산하여 재표시하여줌.
        GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.
        ValueDeliverScript.SaveGameData();
    }

    public void GasPurchaseWindow(int itemNumber)
    {
        gasPrice = int.Parse((ValueDeliverScript.gasPrice["GasPrice" + itemNumber.ToString("000")]).ToString());     //아이템 메달가격을 알아온다.
        gasPriceNum = int.Parse((ValueDeliverScript.gasPrice["GasPrice" + itemNumber.ToString("000") + "Num"]).ToString());     //아이템별 구매시 지급되는 가스(연료)의 갯수를 알아온다.
        itemNumberF = itemNumber;
        int medalRest = ValueDeliverScript.medalRest;

        int gasRest = ValueDeliverScript.gasRest;

        if (gasPrice > medalRest)
        {
            GoToMedalShortageWindow();
            return;
        }
        if (gasPriceNum + gasRest > 500)
        {
            GotoGasOverWindow();
            return;
        }

        GasPurchaseWindow2();
    }

    public void GasPurchaseWindow2()
    {
        int medalRest = ValueDeliverScript.medalRest;
        int gasRest = ValueDeliverScript.gasRest;

        medalRest -= gasPrice;
        gasRest += gasPriceNum;

        //
        GameObject.Find("GasRestLabel").GetComponent<GasRestLabelScript>().GasRest(gasPriceNum, true);
        //

        ValueDeliverScript.medalRest = medalRest;
        ValueDeliverScript.gasRest = gasRest;

        GameObject.Find("GameManager").GetComponent<GasTimeScript>().isChangeFuel = true;
        purchaseConfirmWindow.SetActive(true);
        purchaseConfirmWindow.GetComponent<purchaseScript>().Activate();
        purchaseConfirmWindow.transform.FindChild("purchaseItem").GetComponent<UISprite>().spriteName = "icon_fuel_" + (itemNumberF + 1); //가스 이미지를 아이템에 맞게 보여준다.
        purchaseConfirmWindow.transform.FindChild("purchaseItem").GetComponent<UISprite>().MakePixelPerfect(); //가스 이미지를 아이템에 맞게 보여준다.
        purchaseConfirmWindow.transform.FindChild("Script01").GetComponent<UILabel>().text = "You purchased Fuel."; //가스 이미지를 아이템에 맞게 보여준다.

        gasPrice = 0;
        gasPriceNum = 0;
        itemNumberF = 0;

        GameObject.Find("GameManager").GetComponent<GasTimeScript>().MedalRecount(); //화면에 표시되는 메달양을 다시 계산하여 재표시하여줌.
        GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.

        GameObject.Find("GasRestLabel").GetComponent<GasRestLabelScript>().GasRest(0, false);   //입력된 추가 연료 갯수를 화면에 표시하기 위한 함수 호출.

        ValueDeliverScript.SaveGameData();
    }

    private void GotoGasOverWindow()
    {
        gasOverWindow.SetActive(true);
        halfBLKPanel.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, gasOverWindow.transform.localPosition.z + 5);
    }

    private void GasOverWindowYes()
    {
        gasOverWindow.SetActive(false);
        halfBLKPanel.SetActive(false);
        GasPurchaseWindow2();
    }

    private void GasOverWindowNo()
    {
        gasPrice = 0;
        gasPriceNum = 0;
        itemNumberF = 0;
        gasOverWindow.SetActive(false);
        halfBLKPanel.SetActive(false);
    }

    public static void Billing(String index)
    {
        //index = "6037045" + index;
        Debug.Log("INdex ::: " + index);
        //if (!CmBillingAndroid.Instance.GetActivateFlag(index))
        //{
        //    Debug.Log(":::::::::: Index Next 001");

        //    CmBillingAndroid.Instance.DoBilling(true, false, index, null, "GameManager", "OnBillingResult");
        //    Debug.Log(":::::::::: Index Next 002");

        //}
    }

    private void OnBillingResult(String result)
    {
        Debug.Log("여기오냐?돈?");
        Debug.Log("BillingResult=" + result);

        String[] results = result.Split('|');
    }

    public void MedalPurchaseWindow(int itemNumber)
    {
        //결제후 처리하는 부분들//
        int medalPriceNum = int.Parse((ValueDeliverScript.medalPrice["MedalPrice" + itemNumber.ToString("000") + "Num"]).ToString());
        int medalRest = ValueDeliverScript.medalRest;
        medalRest += medalPriceNum;
        ValueDeliverScript.medalRest = medalRest;
        ValueDeliverScript.SaveGameData();

        purchaseConfirmWindow.SetActive(true);
        purchaseConfirmWindow.GetComponent<purchaseScript>().Activate();
        if (itemNumber > 2) itemNumber += 1;

        purchaseConfirmWindow.transform.FindChild("purchaseItem").GetComponent<UISprite>().spriteName = "icon_deco_" + (itemNumber); //가스 이미지를 아이템에 맞게 보여준다.
        purchaseConfirmWindow.transform.FindChild("purchaseItem").GetComponent<UISprite>().MakePixelPerfect(); //다이아몬드 이미지를 아이템에 맞게 보여준다.
        purchaseConfirmWindow.transform.FindChild("Script01").GetComponent<UILabel>().text = "You purchased Diamonds"; //다이아몬드 이미지를 아이템에 맞게 보여준다.

        GameObject.Find("GameManager").GetComponent<GasTimeScript>().MedalRecount(); //화면에 표시되는 메달양을 다시 계산하여 재표시하여줌.
        GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.

        itemNumber = 0;
    }

    private IEnumerator GoSkinSelectWindow()
    {
        GetComponent<HangarPopupController>().CloseWindow();

        //duraBuyAlarmWindow.SetActive(false);
        //halfBLKPanel.SetActive(false);

        if (friendWindow.transform.localPosition.x < 160)
        {
            bgTop.animation.Play("BGMainTopAnim01");
            friendWindow.animation.Play("FriendWindowAnim02");
            yield return new WaitForSeconds(1f);

            switch (ValueDeliverScript.flightNumber)
            {
                case 0:
                    StartCoroutine(GoToSkinSelectWindow000());
                    break;

                case 1:
                    StartCoroutine(GoToSkinSelectWindow001());
                    break;

                case 2:
                    StartCoroutine(GoToSkinSelectWindow002());
                    break;
            }
        }

        if (ResultPanel.transform.FindChild("ResultPanelLeft").localPosition.x == 0)
        {
            ResultPanel.transform.FindChild("ResultPanelLeft").animation.Play("ResultPanelLeftAnim03");
            ResultPanel.transform.FindChild("ResultPanelRight").animation.Play("ResultPanelRightAnim02");
            ResultPanel.transform.FindChild("ResultLowTab").animation.Play("ResultLowTabAnim02");
            yield return new WaitForSeconds(1f);

            switch (ValueDeliverScript.flightNumber)
            {
                case 0:
                    skinSelectWindow00.animation.Play("SkinSelectWindowAnim01");
                    yield return new WaitForSeconds(0.5f);
                    skinSelectWindow00.transform.FindChild("BackBtn").gameObject.SetActive(true);
                    break;

                case 1:
                    skinSelectWindow01.animation.Play("SkinSelectWindowAnim01");
                    yield return new WaitForSeconds(0.5f);
                    skinSelectWindow01.transform.FindChild("BackBtn").gameObject.SetActive(true);
                    break;

                case 2:
                    skinSelectWindow02.animation.Play("SkinSelectWindowAnim01");
                    yield return new WaitForSeconds(0.5f);
                    skinSelectWindow01.transform.FindChild("BackBtn").gameObject.SetActive(true);
                    break;
            }

            prepareReady.transform.FindChild("RankFriendTF").gameObject.SetActive(true);
            Debug.Log("PrepareReadyAnim01");

            //메세지 유무 여부에 따라 깜박이 보이게 할지 안보이게 할지 결정//
            if (ValueDeliverScript.messageData.Length != 0) GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(true);
            else GameObject.Find("RankFriendTF").transform.FindChild("MessageArlam").gameObject.SetActive(false);

            prepareReady.animation.Play("PrepareReadyAnim01");
            flights.transform.FindChild("MoveTF/FlightsMove").localPosition = new Vector3(ValueDeliverScript.flightNumber * -1000, 0, 0);
        }
        else
        {
            switch (ValueDeliverScript.flightNumber)
            {
                case 0:
                    flights.animation.Play("FlightsPanelAnim02");
                    skinSelectWindow00.animation.Play("SkinSelectWindowAnim01");
                    yield return new WaitForSeconds(0.5f);
                    skinSelectWindow00.transform.FindChild("BackBtn").gameObject.SetActive(true);
                    break;

                case 1:
                    flights.animation.Play("FlightsPanelAnim02");
                    skinSelectWindow01.animation.Play("SkinSelectWindowAnim01");
                    yield return new WaitForSeconds(0.5f);
                    skinSelectWindow01.transform.FindChild("BackBtn").gameObject.SetActive(true);
                    break;

                case 2:
                    flights.animation.Play("FlightsPanelAnim02");
                    skinSelectWindow02.animation.Play("SkinSelectWindowAnim01");
                    yield return new WaitForSeconds(0.5f);
                    skinSelectWindow02.transform.FindChild("BackBtn").gameObject.SetActive(true);
                    break;
            }
        }
    }

    private void FlightLockOff()
    {
        int userLevel = ValueDeliverScript.userLevel;
        if (ValueDeliverScript.flightWindowPosition == 1 && userLevel >= 6) //코만치 락 해제되어 코인으로 살수 있는 조건.
            FlightLockOffCoin();
        else if (ValueDeliverScript.flightWindowPosition == 1 && userLevel < 6) //코만치 락 해제되어 코인으로 살수 있는 조건.
            FlightLockOffMedal();

        if (ValueDeliverScript.flightWindowPosition == 2 && userLevel >= 12) //팬텀 락 해제되어 코인으로 살수 있는 조건.
            FlightLockOffCoin();
        else if (ValueDeliverScript.flightWindowPosition == 2 && userLevel < 12)
            FlightLockOffMedal();
    }

    private void FlightLockOffCoin()
    {
        flights.GetComponent<UpgradeAlarmShow>().upParentShow();

        int coinRest = ValueDeliverScript.coinRest;
        int upgradePoint = ValueDeliverScript.upgradePoint;

        int flightCoinVal = 0;
        switch (ValueDeliverScript.flightWindowPosition)
        {
            case 1: flightCoinVal = ValueDeliverScript.FlightLockOff001Coin; break;
            case 2: flightCoinVal = ValueDeliverScript.FlightLockOff002Coin; break;
        }

        if (coinRest >= flightCoinVal)
        {
            coinRest -= flightCoinVal;
            ValueDeliverScript.coinRest = coinRest;

            switch (ValueDeliverScript.flightWindowPosition)
            {
                case 1:
                    ValueDeliverScript.FlightLockOff001 = 2;
                    ValueDeliverScript.flight001Skin = 0;
                    ValueDeliverScript.flight001Bullet = 1;
                    ValueDeliverScript.flight001Skill = 1;
                    break;
                case 2:
                    ValueDeliverScript.FlightLockOff002 = 2;
                    ValueDeliverScript.flight002Skin = 0;
                    ValueDeliverScript.flight002Bullet = 1;
                    ValueDeliverScript.flight002Skill = 1;
                    break;
            }

            ValueDeliverScript.flightNumber = ValueDeliverScript.flightWindowPosition;   //비행기 락이 풀려있으면 비행기가 현재 선택되어있다고(출격가능) 표시.
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet" + ValueDeliverScript.flightNumber.ToString("00")).gameObject.SetActive(false);
            GameObject.Find("MoveTF").GetComponent<UIPanel>().alpha = 1f;
            GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.

            StartCoroutine(CharacterSoundBuyFlight());

            upgradePoint += 3;
            ValueDeliverScript.upgradePoint = upgradePoint;
            upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 3";
            ShowUpgradePointWindow();
            flightUpointSetScript.RedrawStatePoint();
        }
        else
            GoToCoinShortageWindow();

        ValueDeliverScript.SaveGameData();
    }

    private void FlightLockOffMedal()
    {
        flights.GetComponent<UpgradeAlarmShow>().upParentShow();

        int medalRest = ValueDeliverScript.medalRest;
        int upgradePoint = ValueDeliverScript.upgradePoint;

        int skinMedalVal = 0;
        switch (ValueDeliverScript.flightWindowPosition)
        {
            case 1: skinMedalVal = ValueDeliverScript.FlightLockOff001Medal; break;
            case 2: skinMedalVal = ValueDeliverScript.FlightLockOff002Medal; break;
        }

        if (medalRest >= skinMedalVal)
        {
            medalRest -= skinMedalVal;
            ValueDeliverScript.medalRest = medalRest;

            switch (ValueDeliverScript.flightWindowPosition)
            {
                case 1: ValueDeliverScript.FlightLockOff001 = 2; break;
                case 2: ValueDeliverScript.FlightLockOff002 = 2; break;
            }
            ValueDeliverScript.flightNumber = ValueDeliverScript.flightWindowPosition;   //비행기 락이 풀려있으면 비행기가 현재 선택되어있다고(출격가능) 표시.
            GameObject.Find("FlightLock/FlightLockMove/Dummy").transform.FindChild("FlightLockSet" + ValueDeliverScript.flightNumber.ToString("00")).gameObject.SetActive(false);
            GameObject.Find("MoveTF").GetComponent<UIPanel>().alpha = 1f;
            GameObject.Find("GameManager").GetComponent<GasTimeScript>().MedalRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.
            StartCoroutine(CharacterSoundBuyFlight());

            upgradePoint += 3;
            ValueDeliverScript.upgradePoint = upgradePoint;

            upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 3";
            ShowUpgradePointWindow();

            flightUpointSetScript.RedrawStatePoint();
        }
        else
        {
            GoToMedalShortageWindow();
        }
        ValueDeliverScript.SaveGameData();
    }

    private IEnumerator CharacterSoundBuyFlight()
    {
        int activeOper = ValueDeliverScript.activeOper;
        yield return new WaitForSeconds(0.3f);
        CharacterMsgSndConScript characterMsgSndCon;
        characterMsgSndCon = GameObject.Find("CharacterMsgSndCon").GetComponent<CharacterMsgSndConScript>();
        characterMsgSndCon.BuyFlight(activeOper);
    }

    private void ResultSpecialAttackOnAnimation()
    {
        if (!ValueDeliverScript.isSpecialAnimation)
            StartCoroutine(SpecialAnimation());
        else
        {
            Debug.Log("Income2?????????");
            GameObject.Find("SpecialInfo/SpecialAttackOn").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("SpecialAttackOnText").transform.localScale = new Vector3(46, 46, 1);   //스페셜 어택 발동 문자 스케일 키워서 표시.
            GameObject.Find("GameSpecialStart").transform.localPosition = new Vector3(389, -281, 0);
            GameObject.Find("ResultLowTab/AttackBtn/GameStart").GetComponent<UISprite>().enabled = false;

            GameObject.Find("PrepareBtn/GameStart").GetComponent<UISprite>().spriteName = "Btn_SpecialGameReady_00";
            GameObject.Find("PrepareBtn/GameStart").GetComponent<UIImageButton>().normalSprite = "Btn_SpecialGameReady_00";
            GameObject.Find("PrepareBtn/GameStart").GetComponent<UIImageButton>().hoverSprite = "Btn_SpecialGameReady_00";
            GameObject.Find("PrepareBtn/GameStart").GetComponent<UIImageButton>().pressedSprite = "Btn_SpecialGameReady_01";

            GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UISprite>().spriteName = "Btn_SpecialGame_00";
            GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().normalSprite = "Btn_SpecialGame_00";
            GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().hoverSprite = "Btn_SpecialGame_00";
            GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().pressedSprite = "Btn_SpecialGame_01";
        }
    }

    private IEnumerator SpecialAnimation()
    {
        while (!isRLowTabAnim) yield return new WaitForSeconds(0.1f);

        GameObject.Find("PrepareBtn/GameStart").GetComponent<UISprite>().spriteName = "Btn_SpecialGameReady_00";
        GameObject.Find("PrepareBtn/GameStart").GetComponent<UIImageButton>().normalSprite = "Btn_SpecialGameReady_00";
        GameObject.Find("PrepareBtn/GameStart").GetComponent<UIImageButton>().hoverSprite = "Btn_SpecialGameReady_00";
        GameObject.Find("PrepareBtn/GameStart").GetComponent<UIImageButton>().pressedSprite = "Btn_SpecialGameReady_01";

        GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UISprite>().spriteName = "Btn_SpecialGame_00";
        GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().normalSprite = "Btn_SpecialGame_00";
        GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().hoverSprite = "Btn_SpecialGame_00";
        GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().pressedSprite = "Btn_SpecialGame_01";

        yield return new WaitForSeconds(1f);

        GameObject pilotLevelUpWindow = GameObject.Find("Windows/PilotLevelUpWindow");
        GameObject upgradePointWindow = GameObject.Find("Windows/UpgradePointWindow");

        //while (true)
        //{
        //    if (pilotLevelUpWindow.activeSelf == false && upgradePointWindow.activeSelf == false) break;

        //    yield return new WaitForSeconds(0.1f);
        //}

        GameObject.Find("ResultLowTab").animation.Play("SpecialAnim01");
        ValueDeliverScript.isSpecialAnimation = true;
        yield return new WaitForSeconds(1f);

        GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UISprite>().spriteName = "Btn_SpecialGame_00";
        GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().normalSprite = "Btn_SpecialGame_00";
        GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().hoverSprite = "Btn_SpecialGame_00";
        GameObject.Find("AttackReady/AttackBtn/GameStart").GetComponent<UIImageButton>().pressedSprite = "Btn_SpecialGame_01";
        GameObject.Find("ResultLowTab/AttackBtn/GameStart").GetComponent<UISprite>().enabled = false;
    }

    public void ShowFuelSendWindow(string userId, string nickName, GameObject fromFriendTab)
    {
        friendTab = fromFriendTab;
        fuelSendWindow = GameObject.Find("Windows").transform.FindChild("FuelSendWindow").gameObject;
        fuelSendWindow.SetActive(true);
        fuelSendWindow.transform.FindChild(nickName + "님께 카카오톡으로 연료를 발송하시겠습니까?");
        friendUserId = userId;
        halfBLKPanel.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, fuelSendWindow.transform.localPosition.z + 5);
    }

    private void FuelSendWindowYes()
    {
        friendTab.transform.FindChild("GasStatusOn").GetComponent<UISprite>().spriteName = "Btn_FriendSend_02";
        friendTab.transform.FindChild("GasStatusOn").GetComponent<UIImageButton>().normalSprite = "Btn_FriendSend_02";
        friendTab.transform.FindChild("GasStatusOn").GetComponent<UIImageButton>().hoverSprite = "Btn_FriendSend_02";
        friendTab.transform.FindChild("GasStatusOn").GetComponent<UIImageButton>().pressedSprite = "Btn_FriendSend_02";
        friendUserId = "";
        halfBLKPanel.SetActive(false);
        fuelSendWindow.SetActive(false);
    }

    private void FuelSendWindowCancel()
    {
        friendTab.transform.FindChild("GasStatusOn").GetComponent<UISprite>().spriteName = "Btn_FriendSend_00";
        friendTab.transform.FindChild("GasStatusOn").GetComponent<UIImageButton>().normalSprite = "Btn_FriendSend_00";
        friendTab.transform.FindChild("GasStatusOn").GetComponent<UIImageButton>().hoverSprite = "Btn_FriendSend_00";
        friendTab.transform.FindChild("GasStatusOn").GetComponent<UIImageButton>().pressedSprite = "Btn_FriendSend_01";
        halfBLKPanel.SetActive(false);
        fuelSendWindow.SetActive(false);
    }

    public void ShowFriendInfoWindow(RankDataS friendInfo)
    {
        friendInfoM = friendInfo;
        GetComponent<HangarPopupController>().AddPopWin(friendInfoWindow, 0, ShowFriendInfoWindow01);
    }

    RankDataS friendInfoM;
    public void ShowFriendInfoWindow01()
    {
        string icon01Name = "Fokker";
        string icon02Name = "icon_operator_1";
        string icon03Name = "";
        string icon04Name = "";
        string icon05Name = "";

        switch (friendInfoM.Flight)
        {
            case "0":
                icon01Name = "Fokker";
                break;

            case "1":
                icon01Name = "Comanche";
                break;

            case "2":
                icon01Name = "Phantom";
                break;
        }

        switch (friendInfoM.Supporter)
        {
            case "1":
                icon02Name = "icon_operator_1";
                break;

            case "2":
                icon02Name = "icon_operator_4";
                break;

            case "3":
                icon02Name = "icon_operator_2";
                break;

            case "4":
                icon02Name = "icon_operator_3";
                break;
        }

        switch (friendInfoM.Bomb)
        {
            case "1":
                icon03Name = "icon_equip_bomb_sma_2";
                break;

            case "5":
                icon03Name = "icon_equip_bomb_sma_6";
                break;
        }

        switch (friendInfoM.Rein)
        {
            case "1":
                icon04Name = "icon_equip_force_small_1";
                break;

            case "2":
                icon04Name = "icon_equip_force_small_2";
                break;

            case "3":
                icon04Name = "icon_equip_force_small_3";
                break;

            case "4":
                icon04Name = "icon_equip_force_small_4";
                break;

            case "5":
                icon04Name = "icon_equip_force_small_5";
                break;

            case "6":
                icon04Name = "icon_equip_force_small_6";
                break;

            case "7":
                icon04Name = "icon_equip_force_small_7";
                break;

            case "8":
                icon04Name = "icon_equip_boost_small_1";
                break;
        }

        switch (friendInfoM.Assist)
        {
            case "1":
                icon05Name = "icon_equip_sub_small_1";
                break;

            case "2":
                icon05Name = "icon_equip_sub_small_2";
                break;

            case "3":
                icon05Name = "icon_equip_sub_small_3";
                break;

            case "4":
                icon05Name = "icon_equip_sub_small_4";
                break;

            case "5":
                icon05Name = "icon_equip_boost_small_7";
                break;

            case "6":
                icon05Name = "icon_equip_boost_small_6";
                break;
        }

        //friendInfoWindow.SetActive(true);
        if (icon02Name == "")
            friendInfoWindow.transform.FindChild("Items/Item002/Icon2").gameObject.SetActive(false);
        else
            friendInfoWindow.transform.FindChild("Items/Item002/Icon2").gameObject.SetActive(true);

        if (icon03Name == "")
            friendInfoWindow.transform.FindChild("Items/Item003/Icon3").gameObject.SetActive(false);
        else
            friendInfoWindow.transform.FindChild("Items/Item003/Icon3").gameObject.SetActive(true);

        if (icon04Name == "")
            friendInfoWindow.transform.FindChild("Items/Item003/Icon4").gameObject.SetActive(false);
        else
            friendInfoWindow.transform.FindChild("Items/Item003/Icon4").gameObject.SetActive(true);

        if (icon05Name == "")
            friendInfoWindow.transform.FindChild("Items/Item003/Icon5").gameObject.SetActive(false);
        else
            friendInfoWindow.transform.FindChild("Items/Item003/Icon5").gameObject.SetActive(true);

        friendInfoWindow.transform.FindChild("UserName").GetComponent<UILabel>().text = friendInfoM.NickName;
        Debug.Log("친구이름 :: " + friendInfoM.NickName);
        Debug.Log("스킨번호 :: " + friendInfoM.Skin);

        int skinNum = 0;
        int.TryParse(friendInfoM.Skin, out skinNum);
        if (skinNum == null) skinNum = 1; else skinNum += 1;

        friendInfoWindow.transform.FindChild("Items/Item001/Icon1").GetComponent<UISprite>().spriteName = icon01Name + skinNum.ToString("000") + "Fix";
        friendInfoWindow.transform.FindChild("Items/Item001/Icon1").GetComponent<UISprite>().MakePixelPerfect();
        friendInfoWindow.transform.FindChild("Items/Item002/Icon2").GetComponent<UISprite>().spriteName = icon02Name;
        friendInfoWindow.transform.FindChild("Items/Item003/Icon3").GetComponent<UISprite>().spriteName = icon03Name;
        friendInfoWindow.transform.FindChild("Items/Item003/Icon4").GetComponent<UISprite>().spriteName = icon04Name;
        friendInfoWindow.transform.FindChild("Items/Item003/Icon5").GetComponent<UISprite>().spriteName = icon05Name;
        friendInfoWindow.transform.FindChild("Script02").GetComponent<UILabel>().text = friendInfoM.TWeekScore;

        //halfBLKPanel.SetActive(true);
        //halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, friendInfoWindow.transform.localPosition.z + 5);
    }

    private void CloseFriendInfoWindow()
    {
        GetComponent<HangarPopupController>().CloseWindow();
    }

    public void ShotFriendshipPoint()
    {
        Debug.Log("PrepareReadyAnim03_2");
        prepareReady.animation.Play("PrepareReadyAnim03_2");

        Transform point100 = prepareReady.transform.FindChild("OperMessage/FriendshipPoint/Point100Amount");
        point100.localScale = new Vector3(0, point100.localScale.y, point100.localScale.z);
        Transform pointIcn01 = prepareReady.transform.FindChild("OperMessage/FriendshipPoint/PointIcn01");
        pointIcn01.localScale = new Vector3(0, pointIcn01.localScale.y, pointIcn01.localScale.z);
    }

    public void ShowUpgradePointWindow()
    {
        GetComponent<HangarPopupController>().AddPopWin(upgradePointWindow, 0);
    }

    private IEnumerator NoClickUpgradePointWindow()
    {
        upgradePointWindow.transform.FindChild("YesBtn").GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(2f);
        upgradePointWindow.transform.FindChild("YesBtn").GetComponent<BoxCollider>().enabled = true;
    }

    public void CloseUpgradePointWindow()
    {
        GetComponent<HangarPopupController>().AddPopWin(uiInfo02Window, -1, null,true,null);
    }

    public void UnregiLoadLevel()
    {
        StartCoroutine(UnregiLoadLevel2());
    }

    private IEnumerator UnregiLoadLevel2()
    {
        yield return new WaitForSeconds(1f);
        Application.LoadLevel("Loading");
    }

    public void GotoFriendLockWindow()
    {
        GameObject FriendLockWindow = GameObject.Find("Window/FriendLockWindow");
        FriendLockWindow.SetActive(true);
        halfBLKPanel.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, FriendLockWindow.transform.localPosition.z + 5);
    }

    public void CloseFriendLockWindow()
    {
        GameObject FriendLockWindow = GameObject.Find("Window/FriendLockWindow");
        FriendLockWindow.SetActive(false);
        halfBLKPanel.SetActive(false);
    }

    public void GotoMessageOnFailWindow()
    {
        GameObject Window = GameObject.Find("Windows").transform.FindChild("MessageOnFailWindow").gameObject;
        Window.SetActive(true);
        halfBLKPanel.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, Window.transform.localPosition.z + 5);
    }

    public void MessageOnFailWindowYes()
    {
        GameObject Window = GameObject.Find("Windows").transform.FindChild("MessageOnFailWindow").gameObject;
        Window.SetActive(false);
        halfBLKPanel.SetActive(false);
    }

    public void GotoFuelFailWindow()
    {
        GameObject Window = GameObject.Find("Windows").transform.FindChild("FuelFailWindow").gameObject;
        Window.SetActive(true);
        halfBLKPanel.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, Window.transform.localPosition.z + 5);
    }

    public void FuelFailWindowYes()
    {
        GameObject Window = GameObject.Find("Windows").transform.FindChild("FuelFailWindow").gameObject;
        Window.SetActive(false);
        halfBLKPanel.SetActive(false);
    }

    public void ShowUiInfo01()
    {
        GetComponent<HangarPopupController>().AddPopWin(uiInfo01Window,0);
    }

    public void ShowUiInfo02()
    {
        GetComponent<HangarPopupController>().AddPopWin(uiInfo02Window, 0);
    }

    public void ShowUiInfo03()
    {
        GetComponent<HangarPopupController>().AddPopWin(uiInfo03Window, 0);
    }


    public void CloseUiInfo01()
    {
        GetComponent<HangarPopupController>().CloseWindow();
    }

    public void CloseUiInfo02()
    {
        GetComponent<HangarPopupController>().CloseWindow();
    }

    public void CloseUiInfo03()
    {
        GetComponent<HangarPopupController>().CloseWindow();
    }

    IEnumerator HalfBLKPanelShow()
    {
        yield return null;
        GameObject.Find("Windows").transform.FindChild("HalfBLKPanel").gameObject.SetActive(true);
    }

    void SkinFullLevelUpCheck()
    {
        if (ValueDeliverScript.skinNumber != 0)
        {
            int nowPoint = 0;
            switch (ValueDeliverScript.flightNumber)
            {
                case 0: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: nowPoint = ValueDeliverScript.FlightExp000Skin001; break;
                        case 2: nowPoint = ValueDeliverScript.FlightExp000Skin002; break;
                        case 3: nowPoint = ValueDeliverScript.FlightExp000Skin003; break;
                        case 4: nowPoint = ValueDeliverScript.FlightExp000Skin004; break;
                        case 5: nowPoint = ValueDeliverScript.FlightExp000Skin005; break;
                    } break;
                case 1: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: nowPoint = ValueDeliverScript.FlightExp001Skin001; break;
                        case 2: nowPoint = ValueDeliverScript.FlightExp001Skin002; break;
                        case 3: nowPoint = ValueDeliverScript.FlightExp001Skin003; break;
                        case 4: nowPoint = ValueDeliverScript.FlightExp001Skin004; break;
                        case 5: nowPoint = ValueDeliverScript.FlightExp001Skin005; break;
                    } break;
                case 2: switch (ValueDeliverScript.skinNumber)
                    {
                        case 1: nowPoint = ValueDeliverScript.FlightExp002Skin001; break;
                        case 2: nowPoint = ValueDeliverScript.FlightExp002Skin002; break;
                        case 3: nowPoint = ValueDeliverScript.FlightExp002Skin003; break;
                        case 4: nowPoint = ValueDeliverScript.FlightExp002Skin004; break;
                        case 5: nowPoint = ValueDeliverScript.FlightExp002Skin005; break;
                    } break;
            }
            int oldPoint = nowPoint - ValueDeliverScript.skinExp;

            string skinName = "Flight" + ValueDeliverScript.flightNumber.ToString("D3") + "Skin" + ValueDeliverScript.skinNumber.ToString("D3");

            if (nowPoint >= int.Parse(skinFullLevel[skinName].ToString()) && oldPoint < int.Parse(skinFullLevel[skinName].ToString()))
            {
                isSkinFullLevel = true;
            }
        }
    }

    IEnumerator RescueFriendLoad()  //임시로 친구 구출 인원 표시되도록 만드는것 후에 이와 연결된 함수를 구성해서 연결시켜야함.
    {
        Debug.Log("rescueFriendId :: " + ValueDeliverScript.rescueFriendId);
        rescueFriend = ValueDeliverScript.rescueFriendId.Split(',');

        if (rescueFriend[0] == "")
            GameObject.Find("RescueTopMessageText").GetComponent<UILabel>().text = "You have rescued no friend!!";
        else if (rescueFriend.Length > 0)
        {
            GameObject.Find("RescueTopMessageText").GetComponent<UILabel>().text = "You rescued " + rescueFriend.Length + " friends! (Buddy Points +" + rescueFriend.Length + ")";
            ValueDeliverScript.buddyPoint = ValueDeliverScript.buddyPoint + rescueFriend.Length;
            GameObject.Find("PrepareReady").GetComponent<PrepareReadyScript>().GageSetting();//인터페이스상에서 추가된 점수가 보이게 만든다.
        }

        ValueDeliverScript.rescueFriendId = ""; //구출한 친구목록 초기화. 이걸 하지 않으면 다음번 구출 친구 목록이 이전것과 겹쳐 꼬인다.

        //친구 사진을 대신하는 아이콘(이미지)를 켜줌.
        Transform rescueInfo = GameObject.Find("RescueInfo").transform;
        int count = rescueInfo.childCount;


        int rescueCount = rescueFriend.Length;

        if (rescueCount > count) rescueCount = count;

        if (rescueFriend[0] != "")
        {
            for (int i = 0; i < rescueCount; i++)
            {
                Debug.Log("친구 구함 ::: " + "FriendImg00" + (i + 1) + "Base ::: " + rescueFriend[i]);
                picObj = rescueInfo.FindChild("FriendImg00" + (i + 1) + "Base").gameObject;
                picObj.SetActive(true);
                picObj.GetComponent<UITexture>().mainTexture = FindFriPhoto(rescueFriend[i]);
            }
        }
        //친구 사진을 대신하는 아이콘(이미지)를 켜줌.
        yield break;
    }

    Texture FindFriPhoto(string fId)
    {
        Debug.Log(":: FindFriPhoto ::");
        int rLength = 0;
        if (ValueDeliverScript.rankDataFB.Length == null) rLength = 0;
        else rLength = ValueDeliverScript.rankDataFB.Length;
        fLength = rLength;
        for (int i = 0; i < fLength; i++)
        {
            if (ValueDeliverScript.rankDataFB[i].FbId == fId)
            {
                //여기 와서 텍스쳐 가져감//
                Debug.Log("여기 와서 텍스쳐 가져감: 패북아이디 :: " + ValueDeliverScript.rankDataFB[i].FbId + "::" + fId);
                fTex = ValueDeliverScript.rankDataFB[i].FbPic;
                Debug.Log("ValueDeliverScript.rankDataFB[i].FbPic.texelSize :: " + ValueDeliverScript.rankDataFB[i].FbPic.texelSize);
                Debug.Log("fTex.texelSize :: " + fTex.texelSize);
                break;
            }
        }
        return fTex;
    }

    IEnumerator TouchFalse()
    {
        yield return new WaitForSeconds(10f);
    }

    IEnumerator FirstSoundPlay()
    {
        int activeOper = ValueDeliverScript.activeOper;

        yield return new WaitForSeconds(1.5f);
        if (gameEndResult)
        {
            characterMsgSndCon.LoadingGame(activeOper);
        }
        else if (ValueDeliverScript.isBreakGame)
        {
            characterMsgSndCon.BreakGame(activeOper);
            ValueDeliverScript.isBreakGame = false;
        }
        else
        {
            characterMsgSndCon.LoadingBirth(activeOper);
        }
    }

    public void MessageTabSetting()
    {
        MessageDataS[] messageData = ValueDeliverScript.messageData;

        if (messageData.Length == 0) { friendMailTab.SetActive(false); return; }


        for (int i = 0; i < messageData.Length; i++)
        {
            //인스턴스로 메세지를 하나 생성//
            GameObject messageTab = Instantiate(friendMessage) as GameObject;
            //이름을 변경함//
            messageTab.GetComponent<MessageTabScript>().messageTab = messageData[i];

            //만약 메세지가 시간을 기록하고 있지 않으면 강제로 시간을 기록하여 넣어준다//
            string msgTime = messageTab.GetComponent<MessageTabScript>().messageTab.Time;
            if (msgTime == "" || msgTime == null)
            {
                ValueDeliverScript.messageData[i].Time = messageTab.GetComponent<MessageTabScript>().messageTab.Time = DateTime.UtcNow.ToBinary().ToString();
            }

            messageTab.name = "friendMessage" + i;
            //위치값을 임시로 지정//메소드 진행중 변경//
            Vector3 pos = messageTab.transform.localPosition;

            //메세지 탭을 메세지 그리드에 차일드로 종속시킴//
            messageTab.transform.parent = friendMailTab.transform;
            //화면에 보이도록  액티브를 켬//
            messageTab.SetActive(true);
            //크기를 재지정함//
            messageTab.transform.localScale = new Vector3(1, 1, 1);
            //위치를 재지정함//
            messageTab.transform.localPosition = new Vector3(pos.x, pos.y, 0);

            //메세지를 보낸 친구 이름과 사진 찾기//
            //0.받아올 이름과 사진의 그릇이 될 임시 변수를 선언한다//
            string nick = "";
            Texture fbPic = null;
            //1.친구 랭크 데이터를 가지고 온다//
            RankDataS[] friendRankFB = ValueDeliverScript.rankDataFB;
            //현재 메세지를 보낸 친구 페북 아이디를 추출한다//
            string buddyFbId = messageData[i].From;
            //for문을 돌려 같은 이름의 친구가 있는지 확인한다//
            //확인하여 닉네임과 사진을 추추한다//
            for (int j = 0; j < friendRankFB.Length; j++)
            {
                if (buddyFbId == friendRankFB[j].FbId)
                {
                    nick = friendRankFB[j].NickName;
                    fbPic = friendRankFB[j].FbPic;
                    break;
                }
            }
            //각각의 오브젝트들(아이템이미지,니네임등)을 보여준다//
            //선물을 입력한다//
            //보내온 메세지 내용이 무엇인지 파악한다//
            string giftName = "icon_fuel";
            switch (messageData[i].Type)
            {
                case "1":
                    giftName = "icon_fuel"; break;
                case "2":
                    giftName = "icon_gold"; break;
                case "3":
                    giftName = "icon_deco"; break;
                case "4":
                    giftName = "Icn_AP"; break;
            }
            messageTab.transform.Find("FuelIcon").GetComponent<UISprite>().spriteName = giftName;
            messageTab.transform.Find("FuelIcon").GetComponent<UISprite>().MakePixelPerfect();

            //닉네임을 입력한다//
            messageTab.transform.Find("UserName").GetComponent<UILabel>().text = nick;

            //친구 사진을 입력한다//
            if (fbPic != null)
            {
                messageTab.transform.Find("UserPhoto").gameObject.SetActive(true);
                messageTab.transform.Find("UserPhoto").GetComponent<UITexture>().mainTexture = fbPic;
            }

            //친구에게 보내는 메세지를 표시한다//
            //메세지 내용이 무엇인지 파악한다//
            string msg;
            switch (messageData[i].Contents)
            {
                case "1": msg = "Got Fuels!"; break;

                case "2": msg = "Got golds!"; break;

                case "3": msg = "Got Diamonds!"; break;

                case "4": msg = "Got Ab Points"; break;

                default: msg = messageData[i].Contents; break;
            }
            messageTab.transform.Find("Message").GetComponent<UILabel>().text = msg;
            //Debug.LogError("잠심 멈추고 메세지 생성 되었는가 확인");
        }
    }

    int logEventDay;
    void LoginEvent()
    {
        //Debug.Log("LoginEvent");
        //ShowLoginEventWin(6); //테스트용 코드.

        if (!PlayerPrefs.HasKey("LoginDate"))
        {

            string[] loginDate = DateTime.Now.GetDateTimeFormats();
            PlayerPrefs.SetString("LoginDate", loginDate[0]);
            PlayerPrefs.SetInt("AddDate", 1);
            //첫 로그인이니 무조건 첫날 보상창을 띄움.
            logEventDay = 1;
            ShowLoginEventWin();
        }
        else
        {
            string oldDate = PlayerPrefs.GetString("LoginDate");
            string today = DateTime.Now.GetDateTimeFormats()[0];
            DateTime oDate = DateTime.Parse(oldDate);
            DateTime tDay = DateTime.Parse(today);
            int intervalDay = (tDay - oDate).Days;

            PlayerPrefs.SetString("LoginDate", today);

            if (intervalDay == 1)
            {
                //값이 1이라는 것은 어제 접속하고 오늘 접속했다는 것 그러니 더해지는 날을.
                //추가 1을 해준다음.. 더해진 날의 보상을 보여주는 창을 띄운다.
                int addDate = PlayerPrefs.GetInt("AddDate");
                addDate++;
                PlayerPrefs.SetInt("AddDate", addDate);

                //여기서 창을 띄움.
                //10이 넘어가면 보상창의 모든 내용을 다 받은것이기에 다시 1일부터 시작한다.
                if (addDate > 10)
                {
                    PlayerPrefs.SetInt("AddDate", 1);
                    //1일차 보상을 띄움.
                    logEventDay = 1;
                    ShowLoginEventWin();
                }
                else
                {
                    //날짜에 맞는 보상창을 띄움.
                    logEventDay = addDate;
                    ShowLoginEventWin();
                }
            }

            //하루 이상 거르게 되면 연속 로그인이 초기화 되서 다시 1일부터 시작한다.
            if (intervalDay > 1)
            {
                PlayerPrefs.SetInt("AddDate", 1);
                //1일차 보상을 띄움
                logEventDay = 1;
                ShowLoginEventWin();
            }
        }
    }

    void ShowLoginEventWin()
    {
        GetComponent<HangarPopupController>().AddPopWin(loginEventWin, -1, ShowLoginEventWin01);
        //로그인 이벤트 윈도우가 뜨지 않으면 랭크 리워드 여부 알림 창이 뜰수가 없으니 여기서 처리하게 하면//
        //계산 횟수가 줄고 복잡함이 줄어듬//
        FbWdReward();
    }

    void FbWdReward()
    {
        HangarPopupController hpController = GameObject.Find("GameManager").GetComponent<HangarPopupController>();
        if(ValueDeliverScript.isNewFbRank == true)
        {
            if (ValueDeliverScript.myFbRank <= ValueDeliverScript.fbRewardGrade)
                hpController.AddPopWin(rewardFBOn, 0, RewardFBIcon);
            else
                hpController.AddPopWin(rewardFBOff, 0);
        }

        if (ValueDeliverScript.isNewWdRank == true)
        {
            if (ValueDeliverScript.myWdRank <= ValueDeliverScript.wdRewardGrade)
                hpController.AddPopWin(rewardWDOn, 0, rewardWDIcon);
            else
                hpController.AddPopWin(rewardWDOff, 0);
        }
    }

    void RewardFBIcon()
    {
        string type = ValueDeliverScript.fbReward.Type;
        string giftName = "";
        switch (type)
        {
            case "1":
                giftName = "icon_fuel_2"; break;
            case "2":
                giftName = "icon_gold_5"; break;
            case "3":
                giftName = "icon_deco_5"; break;
            case "4":
                giftName = "Icn_Apoint"; break;
        }
        string oNum="";
        switch(ValueDeliverScript.myFbRank) 
        {
            case 1: oNum = "1st Place!"; break;
            case 2: oNum = "2nd Place!"; break;
            case 3: oNum = "3rd Place!"; break;
        }
        rewardFBOn.transform.FindChild("MainText").GetComponent<UILabel>().text = "Won FB " + oNum;
        rewardFBOn.transform.FindChild("Items/Item001/Icon").GetComponent<UISprite>().spriteName = giftName;
        rewardFBOn.transform.FindChild("Items/Item001/Icon").GetComponent<UISprite>().MakePixelPerfect();
        rewardFBOn.transform.FindChild("Items/Item001/Label").GetComponent<UILabel>().text = ValueDeliverScript.fbReward.Ea;
    }


    //리워드 알림창에 받게 된 리워드와 같은 아이템 이미지와 갯수가 보이게 한다//
    void rewardWDIcon()
    {
        string giftName = "";
        switch (ValueDeliverScript.wdReward.Length)
        {
            case 1:
                rewardWDOn.transform.FindChild("Items").localPosition = new Vector3(0, 0, 0);
                rewardWDOn.transform.FindChild("Items/Item002").gameObject.SetActive(false);
                rewardWDOn.transform.FindChild("Items/Item003").gameObject.SetActive(false);
                break;
            case 2:
                rewardWDOn.transform.FindChild("Items").localPosition = new Vector3(-95, 0, 0);
                rewardWDOn.transform.FindChild("Items/Item003").gameObject.SetActive(false);
                break;
            case 3:
                rewardWDOn.transform.FindChild("Items").localPosition = new Vector3(-190, 0, 0); 
                break;
        }

        for (int i =0; i <  ValueDeliverScript.wdReward.Length ;i++)
        {
            switch (ValueDeliverScript.wdReward[i].Type)
            {
                case "1":
                    giftName = "icon_fuel_2"; break;
                case "2":
                    giftName = "icon_gold_5"; break;
                case "3":
                    giftName = "icon_deco_5"; break;
                case "4":
                    giftName = "Icn_Apoint"; break;
            }

            rewardWDOn.transform.FindChild("Items/Item00" + (i + 1) + "/Icon").GetComponent<UISprite>().spriteName = giftName;
            rewardWDOn.transform.FindChild("Items/Item00" + (i + 1) + "/Icon").GetComponent<UISprite>().MakePixelPerfect();
            rewardWDOn.transform.FindChild("Items/Item00" + (i + 1) + "/Label").GetComponent<UILabel>().text = ValueDeliverScript.fbReward.Ea;
        }

        int oNumI = ValueDeliverScript.myWdRank % 10;
        string oNumS = "";
        switch (oNumI)
        {
            case 1: oNumS = "st Place!"; break;
            case 2: oNumS = "nd Place!"; break;
            case 3: oNumS = "rd Place!"; break;
            default: oNumS = "th Place!"; break;
        }
        rewardWDOn.transform.FindChild("MainText").GetComponent<UILabel>().text = "Won WD " + ValueDeliverScript.myWdRank + oNumS;
    }



    void ShowLoginEventWin01()
    {
        GameObject[] rewardTab = new GameObject[10];
        GameObject hilight = loginEventWin.transform.FindChild("Rewards/Hilight").gameObject;

        for (int i = 0; i < 10; i++)
        {
            rewardTab[i] = loginEventWin.transform.FindChild("Rewards/Reward" + (i + 1).ToString("00")).gameObject;
        }

        for (int i = 0; i < logEventDay; i++)
        {
            if (i > 0) rewardTab[i - 1].GetComponent<UIPanel>().alpha = 0.35f;
            rewardTab[i].transform.FindChild("Check").GetComponent<UISprite>().spriteName = "Btn_CheckBox01";
        }

        float hPositionX = -280;
        float hPositionY = 72;

        int xAdd = 140;
        int yAdd = -165;

        int multiValX = (logEventDay - 1) % 5;
        int multiValY = (logEventDay - 1) / 5;

        hPositionX = hPositionX + (xAdd * multiValX);
        hPositionY = hPositionY + (yAdd * multiValY);

        hilight.transform.localPosition = new Vector3(hPositionX, hPositionY, 0);

        ReceiveLoginReward(logEventDay);
    }



    void CloseLoginEventWin()
    {
        GetComponent<HangarPopupController>().CloseWindow();
        //loginEventWin.SetActive(false);
    }

    void ReceiveLoginReward(int date)
    {
        switch (date)
        {
            case 1: ValueDeliverScript.EquipBomb01 = ValueDeliverScript.EquipBomb01 + 3; break;
            case 2: ValueDeliverScript.EquipReinforce08 = ValueDeliverScript.EquipReinforce08 + 3; break;
            case 3: ValueDeliverScript.coinRest = ValueDeliverScript.coinRest + 2000; break;
            case 4: ValueDeliverScript.EquipAssist01 = ValueDeliverScript.EquipAssist01 + 2; break;
            case 5: ValueDeliverScript.medalRest = ValueDeliverScript.medalRest + 5; break;
            case 6: ValueDeliverScript.EquipBomb05 = ValueDeliverScript.EquipBomb05 + 5; break;
            case 7: ValueDeliverScript.coinRest = ValueDeliverScript.coinRest + 5000; break;
            case 8: ValueDeliverScript.EquipReinforce07 = ValueDeliverScript.EquipReinforce07 + 5; break;
            case 9: ValueDeliverScript.coinRest = ValueDeliverScript.coinRest + 12000; break;
            case 10: ValueDeliverScript.medalRest = ValueDeliverScript.medalRest + 20; break;
        }

        //로그인 리워드일 때는 서버에 한번 저장을 한다//
        ValueDeliverScript.SaveGameData();

        GetComponent<GasTimeScript>().MedalRecount(); //화면에 표시되는 메달양을 다시 계산하여 재표시하여줌.
        GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.
        LoadEquip(); //이큅창들에 들어가는 아이템 표시를 다시 계산하고.
        EquipStartSetting(); //1173번줄에 있는 이큅스타트세팅 함수를 호출.
    }

    //게임친구탭에 보상 아이템을 보여줄때 정리해주는 메소드//
    void RankTabRewardItemShow(bool[] isShow, string[] name, string[] count)
    {
        gFrndScript.item[0].item[0].SetActive(isShow[0]);
        gFrndScript.item[0].item[1].SetActive(isShow[0]);
        gFrndScript.item[0].item[2].SetActive(isShow[0]);
        gFrndScript.item[0].item[0].GetComponent<UISprite>().spriteName = name[0];
        gFrndScript.item[0].item[0].GetComponent<UISprite>().MakePixelPerfect();
        gFrndScript.item[0].item[2].GetComponent<UILabel>().text = count[0];

        gFrndScript.item[1].item[0].SetActive(isShow[1]);
        gFrndScript.item[1].item[1].SetActive(isShow[1]);
        gFrndScript.item[1].item[2].SetActive(isShow[1]);
        gFrndScript.item[1].item[0].GetComponent<UISprite>().spriteName = name[1];
        gFrndScript.item[1].item[0].GetComponent<UISprite>().MakePixelPerfect();
        gFrndScript.item[1].item[2].GetComponent<UILabel>().text = count[1];

        gFrndScript.item[2].item[0].SetActive(isShow[2]);    //아이템//
        gFrndScript.item[2].item[1].SetActive(isShow[2]);    //바탕굴림사각형//
        gFrndScript.item[2].item[2].SetActive(isShow[2]);    //갯수//
        gFrndScript.item[2].item[0].GetComponent<UISprite>().spriteName = name[2];  //아이템이름//
        gFrndScript.item[2].item[0].GetComponent<UISprite>().MakePixelPerfect();     //아이템크기재조정//
        gFrndScript.item[2].item[2].GetComponent<UILabel>().text = count[2];        //받을수 있는 아이템 갯수//
    }
    //게임친구탭에 보상 아이템을 보여줄때 정리해주는 메소드//

    void FriendRankTabSetting(RankDataS[] friendData, Transform parentT, bool isFB = true)
    {
        //친구 데이터가 하나도 없다면 이 메서드로 들어온 리더보드는 보이지 않게 한고 메서드 전체를 실행하지 않고 그냥 리턴한다//
        if (friendData.Length == 0) { parentT.gameObject.SetActive(false); return; }

        Debug.Log(" ::::: FriendRankTabSetting ::::: " + parentT.name);
        BubbleSorting(friendData);    // 우선 친구 점수를 기준으로 한 랭킹 정렬.

        for (int i = 0; i < friendData.Length; i++)
        {
            GameObject friendRankTab = Instantiate(friendRank) as GameObject;
            friendRankTab.name = "friendRank" + i;
            Vector3 pos = friendRankTab.transform.localPosition;

            friendRankTab.transform.parent = parentT;
            friendRankTab.SetActive(true);
            friendRankTab.transform.localScale = new Vector3(1, 1, 1);

            friendRankTab.transform.localPosition = new Vector3(pos.x, pos.y, 0);

            //Debug.Log(i + " NickName ::: " + friendData[i].NickName);
            //Debug.Log(i + " Score ::: " + friendData[i].TWeekScore);
            friendRankTab.transform.FindChild("UserName").GetComponent<UILabel>().text = friendData[i].NickName;
            friendRankTab.transform.FindChild("Score").GetComponent<UILabel>().text = friendData[i].TWeekScore;

            //20140925 추가 //프로필 사진이 있으면 나오게 만듬(페북 아이디가 있다면 사진을 보여줌)//
            if (friendData[i].FbId != "" && friendData[i].FbId != null && friendData[i].FbId != "0")
            {
                //Debug.Log("행거 사진 박음?");
                friendRankTab.transform.FindChild("UserPhoto").GetComponent<UITexture>().mainTexture = friendData[i].FbPic;
            }

            friendRankTab.GetComponent<GameFriendTabScript>().inputFriendInfo(friendData[i]);


            gFrndScript = friendRankTab.GetComponent<GameFriendTabScript>();
            string myNick = ValueDeliverScript.Nick;
            string myScore = ValueDeliverScript.scoreHigh.ToString();
            string fuelSendTime = gFrndScript.friendInfo.FuelSendTime;
            GameObject gasStatusOff = gFrndScript.gasStatusOff;
            GameObject fuelRemainTime = gFrndScript.fuelRemainTime;
            GameObject gasStatusOn = gFrndScript.gasStatusOn;

            //탭에 보상 아이템 보이기//
            if (isFB == true)   //페북 친구 랭킹일 때
            {
                switch (i)
                {
                    case 0: { RankTabRewardItemShow(new bool[] { true, false, false }, new string[] { reinforceS, "", "" }, new string[] { "+1", "", "" }); break; }
                    case 1: { RankTabRewardItemShow(new bool[] { true, false, false }, new string[] { diamondS, "", "" }, new string[] { "+5", "", "" }); break; }
                    case 2: { RankTabRewardItemShow(new bool[] { true, false, false }, new string[] { coinS, "", "" }, new string[] { "+2500", "", "" }); break; }
                    default: { RankTabRewardItemShow(new bool[] { false, false, false }, new string[] { "", "", "" }, new string[] { "", "", "" }); break; }
                }
            }
            else if (isFB == false) //월드 랭킹일 때
            {
                switch (i)
                {
                    case 0: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+5", "+30000", "30" }); break; }
                    case 1: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+4", "+25000", "25" }); break; }
                    case 2: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+3", "+20000", "20" }); break; }
                    case 3: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+2", "+10000", "15" }); break; }
                    case 4: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+2", "+10000", "15" }); break; }
                    case 5: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+2", "+10000", "15" }); break; }
                    case 6: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+2", "+10000", "15" }); break; }
                    case 7: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+2", "+10000", "15" }); break; }
                    case 8: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+2", "+10000", "15" }); break; }
                    case 9: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+2", "+10000", "15" }); break; }

                    case 10: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+1", "+7500", "10" }); break; }
                    case 11: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+1", "+7500", "10" }); break; }
                    case 12: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+1", "+7500", "10" }); break; }
                    case 13: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+1", "+7500", "10" }); break; }
                    case 14: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+1", "+7500", "10" }); break; }
                    case 15: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+1", "+7500", "10" }); break; }
                    case 16: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+1", "+7500", "10" }); break; }
                    case 17: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+1", "+7500", "10" }); break; }
                    case 18: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+1", "+7500", "10" }); break; }
                    case 19: { RankTabRewardItemShow(new bool[] { true, true, true }, new string[] { reinforceS, coinS, diamondS }, new string[] { "+1", "+7500", "10" }); break; }

                    case 20: { RankTabRewardItemShow(new bool[] { false, true, true }, new string[] { "", coinS, diamondS }, new string[] { "", "+5000", "5" }); break; }
                    case 21: { RankTabRewardItemShow(new bool[] { false, true, true }, new string[] { "", coinS, diamondS }, new string[] { "", "+5000", "5" }); break; }
                    case 22: { RankTabRewardItemShow(new bool[] { false, true, true }, new string[] { "", coinS, diamondS }, new string[] { "", "+5000", "5" }); break; }
                    case 23: { RankTabRewardItemShow(new bool[] { false, true, true }, new string[] { "", coinS, diamondS }, new string[] { "", "+5000", "5" }); break; }
                    case 24: { RankTabRewardItemShow(new bool[] { false, true, true }, new string[] { "", coinS, diamondS }, new string[] { "", "+5000", "5" }); break; }
                    case 25: { RankTabRewardItemShow(new bool[] { false, true, true }, new string[] { "", coinS, diamondS }, new string[] { "", "+5000", "5" }); break; }
                    case 26: { RankTabRewardItemShow(new bool[] { false, true, true }, new string[] { "", coinS, diamondS }, new string[] { "", "+5000", "5" }); break; }
                    case 27: { RankTabRewardItemShow(new bool[] { false, true, true }, new string[] { "", coinS, diamondS }, new string[] { "", "+5000", "5" }); break; }
                    case 28: { RankTabRewardItemShow(new bool[] { false, true, true }, new string[] { "", coinS, diamondS }, new string[] { "", "+5000", "5" }); break; }
                    case 29: { RankTabRewardItemShow(new bool[] { false, true, true }, new string[] { "", coinS, diamondS }, new string[] { "", "+5000", "5" }); break; }

                    //30위 아래는 아무런 리워드를 주지 않는다//
                    default: { RankTabRewardItemShow(new bool[] { false, false, false }, new string[] { "", "", "" }, new string[] { "", "", "" }); break; }
                }
            }

            if (i > 2)
            {
                friendRankTab.transform.FindChild("RankNumText").GetComponent<UILabel>().text = (i + 1).ToString();
                friendRankTab.transform.FindChild("TopRank").gameObject.SetActive(false);
            }
            else
            {
                friendRankTab.transform.FindChild("RankNumText").gameObject.SetActive(false);
                friendRankTab.transform.FindChild("TopRank").gameObject.SetActive(true);
                friendRankTab.transform.FindChild("TopRank").GetComponent<UISprite>().spriteName = "Icn_Rank" + (i + 1);
            }


            //Debug.Log("fuelSendTime ::: " + friendData[i].NickName + " ::: " + fuelSendTime);
            if (myNick == friendData[i].NickName && myScore == friendData[i].TWeekScore)
            {
                friendRankTab.transform.FindChild("FriendRankBG").GetComponent<UISprite>().spriteName = "Bgr_Ranker_00";
                gasStatusOff.SetActive(false);
                fuelRemainTime.SetActive(false);
                gasStatusOn.SetActive(false);
            }

            else if (isFB == false)
            {
                gasStatusOff.SetActive(false);
                fuelRemainTime.SetActive(false);
                gasStatusOn.SetActive(false);
            }
            //여기서 연료 보냄 여부를 감지하여 아이콘을 어떤것을 보일것인지 결정한다//
            else if (fuelSendTime == "" || fuelSendTime == null)
            {
                gasStatusOff.SetActive(false);
                fuelRemainTime.SetActive(false);
                gasStatusOn.SetActive(true);
            }
            else
            {

                System.DateTime nowTime = System.DateTime.UtcNow;
                System.DateTime fuelTime = DateTime.FromBinary(Convert.ToInt64(double.Parse(fuelSendTime)));

                Debug.Log(":: nowTime :: " + nowTime);
                Debug.Log(":: fuelTime :: " + fuelTime);

                fuelTime.AddMinutes(90);//다음 연료가 찰 시간//
                Debug.Log(":: fuelTime + 90min :: " + fuelTime.AddMinutes(90));

                if (nowTime < fuelTime.AddMinutes(90)) //이 조건은 아직 시간에 도달하지 못함을 뜻함//
                {
                    gasStatusOff.SetActive(true);
                    fuelRemainTime.SetActive(true);
                    fuelRemainTime.GetComponent<UILabel>().text = (int)(fuelTime.AddMinutes(90).Subtract(nowTime).TotalMinutes) + "m";
                    gasStatusOn.SetActive(false);
                }
                else
                {
                    gasStatusOff.SetActive(false);
                    fuelRemainTime.SetActive(false);
                    gasStatusOn.SetActive(true);
                }
            }
        }
    }

    void BubbleSorting(RankDataS[] friendData)
    {
        string myNick = ValueDeliverScript.Nick;
        int rLength = friendData.Length;
        Debug.Log("친구는 몇명인가? :: " + rLength + " ::");

        RankDataS temp;

        for (int j = 0; j < rLength; j++)
        {
            if (myNick == friendData[j].NickName)
            {
                friendData[j].TWeekScore = ValueDeliverScript.scoreHigh.ToString();
                break;
            }
        }

        for (int h = 0; h < rLength - 1; h++)
        {
            for (int i = 0; i < rLength - 1; i++)
            {
                int TWeekScore01 = 0;
                int TWeekScore02 = 0;
                int.TryParse(friendData[i].TWeekScore, out TWeekScore01);
                int.TryParse(friendData[i + 1].TWeekScore, out TWeekScore02);

                if (TWeekScore01 < TWeekScore02)
                {
                    temp = friendData[i];
                    friendData[i] = friendData[i + 1];
                    friendData[i + 1] = temp;
                }
            }
        }
    }


    //스킨의 락오프 여부를 검사해서 알려줌.
    public void FlightLockOffCheck()
    {
        int flightCount = GameObject.Find("Windows").transform.FindChild("WinMove/Flights/MoveTF/FlightsMove").childCount;

        for (int flightNumber = 0; flightNumber < flightCount; flightNumber++)
        {
            for (int skinNum = 1; skinNum <= 5; skinNum++)
            {
                int skinLock = 0;

                switch (flightNumber)
                {
                    case 0: switch (skinNum)
                        {
                            case 1: skinLock = ValueDeliverScript.FlightLock000Skin001; break;
                            case 2: skinLock = ValueDeliverScript.FlightLock000Skin002; break;
                            case 3: skinLock = ValueDeliverScript.FlightLock000Skin003; break;
                            case 4: skinLock = ValueDeliverScript.FlightLock000Skin004; break;
                            case 5: skinLock = ValueDeliverScript.FlightLock000Skin005; break;
                        } break;
                    case 1: switch (skinNum)
                        {
                            case 1: skinLock = ValueDeliverScript.FlightLock001Skin001; break;
                            case 2: skinLock = ValueDeliverScript.FlightLock001Skin002; break;
                            case 3: skinLock = ValueDeliverScript.FlightLock001Skin003; break;
                            case 4: skinLock = ValueDeliverScript.FlightLock001Skin004; break;
                            case 5: skinLock = ValueDeliverScript.FlightLock001Skin005; break;
                        } break;
                    case 2: switch (skinNum)
                        {
                            case 1: skinLock = ValueDeliverScript.FlightLock002Skin001; break;
                            case 2: skinLock = ValueDeliverScript.FlightLock002Skin002; break;
                            case 3: skinLock = ValueDeliverScript.FlightLock002Skin003; break;
                            case 4: skinLock = ValueDeliverScript.FlightLock002Skin004; break;
                            case 5: skinLock = ValueDeliverScript.FlightLock002Skin005; break;
                        } break;
                }

                if (skinLock != 1)
                {
                    bool ischeck = SkinLockCheck(flightNumber, skinNum);
                }
            }
        }
    }

    public void Flight000Skin(int skinNumber, int skinLevel)
    {

        ValueDeliverScript.flight000Skin = skinNumber;
        ValueDeliverScript.skinNumber = skinNumber;
        ValueDeliverScript.skinLevel = skinLevel;
        flight000.renderer.material.mainTexture = flight000Skin[skinNumber];
    }

    public void Flight001Skin(int skinNumber, int skinLevel)
    {

        ValueDeliverScript.flight001Skin = skinNumber;
        ValueDeliverScript.skinNumber = skinNumber;
        ValueDeliverScript.skinLevel = skinLevel;
        flight001.renderer.material.mainTexture = flight001Skin[skinNumber];
    }

    public void Flight002Skin(int skinNumber, int skinLevel)
    {

        ValueDeliverScript.flight002Skin = skinNumber;
        ValueDeliverScript.skinNumber = skinNumber;
        ValueDeliverScript.skinLevel = skinLevel;
        flight002.renderer.material.mainTexture = flight002Skin[skinNumber];
    }

    public void SkinlockOffCount()//소유 스킨 갯수 표시.
    {
        //소유 스킨 갯수 표시.
        for (int fNum = 0; fNum < 3; fNum++)
        {
            int skinLockOffCon = 0;
            int lockOffNum = 1;
            for (int sNum = 1; sNum < 6; sNum++)
            {
                switch (fNum)
                {
                    case 0: switch (sNum)
                        {
                            case 1: skinLockOffCon = ValueDeliverScript.FlightLock000Skin001; break;
                            case 2: skinLockOffCon = ValueDeliverScript.FlightLock000Skin002; break;
                            case 3: skinLockOffCon = ValueDeliverScript.FlightLock000Skin003; break;
                            case 4: skinLockOffCon = ValueDeliverScript.FlightLock000Skin004; break;
                            case 5: skinLockOffCon = ValueDeliverScript.FlightLock000Skin005; break;
                        } break;
                    case 1: switch (sNum)
                        {
                            case 1: skinLockOffCon = ValueDeliverScript.FlightLock001Skin001; break;
                            case 2: skinLockOffCon = ValueDeliverScript.FlightLock001Skin002; break;
                            case 3: skinLockOffCon = ValueDeliverScript.FlightLock001Skin003; break;
                            case 4: skinLockOffCon = ValueDeliverScript.FlightLock001Skin004; break;
                            case 5: skinLockOffCon = ValueDeliverScript.FlightLock001Skin005; break;
                        } break;
                    case 2: switch (sNum)
                        {
                            case 1: skinLockOffCon = ValueDeliverScript.FlightLock002Skin001; break;
                            case 2: skinLockOffCon = ValueDeliverScript.FlightLock002Skin002; break;
                            case 3: skinLockOffCon = ValueDeliverScript.FlightLock002Skin003; break;
                            case 4: skinLockOffCon = ValueDeliverScript.FlightLock002Skin004; break;
                            case 5: skinLockOffCon = ValueDeliverScript.FlightLock002Skin005; break;
                        } break;
                }

                if (skinLockOffCon == 1)
                    lockOffNum++;
            }
            skinLockOffTag[fNum].GetComponent<UILabel>().text = lockOffNum.ToString() + "/6";
        }
        //소유 스킨 갯수 표시.
    }

    void EveryPlayWindowNo()
    {
        GetComponent<HangarPopupController>().CloseWindow();
    }

    void EveryPlayWindowYes()
    {
        GetComponent<HangarPopupController>().CloseWindow(EveryPlayWindowYes01);
    }

    void EveryPlayWindowYes01()
    {
        int everyPlayUpload = 0;

        if (PlayerPrefs.HasKey("EveryPlayUpload")) everyPlayUpload = PlayerPrefs.GetInt("EveryPlayUpload");
        //한번도 업로드한 기록이 없거나 또는 저장 날짜가 맞지 않을 경우 리워드를 제공한다//
        if (!PlayerPrefs.HasKey("EveryPlayUpload") || everyPlayUpload != DateTime.Now.DayOfYear)
        {
            PlayerPrefs.SetInt("EveryPlayUpload", DateTime.Now.DayOfYear);
            //리워들 제공한다.리워드는 코인 1000이다//
            ValueDeliverScript.coinRest += 1000;
            GameObject.Find("GameManager").GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.
        }
        //에브리 플레이에 영상을 올린다//
        Debug.Log("에브리 플레이 영상을 올린다.");
        Everyplay.ShowSharingModal();
       
    }

    void PopupClose()
    {
        GetComponent<HangarPopupController>().CloseWindow();
    }

    void ReviewApp()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.joywinggames.aerogate");
        //게임을 리뷰할 수 있도록 주소 적어줄것
        PlayerPrefs.SetInt("reviewApp", 0);
        ValueDeliverScript.medalRest += 5;
        GameObject.Find("GameManager").GetComponent<GasTimeScript>().MedalRecount();
        ValueDeliverScript.SaveGameData();
    }

    void LogOutForFbLogin()
    {
        PlayerPrefs.DeleteAll();
        ValueDeliverScript.ResetValue(true);
        StartCoroutine(LoadFirst());
    }

    IEnumerator LoadFirst()
    {
        yield return new WaitForSeconds(1f);
        //Application.Quit();
        Destroy(GameObject.Find("FacebookLogin"));
        Destroy(GameObject.Find("EveryPlayTest"));

        Application.LoadLevel(0);

    }
}
