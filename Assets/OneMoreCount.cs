using UnityEngine;
using System.Collections;

public class OneMoreCount : MonoBehaviour {

    float hasSecondsTemp = 10;
    float hasSeconds = 10;
    int hasSecondsI;
    public bool isIntoShop = false;

    void Awake()
    {
        hasSecondsTemp = hasSeconds;
    }

	// Update is called once per frame
    void Update()
    {
        if (isIntoShop == false)
        {
            hasSeconds -= Time.deltaTime;
            if (hasSeconds > 0)
            {
                hasSecondsI = (int)hasSeconds;
                GetComponent<UISprite>().spriteName = "Img_StageCount" + hasSecondsI;
                GetComponent<UISprite>().MakePixelPerfect();
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<UiShow>().OneMoreActionCancel();
            }
        }
        //카운트를 담당하는 IF 구문//
    }

    public void CountReset()
    {
        hasSeconds = hasSecondsTemp;
    }
}
