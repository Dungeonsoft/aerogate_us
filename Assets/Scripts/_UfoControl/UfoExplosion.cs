using UnityEngine;
using System.Collections;



public class UfoExplosion : MonoBehaviour
{
    #region Valiables
    public int ufoLife = 100;		//HP.
    public int addScore = 100;		//Score;
    public int addSkillGage = 50;	//SkillGage;
    public int perfectKillBonusScore = 10000; //Perfect Kill Bonus Score;
    public int skinExp = 12;
    int ufoLifeOri;
    ActivateScript activate;
    public GameObject explode;
    bool isUfoLife = false;

    public Vector3 addPosition;

    GameObject parentPortal;
    GameObject gameManager;
    GameObject flight;

    public string ufoName;

    public int coin01Chance;
    public int coin02Chance;

    public int item01Chance;
    public int item11Chance;
    public int item21Chance;
    public int item31Chance;
    public int item41Chance;
    public int item51Chance;
    public int item61Chance;
    public int item71Chance;

    public int coinChance;

    bool isLevelChangeBomb01 = false;

    PortalActivation portalActivation;
    uiObjectPool addScoreLabelUiObjectPool;
    SoundUiControlScript soundUiControlScript;
    ScoreCoinCount scoreCoinCount;
    InstanceMissionScript instanceMission;
    BombSkillGageScript bombSkillGageScript;

    GameObject ufoObj;

    public int ufoType; // 1.스핀볼 2.다트 3.더스트 4.시드
    public float ufoTypeDamage = 1f;

    GameObject criticalHit;

    float exelDamage = 1;

    public int crashDamage = 1;

    GameObject fuelSlider;
    #endregion Valuables

    //	bool isTwistMove = false;



    float fAttackPo;
    float incrBoAttackPer;
    float AttackPoPer;
    int addAttackAbil;
    float itemMagEf;
    float skin02_04Effect;
    float skin02_05Effect1;

    
    void Awake()
    {
        ufoLifeOri = ufoLife;
        criticalHit = GameObject.Find("CriticalHit");
    }

    public void Activate()
    {
        ufoLife = ufoLifeOri;
        isUfoLife = true;
    }


    // Use this for initialization
    void Start()
    {
        fuelSlider = GameObject.Find("FuelSlider");
        flight = GameObject.Find("PC/Flight");
        gameManager = GameObject.Find("GameManager");
        activate = gameManager.GetComponent<ActivateScript>();
        //		portalActivation = parentPortal.GetComponent<PortalActivation>();
        addScoreLabelUiObjectPool = GameObject.Find("AddScoreLabel").GetComponent<uiObjectPool>();

        soundUiControlScript = gameManager.GetComponent<SoundUiControlScript>();
        scoreCoinCount = gameManager.GetComponent<ScoreCoinCount>();
        instanceMission = gameManager.GetComponent<InstanceMissionScript>();
        bombSkillGageScript = gameManager.GetComponent<BombSkillGageScript>();

        if (ufoType == ValueDeliverScript.targetUfoType && ufoType + ValueDeliverScript.targetUfoType >= 2) //2보다 크다고 설정한것은 혹시라도 1보다 작은 짝수가 나왔을때(값이 잘못 입력되었을때)를 무시하기 위해서
        {
            switch (ufoType + ValueDeliverScript.targetUfoType)
            {
                case 2: ufoTypeDamage = 2f; break;
                case 4: ufoTypeDamage = 2f; break;
                case 6: ufoTypeDamage = 2f; break;
                case 8: ufoTypeDamage = 2f; break;
            }
        }


         fAttackPo = ValueDeliverScript.flightAttackPower;
        incrBoAttackPer = ValueDeliverScript.increaseBombAttackPercentInGame;
        AttackPoPer = ValueDeliverScript.AttackPowerPercentTemp;
        addAttackAbil = ValueDeliverScript.addAttackAbility;
        itemMagEf = ValueDeliverScript.itemMagnetEffect;
        skin02_04Effect = ValueDeliverScript.skin02_04Effect;


    }

    void Update()
    {
        if (flight == null || flight.activeSelf == false) return;
        if (transform.position.z < -5) //최종 사라지는 위치를 정해준다.
        {
            if (ufoType == 2 && this.gameObject.activeSelf == true)   //다트이면~
            {
                //this.gameObject.GetComponent<UfoDart>().StopEngine();
            }
            StartCoroutine(Naturaldestroy());
        }

    }

    public IEnumerator Naturaldestroy()
    {
        portalActivation.AddEnumyDeathCount(); //자연소멸 되고 나서 자연소멸 수 더해줌.
        transform.rotation = Quaternion.Euler(0, 180, 0);
        ValueDeliverScript.enemyInGame.Remove(this.gameObject);
        yield return null;
        gameObject.SetActive(false);
    }

    public void BlackHollIn()
    {
        soundUiControlScript.UfoAttacked();
        ufoLife = 0;
        if (ufoType != 3)
            activate.ExploActivation(transform.position + addPosition, 02, gameObject.name); //피탄 이펙트 켜짐.
        DestroyUfo("BlackHall");
    }


    int attackDamage;
    int bulletDamage;
    float damageAddPercent;

    void OnTriggerEnter(Collider col)
    {
        if (isUfoLife == false) return; //초기화가 되지 않으면 피탄 계산 자체를 하지 않는다.

        float spinballDamPercent = 0;
        if (ufoName == "UfoSpinball")
            spinballDamPercent = ValueDeliverScript.spinballDamagePercent;


        if (ValueDeliverScript.isdamageAddChance)
        {
            int chance = Random.Range(0, 10000);
            if (chance < ValueDeliverScript.damageAddChance)
                damageAddPercent = ValueDeliverScript.damageAddPercent;
        }


        switch (col.tag)
        {
            #region SuperPower PcLaser Bomb01
            case "SuperPower":
            case "PcLaser":
            case "Bomb01":
                soundUiControlScript.UfoAttacked();
                ufoLife = 0;
                if (ufoType != 3)
                    activate.ExploActivation(transform.position + addPosition, 02, gameObject.name); //피탄 이펙트 켜짐.
                else
                    activate.ExploActivation(transform.GetChild(0).position + addPosition, 02, gameObject.name); //피탄 이펙트 켜짐.
                break;
            #endregion

            #region LevelChangeBomb
            case "LevelChangeBomb":
                soundUiControlScript.UfoAttacked();
                ufoLife = 0;
                if (ufoType != 3)
                    activate.ExploActivation(transform.position + addPosition, 02, gameObject.name); //피탄 이펙트 켜짐.
                else
                    activate.ExploActivation(transform.GetChild(0).position + addPosition, 02, gameObject.name); //피탄 이펙트 켜짐.
                isLevelChangeBomb01 = true;
                ExploEnd();
                break;
            #endregion

            #region Bullet Missile
            case "Bullet":
            case "Missile":
                bulletDamage = col.gameObject.GetComponent<BulletInfoScript>().bulletDamageF;
                skin02_05Effect1 = 0f;

                if (ValueDeliverScript.nowPortalLevel >= ValueDeliverScript.applyPortalLevel)
                    skin02_05Effect1 = ValueDeliverScript.skin02_05Effect1;

                ExeDemage();
                attackDamage = (int)(bulletDamage * exelDamage * ufoTypeDamage * (1 + fAttackPo + incrBoAttackPer + AttackPoPer + damageAddPercent + spinballDamPercent + itemMagEf + skin02_04Effect + skin02_05Effect1) + addAttackAbil * 5);

                switch (col.tag)
                {
                    case "Bullet":
                        if (gameObject.activeSelf)
                            ufoObj.GetComponent<AttackWhilteScript>().AttackWhilte();
                        soundUiControlScript.UfoAttacked();
                        ufoLife -= attackDamage;
                        if (ValueDeliverScript.flightNumber == 1 && gameObject.name.ToString().Contains("Seed"))
                            ufoLife -= (int)(bulletDamage * 0.2f);

                        if (ufoType != 3)
                            activate.ExploActivation(transform.position + addPosition, 02, gameObject.name); //피탄 이펙트 켜짐.
                        else
                            activate.ExploActivation(transform.GetChild(0).position + addPosition, 02, gameObject.name); //피탄 이펙트 켜짐.

                        col.gameObject.SetActive(false);
                        break;

                    case "Missile":
                        if (gameObject.activeSelf)
                            ufoObj.GetComponent<AttackWhilteScript>().AttackWhilte();
                        soundUiControlScript.UfoAttacked();
                        ufoLife -= attackDamage;

                        if (ufoType != 3)
                            activate.ExploActivation(transform.position + addPosition, 02, gameObject.name); //피탄 이펙트 켜짐.
                        else
                            activate.ExploActivation(transform.GetChild(0).position + addPosition, 02, gameObject.name); //피탄 이펙트 켜짐.

                        col.gameObject.SetActive(false);
                        break;
                }
                break;
            #endregion

            #region SkillBullet Player
            case "SkillBullet":
                soundUiControlScript.UfoAttacked();
                int skillDamage = col.gameObject.GetComponent<BulletInfoScript>().bulletDamageF;
                ufoLife -= (int)(skillDamage * exelDamage * ufoTypeDamage * (1 + ValueDeliverScript.flightAttackPower));
                soundUiControlScript.UfoAttacked();
                //Debug.Log("Skill Shot !   :::::::::::" + col.name);
                if (ufoType != 3) activate.ExploActivation(transform.position + addPosition, 02, gameObject.name); //피탄 이펙트 켜짐.
                else activate.ExploActivation(transform.GetChild(0).position + addPosition, 02, gameObject.name); //피탄 이펙트 켜짐.
                break;

            case "Player":
                if (flight == null && flight.activeSelf == false) break;


                //ufo 폭발이펙트 형태를 정해줌//
                if (ufoType != 3) activate.ExploActivation(transform.position, 01, gameObject.name); //폭발이펙트 켜짐.
                else activate.ExploActivation(transform.GetChild(0).position, 01, gameObject.name); //피탄 이펙트 켜짐.
                //ufo 폭발이펙트 형태를 정해줌//

                //보호막이 있을때와 수리기능 있을때와 아무보호기능이 없을때를 순서대로 검사해서 그에 맞게 처리해줌//
                if (ValueDeliverScript.shieldEquip) //보호막 있을때 처리//
                {
                    ValueDeliverScript.shieldEquip = false;
                    GameObject.Find("AssistIcon").SetActive(false);//자석 아이템 안보이게 끔.
                    GameObject.Find("PC").GetComponent<PlayerMoveScript>().ShieldEquipStart();
                }

                //수리기능이 있는지 여부를 검사//
                else if (ValueDeliverScript.fuelSize > 0)
                {
                    fuelSlider.GetComponent<FuelSliderScript>().GageReduceVoid(crashDamage);
                    soundUiControlScript.PcExplo();									//폭발사운드. 적용.	
                    ufoLife = 0;
                }

                //화면에 유리깨짐 효과를 만듬//

                gameManager.GetComponent<RedAlert>().StateChage(RedAlert.AlertState.attacked);
                break;
            #endregion
        }

        if (ufoLife <= 0 && gameObject.activeSelf  == true)
            StartCoroutine(DestroyUfoIE(col.tag));
    }

    void ExeDemage()
    {
        //크리티컬 히트 여부 결정과 UI 생성을 보여주는 부분을 관장하는 곳.
        if (ValueDeliverScript.isCriticalExel)
        {
            int criticalRand = Random.Range(0, 100);
            if (criticalRand > 0 && criticalRand < 10) //원래 20-25.
            {
                //Debug.Log("CRITICAL!!!");
                if (ufoType == 3) criticalHit.GetComponent<CriticalHitObjPool>().CriticalObjActivation(transform.GetChild(0).gameObject);
                else criticalHit.GetComponent<CriticalHitObjPool>().CriticalObjActivation(this.gameObject);
                exelDamage = 3f;
            }
        }
        else
            exelDamage = 1f;
        //크리티컬 히트 여부 결정과 UI 생성을 보여주는 부분을 관장하는 곳.
    }

    public IEnumerator DestroyUfoIE(string nameTag)
    {
        yield return null;
        DestroyUfo(nameTag);
    }

    void DestroyUfo(string nameTag ="None")
    {
        if (ValueDeliverScript.flightNumber == 1)
        {
            ValueDeliverScript.flight001EnemyKillTemp++;
        }
        else if (ValueDeliverScript.flightNumber == 2 && ufoType == 1)
        {
            ValueDeliverScript.flight002KillSpinballTemp++;
        }

        if (!isLevelChangeBomb01)
        { // 레벨체인지밤으로 처리시 점수나 아이템 방출은 처리안함.//동전 생성. -파워업은 PortalActivation에서 처리함.
            portalActivation.AddEnumyKillCount(); //.AddEnumyKillCount(); //킬 되고 나서 킬수 더해줌.
            //						Debug.Log (parentPortal.name + "AddEnumyKillCount");
            
            int addedScore;
            addedScore = GameObject.Find("GameManager").GetComponent<ComboSystemScript>().isCombo(this.addScore);

            AddScore(addedScore);	//스코어 추가.

            AddSkillGage(addSkillGage); //스킬 게이지 추가.
            AddUfoCount();
            ValueDeliverScript.skinExp += skinExp;

            ////////////포털에서 나온 유에프오의 파괴와 소멸을 계산하여 점수화 하는 부분.-시작.
            //이프 조건 시작.
            if (portalActivation.enemyBirthCount == portalActivation.enemyMaxCount
                    &&
                    (portalActivation.enumyKilledCount + portalActivation.enumyDeathCount) >= portalActivation.enemyMaxCount)
            //여기까지 이프조건 내용.
            {

                if (portalActivation.enumyDeathCount == 0 && portalActivation.ufoOn == true)
                {
                    int perfectKillBonusScoreAdd = 0;
                    perfectKillBonusScoreAdd = (int)(perfectKillBonusScore * (1 + ValueDeliverScript.scoreIncreasePercent));
                    perfectKillBonusScoreAdd = GameObject.Find("GameManager").GetComponent<ComboSystemScript>().isComboOnlyScore(perfectKillBonusScoreAdd);
                    AddScore(perfectKillBonusScoreAdd);

                    if (ufoType == 3) addScoreLabelUiObjectPool.AddScoreActivation(transform.GetChild(0).gameObject, perfectKillBonusScoreAdd, true);
                    else addScoreLabelUiObjectPool.AddScoreActivation(this.gameObject, perfectKillBonusScoreAdd, true);
                    ItemBoxBirth();
                }

                if (portalActivation.gameObject.activeSelf == true)
                {
                    portalActivation.ufoOn = false;
                    portalActivation.IsDeactivate();
                }
            }
            ////////////포털에서 나온 유에프오의 파괴와 소멸을 계산하여 점수화 하는 부분.-끝.

            CoinMaker();
            if (ufoType == 3) addScoreLabelUiObjectPool.AddScoreActivation(transform.GetChild(0).gameObject, addedScore, false);
            else addScoreLabelUiObjectPool.AddScoreActivation(this.gameObject, addedScore, false); // 추가하여야 될 점수 표시판에 넣어줌.
        }
        ExploEnd();
    }


    void ExploEnd()
    {
        isUfoLife = false;
        if (ufoType != 3) activate.ExploActivation(transform.position + addPosition, 01, gameObject.name); //피탄 이펙트 켜짐.
        else activate.ExploActivation(transform.GetChild(0).position + addPosition, 01, gameObject.name); //피탄 이펙트 켜짐.

        if (ufoType != 4) soundUiControlScript.UfoExplo(); //폭파음재생.
        else soundUiControlScript.UfoLargeExplo(); //쉴드폭파음재생.

        ValueDeliverScript.enemyInGame.Remove(this.gameObject);

        gameObject.SetActive(false);
    }

    IEnumerator ufoHide()
    {
        yield return null;
        gameObject.SetActive(false);
    }

    void CoinMaker() //코인생성.
    {
        int maxValue = 1;   //코인이 나오는 갯수.
        int chance = Random.Range(0, 10000);
        if (chance < ValueDeliverScript.coinAddChance) maxValue = ValueDeliverScript.coinAddNumber;

        for (int i = 0; i < maxValue; i++)
        {
            //코인 생성 확률 구하기.
            int coinPer100 = Random.Range(0, 100);
            if (coinPer100 < coinChance)
            {
                int coinLevel;
                int isCoinLevel = Random.Range(0, 10000);

                if (isCoinLevel < coin01Chance) coinLevel = 1;
                else if (isCoinLevel < coin01Chance + coin02Chance) coinLevel = 2;
                else coinLevel = 3;

                activate.CoinActivation(transform.position, coinLevel);
            }
        }
    }


    public void ExploActivate(GameObject parentPortal)
    {
        this.parentPortal = parentPortal;
        //Debug.Log(this.parentPortal + "::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
        portalActivation = parentPortal.GetComponent<PortalActivation>();
        isLevelChangeBomb01 = false;
        string[] name;
        name = gameObject.name.Split('0');
        //Debug.Log("폭파되는 오브젝트 이름 :: "+name[0]);
        ufoObj = gameObject.transform.FindChild(name[0]).gameObject;
        ufoObj.GetComponent<AttackWhilteScript>().WhiteAct();
    }

    void ItemBoxBirth() // 아이템 생성확률 구하기.
    {
        portalActivation = parentPortal.GetComponent<PortalActivation>();
        int randomNumber1 = Random.Range(0, 10000);
        if (randomNumber1 > 6666)
        {
            int randomNumber2 = Random.Range(0, 10000);
            if (randomNumber2 < item01Chance + ValueDeliverScript.powerUpDropChance)
            {
                int itemLevel = 1;
                activate.ItemActivation(transform.position, itemLevel);
            }
            else if (randomNumber2 < item11Chance)
            {
                int itemLevel = 11;
                activate.ItemActivation(transform.position, itemLevel);
            }
            else if (randomNumber2 <= item61Chance)
            {
                int itemLevel = 61;
                activate.ItemActivation(transform.position, itemLevel);
            }


            //차후 추가되는 아이템에 대한 것은 이부분에 이프문으로 연결하여 작성한다.
        }
        if (portalActivation.gameObject.activeSelf == true)
        {
            portalActivation.ufoOn = false;
            portalActivation.IsDeactivate();
        }
    }

    void AddScore(int score)
    {
        if (ValueDeliverScript.isIncreaseScorePercent & ufoName == "Shield")
        {
            int addScore = (int)(score * (1 + ValueDeliverScript.increaseScorePercent + ValueDeliverScript.shieldDestroyAddScorePercent));
            ValueDeliverScript.scorePlay += addScore;
            ValueDeliverScript.portalUpScore += addScore;

            GameObject.Find("GameManager").GetComponent<FriendRescueScript>().MinusScore(ValueDeliverScript.scorePlay, transform.position, true);  //좌측 친구 이미지에서 점수를 조금씩 빼게 만들어준다.
        }
        else if (ValueDeliverScript.isIncreaseScorePercent)
        {
            int addScore = (int)(score * (1 + ValueDeliverScript.increaseScorePercent));
            ValueDeliverScript.scorePlay += addScore;
            ValueDeliverScript.portalUpScore += addScore;

            GameObject.Find("GameManager").GetComponent<FriendRescueScript>().MinusScore(ValueDeliverScript.scorePlay, transform.position, true);  //좌측 친구 이미지에서 점수를 조금씩 빼게 만들어준다.
        }
        else
        {
            ValueDeliverScript.scorePlay += score;
            ValueDeliverScript.portalUpScore += score;

            GameObject.Find("GameManager").GetComponent<FriendRescueScript>().MinusScore(ValueDeliverScript.scorePlay, transform.position, true);  //좌측 친구 이미지에서 점수를 조금씩 빼게 만들어준다.
        }
        scoreCoinCount.ScoreCount();
        instanceMission.AddScore(score);    //인스턴스 미션중 스코어 관련 부분을 위해 필요한 함수.
    }

    void AddSkillGage(int addSkillGage)
    {
        addSkillGage += ValueDeliverScript.rechargeEnergy;
        bombSkillGageScript.AddSkillGageValue(addSkillGage);
    }


    void AddUfoCount()
    {
        switch (ufoName)
        {
            case "UfoDart":
                ValueDeliverScript.dartCountTemp++;
                instanceMission.AddDart();
                break;
            case "UfoDust":
                ValueDeliverScript.dustCountTemp++;
                instanceMission.AddDust();
                break;
            case "UfoSpinball":
                ValueDeliverScript.spinballCountTemp++;
                instanceMission.AddSpinBall();
                break;
            case "UfoSeed":
                ValueDeliverScript.shieldCountTemp++;
                instanceMission.AddSeed();
                break;
        }
        #region 안쓰이는 코드 스위치문으로 전환됨//
        //if (ufoName == "UfoDart")
        //{
        //    ValueDeliverScript.dartCountTemp++;
        //    instanceMission.AddDart();
        //}
        //else if (ufoName == "UfoDust")
        //{
        //    ValueDeliverScript.dustCountTemp++;
        //    instanceMission.AddDust();
        //}
        //else if (ufoName == "UfoSpinball")
        //{
        //    ValueDeliverScript.spinballCountTemp++;
        //    instanceMission.AddSpinBall();
        //}
        //else if (ufoName == "UfoShield")
        //{
        //    ValueDeliverScript.shieldCountTemp++;
        //    instanceMission.AddSeed();
        //}
        #endregion
    }
}