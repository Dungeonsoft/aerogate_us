using UnityEngine;
using System.Collections;

public class FbLoginScript : MonoBehaviour
{

    public FaceBookUseScript faceBookUseScript;

    void Start()
    {
        //최초 페이스북 이니셜 실행//
        faceBookUseScript.CallFBInit();
    }

}
