using UnityEngine;
using System.Collections;

public class AfterInitialScript : MonoBehaviour
{

    string inputNick;

    char[] inputNickChar;

    string[] badNick;

    JoywingServerScript jwsScript;
    #region Awake
    void Awake()
    {
        jwsScript = GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>();

        badNick = new string[] 
        {
            "sex","fuck","porn","Reinput Nick","suck","dick","cunt","annal","porno","Nickname","Please, Retyping"
        };
    }
    #endregion

    public void SetStart()
    {
        Debug.Log("::::::::::: SetStart ::::::::::::::::");

        ValueDeliverScript.AlreadyAppStart = false;
        
        //GameObject.Find("Anchor").transform.FindChild("FacebookBTN").gameObject.SetActive(false);
        //GameObject.Find("Anchor").transform.FindChild("LoadingBar").gameObject.SetActive(true);

        BoolFirstLogIn();
    }

    public void BoolFirstLogIn()
    {
        string nick = "";
        string userID = "";

        Debug.Log("유저 아이디 :::" + ValueDeliverScript.UserID+":::");
        Debug.Log("유저 닉네임 :::" + ValueDeliverScript.Nick + ":::");

        if (ValueDeliverScript.Nick != null)
        {
            nick = ValueDeliverScript.Nick;
        }

        if (ValueDeliverScript.UserID != null)
        {
            userID = ValueDeliverScript.UserID;
        }

        if (nick == "" || userID == "")
        {
            Debug.Log("No Nick");
            EnterNickWin();
        }
        else
        {
            //한번이상 게임을 실행했으면 바로 행거로 넘어갈 수 있도록 한다.
            //넘어가기 전에 랭크 데이터를 먼저 서버에서 부르도록 코드를 작성한다.

            GameObject.Find("Anchor").transform.FindChild("FacebookBTN").gameObject.SetActive(false);
            GameObject.Find("Anchor").transform.FindChild("LoadingBar").gameObject.SetActive(true);

            StartCoroutine(LoadMyDataNRank());
        }
    }

    //내정보를 로드하는 위치//
    public IEnumerator LoadMyDataNRank()
    {

        //버전체크//
        yield return StartCoroutine(jwsScript.CheckVersion());
        //버전체크//
        Debug.Log("StartGetData 시작점 ::: 여기 들어옴?" + GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>().isStartGetData);

        if (GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>().isStartGetData == false
            &&
            ValueDeliverScript.myFBid != "")
        {
            yield return StartCoroutine(jwsScript.StartGetData());
        }
        else
        {
            StartCoroutine(GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>().StartGetData2());
            GameObject.Find("LoadingBar").GetComponent<LoadingBarScript>().LoadingBarFill();
        }

        Debug.Log("LoadMyDataNRank 메서드 인가?");
        jwsScript.AfterReceiveUserIdData();
    }

    public void EnterNickWin()
    {
        if ((ValueDeliverScript.UserID != "" && ValueDeliverScript.Nick != "") || ValueDeliverScript.AlreadyAppStart == true)
        {
            MyDelegateNS.UsercheckDele UserCheckComplete = new MyDelegateNS.UsercheckDele(GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().UserCheckComplete);
            StartCoroutine(GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>().UpdateFBid(UserCheckComplete));
        }
        else
        {
            //Debug.Log("Enter Nick Win");
            GameObject.Find("Anchor").transform.FindChild("LogInWin").gameObject.SetActive(true);
        }
    }

    public void OnSubMit()
    {
        GameObject.Find("LogInWin/Input/Label").GetComponent<UILabel>().color = new Color(0.79f, 0.955f, 1, 1);
        //Debug.Log("OnSubMit!!!");
        inputNick = GameObject.Find("LogInWin/Input/Label").GetComponent<UILabel>().text;
        inputNickChar = inputNick.ToCharArray();
        string failText = "Reinput Nick";

        for (int i = 0; i < badNick.Length; i++)
        {
            if (inputNick.Contains(badNick[i]))
            {
                GameObject.Find("LogInWin/Input/Label").GetComponent<UILabel>().text = failText;
                GameObject.Find("LogInWin/Input/Label").GetComponent<UILabel>().color = new Color(1, 0, 0, 1);
                EnterNickWin();
                return;
            }
        }

        if (inputNickChar.Length > 15 || inputNickChar.Length < 3 || inputNick == "Nickname" || inputNick == "Please, Retyping")
        {
            GameObject.Find("LogInWin/Input/Label").GetComponent<UILabel>().text = failText;
            GameObject.Find("LogInWin/Input/Label").GetComponent<UILabel>().color = new Color(1, 0, 0, 1);
            EnterNickWin(); //글씨수가 1 이하 또는 10 이상이면 입력을 다시 하게 함.
        }
        else
        {
            GameObject.Find("LogInWin").SetActive(false);
            SendDataToServer();
        }
    }

    public void SendDataToServer()  //서버에 데이터(닉네임) 저장할때. 페이스북 아이디도 서버에 저장한다.//
    {
        //로그인 버튼들을 사라지게 하고 로딩바를 보여준다.//
        GameObject.Find("Anchor").transform.FindChild("FacebookBTN").gameObject.SetActive(false);
        GameObject.Find("Anchor").transform.FindChild("LoadingBar").gameObject.SetActive(true);

        ValueDeliverScript.Nick = inputNick;
        //기존에 있던것//
        GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>().SendNickData(inputNick);
        //새로 추가된 닉 생성 메소드//
        GameObject.Find("JoywingServer").GetComponent<JoywingServerScript>().StartNewIDInsert(inputNick);
    }

    public void ReceiveData()   //서버에 닉네임을 저장하고 유저아이디를 불러온 후 호출되는 메소드.
    {
        ValueDeliverScript.SaveGameData();      //서버에 데이터를 저장한다.
    }
}
