using UnityEngine;
using System.Collections;

public class UpgradeAlarmShow : MonoBehaviour {


    public GameObject upParent;

    public void upParentShow()
    {
        int bulletNum = 0;
        switch (ValueDeliverScript.flightNumber)
        {
            case 0: bulletNum = ValueDeliverScript.flight000Bullet; break;
            case 1: bulletNum = ValueDeliverScript.flight001Bullet; break;
            case 2: bulletNum = ValueDeliverScript.flight002Bullet; break;
        }
        if (bulletNum < 15)
            upParent.SetActive(true);
        else
            upParent.SetActive(false);
    }

    public void upParentHide()
    {
        upParent.SetActive(false);
    }
}
