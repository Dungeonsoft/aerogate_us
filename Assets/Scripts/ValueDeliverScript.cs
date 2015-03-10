using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using MyDelegateNS;
using UnityEngine;

public struct RankDataS
{
    public string NickName;
    public string BestScore;
    public string LWeekScore;
    public string TWeekScore;

    public string Flight;
    public string Skin;
    public string Bullet;
    public string Bomb;
    public string Rein;
    public string Assist;
    public string Supporter;

    //20140925 추가 //친구 페북 아이디와 사진 있으면 저장
    public string FbId;

    public string FbName;
    public Texture FbPic;

    public string FuelSendTime;
}

public struct MessageDataS
{
    public string To;
    public string From;
    public string Type;
    public string Ea;
    public string Time;
    public string Contents;

    public Texture fbpic;

    public MessageDataS(string To, string From, string Type, string Ea, string Time, string Contents, Texture fbpic)
    {
        this.To = To;
        this.From = From;
        this.Type = Type;
        this.Ea = Ea;
        this.Time = Time;
        this.Contents = Contents;
        this.fbpic = fbpic;
    }
}

public class ValueDeliverScript : MonoBehaviour
{

    public static void SaveGameData(NextFunc nextF = null)
    {
        Debug.Log("Save Game Data!!!");
        if (Application.loadedLevel != 0)
        {
            saveCount++;
            Debug.Log("행거임?" + saveCount);
            GameObject.Find("GameManager").GetComponent<UpdateUserInfo>().UpdateUserData1(nextF);

            //로컬에 저장할 것들을 정리//


            PlayerPrefs.SetInt("flightNumber", flightNumber);
            PlayerPrefs.SetInt("activeOper", activeOper);
            PlayerPrefs.SetInt("dartCount", dartCount);
            PlayerPrefs.SetInt("dustCount", dustCount);
            PlayerPrefs.SetInt("shieldCount", shieldCount);
            PlayerPrefs.SetInt("spinballCount", spinballCount);

            PlayerPrefs.SetInt("isSpecialAttackMissionSelect", isSpecialAttackMissionSelect);
            PlayerPrefs.SetInt("specialAttackType", specialAttackType);
            PlayerPrefs.SetInt("isSpecialAttackComplete", isSpecialAttackComplete);
            PlayerPrefs.SetString("specialEndTime", specialEndTime);
            PlayerPrefs.SetString("specialAttackItemName", specialAttackItemName);

            PlayerPrefs.SetInt("flight000SortieNumber", flight000SortieNumber);
            PlayerPrefs.SetInt("flight000BombUseNumber", flight000BombUseNumber);
            PlayerPrefs.SetInt("flight000ScoreHigh", flight000ScoreHigh);
            PlayerPrefs.SetInt("flight001EnemyKill", flight001EnemyKill);
            PlayerPrefs.SetInt("flight001GetCoin", flight001GetCoin);
            PlayerPrefs.SetInt("flight001UseSkill", flight001UseSkill);
            PlayerPrefs.SetInt("flight001GetPowerItem", flight001GetPowerItem);
            PlayerPrefs.SetInt("flight002KillSpinball", flight002KillSpinball);
            PlayerPrefs.SetInt("flight002SpecialAttack", flight002SpecialAttack);
            PlayerPrefs.SetInt("flight002CompleteInstanceMission", flight002CompleteInstanceMission);
            PlayerPrefs.SetInt("flight002RescueFriend", flight002RescueFriend);
            PlayerPrefs.SetInt("flight002WormLevel5", flight002WormLevel5);
            PlayerPrefs.SetInt("isFirstAccess", isFirstAccess);
        }
    }
    //친구에게 메세지(연료보내기)를 하였을 경우 메세지 보낸 시간을 기록하는 메서드//
    public static void SaveFuelSendTime(string fbId, string sendTime)
    {
        Debug.Log("::: Save Fuel Send Time ::: 001");
        Debug.Log("::: Save Fuel Send Time ::: fbId ::: " + fbId);
        Debug.Log("::: Save Fuel Send Time ::: sendTime ::: " + sendTime);

        if (PlayerPrefs.HasKey("fuelSendTime"))
        {
            Debug.Log("::: Save Fuel Send Time ::: 002");

            fuelSendTime = PlayerPrefs.GetString("fuelSendTime");

            string[] sendtimeTemp = fuelSendTime.Split(',');

            for (int i = 0; i < sendtimeTemp.Length; i++)
            {
                if (fbId == sendtimeTemp[i])
                {
                    Debug.Log("::: Save Fuel Send Time ::: 003");

                    //이전에도 리퀘한적이 있으면 아이디를 찾아서 그부분을 삭제하고 내용을 재정렬해준다//
                    DelSendtimeSameId(sendtimeTemp, i);
                    break;
                }
            }
            fuelSendTime = fuelSendTime + "," + fbId + "," + sendTime;
        }
        else
        {
            Debug.Log("::: Save Fuel Send Time ::: 004");

            fuelSendTime = fbId + "," + sendTime;
        }
        Debug.Log("::: Save Fuel Send Time ::: 005");
        PlayerPrefs.SetString("fuelSendTime", fuelSendTime);
        Debug.Log("fuelSendTime String :::: " + fuelSendTime);
    }

    static void DelSendtimeSameId(string[] sendtimeTemp, int sameIdNum)
    {
        Debug.Log("DelSendtimeSameId ::: 001");
        if (sendtimeTemp.Length > 2)
        {
            string[] temp = new string[sendtimeTemp.Length - 2];

            for (int j = 0; j < sameIdNum; j++)
            {
                temp[j] = sendtimeTemp[j];
            }

            Debug.Log("DelSendtimeSameId ::: 002");
            Debug.Log("sendtimeTemp.Length ::: " + sendtimeTemp.Length);
            Debug.Log("sameIdNum ::: " + sameIdNum);

            for (int i = sameIdNum; i < sendtimeTemp.Length - 2; i++)
            {

                temp[i] = sendtimeTemp[i + 2];
            }


            Debug.Log("DelSendtimeSameId ::: 003");
            string toString = "";
            for (int k = 0; k < temp.Length; k++)
            {
                toString += temp[k];
                if (k + 1 < temp.Length) toString += ",";
            }
            fuelSendTime = toString;
            Debug.Log("toString ::: " + toString);
        }
        else
        {
            fuelSendTime = "";
        }
    }






    private static int saveCount = 0;
    static string fuelSendTime;
    public static bool isVerCheckFaild = false;

    public static Dictionary<string, object> gameData;

    public static RankDataS[] rankDataFB;
    public static RankDataS[] worldRank;
    public static MessageDataS[] messageData;
    public static MessageDataS messageSend;

    public static bool logInAlready = false;
    public static int flightNumber = 0; //기본은 0(포커)
    public static int skinNumber = 0;   //기본은 0(기능없는 스킨)
    public static int resultSkinnumber = -1;
    public static int skinLevel = 1;
    public static int bulletLevel = 1; //기본은 1.
    public static int bombRecycle = 60;	//기본은 60.

    public static int skillLevel = 1;   //기본은 1.

    public static int scorePlay = 0;    //기본값은 0//
    public static int scoreResult = 0;

    public static int portalUpScore = 0;

    public static int coinPlay = 0;

    public static bool isHigh = false;      //최고점수 상태에 도달 했는지 여부 확인.

    //스페셜 출격에 관련된 적기 갯수를 세는 부분.//

    public static int dartCountTemp = 0;
    public static int dustCountTemp = 0;
    public static int shieldCountTemp = 0;
    public static int spinballCountTemp = 0;
    //스페셜 출격에 관련된 적기 갯수를 세는 부분.//

    public static bool gameEndResult = false;   //기본은 false. 결과창 테스트를 위해선 true로 바꾸어야 됨.
    public static bool isResultToHanger = false;

    public static bool alreadyRoadPhpData = false;
    public static bool isTableGet = false;

    public static int medalPlay = 0;

    public static int oldTime;

    public static int skinExp = 0;  //활성화된 비행기가 인게임에서 얻는 스킨 경험치를 임시 저장하는 변수.

    public static int purchaseCharge = 0;

    public static GameObject SelectedItem;
    public static string SelectedItemSprite;

    public static bool shieldEquip = false;
    public static float fuelSize = 100;  //기본이 0
    public static float fuelSizeOri = 100;

    public static string[] bombSpriteName;
    public static string[] reinforceSpriteName;
    public static string[] assistSpriteName;
    public static string[] operSpriteName;

    //public static ArrayList enemyInGame = new ArrayList();
    public static List<GameObject> enemyInGame = new List<GameObject>();

    //이큅 관련된 변수들.

    public static float flightAttackPower = 0f;
    public static float flightAttackSpeed = 0f;
    public static int targetUfoType;
    public static bool isCriticalExel = false; //임시로 TRUE로 변경.

    public static int dartApearPer = 2500;  //2500
    public static int dustApearPer = 5000;  //5000
    public static int spinballApearPer = 7500;  //7500

    public static bool isSpecialAnimation = false;  //원랜 false.

    public static int detectorType = -1; //원래 -1.

    public static bool wingboxDouble = false;

    //스킨 기능 관련 변수들.∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨∨.
    public static int addFlightExp = 0;

    public static float plasmaWaveCoolTime = 0;

    public static int addAttackAbility = 0;
    public static float itemReinforce08Effect = 0f;

    public static float increaseBombAttackPercent = 0f; //핵폭탄 사용시 공격력 증가 시간 설정 변수.
    public static float increaseBombAttackPercentInGame = 0f;
    public static float increaseBombAttackTime = 0;
    public static bool isIncreaseBombAttackPercent = false;

    public static float increaseScorePercent = 0f;
    public static bool isIncreaseScorePercent = false;
    public static float shieldDestroyAddScorePercent = 0f;

    public static int powerUpDropChance = 0;	// 1/10000 확률료 표시할것.
    public static float powerUpAttackIncreaseTime = 0f;
    public static float AttackPowerPercent = 0f;
    public static float AttackPowerPercentTemp = 0f;

    public static bool isdamageAddChance = false;
    public static int damageAddChance = 0;	// 1/10000 확률료 표시할것.
    public static float damageAddPercent = 0f;

    public static int coinAddChance = 0; // 1/10000 확률료 표시할것.
    public static int coinAddNumber = 1;

    public static int rechargeEnergy = 0;

    public static bool isBombRechargeDecrease = false;
    public static bool isBombRechargeDecreaseTemp = false;
    public static bool isBombToSkillGageIncrease = false;
    public static float bombRechargeDecrease = 0f;	//시간(초).
    public static int addSkillGagePercent = 0;	// 1/10000 확률료 표시할것.

    public static float scoreIncreasePercent = 0f;
    public static float comancheDeveilBreathAddSpeed = 0f;

    public static float spinballDamagePercent = 0f;

    public static float specialBombRechargeDecrease = 0f;	//시간(초).

    public static float wingboxAddtime = 0f;

    public static float friendFlightAddTime = 0f;

    public static int applyPortalLevel = 0;
    public static float bombTimeDecrease = 0f;
    public static float nowPortalLevel = 1;
    //스킨 기능 관련 변수들.∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧∧.

    //총알과 스킬샷의 업그레이드시 들어가는 비용 마지막 똑같은 값이 하나더 들어간것은 널 에러를 막기위해 임시로 넣은값. 꼭 필요하니 지우지 말것.
    public static int[] flight000BulletUpCoin = { 0, 0, 100, 300, 600, 1000, 1500, 2100, 2800, 3600, 4500, 5500, 6600, 7800, 9100, 10500, 10500 };
    public static int[] flight001BulletUpCoin = { 0, 0, 100, 300, 600, 1000, 1500, 2100, 2800, 3600, 4500, 5500, 6600, 7800, 9100, 10500, 10500 };
    public static int[] flight002BulletUpCoin = { 0, 0, 100, 300, 600, 1000, 1500, 2100, 2800, 3600, 4500, 5500, 6600, 7800, 9100, 10500, 10500 };

    public static int[] flight000SkillUpCoin = { 0, 0, 1000, 5000, 10000, 30000, 30000 };
    public static int[] flight001SkillUpCoin = { 0, 0, 1000, 5000, 10000, 30000, 30000 };
    public static int[] flight002SkillUpCoin = { 0, 0, 1000, 5000, 10000, 30000, 30000 };

    //비행기별 속도-배열 앞부터 포커, 코만치, 팬텀, 차후 추가되는것은 뒤에 붙이면 됨.
    public static float[] flightSpeed = { 12f, 18f, 15f };

    //스페셜 출격 이벤트가 끝나는 시간을 저장. 시간은 항상 스트링으로 변환하여 저장한다.
    //다시 꺼내 쓸때는 DateTime timeTemp =  DateTime.FromBinary(Convert.ToInt64(시간변수)) 형식으로 변환하여 스트링이 시스템 시간과 같은 것으로 인식이 되게 만든다.
    //시간을 저장할때는
    //string timeTemp = System.DateTime.ToBinary().ToString();
    //이와같은 구조로 만들어 저장한다.
    //string endTime = System.DateTime.Now.AddMinutes(-minutesTemp).AddSeconds(-secondsTemp).ToBinary().ToString();
    //시간을 더하거나 뺄때는 바로 윗줄의 형식과 같이 해준다. 지금 예는 시간을 빼는 형태이다.
    //스페셜 출격 시간은 꼭 서버에 저장되게 만든다.
    //한번더 정리 . 시간을 저장하고 꺼내쓰는 방법.
    //시간은 DateTime 이라는 형식으로 생성을 한다.
    //시간을 따로 일반적인 형태의 변수로 저장을 할때는 string 형으로 변환한다.
    //다시 꺼내 쓸때는 string 형을 long 형으로 변환하고 DateTime.FromBinary 이용하여 다시 시간으로 변환한다.(190번줄 참고)  그값을 DateTime 형 변수에 저장하여 사용한다.
    public static int specialAttackAddTime = 30; //스페셜 출격이 시작되고 유지되는 시간을 정한다. 기본 30분으로 한다.

    public static int specialDart = 600;    //900.
    public static int specialSpinball = 900;   //1500.
    public static int specialDust = 2400;   //3000.
    public static int specialSeed = 300;  //300.

    public static int addGasTime = 900; //연료를 지급하는데 걸리는 시간을 기록한다.

    public static Hashtable duraCost = new Hashtable(); //내구도 구매 가격 설정.
    public static bool isDuraCostLoad = false;

    //public static bool isSelectSpecial = false;
    public static bool isSelectSpecial = false;
    public static float specialSpeed = 1.5f;

    //스킨 락 해제 조건 관련 변수들//
    public static int flight000BombUseNumberTemp;   //Flight000Skin003//

    public static int flight001EnemyKillTemp;      //Flight001Skin001//
    public static int flight001GetCoinTemp;        //Flight001Skin002//
    public static int flight001UseSkillTemp;        //Flight001Skin003//
    public static int flight001GetPowerItemTemp;    //Flight001Skin004//
    public static int flight002KillSpinballTemp;    //Flight002Skin001//
    public static int flight002CompleteInstanceMissionTemp; //Flight002Skin003//
    public static int flight002RescueFriendTemp;    //Flight002Skin004//

    public static Hashtable skinMedalCost = new Hashtable();
    public static bool isSkinMedalCostLoad = false;

    //스킨 락 해제 조건 관련 변수들//

    public static Hashtable goldPrice = new Hashtable();    //금화 구매 가격 설정.
    public static bool isGoldPriceLoad = false;

    public static Hashtable gasPrice = new Hashtable();     //가스(연료) 구매 가격 설정.
    public static bool isGasPriceLoad = false;

    public static Hashtable medalPrice = new Hashtable();     //메달 구매 가격 설정.
    public static bool isMedalPriceLoad = false;

    public static Hashtable operaterLockOff = new Hashtable();     //오퍼레이터 락오프여부.

    public static int flightWindowPosition;

    public static string ver = "20150306";

    public static float characterSound = 1f;
    public static float fxSound = 0.5f;
    public static float bgSound = 0f;

    public static NameValueCollection equipSpriteName = new NameValueCollection();  //이큅 아이템별 스프라이트 이름을 저장하기 위한 변수.
    public static NameValueCollection equipItemName = new NameValueCollection();    //이큅 아이템별 스프라이트 이름을 저장하기 위한 변수.
    public static NameValueCollection equipItemPrice = new NameValueCollection();   //이큅 아이템별 스프라이트 이름을 저장하기 위한 변수.

    //할인판매창에서 쓰이는 변수들.//
    public static string saleItem01;    //할인판매창에서 쓰이는 변수들.//

    public static string saleItem02;    //할인판매창에서 쓰이는 변수들.//
    public static string saleItem03;    //할인판매창에서 쓰이는 변수들.//
    //할인판매창에서 쓰이는 변수들.//

    public static int salePriceInt;

    public static bool isCharacterSound = false;

    public static bool isKakaoUpdate = false;

    public static bool isGetFriend = false;

    public static bool isMessageLoad = false;

    public static float comboTime = 2f;

    public static bool isBreakGame = false;

    public static string rescueFriendId = "";

    public static string rescueArlamFriendNick = "";
    public static string rescueArlamFriendId = "";
    public static bool rescueFriendBlock = false;
    public static int isSendRescueArlamNum = -1;
    //public static int friendshipPoint = 200;

    /////////////////////강화포인트///////////

    ////기본 포인트////
    public static int pointF00P01 = 50;
    public static int pointF00P02 = 60;
    public static int pointF00P03 = 60;
    public static int pointF00P04 = 20;

    public static int pointF01P01 = 60;
    public static int pointF01P02 = 100;
    public static int pointF01P03 = 90;
    public static int pointF01P04 = 30;

    public static int pointF02P01 = 70;
    public static int pointF02P02 = 80;
    public static int pointF02P03 = 75;
    public static int pointF02P04 = 40;
    ////기본 포인트////

    ////최대 포인트////
    public static int pointF00P01Max = 150;
    public static int pointF00P02Max = 120;
    public static int pointF00P03Max = 100;
    public static int pointF00P04Max = 150;

    public static int pointF01P01Max = 200;
    public static int pointF01P02Max = 180;
    public static int pointF01P03Max = 140;
    public static int pointF01P04Max = 160;

    public static int pointF02P01Max = 250;
    public static int pointF02P02Max = 150;
    public static int pointF02P03Max = 120;
    public static int pointF02P04Max = 200;
    ////최대 포인트////

    /////////////////////강화포인트///////////

    public static bool isArlamRescue = false;

    public static bool isBgSound = true;
    public static bool isFxSound = true;
    public static bool isArlamMessage = true;

    public static int logoutCount = 0;

    public static int isTutComplete = 2;    //2월 28일 서버에 넣어야 될 데이터 기본값은 0이며 튜토리얼 완료시 서버에 2로 저장.
    public static int skin00_04Effect = 0;
    public static float itemMagnetEffect = 0f;
    public static int Item04Effect = 0;

    public static float skin02_03Effect = 1f;
    public static float skin02_04Effect = 0f;
    public static float skin02_05Effect1 = 0f;
    public static float skin02_05Effect2 = 1f;

    public static GameObject invitedFriendTab = null;

    //원래 포어 카카오에 있던것들//
    public static string appFriendsUserId = "";

    //public static string friendsUserId = "";

    //public static string[] appFriendsUserIdFrom;
    //public static string[] friendsUserIdFrom;

    public static AppFriendInfo[] appFriendsInfo;
    public static KakaoFriendInfo[] kakaoFriendInfo;
    //원래 포어 카카오에 있던것들//

    public static int AllMessageCount = 0;

    public static int RescuedFriendCount = 0;

    public static bool isNoEnd = false;

    public static bool isPcExplo = false;   //true면 파괴된 상태 // false면 정상비행상태//

    //밸류퍼스트에 있는것들 다시 이곳으로 옮김.

    //gameData.Add("Nick", "");
    public static string Nick = "";

    //gameData.Add("UserID", "");
    public static string UserID = "";

    //////////////gameData.Add("UserRankingGroup", 0); //안씀//

    //gameData.Add("flightNumber", 0);    //처음시작할때 비행기 번호(0은 포커)
    //public static int flightNumber;

    //gameData.Add("scoreHigh", 0);
    public static int scoreHigh;

    //gameData.Add("lastScoreHigh", 0); //지난주 최고점수.
    public static int lastScoreHigh;

    //gameData.Add("coinRest", 2500);    //남아있는 코인갯수.
    public static int coinRest;

    //gameData.Add("medalRest", 10);  //남아있는 메달갯수.(블루 다이아몬드)
    public static int medalRest;

    //gameData.Add("highFlight", 0);  //최고점수기체.
    public static int highFlight;

    //gameData.Add("highSkin", 0);    //최고점수스킨.
    public static int highSkin;

    //gameData.Add("highChar", 0);    //최고점수캐릭터.
    public static int highChar;

    //gameData.Add("highBullet", 0);  //최고점수총알.
    public static int highBullet;

    //gameData.Add("highBomb", 0);    //최고점수폭탄.
    public static int highBomb;

    //gameData.Add("highReinforce", 0);   //최고점수강화품.
    public static int highReinforce;

    //gameData.Add("highAssist", 0);  //최고점수보조품.
    public static int highAssist;

    //gameData.Add("dartCount", 0);
    public static int dartCount;

    //gameData.Add("dustCount", 0);
    public static int dustCount;

    //gameData.Add("shieldCount", 0);
    public static int shieldCount;

    //gameData.Add("spinballCount", 0);
    public static int spinballCount;

    //gameData.Add("gasRest", 5);     //남아있는 연료갯수.
    public static int gasRest;

    public static int gasMax = 5;   //가스 최대치.  

    //gameData.Add("userLevel", 0);   //유저레벨.
    public static int userLevel;

    //gameData.Add("userExp", 0);     //유저경험치.
    public static int userExp;

    ////내비행기목록.레벨치.

    //gameData.Add("flight000Skin", 0);
    public static int flight000Skin;

    //gameData.Add("flight000Bullet", 1);
    public static int flight000Bullet;

    //gameData.Add("flight000Skill", 1);
    public static int flight000Skill;

    //gameData.Add("flight001Skin", 0);
    public static int flight001Skin;

    //gameData.Add("flight001Bullet", 1);
    public static int flight001Bullet;

    //gameData.Add("flight001Skill", 1);
    public static int flight001Skill;

    //gameData.Add("flight002Skin", 0);
    public static int flight002Skin;

    //gameData.Add("flight002Bullet", 1);
    public static int flight002Bullet;

    //gameData.Add("flight002Skill", 1);
    public static int flight002Skill;

    ////내비행기목록.레벨치.

    ////스킨경험치

    //gameData.Add("FlightExp000Skin001", 0);
    public static int FlightExp000Skin001;

    //gameData.Add("FlightExp000Skin002", 0);
    public static int FlightExp000Skin002;

    //gameData.Add("FlightExp000Skin003", 0);
    public static int FlightExp000Skin003;

    //gameData.Add("FlightExp000Skin004", 0);
    public static int FlightExp000Skin004;

    //gameData.Add("FlightExp000Skin005", 0);
    public static int FlightExp000Skin005;

    //gameData.Add("FlightExp001Skin001", 0);
    public static int FlightExp001Skin001;

    //gameData.Add("FlightExp001Skin002", 0);
    public static int FlightExp001Skin002;

    //gameData.Add("FlightExp001Skin003", 0);
    public static int FlightExp001Skin003;

    //gameData.Add("FlightExp001Skin004", 0);
    public static int FlightExp001Skin004;

    //gameData.Add("FlightExp001Skin005", 0);
    public static int FlightExp001Skin005;

    //gameData.Add("FlightExp002Skin001", 0);
    public static int FlightExp002Skin001;

    //gameData.Add("FlightExp002Skin002", 0);
    public static int FlightExp002Skin002;

    //gameData.Add("FlightExp002Skin003", 0);
    public static int FlightExp002Skin003;

    //gameData.Add("FlightExp002Skin004", 0);
    public static int FlightExp002Skin004;

    //gameData.Add("FlightExp002Skin005", 0);
    public static int FlightExp002Skin005;

    ////스킨경험치

    ////스킨레벨

    //gameData.Add("FlightLev000Skin001", 1);
    public static int FlightLev000Skin001;

    //gameData.Add("FlightLev000Skin002", 1);
    public static int FlightLev000Skin002;

    //gameData.Add("FlightLev000Skin003", 1);
    public static int FlightLev000Skin003;

    //gameData.Add("FlightLev000Skin004", 1);
    public static int FlightLev000Skin004;

    //gameData.Add("FlightLev000Skin005", 1);
    public static int FlightLev000Skin005;

    //gameData.Add("FlightLev001Skin001", 1);
    public static int FlightLev001Skin001;

    //gameData.Add("FlightLev001Skin002", 1);
    public static int FlightLev001Skin002;

    //gameData.Add("FlightLev001Skin003", 1);
    public static int FlightLev001Skin003;

    //gameData.Add("FlightLev001Skin004", 1);
    public static int FlightLev001Skin004;

    //gameData.Add("FlightLev001Skin005", 1);
    public static int FlightLev001Skin005;

    //gameData.Add("FlightLev002Skin001", 1);
    public static int FlightLev002Skin001;

    //gameData.Add("FlightLev002Skin002", 1);
    public static int FlightLev002Skin002;

    //gameData.Add("FlightLev002Skin003", 1);
    public static int FlightLev002Skin003;

    //gameData.Add("FlightLev002Skin004", 1);
    public static int FlightLev002Skin004;

    //gameData.Add("FlightLev002Skin005", 1);
    public static int FlightLev002Skin005;

    ////스킨레벨

    ////스킨내구도

    //gameData.Add("FlightDura000Skin001", 10);
    public static int FlightDura000Skin001;

    //gameData.Add("FlightDura000Skin002", 10);
    public static int FlightDura000Skin002;

    //gameData.Add("FlightDura000Skin003", 10);
    public static int FlightDura000Skin003;

    //gameData.Add("FlightDura000Skin004", 10);
    public static int FlightDura000Skin004;

    //gameData.Add("FlightDura000Skin005", 10);
    public static int FlightDura000Skin005;

    //gameData.Add("FlightDura001Skin001", 10);
    public static int FlightDura001Skin001;

    //gameData.Add("FlightDura001Skin002", 10);
    public static int FlightDura001Skin002;

    //gameData.Add("FlightDura001Skin003", 10);
    public static int FlightDura001Skin003;

    //gameData.Add("FlightDura001Skin004", 10);
    public static int FlightDura001Skin004;

    //gameData.Add("FlightDura001Skin005", 10);
    public static int FlightDura001Skin005;

    //gameData.Add("FlightDura002Skin001", 10);
    public static int FlightDura002Skin001;

    //gameData.Add("FlightDura002Skin002", 10);
    public static int FlightDura002Skin002;

    //gameData.Add("FlightDura002Skin003", 10);
    public static int FlightDura002Skin003;

    //gameData.Add("FlightDura002Skin004", 10);
    public static int FlightDura002Skin004;

    //gameData.Add("FlightDura002Skin005", 10);
    public static int FlightDura002Skin005;

    ////스킨내구도

    ////이큅소유량

    //gameData.Add("EquipBomb01", 5);//플라즈마웨이브.
    public static int EquipBomb01;

    //gameData.Add("EquipBomb02", 0);
    public static int EquipBomb02;

    //gameData.Add("EquipBomb03", 0);
    public static int EquipBomb03;

    //gameData.Add("EquipBomb04", 0);
    public static int EquipBomb04;

    //gameData.Add("EquipBomb05", 0);//블랙홀.
    public static int EquipBomb05;

    //gameData.Add("EquipBomb06", 0);
    public static int EquipBomb06;

    //gameData.Add("EquipBomb07", 0);
    public static int EquipBomb07;

    //gameData.Add("EquipBomb08", 0);
    public static int EquipBomb08;

    //gameData.Add("EquipBomb09", 0);
    public static int EquipBomb09;

    //gameData.Add("EquipBomb10", 0);
    public static int EquipBomb10;

    //gameData.Add("EquipBomb11", 0);
    public static int EquipBomb11;

    //gameData.Add("EquipBomb12", 0);
    public static int EquipBomb12;

    //gameData.Add("EquipReinforce01", 0);//싱글증폭기.
    public static int EquipReinforce01;

    //gameData.Add("EquipReinforce02", 0);//듀얼증폭기.
    public static int EquipReinforce02;

    //gameData.Add("EquipReinforce03", 0);//스핀볼탐지증폭기.
    public static int EquipReinforce03;

    //gameData.Add("EquipReinforce04", 0);//다트탐지증폭기.
    public static int EquipReinforce04;

    //gameData.Add("EquipReinforce05", 0);//더스트탐지증폭기.
    public static int EquipReinforce05;

    //gameData.Add("EquipReinforce06", 0);//실드탐지증폭기.
    public static int EquipReinforce06;

    //gameData.Add("EquipReinforce07", 0);//크리티컬엑셀레이터.
    public static int EquipReinforce07;

    //gameData.Add("EquipReinforce08", 0);//파이널파워업.
    public static int EquipReinforce08;

    //gameData.Add("EquipReinforce09", 0);
    public static int EquipReinforce09;

    //gameData.Add("EquipReinforce10", 0);
    public static int EquipReinforce10;

    //gameData.Add("EquipReinforce11", 0);
    public static int EquipReinforce11;

    //gameData.Add("EquipReinforce12", 0);
    public static int EquipReinforce12;

    //gameData.Add("EquipAssist01", 5);//보호막.(쉴드)
    public static int EquipAssist01;

    //gameData.Add("EquipAssist02", 0);//자석.
    public static int EquipAssist02;

    //gameData.Add("EquipAssist03", 0);//빠른핵폭탄.(숏봄)
    public static int EquipAssist03;

    //gameData.Add("EquipAssist04", 0);//스킬드레인.(에너지드레인)
    public static int EquipAssist04;

    //gameData.Add("EquipAssist05", 0);//더블윙박스.
    public static int EquipAssist05;

    //gameData.Add("EquipAssist06", 0);//스트롱웜홀.
    public static int EquipAssist06;

    //gameData.Add("EquipAssist07", 0);
    public static int EquipAssist07;

    //gameData.Add("EquipAssist08", 0);
    public static int EquipAssist08;

    //gameData.Add("EquipAssist09", 0);
    public static int EquipAssist09;

    //gameData.Add("EquipAssist10", 0);
    public static int EquipAssist10;

    //gameData.Add("EquipAssist11", 0);
    public static int EquipAssist11;

    //gameData.Add("EquipAssist12", 0);
    public static int EquipAssist12;

    public static int EquipOper01;

    public static int EquipOper02;

    public static int EquipOper03;

    public static int EquipOper04;

    public static int EquipOper05;

    public static int EquipOper06;

    public static int EquipOper07;

    public static int EquipOper08;

    public static int EquipOper09;

    public static int EquipOper10;

    public static int EquipOper11;

    public static int EquipOper12;

    ////이큅소유량

    //gameData.Add("activeBomb", 5);
    public static int activeBomb;

    //gameData.Add("activeReinforce", 0);
    public static int activeReinforce;

    //gameData.Add("activeAssist", 0);
    public static int activeAssist;

    //gameData.Add("activeOper", 1);
    public static int activeOper = 1;

    //gameData.Add("isSpecialMissionSelect", 0);  //원래불린 - 0과 1로 처리할것-
    public static int isSpecialAttackMissionSelect;

    //gameData.Add("specialAttackTyp", 0);
    public static int specialAttackType;

    //gameData.Add("isSpecialAttackComplete", 0);   //원래불린 - 0과 1로 처리할것-
    public static int isSpecialAttackComplete;

    //gameData.Add("specialEndTime", "");
    public static string specialEndTime;

    //gameData.Add("specialAttackItemName", "");
    public static string specialAttackItemName;

    //gameData.Add("specialAttackItemMaxNumber", 0);
    public static int specialAttackItemMaxNumber;   //서버나 로컬에 저장 안함//

    //gameData.Add("gasLastAddTime", "");
    public static string gasLastAddTime;

    //gameData.Add("gasNextAddTime", "");
    public static string gasNextAddTime;

    //gameData.Add("timeRecord", 0);
    public static int timeRecord;   //이미 로컬에 저장했음//

    //gameData.Add("flight000SortieNumber", 0);
    public static int flight000SortieNumber;

    //gameData.Add("flight000BombUseNumber", 0);
    public static int flight000BombUseNumber;

    //gameData.Add("flight000ScoreHigh", 0);
    public static int flight000ScoreHigh;

    //gameData.Add("flight001EnemyKill", 0);
    public static int flight001EnemyKill;

    //gameData.Add("flight001GetCoin", 0);
    public static int flight001GetCoin;

    //gameData.Add("flight001UseSkill", 0);
    public static int flight001UseSkill;

    //gameData.Add("flight001GetPowerItem", 0);
    public static int flight001GetPowerItem;

    //gameData.Add("flight002KillSpinball", 0);
    public static int flight002KillSpinball;

    //gameData.Add("flight002SpecialAttack", 0);
    public static int flight002SpecialAttack;

    //gameData.Add("flight002CompleteInstanceMission", 0);
    public static int flight002CompleteInstanceMission;

    //gameData.Add("flight002RescueFriend", 0);
    public static int flight002RescueFriend;

    //gameData.Add("flight002WormLevel5", 0);   //원래불린 - 0과 1로 처리할것-
    public static int flight002WormLevel5;

    ////스킨락오프 //원래불린 - 0과 1로 처리할것-

    //gameData.Add("FlightLock000Skin001", 0);
    public static int FlightLock000Skin001;

    //gameData.Add("FlightLock000Skin002", 0);
    public static int FlightLock000Skin002;

    //gameData.Add("FlightLock000Skin003", 0);
    public static int FlightLock000Skin003;

    //gameData.Add("FlightLock000Skin004", 0);
    public static int FlightLock000Skin004;

    //gameData.Add("FlightLock000Skin005", 0);
    public static int FlightLock000Skin005;

    //gameData.Add("FlightLock001Skin001", 0);
    public static int FlightLock001Skin001;

    //gameData.Add("FlightLock001Skin002", 0);
    public static int FlightLock001Skin002;

    //gameData.Add("FlightLock001Skin003", 0);
    public static int FlightLock001Skin003;

    //gameData.Add("FlightLock001Skin004", 0);
    public static int FlightLock001Skin004;

    //gameData.Add("FlightLock001Skin005", 0);
    public static int FlightLock001Skin005;

    //gameData.Add("FlightLock002Skin001", 0);
    public static int FlightLock002Skin001;

    //gameData.Add("FlightLock002Skin002", 0);
    public static int FlightLock002Skin002;

    //gameData.Add("FlightLock002Skin003", 0);
    public static int FlightLock002Skin003;

    //gameData.Add("FlightLock002Skin004", 0);
    public static int FlightLock002Skin004;

    //gameData.Add("FlightLock002Skin005", 0);
    public static int FlightLock002Skin005;

    ////스킨락오프

    ////플라이트락오프

    //gameData.Add("FlightLockOff000", 2);
    public static int FlightLockOff000 = 2;

    //gameData.Add("FlightLockOff001", 0);
    public static int FlightLockOff001;

    //gameData.Add("FlightLockOff002", 0);
    public static int FlightLockOff002;

    //gameData.Add("FlightLockOff001Coin", 29000);
    public static int FlightLockOff001Coin = 29000;

    //gameData.Add("FlightLockOff002Coin", 36000);
    public static int FlightLockOff002Coin = 36000;

    //gameData.Add("FlightLockOff001Medal", 49);
    public static int FlightLockOff001Medal = 49;

    //gameData.Add("FlightLockOff002Medal", 59);
    public static int FlightLockOff002Medal = 59;

    ////플라이트락오프

    //업그레이드 포인트 당 적용되는 강화 량//

    //데미지(공격력)
    public static int damagePerUpoint = 2;
    public static float fRatePerUpoint = 0.1f;
    public static float speedPerUpoint = 0.2f;
    public static int fuelPerUpoint = 5;

    //gameData.Add("isFirstAccess", 0);
    public static int isFirstAccess;

    //gameData.Add("upgradePoint", 0);
    public static int upgradePoint;

    //gameData.Add("upgradePointF00P01", 0);
    public static int upgradePointF00P01;

    //gameData.Add("upgradePointF00P02", 0);
    public static int upgradePointF00P02;

    //gameData.Add("upgradePointF00P03", 0);
    public static int upgradePointF00P03;

    //gameData.Add("upgradePointF00P04", 0);
    public static int upgradePointF00P04;

    //gameData.Add("upgradePointF01P01", 0);
    public static int upgradePointF01P01;

    //gameData.Add("upgradePointF01P02", 0);
    public static int upgradePointF01P02;

    //gameData.Add("upgradePointF01P03", 0);
    public static int upgradePointF01P03;

    //gameData.Add("upgradePointF01P04", 0);
    public static int upgradePointF01P04;

    //gameData.Add("upgradePointF02P01", 0);
    public static int upgradePointF02P01;

    //gameData.Add("upgradePointF02P02", 0);
    public static int upgradePointF02P02;

    //gameData.Add("upgradePointF02P03", 0);
    public static int upgradePointF02P03;

    //gameData.Add("upgradePointF02P04", 0);
    public static int upgradePointF02P04;

    //gameData.Add("pointResetCount", 0);
    public static int pointResetCount;

    //gameData.Add("FriendRequestCount", 0);
    public static int FriendRequestCount;

    //gameData.Add("invitedFriendCount", 0);
    public static int invitedFriendCount;

    ////우정포인트-백점당 1회의 랜덤 뽑기가 가능.

    //gameData.Add("friendshipPoint", 100);
    public static int buddyPoint;

    ////우정포인트-백점당 1회의 랜덤 뽁기가 가능.

    public static string myFBid = "";

    public static string myFBName = "";

    //임시테스트? 페이스북 모든 친구 제이슨데이터//
    public static string friendJsonAll;

    //페이스북 내사진//
    public static Texture2D myPic;

    //페이스북랭킹 최초 기준 시간//
    public static string fRankDefaultTime = (new System.DateTime(2014, 11, 17).ToUniversalTime().ToBinary()).ToString();

    //월드랭킹 최초 기준 시간//
    public static string wRankDefaultTime = (new System.DateTime(2014, 11, 17).ToUniversalTime().ToBinary()).ToString();

    //페이스북 랭킹 인터벌 시간(날수)//
    public static int fRankInterDay = 1;

    //월드 랭킹 인터벌 시간(날수)//
    public static int wRankInterDay = 1;

    //접속을 해서 리워드를 받은 날을 기록/ 아무값도 기록이 없거나 또는 지난 날이면 리워드를 받을 수 있게 해준다//
    public static string myRewardTime = "0";

    //이번 페북친구랭크를 계산하여 나온 나의 등수//
    public static int myFbRank = 0;

    //이번 월드랭크를 계산하여 나온 나의 등수//
    public static int myWdRank = 0;

    //페북랭크 몇등까지 보상을 줄지 결정//
    public static int fbRewardGrade = 3;

    //월드랭크 몇등까지 보상을 줄지 결정//
    public static int wdRewardGrade = 50;

    //새로운 페북 랭크가 시작되었는지 확인한다//
    public static bool isNewFbRank = false;

    //새로운 월드 랭크가 시작되었는지 확인한다//
    public static bool isNewWdRank = false;

    //페북 랭킹에 들었을 경우 받는 리워드 정보//
    public static MessageDataS fbReward;

    //월드 랭킹에 들었을 경우 받는 리워드 정보//
    public static MessageDataS[] wdReward;

    //포털 레벨을 저장하기 위해 만든 변수 0부터 시작함//
    public static int portalUpLevel;

    public static int inviteCount;

    public static int maxInvite = 10;

    public static int destinyCardNumber = 0;

    public static bool isOneMoreWin = false;


    //페북 로그아웃후 재로그인하는 상황일때 닉네임 입력창을 안나타나게 하기 위해 생성한 불린 변수//
    //변수값이 true이면 창이 나오지 않게 해준다//
    //변수값이 true가 되는 경우는 intro에서 모든 데이터를 로드후 hangar로 넘어갈때 true로 변경해준다//
    public static bool AlreadyAppStart = false;






    public static void ResetValue(bool forFbLogin = false)
    {
        PlayerPrefs.SetInt("isTutComplete", 2);
        saveCount = 0;
        fuelSendTime = "";
        isVerCheckFaild = false;
        gameData = null;
        rankDataFB = null;
        worldRank = null;
        messageData = null;
        messageSend = new MessageDataS();
        logInAlready = false;
        flightNumber = 0; //기본은 0(포커)
        skinNumber = 0;   //기본은 0(기능없는 스킨)
        resultSkinnumber = -1;
        skinLevel = 1;
        bulletLevel = 1; //기본은 1.
        bombRecycle = 60;	//기본은 60.
        skillLevel = 1;   //기본은 1.
        scorePlay = 0;    //기본값은 0//
        scoreResult = 0;
        portalUpScore = 0;
        coinPlay = 0;
        isHigh = false;      //최고점수 상태에 도달 했는지 여부 확인.
        dartCountTemp = 0;
        dustCountTemp = 0;
        shieldCountTemp = 0;
        spinballCountTemp = 0;
        gameEndResult = false;   //기본은 false. 결과창 테스트를 위해선 true로 바꾸어야 됨.
        isResultToHanger = false;
        alreadyRoadPhpData = false;
        isTableGet = false;
        medalPlay = 0;
        oldTime = 0;
        skinExp = 0;  //활성화된 비행기가 인게임에서 얻는 스킨 경험치를 임시 저장하는 변수.
        purchaseCharge = 0;
        SelectedItem = null;
        SelectedItemSprite = "";
        shieldEquip = false;
        fuelSize = 100;  //기본이 100//
        fuelSizeOri = 100;
        bombSpriteName = null;
        reinforceSpriteName = null;
        assistSpriteName = null;
        operSpriteName = null;
        enemyInGame = new List<GameObject>();
        flightAttackPower = 0f;
        flightAttackSpeed = 0f;
        targetUfoType = 0;
        isCriticalExel = false; //임시로 TRUE로 변경.
        dartApearPer = 2500;  //2500
        dustApearPer = 5000;  //5000
        spinballApearPer = 7500;  //7500
        isSpecialAnimation = false;  //원랜 false.
        detectorType = -1; //원래 -1.
        wingboxDouble = false;
        addFlightExp = 0;
        plasmaWaveCoolTime = 0;
        addAttackAbility = 0;
        itemReinforce08Effect = 0f;
        increaseBombAttackPercent = 0f; //핵폭탄 사용시 공격력 증가 시간 설정 변수.
        increaseBombAttackPercentInGame = 0f;
        increaseBombAttackTime = 0;
        isIncreaseBombAttackPercent = false;
        increaseScorePercent = 0f;
        isIncreaseScorePercent = false;
        shieldDestroyAddScorePercent = 0f;
        powerUpDropChance = 0;	// 1/10000 확률료 표시할것.
        powerUpAttackIncreaseTime = 0f;
        AttackPowerPercent = 0f;
        AttackPowerPercentTemp = 0f;
        isdamageAddChance = false;
        damageAddChance = 0;	// 1/10000 확률료 표시할것.
        damageAddPercent = 0f;
        coinAddChance = 0; // 1/10000 확률료 표시할것.
        coinAddNumber = 1;
        rechargeEnergy = 0;
        isBombRechargeDecrease = false;
        isBombRechargeDecreaseTemp = false;
        isBombToSkillGageIncrease = false;
        bombRechargeDecrease = 0f;	//시간(초).
        addSkillGagePercent = 0;	// 1/10000 확률료 표시할것.
        scoreIncreasePercent = 0f;
        comancheDeveilBreathAddSpeed = 0f;
        spinballDamagePercent = 0f;
        specialBombRechargeDecrease = 0f;	//시간(초).
        wingboxAddtime = 0f;
        friendFlightAddTime = 0f;
        applyPortalLevel = 0;
        bombTimeDecrease = 0f;
        nowPortalLevel = 1;
        isSelectSpecial = false;
        specialSpeed = 1.5f;
        flight000BombUseNumberTemp = 0;   //Flight000Skin003//
        flight001EnemyKillTemp = 0;      //Flight001Skin001//
        flight001GetCoinTemp = 0;        //Flight001Skin002//
        flight001UseSkillTemp = 0;        //Flight001Skin003//
        flight001GetPowerItemTemp = 0;    //Flight001Skin004//
        flight002KillSpinballTemp = 0;    //Flight002Skin001//
        flight002CompleteInstanceMissionTemp = 0; //Flight002Skin003//
        flight002RescueFriendTemp = 0;    //Flight002Skin004//
        isSkinMedalCostLoad = true;
        isGoldPriceLoad = true;
        isGasPriceLoad = true;
        isMedalPriceLoad = true;
        isDuraCostLoad = true;

        flightWindowPosition = 0;
        saleItem01 = "";    //할인판매창에서 쓰이는 변수들.//
        saleItem02 = "";    //할인판매창에서 쓰이는 변수들.//
        saleItem03 = "";    //할인판매창에서 쓰이는 변수들.//
        salePriceInt = 0;
        isCharacterSound = false;
        isKakaoUpdate = false;
        isGetFriend = false;
        isMessageLoad = false;
        comboTime = 2f;
        isBreakGame = false;
        rescueFriendId = "";
        rescueArlamFriendNick = "";
        rescueArlamFriendId = "";
        rescueFriendBlock = false;
        isSendRescueArlamNum = -1;
        isArlamRescue = false;
        isBgSound = true;
        isFxSound = true;
        isArlamMessage = true;
        logoutCount = 0;
        isTutComplete = 2;    //2월 28일 서버에 넣어야 될 데이터 기본값은 0이며 튜토리얼 완료시 서버에 2로 저장.
        skin00_04Effect = 0;
        itemMagnetEffect = 0f;
        Item04Effect = 0;
        skin02_03Effect = 1f;
        skin02_04Effect = 0f;
        skin02_05Effect1 = 0f;
        skin02_05Effect2 = 1f;
        invitedFriendTab = null;
        appFriendsUserId = "";
        AllMessageCount = 0;
        RescuedFriendCount = 0;
        isNoEnd = false;
        isPcExplo = false;   //true면 파괴된 상태 // false면 정상비행상태//

        if (forFbLogin == false)
        {
            Nick = "";
            UserID = "";
        }
        scoreHigh = 0;
        lastScoreHigh = 0;
        coinRest = 0;
        medalRest = 0;
        highFlight = 0;
        highSkin = 0;
        highChar = 0;
        highBullet = 1;
        highBomb = 0;
        highReinforce = 0;
        highAssist = 0;
        dartCount = 0;
        dustCount = 0;
        shieldCount = 0;
        spinballCount = 0;
        gasRest = 0;
        gasMax = 5;   //가스 최대치.  
        userLevel = 0;
        userExp = 0;
        flight000Skin = 0;
        flight000Bullet = 1;
        flight000Skill = 1;
        flight001Skin = 0;
        flight001Bullet = 1;
        flight001Skill = 1;
        flight002Skin = 0;
        flight002Bullet = 1;
        flight002Skill = 1;
        FlightExp000Skin001 = 0;
        FlightExp000Skin002 = 0;
        FlightExp000Skin003 = 0;
        FlightExp000Skin004 = 0;
        FlightExp000Skin005 = 0;
        FlightExp001Skin001 = 0;
        FlightExp001Skin002 = 0;
        FlightExp001Skin003 = 0;
        FlightExp001Skin004 = 0;
        FlightExp001Skin005 = 0;
        FlightExp002Skin001 = 0;
        FlightExp002Skin002 = 0;
        FlightExp002Skin003 = 0;
        FlightExp002Skin004 = 0;
        FlightExp002Skin005 = 0;
        FlightLev000Skin001 = 1;
        FlightLev000Skin002 = 1;
        FlightLev000Skin003 = 1;
        FlightLev000Skin004 = 1;
        FlightLev000Skin005 = 1;
        FlightLev001Skin001 = 1;
        FlightLev001Skin002 = 1;
        FlightLev001Skin003 = 1;
        FlightLev001Skin004 = 1;
        FlightLev001Skin005 = 1;
        FlightLev002Skin001 = 1;
        FlightLev002Skin002 = 1;
        FlightLev002Skin003 = 1;
        FlightLev002Skin004 = 1;
        FlightLev002Skin005 = 1;
        FlightDura000Skin001 = 10;
        FlightDura000Skin002 = 10;
        FlightDura000Skin003 = 10;
        FlightDura000Skin004 = 10;
        FlightDura000Skin005 = 10;
        FlightDura001Skin001 = 10;
        FlightDura001Skin002 = 10;
        FlightDura001Skin003 = 10;
        FlightDura001Skin004 = 10;
        FlightDura001Skin005 = 10;
        FlightDura002Skin001 = 10;
        FlightDura002Skin002 = 10;
        FlightDura002Skin003 = 10;
        FlightDura002Skin004 = 10;
        FlightDura002Skin005 = 10;
        EquipBomb01 = 5;
        EquipBomb02 = 0;
        EquipBomb03 = 0;
        EquipBomb04 = 0;
        EquipBomb05 = 0;
        EquipBomb06 = 0;
        EquipBomb07 = 0;
        EquipBomb08 = 0;
        EquipBomb09 = 0;
        EquipBomb10 = 0;
        EquipBomb11 = 0;
        EquipBomb12 = 0;
        EquipReinforce01 = 0;
        EquipReinforce02 = 0;
        EquipReinforce03 = 0;
        EquipReinforce04 = 0;
        EquipReinforce05 = 0;
        EquipReinforce06 = 0;
        EquipReinforce07 = 0;
        EquipReinforce08 = 0;
        EquipReinforce09 = 0;
        EquipReinforce10 = 0;
        EquipReinforce11 = 0;
        EquipReinforce12 = 0;
        EquipAssist01 = 5;
        EquipAssist02 = 0;
        EquipAssist03 = 0;
        EquipAssist04 = 0;
        EquipAssist05 = 0;
        EquipAssist06 = 0;
        EquipAssist07 = 0;
        EquipAssist08 = 0;
        EquipAssist09 = 0;
        EquipAssist10 = 0;
        EquipAssist11 = 0;
        EquipAssist12 = 0;
        EquipOper01 = 0;
        EquipOper02 = 0;
        EquipOper03 = 0;
        EquipOper04 = 0;
        EquipOper05 = 0;
        EquipOper06 = 0;
        EquipOper07 = 0;
        EquipOper08 = 0;
        EquipOper09 = 0;
        EquipOper10 = 0;
        EquipOper11 = 0;
        EquipOper12 = 0;
        activeBomb = 5;
        activeReinforce = 0;
        activeAssist = 0;
        activeOper = 1;
        isSpecialAttackMissionSelect = 0;
        specialAttackType = 0;
        isSpecialAttackComplete = 0;
        specialEndTime = "";
        specialAttackItemName = "";
        specialAttackItemMaxNumber = 0;   //서버나 로컬에 저장 안함//
        gasLastAddTime = "";
        gasNextAddTime = "";
        timeRecord = 0;   //이미 로컬에 저장했음//
        flight000SortieNumber = 0;
        flight000BombUseNumber = 0;
        flight000ScoreHigh = 0;
        flight001EnemyKill = 0;
        flight001GetCoin = 0;
        flight001UseSkill = 0;
        flight001GetPowerItem = 0;
        flight002KillSpinball = 0;
        flight002SpecialAttack = 0;
        flight002CompleteInstanceMission = 0;
        flight002RescueFriend = 0;
        flight002WormLevel5 = 0;
        FlightLock000Skin001 = 0;
        FlightLock000Skin002 = 0;
        FlightLock000Skin003 = 0;
        FlightLock000Skin004 = 0;
        FlightLock000Skin005 = 0;
        FlightLock001Skin001 = 0;
        FlightLock001Skin002 = 0;
        FlightLock001Skin003 = 0;
        FlightLock001Skin004 = 0;
        FlightLock001Skin005 = 0;
        FlightLock002Skin001 = 0;
        FlightLock002Skin002 = 0;
        FlightLock002Skin003 = 0;
        FlightLock002Skin004 = 0;
        FlightLock002Skin005 = 0;
        FlightLockOff000 = 2;
        FlightLockOff001 = 0;
        FlightLockOff002 = 0;
        FlightLockOff001Coin = 29000;
        FlightLockOff002Coin = 36000;
        FlightLockOff001Medal = 49;
        FlightLockOff002Medal = 59;
        damagePerUpoint = 2;
        fRatePerUpoint = 0.1f;
        speedPerUpoint = 0.2f;
        fuelPerUpoint = 5;
        isFirstAccess = 0;
        upgradePoint = 0;
        upgradePointF00P01 = 0;
        upgradePointF00P02 = 0;
        upgradePointF00P03 = 0;
        upgradePointF00P04 = 0;
        upgradePointF01P01 = 0;
        upgradePointF01P02 = 0;
        upgradePointF01P03 = 0;
        upgradePointF01P04 = 0;
        upgradePointF02P01 = 0;
        upgradePointF02P02 = 0;
        upgradePointF02P03 = 0;
        upgradePointF02P04 = 0;
        pointResetCount = 0;
        FriendRequestCount = 0;
        invitedFriendCount = 0;
        buddyPoint = 0;
        myFBid = "";
        myFBName = "";
        friendJsonAll = "";
        myPic = null;
        fRankDefaultTime = (new System.DateTime(2014, 11, 17).ToUniversalTime().ToBinary()).ToString();
        wRankDefaultTime = (new System.DateTime(2014, 11, 17).ToUniversalTime().ToBinary()).ToString();
        fRankInterDay = 1;
        wRankInterDay = 1;
        myRewardTime = "0";
        myFbRank = 0;
        myWdRank = 0;
        fbRewardGrade = 3;
        wdRewardGrade = 50;
        isNewFbRank = false;
        isNewWdRank = false;
        fbReward = new MessageDataS(); ;
        wdReward = null;
        portalUpLevel = 0;
        inviteCount = 0;
        maxInvite = 10;
        destinyCardNumber = 0;
        isOneMoreWin = false;
    }
}