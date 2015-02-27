using UnityEngine;
using System.Collections;

public class InTutScript : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        if (ValueDeliverScript.isTutComplete == 0)
        {
            transform.localPosition = new Vector3(-450, 0, 0);
        }
    }
	
}
