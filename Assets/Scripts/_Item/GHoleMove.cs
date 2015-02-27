using UnityEngine;
using System.Collections;
using MyDelegateNS;

public class GHoleMove : MonoBehaviour
{
    Vector3 nowPosition;
    Vector3 nextPosition;
    bool delayTimeStart = false;
    public float intervalTime = 2;
    float pastTime = 0;
    bool isMove = false;
    float startTime;
    float lerpTime = 1f;
    float posX;

    public int wingboxLife = 2000;	//HP 피통사이즈.
    public int oriWingboxLife = 2000;	//HP 피통사이즈와 함상 같은 값으로 설정.
    public int addScore = 10000;	//Score;

    ActivateScript activate;
    GameObject gameManager;

    public Vector3 addPosition;

    int coinCount = 0;

    bool isAttacked = false;
    bool isAttackMove = false;

    float spendTime;

    bool megaCoin = false;
    public int coinLevel = 1;
    float coinTime;

    public int item01Chance;
    public int item11Chance;
    public int item21Chance;
    public int item31Chance;
    public int item41Chance;
    public int item51Chance;
    public int item61Chance;
    public int item71Chance;

    bool wingboxout = false;

    SoundUiControlScript soundUiControlScript;
    InstanceMissionScript instanceMissionScript;
    uiObjectPool addScoreLabelUiObjectPool;
    ScoreCoinCount scoreCoinCount;

    //GameObject wingBoxMesh;		//윙박스 실제 오브젝트.
    //ParticleSystem wingBoxParticle;	//윙박스에 붙어있는 파티클.

    GameObject effectObject;	//윙박스 생성시 나오는 별똥별 파티클.
    ParticleEmitter wingBoxEffect01ParticleEmitter;

    bool isFirst = false;	//첫위치를 구하는지 여부를 체크.
    float randomRangeFirst;

    GameObject instanceMission;
    //GameObject wingBoxApear;

    float WingboxActiveTime = 10f;

    public int megaCoinCount = 10;

    public Vector3 bPos;
    float lrMoveSpeed = 2.5f;
    float lrMoveSpeedOri;

    bool isBalckHallActive = false;
    
    void Awake()
    {
        lrMoveSpeedOri = lrMoveSpeed;
        instanceMission = GameObject.Find("InstanceMission");

        gameManager = GameObject.Find("GameManager");
        activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();

        soundUiControlScript = gameManager.GetComponent<SoundUiControlScript>();
        instanceMissionScript = gameManager.GetComponent<InstanceMissionScript>();
        addScoreLabelUiObjectPool = GameObject.Find("AddScoreLabel").GetComponent<uiObjectPool>();
        scoreCoinCount = gameManager.GetComponent<ScoreCoinCount>();

        effectObject = GameObject.Find("WingBoxEffect01");
        wingBoxEffect01ParticleEmitter = effectObject.transform.FindChild("BirthEffect").gameObject.GetComponent<ParticleEmitter>();
        wingBoxEffect01ParticleEmitter.emit = false;

        WingboxActiveTime += ValueDeliverScript.wingboxAddtime;
    }


    void Update()
    {
        //아직 이펙트가 시작하지 않았으면 아래 내용을 실행하지 않는다.
        if (isFinishFx == false) return;
        //블랙홀이 작동을 시작하고 BalckHallActive() 메소드가 시작하지 않으면 이 아래 부분을 실행한다//
        if (BlackHoleBombScript.blackHallOn == true)
        {
            if (isBalckHallActive == false)
            {
                //한번 들어왔은 다시는 이 조건문 안으로 못들어오게 막아준다//
                isBalckHallActive = true;
                //골든웜홀 파괴모드로 들어간다//
                DestroyUfo();
            }
        }
        else if (isAttacked == true && megaCoin == false)
        {
            if (lerpTime < 1f)
            {
                lerpTime += Time.deltaTime * lrMoveSpeed;
                bPos = Vector3.Slerp(nowPosition, nextPosition, lerpTime);
                //Debug.Log("움직인다!!! ::: 첫 위치 ::: " + nowPosition + " ::: 나중위치 ::: " + nextPosition + " ::: 러프 ::: " + lerpTime);
            }
            else
            {
                bPos = nowPosition = nextPosition;

                NextPosition();
                isAttacked = false;
                lerpTime = 0;
            }
        }

        if (Mathf.Abs(transform.position.x) > 35)
        { // 지정된 좌우 범위를 넘어서면 사라지게 함.
            instanceMissionScript.NewMission();
            instanceMission.animation.Play("InstanceMissionApearAnim01");
            ValueDeliverScript.enemyInGame.Remove(this.gameObject);
            gameObject.SetActive(false);
        }

        if (megaCoin)
        { //처치시 동전 드랍. 폭발.시작.
            animation.Stop("GoldenWhole01");
            if (coinTime + 0.05f <= Time.timeSinceLevelLoad)
            {
                activate.CoinActivation(transform.position, coinLevel);	//3은 코인레벨. 격추시 3개짜리 동전만 출현해줌.
                coinCount++;
                coinTime = Time.timeSinceLevelLoad;
            }

            if (coinCount >= megaCoinCount)
            {
                soundUiControlScript.PcExplo();	//폭발사운드. 적용.	
                activate.ExploActivation(transform.position, 01, "WingBox"); //폭발이펙트 켜짐.
                isFirst = false;

                ValueDeliverScript.enemyInGame.Remove(this.gameObject);
                gameObject.SetActive(false);
            }

            transform.position += new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f));
        }

        spendTime += Time.deltaTime;

        //10초가 지나면 골든웜홀을 화면 밖으로 사라지게 해준다.
        if (spendTime > 10f && isOutPosition == false)
        {
            isOutPosition = true;
            OutPosition();
        }
    }

    bool isOutPosition =false;

    void LateUpdate()
    {
        transform.position = new Vector3(bPos.x, transform.position.y, bPos.z);
    }

    public void Activate(Vector3 birthPos)
    {
        lrMoveSpeed = lrMoveSpeedOri;
        isOutPosition = false;
        animation.Stop("GoldenWhole01");
        transform.position = bPos = nowPosition = new Vector3(0, 0, -100);
        Debug.Log("플라이트 어택 파워 ::: " + ValueDeliverScript.flightAttackPower);
        Debug.Log("스킨 효과 ::: " + ValueDeliverScript.skin02_03Effect);

        //에스자 모양 빛줄기 출현(birthPos) 골든웜홀 생성위치까지 이동한다//
        StartCoroutine(OnEffectMove(birthPos));

        lerpTime = 0;

        spendTime = 0;
        NextPosition();
        intervalTime = Random.Range(intervalTime - 0.5f, intervalTime + 0.5f);
        coinCount = 0;
        isAttacked = false;
        isAttackMove = false;
        wingboxLife = oriWingboxLife;
        megaCoin = false;
        isMove = true;
        wingboxout = false;
        delayTimeStart = false;

        isFirst = false;

        isBalckHallActive = false;

        isFinishFx = false;

        ValueDeliverScript.enemyInGame.Add(this.gameObject);
    }

    int isPlusMinus;

    void OutPosition()
    {
        if (nowPosition.x >= 0) isPlusMinus = -1; else isPlusMinus = 1;

        lrMoveSpeed = lrMoveSpeed * 0.5f;
        nowPosition = transform.position;
        if (!wingboxout) ItemBoxBirth(); //아이템 발생.
        posX = 40 * isPlusMinus;
        nextPosition = new Vector3(posX, 0, Random.Range(10, 30f));
        isAttacked = true;
    }

    void NextPosition()
    {
        //먼저 좌우 어디에 생길지 위치를 결정한다.
        if (nowPosition.x >= 0) isPlusMinus = -1; else isPlusMinus = 1;

        //x값을 정확히 정한다.
        posX = Random.Range(8f, 11f) * isPlusMinus;


        //최초 생성 위치는 전투기와 거리를 멀리 두기 위해 25가 되도록 한다.//
        if (!isFirst)
        {
            randomRangeFirst = 25f;
            isFirst = true;
        }
        else randomRangeFirst = 10f;

        nextPosition = new Vector3(posX, 0, Random.Range(randomRangeFirst, 30f));

        //if (!isEffectMove) StartCoroutine(OnEffectMove());
    }

    NextFuncV nextF;
    IEnumerator OnEffectMove(Vector3 Pos)
    {
        nextF = new NextFuncV(AfterStartFx);
        wingBoxEffect01ParticleEmitter.emit = true;
        effectObject.GetComponent<WingBoxEffectScript>().Activate(Pos, nextF);
        yield return new WaitForSeconds(2f);
        wingBoxEffect01ParticleEmitter.emit = false;

        GameObject.Find("GameManager").GetComponent<SoundUiControlScript>().WingboxAppear();   //윙박스 나타날때 사운드.
    }

    bool isFinishFx = false;
    void AfterStartFx(Vector3 endPos)
    {
        isFinishFx = true;
        Debug.Log("골든 웜홀 시작 위치 ::: " + endPos);
        animation.Play("GoldenWhole01");
        bPos = transform.position = nowPosition = endPos;
    }

    void OnTriggerEnter(Collider col)
    {
        int bulletDamage;
        if (wingboxLife <= 0) return;

        switch (col.tag)
        {
            case "Missile":
            case "Bullet":
                //총알 피격 계산.
                soundUiControlScript.UfoAttacked();
                bulletDamage = (int)(col.gameObject.GetComponent<BulletInfoScript>().bulletDamageF * ValueDeliverScript.skin02_03Effect);
                wingboxLife -= (int)(bulletDamage * (ValueDeliverScript.flightAttackPower + 1));
                activate.ExploActivation(transform.position + addPosition, 02, "GoldenWH"); //피탄 이펙트 켜짐.

                activate.CoinActivation(transform.position, 1);	//3은 코인레벨. 격추시 3개짜리 동전만 출현해줌.

                col.gameObject.SetActive(false); // 총알 끔.

                //if (!isAttackMove)
                isAttacked = true;
                break;

            //case "Missile":
            //    //총알 피격 계산.
            //    soundUiControlScript.UfoAttacked();
            //    bulletDamage = (int)(col.gameObject.GetComponent<BulletInfoScript>().bulletDamageF * ValueDeliverScript.skin02_03Effect);
            //    wingboxLife -= (int)(bulletDamage * ValueDeliverScript.flightAttackPower);
            //    activate.ExploActivation(transform.position, 05, "WingBox"); //폭발이펙트 켜짐.
            //    activate.CoinActivation(transform.position, 1);	//3은 코인레벨. 격추시 3개짜리 동전만 출현해줌.
            //    col.gameObject.SetActive(false);
            //    break;
      
            case "SuperPower":
            case "PcLaser":
            case "Bomb01":
            case "Bomb03":
                // 핵폭탄 피격 계산.
                soundUiControlScript.UfoAttacked();
                wingboxLife = -1;
                activate.ExploActivation(transform.position + addPosition, 02, "WingBox"); //피탄 이펙트 켜짐.

                //if (!isAttackMove)
                isAttacked = true;
                break;

            case "SkillBullet":  //실제 스킬샷 타격 계산// 현재는 스킬포탄의 태크는 이것으로 밖에 안쓰임//

                soundUiControlScript.UfoAttacked();
                int skillBDamage = col.gameObject.GetComponent<BulletInfoScript>().bulletDamageF;
                wingboxLife -= skillBDamage;
                activate.ExploActivation(transform.position + addPosition, 02, "WingBox"); //피탄 이펙트 켜짐.

                //if (!isAttackMove)
                isAttacked = true;
                break;
        }

        if (wingboxLife <= 0) DestroyUfo();
    }

    int addedScore = 0;
    void DestroyUfo()
    {
        //내 비행기 폭파 여부 검사하여 폭파하지 않았으면 점수 계산.
        if (GameObject.Find("Flight") == null || addScore == 0) return;
        addedScore = GameObject.Find("GameManager").GetComponent<ComboSystemScript>().isComboOnlyScore(addScore);

        AddScore(addedScore);	//스코어 추가.
        addScoreLabelUiObjectPool.AddScoreActivation(this.gameObject, addedScore, true);	//폭파시 화면에 추가점수 표시해줌.

        coinTime = Time.timeSinceLevelLoad;
        if (!wingboxout) ItemBoxBirth(); //아이템 발생.
        megaCoin = true;
        instanceMissionScript.NewMission();
    }

    void AddScore(int score)
    {
        ValueDeliverScript.scorePlay += score;
        ValueDeliverScript.portalUpScore += score;

        scoreCoinCount.ScoreCount();
    }


    int itemLevel;
    void ItemBoxBirth() // 아이템 생성확률 구하기.
    {
        GameObject.Find("GameManager").GetComponent<SoundUiControlScript>().WingboxItemDrop();   //윙박스 아이템 나타날때 사운드.

        wingboxout = true;
        int randomNumber = Random.Range(0, 10000);  //원본
        //int randomNumber = Random.Range(6000, 6100);

        int activeBomb = ValueDeliverScript.activeBomb;
        if (activeBomb == 0)
        {
            while (randomNumber >= item21Chance && randomNumber < item31Chance)
                randomNumber = Random.Range(0, 10000);
        }

        if (randomNumber < item01Chance)  itemLevel = 1;   //파워업 확률.
        else if (randomNumber < item11Chance)  itemLevel = 11;  //스킬업확률.
        else if (randomNumber < item21Chance) itemLevel = 21;   //에너지제너레이터 확률.
        else if (randomNumber < item31Chance)  itemLevel = 31;  //밤리로더 확률.
        else if (randomNumber < item51Chance)  itemLevel = 51; //슈퍼파워 확률.
        else if (randomNumber < item71Chance) itemLevel = 71;  //푸엘 맥스 확률.

        activate.ItemActivation(transform.position, itemLevel);
        //차후 추가되는 아이템에 대한 것은 이부분에 이프문으로 연결하여 작성한다.
    }
}
