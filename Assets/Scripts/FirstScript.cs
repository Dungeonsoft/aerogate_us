using UnityEngine;
using System.Collections;

public class FirstScript : MonoBehaviour
{


    void LoadStart()
    {
        Debug.Log("WaitingLogIn");

        //StartCoroutine(WatingForLogoAnim());
    }

//    IEnumerator WatingForLogoAnim()
//    {
//        Debug.Log("WaitingLogIn");

//        //Debug.Log("WaitingLogIn2");

//#if UNITY_EDITOR

//        //Debug.Log("EDITOR!!!!");
//        //GameObject.Find("CM_Manager").GetComponent<AfterInitialScript>().BoolFirstLogIn();
//#endif
//        //while (true)
//        //{
//        //    //Debug.Log("Wating?");
//        //    yield return new WaitForSeconds(.5f);
//        //}

//        //Debug.Log("LogOK");
//        //yield return new WaitForSeconds(2f);
//        //if (ValueDeliverScript.isVerCheckFaild == false)
//        //    Application.LoadLevel("Hangar");
//    }

    //public void NextScene()
    //{
    //    Debug.Log("LogOK");
    //    if (ValueDeliverScript.isVerCheckFaild == false)
    //        Application.LoadLevel("Hangar");
    //}
}
