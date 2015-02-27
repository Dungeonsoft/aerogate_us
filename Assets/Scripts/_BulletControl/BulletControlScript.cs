using UnityEngine;
using System.Collections;

public class BulletControlScript : MonoBehaviour
{

    int bulletLevel = 1; // 최초 게임에 진입했을때 유저 비행기의 총알 레벨을 파악해 기록하는 변수. 파워업아이템 먹으면 일씩 증가.
    int startBulletLevel;// 최초 게임에 진입했을때 유저 비행기의 총알 레벨을 파악해 기록하는 변수. 최초 레벨만 기록하고 더이상의 기록은 하면 안된다.
    public int addedGageForNumber;
    public int addBulletLevel = 0;
    public int addSkillUpGage = 0;

    ActivateScript Activate;

    UISprite levelShow;
    GameObject flight;

    UIFilledSprite bulletLevelGageLine;
    AddedChSpeakScript addedChSpeakScript;

    GameObject scriptReadys;

    float missileInterTime;
    float bulletDefaultIntervalTime;    //각 비행기별 총알 기본 속도를 세팅하는 변수.
    float interTime;
    bool isSuperPower = false;
    float repairBulletTime;

    GameObject bulletLevelGage;

    void Awake()
    {
        bulletLevelGage = GameObject.Find("BulletLevelGage");

        addedChSpeakScript = GameObject.Find("CharacterSpeakManager").GetComponent<AddedChSpeakScript>();

        ValueDeliverScript.isPcExplo = false;

        bulletLevelGageLine = GameObject.Find("BulletLevelGageLine").GetComponent<UIFilledSprite>();
        //총알에 대한 변수 두개를 생성해서 하나엔 최초 시작시 총알의 레벨을 저장해놓고, 또 하나는 현재 총알의 레벨을 저장할수 있게 세팅//
        startBulletLevel = bulletLevel = ValueDeliverScript.bulletLevel;

        levelShow = GameObject.Find("Camera/Anchor/InfoUI/BulletLevelGage/Level1").GetComponent<UISprite>();

        //하단의 총알 레벨 12를 넘어서 13이상이 되면 첨부터 게이지가 차있게 만들어 주기 위한 부분. 30단계면 풀 세팅이라 모든 게이지가 다 차게 보인다.
        int bulletLevelTemp = ValueDeliverScript.bulletLevel;
        if (bulletLevelTemp > 12)
        {
            bulletLevelGageLine.fillAmount = 0;
            bulletLevelGageLine.spriteName = "Bgr_AttackPowerGage1";
            levelShow.spriteName = "Bgr_AttackPowerCnt1";
            addedGageForNumber = 3;
            if (bulletLevelTemp > 13)
            {
                bulletLevelGageLine.fillAmount = 0;
                bulletLevelGageLine.spriteName = "Bgr_AttackPowerGage2";
                levelShow.spriteName = "Bgr_AttackPowerCnt2";
                addedGageForNumber = 8;
            }
            if (bulletLevelTemp > 14)
            {
                bulletLevelGageLine.fillAmount = 1;
                bulletLevelGageLine.spriteName = "Bgr_AttackPowerGage3";
                levelShow.spriteName = "Bgr_AttackPowerCnt3";
                addedGageForNumber = 16;
            }
            levelShow.MakePixelPerfect();
        }
    }

    // Use this for initialization
    void Start()
    {
        float flightAttackSpeed = ValueDeliverScript.flightAttackSpeed;
        float itemReinforce08Effect = ValueDeliverScript.itemReinforce08Effect;

        int upgradePointF00P02 = ValueDeliverScript.upgradePointF00P02;
        int upgradePointF01P02 = ValueDeliverScript.upgradePointF01P02;
        int upgradePointF02P02 = ValueDeliverScript.upgradePointF02P02;

        //비행기 종류별로 다르게 총알 발사속도를 세팅해준다.
        switch (ValueDeliverScript.flightNumber)
        {                       //    1f / 기본분모(초당발사수) * 총알속도증가용 수치 곱(1.x 형태)   + 강화포인트로 인한 발사속도 증가//              
            case 0:
                bulletDefaultIntervalTime = (1f / (6f * (1 + flightAttackSpeed + itemReinforce08Effect) + ((ValueDeliverScript.Item04Effect + upgradePointF00P02) * ValueDeliverScript.fRatePerUpoint))); //0.1f  12
                break;
            case 1:
                bulletDefaultIntervalTime = (1f / (10f * (1 + flightAttackSpeed + itemReinforce08Effect) + ((ValueDeliverScript.Item04Effect + upgradePointF01P02) * ValueDeliverScript.fRatePerUpoint))); //0.075f    16
                break;
            case 2:
                bulletDefaultIntervalTime = (1f / (8f * (1 + flightAttackSpeed + itemReinforce08Effect) + ((ValueDeliverScript.Item04Effect + upgradePointF02P02) * ValueDeliverScript.fRatePerUpoint))); //0.083f    14
                break;
        }

        //리페어 상태시 총알발사 간격시간 정함//
        repairBulletTime = bulletDefaultIntervalTime * 4;

        //위에서 정해진 총알값을 실제 발사함수에서 쓰이는 총알발사간격 변수에 대입을 시킴//
        interTime = bulletDefaultIntervalTime;

        Activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();

        flight = GameObject.Find("Flight");
        scriptReadys = GameObject.Find("ScriptReadys");

        //미사일 발사시 각 미사일별 발사간격을 정의해준다. 지금은 미사일을 발사는 비행기는 코만치와 팬텀이며 이 두개의 미사일 발사 간격을 같게 세팅해 놓았다.
        switch (ValueDeliverScript.flightNumber)
        {
            case 1:
            case 2:
                missileInterTime = 1f;
                break;
        }
    }


    //이큅 아이템을 장착하여 5단계 파워업 상태로 게임을 시작할 때 이 부분을 실행하고 
    //총알의 레벨을 유저의 레벨보다 5만큼 증가 시켜서 게임 끝날때까지 고정한다.
    public void ActiveBoost01()
    {
        addedGageForNumber = 16;
        bulletLevel += 3;


        bulletLevelGageLine.fillAmount = 1;
        bulletLevelGageLine.spriteName = "Bgr_AttackPowerGage3";
        levelShow.spriteName = "Bgr_AttackPowerCnt3";
        levelShow.MakePixelPerfect();


        //15단계 이상은 총알이 없으니 총알단계 최고인 15으로 고정한다.
        if (bulletLevel > 15)
        {
            bulletLevel = 15;
        }
    }


    //기본 기능인 게임중 아이템인 파워업 아이템을 먹으면 발동시키는  함수이다. 여기에선 총알의 단계가 16이상이면 실행을 막는다. 15이상의 총알 증가 레벨은 존재하지 않는다.
    public void AddBulletLevel(int powerUpBulletGage = 1)
    {
        if (flight.activeSelf == false || bulletLevel > 15)
            return;

        addedGageForNumber += powerUpBulletGage;
        Debug.Log("애드블릿함!!! " + addedGageForNumber);

        if (addedGageForNumber < 4)
        {
            bulletLevelGageLine.fillAmount = (addedGageForNumber / 3f);
            if (bulletLevelGageLine.fillAmount >= 1) bulletLevelGageLine.fillAmount =0;
           
            bulletLevelGageLine.spriteName = "Bgr_AttackPowerGage1";
            levelShow.spriteName = "Bgr_AttackPowerCnt0";
            if (addedGageForNumber == 3) levelShow.spriteName = "Bgr_AttackPowerCnt1";

            bulletLevelGage.animation.Play("ButtonScaleActionAnim01");
        }
        else if (addedGageForNumber < 9)
        {
            bulletLevelGageLine.fillAmount = ((addedGageForNumber-3) / 5f);
            if (bulletLevelGageLine.fillAmount >= 1) bulletLevelGageLine.fillAmount = 0;

            bulletLevelGageLine.spriteName = "Bgr_AttackPowerGage2";
            levelShow.spriteName = "Bgr_AttackPowerCnt1";
            if (addedGageForNumber == 8) levelShow.spriteName = "Bgr_AttackPowerCnt2";

            bulletLevelGage.animation.Play("ButtonScaleActionAnim01");
        }
        else if(addedGageForNumber < 17)
        {
            Debug.Log("마지막 관문 ::: " + addedGageForNumber);
            bulletLevelGageLine.fillAmount = ((addedGageForNumber - 8) / 8f);

            bulletLevelGageLine.spriteName = "Bgr_AttackPowerGage3";
            levelShow.spriteName = "Bgr_AttackPowerCnt2";
            if (addedGageForNumber == 16) levelShow.spriteName = "Bgr_AttackPowerCnt3";
            
            bulletLevelGage.animation.Play("ButtonScaleActionAnim01");
        }
        else if (addedGageForNumber >= 17)
        {
            bulletLevelGageLine.fillAmount = 1f;
            bulletLevelGageLine.spriteName = "Bgr_AttackPowerGage3";
            levelShow.spriteName = "Bgr_AttackPowerCnt3";
            bulletLevelGage.animation.Play("ButtonScaleActionAnim01");
        }
        levelShow.MakePixelPerfect();

        switch (addedGageForNumber)
        {
            case 3:
                scriptReadys.GetComponent<SpeechBubbleScript>().TogglePowerUp();
                if (bulletLevel < 13)
                {
                    bulletLevel += 1;
                    addedChSpeakScript.ChSpeak(2);
                }
                break;

            case 8:
                scriptReadys.GetComponent<SpeechBubbleScript>().TogglePowerUp();
                if (bulletLevel < 14)
                {
                    bulletLevel += 1;
                    addedChSpeakScript.ChSpeak(2);
                }
                break;

            case 16:
                Debug.Log("총알 레벨 변경 : 현재 레벨 ::: " + bulletLevel);

                scriptReadys.GetComponent<SpeechBubbleScript>().TogglePowerUp();
                if (bulletLevel < 15)
                {
                    Debug.Log("총알 최초 레벨 ::: " + startBulletLevel);
                    Debug.Log("총알 현재 레벨 ::: " + bulletLevel);

                    bulletLevel += 1;
                    addedChSpeakScript.ChSpeak(2);
                }
                break;
        }
    }


    public void QpcExploFunc()
    {
        Debug.Log("ValueDeliverScript.isPcExplo +++++ " + ValueDeliverScript.isPcExplo);
        Debug.Log("++++++비행기 파괴시+++++++");
        ValueDeliverScript.isPcExplo = true;
        Debug.Log("ValueDeliverScript.isPcExplo +++++ " + ValueDeliverScript.isPcExplo);
    }

    public bool newSuperPower = false;

    public void OnSuperPower()
    {
        isSuperPower = true;
        Debug.Log("OnSuperPower");
    }

    public void OffSuperPower()
    {
        isSuperPower = false;
        ValueDeliverScript.isPcExplo = false;
        Debug.Log("OffSuperPower");
        Debug.Log("isPcExplo" + ValueDeliverScript.isPcExplo);
    }

    public IEnumerator BulletShot()   //실제 총알 나가는 속도를 조절하는 부분.
    {
        //총알 발사 최초 시작시 3초를 기다린다//
        yield return new WaitForSeconds(3f);
        while (true)
        {
            yield return new WaitForSeconds(interTime);
            if (ValueDeliverScript.isPcExplo == true || isSuperPower == true || flight.tag == "SuperPower") continue;   //비행기가 파괴 상태이가나 슈퍼파워 상태면 이번턴에 총알을 발사하지 않는다//

            Activate.BulletActivate(bulletLevel);
        }
    }

    public void RepairBulletIntervalChange()
    {
        interTime = repairBulletTime;
    }

    public void DefaultBulletIntervalTime()
    {
        interTime = bulletDefaultIntervalTime;
    }


    public IEnumerator BulletMissileShot()
    {
        //미사일 발사시 최초 3초를 기다린다//
        yield return new WaitForSeconds(3f);
        if (ValueDeliverScript.flightNumber > 0)
        {
            while (true)
            {
                yield return new WaitForSeconds(missileInterTime);

                if (ValueDeliverScript.isPcExplo == true || isSuperPower == true) continue;    //비행기가 파괴된 상태면 아래 내용을 실행하지 않고 넘어간다.
                Activate.BulletMissileActivate(bulletLevel);
            }
        }
    }
}
