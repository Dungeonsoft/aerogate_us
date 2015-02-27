using UnityEngine;
using System.Collections;

public class SpeedEffectTFScript : MonoBehaviour
{

	GameObject speedEffect01;
	GameObject speedEffect02;

	// Use this for initialization
	void Start ()
	{
		speedEffect01 = gameObject.transform.FindChild ("SpeedEffect01").gameObject;
		speedEffect02 = gameObject.transform.FindChild ("SpeedEffect02").gameObject;	
	}

	public void Activate ()
	{
		StartCoroutine(Twinkle ());
	}

	IEnumerator Twinkle ()  
	{
		MeshRenderer mesh01Render = speedEffect01.GetComponent<MeshRenderer>();
		MeshRenderer mesh02Render = speedEffect02.GetComponent<MeshRenderer>();

		mesh01Render.enabled = true;
		mesh02Render.enabled = false;

		while(true)
		{
			yield return null;
			mesh01Render.enabled = false;
			mesh02Render.enabled = true;
			yield return null;
			mesh01Render.enabled = false;
			mesh02Render.enabled = false;
			yield return null;
			mesh01Render.enabled = true;
			mesh02Render.enabled = false;
			yield return null;
			mesh01Render.enabled = false;
			mesh02Render.enabled = false;
		}
	}
	
}
