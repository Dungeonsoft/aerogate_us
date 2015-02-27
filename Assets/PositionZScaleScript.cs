using UnityEngine;
using System.Collections;

public class PositionZScaleScript : MonoBehaviour {
    float zVal;
    float zPosition;

    void Awake()
    {
        zPosition = transform.localPosition.z;
        zVal = (618.9695f + zPosition) / 618.9695f;
        transform.localScale = new Vector3(zVal, zVal, zVal);
    }

    void OnEnable()
    {
        zPosition = transform.localPosition.z;
        zVal = (618.9695f + zPosition) / 618.9695f;
        transform.localScale = new Vector3(zVal, zVal, zVal);
    }
}
