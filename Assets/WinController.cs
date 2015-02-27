using UnityEngine;
using System.Collections;

public class WinController : MonoBehaviour {

    public TestSceneController sceneManager;
    void CloseBtn01()
    {
        Debug.Log("여기옴?");
        sceneManager.CloseWindow(this.gameObject);
    }


    void close()
    {
        Debug.Log("여기서 기술한 내용을 실행 :: "+ this.gameObject.name);
    }

}
