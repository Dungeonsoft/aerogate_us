using UnityEngine;
using System.Collections;

public class RotateZFlight : MonoBehaviour {
	
	float startTime;
	public int speed = 2;
	bool targetOn = true;
	public bool isRot = false;
	// Use this for initialization
	void Start () 
	{
		if(isRot)
		{
		transform.rotation = Quaternion.Euler(0,180,0);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(targetOn)
		{
			startTime = Time.time;
			targetOn = false;
		}

		if(isRot)
		{
		transform.localRotation = Quaternion.Euler(0 , 0 , speed*(Time.time-startTime) );
		}
		else
		{
		transform.localRotation = Quaternion.Euler( 0 , speed*(Time.time-startTime) , 0);
		}

//		Debug.Log("transform.rotation.y : "+transform.rotation.y);
	}
	
	public void TargetOn()
	{
		targetOn = true;
	}
}
