using UnityEngine;
using System.Collections;

public class GetThumanil : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        Debug.Log("널이냐1?");
        Debug.Log("널이냐2?" + GameObject.Find("EveryPlayTest").GetComponent<EveryplayTest>().previousThumbnail != null);
        if (GameObject.Find("EveryPlayTest").GetComponent<EveryplayTest>().previousThumbnail != null)
        {
            gameObject.GetComponent<UITexture>().mainTexture = GameObject.Find("EveryPlayTest").GetComponent<EveryplayTest>().previousThumbnail;
        }
    }
}
