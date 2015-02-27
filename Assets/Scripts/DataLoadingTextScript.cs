using UnityEngine;
using System.Collections;

public class DataLoadingTextScript : MonoBehaviour {
    int pointCount = 0;
    string oriText;
	// Use this for initialization

    void Awake()
    {
        oriText = GetComponent<UILabel>().text;
    }
	IEnumerator Start () 
    {
        while (true)
        {
            GetComponent<UILabel>().text = oriText;

            pointCount = 0;
            while (pointCount < 3)
            {
                yield return new WaitForSeconds(1f);
                GetComponent<UILabel>().text += ".";
                pointCount++;
            }
            yield return new WaitForSeconds(1f);
        }
	}
	
}
