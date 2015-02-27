using UnityEngine;
using System.Collections;

public class TestInst03 : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
        TestInst.instance.tempNumA += 5;

        //Debug.Log("TempA is " + TestInst.instance.tempNumA + " in test02 Scene");

        //Debug.Log("TempA is " + TestInst.instance.tempNumA);
        yield return new WaitForSeconds(2f);
        //Debug.Log("Load Level ..........");

        Application.LoadLevel(3);
	}
	
}
