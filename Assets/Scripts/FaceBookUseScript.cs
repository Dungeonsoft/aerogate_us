using System;
using System.Security;
using System.Collections;
using System.Collections.Generic;
using MyDelegateNS;
using UnityEngine;

using System.Text;
using System.Security;
using MiniJSON;
using SimpleJSON;

public class FaceBookUseScript : MonoBehaviour
{
    private string status;

    public GameObject facebookBTN;
    public GameObject afterInitialObject;
    public UILabel labelAll;

    public static FaceBookUseScript instance;

    [System.NonSerialized]
    public bool logIn = false;

    private void Awake()
    {
        FaceBookUseScript.instance = this;
        DontDestroyOnLoad(instance);
    }

    void Start()
    {
        //로컬에 저장되어 있는 데이터들을 로드한다//
        ValueDeliverScript.flightNumber = PlayerPrefs.GetInt("flightNumber", ValueDeliverScript.flightNumber);
        ValueDeliverScript.activeOper = PlayerPrefs.GetInt("activeOper", ValueDeliverScript.activeOper);
        ValueDeliverScript.dartCount = PlayerPrefs.GetInt("dartCount", ValueDeliverScript.dartCount);
        ValueDeliverScript.dustCount = PlayerPrefs.GetInt("dustCount", ValueDeliverScript.dustCount);
        ValueDeliverScript.shieldCount = PlayerPrefs.GetInt("shieldCount", ValueDeliverScript.shieldCount);
        ValueDeliverScript.spinballCount = PlayerPrefs.GetInt("spinballCount", ValueDeliverScript.spinballCount);

        ValueDeliverScript.isSpecialAttackMissionSelect = PlayerPrefs.GetInt("isSpecialAttackMissionSelect", ValueDeliverScript.isSpecialAttackMissionSelect);
        ValueDeliverScript.specialAttackType = PlayerPrefs.GetInt("specialAttackType", ValueDeliverScript.specialAttackType);
        ValueDeliverScript.isSpecialAttackComplete = PlayerPrefs.GetInt("isSpecialAttackComplete", ValueDeliverScript.isSpecialAttackComplete);
        ValueDeliverScript.specialEndTime = PlayerPrefs.GetString("specialEndTime", ValueDeliverScript.specialEndTime);
        ValueDeliverScript.specialAttackItemName = PlayerPrefs.GetString("specialAttackItemName", ValueDeliverScript.specialAttackItemName);

        ValueDeliverScript.flight000SortieNumber = PlayerPrefs.GetInt("flight000SortieNumber", ValueDeliverScript.flight000SortieNumber);
        ValueDeliverScript.flight000BombUseNumber = PlayerPrefs.GetInt("flight000BombUseNumber", ValueDeliverScript.flight000BombUseNumber);
        ValueDeliverScript.flight000ScoreHigh = PlayerPrefs.GetInt("flight000ScoreHigh", ValueDeliverScript.flight000ScoreHigh);
        ValueDeliverScript.flight001EnemyKill = PlayerPrefs.GetInt("flight001EnemyKill", ValueDeliverScript.flight001EnemyKill);
        ValueDeliverScript.flight001GetCoin = PlayerPrefs.GetInt("flight001GetCoin", ValueDeliverScript.flight001GetCoin);
        ValueDeliverScript.flight001UseSkill = PlayerPrefs.GetInt("flight001UseSkill", ValueDeliverScript.flight001UseSkill);
        ValueDeliverScript.flight001GetPowerItem = PlayerPrefs.GetInt("flight001GetPowerItem", ValueDeliverScript.flight001GetPowerItem);
        ValueDeliverScript.flight002KillSpinball = PlayerPrefs.GetInt("flight002KillSpinball", ValueDeliverScript.flight002KillSpinball);
        ValueDeliverScript.flight002SpecialAttack = PlayerPrefs.GetInt("flight002SpecialAttack", ValueDeliverScript.flight002SpecialAttack);
        ValueDeliverScript.flight002CompleteInstanceMission = PlayerPrefs.GetInt("flight002CompleteInstanceMission", ValueDeliverScript.flight002CompleteInstanceMission);
        ValueDeliverScript.flight002RescueFriend = PlayerPrefs.GetInt("flight002RescueFriend", ValueDeliverScript.flight002RescueFriend);
        ValueDeliverScript.flight002WormLevel5 = PlayerPrefs.GetInt("flight002WormLevel5", ValueDeliverScript.flight002WormLevel5);
        ValueDeliverScript.isFirstAccess = PlayerPrefs.GetInt("isFirstAccess", ValueDeliverScript.isFirstAccess);
    }

    #region 이니셜라이징 부분 메소드 모음

    //최초 게임 구동시 이니셜라이징//

    //호출할 메소드//
    public void CallFBInit()
    {
        Debug.Log("CallFBInit");
        facebookBTN.SetActive(false);

        FB.Init(OnInitComplete, OnHideUnity);
    }

    private void OnInitComplete()
    {
        status = "FB.Init completed: Is user logged in? " + FB.IsLoggedIn;
        Debug.Log(status);
        labelAll.text += status + "\n";

        //이니셜후 할 내용을 적는 부분 상시 변경 가능//
        ///////////////////////////////////////////////////////////////////////////////
        if (FB.IsLoggedIn == true)  //로긴까지 성공//
        {
            logIn = true;
            facebookBTN.SetActive(false);
            GameObject.Find("Anchor").transform.FindChild("LoadingBar").gameObject.SetActive(true);

            CAPI_MyInfo();
            //GameObject.Find("LogIn").SetActive(false);
        }
        else   //이니셜만 성공//
        {
            logIn = false;
            facebookBTN.SetActive(true);
        }
        ///////////////////////////////////////////////////////////////////////////////
        //이니셜후 할 내용을 적는 부분 상시 변경 가능//

        //이니셜이 되면 로그인도 되도록 메소드 호출//
        //Login();
    }

    public void CAPI_MyInfo()
    {
        ApiQuery = "me?fields=id,name";
        Debug.Log("Query :: " + ApiQuery);
        FB.API(ApiQuery, Facebook.HttpMethod.GET, CallbackMy);
        ApiQuery = "";
    }

    public string myFBid;

    private void picInput(Texture2D pic)
    {
        Debug.Log("님하 여기옴? 사진 찍어야지!");
        ValueDeliverScript.myPic = pic;
        GameObject.Find("LoadingBar").GetComponent<LoadingBarScript>().LoadingBarFill();

        UserCheck();    // 유저가 이전에 페이스북 로그인을 하지 않고 게임을 하고 있었는지 알아본다.
        //CAPI_BuddyInfo();//내사진 부르기가 끝나면 친구사진을 불러온다.
    }

    private PicDataInput dePicInput;

    private void CallbackMy(FBResult result)
    {
        Debug.Log("My Info ::");
        Debug.Log(":: Result ::\n" + result.Text);

        var dict = MiniJSON.Json.Deserialize(result.Text) as Dictionary<string, object>;

        Debug.Log("dict ID :: " + dict["id"]);
        myFBid = dict["id"].ToString();

        ValueDeliverScript.myFBid = myFBid;
        ValueDeliverScript.myFBName = dict["name"].ToString();

        dePicInput = new PicDataInput(picInput);
        StartCoroutine(loadFbPic(myFBid));

        //로딩바 첫 시작
        GameObject.Find("LoadingBar").GetComponent<LoadingBarScript>().LoadingBarFill();
    }


    public IEnumerator loadFbPic(string id)
    {
        WWW url = new WWW("https" + "://graph.facebook.com/" + id + "/picture");

        yield return url;

        dePicInput(url.texture);
    }

    private bool FBisGetData = false;

    public void CAPI_BuddyInfo(bool isGetData = false)
    {
        FBisGetData = isGetData;
        ApiQuery = "me/friends";
        Debug.Log("Query :: " + ApiQuery);
        FB.API(ApiQuery, Facebook.HttpMethod.GET, CallbackBuddy);
        ApiQuery = "";
    }

    //친구 사진을 담기 위한 해쉬테이블 변수 선언//
    //public Hashtable FriendsPic = new Hashtable();

    private int FriendsCount;

    private void CallbackBuddy(FBResult result)
    {
        picCount = 0;
        ValueDeliverScript.friendJsonAll = result.ToString();

        var dict = MiniJSON.Json.Deserialize(result.Text) as Dictionary<string, object>;
        List<object> AccountList = (List<object>)dict["data"];

        FriendsCount = AccountList.Count;
        Debug.Log("Friend Count :: " + FriendsCount);

        ValueDeliverScript.rankDataFB = new RankDataS[FriendsCount + 1]; //+1을 한 것은 내 정보를 랭킹 데이터로 같이 불러오게 하기 위해서//

        int count = 0;
        if (FriendsCount != 0)
        {
            foreach (Dictionary<string, object> Ac in AccountList)
            {
                Debug.Log("data ID - " + Ac["id"]);
                Debug.Log("data Name - " + Ac["name"]);

                ValueDeliverScript.rankDataFB[count].FbId = Ac["id"].ToString();
                ValueDeliverScript.rankDataFB[count].FbName = Ac["name"].ToString();

                Debug.Log("ValueDeliverScript.rankDataFB[" + count + "].fbId ::: " + ValueDeliverScript.rankDataFB[count].FbId);
                Debug.Log("ValueDeliverScript.rankDataFB[" + count + "].fbName ::: " + ValueDeliverScript.rankDataFB[count].FbName);

                ValueDeliverScript.rankDataFB[count].Assist = "0";
                ValueDeliverScript.rankDataFB[count].BestScore = "0";
                ValueDeliverScript.rankDataFB[count].Bomb = "0";
                ValueDeliverScript.rankDataFB[count].Bullet = "0";
                ValueDeliverScript.rankDataFB[count].Flight = "0";
                ValueDeliverScript.rankDataFB[count].LWeekScore = "0";
                ValueDeliverScript.rankDataFB[count].NickName = "0";
                ValueDeliverScript.rankDataFB[count].Rein = "0";
                ValueDeliverScript.rankDataFB[count].Skin = "0";
                ValueDeliverScript.rankDataFB[count].Supporter = "0";
                ValueDeliverScript.rankDataFB[count].TWeekScore = "0";

                //연료를 보낸적이 있으면 연료 보낸 시간을 기록하여 준다.
                #region
                string fuelSendTime;
                if (PlayerPrefs.HasKey("fuelSendTime"))
                {
                    fuelSendTime = PlayerPrefs.GetString("fuelSendTime");
                    string[] sendtimeTemp = fuelSendTime.Split(',');

                    for (int i = 0; i < sendtimeTemp.Length; i++)
                    {
                        if (ValueDeliverScript.rankDataFB[count].FbId == sendtimeTemp[i])
                        {
                            ValueDeliverScript.rankDataFB[count].FuelSendTime = sendtimeTemp[i + 1];
                            break;
                        }
                    }
                }
                #endregion
                //연료를 보낸적이 있으면 연료 보낸 시간을 기록하여 준다.

                string id = Ac["id"].ToString();
                StartCoroutine(loadFriendPic(id, count, FriendPicLoadEnd));
                count++;
                Debug.Log("count :: " + count);
            }
        }
        else
        {
            GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>().isFriendDataload = true;
        }

        finalCount = count;
        //여기서 친구랭킹데이터에 내 정보를 추가하여 준다.//
        //내 정보는 이미 받아와서 밸류딜리버에 저장했으니 서버와 통신하지 않고 직접 로컬에서 불러온다.//
        //{
        //    ValueDeliverScript.rankDataFB[count].FbId = ValueDeliverScript.myFBid;
        //    ValueDeliverScript.rankDataFB[count].FbName = ValueDeliverScript.myFBName;
        //    ValueDeliverScript.rankDataFB[count].FbPic = ValueDeliverScript.myPic;

        //    ValueDeliverScript.rankDataFB[count].Assist = ValueDeliverScript.highAssist+"";
        //    ValueDeliverScript.rankDataFB[count].BestScore = ValueDeliverScript.scoreHigh + "";
        //    ValueDeliverScript.rankDataFB[count].Bomb = ValueDeliverScript.highBomb + "";
        //    ValueDeliverScript.rankDataFB[count].Bullet = ValueDeliverScript.highBullet + "";
        //    ValueDeliverScript.rankDataFB[count].Flight = ValueDeliverScript.highFlight + "";
        //    ValueDeliverScript.rankDataFB[count].LWeekScore = ValueDeliverScript.lastScoreHigh + "";
        //    ValueDeliverScript.rankDataFB[count].NickName = ValueDeliverScript.Nick + "";
        //    ValueDeliverScript.rankDataFB[count].Rein = ValueDeliverScript.highReinforce + "";
        //    ValueDeliverScript.rankDataFB[count].Skin = ValueDeliverScript.highSkin + "";
        //    ValueDeliverScript.rankDataFB[count].Supporter = ValueDeliverScript.highChar + "";
        //    ValueDeliverScript.rankDataFB[count].TWeekScore = ValueDeliverScript.scoreHigh + "";
        //}

        Debug.Log("페북 친구 정리 끝!! == 다음거 부른다.");
        //if (FBisGetData == true) 
            StartCoroutine(GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>().StartGetData2());

        GameObject.Find("LoadingBar").GetComponent<LoadingBarScript>().LoadingBarFill();
    }

    int finalCount;

    public void LoadMyLankDataFromServerToRankDataFB()
    {
        Debug.Log("LoadMyLankDataFromServerToRankDataFB 들어옴");
        //Debug.Log("ValueDeliverScript.rankDataFB.Length ::: " + ValueDeliverScript.rankDataFB.Length);
        if (ValueDeliverScript.rankDataFB.Length == null || ValueDeliverScript.myFBid == "" || ValueDeliverScript.myFBid == null)
        {
            Debug.Log("Null 찍힘 !!!"); return;
        }
        foreach (RankDataS FB in ValueDeliverScript.rankDataFB)
        {
            if (FB.FbId == ValueDeliverScript.myFBid)
            {
                Debug.Log("같은 이름이 있네?");
                return;
            }
        }
        Debug.Log("같은 이름이 없네?");
        ValueDeliverScript.rankDataFB[finalCount].FbId = ValueDeliverScript.myFBid;
        ValueDeliverScript.rankDataFB[finalCount].FbName = ValueDeliverScript.myFBName;
        ValueDeliverScript.rankDataFB[finalCount].FbPic = ValueDeliverScript.myPic;

        ValueDeliverScript.rankDataFB[finalCount].Assist = ValueDeliverScript.highAssist + "";
        ValueDeliverScript.rankDataFB[finalCount].BestScore = ValueDeliverScript.scoreHigh + "";
        ValueDeliverScript.rankDataFB[finalCount].Bomb = ValueDeliverScript.highBomb + "";
        ValueDeliverScript.rankDataFB[finalCount].Bullet = ValueDeliverScript.highBullet + "";
        ValueDeliverScript.rankDataFB[finalCount].Flight = ValueDeliverScript.highFlight + "";
        ValueDeliverScript.rankDataFB[finalCount].LWeekScore = ValueDeliverScript.lastScoreHigh + "";
        ValueDeliverScript.rankDataFB[finalCount].NickName = ValueDeliverScript.Nick + "";
        ValueDeliverScript.rankDataFB[finalCount].Rein = ValueDeliverScript.highReinforce + "";
        ValueDeliverScript.rankDataFB[finalCount].Skin = ValueDeliverScript.highSkin + "";
        ValueDeliverScript.rankDataFB[finalCount].Supporter = ValueDeliverScript.highChar + "";
        ValueDeliverScript.rankDataFB[finalCount].TWeekScore = ValueDeliverScript.scoreHigh + "";
        finalCount = 0;
    }

    private int picCount = 0;

    private void FriendPicLoadEnd()
    {
        picCount++;
        Debug.Log("FriendsCount :: " + FriendsCount + " :::: picCount ::" + picCount);
        if (FriendsCount == picCount)
        {
            CallbackBuddy2();
        }
    }

    private void CallbackBuddy2()
    {
        Debug.Log("페이스북 아이디 제대로 박혔는지 확인하는 곳 ::: 친구 수 ::: " + FriendsCount);
        for (int i = 0; i < FriendsCount; i++)
        {
            Debug.Log("ValueDeliverScript.rankDataFB[" + i + "].fbId ::: " + ValueDeliverScript.rankDataFB[i].FbId);
        }
        Debug.Log("페이스북 아이디 제대로 박혔는지 확인하는 곳");

        if (GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>().isFriendDataload == false)
        {
            Debug.Log("우리서버에서 친구 데이터를 받아오는 메소드 실행!!");
            StartCoroutine(GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>().GetFriendsData());
        }

        afterInitialObject.GetComponent<AfterInitialScript>().SetStart();
        GameObject.Find("LoadingBar").GetComponent<LoadingBarScript>().LoadingBarFill();
    }

    private IEnumerator loadFriendPic(string id, int count, NextFunc func)
    {
        WWW url = new WWW("https" + "://graph.facebook.com/" + id + "/picture");
        yield return url;

        Debug.Log("사진 받아옴 + " + id);
        ValueDeliverScript.rankDataFB[count].FbPic = url.texture;
        //GameObject.Find("Tex").GetComponent<UITexture>().mainTexture = url.texture;
        //FriendsPic.Add(id, url.texture);
        func();
    }

    private void OnHideUnity(bool isGameShown)
    {
        status = "Is game showing? " + isGameShown;
        Debug.Log(status);
        labelAll.text += status + "\n";
    }

    //최초 게임 구동시 이니셜라이징//

    #endregion 이니셜라이징 부분 메소드 모음

    #region 로그인/아웃 부분 메소드 모음

    //페이스북 로그인 로그아웃//
    private string lastResponse;

    //로그인시 호출//
    public void Login()
    {
        CallFBLogin();
        status = "Login called";
        labelAll.text += status + "\n";
        Debug.Log("Log In Called !!");
    }

    private void CallFBLogin()
    {
        FB.Login("email,publish_actions", LoginCallback);
    }

    private void LoginCallback(FBResult result)
    {
        Debug.Log("LogInResult :: " + result);
        if (result.Error != null)
            lastResponse = "Error Response:\n" + result.Error;
        else if (!FB.IsLoggedIn)
        {
            lastResponse = "Login cancelled by Player";
        }
        else
        {
            lastResponse = "Login was successful!";
            //StartCoroutine(UserCheck());

            //로그인 버튼들을 사라지게 하고 로딩바를 보여준다.//
            facebookBTN.SetActive(false);
            GameObject.Find("Anchor").transform.FindChild("LoadingBar").gameObject.SetActive(true);

            CAPI_MyInfo();
        }

        status = "last Response :: " + lastResponse + " ::";
        Debug.Log(status);
        labelAll.text += status + "\n";

        logIn = true;
    }

    private void UserCheck()
    {
        Debug.Log("유적 첵 진입!!");
        //로컬(폰)에 아이디와 닉이 없을 경우 서버에 FB 아이디를 보내 기존에 플레이 하던 유저인지 확인을 한다.//
        //if (ValueDeliverScript.UserID == "" || ValueDeliverScript.Nick == "")
        //{
            Debug.Log("유적 첵 진입!!_1");
            StartCoroutine(GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>().CheckUserFBid());
        //}

        ////페이스북으로 로그인을 하기전에 이미 플레이하던 유저였다면 기존 서버에 내 정보 부분에 페이스북 아이디만 추가하는 메소드를 실행한다.//
        //else if (ValueDeliverScript.UserID != "" && ValueDeliverScript.Nick != "" && ValueDeliverScript.myFBid =="")
        //{
        //    Debug.Log("유적 첵 진입!!_2");
        //    //페이스북 아이디매칭이 되는 서버의 자체 아이디를 찾아 그곳에 페이스북 아이디를 저장하는 메소드를 적어 넣을 것//
        //    StartCoroutine(GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>().UpdateFBid(UserCheckComplete));
        //}
        //else
        //{
            //Debug.Log("유적 첵 진입!!_3");
            //CAPI_BuddyInfo();
            //yield return null;
        //}
    }

    public void UserCheckComplete()
    {
        Debug.Log("UserCheckComplete 까지 왔음!!");
        CAPI_BuddyInfo();
        GameObject.Find("LoadingBar").GetComponent<LoadingBarScript>().LoadingBarFill();
    }

    //로그아웃시 호출//
    public void CallFBLogout()
    {
        FB.Logout();
        Debug.Log("Log Out Btn Click");
        //테스트용 임시//
        ///////////////////////////////////////////////////////////////////////////////
        //GameObject.Find("BTNs").transform.FindChild("LogIn").gameObject.SetActive(true);
        ///////////////////////////////////////////////////////////////////////////////
        //테스트용 임시//
    }

    //페이스북 로그인 로그아웃//

    #endregion 로그인/아웃 부분 메소드 모음

    #region 퍼블리시 인스톨 부분 메소드 모음

    //호출할 메소드//
    public void PublishInstall()
    {
        CallFBActivateApp();
        status = "Install Published";
        labelAll.text += status + "\n";
    }

    private void CallFBActivateApp()
    {
        FB.ActivateApp();
        Callback(new FBResult("Check Insights section for your app in the App Dashboard under \"Mobile App Installs\""));
    }

    #endregion 퍼블리시 인스톨 부분 메소드 모음

    #region 친구선택 관련 메소드 모음

    //기능 수행을 위해선 OpenFriendSelector()을 호출

    public string FriendSelectorTitle = "";
    public string FriendSelectorMessage = "CallAppRequestAsFriendSelector";
    public string FriendSelectorFilters = "[\"app_users\"]";
    public string FriendSelectorData = "{}";
    public string FriendSelectorExcludeIds = "";
    public string FriendSelectorMax = "";

    protected Texture2D lastResponseTexture;

    //게임을 하지 않는 페북 친구들을 초대할때//
    //호출할 메소드//
    public void OpenFriendSelector()
    {
        try
        {
            CallAppRequestAsFriendSelector();
            status = "Friend Selector called";
            labelAll.text += status + "\n";
        }
        catch (Exception e)
        {
            status = e.Message;
            labelAll.text += status + "\n";

            GameObject.Find("InviteBtn").GetComponent<InviteBtnScript>().EndNetworkWithoutAddFuel();
        }
        status = "Status :: " + status + " ::";
        Debug.Log(status);
        labelAll.text += status + "\n";
    }

    private void CallAppRequestAsFriendSelector()
    {
        // If there's a Max Recipients specified, include it
        /*
        int? maxRecipients = null;
        if (FriendSelectorMax != "")
        {
            try
            {
                maxRecipients = Int32.Parse(FriendSelectorMax);
            }
            catch (Exception e)
            {
                status = e.Message;
                labelAll.text += status + "\n";
            }
        }

        // include the exclude ids
        string[] excludeIds = (FriendSelectorExcludeIds == "") ? null : FriendSelectorExcludeIds.Split(',');
        List<object> FriendSelectorFiltersArr = null;
        if (!String.IsNullOrEmpty(FriendSelectorFilters))
        {
            try
            {
                FriendSelectorFiltersArr = Facebook.MiniJSON.Json.Deserialize(FriendSelectorFilters) as List<object>;
            }
            catch
            {
                throw new Exception("JSON Parse error");
            }
        }

        FB.AppRequest(
            FriendSelectorMessage,
            null,
            FriendSelectorFiltersArr,
            excludeIds,
            maxRecipients,
            FriendSelectorData,
            FriendSelectorTitle,
            Callback
        );
        */


        //FB.AppRequest(
        //    message: "Join our fight!",
        //    actionType: null,
        //    objectId: null,
        //    filters: null,
        //    excludeIds: null,
        //    maxRecipients: null,
        //    data: null,
        //    title: "Play Aero Gate with me!",
        //    callback: Callback
        //);

        string[] friendFbId = new string[ValueDeliverScript.rankDataFB.Length];
        for (int i = 0; i < ValueDeliverScript.rankDataFB.Length; i++)
        {
            friendFbId[i] = ValueDeliverScript.rankDataFB[i].FbId;
        }

        FB.AppRequest(
            message: "Join our fight!",
            actionType: null,
            objectId: null,
            filters: null,
            excludeIds: friendFbId,
            maxRecipients: 1,
            data: null,
            title: "Play Aero Gate with me!",
            callback: Callback
        );


        //FB.AppRequest(
        //     "Join our fight!",
        //     null,
        //     null,
        //     null,
        //     null,
        //     "Play Aero Gate with me!",
        //     Callback
        //);
    }

    protected void Callback(FBResult result)
    {
        lastResponseTexture = null;
        // Some platforms return the empty string instead of null.
        if (!String.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Error Response:\n" + result.Error);

            lastResponse = "Error Response:\n" + result.Error;
            status = lastResponse;
            labelAll.text += status + "\n";

            GameObject.Find("InviteBtn").GetComponent<InviteBtnScript>().EndNetworkWithoutAddFuel();
        }
        else if (!String.IsNullOrEmpty(result.Text))
        {
            Debug.Log("Success Response:\n" + result.Text);

            var requestinfo = SimpleJSON.JSON.Parse(result.Text);
            int inviteCount = requestinfo["to"].Count;
            Debug.Log("inviteCount ::: " + inviteCount);

            CallBackResponse(inviteCount);

            lastResponse = "Success Response:\n" + result.Text;
            status = lastResponse;
            labelAll.text += status + "\n";

            GameObject.Find("InviteBtn").GetComponent<InviteBtnScript>().EndNetworkWithoutAddFuel();

        }
        else if (result.Texture != null)
        {
            Debug.Log("Success Response: texture\n");

            lastResponseTexture = result.Texture;
            lastResponse = "Success Response: texture\n";
            status = lastResponse;
            labelAll.text += status + "\n";

            GameObject.Find("InviteBtn").GetComponent<InviteBtnScript>().EndNetworkWithoutAddFuel();

        }
        else
        {
            Debug.Log("Empty Response\n");

            lastResponse = "Empty Response\n";
            status = lastResponse;
            labelAll.text += status + "\n";

            GameObject.Find("InviteBtn").GetComponent<InviteBtnScript>().EndNetworkWithoutAddFuel();
        }
    }

    void CallBackResponse(int inviteCount)
    {
        if (inviteCount == 0) return;
        Debug.Log("inviteCount :::: " + inviteCount);
        ValueDeliverScript.inviteCount = inviteCount;
        StartCoroutine(GameObject.Find("InviteBtn").GetComponent<InviteBtnScript>().NetworkWait());
        ValueDeliverScript.SaveGameData(GameObject.Find("InviteBtn").GetComponent<InviteBtnScript>().EndNetworkWithFuel);
    }

    #endregion 친구선택 관련 메소드 모음

    #region 앱 요청 관련(Request) 메소드 모음

    //기능을 수행하기 위해선 무조건 OpenDirectRequest () 메소드를 호출

    public string DirectRequestTitle = "";
    public string DirectRequestMessage = "Get a Fuel";
    public string DirectRequestTo = "";

    //호출할 메소드//
    public void OpenDirectRequest(string fbId, NextFunc nextF)
    {
        Debug.Log("연료보내기 여기옴? 001");
        DirectRequestTo = fbId;
        try
        {
            CallAppRequestAsDirectRequest(nextF);
            status = "Direct Request called";
            //labelAll.text += status + "\n";
        }
        catch (Exception e)
        {
            status = e.Message;
            //labelAll.text += status + "\n";
        }
    }

    private void CallAppRequestAsDirectRequest(NextFunc nextF)
    {
        Debug.Log("연료보내기 여기옴? 002");

        if (DirectRequestTo == "")
        {
            throw new ArgumentException("\"To Comma Ids\" must be specificed", "to");
        }
        FB.AppRequest(
            DirectRequestMessage,
            DirectRequestTo.Split(','),
            null,
            null,
            null,
            "",
            DirectRequestTitle,
            CallBackForRequest
        );
        Debug.Log("연료보내기 여기옴? 003");

        nextF();
    }

    protected void CallBackForRequest(FBResult result)
    {
        Debug.Log("리퀘스트Test임" + result.Text);
        DirectRequestTo = "";
    }

    #endregion 앱 요청 관련(Request) 메소드 모음

    #region 피드 다이얼로그 호출 메소드 모음

    public string FeedToId = "";
    public string FeedLink = "";
    public string FeedLinkName = "";
    public string FeedLinkCaption = "";
    public string FeedLinkDescription = "";
    public string FeedPicture = "";
    public string FeedMediaSource = "";
    public string FeedActionName = "";
    public string FeedActionLink = "";
    public string FeedReference = "";
    public bool IncludeFeedProperties = false;
    private Dictionary<string, string[]> FeedProperties = new Dictionary<string, string[]>();

    //호출할 메소드//
    public void OpenFeedDialog()
    {
        try
        {
            CallFBFeed();
            status = "Feed dialog called";
        }
        catch (Exception e)
        {
            status = e.Message;
        }

        Debug.Log("Status :: " + status + " ::");
        status = "Status :: " + status + " ::";
        labelAll.text += status + "\n";
    }

    private void CallFBFeed()
    {
        Dictionary<string, string[]> feedProperties = null;
        if (IncludeFeedProperties)
        {
            feedProperties = FeedProperties;
        }
        FB.Feed(
            toId: FeedToId,
            link: FeedLink,
            linkName: FeedLinkName,
            linkCaption: FeedLinkCaption,
            linkDescription: FeedLinkDescription,
            picture: FeedPicture,
            mediaSource: FeedMediaSource,
            actionName: FeedActionName,
            actionLink: FeedActionLink,
            reference: FeedReference,
            properties: feedProperties,
            callback: Callback
        );
    }

    #endregion 피드 다이얼로그 호출 메소드 모음

    #region 콜API 메소드 모음

    public string ApiQuery = "";

    public void CallAPI()
    {
        status = "API called";
        labelAll.text += status + "\n";

        CallFBAPI();
    }

    private void CallFBAPI()
    {
        FB.API(ApiQuery, Facebook.HttpMethod.GET, Callback);
    }

    #endregion 콜API 메소드 모음

    #region 스크린샷 관련 메소드 모음

    public void TakeUploadScreenshot()
    {
        status = "Take screenshot";
        labelAll.text += status + "\n";

        StartCoroutine(TakeScreenshot());
    }

    private IEnumerator TakeScreenshot()
    {
        yield return new WaitForEndOfFrame();

        var width = Screen.width;
        var height = Screen.height;
        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        byte[] screenshot = tex.EncodeToPNG();

        var wwwForm = new WWWForm();
        wwwForm.AddBinaryData("image", screenshot, "InteractiveConsole.png");
        wwwForm.AddField("message", "herp derp.  I did a thing!  Did I do this right?");

        FB.API("me/photos", Facebook.HttpMethod.POST, Callback, wwwForm);
    }

    #endregion 스크린샷 관련 메소드 모음

    #region 딮링크 가져오는 메소드 모음

    public void GetDeepLink()
    {
        CallFBGetDeepLink();
    }

    private void CallFBGetDeepLink()
    {
        FB.GetDeepLink(Callback);
    }

    #endregion 딮링크 가져오는 메소드 모음

    #region 페이스북앱이벤트 호출 관련 메소드

#if UNITY_IOS || UNITY_ANDROID
    public float PlayerLevel = 1.0f;

    public void LogFbAppEvent()
    {
        status = "Logged FB.AppEvent";
        labelAll.text += status + "\n";

        CallAppEventLogEvent();
    }

    public void CallAppEventLogEvent()
    {
        var parameters = new Dictionary<string, object>();
        parameters[Facebook.FBAppEventParameterName.Level] = "Player Level";
        FB.AppEvents.LogEvent(Facebook.FBAppEventName.AchievedLevel, PlayerLevel, parameters);
        PlayerLevel++;
    }

#endif

    #endregion 페이스북앱이벤트 호출 관련 메소드

    private JoywingServerScript jws;
    MessageDataS fbReward;
    MessageDataS[] wdReward;

    public IEnumerator NextScene()
    {
        ////최초 접속시//
        ////한번도 리워드를 받은적이 없으니 첫 접속날을 리워드 받은날로 기록하여 처음부터 리워드를 받는 현상이 생기지 않게 한다//
        string firstLoginDay = PlayerPrefs.GetString("firstLoginDay", System.DateTime.UtcNow.ToBinary().ToString());
        PlayerPrefs.SetString("firstLoginDay", firstLoginDay);
        if (ValueDeliverScript.myRewardTime == "0")
            ValueDeliverScript.myRewardTime = firstLoginDay;
        ////최초 접속시//


        jws = GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>();

        //페이스북없이 게임을 할경우엔 아래 불린 값을 체크하지 않으니 강제로 true를 넣어준다//
        if (ValueDeliverScript.myFBid == "") jws.isFriendDataload = true;

        GameObject.Find("LoadingBar").GetComponent<LoadingBarScript>().LoadingBarFill();
        Debug.Log("LogOK");
        while (true)
        {
            //Debug.Log("::isGetGameInfo::" + jws.isGetGameInfo + "::isGetItemInfo::" + jws.isGetItemInfo + "::isGetFlightInfo::" + jws.isGetFlightInfo + "::isGetRankingData::" + jws.isGetRankingData + "::isGetWorldRanking::" + jws.isGetWorldRanking + "::isFriendDataload::" + jws.isFriendDataload);

            if (jws.isGetGameInfo
                && jws.isGetItemInfo
                && jws.isGetFlightInfo
                && jws.isGetRankingData
                && jws.isGetWorldRanking
                && jws.isFriendDataload)
            {
                if (ValueDeliverScript.isVerCheckFaild == false)
                {
                    //리워드를 받을 수 있는 날짜가 되었는지 그리고 내가 받을 등수가 되었는지 확인하는 함수를 호출한다//
                    Debug.Log("페이스북랭크 수 :: ");
                    if (ValueDeliverScript.rankDataFB !=null && ValueDeliverScript.rankDataFB.Length > 0)
                        CheckRewardAble(ValueDeliverScript.rankDataFB, isFb: true);
                    if (ValueDeliverScript.worldRank.Length > 0)
                        CheckRewardAble(ValueDeliverScript.worldRank, isFb: false);

                    //내 등수를 확인했으니 현재 리워드를받을 수 있는 시간이 되었는지 확인하고//
                    //등수를 확인해서 리워드를 받을 수 있으면 받게하는 메소드를 호출한다//
                    int fbRank = ValueDeliverScript.myFbRank;
                    int wdRank = ValueDeliverScript.myWdRank;
                    int fbRewardGrade = ValueDeliverScript.fbRewardGrade;
                    int wdRewardGrade = ValueDeliverScript.wdRewardGrade;
                    int fRankInterDay = ValueDeliverScript.fRankInterDay;
                    int wRankInterDay = ValueDeliverScript.wRankInterDay;

                    bool isFbReward = false;
                    bool isWdReward = false;
                    //참고// ValueDeliverScript.messageData //


                    Debug.Log("Fb Default Time :: " + ValueDeliverScript.fRankDefaultTime);
                    System.DateTime fbDefaultTime = StringTimeToDateTime(ValueDeliverScript.fRankDefaultTime);
                    Debug.Log("Wd Default Time :: " + ValueDeliverScript.wRankDefaultTime);
                    System.DateTime wdDefaultTime = StringTimeToDateTime(ValueDeliverScript.wRankDefaultTime);
                    Debug.Log("Wd Default Time :: " + ValueDeliverScript.myRewardTime);
                    DateTime convertMRTime = StringTimeToDateTime(ValueDeliverScript.myRewardTime);

                    int interDays = 0;


                    //페북 리워드 여부 조사-가능하면 임시메세지 변수로 저장하도록 설정//
                    //페북 리워드 여부 조사-가능하면 임시메세지 변수로 저장하도록 설정//
                    //페북 리워드 여부 조사-가능하면 임시메세지 변수로 저장하도록 설정//
                    ////////////////////////////////////////////////////////////////
                    //지난 리워드 받는 기간이 언제 였는지 체크- 최초 시작 시간부터 몇번의 인터벌이 지났는지를 알아옴//
                    while (fbDefaultTime.AddDays(fRankInterDay * interDays) < System.DateTime.UtcNow) interDays += 1;

                    //아직 한번도 리워드를 받은적이 없거나 ((ValueDeliverScript.myRewardTime 이 0 이거나))
                    //리워드 받은 시간이 지난시즌마지막 날짜보다 작으면//
                    if (
                        (ValueDeliverScript.myRewardTime == "0" || fbDefaultTime.AddDays(fRankInterDay * (interDays - 1)) > convertMRTime)
                        &&
                        (ValueDeliverScript.myFBid != "" && ValueDeliverScript.myFBid != null)
                        )
                    {
                        ValueDeliverScript.isNewFbRank = true;  //행거에서 리워드를 받았는지 여부를 보여주는 창을 열어줌을 결정하는 불린변수//
                        //페북 리워드 받을 수 있는 등수인지 체크//
                        if (fbRank <= fbRewardGrade)
                        {
                            Debug.Log("페북 리워드 받음 ::: 등수 ::: " + fbRank);
                            Debug.Log("리워드타임 :: " + System.DateTime.UtcNow.ToBinary().ToString());
                            ValueDeliverScript.myRewardTime = System.DateTime.UtcNow.ToBinary().ToString();
                            isFbReward = true;
                            //페북 랭크에서 리워드를 받는 메소드를 실행한다//
                            //이 메소드가 실행이 되면 내가 받을 리워드가 임시로 messageData 형태로 저장이 된다//
                            fbReward = myFbRewardCheck(fbRank, fbReward);
                            ValueDeliverScript.fbReward = fbReward;
                        }
                    }
                    ////////////////////////////////////////////////////////////////
                    //페북 리워드 여부 조사-가능하면 임시메세지 변수로 저장하도록 설정//
                    //페북 리워드 여부 조사-가능하면 임시메세지 변수로 저장하도록 설정//
                    //페북 리워드 여부 조사-가능하면 임시메세지 변수로 저장하도록 설정//



                    //월드 리워드 여부 조사-가능하면 임시메세지 변수로 저장하도록 설정//
                    //월드 리워드 여부 조사-가능하면 임시메세지 변수로 저장하도록 설정//
                    //월드 리워드 여부 조사-가능하면 임시메세지 변수로 저장하도록 설정//
                    ////////////////////////////////////////////////////////////////
                    //월드 리워드 받을 시간이 되었는지 체크
                    interDays = 0;
                    while (wdDefaultTime.AddDays(wRankInterDay * interDays) < System.DateTime.UtcNow) interDays += 1;

                    //아직 한번도 리워드를 받은적이 없거나 ((ValueDeliverScript.myRewardTime 이 0 이거나))
                    //리워드 받은 시간이 지난시즌마지막 날짜보다 작으면//
                    if (ValueDeliverScript.myRewardTime == "0" || wdDefaultTime.AddDays(wRankInterDay * (interDays - 1)) > convertMRTime)
                    {
                        ValueDeliverScript.isNewWdRank = true;  //행거에서 리워드를 받았는지 여부를 보여주는 창을 열어줌을 결정하는 불린변수//
                        //월드 리워드 받을 수 있는 등수인지 체크//
                        if (wdRank <= wdRewardGrade)
                        {
                            Debug.Log("월드 리워드 받음 ::: 등수 ::: " + wdRank);
                            Debug.Log("리워드타임 :: " + System.DateTime.UtcNow.ToBinary().ToString());
                            ValueDeliverScript.myRewardTime = System.DateTime.UtcNow.ToBinary().ToString();
                            isWdReward = true;
                            //월드 랭크에서 몇개의 리워드를 받을 수 있는지 체크하여 배열 크기를 정한다//
                            int msgCount = 0;
                            if (wdRank < 21) msgCount = 3; else msgCount = 2;
                            wdReward = new MessageDataS[msgCount];

                            for (int i = 0; i < msgCount; i++)
                            {
                                wdReward[i] = myWRewardCheck(wdRank, i, wdReward[i]);
                            }

                            ValueDeliverScript.wdReward = wdReward;
                        }
                    }
                    //여기까지 임시 변수에 보상을 마련//
                    ////////////////////////////////////////////////////////////////
                    //월드 리워드 여부 조사-가능하면 임시메세지 변수로 저장하도록 설정//
                    //월드 리워드 여부 조사-가능하면 임시메세지 변수로 저장하도록 설정//
                    //월드 리워드 여부 조사-가능하면 임시메세지 변수로 저장하도록 설정//


                    //임시로 받은 메세지 변수들을 기존 메세지 변수 배열과 통합하는 부분//
                    //페북이나 월드 중 하나 이상 등수 안에 들었으면 서버에서 나의 받은 메세지(메일) 정보를 최신 정보로 다시 불러온다//
                    if (isFbReward == true || isWdReward == true)
                    {
                        //우선 정보를 갱신하기 위해 나의 메세지 함의 데이터를 다시 불러온다//
                        yield return StartCoroutine(jws.GetMailInfo());

                        //페북랭킹 리워드로 받은 것들이 있으면 메세지 변수에 모두 추가 하여준다//
                        if (isFbReward == true)
                        {
                            MessageDataS[] tempMsg = ValueDeliverScript.messageData;
                            ValueDeliverScript.messageData = new MessageDataS[tempMsg.Length + 1];
                            for (int i = 0; i < tempMsg.Length; i++)
                            {
                                ValueDeliverScript.messageData[i] = tempMsg[i];
                            }
                            ValueDeliverScript.messageData[tempMsg.Length] = fbReward;
                        }
                        //월드랭킹 리워드로 받은 것들이 있으면 메세지 변수에 모두 추가 하여준다//
                        if (isWdReward == true)
                        {
                            MessageDataS[] tempMsg = ValueDeliverScript.messageData;
                            ValueDeliverScript.messageData = new MessageDataS[tempMsg.Length + wdReward.Length];
                            for (int i = 0; i < tempMsg.Length; i++)
                            {
                                ValueDeliverScript.messageData[i] = tempMsg[i];
                            }
                            for (int i = 0; i < wdReward.Length; i++)
                            {
                                ValueDeliverScript.messageData[tempMsg.Length + i] = wdReward[i];
                            }
                        }
                        //랭킹 리워드로 받은 것들을 메세지 변수에 모두 추가 하여준다//

                        //받은 리워드 수가 50이 넘는지 확인하고 넘으면 시간상 오래된 것부터 삭제하여 준다//
                        //받은 리워드 수가 50이 넘는지 확인하고 넘으면 시간상 오래된 것부터 삭제하여 준다//
                        Debug.Log("111:::여기서 메시지 정리로 가는가?:::111");
                        if (ValueDeliverScript.messageData.Length > 50) OverMsg50();
                        //받은 리워드 수가 50이 넘는지 확인하고 넘으면 시간상 오래된 것부터 삭제하여 준다//
                        //받은 리워드 수가 50이 넘는지 확인하고 넘으면 시간상 오래된 것부터 삭제하여 준다//


                        //로딩바를 꽉 채워준다//
                        GameObject.Find("LoadingBar").GetComponent<LoadingBarScript>().LoadingBarFill();

                        //변경된 메세지 함 변수를 서버에 저장한다//
                        UpdateMsgToServer01();
                        //변경된 메세지 함 변수를 서버에 저장한다// 변경된 내용을 저장하는 것이기 때문에 myrewardTime도 같이 변경된 내용을 저장한다//
                        //지금 여기서 저장하는 가장 큰 이유는 밸류딜리버에 있는 myRewardTime 을 저장하기 위함이다.//
                        yield break;
                    }
                    //임시로 받은 메세지 변수들을 기존 메세지 변수 배열과 통합하는 부분//
                    //임시로 받은 메세지 변수들을 기존 메세지 변수 배열과 통합하는 부분//


                    else
                    {
                        if (ValueDeliverScript.messageData.Length > 50)
                        {
                            Debug.Log("222:::여기서 메시지 정리로 가는가?:::222");
                            OverMsg50();
                            yield return StartCoroutine(GameObject.Find("JoywingServer").GetComponent<UpdateUserInfo>().UpdateMailInfo(LoadHanger));
                            yield break;
                        }
                        else
                        {
                            Debug.Log("여기서 바로 행거를 로딩한다는 것은 메세지 부분에 변경사항이 없기 때문에 서버에 내 정보 저장이 아무것도 안 일어난다는 것이다.");
                            GameObject.Find("LoadingBar").GetComponent<LoadingBarScript>().LoadingBarFill();
                            yield return new WaitForSeconds(0.5f);
                            LoadHanger();
                            yield break;
                        }

                    }
                }
            }
            else
            {
                //Debug.Log("NextScene  ::::   Failed");
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    void UpdateMsgToServer01()
    {
        StartCoroutine(GameObject.Find("JoywingServer").GetComponent<UpdateUserInfo>().UpdateGiftInfo(UpdateMsgToServer02));
    }

    void UpdateMsgToServer02()
    {
        StartCoroutine(GameObject.Find("JoywingServer").GetComponent<UpdateUserInfo>().UpdateMailInfo(LoadHanger));
    }

    void OverMsg50()
    {
        Debug.Log("현재 받은 메세지 수는? ::: " + ValueDeliverScript.messageData.Length);
        MessageDataS[] tempMsg = ValueDeliverScript.messageData;
        ValueDeliverScript.messageData = new MessageDataS[50];

        int tempCountStart = tempMsg.Length - 50;

        for (int i = tempCountStart; i < tempMsg.Length; i++)
            ValueDeliverScript.messageData[i - tempCountStart] = tempMsg[i];

        Debug.Log("정리된 메세지 수는? ::: " + ValueDeliverScript.messageData.Length);
    }

    void CheckRewardAble(RankDataS[] rData, bool isFb)
    {
        if (rData.Length == 0) return;
        //ValueDeliverScript.rankDataFB//
        //페이스북 친구 랭킹을 점수를 기준으로 재정렬하여준다//
        rData = BubbleSorting(rData);
        for (int i = 0; i < rData.Length; i++)
        {
            if (ValueDeliverScript.myFBid == rData[i].FbId)
            {
                if (isFb == true)
                {
                    ValueDeliverScript.myFbRank = i + 1;
                    break;
                }
                else if (isFb == false)
                {
                    ValueDeliverScript.myWdRank = i + 1;
                    break;
                }
            }
        }
    }

    MessageDataS myFbRewardCheck(int fbRank, MessageDataS fbReward)
    {
        string nowTime = System.DateTime.UtcNow.ToBinary().ToString();
        //등수를 이용하여 보상을 만들어 준다//
        switch (fbRank)
        {
            case 1:
                fbReward = new MessageDataS("FB01", "AeroGate", "4", "1", nowTime, "Get 1st Grade Rewards", null); break;
            case 2:
                fbReward = new MessageDataS("FB02", "AeroGate", "3", "5", nowTime, "Get 2nd Grade Rewards", null); break;
            case 3:
                fbReward = new MessageDataS("FB03", "AeroGate", "2", "2500", nowTime, "Get 3rd Grade Rewards", null); break;
        }
        //등수를 이용하여 보상을 만들어 준다//

        return fbReward;
    }

    MessageDataS myWRewardCheck(int wdRank, int giftNum, MessageDataS wdReward)
    {
        string nowTime = System.DateTime.UtcNow.ToBinary().ToString();

        //등수를 이용하여 보상을 만들어 준다//
        #region
        switch (wdRank)
        {
            case 1:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG01", "AeroGate", "4", "5", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG01", "AeroGate", "2", "30000", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG01", "AeroGate", "3", "30", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 2:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG02", "AeroGate", "4", "4", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG02", "AeroGate", "2", "25000", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG02", "AeroGate", "3", "25", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 3:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG03", "AeroGate", "4", "3", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG03", "AeroGate", "2", "20000", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG03", "AeroGate", "3", "20", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 4:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG04", "AeroGate", "4", "2", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG04", "AeroGate", "2", "10000", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG04", "AeroGate", "3", "15", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 5:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG05", "AeroGate", "4", "2", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG05", "AeroGate", "2", "10000", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG05", "AeroGate", "3", "15", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 6:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG06", "AeroGate", "4", "2", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG06", "AeroGate", "2", "10000", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG06", "AeroGate", "3", "15", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 7:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG07", "AeroGate", "4", "2", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG07", "AeroGate", "2", "10000", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG07", "AeroGate", "3", "15", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 8:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG08", "AeroGate", "4", "2", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG08", "AeroGate", "2", "10000", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG08", "AeroGate", "3", "15", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 9:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG09", "AeroGate", "4", "2", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG09", "AeroGate", "2", "10000", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG09", "AeroGate", "3", "15", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 10:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG10", "AeroGate", "4", "2", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG10", "AeroGate", "2", "10000", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG10", "AeroGate", "3", "15", nowTime, "Get World Grade Rewards", null); break;
                }
                break;




            case 11:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG11", "AeroGate", "4", "1", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG11", "AeroGate", "2", "7500", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG11", "AeroGate", "3", "10", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 12:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG12", "AeroGate", "4", "1", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG12", "AeroGate", "2", "7500", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG12", "AeroGate", "3", "10", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 13:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG13", "AeroGate", "4", "1", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG13", "AeroGate", "2", "7500", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG13", "AeroGate", "3", "10", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 14:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG14", "AeroGate", "4", "1", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG14", "AeroGate", "2", "7500", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG14", "AeroGate", "3", "10", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 15:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG15", "AeroGate", "4", "1", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG15", "AeroGate", "2", "7500", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG15", "AeroGate", "3", "10", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 16:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG16", "AeroGate", "4", "1", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG16", "AeroGate", "2", "7500", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG16", "AeroGate", "3", "10", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 17:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG17", "AeroGate", "4", "1", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG17", "AeroGate", "2", "7500", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG17", "AeroGate", "3", "10", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 18:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG18", "AeroGate", "4", "1", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG18", "AeroGate", "2", "7500", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG18", "AeroGate", "3", "10", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 19:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG19", "AeroGate", "4", "1", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG19", "AeroGate", "2", "7500", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG19", "AeroGate", "3", "10", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 20:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG20", "AeroGate", "4", "1", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG20", "AeroGate", "2", "7500", nowTime, "Get World Grade Rewards", null); break;
                    case 2: wdReward = new MessageDataS("WG20", "AeroGate", "3", "10", nowTime, "Get World Grade Rewards", null); break;
                }
                break;



            case 21:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG21", "AeroGate", "2", "5000", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG21", "AeroGate", "3", "5", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 22:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG22", "AeroGate", "2", "5000", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG22", "AeroGate", "3", "5", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 23:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG23", "AeroGate", "2", "5000", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG23", "AeroGate", "3", "5", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 24:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG24", "AeroGate", "2", "5000", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG24", "AeroGate", "3", "5", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 25:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG25", "AeroGate", "2", "5000", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG25", "AeroGate", "3", "5", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 26:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG26", "AeroGate", "2", "5000", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG26", "AeroGate", "3", "5", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 27:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG27", "AeroGate", "2", "5000", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG27", "AeroGate", "3", "5", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 28:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG28", "AeroGate", "2", "5000", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG28", "AeroGate", "3", "5", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 29:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG29", "AeroGate", "2", "5000", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG29", "AeroGate", "3", "5", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
            case 30:
                switch (giftNum)
                {
                    case 0: wdReward = new MessageDataS("WG30", "AeroGate", "2", "5000", nowTime, "Get World Grade Rewards", null); break;
                    case 1: wdReward = new MessageDataS("WG30", "AeroGate", "3", "5", nowTime, "Get World Grade Rewards", null); break;
                }
                break;
        }
        #endregion
        //등수를 이용하여 보상을 만들어 준다//

        return wdReward;
    }


    void LoadHanger()
    {
        ValueDeliverScript.AlreadyAppStart = true;
        //yield return new WaitForSeconds(1f);
        Application.LoadLevel("Hangar");
    }




    System.DateTime StringTimeToDateTime(string stringTime)
    {
        Debug.Log("stringTime :: " + stringTime);
        System.DateTime returnTime = System.DateTime.UtcNow;
        returnTime = DateTime.FromBinary(Convert.ToInt64(double.Parse(stringTime)));

        return returnTime;
    }


    //지난주 점수를 기준으로 랭크를 버블 소팅 할 수 있게 해주는 메소드//
    RankDataS[] BubbleSorting(RankDataS[] friendData)
    {
        if (friendData.Length == 0) return friendData;
        string myNick = ValueDeliverScript.Nick;
        int rLength = friendData.Length;
        Debug.Log("지난주 첨수를 기준으로 등수 판별하는 곳 :: 친구는 몇명인가? :: " + rLength + " ::");

        RankDataS temp;

        for (int h = 0; h < rLength - 1; h++)
        {
            for (int i = 0; i < rLength - 1; i++)
            {
                int LWeekScore01 = 0;
                int LWeekScore02 = 0;
                int.TryParse(friendData[i].LWeekScore, out LWeekScore01);
                int.TryParse(friendData[i + 1].LWeekScore, out LWeekScore02);

                if (LWeekScore01 < LWeekScore02)
                {
                    temp = friendData[i];
                    friendData[i] = friendData[i + 1];
                    friendData[i + 1] = temp;
                }
            }
        }
        return friendData;
    }

}