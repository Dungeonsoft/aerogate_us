using UnityEngine;
using System.Collections;

public class GasBubbleScaleScript : MonoBehaviour
{
    int gasRest;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(IsShow());
    }

    // Update is called once per frame
    IEnumerator IsShow()
    {
        while (true)
        {
            gasRest = ValueDeliverScript.gasRest;
            //Debug.Log("gasRest ::: " + gasRest);
            if (gasRest >= ValueDeliverScript.gasMax)
            {
                transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
