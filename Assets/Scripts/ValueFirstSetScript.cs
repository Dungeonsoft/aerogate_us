using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class ValueFirstSetScript : MonoBehaviour
{
    /*

 * 
 * 
    IEnumerator FNtest()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("시작시 비행기 번호 :::: " + ValueDeliverScript.gameData["flightNumber"].ToString());
        }
    }

    void Awake()
    {
        string _res;

        //Debug.Log("ValueFirstSetScript");
        if (PlayerPrefs.HasKey("GameData"))
        {
            _res = PlayerPrefs.GetString("GameData");

            Dictionary<string, object> gameData = MiniJSON.Json.Deserialize(_res) as Dictionary<string, object>;

            ValueDeliverScript.gameData = gameData; //여기에서 

            foreach (var data in gameData)
            {
                //Debug.Log(data);
            }
            return;
        }
        else
        {
            //Debug.Log("ValueFirstSetScript - No Key");

            Dictionary<string, object> gameData = new Dictionary<string, object>();

            //////////////////////////////////////////////////////////////////////////////////////////
            //Json으로 게임에 들어가는 데이터들을 선언.
            gameData.Add("Nick", "");
            gameData.Add("UserID", "");
            gameData.Add("UserRankingGroup", 0);

            gameData.Add("flightNumber", 0);    //처음시작할때 비행기 번호(0은 포커)

            gameData.Add("scoreHigh", 0);
            gameData.Add("lastScoreHigh", 0); //지난주 최고점수.
            gameData.Add("coinRest", 2500);    //남아있는 코인갯수.
            gameData.Add("medalRest", 10);  //남아있는 메달갯수.(블루 다이아몬드)

            gameData.Add("highFlight", 0);  //최고점수기체.
            gameData.Add("highSkin", 0);    //최고점수스킨.
            gameData.Add("highChar", 0);    //최고점수캐릭터.
            gameData.Add("highBullet", 0);  //최고점수총알.
            gameData.Add("highBomb", 0);    //최고점수폭탄.
            gameData.Add("highReinforce", 0);   //최고점수강화품.
            gameData.Add("highAssist", 0);  //최고점수보조품.

            gameData.Add("dartCount", 0);
            gameData.Add("dustCount", 0);
            gameData.Add("shieldCount", 0);
            gameData.Add("spinballCount", 0);
            gameData.Add("gasRest", 5);     //남아있는 연료갯수.
            gameData.Add("userLevel", 0);   //유저레벨.
            gameData.Add("userExp", 0);     //유저경험치.

            //내비행기목록.레벨치.
            gameData.Add("flight000Skin", 0);
            gameData.Add("flight000Bullet", 1);
            gameData.Add("flight000Skill", 1);
            gameData.Add("flight001Skin", 0);
            gameData.Add("flight001Bullet", 1);
            gameData.Add("flight001Skill", 1);
            gameData.Add("flight002Skin", 0);
            gameData.Add("flight002Bullet", 1);
            gameData.Add("flight002Skill", 1);
            //내비행기목록.레벨치.

            //스킨경험치
            gameData.Add("FlightExp000Skin001", 0);
            gameData.Add("FlightExp000Skin002", 0);
            gameData.Add("FlightExp000Skin003", 0);
            gameData.Add("FlightExp000Skin004", 0);
            gameData.Add("FlightExp000Skin005", 0);

            gameData.Add("FlightExp001Skin001", 0);
            gameData.Add("FlightExp001Skin002", 0);
            gameData.Add("FlightExp001Skin003", 0);
            gameData.Add("FlightExp001Skin004", 0);
            gameData.Add("FlightExp001Skin005", 0);

            gameData.Add("FlightExp002Skin001", 0);
            gameData.Add("FlightExp002Skin002", 0);
            gameData.Add("FlightExp002Skin003", 0);
            gameData.Add("FlightExp002Skin004", 0);
            gameData.Add("FlightExp002Skin005", 0);
            //스킨경험치


            //스킨레벨
            gameData.Add("FlightLev000Skin001", 1);
            gameData.Add("FlightLev000Skin002", 1);
            gameData.Add("FlightLev000Skin003", 1);
            gameData.Add("FlightLev000Skin004", 1);
            gameData.Add("FlightLev000Skin005", 1);

            gameData.Add("FlightLev001Skin001", 1);
            gameData.Add("FlightLev001Skin002", 1);
            gameData.Add("FlightLev001Skin003", 1);
            gameData.Add("FlightLev001Skin004", 1);
            gameData.Add("FlightLev001Skin005", 1);

            gameData.Add("FlightLev002Skin001", 1);
            gameData.Add("FlightLev002Skin002", 1);
            gameData.Add("FlightLev002Skin003", 1);
            gameData.Add("FlightLev002Skin004", 1);
            gameData.Add("FlightLev002Skin005", 1);
            //스킨경험치


            //스킨내구도
            gameData.Add("FlightDura000Skin001", 10);
            gameData.Add("FlightDura000Skin002", 10);
            gameData.Add("FlightDura000Skin003", 10);
            gameData.Add("FlightDura000Skin004", 10);
            gameData.Add("FlightDura000Skin005", 10);

            gameData.Add("FlightDura001Skin001", 10);
            gameData.Add("FlightDura001Skin002", 10);
            gameData.Add("FlightDura001Skin003", 10);
            gameData.Add("FlightDura001Skin004", 10);
            gameData.Add("FlightDura001Skin005", 10);

            gameData.Add("FlightDura002Skin001", 10);
            gameData.Add("FlightDura002Skin002", 10);
            gameData.Add("FlightDura002Skin003", 10);
            gameData.Add("FlightDura002Skin004", 10);
            gameData.Add("FlightDura002Skin005", 10);
            //스킨내구도

            //이큅소유량
            gameData.Add("EquipBomb01", 5);//플라즈마웨이브.
            gameData.Add("EquipBomb02", 0);
            gameData.Add("EquipBomb03", 0);
            gameData.Add("EquipBomb04", 0);
            gameData.Add("EquipBomb05", 0);//블랙홀.
            gameData.Add("EquipBomb06", 0);
            gameData.Add("EquipBomb07", 0);
            gameData.Add("EquipBomb08", 0);
            gameData.Add("EquipBomb09", 0);
            gameData.Add("EquipBomb10", 0);
            gameData.Add("EquipBomb11", 0);
            gameData.Add("EquipBomb12", 0);

            gameData.Add("EquipReinforce01", 0);//싱글증폭기.
            gameData.Add("EquipReinforce02", 0);//듀얼증폭기.
            gameData.Add("EquipReinforce03", 0);//스핀볼탐지증폭기.
            gameData.Add("EquipReinforce04", 0);//다트탐지증폭기.
            gameData.Add("EquipReinforce05", 0);//더스트탐지증폭기.
            gameData.Add("EquipReinforce06", 0);//실드탐지증폭기.
            gameData.Add("EquipReinforce07", 0);//크리티컬엑셀레이터.
            gameData.Add("EquipReinforce08", 0);//파이널파워업.
            gameData.Add("EquipReinforce09", 0);
            gameData.Add("EquipReinforce10", 0);
            gameData.Add("EquipReinforce11", 0);
            gameData.Add("EquipReinforce12", 0);

            gameData.Add("EquipAssist01", 5);//보호막.(쉴드)
            gameData.Add("EquipAssist02", 0);//자석.
            gameData.Add("EquipAssist03", 0);//빠른핵폭탄.(숏봄)
            gameData.Add("EquipAssist04", 0);//스킬드레인.(에너지드레인)
            gameData.Add("EquipAssist05", 0);//더블윙박스.
            gameData.Add("EquipAssist06", 0);//스트롱웜홀.
            gameData.Add("EquipAssist07", 0);
            gameData.Add("EquipAssist08", 0);
            gameData.Add("EquipAssist09", 0);
            gameData.Add("EquipAssist10", 0);
            gameData.Add("EquipAssist11", 0);
            gameData.Add("EquipAssist12", 0);

            gameData.Add("EquipOper01", 1);//덴모렌.
            gameData.Add("EquipOper02", 0);//에이단.
            gameData.Add("EquipOper03", 0);//레이첼.
            gameData.Add("EquipOper04", 0);//윤세미.
            gameData.Add("EquipOper05", 0);
            gameData.Add("EquipOper06", 0);
            gameData.Add("EquipOper07", 0);
            gameData.Add("EquipOper08", 0);
            gameData.Add("EquipOper09", 0);
            gameData.Add("EquipOper10", 0);
            gameData.Add("EquipOper11", 0);
            gameData.Add("EquipOper12", 0);
            //이큅소유량

            gameData.Add("activeBomb", 5);
            gameData.Add("activeReinforce", 0);
            gameData.Add("activeAssist", 0);
            gameData.Add("activeOper", 1);
            gameData.Add("isSpecialMissionSelect", 0);  //원래불린 - 0과 1로 처리할것-
            gameData.Add("specialAttackTyp", 0);
            gameData.Add("isSpecialAttackOn", 0);   //원래불린 - 0과 1로 처리할것-
            gameData.Add("playerName", "Player");
            gameData.Add("specialEndTime", "");
            gameData.Add("specialAttackItemName", "");
            gameData.Add("specialAttackItemMaxNumber", 0);
            gameData.Add("gasLastAddTime", "");
            gameData.Add("gasNextAddTime", "");
            gameData.Add("timeRecord", 0);

            gameData.Add("flight000SortieNumber", 0);
            gameData.Add("flight000BombUseNumber", 0);
            gameData.Add("flight000ScoreHigh", 0);
            gameData.Add("flight001EnemyKill", 0);
            gameData.Add("flight001GetCoin", 0);
            gameData.Add("flight001UseSkill", 0);
            gameData.Add("flight001GetPowerItem", 0);
            gameData.Add("flight002KillSpinball", 0);
            gameData.Add("flight002SpecialAttack", 0);
            gameData.Add("flight002CompleteInstanceMission", 0);
            gameData.Add("flight002RescueFriend", 0);
            gameData.Add("flight002WormLevel5", 0);   //원래불린 - 0과 1로 처리할것-

            //스킨락오프 //원래불린 - 0과 1로 처리할것-
            gameData.Add("FlightLock000Skin001", 0);
            gameData.Add("FlightLock000Skin002", 0);
            gameData.Add("FlightLock000Skin003", 0);
            gameData.Add("FlightLock000Skin004", 0);
            gameData.Add("FlightLock000Skin005", 0);

            gameData.Add("FlightLock001Skin001", 0);
            gameData.Add("FlightLock001Skin002", 0);
            gameData.Add("FlightLock001Skin003", 0);
            gameData.Add("FlightLock001Skin004", 0);
            gameData.Add("FlightLock001Skin005", 0);

            gameData.Add("FlightLock002Skin001", 0);
            gameData.Add("FlightLock002Skin002", 0);
            gameData.Add("FlightLock002Skin003", 0);
            gameData.Add("FlightLock002Skin004", 0);
            gameData.Add("FlightLock002Skin005", 0);
            //스킨락오프

            //플라이트락오프
            gameData.Add("FlightLockOff000", 2);
            gameData.Add("FlightLockOff001", 0);
            gameData.Add("FlightLockOff002", 0);
            gameData.Add("FlightLockOff001Coin", 29000);
            gameData.Add("FlightLockOff002Coin", 36000);
            gameData.Add("FlightLockOff001Medal", 49);
            gameData.Add("FlightLockOff002Medal", 59);
            //플라이트락오프

            gameData.Add("isFirstAccess", 0);
            gameData.Add("upgradePoint", 0);
            gameData.Add("upgradePointF00P01", 0);
            gameData.Add("upgradePointF00P02", 0);
            gameData.Add("upgradePointF00P03", 0);
            gameData.Add("upgradePointF00P04", 0);
            gameData.Add("upgradePointF01P01", 0);
            gameData.Add("upgradePointF01P02", 0);
            gameData.Add("upgradePointF01P03", 0);
            gameData.Add("upgradePointF01P04", 0);
            gameData.Add("upgradePointF02P01", 0);
            gameData.Add("upgradePointF02P02", 0);
            gameData.Add("upgradePointF02P03", 0);
            gameData.Add("upgradePointF02P04", 0);

            gameData.Add("pointResetCount", 0);
            gameData.Add("todayInt", 0);
            gameData.Add("FriendRequestCount", 0);
            gameData.Add("FuelSendCount", 0);
            gameData.Add("invitedFriendCount", 0);

            //우정포인트-백점당 1회의 랜덤 뽁기가 가능.
            gameData.Add("friendshipPoint", 100);
            //우정포인트-백점당 1회의 랜덤 뽁기가 가능.

            ValueDeliverScript.gameData = gameData;
            //Json으로 게임에 들어가는 데이터들을 선언.
            //////////////////////////////////////////////////////////////////////////////////////////

            string gameDataStr = MiniJSON.Json.Serialize(gameData);
            PlayerPrefs.SetString("GameData", gameDataStr);
        }
    }
     * */
}

