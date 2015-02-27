using UnityEngine;
using System.Collections;

public class LevelChangeBombScript : MonoBehaviour 
{
	public int speed = 25;
	public int endPositionZ;

	void Update ()
	{
		transform.Translate(0 , 0 , speed * Time.deltaTime);

		if(transform.position.z >= endPositionZ)
			Destroy(gameObject);
	}
}
