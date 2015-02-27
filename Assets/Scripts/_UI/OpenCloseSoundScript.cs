using UnityEngine;
using System.Collections;


public class OpenCloseSoundScript : MonoBehaviour {

    HangarManager hangarManager;

    public bool isLevelPopUp = false;

    void Awake()
    {
        hangarManager = GameObject.Find("GameManager").GetComponent<HangarManager>();
    }


    void OnEnable()
    {
        if (!isLevelPopUp)
        {
            hangarManager.OpenSound();
        }
        else
        {
            hangarManager.LevelPopupDisplay();
        }
    }

    void OnDisable()
    {
        hangarManager.CloseSound();
    }

}
