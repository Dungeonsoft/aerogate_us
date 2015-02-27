using UnityEngine;
using System.Collections;

public class ThunderAct : MonoBehaviour {

	float alphaValue;

	public void Activate (float alphaValue)
	{
		this.alphaValue = alphaValue;
		StartCoroutine (DecendAlpha());
	}

	IEnumerator DecendAlpha()  
	{
		while(alphaValue>0)
		{
//			Debug.Log ("AlphaValue ::: " + alphaValue);
			gameObject.renderer.material.SetColor("_TintColor" , new Color ( 0.5f , 0.5f , 0.5f , alphaValue));
//			portal01.renderer.material.SetColor ("_TintColor" , nowPortalColor * new Color(1f , 1f , 1f , alphaTime) );

			alphaValue -= Time.deltaTime * 3f;
			yield return null;
		}
		gameObject.renderer.material.SetColor("_TintColor" , new Color ( 0.5f , 0.5f , 0.5f , 0f));
	}
}
