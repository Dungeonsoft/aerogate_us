using UnityEngine;
using System.Collections;

public class ItemInfomationScript : MonoBehaviour
{

    int sW;
    int sH;
    float propotion;

    GameObject UiRoot;

    bool moveTrue = false;

    void Awake()
    {
        sW = Screen.width;
        sH = Screen.height;
        UiRoot = GameObject.Find("UI Root (2D)");
        propotion = ((float)UiRoot.GetComponent<UIRoot>().manualHeight / sH);

        sW = (int)(sW * propotion);
        sH = (int)(sH * propotion);
    }

    public void Activate(Vector3 target)
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(target);
        transform.localPosition = new Vector3((pos.x - 0.5f) * sW - 60, (pos.y - 0.5f) * sH + 20, 0);
        StartCoroutine(Deactivate());
        StartCoroutine(MoveUp());
    }

    IEnumerator Deactivate()
    {
        moveTrue = true;
        yield return new WaitForSeconds(2f);
        transform.localPosition = new Vector3(0, -800, 0);
        moveTrue = false;
    }

    IEnumerator MoveUp()
    {
        float valueY = 0;
        while (moveTrue)
        {
            transform.localPosition += new Vector3(0, valueY, 0);
            valueY += Time.deltaTime * .8f;
            yield return null;
        }
    }
}
