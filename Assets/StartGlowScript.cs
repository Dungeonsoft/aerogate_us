using UnityEngine;
using System.Collections;

public class StartGlowScript : MonoBehaviour {

    //void Start()
    //{
    //    transform.FindChild("GlowBtn").GetComponent<BtnGlowScript>().userStart();
    //}

    public void ShowGlow()
    {
        transform.FindChild("GlowBtn").GetComponent<BtnGlowScript>().userStart();
    }

}
