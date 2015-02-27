using UnityEngine;
using System.Collections;

[System.Serializable]
public class ItemArray
{
    public GameObject[] item;
}

public class GameFriendTabScript : MonoBehaviour
{
    public RankDataS friendInfo;
    public GameObject gasStatusOff;
    public GameObject gasStatusOn;
    public GameObject fuelRemainTime;

    public ItemArray[] item;


    bool isNetwork = false;

    GameObject serverLoadingPanel;

    PrepareReadyScript prScript;

    void Awake()
    {
        prScript = GameObject.Find("PrepareReady").GetComponent<PrepareReadyScript>();
        serverLoadingPanel = GameObject.Find("Windows").transform.FindChild("ServerLoadingPanel").gameObject;
    }
    public void inputFriendInfo(RankDataS input)
    {
        friendInfo = input;
    }

    public void SendMessageFuel()
    {
        Debug.Log("연료주기 여기 오냥????");

        GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().OpenDirectRequest(friendInfo.FbId, SeccessSendFuel01);
        StartCoroutine(NetworkWait());
    }

    MyDelegateNS.NextFuncD nextFD;
    void SeccessSendFuel01()
    {
        //먼저 우리쪽 서버에 저장을 위해 코드를 실행한다.//SendMessageFuel
        StartCoroutine(GameObject.Find("GameManager").GetComponent<UpdateUserInfo>().UpdateSendMailInfo(friendInfo.FbId, SeccessSendFuel02));
    }

    void SeccessSendFuel02()
    {
        ValueDeliverScript.buddyPoint += 5;
        ChangeBuddyPoint();
        ValueDeliverScript.SaveGameData(SeccessSendFuel03);
    }


    //public GameObject friendshipPoint;
    //public GameObject gageBar;
    //public GameObject point100;
    //public GameObject pointAmount;
    //public GameObject friendshipPointIcon;

    //딴곳에서 임시로 가지고 온것//
    public void ChangeBuddyPoint()
    {
        //GameObject.Find("PostGameInfoManager").GetComponent<PostUserGameInfo>().PostGameInfo();

        int gage100Int = ValueDeliverScript.buddyPoint / 100;
        int gageBarInt = ValueDeliverScript.buddyPoint % 100;

        if (gageBarInt < 0)
            gageBarInt = 100 + gageBarInt;

        prScript.point100.GetComponent<UILabel>().text = gage100Int.ToString("00");

        //수령가능한 친구박스가 없으면 숫자"00"을 안보이게 한다// 
        if (gage100Int <= 0) prScript.point100.GetComponent<UILabel>().text = "";

        prScript.gageBar.GetComponent<UIFilledSprite>().fillAmount = gageBarInt / 100f;
        prScript.pointAmount.GetComponent<UILabel>().text = gageBarInt + "/100";

        Debug.Log("ChangeShowObject01");

        //포인트가 100을 넘지 못하면 친구박스 받을 수 있는 기능들과 그와 관련된 숫자이미지들도 안보이게 처리한다//
        if (ValueDeliverScript.buddyPoint < 100)
        {
            prScript.point100.GetComponent<UILabel>().text = "";
            prScript.transform.FindChild("FriendPointBtn").gameObject.SetActive(false);
            prScript.friendshipPointIcon.GetComponent<UISprite>().spriteName = "Icn_GiftBoxOff";
        }
        else
        {
            prScript.transform.FindChild("FriendPointBtn").gameObject.SetActive(true);
            prScript.friendshipPointIcon.GetComponent<UISprite>().spriteName = "Icn_GiftBoxOn";
            prScript.animation.Play("PrepareReadyAnim05");

        }
    }
    //딴곳에서 임시로 가지고 온것//



    void SeccessSendFuel03()
    {
        Debug.Log("연료보내기 여기옴? 007_1");

        //팝업창 보이게 함//
        GameObject fuelSend = GameObject.Find("GameManager").GetComponent<HangarManager>().fuelSend;
        HangarPopupController hpController = GameObject.Find("GameManager").GetComponent<HangarPopupController>();
        hpController.AddPopWin(fuelSend, 0);


        //우리쪽 서버에까지 적용이 다 끝나면 그때서야 비로소 앱 터치를 막은 것을 풀어준다//
        isNetwork = false;
        Debug.Log("연료보내기 여기옴? 007_2 :: isNetwork :: " + isNetwork);
        serverLoadingPanel.SetActive(false);
        Debug.Log("연료 지급 완료!");
        gasStatusOn.SetActive(false);
        gasStatusOff.SetActive(true);
        fuelRemainTime.SetActive(true);
        fuelRemainTime.GetComponent<UILabel>().text = "90m";
        friendInfo.FuelSendTime = (System.DateTime.UtcNow).ToBinary().ToString();

        string fbId = friendInfo.FbId;

        int rLength = 0;
        if (ValueDeliverScript.rankDataFB.Length == null) rLength = 0;

        if (rLength > 0)
        {
            for (int i = 0; i < rLength; i++)
            {
                if (fbId == ValueDeliverScript.rankDataFB[i].FbId)
                {
                    ValueDeliverScript.rankDataFB[i].FuelSendTime = friendInfo.FuelSendTime;
                    Debug.Log("Fuel Send Time ::: " + ValueDeliverScript.rankDataFB[i].FuelSendTime);
                    break;
                }
            }
        }

        ValueDeliverScript.SaveFuelSendTime(friendInfo.FbId , friendInfo.FuelSendTime);
        Debug.Log("연료보내기 여기옴? 007_3 :: isNetwork :: " + isNetwork);
    }


    private void ShowFriendinfoWindowTab()
    {
        GameObject.Find("GameManager").GetComponent<HangarManager>().ShowFriendInfoWindow(friendInfo);
    }

    IEnumerator NetworkWait()
    {
        serverLoadingPanel.SetActive(true);
        isNetwork = true;

        yield return new WaitForSeconds(10f);
        if (isNetwork == true)
        {
            serverLoadingPanel.SetActive(false);

            Debug.Log("네트웍이 불안합니다");
            //네트웍이 불안하다는 정보를 띄워주고 앱을 강제로 종료시키거나 또는 다시 시도케 한다//
        }
    }
}