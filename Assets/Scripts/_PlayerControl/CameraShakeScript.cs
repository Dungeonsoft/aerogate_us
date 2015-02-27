using UnityEngine;
using System.Collections;

public class CameraShakeScript : MonoBehaviour {

//	float nowTime = 0;
	float shakeTime = 0;
//	float shakeRange = 0;
	bool withPC = false;
	bool vib = false;
	public GameObject PC;



	// Use this for initialization
	public void NowTime (/*float _shakeRange ,*/ float _shakeTime , bool withPC=false , bool vib=false)
	{

		this.withPC = withPC;
//		nowTime = Time.timeSinceLevelLoad;
		shakeTime = _shakeTime + Time.timeSinceLevelLoad;
//		shakeRange = _shakeRange;
		this.vib = vib;



		StartCoroutine(Shaker ());
	}

	IEnumerator Shaker () 
	{
		if(vib)
		{
            //Handheld.Vibrate ();
			vib =false;
		}
		while(shakeTime > Time.timeSinceLevelLoad)
		{
            if (Time.timeScale == 0) continue;
			Vector3 randPosition = new Vector3( Random.Range(-.3f,.3f) , Random.Range(-.3f,.3f) , Random.Range(-.3f,.3f) );
			transform.position = new Vector3(0 , 21.5f , -9f) + randPosition;
			if(withPC)
			{
//				PC.transform.parent = this.gameObject.transform;
			}
			yield return null ;
		}
		transform.position = new Vector3(0 , 21.5f , -9f);
//		PC.transform.parent = transform.Find ("GameManager");
	}

}