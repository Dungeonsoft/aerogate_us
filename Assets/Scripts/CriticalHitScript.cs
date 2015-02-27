using UnityEngine;
using System.Collections;


//리페어 애니메이션에도 쓰임.
public class CriticalHitScript : MonoBehaviour
{
    public enum animState
    {
        criticalHit,
        repair,
    }


    int sW;
    int sH;
    float propotion;

    GameObject UiRoot;
    Vector3 pos;
    GameObject target;
    public int addPosZ = 70;

    public animState state = animState.criticalHit;

    public int actTime = 1;

    bool isChangeColor = false;

    Color oriColor;
    Color changeColor;

    bool isRebirth = false;

    void Awake()
    {
        sW = Screen.width;
        sH = Screen.height;
        UiRoot = GameObject.Find("UI Root (2D)");
        propotion = ((float)UiRoot.GetComponent<UIRoot>().manualHeight / sH);
        sW = (int)(sW * propotion);
        sH = (int)(sH * propotion);

        if (state == animState.repair) target = GameObject.Find("PC");

        oriColor = new Color(1,1,1);
        changeColor = new Color(0.1f, 0.1f, 0.1f);
    }

    public void Activate(GameObject parentObj , bool isRebirth = false)
    {
        isChangeColor = false;
        this.isRebirth = isRebirth;
        this.target = parentObj;
        pos = Camera.main.WorldToViewportPoint(target.transform.position);
        transform.localPosition = new Vector3((pos.x - 0.5f) * sW, (pos.y - 0.5f) * sH + addPosZ, 0);

        switch (state)
        {
            case animState.criticalHit:
                transform.GetChild(0).animation.Play("CriticalHitAnim01");
                break;

            case animState.repair:
                transform.animation.Play("RefairAnim01");
                //GameObject.Find("GameManager").GetComponent<BulletControlScript>().RepairTime(4f);
                //target.GetComponent<PlayerMoveScript>().RepairTime();
                GameObject.Find("Main Camera").GetComponent<CameraShakeScript>().NowTime(1f);
                break;
        }
        StartCoroutine(ActiveFalse());
    }

    void Update()
    {
        if (state == animState.repair)
        {
            pos = Camera.main.WorldToViewportPoint(target.transform.position);
            transform.localPosition = new Vector3((pos.x - 0.5f) * sW, (pos.y - 0.5f) * sH + addPosZ, 0);
            if (isChangeColor == false)
            {
                isChangeColor = true;
                StartCoroutine(ChangeColor());

            }
        }
    }

    IEnumerator ActiveFalse()
    {
        yield return new WaitForSeconds(actTime);
        gameObject.SetActive(false);
    }


    IEnumerator ChangeColor()
    {
        if (isRebirth == false) StartCoroutine(ChColor(oriColor, changeColor));
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(ChColor(changeColor, oriColor));
        target.GetComponent<PlayerMoveScript>().RepairEnd();

        isRebirth = false;
    }

    IEnumerator ChColor(Color aClr, Color bClr)
    {
        Material fMat = target.transform.FindChild("Flight/BodyBase").renderer.material;
        Color addColor = new Color(1, 1, 1);
        float val = 0;
        while (val < 1)
        {
            addColor = Color.Lerp(aClr, bClr, val);
            fMat.SetColor("_AddColor", addColor);
            yield return null;
            val += Time.deltaTime * 2;
        }
        fMat.SetColor("_AddColor", bClr);
    }
}
