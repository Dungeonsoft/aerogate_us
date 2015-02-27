using UnityEngine;
using System.Collections;

public class ChangeTex01 : MonoBehaviour 
{
	UISprite uiSprite;
    //GameObject wingBoxGold;

	void Awake ()
	{
        //uiSprite = GameObject.Find ("MissionUfoIcon").GetComponent<UISprite>();
        uiSprite = GetComponent<UISprite>();

        //wingBoxGold = GameObject.Find ("WingBoxIconGold");
	}

	public void MissionNumber (int number) 
	{
        //wingBoxGold.GetComponent<UIFilledSprite>().fillAmount = 0;

        switch (number)
        {
            case 1:
            case 2:
            case 3:
                uiSprite.spriteName = "item_icon1";
                uiSprite.MakePixelPerfect();
                break;
            case 4:
            case 5:
            case 6:
                uiSprite.spriteName = "item_icon2";
                uiSprite.MakePixelPerfect();
                break;
            case 7:
            case 8:
            case 9:
                uiSprite.spriteName = "item_icon3";
                uiSprite.MakePixelPerfect();
                break;
            case 10:
            case 11:
            case 12:
                uiSprite.spriteName = "item_icon4";
                uiSprite.MakePixelPerfect();
                break;
            case 13:
            case 14:
                uiSprite.spriteName = "item_icon5";
                uiSprite.MakePixelPerfect();
                break;
            case 15:
            case 16:
                uiSprite.spriteName = "item_icon6";
                uiSprite.MakePixelPerfect();
                break;
            case 17:
            case 18:
            case 19:
                uiSprite.spriteName = "item_icon7";
                uiSprite.MakePixelPerfect();
                break;
            case 20:
            case 21:
            case 22:
                uiSprite.spriteName = "item_icon8";
                uiSprite.MakePixelPerfect();
                break;
            case 23:
            case 24:
            case 25:
                uiSprite.spriteName = "item_icon9";
                uiSprite.MakePixelPerfect();
                break;
            case 26:
            case 27:
            case 28:
                uiSprite.spriteName = "item_icon10";
                uiSprite.MakePixelPerfect();
                break;
            case 29:
            case 30:
            case 31:
                uiSprite.spriteName = "item_icon11";
                uiSprite.MakePixelPerfect();
                break;
        }
	}
}
