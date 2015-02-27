using UnityEngine;
using System.Collections;

public class NoTouchScript : MonoBehaviour {

    public GameObject noTouchPanel;

    public GameObject ScoreText;

    public bool isWaitScore;

    void Awake()
    {
        noTouchPanel = GameObject.Find("Anchor").transform.FindChild("NoTouchPanel").gameObject;
    }


    public void NoTouchStart()
    {
        noTouchPanel.SetActive(true);
    }

    public void NotouchEnd()
    {
        noTouchPanel.SetActive(false);
    }

    public void NotouchEnd2()
    {
        StartCoroutine(ScoreText.GetComponent<ScoreTextScript>().ScoreAnim());
        StartCoroutine(notouch());
    }


    IEnumerator notouch()
    {
        float waitTime = 0 ;
        if (ValueDeliverScript.isSpecialAttackComplete == 0)
        {
            waitTime = 2f;
        }
        else
        {
            waitTime = 4f;
        }

            yield return new WaitForSeconds(waitTime);
        noTouchPanel.SetActive(false);
    }
}
