using UnityEngine;
using System.Collections;

public class BuyDiamondWin : MonoBehaviour {

    public GameObject DiaTxt;

	// Use this for initialization
	void Start () {
       DiaTxt.GetComponent<UILabel>().text = ValueDeliverScript.medalRest+"";
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void MedalPurchaseWindow(int itemNumber)
    {
        //결제후 처리하는 부분들//
       int itemNum = itemNumber;
       int medalPriceNum = int.Parse((ValueDeliverScript.medalPrice["MedalPrice" + itemNumber.ToString("000") + "Num"]).ToString());
        ValueDeliverScript.medalRest += medalPriceNum;
        DiaTxt.GetComponent<UILabel>().text = ValueDeliverScript.medalRest + "";
        ValueDeliverScript.SaveGameData();
    }
}
