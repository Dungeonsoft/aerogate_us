using UnityEngine;
using System.Collections;

public class RotateYFlight : MonoBehaviour {
	
	float startTime;
	public int speed = 2;
	bool targetOn = true;
	// Use this for initialization
	void Start () 
	{
		transform.rotation = Quaternion.Euler(0,0,0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(targetOn)
		{
			startTime = Time.time;
			targetOn = false;
		}
		
		transform.rotation = Quaternion.Euler(-speed*(Time.time-startTime), 0 , 0);
//		Debug.Log("transform.rotation.y : "+transform.rotation.y);
	}
	
	public void TargetOn()
	{
		targetOn = true;
	}
}
