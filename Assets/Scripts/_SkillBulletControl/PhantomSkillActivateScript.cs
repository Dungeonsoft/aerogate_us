using UnityEngine;
using System.Collections;

public class PhantomSkillActivateScript : MonoBehaviour {

	public float endPosition = 55;
	public float speed = 20;

	float speedOri;

	void Start ()
		{
				speedOri = speed;
		}


	public void Activate ()
		{
				transform.position = new Vector3 (transform.position.x, 0, 0);
				speed = speedOri;
                GameObject.Find("GameManager").GetComponent<SoundUiControlScript>().PhantomSkillShot();
		}

	void Update ()
		{
				if (transform.position.z < endPosition) {
						transform.Translate (0, 0, speed * Time.deltaTime);
						speed += Time.deltaTime * 50;
				} else {
						gameObject.SetActive (false);
				}
		}
}
