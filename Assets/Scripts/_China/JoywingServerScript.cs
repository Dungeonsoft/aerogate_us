using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Security;
using MiniJSON;

using MyDelegateNS;


public class JoywingServerScript : MonoBehaviour
{
    //서버에 최초 로그인을 하면서 받아온 UserID를 기록하는 변수. 
    //AfterReceiveUserIdData를 호출하기전에 먼저 UserID를 선 기록한다.
    private string secretKey = "12345";
    public string wwwResult;
    public string CheckFBidUrl = "http://leessoda.cafe24.com/US/login_unique.php";
    public string FindUserInfoUrl = "http://leessoda.cafe24.com/US/get_useruninumber.php";
    public string DelUserInfoUrl = "http://leessoda.cafe24.com/US/del_userunique.php";
    public string VersionUrl = "http://leessoda.cafe24.com/US/ver_check.php";
    public string GetUserNumberUrl = "http://leessoda.cafe24.com/US/get_useruninumber.php";
    public string InsertUserInfoUrl = "http://leessoda.cafe24.com/US/record_newid.php";
    public string InsertUserRangkingUrl = "http://leessoda.cafe24.com/US/insert_newranking.php";
    public string InsertGameInfoUrl = "http://leessoda.cafe24.com/US/insert_newgameinfo.php";
    public string InsertItemInfoUrl = "http://leessoda.cafe24.com/US/insert_newiteminfo.php";
    public string InsertFlightInfoUrl = "http://leessoda.cafe24.com/US/insert_newflightinfo.php";
    public string InsertMailInfoUrl = "http://leessoda.cafe24.com/US/insert_newmailinfo.php";
    public string InsertUserPurchaseUrl = "http://leessoda.cafe24.com/US/record_newpurchase.php";
    public string GetUserDataUrl = "http://leessoda.cafe24.com/US/userinfo.php";
    public string GetGameInfoUrl = "http://leessoda.cafe24.com/US/get_gameinfo.php";
    public string GetItemInfoUrl = "http://leessoda.cafe24.com/US/get_iteminfo.php";
    public string GetFlightInfoUrl = "http://leessoda.cafe24.com/US/get_flightinfo.php";
    public string GetRankingDataUrl = "http://leessoda.cafe24.com/US/get_rankinginfo.php";
    public string GetFriendsDataUrl = "http://leessoda.cafe24.com/US/get_friendsinfo.php";
    public string GetWorldRankingUrl = "http://leessoda.cafe24.com/US/get_worldranking.php";
    public string UpdateFbidUrl = "http://leessoda.cafe24.com/US/update_fbid.php";
    public string GetMailInfoUrl = "http://leessoda.cafe24.com/US/get_mailinfo.php";
    public string GetGiftInfoUrl = "http://leessoda.cafe24.com/US/get_giftinfo.php";


    public int userInitialize = 0;
    public string userUniNumber;
    public int groupNumber;
    public string userUnique;

    public GameObject ServerPopUp;
    public GameObject ServerManager;
    public GameObject verCheckWindow;
    public GameObject verCheckLabel;
    public GameObject loadingText;

    public string inputNickFromLabel;
    float ServerConnectionTimeout = 15.0f;

    //아래 메소드의 이름은 타 클래스 내에서 쓰이고 있으므로 임의로 바꾸어선 안된다.
    //아래 메소드를 호출함으로써 조이윙서버에 데이터를 저장하는 활동이 시작된다.


    //void Awake()
    //{
    //    PlayerPrefs.DeleteAll();
    //}

    public void SendNickData(string inputNick)
    {
        //이 메소드를 시점으로 하여 서버에 닉네임을 저장하는 코드를 기술한다.
        //서버에 데이터 저장 코드 입력.
        ServerPopUp.SetActive(false);
        StartCoroutine(StartNewIDInsert(inputNick));
    }

    public void SetStart()
    {
        Debug.Log("Start Here!!~~!!!!!!!!!!!!");
    }

    void Start()
    {
        //StartCoroutine(CheckUserUnique());
        if (Application.internetReachability == 0)
        {
            Debug.Log("Internet Nonnection has been Lost!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        //StartCoroutine(GetFriendsData());
    }

    public bool isStartGetData = false;
    //서버에서 유저넘버로 사용자의 모든 정보를 불러올때 호출.
    public IEnumerator StartGetData()
    {
        if (isStartGetData == false)
        {
            isStartGetData = true;
            Debug.Log("여기서 페북친구 정보를 페북에서 부른다.");
            GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().CAPI_BuddyInfo(true);

            //아래 내용을 주석처리하고 코루틴 메서드가 작동하도록 만들기 위해 넣은 코드(작성자 : 류용근)//
            yield return null;
            //yield return StartCoroutine(GetGameInfo());

            //yield return StartCoroutine(GetItemInfo());

            //yield return StartCoroutine(GetFlightInfo());

            //yield return StartCoroutine(GetRankingData());

            //yield return StartCoroutine(GetWorldRanking());
        }

    }

    public IEnumerator StartGetData2()
    {
        Debug.Log("StartGetData2 옴1?");
        yield return StartCoroutine(GetComponent<GetGameData>().GetRankResetTime());
        Debug.Log("StartGetData2 옴2?");
        yield return StartCoroutine(GetGameInfo());
        Debug.Log("StartGetData2 옴3?");
        yield return StartCoroutine(GetItemInfo());
        Debug.Log("StartGetData2 옴4?");
        yield return StartCoroutine(GetFlightInfo());
        Debug.Log("StartGetData2 옴5?");
        yield return StartCoroutine(GetRankingData());
        Debug.Log("StartGetData2 옴6?");
        yield return StartCoroutine(GetMailInfo());
        Debug.Log("StartGetData2 옴7?");
        yield return StartCoroutine(GetGiftInfo());
        Debug.Log("StartGetData2 옴8?");
        yield return StartCoroutine(GetWorldRanking());

        Debug.Log("StartGetData2 옴?완료!!!");
    }

    //처음 접속하는 유저가 아이디를 생성할때 호출.
    public IEnumerator StartNewIDInsert(string inputNick)
    {
        yield return StartCoroutine(NewIDInsert(inputNick));
    }

    //서버에서 fb 아이디를 기반으로 정보를 받아오는 메소드.
    public IEnumerator CheckUserFBid()
    {
        string fbid = GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().myFBid;
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        yield return null;

        WWWForm form = new WWWForm();

        form.AddField("FBid", fbid);
        form.AddField("hash", hash);

        WWW www = new WWW(CheckFBidUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }

        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "First Login User")
            {
                Debug.Log("User Not Exits!!!!!!!!!!!!!!!!!");
                Debug.Log(wwwResult);
                //첫 로그인 사용자이기 때문에 유저 닉네임을 적는 창을 띄운다.//
                    GameObject.Find("AfterInitialObject").GetComponent<AfterInitialScript>().EnterNickWin();
            }
            else if (wwwResult == "hashFalse")
            {
                Debug.Log(wwwResult);
                ServerPopUp.SetActive(true);
            }
            else if (wwwResult == "Login Fail")
            {
                Debug.Log(wwwResult);
                ServerPopUp.SetActive(true);
            }
            else
            {

                ValueDeliverScript.UserID = www.text;

                Debug.Log(":::: UserPK ::::" + ValueDeliverScript.UserID);

                userUniNumber = ValueDeliverScript.UserID;

                Debug.Log("CheckUserFBid 메서드 인가?");

                if (isStartGetData == false)
                {
                    Debug.Log("CheckUserFBid 메서드 인가?22222");
                    yield return StartCoroutine(StartGetData());
                }
                AfterReceiveUserIdData();

                //start

                //*****************여기에 다음씬으로 넘어가는거 처리***********************//
            }
        }
    }

    public IEnumerator NewIDInsert(string inputNick)
    {
        inputNickFromLabel = inputNick;
        string fbid = GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().myFBid;
        string userunique = DateTime.UtcNow.Ticks.ToString();
        PlayerPrefs.SetString("UserUnique", userunique);
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("User_name", ValueDeliverScript.Nick);
        form.AddField("User_Unique", userunique);
        form.AddField("FBid", fbid);
        form.AddField("hash", hash);

        WWW www = new WWW(InsertUserInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Debug.Log(www.error);
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "NewIDUpdateSuccess")
            {
                Debug.Log(wwwResult);
                StartCoroutine(GetUserNumber());
            }
            else
            {
                Debug.Log(wwwResult);
                Debug.Log("NewIDUpdate Failed !!!!!!!!!!!!!!!!");
            }
        }
    }

    public IEnumerator GetUserNumber()
    {
        string userunique = PlayerPrefs.GetString("UserUnique");
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("User_Unique", userunique);
        form.AddField("hash", hash);

        WWW www = new WWW(GetUserNumberUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;
            ValueDeliverScript.UserID = www.text;
            PlayerPrefs.SetString("UserId", www.text);  //폰 내부에 아이디 저장.
            PlayerPrefs.SetString("Nick", ValueDeliverScript.Nick); //폰 내부에 닉네임 저장.

            Debug.Log(":::: UserId ::::" + ValueDeliverScript.UserID);
            Debug.Log(":::: Nick ::::" + ValueDeliverScript.Nick);

            userUniNumber = ValueDeliverScript.UserID;

            StartCoroutine(NewGameInfoInsert());

        }
    }


    public IEnumerator NewGameInfoInsert()
    {
        string userUnique = SystemInfo.deviceUniqueIdentifier;
        string fbid = GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().myFBid;
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("User_number", userUniNumber);
        form.AddField("User_name", inputNickFromLabel);
        form.AddField("FBid", fbid);
        form.AddField("hash", hash);

        WWW www = new WWW(InsertGameInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "NewGameInfoSuccess")
            {
                Debug.Log(wwwResult);
                StartCoroutine(NewItemInfoInsert());
            }
            else
            {
                Debug.Log(wwwResult);
                Debug.Log("NewGameInfoInsert Failed !!!!!!!!!!!!!!!!");
            }
        }
    }

    public IEnumerator NewItemInfoInsert()
    {
        string userUnique = SystemInfo.deviceUniqueIdentifier;
        string fbid = GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().myFBid;
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("User_number", userUniNumber);
        form.AddField("User_name", inputNickFromLabel);
        form.AddField("FBid", fbid);
        form.AddField("hash", hash);

        WWW www = new WWW(InsertItemInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "NewItemInfoSuccess")
            {
                Debug.Log(wwwResult);
                StartCoroutine(NewFlightInfoInsert());
            }
            else
            {
                Debug.Log(wwwResult);
                Debug.Log("NewItemInfoInsert Failed !!!!!!!!!!!!!!!!");
            }
        }
    }

    public IEnumerator NewFlightInfoInsert()
    {
        string userUnique = SystemInfo.deviceUniqueIdentifier;
        string fbid = GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().myFBid;
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("User_number", userUniNumber);
        form.AddField("User_name", inputNickFromLabel);
        form.AddField("FBid", fbid);
        form.AddField("hash", hash);

        WWW www = new WWW(InsertFlightInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "NewFlightInfoSuccess")
            {
                Debug.Log(wwwResult);

                StartCoroutine(NewMailInfoInsert());

            }
            else
            {
                Debug.Log(wwwResult);
                Debug.Log("NewItemInfoInsert Failed !!!!!!!!!!!!!!!!");
            }
        }
    }

    public IEnumerator NewMailInfoInsert()
    {
        string fbid = GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().myFBid;
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("User_number", userUniNumber);
        form.AddField("User_name", inputNickFromLabel);
        form.AddField("FBid", fbid);
        form.AddField("hash", hash);

        WWW www = new WWW(InsertMailInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "MailInfoInsertSuccess")
            {
                Debug.Log(wwwResult);

                StartCoroutine(NewIRecordRanking());

            }
            else
            {
                Debug.Log(wwwResult);
                Debug.Log(www.error);
                Debug.Log("NewMailInfoInsert Failed !!!!!!!!!!!!!!!!");
            }
        }
    }

    public IEnumerator NewIRecordRanking()
    {
        userUniNumber = ValueDeliverScript.UserID;
        string hash = Md5Sum(secretKey).ToLower();
        string fbid = GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().myFBid;
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("User_number", userUniNumber);
        form.AddField("User_name", ValueDeliverScript.Nick);
        form.AddField("FBid", fbid);
        form.AddField("hash", hash);

        WWW www = new WWW(InsertUserRangkingUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "NewRankingSuccess")
            {
                Debug.Log(wwwResult);

                StartCoroutine(GameObject.Find("AfterInitialObject").GetComponent<AfterInitialScript>().LoadMyDataNRank());
            }
            else
            {
                Debug.Log(wwwResult);
                Debug.Log("RankingUpdate Failed !!!!!!!!!!!!!!!!");
                ServerPopUp.SetActive(true);
            }
        }

    }

    IEnumerator NewIRecordPurchase()
    {
        Debug.Log("inputNickFromLabel  :::::::   " + inputNickFromLabel);
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;
        //newIDWindow.SetActive(false);
        yield return new WaitForSeconds(0.2f);

        WWWForm form = new WWWForm();

        form.AddField("User_number", userUniNumber);
        form.AddField("hash", hash);

        WWW www = new WWW(InsertUserPurchaseUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "UserPurchaseUpdateSuccess")
            {
                Debug.Log(wwwResult);
            }
            else
            {
                Debug.Log(wwwResult);
                Debug.Log("UserPurchaseUpdate Failed !!!!!!!!!!!!!!!!");
            }
        }

    }

    public IEnumerator UpdateFBid(UsercheckDele NextMethod)
    {
        Debug.Log(":::::::: UpdateFBid ::: myFBid ::: ");
        Debug.Log(":::::::: UpdateFBid ::: myFBid ::: ");
        Debug.Log(":::::::: UpdateFBid ::: myFBid ::: ");
        Debug.Log(":::::::: UpdateFBid ::: myFBid ::: " + ValueDeliverScript.myFBid);
        Debug.Log(":::::::: UpdateFBid ::: UserID ::: " + ValueDeliverScript.UserID);

        userUniNumber = ValueDeliverScript.UserID; // 유저넘버를 입력.
        string hash = Md5Sum(secretKey).ToLower();
        string fbid = ValueDeliverScript.myFBid; // 이곳에 새로 입력된 페이스북 아이디를 넣는다.
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("User_number", userUniNumber);
        form.AddField("FBid", fbid);
        form.AddField("hash", hash);

        WWW www = new WWW(UpdateFbidUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);

        }
        else
        {
            wwwResult = www.text;

            if (wwwResult == "FBidUpdateSuccess")
            {
                Debug.Log(wwwResult);
                NextMethod();

            }
            else
            {
                Debug.Log(wwwResult);
                Debug.Log("FBidUpdate Failed !!!!!!!!!!!!!!!!");
                ServerPopUp.SetActive(true);
            }
        }
    }

    IEnumerator GetGroup()
    {
        yield return null;
        userUniNumber = ValueDeliverScript.UserID;
        //groupNumber = userUniNumber / 50 + 1;   //그룹넘버//
    }

    public IEnumerator GetUserInfo()
    {
        userUniNumber = ValueDeliverScript.UserID;
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("hash", hash);

        WWW www = new WWW(GetUserDataUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;
            Debug.Log(wwwResult);
        }

    }

    public bool isGetGameInfo = false;
    public IEnumerator GetGameInfo()
    {
        userUniNumber = ValueDeliverScript.UserID;
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("hash", hash);

        WWW www = new WWW(GetGameInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;
            Debug.Log(wwwResult);
            Debug.Log(www.error);
            var gameinfo = SimpleJSON.JSON.Parse(wwwResult);
            Debug.Log("CoinRest IS Here!!!!!!!!!!!!!!!!!" + ValueDeliverScript.coinRest);

            Debug.Log("Game Info ::: " + gameinfo);
            ValueDeliverScript.Nick = gameinfo["GameInfo_UserNick"][0]["UserNick"];
            ValueDeliverScript.gasRest = int.Parse(gameinfo["GameInfo_Gas"][0]["Gas"]);
            ValueDeliverScript.gasLastAddTime = gameinfo["GameInfo_LastTime"][0]["LastTime"];
            ValueDeliverScript.gasNextAddTime = gameinfo["GameInfo_NextTime"][0]["NextTime"];
            ValueDeliverScript.coinRest = int.Parse(gameinfo["GameInfo_Coin"][0]["Coin"]);
            ValueDeliverScript.medalRest = int.Parse(gameinfo["GameInfo_Medal"][0]["Medal"]);
            ValueDeliverScript.userExp = int.Parse(gameinfo["GameInfo_Exp"][0]["Exp"]);
            ValueDeliverScript.buddyPoint = int.Parse(gameinfo["GameInfo_FSPoint"][0]["FSPoint"]);
            ValueDeliverScript.upgradePoint = int.Parse(gameinfo["GameInfo_UpPoint"][0]["UpPoint"]);
            ValueDeliverScript.pointResetCount = int.Parse(gameinfo["GameInfo_PointReset"][0]["PointReset"]);

            Debug.Log("Coin ===>  " + gameinfo["GameInfo_Coin"][0]["Coin"]);
            Debug.Log("LastTime ===>  " + gameinfo["GameInfo_LastTime"][0]["LastTime"]);
            Debug.Log("NextTime ===>  " + gameinfo["GameInfo_NextTime"][0]["NextTime"]);
            Debug.Log("Medal ===> " + gameinfo["GameInfo_Medal"][0]["Medal"]);
            Debug.Log("Exp ===> " + gameinfo["GameInfo_Exp"][0]["Exp"]);
            Debug.Log("FSPoint ===> " + gameinfo["GameInfo_FSPoint"][0]["FSPoint"]);
            Debug.Log("UpPoint ===> " + gameinfo["GameInfo_UpPoint"][0]["UpPoint"]);
            Debug.Log("PointReset ===> " + gameinfo["GameInfo_PointReset"][0]["PointReset"]);

            isGetGameInfo = true;
        }
    }
    public bool isGetItemInfo = false;
    public IEnumerator GetItemInfo()
    {
        userUniNumber = ValueDeliverScript.UserID;//여기에 유저아이디 입력.
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("hash", hash);

        WWW www = new WWW(GetItemInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;
            Debug.Log(wwwResult);
            var iteminfo = SimpleJSON.JSON.Parse(wwwResult);

            ValueDeliverScript.EquipBomb01 = int.Parse(iteminfo["ItemInfo_Bomb"][0]["Plasma"]);
            ValueDeliverScript.EquipBomb05 = int.Parse(iteminfo["ItemInfo_Bomb"][0]["Blackhole"]);

            //Debug.Log("Nick ===>  " + iteminfo["ItemInfo_UserNick"][0]["UserNick"]);
            //Debug.Log("Bomb Plasma ===>  " + iteminfo["ItemInfo_Bomb"][0]["Plasma"]);
            //Debug.Log("Bomb Blackhole ===>  " + iteminfo["ItemInfo_Bomb"][0]["Blackhole"]);

            ValueDeliverScript.EquipReinforce01 = int.Parse(iteminfo["ItemInfo_Rein"][0]["SingleUp"]);
            ValueDeliverScript.EquipReinforce02 = int.Parse(iteminfo["ItemInfo_Rein"][0]["DoubleUp"]);
            ValueDeliverScript.EquipReinforce03 = int.Parse(iteminfo["ItemInfo_Rein"][0]["SkinballUp"]);
            ValueDeliverScript.EquipReinforce04 = int.Parse(iteminfo["ItemInfo_Rein"][0]["DartUp"]);
            ValueDeliverScript.EquipReinforce05 = int.Parse(iteminfo["ItemInfo_Rein"][0]["ShieldUp"]);
            ValueDeliverScript.EquipReinforce06 = int.Parse(iteminfo["ItemInfo_Rein"][0]["DustUp"]);
            ValueDeliverScript.EquipReinforce07 = int.Parse(iteminfo["ItemInfo_Rein"][0]["Critical"]);
            ValueDeliverScript.EquipReinforce08 = int.Parse(iteminfo["ItemInfo_Rein"][0]["MaxPower"]);

            //Debug.Log("Rein SingleUp ===> " + iteminfo["ItemInfo_Rein"][0]["SingleUp"]);
            //Debug.Log("Rein DoubleUp ===> " + iteminfo["ItemInfo_Rein"][0]["DoubleUp"]);
            //Debug.Log("Rein SkinballUp ===> " + iteminfo["ItemInfo_Rein"][0]["SkinballUp"]);
            //Debug.Log("Rein DartUp ===> " + iteminfo["ItemInfo_Rein"][0]["DartUp"]);
            //Debug.Log("Rein ShieldUp ===> " + iteminfo["ItemInfo_Rein"][0]["ShieldUp"]);
            //Debug.Log("Rein DustUp ===> " + iteminfo["ItemInfo_Rein"][0]["DustUp"]);
            //Debug.Log("Rein Critical ===> " + iteminfo["ItemInfo_Rein"][0]["Critical"]);
            //Debug.Log("Rein MaxPower ===> " + iteminfo["ItemInfo_Rein"][0]["MaxPower"]);

            ValueDeliverScript.EquipAssist01 = int.Parse(iteminfo["ItemInfo_Assist"][0]["Shield"]);
            ValueDeliverScript.EquipAssist02 = int.Parse(iteminfo["ItemInfo_Assist"][0]["Magnet"]);
            ValueDeliverScript.EquipAssist03 = int.Parse(iteminfo["ItemInfo_Assist"][0]["BombCool"]);
            ValueDeliverScript.EquipAssist04 = int.Parse(iteminfo["ItemInfo_Assist"][0]["SkillCool"]);
            ValueDeliverScript.EquipAssist05 = int.Parse(iteminfo["ItemInfo_Assist"][0]["WingBox"]);

            //Debug.Log("Assist Shield ===> " + iteminfo["ItemInfo_Assist"][0]["Shield"]);
            //Debug.Log("Assist Magnet ===> " + iteminfo["ItemInfo_Assist"][0]["Magnet"]);
            //Debug.Log("Assist BombCool ===> " + iteminfo["ItemInfo_Assist"][0]["BombCool"]);
            //Debug.Log("Assist SkillCool ===> " + iteminfo["ItemInfo_Assist"][0]["SkillCool"]);
            //Debug.Log("Assist WingBox ===> " + iteminfo["ItemInfo_Assist"][0]["WingBox"]);

            Debug.Log("Support Yoon ===> " + iteminfo["ItemInfo_Support"][0]["Yoon"]);
            ValueDeliverScript.EquipOper01 = int.Parse(iteminfo["ItemInfo_Support"][0]["Yoon"]);
            ValueDeliverScript.EquipOper02 = int.Parse(iteminfo["ItemInfo_Support"][0]["Aidan"]);
            ValueDeliverScript.EquipOper03 = int.Parse(iteminfo["ItemInfo_Support"][0]["Dan"]);
            ValueDeliverScript.EquipOper04 = int.Parse(iteminfo["ItemInfo_Support"][0]["Rechel"]);

            //Debug.Log("Support Yoon ===> " + iteminfo["ItemInfo_Support"][0]["Yoon"]);
            //Debug.Log("Support Aidan ===> " + iteminfo["ItemInfo_Support"][0]["Aidan"]);
            //Debug.Log("Support Dan ===> " + iteminfo["ItemInfo_Support"][0]["Dan"]);
            //Debug.Log("Support Rechel ===> " + iteminfo["ItemInfo_Support"][0]["Rechel"]);



            isGetItemInfo = true;
        }
    }

    public bool isGetFlightInfo = false;
    public IEnumerator GetFlightInfo()
    {
        userUniNumber = ValueDeliverScript.UserID;//여기에 유저아이디 입력.
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("hash", hash);

        WWW www = new WWW(GetFlightInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            yield return www.text;
            yield return wwwResult = www.text;
            Debug.Log(wwwResult);
            
            var flightinfo = SimpleJSON.JSON.Parse(wwwResult);
            Debug.Log(wwwResult);
            Debug.Log("Nick ===>  " + flightinfo["Flight_UserNick"][0]["UserNick"]);
            //선택된 기체 번호.
            ValueDeliverScript.flightNumber = int.Parse(flightinfo["Flight_Lock"][0]["AircraftSelect"]);
            ValueDeliverScript.FlightLockOff000 = int.Parse(flightinfo["Flight_Lock"][0]["FokkerLock"]);
            ValueDeliverScript.FlightLockOff001 = int.Parse(flightinfo["Flight_Lock"][0]["ComancheLock"]);
            ValueDeliverScript.FlightLockOff002 = int.Parse(flightinfo["Flight_Lock"][0]["PhantomLock"]);


            //Debug.Log("Flight_Lock AircraftSelect ===>  " + flightinfo["Flight_Lock"][0]["AircraftSelect"]);
            //Debug.Log("Flight_Lock FokkerLock ===>  " + flightinfo["Flight_Lock"][0]["FokkerLock"]);
            //Debug.Log("Flight_Lock ComancheLock ===>  " + flightinfo["Flight_Lock"][0]["ComancheLock"]);
            //Debug.Log("Flight_Lock PhantomLock ===>  " + flightinfo["Flight_Lock"][0]["PhantomLock"]);

            ValueDeliverScript.FlightLock000Skin001 = int.Parse(flightinfo["Flight_SkinLock"][0]["Fokker001"]);
            ValueDeliverScript.FlightLock000Skin002 = int.Parse(flightinfo["Flight_SkinLock"][0]["Fokker002"]);
            ValueDeliverScript.FlightLock000Skin003 = int.Parse(flightinfo["Flight_SkinLock"][0]["Fokker003"]);
            ValueDeliverScript.FlightLock000Skin004 = int.Parse(flightinfo["Flight_SkinLock"][0]["Fokker004"]);
            ValueDeliverScript.FlightLock000Skin005 = int.Parse(flightinfo["Flight_SkinLock"][0]["Fokker005"]);

            //Debug.Log("Flight_SkinLock Fokker001 ===>  " + flightinfo["Flight_SkinLock"][0]["Fokker001"]);
            //Debug.Log("Flight_SkinLock Fokker002 ===>  " + flightinfo["Flight_SkinLock"][0]["Fokker002"]);
            //Debug.Log("Flight_SkinLock Fokker003 ===>  " + flightinfo["Flight_SkinLock"][0]["Fokker003"]);
            //Debug.Log("Flight_SkinLock Fokker004 ===>  " + flightinfo["Flight_SkinLock"][0]["Fokker004"]);
            //Debug.Log("Flight_SkinLock Fokker005 ===>  " + flightinfo["Flight_SkinLock"][0]["Fokker005"]);

            ValueDeliverScript.FlightLock001Skin001 = int.Parse(flightinfo["Flight_SkinLock"][0]["Comanche001"]);
            ValueDeliverScript.FlightLock001Skin002 = int.Parse(flightinfo["Flight_SkinLock"][0]["Comanche002"]);
            ValueDeliverScript.FlightLock001Skin003 = int.Parse(flightinfo["Flight_SkinLock"][0]["Comanche003"]);
            ValueDeliverScript.FlightLock001Skin004 = int.Parse(flightinfo["Flight_SkinLock"][0]["Comanche004"]);
            ValueDeliverScript.FlightLock001Skin005 = int.Parse(flightinfo["Flight_SkinLock"][0]["Comanche005"]);

            //Debug.Log("Flight_SkinLock Comanche001 ===>  " + flightinfo["Flight_SkinLock"][0]["Comanche001"]);
            //Debug.Log("Flight_SkinLock Comanche002 ===>  " + flightinfo["Flight_SkinLock"][0]["Comanche002"]);
            //Debug.Log("Flight_SkinLock Comanche003 ===>  " + flightinfo["Flight_SkinLock"][0]["Comanche003"]);
            //Debug.Log("Flight_SkinLock Comanche004 ===>  " + flightinfo["Flight_SkinLock"][0]["Comanche004"]);
            //Debug.Log("Flight_SkinLock Comanche005 ===>  " + flightinfo["Flight_SkinLock"][0]["Comanche005"]);

            ValueDeliverScript.FlightLock002Skin001 = int.Parse(flightinfo["Flight_SkinLock"][0]["Phantom001"]);
            ValueDeliverScript.FlightLock002Skin002 = int.Parse(flightinfo["Flight_SkinLock"][0]["Phantom002"]);
            ValueDeliverScript.FlightLock002Skin003 = int.Parse(flightinfo["Flight_SkinLock"][0]["Phantom003"]);
            ValueDeliverScript.FlightLock002Skin004 = int.Parse(flightinfo["Flight_SkinLock"][0]["Phantom004"]);
            ValueDeliverScript.FlightLock002Skin005 = int.Parse(flightinfo["Flight_SkinLock"][0]["Phantom005"]);

            //Debug.Log("Flight_SkinLock Phantom001 ===>  " + flightinfo["Flight_SkinLock"][0]["Phantom001"]);
            //Debug.Log("Flight_SkinLock Phantom002 ===>  " + flightinfo["Flight_SkinLock"][0]["Phantom002"]);
            //Debug.Log("Flight_SkinLock Phantom003 ===>  " + flightinfo["Flight_SkinLock"][0]["Phantom003"]);
            //Debug.Log("Flight_SkinLock Phantom004 ===>  " + flightinfo["Flight_SkinLock"][0]["Phantom004"]);
            //Debug.Log("Flight_SkinLock Phantom005 ===>  " + flightinfo["Flight_SkinLock"][0]["Phantom005"]);

            ValueDeliverScript.upgradePointF00P01 = int.Parse(flightinfo["Flight_Upgrade"][0]["Fokker_PW"]);
            ValueDeliverScript.upgradePointF00P02 = int.Parse(flightinfo["Flight_Upgrade"][0]["Fokker_AS"]);
            ValueDeliverScript.upgradePointF00P03 = int.Parse(flightinfo["Flight_Upgrade"][0]["Fokker_MS"]);
            ValueDeliverScript.upgradePointF00P04 = int.Parse(flightinfo["Flight_Upgrade"][0]["Fokker_SK"]);

            //Debug.Log("Flight_Upgrade Fokker_PW ===>  " + flightinfo["Flight_Upgrade"][0]["Fokker_PW"]);
            //Debug.Log("Flight_Upgrade Fokker_AS ===>  " + flightinfo["Flight_Upgrade"][0]["Fokker_AS"]);
            //Debug.Log("Flight_Upgrade Fokker_MS ===>  " + flightinfo["Flight_Upgrade"][0]["Fokker_MS"]);
            //Debug.Log("Flight_Upgrade Fokker_SK ===>  " + flightinfo["Flight_Upgrade"][0]["Fokker_SK"]);

            ValueDeliverScript.upgradePointF01P01 = int.Parse(flightinfo["Flight_Upgrade"][0]["Comanche_PW"]);
            ValueDeliverScript.upgradePointF01P02 = int.Parse(flightinfo["Flight_Upgrade"][0]["Comanche_AS"]);
            ValueDeliverScript.upgradePointF01P03 = int.Parse(flightinfo["Flight_Upgrade"][0]["Comanche_MS"]);
            ValueDeliverScript.upgradePointF01P04 = int.Parse(flightinfo["Flight_Upgrade"][0]["Comanche_SK"]);

            //Debug.Log("Flight_Upgrade Comanche_PW ===>  " + flightinfo["Flight_Upgrade"][0]["Comanche_PW"]);
            //Debug.Log("Flight_Upgrade Comanche_AS ===>  " + flightinfo["Flight_Upgrade"][0]["Comanche_AS"]);
            //Debug.Log("Flight_Upgrade Comanche_MS ===>  " + flightinfo["Flight_Upgrade"][0]["Comanche_MS"]);
            //Debug.Log("Flight_Upgrade Comanche_SK ===>  " + flightinfo["Flight_Upgrade"][0]["Comanche_SK"]);

            ValueDeliverScript.upgradePointF02P01 = int.Parse(flightinfo["Flight_Upgrade"][0]["Phantom_PW"]);
            ValueDeliverScript.upgradePointF02P02 = int.Parse(flightinfo["Flight_Upgrade"][0]["Phantom_AS"]);
            ValueDeliverScript.upgradePointF02P03 = int.Parse(flightinfo["Flight_Upgrade"][0]["Phantom_MS"]);
            ValueDeliverScript.upgradePointF02P04 = int.Parse(flightinfo["Flight_Upgrade"][0]["Phantom_SK"]);

            //Debug.Log("Flight_Upgrade Phantom_PW ===>  " + flightinfo["Flight_Upgrade"][0]["Phantom_PW"]);
            //Debug.Log("Flight_Upgrade Phantom_AS ===>  " + flightinfo["Flight_Upgrade"][0]["Phantom_AS"]);
            //Debug.Log("Flight_Upgrade Phantom_MS ===>  " + flightinfo["Flight_Upgrade"][0]["Phantom_MS"]);
            //Debug.Log("Flight_Upgrade Phantom_SK ===>  " + flightinfo["Flight_Upgrade"][0]["Phantom_SK"]);

            ValueDeliverScript.flight000Bullet = int.Parse(flightinfo["Flight_Detail"][0]["Fokker_BulletLv"]);
            ValueDeliverScript.flight000Skill = int.Parse(flightinfo["Flight_Detail"][0]["Fokker_SkillLv"]);
            ValueDeliverScript.flight000Skin = int.Parse(flightinfo["Flight_Detail"][0]["Fokker_Skin"]);
            ValueDeliverScript.FlightDura000Skin001 = int.Parse(flightinfo["Flight_Detail"][0]["Fokker_DuraA"]);
            ValueDeliverScript.FlightExp000Skin001 = int.Parse(flightinfo["Flight_Detail"][0]["Fokker_ExpA"]);
            ValueDeliverScript.FlightDura000Skin002 = int.Parse(flightinfo["Flight_Detail"][0]["Fokker_DuraB"]);
            ValueDeliverScript.FlightExp000Skin002 = int.Parse(flightinfo["Flight_Detail"][0]["Fokker_ExpB"]);
            ValueDeliverScript.FlightDura000Skin003 = int.Parse(flightinfo["Flight_Detail"][0]["Fokker_DuraC"]);
            ValueDeliverScript.FlightExp000Skin003 = int.Parse(flightinfo["Flight_Detail"][0]["Fokker_ExpC"]);
            ValueDeliverScript.FlightDura000Skin004 = int.Parse(flightinfo["Flight_Detail"][0]["Fokker_DuraD"]);
            ValueDeliverScript.FlightExp000Skin004 = int.Parse(flightinfo["Flight_Detail"][0]["Fokker_ExpD"]);
            ValueDeliverScript.FlightDura000Skin005 = int.Parse(flightinfo["Flight_Detail"][0]["Fokker_DuraE"]);
            ValueDeliverScript.FlightExp000Skin005 = int.Parse(flightinfo["Flight_Detail"][0]["Fokker_ExpE"]);

            //Debug.Log("Flight_Detail Fokker_BulletLv ===>  " + flightinfo["Flight_Detail"][0]["Fokker_BulletLv"]);
            //Debug.Log("Flight_Detail Fokker_SkillLv ===>  " + flightinfo["Flight_Detail"][0]["Fokker_SkillLv"]);
            //Debug.Log("Flight_Detail Fokker_Skin ===>  " + flightinfo["Flight_Detail"][0]["Fokker_Skin"]);
            //Debug.Log("Flight_Detail Fokker_DuraA ===>  " + flightinfo["Flight_Detail"][0]["Fokker_DuraA"]);
            //Debug.Log("Flight_Detail Fokker_ExpA ===>  " + flightinfo["Flight_Detail"][0]["Fokker_ExpA"]);
            //Debug.Log("Flight_Detail Fokker_DuraB ===>  " + flightinfo["Flight_Detail"][0]["Fokker_DuraB"]);
            //Debug.Log("Flight_Detail Fokker_ExpB ===>  " + flightinfo["Flight_Detail"][0]["Fokker_ExpB"]);
            //Debug.Log("Flight_Detail Fokker_DuraC ===>  " + flightinfo["Flight_Detail"][0]["Fokker_DuraC"]);
            //Debug.Log("Flight_Detail Fokker_ExpC ===>  " + flightinfo["Flight_Detail"][0]["Fokker_ExpC"]);
            //Debug.Log("Flight_Detail Fokker_DuraD ===>  " + flightinfo["Flight_Detail"][0]["Fokker_DuraD"]);
            //Debug.Log("Flight_Detail Fokker_ExpD ===>  " + flightinfo["Flight_Detail"][0]["Fokker_ExpD"]);
            //Debug.Log("Flight_Detail Fokker_DuraE ===>  " + flightinfo["Flight_Detail"][0]["Fokker_DuraE"]);
            //Debug.Log("Flight_Detail Fokker_ExpE ===>  " + flightinfo["Flight_Detail"][0]["Fokker_ExpE"]);

            ValueDeliverScript.flight001Bullet = int.Parse(flightinfo["Flight_Detail"][0]["Comanche_BulletLv"]);
            ValueDeliverScript.flight001Skill = int.Parse(flightinfo["Flight_Detail"][0]["Comanche_SkillLv"]);
            ValueDeliverScript.flight001Skin = int.Parse(flightinfo["Flight_Detail"][0]["Comanche_Skin"]);
            ValueDeliverScript.FlightDura001Skin001 = int.Parse(flightinfo["Flight_Detail"][0]["Comanche_DuraA"]);
            ValueDeliverScript.FlightExp001Skin001 = int.Parse(flightinfo["Flight_Detail"][0]["Comanche_ExpA"]);
            ValueDeliverScript.FlightDura001Skin002 = int.Parse(flightinfo["Flight_Detail"][0]["Comanche_DuraB"]);
            ValueDeliverScript.FlightExp001Skin002 = int.Parse(flightinfo["Flight_Detail"][0]["Comanche_ExpB"]);
            ValueDeliverScript.FlightDura001Skin003 = int.Parse(flightinfo["Flight_Detail"][0]["Comanche_DuraC"]);
            ValueDeliverScript.FlightExp001Skin003 = int.Parse(flightinfo["Flight_Detail"][0]["Comanche_ExpC"]);
            ValueDeliverScript.FlightDura001Skin004 = int.Parse(flightinfo["Flight_Detail"][0]["Comanche_DuraD"]);
            ValueDeliverScript.FlightExp001Skin004 = int.Parse(flightinfo["Flight_Detail"][0]["Comanche_ExpD"]);
            ValueDeliverScript.FlightDura001Skin005 = int.Parse(flightinfo["Flight_Detail"][0]["Comanche_DuraE"]);
            ValueDeliverScript.FlightExp001Skin005 = int.Parse(flightinfo["Flight_Detail"][0]["Comanche_ExpE"]);

            //Debug.Log("Flight_Detail Comanche_BulletLv ===>  " + flightinfo["Flight_Detail"][0]["Comanche_BulletLv"]);
            //Debug.Log("Flight_Detail Comanche_SkillLv ===>  " + flightinfo["Flight_Detail"][0]["Comanche_SkillLv"]);
            //Debug.Log("Flight_Detail Comanche_Skin ===>  " + flightinfo["Flight_Detail"][0]["Comanche_Skin"]);
            //Debug.Log("Flight_Detail Comanche_DuraA ===>  " + flightinfo["Flight_Detail"][0]["Comanche_DuraA"]);
            //Debug.Log("Flight_Detail Comanche_ExpA ===>  " + flightinfo["Flight_Detail"][0]["Comanche_ExpA"]);
            //Debug.Log("Flight_Detail Comanche_DuraB ===>  " + flightinfo["Flight_Detail"][0]["Comanche_DuraB"]);
            //Debug.Log("Flight_Detail Comanche_ExpB ===>  " + flightinfo["Flight_Detail"][0]["Comanche_ExpB"]);
            //Debug.Log("Flight_Detail Comanche_DuraC ===>  " + flightinfo["Flight_Detail"][0]["Comanche_DuraC"]);
            //Debug.Log("Flight_Detail Comanche_ExpC ===>  " + flightinfo["Flight_Detail"][0]["Comanche_ExpC"]);
            //Debug.Log("Flight_Detail Comanche_DuraD ===>  " + flightinfo["Flight_Detail"][0]["Comanche_DuraD"]);
            //Debug.Log("Flight_Detail Comanche_ExpD ===>  " + flightinfo["Flight_Detail"][0]["Comanche_ExpD"]);
            //Debug.Log("Flight_Detail Comanche_DuraE ===>  " + flightinfo["Flight_Detail"][0]["Comanche_DuraE"]);
            //Debug.Log("Flight_Detail Comanche_ExpE ===>  " + flightinfo["Flight_Detail"][0]["Comanche_ExpE"]);

            ValueDeliverScript.flight002Bullet = int.Parse(flightinfo["Flight_Detail"][0]["Phantom_BulletLv"]);
            ValueDeliverScript.flight002Skill = int.Parse(flightinfo["Flight_Detail"][0]["Phantom_SkillLv"]);
            ValueDeliverScript.flight002Skin = int.Parse(flightinfo["Flight_Detail"][0]["Phantom_Skin"]);
            ValueDeliverScript.FlightDura002Skin001 = int.Parse(flightinfo["Flight_Detail"][0]["Phantom_DuraA"]);
            ValueDeliverScript.FlightExp002Skin001 = int.Parse(flightinfo["Flight_Detail"][0]["Phantom_ExpA"]);
            ValueDeliverScript.FlightDura002Skin002 = int.Parse(flightinfo["Flight_Detail"][0]["Phantom_DuraB"]);
            ValueDeliverScript.FlightExp002Skin002 = int.Parse(flightinfo["Flight_Detail"][0]["Phantom_ExpB"]);
            ValueDeliverScript.FlightDura002Skin003 = int.Parse(flightinfo["Flight_Detail"][0]["Phantom_DuraC"]);
            ValueDeliverScript.FlightExp002Skin003 = int.Parse(flightinfo["Flight_Detail"][0]["Phantom_ExpC"]);
            ValueDeliverScript.FlightDura002Skin004 = int.Parse(flightinfo["Flight_Detail"][0]["Phantom_DuraD"]);
            ValueDeliverScript.FlightExp002Skin004 = int.Parse(flightinfo["Flight_Detail"][0]["Phantom_ExpD"]);
            ValueDeliverScript.FlightDura002Skin005 = int.Parse(flightinfo["Flight_Detail"][0]["Phantom_DuraE"]);
            ValueDeliverScript.FlightExp002Skin005 = int.Parse(flightinfo["Flight_Detail"][0]["Phantom_ExpE"]);

            //Debug.Log("Flight_Detail Phantom_BulletLv ===>  " + flightinfo["Flight_Detail"][0]["Phantom_BulletLv"]);
            //Debug.Log("Flight_Detail Phantom_SkillLv ===>  " + flightinfo["Flight_Detail"][0]["Phantom_SkillLv"]);
            //Debug.Log("Flight_Detail Phantom_Skin ===>  " + flightinfo["Flight_Detail"][0]["Phantom_Skin"]);
            //Debug.Log("Flight_Detail Phantom_DuraA ===>  " + flightinfo["Flight_Detail"][0]["Phantom_DuraA"]);
            //Debug.Log("Flight_Detail Phantom_ExpA ===>  " + flightinfo["Flight_Detail"][0]["Phantom_ExpA"]);
            //Debug.Log("Flight_Detail Phantom_DuraB ===>  " + flightinfo["Flight_Detail"][0]["Phantom_DuraB"]);
            //Debug.Log("Flight_Detail Phantom_ExpB ===>  " + flightinfo["Flight_Detail"][0]["Phantom_ExpB"]);
            //Debug.Log("Flight_Detail Phantom_DuraC ===>  " + flightinfo["Flight_Detail"][0]["Phantom_DuraC"]);
            //Debug.Log("Flight_Detail Phantom_ExpC ===>  " + flightinfo["Flight_Detail"][0]["Phantom_ExpC"]);
            //Debug.Log("Flight_Detail Phantom_DuraD ===>  " + flightinfo["Flight_Detail"][0]["Phantom_DuraD"]);
            //Debug.Log("Flight_Detail Phantom_ExpD ===>  " + flightinfo["Flight_Detail"][0]["Phantom_ExpD"]);
            //Debug.Log("Flight_Detail Phantom_DuraE ===>  " + flightinfo["Flight_Detail"][0]["Phantom_DuraE"]);
            //Debug.Log("Flight_Detail Phantom_ExpE ===>  " + flightinfo["Flight_Detail"][0]["Phantom_ExpE"]);

            GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().LoadMyLankDataFromServerToRankDataFB();
            isGetFlightInfo = true;
        }
    }

    public void UserInfoSave(string fromServerUserInfoJson)
    {
        var rankData = MiniJSON.Json.Deserialize(fromServerUserInfoJson) as Dictionary<string, object>;
        List<object> RankData = (List<object>)rankData["RankingInfo"];


        ValueDeliverScript.rankDataFB = new RankDataS[RankData.Count];

        foreach (Dictionary<string, object> Rank in RankData)
        {

            ValueDeliverScript.Nick = Rank["NickName"].ToString();
            ValueDeliverScript.scoreHigh = int.Parse(Rank["TWeekScore"].ToString());

        }
    }

    public bool isGetRankingData = false;
    public IEnumerator GetRankingData()
    {
        Debug.Log(":::랭킹정보받아오는 메소드 진입 ::: Unique_number ::: " + ValueDeliverScript.UserID);
        userUniNumber = ValueDeliverScript.UserID;
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("hash", hash);



        WWW www = new WWW(GetRankingDataUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;
            Debug.Log(wwwResult);
            var rankinginfo = SimpleJSON.JSON.Parse(wwwResult);

            Debug.Log("Ranking Info ::: " + rankinginfo);
            ValueDeliverScript.lastScoreHigh = int.Parse(rankinginfo["Ranking_LWeekScore"][0]["LWeekScore"]);
            ValueDeliverScript.scoreHigh = int.Parse(rankinginfo["Ranking_TWeekScore"][0]["TWeekScore"]);
            ValueDeliverScript.highFlight = int.Parse(rankinginfo["Ranking_BestFlight"][0]["BestFlight"]);
            ValueDeliverScript.highSkin = int.Parse(rankinginfo["Ranking_BestSkin"][0]["BestSkin"]);
            ValueDeliverScript.highBomb = int.Parse(rankinginfo["Ranking_BestBomb"][0]["BestBomb"]);
            ValueDeliverScript.highReinforce = int.Parse(rankinginfo["Ranking_BestRein"][0]["BestRein"]);
            ValueDeliverScript.highAssist = int.Parse(rankinginfo["Ranking_BestAssist"][0]["BestAssist"]);
            ValueDeliverScript.highChar = int.Parse(rankinginfo["Ranking_BestSupporter"][0]["BestSupporter"]);

            isGetRankingData = true;
        }
    }

    public bool isFriendDataload = false;

    public IEnumerator GetFriendsData()
    {
        Debug.Log(":::친구정보받아오는 메소드 진입");

        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        yield return null;

        int rLength = 0;

        Debug.Log("페북 친구 길이~~~~!!!!");
        if (ValueDeliverScript.rankDataFB.Length == null)
        {
            rLength = 0;
            Debug.Log("rLength ::: " + rLength);
        }
        else
        {
            rLength = ValueDeliverScript.rankDataFB.Length;
            Debug.Log("ValueDeliverScript.rankDataFB.Length" + ValueDeliverScript.rankDataFB.Length);
        }
        string[] friendToServerData = new string[rLength];

        if (rLength > 0)
        {
            for (int i = 0; i < rLength; i++)
            {
                friendToServerData[i] = ValueDeliverScript.rankDataFB[i].FbId;
            }
        }

        string FriendJson = MiniJSON.Json.Serialize(friendToServerData);

        Debug.Log(FriendJson);

        WWWForm form = new WWWForm();

        form.AddField("FB_Friends", FriendJson);
        form.AddField("hash", hash);

        WWW www = new WWW(GetFriendsDataUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Debug.Log(www.error);
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;
            Debug.Log("Here!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Debug.Log(wwwResult);
            Debug.Log(www.text);
            RankGroupSave(wwwResult);
            GameObject.Find("LoadingBar").GetComponent<LoadingBarScript>().LoadingBarFill();
        }
    }


    public IEnumerator GetMailInfo()
    {
        userUniNumber = ValueDeliverScript.UserID;
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("hash", hash);

        WWW www = new WWW(GetMailInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;
            Debug.Log(wwwResult);
            var mailInfo = SimpleJSON.JSON.Parse(wwwResult);
            ValueDeliverScript.messageData = new MessageDataS[mailInfo["MailInfo"].Count];
            Debug.Log("Mail Info Count " + mailInfo["MailInfo"].Count);
            int count = 0;

            if (ValueDeliverScript.messageData.Length > 0)
            {
                while (count < mailInfo["MailInfo"].Count)
                {
                    ValueDeliverScript.messageData[count].To = mailInfo["MailInfo"][count]["To"];
                    ValueDeliverScript.messageData[count].From = mailInfo["MailInfo"][count]["From"];
                    ValueDeliverScript.messageData[count].Type = mailInfo["MailInfo"][count]["Type"];
                    ValueDeliverScript.messageData[count].Ea = mailInfo["MailInfo"][count]["Ea"];
                    ValueDeliverScript.messageData[count].Time = mailInfo["MailInfo"][count]["Time"];
                    ValueDeliverScript.messageData[count].Contents = mailInfo["MailInfo"][count]["Contents"];

                    Debug.Log("MailInfo " + count + " To ===> " + ValueDeliverScript.messageData[count].To);
                    Debug.Log("MailInfo " + count + " From ===> " + ValueDeliverScript.messageData[count].From);
                    Debug.Log("MailInfo " + count + " Type ===> " + ValueDeliverScript.messageData[count].Type);
                    Debug.Log("MailInfo " + count + " Ea ===> " + ValueDeliverScript.messageData[count].Ea);
                    Debug.Log("MailInfo " + count + " Time ===> " + ValueDeliverScript.messageData[count].Time);
                    Debug.Log("MailInfo " + count + " Contents ===> " + ValueDeliverScript.messageData[count].Contents);
                    count++;
                }
            }
            else
            {
                Debug.Log("Message is Null");
            }
        }
    }
    public IEnumerator GetGiftInfo()
    {
        userUniNumber = ValueDeliverScript.UserID;
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("hash", hash);

        WWW www = new WWW(GetGiftInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;
            Debug.Log(www.error);
            Debug.Log("Reward Time ::::::   " + wwwResult);
            ValueDeliverScript.myRewardTime = wwwResult;
        }
    }

    public bool isGetWorldRanking = false;
    public IEnumerator GetWorldRanking()
    {
        GameObject.Find("LoadingBar").GetComponent<LoadingBarScript>().LoadingBarFill();

        userUniNumber = ValueDeliverScript.UserID;
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("Unique_number", userUniNumber);
        form.AddField("hash", hash);

        WWW www = new WWW(GetWorldRankingUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;
            Debug.Log(wwwResult);
            var worldRankinginfo = SimpleJSON.JSON.Parse(wwwResult);
            ValueDeliverScript.worldRank = new RankDataS[worldRankinginfo["World_RankingInfo"].Count];
            Debug.Log("World Ranking Info Count     " + worldRankinginfo["World_RankingInfo"].Count);
            int count = 0;


            while (count < worldRankinginfo["World_RankingInfo"].Count)
            {
                ValueDeliverScript.worldRank[count].NickName = worldRankinginfo["World_RankingInfo"][count]["NickName"];
                ValueDeliverScript.worldRank[count].BestScore = worldRankinginfo["World_RankingInfo"][count]["BestScore"];
                ValueDeliverScript.worldRank[count].LWeekScore = worldRankinginfo["World_RankingInfo"][count]["LWeekScore"];
                ValueDeliverScript.worldRank[count].TWeekScore = worldRankinginfo["World_RankingInfo"][count]["TWeekScore"];
                ValueDeliverScript.worldRank[count].Flight = worldRankinginfo["World_RankingInfo"][count]["Flight"];
                ValueDeliverScript.worldRank[count].Skin = worldRankinginfo["World_RankingInfo"][count]["Skin"];
                ValueDeliverScript.worldRank[count].Bullet = worldRankinginfo["World_RankingInfo"][count]["Bullet"];
                ValueDeliverScript.worldRank[count].Bomb = worldRankinginfo["World_RankingInfo"][count]["Bomb"];
                ValueDeliverScript.worldRank[count].Rein = worldRankinginfo["World_RankingInfo"][count]["Rein"];
                ValueDeliverScript.worldRank[count].Assist = worldRankinginfo["World_RankingInfo"][count]["Assist"];
                ValueDeliverScript.worldRank[count].Supporter = worldRankinginfo["World_RankingInfo"][count]["Supporter"];
                ValueDeliverScript.worldRank[count].FbId = worldRankinginfo["World_RankingInfo"][count]["Fbid"];


                //페이스북 계정이 있는 유저라면 프로필 사진을 로드한다//
                string fbId = ValueDeliverScript.worldRank[count].FbId;
                if (fbId != "0" && fbId != null && fbId != "")
                {
                    WWW url = new WWW("https" + "://graph.facebook.com/" + fbId + "/picture");

                    yield return url;
                    ValueDeliverScript.worldRank[count].FbPic = url.texture;
                }



                //Debug.Log("World_Ranking   " + count + "  NickName ===>  " + ValueDeliverScript.worldRank[count].NickName);
                //Debug.Log("World_Ranking   " + count + "  BestScore ===>  " + ValueDeliverScript.worldRank[count].BestScore);
                //Debug.Log("World_Ranking   " + count + "  LWeekScore ===>  " + ValueDeliverScript.worldRank[count].LWeekScore);
                //Debug.Log("World_Ranking   " + count + "  TWeekScore ===>  " + ValueDeliverScript.worldRank[count].TWeekScore);
                //Debug.Log("World_Ranking   " + count + "  Flight ===>  " + ValueDeliverScript.worldRank[count].Flight);
                //Debug.Log("World_Ranking   " + count + "  Skin ===>  " + ValueDeliverScript.worldRank[count].Skin);
                //Debug.Log("World_Ranking   " + count + "  Bullet ===>  " + ValueDeliverScript.worldRank[count].Bullet);
                //Debug.Log("World_Ranking   " + count + "  Bomb ===>  " + ValueDeliverScript.worldRank[count].Bomb);
                //Debug.Log("World_Ranking   " + count + "  Rein ===>  " + ValueDeliverScript.worldRank[count].Rein);
                //Debug.Log("World_Ranking   " + count + "  Assist ===>  " + ValueDeliverScript.worldRank[count].Assist);
                //Debug.Log("World_Ranking   " + count + "  Supporter ===>  " + ValueDeliverScript.worldRank[count].Supporter);


                GameObject.Find("LoadingBar").GetComponent<LoadingBarScript>().LoadingBarFill(worldRankinginfo["World_RankingInfo"].Count/4);
                count++;
            }
            isGetWorldRanking = true;
        }
        if (isNextScene == false)
        {
            isNextScene = true;
            StartCoroutine(GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().NextScene());
        }
    }
    bool isNextScene = false;

    public void RankGroupSave(string fromServerJson)
    {
        int count = 0;
        var friendsinfo = SimpleJSON.JSON.Parse(fromServerJson);

        //ValueDeliverScript.rankDataFB = new RankDataS[friendsinfo.Count];

        FaceBookUseScript faceBookUseScript = GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>();

        while (count < friendsinfo.Count)
        {
            ValueDeliverScript.rankDataFB[count].NickName = friendsinfo[count][0][0]["name"];
            ValueDeliverScript.rankDataFB[count].BestScore = friendsinfo[count][0][0]["bestscore"];
            ValueDeliverScript.rankDataFB[count].LWeekScore = friendsinfo[count][0][0]["lweekscore"];
            ValueDeliverScript.rankDataFB[count].TWeekScore = friendsinfo[count][0][0]["tweekscore"];
            ValueDeliverScript.rankDataFB[count].Flight = friendsinfo[count][0][0]["bestflight"];
            ValueDeliverScript.rankDataFB[count].Skin = friendsinfo[count][0][0]["bestskin"];
            ValueDeliverScript.rankDataFB[count].Bullet = friendsinfo[count][0][0]["bestbullet"];
            ValueDeliverScript.rankDataFB[count].Bomb = friendsinfo[count][0][0]["bestbomb"];
            ValueDeliverScript.rankDataFB[count].Rein = friendsinfo[count][0][0]["bestrein"];
            ValueDeliverScript.rankDataFB[count].Assist = friendsinfo[count][0][0]["bestassist"];
            ValueDeliverScript.rankDataFB[count].Supporter = friendsinfo[count][0][0]["bestsupporter"];
            Debug.Log(friendsinfo[count][0][0]["name"]);
            Debug.Log("ValueDeliverScript   " + count + "  fbId ===>  " + ValueDeliverScript.rankDataFB[count].FbId);
            Debug.Log("ValueDeliverScript   " + count + "  fbName ===>  " + ValueDeliverScript.rankDataFB[count].FbName);

            Debug.Log("ValueDeliverScript   " + count + "  NickName ===>  " + ValueDeliverScript.rankDataFB[count].NickName);
            Debug.Log("ValueDeliverScript   " + count + "  BestScore ===>  " + ValueDeliverScript.rankDataFB[count].BestScore);
            Debug.Log("ValueDeliverScript   " + count + "  LWeekScore ===>  " + ValueDeliverScript.rankDataFB[count].LWeekScore);
            Debug.Log("ValueDeliverScript   " + count + "  TWeekScore ===>  " + ValueDeliverScript.rankDataFB[count].TWeekScore);
            Debug.Log("ValueDeliverScript   " + count + "  Flight ===>  " + ValueDeliverScript.rankDataFB[count].Flight);
            Debug.Log("ValueDeliverScript   " + count + "  Skin ===>  " + ValueDeliverScript.rankDataFB[count].Skin);
            Debug.Log("ValueDeliverScript   " + count + "  Bullet ===>  " + ValueDeliverScript.rankDataFB[count].Bullet);
            Debug.Log("ValueDeliverScript   " + count + "  Bomb ===>  " + ValueDeliverScript.rankDataFB[count].Bomb);
            Debug.Log("ValueDeliverScript   " + count + "  Rein ===>  " + ValueDeliverScript.rankDataFB[count].Rein);
            Debug.Log("ValueDeliverScript   " + count + "  Assist ===>  " + ValueDeliverScript.rankDataFB[count].Assist);
            Debug.Log("ValueDeliverScript   " + count + "  Supporter ===>  " + ValueDeliverScript.rankDataFB[count].Supporter);
            count++;
        }
        isFriendDataload = true;

        if (isNextScene == false)
        {
            isNextScene = true;
            StartCoroutine(GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().NextScene());
        }
    }

    //서버에 닉 데이터를 보내고 UserID 데이터를 받은후 아래 메소드를 호출한다.
    //아래 메소드가 호출 되어야만 로딩 씬에서 행거 씬으로 넘어간다.
    //현 클래스 내에서만 사용될 것이기 때문에 메소드 이름은 바꾸어도 무방.

    public void AfterReceiveUserIdData()
    {
        Debug.Log("AfterRe :::");
        //아래 코드는 씬내 기 정해진 오브젝트 이름과 클래스 이름을 사용하기 때문에 바뀌어선 안된다.
        GameObject.Find("AfterInitialObject").GetComponent<AfterInitialScript>().ReceiveData();
    }

    IEnumerator FindID()
    {
        string userUnique = SystemInfo.deviceUniqueIdentifier;
        string hash = Md5Sum(userUnique + secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("Unique_name", userUnique);
        form.AddField("hash", hash);

        WWW www = new WWW(FindUserInfoUrl, form);
        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }

        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;
        }
        Debug.Log(www.text);

    }

    IEnumerator DeleteID()
    {
        string userUnique = SystemInfo.deviceUniqueIdentifier;
        string hash = Md5Sum(userUnique + secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("Unique_name", userUnique);
        form.AddField("hash", hash);

        WWW www = new WWW(FindUserInfoUrl, form);

        yield return www;

        while (!www.isDone && www.error == null && tempTime < ServerConnectionTimeout)
        {
            tempTime += Time.deltaTime;
            yield return 0;
        }
        if (www.error != null || tempTime >= ServerConnectionTimeout)
        {
            //타임아웃처리
            Debug.Log("Disconnected!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            ServerPopUp.SetActive(true);
        }
        else
        {
            wwwResult = www.text;
            Debug.Log(wwwResult);
        }


    }

    IEnumerator DeleteFindID()
    {
        yield return StartCoroutine(FindID());

        int userIDNumber = int.Parse(wwwResult);
        string serverResult;
        string hash = Md5Sum(secretKey).ToLower();
        float tempTime = 0;

        WWWForm form = new WWWForm();

        form.AddField("User_IDNumber", userIDNumber);
        form.AddField("hash", hash);

        Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>                 " + userIDNumber);
        WWW www = new WWW(DelUserInfoUrl, form);
        yield return www;

        serverResult = www.text;

        if (serverResult == "DeleteUserInformation")
        {
            Debug.Log("============== Delete " + wwwResult + " User Information ==============");
            //Application.LoadLevel("Loading");
        }

        Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>                 " + serverResult);

    }

    public IEnumerator CheckVersion()
    {
        string userUnique = SystemInfo.deviceUniqueIdentifier;
        string hash = Md5Sum(secretKey).ToLower();

        WWWForm form = new WWWForm();

        form.AddField("Version", ValueDeliverScript.ver);
        form.AddField("hash", hash);

        WWW www = new WWW(VersionUrl, form);
        yield return www;

        wwwResult = www.text;

        if (int.Parse(wwwResult) <= int.Parse(ValueDeliverScript.ver))
        {
            //Debug.Log("<<<<<<<<<<<<<<<<<   Version Check Complete    >>>>>>>>>>>>>>>");
        }
        else
        {
            //Debug.Log("Version is wrong!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            //Debug.Log(wwwResult);

            //버전이 맞지 않기에 버전이 잘못되었음을 알려주는 정보창을 띄움.
            if (GameObject.Find("Anchor").transform.FindChild("ServerWin").gameObject.activeSelf == false)
                GameObject.Find("Anchor").transform.FindChild("CheckVerWin").gameObject.SetActive(true);
            ValueDeliverScript.isVerCheckFaild = true;
            StartCoroutine(QuitApp());
        }
    }

    IEnumerator QuitApp()
    {
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }


    public string Md5Sum(string strToEncrypt)
    {

        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);
        string hashString = "";
        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }
        return hashString.PadLeft(32, '0');
    }


}
