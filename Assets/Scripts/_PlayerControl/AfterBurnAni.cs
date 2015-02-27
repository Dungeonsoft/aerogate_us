using UnityEngine;
using System.Collections;

public class AfterBurnAni : MonoBehaviour 
{
	void Update () 
	{
		transform.localScale = new Vector3 (1,1, Random.Range(0.8f , 1.2f) );
	}
}
