using UnityEngine;
using System.Collections;

public class SeedBulletMove : MonoBehaviour {

    public float bulletSpeed = -0.5f;
    public int crashDamage;

    GameObject flight;
    GameObject fuelSlider;
    SoundUiControlScript soundUiControlScript;
    ActivateScript activate;

   bool isBalckHallActive = false;
	// Use this for initialization
	void Start () {
        flight = GameObject.Find("PC/Flight");
        fuelSlider = GameObject.Find("FuelSlider");
        soundUiControlScript = GameObject.Find("GameManager").GetComponent<SoundUiControlScript>();
        activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();
    }
	
	// Update is called once per frame
    void Update()
    {

        //블랙홀이 작동을 시작하고 BalckHallActive() 메소드가 시작하지 않으면 이 아래 부분을 실행한다//
        if (BlackHoleBombScript.blackHallOn == true)
        {
            if (isBalckHallActive == false)
            {
                //한번 들어왔은 다시는 이 조건문 안으로 못들어오게 막아준다//
                isBalckHallActive = true;
                //골든웜홀 파괴모드로 들어간다//
                ExploEnd();
            }
        }
        else
        {
            transform.Translate(0, 0, bulletSpeed);

            if (transform.position.z < -10f)
                gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        switch (col.tag)
        {
            case "Player":
                if (flight && flight.activeSelf == true)
                {
                    GameObject.Find("GameManager").GetComponent<RedAlert>().StateChage(RedAlert.AlertState.attacked);

                    Debug.Log("::: 레이저랑 비행기 충돌 :::");
                    //보호막이 있을때와 수리기능 있을때와 아무보호기능이 없을때를 순서대로 검사해서 그에 맞게 처리해줌//
                    if (ValueDeliverScript.shieldEquip == true) //보호막 있을때 처리//
                    {
                        ValueDeliverScript.shieldEquip = false;
                        //상단 어시스트에 실드 아이콘이 보이는것 안보이게 처리//
                        GameObject.Find("AssistIcon").SetActive(false);
                        GameObject.Find("PC").GetComponent<PlayerMoveScript>().ShieldEquipStart();
                    }
                    //에너지가 얼마나 남았는지 검사하여 거기에 맞게 처리//
                    else if (ValueDeliverScript.fuelSize > 0)
                    {
                        Debug.Log("::: 비행기 폭파 :::");
                        fuelSlider.GetComponent<FuelSliderScript>().GageReduceVoid(crashDamage);
                        soundUiControlScript.PcExplo();									//폭발사운드. 적용.	
                    }
                }
                break;

            case "SuperPower":
            case "Bomb01":
            //case "Bomb":
            case "PcLaser":
            //case "SkillBullet":

            //case "Bomb03":
                ExploEnd();
                break;
        }
    }


    void ExploEnd()
    {
        activate.ExploActivation(transform.position, 01, gameObject.name); //피탄 이펙트 켜짐.

        soundUiControlScript.UfoExplo(); //폭파음재생.
        isBalckHallActive = false;
        gameObject.SetActive(false);
    }


    
}
