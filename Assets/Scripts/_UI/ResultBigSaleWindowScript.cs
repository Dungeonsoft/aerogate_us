using UnityEngine;
using System.Collections;

public class ResultBigSaleWindowScript : MonoBehaviour {
    public int bunchCount = 50;

    public string[] bunchListBomb;
    public string[] bunchListReinforce;
    public string[] bunchListAssist;

    public GameObject[] saleItem;

    public GameObject salePer;
    public GameObject oriPrice;
    public GameObject salePrice;

    int selectBunch;

    int salePercent;

    bool gameEndResult;

    void Awake()
    {
        gameEndResult = ValueDeliverScript.gameEndResult;
    }

    void Start()
    {
        if (!gameEndResult) return;

        selectBunch = Random.Range(0, 50);    //어떤 아이템을 할인판매할것인지 랜덤으로 정한다.
        
        salePercent = Random.Range(25, 50);

        ValueDeliverScript.saleItem01 = bunchListBomb[selectBunch];
        ValueDeliverScript.saleItem02 = bunchListReinforce[selectBunch];
        ValueDeliverScript.saleItem03 = bunchListAssist[selectBunch];

        saleItem[0].transform.FindChild("ItemIcon").GetComponent<UISprite>().spriteName = ValueDeliverScript.equipSpriteName.Get(bunchListBomb[selectBunch]);
        saleItem[0].transform.FindChild("ItemName").GetComponent<UILabel>().text = ValueDeliverScript.equipItemName.Get(bunchListBomb[selectBunch]);
        saleItem[0].transform.FindChild("Price").GetComponent<UILabel>().text = ValueDeliverScript.equipItemPrice.Get(bunchListBomb[selectBunch]);

        saleItem[1].transform.FindChild("ItemIcon").GetComponent<UISprite>().spriteName = ValueDeliverScript.equipSpriteName.Get(bunchListReinforce[selectBunch]);
        saleItem[1].transform.FindChild("ItemName").GetComponent<UILabel>().text = ValueDeliverScript.equipItemName.Get(bunchListReinforce[selectBunch]);
        saleItem[1].transform.FindChild("Price").GetComponent<UILabel>().text = ValueDeliverScript.equipItemPrice.Get(bunchListReinforce[selectBunch]);

        saleItem[2].transform.FindChild("ItemIcon").GetComponent<UISprite>().spriteName = ValueDeliverScript.equipSpriteName.Get(bunchListAssist[selectBunch]);
        saleItem[2].transform.FindChild("ItemName").GetComponent<UILabel>().text = ValueDeliverScript.equipItemName.Get(bunchListAssist[selectBunch]);
        saleItem[2].transform.FindChild("Price").GetComponent<UILabel>().text = ValueDeliverScript.equipItemPrice.Get(bunchListAssist[selectBunch]);

        saleItem[0].transform.FindChild("ItemIcon").GetComponent<UISprite>().MakePixelPerfect();
        saleItem[1].transform.FindChild("ItemIcon").GetComponent<UISprite>().MakePixelPerfect();
        saleItem[2].transform.FindChild("ItemIcon").GetComponent<UISprite>().MakePixelPerfect();

        saleItem[0].transform.FindChild("ItemIcon").localScale = new Vector3(saleItem[0].transform.FindChild("ItemIcon").localScale.x * 0.65f ,saleItem[0].transform.FindChild("ItemIcon").localScale.y * 0.65f ,saleItem[0].transform.FindChild("ItemIcon").localScale.z * 0.65f);
        saleItem[1].transform.FindChild("ItemIcon").localScale = new Vector3(saleItem[1].transform.FindChild("ItemIcon").localScale.x * 0.65f, saleItem[1].transform.FindChild("ItemIcon").localScale.y * 0.65f, saleItem[1].transform.FindChild("ItemIcon").localScale.z * 0.65f);
        saleItem[2].transform.FindChild("ItemIcon").localScale = new Vector3(saleItem[2].transform.FindChild("ItemIcon").localScale.x * 0.65f, saleItem[2].transform.FindChild("ItemIcon").localScale.y * 0.65f, saleItem[2].transform.FindChild("ItemIcon").localScale.z * 0.65f);

        salePer.GetComponent<UILabel>().text = salePercent.ToString();
        int oriPriceInt = int.Parse(ValueDeliverScript.equipItemPrice.Get(bunchListBomb[selectBunch])) + int.Parse(ValueDeliverScript.equipItemPrice.Get(bunchListReinforce[selectBunch])) + int.Parse(ValueDeliverScript.equipItemPrice.Get(bunchListAssist[selectBunch]));
        oriPrice.GetComponent<UILabel>().text = oriPriceInt.ToString();

        int salePriceInt = (int)(oriPriceInt * ((100-salePercent) * 0.01f));
        ValueDeliverScript.salePriceInt = salePriceInt;
        salePrice.GetComponent<UILabel>().text = salePriceInt.ToString();
    }

}
