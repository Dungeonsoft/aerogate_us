using UnityEngine;
using System.Collections;

public class PrepareReadyScript : MonoBehaviour
{

    public GameObject specialMsg;
    public GameObject friendshipPoint;
    public GameObject operMessageText;
    public GameObject UpgradePointMessage;
    public GameObject SpecialAttackOn;

    public GameObject friendshipPointIcon;

    bool isGiftBox = false;

    public GameObject gageBar;
    public GameObject point100;
    public GameObject pointAmount;

    public FlightUpointSetScript flightUpointSetScript;

    public GameObject specialAttackOn;


    void Awake()
    {
        GageSetting();
    }

    public void GageSetting()
    {
        //GameObject.Find("PostGameInfoManager").GetComponent<PostUserGameInfo>().PostGameInfo();

        int gage100Int = ValueDeliverScript.buddyPoint / 100;
        int gageBarInt = ValueDeliverScript.buddyPoint % 100;

        if (gageBarInt < 0)
            gageBarInt = 100 + gageBarInt;

        point100.GetComponent<UILabel>().text = gage100Int.ToString("00");

        //수령가능한 친구박스가 없으면 숫자"00"을 안보이게 한다// 
        if (gage100Int <= 0) point100.GetComponent<UILabel>().text = "";

        gageBar.GetComponent<UIFilledSprite>().fillAmount = gageBarInt / 100f;
        pointAmount.GetComponent<UILabel>().text = gageBarInt + "/100";
    }


    public void ChangeShowObject01()
    {

        Debug.Log("ChangeShowObject01");

        specialMsg.SetActive(false);
        UpgradePointMessage.SetActive(false);

        friendshipPoint.SetActive(true);

        //포인트가 100을 넘지 못하면 친구박스 받을 수 있는 기능들과 그와 관련된 숫자이미지들도 안보이게 처리한다//
        if (ValueDeliverScript.buddyPoint < 100)
        {
            point100.GetComponent<UILabel>().text = "";
            transform.FindChild("FriendPointBtn").gameObject.SetActive(false);
            friendshipPointIcon.GetComponent<UISprite>().spriteName = "Icn_GiftBoxOff";
            isGiftBox = false;
        }
        else
        {
            transform.FindChild("FriendPointBtn").gameObject.SetActive(true);
            friendshipPointIcon.GetComponent<UISprite>().spriteName = "Icn_GiftBoxOn";
            isGiftBox = true;
        }

        if (operMessageText.activeSelf == true)
            operMessageText.SetActive(false);
        if (SpecialAttackOn.activeSelf == true)
            SpecialAttackOn.SetActive(false);
    }

    public void ChangeShowObject02()
    {
        Debug.Log("ChangeShowObject02");

        UpgradePointMessage.SetActive(false);

        {
            Debug.Log("위치3");
            flightUpointSetScript.CalRemainPoint();
            flightUpointSetScript.IsBtnAnimationFirst();
            flightUpointSetScript.RemainPointLabel();
        }

        friendshipPoint.SetActive(false);
    }

    public void ChangeShowObject03()
    {
        specialMsg.SetActive(false);
        friendshipPoint.SetActive(false);
        operMessageText.SetActive(false);
        specialAttackOn.SetActive(false);
        UpgradePointMessage.SetActive(true);
    }

    public void GiftBoxOn()
    {
        if (isGiftBox)
        {
            isGiftBox = false;
            Debug.Log("PrepareReadyAnim05");
            animation.Play("PrepareReadyAnim05");
        }
    }


    public GameObject noTouchPanel;

    public void NoTouchStart()
    {
        noTouchPanel.SetActive(true);
    }

    public void NotouchEnd()
    {
        noTouchPanel.SetActive(false);
    }

}
