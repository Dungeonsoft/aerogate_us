using UnityEngine;
using System.Collections;

public class InGameOnLoadScript : MonoBehaviour
{
    //인게임시작시 구입한 이큅(아이템)들의 화면내 표현을 담당하는 스크립트

    public GameObject bombButton00;
    public GameObject bombButton01;
    public GameObject bombButton02;
    public GameObject bombBtnRollingEffect;

    public GameObject equipReinforceIcon;
    public GameObject equipAssistIcon;
    public GameObject equipBoostIcon;

    GameObject gameManager;
    GameObject bodyBase;


    float bombRecharge = 0;

    public float[] itemReinforce08SkinEffect;

    // Use this for initialization
    void Awake()
    {
        Debug.Log("::::::::: InGameOnLoadScript :::::::: Awake :::::::::::::::::");
        Debug.Log("::::::::: InGameOnLoadScript :::::::: Awake :::::::::::::::::");
        Debug.Log("::::::::: InGameOnLoadScript :::::::: Awake :::::::::::::::::");
        Debug.Log("::::::::: InGameOnLoadScript :::::::: Awake :::::::::::::::::");
        Debug.Log("::::::::: InGameOnLoadScript :::::::: Awake :::::::::::::::::");
        Debug.Log("::::::::: InGameOnLoadScript :::::::: Awake :::::::::::::::::");

        if (ValueDeliverScript.isTutComplete != 2)
        {
            Debug.Log("::::::::: InGameOnLoadScript :::::::: isGuestPlay :::::::::::::::::");
            Debug.Log("::::::::: InGameOnLoadScript :::::::: isTutComplete :::::::::::::::::" + ValueDeliverScript.isTutComplete);
            ValueDeliverScript.activeBomb = 5;

            bombButton01.SetActive(true);
            bombButton00.GetComponent<UIFilledSprite>().spriteName = "bt_bomb_n";
            //bombButton00.SetActive(false);
            bombButton01.GetComponent<UIFilledSprite>().spriteName = "bt_bomb_o";
            bombButton02.GetComponent<UISprite>().spriteName = "bt_bomb_n";

            equipReinforceIcon.SetActive(false);
            equipAssistIcon.SetActive(false);
            ValueDeliverScript.SaveGameData();

            //GameObject.Find("RepairIcon").SetActive(false);
            //GameObject.Find("RepairIconBG").SetActive(false);

            return;
        }

        float specialBombRechargeDecrease = 0f;
        if (ValueDeliverScript.isSelectSpecial)
        {
            specialBombRechargeDecrease = ValueDeliverScript.specialBombRechargeDecrease;
        }

        int tempDecreaseBombTime = 0;
        if (ValueDeliverScript.flightNumber == 2)
        {
            tempDecreaseBombTime = -3;
        }

        bombRecharge = ValueDeliverScript.bombRecycle + specialBombRechargeDecrease + tempDecreaseBombTime; //폭탄 회복시간.

        gameManager = GameObject.Find("GameManager");

        #region 폭탄 인게임내 세팅.
        int activeBomb = ValueDeliverScript.activeBomb;
        switch (activeBomb)
        {
            case 0: //폭탄 구매 자체가 이루어지지 않았으므로 폭탄 버튼을 꺼준다.
                bombButton00.SetActive(false);
                bombButton01.GetComponent<UIFilledSprite>().enabled = false;
                //						bombButton02.GetComponent<UISprite> ().enabled = false;
                bombButton02.GetComponent<UISprite>().spriteName = "bt_bomb_n";
                bombBtnRollingEffect.SetActive(false);
                bombButton01.transform.parent.gameObject.GetComponent<BoxCollider>().enabled = false;
                //ValueDeliverScript.SaveGameData();
                break;
            case 1:
                if (ValueDeliverScript.EquipBomb01 > 0)
                {
                    bombButton01.SetActive(true);
                    ValueDeliverScript.EquipBomb01 = ValueDeliverScript.EquipBomb01 - 1;
                    bombButton00.GetComponent<UIFilledSprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_n");
                    //bombButton00.SetActive(false);
                    bombButton01.GetComponent<UIFilledSprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_o");
                    bombButton02.GetComponent<UISprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_n");
                }
                else
                {
                    bombButton01.GetComponent<UIFilledSprite>().enabled = false;    //이 폭탄을 구매한적이 없으면 폭탄 버튼을 꺼준다.
                    bombBtnRollingEffect.SetActive(false);
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 2:
                if (ValueDeliverScript.EquipBomb02 > 0)
                {
                    bombButton01.SetActive(true);
                    ValueDeliverScript.EquipBomb02 = ValueDeliverScript.EquipBomb02 - 1;
                    bombButton00.GetComponent<UIFilledSprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_n");
                    //bombButton00.SetActive(false);
                    bombButton01.GetComponent<UIFilledSprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_o");
                    bombButton02.GetComponent<UISprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_n");
                }
                else
                {
                    bombButton01.GetComponent<UIFilledSprite>().enabled = false;    //이 폭탄을 구매한적이 없으면 폭탄 버튼을 꺼준다.
                    bombBtnRollingEffect.SetActive(false);
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 3:
                if (ValueDeliverScript.EquipBomb03 > 0)
                {
                    bombButton01.SetActive(true);
                    ValueDeliverScript.EquipBomb03 = ValueDeliverScript.EquipBomb03 - 1;
                    bombButton00.GetComponent<UIFilledSprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_n");
                    //bombButton00.SetActive(false);
                    bombButton01.GetComponent<UIFilledSprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_o");
                    bombButton02.GetComponent<UISprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_n");
                }
                else
                {
                    bombButton01.GetComponent<UIFilledSprite>().enabled = false;    //이 폭탄을 구매한적이 없으면 폭탄 버튼을 꺼준다.
                    bombBtnRollingEffect.SetActive(false);
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 4:
                if (ValueDeliverScript.EquipBomb04 > 0)
                {
                    bombButton01.SetActive(true);
                    ValueDeliverScript.EquipBomb04 = ValueDeliverScript.EquipBomb04 - 1;
                    bombButton00.GetComponent<UIFilledSprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_n");
                    //bombButton00.SetActive(false);
                    bombButton01.GetComponent<UIFilledSprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_o");
                    bombButton02.GetComponent<UISprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_n");
                }
                else
                {
                    bombButton01.GetComponent<UIFilledSprite>().enabled = false;    //이 폭탄을 구매한적이 없으면 폭탄 버튼을 꺼준다.
                    bombBtnRollingEffect.SetActive(false);
                }

                //ValueDeliverScript.SaveGameData();
                break;
            case 5:
                if (ValueDeliverScript.EquipBomb05 > 0)
                {
                    bombButton01.SetActive(true);
                    ValueDeliverScript.EquipBomb05 = ValueDeliverScript.EquipBomb05 - 1;
                    bombButton00.GetComponent<UIFilledSprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_n");
                    //bombButton00.SetActive(false);
                    bombButton01.GetComponent<UIFilledSprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_o");
                    bombButton02.GetComponent<UISprite>().spriteName = ValueDeliverScript.bombSpriteName[activeBomb].Replace("icon_equip_bomb_big", "bt_bomb_n");
                }
                else
                {
                    bombButton01.GetComponent<UIFilledSprite>().enabled = false;    //이 폭탄을 구매한적이 없으면 폭탄 버튼을 꺼준다.
                    bombBtnRollingEffect.SetActive(false);
                }
                //ValueDeliverScript.SaveGameData();
                break;

        }
        #endregion

        #region 강화품 인게임내 세팅.
        int activeReinforce = ValueDeliverScript.activeReinforce;
        switch (activeReinforce)
        {
            case 0:
                equipReinforceIcon.SetActive(false);
                //ValueDeliverScript.SaveGameData();
                break;
            case 1:		//기체의 공격력을 50% 증가시킵니다.
                if (ValueDeliverScript.EquipReinforce01 > 0)
                {
                    ValueDeliverScript.EquipReinforce01 = (ValueDeliverScript.EquipReinforce01 - 1);
                    equipReinforceIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.reinforceSpriteName[activeReinforce].Replace("big", "small");
                    ValueDeliverScript.flightAttackPower = 0.5f;    //비행기의 공경력을 50% 증가시킨다.

                    if (ValueDeliverScript.flightNumber == 0 && ValueDeliverScript.skinNumber == 5)
                        ValueDeliverScript.flightAttackPower += 0.3f + (ValueDeliverScript.skinLevel * 0.02f);
                }
                //ValueDeliverScript.SaveGameData();
                break;

            case 2:		//기체의 공격력을 50%, 연사속도를 20%증가시킵니다.
                if (ValueDeliverScript.EquipReinforce02 > 0)
                {
                    ValueDeliverScript.EquipReinforce02 = (ValueDeliverScript.EquipReinforce02 - 1);
                    equipReinforceIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.reinforceSpriteName[activeReinforce].Replace("big", "small");
                    ValueDeliverScript.flightAttackPower = 0.5f;    //총알 발사 속도의 인터벌을 반으로 줄인다.
                    ValueDeliverScript.flightAttackSpeed = 0.2f;    //총알 발사 속도의 인터벌을 20% 줄인다.

                    if (ValueDeliverScript.flightNumber == 2 && ValueDeliverScript.skinNumber == 1)
                    {
                        ValueDeliverScript.flightAttackPower += 0.3f + 0.01f * ValueDeliverScript.skinLevel;
                        ValueDeliverScript.flightAttackSpeed += 0.1f + 0.01f * ValueDeliverScript.skinLevel;
                    }
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 3:		//10초 마다 스핀볼이 추가로 등장하고 스핀볼에 대한 피해량이 100% 증가합니다. dartApearPer = 0 dustApearPer = 1 spinballApearPer = 2 shieldApearPer = 3
                if (ValueDeliverScript.EquipReinforce03 > 0)
                {
                    ValueDeliverScript.EquipReinforce03 = (ValueDeliverScript.EquipReinforce03 - 1);
                    equipReinforceIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.reinforceSpriteName[activeReinforce].Replace("big", "small");
                    ValueDeliverScript.targetUfoType = 1;   //이값에 대한것은 UfoExplosion.cs 64줄에서 80줄까지 참고
                    ValueDeliverScript.detectorType = 2;

                    if (ValueDeliverScript.flightNumber == 1 && ValueDeliverScript.skinNumber == 1)
                    {
                        GameObject.Find("GameManager").GetComponent<BombSkillGageScript>().AddSkillGageValue(100 * ValueDeliverScript.skillLevel);
                    }
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 4:		//10초 마다 다트가 추가로 등장하고 다트에 대한 피해량이 100% 증가합니다.
                if (ValueDeliverScript.EquipReinforce04 > 0)
                {
                    ValueDeliverScript.EquipReinforce04 = (ValueDeliverScript.EquipReinforce04 - 1);
                    equipReinforceIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.reinforceSpriteName[activeReinforce].Replace("big", "small");
                    ValueDeliverScript.targetUfoType = 2;   //이값에 대한것은 UfoExplosion.cs 64줄에서 80줄까지 참고
                    ValueDeliverScript.detectorType = 0;

                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 5:		//10초 마다 더스트가 추가로 등장하고 더스트에 대한 피해량이 100% 증가합니다.
                if (ValueDeliverScript.EquipReinforce05 > 0)
                {
                    ValueDeliverScript.EquipReinforce05 = (ValueDeliverScript.EquipReinforce05 - 1);
                    equipReinforceIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.reinforceSpriteName[activeReinforce].Replace("big", "small");
                    ValueDeliverScript.targetUfoType = 3;   //이값에 대한것은 UfoExplosion.cs 64줄에서 80줄까지 참고
                    ValueDeliverScript.detectorType = 1;
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 6:		//10초 마다 쉴드가 추가로 등장하고 쉴드에 대한 피해량이 100% 증가합니다.
                if (ValueDeliverScript.EquipReinforce06 > 0)
                {
                    ValueDeliverScript.EquipReinforce06 = (ValueDeliverScript.EquipReinforce06 - 1);
                    equipReinforceIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.reinforceSpriteName[activeReinforce].Replace("big", "small");
                    ValueDeliverScript.targetUfoType = 4;   //이값에 대한것은 UfoExplosion.cs 64줄에서 80줄까지 참고
                    ValueDeliverScript.detectorType = 3;
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 7:		//적 공격시 일정 확률로 3배의 피해를 입힙니다.
                if (ValueDeliverScript.EquipReinforce07 > 0)
                {
                    ValueDeliverScript.EquipReinforce07 = (ValueDeliverScript.EquipReinforce07 - 1);
                    equipReinforceIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.reinforceSpriteName[activeReinforce].Replace("big", "small");
                    ValueDeliverScript.isCriticalExel = true;
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 8:     //5단계 파워업 상태로 게임을 시작할 수 있습니다.
                if (ValueDeliverScript.EquipReinforce08 > 0)
                {
                    ValueDeliverScript.EquipReinforce08 = (ValueDeliverScript.EquipReinforce08 - 1);
                    equipReinforceIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.reinforceSpriteName[activeReinforce].Replace("big", "small");
                    gameManager.GetComponent<BulletControlScript>().ActiveBoost01();	//부스트1이 실제 게임에 적용되도록 함수 실행.


                    if (ValueDeliverScript.flightNumber == 0 && ValueDeliverScript.skinNumber == 2)
                    {
                        float itemAddSpeed = 0.10f;
                        if (ValueDeliverScript.skinLevel != 10)
                        {
                            itemAddSpeed = 0.10f + ((ValueDeliverScript.skinLevel - 1) * 0.01f);   //매 레벨마다 2퍼센트씩 증가해준다.
                        }
                        else if (ValueDeliverScript.skinLevel == 10)
                        {
                            itemAddSpeed = 0.2f;
                        }
                        ValueDeliverScript.itemReinforce08Effect = itemAddSpeed;
                    }
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 9:
                if (ValueDeliverScript.EquipReinforce09 > 0)
                {
                    ValueDeliverScript.EquipReinforce09 = (ValueDeliverScript.EquipReinforce09 - 1);
                    equipReinforceIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.reinforceSpriteName[activeReinforce].Replace("big", "small");
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 10:
                if (ValueDeliverScript.EquipReinforce10 > 0)
                {
                    ValueDeliverScript.EquipReinforce10 = (ValueDeliverScript.EquipReinforce10 - 1);
                    equipReinforceIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.reinforceSpriteName[activeReinforce].Replace("big", "small");
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 11:
                if (ValueDeliverScript.EquipReinforce11 > 0)
                {
                    ValueDeliverScript.EquipReinforce11 = (ValueDeliverScript.EquipReinforce11 - 1);
                    equipReinforceIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.reinforceSpriteName[activeReinforce].Replace("big", "small");
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 12:
                if (ValueDeliverScript.EquipReinforce12 > 0)
                {
                    ValueDeliverScript.EquipReinforce12 = (ValueDeliverScript.EquipReinforce12 - 1);
                    equipReinforceIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.reinforceSpriteName[activeReinforce].Replace("big", "small");
                }
                //ValueDeliverScript.SaveGameData();
                break;
        }
        #endregion

        #region 보조품 인게임내 세팅.
        int activeAssist = ValueDeliverScript.activeAssist;

        switch (activeAssist)
        {
            case 0:
                equipAssistIcon.SetActive(false);
                break;
            case 1:		//기체의 보호막을 생성하여 공격을 \n1회 무효화 시킵니다.
                if (ValueDeliverScript.EquipAssist01 > 0)
                {
                    ValueDeliverScript.EquipAssist01 = (ValueDeliverScript.EquipAssist01 - 1);
                    //								equipAssistIcon.GetComponent<UISprite> ().spriteName = "icon_equip_sub_small_1";
                    equipAssistIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.assistSpriteName[activeAssist].Replace("big", "small");
                    ValueDeliverScript.shieldEquip = true;  //방패가 있다는 것을 기록한다.
                    GameObject.Find("PC").transform.FindChild("ShieldMesh01").gameObject.SetActive(true);

                    if (ValueDeliverScript.flightNumber == 2 && ValueDeliverScript.skinNumber == 5)
                    {
                        ValueDeliverScript.skin02_05Effect2 = 2f + 0.1f * ValueDeliverScript.skinLevel;
                    }
                }
                //ValueDeliverScript.SaveGameData();
                break;
            //case 2:		//기체주변에 자기장을 방출하여 범위내에 \n드롭되는 모든 코인을 획득합니다.
            //    if (ValueDeliverScript.EquipAssist02 > 0)
            //    {
            //        ValueDeliverScript.EquipAssist02 = (ValueDeliverScript.EquipAssist02 - 1);
            //        //								equipAssistIcon.GetComponent<UISprite> ().spriteName = "icon_equip_sub_small_2";
            //        equipAssistIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.assistSpriteName[activeAssist].Replace("big", "small");
            //        gameManager.GetComponent<MagnetScript>().extendMagnetRadius = 10f;	//자석 아이템의 범위를 지정해준다.
            //        gameManager.GetComponent<MagnetScript>().sphereCollider.radius = gameManager.GetComponent<MagnetScript>().extendMagnetRadius;
            //        //gameManager.GetComponent<MagnetScript>().ItemMagnet();

            //        if (ValueDeliverScript.flightNumber == 1 && ValueDeliverScript.skinNumber == 2)
            //        {
            //            ValueDeliverScript.itemMagnetEffect = 0.5f + (0.02f * ValueDeliverScript.skinLevel);
            //        }

            //    }
                //Debug.Log("Magnet Radius ::: " + gameManager.GetComponent<MagnetScript>().sphereCollider.radius);
                //ValueDeliverScript.SaveGameData();
                //break;
            case 3:		//핵폭탄의 재사용 대기시간을 5초 감소시킵니다.
                if (ValueDeliverScript.EquipAssist03 > 0)
                {
                    ValueDeliverScript.EquipAssist03 = (ValueDeliverScript.EquipAssist03 - 1);
                    equipAssistIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.assistSpriteName[activeAssist].Replace("big", "small");

                    float bombDecreaseCoolTime = 5;
                    //포커 폭발의왕 스킨(3번스킨) 장착시 재사용 대기시간 감소 추가.
                    if (ValueDeliverScript.flightNumber == 0 && ValueDeliverScript.skinNumber == 3)
                    {
                        bombDecreaseCoolTime += 3 + (0.2f * ValueDeliverScript.skinLevel);
                    }


                    gameManager.GetComponent<BombSkillGageScript>().BombRechargeSubtration(bombDecreaseCoolTime);  //핵폭탄의 재사용 대기시간을 5초 감소시킵니다.

                    //Debug.Log("        gameManager.GetComponent<BombSkillGageScript>().BombRechargeSubtration(5);  //핵폭탄의 재사용 대기시간을 5초 감소시킵니다.");
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 4:		//스킬 사용시 25%의 스킬게이지를 유지해줍니다.
                if (ValueDeliverScript.EquipAssist04 > 0)
                {
                    ValueDeliverScript.EquipAssist04 = (ValueDeliverScript.EquipAssist04 - 1);
                    equipAssistIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.assistSpriteName[activeAssist].Replace("big", "small");
                    gameManager.GetComponent<BombSkillGageScript>().AddItemSkillGageValue(2500);	//스킬폭탄의 게이지를 추가해준 수치만큼부터 시작하게 해줌(만분률).

                    if (ValueDeliverScript.flightNumber == 1 && ValueDeliverScript.skinNumber == 3)
                    {
                        ValueDeliverScript.Item04Effect = 20 + 1 * ValueDeliverScript.skinLevel;
                    }
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 5:     //인스턴트 미션 완료시 2마리의 윙박스가 등장합니다.
                if (ValueDeliverScript.EquipAssist05 > 0)
                {
                    ValueDeliverScript.EquipAssist05 = (ValueDeliverScript.EquipAssist05 - 1);
                    equipAssistIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.assistSpriteName[activeAssist].Replace("big", "small");
                    ValueDeliverScript.wingboxDouble = true;

                    if (ValueDeliverScript.flightNumber == 2 && ValueDeliverScript.skinNumber == 3)
                    {
                        ValueDeliverScript.skin02_03Effect = 1f + (1 + 0.1f * ValueDeliverScript.skinLevel);
                    }
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 6:     //출격시 2단계 웜홀부터 등장합니다.
                if (ValueDeliverScript.EquipAssist06 > 0)
                {
                    ValueDeliverScript.EquipAssist06 = (ValueDeliverScript.EquipAssist06 - 1);
                    equipAssistIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.assistSpriteName[activeAssist].Replace("big", "small");
                    gameManager.GetComponent<PortalControlScript>().ActiveBoost02(1);	//포탈의 강화될(더해질) 레벨수치를 적어준다.
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 7:
                if (ValueDeliverScript.EquipAssist07 > 0)
                {
                    ValueDeliverScript.EquipAssist07 = (ValueDeliverScript.EquipAssist07 - 1);
                    equipAssistIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.assistSpriteName[activeAssist].Replace("big", "small");
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 8:
                if (ValueDeliverScript.EquipAssist08 > 0)
                {
                    ValueDeliverScript.EquipAssist08 = (ValueDeliverScript.EquipAssist08 - 1);
                    equipAssistIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.assistSpriteName[activeAssist].Replace("big", "small");
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 9:
                if (ValueDeliverScript.EquipAssist09 > 0)
                {
                    ValueDeliverScript.EquipAssist09 = (ValueDeliverScript.EquipAssist09 - 1);
                    equipAssistIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.assistSpriteName[activeAssist].Replace("big", "small");
                }
                //ValueDeliverScript.SaveGameData();
                break;
            case 10:
                if (ValueDeliverScript.EquipAssist10 > 0)
                {
                    ValueDeliverScript.EquipAssist10 = (ValueDeliverScript.EquipAssist10 - 1);
                    equipAssistIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.assistSpriteName[activeAssist].Replace("big", "small");
                }

                //ValueDeliverScript.SaveGameData();
                break;
            case 11:
                if (ValueDeliverScript.EquipAssist11 > 0)
                {
                    ValueDeliverScript.EquipAssist11 = (ValueDeliverScript.EquipAssist11 - 1);
                    equipAssistIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.assistSpriteName[activeAssist].Replace("big", "small");
                }
                
                //ValueDeliverScript.SaveGameData();
                break;
            case 12:
                if (ValueDeliverScript.EquipAssist12 > 0)
                {
                    ValueDeliverScript.EquipAssist12 = (ValueDeliverScript.EquipAssist12 - 1);
                    equipAssistIcon.GetComponent<UISprite>().spriteName = ValueDeliverScript.assistSpriteName[activeAssist].Replace("big", "small");
                }
                 
                //ValueDeliverScript.SaveGameData();
                break;
        }
        #endregion




        #region 비행기별 연료 세팅.
        switch (ValueDeliverScript.flightNumber)
        {
            case 0:
                switch (ValueDeliverScript.skinNumber)
                {
                    case 0:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 100 + (ValueDeliverScript.upgradePointF00P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 1:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 100 + (ValueDeliverScript.upgradePointF00P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 2:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 100 + (ValueDeliverScript.upgradePointF00P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 3:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 100 + (ValueDeliverScript.upgradePointF00P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 4:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 110 + (ValueDeliverScript.upgradePointF00P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 5:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 110 + (ValueDeliverScript.upgradePointF00P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                }
                break;

            case 1:
                switch (ValueDeliverScript.skinNumber)
                {
                    case 0:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 110 + (ValueDeliverScript.upgradePointF01P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 1:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 120 + (ValueDeliverScript.upgradePointF01P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 2:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 120 + (ValueDeliverScript.upgradePointF01P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 3:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 120 + (ValueDeliverScript.upgradePointF01P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 4:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 130 + (ValueDeliverScript.upgradePointF01P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 5:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 130 + (ValueDeliverScript.upgradePointF01P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                }
                break;

            case 2:
                switch (ValueDeliverScript.skinNumber)
                {
                    case 0:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 120 + (ValueDeliverScript.upgradePointF02P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 1:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 140 + (ValueDeliverScript.upgradePointF02P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 2:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 140 + (ValueDeliverScript.upgradePointF02P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 3:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 140 + (ValueDeliverScript.upgradePointF02P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 4:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 150 + (ValueDeliverScript.upgradePointF02P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                    case 5:
                        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize = 150 + (ValueDeliverScript.upgradePointF02P04 * ValueDeliverScript.fuelPerUpoint);
                        break;
                }
                break;
        }

        ValueDeliverScript.fuelSizeOri = ValueDeliverScript.fuelSize;
        Debug.Log("01 . 적용후 연료게이지 총량 :: " + ValueDeliverScript.fuelSizeOri);

        #endregion

        //변경된 값 서버에 저장
        ValueDeliverScript.SaveGameData();
    }
    //Awake End.





    public IEnumerator Unbeatable() //UfoExplosion 220번대 줄에서 호출.
    {
        //Debug.Log("In To Unbeatable");
        bodyBase = GameObject.Find("BodyBase");
        bodyBase.tag = "Unbeatable";
        float spendTime = 0;
        //Debug.Log("bling bling~ ::: " + bodyBase.tag);
        while (spendTime < 3)
        {
            bodyBase.renderer.enabled = !this.renderer.enabled;
            yield return null;
            spendTime += Time.deltaTime;
        }
        bodyBase.tag = "Player";
        bodyBase.renderer.enabled = true;

    }

}
