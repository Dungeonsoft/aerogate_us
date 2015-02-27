using UnityEngine;
using System.Collections;

public class RecieveAllScript : MonoBehaviour {

    MessageDataS[] msgDataTemp;
    bool isNetwork = false;

    GameObject serverLoadingPanel;
    void Awake()
    {
        serverLoadingPanel = GameObject.Find("Windows").transform.FindChild("ServerLoadingPanel").gameObject;
    }
    
    //여기서 모든 메세지를 받는 메소드를 실행한다//아래부분이 모든 메세지를 받는 메소드이다//
    public void AllMessageAccept()
    {
        //메세지 탭이 보였다 안보였다 자동으로 하는 기능을 끔//
        GameObject.Find("MessageGrid").GetComponent<RankViewControl>().IsAbleF();
        StartCoroutine(AcceptMsg());
        //네트웍 송수신이 다 끝날때까지 화면 터치를 막아주는 코루틴을 실행한다//
        StartCoroutine(NetworkWait());
    }

    IEnumerator AcceptMsg()
    {
        Transform msgGrid = GameObject.Find("MessageGrid").transform;

        int count = msgGrid.childCount;

        for (int i = 0; i < count; i++)
        {
            msgGrid.GetChild(i).gameObject.SetActive(true);
            msgGrid.GetChild(i).GetComponent<MessageTabScript>().RevieveMsgAll(false);
            yield return new WaitForSeconds(0.05f);
        }

        //기존 메세지 데이터를 임시 변수 배열에 넣어둔다.
        msgDataTemp = ValueDeliverScript.messageData;

        StartCoroutine(GameObject.Find("GameManager").GetComponent<UpdateUserInfo>().GetMailInfoBefoeSend(recieveMsg01));


        //ValueDeliverScript.SaveGameData();
    }

    void recieveMsg01()
    {
        string msgTime= "";
        //새로운 데이터는 길이가 다를 수 있으니 하나씩 비교해 가면서 같은 것만 골라서 삭제해준다//
        for (int i = 0; i < msgDataTemp.Length; i++)
        {
            msgTime = msgDataTemp[i].Time;

            for (int ii = 0; ii < ValueDeliverScript.messageData.Length; ii++)
            {
                if (msgTime == ValueDeliverScript.messageData[ii].Time)
                {
                    Debug.Log("I 값은 뭔가? ::: " + ii);
                    MessageDataS[] messageDataTemp = new MessageDataS[ValueDeliverScript.messageData.Length - 1];

                    int kk = 0;
                    for (int j = 0; j < ii; j++)
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
        }

        Debug.Log("메세지 갯수 ::: " + ValueDeliverScript.messageData.Length);
        StartCoroutine(GameObject.Find("GameManager").GetComponent<UpdateUserInfo>().UpdateMailInfo(recieveMsg02));
    }

    void recieveMsg02()
    {
        ValueDeliverScript.SaveGameData(EndNetwork);
        GameObject msgItemGet = GameObject.Find("GameManager").GetComponent<HangarManager>().msgItemGet;
        HangarPopupController hpController = GameObject.Find("GameManager").GetComponent<HangarPopupController>();
        hpController.AddPopWin(msgItemGet, 0);
    }

    //여기까지 와서 isNetwork를 false로 변경해준다면 데이터 송수신이 아주 원활히 이루어진 것//
    void EndNetwork()
    {
        //여기서 IsAbleF에 인자값으로 true를 넣어주면 항시 탭정렬(보임과 안보임) 하는 기능을
        //끔과 동시에 지정된 그리드의 모든 하위 오브젝트를 제거하여준다//
        GameObject.Find("MessageGrid").GetComponent<RankViewControl>().IsAbleF(true);
        isNetwork = false;
        serverLoadingPanel.SetActive(false);
        GameObject.Find("NewIcn").SetActive(false);//메세지가 있다는 표시를 해주는 붉은색에 하얀글씩 아이콘을 안 보이게 한다//
        GameObject.Find("AllMessageBtn").SetActive(false);//리시브올 버튼을 안 보이게 해준다//

    }


    //잠시간 화면을 터치 못하게 막아주는 역할을 한다//
    //10초 이후에도 데이터 송수신이 잘 되질 않아 처리가 되지 않았을때는 네트웍이 불안하다는 내용을 띄워준다//
    //현재는 디버그로만 존재//
    IEnumerator NetworkWait()
    {
        serverLoadingPanel.SetActive(true);
        isNetwork = true;
        yield return new WaitForSeconds(20f);
        //10초가 지났는데도 여전히 isnetwork가 트루이면 네트웍에 문제가 있다고 판단하여 디버그를 찍어준다//
        if (isNetwork == true)
        {
            serverLoadingPanel.SetActive(false);
            isNetwork = false;
            Debug.Log("네트웍이 불안합니다");
            //네트웍이 불안하다는 정보를 띄워주고 앱을 강제로 종료시키거나 또는 다시 시도케 한다//
        }
    }

    //void OnEnable()
    //{
    //    Debug.LogError("여기서 켜지냐?");
    //}
}
