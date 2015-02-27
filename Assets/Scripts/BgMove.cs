using UnityEngine;
using System.Collections;

public class BgMove : MonoBehaviour 
{
	public int speed;
	public int endPosition = -155;
    public int startPosition = 380;
	public float maxIncreaseSpeed;
	public int maxSpeedTime;
	int portalLevel;
    public PortalControlScript portalControlScript;

	bool isSpeedUp = false;
	bool isReverse = false;
	float firstSpeed;
	float secondSpeed;
	float speedUpTime;
	float timer;
	
	void Start () 
	{
        Debug.Log("isSelectSpecial ::: " + ValueDeliverScript.isSelectSpecial);
        float increaseSpeCialSpeed = 1;
        if (ValueDeliverScript.isSelectSpecial == true) increaseSpeCialSpeed = ValueDeliverScript.specialSpeed;
        if (portalControlScript != null)
        {
            firstSpeed = -(speed + ((portalControlScript.portalLevel - 1) * 20)) * increaseSpeCialSpeed;
        }

	}
	
	void Update () 
	{
		if(isSpeedUp)
		{
			timer += Time.deltaTime;
			if(!isReverse)
			{
				transform.Translate(0 , 0 ,  Time.deltaTime * Mathf.Lerp(firstSpeed , secondSpeed , speedUpTime));
				speedUpTime += Time.deltaTime * 0.5f;
				if(speedUpTime >= 1) isReverse = true;
			}
			else
				if(timer <= 4 && isReverse)
			{
				transform.Translate(0 , 0 ,  Time.deltaTime * secondSpeed);
			}
			if(timer > 4)
			{
                transform.Translate(0, 0, Time.deltaTime * Mathf.Lerp( firstSpeed, secondSpeed, speedUpTime));
				speedUpTime -= Time.deltaTime * 0.3f;
				if(speedUpTime <= 0) isSpeedUp = false;
			}
		}

		else
		{
            transform.Translate(0, 0, (firstSpeed * Time.deltaTime));
		}

        if (transform.position.z <= endPosition)
		{
            transform.position = new Vector3(0, 0, (startPosition + (transform.position.z - endPosition)));
		}
	}

	public void SpeedUp ()
	{
		isSpeedUp = true;
		isReverse = false;
		firstSpeed = -(speed+((portalControlScript.portalLevel-1)*20));
		secondSpeed = -300;
		speedUpTime = 0;
		timer = 0;
	}
}
