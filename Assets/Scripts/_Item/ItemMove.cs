using UnityEngine;
using System.Collections;

public class ItemMove : MonoBehaviour
{
    #region Variable
    float xPosition;
    float nowTime;
    public int addCoin = 1;
    public int addPower = 1;
    public bool isLineMove = false; //단순 직선 패턴일지 아님 포물선 패턴일지 결정. true면 직선운동.
    public int lineMoveSpeed = 5;
    public int powerUpBulletAddGage = 1;
    public int addGage = 500;


    public GameObject[] childObject;
    int randomX;
    int randomY;

    GameObject gameManager;
    GameObject pcFlight;
    GameObject pc;

    public int overItemBonusScore = 1000;

    public float mRadius = 20f;
    public float mTime = 3f;
    float magnetStartTime;
    bool isMagnet = false;
    bool isMagnetStartTime = false;

    GameObject runeObj;
    uiObjectPool addScoreLabeluiObjectPool;

    SoundUiControlScript soundUiControlScript;
    BulletControlScript bulletControlScript;
    InstanceMissionScript instanceMissionScript;
    BombSkillGageScript bombSkillGageScript;
    UIFilledSprite bombButton01UIFilledSprite;
    MagnetScript magnetScript;
    RuneAlphaAni runeAlphaAni;
    ScoreCoinCount scoreCoinCount;
    PlayerMoveScript playerMoveScript;

    CharacterSpeakManagerScript characterSpeakManager;
    AddedChSpeakScript addedChSpeakScript;
    //string[] itemGetScript;

    GameObject characterMessageUI;


    GameObject bombButton;
    GameObject skillButton;

    GameObject bulletLevelGage;
    GameObject fuelImageTF;

    Vector3 scale0;
    Vector3 scale1;

    GameObject PC;
    #endregion

    void Awake()
    {
        characterMessageUI = GameObject.Find("CharacterMessageUI");

        scale0 = new Vector3(0, 0, 0);
        scale1 = new Vector3(1, 1, 1);

        PC = GameObject.Find("PC");
    }

    void Start()
    {
        bombButton = GameObject.Find("BombButton");
        skillButton = GameObject.Find("SkillButton");
        gameManager = GameObject.Find("GameManager");
        bulletLevelGage = GameObject.Find("BulletLevelGage");
        fuelImageTF = GameObject.Find("FuelImageTF");


        //itemGetScript = gameManager.GetComponent<ObjectPoolScript>().itemGetScript;

        if (gameManager.transform.FindChild("PC/Flight").gameObject)
        {
            pcFlight = gameManager.transform.FindChild("PC/Flight").gameObject;
        }
        pc = gameManager.transform.FindChild("PC").gameObject;
        addScoreLabeluiObjectPool = GameObject.Find("AddScoreLabel").GetComponent<uiObjectPool>();
        runeObj = GameObject.Find("GameManager").transform.FindChild("Rune").gameObject;

        soundUiControlScript = gameManager.GetComponent<SoundUiControlScript>();
        bulletControlScript = gameManager.GetComponent<BulletControlScript>();
        instanceMissionScript = gameManager.GetComponent<InstanceMissionScript>();
        bombSkillGageScript = gameManager.GetComponent<BombSkillGageScript>();
        bombButton01UIFilledSprite = GameObject.Find("BombButton01").GetComponent<UIFilledSprite>();
        magnetScript = gameManager.GetComponent<MagnetScript>();
        runeAlphaAni = runeObj.GetComponent<RuneAlphaAni>();
        scoreCoinCount = gameManager.GetComponent<ScoreCoinCount>();
        playerMoveScript = gameManager.transform.FindChild("PC").gameObject.GetComponent<PlayerMoveScript>();

        characterSpeakManager = GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>();
        addedChSpeakScript = GameObject.Find("CharacterSpeakManager").GetComponent<AddedChSpeakScript>();
    }


    float lerpValue = 0;
    void Update()
    {
        if (isMagnet && pcFlight)
        {
            lerpValue += (Time.deltaTime * 10f) / itemPcDis;
            transform.position = Vector3.Lerp(transform.position, pcFlight.transform.position, lerpValue);
            transform.localScale = Vector3.Lerp(scale1, scale0, lerpValue);
            if (lerpValue >= 1) GetItem();
        }
        else
        {
            if (isLineMove)
            { // 단순 한축 이동 여부 결정.
                transform.Translate(0, 0, -Time.deltaTime * lineMoveSpeed);
            }
            else
            {
                int isPlusMinus = 1;
                if (xPosition > 0)
                {
                    isPlusMinus = -1;
                }
                transform.Translate(0.5f * (randomX * Time.deltaTime * isPlusMinus), 0, 0.5f * (randomY * Time.deltaTime - (Time.timeSinceLevelLoad - nowTime) * Time.deltaTime * randomY));
            }

            if (transform.position.z < -5)
            { // 일정위치 이하로 내려가면 death.
                gameObject.SetActive(false);
            }
        }

    }


    float itemPcDis = 0;
    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("pcFlight ::: " + pcFlight.name + " ::: isPcExplo ::: " + ValueDeliverScript.isPcExplo + " ::: Flignt Tag ::: " + col.tag);
        //전투기가 존재하지 않거나//이미슈퍼파워상태거나//전투기가 파괴되었거나// 함수를 실행하지 않는다//
        if (pcFlight == null || /* isAlreadyIn == true || */ ValueDeliverScript.isPcExplo == true)
            return;

        if (col.gameObject.tag == "Magnet")
        {

            if (!isMagnetStartTime)
            {
                magnetStartTime = Time.timeSinceLevelLoad;
                isMagnetStartTime = true;

                itemPcDis = Vector3.Distance(transform.position, pc.transform.position);
            }
            isMagnet = true;
        }
    }

    public void Activate()
    {
        nowTime = Time.timeSinceLevelLoad;
        xPosition = transform.position.x;
        randomX = Random.Range(2, 4);
        randomY = Random.Range(25, 32);
        isMagnet = false;
        isMagnetStartTime = false;

        lerpValue = 0;

        transform.localScale = scale1;
    }

    void GetItem()
    {
        switch (gameObject.tag)
        {
            case "Coin":
                if (!pcFlight)
                    return;
                if (ValueDeliverScript.flightNumber == 1)
                {
                    ValueDeliverScript.flight001GetCoinTemp += addCoin;
                }
                if (PC.particleSystem)
                    PC.particleSystem.Play();
                else
                    PC.transform.parent.gameObject.particleSystem.Play();
                soundUiControlScript.CoinGet();	//동전획득음 재생.
                ValueDeliverScript.coinPlay += addCoin; //획득한 코인점수 더함.
                scoreCoinCount.CoinCount(); //점수판에 코인점수 표시.
                instanceMissionScript.AddCoin(addCoin);

                gameObject.SetActive(false);
                break;


            case "Item01":
                if (ValueDeliverScript.flightNumber == 1)
                    ValueDeliverScript.flight001GetPowerItemTemp++;

                //Debug.Log("현재 전투기 상태 ::: " + col.gameObject.tag);
                if (ValueDeliverScript.isBombRechargeDecrease)
                {
                    Debug.Log("실행하냐? isBombRechargeDecrease ::: " + ValueDeliverScript.isBombRechargeDecrease);
                    bombSkillGageScript.AddBombGage();


                }

                int addedGageForNumber = bulletControlScript.addedGageForNumber;
                //초과획득시 추가 점수 제공.
                if (addedGageForNumber >= 16)
                {
                    ValueDeliverScript.scorePlay += overItemBonusScore; //추가 점수 스코어에 더함. 기본 5000점으로 초기화되어있음.
                    ValueDeliverScript.portalUpScore += overItemBonusScore; //포털레벨업을 위한 목표점수에 이 점수 역시 추가.
                    scoreCoinCount.ScoreCount();	//점수판에 획득 점수 표시.
                    addScoreLabeluiObjectPool.AddScoreActivation(this.gameObject, overItemBonusScore, true);	//화면에 폭파된 적기 위에 점수 표시해주는 이펙트.
                    instanceMissionScript.AddScore(overItemBonusScore);

                    GameObject.Find("GameManager").GetComponent<FriendRescueScript>().MinusScore(ValueDeliverScript.scorePlay, transform.position, false);  //좌측 친구 이미지에서 점수를 조금씩 빼게 만들어준다.
                    bulletControlScript.AddBulletLevel(powerUpBulletAddGage);// 불릿레벨 증가.
                }
                else
                {
                    //Debug.Log("불릿레벨증가함?");
                    bulletControlScript.AddBulletLevel(powerUpBulletAddGage);// 불릿레벨 증가.
                }
                soundUiControlScript.ItemGet();	//아이템획득음 재생.
                //Debug.Log("Get Power Up Item ! ");
                instanceMissionScript.AddPowerUp();

                gameObject.SetActive(false);
                break;



            case "Item02":
                //스킬게이지약간 추가
                soundUiControlScript.GetEnergy();	//아이템획득음 재생.
                bombSkillGageScript.AddSkillGageValue(addGage);// 스킬레벨 증가.
                instanceMissionScript.AddSkillUp();     //스킬 아이템을 몇개 먹었는지 체크.

                skillButton.animation.Play("ButtonScaleActionAnim01");

                gameObject.SetActive(false);
                break;

            case "Item03":
                //스킬맥스
                soundUiControlScript.WingboxItemGet();	//아이템획득음 재생.
                bombSkillGageScript.AddSkillGageValue(addGage);// 스킬게이지 모두 회복.
                characterSpeakManager.CharacterMessageShow(0);

                skillButton.animation.Play("ButtonScaleActionAnim01");

                gameObject.SetActive(false);
                break;


            case "Item04":
                //밤리로더.
                soundUiControlScript.WingboxItemGet();	//아이템획득음 재생.
                bombButton01UIFilledSprite.fillAmount = 1; //핵폭탄게이지 모두 차고 시간 초기화.
                characterSpeakManager.CharacterMessageShow(1);

                bombButton.animation.Play("ButtonScaleActionAnim01");

                gameObject.SetActive(false);
                break;

            case "Item05":
                //마그넷코어.
                addedChSpeakScript.ChSpeak(0);

                Debug.Log("magnet Core!!!");
                soundUiControlScript.WingboxItemGet();	//아이템획득음 재생.
                magnetScript.Activate(mRadius, mTime);	//마그넷 기능 활성화.
                //runeObj.SetActive(true);	//비행기 주변 룬기능 활성화.
                //runeAlphaAni.Activate(mTime);
                characterSpeakManager.CharacterMessageShow(2);

                gameObject.SetActive(false);
                break;

            case "Item07":
                //푸엘 노멀.
                addedChSpeakScript.ChSpeak(0);

                Debug.Log("Fuel Normal!!!");
                soundUiControlScript.WingboxItemGet();	//아이템획득음 재생.
                //아이템 획득시 기능 설정//
                GameObject.Find("FuelSlider").GetComponent<FuelSliderScript>().AddFuel(addGage);
                //아이템 획득시 기능 설정//
                characterSpeakManager.CharacterMessageShow(2);
                fuelImageTF.animation.Play("ButtonScaleActionAnim02");
                instanceMissionScript.addFuelItem();     //연료 아이템을 몇개 먹었는지 체크.

                gameObject.SetActive(false);
                break;

            case "Item08":
                //푸엘 맥스.
                addedChSpeakScript.ChSpeak(0);

                Debug.Log("Fuel Max!!!");
                soundUiControlScript.WingboxItemGet();	//아이템획득음 재생.
                //아이템 획득시 기능 설정//
                GameObject.Find("FuelSlider").GetComponent<FuelSliderScript>().AddFuel(addGage);

                //GameObject.Find("FuelSlider").GetComponent<FuelSliderScript>().FullFuel();
                //아이템 획득시 기능 설정//
                characterSpeakManager.CharacterMessageShow(2);
                fuelImageTF.animation.Play("ButtonScaleActionAnim02");

                gameObject.SetActive(false);
                break;
        }
    }

}
