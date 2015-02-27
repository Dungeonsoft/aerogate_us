using UnityEngine;
using System.Collections;

public class FlightSkinLevelAbility : MonoBehaviour
{

    //public float[] skinAcePlasmaCoolTime;   //포커 에이스 스킨 선택시 발동되는 어빌러티 설정.플라즈마 웨이브 쿨타임 감소.값을 적어준다.

    void Awake()
    {
        //선택한 스킨에 따라 적용되는 추가 기능을 적용.
        //1.비행기 종류 확인.
        switch (ValueDeliverScript.flightNumber)
        {
            case 00:	//포커.
                //2.스킨 종류확인.
                switch (ValueDeliverScript.skinNumber)
                {
                    case 000:	//기본스킨.
                        //기본스킨. 능력치 없음.
                        break;

                    case 001:	//포커-에이스. //3.스킨의 레벨을 확인하여 능력 적용.(완)
                        #region case001
                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                ValueDeliverScript.addFlightExp = 20;
                                ValueDeliverScript.plasmaWaveCoolTime = 5f;
                                break;
                            case 0002:
                                ValueDeliverScript.addFlightExp = 21;
                                ValueDeliverScript.plasmaWaveCoolTime = 5.5f;
                                break;
                            case 0003:
                                ValueDeliverScript.addFlightExp = 22;
                                ValueDeliverScript.plasmaWaveCoolTime = 6f;
                                break;
                            case 0004:
                                ValueDeliverScript.addFlightExp = 23;
                                ValueDeliverScript.plasmaWaveCoolTime = 6.5f;
                                break;
                            case 0005:
                                ValueDeliverScript.addFlightExp = 24;
                                ValueDeliverScript.plasmaWaveCoolTime = 7f;
                                break;
                            case 0006:
                                ValueDeliverScript.addFlightExp = 25;
                                ValueDeliverScript.plasmaWaveCoolTime = 7.5f;
                                break;
                            case 0007:
                                ValueDeliverScript.addFlightExp = 26;
                                ValueDeliverScript.plasmaWaveCoolTime = 8f;
                                break;
                            case 0008:
                                ValueDeliverScript.addFlightExp = 27;
                                ValueDeliverScript.plasmaWaveCoolTime = 8.5f;
                                break;
                            case 0009:
                                ValueDeliverScript.addFlightExp = 28;
                                ValueDeliverScript.plasmaWaveCoolTime = 9f;
                                break;
                            case 0010:
                                ValueDeliverScript.addFlightExp = 30;
                                ValueDeliverScript.plasmaWaveCoolTime = 10f;
                                break;
                        }
                        #endregion
                        break;

                    case 002:	//포커-스토커.(완)
                        #region case002
                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                ValueDeliverScript.addAttackAbility += 100; break;
                            //파이날 파워업 장착시 연사속도와 이동속도 2%씩 증가. 이부분은 인게임온로드스크립트 reinforce08을 참고할것.
                            case 0002:
                                ValueDeliverScript.addAttackAbility += 105; break;
                            case 0003:
                                ValueDeliverScript.addAttackAbility += 110; break;
                            case 0004:
                                ValueDeliverScript.addAttackAbility += 115; break;
                            case 0005:
                                ValueDeliverScript.addAttackAbility += 120; break;
                            case 0006:
                                ValueDeliverScript.addAttackAbility += 125; break;
                            case 0007:
                                ValueDeliverScript.addAttackAbility += 130; break;
                            case 0008:
                                ValueDeliverScript.addAttackAbility += 135; break;
                            case 0009:
                                ValueDeliverScript.addAttackAbility += 140; break;
                            case 0010:
                                ValueDeliverScript.addAttackAbility += 150; break;
                        }
                        #endregion
                        break;

                    case 003:	//포커-폭발의왕.(완) -핵폭탄 사용시 10초간 공격력 5~50% 증가.
                        #region case003
                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                //빠른핵폭탄 효과 증가. 인게임온로드스크립트Assist03참고.
                                ValueDeliverScript.isIncreaseBombAttackPercent = true;
                                ValueDeliverScript.increaseBombAttackTime = 10f;
                                ValueDeliverScript.increaseBombAttackPercent = 0.50f;
                                break;
                            case 0002:
                                ValueDeliverScript.isIncreaseBombAttackPercent = true;
                                ValueDeliverScript.increaseBombAttackTime = 10f;
                                ValueDeliverScript.increaseBombAttackPercent = 0.55f;
                                break;
                            case 0003:
                                ValueDeliverScript.isIncreaseBombAttackPercent = true;
                                ValueDeliverScript.increaseBombAttackTime = 10f;
                                ValueDeliverScript.increaseBombAttackPercent = 0.60f;
                                break;
                            case 0004:
                                ValueDeliverScript.isIncreaseBombAttackPercent = true;
                                ValueDeliverScript.increaseBombAttackTime = 10f;
                                ValueDeliverScript.increaseBombAttackPercent = 0.65f;
                                break;
                            case 0005:
                                ValueDeliverScript.isIncreaseBombAttackPercent = true;
                                ValueDeliverScript.increaseBombAttackTime = 10f;
                                ValueDeliverScript.increaseBombAttackPercent = 0.70f;
                                break;
                            case 0006:
                                ValueDeliverScript.isIncreaseBombAttackPercent = true;
                                ValueDeliverScript.increaseBombAttackTime = 10f;
                                ValueDeliverScript.increaseBombAttackPercent = 0.75f;
                                break;
                            case 0007:
                                ValueDeliverScript.isIncreaseBombAttackPercent = true;
                                ValueDeliverScript.increaseBombAttackTime = 10f;
                                ValueDeliverScript.increaseBombAttackPercent = 0.80f;
                                break;
                            case 0008:
                                ValueDeliverScript.isIncreaseBombAttackPercent = true;
                                ValueDeliverScript.increaseBombAttackTime = 10f;
                                ValueDeliverScript.increaseBombAttackPercent = 0.85f;
                                break;
                            case 0009:
                                ValueDeliverScript.isIncreaseBombAttackPercent = true;
                                ValueDeliverScript.increaseBombAttackTime = 10f;
                                ValueDeliverScript.increaseBombAttackPercent = 0.90f;
                                break;
                            case 0010:
                                ValueDeliverScript.isIncreaseBombAttackPercent = true;
                                ValueDeliverScript.increaseBombAttackTime = 10f;
                                ValueDeliverScript.increaseBombAttackPercent = 1f;
                                break;
                        }
                        #endregion
                        break;

                    case 004:	//포커-최고의자리.(완)
                        #region case004
                        if (ValueDeliverScript.activeOper == 3)
                        {
                            switch (ValueDeliverScript.skinLevel)
                            {
                                case 0001:
                                    ValueDeliverScript.addAttackAbility += 100; break;
                                case 0002:
                                    ValueDeliverScript.addAttackAbility += 105; break;
                                case 0003:
                                    ValueDeliverScript.addAttackAbility += 110; break;
                                case 0004:
                                    ValueDeliverScript.addAttackAbility += 115; break;
                                case 0005:
                                    ValueDeliverScript.addAttackAbility += 120; break;
                                case 0006:
                                    ValueDeliverScript.addAttackAbility += 125; break;
                                case 0007:
                                    ValueDeliverScript.addAttackAbility += 130; break;
                                case 0008:
                                    ValueDeliverScript.addAttackAbility += 135; break;
                                case 0009:
                                    ValueDeliverScript.addAttackAbility += 140; break;
                                case 0010:
                                    ValueDeliverScript.addAttackAbility += 150; break;
                            }
                        }
                        else
                        {
                            ValueDeliverScript.skin00_04Effect = 0;
                        }

                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                ValueDeliverScript.isIncreaseScorePercent = true;
                                ValueDeliverScript.increaseScorePercent = 0.10f;
                                //ValueDeliverScript.shieldDestroyAddScorePercent = 0f;

                                break;
                            case 0002:
                                ValueDeliverScript.isIncreaseScorePercent = true;
                                ValueDeliverScript.increaseScorePercent = 0.105f;
                                //ValueDeliverScript.shieldDestroyAddScorePercent = 0f;
                                break;
                            case 0003:
                                ValueDeliverScript.isIncreaseScorePercent = true;
                                ValueDeliverScript.increaseScorePercent = 0.11f;
                                //ValueDeliverScript.shieldDestroyAddScorePercent = 0f;
                                break;
                            case 0004:
                                ValueDeliverScript.isIncreaseScorePercent = true;
                                ValueDeliverScript.increaseScorePercent = 0.115f;
                                //ValueDeliverScript.shieldDestroyAddScorePercent = 0f;
                                break;
                            case 0005:
                                ValueDeliverScript.isIncreaseScorePercent = true;
                                ValueDeliverScript.increaseScorePercent = 0.12f;
                                //ValueDeliverScript.shieldDestroyAddScorePercent = 0f;
                                break;
                            case 0006:
                                ValueDeliverScript.isIncreaseScorePercent = true;
                                ValueDeliverScript.increaseScorePercent = 0.125f;
                                //ValueDeliverScript.shieldDestroyAddScorePercent = 0.01f;
                                break;
                            case 0007:
                                ValueDeliverScript.isIncreaseScorePercent = true;
                                ValueDeliverScript.increaseScorePercent = 0.13f;
                                //ValueDeliverScript.shieldDestroyAddScorePercent = 0.02f;
                                break;
                            case 0008:
                                ValueDeliverScript.isIncreaseScorePercent = true;
                                ValueDeliverScript.increaseScorePercent = 0.135f;
                                //ValueDeliverScript.shieldDestroyAddScorePercent = 0.03f;
                                break;
                            case 0009:
                                ValueDeliverScript.isIncreaseScorePercent = true;
                                ValueDeliverScript.increaseScorePercent = 0.14f;
                                //ValueDeliverScript.shieldDestroyAddScorePercent = 0.04f;
                                break;
                            case 0010:
                                ValueDeliverScript.isIncreaseScorePercent = true;
                                ValueDeliverScript.increaseScorePercent = 0.15f;
                                //ValueDeliverScript.shieldDestroyAddScorePercent = 0.05f;
                                break;
                        }
                        #endregion
                        break;

                    case 005:	//포커-엔지니어.-광복절와서 할부분.(완)
                        #region case005
                        //싱글증폭기 공격력 증가 효과는 인게임온로드스크립트 Reinforce01 부분을 참고.
                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                ValueDeliverScript.powerUpDropChance = 1000;	//1/10000로 표시.
                                break;
                            case 0002:
                                ValueDeliverScript.powerUpDropChance = 1100;	//1/10000로 표시.
                                break;
                            case 0003:
                                ValueDeliverScript.powerUpDropChance = 1200;	//1/10000로 표시.
                                break;
                            case 0004:
                                ValueDeliverScript.powerUpDropChance = 1300;	//1/10000로 표시.
                                break;
                            case 0005:
                                ValueDeliverScript.powerUpDropChance = 1400;	//1/10000로 표시.
                                break;
                            case 0006:
                                ValueDeliverScript.powerUpDropChance = 1500;	//1/10000로 표시.
                                break;
                            case 0007:
                                ValueDeliverScript.powerUpDropChance = 1600;	//1/10000로 표시.
                                break;
                            case 0008:
                                ValueDeliverScript.powerUpDropChance = 1700;	//1/10000로 표시.
                                break;
                            case 0009:
                                ValueDeliverScript.powerUpDropChance = 1800;	//1/10000로 표시.
                                break;
                            case 0010:
                                ValueDeliverScript.powerUpDropChance = 2000; //1/10000로 표시.
                                break;
                        }
                        #endregion
                        break;
                }
                break;


            case 01:	//코만치.
                switch (ValueDeliverScript.skinNumber)
                {
                    case 000:	//기본스킨.
                        //기본스킨- 스킨에 의한 추가기능 없음.
                        break;

                    case 001:	//코만치-바람개비.(완)
                        #region case001
                        //스킬회복량 표시는 인게임온로드스크립트Reinforce03참고. 
                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                ValueDeliverScript.isdamageAddChance = true;
                                ValueDeliverScript.damageAddChance = 2000;
                                ValueDeliverScript.damageAddPercent = 0.5f;
                                break;
                            case 0002:
                                ValueDeliverScript.isdamageAddChance = true;
                                ValueDeliverScript.damageAddChance = 2000;
                                ValueDeliverScript.damageAddPercent = 0.55f;
                                break;
                            case 0003:
                                ValueDeliverScript.isdamageAddChance = true;
                                ValueDeliverScript.damageAddChance = 2000;
                                ValueDeliverScript.damageAddPercent = 0.6f;
                                break;
                            case 004:
                                ValueDeliverScript.isdamageAddChance = true;
                                ValueDeliverScript.damageAddChance = 2000;
                                ValueDeliverScript.damageAddPercent = 0.65f;
                                break;
                            case 0005:
                                ValueDeliverScript.isdamageAddChance = true;
                                ValueDeliverScript.damageAddChance = 2000;
                                ValueDeliverScript.damageAddPercent = 0.7f;
                                break;
                            case 0006:
                                ValueDeliverScript.isdamageAddChance = true;
                                ValueDeliverScript.damageAddChance = 2000;
                                ValueDeliverScript.damageAddPercent = 0.75f;
                                break;
                            case 0007:
                                ValueDeliverScript.isdamageAddChance = true;
                                ValueDeliverScript.damageAddChance = 2000;
                                ValueDeliverScript.damageAddPercent = 0.8f;
                                break;
                            case 0008:
                                ValueDeliverScript.isdamageAddChance = true;
                                ValueDeliverScript.damageAddChance = 2000;
                                ValueDeliverScript.damageAddPercent = 0.85f;
                                break;
                            case 0009:
                                ValueDeliverScript.isdamageAddChance = true;
                                ValueDeliverScript.damageAddChance = 2000;
                                ValueDeliverScript.damageAddPercent = 0.9f;
                                break;
                            case 0010:
                                ValueDeliverScript.isdamageAddChance = true;
                                ValueDeliverScript.damageAddChance = 2000;
                                ValueDeliverScript.damageAddPercent = 1f;
                                break;
                        }
                        #endregion
                        break;

                    case 002:	//코만치-티클모아태산.(완)
                        #region case002
                        //자석으로 인한 공격력증가는 인게임온로드스크립트 Assist02 참고.
                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                ValueDeliverScript.coinAddChance = 1000;
                                ValueDeliverScript.coinAddNumber = 2;
                                break;
                            case 0002:
                                ValueDeliverScript.coinAddChance = 1100;
                                ValueDeliverScript.coinAddNumber = 2;
                                break;
                            case 0003:
                                ValueDeliverScript.coinAddChance = 1200;
                                ValueDeliverScript.coinAddNumber = 2;
                                break;
                            case 004:
                                ValueDeliverScript.coinAddChance = 1300;
                                ValueDeliverScript.coinAddNumber = 2;
                                break;
                            case 0005:
                                ValueDeliverScript.coinAddChance = 1400;
                                ValueDeliverScript.coinAddNumber = 2;
                                break;
                            case 0006:
                                ValueDeliverScript.coinAddChance = 1500;
                                ValueDeliverScript.coinAddNumber = 2;
                                break;
                            case 0007:
                                ValueDeliverScript.coinAddChance = 1600;
                                ValueDeliverScript.coinAddNumber = 2;
                                break;
                            case 0008:
                                ValueDeliverScript.coinAddChance = 1700;
                                ValueDeliverScript.coinAddNumber = 2;
                                break;
                            case 0009:
                                ValueDeliverScript.coinAddChance = 1800;
                                ValueDeliverScript.coinAddNumber = 2;
                                break;
                            case 0010:
                                ValueDeliverScript.coinAddChance = 2000;
                                ValueDeliverScript.coinAddNumber = 2;
                                break;
                        }
                        #endregion
                        break;

                    case 003:	//코만치-탱크킬러.(완)
                        #region case003
                        //연사력 증가는 인게임온로드스크립트  Assist04참고.
                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                ValueDeliverScript.rechargeEnergy = 10;
                                break;
                            case 0002:
                                ValueDeliverScript.rechargeEnergy = 11;
                                break;
                            case 0003:
                                ValueDeliverScript.rechargeEnergy = 12;
                                break;
                            case 004:
                                ValueDeliverScript.rechargeEnergy = 13;
                                break;
                            case 0005:
                                ValueDeliverScript.rechargeEnergy = 14;
                                break;
                            case 0006:
                                ValueDeliverScript.rechargeEnergy = 15;
                                break;
                            case 0007:
                                ValueDeliverScript.rechargeEnergy = 16;
                                break;
                            case 0008:
                                ValueDeliverScript.rechargeEnergy = 17;
                                break;
                            case 0009:
                                ValueDeliverScript.rechargeEnergy = 18;
                                break;
                            case 0010:
                                ValueDeliverScript.rechargeEnergy = 20;
                                break;
                        }
                        #endregion
                        break;

                    case 004:	//코만치-캣츠아이.(완)  - 파워업 획득시 핵폭탄 쿨타임 감소.
                        #region case004
                        //블랙홀 핵폭탄 지속시간 증가는 블랙홀 봄 스크립트 참고
                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                ValueDeliverScript.isBombRechargeDecrease = true;
                                ValueDeliverScript.bombRechargeDecrease = 2f;
                                //ValueDeliverScript.addSkillGagePercent = 0;
                                break;
                            case 0002:
                                ValueDeliverScript.isBombRechargeDecrease = true;
                                ValueDeliverScript.bombRechargeDecrease = 2.1f;
                                //ValueDeliverScript.addSkillGagePercent = 0;
                                break;
                            case 0003:
                                ValueDeliverScript.isBombRechargeDecrease = true;
                                ValueDeliverScript.bombRechargeDecrease = 2.2f;
                                //ValueDeliverScript.addSkillGagePercent = 0;
                                break;
                            case 004:
                                ValueDeliverScript.isBombRechargeDecrease = true;
                                ValueDeliverScript.bombRechargeDecrease = 2.3f;
                                //ValueDeliverScript.addSkillGagePercent = 0;
                                break;
                            case 0005:
                                ValueDeliverScript.isBombRechargeDecrease = true;
                                ValueDeliverScript.bombRechargeDecrease = 2.4f;
                                //ValueDeliverScript.addSkillGagePercent = 0;
                                break;
                            case 0006:
                                ValueDeliverScript.isBombRechargeDecrease = true;
                                ValueDeliverScript.bombRechargeDecrease = 2.5f;
                                //ValueDeliverScript.addSkillGagePercent = 100;
                                break;
                            case 0007:
                                ValueDeliverScript.isBombRechargeDecrease = true;
                                ValueDeliverScript.bombRechargeDecrease = 2.6f;
                                //ValueDeliverScript.addSkillGagePercent = 200;
                                break;
                            case 0008:
                                ValueDeliverScript.isBombRechargeDecrease = true;
                                ValueDeliverScript.bombRechargeDecrease = 2.7f;
                                //ValueDeliverScript.addSkillGagePercent = 300;
                                break;
                            case 0009:
                                ValueDeliverScript.isBombRechargeDecrease = true;
                                ValueDeliverScript.bombRechargeDecrease = 2.8f;
                                //ValueDeliverScript.addSkillGagePercent = 400;
                                break;
                            case 0010:
                                ValueDeliverScript.isBombRechargeDecrease = true;
                                ValueDeliverScript.bombRechargeDecrease = 3f;
                                //ValueDeliverScript.addSkillGagePercent = 500;
                                break;
                        }
                        #endregion
                        break;

                    case 005:	//코만치-악마의숨결.(완)
                        #region case005
                        //에이단 장착 스피드 증가는 플레이어무브스크립트를 참고.
                        switch (ValueDeliverScript.skinLevel)
                        {
                                //뒤에 0.2f로 붙는 것은 강화 포인트 1당 증가하는 값을 얘기하는것 속도가 20이 늘어난다는 것은//
                                //실제론 20 에 0.2를 곱한 값을 얘기하는 것임//
                            case 0001:
                                ValueDeliverScript.scoreIncreasePercent = 0.3f;
                                if (ValueDeliverScript.activeOper == 2)
                                    ValueDeliverScript.comancheDeveilBreathAddSpeed = 20f * 0.2f;
                                break;
                            case 0002:
                                ValueDeliverScript.scoreIncreasePercent = 0.32f;
                                if (ValueDeliverScript.activeOper == 2)
                                    ValueDeliverScript.comancheDeveilBreathAddSpeed = 21f * 0.2f;
                                break;
                            case 0003:
                                ValueDeliverScript.scoreIncreasePercent = 0.34f;
                                if (ValueDeliverScript.activeOper == 2)
                                    ValueDeliverScript.comancheDeveilBreathAddSpeed = 22f * 0.2f;
                                break;
                            case 004:
                                ValueDeliverScript.scoreIncreasePercent = 0.36f;
                                if (ValueDeliverScript.activeOper == 2)
                                    ValueDeliverScript.comancheDeveilBreathAddSpeed = 23f * 0.2f;
                                break;
                            case 0005:
                                ValueDeliverScript.scoreIncreasePercent = 0.38f;
                                if (ValueDeliverScript.activeOper == 2)
                                    ValueDeliverScript.comancheDeveilBreathAddSpeed = 24f * 0.2f;
                                break;
                            case 0006:
                                ValueDeliverScript.scoreIncreasePercent = 0.40f;
                                if (ValueDeliverScript.activeOper == 2)
                                    ValueDeliverScript.comancheDeveilBreathAddSpeed = 25f * 0.2f;
                                break;
                            case 0007:
                                ValueDeliverScript.scoreIncreasePercent = 0.42f;
                                if (ValueDeliverScript.activeOper == 2)
                                    ValueDeliverScript.comancheDeveilBreathAddSpeed = 26f * 0.2f;
                                break;
                            case 0008:
                                ValueDeliverScript.scoreIncreasePercent = 0.44f;
                                if (ValueDeliverScript.activeOper == 2)
                                    ValueDeliverScript.comancheDeveilBreathAddSpeed = 27f * 0.2f;
                                break;
                            case 0009:
                                ValueDeliverScript.scoreIncreasePercent = 0.47f;
                                if (ValueDeliverScript.activeOper == 2)
                                    ValueDeliverScript.comancheDeveilBreathAddSpeed = 28f * 0.2f;
                                break;
                            case 0010:
                                ValueDeliverScript.scoreIncreasePercent = 0.50f;
                                if (ValueDeliverScript.activeOper == 2)
                                    ValueDeliverScript.comancheDeveilBreathAddSpeed = 30f * 0.2f;
                                break;
                        }
                        #endregion
                        break;
                }
                break;

            case 02:	//팬텀.
                switch (ValueDeliverScript.skinNumber)
                {
                    case 000:	//기본스킨.
                        //기본스킨- 스킨에 의한 추가기능 없음.
                        break;

                    case 001:	//팬텀-검은불꽃.(완)
                        #region case001
                        //추가기능은 인게임온로드스크립트 Reinforce02 참고.
                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                ValueDeliverScript.spinballDamagePercent = 0.50f;
                                break;
                            case 0002:
                                ValueDeliverScript.spinballDamagePercent = 0.55f;
                                break;
                            case 0003:
                                ValueDeliverScript.spinballDamagePercent = 0.60f;
                                break;
                            case 004:
                                ValueDeliverScript.spinballDamagePercent = 0.65f;
                                break;
                            case 0005:
                                ValueDeliverScript.spinballDamagePercent = 0.70f;
                                break;
                            case 0006:
                                ValueDeliverScript.spinballDamagePercent = 0.75f;
                                break;
                            case 0007:
                                ValueDeliverScript.spinballDamagePercent = 0.80f;
                                break;
                            case 0008:
                                ValueDeliverScript.spinballDamagePercent = 0.85f;
                                break;
                            case 0009:
                                ValueDeliverScript.spinballDamagePercent = 0.90f;
                                break;
                            case 0010:
                                ValueDeliverScript.spinballDamagePercent = 1.00f;
                                break;
                        }
                        #endregion
                        break;

                    case 002:	//팬텀-환상의날개.(완)
                        #region case002
                        //추가기능은 봄스킬게이지스크립트 플라즈마 폭발(BombGageZero) 참고.
                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                ValueDeliverScript.specialBombRechargeDecrease = 5f;
                                break;
                            case 0002:
                                ValueDeliverScript.specialBombRechargeDecrease = 5.5f;
                                break;
                            case 0003:
                                ValueDeliverScript.specialBombRechargeDecrease = 6f;
                                break;
                            case 004:
                                ValueDeliverScript.specialBombRechargeDecrease = 6.5f;
                                break;
                            case 0005:
                                ValueDeliverScript.specialBombRechargeDecrease = 7f;
                                break;
                            case 0006:
                                ValueDeliverScript.specialBombRechargeDecrease = 7.5f;
                                break;
                            case 0007:
                                ValueDeliverScript.specialBombRechargeDecrease = 8f;
                                break;
                            case 0008:
                                ValueDeliverScript.specialBombRechargeDecrease = 8.5f;
                                break;
                            case 0009:
                                ValueDeliverScript.specialBombRechargeDecrease = 9f;
                                break;
                            case 0010:
                                ValueDeliverScript.specialBombRechargeDecrease = 10f;
                                break;
                        }
                        #endregion
                        break;

                    case 003:	//팬텀-돈벼락.(완)
                        #region case003
                        //추가기능은 인게임온로드스크립트 Assist05 참고.
                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                ValueDeliverScript.wingboxAddtime = 3.0f;
                                break;
                            case 0002:
                                ValueDeliverScript.wingboxAddtime = 3.2f;
                                break;
                            case 0003:
                                ValueDeliverScript.wingboxAddtime = 3.4f;
                                break;
                            case 004:
                                ValueDeliverScript.wingboxAddtime = 3.6f;
                                break;
                            case 0005:
                                ValueDeliverScript.wingboxAddtime = 3.8f;
                                break;
                            case 0006:
                                ValueDeliverScript.wingboxAddtime = 4.0f;
                                break;
                            case 0007:
                                ValueDeliverScript.wingboxAddtime = 4.2f;
                                break;
                            case 0008:
                                ValueDeliverScript.wingboxAddtime = 4.4f;
                                break;
                            case 0009:
                                ValueDeliverScript.wingboxAddtime = 4.7f;
                                break;
                            case 0010:
                                ValueDeliverScript.wingboxAddtime = 5f;
                                break;
                        }
                        #endregion
                        break;

                    case 004:	//팬텀-구원의손길.(완)
                        #region case004
                        //레이첼일경우 공격력 증가.
                        if (ValueDeliverScript.activeOper == 4)
                        {
                            switch (ValueDeliverScript.skinLevel)
                            {
                                case 0001:
                                    ValueDeliverScript.skin02_04Effect = 0.5f;
                                    break;
                                case 0002:
                                    ValueDeliverScript.skin02_04Effect = 0.6f;
                                    break;
                                case 0003:
                                    ValueDeliverScript.skin02_04Effect = 0.7f;
                                    break;
                                case 004:
                                    ValueDeliverScript.skin02_04Effect = 0.8f;
                                    break;
                                case 0005:
                                     ValueDeliverScript.skin02_04Effect = 0.9f;
                                   break;
                                case 0006:
                                    ValueDeliverScript.skin02_04Effect = 1.0f;
                                    break;
                                case 0007:
                                    ValueDeliverScript.skin02_04Effect = 1.1f;
                                    break;
                                case 0008:
                                    ValueDeliverScript.skin02_04Effect = 1.2f;
                                    break;
                                case 0009:
                                    ValueDeliverScript.skin02_04Effect = 1.35f;
                                    break;
                                case 0010:
                                    ValueDeliverScript.skin02_04Effect = 1.5f;
                                    break;
                            }

                        }
                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                ValueDeliverScript.friendFlightAddTime = 5.0f;
                                break;
                            case 0002:
                                ValueDeliverScript.friendFlightAddTime = 5.2f;
                                break;
                            case 0003:
                                ValueDeliverScript.friendFlightAddTime = 5.4f;
                                break;
                            case 004:
                                ValueDeliverScript.friendFlightAddTime = 5.6f;
                                break;
                            case 0005:
                                ValueDeliverScript.friendFlightAddTime = 5.8f;
                                break;
                            case 0006:
                                ValueDeliverScript.friendFlightAddTime = 6.0f;
                                break;
                            case 0007:
                                ValueDeliverScript.friendFlightAddTime = 6.2f;
                                break;
                            case 0008:
                                ValueDeliverScript.friendFlightAddTime = 6.4f;
                                break;
                            case 0009:
                                ValueDeliverScript.friendFlightAddTime = 6.7f;
                                break;
                            case 0010:
                                ValueDeliverScript.friendFlightAddTime = 7.0f;
                                break;
                        }
                        #endregion
                        break;

                    case 005:	//팬텀-거위의꿈.(완)
                        #region case005
                        //추가 효과는 인게임온로드스크립트 Assist01 참고.
                        switch (ValueDeliverScript.skinLevel)
                        {
                            case 0001:
                                ValueDeliverScript.applyPortalLevel = 5;
                                ValueDeliverScript.skin02_05Effect1 = 0.50f; 
                                break;
                            case 0002:
                                ValueDeliverScript.applyPortalLevel = 5;
                                ValueDeliverScript.skin02_05Effect1 = 0.55f; 
                                break;
                            case 0003:
                                ValueDeliverScript.applyPortalLevel = 5;
                                ValueDeliverScript.skin02_05Effect1 = 0.60f; 
                                break;
                            case 004:
                                ValueDeliverScript.applyPortalLevel = 5;
                                ValueDeliverScript.skin02_05Effect1 = 0.65f; 
                                break;
                            case 0005:
                                ValueDeliverScript.applyPortalLevel = 5;
                                ValueDeliverScript.skin02_05Effect1 = 0.70f; 
                                break;
                            case 0006:
                                ValueDeliverScript.applyPortalLevel = 5;
                                ValueDeliverScript.skin02_05Effect1 = 0.75f; 
                                break;
                            case 0007:
                                ValueDeliverScript.applyPortalLevel = 5;
                                ValueDeliverScript.skin02_05Effect1 = 0.80f; 
                                break;
                            case 0008:
                                ValueDeliverScript.applyPortalLevel = 5;
                                ValueDeliverScript.skin02_05Effect1 = 0.85f; 
                                break;
                            case 0009:
                                ValueDeliverScript.applyPortalLevel = 5;
                                ValueDeliverScript.skin02_05Effect1 = 0.90f; 
                                break;
                            case 0010:
                                ValueDeliverScript.applyPortalLevel = 5;
                                ValueDeliverScript.skin02_05Effect1 = 1.00f;
                                break;
                        }
                        #endregion
                        break;
                }
                break;
        }
    }
}