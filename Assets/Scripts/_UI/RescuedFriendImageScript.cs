using UnityEngine;
using System.Collections;

public class RescuedFriendImageScript : MonoBehaviour {

    public GameObject[] friendCheck;
    public GameObject[] friendImgObj;

    bool[] isSendRescueArlam;

    void Awake()
    {
        isSendRescueArlam = new bool[4];

        isSendRescueArlam[0] = false;
        isSendRescueArlam[1] = false;
        isSendRescueArlam[2] = false;
        isSendRescueArlam[3] = false;

    }

    void Start()
    {
        ValueDeliverScript.rescueArlamFriendNick = "";
        ValueDeliverScript.rescueArlamFriendId = "";
        ValueDeliverScript.rescueFriendBlock = false;
        ValueDeliverScript.isSendRescueArlamNum = -1;

    }

    void FriendImg001()
    {
        if (isSendRescueArlam[0]) return;
        //isSendRescueArlam[0] = true;
        if (friendImgObj[0].GetComponent<FriendImgInfo>().id == "") return;
        checkFalse(0);
        ValueDeliverScript.rescueArlamFriendNick = friendImgObj[0].GetComponent<FriendImgInfo>().nickname;
        ValueDeliverScript.rescueArlamFriendId = friendImgObj[0].GetComponent<FriendImgInfo>().id;
        ValueDeliverScript.rescueFriendBlock = friendImgObj[0].GetComponent<FriendImgInfo>().isBlock;
        ValueDeliverScript.isSendRescueArlamNum = 0;
    }

    void FriendImg002()
    {
        if (isSendRescueArlam[1]) return;
        //isSendRescueArlam[1] = true;
        if (friendImgObj[1].GetComponent<FriendImgInfo>().id == "") return;
        checkFalse(1);
        ValueDeliverScript.rescueArlamFriendNick = friendImgObj[1].GetComponent<FriendImgInfo>().nickname;
        ValueDeliverScript.rescueArlamFriendId = friendImgObj[1].GetComponent<FriendImgInfo>().id;
        ValueDeliverScript.rescueFriendBlock = friendImgObj[1].GetComponent<FriendImgInfo>().isBlock;
        ValueDeliverScript.isSendRescueArlamNum = 1;
    }

    void FriendImg003()
    {
        if (isSendRescueArlam[2]) return;
        //isSendRescueArlam[2] = true;
        if (friendImgObj[2].GetComponent<FriendImgInfo>().id == "") return;
        checkFalse(2);
        ValueDeliverScript.rescueArlamFriendNick = friendImgObj[2].GetComponent<FriendImgInfo>().nickname;
        ValueDeliverScript.rescueArlamFriendId = friendImgObj[2].GetComponent<FriendImgInfo>().id;
        ValueDeliverScript.rescueFriendBlock = friendImgObj[2].GetComponent<FriendImgInfo>().isBlock;
        ValueDeliverScript.isSendRescueArlamNum = 2;
    }

    void FriendImg004()
    {
        if (isSendRescueArlam[3]) return;
        //isSendRescueArlam[3] = true;
        if (friendImgObj[3].GetComponent<FriendImgInfo>().id == "") return;
        checkFalse(3);
        ValueDeliverScript.rescueArlamFriendNick = friendImgObj[3].GetComponent<FriendImgInfo>().nickname;
        ValueDeliverScript.rescueArlamFriendId = friendImgObj[3].GetComponent<FriendImgInfo>().id;
        ValueDeliverScript.rescueFriendBlock = friendImgObj[3].GetComponent<FriendImgInfo>().isBlock;
        ValueDeliverScript.isSendRescueArlamNum = 3;
    }



    void checkFalse(int val)
    {
        foreach (var check in friendCheck)
        {
            check.SetActive(false);
        }
        friendCheck[val].SetActive(true);
    }

    public void IsSendRescueArlamCheck(int CheckNum)
    {
        friendImgObj[ValueDeliverScript.isSendRescueArlamNum].SetActive(false);
        friendCheck[ValueDeliverScript.isSendRescueArlamNum].SetActive(false);
        isSendRescueArlam[CheckNum] = true;
        ValueDeliverScript.isSendRescueArlamNum = -1;
        ValueDeliverScript.rescueArlamFriendNick = "";
    }
}
