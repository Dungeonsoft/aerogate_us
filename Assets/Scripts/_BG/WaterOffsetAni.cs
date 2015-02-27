using UnityEngine;
using System.Collections;

public class WaterOffsetAni : MonoBehaviour {
	public float scrollSpeed;
	float speed;
	float speedIns;
	public float maxIncreaseSpeed;
	public int maxSpeedTime;

	void Update () {
		
		if(Time.timeSinceLevelLoad < maxSpeedTime)
		{
			speedIns = (scrollSpeed * Time.deltaTime) + ((scrollSpeed * Time.deltaTime) * (Time.timeSinceLevelLoad/maxSpeedTime)*(maxIncreaseSpeed-1));
		}
		speed += speedIns;		
		
		renderer.material.mainTextureOffset = new Vector2(0,-speed);
	
	}
}
