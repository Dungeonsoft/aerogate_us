using UnityEngine;
using System.Collections;

public class SkillMoveActivateScript : MonoBehaviour 
{

	public int speed = 30;
	
	public int skillADamage = 5000;
	public int skillBDamage = 5000;
	
	float lifeTime;
	GameObject fx;

	bool isMove = true;
//	GameObject sBullet;

	void Start ()
	{
		fx = gameObject.transform.FindChild("Fx").gameObject;
//		sBullet = gameObject.transform.FindChild ("sBullet").gameObject;
	}

	void Update () 
	{
		if(lifeTime <= 0)
		{
			fx.SetActive(false);
			gameObject.SetActive(false);
		}
		else
		{
			if(isMove) transform.Translate(0,0,speed*Time.deltaTime);
		}

		lifeTime -= Time.deltaTime;
	}
	
	public void Activate()
	{
		isMove =true;
		lifeTime = 5f;
		gameObject.transform.FindChild ("sBullet").gameObject.SetActive(true);
	}
	
	public void FxActivate()
	{
		isMove = false;
		lifeTime = 1f;
	}
	
}
