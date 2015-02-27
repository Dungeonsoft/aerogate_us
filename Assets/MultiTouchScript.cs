using UnityEngine;
using System.Collections;

public class MultiTouchScript : MonoBehaviour {

    public bool isMultiTouch;
    void Awake()
    {
        Input.multiTouchEnabled = isMultiTouch;
    }
}
