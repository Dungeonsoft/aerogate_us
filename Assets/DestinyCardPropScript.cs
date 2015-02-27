using UnityEngine;
using System.Collections;

public class DestinyCardPropScript : MonoBehaviour
{
    int creatCardRndOut;
    public int[] itemRange;

    public bool isGold = false; //금카드인지...(외부에서 접근함)
    public int itemNumber = 0;    //아이템은 어떤 종류인지...(외부에서 접근함)
    string iconName;            //아이템 스프라이트 이름은 무엇인지...
    int bonusPercent;           //적용되는 보너스 퍼센트는 얼마인지...

    public GameObject item;
    public GameObject bonusLabel;

    void Awake()
    {
        creatCardRndOut = Random.Range(0, itemRange[itemRange.Length - 1]);

        if (creatCardRndOut >= 0)
        {
            isGold = false;
            itemNumber = 0;
            iconName = "Icn_Destiny_01";
            bonusPercent = 10;
        }
        if (creatCardRndOut > itemRange[0])
        {
            isGold = false;
            itemNumber = 1;
            iconName = "Icn_Destiny_01";
            bonusPercent = 20;
        }
        if (creatCardRndOut > itemRange[1])
        {
            isGold = false;
            itemNumber = 2;
            iconName = "Icn_Destiny_01";
            bonusPercent = 30;
        }
        if (creatCardRndOut > itemRange[2])
        {
            isGold = false;
            itemNumber = 3;
            iconName = "Icn_Destiny_02";
            bonusPercent = 50;
        }
        if (creatCardRndOut > itemRange[3])
        {
            isGold = false;
            itemNumber = 4;
            iconName = "Icn_Destiny_02";
            bonusPercent = 75;
        }
        if (creatCardRndOut > itemRange[4])
        {
            isGold = false;
            itemNumber = 5;
            iconName = "Icn_Destiny_02";
            bonusPercent = 100;
        }
        if (creatCardRndOut > itemRange[5])
        {
            isGold = false;
            itemNumber = 6;
            iconName = "Icn_Destiny_03";
            bonusPercent = 50;
        }
        if (creatCardRndOut > itemRange[6])
        {
            isGold = false;
            itemNumber = 7;
            iconName = "Icn_Destiny_03";
            bonusPercent = 75;
        }
        if (creatCardRndOut > itemRange[7])
        {
            isGold = false;
            itemNumber = 8;
            iconName = "Icn_Destiny_03";
            bonusPercent = 100;
        }
        if (creatCardRndOut > itemRange[8])
        {
            isGold = false;
            itemNumber = 9;
            iconName = "Icn_Destiny_04";
            bonusPercent = 50;
        }
        if (creatCardRndOut > itemRange[9])
        {
            isGold = false;
            itemNumber = 10;
            iconName = "Icn_Destiny_04";
            bonusPercent = 75;
        }
        if (creatCardRndOut > itemRange[10])
        {
            isGold = false;
            itemNumber = 11;
            iconName = "Icn_Destiny_04";
            bonusPercent = 100;
        }
        if (creatCardRndOut > itemRange[11])
        {
            isGold = false;
            itemNumber = 12;
            iconName = "Icn_Destiny_05";
            bonusPercent = 20;
        }
        if (creatCardRndOut > itemRange[12])
        {
            isGold = false;
            itemNumber = 13;
            iconName = "Icn_Destiny_06";
            bonusPercent = 20;
        }
        if (creatCardRndOut > itemRange[13])
        {
            isGold = false;
            itemNumber = 14;
            iconName = "Icn_Destiny_07";
            bonusPercent = 20;
        }
        if (creatCardRndOut > itemRange[14])
        {
            isGold = true;
            itemNumber = 15;
            iconName = "Icn_Destiny_05";
            bonusPercent = 30;
        }
        if (creatCardRndOut > itemRange[15])
        {
            isGold = true;
            itemNumber = 16;
            iconName = "Icn_Destiny_06";
            bonusPercent = 30;
        }
        if (creatCardRndOut > itemRange[16])
        {
            isGold = true;
            itemNumber = 17;
            iconName = "Icn_Destiny_07";
            bonusPercent = 30;
        }

        //설명아이콘과 적용되는 값을 이미지로 보이게 만든후 임시로 숨겨놓는다. 
        item.GetComponent<UISprite>().spriteName = iconName;
        bonusLabel.GetComponent<UILabel>().text = "+" + bonusPercent + "%";
      
        item.GetComponent<UISprite>().MakePixelPerfect();
        bonusLabel.GetComponent<UILabel>().MakePixelPerfect();

        item.SetActive(false);
        bonusLabel.SetActive(false);
    }

}
