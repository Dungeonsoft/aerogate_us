using UnityEngine;
using System.Collections;
using System;

public class UtcTimeScript : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        //Debug.Log("Time  ::: " + DateTime.UtcNow);

        //Debug.Log("Time To Double ::: " + (DateTime.UtcNow.Year));
        //Debug.Log("Time To Double ::: " + (DateTime.UtcNow.Month));
        //Debug.Log("Time To Double ::: " + (DateTime.UtcNow.Day));
        //Debug.Log("Time To Double ::: " + (DateTime.UtcNow.Hour));
        //Debug.Log("Time To Double ::: " + (DateTime.UtcNow.Minute));
        //Debug.Log("Time To Double ::: " + (DateTime.UtcNow.Second));

        //Debug.Log("Time Tick " + DateTime.Now.Ticks/10000);

        DateTime UtcNow = DateTime.UtcNow;
        DateTime baseTime = new DateTime(1970, 1, 1, 0, 0, 0);
        long timeStamp = (UtcNow - baseTime).Ticks / 10000000;

        //Debug.Log("Time Stamp ::: " + timeStamp);

        //Debug.Log("UTC Time To Double1 ::: " + System.Convert.ToDouble(DateTime.UtcNow.ToShortDateString()));
        //Debug.Log("UTC Time To Double2 ::: " + System.Convert.ToDouble(DateTime.UtcNow.ToLongDateString()));
        //Debug.Log("UTC Time To Double3 ::: " + System.Convert.ToDouble(DateTime.UtcNow.ToUniversalTime()));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
