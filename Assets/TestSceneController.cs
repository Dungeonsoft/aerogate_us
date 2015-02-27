using UnityEngine;
using System.Collections;

struct TPopupWin
{
    public GameObject TpopupWin;
    public int TorderNum;

    public TPopupWin(GameObject pw,  int oNum)
    {
        TpopupWin = pw;
        TorderNum = oNum;
    }
}

public class TestSceneController : MonoBehaviour {

    public GameObject PopupWin01;
    public GameObject PopupWin02;
    public GameObject PopupWin03;
    public GameObject PopupWin04;
    public GameObject PopupWin05;

    ArrayList popupList = new ArrayList();

    void Awake()
    {
        Debug.Log(":::: 프로그램 시작 ::::");
        WindowOnOffStatus(window: PopupWin01, orderNum: 2);
        WindowOnOffStatus(window: PopupWin02, orderNum: 0);
        WindowOnOffStatus(window: PopupWin03, orderNum: 1);
        WindowOnOffStatus(window: PopupWin04, orderNum: 0);
        WindowOnOffStatus(window: PopupWin05, orderNum: 0);
    }

    void Start()
    {
        SortPopup(popupList);
        TPopupWin openWin = (TPopupWin)popupList[0];
        openWin.TpopupWin.SetActive(true);
    }

    void WindowOnOffStatus(GameObject window, int orderNum)
    {
        window.SetActive(false);
        TPopupWin win =new TPopupWin(window, orderNum);
        popupList.Add(win);
    }

    void SortPopup(ArrayList data)
    {
        Debug.Log(data[0]);
        Debug.Log(data[1]);
        Debug.Log(data[2]);
        Debug.Log(data[3]);
        Debug.Log(data[4]);
        TPopupWin tempP01 = new TPopupWin();
        TPopupWin tempP02 = new TPopupWin();
        for (int i = 0; i < data.Count - 1; i++)
        {
            for (int wNum = 0; wNum < data.Count - 1; wNum++)
            {
                tempP01 = (TPopupWin)data[wNum];
                Debug.Log("tempP01 :: " + tempP01.TorderNum);
                tempP02 = (TPopupWin)data[wNum + 1];
                Debug.Log("tempP02 :: " + tempP02.TorderNum);
                if (tempP01.TorderNum > tempP02.TorderNum)
                {
                    data[wNum] = tempP02;
                    data[wNum + 1] = tempP01;
                }
            }
        }
    }


    public void CloseWindow(GameObject Window, System.Action NextF = null)
    {
        Window.SetActive(false);
        if (NextF == null)
        {
            TPopupWin openWin;
            popupList.RemoveRange(0, 1);
            if (popupList.Count>0)
            {
                openWin = (TPopupWin)popupList[0];
                openWin.TpopupWin.SetActive(true);
            }
        }
        else NextF();
    }
}
