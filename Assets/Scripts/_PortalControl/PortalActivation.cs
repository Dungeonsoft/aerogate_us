using UnityEngine;
using System.Collections;

public class PortalActivation : MonoBehaviour
{
    #region Variation
    float startTime;
    float nowTime;
    public Color[] portalColor;

    Color nowPortalColor;

    int isPortalLevel;
    public GameObject portal01;
    public GameObject portal02;

    string[] ufoName;

    float alphaTime = 0;

    public int enemyBirthCount = 1; //생성되고 있는 유에프오의 수.
    public int enemyMaxCount; //최대생성되어야할 유에프오의 수.

    public int enumyKilledCount; //총알맞아서 파괴된 유에프오의 수.
    public int enumyDeathCount; //시간이 지나거나 해서 자연소멸된 유에프오의 수.
    public bool ufoOn = false;

    public int[] changeDemageValue;
    int addChangeLevel;


    float addY;
    float delayStartTime;

    float randomAngle;
    int nameNumber;

    bool isOnTrigger = true;
    int addDemage = 0;

    float changeColorValue = 0;

    ActivateScript activate;

    GameObject gameManager;

    public Vector3 addPosition;

    SoundUiControlScript soundUiControlScript;

    GameObject portalRotSubObj;

    //	GameObject flight;

    public float ufoBirthInterval = 0.2f;

    #endregion

    void Awake()
    {
        portalRotSubObj = gameObject.transform.FindChild("Plane01").gameObject;
        //		Debug.Log ("portalRotSubObj :::"+portalRotSubObj.name);
    }


    // Use this for initialization
    void Start()
    {
        //		flight = GameObject.Find ("Flight");
        gameManager = GameObject.Find("GameManager");
        activate = gameManager.GetComponent<ActivateScript>();

        ufoName = new string[4];
        ufoName[0] = "UfoDart";
        ufoName[1] = "UfoDust";
        ufoName[2] = "UfoSpinball";
        ufoName[3] = "UfoSeed";

        soundUiControlScript = gameManager.GetComponent<SoundUiControlScript>();

    }

    float portalStart = 0;
    void Update()
    {
        if (portalStart > 10)
        {
            portalStart = 0;
            this.gameObject.SetActive(false);
        }
        else
        {
            portalStart += Time.deltaTime;
        }
    }

    public void Activate(int portalLevel, int fromNameNumber)
    {
        portalStart = 0;
        portal01.renderer.material.SetColor("_TintColor", nowPortalColor * new Color(1f, 1f, 1f, 0));
        portal02.renderer.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0));

        nameNumber = fromNameNumber;
        //		Debug.Log ("1portalLevel : " +portalLevel);

        enumyKilledCount = 0;	//값을 다시 초기화.
        enumyDeathCount = 0;	//값을 다시 초기화.
        enemyBirthCount = 0;	//값을 다시 초기화.  
        enemyMaxCount = 0;		//값을 다시 초기화.

        isOnTrigger = true; //초기에 총알을 맞을지 여부를 결정.

        addChangeLevel = 0;
        addDemage = 0;
        changeColorValue = 0;


        ufoOn = true;
        startTime = 4f;
        nowTime = startTime;
        alphaTime = 0f;
        this.isPortalLevel = portalLevel;
        addY = 0f;
        delayStartTime = 2.5f;  //다트가 생성되서 발사까지 걸리는 시간. 기본 2.5초.


        //출현 UFO의 종류를 정의.

        if (nameNumber < 0)
        {
            int UfoRandomBirth = Random.Range(0, 10000);    //원래 10000.
            if (0 <= UfoRandomBirth && UfoRandomBirth < ValueDeliverScript.dartApearPer)	//dartApearPer	dustApearPer	spinballApearPer	shieldApearPer
                nameNumber = 0;  //Dart
            else
                if (UfoRandomBirth < ValueDeliverScript.dustApearPer)
                    nameNumber = 1;	//Dust
                else
                    if (UfoRandomBirth < ValueDeliverScript.spinballApearPer)
                        nameNumber = 2;	//Spinball
                    else
                        nameNumber = 3;	//Shield
        }

        {
            int rnd = Random.Range(0, 4);
            switch (rnd)
            {
                case 0:
                    randomAngle = Random.Range(15, 75);
                    break;

                case 1:
                    randomAngle = Random.Range(-15, -75);
                    break;

                case 2:
                    randomAngle = Random.Range(105, 165);
                    break;

                case 3:
                    randomAngle = Random.Range(-105, -165);
                    break;
            }
        }

        portalRotSubObj.GetComponent<PortalRotateScript>().AddSpeed(portalLevel);

        StartCoroutine(PortalAlphaIncrease());

    }

    IEnumerator PortalAlphaIncrease()
    {
        nowPortalColor = portalColor[this.isPortalLevel - 1];

        while (alphaTime < 0.5f)
        {
            portal01.renderer.material.SetColor("_TintColor", nowPortalColor * new Color(1f, 1f, 1f, alphaTime));
            portal02.renderer.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, alphaTime * 2));
            alphaTime += Time.deltaTime * 0.334f;
            yield return null;
        }
        alphaTime = 0.5f;
        isOnTrigger = false;

        if (addDemage >= changeDemageValue[isPortalLevel - 1] && isPortalLevel < 7)
        { //데미지를 얼마나 받았는지 검사해서 레벨 변경이 가능한 수준까지 되면 아래 내용을 실행.

            soundUiControlScript.WormholeEvolution();   //웜홀 레벨업시 사운드.

            int addDemageRest = addDemage;

            // 남은 데미지 량이 포털 업그레이드 하기에 충분한 양인지 검사 그리고 아직 최고 레벨보다 레벨이 적은가 검사 둘다 만족하면 화일 내용을 실행함.
            while (addDemageRest >= changeDemageValue[isPortalLevel - 1 + addChangeLevel]
                   &&
                   (isPortalLevel - 1 + addChangeLevel) <= 5)
            {
                addDemageRest -= changeDemageValue[isPortalLevel - 1 + addChangeLevel];
                addChangeLevel++;
            }

            nowTime += 1f;
            //////
            gameObject.animation.Play("PortalLevelChangeScaleAni");

            while (changeColorValue < 1)
            {
                nowPortalColor = Color.Lerp(nowPortalColor, portalColor[this.isPortalLevel - 1 + addChangeLevel], changeColorValue);
                changeColorValue += Time.deltaTime;
                portal01.renderer.material.SetColor("_TintColor", nowPortalColor * new Color(1f, 1f, 1f, alphaTime));
                portal02.renderer.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, alphaTime * 2));
                yield return null;
            }
            isPortalLevel += addChangeLevel;
            portalRotSubObj.GetComponent<PortalRotateScript>().AddSpeed(isPortalLevel); //
        }

        if (isPortalLevel >= 7) isPortalLevel = 7;	//혹시 모를 포탈 레벨의 7을 넘어가는 것을 방지.

        switch (nameNumber) // 어떤 유에프오를 출현시킬지 결정.
        {
            case 0:
                switch (isPortalLevel)				//UfoDart.//레벨별로 출현갯수가 다름.
                {
                    case 1: enemyMaxCount = 02; break;
                    case 2: enemyMaxCount = 02; break;
                    case 3: enemyMaxCount = 02; break;
                    case 4: enemyMaxCount = 02; break;
                    case 5: enemyMaxCount = 02; break;
                    case 6: enemyMaxCount = 02; break;
                    case 7: enemyMaxCount = 02; break;
                } break;
            case 1: 							//UfoDust.//레벨별로 출현갯수가 다름.
                switch (isPortalLevel)
                {
                    case 1: enemyMaxCount = 08; break;
                    case 2: enemyMaxCount = 08; break;
                    case 3: enemyMaxCount = 08; break;
                    case 4: enemyMaxCount = 08; break;
                    case 5: enemyMaxCount = 08; break;
                    case 6: enemyMaxCount = 08; break;
                    case 7: enemyMaxCount = 08; break;
                } break;
            case 2:
                switch (isPortalLevel)				//UfoSpinball.//레벨별로 출현갯수가 다름.
                {
                    case 1: enemyMaxCount = 04; break;
                    case 2: enemyMaxCount = 04; break;
                    case 3: enemyMaxCount = 04; break;
                    case 4: enemyMaxCount = 04; break;
                    case 5: enemyMaxCount = 04; break;
                    case 6: enemyMaxCount = 04; break;
                    case 7: enemyMaxCount = 04; break;
                } break;
            case 3: 							//UfoSeed.//레벨별로 출현갯수가 다름.
                switch (isPortalLevel)
                {
                    case 1: enemyMaxCount = 01; break;
                    case 2: enemyMaxCount = 01; break;
                    case 3: enemyMaxCount = 01; break;
                    case 4: enemyMaxCount = 01; break;
                    case 5: enemyMaxCount = 01; break;
                    case 6: enemyMaxCount = 01; break;
                    case 7: enemyMaxCount = 01; break;
                } break;
        }//유에프오 출현종류 결정 완료.

        while (enemyBirthCount < enemyMaxCount)
        {
            activate.UfoActivate(gameObject.name, transform, ufoName[nameNumber], isPortalLevel, delayStartTime, addY, randomAngle, this.gameObject, enemyMaxCount);  //원본.

            if (nameNumber == 0) addY += 1.8f;
            enemyBirthCount++;
            yield return new WaitForSeconds(ufoBirthInterval);
        }

        while (alphaTime > 0f)
        {
            portal01.renderer.material.SetColor("_TintColor", nowPortalColor * new Color(1f, 1f, 1f, alphaTime));
            portal02.renderer.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, alphaTime * 2));
            //alphaTime -= Time.deltaTime * 0.2f;
            alphaTime -= Time.deltaTime * 2f;

            yield return null;
        }
        alphaTime = 0f;
        portal01.renderer.material.SetColor("_TintColor", nowPortalColor * new Color(1f, 1f, 1f, alphaTime));
        portal02.renderer.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, alphaTime * 2));

    }


    public void IsDeactivate()
    {
        if (this.gameObject.activeSelf == true)
        {
            if (enemyBirthCount > 0 && enemyBirthCount == enemyMaxCount && (enumyKilledCount + enumyDeathCount) >= enemyMaxCount)
            {
                StartCoroutine(Deactivate());
            }
        }
    }

    IEnumerator Deactivate()
    {
        while (true)
        {
            if (alphaTime == 0f)
            {
                gameObject.SetActive(false);
                yield break;
            }
            yield return null;
        }
    }

    public void Deactivate2()  // 공중폭격시에만 적용되는 디액티베이트.
    {
        portal01.renderer.material.SetColor("_TintColor", nowPortalColor * new Color(1f, 1f, 1f, 0));
        portal02.renderer.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0));

        gameObject.SetActive(false);
    }

    public void AddEnumyKillCount()
    {
        enumyKilledCount++;
        IsDeactivate();
    }

    public void AddEnumyDeathCount()
    {
        enumyDeathCount++;
        IsDeactivate();
    }

    void OnTriggerEnter(Collider col)
    {
        if (isOnTrigger && col.gameObject.tag == "Bullet")
        {
            int bulletDamage = (int)(col.gameObject.GetComponent<BulletInfoScript>().bulletDamageF * (1+ValueDeliverScript.flightAttackPower));
            soundUiControlScript.WormholeAttacked(); //피탄 사운드 켜짐.
            activate.ExploActivation(transform.position + new Vector3(0, 0, -0.3f), 02, "WingBox"); //피탄 이펙트 켜짐.
            col.gameObject.SetActive(false);

            addDemage += bulletDamage;
        }

        if (col.gameObject.tag == "Bomb01") // 포털레벨체인지 폭탄 피격 계산.
        {
            soundUiControlScript.UfoAttacked();
            activate.ExploActivation(transform.position + addPosition, 02, "WingBox"); //피탄 이펙트 켜짐.
            Deactivate2();
        }
    }
}
