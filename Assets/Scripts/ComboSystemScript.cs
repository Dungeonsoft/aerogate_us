using UnityEngine;
using System.Collections;

public class ComboSystemScript : MonoBehaviour {

    float comboTime;
    int comboAttack;

    bool isCountDown = false;
    bool isAttack = false;

    public Transform ComboObject;

    public void ComboTimeFunc(float addTime)
    {
        comboTime += addTime;
    }

    void Awake()
    {
        ComboObject.localScale = new Vector3(0, 0, 0);
        comboTime = ValueDeliverScript.comboTime;
    }

    public int isCombo(int baseScore)
    {
        int addedScore = 0;

        if (isCountDown)
        {
            isAttack = true;
            StartCoroutine(ComboScale());
            comboAttack++;
        }
        else
        {
            StartCoroutine(ComboScale());
            StartCoroutine(CountDown());
        }

        float comboNum = (1 + (0.1f * comboAttack));
        ComboObject.GetComponentInChildren<UILabel>().text = "x"+comboNum.ToString("N1");
        addedScore = (int)(baseScore *comboNum);

        return addedScore;
    }

    public int isComboOnlyScore(int baseScore)
    {
        int addedScore = 0;
        float comboNum = (1 + (0.1f * comboAttack));
        addedScore = (int)(baseScore * comboNum);
        return addedScore;
    }


    IEnumerator CountDown()
    {
        isCountDown = true;
        float comboTimeCopy = comboTime;
        while (comboTimeCopy > 0f)
        {
            if (isAttack)
            {
                comboTimeCopy = comboTime;
                isAttack = false;
            }
            yield return null;
            comboTimeCopy -= Time.deltaTime;

            if (comboTimeCopy < 1f)
            {
                Color scoreColor = ComboObject.GetComponentInChildren<UILabel>().color;
                float cR = scoreColor.r;
                cR = 1f - cR;
                float cG = scoreColor.g;
                float cB = scoreColor.b;
                ComboObject.GetComponentInChildren<UILabel>().color += new Color(cR, cG*-1, cB*-1, 0);
                ComboObject.GetComponentInChildren<TweenAlpha>().enabled = true;
            }
            else
            {
                ComboObject.GetComponentInChildren<TweenAlpha>().alpha = 1f;
                ComboObject.GetComponentInChildren<TweenAlpha>().enabled = false;
            }
        }
        isCountDown = false;
        comboAttack = 0;
        StartCoroutine(ComboScaleReverce());
    }

    IEnumerator ComboScale()
    {
        ComboObject.GetComponentInChildren<TweenAlpha>().alpha = 1f;
        ComboObject.GetComponentInChildren<UILabel>().color = new Color(135f/255,255f/255,125f/255);

        float val = 0;
        while(val<1)
        {
            ComboObject.localScale = Vector3.Lerp(Vector3.zero, new Vector3(1.7f, 1.7f, 1.7f), val);
            val += Time.deltaTime * 9;
            yield return null;
        }
        ComboObject.localScale = new Vector3(1.6f, 1.6f, 1.6f);
    }

    IEnumerator ComboScaleReverce()
    {
        float val = 0;
        while (val < 1)
        {
            ComboObject.localScale = Vector3.Lerp(new Vector3(1.6f, 1.7f, 1.6f), new Vector3(1.6f, 0, 1.6f), val);
            val += Time.deltaTime * 9;
            yield return null;
        }
        ComboObject.localScale = new Vector3(0, 0, 0);
    }
}
