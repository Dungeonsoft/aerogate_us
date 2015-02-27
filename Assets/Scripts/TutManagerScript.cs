using UnityEngine;
using System.Collections;

public class TutManagerScript : MonoBehaviour
{


    public GameObject tutPanel;
    public GameObject centerBlack;
    public GameObject tip;

    public UILabel tipLabelTut;

    public string[] tutText;
    int textNum = 0;

    public AudioClip[] RayChel;

    public GameObject nextBtn;

    bool showBtn =false;

    int soundNumber = 0;

    void Awake()
    {
        if (ValueDeliverScript.isBgSound == false)
        {
            ValueDeliverScript.bgSound = 0f;
            ValueDeliverScript.characterSound = 0f;
            GetComponent<AudioSource>().volume = 0f;
            if (Application.loadedLevel == 1)
            {
                GameObject.Find("CharacterMsgSndCon").GetComponent<AudioSource>().volume = 0f;
            }
            GetComponent<AudioSource>().volume = 0f;
        }
        else
        {
            ValueDeliverScript.bgSound = 0.5f;
            ValueDeliverScript.characterSound = 1f;

            GetComponent<AudioSource>().volume = 1f;

            if (Application.loadedLevel == 1)
            {
                GameObject.Find("CharacterMsgSndCon").GetComponent<AudioSource>().volume = 1f;
            }
            GetComponent<AudioSource>().volume = 1f;
        }

        nextBtn.SetActive(false);
        tutPanel.SetActive(false);
        centerBlack.SetActive(false);
        showBtn = false;



    }


    public void ActivateHanger()
    {
        Debug.Log("튜토말하려 오냐? 번호는? ::: " + textNum);
        tutPanel.SetActive(true);
        showBtn = true;
        float[] empty = new float[] { 0 };
        StartCoroutine(TextAnim(tutText[textNum], empty, 0));

        //tipLabel.text = tutText[textNum];
        PlayRayChelSound(0);

    }

    public void ActivateInGame()
    {
        textNum = 3;
        tutPanel.SetActive(true);
        float[] empty = new float[] { 0 };
        StartCoroutine(TextAnim(tutText[textNum], empty, 0));

        //tipLabel.text = tutText[textNum];

        //StartCoroutine(HiMultiSprite());

        centerBlack.SetActive(true);
        //centerBlack.GetComponent<UITexture>().material.SetColor("_TintColor", new Color(0, 0, 0, 0.3f));
        PlayRayChelSound(textNum);

    }

    public void ActivateResult()
    {
        tipLabelTut.text = "";
        textNum = 10;
        tutPanel.SetActive(true);
        
        PlayRayChelSound(10);

        //StartCoroutine(TextAnim(tutText[textNum],empty, 0));
        StartCoroutine(TipMoveDelay(2));
    }

    IEnumerator TipMoveDelay(float dTime)
    {
        yield return new WaitForSeconds(dTime);
        StartCoroutine(TipMove(-100));
        float[] hiSpriteVal = new float[] { 194, 250, 10, 328, 438, 0f };
        StartCoroutine(TextAnim(tutText[textNum], hiSpriteVal, 0));

    }

    IEnumerator TipMove(int moveY)
    {
        Vector3 tipPosition = tip.transform.localPosition;
        float val = 0;
        while (val < 1)
        {
            tip.transform.localPosition = Vector3.Lerp(tipPosition, tipPosition + new Vector3(0, moveY, 0), val);
            val += Time.deltaTime;
            yield return null;
        }
    }


    bool isNull = true;

    IEnumerator TextAnim(string laychelText, float[] hiSpriteVal, int pMinus)
    {
        //Debug.Log("textNum ::: " + textNum);
        tipLabelTut.text = "";
        char[] text = laychelText.ToCharArray();
        foreach (var textChar in text)
        {
            tipLabelTut.text += textChar;
            if (textChar == '[')
                isNull = false;

            if (textChar == ']')
                isNull = true;

            if(isNull == true)
                yield return null;
            //yield return new WaitForSeconds(0.035f);
        }

        if (textNum == 3)
        {
            //Debug.Log("Into Coroutine !!!!!");
            StartCoroutine(HiMultiSprite());
            
        }

        if (hiSpriteVal.Length != 1)
        {
            HiSingleSprite(hiSpriteVal, pMinus);
        }

        if (showBtn && textNum != 10)
        {
            //Debug.Log("ShowBtn000");
            showBtn = false;
            StartCoroutine(NextBtnScaleAnim());
        }
    }

    IEnumerator NextBtnScaleAnim()
    {
        yield return new WaitForSeconds(0.5f);

        nextBtn.SetActive(true);
        float val = 0;
        while (val < 1)
        {
            nextBtn.transform.localScale = Vector3.Lerp(new Vector3(1, 0, 1), new Vector3(1, 1, 1), val);
            val += Time.deltaTime * 10;
            yield return null;
        }
        nextBtn.transform.localScale = new Vector3(1, 1, 1);
    }


    public void TutNextBtn()
    {

        nextBtn.SetActive(false);
        hiSprite.gameObject.SetActive(false);
        textNum++;
        Debug.Log("textNum ::: " + textNum);
        if (textNum == 1)
        {
            PlayRayChelSound(textNum);

            float[] hiSpriteVal = new float[] { 12, 196, 10, 360, 255, 0 };
            StartCoroutine(TextAnim(tutText[textNum], hiSpriteVal, 0));

            StartCoroutine(TipMove(-75));
            StartCoroutine(FadeBlack());
        }
        else if (textNum == 2)
        {
            PlayRayChelSound(textNum);

            float[] hiSpriteVal = new float[] { 259, -208, 10, 260, 132, 0 };
            StartCoroutine(TextAnim(tutText[textNum], hiSpriteVal, 0));

            StartCoroutine(TipMove(115));

            StartCoroutine(GameObject.Find("GameManager").GetComponent<HangarManager>().GotoEquipWindows());
        }
        else if (textNum == 3)
        {
            //PlayRayChelSound(textNum);

            GameObject.Find("GameManager").GetComponent<FlightSelectBtnScript>().GameStart();
        }
        else if (textNum == 4)
        {
            PlayRayChelSound(textNum);
            
            float[] hiSpriteVal = new float[] { -540, 50, -90, 172, 172, 0 };
            StartCoroutine(TextAnim(tutText[textNum], hiSpriteVal, -1));
        }
        else if (textNum == 5)
        {
            PlayRayChelSound(textNum);

            float[] hiSpriteVal = new float[] { 368, 50, -90, 172, 172, 0 };
            StartCoroutine(TextAnim(tutText[textNum], hiSpriteVal, 1));
        }
        else if (textNum == 6)
        {
            PlayRayChelSound(textNum);

            float[] hiSpriteVal = new float[] { -540, 358, -90, 310, 142, 0 };
            StartCoroutine(TextAnim(tutText[textNum], hiSpriteVal, -1));
        }
        else if (textNum == 7)
        {
            PlayRayChelSound(textNum);

            float[] hiSpriteVal = new float[] { -351, -243, -90, 114, 114, 0 };
            StartCoroutine(TextAnim(tutText[textNum], hiSpriteVal, 0));
        }
        else if (textNum == 8)
        {
            PlayRayChelSound(textNum);

            float[] hiSpriteVal = new float[] { 398, -100, -90, 242, 114, 0 };
            StartCoroutine(TextAnim(tutText[textNum], hiSpriteVal, 0));
        }
        else if (textNum == 9)
        {
            PlayRayChelSound(textNum);

            hiSprite.gameObject.SetActive(false);

            float[] empty = new float[] { 0 };
            showBtn = true;
            StartCoroutine(TextAnim(tutText[textNum], empty, 0));

        }
        else if (textNum == 10)
        {
            audio.Stop();
            centerBlack.SetActive(false);
            GameObject.Find("GameManager").GetComponent<ObjectPoolScript>().TutStart();
            tutPanel.SetActive(false);
        }

        else if (textNum == 11)
        {
            ValueDeliverScript.gameEndResult = false;
            tutPanel.SetActive(false);
            //제일 하단에 들어가는 내용. 위치 바뀌면 안됨.

            if (ValueDeliverScript.isFirstAccess == 0)
            {
                GameObject.Find("GameManager").GetComponent<HangarManager>().FirstAccessOpen();
                ValueDeliverScript.isFirstAccess = 1;
                ValueDeliverScript.SaveGameData();
            }
            else
            {
                PlayerPrefs.SetInt("isTutComplete", 2);
                ValueDeliverScript.isTutComplete = 2;
                Application.LoadLevel("Hangar");
            }
        }

    }

    public IEnumerator TutEnd()
    {
        PlayerPrefs.SetInt("isTutComplete", 2);
        ValueDeliverScript.isTutComplete = 2;
        ValueDeliverScript.gameEndResult = false;
        yield return StartCoroutine(FadeOut());
        Application.LoadLevel("Hangar");
    }

    IEnumerator FadeBlack()
    {
        float alphaValue = 1f;

        while (alphaValue > 0)
        {
            centerBlack.GetComponent<UITexture>().material.SetColor("_TintColor", new Color(0, 0, 0, alphaValue));
            alphaValue -= Time.deltaTime * 2;
            yield return null;
        }
        centerBlack.GetComponent<UITexture>().material.SetColor("_TintColor", new Color(0, 0, 0, 0));
        centerBlack.SetActive(false);
    }

    IEnumerator FadeOut()
    {
        float alphaValue = 0f;

        while (alphaValue < 1)
        {
            centerBlack.GetComponent<UITexture>().material.SetColor("_TintColor", new Color(0, 0, 0, alphaValue));
            alphaValue += Time.deltaTime * 2;
            yield return null;
        }
        centerBlack.GetComponent<UITexture>().material.SetColor("_TintColor", new Color(0, 0, 0, 1));
    }

    void PlayRayChelSound(int soundNum)
    {
        audio.Stop();
        //yield return new WaitForSeconds(1f);
        //Debug.Log("Come here? ::: " + soundNum);
        audio.PlayOneShot(RayChel[soundNum]);
    }

    public Transform hiSprite;


    IEnumerator HiMultiSprite()
    {
        //Debug.Log("HiMultiSprite   :::::::    HiMultiSprite   ::::::");
        int scrX = 0;
        int scrY = 0;
        float scrRatio = 0f;

        scrX = Screen.width;
        scrY = Screen.height;
        scrRatio = (float)scrX / (float)scrY;

        int posX = (-540) - (int)((((720 * scrRatio) - 1080) * 0.5f));

        float[] hiSpriteVal = new float[] { posX, -168, -90, 176, 194, 0};
        StartCoroutine(ShowingHiSprite(hiSpriteVal));

        yield return new WaitForSeconds(1.5f);

        posX = (365) + (int)((((720 * scrRatio) - 1080) * 0.5f));

        hiSpriteVal = new float[] { posX, -168, -90, 176, 194, 0 };

        showBtn = true;
        StartCoroutine(ShowingHiSprite(hiSpriteVal));

    }

    void HiSingleSprite(float[] spriteVal , int pMinus) //-540, 368    50,-90,172,172,1 
    {
        int scrX = 0;
        int scrY = 0;
        float scrRatio = 0f;

        scrX = Screen.width;
        scrY = Screen.height;
        scrRatio = (float)scrX / (float)scrY;

        int posX = (int)spriteVal[0] + (pMinus * (int)((((720 * scrRatio) - 1080) * 0.5f)));

        float[] hiSpriteVal = new float[] { posX, spriteVal[1], spriteVal[2], spriteVal[3], spriteVal[4], spriteVal[5] };
        
        showBtn = true;
        StartCoroutine(ShowingHiSprite(hiSpriteVal));
    }

    IEnumerator ShowingHiSprite(float[] spriteVal)
    {
        hiSprite.gameObject.SetActive(true);
        hiSprite.localScale = new Vector3(0, 0, 0);
        float val = 0;

        float posX = spriteVal[0];
        float posY = spriteVal[1];
        float posZ = spriteVal[2];
        float maxX = spriteVal[3];
        float maxY = spriteVal[4];
        float interTime = spriteVal[5];

        yield return new WaitForSeconds(interTime);

        hiSprite.localPosition = new Vector3(posX, posY, posZ);

        Vector3 minScale = new Vector3(0, 0, 1);
        Vector3 maxScale = new Vector3(maxX, maxY, 1);

        while (val < 1)
        {
            hiSprite.localScale = Vector3.Lerp(minScale, maxScale, val);
            val += 3 * Time.deltaTime;
            yield return null;
        }
        hiSprite.localScale = maxScale;

        if (showBtn)
        {
            //Debug.Log("ShowBtn1111111");
            showBtn = false;
            StartCoroutine(NextBtnScaleAnim());
        }

    }
}
