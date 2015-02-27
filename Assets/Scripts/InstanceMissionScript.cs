using UnityEngine;
using System.Collections;

public class InstanceMissionScript : MonoBehaviour
{
    int missionNumber = 0;
    public int missionMaxNumber = 28;

    int spinBallKilled;
    int dustKilled;
    int dartKilled;
    int seeddKilled;
    int bombUsed;
    int skillBombUsed;
    int coinAdded;
    int scoreAdded;
    int powerUpAdded;
    int skillUpAdded;
    int fuelItemAdded;
    int comboCount;

    int oldPosition = -1;

    ActivateScript activation;
    Vector3 birthPosition;
    ChangeLabel changeLavel;

    int missionCount;

    bool isSuccessMission = false;

    ChangeTex01 missionUfoIconChangeTex01;


    // Use this for initialization
    void Start()
    {
        activation = GameObject.Find("GameManager").GetComponent<ActivateScript>();
        changeLavel = GameObject.Find("UfoCount").GetComponent<ChangeLabel>();
        missionUfoIconChangeTex01 = GameObject.Find("MissionUfoIcon").GetComponent<ChangeTex01>();
        MissionNumberCreate(missionNumber);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SuccessMission(1);
        }
    }


    void MissionNumberCreate(int oldMissionNumber)
    {
        isSuccessMission = false;
        // 각 킬수 초기화.
        spinBallKilled = 0;
        dustKilled = 0;
        dartKilled = 0;
        seeddKilled = 0;
        bombUsed = 0;
        skillBombUsed = 0;
        coinAdded = 0;
        scoreAdded = 0;
        powerUpAdded = 0;
        skillUpAdded = 0;
        fuelItemAdded = 0;
        comboCount = 0;
        // 각 킬수 초기화.


        missionNumber = Random.Range(1, missionMaxNumber + 1);
        if (missionNumber == oldMissionNumber)
            MissionNumberCreate(missionNumber);

        //인스턴스미션 이미지들 변경.
        MissionUfoNumber(missionNumber);
        changeLavel.LabelChange(missionCount, 0);
        missionUfoIconChangeTex01.MissionNumber(missionNumber);
    }

    void MissionUfoNumber(int number)
    {
        switch (number)
        {
            case 1: missionCount = 25; break;
            case 2: missionCount = 30; break;
            case 3: missionCount = 40; break;
            case 4: missionCount = 40; break;
            case 5: missionCount = 45; break;
            case 6: missionCount = 60; break;
            case 7: missionCount = 12; break;
            case 8: missionCount = 14; break;
            case 9: missionCount = 20; break;
            case 10: missionCount = 5; break;
            case 11: missionCount = 7; break;
            case 12: missionCount = 10; break;
            case 13: missionCount = 1; break;
            case 14: missionCount = 2; break;
            case 15: missionCount = 1; break;
            case 16: missionCount = 2; break;
            case 17: missionCount = 50; break;
            case 18: missionCount = 60; break;
            case 19: missionCount = 70; break;
            case 20: missionCount = 30000; break;
            case 21: missionCount = 45000; break;
            case 22: missionCount = 60000; break;
            case 23: missionCount = 5; break;
            case 24: missionCount = 6; break;
            case 25: missionCount = 7; break;
            case 26: missionCount = 5; break;
            case 27: missionCount = 6; break;
            case 28: missionCount = 7; break;
            case 29: missionCount = 5; break;
            case 30: missionCount = 6; break;
            case 31: missionCount = 7; break;
            //case 32: missionCount = 5; break;
            //case 33: missionCount = 10; break;
            //case 34: missionCount = 15; break;
        }
    }

    public void AddSpinBall()
    {
        spinBallKilled++; IsMissionComplete();
    }

    public void AddDust()
    {
        dustKilled++; IsMissionComplete();
    }

    public void AddDart()
    {
        dartKilled++; IsMissionComplete();
    }

    public void AddSeed()
    {
        seeddKilled++; IsMissionComplete();
    }

    public void UseBomb()
    {
        bombUsed++; IsMissionComplete();
    }

    public void UseSkillBomb()
    {
        skillBombUsed++; IsMissionComplete();
    }

    public void AddCoin(int coin)
    {
        coinAdded += coin; IsMissionComplete();
    }

    public void AddScore(int score)
    {
        scoreAdded += score; IsMissionComplete();
    }

    public void AddPowerUp()
    {
        powerUpAdded++; IsMissionComplete();
    }

    public void AddSkillUp()
    {
        skillUpAdded++; IsMissionComplete();
    }

    public void addFuelItem()
    {
        fuelItemAdded++; IsMissionComplete();
        //2014년 12월 15일 새로 추가된 인스턴스 기능//
    }

    //public void nowComboCount()
    //{
    //    IsMissionComplete();
    //    //2014년 12월 15일 새로 추가된 인스턴스 기능//
    //}


    //미션 완료여부 검사후 윙박스 출현시킴.
    void IsMissionComplete()
    {
        switch (missionNumber)
        {
            case 1:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - spinBallKilled, (float)spinBallKilled / missionCount);
                    if (spinBallKilled >= missionCount) SuccessMission(1);
                    break;
                }

            case 2:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - spinBallKilled, (float)spinBallKilled / missionCount);
                    if (spinBallKilled >= missionCount) SuccessMission(2);
                    break;
                }

            case 3:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - spinBallKilled, (float)spinBallKilled / missionCount);
                    if (spinBallKilled >= missionCount) SuccessMission(3);
                    break;
                }

            case 4:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - dustKilled, (float)dustKilled / missionCount);
                    if (dustKilled >= missionCount) SuccessMission(1);
                    break;
                }

            case 5:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - dustKilled, (float)dustKilled / missionCount);
                    if (dustKilled >= missionCount) SuccessMission(2);
                    break;
                }

            case 6:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - dustKilled, (float)dustKilled / missionCount);
                    if (dustKilled >= missionCount) SuccessMission(3);
                    break;
                }

            case 7:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - dartKilled, (float)dartKilled / missionCount);
                    if (dartKilled >= missionCount) SuccessMission(1);
                    break;
                }

            case 8:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - dartKilled, (float)dartKilled / missionCount);
                    if (dartKilled >= missionCount) SuccessMission(2);
                    break;
                }

            case 9:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - dartKilled, (float)dartKilled / missionCount);
                    if (dartKilled >= missionCount) SuccessMission(3);
                    break;
                }

            case 10:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - seeddKilled, (float)seeddKilled / missionCount);
                    if (seeddKilled >= missionCount) SuccessMission(1);
                    break;
                }

            case 11:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - seeddKilled, (float)seeddKilled / missionCount);
                    if (seeddKilled >= missionCount) SuccessMission(2);
                    break;
                }

            case 12:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - seeddKilled, (float)seeddKilled / missionCount);
                    if (seeddKilled >= missionCount) SuccessMission(3);
                    break;
                }

            case 13:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - bombUsed, (float)bombUsed / missionCount);
                    if (bombUsed >= missionCount) SuccessMission(1);
                    break;
                }

            case 14:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - bombUsed, (float)bombUsed / missionCount);
                    if (bombUsed >= missionCount) SuccessMission(2);
                    break;
                }

            case 15:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - skillBombUsed, (float)skillBombUsed / missionCount);
                    if (skillBombUsed >= missionCount) SuccessMission(1);
                    break;
                }

            case 16:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - skillBombUsed, (float)skillBombUsed / missionCount);
                    if (skillBombUsed >= missionCount) SuccessMission(2);
                    break;
                }

            case 17:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - coinAdded, (float)coinAdded / missionCount);
                    if (coinAdded >= missionCount) SuccessMission(1);
                    break;
                }

            case 18:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - coinAdded, (float)coinAdded / missionCount);
                    if (coinAdded >= missionCount) SuccessMission(2);
                    break;
                }

            case 19:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - coinAdded, (float)coinAdded / missionCount);
                    if (coinAdded >= missionCount) SuccessMission(3);
                    break;
                }

            case 20:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - scoreAdded, (float)scoreAdded / missionCount);
                    if (scoreAdded >= missionCount) SuccessMission(1);
                    break;
                }

            case 21:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - scoreAdded, (float)scoreAdded / missionCount);
                    if (scoreAdded >= missionCount) SuccessMission(2);
                    break;
                }

            case 22:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - scoreAdded, (float)scoreAdded / missionCount);
                    if (scoreAdded >= missionCount) SuccessMission(3);
                    break;
                }

            case 23:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - powerUpAdded, (float)powerUpAdded / missionCount);
                    if (powerUpAdded >= missionCount) SuccessMission(1);
                    break;
                }

            case 24:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - powerUpAdded, (float)powerUpAdded / missionCount);
                    if (powerUpAdded >= missionCount) SuccessMission(2);
                    break;
                }

            case 25:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - powerUpAdded, (float)powerUpAdded / missionCount);
                    if (powerUpAdded >= missionCount) SuccessMission(3);
                    break;
                }

            case 26:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - skillUpAdded, (float)skillUpAdded / missionCount);
                    if (skillUpAdded >= missionCount) SuccessMission(1);
                    break;
                }

            case 27:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - skillUpAdded, (float)skillUpAdded / missionCount);
                    if (skillUpAdded >= missionCount) SuccessMission(2);
                    break;
                }

            case 28:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - skillUpAdded, (float)skillUpAdded / missionCount);
                    if (skillUpAdded >= missionCount) SuccessMission(3);
                    break;
                }

            case 29:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - fuelItemAdded, (float)fuelItemAdded / missionCount);
                    if (fuelItemAdded >= missionCount) SuccessMission(1);
                    break;
                }

            case 30:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - fuelItemAdded, (float)fuelItemAdded / missionCount);
                    if (fuelItemAdded >= missionCount) SuccessMission(2);
                    break;
                }

            case 31:
                {
                    if (isSuccessMission) break;
                    changeLavel.LabelChange(missionCount - fuelItemAdded, (float)fuelItemAdded / missionCount);
                    if (fuelItemAdded >= missionCount) SuccessMission(3);
                    break;
                }

            //case 32:
            //    {
            //        if (isSuccessMission) break;
            //        changeLavel.LabelChange(missionCount - skillUpAdded, (float)skillUpAdded / missionCount);
            //        if (skillUpAdded >= missionCount) SuccessMission(1);
            //        break;
            //    }

            //case 33:
            //    {
            //        if (isSuccessMission) break;
            //        changeLavel.LabelChange(missionCount - skillUpAdded, (float)skillUpAdded / missionCount);
            //        if (skillUpAdded >= missionCount) SuccessMission(2);
            //        break;
            //    }

            //case 34:
            //    {
            //        if (isSuccessMission) break;
            //        changeLavel.LabelChange(missionCount - skillUpAdded, (float)skillUpAdded / missionCount);
            //        if (skillUpAdded >= missionCount) SuccessMission(3);
            //        break;
            //    }
        }
    }


    void SuccessMission(int gHoleNum)
    {
        //바로 아래 메서드를 실행함으로서 포탈 이미지가 돌아가고 골든웜홀이 나타나있는 시간을 알수있는 시간바가 보이게 된다.//
        GameObject.Find("InstanceMission").GetComponent<InstanceWingBoxApearScript>().Activate();
        VarReinitioalization(); // 모든 값을 초기화.
        isSuccessMission = true;
        StartCoroutine(GHoleAct(gHoleNum));
        GameObject.Find("GameManager").GetComponent<SoundUiControlScript>().InstantMissionCheck();    //미션완료음.


        if (ValueDeliverScript.flightNumber == 2)   //팬텀으로 출격시 완수한 인스턴스 미션의 수를 기록.
            ValueDeliverScript.flight002CompleteInstanceMissionTemp++;
    }

    IEnumerator GHoleAct(int gHoleNum)
    {
        //골든웜홀이 나타날 위치를 랜덤으로 지정한다//
        BirthPosition();
        //위치를 지정하고 그 위치를 기반으로 s자 이펙트후 골든웜홀이 나타나게 한다//
        activation.WingBoxActivation(birthPosition, gHoleNum);

        //더블윙박스(더블 골든 웜홀) 아이템을 장착했을때 한번 더 골든 윙박스가 나오게 한다.
        if (ValueDeliverScript.wingboxDouble)
        {
            yield return new WaitForSeconds(2.1f);
            BirthPosition();
            activation.WingBoxActivation(birthPosition, gHoleNum);
        }
    }

    public void NewMission()
    {
        MissionNumberCreate(missionNumber);
    }

    void VarReinitioalization()	// 모든 값을 초기화.
    {
        spinBallKilled = 0;
        dustKilled = 0;
        dartKilled = 0;
        seeddKilled = 0;
        bombUsed = 0;
        skillBombUsed = 0;
        coinAdded = 0;
        scoreAdded = 0;
        powerUpAdded = 0;
        skillUpAdded = 0;
    }

    void BirthPosition()
    {
        int xPosition = RePosition(oldPosition);
        birthPosition = new Vector3(Random.Range(-11f, -7f) + xPosition * 6f, 0, Random.Range(35, 45));
        oldPosition = xPosition;
    }

    int RePosition(int oldPosition2)
    {
        int xPosition = Random.Range(0, 4);

        if (xPosition == oldPosition2)
        {
            return RePosition(oldPosition2);
        }
        else
        {
            return xPosition;
        }
    }

}
