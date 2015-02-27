using UnityEngine;
using System.Collections;

public class SpeedLightXposition : MonoBehaviour 
{

	public Transform AimPosition;

	void Update () 
	{
		transform.position = new Vector3 (AimPosition.position.x , transform.position.y , transform.position.z );	
	}
}