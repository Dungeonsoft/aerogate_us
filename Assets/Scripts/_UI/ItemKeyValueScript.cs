using UnityEngine;
using System.Collections;

public class ItemKeyValueScript : MonoBehaviour
{
    public int itemPositionNumber;

    public int itemNumber;
    public string itemKey;
    public int itemValue;

    public int itemCoinCost;
    public int itemMedalCost;

    public string itemName;
    public string itemScript;

    public bool isMedalPurchase = false;
    public int lockOffLevel;

    //	[System.NonSerialized]
    public string itemSpriteName;

    void Start()
    {
        itemSpriteName = transform.FindChild("Item").GetComponent<UISprite>().spriteName;

        int posX = -325;
        int posY = 65;
        int num = itemPositionNumber;
        posX += 130 * num;
        if (num > 5)
        {
            posX += 1000;
        }
        transform.localPosition = new Vector3(posX, posY, 0);

        UserLevel();
    }

    void UserLevel()
    {
        int userLevel = ValueDeliverScript.userLevel;

        if (lockOffLevel == 0 || userLevel >= lockOffLevel)
        {
            isMedalPurchase = false;
        }
    }
}
