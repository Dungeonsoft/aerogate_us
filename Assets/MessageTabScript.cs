using UnityEngine;
using System.Collections;

public class MessageTabScript : MonoBehaviour
{
    public MessageDataS messageTab;
    bool isMoveHide = false;
    bool isPos = false;
    Vector3 pos;
    Vector3 pos1;
    float lerpVal;
    bool isNetwork = false;
    bool isOneMsg;
    GameObject serverLoadingPanel;

    // Use this for initialization
    void Awake()
    {
        serverLoadingPanel = GameObject.Find("Windows").transform.FindChild("ServerLoadingPanel").gameObject;
    }

    public void RecieveMsg()
    {
        RevieveMsgAll(true);
        StartCoroutine(NetworkWait());
    }

    public void RevieveMsgAll(bool isOneMsg = true)
    {
        this.isOneMsg = isOneMsg;
        Debug.Log("Message Tab :: To :: " + messageTab.To);
        Debug.Log("Message Tab :: From :: " + messageTab.From);
        Debug.Log("Message Tab :: Type :: " + messageTab.Type);
        Debug.Log("Message Tab :: Ea :: " + messageTab.Ea);
        Debug.Log("Message Tab :: Time ::" + messageTab.Time);
        Debug.Log("Message Tab :: Contents :: " + messageTab.Contents);

        switch (messageTab.Type)
        {
            case "1": //연료//
                {
                    Debug.Log("messageTab.Ea ::: " + messageTab.Ea);
                    if (int.Parse(messageTab.Ea) < 1 || messageTab.Ea == "" || messageTab.Ea == null) messageTab.Ea = "1";
                    GameObject.Find("GasRestLabel").GetComponent<GasRestLabelScript>().GasRest(int.Parse(messageTab.Ea), false);
                    break;
                }
            case "2": //동전//
                {
                    Debug.Log("messageTab.Ea ::: " + messageTab.Ea);
                    if (int.Parse(messageTab.Ea) < 1 || messageTab.Ea == "" || messageTab.Ea == null) messageTab.Ea = "1";
                    ValueDeliverScript.coinRest += int.Parse(messageTab.Ea);
                    GameObject.Find("GoldRestLabel").GetComponent<UILabel>().text = ValueDeliverScript.coinRest.ToString();
                    break;
                }
            case "3": //다이아몬드//
                {
                    Debug.Log("messageTab.Ea ::: " + messageTab.Ea);
                    if (int.Parse(messageTab.Ea) < 1 || messageTab.Ea == "" || messageTab.Ea == null) messageTab.Ea = "1";
                    ValueDeliverScript.medalRest += int.Parse(messageTab.Ea);
                    GameObject.Find("MedalRestLabel").GetComponent<UILabel>().text = ValueDeliverScript.medalRest.ToString(); //화면에 표시되는 다이아몬드 양을 다시 계산하여 재표시하여줌.
                    break;
                }
            case "4": //강화포인트//
                {
                    Debug.Log("messageTab.Ea ::: " + messageTab.Ea);
                    if (int.Parse(messageTab.Ea) < 1 || messageTab.Ea == "" || messageTab.Ea == null) messageTab.Ea = "1";
                    ValueDeliverScript.upgradePoint += int.Parse(messageTab.Ea);
                    //GameObject.Find("GoldRestLabel").GetComponent<UILabel>().text = ValueDeliverScript.coinRest.ToString();
                    break;
                }
        }

        //이 메세지를 받았으니 ValueDeliverScript의 messageData에서 이 메세지 부분을 삭제하는 기능을 구현//
        if (isOneMsg == true)
        {
            //이 코드에서 현재 나의 메세지 데이터를 서버에서 가지고 와 다시 밸류딜리버리의 메세지데이터에 넣어주는 일을 한다//
            //그 일이 다 끝나면 recieveMsg01 메소드를 딜리게이트 기능을 이용하여 호출한다//
            StartCoroutine(GameObject.Find("GameManager").GetComponent<UpdateUserInfo>().GetMailInfoBefoeSend(recieveMsg01));
            //이 메세지를 받았으니 ValueDeliverScript의 messageData에서 이 메세지 부분을 삭제하는 기능을 구현//
            isMoveHide = true;
        }
    }

    //서버에서 나의 최신 메세지 데이터를 가지고 와서 가공(받은 메세지 삭제)을 한다//
    void recieveMsg01()
    {
        Debug.Log("recieveMsg01_001");
        //실제 이곳에서 받은 메시지 탭을 삭제하여 준다//
        for (int i = 0; i < ValueDeliverScript.messageData.Length; i++)
        {
            if (messageTab.Time == ValueDeliverScript.messageData[i].Time)
            {
                Debug.Log("I 값은 뭔가? ::: " + i);
                MessageDataS[] messageDataTemp = new MessageDataS[ValueDeliverScript.messageData.Length - 1];

                int kk = 0;
                for (int j = 0; j < i; j++)
                {
                    messageDataTemp[j] = ValueDeliverScript.messageData[j];
                    kk++;
                }
                for (int k = kk; k < messageDataTemp.Length; k++)
                {
                    messageDataTemp[k] = ValueDeliverScript.messageData[k + 1];
                }

                ValueDeliverScript.messageData = messageDataTemp;
                break;
            }
        }
        Debug.Log("recieveMsg01_002");

        Debug.Log("메세지 갯수 ::: " + ValueDeliverScript.messageData.Length);
        if (ValueDeliverScript.messageData.Length > 0)
        {
            for (int i = 0; i < ValueDeliverScript.messageData.Length; i++)
            {
                Debug.Log("어떤 기프트를 주었는가? ::: " + ValueDeliverScript.messageData[i].Type);
            }
        }
        else
        {
            GameObject.Find("FriendRankWindow").transform.FindChild("NewIcn").gameObject.SetActive(false);
        }

        //가공된 메세지 데이터를 저장한다//
        StartCoroutine(GameObject.Find("GameManager").GetComponent<UpdateUserInfo>().UpdateMailInfo(recieveMsg02));

    }

    bool hideTab = false;
    //나의 변경된 나머지 모든 데이터를 저장한다//
    void recieveMsg02()
    {
        ValueDeliverScript.SaveGameData(EndNetwork);
    }

    //여기까지 와서 isNetwork를 false로 변경해준다면 데이터 송수신이 아주 원활히 이루어진 것//
    void EndNetwork()
    {
        isNetwork = false;
        hideTab = true;
    }


    //잠시간 화면을 터치 못하게 막아주는 역할을 한다//
    //10초 이후에도 데이터 송수신이 잘 되질 않아 처리가 되지 않았을때는 네트웍이 불안하다는 내용을 띄워준다//
    //현재는 디버그로만 존재//
    IEnumerator NetworkWait()
    {
        serverLoadingPanel.SetActive(true);
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


    void Update()
    {
        if (hideTab ==true)
        {
            if (isPos == false)
            {
                pos = transform.localPosition;
                pos1 = new Vector3(-1000, pos.y, pos.z);
                isPos = true;
            }

            transform.localPosition = Vector3.Lerp(pos, pos1, lerpVal);
            lerpVal += Time.deltaTime*2;

            if (lerpVal >= 1)
            {
                serverLoadingPanel.SetActive(false);

                GameObject msgItemGet = GameObject.Find("GameManager").GetComponent<HangarManager>().msgItemGet;
                HangarPopupController hpController = GameObject.Find("GameManager").GetComponent<HangarPopupController>();
                hpController.AddPopWin(msgItemGet, 0);

                transform.parent.GetComponent<RearrangeMessageScript>().RearrangeTabs(this.gameObject);
            }
        }
    }
}
