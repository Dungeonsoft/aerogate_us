using UnityEngine;
using System.Collections;

public class PlayerMoveScript : MonoBehaviour {

    float oriSpeed;
    float speed;
	public float xLimit = 13f;
	public int zRotLimit = 30;

	bool bOnMouseL;
	bool bOnMouseR;

    float spinballDestroySpeedUpPercent = 0;

    float superSpeed = 1f;
    float addSpeed = 0;
    float repairSpeed = 1;

    BombSkillGageScript bsGageScript;

    Color oriColor = new Color(1, 1, 1);
    Color changeColor = new Color(0.1f, 0.1f, 0.1f);

    Vector3 rotZero = new Vector3(0, 0, 0);
    Vector3 rotZ360 = new Vector3(0, 0, 360);

    void Awake()
    {
        bsGageScript = GameObject.Find("GameManager").GetComponent<BombSkillGageScript>();
    }

    public void OnSuperPowerSpeed()
    {
        superSpeed = 0.8f;
    }

    public void OffSuperPowerSpeed()
    {
        superSpeed = 1f;
    }

    void Start()
    {
        float addSpeed2 =0;

        int activeOper = ValueDeliverScript.activeOper;

        int upgradePointF00P03 = ValueDeliverScript.upgradePointF00P03;
        int upgradePointF01P03 = ValueDeliverScript.upgradePointF01P03;
        int upgradePointF02P03 = ValueDeliverScript.upgradePointF02P03;


        if (ValueDeliverScript.flightNumber == 1 && ValueDeliverScript.skinNumber == 5 && activeOper == 2)
        {
            addSpeed2 = 2 * ValueDeliverScript.skinLevel;
        }
        switch (ValueDeliverScript.flightNumber)
        {
            case 0:
                addSpeed = upgradePointF00P03 * ValueDeliverScript.speedPerUpoint;
                break;

            case 1:
                addSpeed = (addSpeed2 + upgradePointF01P03) * ValueDeliverScript.speedPerUpoint;
                break;

            case 2:
                addSpeed = upgradePointF02P03 * ValueDeliverScript.speedPerUpoint;
                break;
        }

        // 기본 속도 * 스토커스킨에서 reinforce08(파이널 파워업)장착시 늘려주는 속도 곱 + 강화포인트 추가로 인한 속도 증가 + 코만치 악마의 숨결 스킨 장착시 속도 증가부분.
        oriSpeed = ValueDeliverScript.flightSpeed[ValueDeliverScript.flightNumber] * (1 + ValueDeliverScript.itemReinforce08Effect) + addSpeed + ValueDeliverScript.comancheDeveilBreathAddSpeed;

    }

    public void RepairFlightSpeed(float val = 0.25f)
    {
        repairSpeed = val;
    }

    public void RepairEnd()
    {
        repairSpeed = 1f;
    }

	void Update () 
	{
        do
        {
            speed = oriSpeed * (1 + spinballDestroySpeedUpPercent) * superSpeed * repairSpeed;
            if ((bOnMouseL && !bOnMouseR) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(transform.position.x + (-speed * Time.deltaTime), 0, 0);
                transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, speed * Time.deltaTime * 10);
                IsPress();
            }
            else if ((bOnMouseR && !bOnMouseL) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), 0, 0);
                transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, -1f * speed * Time.deltaTime * 10);
                IsPress();
            }
            else
            {
                //transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, rotZero, 0.15f);

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.15f);


                if (transform.eulerAngles.z < 0.1)
                {
                    transform.eulerAngles = rotZero;
                }
            }

            if (Input.GetKey(KeyCode.Z))
            {
                bsGageScript.BombGageZero();
            }

            if (Input.GetKey(KeyCode.X))
            {
                bsGageScript.SkillGageZero();
            }
            break;
        } while (false);

        //bOnMouseR = false;
        //bOnMouseL = false;
	}

    #region 좌우버튼 늘렀을때 쓰이는 함수들
    float IsPlusMinus(float val) // 현재값의 음양을 판별하여 돌려준다.
	{
		if(val > 0)
		{
			return 1f;
		}
		else
		{
			return -1f;
		}
	}

    void OnPressLeft()
	{ 
		bOnMouseL = true; 
	}
	
	void OnPressRight()
	{
		bOnMouseR = true;
	} 

	void OnReleaseLeft()
	{ 
		bOnMouseL = false;
	}

	void OnReleaseRight()
	{ 
		bOnMouseR = false;
	}

    void IsPress()
    {

        if (Mathf.Abs(transform.position.x) > xLimit)
        {
            transform.position = new Vector3((xLimit * IsPlusMinus(transform.position.x)), 0, 0);
        }


        if (transform.eulerAngles.z < 180  && transform.eulerAngles.z > zRotLimit)
        {
            transform.eulerAngles = new Vector3(0, 0, zRotLimit);
            return;
        }

        if (transform.eulerAngles.z > 180 && transform.eulerAngles.z < (360 - zRotLimit))
        {
            transform.eulerAngles = new Vector3(0, 0, -zRotLimit);
            return;
        }
    }
    #endregion

    public bool newSuperPower = false;

    public SoundUiControlScript soundControl;

	public void SuperPowerReadyTag (float limitTime)
	{
        soundControl.EffectLaseBeam();
        this.tag = "SuperPower";
        transform.FindChild("ExtendPlayerBound").gameObject.tag = "SuperPower";



		StartCoroutine(SuperPower(limitTime));
	}

    IEnumerator SuperPower(float limitTime)
    {
        if (newSuperPower)
        {
            newSuperPower = false;
            yield break;
        }

        superSpeed = 0.8f;

        //StartCoroutine(BigSize());
        if (newSuperPower)
        {
            newSuperPower = false;
            yield break;
        }

        //StartCoroutine(SmallSize(limitTime-0.5f));
        yield return null;
    }

    //IEnumerator BigSize()
    //{
    //    Transform flight = transform.FindChild("Flight");
    //    Vector3 fScale = flight.localScale;
    //    Color fColor = flight.transform.FindChild("BodyBase").renderer.material.GetColor("_AddColor");
    //    Color redColor =  new Color (1,0,0,0);
    //    Color newColor;

    //    if (newSuperPower)
    //    {
    //        newSuperPower = false;
    //        yield break;
    //    }

    //    if (flight != null)
    //    {
    //        float val = 0;
    //        while (val < 1)
    //        {
    //            flight.localScale = Vector3.Lerp(fScale, new Vector3(1.3f, 1.3f, 1.3f), val);

    //            newColor = Color.Lerp(fColor, redColor, val);
    //            flight.transform.FindChild("BodyBase").renderer.material.SetColor("_AddColor", newColor);

    //            yield return null;
    //            val += Time.deltaTime * 2;

    //            if (newSuperPower)
    //            {
    //                newSuperPower = false;
    //                yield break;
    //            }

    //        }
    //        flight.transform.FindChild("BodyBase").renderer.material.SetColor("_AddColor", redColor);
    //        flight.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    //    }
    //}

    //IEnumerator SmallSize(float limitTime)
    //{
    //    float spendTime = 0;

    //    if (newSuperPower)
    //    {
    //        newSuperPower = false;
    //        yield break;
    //    }

    //    while (spendTime <= limitTime)
    //    {
    //        yield return null;
    //        spendTime += Time.deltaTime;
    //        if (newSuperPower)
    //        {
    //            newSuperPower = false;
    //            yield break;
    //        }
    //    }


    //    if (newSuperPower)
    //    {
    //        newSuperPower = false;
    //        yield break;
    //    }

    //    Transform flight = transform.FindChild("Flight");
    //    if (flight != null)
    //    {
    //        Vector3 fScale = flight.localScale;
    //        Color fColor = flight.transform.FindChild("BodyBase").renderer.material.GetColor("_AddColor");
    //        Color wColor = new Color(1, 1, 1, 0);
    //        Color newColor;

    //        float val = 0;
    //        while (val < 1)
    //        {
    //            flight.localScale = Vector3.Lerp(fScale, new Vector3(1f, 1f, 1f), val);

    //            newColor = Color.Lerp(fColor, wColor, val);
    //            flight.transform.FindChild("BodyBase").renderer.material.SetColor("_AddColor", newColor);

    //            yield return null;
    //            val += Time.deltaTime * 2;

    //            if (newSuperPower)
    //            {
    //                newSuperPower = false;
    //                yield break;
    //            }
    //        }
    //        flight.transform.FindChild("BodyBase").renderer.material.SetColor("_AddColor", wColor);
    //        flight.localScale = new Vector3(1,1,1);

    //        superSpeed = 1f;
    //        this.tag = "Player";
    //        transform.FindChild("ExtendPlayerBound").tag = "PlayerEtc";

    //    }
    //}


    public void DefenceItemMinus()
    {
        StartCoroutine(DefenceItemMinusIE());
    }


    //피격시 수리기능이 남아 있을때 작동하는 부분. 
    public IEnumerator DefenceItemMinusIE()
    {
        Debug.Log("DefenceItemMinus 000");

        transform.FindChild("RepairFx").gameObject.SetActive(true);    //연기효과 켬. 보이게 함//
        GameObject.Find("Anchor").transform.FindChild("RepairAnim").gameObject.SetActive(true);  //스패너 켜고 애니 보이게함//
        GameObject.Find("Anchor").transform.FindChild("RepairAnim").GetComponent<CriticalHitScript>().Activate(GameObject.Find("PC"));
        transform.FindChild("ShieldMesh01").gameObject.SetActive(false);  //쉴드 아이템이 있으면 꺼줌//
        Debug.Log("DefenceItemMinus 001");
        tag = "Unbeatable";   //일차로 총알을 맞지 않게 세팅.

        StartCoroutine(repairBulletTime());

        //3초를 쉼 이동안 리페어 애니메이션을 다 끝마침.
        yield return new WaitForSeconds(3f);

        Debug.Log("DefenceItemMinus 002");
        transform.FindChild("RepairFx").gameObject.SetActive(false);
        //GameObject.Find("Anchor").transform.FindChild("RepairAnim").gameObject.SetActive(false);
        Debug.Log("DefenceItemMinus 003");

        Component[] unbeatableScripts;
        unbeatableScripts = GameObject.Find("PC").GetComponentsInChildren<UnbeatableScript>();
        foreach (UnbeatableScript unBeat in unbeatableScripts)
        {
            unBeat.UnbeatableStart(3f);//보호막 깨지고 무적 타임.
        }
        Debug.Log("DefenceItemMinus 004");
    }

    IEnumerator repairBulletTime()
    {
        RepairFlightSpeed();
        GameObject.Find("GameManager").GetComponent<BulletControlScript>().RepairBulletIntervalChange();
        yield return new WaitForSeconds(3f);
        RepairEnd();
        GameObject.Find("GameManager").GetComponent<BulletControlScript>().DefaultBulletIntervalTime();
    }




    //보호막이 있을때 작동하는 부분.
    public void ShieldEquipStart()
    {
        Debug.Log("Shield Equip Start");
        transform.FindChild("ShieldMesh01").gameObject.SetActive(false);  //쉴드 아이템이 있으면 꺼줌//

        Component[] unbeatableScripts;
        unbeatableScripts = GameObject.Find("PC").GetComponentsInChildren<UnbeatableScript>();
        foreach (UnbeatableScript unBeat in unbeatableScripts)
        {
            unBeat.UnbeatableStart(3f);//보호막 깨지고 무적 타임.
        }
        Debug.Log("DefenceItemMinus 004");
    }

    //비행기 격추시 작동하는 부분.
    public void FlightExplo()
    {
        Debug.Log("Flight Explosion!!!");
        tag = "Unbeatable";   //일차로 총알을 맞지 않게 세팅.
        Debug.Log("++++++++++++++ 비행기파괴 총알발사 중지 ++++++++++++++++");
        GameObject.Find("GameManager").GetComponent<BulletControlScript>().QpcExploFunc();  //총알이 발사되는걸 막는다.
        GetComponent<PlayerMoveScript>().RepairFlightSpeed(0f); //비행기 움직임 속도;

        transform.FindChild("RepairFx").gameObject.SetActive(true);    //연기효과 켬. 보이게 함//
        StartCoroutine(ChColor(oriColor, changeColor)); //색을 어둡게 바꿈//
    }

    IEnumerator ChColor(Color aClr, Color bClr)
    {
        Material fMat = transform.FindChild("Flight/BodyBase").renderer.material;
        //Debug.Log("Material Name ::: " + fMat.name);
        Color addColor = new Color(1, 1, 1);
        float val = 0;
        while (val < 1)
        {
            addColor = Color.Lerp(aClr, bClr, val);
            fMat.SetColor("_AddColor", addColor);
            //Debug.Log("Color ::: " + fMat.GetColor("_AddColor"));
            //Debug.Log("Lerp Value ::: " + val);
            yield return null;
            val += Time.deltaTime * 2;
        }
        fMat.SetColor("_AddColor", bClr);
        yield return null;
    }

    public IEnumerator Rebirth()
    {
        Debug.Log("DefenceItemMinus 000");

        //파괴상태가 끝났음을 알려줌//
        //GameObject.Find("GameManager").GetComponent<BulletControlScript>().QpcExploFunc();
        StartCoroutine(repairBulletTime());

        GameObject.Find("Anchor").transform.FindChild("RepairAnim").gameObject.SetActive(true);  //스패너 켜고 애니 보이게함//
        GameObject.Find("Anchor").transform.FindChild("RepairAnim").GetComponent<CriticalHitScript>().Activate(GameObject.Find("PC") , true);
        tag = "Unbeatable";   //일차로 총알을 맞지 않게 세팅.

        yield return new WaitForSeconds(3f);

        GameObject.Find("GameManager").GetComponent<SuperPowerControlScript>().OnLaserBeam();

    }

}
