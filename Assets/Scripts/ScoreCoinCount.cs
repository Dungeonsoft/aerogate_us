using UnityEngine;
using System.Collections;
//using SimpleJSON;


public class ScoreCoinCount : MonoBehaviour
{
	
	UILabel scoreCount;
	UILabel coinCount;
	UILabel highScoreCount;
    GameObject goldParticle;
    bool isParticleOn;

    int oldScore;
    Color goldColor;
	// Use this for initialization
    void Awake()
    {
        goldParticle = GameObject.Find("InfoPanel").transform.FindChild("GoldParticle").gameObject;
        goldParticle.SetActive(false);

    }

	void Start () 
	{
		scoreCount = GameObject.Find ("ScoreCount").GetComponent<UILabel>();
		scoreCount.text = "0";
		coinCount = GameObject.Find ("CoinCount").GetComponent<UILabel>();
		highScoreCount = GameObject.Find ("HighScoreCount").GetComponent<UILabel>();
        //highScoreCount.text = ValueDeliverScript.scoreHigh.ToString();
        if (ValueDeliverScript.isTutComplete !=2) return;
        highScoreCount.text = ValueDeliverScript.scoreHigh.ToString();
        oldScore = int.Parse(highScoreCount.text);
        goldColor = new Color(248f / 255, 220f / 255, 73f / 255);
	}
	
	public void ScoreCount()
	{
        if (ValueDeliverScript.isPcExplo == true) return;   //전투기가 파괴된 상태이므로 스코어 증가를 중지한다.
        //간격 _ 20.
        string scoreString = ValueDeliverScript.scorePlay.ToString();
        int scoreLength = scoreString.Length;
        if (scoreLength > 4)
        {
            float xPos = (scoreLength - 4) * 19;
            GetComponent<ComboSystemScript>().ComboObject.localPosition = new Vector3(-361 + xPos, 263, 0); 
        }
        scoreCount.text = scoreString;

        if (ValueDeliverScript.scorePlay > oldScore && ValueDeliverScript.isTutComplete == 2)
        {
            highScoreCount.color = goldColor; 
            highScoreCount.text = scoreString;
            if (!isParticleOn)
            {
                isParticleOn = true;
                goldParticle.SetActive(true);
                goldParticle.transform.FindChild("GoldPar01").particleSystem.Play();
                goldParticle.transform.FindChild("GoldPar02").particleSystem.Play();
            }

        }
	}
	
	public void CoinCount()
	{
		coinCount.text = ValueDeliverScript.coinPlay.ToString ();
	}
	
	public void HighScore()
	{
        if (ValueDeliverScript.scorePlay > ValueDeliverScript.scoreHigh)
		{
            ValueDeliverScript.isHigh = true;
            //ValueDeliverScript.scoreHigh = ValueDeliverScript.scorePlay;
            //ValueDeliverScript.highFlight = ValueDeliverScript.flightNumber;
            //ValueDeliverScript.highSkin = ValueDeliverScript.skinNumber;
            //ValueDeliverScript.highBullet = ValueDeliverScript.bulletLevel;
            //ValueDeliverScript.highChar = ValueDeliverScript.activeOper;
            //ValueDeliverScript.highBomb = ValueDeliverScript.activeBomb;
            //ValueDeliverScript.highReinforce = ValueDeliverScript.activeReinforce;
            //ValueDeliverScript.highAssist = ValueDeliverScript.activeAssist;

            //GameObject.Find("GameManager").GetComponent<HangarManager>().ShowEveryPlay();
        }
        highScoreCount.text = ValueDeliverScript.scoreHigh.ToString();
        //ValueDeliverScript.SaveGameData();
    }
}
