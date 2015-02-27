using UnityEngine;
using System.Collections;

public class FlightStatusShowScript : MonoBehaviour
{
    public GameObject BtnStatus;
    public GameObject statusBg;

    public UILabel abilityTextLabel;

    int fNum;
    int sNum;
    int sLev;
    string locObjName;
    string abilityText;

    public int tempSkinNum;

    void Awake()
    {
        //abilityTextLabel = transform.FindChild("FlightNameTag03").GetComponent<UILabel>();
        //abilityTextLabel.transform.localScale = new Vector3(25, 0, 1);

    }

    void ShowStatus()
    {
        string sName = BtnStatus.GetComponent<UISprite>().spriteName;
        if (sName.Contains("On"))
        {
            StatusAbilityText();

            StartCoroutine(ShowIE());
        }
        else
        {
            StartCoroutine(CloseIE());
        }
    }

    void StatusAbilityText()
    {
        //스킨셀렉트창에서만 작동하는 부분//
        if (GameObject.Find("Flights").transform.localPosition.x != 0)
        {
            sNum = tempSkinNum;
        }
        //스킨셀렉트창에서만 작동하는 부분//
        else
        {
            switch (fNum)
            {
                case 0: sNum = ValueDeliverScript.flight000Skin; break;
                case 1: sNum = ValueDeliverScript.flight001Skin; break;
                case 2: sNum = ValueDeliverScript.flight002Skin; break;
            }
        }


        if (sNum != 0)
        {
            fNum = ValueDeliverScript.flightNumber;
            switch (fNum)
            {
                case 0:
                    switch (sNum)
                    {
                        case 1: sLev = ValueDeliverScript.FlightLev000Skin001; break;
                        case 2: sLev = ValueDeliverScript.FlightLev000Skin002; break;
                        case 3: sLev = ValueDeliverScript.FlightLev000Skin003; break;
                        case 4: sLev = ValueDeliverScript.FlightLev000Skin004; break;
                        case 5: sLev = ValueDeliverScript.FlightLev000Skin005; break;
                    }
                    break;
                case 1:
                    switch (sNum)
                    {
                        case 1: sLev = ValueDeliverScript.FlightLev001Skin001; break;
                        case 2: sLev = ValueDeliverScript.FlightLev001Skin002; break;
                        case 3: sLev = ValueDeliverScript.FlightLev001Skin003; break;
                        case 4: sLev = ValueDeliverScript.FlightLev001Skin004; break;
                        case 5: sLev = ValueDeliverScript.FlightLev001Skin005; break;
                    }
                    break;
                case 2:
                    switch (sNum)
                    {
                        case 1: sLev = ValueDeliverScript.FlightLev002Skin001; break;
                        case 2: sLev = ValueDeliverScript.FlightLev002Skin002; break;
                        case 3: sLev = ValueDeliverScript.FlightLev002Skin003; break;
                        case 4: sLev = ValueDeliverScript.FlightLev002Skin004; break;
                        case 5: sLev = ValueDeliverScript.FlightLev002Skin005; break;
                    }
                    break;
            }

            locObjName = "SkinSelectWindow" + fNum.ToString("00") + "/Skin/Skin" + sNum.ToString("00");
            abilityText = GameObject.Find(locObjName).GetComponent<PositionSkinSendScript>().skinScript[sLev - 1];
            abilityTextLabel.text = abilityText;
        }
        else
        {
            abilityTextLabel.text = "No Function";
        }


    }

    IEnumerator ShowIE()
    {
        yield return statusBg.animation.Play("FlightStatusBg01");

        abilityTextLabel.animation.Play("StatusTextAnim01");

        BtnStatus.GetComponent<UISprite>().spriteName = "Btn_AircraftInfoOff_00";
        BtnStatus.GetComponent<UIImageButton>().normalSprite = "Btn_AircraftInfoOff_00";
        BtnStatus.GetComponent<UIImageButton>().hoverSprite = "Btn_AircraftInfoOff_00";
        BtnStatus.GetComponent<UIImageButton>().pressedSprite = "Btn_AircraftInfoOff_01";
    }

    IEnumerator CloseIE()
    {
        yield return abilityTextLabel.animation.Play("StatusTextAnim02");
        abilityTextLabel.text = "";

        statusBg.animation.Play("FlightStatusBg02");
        BtnStatus.GetComponent<UISprite>().spriteName = "Btn_AircraftInfoOn_00";
        BtnStatus.GetComponent<UIImageButton>().normalSprite = "Btn_AircraftInfoOn_00";
        BtnStatus.GetComponent<UIImageButton>().hoverSprite = "Btn_AircraftInfoOn_00";
        BtnStatus.GetComponent<UIImageButton>().pressedSprite = "Btn_AircraftInfoOn_01";

    }
}
