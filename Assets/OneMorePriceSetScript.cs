using UnityEngine;
using System.Collections;

public class OneMorePriceSetScript : MonoBehaviour {

    int oneMoreCount = 0;
    public int diamondpriceDefault = 10;

    [System.NonSerialized]
    public int diamondPrice;
    [System.NonSerialized]
    public int MoneyPrice = 1;

    public UILabel diamondPriceText;
    public UILabel moneyPriceText;

    public void Activate()
    {
        oneMoreCount++;
        diamondPrice = diamondpriceDefault;

        diamondPriceText.text = diamondPrice.ToString();
        //moneyPriceText.text = MoneyPrice.ToString();
    }
}
