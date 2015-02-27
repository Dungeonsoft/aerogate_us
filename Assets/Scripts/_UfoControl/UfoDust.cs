using UnityEngine;
using System.Collections;

public class UfoDust : UfoActivation 
{
	float startTime;
	float scaleTime;
	bool isScaleTime = false;
	float changeTranValue;

	public float dustSpeed = 10f;
//	UfoExplosion ufoExplosion;

	bool isBalckHallActive = false;
	float lerpValue;
    float lerpValueScl;
    bool isLerpValueSclUp = false;

    void Awake()
    {
        isBalckHallActive = false;

        if (ValueDeliverScript.isSelectSpecial == true)
        {
            transform.GetChild(0).animation["RotZSMove"].speed = ValueDeliverScript.specialSpeed;
        }
    }

    void Update()
    {        //블랙홀이 작동을 시작하고 아직 사라지지 않았으면 이부분을 실행한다/
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

        //일반적인 상황에서 위치가 화면을 벗어났을때//
        else if (transform.GetChild(0).position.z < -7)
        {
            StartCoroutine(GetComponent<UfoExplosion>().Naturaldestroy());
        }
    }

    Vector3 posAtBlkHall;
    Vector3 sclAtBlkHall;

    //블랙홀 핵폭탄이 터졌을때 이 함수가 호출되어 isBalckHallActive 변수가 true가 된다.//
    //이후부터는 움직임이 블랙홀로 빨려가는 모양이 된다.
    void BalckHallActive()
    {
        transform.GetChild(0).animation.Stop("RotZSMove");

        posAtBlkHall = transform.position;
        sclAtBlkHall = transform.localScale*1.5f;
        isBalckHallActive = true;
        lerpValue = 0;
        lerpValueScl = 0.333f;
        isLerpValueSclUp = false;
    }


	public override void Activate(float delayStartTime , float addY , float randomAngle , GameObject parentPortal)	
	{
		ValueDeliverScript.enemyInGame.Add (this.gameObject);

		transform.rotation = Quaternion.Euler (0,180,0);
		startTime = Time.timeSinceLevelLoad;

		this.gameObject.GetComponent<UfoExplosion>().ExploActivate(parentPortal);	

		transform.localScale= new Vector3(1.5f,1.5f,1.5f);
        transform.GetChild(0).localScale = new Vector3(0f, 0f, 0f);
		scaleTime = 0;
		isScaleTime = false;

		isBalckHallActive = false;
		lerpValue = 0;

        GetComponent<UfoExplosion>().Activate();        //비행기의 생명값을 관장하는 부분을 초기화 하기 위해 필요한 부분.
        transform.GetChild(0).animation.Play("RotZSMove");

        StartCoroutine(ScaleObj());

	}

    void LateUpdate()
    {
        GetComponent<BoxCollider>().center = transform.GetChild(0).localPosition;
    }

    IEnumerator ScaleObj()
    {
        scaleTime = 0;
        while (scaleTime < 1f)
        {
            transform.GetChild(0).localScale = new Vector3(scaleTime, scaleTime, scaleTime);
            scaleTime += Time.deltaTime * 2;
            yield return null;
        }
            transform.GetChild(0).localScale = new Vector3(1f, 1f, 1f);
            isScaleTime = true;
    }
}
