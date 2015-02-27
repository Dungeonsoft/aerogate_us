using UnityEngine;
using System.Collections;

public class itemName
{
    public string finalPowerUp = "icon_equip_boost_med_1";
    public string shield = "icon_equip_sub_med_1";
    public string blackHall = "icon_equip_bomb_med_6";
    public string singleAmp = "icon_equip_force_med_1";
    public string dualAmp = "icon_equip_force_med_2";
    public string ShortBomb = "icon_equip_sub_med_3";
    public string shortSkill = "icon_equip_sub_med_4";
    public string criAccel = "icon_equip_force_med_7";
    public string spinballAmp = "icon_equip_force_med_3";
    public string dartAmp = "icon_equip_force_med_4";
    public string dustAmp = "icon_equip_force_med_5";
    public string seedAmp = "icon_equip_force_med_6";
    public string plazmaWave = "icon_equip_bomb_med_2";

    public string Aidan = "icon_operator_4";
    public string comanch = "Comanche001Fix";
    public string Dan = "icon_operator_2";
    public string phantom = "Phantom001Fix";
    public string rachel = "icon_operator_3";
}

public class PilotLevelUpWindowScript : MonoBehaviour
{
    void EquipStartSetting()
    {
        StartCoroutine(EquipStartSetting2());
    }

    IEnumerator EquipStartSetting2()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject.Find("GameManager").GetComponent<HangarManager>().EquipStartSetting();   //레벨업 관련하여 변경이 있을경우 이곳을 통해서 함수가 실행된다.

    }


    void LevelUpReward(int maxFuel,string itm5N, int itm5C, string itm6N = "", int itm6C = 0, string itm7N = "", string itm7C = "")
    {
        ValueDeliverScript.gasMax = maxFuel;
        GameObject.Find("GasRestLabel").GetComponent<GasRestLabelScript>().GasRest(maxFuel, true);   //입력된 추가 연료 갯수를 화면에 표시하기 위한 함수 호출.

        transform.FindChild("IndemnityItem/Item003/MaxFuel").GetComponent<UILabel>().text = maxFuel.ToString();


        transform.FindChild("IndemnityItem/Item005/Script").GetComponent<UILabel>().text = "+" + itm5C;
        transform.FindChild("IndemnityItem/Item005/Icon").GetComponent<UISprite>().spriteName = itm5N;
        transform.FindChild("IndemnityItem/Item005/Icon").GetComponent<UISprite>().MakePixelPerfect();

        if (itm6C != 0)
        {
            transform.FindChild("IndemnityItem/Item006/Script").GetComponent<UILabel>().text = "+" + itm6C;
            transform.FindChild("IndemnityItem/Item006/Icon").GetComponent<UISprite>().spriteName = itm6N;
            transform.FindChild("IndemnityItem/Item006/Icon").GetComponent<UISprite>().MakePixelPerfect();
        }
        else
        {
            transform.FindChild("IndemnityItem/Item006").gameObject.SetActive(false);
        }

        if (itm7C != "")
        {
            transform.FindChild("IndemnityItem/Item007/Script").GetComponent<UILabel>().text = "+" + itm7C;
            transform.FindChild("IndemnityItem/Item007/Icon").GetComponent<UISprite>().spriteName = itm7N;
            transform.FindChild("IndemnityItem/Item007/Icon").localScale = new Vector3(80, 80, 1);
            if (ValueDeliverScript.userLevel == 3)
            {
                transform.FindChild("IndemnityItem/Item007").localPosition = new Vector3(300, 64, -270);
            }
        }
        else
        {
            transform.FindChild("IndemnityItem/Item007").gameObject.SetActive(false);
        }

        switch (ValueDeliverScript.userLevel)
        {
            case 2:
            case 4:
            case 5:
                transform.FindChild("IndemnityItem").localPosition = new Vector3(0, 0, 0); break;

            case 6:
            case 9:
            case 12:
            case 15:
                transform.FindChild("IndemnityItem").localPosition = new Vector3(-100, 0, 0); break;

            default: transform.FindChild("IndemnityItem").localPosition = new Vector3(-50, 0, 0); break;
        }
        ValueDeliverScript.SaveGameData();
        EquipStartSetting();
    }



    public void Activate(int addCoin, int addMedal)
    {
        int userLevel = ValueDeliverScript.userLevel;

        Debug.Log("Into Level Up Activate Function");
        Debug.Log("My New Level is " + userLevel);

        transform.FindChild("IndemnityItem/Item001/Script").GetComponent<UILabel>().text = "+" + addCoin;
        transform.FindChild("IndemnityItem/Item002/Script").GetComponent<UILabel>().text = "+" + addMedal;
        transform.FindChild("IndemnityItem/Item003/Script").GetComponent<UILabel>().text = "Max";
        transform.FindChild("IndemnityItem/Item004/Script").GetComponent<UILabel>().text = "+1";

        itemName iName = new itemName();
        //레벨별 보상을 보여준다.
        switch (userLevel)
        {
            case 02:
                ValueDeliverScript.EquipReinforce08 += 5;   //파이널파워업+5.
                LevelUpReward(5, iName.finalPowerUp, 5); break;
            case 03:
                ValueDeliverScript.EquipBomb01 += 5;  //플라즈마웨이브+5.
                ValueDeliverScript.operaterLockOff["Operater001"] = true;   //오퍼레이터01 잠금해제.(Aidan)
                LevelUpReward(5, iName.plazmaWave, 5, "", 0, iName.Aidan, "Aidan"); break;
            case 04:
                ValueDeliverScript.EquipAssist01 += 5;  //쉴드+5.
                LevelUpReward(5, iName.shield, 5); break;
            case 05:
                ValueDeliverScript.EquipBomb05 += 5;    //블랙홀+5.
                LevelUpReward(6, iName.blackHall, 5); break;
            case 06:
                ValueDeliverScript.EquipBomb01 += 3;  //플라즈마웨이브+3.
                ValueDeliverScript.EquipReinforce08 += 3;   //파이널파워업+3.
                LevelUpReward(6, iName.plazmaWave, 3, iName.finalPowerUp, 3, iName.comanch, "Comanch"); break;
            case 07:
                ValueDeliverScript.EquipReinforce01 += 3;  //싱글증폭기+2.
                ValueDeliverScript.EquipAssist03 += 3;  //숏봄+3.
                LevelUpReward(6, iName.singleAmp, 3, iName.ShortBomb, 3); break;
            case 08:
                ValueDeliverScript.EquipReinforce02 += 3;  //듀얼증폭기+3.
                ValueDeliverScript.EquipAssist04 += 3;  //스킬드레인.(에너지드레인)+3.
                LevelUpReward(6, iName.dualAmp, 3, iName.shortSkill, 3); break;
            case 09:
                ValueDeliverScript.EquipBomb01 += 3;  //플라즈마웨이브+3.
                ValueDeliverScript.EquipReinforce07 += 3;  //크리티컬엑셀레이터+3.
                LevelUpReward(6, iName.plazmaWave, 3, iName.criAccel, 3, iName.Dan, "Dan Moren"); break;
            case 10:
                ValueDeliverScript.EquipBomb05 += 3;    //블랙홀+3.
                ValueDeliverScript.EquipReinforce03 += 3;  //스핀볼탐지증폭기+3.
                if (ValueDeliverScript.FlightLockOff001 == 0) ValueDeliverScript.FlightLockOff001 = 1;   //코만치 락해제. 완전 봉인 해제는 2가 되어야 됨.
                LevelUpReward(7, iName.blackHall, 3, iName.spinballAmp, 3); break;
            case 11:
                ValueDeliverScript.EquipReinforce04 += 3;  //다트탐지증폭기+3.
                ValueDeliverScript.EquipAssist01 += 3;  //쉴드+3.
                LevelUpReward(7, iName.dartAmp, 3, iName.shield, 3); break;
            case 12:
                ValueDeliverScript.EquipReinforce05 += 3;  //더스트탐지증폭기+3.
                ValueDeliverScript.EquipReinforce06 += 3;  //시드탐지증폭기+3.
                if (ValueDeliverScript.FlightLockOff002 == 0) ValueDeliverScript.FlightLockOff002 = 1;   //팬텀 잠금해제. 완전 봉인 해제는 2가 되어야 됨.
                LevelUpReward(7, iName.dustAmp, 3, iName.seedAmp, 3, iName.phantom, "Phantom"); break;
            case 13:
                ValueDeliverScript.EquipBomb01 += 4;  //플라즈마웨이브+4.
                ValueDeliverScript.EquipReinforce08 += 4;   //파이널파워업+4.
                LevelUpReward(7, iName.plazmaWave, 4, iName.finalPowerUp, 4); break;
            case 14:
                ValueDeliverScript.EquipBomb01 += 4;  //플라즈마웨이브+4.
                ValueDeliverScript.EquipReinforce08 += 4;   //파이널파워업+4.
                LevelUpReward(7, iName.plazmaWave, 4, iName.finalPowerUp, 4); break;
            case 15:
                ValueDeliverScript.EquipReinforce01 += 4;  //싱글증폭기+4.
                ValueDeliverScript.EquipAssist03 += 4;  //숏봄+4.
                ValueDeliverScript.operaterLockOff["Operater003"] = true;   //오퍼레이터03 잠금해제.
                LevelUpReward(8, iName.singleAmp, 4, iName.ShortBomb, 3, iName.rachel, "Rachel"); break;
            case 16:
                ValueDeliverScript.EquipReinforce02 += 4;  //듀얼증폭기+4.
                ValueDeliverScript.EquipAssist04 += 4;  //스킬드레인.(에너지드레인)+4.
                LevelUpReward(8, iName.dualAmp, 4, iName.shortSkill, 4); break;
            case 17:
                ValueDeliverScript.EquipBomb01 += 4;  //플라즈마웨이브+4.
                ValueDeliverScript.EquipReinforce07 += 4;  //크리티컬엑셀레이터+4.
                LevelUpReward(8, iName.plazmaWave, 4, iName.criAccel, 4); break;
            case 18:
                ValueDeliverScript.EquipBomb05 += 4;    //블랙홀+4.
                ValueDeliverScript.EquipReinforce03 += 4;  //스핀볼탐지증폭기+4.
                LevelUpReward(8, iName.blackHall, 4, iName.spinballAmp, 4); break;
            case 19:
                ValueDeliverScript.EquipReinforce04 += 4;  //다트탐지증폭기+4.
                ValueDeliverScript.EquipAssist01 += 4;  //쉴드+4.
                LevelUpReward(8, iName.dartAmp, 4, iName.shield, 4); break;
            case 20:
                ValueDeliverScript.EquipReinforce05 += 4;  //더스트탐지증폭기+4.
                ValueDeliverScript.EquipReinforce06 += 4;  //시드탐지증폭기+4.
                LevelUpReward(9, iName.dustAmp, 4, iName.seedAmp, 4); break;
            case 21:
                ValueDeliverScript.EquipBomb01 += 5;  //플라즈마웨이브+5.
                ValueDeliverScript.EquipReinforce08 += 5;   //파이널파워업+5.
                LevelUpReward(9, iName.plazmaWave, 5, iName.finalPowerUp, 5); break;
            case 22:
                ValueDeliverScript.EquipBomb01 += 5;  //플라즈마웨이브+5.
                ValueDeliverScript.EquipReinforce08 += 5;   //파이널파워업+5.
                LevelUpReward(9, iName.plazmaWave, 5, iName.finalPowerUp, 5); break;
            case 23:
                ValueDeliverScript.EquipReinforce01 += 5;  //싱글증폭기+5.
                ValueDeliverScript.EquipAssist03 += 5;  //숏봄+5.
                LevelUpReward(9, iName.singleAmp, 5, iName.ShortBomb, 5); break;
            case 24:
                ValueDeliverScript.EquipReinforce02 += 5;  //듀얼증폭기+5.
                ValueDeliverScript.EquipAssist04 += 5;  //스킬드레인.(에너지드레인)+5.
                LevelUpReward(9, iName.dualAmp, 5, iName.shortSkill, 5); break;
            case 25:
                ValueDeliverScript.EquipBomb01 += 5;  //플라즈마웨이브+5.
                ValueDeliverScript.EquipReinforce07 += 5;  //크리티컬엑셀레이터+5.
                LevelUpReward(10, iName.plazmaWave, 5, iName.criAccel, 5); break;
            case 26:
                ValueDeliverScript.EquipBomb05 += 5;    //블랙홀+5.
                ValueDeliverScript.EquipReinforce03 += 5;  //스핀볼탐지증폭기+5.
                LevelUpReward(10, iName.blackHall, 5, iName.spinballAmp, 5); break;
            case 27:
                ValueDeliverScript.EquipReinforce04 += 5;  //다트탐지증폭기+5.
                ValueDeliverScript.EquipAssist01 += 5;  //쉴드+5.
                LevelUpReward(10, iName.dartAmp, 5, iName.shield, 5); break;
            case 28:
                ValueDeliverScript.EquipReinforce05 += 5;  //더스트탐지증폭기+5.
                ValueDeliverScript.EquipReinforce06 += 5;  //시드탐지증폭기+5.
                LevelUpReward(10, iName.dustAmp, 5, iName.seedAmp, 5); break;
            case 29:
                ValueDeliverScript.EquipBomb01 += 6;  //플라즈마웨이브+6.
                ValueDeliverScript.EquipReinforce08 += 6;   //파이널파워업+6.
                LevelUpReward(10, iName.plazmaWave, 6, iName.finalPowerUp, 6); break;
            case 30:
                ValueDeliverScript.EquipBomb01 += 6;  //플라즈마웨이브+6.
                ValueDeliverScript.EquipReinforce08 += 6;   //파이널파워업+6.
                LevelUpReward(11, iName.plazmaWave, 6, iName.finalPowerUp, 6); break;
            case 31:
                ValueDeliverScript.EquipReinforce01 += 6;  //싱글증폭기+6.
                ValueDeliverScript.EquipAssist03 += 6;  //숏봄+6.
                LevelUpReward(11, iName.singleAmp, 6, iName.ShortBomb, 6); break;
            case 32:
                ValueDeliverScript.EquipReinforce02 += 6;  //듀얼증폭기+6.
                ValueDeliverScript.EquipAssist04 += 6;  //스킬드레인.(에너지드레인)+6.
                LevelUpReward(11, iName.dualAmp, 6, iName.shortSkill, 6); break;
            case 33:
                ValueDeliverScript.EquipBomb01 += 6;  //플라즈마웨이브+6.
                ValueDeliverScript.EquipReinforce07 += 6;  //크리티컬엑셀레이터+6.
                LevelUpReward(11, iName.plazmaWave, 6, iName.criAccel, 6); break;
            case 34:
                ValueDeliverScript.EquipBomb05 += 6;    //블랙홀+6.
                ValueDeliverScript.EquipReinforce03 += 6;  //스핀볼탐지증폭기+6.
                LevelUpReward(11, iName.blackHall, 6, iName.spinballAmp, 6); break;
            case 35:
                ValueDeliverScript.EquipReinforce04 += 6;  //다트탐지증폭기+6.
                ValueDeliverScript.EquipAssist01 += 6;  //쉴드+6.
                LevelUpReward(12, iName.dartAmp, 6, iName.shield, 6); break;
            case 36:
                ValueDeliverScript.EquipReinforce05 += 6;  //더스트탐지증폭기+6.
                ValueDeliverScript.EquipReinforce06 += 6;  //시드탐지증폭기+6.
                LevelUpReward(12, iName.dustAmp, 6, iName.seedAmp, 6); break;
            case 37:
                ValueDeliverScript.EquipBomb01 += 7;  //플라즈마웨이브+7.
                ValueDeliverScript.EquipReinforce08 += 7;   //파이널파워업+7.
                LevelUpReward(12, iName.plazmaWave, 7, iName.finalPowerUp, 7); break;
            case 38:
                ValueDeliverScript.EquipBomb01 += 7;  //플라즈마웨이브+7.
                ValueDeliverScript.EquipReinforce08 += 7;   //파이널파워업+7.
                LevelUpReward(12, iName.plazmaWave, 7, iName.finalPowerUp, 7); break;
            case 39:
                ValueDeliverScript.EquipReinforce01 += 7;  //싱글증폭기+7.
                ValueDeliverScript.EquipAssist03 += 7;  //숏봄+7.
                LevelUpReward(12, iName.singleAmp, 7, iName.ShortBomb, 7); break;
            case 40:
                ValueDeliverScript.EquipReinforce02 += 7;  //듀얼증폭기+7.
                ValueDeliverScript.EquipAssist04 += 7;  //스킬드레인.(에너지드레인)+7.
                LevelUpReward(13, iName.dualAmp, 7, iName.shortSkill, 7); break;
            case 41:
                ValueDeliverScript.EquipBomb01 += 7;  //플라즈마웨이브+7.
                ValueDeliverScript.EquipReinforce07 += 7;  //크리티컬엑셀레이터+7.
                LevelUpReward(13, iName.plazmaWave, 7, iName.criAccel, 7); break;
            case 42:
                ValueDeliverScript.EquipBomb05 += 7;    //블랙홀+7.
                ValueDeliverScript.EquipReinforce03 += 7;  //스핀볼탐지증폭기+7.
                LevelUpReward(13, iName.blackHall, 7, iName.spinballAmp, 7); break;
            case 43:
                ValueDeliverScript.EquipReinforce04 += 7;  //다트탐지증폭기+7.
                ValueDeliverScript.EquipAssist01 += 7;  //쉴드+7.
                LevelUpReward(13, iName.dartAmp, 7, iName.shield, 7); break;
            case 44:
                ValueDeliverScript.EquipReinforce05 += 7;  //더스트탐지증폭기+7.
                ValueDeliverScript.EquipReinforce06 += 7;  //시드탐지증폭기+7.
                LevelUpReward(13, iName.dustAmp, 7, iName.seedAmp, 7); break;
            case 45:
                ValueDeliverScript.EquipBomb01 += 8;  //플라즈마웨이브+8.
                ValueDeliverScript.EquipReinforce08 += 8;   //파이널파워업+8.
                LevelUpReward(14, iName.plazmaWave, 8, iName.finalPowerUp, 8); break;
            case 46:
                ValueDeliverScript.EquipBomb01 += 8;  //플라즈마웨이브+8.
                ValueDeliverScript.EquipReinforce08 += 8;   //파이널파워업+8.
                LevelUpReward(14, iName.plazmaWave, 8, iName.finalPowerUp, 8); break;
            case 47:
                ValueDeliverScript.EquipReinforce01 += 8;  //싱글증폭기+8.
                ValueDeliverScript.EquipAssist03 += 8;  //숏봄+8.
                LevelUpReward(14, iName.singleAmp, 8, iName.ShortBomb, 8); break;
            case 48:
                ValueDeliverScript.EquipReinforce02 += 8;  //듀얼증폭기+8.
                ValueDeliverScript.EquipAssist04 += 8;  //스킬드레인.(에너지드레인)+8.
                LevelUpReward(14, iName.dualAmp, 8, iName.shortSkill, 8); break;
            case 49:
                ValueDeliverScript.EquipBomb01 += 8;  //플라즈마웨이브+8.
                ValueDeliverScript.EquipReinforce07 += 8;  //크리티컬엑셀레이터+8.
                LevelUpReward(14, iName.plazmaWave, 8, iName.criAccel, 8); break;
            case 50:
                ValueDeliverScript.EquipBomb05 += 8;    //블랙홀+8.
                ValueDeliverScript.EquipReinforce03 += 8;  //스핀볼탐지증폭기+8.
                LevelUpReward(15, iName.blackHall, 8, iName.spinballAmp, 8); break;
        }
        ValueDeliverScript.SaveGameData();
    }


    void WinClose()
    {
        gameObject.SetActive(false);
    }
}
