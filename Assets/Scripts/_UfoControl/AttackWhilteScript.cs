using UnityEngine;
using System.Collections;

public class AttackWhilteScript : MonoBehaviour {

	public GameObject[] changeColorObj;

	public void AttackWhilte ()
		{
				for (int i = 0; i < changeColorObj.Length; i++)
//						if (changeColorObj [i].activeSelf == true) {
                    if (gameObject.activeSelf == true)
                    {
                        StartCoroutine(White(changeColorObj[i]));
                    }
//						}
		}

	IEnumerator White(GameObject obj)
		{
//				if (obj.renderer != null)
						obj.renderer.material.SetColor ("_AddColor", new Color (0.7f, 0.7f, 0.7f, 0));
				yield return null;
				if (obj.renderer != null)
						obj.renderer.material.SetColor ("_AddColor", new Color (0, 0, 0, 0));
		}

	public void WhiteAct ()
	{
//				Debug.Log ("In White Act!");
		for (int i = 0; i < changeColorObj.Length; i++)
			changeColorObj [i].renderer.material.SetColor ("_AddColor", new Color (0, 0, 0, 0));
	}

}
