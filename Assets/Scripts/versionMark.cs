using UnityEngine;
using System.Collections;

public class versionMark : MonoBehaviour {

	// Use this for initialization
    void Awake()
    {
        GetComponent<UILabel>().text = ValueDeliverScript.ver;
    }
}
