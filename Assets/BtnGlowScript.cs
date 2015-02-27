using UnityEngine;
using System.Collections;

public class BtnGlowScript : MonoBehaviour {

    public UITexture[] glow;
    public UISprite[] glowBase;

    public bool isAutoStart;
    public bool isAnim;
    

    public float delayTime = 2.5f;
    public float intervalTime = 0.13f;
    public float waitTime = 4f;

    public float blingSpeed = 4.5f;
	// Use this for initialization

    void Awake()
    {
        foreach (var obj in glow)
        {
            obj.alpha = 0f;
        }
        if (isAutoStart) userStart();
    }

	public void userStart () {
        StartCoroutine(GlowAnim());
	}

    IEnumerator GlowAnim()
    {
        if (isAnim == true) yield break;

        isAnim = true;

        yield return new WaitForSeconds(delayTime);

        while (true)
        {
            for (int i = 0; i < glow.Length; i++)
            {
                if (glowBase.Length == 0) StartCoroutine(AlphaAnim(glow[i]));
                else if (glowBase.Length != 0) StartCoroutine(AlphaAnim(glow[i], glowBase[i]));
                yield return new WaitForSeconds(intervalTime);
            }
            yield return new WaitForSeconds(waitTime);
        }

        isAnim = false;

    }

    IEnumerator AlphaAnim(UITexture objGlow , UISprite baseObj = null)
    {
        objGlow.alpha = 0f;
        float addTime = 0f;
        while (addTime < 4f)
        {
            if (baseObj != null && baseObj.spriteName != "Btn_UpgradePlus00")
            {
                objGlow.alpha = 0f;
                yield break; //눌러진 버튼이면 애니 작동 안함//
            }

            objGlow.alpha = Mathf.Sin(addTime);
            //Debug.Log("::: objGlow.alpha ::: " + objGlow.alpha+" :::");
            addTime += Time.deltaTime * blingSpeed;
            yield return null;
        }
    }

}
