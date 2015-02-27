using UnityEngine;
using System.Collections;

public class SelDstnCardWinScript : MonoBehaviour
{
    float hasSecondsTemp = 10;
    float hasSeconds = 10;
    int hasSecondsI;
    bool isIntoShop = false;
    int selCard = 0;
    float rotateY = 0;
    bool isOver90 = false;
    bool isUpdateReturn = false;
    int goldCardNum = 0;
    bool isOneMoreSelected = false;
    bool isYes = false;

    public int changableDia;
    public GameObject centerBlack;
    public GameObject fromCenterBlack;

    public GameObject[] card;
    public GameObject count;
    public GameObject Title;
    public GameObject TitleScript;
    public GameObject ChangeBtn;
    public GameObject YesBtn;

    public GameObject SAttackIcon;
    public GameObject SAttackIconBg;
    public GameObject sAttackIconFx;

    public GameObject BuyDiamondWin;

    public void ChangeHasSeconds(float resetSec=10)
    {
        hasSeconds = hasSecondsTemp = resetSec;
    }

    void Awake()
    {
        hasSecondsTemp = hasSeconds;
    }
    void OnEnable()
    {
        centerBlack.SetActive(true);
        centerBlack.GetComponent<UITexture>().material.SetColor("_TintColor", new Color(0f, 0f, 0f, 0.45f));
    }

    void OnDisable()
    {
        centerBlack.SetActive(false);
    }

    void Update()
    {
        //이부분은 카운트가 나오게 할 것인가 결정하는 부분//
        //자동으로 이루어지는 부분이고 카드가 선택되면 더이상 카운트가 작동하지 않는다//
        //카드 선택 여부는 isCardSel 변수를 true로 바꾸어주면 된다//
        if (isIntoShop == false)
        {
            hasSeconds -= Time.deltaTime;
            if (hasSeconds > 0)
            {
                hasSecondsI = (int)hasSeconds;
                count.GetComponent<UISprite>().spriteName = "Img_StageCount" + hasSecondsI;
                count.GetComponent<UISprite>().MakePixelPerfect();
            }
            else
            {

                if (isOneMoreSelected == true&& isYes == false)
                {
                    isYes = true;
                    Debug.Log("여기올까?");
                    StartCoroutine(YesBtnClick());
                }
                else if(isYes == false)
                {
                    int rndSel = Random.Range(0, 3);
                    switch (rndSel)
                    {
                        case 0: SelCard01(); break;
                        case 1: SelCard02(); break;
                        case 2: SelCard03(); break;
                    }
                }
                //isIntoShop = true;
            }
        }
        //카운트를 담당하는 IF 구문//
    }



    #region 처음에 카드 선택시 작동하는 메소드 SelCard01 SelCard02 SelCard03//
    void SelCard01()
    {
        fromCenterBlack.SetActive(true);

        //isCardSel = true;
        ChangeHasSeconds();
        this.selCard = 1;
        SelCardDis(0);//쓰이지 않는 스크립트들을 꺼준다//
        //선택된 카드를 뒤집는 연출//
        //나머지 두 카드를 뒤집는 연출//
        hasSeconds = hasSecondsTemp;
    }

    void SelCard02()
    {
        fromCenterBlack.SetActive(true);

        //isCardSel = true;
        ChangeHasSeconds();
        this.selCard = 2;
        SelCardDis(1);//쓰이지 않는 스크립트들을 꺼준다//
        //선택된 카드를 뒤집는 연출//
        //나머지 두 카드를 뒤집는 연출//
        hasSeconds = hasSecondsTemp;
    }

    void SelCard03()
    {
        fromCenterBlack.SetActive(true);

        //isCardSel = true;
        ChangeHasSeconds();
        this.selCard = 3;
        SelCardDis(2);//쓰이지 않는 스크립트들을 꺼준다//
        //선택된 카드를 뒤집는 연출//
        //나머지 두 카드를 뒤집는 연출//
        hasSeconds = hasSecondsTemp;
    }


    #endregion

    #region 재선택시 작동하는 메소드 SelCard01Resel SelCard02Resel SelCard03Resel//
    void SelCard01Resel()
    {
        fromCenterBlack.SetActive(true);

        //isCardSel = true;
        ChangeHasSeconds();

        StartCoroutine(CardReselMove(0));
        hasSeconds = hasSecondsTemp;
    }
    void SelCard02Resel()
    {
        fromCenterBlack.SetActive(true);

        //isCardSel = true;
        ChangeHasSeconds();

        StartCoroutine(CardReselMove(1));
        hasSeconds = hasSecondsTemp;
    }
    void SelCard03Resel()
    {
        fromCenterBlack.SetActive(true);

        //isCardSel = true;
        ChangeHasSeconds();

        StartCoroutine(CardReselMove(2));
        hasSeconds = hasSecondsTemp;
    }

    IEnumerator CardReselMove(int cn = 0)
    {
        card[cn].GetComponent<TweenPosition>().from = card[cn].transform.localPosition;
        card[cn].GetComponent<TweenPosition>().to = new Vector3(0, card[cn].transform.localPosition.y, card[0].transform.localPosition.z);
        card[cn].GetComponent<TweenPosition>().method = UITweener.Method.BounceIn;
        card[cn].GetComponent<TweenPosition>().style = UITweener.Style.Loop;
        card[cn].GetComponent<TweenPosition>().duration = 0.4f;
        card[cn].GetComponent<TweenPosition>().enabled = true;
        yield return null;
        card[cn].GetComponent<TweenPosition>().style = TweenPosition.Style.Once;

        for (int i = 0; i < card.Length; i++)
        {
            if (i != cn && i != (selCard - 1))
            {
                card[i].GetComponent<TweenScale>().from = Vector3.one;
                card[i].GetComponent<TweenScale>().to = Vector3.zero;
                card[i].GetComponent<TweenScale>().method = UITweener.Method.BounceOut;
                card[i].GetComponent<TweenScale>().style = UITweener.Style.Loop;
                card[i].GetComponent<TweenScale>().duration = 0.4f;
                card[i].GetComponent<TweenScale>().enabled = true;
                yield return null;
                card[i].GetComponent<TweenScale>().style = UITweener.Style.Once;
            }
        }

        //최종 선택된 카드 넘버 기록//
        selCard = cn + 1;
        ValueDeliverScript.destinyCardNumber = card[cn].GetComponent<DestinyCardPropScript>().itemNumber;
        fromCenterBlack.SetActive(true);

        StartCoroutine(ChangeCardTitle());
        //YesBtn.GetComponent<TweenPosition>().enabled = true;
        YesBtn.SetActive(true);
        YesBtn.transform.localPosition = new Vector3(0, -273, 0);
        YesBtn.GetComponent<TweenScale>().from = Vector3.zero;
        YesBtn.GetComponent<TweenScale>().to = Vector3.one;
        YesBtn.GetComponent<TweenScale>().method = UITweener.Method.BounceOut;
        YesBtn.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        YesBtn.GetComponent<TweenScale>().duration = 0.4f;
        YesBtn.GetComponent<TweenScale>().enabled = true;
        yield return null;
        YesBtn.GetComponent<TweenScale>().style = UITweener.Style.Once;

        fromCenterBlack.SetActive(false);
    }
    #endregion

    IEnumerator ChangeCardTitle()
    {
        //여기서 카드가 선택되고 난후 타이틀이 선택되었다는 내용으로 바뀌는 것을 한다.//
        if (Title.GetComponent<TweenScale>() == null) 
            Title.AddComponent<TweenScale>();

        Title.GetComponent<TweenScale>().from = Vector3.one;
        Title.GetComponent<TweenScale>().to = Vector3.zero;
        Title.GetComponent<TweenScale>().method = UITweener.Method.BounceOut;
        Title.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        Title.GetComponent<TweenScale>().duration = 0.4f;
        Title.GetComponent<TweenScale>().eventReceiver = this.gameObject;
        Title.GetComponent<TweenScale>().callWhenFinished = "ChangeTitleTxt";
        Title.GetComponent<TweenScale>().enabled = true;
        yield return null;
        Title.GetComponent<TweenScale>().style = UITweener.Style.Once;
        //여기서 카드가 선택되고 난후 타이틀이 선택되었다는 내용으로 바뀌는 것을 한다.//
    }

    IEnumerator ChangeTitleTxt()
    {
        Title.GetComponent<TweenScale>().enabled = false;
        yield return null;
        Title.GetComponent<TweenScale>().enabled = true;
        Debug.Log("ChangeTitleTxt 들어옴");
        //우선 어떤 라벨이 지정되어 있는가 확인후 반대가 되는 것으로 라벨 이미지를 바꾼다//
        string label = Title.transform.GetChild(0).GetComponent<UISprite>().spriteName;
        if (label == "Txt_Choose")
            Title.transform.GetChild(0).GetComponent<UISprite>().spriteName = "Txt_Selected";
        else
            Title.transform.GetChild(0).GetComponent<UISprite>().spriteName = "Txt_Choose";
        Title.transform.GetChild(0).GetComponent<UISprite>().MakePixelPerfect();
        Title.GetComponent<TweenScale>().from = Vector3.zero;
        Title.GetComponent<TweenScale>().to = Vector3.one;
        Title.GetComponent<TweenScale>().method = UITweener.Method.BounceIn;
        Title.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        Title.GetComponent<TweenScale>().duration = 0.4f;
        Title.GetComponent<TweenScale>().eventReceiver = null;
        Title.GetComponent<TweenScale>().callWhenFinished = "";
        Title.GetComponent<TweenScale>().enabled = true;
        Debug.Log("enabled :: " + Title.GetComponent<TweenScale>().enabled);
        yield return null;
        Title.GetComponent<TweenScale>().style = UITweener.Style.Once;
    }


    //1.카드를 선택하면 먼저 더 이상 쓰리지 않을 스크립트들을 꺼준다//
    void SelCardDis(int cNum)
    {
        ValueDeliverScript.destinyCardNumber = card[cNum].GetComponent<DestinyCardPropScript>().itemNumber;

        card[cNum].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        card[cNum].GetComponent<UIButtonScale>().enabled = false;
        card[cNum].collider.enabled = false;
        StartCoroutine(FirstOpen(cNum));
        StartCoroutine(ChangeCardTitle());
        Debug.Log("카드 셀렉은 옴?");
        Debug.Log("isOneMoreSelected = " + isOneMoreSelected);
        isOneMoreSelected = true;
        Debug.Log("isOneMoreSelected = " + isOneMoreSelected);
    }

    IEnumerator FirstOpen(int cNum = 0)
    {
        yield return StartCoroutine(cardFlipCon(cNum, true));
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < card.Length; i++)
        {
            if (i != cNum)
            {
                card[i].GetComponent<UIButtonScale>().enabled = false;
                card[i].collider.enabled = false;
                StartCoroutine(PanelAlpha(i));
                yield return StartCoroutine(cardFlipCon(i, false));
            }
        }
        TitleScript.GetComponent<UILabel>().text = "It is allowed to change the Selected Card using Diamonds";
        ChangeBtn.GetComponent<TweenScale>().enabled = true;
        YesBtn.GetComponent<TweenScale>().enabled = true;
        fromCenterBlack.SetActive(false);
    }

    //2.선택한 카드를 보여주는 애니메이션을 만든다//
    IEnumerator cardFlipCon(int cNum, bool isBigSize = false)
    {
        int[] ry = new int[] { 450, 900 };
        if (isBigSize == false)
        {
            ry = new int[] { 270, 540 };
        }
        //우선은 돌린다. 450도까지//
        while (rotateY < ry[0])
        {
            card[cNum].transform.eulerAngles = new Vector3(0, rotateY, 0);
            rotateY += Time.deltaTime * 1350;
            yield return null;
        }
        //우선은 돌린다. 450도까지//



        //골드 카드인지 여부를 확인한다//
        string cardName = "";
        bool isGold = card[cNum].GetComponent<DestinyCardPropScript>().isGold;
        if (isGold == true)
        {
            cardName = "Bgr_Destiny_03";
        }
        else
        {
            cardName = "Bgr_Destiny_02";
        }
        card[cNum].transform.GetChild(0).GetComponent<UISprite>().spriteName = cardName;
        //골드 카드인지 여부를 확인한다//


        //카드 종류를 확인했으니 운명카드 적용아이콘과 보너스퍼센트를 켜준다//
        for (int i = 0; i < card[cNum].transform.childCount; i++)
        {
            card[cNum].transform.GetChild(i).gameObject.SetActive(true);
        }
        //카드 종류를 확인했으니 운명카드 적용아이콘과 보너스퍼센트를 켜준다//


        //900도까지 돌린다//
        while (rotateY < ry[1])
        {
            card[cNum].transform.eulerAngles = new Vector3(0, rotateY, 0);
            rotateY += Time.deltaTime * 1350;
            yield return null;
        }

        card[cNum].transform.eulerAngles = new Vector3(0, 0, 0);
        rotateY = 0;

        if (isBigSize == true)
        {
            float baseValue = 1;
            while (true)
            {
                if (baseValue >= 1.2f)
                {
                    card[cNum].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                    yield break;
                }

                card[cNum].transform.localScale = new Vector3(baseValue, baseValue, baseValue);
                baseValue += Time.deltaTime * 4;
                yield return null;
            }
        }
    }

    IEnumerator PanelAlpha(int cNum)
    {
        float aValue = 1;
        while (aValue > 0.4f)
        {
            aValue -= Time.deltaTime;
            card[cNum].GetComponent<UIPanel>().alpha = aValue;
            yield return null;
        }
    }

    IEnumerator PanelAlphaReverse(int cNum)
    {
        float aValue = 0.4f;
        while (aValue < 1f)
        {
            aValue += Time.deltaTime;
            card[cNum].GetComponent<UIPanel>().alpha = aValue;
            yield return null;
        }
    }

    void ReSelReady()
    {
        //재선택을 눌렀을때 기존 선택 카드는 회색이나 제거처리를 하고// 
        //나머지 두카드를 선택할 수 있도록 부각하는 연출//
    }

    void ChangeCard()
    {
        fromCenterBlack.SetActive(true);

        //테스트 코드//
        //StartCoroutine(EnoughDia()); StartCoroutine(ChangeCardTitle()); hasSeconds = hasSecondsTemp; return;

        if (ValueDeliverScript.medalRest >= changableDia)
        {
            Debug.Log("1");
            //다이아몬드가 충분할때
            StartCoroutine(EnoughDia());

            //상단 타이틀 바뀌는 메소드 호출한다//
            StartCoroutine(ChangeCardTitle());
            hasSeconds = hasSecondsTemp;
        }
        else
        {
            Debug.Log("2");
            //다이아몬드가 모자랄때
            StartCoroutine(NotEnoughDia());
            isIntoShop = true;
            //hasSeconds = hasSecondsTemp;
        }
    }

    //다이아를 이용해서 카드 뽑기를 다시 할경우 다이아가 충분할때///
    IEnumerator EnoughDia()
    {
        fromCenterBlack.SetActive(true);
        ChangeBtn.GetComponent<TweenScale>().from = Vector3.one;
        ChangeBtn.GetComponent<TweenScale>().to = Vector3.zero;
        ChangeBtn.GetComponent<TweenScale>().method = UITweener.Method.BounceOut;
        ChangeBtn.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        ChangeBtn.GetComponent<TweenScale>().enabled = true;

        YesBtn.GetComponent<TweenScale>().from = Vector3.one;
        YesBtn.GetComponent<TweenScale>().to = Vector3.zero;
        YesBtn.GetComponent<TweenScale>().method = UITweener.Method.BounceOut;
        YesBtn.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        YesBtn.GetComponent<TweenScale>().enabled = true;
        yield return null;

        //기존에 선택되었던 카드를 사라지게 한다//
        CardDisapear(selCard);

        ChangeBtn.GetComponent<TweenScale>().style = UITweener.Style.Once;
        YesBtn.GetComponent<TweenScale>().style = UITweener.Style.Once;
        yield return new WaitForSeconds(0.3f);
        //YesBtn.GetComponent<TweenPosition>().enabled = true;
        //yield return new WaitForSeconds(0.5f);
        fromCenterBlack.SetActive(false);
    }

    //지정한 카드를 스케일을 이용하여 조그맣게 만들어 사라지게 한다//
    void CardDisapear(int cardNum = 0)
    {
        Debug.Log("카드 스케일하러 옴?01");
        Debug.Log("SelCard01 Number :: " + cardNum);
        Vector3 firstScale = card[cardNum - 1].transform.localScale;

        if (card[cardNum - 1].GetComponent<TweenScale>() == null) card[cardNum - 1].AddComponent<TweenScale>();
        card[cardNum - 1].GetComponent<TweenScale>().from = firstScale;
        card[cardNum - 1].GetComponent<TweenScale>().to = Vector3.zero;
        card[cardNum - 1].GetComponent<TweenScale>().method = UITweener.Method.BounceOut;
        card[cardNum - 1].GetComponent<TweenScale>().style = UITweener.Style.Loop;
        card[cardNum - 1].GetComponent<TweenScale>().duration = 0.5f;
        card[cardNum - 1].GetComponent<TweenScale>().enabled = true;
        card[cardNum - 1].GetComponent<TweenScale>().style = UITweener.Style.Once;
        Debug.Log("카드 스케일하러 옴?02");

        if (cardNum == selCard)
        {
            Debug.Log("카드 재정리 함");
            card[cardNum - 1].GetComponent<TweenScale>().eventReceiver = this.gameObject;
            card[cardNum - 1].GetComponent<TweenScale>().callWhenFinished = "cardRearrange";
        }
        else
        {
            card[cardNum - 1].GetComponent<TweenScale>().eventReceiver = null;
            card[cardNum - 1].GetComponent<TweenScale>().callWhenFinished = "";
        }
    }

    //다시 뽑기를 해서 기 선택된 카드는 사라지고 남은 두개의 카드를 정리하는 메소드//
    void cardRearrange()
    {
        int xPos = -170;
        for (int i = 0; i < card.Length; i++)
        {
            if (i != (selCard - 1))
            {
                if (card[i].GetComponent<TweenPosition>() == null) card[i].AddComponent<TweenPosition>();

                card[i].GetComponent<TweenPosition>().from = card[i].transform.localPosition;
                card[i].GetComponent<TweenPosition>().to = new Vector3(xPos, card[i].transform.localPosition.y, card[i].transform.localPosition.z);
                card[i].GetComponent<TweenPosition>().method = UITweener.Method.BounceIn;
                card[i].GetComponent<TweenPosition>().style = UITweener.Style.Loop;
                card[i].GetComponent<TweenPosition>().duration = 0.4f;
                card[i].GetComponent<TweenPosition>().enabled = true;
                card[i].collider.enabled = true;
                card[i].GetComponent<UIButtonMessage>().functionName = "SelCard0" + (i + 1) + "Resel";
                card[i].GetComponent<TweenPosition>().style = UITweener.Style.Once;

                StartCoroutine(PanelAlphaReverse(i));

                xPos = xPos * -1;
            }
        }
    }


    IEnumerator NotEnoughDia()
    {
        if (this.GetComponent<TweenScale>() == null)
        {
            this.gameObject.AddComponent<TweenScale>();
        }
        this.GetComponent<TweenScale>().from = Vector3.one;
        this.GetComponent<TweenScale>().to = Vector3.zero;
        this.GetComponent<TweenScale>().method = UITweener.Method.BounceOut;
        this.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        this.GetComponent<TweenScale>().duration = 0.4f;
        this.GetComponent<TweenScale>().enabled = true;
        yield return null;
        this.GetComponent<TweenScale>().style = UITweener.Style.Once;

        yield return new WaitForSeconds(0.4f);

        if (BuyDiamondWin.GetComponent<TweenScale>() == null)
        {
            BuyDiamondWin.AddComponent<TweenScale>();
        }
        BuyDiamondWin.GetComponent<TweenScale>().from = Vector3.zero;
        BuyDiamondWin.GetComponent<TweenScale>().to = Vector3.one;
        BuyDiamondWin.GetComponent<TweenScale>().method = UITweener.Method.BounceIn;
        BuyDiamondWin.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        BuyDiamondWin.GetComponent<TweenScale>().duration = 0.4f;
        BuyDiamondWin.GetComponent<TweenScale>().enabled = true;
        yield return null;
        BuyDiamondWin.GetComponent<TweenScale>().style = UITweener.Style.Once;

        yield return new WaitForSeconds(0.4f);
        fromCenterBlack.SetActive(false);

    }

    IEnumerator BuyDiamondWinClose()
    {
        fromCenterBlack.SetActive(true);

        isIntoShop = false;
        if (BuyDiamondWin.GetComponent<TweenScale>() == null)
        {
            BuyDiamondWin.AddComponent<TweenScale>();
        }
        BuyDiamondWin.GetComponent<TweenScale>().from = Vector3.one;
        BuyDiamondWin.GetComponent<TweenScale>().to = Vector3.zero;
        BuyDiamondWin.GetComponent<TweenScale>().method = UITweener.Method.BounceOut;
        BuyDiamondWin.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        BuyDiamondWin.GetComponent<TweenScale>().duration = 0.4f;
        BuyDiamondWin.GetComponent<TweenScale>().enabled = true;
        yield return null;
        BuyDiamondWin.GetComponent<TweenScale>().style = UITweener.Style.Once;

        
        yield return new WaitForSeconds(0.4f);
        
        if (this.GetComponent<TweenScale>() == null)
        {
            this.gameObject.AddComponent<TweenScale>();
        }
        this.GetComponent<TweenScale>().from = Vector3.zero;
        this.GetComponent<TweenScale>().to = Vector3.one;
        this.GetComponent<TweenScale>().method = UITweener.Method.BounceIn;
        this.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        this.GetComponent<TweenScale>().duration = 0.4f;
        this.GetComponent<TweenScale>().enabled = true;
        yield return null;
        this.GetComponent<TweenScale>().style = UITweener.Style.Once;

        yield return new WaitForSeconds(0.4f);
        fromCenterBlack.SetActive(false);
    }



    IEnumerator BtnMoveCenter()
    {
        yield return null;
    }

    IEnumerator YesBtnClick()
    {
        fromCenterBlack.SetActive(true);

        if (this.GetComponent<TweenScale>() == null)
        {
            this.gameObject.AddComponent<TweenScale>();
        }
        this.GetComponent<TweenScale>().from = Vector3.one;
        this.GetComponent<TweenScale>().to = Vector3.zero;
        this.GetComponent<TweenScale>().method = UITweener.Method.BounceOut;
        this.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        this.GetComponent<TweenScale>().duration = 0.4f;

        this.GetComponent<TweenScale>().eventReceiver = this.gameObject;
        this.GetComponent<TweenScale>().callWhenFinished = "CenterBlackHideNIconShow";

        this.GetComponent<TweenScale>().enabled = true;
        yield return null;
        this.GetComponent<TweenScale>().style = UITweener.Style.Once;
        //yield return new WaitForSeconds(0.4f);

    }

    IEnumerator CenterBlackHideNIconShow()
    {
        float cAlpha = centerBlack.GetComponent<UITexture>().material.GetColor("_TintColor").a;

        while (cAlpha > 0)
        {
            centerBlack.GetComponent<UITexture>().material.SetColor("_TintColor", new Color(0f, 0f, 0f, cAlpha));
            yield return null;
            cAlpha -= Time.deltaTime;
        }
        centerBlack.SetActive(false);

        //화면 좌상단에 아이콘 표시나게 스케일링//
        SAttackIcon.SetActive(true);
        SAttackIconBg.SetActive(true);

        SAttackIcon.GetComponent<UISprite>().spriteName = SpAttackIcon();
        SAttackIcon.GetComponent<UISprite>().MakePixelPerfect();

        if (SAttackIcon.GetComponent<TweenScale>() == null)
        {
            SAttackIcon.AddComponent<TweenScale>();
        }
        SAttackIcon.GetComponent<TweenScale>().from = SAttackIcon.transform.localScale * 2;
        SAttackIcon.GetComponent<TweenScale>().to = SAttackIcon.transform.localScale;
        SAttackIcon.GetComponent<TweenScale>().method = UITweener.Method.BounceOut;
        SAttackIcon.GetComponent<TweenScale>().style = UITweener.Style.Loop;
        SAttackIcon.GetComponent<TweenScale>().duration = 0.5f;
        SAttackIcon.GetComponent<TweenScale>().eventReceiver = GameObject.Find("GameManager");
        SAttackIcon.GetComponent<TweenScale>().callWhenFinished = "RealStart";
        SAttackIcon.GetComponent<TweenScale>().enabled = true;
        yield return null;
        SAttackIcon.GetComponent<TweenScale>().style = UITweener.Style.Once;

        sAttackIconFx.SetActive(true);
        fromCenterBlack.SetActive(false);
        this.gameObject.SetActive(false);

    }

    string SpAttackIcon()
    {
        string iconName = "";
        int itemNumber = card[selCard - 1].GetComponent<DestinyCardPropScript>().itemNumber;
        switch (itemNumber)
        {
            case 0:
            case 1:
            case 2:
                iconName = "Icn_DestinySmall_01";
                break;
          
            case 3:
            case 4:
            case 5:
            case 12:
            case 15:
             iconName = "Icn_DestinySmall_02";
                break;
         
            case 6:
            case 7:
            case 8:
            case 13:
            case 16:
                iconName = "Icn_DestinySmall_03";
                break;

            case 9:
            case 10:
            case 11:
            case 14:
            case 17:
                iconName = "Icn_DestinySmall_04";
                break;
        }
        Debug.Log("ValueDeliverScript.destinyCardNumber :: " + ValueDeliverScript.destinyCardNumber);
        Debug.Log("iconName :: " + itemNumber + " :: " + iconName);
        return iconName;
    }
}