using UnityEngine;
using System.Collections;

public class FbOutScript : MonoBehaviour {

    public void FbOut()
    {
        GameObject.Find("FacebookLogin").GetComponent<FaceBookUseScript>().CallFBLogout();
        PlayerPrefs.DeleteAll();
        Debug.Log("FbOut Started!!");
        ValueDeliverScript.ResetValue();
        StartCoroutine(LoadFirst());
    }

    public void LogOutForFbLogin()
    {
        PlayerPrefs.DeleteAll();
        ValueDeliverScript.ResetValue(true);
        StartCoroutine(LoadFirst());
    }

    IEnumerator LoadFirst()
    {
        yield return new WaitForSeconds(1f);
        //Application.Quit();
        Destroy(GameObject.Find("FacebookLogin"));
        Destroy(GameObject.Find("EveryPlayTest"));
        
        Application.LoadLevel(0);

    }
}