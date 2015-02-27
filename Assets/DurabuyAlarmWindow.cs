using UnityEngine;
using System.Collections;

public class DurabuyAlarmWindow : MonoBehaviour
{
    string skinName;
    string flightName;


    //public GameObject[] skinSelectWindow;

    void OnEnable()
    {
        skinName = "Flight" + ValueDeliverScript.flightNumber.ToString("D3") + "Skin" + ValueDeliverScript.skinNumber.ToString("D3");
        if (ValueDeliverScript.flightNumber == 0)
        {
            flightName = "Fokker";
        }
        else if (ValueDeliverScript.flightNumber == 1)
        {
            flightName = "Comanche";
        }
        else if (ValueDeliverScript.flightNumber == 2)
        {
            flightName = "Phantom";
        }

        //Debug.Log("Flight Name ::: \n"+flightName + (ValueDeliverScript.resultSkinnumber + 1).ToString("D3") + "Fix");
        transform.FindChild("Item001/Icon").gameObject.GetComponent<UISprite>().spriteName = flightName + (ValueDeliverScript.resultSkinnumber + 1).ToString("D3") + "Fix";
        transform.FindChild("Item001/Icon").gameObject.GetComponent<UISprite>().MakePixelPerfect();
    }

    //void GoSkinSelectWindow()
    //{
    //    gameObject.SetActive(false);
    //}
}
