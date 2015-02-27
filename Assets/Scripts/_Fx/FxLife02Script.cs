using UnityEngine;
using System.Collections;

public class FxLife02Script : MonoBehaviour
{
    public float xValue = 3f;
    public float yValue = 2f;
    public Transform cObject;
    Material mat;
    public int xV = 0;
    public int yV = 0;
    int xVT;
    int yVT;

    void Awake()
    {
        xVT = xV;
        yVT = yV;

        //Debug.Log("cObject : " + cObject.name);
        mat = cObject.renderer.materials[0];

        GameObject cam = GameObject.Find("Main Camera");
        transform.LookAt(cam.transform.position);
    }

    void OnEnable()
    {
        //Debug.Log("mat" + mat.name);
        mat.mainTextureScale = new Vector2(1 / xValue, 1 / yValue);
        GameObject cam = GameObject.Find("Main Camera");
        transform.LookAt(cam.transform.position);
    }


    void Update()
    {
        mat.mainTextureOffset = new Vector2(xV / xValue, 1 - (yV / yValue));

        if ((xV * yV) >= (xValue * yValue))
        {
            xV = xVT;
            yV = yVT;
            gameObject.SetActive(false);
        }

        if (xV < xValue) { xV++; }
        else { xV = 0; yV++; }
    }
}
