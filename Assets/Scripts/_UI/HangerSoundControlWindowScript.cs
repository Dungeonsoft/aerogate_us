using UnityEngine;
using System.Collections;

public class HangerSoundControlWindowScript : MonoBehaviour {

    public UISlicedSprite bgBtn;
    public UISlicedSprite fxBtn;
    public UISlicedSprite arlBtn;

    public UILabel Uid;
    public UILabel ver;
    

    public GameObject halfBLKPanel;
    public GameObject TutStartWin;
    public GameObject eventWin;
    public GameObject backOutWin;
    public GameObject logOutWin;

    bool gameEndResult;

    void Awake()
    {
        gameEndResult = ValueDeliverScript.gameEndResult;
    }

    void Start()
    {
        //userId = KakaoGameUserInfo.Instance.user_id;

        Uid.text = ValueDeliverScript.UserID;
        ver.text = ValueDeliverScript.ver;
    }

    void OnEnable()
    {
        //Debug.Log("message_blocked  ::: " + KakaoGameUserInfo.Instance.message_blocked);
        //ValueDeliverScript.isArlamMessage = KakaoGameUserInfo.Instance.message_blocked;

        if (ValueDeliverScript.isBgSound)
            bgBtn.spriteName = "Btn_RadioOn";
        else
            bgBtn.spriteName = "Btn_RadioOff";

        if (ValueDeliverScript.isFxSound)
            fxBtn.spriteName = "Btn_RadioOn";
        else
            fxBtn.spriteName = "Btn_RadioOff";

        //if (ValueDeliverScript.isArlamMessage)
        //    arlBtn.spriteName = "Btn_RadioOff";
        //else
        //    arlBtn.spriteName = "Btn_RadioOn";
    }


    void ChangeBgSound()
    {
        if (ValueDeliverScript.isBgSound == false)
        {
            ValueDeliverScript.bgSound = 0.5f;
            ValueDeliverScript.characterSound = 1f;

            if (gameEndResult)
            {
                GameObject.Find("ResultSoundManager").GetComponent<AudioSource>().volume = 1f;
                GameObject.Find("BgSoundManager").GetComponent<AudioSource>().volume = 0f;
                GameObject.Find("ResultSoundManager").GetComponent<AudioSource>().Play();
            }
            else
            {
                Debug.Log("배경소리켬!!!");
                GameObject.Find("ResultSoundManager").GetComponent<AudioSource>().volume = 0f;
                GameObject.Find("BgSoundManager").GetComponent<AudioSource>().volume = 1f;
                GameObject.Find("BgSoundManager").GetComponent<AudioSource>().Play();
            }
            GameObject.Find("CharacterMsgSndCon").GetComponent<AudioSource>().volume = 1f;

            ValueDeliverScript.isBgSound = true;
            bgBtn.spriteName = "Btn_RadioOn";
        }

        else
        {
            ValueDeliverScript.bgSound = 0f;
            ValueDeliverScript.characterSound = 0f;

            if (gameEndResult)
            {
                GameObject.Find("ResultSoundManager").GetComponent<AudioSource>().volume = 0f;
                GameObject.Find("BgSoundManager").GetComponent<AudioSource>().volume = 0f;
            }
            else
            {
                GameObject.Find("ResultSoundManager").GetComponent<AudioSource>().volume = 0f;
                GameObject.Find("BgSoundManager").GetComponent<AudioSource>().volume = 0f;
            }
            GameObject.Find("CharacterMsgSndCon").GetComponent<AudioSource>().volume = 0f;

            ValueDeliverScript.isBgSound = false;
            bgBtn.spriteName = "Btn_RadioOff";
        }
    }



    void ChangeFxSound()
    {
        if (ValueDeliverScript.isFxSound == false)
        {
            ValueDeliverScript.fxSound = 0.5f;
            ValueDeliverScript.characterSound = 1f;

            ValueDeliverScript.isFxSound = true;
            fxBtn.spriteName = "Btn_RadioOn";
        }
        else
        {
            ValueDeliverScript.fxSound = 0f;
            ValueDeliverScript.characterSound = 0f;

            ValueDeliverScript.isFxSound = false;
            fxBtn.spriteName = "Btn_RadioOff";
        }
    }

    void ChangeArlamMessage()
    {
        if (ValueDeliverScript.isArlamMessage == false)
        {
            ValueDeliverScript.isArlamMessage = true;
            arlBtn.spriteName = "Btn_RadioOff";
        }
        else
        {
            ValueDeliverScript.isArlamMessage = false;
            arlBtn.spriteName = "Btn_RadioOn";
        }
        //ForKakao.instance.MyBlockMessage();
    }





    void GotoTutStartWin()
    {
        halfBLKPanel.SetActive(true);
        TutStartWin.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, TutStartWin.transform.localPosition.z + 5);
    }

    void TutStartWinYes()
    {
        TutStartWin.SetActive(false);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, gameObject.transform.localPosition.z + 5);

        PlayerPrefs.SetInt("isTutComplete", 0);
        ValueDeliverScript.isTutComplete = 0;
        //튜토리얼 시작하는 코드 작성.
        StartCoroutine(TutStart());
    }

    IEnumerator TutStart()
    {
        GameObject.Find("Anchor").transform .FindChild("NoTouchPanel").gameObject.SetActive(true);
        GameObject cBlk = GameObject.Find("BlackBezel").transform.FindChild("CenterBack").gameObject;

        cBlk.SetActive(true);

        float alphaValue = 0f;

        while (alphaValue < 1)
        {
            cBlk.GetComponent<UITexture>().material.SetColor("_TintColor", new Color(0, 0, 0, alphaValue));
            alphaValue += Time.deltaTime * 2;
            yield return null;
        }

        Application.LoadLevel("Hangar");

    }

    void TutStartWinNo()
    {
        TutStartWin.SetActive(false);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, gameObject.transform.localPosition.z + 5);
    }






    void GotoEventWin()
    {
        halfBLKPanel.SetActive(true);
        eventWin.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, eventWin.transform.localPosition.z + 5);
    }

    void eventWinYes()
    {
        eventWin.SetActive(false);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, gameObject.transform.localPosition.z + 5);
        //이벤트를 적용하는 코드를 작성.
    }

    void eventWinNo()
    {
        eventWin.SetActive(false);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, gameObject.transform.localPosition.z + 5);
    }






    void SendMail()
    {
        string mailSubject = WWW.EscapeURL("메이데이 문의 메일").Replace("+", "%20");
        string mailBody = WWW.EscapeURL("메이데이 문의 메일").Replace("+", "%20");
        //Debug.Log("내 카카오 아이디 :: " + userId);
        Application.OpenURL("mailto:ernham1@gmail.com?subject=" + mailSubject + "&body=" + mailBody);
    }







    void GotoBackOutWin()
    {
        halfBLKPanel.SetActive(true);
        backOutWin.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, backOutWin.transform.localPosition.z + 5);
    }

    public GameObject backOut2Win;
    void BackOutWinYes()
    {
        Debug.Log("BackOutWinYes01");
        backOut2Win.SetActive(true);
        Debug.Log("BackOutWinYes02");
        backOutWin.SetActive(false);
        Debug.Log("BackOutWinYes03");
        //halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, gameObject.transform.localPosition.z + 5);
        //게임 탈퇴하는 코드 호출. 첫화면으로 이동. 약관 동의 띄움.
        StartCoroutine(BackOutWinYes2());
    }

    IEnumerator BackOutWinYes2()
    {
        //PlayerPrefs.DeleteKey("GameData");
        //초기화 코드 입력.
        //ValueDeliverScript.isFlightSkinExpLoad = false;
        //ValueDeliverScript.isFlightSkinLevelLoad = false;
        //ValueDeliverScript.isFlightDuraLevelLoad = false;
        //ValueDeliverScript.isMyEquipload = false;
        //ValueDeliverScript.isDuraCostLoad = false;
        //ValueDeliverScript.isSkinLockOffLoad = false;
        //ValueDeliverScript.isSkinMedalCostLoad = false;
        //ValueDeliverScript.isGoldPriceLoad = false;
        //ValueDeliverScript.isGasPriceLoad = false;
        //ValueDeliverScript.isMedalPriceLoad = false;
        //ValueDeliverScript.isOperaterLockOff = false;
        //ValueDeliverScript.isFlightLockOff = false;

        //ValueDeliverScript.flightSkinExp.Clear();
        //ValueDeliverScript.flightSkinLevel.Clear();
        //ValueDeliverScript.flightSkinDura.Clear();
        //ValueDeliverScript.myEquip.Clear();
        //ValueDeliverScript.duraCost.Clear();
        //ValueDeliverScript.skinLockOff.Clear();
        //ValueDeliverScript.skinMedalCost.Clear();
        //ValueDeliverScript.goldPrice.Clear();
        //ValueDeliverScript.gasPrice.Clear();
        //ValueDeliverScript.medalPrice.Clear();
        //ValueDeliverScript.operaterLockOff.Clear();
        //ValueDeliverScript.flightLockOff.Clear();
        //초기화 코드 입력.

        yield return null;

        //yield return StartCoroutine(GetComponent<DelUserInfo>().DeleteID());
        PlayerPrefs.DeleteAll(); // .DeleteKey("isTutComplete");

        Debug.Log("BackOutWinYes04");
        //ForKakao.instance.Unregister();
        Debug.Log("BackOutWinYes05");
    }

    void BackOutWinNo()
    {
        backOutWin.SetActive(false);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, gameObject.transform.localPosition.z + 5);
    }







    void GotoLogOut()
    {
        halfBLKPanel.SetActive(true);
        logOutWin.SetActive(true);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, logOutWin.transform.localPosition.z + 5);
    }

    void LogOutYes()
    {
        //logOutWin.SetActive(false);
        //halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, gameObject.transform.localPosition.z + 5);
        //로그아웃 후 첫 화면으로 이동. 약관 동의. 띄움.
        //PlayerPrefs.SetInt("UserUnique", 0);
        //PlayerPrefs.DeleteKey("UserUnique");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("isTutComplete", 2);
		//Debug.Log ("For Kakao : " + ForKakao.instance );
        //ForKakao.instance.Logout();
    }

    void LogOutNo()
    {
        logOutWin.SetActive(false);
        halfBLKPanel.transform.localPosition = new Vector3(halfBLKPanel.transform.localPosition.x, halfBLKPanel.transform.localPosition.y, gameObject.transform.localPosition.z + 5);
    }
}
