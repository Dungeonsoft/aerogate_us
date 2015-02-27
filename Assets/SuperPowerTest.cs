using UnityEngine;
using System.Collections;

public class SuperPowerTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
           GameObject.Find("GameManager").GetComponent<SuperPowerControlScript>().OnLaserBeam();

        }
	}
}
