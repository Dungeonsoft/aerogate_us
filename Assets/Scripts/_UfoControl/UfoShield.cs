using UnityEngine;
using System.Collections;

public class UfoShield : UfoActivation
{
    //float scaleTime;
    //bool isScaleTime = false;

    GameObject fuelSlider;
    GameObject flight;
    SoundUiControlScript soundUiControlScript;
    ActivateScript activate;

    public int[] crashDamage;


    bool isBalckHallActive = false;

    //	UfoExplosion ufoExplosion;

    void Start()
    {
        fuelSlider = GameObject.Find("FuelSlider");
        flight = GameObject.Find("PC/Flight");
        soundUiControlScript = GameObject.Find("GameManager").GetComponent<SoundUiControlScript>();
        activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();

        //		ufoExplosion = this.gameObject.GetComponent<UfoExplosion>();
    }


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

    }


    void OnTriggerEnter(Collider col)
    {
       switch(col.tag)
        {
           case "Bullet":
           case "Missile":
               if (gameObject.activeSelf == true)
               {
                   GetComponent<AttackWhilteScript>().AttackWhilte();
                   col.gameObject.SetActive(false);
               }
            break;

           case "Player":
            if (flight && flight.activeSelf == true)
            {
                //보호막이 있을때와 수리기능 있을때와 아무보호기능이 없을때를 순서대로 검사해서 그에 맞게 처리해줌//
                if (ValueDeliverScript.shieldEquip) //보호막 있을때 처리//
                {
                    ValueDeliverScript.shieldEquip = false;
                    //상단 어시스트에 실드 아이콘이 보이는것 안보이게 처리//
                    GameObject.Find("AssistIcon").SetActive(false);
                    GameObject.Find("PC").GetComponent<PlayerMoveScript>().ShieldEquipStart();
                }
                //에너지가 얼마나 남았는지 검사하여 거기에 맞게 처리//
                else if (ValueDeliverScript.fuelSize > 0)
                {
                    fuelSlider.GetComponent<FuelSliderScript>().GageReduceVoid(crashDamage[ValueDeliverScript.portalUpLevel]);
                    soundUiControlScript.PcExplo();									//폭발사운드. 적용.	
                }
            }
            break;

           case "SuperPower":
           case "Bomb01":
           //case "Bomb":
           case "Bomb03":
           case "PcLaser":
            ExploEnd();
            break;
        }
    }


    private void ExploEnd()
    {
        activate.ExploActivation(transform.position, 01, gameObject.name); //피탄 이펙트 켜짐.

        soundUiControlScript.UfoExplo(); //폭파음재생.

        isBalckHallActive = false;
        gameObject.SetActive(false);
    }

}
