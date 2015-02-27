using UnityEngine;
using System.Collections;

public class RankViewControl : MonoBehaviour
{
    GameObject gameFriend;
    public int friendCount;
    bool isChildCountStart = false;
    public bool isAble = false;

    public void Start()
    {
        friendCount = this.transform.GetChildCount();   //목록의 수가 얼마나 되나 계산하여 저장.
    }

    //업뎃기능 사용여부 토글해주는 함수.
    public void IsAbleT()
    {
        Debug.Log("Tab Able");
        isAble = true;
    }

    public void IsAbleF(bool isMessage = false)
    {
        if (isMessage)
        {
            //메세지를 삭제할 때 이부분을 쓰려고 만든 것//
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        //Debug.Log("No Able");
        isAble = false;
    }


    void Update()
    {
        if (!isAble) return;
        //Debug.Log("탭 재정렬하러 여기 오는가?");

        if (isChildCountStart == false)
        {
            isChildCountStart = true;
            StartCoroutine(CountChild());
        }

        if (friendCount == 0) return;
        //Debug.Log("In Update!!");
        for (int i = 0; i < friendCount; i++)
        {
            //Debug.Log("For +++ "+i);
            gameFriend = this.transform.GetChild(i).gameObject;

            if (gameFriend.transform.localPosition.y + transform.localPosition.y > 350 || gameFriend.transform.localPosition.y + transform.localPosition.y < -800)
            {
                gameFriend.SetActive(false);
            }
            else
            {
                gameFriend.SetActive(true);
            }
            //Debug.Log(gameFriend.name + " : " + "SetActive : " + gameFriend.activeSelf + " : Position Y :" + gameFriend.transform.localPosition.y);
        }
        isAble = false;
    }

    IEnumerator CountChild()
    {
        while (true && isAble)
        {
            friendCount = this.transform.childCount;   //목록의 수가 얼마나 되나 계산하여 저장.
            yield return new WaitForSeconds(1f);
        }
    }

    void OnDisable()
    {
        isChildCountStart = false;
    }

}
