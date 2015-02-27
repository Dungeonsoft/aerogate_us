using UnityEngine;
using System.Collections;

public class EventTabScript : MonoBehaviour {

    void OnEnable()
    {
        UpdateEvent();
    }

    public void UpdateEvent()
    {
        //Debug.Log("들어오나?");

        if (ValueDeliverScript.invitedFriendCount >= 10)
        {
            //Debug.Log("들어오나?111");

            transform.FindChild("Tab01").GetComponent<UIPanel>().alpha = 0.25f;
            transform.FindChild("Tab01/Child/Text01_1").GetComponent<UILabel>().text = "완료:";
        }
        if (ValueDeliverScript.invitedFriendCount >= 20)
        {
            //Debug.Log("들어오나?222");

            transform.FindChild("Tab02").GetComponent<UIPanel>().alpha = 0.25f;
            transform.FindChild("Tab02/Child/Text01_1").GetComponent<UILabel>().text = "완료:";
        }
        if (ValueDeliverScript.invitedFriendCount >= 30)
        {
            //Debug.Log("들어오나?333");

            transform.FindChild("Tab03").GetComponent<UIPanel>().alpha = 0.25f;
            transform.FindChild("Tab03/Child/Text01_1").GetComponent<UILabel>().text = "완료:";
        }
        if (ValueDeliverScript.invitedFriendCount >= 40)
        {
            //Debug.Log("들어오나?444");

            transform.FindChild("Tab04").GetComponent<UIPanel>().alpha = 0.25f;
            transform.FindChild("Tab04/Child/Text01_1").GetComponent<UILabel>().text = "완료:";
        }

    }
}
