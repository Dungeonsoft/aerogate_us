using UnityEngine;
using System.Collections;

public class PortalRotateScript : MonoBehaviour
{

	public float[] portalLevelSpeed;
	int portalLevel;

	void Start ()
	{
		portalLevel = 1;
//		portalLevelSpeed = new float[7]{100,1200,140,160,180,200,220};
	}

	void Update () 
	{
		transform.Rotate( 0 , 0 , portalLevelSpeed[portalLevel-1]*Time.deltaTime);
	}

	public void AddSpeed (int fromPortalLevel)
	{

//		Debug.Log ("fromPortalLevel ::: "+fromPortalLevel);
		portalLevel = fromPortalLevel;
	}
}
