using UnityEngine;
using System.Collections;

public class LoadMyPic : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<UITexture>().mainTexture = ValueDeliverScript.myPic;
    }
}
