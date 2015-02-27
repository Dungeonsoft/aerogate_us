using UnityEngine;
using System.Collections;

public class BombActivateScript : MonoBehaviour {
	float startTime;
	public int bombDamage = 5000;
	
	// Update is called once per frame
	void Update () 
	{
		if(startTime <= 0)
		{
			gameObject.SetActive(false);
		}
		startTime -= Time.deltaTime;
	
	}
	
	public void Activate()
	{
        GameObject.Find("GameManager").GetComponent<SoundUiControlScript>().PlasmaWaveShot();    //미션완료음.
		startTime = 0.9f;
	}
}
