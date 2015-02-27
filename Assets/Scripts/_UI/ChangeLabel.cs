using UnityEngine;
using System.Collections;

public class ChangeLabel : MonoBehaviour {

    //GameObject wingBoxGold;
    //Animation wingBoxIconanimation1;
    //Animation wingBoxIconanimation2;
	UILabel uiLabel;

	void Start ()
	{
        //wingBoxGold = GameObject.Find ("WingBoxIconGold");
        //wingBoxIconanimation1 = GameObject.Find ("WingBoxIconGrey").animation;
        //wingBoxIconanimation2 = GameObject.Find ("WingBoxIconGold").animation;
		uiLabel = gameObject.GetComponent<UILabel>();
	}

	public void LabelChange (int count , float gageFill)
	{
        //wingBoxGold.GetComponent<UIFilledSprite>().fillAmount = gageFill;
//		Debug.Log ("fillAmount" + wingBoxGold.GetComponent<UIFilledSprite>().fillAmount);

		int oldLabel = int.Parse(uiLabel.text);

		if(count<0) count = 0;
		uiLabel.text = count.ToString("0000");

		int newLabel = int.Parse(uiLabel.text);
		if(oldLabel != newLabel)
		{
            //wingBoxIconanimation1.Play("IconScale");
            //wingBoxIconanimation2.Play("IconScale");
		}
	}
}
