using UnityEngine;
using System.Collections;

public class ThunderFXScript : MonoBehaviour {
	public GameObject[] thunder;


	public void Activate ()
	{
		StartCoroutine(ThunderStart ());
	}

	IEnumerator ThunderStart ()
	{
        Debug.Log("여기 썬더!!!!!");
		for(int i = 0 ; i < thunder.Length ; i++)
		{
			thunder[i].GetComponent<ThunderAct>().Activate(1f);
			yield return new WaitForSeconds(.2f);
		}
	}


}
