using UnityEngine;
using System.Collections;

public class PauseControlScript : MonoBehaviour {


    void OnApplicationPause(bool pauseSt)
    {
        if (GameObject.Find("Anchor").transform.FindChild("PauseMessage").gameObject.activeSelf == false)
        {
            if (pauseSt)
            {
                GameObject.Find("GameManager").GetComponent<UiShow>().OnPose();
            }
        }
    }
}
