using UnityEngine;
using System.Collections;

public class BulletMissileActivationBackUp : MonoBehaviour {

	public GameObject focusEnemy;
	public bool targetOn;
	public float lifeTime;
	float enemyDistance = 6;
	float enemyDistanceDouble;

	float distX;
	float distZ;
	float rad;
	float degY;

	float tRotY;

	float fixedY;
	float addValue = 0;


	// Use this for initialization

	public void Activate()
		{
				StartCoroutine (DeadTime ());
		}

	public void Activate(float missileAngle){
//				targetOn = false;
				enemyDistanceDouble = enemyDistance * enemyDistance;
				transform.eulerAngles = new Vector3 (0, missileAngle, 0);
//				StartCoroutine (DeadPosition ());
		}

	IEnumerator DeadTime ()
		{
				
				yield return new WaitForSeconds (lifeTime);
				gameObject.SetActive (false);
		}

	void Update ()
		{
				if (!targetOn) {
						return;
				}
				if (focusEnemy != null) {
						if (focusEnemy.activeSelf == true) {
								distX = focusEnemy.transform.position.x - transform.position.x;
								distZ = focusEnemy.transform.position.z - transform.position.z;
								rad = Mathf.Atan2 (distX, distZ);
																		Debug.Log ("rad ::: " + rad);
								degY = ((rad * 180f) * 0.3183f);
																		Debug.Log ("degY ::: " + degY);
								tRotY = transform.eulerAngles.y;

								if (addValue < 1) {		
										fixedY = Mathf.LerpAngle (tRotY, degY, addValue);
										transform.eulerAngles = new Vector3 (transform.eulerAngles.x, fixedY, transform.eulerAngles.z);
										addValue = Time.deltaTime * 7;
								} else {
										transform.eulerAngles = new Vector3 (transform.eulerAngles.x, degY, transform.eulerAngles.z);
								}
						}
				}

				transform.Translate (0, 0, 35 * Time.deltaTime);
//				Debug.Log ("Move Move Move Move Move Move Move Move Move Move Move Move Move Move Move Move Move Move ");

				if (transform.position.x > 25 || transform.position.x < -25 || transform.position.z > 120 || transform.position.z < -10) {
						gameObject.SetActive (false);
				}
		}
		


	/*
	IEnumerator DeadPosition ()
		{
				while (true) {
						if (isFindEnemy && focusEnemy.activeSelf == true) {
								distX = focusEnemy.transform.position.x - transform.position.x;
								distZ = focusEnemy.transform.position.z - transform.position.z;
								rad = Mathf.Atan2 (distX, distZ);
//										Debug.Log ("rad ::: " + rad);
								degY = ((rad * 180f) * 0.3183f);
//										Debug.Log ("degY ::: " + degY);
								tRotY = transform.eulerAngles.y;

								if (addValue < 1) {		
										fixedY = Mathf.LerpAngle (tRotY, degY, addValue);
										transform.eulerAngles = new Vector3 (transform.eulerAngles.x, fixedY, transform.eulerAngles.z);
										addValue = Time.deltaTime * 7;
								} else {
										transform.eulerAngles = new Vector3 (transform.eulerAngles.x, degY, transform.eulerAngles.z);
								}
						}

						transform.Translate (0, 0, 35 * Time.deltaTime);
						if (transform.position.x > 25 || transform.position.x < -25 || transform.position.z > 120 || transform.parent.position.z < -10) {
								break;
						}
						yield return null;
				}
				gameObject.SetActive (false);
		}
	/*
	void Update ()
		{
				if (!isFindEnemy) {
						addValue = 0;

						GameObject[] enemyObject;
						enemyObject = GameObject.FindGameObjectsWithTag ("Enemy");

						foreach (GameObject go in enemyObject) {
								distX = go.transform.position.x - transform.position.x;
								distZ = go.transform.position.y - transform.position.y;
								if (distX * distX + distZ * distZ < enemyDistanceDouble) {
										isFindEnemy = true;
										focusEnemy = go;
										break;
								}
						}
				}
		}

	/*
	void FindEnemy()
		{
				addValue = 0;

				GameObject[] enemyObject;
				enemyObject = GameObject.FindGameObjectsWithTag ("Enemy");

				foreach (GameObject go in enemyObject) {
						distX = go.transform.position.x - transform.position.x;
						distZ = go.transform.position.y - transform.position.y;
						if (distX * distX + distZ * distZ < enemyDistanceDouble) {
								isFindEnemy = true;
								focusEnemy = go;
								break;
						}
				}
		}
	*/
}        

