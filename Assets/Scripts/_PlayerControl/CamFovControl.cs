using UnityEngine;
using System.Collections;

public class CamFovControl : MonoBehaviour {

	Camera camera;

	void Start ()
	{
		camera = gameObject.GetComponent<Camera>();
	}

	public void Activate ()
	{
		StartCoroutine( ChangeFov ());
	}

	IEnumerator ChangeFov()
	{
		while(camera.fieldOfView < 80f)
		{
			camera.fieldOfView += Time.deltaTime * 7f;
			yield return null;
		}
		camera.fieldOfView = 80f;

		yield return new WaitForSeconds (3f);

		while(camera.fieldOfView > 60)
		{
			camera.fieldOfView -= Time.deltaTime * 7f;
			yield return null;
		}
		camera.fieldOfView = 60f;
	}
}
