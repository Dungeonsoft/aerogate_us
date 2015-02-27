using UnityEngine;
using System.Collections;

public class UfoSpinball : UfoActivation 
{

	
	Vector3 nowPosition;
	float randomAngle; // 최초 설정되어 들어온 회전값을 저장.
	public bool isBottomOpen = false;
	float speed;
	float intervalValue;
	public float minSpeed = 10;
	public float maxSpeed = 25;
	public float veloSpeed = 1;

	float scaleTime;
	bool isScaleTime = false;

	bool isBalckHallActive = false;
    float lerpValue;
    float lerpValueScl;
    bool isLerpValueSclUp = false;
    GameObject fxEdge;


	void Awake ()
    {
        isBalckHallActive = false;
        if (ValueDeliverScript.isSelectSpecial == true)
        {
            maxSpeed = maxSpeed * ValueDeliverScript.specialSpeed;
        }

        fxEdge = transform.FindChild("ufoSpinball/FxEdge").gameObject;
	}

	
	// Update is called once per frame
    void Update()
    {           
        //블랙홀이 작동을 시작하고 아직 사라지지 않았으면 이부분을 실행한다/
        if (isBalckHallActive == true)
        {
            transform.position = Vector3.Lerp(posAtBlkHall, new Vector3(0, 0, 18), lerpValue);
            transform.localScale = Vector3.Lerp(sclAtBlkHall, new Vector3(0, 0, 0), lerpValueScl);
            //transform.localScale = Vector3.Lerp(sclAtBlkHall, new Vector3(0, 0, 0), lerpValue);

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

        else if (isBalckHallActive == false || transform.localScale.x < 1)
        {

            if (isScaleTime == false)
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

            nowPosition = transform.position;

            //반사각 조절.
            if (nowPosition.x >= 13)
            {
                //Debug.Log("Bounce!!! \n      Bounce!!!");
                fxEdge.animation.Play("SpinballBounceAnim01");
                //Debug.Log("Bounce!!! \n      Bounce!!!");

                isVector(randomAngle); // z rotation 값이 180을 넘었는지 안넘었는지 확인하여 넘었으면 값을 재조정하여 180 이하로 맞추어줌.(절대값기준).

                transform.position = new Vector3(13, transform.position.y, transform.position.z);

                if (randomAngle > -90)
                {
                    randomAngle = randomAngle * -1;
                    transform.rotation = Quaternion.Euler(0, (randomAngle + 180), 0);
                }
                else
                {
                    randomAngle = randomAngle - ((180 + randomAngle) * 2);
                    transform.rotation = Quaternion.Euler(0, (randomAngle + 180), 0);
                }
            }

            else if (nowPosition.x <= -13)
            {
                //Debug.Log("Bounce!!! \n      Bounce!!!");
                fxEdge.animation.Play("SpinballBounceAnim01");
                //Debug.Log("Bounce!!! \n      Bounce!!!");

                isVector(randomAngle); // z rotation 값이 180을 넘었는지 안넘었는지 확인하여 넘었으면 값을 재조정하여 180 이하로 맞추어줌.(절대값기준).

                transform.position = new Vector3(-13, transform.position.y, transform.position.z);

                if (randomAngle < 90)
                {
                    randomAngle = randomAngle * -1;
                    transform.rotation = Quaternion.Euler(0, (randomAngle + 180), 0);
                }
                else
                {
                    randomAngle = randomAngle + ((180 - randomAngle) * 2);
                    transform.rotation = Quaternion.Euler(0, (randomAngle + 180), 0);
                }
            }

            if (nowPosition.z >= 35)
            {
                //Debug.Log("Bounce!!! \n      Bounce!!!");
                fxEdge.animation.Play("SpinballBounceAnim01");
                //Debug.Log("Bounce!!! \n      Bounce!!!");
                isVector(randomAngle); // z rotation 값이 180을 넘었는지 안넘었는지 확인하여 넘었으면 값을 재조정하여 180 이하로 맞추어줌.(절대값기준).

                transform.position = new Vector3(transform.position.x, transform.position.y, 35); // 몹이 범위값을 넘어가지 않게 설정.

                if (randomAngle > 0)
                {
                    randomAngle = 180 - randomAngle;
                    transform.rotation = Quaternion.Euler(0, (randomAngle + 180), 0);
                }
                else
                {
                    randomAngle = 180 - randomAngle;
                    transform.rotation = Quaternion.Euler(0, (randomAngle + 180), 0);
                }

            }

            else if (nowPosition.z <= 0 && !isBottomOpen)
            {
                //Debug.Log("Bounce!!! \n      Bounce!!!");
                fxEdge.animation.Play("SpinballBounceAnim01");
                //Debug.Log("Bounce!!! \n      Bounce!!!");

                isVector(randomAngle); // z rotation 값이 180을 넘었는지 안넘었는지 확인하여 넘었으면 값을 재조정하여 180 이하로 맞추어줌.(절대값기준).

                transform.position = new Vector3(transform.position.x, transform.position.y, 0);

                if (randomAngle < 0)
                {
                    randomAngle = 180 - randomAngle;
                    transform.rotation = Quaternion.Euler(0, (randomAngle + 180), 0);
                }
                else
                {
                    randomAngle = 180 - randomAngle;
                    transform.rotation = Quaternion.Euler(0, (randomAngle + 180), 0);
                }
            }


            intervalValue += Time.deltaTime / veloSpeed;
            speed = Mathf.Lerp(minSpeed, maxSpeed, intervalValue);
            //		Debug.Log ("speed : "+speed);
            transform.Translate(0, 0, speed * Time.deltaTime); //속도조절이 필요함. 처음에는 천천히 점점 빨라지게.
        }
    }// 업뎃 종료.



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

	
	void isVector(float rAngle)
	{
		if( Mathf.Abs (rAngle) > 180)
		{
			int vector;
			if(rAngle > 0)	vector = -1;
			else vector = 1;

			this.randomAngle = (360 - Mathf.Abs (rAngle)) * vector ;
		}
	}	

	
	public override void Activate(float delayStartTime , float addY , float randomAngle , GameObject parentPortal)
	{
		ValueDeliverScript.enemyInGame.Add (this.gameObject);

		transform.rotation = Quaternion.Euler (0,180,0);
//		transform.localPosition = new Vector3(0,0,0);
		transform.rotation *= Quaternion.Euler(0 , randomAngle, 0);
		this.randomAngle =randomAngle;
		this.gameObject.GetComponent<UfoExplosion>().ExploActivate(parentPortal);
		intervalValue = 0;

		transform.localScale= new Vector3(0f,0f,0f);
		scaleTime = 0;
		isScaleTime = false;

		isBalckHallActive = false;
		lerpValue = 0;

        //Debug.Log("This Object Name Is " + transform.FindChild("ufoSpinball/FxEdge").name);

        transform.FindChild("ufoSpinball/FxEdge").renderer.material.SetColor("_TintColor", new Color(0, 76 / 255f, 1, 0.5f));   //띠 이펙트의 색깔을 기본색인 파란색으로 정의해줌.

        GetComponent<UfoExplosion>().Activate();        //비행기의 생명값을 관장하는 부분을 초기화 하기 위해 필요한 부분.
	}


}
