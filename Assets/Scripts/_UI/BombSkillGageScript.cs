using UnityEngine;
using System.Collections;

public class BombSkillGageScript : MonoBehaviour
{

    float skillGageValue = 0;
    int skillLevel = 1;

    float bombGageValue = 0;
    float bombRecharge = 0;

    public GameObject skillButton00;
    public GameObject bombButton00;
    UIFilledSprite skillUiFilledSprite;
    UIFilledSprite bombUiFilledSprite;
    UISprite bombUiSprite;

    GameObject PC;
    GameObject flight;
    GameObject gameManager;
    ActivateScript activateScript;
    InstanceMissionScript instanceMissionScript;

    GameObject scriptReadys;


    public GameObject bombBtnRollingEffect;
    public GameObject skillBtnRollingEffect;

    public GameObject bombHole;

    int addItemSkillGageValue = 0;

    SoundUiControlScript soundUiControlScript;

    int[] maxSkillGage = {10000 , 10000 , 10000};   //비행기별로 스킬게이지 맥스 값이 다름. 0:포커   1:코만치   2:팬텀.

    float addPowerAddGage = 0f;


    void Awake()
    {
        //int upgradePointF00P04 = ValueDeliverScript.upgradePointF00P04;
        //int upgradePointF01P04 = ValueDeliverScript.upgradePointF01P04;
        //int upgradePointF02P04 = ValueDeliverScript.upgradePointF02P04;

        //maxSkillGage[0] -= upgradePointF00P04 * 50;
        //maxSkillGage[1] -= upgradePointF01P04 * 50;
        //maxSkillGage[2] -= upgradePointF02P04 * 50;

   }

    void Start()
    {
        float specialBombRechargeDecrease = 0f;
        int tempDecreaseBombTime = 0;

        if (ValueDeliverScript.isSelectSpecial)   //스페셜 어택 미션 완료로 인한 보상 시간이 발동되었을때 팬텀 환상의 날개 스킨의 효과가 발동한다.
            specialBombRechargeDecrease = ValueDeliverScript.specialBombRechargeDecrease;

        if (ValueDeliverScript.flightNumber == 2)//비행기가 2번(팬텀)이 선택되면 기본적으로 쿨타임을 3초 줄여준다.
            tempDecreaseBombTime = 3;

        //Debug.Log("/////////////////////////////////////////////////////////");
        //Debug.Log("/////////////////////////////////////////////////////////");
        //Debug.Log("specialBombRechargeDecrease" + specialBombRechargeDecrease);
        //Debug.Log("tempDecreaseBombTime" + tempDecreaseBombTime);
        //Debug.Log("bombRechargeDecrease" + ValueDeliverScript.bombRechargeDecrease);
        //Debug.Log("plasmaWaveCoolTime" + ValueDeliverScript.plasmaWaveCoolTime);
        //Debug.Log("/////////////////////////////////////////////////////////");
        //Debug.Log("/////////////////////////////////////////////////////////");
        
        //기본 폭탄 회복 시간을 정한다.
        bombRecharge = specialBombRechargeDecrease + tempDecreaseBombTime + ValueDeliverScript.plasmaWaveCoolTime; //폭탄 회복시간.
        //기본 폭탄 회복 시간을 정한다.

        
        
        //바로 아래 코드가 폭탄 게이지 줄여줌 표시 아이콘의 양을 입력하는 부분이다. 기본 폭탄
        bombButton00.GetComponent<UIFilledSprite>().fillAmount = bombRecharge / ValueDeliverScript.bombRecycle;

        soundUiControlScript = GameObject.Find("GameManager").GetComponent<SoundUiControlScript>();


        //				skillLevel = ValueDeliverScript.skillLevel;
        skillLevel = ValueDeliverScript.skillLevel + ((ValueDeliverScript.flightNumber % 3) * 10);	//총알을 구현한것이 적어 임시로 3가지 범주안에서만 나오게 세팅.

        skillUiFilledSprite = GameObject.Find("SkillButton01").GetComponent<UIFilledSprite>();
        bombUiFilledSprite = GameObject.Find("BombButton01").GetComponent<UIFilledSprite>();
        bombUiSprite = GameObject.Find("BombButton02").GetComponent<UISprite>();
        flight = GameObject.Find("Flight");
        gameManager = GameObject.Find("GameManager");
        activateScript = gameManager.GetComponent<ActivateScript>();
        instanceMissionScript = gameManager.GetComponent<InstanceMissionScript>();
        PC = GameObject.Find("PC");
        scriptReadys = GameObject.Find("ScriptReadys");

        //skillUiFilledSprite.spriteName = "bt_skill1_o";
        skillUiFilledSprite.spriteName = "bt_skill" + (ValueDeliverScript.flightNumber + 1) + "_o";
        GameObject.Find("SkillButton02").GetComponent<UISprite>().spriteName = "bt_skill" + (ValueDeliverScript.flightNumber + 1) + "_n";
        skillButton00.SetActive(false);
    }

    //이큅 아이템 장착시 발동되는 아이템 효과를 적용하기 위해 호출하는 부분.
    public void BombRechargeSubtration(float subtrValue)
    {
        bombRecharge += subtrValue;
        //Debug.Log("bombRecharge is " + bombRecharge);
    }

    public void AddItemSkillGageValue(int AddItemValue)
    {
        addItemSkillGageValue = AddItemValue;
        skillButton00.GetComponent<UIFilledSprite>().fillAmount = AddItemValue * 0.0001f;
    }

    public void AddSkillGageValue(int addValue)
    {
        if (skillUiFilledSprite.fillAmount < 1)
        {
            skillGageValue += addValue;
            addSkillGageUi();
        }
    }

    void addSkillGageUi()
    {
        skillUiFilledSprite.fillAmount = skillGageValue / maxSkillGage[ValueDeliverScript.flightNumber];
        if (skillUiFilledSprite.fillAmount >= 1)
        {
            GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterSpeak(6);
            scriptReadys.GetComponent<SpeechBubbleScript>().ToggleSkillReady();
            skillUiFilledSprite.spriteName = "bt_skill" + (ValueDeliverScript.flightNumber + 1) + "_o";
            skillBtnRollingEffect.SetActive(true);
        }
    }

    public void SkillGageZero()
    {
        if (flight.activeSelf == false || skillUiFilledSprite.fillAmount < 1)
        {
            return;
        }

        if (ValueDeliverScript.flightNumber == 1)   //코만치로 출격후 스킬을 사용할때 마다 카운트를 해준다.
        {
            ValueDeliverScript.flight001UseSkillTemp++;
        }

        //Debug.Log("     ::::::: addItemSkillGageValue   111111111 is " + addItemSkillGageValue);

        skillButton00.SetActive(true);
        skillButton00.GetComponent<UIFilledSprite>().fillAmount = addItemSkillGageValue / 10000f;
        StartCoroutine(SkillGageZero1());
    }


    IEnumerator SkillGageZero1() // 스킬 레벨에 따른 각각 다른 스킬폭탄을 생성하도록 세팅하는 부분.
    {
        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterSpeak(11);  //캐릭터 음성 스킬발사.
        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterMessageShow(16);

        //Debug.Log("     ::::::: addItemSkillGageValue   22222222 is " + addItemSkillGageValue);

        skillBtnRollingEffect.SetActive(false);
        skillUiFilledSprite.spriteName = "bt_skill" + (ValueDeliverScript.flightNumber + 1) + "_n";
        skillGageValue = 0 + addItemSkillGageValue;
        skillUiFilledSprite.fillAmount = skillGageValue / maxSkillGage[ValueDeliverScript.flightNumber];
        switch (skillLevel)
        {
            case 1:
                activateScript.SkillActivation(1, 0, "ForkkerSkill01Ani");

                break;
            case 2:
                activateScript.SkillActivation(1, 12, "ForkkerSkill01Ani");
                activateScript.SkillActivation(1, -12, "ForkkerSkill01Ani");

                break;
            case 3:
                activateScript.SkillActivation(1, 0, "ForkkerSkill01Ani");
                yield return new WaitForSeconds(0.1f);
                activateScript.SkillActivation(1, 20, "ForkkerSkill01Ani");
                activateScript.SkillActivation(1, -20, "ForkkerSkill01Ani");

                break;
            case 4:
                activateScript.SkillActivation(2, 0, "ForkkerSkill01Ani");

                break;
            case 5:
                activateScript.SkillActivation(2, 0, "ForkkerSkill01Ani");
                yield return new WaitForSeconds(0.5f);
                activateScript.SkillActivation(2, 0, "ForkkerSkill01Ani");

                break;


            case 11:
                activateScript.SkillActivation(3, 0, "ComancheSkill02Ani");

                break;
            case 12:
                activateScript.SkillActivation(3, 5, "ComancheSkill02Ani");
                activateScript.SkillActivation(3, -5, "ComancheSkill03Ani");

                break;
            case 13:
                activateScript.SkillActivation(3, 0, "ComancheSkill01Ani");
                yield return new WaitForSeconds(0.1f);
                activateScript.SkillActivation(3, 10, "ComancheSkill02Ani");
                activateScript.SkillActivation(3, -10, "ComancheSkill03Ani");

                break;
            case 14:
                activateScript.SkillActivation(3, 5, "ComancheSkill02Ani");
                activateScript.SkillActivation(3, -5, "ComancheSkill03Ani");
                yield return new WaitForSeconds(0.1f);
                activateScript.SkillActivation(3, 15, "ComancheSkill03Ani");
                activateScript.SkillActivation(3, -15, "ComancheSkill02Ani");

                break;
            case 15:
                activateScript.SkillActivation(3, 0, "ComancheSkill01Ani");
                yield return new WaitForSeconds(0.1f);
                activateScript.SkillActivation(3, 10, "ComancheSkill02Ani");
                activateScript.SkillActivation(3, -10, "ComancheSkill03Ani");
                yield return new WaitForSeconds(0.1f);
                activateScript.SkillActivation(3, 20, "ComancheSkill03Ani");
                activateScript.SkillActivation(3, -20, "ComancheSkill02Ani");

                break;


            case 21:
                activateScript.SkillActivation(4, 0, "");


                break;
            case 22:
                activateScript.SkillActivation(4, 0, "");
                yield return new WaitForSeconds(0.5f);
                activateScript.SkillActivation(4, 0, "");


                break;
            case 23:
                activateScript.SkillActivation(4, 0, "");
                yield return new WaitForSeconds(0.5f);
                activateScript.SkillActivation(4, 0, "");
                yield return new WaitForSeconds(0.5f);
                activateScript.SkillActivation(4, 0, "");


                break;
            case 24:
                activateScript.SkillActivation(4, 0, "");
                yield return new WaitForSeconds(0.5f);
                activateScript.SkillActivation(4, 0, "");
                yield return new WaitForSeconds(0.5f);
                activateScript.SkillActivation(4, 0, "");
                yield return new WaitForSeconds(0.5f);
                activateScript.SkillActivation(4, 0, "");


                break;
            case 25:
                activateScript.SkillActivation(4, 0, "");
                yield return new WaitForSeconds(0.5f);
                activateScript.SkillActivation(4, 0, "");
                yield return new WaitForSeconds(0.5f);
                activateScript.SkillActivation(4, 0, "");
                yield return new WaitForSeconds(0.5f);
                activateScript.SkillActivation(4, 0, "");
                yield return new WaitForSeconds(0.5f);
                activateScript.SkillActivation(4, 0, "");


                break;
        }


        instanceMissionScript.UseSkillBomb();
    }

    public void BombGageZero()
    {
        if (flight.activeSelf == false || bombUiFilledSprite.fillAmount < 1)
        {
            return;
        }
        addPowerAddGage = 0f;   //파워아이템 먹어서 생긴 핵폭탄 추가 게이지 찬것을 초기화해줌.

        #region 튜토리얼시 발동되는 폭탄 기능//
        if (ValueDeliverScript.isTutComplete == 0)
        {
            bombHole.SetActive(true); //5번 핵폭탄. 블랙홀.
            bombHole.GetComponent<BlackHoleBombScript>().Activate();

            if (PC.tag != "SuperPower") StartCoroutine(Unbeatable());

            soundUiControlScript.BombShot();    //폭탄 사용음.

            GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterSpeak(10);
            GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterMessageShow(15);
            bombGageValue = 0;
            bombUiFilledSprite.fillAmount = bombGageValue;
            bombBtnRollingEffect.SetActive(false);
            StartCoroutine(AddBombGageBar());

            return;
        }
        #endregion

        bombButton00.SetActive(true);


        //이부분이 아님 .이전 기준으로 만들어진 것이니 아래의 주석을 참고하여 기능을 완성시킨다.//
        //if (ValueDeliverScript.nowPortalLevel >= 5) //팬텀 거위의꿈 스킨 장작시 포탈레벨이 5단계 이상이면 공격력이 증가한다.
        //    portal3BombTimeDecrease = ValueDeliverScript.bombTimeDecrease;


        //쿨타임 감소양를 정의하기 위해 재계산을 해준다.
        float bombCoolTimeDecrease = bombRecharge;
        //쿨타임 감소양를 정의하기 위해 계산을 해준다.
        bombGageValue = bombCoolTimeDecrease / ValueDeliverScript.bombRecycle;  //게이지에 표시해주기 위해 최소값 0에서 1사이의 값이 나오도록 변환해준다.(통상적으로 1은 60초와 의미가 같다)
        //Debug.Log("봄 리차지 시간 ::: " + bombCoolTimeDecrease);
        //Debug.Log("봄 게이지 밸류 ::: " + bombGageValue);
        //Debug.Log("봄 리사이클 기본시간 ::: " + ValueDeliverScript.bombRecycle);
        bombButton00.GetComponent<UIFilledSprite>().fillAmount = bombGageValue;    //쿨타임이 감소된만큼 화면에 녹색으로 표시를 해준다.
        bombUiFilledSprite.fillAmount = bombGageValue;

        if (ValueDeliverScript.flightNumber == 0)
        {
            ValueDeliverScript.flight000BombUseNumberTemp++;
        }

        soundUiControlScript.BombShot();    //폭탄 사용음.

        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterSpeak(10);
        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterMessageShow(15);



        int activeBomb = ValueDeliverScript.activeBomb;


        if (activeBomb == 1)
        {	
            //1번 핵폭탄.
            float addRange = 1;
            if (ValueDeliverScript.flightNumber == 2 && ValueDeliverScript.skinNumber == 2)
            {
                addRange = 1 + (0.5f + 0.05f * ValueDeliverScript.skinLevel);
            }
            activateScript.BombActivation(activeBomb, addRange);
        }
        else if (activeBomb == 5)
        {
            bombHole.SetActive(true); //5번 핵폭탄. 블랙홀.
            bombHole.GetComponent<BlackHoleBombScript>().Activate();
        }
        //				BombType ();

        if (PC.tag != "SuperPower")
        {
            isUnbeat = true;
            PC.tag = "Unbeatable";
        }

        //StartCoroutine(Unbeatable());
        instanceMissionScript.UseBomb();
        bombBtnRollingEffect.SetActive(false);

        StartCoroutine(AddBombGageBar());
        if (ValueDeliverScript.isIncreaseBombAttackPercent) //폭발의왕(포커) 스킨이 적용되어있는가 여부.(핵폭탄 리젠을 단축).
        {
            StartCoroutine(IncreaseBombAttackPercent());
        }


    }

    bool isUnbeat = false;
    float unbeatSpendTime = 0;


    void Update()
    {
        if (isUnbeat == true)
        {
            unbeatSpendTime += Time.deltaTime;

            if (unbeatSpendTime > 2f && PC.tag != "SuperPower")
            {
                PC.tag = "Player";
                unbeatSpendTime = 0;
                isUnbeat = false;
            }
            else if (PC.tag == "SuperPower")
            {
                unbeatSpendTime = 0;
                isUnbeat = false;
            }
        }
    }

    IEnumerator IncreaseBombAttackPercent() //폭발의왕(포커) 스킨이 적용시 적용되는 함수.
    {
        float temp = ValueDeliverScript.increaseBombAttackPercentInGame;
        ValueDeliverScript.increaseBombAttackPercentInGame = ValueDeliverScript.increaseBombAttackPercent;

        yield return new WaitForSeconds(ValueDeliverScript.increaseBombAttackTime);

        ValueDeliverScript.increaseBombAttackPercentInGame = temp;
    }

    public void AddBombGage()
    {
        addPowerAddGage += ValueDeliverScript.bombRechargeDecrease / ValueDeliverScript.bombRecycle;
    }

    IEnumerator AddBombGageBar()
    {
        int activeBomb = ValueDeliverScript.activeBomb;

        float timeSpend = 0;
        if (activeBomb != 0 && flight)
        {
            //Debug.Log(":::::::::::::::::::::::::::시간재기::::::::::::::::::::::::::");
            while (bombUiFilledSprite.fillAmount < 1)
            {
                timeSpend += Time.deltaTime;
                //if (ValueDeliverScript.isBombRechargeDecreaseTemp)
                //{
                //    bombGageValue += ValueDeliverScript.bombRechargeDecrease / ValueDeliverScript.bombRecycle;
                //    ValueDeliverScript.isBombRechargeDecreaseTemp = false;
                //}
                bombUiFilledSprite.fillAmount = bombGageValue + timeSpend / ValueDeliverScript.bombRecycle + addPowerAddGage;

                //Debug.Log("밤게이지 값 ::: " + bombGageValue);
                //Debug.Log("애드파워애드게이지 값 ::: " + addPowerAddGage);
                //Debug.Log("타임스팬드 값 ::: " + timeSpend);
                //Debug.Log("밤리사이클 값 ::: " + ValueDeliverScript.bombRecycle);

                //Debug.Log("게이지필어마운트 값 ::: " + bombUiFilledSprite.fillAmount);
                
                
                //ValueDeliverScript.bombRechargeDecrease = 0f;
                yield return null;
            }
            bombBtnRollingEffect.SetActive(true);
            GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterSpeak(4);
            scriptReadys.GetComponent<SpeechBubbleScript>().ToggleBombReady();	//좌상단에서 캐릭터나오면서 글로 표시.

            if (activeBomb == 0)
                bombBtnRollingEffect.SetActive(false);
        }

    }


    IEnumerator Unbeatable()
    {
        yield return new WaitForSeconds(8f);
        PC.tag = "Player";
    }

}