using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityAdsManager : MonoBehaviour {

    void Awake()
    {
        string adsID = "24534";
        
#if UNITY_IOS
        adsID = "24763";
#endif

        if (Advertisement.isSupported)
        {
            Advertisement.allowPrecache = true;
            Advertisement.Initialize(adsID, false);
        }
        else
        {
            Debug.Log("Platform not supported");
        }
    }


    public void AbleAds(System.Action SucceessF = null)
    {
        if (Advertisement.isReady() == true)
        {

            Advertisement.Show(null, new ShowOptions
            {
                pause = true,
                resultCallback = result =>
                {
                    Debug.Log(result.ToString());
                    if (result.ToString() == "Finished")
                    {
                        SucceessF();
                    }
                }
            });
        }
    }
}
