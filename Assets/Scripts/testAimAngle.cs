using UnityEngine;
using System.Collections;

public class testAimAngle : MonoBehaviour {


	public Transform focusEnemy;

	float distX;
	float distZ;
	float rad;
	float degY;

	float tRotY;

	float fixedY;
	float addValue = 0;
	public float testA= 180;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				distX = focusEnemy.position.x - transform.position.x;
				distZ = focusEnemy.position.z - transform.position.z;
				rad = Mathf.Atan2 (distX, distZ);
		Debug.Log ("distX ::: "+distX);
		Debug.Log ("distY ::: "+distZ);
				Debug.Log ("rad ::: " + rad);
				degY = ((rad * 180f) * 0.3183f) + testA;
				Debug.Log ("degY ::: " + degY);
				tRotY = transform.eulerAngles.y;
				fixedY = Mathf.LerpAngle (tRotY, degY, addValue);
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, fixedY, transform.eulerAngles.z);
				if (addValue < 1)					
						addValue = Time.deltaTime * 2;
	
		}
}
