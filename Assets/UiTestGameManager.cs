using UnityEngine;
using System.Collections;

public class UiTestGameManager : MonoBehaviour {

    public GameObject GB;

    void GbRotate()
    {
        GB.transform.rotation *= Quaternion.Euler(10, 5, 10);
    }
}
