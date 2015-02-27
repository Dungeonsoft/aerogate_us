using UnityEngine;
using System.Collections;
using System;

public class GasTimeScript : MonoBehaviour
{

    [System.NonSerialized]
    public int restTime;
    public int addGasTime = 600;
    public GameObject gasTimeUi;
    public GameObject[] coinRest;
    public GameObject[] medalRest;
    public GameObject gasRestLabel;
    public GameObject gasRestNumber;




    int fuelMax;    //연료 최고치 서버에서 받아올 변수.
    double lastRegenTime;   //지난번 연료 리젠 시간.
    int regenIntervalTime;   //연료 채워지는데 걸리는 시간.

    public bool isChangeFuel;

    public void CoinRecount()
    {
        for (int i = 0; i < coinRest.Length; i++)
        {
            coinRest[i].GetComponent<UILabel>().text = ValueDeliverScript.coinRest.ToString();
        }
    }

    public void MedalRecount()
    {
        for (int i = 0; i < medalRest.Length; i++)
        {
            medalRest[i].GetComponent<UILabel>().text = ValueDeliverScript.medalRest.ToString();
        }
    }

    void Awake()
    {
        if (PlayerPrefs.HasKey("timeRecord"))
        {
            ValueDeliverScript.timeRecord = PlayerPrefs.GetInt("timeRecord");
            Debug.Log("시간 기록을 한적이 있는가?  있다!!!! :::: "+ ValueDeliverScript.timeRecord);
        }
    }

    void Start()
    {
        CoinRecount();
        MedalRecount();

        addGasTime = ValueDeliverScript.addGasTime;


        DateTime gasNextAddTime;
        DateTime gasLastAddTime;

        if (ValueDeliverScript.timeRecord == 0) //시간 기록을 한적이 한번도 없으면~
        {
            gasLastAddTime = DateTime.Now;  //현재 시간을 기록하고. 
            gasNextAddTime = DateTime.Now.AddSeconds(addGasTime);   //다음 연료가 찰 시간인 15분후 시간을 기록한다.
            ValueDeliverScript.gasLastAddTime = gasLastAddTime.ToBinary().ToString();   //플레이어프리퍼런스에 마지막 연료가 찬 시간을 기록한다.
            ValueDeliverScript.gasNextAddTime = gasNextAddTime.ToBinary().ToString();   //플레이어프리퍼런스에 다음 연료가 찰 시간을 기록한다.

            ValueDeliverScript.timeRecord = 1;  //시간기록을 시작했다는것을 밸류딜리버스크립트에 알려서 서버에 저장한다. 이후에는 서버에 기록되었기에 이 구문은 무시하고 넘어가게 된다.
            PlayerPrefs.SetInt("timeRecord", 1);
        }
        else
        {
            //한번이라도 게임을 실행한 적이 있었다면 이쪽으로 바로 이동한다. 첫 시작 빼고는 항상 이쪽으로 이동한다.

            double gasLastAddTimeVal =  double.Parse(ValueDeliverScript.gasLastAddTime); //마지막 연료가 찼던 시간을 로컬에서 가지고 온다.
            DateTime nowTime = System.DateTime.Now;         //현재시간을 저장해놓음.
            DateTime endTime = DateTime.FromBinary(Convert.ToInt64(gasLastAddTimeVal));  //가장마지막에 연료를 채웠던 시간을 기록한걸 가지고와서 다시 시간으로 바꾸어준다.
            double spendTime = nowTime.Subtract(endTime).TotalSeconds;     //현재시간과 마지막 연료지급시간을 비교하여 얼마나 시간이 지났는지 알아낸다.(초)



            int addGas = Mathf.FloorToInt(float.Parse((spendTime / addGasTime).ToString()));      //추가될 연료 갯수를 계산한다.

            restTime = Mathf.FloorToInt(float.Parse((spendTime % addGasTime).ToString()));        //연료추가를 하고 남은 시간을 계산한다.

            //Debug.Log("now Time ::: " + nowTime);
            //Debug.Log("Last Added Time ::: " + endTime);
            //Debug.Log("spendTime ::: " + spendTime);

            //Debug.Log("addGasTime ::: " + addGasTime);
            //Debug.Log("addGas Original ::: " + spendTime / addGasTime + "개의 연료가 추가됨.");
            //Debug.Log("addGas ::: " + addGas + "개의 연료가 추가됨.");
            //Debug.Log("restTime ::: " + restTime);


            if (addGas > 0) //연료가 하나라도 차야만 실행된다. 재충전 시간을 다시 알아내야 되기 때문에 꼭 필요.
            {
                gasNextAddTime = DateTime.Now.AddSeconds(addGasTime - restTime);       //남은시간을 연료가 채워지는데 필요한 시간에서 제한다음에 다음연료가 채워지는 시간을 도출한다.
                ValueDeliverScript.gasNextAddTime = gasNextAddTime.ToBinary().ToString();       //다음 연료가 채워지는 시간을 밸류딜리버스크립트에 저장한다.(서버에 저장해야함)
                gasLastAddTime = DateTime.Now.AddSeconds(-restTime);                   //현재시간에서 연료를 지급하고 남은 시간을 뺀 시간을 연료 지급시간으로 저장한다.
                ValueDeliverScript.gasLastAddTime = nowTime.ToBinary().ToString();              //마지막 연료 지급시간으로 서버에 저장한다.
                GameObject.Find("GasRestLabel").GetComponent<GasRestLabelScript>().GasRest(addGas, true);   //입력된 추가 연료 갯수를 화면에 표시하기 위한 함수 호출.
            }

            ValueDeliverScript.timeRecord = 1;
        }

        StartCoroutine(GameSpendTime());

        //ValueDeliverScript.SaveGameData();
    }


    IEnumerator GameSpendTime()
    {
        while (true)
        {
            DateTime gasNextAddTime = DateTime.FromBinary(Convert.ToInt64(double.Parse(ValueDeliverScript.gasNextAddTime)));  //서버(밸류딜리버스크립트)에서 다음 연료지급시간을 가지고온다.
            
            double sysRestTime = gasNextAddTime.Subtract(DateTime.Now).TotalSeconds;   //다음 연료지급시간에서 현재시간을 빼서 남은 시간이 얼마나되는지 알아낸다.(ㅊ)

            if (ValueDeliverScript.gasRest >= 5)    //서버(밸류딜리버스크립트)에 기록된 현재 잔여 연료 갯수가 5개가 넘었는지 파악한다.
            {
                gasNextAddTime = DateTime.Now.AddSeconds(addGasTime);
                ValueDeliverScript.gasNextAddTime = gasNextAddTime.ToBinary().ToString();   //시간만 다음 연료 지급시간까지 늘이기만 하고 연료를 채워주지는 않는다.
                gasTimeUi.GetComponent<UILabel>().text = "0:00";
                yield return new WaitForSeconds(1f);
            }
            else    //연료 잔여갯수가 5개가 안될때~
            {
                int mValue = Mathf.FloorToInt(float.Parse((sysRestTime / 60).ToString()));
                int sValue = Mathf.FloorToInt(float.Parse((sysRestTime % 60).ToString()));
                if (mValue < 0) mValue = 0;
                if (sValue < 0) sValue = 0;
                gasTimeUi.GetComponent<UILabel>().text = mValue + ":" + sValue.ToString("00");  //연료가 채워지기까지 남은 시간을 화면에 실시간으로 표시하여준다.

                if (sysRestTime <= 0)   //연료지급시간에 도달했는지 여부를 판단한다.(0이하면 연료지급시간에 도달했다는 뜻이다.)
                {
                    GameObject.Find("GasRestLabel").GetComponent<GasRestLabelScript>().GasRest(1, true);    //연료가 채워졌음을 화면에 표시하는 함수를 호출한다.

                    gasNextAddTime = DateTime.Now.AddSeconds(addGasTime);   //다음 연료 지급시간을 지정한다.
                    DateTime gasLastAddTime = DateTime.Now; //현재(가장마지막) 연료 지급시간을 저장한다.
                    ValueDeliverScript.gasNextAddTime = gasNextAddTime.ToBinary().ToString();//다음 연료지급시간을 서버에 저장한다.
                    ValueDeliverScript.gasLastAddTime = gasLastAddTime.ToBinary().ToString();//마지막 연료 지급시간을 서버에 저장한다.

                    ValueDeliverScript.SaveGameData();
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }

}
