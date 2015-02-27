using UnityEngine;
using System.Collections;

public class GasRestLabelScript : MonoBehaviour
{
    //Not Use//
    ///*
    int gasGage;
    public GameObject[] gasGageOther;
    // Use this for initialization
    void Awake()
    {
        int userLevel = ValueDeliverScript.userLevel;
        {
            if (userLevel < 5) ValueDeliverScript.gasMax = 5;
            if (userLevel > 4) ValueDeliverScript.gasMax = 6;
            if (userLevel > 9) ValueDeliverScript.gasMax = 7;
            if (userLevel > 14) ValueDeliverScript.gasMax = 8;
            if (userLevel > 19) ValueDeliverScript.gasMax = 9;
            if (userLevel > 24) ValueDeliverScript.gasMax = 10;
            if (userLevel > 29) ValueDeliverScript.gasMax = 11;
            if (userLevel > 34) ValueDeliverScript.gasMax = 12;
            if (userLevel > 39) ValueDeliverScript.gasMax = 13;
            if (userLevel > 44) ValueDeliverScript.gasMax = 14;
            if (userLevel == 50) ValueDeliverScript.gasMax = 15;
        }
        //gasGage = ValueDeliverScript.gasRest;
        gasGage = ValueDeliverScript.gasRest;

        GetComponent<UILabel>().text = gasGage + "/" + ValueDeliverScript.gasMax;

        for (int i = 0; i < gasGageOther.Length; i++)
        {
            gasGageOther[i].GetComponent<UILabel>().text = gasGage.ToString();
        }
    }

    public void GasRest(int addGas, bool normalType)    //입력된 추가 연료 갯수를 화면에 표시하기 위한 함수.
    {
        gasGage = ValueDeliverScript.gasRest;
        int gasMax = ValueDeliverScript.gasMax;
        Debug.Log("Fuel Gage ::: " + gasGage + " ::: " + addGas);
        if (normalType == false)             //아직 5개가 다 차지 않았거나 일반적인 형태가 아닌경우(돈주고 구입한다던가 친구가 선물을 해줬다던가.) 연료가 추가되도록해준다.
        {
            Debug.Log("Special Type Fuel Add");
            gasGage += addGas;
        }
        else if (normalType == true)
        {
            Debug.Log("Normal Type Fuel Add");
            int temp = gasGage;
            if (gasGage + addGas <= gasMax)
            {
                gasGage += addGas;
            }
            else if (gasGage >= gasMax)
            {
                gasGage = temp;
            }
            else if (gasGage < gasMax)
            {
                gasGage = gasMax;
            }
        }
        GameObject.Find("GameManager").GetComponent<GasTimeScript>().restTime = 0;


        //인터페이스상에 연료 표시하는 부분을 모두 갱신하여 준다.
        GetComponent<UILabel>().text = gasGage + "/"+gasMax;
        for (int i = 0; i < gasGageOther.Length; i++)
        {
            gasGageOther[i].GetComponent<UILabel>().text = gasGage.ToString();
        }

        //서버에 연료 갯수를 기록한다.
        ValueDeliverScript.gasRest = gasGage;
        Debug.Log("Final Fuel Rest  :::  "+ gasGage + " ::: "+ ValueDeliverScript.gasRest);
    }

    public void GasRestMinus()
    {
        GetComponent<UILabel>().text = ValueDeliverScript.gasRest + "/" + ValueDeliverScript.gasMax;

        for (int i = 0; i < gasGageOther.Length; i++)
        {
            gasGageOther[i].GetComponent<UILabel>().text = ValueDeliverScript.gasRest+"";
        }

    }


    public void GasRestUpdate()
    {
        GetComponent<UILabel>().text = ValueDeliverScript.gasRest + "/" + ValueDeliverScript.gasMax;

        for (int i = 0; i < gasGageOther.Length; i++)
        {
            gasGageOther[i].GetComponent<UILabel>().text = ValueDeliverScript.gasRest+"";
        }

    }

//*/
}