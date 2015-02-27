using UnityEngine;
using System.Collections;

public class ChangeTex02 : MonoBehaviour 
{
	UISprite uiSprite;
	Animation bulletScaleAnimation;

	void Awake ()
	{
        //uiSprite = GameObject.Find ("bulletLevelIcon").GetComponent<UISprite>();
        uiSprite = GetComponent<UISprite>();

		if(!uiSprite) Debug.Log (uiSprite.name);
		bulletScaleAnimation = transform.parent.animation;
	}

	public void ChangeLevel (int level)
	{

		string bulletLevel;
		bulletLevel = level.ToString("D3");
        uiSprite.spriteName = "Bullet" + ValueDeliverScript.flightNumber.ToString("00") + "_" + bulletLevel;
		uiSprite.MakePixelPerfect();

		bulletScaleAnimation.Play ("BulletIconAni01");

        //Debug.Log("uiSprite.spriteName  is  " + uiSprite.spriteName);
	}
}
