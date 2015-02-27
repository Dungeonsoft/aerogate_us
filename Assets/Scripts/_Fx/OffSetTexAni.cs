using UnityEngine;
using System.Collections;

public class OffSetTexAni : MonoBehaviour
{
    public float xRatioPer100 = 25;
    float uvX;

    void Start()
    {
        renderer.material.mainTextureScale = new Vector2(xRatioPer100 / 100f, 1);
    }

    void Update()
    {
        uvX = xRatioPer100 * 0.01f;
        if (Time.timeScale != 0)
            renderer.material.mainTextureOffset += new Vector2(uvX, 0);

        if (renderer.material.mainTextureOffset.x == 50)
        {
            uvX = 0;
        }
    }
}