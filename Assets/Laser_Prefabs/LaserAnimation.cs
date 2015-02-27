using UnityEngine;
using System.Collections;

public class LaserAnimation : MonoBehaviour
{
    public float ySpeed = 0;
    public float xSpeed = 0;
    Vector3 objPosition;
    public float noiseVal;
    float invertNoiseVal;
    float randNoise;

    Transform parentGo;
    void Awake()
    {
        objPosition = transform.localPosition;
        invertNoiseVal = noiseVal * -1;
        parentGo = transform.parent;
    }


    void Update()
    {
        if (parentGo.localScale.x <= 0) return;

        renderer.material.mainTextureOffset -= new Vector2(0, ySpeed * Time.deltaTime);
        if (renderer.material.mainTextureOffset.y <= -10.0f)
        {
            renderer.material.mainTextureOffset = new Vector2(0, 0);
        }

        randNoise = Random.Range(invertNoiseVal, noiseVal);

        transform.localPosition = objPosition + new Vector3(randNoise, 0, 0);
    }
}
