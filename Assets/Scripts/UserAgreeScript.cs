using UnityEngine;
using System.Collections;

public class UserAgreeScript : MonoBehaviour {
    bool agree01 = false;
    bool agree02 = false;

    void Agree01Func()
    {
        agree01 = !agree01;
        BtnShow();
    }

    void Agree02Func()
    {
        agree02 = !agree02;
        BtnShow();
    }



    void BtnShow()
    {

        if (agree01 && agree02)
        {
            GameObject.Find("Anchor").transform.FindChild("KakaoLoginBtn").gameObject.SetActive(true);
            GameObject.Find("Anchor").transform.FindChild("GuestPlayBtn").gameObject.SetActive(true);
            StartCoroutine(HideObject());
        }
    }

    IEnumerator HideObject()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("SubCamera").SetActive(false);

    }
}
