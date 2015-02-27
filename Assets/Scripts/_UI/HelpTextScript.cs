using UnityEngine;
using System.Collections;

public class HelpTextScript : MonoBehaviour {
	int sW;
	int sH;
	float propotion;

	GameObject UiRoot;
	Vector3 pos;
	GameObject target;

	void Awake ()
		{
				sW = Screen.width;
				sH = Screen.height;
				UiRoot = GameObject.Find ("UI Root (2D)");
				propotion = ((float)UiRoot.GetComponent<UIRoot> ().manualHeight / sH);
				sW = (int)(sW * propotion);
				sH = (int)(sH * propotion);
		}



	// Update is called once per frame
	void Update ()
		{
				pos = Camera.main.WorldToViewportPoint (target.transform.position);
				transform.localPosition = new Vector3 ((pos.x-0.5f) * sW, (pos.y - 0.5f) * sH + 70, 0);
				if (target.activeSelf == false)
						gameObject.SetActive (false);
		}

	public void Activate (GameObject target)
		{
				this.target = target;
				pos = Camera.main.WorldToViewportPoint (target.transform.position);
				transform.localPosition = new Vector3 ((pos.x-0.5f) * sW, (pos.y - 0.5f) * sH + 70, 0);
				animation.Play ();
		}
}
