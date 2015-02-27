using UnityEngine;
using System.Collections;

public class LoadingBarScript : MonoBehaviour
{

    public float GageValueAdded = 0.0834f;
    public UIFilledSprite loadingBarF;

    float sValue;
    float eValue;

    int LodingBarCount = 0;

    public void LoadingBarFill(int fCount =1)
    {
        if (fCount == 1) LodingBarCount++;
        //Debug.Log("LodingBarCount ::: " + LodingBarCount);
        //Debug.Log("LoadingBarFill Int에 들어옴.....");
        //Debug.Log("sValue :: " + sValue);
        //Debug.Log("eValue :: " + eValue);
        eValue += GageValueAdded / fCount;
        //Debug.Log("eValue :: " + eValue);
    }


    void Update()
    {
        loadingBarF.fillAmount = Mathf.Lerp(sValue, eValue, 0.035f);
        sValue = loadingBarF.fillAmount;
    }
}
