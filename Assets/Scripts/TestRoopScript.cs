using UnityEngine;
using System.Collections;

public class TestRoopScript : MonoBehaviour {
    string test;
	// Use this for initialization
	void Start () {
        for(int i = 0 ; i <100; i++)
        {
            test = "None!!!";
            for (int j = 0; j < 100; j++ )
            {
                if (i == j)
                {
                    //Debug.Log("Correct!!!");
                    test = "Have!!!";
                    break;
                }
                //Debug.Log("For00001");
            }
            //Debug.Log("State ::: "+ test);
        }
	}
	
}
