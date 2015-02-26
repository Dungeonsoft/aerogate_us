using UnityEngine;
using System.Collections;

public class LoadingBarScript : MonoBehaviour
{

    public UIFilledSprite loadingBarF;

    float sValue;
    float eValue;

    public void LoadingBarFill(float startV, float endV)
    {
        sValue = startV; eValue = endV;
    }

    public void LoadingBarFill(float endV)
    {
        eValue = endV;
    }

    public void LoadingBarFill()
    {
        eValue = sValue+0.17f;
    }


    void Update()
    {
        loadingBarF.fillAmount = Mathf.Lerp(sValue, eValue, 0.035f);
        sValue = loadingBarF.fillAmount;
    }
}
