using UnityEngine;
using System.Collections;

public class FriendshipPointScript : MonoBehaviour {

    public int usingPoint = 100;
    public int maxpoint = 9999;
    public UILabel point100Label;

    public UISprite getItem;
    public UILabel getValue;

    public GameObject getItemWindow;
    public GameObject halfBLKPanel;

    string itemName;    //적용될 아이템의 이름.
    string text;    //적용될 아이템의 수량이나 정보.

    public int[] itemAbility;

    int maxRange;   //계산된 랜덤값의 최대치를 입력하는 변수.
    int abilitySum; //각 아이템별로 부여된 범위값을 순차적으로 더하여 모아두기 위한 임시 변수의 성격이 있다.


    void Awake()
    {
        getItemWindow.SetActive(false);
        abilitySum = 0;
        MaxRangeFunc(); //랜덤값의 최대치를 구한다. 랜덤값은 아이템갯수와 가중치에 따라 변한다.
    }

    public void FriendshipBoxOpen()
    {
        getItem.transform.localPosition = new Vector3(-1, 2, -1);

        int randomNum = Random.Range(0, maxRange); //어떤 아이템이 나오게 될지 랜덤값을 발생한다.
        for (int i = 0; i < itemAbility.Length; i++)
        {
            abilitySum += itemAbility[i];

            //아이템별로 있는 가중치를 순차적으로 더하여 발생된 랜덤값보다 큰지를 따져본다.
            //가중치를 더한 값이 발생된 랜덤값보다 크면 그 아이템의 가중치 범위안에 있다 판단하여 아이템 번호를 부여하여
            //우정포인트 아이템을 발생시킨다.
            if (randomNum < abilitySum)
            {
                //실제 아이템을 발생하여 게임에 적용하는 부분이다.
                GetPointBox(i);
                break;
            }
        }
        abilitySum = 0; //값이 지속적으로 더해지는 형태니 한번 계산을 마쳤으니 초기값을 입력하여 준다.
    }

    void GetPointBox(int val)
    {
        //Debug.Log("Value is ::: "+ val);

        #region 스위치 비교문.
        switch (val)
        {
            //코인 1, 코인 2, 코인 3// 
            case 0:
                ValueDeliverScript.coinRest = ValueDeliverScript.coinRest + 1000;
                itemName = "icon_gold_1";
                text = "+1000";
                getItem.transform.localPosition += new Vector3(0, 20, 0);
                break;
            case 1:
                ValueDeliverScript.coinRest = ValueDeliverScript.coinRest + 1500;
                itemName = "icon_gold_3";
                text = "+1500";
                getItem.transform.localPosition += new Vector3(0, 9, 0);
                break;
            case 2:
                ValueDeliverScript.coinRest = ValueDeliverScript.coinRest + 2000;
                itemName = "icon_gold_4";
                text = "+2000";
                getItem.transform.localPosition += new Vector3(0, 9, 0);
                break;
            //코인 1, 코인 2, 코인 3// 


            //다이아몬드 1, 다이아몬드 2, 다이아몬드 3// 
            case 3:
                ValueDeliverScript.medalRest = ValueDeliverScript.medalRest + 1; //입력된 추가 다이아몬드 갯수를 화면에 표시하기 위한 함수 호출.
                itemName = "icon_deco_1";
                text = "+1";
                break;
            case 4:
                ValueDeliverScript.medalRest = ValueDeliverScript.medalRest + 2; //입력된 추가 다이아몬드 갯수를 화면에 표시하기 위한 함수 호출.
                itemName = "icon_deco_2";
                text = "+2";
                break;
            case 5:
                ValueDeliverScript.medalRest = ValueDeliverScript.medalRest + 3; //입력된 추가 다이아몬드 갯수를 화면에 표시하기 위한 함수 호출.
                itemName = "icon_deco_3";
                text = "+3";
                break;
            //다이아몬드 1, 다이아몬드 2, 다이아몬드 3// 


            //연료 1, 연료 2, 연료 3// 
            case 6:
                ValueDeliverScript.gasRest = ValueDeliverScript.gasRest + 1;
                itemName = "icon_fuel_2";
                text = "+1";
                getItem.transform.localPosition += new Vector3(0, 18, 0);

                break;
            case 7:
                ValueDeliverScript.gasRest = ValueDeliverScript.gasRest + 2;
                itemName = "icon_fuel_3";
                text = "+2";
                getItem.transform.localPosition += new Vector3(0, 18, 0);

                break;
            case 8:
                ValueDeliverScript.gasRest = ValueDeliverScript.gasRest + 3;
                itemName = "icon_fuel_4";
                text = "+3";
                getItem.transform.localPosition += new Vector3(0, 18, 0);
            //연료 1, 연료 2, 연료 3// 



                break;
            case 9:
                ValueDeliverScript.EquipBomb01 = ValueDeliverScript.EquipBomb01 + 2;
                itemName = "icon_equip_bomb_big_2";
                text = "+2";
                break;
            case 10:
                ValueDeliverScript.EquipBomb01 = ValueDeliverScript.EquipBomb01 + 3;
                itemName = "icon_equip_bomb_big_2";
                text = "+3";
                break;
            case 11:
                ValueDeliverScript.EquipBomb01 = ValueDeliverScript.EquipBomb01 + 4;
                itemName = "icon_equip_bomb_big_2";
                text = "+4";
                break;
            case 12:
                ValueDeliverScript.EquipBomb05 = ValueDeliverScript.EquipBomb05 + 1;
                itemName = "icon_equip_bomb_big_6";
                text = "+1";
                break;
            case 13:
                ValueDeliverScript.EquipReinforce01 = ValueDeliverScript.EquipReinforce01 + 1;
                itemName = "icon_equip_force_big_1";
                text = "+1";
                break;
            case 14:
                ValueDeliverScript.EquipReinforce02 = ValueDeliverScript.EquipReinforce02 + 1;
                itemName = "icon_equip_force_big_2";
                text = "+1";
                break;
            case 15:
                ValueDeliverScript.EquipReinforce03 = ValueDeliverScript.EquipReinforce03 + 1;
                itemName = "icon_equip_force_big_3";
                text = "+1";
                break;
            case 16:
                ValueDeliverScript.EquipReinforce04 = ValueDeliverScript.EquipReinforce04 + 1;
                itemName = "icon_equip_force_big_4";
                text = "+1";
                break;
            case 17:
                ValueDeliverScript.EquipReinforce05 = ValueDeliverScript.EquipReinforce05 + 1;
                itemName = "icon_equip_force_big_5";
                text = "+1";
                break;
            case 18:
                ValueDeliverScript.EquipReinforce06 = ValueDeliverScript.EquipReinforce06 + 1;
                itemName = "icon_equip_force_big_6";
                text = "+1";
                break;
            case 19:
                ValueDeliverScript.EquipReinforce07 = ValueDeliverScript.EquipReinforce07 + 1;
                itemName = "icon_equip_force_big_7";
                text = "+1";
                break;
            case 20:
                ValueDeliverScript.EquipReinforce08 = ValueDeliverScript.EquipReinforce08 + 1;
                itemName = "icon_equip_boost_big_1";
                text = "+1";
                break;
            case 21:
                ValueDeliverScript.EquipAssist01 = ValueDeliverScript.EquipAssist01 + 1;
                itemName = "icon_equip_sub_big_1";
                text = "+1";
                break;
            case 22:
                ValueDeliverScript.EquipAssist02 = ValueDeliverScript.EquipAssist02 + 1;
                itemName = "icon_equip_sub_big_2";
                text = "+1";
                break;
            case 23:
                ValueDeliverScript.EquipAssist03 = ValueDeliverScript.EquipAssist03 + 1;
                itemName = "icon_equip_sub_big_3";
                text = "+1";
                break;
            case 24:
                ValueDeliverScript.EquipAssist04 = ValueDeliverScript.EquipAssist04 + 1;
                itemName = "icon_equip_sub_big_4";
                text = "+1";
                break;
            case 25:
                ValueDeliverScript.EquipAssist05 = ValueDeliverScript.EquipAssist05 + 1;
                itemName = "icon_equip_boost_big_7";
                text = "+1";
                break;
            case 26:
                ValueDeliverScript.EquipAssist06 = ValueDeliverScript.EquipAssist06 + 1;
                itemName = "icon_equip_boost_big_6";
                break;
            case 27:
                ValueDeliverScript.upgradePoint = ValueDeliverScript.upgradePoint + 1;
                itemName = "Icn_Apoint";
                break;
        }
        #endregion

        Recal(val);
    }

    public FlightUpointSetScript flightUpointSetScript;
    public HangarManager hangarManager;

    void Recal(int val = 0)
    {
        //우정포인트를 제하고 화면상에 우정포인트 관련된 것들을 제대로 보이게 만들어 주는 부분.
        ValueDeliverScript.buddyPoint = ValueDeliverScript.buddyPoint - usingPoint;
        //ValueDeliverScript.friendshipPoint -= usingPoint;   //실제 우정포인트의 총량을 감소시킨다.

        HangarManager hangerCon = GameObject.Find("GameManager").GetComponent<HangarManager>();

        if (ValueDeliverScript.buddyPoint < 100)
        {
            GetComponent<HangarManager>().ShotFriendshipPoint();
        }

        point100Label.text = (int.Parse( point100Label.text ) - 1).ToString("00");

        //0이면 숫자 안나오게//
        if (point100Label.text == "00")
        {
            point100Label.text = "";
        }

        getItem.spriteName = itemName;
        getValue.text = text;
        getItem.MakePixelPerfect();


        //발생된 아이템을 알려주는 정보 확인창을 띄운다.

        if (val != 27)
        {
            FreindshipPointGetItemWindow();
        }
        else
        {
            hangarManager.upgradePointWindow.transform.FindChild("PointAdd").GetComponent<UILabel>().text = "X 1";
            flightUpointSetScript.RedrawStatePoint();
            hangarManager.ShowUpgradePointWindow();
        }
        //최신 내역으로 갱신//
        GetComponent<GasTimeScript>().MedalRecount(); //화면에 표시되는 메달양을 다시 계산하여 재표시하여줌.
        GetComponent<GasTimeScript>().CoinRecount(); //화면에 표시되는 동전양을 다시 계산하여 재표시하여줌.
        GetComponent<HangarManager>().LoadEquip(); //이큅창들에 들어가는 아이템 표시를 다시 계산하고.
        StartCoroutine(IEquipStartSetting());   //그 계산한것을 기반으로 어떤것이 선택되어야되는지에 대해서 재계산한다.
        //최신 내역으로 갱신//
        ValueDeliverScript.SaveGameData();
    }

    IEnumerator IEquipStartSetting()
    {
        yield return null;
        GetComponent<HangarManager>().EquipStartSetting(); //1173번줄에 있는 이큅스타트세팅 함수를 호출.
    }

    void MaxRangeFunc()
    {
        foreach (int val in itemAbility)
        {
            maxRange += val;
        }
        maxRange++;
    }

    void FreindshipPointGetItemWindow()
    {
        getItemWindow.SetActive(true);
        halfBLKPanel.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, getItemWindow.transform.localPosition.z + 5);
    }

    void FreindshipPointGetItemWindowClose()
    {
        getItemWindow.SetActive(false);
        halfBLKPanel.SetActive(false);
    }
}
