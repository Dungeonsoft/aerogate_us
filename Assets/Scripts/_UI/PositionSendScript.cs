using UnityEngine;
using System.Collections;

public class PositionSendScript : MonoBehaviour
{

    public GameObject target;

    public GameObject itemName;
    public GameObject itemScript;
    public GameObject itemPrice;
    public GameObject itemCostIcon;


    GameObject bombIcon;
    GameObject boostIcon;
    GameObject assistanceIcon;
    GameObject reinforceIcon;

    public GameObject purchaseBtn;
    public GameObject purchaseBtnLabel;

    public bool isOper;

    GameObject coinAbleLabel;

    void Awake()
    {
        bombIcon = GameObject.Find("BombIcon");
        reinforceIcon = GameObject.Find("ReinforceIcon");
        assistanceIcon = GameObject.Find("AssistanceIcon");
        coinAbleLabel = GameObject.Find("EquipWindows").transform.FindChild("Base/CoinAbleLabel").gameObject;
    }

    public void PositionSend()
    {

        if (isOper)
        {
            GetComponent<EquipCharSelScript>().PlaySound();
        }
        itemName.GetComponent<UILabel>().text = this.gameObject.GetComponent<ItemKeyValueScript>().itemName;
        itemScript.GetComponent<UILabel>().text = this.gameObject.GetComponent<ItemKeyValueScript>().itemScript;
        //Debug.Log("::: Label Number is " + transform.FindChild("Label").GetComponent<UILabel>().text + " :::");

        //아래 IF 구문은 구매할(선택된) 아이템의 구매종류(메달인지 돈인지) 아이콘과 구매시 들어가는 금액을 표시할지 여부를 결정한다.
        if (GetComponent<ItemKeyValueScript>().itemKey.Contains("Oper") && transform.FindChild("Label").GetComponent<UILabel>().text != "0")
        {
            //Debug.Log("감추기");
            //선택된 것이 오퍼레이터이고 이미 한번이상 구매했으면 구매종류 아이콘과 금액을 안보이게 처리한다.
            itemCostIcon.SetActive(false);
            itemPrice.GetComponent<UILabel>().text = "";
            purchaseBtn.SetActive(false);   //기 구매된 캐릭터일경우 구매하기 버튼을 숨김.
            purchaseBtnLabel.SetActive(false);
            coinAbleLabel.GetComponent<UILabel>().text = "";
        }
        else
        {
            //Debug.Log("보이기");
            purchaseBtn.SetActive(true);
            purchaseBtnLabel.SetActive(true);

            itemCostIcon.SetActive(true);
            if (GetComponent<ItemKeyValueScript>().isMedalPurchase)
            {
                itemCostIcon.GetComponent<UISprite>().spriteName = "icon_small_deco";
                itemPrice.GetComponent<UILabel>().text = this.gameObject.GetComponent<ItemKeyValueScript>().itemMedalCost.ToString();
                coinAbleLabel.GetComponent<UILabel>().text = "Coins Purchase over LV " + GetComponent<ItemKeyValueScript>().lockOffLevel + "!!";

            }
            else
            {
                itemCostIcon.GetComponent<UISprite>().spriteName = "icon_small_gold";
                itemPrice.GetComponent<UILabel>().text = this.gameObject.GetComponent<ItemKeyValueScript>().itemCoinCost.ToString();
                coinAbleLabel.GetComponent<UILabel>().text = "";

            }
        }

        //오퍼탭이 아니면 아이템 구매가능 글씨를 무조건 안보이게 한다.
        if (!GetComponent<ItemKeyValueScript>().itemKey.Contains("Oper"))
        {
            coinAbleLabel.GetComponent<UILabel>().text = "";
        }
        //선택한 아이템이 한개이상의 여분이 남아있을경우 활성화 시킴.
        if (gameObject.transform.FindChild("Label").GetComponent<UILabel>().text != "0")
        {
            string selectedItemSprite = transform.FindChild("Item").gameObject.GetComponent<UISprite>().spriteName;

            if (target.name == "EquipBombTab")
            {
                ValueDeliverScript.activeBomb = GetComponent<ItemKeyValueScript>().itemNumber;
                bombIcon.GetComponent<UISprite>().spriteName = selectedItemSprite.Replace("big", "med");
                bombIcon.GetComponent<UISprite>().MakePixelPerfect();

            }
            else if (target.name == "EquipReinforceTab")
            {
                ValueDeliverScript.activeReinforce = GetComponent<ItemKeyValueScript>().itemNumber;
                reinforceIcon.GetComponent<UISprite>().spriteName = selectedItemSprite.Replace("big", "med");
                reinforceIcon.GetComponent<UISprite>().MakePixelPerfect();
            }
            else if (target.name == "EquipAssistTab")
            {
                ValueDeliverScript.activeAssist = GetComponent<ItemKeyValueScript>().itemNumber;
                assistanceIcon.GetComponent<UISprite>().spriteName = selectedItemSprite.Replace("big", "med");
                assistanceIcon.GetComponent<UISprite>().MakePixelPerfect();
            }
            else if (target.name == "EquipOperTab")
            {
                ValueDeliverScript.activeOper = GetComponent<ItemKeyValueScript>().itemNumber;
                ChangeImage();
            }
            //ValueDeliverScript.SaveGameData();
        }


        //아이템이 선택되었다는걸 기록. 활성화화는 관계가 없음. ItemKeyValueScript 스크립트가 붙어있는가를 확인하여 기록여부 결정.
        if (this.GetComponent<ItemKeyValueScript>())
        {
            ValueDeliverScript.SelectedItem = this.gameObject;
            if (GetComponent<ItemKeyValueScript>().isMedalPurchase)
            {
                ValueDeliverScript.purchaseCharge = this.GetComponent<ItemKeyValueScript>().itemMedalCost;
            }
            else
            {
                ValueDeliverScript.purchaseCharge = this.GetComponent<ItemKeyValueScript>().itemCoinCost;
            }
            ValueDeliverScript.SelectedItemSprite = transform.FindChild("Item").gameObject.GetComponent<UISprite>().spriteName;
        }

        //Debug.Log("Position Send Script Working. Now HilightIconAct Function is going to work");
        target.GetComponent<ItemHilightScript>().HilightIconAct(transform.localPosition);
    }

    void ChangeImage()
    {
        int CharNum = ValueDeliverScript.activeOper;
        GameObject CharacterLeftImage = GameObject.Find("CharImg");
        GameObject CharacterLabel = GameObject.Find("CharName");
        switch (CharNum)
        {
            case 1:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator1_01";
                CharacterLabel.GetComponent<UISprite>().spriteName = "text_operator_name1";
                break;
            case 2:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator2_01";
                CharacterLabel.GetComponent<UISprite>().spriteName = "text_operator_name2";
                break;
            case 3:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator3_01";
                CharacterLabel.GetComponent<UISprite>().spriteName = "text_operator_name3";
                break;
            case 4:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator4_01";
                CharacterLabel.GetComponent<UISprite>().spriteName = "text_operator_name4";
                break;
        }
        CharacterLeftImage.GetComponent<UISprite>().MakePixelPerfect();
        CharacterLabel.GetComponent<UISprite>().MakePixelPerfect();
        PlayerPrefs.SetInt("activeOper", ValueDeliverScript.activeOper);
    }
}
