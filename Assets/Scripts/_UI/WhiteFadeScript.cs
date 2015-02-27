using UnityEngine;
using System.Collections;

public class WhiteFadeScript : MonoBehaviour 
{ 
	//게임이 종료되서 격납고로 돌아오거나 혹은 처음 시작할때 화면을 검은색에서 원래섹으로 페이드 해주는 기능이 있는 스크립트.

	public GameObject centerBlack; 
	bool beStarted=false;
	float alphaValue = 0;
	public bool isHanger = false;

	void Start ()
    {
		if(!isHanger)centerBlack.SetActive(false);
	}

	public void Activate ()
	{
		if(!beStarted)
		{
			if(isHanger)
			{
				alphaValue = 0.5f;
			}
			centerBlack.SetActive(true);
			StartCoroutine (BeBlack());


		}
		beStarted = true;
	}

	IEnumerator BeBlack ()
	{
		if(isHanger)
		{
            //점점 투명해짐. 행거에서 작동.
			while(alphaValue > 0)
			{
				centerBlack.GetComponent<UITexture>().material.SetColor("_TintColor" , new Color(0f,0f,0f,alphaValue));
				alphaValue -= Time.deltaTime *0.5f;
				yield return null;
			}
			centerBlack.SetActive(false);
		}
	}
}
