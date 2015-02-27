using UnityEngine;
using System.Collections;
using System.Text;

public class uiObjectPool : MonoBehaviour {

	public GameObject addScore;
	public int addScoreNum;



	// Use this for initialization
	void Start ()
    {
		InstantiatePool(addScore , addScoreNum , "addScore");
   }

	void InstantiatePool(GameObject obj , int objNum , string objName)
	{
		for(int i=0;i<objNum;i++)
		{
			GameObject go = Instantiate(obj) as GameObject;
			go.transform.parent= this.transform;
			go.name =objName+i;
			go.SetActive(false);
		}	
	}

	//액티베이션.
	public void AddScoreActivation(GameObject ufo , int score , bool isPerfect)
	{
		int addScoreUiCount = transform.GetChildCount();
		for(int j=0 ; j<addScoreUiCount ; j++)
		{
			GameObject addUiGo = transform.GetChild(j).gameObject;
			if(addUiGo.activeSelf == false)
			{
				addUiGo.SetActive(true);
				addUiGo.GetComponent<AddScoreLabelScript>().Activate(ufo , score , isPerfect);
				return;
			}
		}
	}

}
