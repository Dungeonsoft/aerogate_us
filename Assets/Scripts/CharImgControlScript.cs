using UnityEngine;
using System.Collections;

public class CharImgControlScript : MonoBehaviour {

    GameObject CharacterLeftImage;

    void Awake()
    {
        CharacterLeftImage = GameObject.Find("Char");
        ChangeImage();
    }

    void ChangeImage()
    {
        int CharNum = ValueDeliverScript.activeOper;
        switch (CharNum)
        {
            case 1:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator1_01";
                break;
            case 2:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator2_01";
                break;
            case 3:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator3_01";
                break;
            case 4:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator4_01";
                break;
        }

        if(ValueDeliverScript.isTutComplete ==0)    //튜토리얼 모드일경우.
            CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator4_01";

        CharacterLeftImage.GetComponent<UISprite>().MakePixelPerfect();
    }

}
