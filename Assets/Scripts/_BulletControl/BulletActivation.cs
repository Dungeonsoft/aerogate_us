using UnityEngine;
using System.Collections;

public class BulletActivation : MonoBehaviour {
	float nowTime;


	public void Activate()
		{
				nowTime = 1f;
				int childCount = gameObject.transform.GetChildCount ();
				for (int j=0; j<childCount; j++) {
						gameObject.transform.GetChild (j).gameObject.GetComponent<Fire> ().Activate ();
				}
				StartCoroutine (DeadTime ());
		}

	IEnumerator DeadTime ()
		{
				yield return new WaitForSeconds (nowTime);
				gameObject.SetActive (false);
		}
}
