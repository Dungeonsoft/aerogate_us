using UnityEngine;
using System.Collections;

public class CharacterShowScript : MonoBehaviour {

    void Awake()
    {

        ChangeImage();

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
                CharacterLeftImage.GetComponent<TweenScale>().to = new Vector3(179,255,1);
                CharacterLabel.GetComponent<UISprite>().spriteName = "text_operator_name1";
                break;
            case 2:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator2_01";
                CharacterLeftImage.GetComponent<TweenScale>().to = new Vector3(179,273,1);
                CharacterLabel.GetComponent<UISprite>().spriteName = "text_operator_name2";
                break;
            case 3:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator3_01";
                CharacterLeftImage.GetComponent<TweenScale>().to = new Vector3(179,278,1);
                CharacterLabel.GetComponent<UISprite>().spriteName = "text_operator_name3";
                break;
            case 4:
                CharacterLeftImage.GetComponent<UISprite>().spriteName = "Img_Operator4_01";
                CharacterLeftImage.GetComponent<TweenScale>().to = new Vector3(179,273,1);
                CharacterLabel.GetComponent<UISprite>().spriteName = "text_operator_name4";
                break;
        }
        CharacterLeftImage.GetComponent<UISprite>().MakePixelPerfect();
        CharacterLabel.GetComponent<UISprite>().MakePixelPerfect();

    }

	// Use this for initialization
    void EndShowAni()
    {
        //Debug.Log("EndShow");
    }
}
