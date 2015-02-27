using UnityEngine;
using System.Collections;

public class UfoSeed : UfoActivation
{
    public float rotStartSpeed = 3f;
    public float rotEndSpeed = 10f;
    public float rotEndSeconds = 10f;
    float rotNowSpeed;
    float rotlerpVal;

    float scaleTime;
    bool isScaleTime = false;

    bool isBalckHallActive = false;
    float lerpValue;
    float lerpValueScl;
    bool isLerpValueSclUp = false;

    bool isExplo = false;

    float ufoOriLife;

    ActivateScript activate;

    public int bulletCount = 5;
    public float bulletRotRage = 60f;

    public int crashDam;


    void Awake()
    {
        isBalckHallActive = false;
        ufoOriLife = GetComponent<UfoExplosion>().ufoLife;
        activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();

    }

    void Update()
    {
        rotNowSpeed = Mathf.Lerp(rotStartSpeed, rotEndSpeed, (ufoOriLife - GetComponent<UfoExplosion>().ufoLife) / ufoOriLife);
        transform.eulerAngles += new Vector3(0, rotNowSpeed, 0);
        GetComponent<UfoExplosion>().ufoLife -= (int)(ufoOriLife * (Time.deltaTime / rotEndSeconds));

        if (GetComponent<UfoExplosion>().ufoLife <= 0 && isExplo == false)
        {
            Debug.Log("시드 폭발!!" + this.name);
            isExplo = true;
            StartCoroutine(GetComponent<UfoExplosion>().DestroyUfoIE("time"));
        }

        else if (isBalckHallActive == true)
        {
            transform.position = Vector3.Lerp(posAtBlkHall, new Vector3(0, 0, 18), lerpValue);
            transform.localScale = Vector3.Lerp(sclAtBlkHall, new Vector3(0, 0, 0), lerpValue);

            //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 30f, transform.eulerAngles.z);

            lerpValue += Time.deltaTime * 1.5f;
            if (isLerpValueSclUp == false)
            {
                lerpValueScl -= Time.deltaTime * 2.25f;
                if (lerpValueScl <= 0) isLerpValueSclUp = true;
            }
            else
                lerpValueScl += Time.deltaTime * 2.25f;
            
            if (lerpValue >= 1) GetComponent<UfoExplosion>().BlackHollIn();
        }

        //블랙홀이 작동을 시작하고 BalckHallActive() 메소드가 시작하지 않으면 이 아래 부분을 실행한다//
        else if (BlackHoleBombScript.blackHallOn == true && isScaleTime == true)
        {
            if (isBalckHallActive == false) BalckHallActive();

            //블랙홀이 작동을 시작하고 아직 사라지지 않았으면 이부분을 실행한다/
        }

        else if (transform.localScale.x < 1)
        {
            if (!isScaleTime)
            {
                //첫 등장시 커지면서 나오게 해주는 효과//
                if (scaleTime < 1f)
                {
                    transform.localScale = new Vector3(scaleTime, scaleTime, scaleTime);
                    scaleTime += Time.deltaTime * 2;
                }
                else
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    isScaleTime = true;
                }
            }

        }

    }

    Vector3 posAtBlkHall;
    Vector3 sclAtBlkHall;

    //블랙홀 핵폭탄이 터졌을때 이 함수가 호출되어 isBalckHallActive 변수가 true가 된다.//
    //이후부터는 움직임이 블랙홀로 빨려가는 모양이 된다.
    void BalckHallActive()
    {
        posAtBlkHall = transform.position;
        sclAtBlkHall = transform.localScale * 1.5f;
        isBalckHallActive = true;
        lerpValue = 0;
        lerpValueScl = 0.333f;
        isLerpValueSclUp = false;
    }


    public override void Activate(float delayStartTime, float addY, float randomAngle, GameObject parentPortal)
    {

        ValueDeliverScript.enemyInGame.Add(this.gameObject);

        transform.rotation = Quaternion.Euler(0, 0, 0);
        this.gameObject.GetComponent<UfoExplosion>().ExploActivate(parentPortal);

        transform.localScale = new Vector3(0f, 0f, 0f);
        scaleTime = 0;
        isScaleTime = false;

        isBalckHallActive = false;
        lerpValue = 0;

        GetComponent<UfoExplosion>().Activate();        //비행기의 생명값을 관장하는 부분을 초기화 하기 위해 필요한 부분.
    }

    void OnDisable()
    {
        isExplo = false;
        activate.SeedBulletActivation(transform.position, bulletCount, bulletRotRage , crashDam);
    }

}
