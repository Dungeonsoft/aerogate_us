using UnityEngine;
using System.Collections;

public class InviteBtnScript : MonoBehaviour {

    GameObject serverLoadingPanel;
    GameObject friendInvite;
    public GameObject noFbLoginWindow;
    bool isNetwork = false;

    void Awake()
    {
        serverLoadingPanel = GameObject.Find("Windows").transform.FindChild("ServerLoadingPanel").gameObject;
        friendInvite = GameObject.Find("GameManager").GetComponent<HangarManager>().friendInvite;
    }

    void InviteFriend()
    {
        if (ValueDeliverScript.myFBid == "" || ValueDeliverScript.myFBid == null)
        {
            GetComponent<HangarPopupController>().AddPopWin(noFbLoginWindow, 0);

            return;
        }

        Debug.Log("친구초대 시작");
        GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().OpenFriendSelector();
        serverLoadingPanel.SetActive(true);
        isNetwork = true;
        //StartCoroutine(NetworkWait());
    }

    public void EndNetworkWithFuel()
    {
        isNetwork = false;
        serverLoadingPanel.SetActive(false);
        //보상으로 가스를 하나 추가하여준다//
        ValueDeliverScript.SaveGameData(showPop);
    }

    public void EndNetworkWithoutAddFuel()
    {
        isNetwork = false;
        serverLoadingPanel.SetActive(false);
    }

    void showPop()
    {
        //맨처음엔 먼저 초대를 해본적이 있는가부터 시작(inviteDay키 여부 검사)// 
        //없으면 판별할 수 있게 inviteDay와 inviteCount를 세팅해준다//
        if (!PlayerPrefs.HasKey("inviteDay"))
        {
            PlayerPrefs.SetInt("inviteDay", System.DateTime.Today.DayOfYear);
            PlayerPrefs.SetInt("inviteCount", 0);
        }

        //같은 날짜인지 먼저 확인 아니면 새로운 날짜를 부여해주고 초대카운트를 0으로 만들어 준다.
        if (System.DateTime.Today.DayOfYear != PlayerPrefs.GetInt("inviteDay"))
        {
            PlayerPrefs.SetInt("inviteDay", System.DateTime.Today.DayOfYear);
            PlayerPrefs.SetInt("inviteCount", 0);
        }

        // 초대 수를 비교하여 최대 치를 못 넘게 만든다//
        int ivtCnt = PlayerPrefs.GetInt("inviteCount");
        if (ivtCnt < ValueDeliverScript.maxInvite)
        {
            if ((ivtCnt + ValueDeliverScript.inviteCount) >= ValueDeliverScript.maxInvite)
            {
                ValueDeliverScript.inviteCount = ValueDeliverScript.maxInvite - ivtCnt;
                PlayerPrefs.SetInt("inviteCount", ValueDeliverScript.maxInvite);
            }
            else
            {
                PlayerPrefs.SetInt("inviteCount", ivtCnt + ValueDeliverScript.inviteCount);
            }
        }
        else
        {
            ValueDeliverScript.inviteCount = 0;
        }

        GameObject.Find("GasRestLabel").GetComponent<GasRestLabelScript>().GasRest(ValueDeliverScript.inviteCount, false);
        HangarPopupController hpController = GameObject.Find("GameManager").GetComponent<HangarPopupController>();
        hpController.AddPopWin(friendInvite, 0, FriendInvteF);
    }


    void FriendInvteF()
    {
        Debug.Log("inviteDay" + PlayerPrefs.GetInt("inviteDay"));
        Debug.Log("inviteCount" + PlayerPrefs.GetInt("inviteCount"));
        Debug.Log("inviteDDDDDDCount" + ValueDeliverScript.inviteCount);
        friendInvite.transform.FindChild("Items/Item001/Label").GetComponent<UILabel>().text = "+" + ValueDeliverScript.inviteCount.ToString();
        if (ValueDeliverScript.inviteCount == 0)
        {
            System.DateTime nextDay = System.DateTime.Today.AddDays(1);
            System.DateTime now = System.DateTime.Now;
            System.TimeSpan remainTime = nextDay - now;

            float remainTimeHF = Mathf.Floor(float.Parse(remainTime.Hours.ToString())); 
            float remainTimeMF = Mathf.Floor(float.Parse(remainTime.Minutes.ToString()));


            friendInvite.transform.FindChild("Script").GetComponent<UILabel>().text = "Over Max Invitation\nCount Reset Remains: " + remainTimeHF + "h " + remainTimeMF + "min";
        }
        ValueDeliverScript.inviteCount = 0;
    }

    public IEnumerator NetworkWait()
    {
        isNetwork = true;
        yield return new WaitForSeconds(10f);
        //10초가 지났는데도 여전히 isnetwork가 트루이면 네트웍에 문제가 있다고 판단하여 디버그를 찍어준다//
        if (isNetwork == true)
        {
            serverLoadingPanel.SetActive(false);
            isNetwork = false;
            Debug.Log("네트웍이 불안합니다");
            //네트웍이 불안하다는 정보를 띄워주고 앱을 강제로 종료시키거나 또는 다시 시도케 한다//
        }
    }

}
