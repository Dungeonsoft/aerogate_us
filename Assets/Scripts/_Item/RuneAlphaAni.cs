using UnityEngine;
using System.Collections;

public class RuneAlphaAni : MonoBehaviour {

	float alphaTime = 0;
	public Transform aimTransform;
	Material runeTexMat;

	// Use this for initialization
	void Start () 
	{
		runeTexMat = this.transform.FindChild("RuneTex").gameObject.renderer.material;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = aimTransform.position;
		runeTexMat.SetColor("_TintColor" , new Color(1, 0 , 0 , 0.3f + Mathf.Sin (alphaTime * Mathf.PI)*0.2f ) );
		alphaTime += Time.deltaTime;
//		Debug.Log ("alphaTime : " + alphaTime);
	}

	public void Activate (float limitTime)
	{
//		aimTransform = GameObject.Find("Flight").transform;
		alphaTime = 0;
		StartCoroutine(LifeTime (limitTime));
	}

	IEnumerator LifeTime (float limitTime)
	{
		yield return new WaitForSeconds(limitTime);
		gameObject.SetActive(false);
	}
}
