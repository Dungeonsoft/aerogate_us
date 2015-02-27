using UnityEngine;
using System.Collections;

public class ScoreTextScript : MonoBehaviour
{
    public GameObject highMessage;
    public GameObject highScoreText;

    int scorePlay = 0;
    int rollingScore = 0;
    // Use this for initialization
    void Awake()
    {
        Debug.Log("::::::::: 서버에 최고점수를 기록하게 함");
        Debug.Log("ValueDeliverScript.scorePlay :: " + ValueDeliverScript.scorePlay);
        Debug.Log("ValueDeliverScript.scoreHigh :: " + ValueDeliverScript.scoreHigh);
        Debug.Log("ValueDeliverScript.flightNumber : " + ValueDeliverScript.flightNumber);
        Debug.Log("ValueDeliverScript.isBreakGame :: " + ValueDeliverScript.isBreakGame);
        Debug.Log("::::::::: 서버에 최고점수를 기록하게 함");
        Debug.Log("::::::::: 서버에 최고점수를 기록하게 함");

        scorePlay = ValueDeliverScript.scorePlay;//플레이해서 나온 최고 점수//
        gameObject.GetComponent<UILabel>().text = "0";

        highMessage.SetActive(false);

        if (ValueDeliverScript.isTutComplete == 0) return;

        if (ValueDeliverScript.isTutComplete == 1)
        {
            gameObject.GetComponent<UILabel>().text = ValueDeliverScript.scorePlay.ToString();
            return;
        }



        if (ValueDeliverScript.isBreakGame == false && ValueDeliverScript.isHigh == true)
        {
            if (ValueDeliverScript.scoreHigh < ValueDeliverScript.scorePlay)
            {
                Debug.Log("::::::::::::::::::::::: 기록 :::::::::::::::::");
                Debug.Log("::::::::::::::::::::::: 기록 :::::::::::::::::");
                Debug.Log("::::::::::::::::::::::: 기록 :::::::::::::::::");

                highMessage.SetActive(true);
                ValueDeliverScript.scoreHigh = ValueDeliverScript.scorePlay;
                //ValueDeliverScript.lastScoreHigh = ValueDeliverScript.scorePlay;
                ValueDeliverScript.highFlight = ValueDeliverScript.flightNumber;
                ValueDeliverScript.highSkin = ValueDeliverScript.skinNumber;
                ValueDeliverScript.highBullet = ValueDeliverScript.bulletLevel;
                ValueDeliverScript.highBomb = ValueDeliverScript.activeBomb;
                ValueDeliverScript.highReinforce = ValueDeliverScript.activeReinforce;
                ValueDeliverScript.highAssist = ValueDeliverScript.activeAssist;
                ValueDeliverScript.highChar = ValueDeliverScript.activeOper;
                //게임을 종료후 이곳으로 이동하여 최고 기록 관련된 것들을 저장한다//
                ValueDeliverScript.SaveGameData();


                Debug.Log("::::::::: 서버에 최고점수를 기록하게 함");
                Debug.Log("::::::::: 서버에 최고점수를 기록하게 함");
                Debug.Log("::::::::: 서버에 최고점수를 기록하게 함");
                Debug.Log("::::::::: 서버에 최고점수를 기록하게 함");
                Debug.Log("::::::::: 서버에 최고점수를 기록하게 함");
                Debug.Log("::::::::: 서버에 최고점수를 기록하게 함");
                //서버에 최고점수를 기록하게 함.
                GameObject.Find("GameManager").GetComponent<UpdateUserInfo>().UpdateScorevoid();

                gameObject.GetComponent<UILabel>().color = new Color(248f / 255, 220f / 255f, 73 / 255);
            }
        }
        highScoreText.GetComponent<UILabel>().text = ValueDeliverScript.scoreHigh + "";

    }

    public IEnumerator ScoreAnim()
    {
        GameObject HalfBLKPanel = GameObject.Find("Windows").transform.FindChild("HalfBLKPanel").gameObject;

        //Debug.Log("점수계산하러옴?");
        int interval = scorePlay / 60;
        Debug.Log("::::::ScoreAnimScoreAnimScoreAnimScoreAnimScoreAnimScoreAnimScoreAnim:::::");
        HangarPopupController hpController = GameObject.Find("GameManager").GetComponent<HangarPopupController>();
        int pListCount = hpController.PopupListCount();
        while (HalfBLKPanel.activeSelf == true || pListCount > 0)
        {
            yield return new WaitForSeconds(0.15f);
            pListCount = hpController.PopupListCount();
        }

        while (rollingScore < scorePlay)
        {
            rollingScore += interval;
            gameObject.GetComponent<UILabel>().text = rollingScore.ToString();
            yield return null;
        }
        gameObject.GetComponent<UILabel>().text = scorePlay.ToString();
    }

    void Start()
    {
        ValueDeliverScript.isHigh = false;
    }
}
