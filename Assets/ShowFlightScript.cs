using UnityEngine;
using System.Collections;

public class ShowFlightScript : MonoBehaviour {

    public UISprite flightImage;
    public UILabel flightName;

    void OnEnable()
    {
        Debug.Log("Flight Number ::: " + ValueDeliverScript.flightNumber);
        Debug.Log("Skin Number ::: " + ValueDeliverScript.skinNumber);

        string fNumber = ValueDeliverScript.flightNumber.ToString("00");
        string sNumber = (ValueDeliverScript.skinNumber+1).ToString("000");

        string flightImgName = "Img_" + fNumber + "_" + sNumber;

        flightImage.spriteName = flightImgName;
        flightImage.MakePixelPerfect();

        switch (flightImgName)
        {
            case "Img_00_001":
                flightName.text = "昔日的辉煌";
                break;
            case "Img_00_002":
                flightName.text = "高手";
                break;
            case "Img_00_003":
                flightName.text = "追猎者";
                break;
            case "Img_00_004":
                flightName.text = "轰炸之王";
                break;
            case "Img_00_005":
                flightName.text = "最高位置";
                break;
            case "Img_00_006":
                flightName.text = "工程师";
                break;
            case "Img_00_007":
                flightName.text = "";
                break;


            case "Img_01_001":
                flightName.text = "空中指挥者";
                break;
            case "Img_01_002":
                flightName.text = "风车";
                break;
            case "Img_01_003":
                flightName.text = "积少成多";
                break;
            case "Img_01_004":
                flightName.text = "坦克杀手";
                break;
            case "Img_01_005":
                flightName.text = "猫眼石";
                break;
            case "Img_01_006":
                flightName.text = "恶魔的呼吸";
                break;


            case "Img_02_001":
                flightName.text = "新的开始";
                break;
            case "Img_02_002":
                flightName.text = "黑色火花";
                break;
            case "Img_02_003":
                flightName.text = "梦幻之翼";
                break;
            case "Img_02_004":
                flightName.text = "钱";
                break;
            case "Img_02_005":
                flightName.text = "救援之手";
                break;
            case "Img_02_006":
                flightName.text = "飞雁之梦";
                break;
        }
    }
}
