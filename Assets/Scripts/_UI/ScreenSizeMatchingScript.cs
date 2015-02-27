using UnityEngine;
using System.Collections;

public class ScreenSizeMatchingScript : MonoBehaviour {

    int scrX;
    int scrY;
    float scrRatio;
    public bool isRight;
    int onRight;

    void Awake()
    {
        if (isRight) onRight = 1;
        else onRight = -1;

        scrX = Screen.width;
        scrY = Screen.height;
        scrRatio =(float)scrX / (float)scrY;

        if (scrRatio <= 1.5f) return;
        else
        {
            int x = (int)((((720 * scrRatio) - 1080) * 0.5f));
            transform.localPosition += new Vector3(onRight * x, 0, 0);
        }
    }
}
