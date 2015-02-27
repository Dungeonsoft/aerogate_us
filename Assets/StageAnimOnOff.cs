using UnityEngine;
using System.Collections;

public class StageAnimOnOff : MonoBehaviour {


    void OffAnim()
    {
        GetComponent<Animator>().SetBool("Run", false);   
    }

}
