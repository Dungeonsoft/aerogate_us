using UnityEngine;
using System.Collections;

public class FakeFxScript : MonoBehaviour {
	ActivateScript activate;
	GameObject gameManager;
	Vector3 camPosition;
	void Start () 
	{
		activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();
		gameManager = GameObject.Find("GameManager");
	}

	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "Bomb02")
		{
			activate.ExploActivation(transform.position,04,"Bomb02"); //폭발이펙트 켜짐.
			gameManager.GetComponent<SoundUiControlScript>().UfoExplo(); //폭파음재생.
		}
	}
}
