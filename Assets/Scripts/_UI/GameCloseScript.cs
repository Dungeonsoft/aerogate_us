using UnityEngine;
using System.Collections;

public class GameCloseScript : MonoBehaviour
{

    public GameObject closeWindow;
    public GameObject halfBLKPanel;
#if UNITY_ANDROID

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (halfBLKPanel.activeSelf == true) return;
            //Debug.Log("이스케이프 눌렀네~~~~~!!");
            //CmBillingAndroid.Instance.ExitWithUI();



            closeWindow.SetActive(true);
            halfBLKPanel.SetActive(true);
            halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, closeWindow.transform.localPosition.z + 5);
        }
    }

    void GameClose()
    {
        //Debug.Log("종료 눌렀네~~~~~!!");
        //CmBillingAndroid.Instance.ExitWithUI();
        Application.Quit();
    }

    void GameCloseCancel()
    {
        //Debug.Log("취소 눌렀네~~~~~!!");
        closeWindow.SetActive(false);
        halfBLKPanel.SetActive(false);
    }

#endif
}
