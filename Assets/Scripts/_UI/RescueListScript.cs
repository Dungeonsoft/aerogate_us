using UnityEngine;
using System.Collections;

public class RescueListScript : MonoBehaviour {

    public GameObject rescueFriend;
    public int RescuedFriendNumber = 10;


    void Awake()
    {
        InstanceRescueFriendTab(RescuedFriendNumber);
    }

    void InstanceRescueFriendTab(int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject go = Instantiate(rescueFriend) as GameObject;
            //go.transform.parent = transform.FindChild("DragPanel/RescueList");
            //go.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    }
