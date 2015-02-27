using UnityEngine;
using System.Collections;

public class InstanceWingBoxApearScript : MonoBehaviour
{

    Transform timer;
    Transform portalRot;
    public Vector3 rotVal = new Vector3(0,0,5);

    GameObject ufoCount;

    void Awake()
    {
        timer = transform.FindChild("TimerSprite");
        portalRot = transform.FindChild("BgBoxBack");

        ufoCount = transform.FindChild("UfoCount").gameObject;

        timer.GetComponent<UIFilledSprite>().fillAmount = 0;
    }
    public void Activate()
    {
        timer.GetComponent<UIFilledSprite>().fillAmount = 1;
        ufoCount.SetActive(false);
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {

        while (timer.GetComponent<UIFilledSprite>().fillAmount > 0)
        {
            timer.GetComponent<UIFilledSprite>().fillAmount -= Time.deltaTime * 0.1f;
            portalRot.eulerAngles += rotVal;
            yield return null;
        }

        ufoCount.SetActive(true);
    }
}
