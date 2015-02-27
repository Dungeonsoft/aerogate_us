using UnityEngine;
using System.Collections;

public class BlinkerScript : MonoBehaviour {

    bool enable = true;

    void Start()
    {
        Activate(10f);
    }

    public void Activate(float duraTime)
    {
        StartCoroutine(Blinker(duraTime));
    }

    IEnumerator Blinker(float duraTime)
    {
        float spendTime = 0;
        while (duraTime > spendTime)
        {
            enable = !enable;
            GetComponent<UISprite>().enabled = !enable;
            spendTime += Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
