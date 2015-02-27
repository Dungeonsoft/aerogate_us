using UnityEngine;
using System.Collections;

public class PlayerPrefabLoadScript : MonoBehaviour {

    void Awake()
    {
        if (PlayerPrefs.HasKey("UserId") && PlayerPrefs.HasKey("Nick"))
        {
            ValueDeliverScript.UserID = PlayerPrefs.GetString("UserId");
            ValueDeliverScript.Nick = PlayerPrefs.GetString("Nick");

            Debug.Log("UserId && Nick ::: " + ValueDeliverScript.UserID + " " + ValueDeliverScript.Nick);

        }
        else
        {
            Debug.Log("Do NOT Have Nick & UserId !!");
        }
    }
}
