using UnityEngine;
using System.Collections;

public class SkinHilightScript : MonoBehaviour
{

    public GameObject hilightIcon;
    public GameObject mountIcon;
    public GameObject skinName01;
    public GameObject skinName02;
    public GameObject skinLevelLabel;
    public GameObject skinLevelGageBar;
    public GameObject skinLevelPerNum;
    public GameObject skinScript;
    public int flightNumber;
    int skinNumber;

    // Use this for initialization

    //public void HilightIconAct(Vector3 targetPosition)
    //{
    //    hilightIcon.SetActive(true);
    //    hilightIcon.transform.localPosition = targetPosition + new Vector3(0, 0, -1);
    //}

    public void HilightIconAct()
    {
        //Debug.Log("HilightIconAct");

        hilightIcon.SetActive(true);
        int flight000Skin = 0;
        int flight001Skin = 0;
        int flight002Skin = 0;

            flight000Skin = ValueDeliverScript.flight000Skin;
            flight001Skin = ValueDeliverScript.flight001Skin;
            flight002Skin = ValueDeliverScript.flight002Skin;

        switch (ValueDeliverScript.flightNumber)
        {
            case 00:
                skinNumber = flight000Skin;
                break;
            case 01:
                skinNumber = flight001Skin;
                break;
            case 02:
                skinNumber = flight002Skin;
                break;
        }

        string skinName = "FlightDura" + flightNumber.ToString("D3") + "Skin" + skinNumber.ToString("D3");

        int skinVal = 0;

        switch (flightNumber)
        {
            case 0: switch (skinNumber)
                {
                    case 1: skinVal = ValueDeliverScript.FlightDura000Skin001; break;
                    case 2: skinVal = ValueDeliverScript.FlightDura000Skin002; break;
                    case 3: skinVal = ValueDeliverScript.FlightDura000Skin003; break;
                    case 4: skinVal = ValueDeliverScript.FlightDura000Skin004; break;
                    case 5: skinVal = ValueDeliverScript.FlightDura000Skin005; break;
                } break;
            case 1: switch (skinNumber)
                {
                    case 1: skinVal = ValueDeliverScript.FlightDura001Skin001; break;
                    case 2: skinVal = ValueDeliverScript.FlightDura001Skin002; break;
                    case 3: skinVal = ValueDeliverScript.FlightDura001Skin003; break;
                    case 4: skinVal = ValueDeliverScript.FlightDura001Skin004; break;
                    case 5: skinVal = ValueDeliverScript.FlightDura001Skin005; break;
                } break;
            case 2: switch (skinNumber)
                {
                    case 1: skinVal = ValueDeliverScript.FlightDura002Skin001; break;
                    case 2: skinVal = ValueDeliverScript.FlightDura002Skin002; break;
                    case 3: skinVal = ValueDeliverScript.FlightDura002Skin003; break;
                    case 4: skinVal = ValueDeliverScript.FlightDura002Skin004; break;
                    case 5: skinVal = ValueDeliverScript.FlightDura002Skin005; break;
                } break;
        }




        int yPosition = 68  - (123 * (skinNumber / 3));
        int xPosition = 75 + (124 * (skinNumber % 3));

        hilightIcon.transform.localPosition = new Vector3(xPosition, yPosition, -3);

        if (skinNumber != 0)
        {

            if (skinVal <= 0)
            {
                Debug.Log("듀라보임 :::");
                transform.FindChild("Dura").gameObject.SetActive(true);
                skinScript.GetComponent<UILabel>().text = "";     //스킨 세부 내용 표시를 하지 않음.
                GameObject BG = transform.FindChild("Flight/BG").gameObject;
                BG.transform.localScale = new Vector3(220, 68, 1);

            }
            else
            {
                transform.FindChild("Dura").gameObject.SetActive(false);
            }

            string duraCost = "Flight" + flightNumber.ToString("D3") + "Skin" + skinNumber.ToString("D3") + "Level" + ValueDeliverScript.skinLevel.ToString("D3");

            transform.FindChild("Dura").FindChild("DuraOffGoldlNum").GetComponent<UILabel>().text = ValueDeliverScript.duraCost[duraCost].ToString(); //스킨 레벨별 내구도 수리비 입력.
            Debug.Log("Dura");
        }
    }

    void OnEnable()
    {
        Activate();
    }

    public void Activate()
    {
        transform.FindChild("Flight/Level").gameObject.SetActive(true);
        transform.FindChild("Flight/LevelGage").gameObject.SetActive(true);
        transform.FindChild("Flight/LevelGageBar").gameObject.SetActive(true);
        transform.FindChild("Flight/LevelNum").gameObject.SetActive(true);

        HilightIconAct();

        int flight000Skin = 0;
        int flight001Skin = 0;
        int flight002Skin = 0;

            flight000Skin = ValueDeliverScript.flight000Skin;
            flight001Skin = ValueDeliverScript.flight001Skin;
            flight002Skin = ValueDeliverScript.flight002Skin;

        switch (ValueDeliverScript.flightNumber)    //윈도가 활성화 되었을때 처음 정보를 보내서 기체에 대한 정보를 제대로 보이도록 하는부분. 일반적인 클릭하는것과 같은 내용을 실ㄹ행하게 함.
        {
            case 00:
                transform.FindChild("Skin").FindChild("Skin" + flight000Skin.ToString("00")).GetComponent<PositionSkinSendScript>().PositionSend();
                break;

            case 01:
                transform.FindChild("Skin").FindChild("Skin" + flight001Skin.ToString("00")).GetComponent<PositionSkinSendScript>().PositionSend();
                break;

            case 02:
                transform.FindChild("Skin").FindChild("Skin" + flight002Skin.ToString("00")).GetComponent<PositionSkinSendScript>().PositionSend();
                break;
        }

        if (skinNumber != 0)
        {
            bool lockFree = GameObject.Find("GameManager").GetComponent<HangarManager>().SkinLockCheck(flightNumber, skinNumber);

            if (lockFree == false)
            {
                transform.FindChild("Lock").gameObject.SetActive(true);
            }
            else if (lockFree == true)
            {
                transform.FindChild("Lock").gameObject.SetActive(false);
            }

            Debug.Log("lockFree ::: " + lockFree);
        }

        if (skinNumber == 0)
        {
            transform.FindChild("Lock").gameObject.SetActive(false);
        }
    }
}
