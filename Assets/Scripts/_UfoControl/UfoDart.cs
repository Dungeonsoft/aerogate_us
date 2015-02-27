using UnityEngine;
using System.Collections;

public class UfoDart : UfoActivation
{
    public float dartSpeed = 30f;


    Transform target;
    Transform look;
    float delayTime;    //다트가 생성되서 발사까지 걸리는 시간. 기본 2.5초. PortalActivation.cs > delayStartTime 을 참고하면 됨.
    float addY;

    float smooth = 0.3f;
    bool isTarget = false;
    Vector3 LookTarget;
    float scaleTime;
    bool isScaleTime = false;

    bool isBalckHallActive = false;
    float lerpValue;
    float lerpValueScl;
    bool isLerpValueSclUp = false;

    Transform engineFx;
    GameObject engineParticle;
    int engineFxCount;
    //
    //bool isEngineStop = false;

    //	UfoExplosion ufoExplosion;

    // Use this for initialization
    void Awake()
    {
        isBalckHallActive = false;
        //스페셜 출격으로 게임을 할때는 유에프오의 속도도 증가시킨다//
        if (ValueDeliverScript.isSelectSpecial) dartSpeed = dartSpeed * ValueDeliverScript.specialSpeed;
        target = GameObject.Find("GameManager/PC").transform;
        look = transform.FindChild("look");
    }

    void Start()
    {
        engineFx = GameObject.Find("EngineFx").transform;
        //engineFxCount = 40;

        //		ufoExplosion = this.gameObject.GetComponent<UfoExplosion>();
    }

    // Update is called once per frame
    void Update()
    {
        //블랙홀이 작동을 시작하고 아직 사라지지 않았으면 이부분을 실행한다/
        if (isBalckHallActive == true)
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

        }

        //일반상황//블랙홀이 터지지 않았을때//
        else if (!isBalckHallActive || transform.localScale.x < 1)
        {
            if (!isScaleTime)
            {
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
            else if (delayTime > 0.3f && delayTime < 1F)
            {
                if (!isTarget)
                {
                    LookTarget = target.position + new Vector3(addY - 2.7f, 0, 0);
                    isTarget = true;
                }
                look.LookAt(LookTarget);
                transform.rotation = Quaternion.Lerp(transform.rotation, look.rotation, smooth);
            }
            else if (delayTime < 0)
            {
                transform.Translate(0, 0, dartSpeed * Time.deltaTime);
            }

            delayTime -= Time.deltaTime;
        }

    }


    Vector3 posAtBlkHall;
    Vector3 sclAtBlkHall;


    void BalckHallActive()    //블랙홀 핵폭탄이 터졌을때 이 함수가 호출되어 트위스트무브 변수가 true가 된다. 이후부터는 움직임이 회오리 모양이 된다.
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

        transform.rotation = Quaternion.Euler(0, 180, 0);
        delayTime = delayStartTime;
        this.addY = addY;
        isTarget = false;
        this.gameObject.GetComponent<UfoExplosion>().ExploActivate(parentPortal);

        transform.localScale = new Vector3(0f, 0f, 0f);
        scaleTime = 0;
        isScaleTime = false;

        isBalckHallActive = false;
        lerpValue = 0;
        ActiveFx();

        GetComponent<UfoExplosion>().Activate();        //비행기의 생명값을 관장하는 부분을 초기화 하기 위해 필요한 부분.
    }

    void ActiveFx()
    {
        engineFx = GameObject.Find("EngineFx").transform;

        //Debug.Log("Engine Fx Loaded01");
        //Debug.Log("Engine Fx Count ::: " + engineFx.childCount);
        engineFxCount = engineFx.childCount;
        GameObject fxChild = null;
        for (int i = 0; i < engineFxCount; i++)
        {
            fxChild = engineFx.GetChild(i).gameObject;
            if (fxChild.activeSelf == false)
            {
                //Debug.Log("여기는 오냐? ::: fxChild");
                fxChild.SetActive(true);
                engineParticle = fxChild;
                //Debug.Log("fxChild Name ::: " + fxChild.name);
                fxChild.transform.position = this.transform.position;
                fxChild.GetComponent<engineFxScript>().Activate(this.gameObject);
                //StartCoroutine(PlayEngine());
                //Debug.Log("왔다갔다!");
                break;
            }
        }
        //Debug.Log("Engine Fx Loaded02");
    }
}
