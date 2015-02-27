using UnityEngine;
using System.Collections;

public class SuperPowerRegen : MonoBehaviour
{
    ActivateScript activate;

    // Use this for initialization
    void Start()
    {
        activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.S))
        {
            int itemLevel = 51;
            activate.ItemActivation(transform.position, itemLevel);
        }
    }
}
