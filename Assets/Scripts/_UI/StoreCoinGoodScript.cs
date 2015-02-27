using UnityEngine;
using System.Collections;

public class StoreCoinGoodScript : MonoBehaviour
{

    public int itemNumber;
    public string storeType;

    public void Purchase()
    {
        switch (storeType)
        {
            case "gas":
                Debug.Log("Gas Purchase Case!!! ::: Item Number ::: " + itemNumber);
                GameObject.Find("GameManager").GetComponent<HangarManager>().GasPurchaseWindow(itemNumber);

                break;

            case "coin":
                GameObject.Find("GameManager").GetComponent<HangarManager>().GoldPurchaseWindow(itemNumber);

                break;

            case "medal":
                Debug.Log("Diamond!!!!");

                if (Application.loadedLevel == 1)
                {
                    GameObject.Find("GameManager").GetComponent<HangarManager>().MedalPurchaseWindow(itemNumber);
                    Debug.Log("Diamond!!!!");
                }
                else if (Application.loadedLevel == 2)
                {
                    transform.parent.parent.GetComponent<BuyDiamondWin>().MedalPurchaseWindow(itemNumber);

                    if (ValueDeliverScript.isOneMoreWin == false)
                    {
                        //아래 메소드를 이용하여 대기시간을 10초로 돌린다.//
                        GameObject.Find("SelDstnCardWin").GetComponent<SelDstnCardWinScript>().ChangeHasSeconds();
                        transform.parent.parent.GetComponent<BuyDiamondWin>().MedalPurchaseWindow(itemNumber);
                    }
                    else if (ValueDeliverScript.isOneMoreWin == true)
                    {
                        GameObject.Find("OneMoreCount").GetComponent<OneMoreCount>().CountReset();
                    }
                }
                break;
        }
    }

}
