using UnityEngine;
using System.Collections;

public class CharacterTweenScaleControlScript : MonoBehaviour
{
    void Start()
    {
        if (ValueDeliverScript.isTutComplete == 0)
        {
            GetComponent<TweenScale>().enabled = false;
        }
    }
}