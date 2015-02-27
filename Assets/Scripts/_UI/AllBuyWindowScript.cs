using UnityEngine;
using System.Collections;

public class AllBuyWindowScript : MonoBehaviour {

    public GameObject[] buyItem;

    void OnEnable()
    {
        buyItem[0].GetComponent<UISprite>().spriteName = ValueDeliverScript.equipSpriteName.Get(ValueDeliverScript.saleItem01);
        buyItem[1].GetComponent<UISprite>().spriteName = ValueDeliverScript.equipSpriteName.Get(ValueDeliverScript.saleItem02);
        buyItem[2].GetComponent<UISprite>().spriteName = ValueDeliverScript.equipSpriteName.Get(ValueDeliverScript.saleItem03);

        buyItem[0].GetComponent<UISprite>().MakePixelPerfect();
        buyItem[1].GetComponent<UISprite>().MakePixelPerfect();
        buyItem[2].GetComponent<UISprite>().MakePixelPerfect();

        buyItem[0].transform.localScale = new Vector3(buyItem[0].transform.localScale.x * 0.7f, buyItem[0].transform.localScale.y * 0.7f, buyItem[0].transform.localScale.z * 0.7f);
        buyItem[1].transform.localScale = new Vector3(buyItem[1].transform.localScale.x * 0.7f, buyItem[1].transform.localScale.y * 0.7f, buyItem[1].transform.localScale.z * 0.7f);
        buyItem[2].transform.localScale = new Vector3(buyItem[2].transform.localScale.x * 0.7f, buyItem[2].transform.localScale.y * 0.7f, buyItem[2].transform.localScale.z * 0.7f);

    }
}
