using UnityEngine;
using System.Collections;

[System.Serializable]
public class BulletArray
{
    public GameObject[] bullet;
}

public class ObjectPoolScript : MonoBehaviour
{
    public Texture[] flight001Skin;
    public Texture[] flight002Skin;
    public Texture[] flight003Skin;

    public GameObject[] PC = new GameObject[2]; //플레이어 오브젝트 - 비행기.

    public BulletArray[] bullet; //총알 오브젝트.

    public int makeBulletNumber = 35;

    public GameObject missileComancheTf01;	//코만치 총알미사일 오브젝트.
    public GameObject missileComancheTf02;	//코만치 총알미사일 오브젝트.
    public GameObject missileComancheTf03;	//코만치 총알미사일 오브젝트.
    public GameObject missileComancheTf04;	//코만치 총알미사일 오브젝트.
    public GameObject missileComancheTf05;	//코만치 총알미사일 오브젝트.
    public GameObject missileComancheTf06;	//코만치 총알미사일 오브젝트.

    public int missileComancheTfNumber = 10;	//코만치 총알미사일 오브젝트 갯수.

    public GameObject missilePantomTf01;	//코만치 총알미사일 오브젝트.
    public GameObject missilePantomTf02;	//코만치 총알미사일 오브젝트.
    public int missilePantomTfNumber = 10;	//코만치 총알미사일 오브젝트 갯수.

    public GameObject skillBullet01; //파워총알 오브젝트.
    public int skillBullet01Number = 3; // 파워총알 오브젝트 갯수.

    public GameObject skillBullet02; //파워총알 오브젝트.
    public int skillBullet02Number = 3; // 파워총알 오브젝트 갯수.

    public GameObject skillBullet03; //파워총알 오브젝트.
    public int skillBullet03Number = 3; // 파워총알 오브젝트 갯수.

    public GameObject skillBullet04; //파워총알 오브젝트.
    public int skillBullet04Number = 3; // 파워총알 오브젝트 갯수.




    public GameObject portal01; //적기를 생성하는 포탈오브젝트.portal01
    public int portal01Number = 10; //적기를 생성하는 오브젝트 갯수.

    public GameObject item01;  //파괴시 뱉어내는 아이템-파워업.
    public int item01Number = 10; //파괴시 뱉어내는 아이템 갯수.

    public GameObject item11;  //파괴시 뱉어내는 아이템-스킬업.
    public int item11Number = 10; //파괴시 뱉어내는 아이템 갯수.

    public GameObject item21;  //파괴시 뱉어내는 아이템-에너지제너레이터.
    public int item21Number = 10; //파괴시 뱉어내는 아이템 갯수.

    public GameObject item31;  //파괴시 뱉어내는 아이템-밤리로더.
    public int item31Number = 10; //파괴시 뱉어내는 아이템 갯수.

    public GameObject item41;  //파괴시 뱉어내는 아이템-마그넷코어.
    public int item41Number = 10; //파괴시 뱉어내는 아이템 갯수.

    public GameObject item51;  //파괴시 뱉어내는 아이템-슈퍼파워.
    public int item51Number = 10; //파괴시 뱉어내는 아이템 갯수.

    public GameObject item61;  //파괴시 뱉어내는 아이템-슈퍼팬텀.
    public int item61Number = 10; //파괴시 뱉어내는 아이템 갯수.

    public GameObject item71;  //파괴시 뱉어내는 아이템-슈퍼팬텀.
    public int item71Number = 10; //파괴시 뱉어내는 아이템 갯수.

    public GameObject coin01;  //파괴시 뱉어내는 아이템-동 동전.
    public int coin01Number = 30; //파괴시 뱉어내는 아이템 갯수.

    public GameObject coin02;  //파괴시 뱉어내는 아이템-은 동전.
    public int coin02Number = 30; //파괴시 뱉어내는 아이템 갯수.

    public GameObject coin03;  //파괴시 뱉어내는 아이템-금 동전.
    public int coin03Number = 30; //파괴시 뱉어내는 아이템 갯수.

    public GameObject friendJail01;
    public int friendJail01Number = 30;

    public int ufoDartNumber = 30; //포탈에서 생성되는 ufoDart 갯수.
    public int ufoDustNumber = 30; //포탈에서 생성되는 ufoDust 갯수.
    public int ufoShieldNumber = 7; //포탈에서 생성되는 ufoShield 갯수.
    public int ufoSpinballNumber = 30; //포탈에서 생성되는 ufoSpinball 갯수.
    public int gHoleNumber = 4; //포탈에서 생성되는 wingBox01 갯수.
    public int ufoSeedNumber = 7; //포탈에서 생성되는 wingBox01 갯수.



    public GameObject ufoDart01; //포탈에서 생성되는 ufoDart01.
    public GameObject ufoDart02; //포탈에서 생성되는 ufoDart02.
    public GameObject ufoDart03; //포탈에서 생성되는 ufoDart03.
    public GameObject ufoDart04; //포탈에서 생성되는 ufoDart04.
    public GameObject ufoDart05; //포탈에서 생성되는 ufoDart05.
    public GameObject ufoDart06; //포탈에서 생성되는 ufoDart06.
    public GameObject ufoDart07; //포탈에서 생성되는 ufoDart07.
    public GameObject ufoDust01; //포탈에서 생성되는 ufoDust01.
    public GameObject ufoDust02; //포탈에서 생성되는 ufoDust02.
    public GameObject ufoDust03; //포탈에서 생성되는 ufoDust03.
    public GameObject ufoDust04; //포탈에서 생성되는 ufoDust04.
    public GameObject ufoDust05; //포탈에서 생성되는 ufoDust05.
    public GameObject ufoDust06; //포탈에서 생성되는 ufoDust06.
    public GameObject ufoDust07; //포탈에서 생성되는 ufoDust07.
    //public GameObject ufoShield01; //포탈에서 생성되는 ufoShield01.
    //public GameObject ufoShield02; //포탈에서 생성되는 ufoShield02.
    //public GameObject ufoShield03; //포탈에서 생성되는 ufoShield03.
    //public GameObject ufoShield04; //포탈에서 생성되는 ufoShield04.
    //public GameObject ufoShield05; //포탈에서 생성되는 ufoShield05.
    //public GameObject ufoShield06; //포탈에서 생성되는 ufoShield06.
    //public GameObject ufoShield07; //포탈에서 생성되는 ufoShield07.
    public GameObject ufoSpinball01; //포탈에서 생성되는 ufoSpinball01.
    public GameObject ufoSpinball02; //포탈에서 생성되는 ufoSpinball02.
    public GameObject ufoSpinball03; //포탈에서 생성되는 ufoSpinball03.
    public GameObject ufoSpinball04; //포탈에서 생성되는 ufoSpinball04.
    public GameObject ufoSpinball05; //포탈에서 생성되는 ufoSpinball05.
    public GameObject ufoSpinball06; //포탈에서 생성되는 ufoSpinball06.
    public GameObject ufoSpinball07; //포탈에서 생성되는 ufoSpinball07.
    public GameObject gHole01; //포탈에서 생성되는 골든웜홀01.
    public GameObject ufoSeed01; //포탈에서 생성되는 ufoSeed01.
    public GameObject ufoSeed02; //포탈에서 생성되는 ufoSeed02.
    public GameObject ufoSeed03; //포탈에서 생성되는 ufoSeed03.
    public GameObject ufoSeed04; //포탈에서 생성되는 ufoSeed04.
    public GameObject ufoSeed05; //포탈에서 생성되는 ufoSeed05.
    public GameObject ufoSeed06; //포탈에서 생성되는 ufoSeed06.
    public GameObject ufoSeed07; //포탈에서 생성되는 ufoSeed07.

    //public GameObject ufoShieldDestroy01; //포탈에서 생성되는 ufoShieldDestroy01.
    //public GameObject ufoShieldDestroy02; //포탈에서 생성되는 ufoShieldDestroy02.
    //public GameObject ufoShieldDestroy03; //포탈에서 생성되는 ufoShieldDestroy03.
    //public GameObject ufoShieldDestroy04; //포탈에서 생성되는 ufoShieldDestroy04.
    //public GameObject ufoShieldDestroy05; //포탈에서 생성되는 ufoShieldDestroy05.
    //public GameObject ufoShieldDestroy06; //포탈에서 생성되는 ufoShieldDestroy06.
    //public GameObject ufoShieldDestroy07; //포탈에서 생성되는 ufoShieldDestroy07.

    public GameObject ufoSeedBullet;
    
    
    public GameObject explosion01; // 폭발 이펙트01.
    public int explosion01Number = 30; //폭발 이펙트01 갯수.

    public GameObject explosion02; // 폭발 이펙트02. 피탄이펙트.
    public int explosion02Number = 30; //폭발 이펙트02 갯수.

    public GameObject explosion03; // 폭발 이펙트03.
    public int explosion03Number = 30; //폭발 이펙트03 갯수.

    public GameObject explosion04; // 폭발 이펙트04.
    public int explosion04Number = 60; //폭발 이펙트03 갯수.

    public GameObject explosion05; // 폭발 이펙트05.

    public GameObject bomb01; // 폭탄01.
    public int bomb01Number = 3; //폭발 폭탄01 갯수.


    public AudioClip pcExplo; //아군 기체 파괴시 재생되는 사운드리소스(1회).
    //public AudioClip ufoAttacked; //개틀링 탄환이 적UFO(웜홀제외)에 적중시 재생될 사운드(1회).
    public AudioClip skillFull; //스킬게이지가 가득찼을 때 재생될 사운드(1회).
    public AudioClip skilShot; //스킬발사시 재생될 사운드(1회).
    public AudioClip ufoExplo; //ufo파괴시 재생될 사운드(1회).
    public AudioClip warmholeAppear; //웜홀 등장시 재생될 사운드(1회).
    //public AudioClip warmholeAttacked; //웜홀이 탄환에 적중시 재생될 사운드(1회)
    public AudioClip coinGet; //코인획득시 재생될 사운드(1회).
    public AudioClip itemGet; //아이템획득시 재생될 사운드(1회).
    public AudioClip bombHole; //블랙홀 폭탄 실행시. 재생될 사운드(1회).
    public AudioClip countSound; //폭격전에 나오는 카운트 사운드.
    //2013년8월30일추가 사운드//
    public AudioClip pcAcceleration;    // 웜홀체인지시 비행기 가속음.(적.완)
    public AudioClip pcChange;          //행거에서 비행기 선택 좌우버튼 눌렀을때 나오는 소리.
    public AudioClip bombShot;          //폭탄 사용음.(적.완)
    public AudioClip btnTouchPhysical;    //물리버튼.(인게임.완)
    public AudioClip btnTouchDigital;    //디지털버튼.(인게임.완)
    public AudioClip friendDrop;        //친구드랍될때.(적.완)
    public AudioClip ufoLargeExplo;     //Ufo 파괴음 큰소리.(적.완)
    public AudioClip popupClose;        //팝업창 닫을때.(인게임.완)
    public AudioClip popupDisplay;      //팝업창 열때.(인게임.완)
    //2013년9월05일추가 사운드//
    public AudioClip fokkerSkillShot;   //포커스킬샷.
    public AudioClip comancheSkilshot;  //코만치스킬샷.
    public AudioClip phantomSkillShot;  //팬텀 스킬샷.
    public AudioClip friendsAircraftAppear; //친구비행기 겟해서 나타났을때.
    public AudioClip friendsDrop;   //친구비행기 감옥 생성될때.
    public AudioClip friendHelp;    //친구비행기 감옥에서 구출했을때
    public AudioClip getEnergy; //스킬아이템 먹었을때.
    public AudioClip instantMissionCheck;   //인스턴스미션 달성시.
    public AudioClip levelPopupDisplay; //레벨업창 나타날때.
    public AudioClip plasmaWaveShot;    //플라즈마웨이브폭탄
    public AudioClip skinSelect;    //스킨셀렉트시 나오는 소리.
    public AudioClip socialReward;  //소셜리워드-차후 적용될예정.
    public AudioClip sortie;    //출격 사운드.
    public AudioClip wingboxAppear; //윙박스 나타났을때.
    public AudioClip wingboxItemDrop;   //윙박스에서 아이템 드랍할때.
    public AudioClip wingboxItemGet;    //윙박스에서 나온 아이템을 먹었을때.
    public AudioClip wormholeAppear;    //웜홀 나타났을때. 
    public AudioClip wormholeEvolution; //웜홀 진화할때.
    //2014년3월6일 추가 사운드//
    public AudioClip effectComancheMissileShot; //코만치 미사일 발사음.
    public AudioClip effectHitComancheMissile;  //코만치 미사일 격추음.
    public AudioClip effectPhantomMissileShot;  //팬텀 미사일 발사음.
    public AudioClip effectHitPhantomMissile;   //팬텀 미사일 격추음.


    int enemyCount;
    //int enemyNumber = 0;


    public string[] itemGetScript;  //아이템을 먹거나 했을때 화면 좌상단에 나오는 캐릭터 메세지.

    public AudioClip[] startCombat;
    public AudioClip[] airCraftExp;
    public AudioClip[] comFirst;
    public AudioClip[] comSecond;
    public AudioClip[] comThird;
    public AudioClip[] comFourth;
    public AudioClip[] comFifth;
    public AudioClip[] comSixth;
    public AudioClip[] readBomb;
    public AudioClip[] readySkill;
    public AudioClip[] fireBomb;
    public AudioClip[] fireSkill;
    public AudioClip[] ComMission;
    public AudioClip[] countDown5;
    public AudioClip[] countDown4;
    public AudioClip[] countDown3;
    public AudioClip[] countDown2;
    public AudioClip[] countDown1;
    public AudioClip[] countDownFire;
    public AudioClip countDown6Ai;

    public AudioClip laserBeam;

    public AudioClip warningVoice;

    [System.NonSerialized]
    public AudioClip[] characterSoundSet;

    public static string[][] characterSpeakScript = new string[5][];


    // 하위 변수가 운명의 카드를 연결해주는 오브젝트 변수이다.//
    public GameObject selDstnCardWin;
    bool isObjectPoolFnish = false;

    void Awake()
    {
        selDstnCardWin.SetActive(false);

        #region 캐릭터 대사 입력
        //윤세미.
        characterSpeakScript[1] = new string[]
        {
         /*00*/   "<Skill Regeneration!!_", //"<스킬회복!!_",
         /*01*/   "<Nuclear Bomb!!_", //"<핵폭탄!!_",
         /*02*/   "<Fuel!!_", //"<자석!!_",
         /*03*/   "<Super Power!!_", //"<슈퍼파워!!_",
         /*04*/   "<Nuclear's Ready!!_", //"<핵폭탄레디!!_",
         /*05*/   "<Power Up!!_", //"<파워업!!_",
         /*06*/   "<Skill's Ready!!_", //"<스킬레디!!_",
         /*07*/   "<Now, here we go!!_", //"<자, 이제 시작이에요!!_",
         /*08*/   "<Noooo! You have any idea\nhow much that chopper was?!!_", //"<으윽! 이게 얼마짜린데!!_",
         /*09*/   "<Yeah, we're finally\ngetting into the rhythm!!_", //"<슬슬 리듬을 타기 시작하는 군요!!_",
         /*10*/   "<Cool! Step up the tempo!!_", //"<좋았어! 템포를 더 올려요!!_",
         /*11*/   "<Hehe, superb!\nLets' go all the way!!_", //"<히힛! 멋진걸?\n이대로 가는거에요!!_",
         /*12*/   "<Whew- that was close!!_", //"<휴. 이번엔 위험했어요!!_",
         /*13*/   "<Focus, stay focused!!_", //"<긴장하자 긴장!!_",
         /*14*/   "<Time to wipe them out!!_", //"<다, 쓸어버리자고요!!_",
         /*15*/   "<We're gonna burn\nyou to a crisp!!_", //"<홀랑 태워주마!!_",
         /*16*/   "<There you go! You're dead!!_", //"<빠샤! 다 죽었어!!_",
         /*17*/   "<5!!_", //"<폭격5초전!!_",
         /*18*/   "<4!!_", //"<폭격4초전!!_",
         /*19*/   "<3!!_", //"<폭격3초전!!_",
         /*20*/   "<2!!_", //"<폭격2초전!!_",
         /*21*/   "<1!!_", //"<폭격1초전!!_",
         /*22*/   "<Fire!!_", //"<폭격!!_",
         /*23*/   "<Heeee-Haaa!\nWe're such a great team!!!_", //"<꺄핫! 우리는 멋진 팀이야!!_"
        };

        //에이단.
        characterSpeakScript[2] = new string[]
        {
         /*00*/   "<Skill Regeneration!!_", //"<스킬회복!!_",
         /*01*/   "<Nuclear Bomb!!_", //"<핵폭탄!!_",
         /*02*/   "<Fuel!!_", //"<자석!!_",
         /*03*/   "<Super Power!!_", //"<슈퍼파워!!_",
         /*04*/   "<Nuclear's Ready!!_", //"<핵폭탄레디!!_",
         /*05*/   "<Power Up!!_", //"<파워업!!_",
         /*06*/   "<Skill's Ready!!_", //"<스킬레디!!_",
         /*07*/   "<The aircraft's\nin superb condition!!_", //"<기체 상태는 최상이야!!_",
         /*08*/   "<You've completely\ndemolished it!!_", //"<아예 다 부숴놨군!!_",
         /*09*/   "<Fly easy!!_", //"<살살 몰아!!_",
         /*10*/   "<Nicely done!!_", //"<자네 실력 좋은걸!!_",
         /*11*/   "<Ho! Let's keep it\nthat way!!_", //"<허허 이대로만 하세나!!_",
         /*12*/   "<Now, stay sharp!!_", //"<이제부터 긴장하게나!!_",
         /*13*/   "<You are the best!!_", //"<자네는 최고야!!_",
         /*14*/   "<Let's go all the way!!_", //"<자, 갈때까지 가자고!!_",
         /*15*/   "<Nuclear, fire!!!_", //"<핵폭탄 발사!!_",
         /*16*/   "<WooooooooHaaaaaaa!!!_", //"<하~아~!!_",
         /*17*/   "<5!!_", //"<폭격5초전!!_",
         /*18*/   "<4!!_", //"<폭격4초전!!_",
         /*19*/   "<3!!_", //"<폭격3초전!!_",
         /*20*/   "<2!!_", //"<폭격2초전!!_",
         /*21*/   "<1!!_", //"<폭격1초전!!_",
         /*22*/   "<Fire!!_", //"<폭격!!_",
         /*23*/   "<You did a good job!!_", //"<고생했네!!_"
        };

        //댄 모렌.
        characterSpeakScript[3] = new string[]
        {
         /*00*/   "<Skill Regeneration!!_", //"<스킬회복!!_",
         /*01*/   "<Nuclear Bomb!!_", //"<핵폭탄!!_",
         /*02*/   "<Fuel!!_", //"<자석!!_",
         /*03*/   "<Super Power!!_", //"<슈퍼파워!!_",
         /*04*/   "<Nuclear's Ready!!_", //"<핵폭탄레디!!_",
         /*05*/   "<Power Up!!_", //"<파워업!!_",
         /*06*/   "<Skill's Ready!!_", //"<스킬레디!!_",
         /*07*/   "<Entering the battlefield!!_", //"<전투지역으로 진입한다!!_",
         /*08*/   "<Request for rescue to HQ!!_", //"<기지에 구조 요청한다!!_",
         /*09*/   "<Here we go!!_", //"<이제 시작이야!!_",
         /*10*/   "<Hmm, not bad!!!_", //"<이거 쓸만 한 걸!!_",
         /*11*/   "<Alright, stay alert!\nWe break all the way through!!_", //"<좋아 긴장풀지 말고\n이대로 가는 거야!!_",
         /*12*/   "<Not as good as I used to be,\nbut well done!!_", //"<내 한창때 보단\n못 하지만 제법인데!!_",
         /*13*/   "<You're better than expected!!_", //"<너! 제법이잖아!!_",
         /*14*/   "<Yes, let's keep going!!_", //"<자, 끝까지 가보자고!!_",
         /*15*/   "<I'll give you hell!!_", //"<뜨거운 맛을 보여주지!!_",
         /*16*/   "<Lock and load!!_", //"<화끈하게 가자!!_",
         /*17*/   "<5!!_", //"<폭격5초전!!_",
         /*18*/   "<4!!_", //"<폭격4초전!!_",
         /*19*/   "<3!!_", //"<폭격3초전!!_",
         /*20*/   "<2!!_", //"<폭격2초전!!_",
         /*21*/   "<1!!_", //"<폭격1초전!!_",
         /*22*/   "<Fire!!_", //"<폭격!!_",
         /*23*/   "<Good job!!_", //"<잘하는데!!_"
        };

        //레이첼.
        characterSpeakScript[4] = new string[]
        {
         /*00*/   "<Skill Regeneration!!_", //"<스킬회복!!_",
         /*01*/   "<Nuclear Bomb!!_", //"<핵폭탄!!_",
         /*02*/   "<Fuel!!_", //"<자석!!_",
         /*03*/   "<Super Power!!_", //"<슈퍼파워!!_",
         /*04*/   "<Nuclear's Ready!!_", //"<핵폭탄레디!!_",
         /*05*/   "<Power Up!!_", //"<파워업!!_",
         /*06*/   "<Skill's Ready!!_", //"<스킬레디!!_",
         /*07*/   "<Relax!!_", //"<긴장 풀어요!!_",
         /*08*/   "<Hewww, sorry for the aircraft,\nbut lucky to escape!!_", //"<휴, 기체가 아쉽지만\n탈출해서 다행이에요!!_",
         /*09*/   "<Nicely cleared!!_", //"<굿 클리어!!_",
         /*10*/   "<Moving to the next battlefield!!_", //"<다음 전투지역으로 이동합니다!!_",
         /*11*/   "<The hostile forces are building up!!_", //"<적들의 공세가 거세지고 있어요!!_",
         /*12*/   "<Let's keep it this way!!_", //"<이대로만 가세요!!_",
         /*13*/   "<The best flight ever!!_", //"<최고의 비행이예요!!_",
         /*14*/   "<Let's wipe them out!!_", //"<싹 쓸어버리자구요!!_",
         /*15*/   "<Cle~ar~!!_", //"<클리어~!!_",
         /*16*/   "<Go Go Go!!_", //"<고! 고! 고!!_",
         /*17*/   "<5!!_", //"<폭격5초전!!_",
         /*18*/   "<4!!_", //"<폭격4초전!!_",
         /*19*/   "<3!!_", //"<폭격3초전!!_",
         /*20*/   "<2!!_", //"<폭격2초전!!_",
         /*21*/   "<1!!_", //"<폭격1초전!!_",
         /*22*/   "<Fire!!_", //"<폭격!!_",
         /*23*/   "<You did a great job!!_", //"<정말 잘했어요!!_"
        };

        #endregion

        //캐릭터에 따라 달라지는 대사를 입력하여 준다.
        int activeOper = ValueDeliverScript.activeOper;

        itemGetScript = characterSpeakScript[activeOper];

        if (ValueDeliverScript.isTutComplete == 0)
        {
            itemGetScript = characterSpeakScript[4];
        }


        GameObject go = Instantiate(PC[ValueDeliverScript.flightNumber]) as GameObject;

        if (ValueDeliverScript.flightNumber == 0)
        {
            int flight000Skin = ValueDeliverScript.flight000Skin;
            go.transform.FindChild("BodyBase").renderer.material.mainTexture = flight001Skin[flight000Skin];
        }
        else if (ValueDeliverScript.flightNumber == 1)
        {
            int flight001Skin = ValueDeliverScript.flight001Skin;
            go.transform.FindChild("BodyBase").renderer.material.mainTexture = flight002Skin[flight001Skin];
        }
        else if (ValueDeliverScript.flightNumber == 2)
        {
            int flight002Skin = ValueDeliverScript.flight002Skin;
            go.transform.FindChild("BodyBase").renderer.material.mainTexture = flight003Skin[flight002Skin];
        }

        go.transform.parent = this.transform.FindChild("PC");
        go.tag = "Player";
        go.name = "Flight";

        Debug.Log("activeOper :::: " + activeOper);

        characterSoundSet = new AudioClip[]  
        {
            /* 00 */startCombat[activeOper-1],    //전투시작.
            /* 01 */airCraftExp[activeOper-1],    //기체파괴.
            /* 02 */comFirst[activeOper-1],       //1단게완료.
            /* 03 */comSecond[activeOper-1],      //2단게완료.
            /* 04 */comThird[activeOper-1],       //3단게완료.
            /* 05 */comFourth[activeOper-1],      //4단게완료.
            /* 06 */comFifth[activeOper-1],       //5단게완료.
            /* 07 */comSixth[activeOper-1],       //6단게완료.
            /* 08 */readBomb[activeOper-1],       //핵폭탄사용가능.
            /* 09 */readySkill[activeOper-1],     //스킬사용가능.
            /* 10 */fireBomb[activeOper-1],       //핵폭탄발사.
            /* 11 */fireSkill[activeOper-1],      //스킬발사.
            /* 12 */ComMission[activeOper-1],     //인스턴트 미션 완료.
            /* 13 */countDown5[activeOper-1],     //폭격 5초전.
            /* 14 */countDown4[activeOper-1],     //폭격 4초전.
            /* 15 */countDown3[activeOper-1],     //폭격 3초전.
            /* 16 */countDown2[activeOper-1],     //폭격 2초전.
            /* 17 */countDown1[activeOper-1],     //폭격 1초전.
            /* 18 */countDownFire[activeOper-1]   //폭격!!!!!!.
        };

        if (ValueDeliverScript.isTutComplete == 0)
        {
            characterSoundSet = new AudioClip[]  
            {
                /* 00 */startCombat[3],    //전투시작.
                /* 01 */airCraftExp[3],    //기체파괴.
                /* 02 */comFirst[3],       //1단게완료.
                /* 03 */comSecond[3],      //3단게완료.
                /* 04 */comThird[3],       //3단게완료.
                /* 05 */comFourth[3],      //4단게완료.
                /* 06 */comFifth[3],       //5단게완료.
                /* 07 */comSixth[3],       //6단게완료.
                /* 08 */readBomb[3],       //핵폭탄사용가능.
                /* 09 */readySkill[3],     //스킬사용가능.
                /* 10 */fireBomb[3],       //핵폭탄발사.
                /* 11 */fireSkill[3],      //스킬발사.
                /* 12 */ComMission[3],     //인스턴트 미션 완료.
                /* 13 */countDown5[3],     //폭격 5초전.
                /* 14 */countDown4[3],     //폭격 4초전.
                /* 15 */countDown3[3],     //폭격 3초전.
                /* 16 */countDown2[3],     //폭격 2초전.
                /* 17 */countDown1[3],     //폭격 1초전.
                /* 18 */countDownFire[3]   //폭격!!!!!!.
            };
        }
    } //Awake 끝!


    void Start()
    {
        StartCoroutine(MakeBullet());   //총알 순차적 생성.

        if (ValueDeliverScript.isTutComplete != 2)
            GameObject.Find("TutManager").GetComponent<TutManagerScript>().ActivateInGame();

        ////스페셜 출격 테스트 임시 변수 변경//
        //ValueDeliverScript.isSelectSpecial = true;
        ////스페셜 출격 테스트 임시 변수 변경//

        if (ValueDeliverScript.isSelectSpecial)
        {
            selDstnCardWin.SetActive(true);
        }
    }

    IEnumerator InstantiatePool(GameObject obj, int objNum, string objName, string parentTF)
    {
        float spendTime = 0;
        float intervalTime = 0;
        float t1 = Time.time;
        float t2;
        for (int i = 0; i < objNum; i++)
        {
            GameObject go = Instantiate(obj) as GameObject;
            go.transform.parent = transform.FindChild(parentTF);
            go.name = objName + i;
            go.SetActive(false);

            t2 = Time.time;
            intervalTime += t2 - t1;
            spendTime += intervalTime;
            if (spendTime > 0.015f)
            {
                yield return null;
                spendTime = 0;
            }

            t1 = Time.time;
        }
    }

    IEnumerator MakeBullet()
    {
        yield return StartCoroutine(InstantiatePool(portal01, portal01Number, "portal01TF", "Portal01"));

        int fNum = ValueDeliverScript.flightNumber;
        int bTemp = ValueDeliverScript.bulletLevel;
        string bNumTF = "bullet" + fNum.ToString("00") + "_" + bTemp.ToString("000") + "TF";
        string bNum = "Bullet" + fNum.ToString("00") + "_" + bTemp.ToString("000");

        Debug.Log("bNumTF ::: " + bNumTF);
        Debug.Log("bNum ::: " + bNum);

        yield return StartCoroutine(InstantiatePool(bullet[fNum].bullet[bTemp - 1], makeBulletNumber, bNumTF, bNum)); //최초엔 비행기랑 짝이 맞는 총알만 생성

        for (int fN = 0; fN < 3; fN++)
        {
            for (int bN = 1; bN <= 15; bN++)
            {
                bNumTF = "bullet" + fN.ToString("00") + "_" + bN.ToString("000") + "TF";
                bNum = "Bullet" + fN.ToString("00") + "_" + bN.ToString("000");

                if (fNum == fN && bTemp == bN) continue;
                StartCoroutine(InstantiatePool(bullet[fN].bullet[bN - 1], makeBulletNumber, bNumTF, bNum));
                yield return null;
            }
        }
        StartCoroutine(MakeMisslie());  //총알 미사일 순차적 생성.
    }


    IEnumerator MakeMisslie()
    {
        yield return null;
        //총알미사일.
        yield return StartCoroutine(InstantiatePool(missileComancheTf01, missileComancheTfNumber, "missileComanche01TF", "MissileComancheTf01"));
        yield return StartCoroutine(InstantiatePool(missileComancheTf02, missileComancheTfNumber, "missileComanche02TF", "MissileComancheTf02"));
        yield return StartCoroutine(InstantiatePool(missileComancheTf03, missileComancheTfNumber, "missileComanche03TF", "MissileComancheTf03"));
        yield return StartCoroutine(InstantiatePool(missileComancheTf04, missileComancheTfNumber, "missileComanche04TF", "MissileComancheTf04"));
        yield return StartCoroutine(InstantiatePool(missileComancheTf05, missileComancheTfNumber, "missileComanche05TF", "MissileComancheTf05"));
        yield return StartCoroutine(InstantiatePool(missileComancheTf06, missileComancheTfNumber, "missileComanche06TF", "MissileComancheTf06"));

        yield return StartCoroutine(InstantiatePool(missilePantomTf01, missilePantomTfNumber, "missilePantom01TF", "MissilePantomTf01"));
        yield return StartCoroutine(InstantiatePool(missilePantomTf02, missilePantomTfNumber, "missilePantom02TF", "MissilePantomTf02"));

        yield return StartCoroutine(MakeEtc());  //아이템 이펙트 등 순차적 생성.
    }

    IEnumerator MakeEtc()
    {
        //핵폭탄.
        yield return StartCoroutine(InstantiatePool(bomb01, bomb01Number, "bomb01TF", "Bomb01"));
        //스킬샷.
        yield return StartCoroutine(InstantiatePool(skillBullet01, skillBullet01Number, "skillBullet01TF", "SkillBullet01"));
        yield return StartCoroutine(InstantiatePool(skillBullet02, skillBullet02Number, "skillBullet02TF", "SkillBullet02"));
        yield return StartCoroutine(InstantiatePool(skillBullet03, skillBullet03Number, "skillBullet03TF", "SkillBullet03"));
        yield return StartCoroutine(InstantiatePool(skillBullet04, skillBullet04Number, "skillBullet04TF", "SkillBullet04"));

        yield return StartCoroutine(InstantiatePool(explosion01, explosion01Number, "explo01TF", "Explo01"));
        yield return StartCoroutine(InstantiatePool(explosion02, explosion02Number, "explo02TF", "Explo02"));
        yield return StartCoroutine(InstantiatePool(explosion03, explosion03Number, "explo03TF", "Explo03"));
        yield return StartCoroutine(InstantiatePool(explosion04, explosion04Number, "explo04TF", "Explo04"));
        yield return StartCoroutine(InstantiatePool(explosion05, explosion04Number, "explo05TF", "Explo05"));

        //아이템01-파워업.
        yield return StartCoroutine(InstantiatePool(item01, item01Number, "item01TF", "Item01"));
        //아이템11-스킬업.
        yield return StartCoroutine(InstantiatePool(item11, item11Number, "item11TF", "Item11"));
        //아이템11-스킬업.
        yield return StartCoroutine(InstantiatePool(item21, item21Number, "item21TF", "Item21"));
        //아이템11-스킬업.
        yield return StartCoroutine(InstantiatePool(item31, item31Number, "item31TF", "Item31"));
        //아이템41-마그넷.
        yield return StartCoroutine(InstantiatePool(item41, item41Number, "item41TF", "Item41"));
        //아이템11-스킬업.
        yield return StartCoroutine(InstantiatePool(item51, item51Number, "item51TF", "Item51"));

        //아이템11-연료 노멀.
        yield return StartCoroutine(InstantiatePool(item61, item61Number, "item61TF", "Item61"));

        //아이템11-연료 맥스.
        yield return StartCoroutine(InstantiatePool(item71, item61Number, "item71TF", "Item71"));
        yield return null;

        //동전.
        yield return StartCoroutine(InstantiatePool(coin01, coin01Number, "coin01TF", "Coin01"));
        yield return StartCoroutine(InstantiatePool(coin02, coin02Number, "coin02TF", "Coin02"));
        yield return StartCoroutine(InstantiatePool(coin03, coin03Number, "coin03TF", "Coin03"));


        //친구감옥.
        yield return StartCoroutine(InstantiatePool(friendJail01, friendJail01Number, "friendJail01TF", "FriendJail01"));
        //Debug.Log("MakeEtc End!!!");

        StartCoroutine(MakeUFO());  //UFO 순차적 생성.
    }

    IEnumerator MakeUFO()
    {
        //Debug.Log("MakeUFO Start!!!");
        yield return StartCoroutine(InstantiatePool(ufoDart01, ufoDartNumber, "ufoDart01TF", "UfoDart01"));
        yield return StartCoroutine(InstantiatePool(ufoDust01, ufoDustNumber, "ufoDust01TF", "UfoDust01"));
        yield return StartCoroutine(InstantiatePool(ufoSpinball01, ufoSpinballNumber, "ufoSpinball01TF", "UfoSpinball01"));
        yield return StartCoroutine(InstantiatePool(gHole01, gHoleNumber, "GoldenWormhole01TF", "GoldenWormhole01"));
        yield return StartCoroutine(InstantiatePool(ufoSeed01, ufoSeedNumber, "ufoSeed01TF", "UfoSeed01"));

        yield return StartCoroutine(InstantiatePool(ufoDart02, ufoDartNumber, "ufoDart02TF", "UfoDart02"));
        yield return StartCoroutine(InstantiatePool(ufoDust02, ufoDustNumber, "ufoDust02TF", "UfoDust02"));
        yield return StartCoroutine(InstantiatePool(ufoSpinball02, ufoSpinballNumber, "ufoSpinball02TF", "UfoSpinball02"));
        yield return StartCoroutine(InstantiatePool(ufoSeed02, ufoSeedNumber, "ufoSeed02TF", "UfoSeed02"));

        yield return StartCoroutine(InstantiatePool(ufoDart03, ufoDartNumber, "ufoDart03TF", "UfoDart03"));
        yield return StartCoroutine(InstantiatePool(ufoDust03, ufoDustNumber, "ufoDust03TF", "UfoDust03"));
        yield return StartCoroutine(InstantiatePool(ufoSpinball03, ufoSpinballNumber, "ufoSpinball03TF", "UfoSpinball03"));
        yield return StartCoroutine(InstantiatePool(ufoSeed03, ufoSeedNumber, "ufoSeed03TF", "UfoSeed03"));

        yield return StartCoroutine(InstantiatePool(ufoDart04, ufoDartNumber, "ufoDart04TF", "UfoDart04"));
        yield return StartCoroutine(InstantiatePool(ufoDust04, ufoDustNumber, "ufoDust04TF", "UfoDust04"));
        yield return StartCoroutine(InstantiatePool(ufoSpinball04, ufoSpinballNumber, "ufoSpinball04TF", "UfoSpinball04"));
        yield return StartCoroutine(InstantiatePool(ufoSeed04, ufoSeedNumber, "ufoSeed04TF", "UfoSeed04"));

        yield return StartCoroutine(InstantiatePool(ufoDart05, ufoDartNumber, "ufoDart05TF", "UfoDart05"));
        yield return StartCoroutine(InstantiatePool(ufoDust05, ufoDustNumber, "ufoDust05TF", "UfoDust05"));
        yield return StartCoroutine(InstantiatePool(ufoSpinball05, ufoSpinballNumber, "ufoSpinball05TF", "UfoSpinball05"));
        yield return StartCoroutine(InstantiatePool(ufoSeed05, ufoSeedNumber, "ufoSeed05TF", "UfoSeed05"));

        yield return StartCoroutine(InstantiatePool(ufoDart06, ufoDartNumber, "ufoDart06TF", "UfoDart06"));
        yield return StartCoroutine(InstantiatePool(ufoDust06, ufoDustNumber, "ufoDust06TF", "UfoDust06"));
        yield return StartCoroutine(InstantiatePool(ufoSpinball06, ufoSpinballNumber, "ufoSpinball06TF", "UfoSpinball06"));
        yield return StartCoroutine(InstantiatePool(ufoSeed06, ufoSeedNumber, "ufoSeed06TF", "UfoSeed06"));

        yield return StartCoroutine(InstantiatePool(ufoDart07, ufoDartNumber, "ufoDart07TF", "UfoDart07"));
        yield return StartCoroutine(InstantiatePool(ufoDust07, ufoDustNumber, "ufoDust07TF", "UfoDust07"));
        yield return StartCoroutine(InstantiatePool(ufoSpinball07, ufoSpinballNumber, "ufoSpinball07TF", "UfoSpinball07"));
        yield return StartCoroutine(InstantiatePool(ufoSeed07, ufoSeedNumber, "ufoSeed07TF", "UfoSeed07"));
        yield return StartCoroutine(InstantiatePool(ufoSeedBullet, 100, "ufoSeedBullet01TF", "UfoSeedBullet01"));
        //Debug.Log("MakeUFO End!!!");

        //여기까지 모든 오브젝트들을 씬에 올리고 게임을 실행할 수 있게 준비를 한다//
        //여기서 튜토리얼이 완료 된 상태이고 게스트 플레이가 아닌지 확인한 후//
        //튜토 완료 상태이면 아래 내용을 실행하고 아니면 tut 스타트가 실행될때가지 아무것도 하지 않는다//
        if (ValueDeliverScript.isTutComplete == 2)
        {
            isObjectPoolFnish = true;
            if (ValueDeliverScript.isSelectSpecial == false)
            {
                //스페셜 출격 상태도 아닌 일반 상태일때 실제 인게임이 시작된다.
                //여기서 포털 생성 스크립트를 실행한다.//
                //포털 생성 스크립트가 실행되면 처음에 하는 일은 카운트 다운이며
                //스페셜 출격 상태로 씬을 만들지 아니면 일반 출격 상태로 씬을 만들지 결정을 한다//
                StartCoroutine(RealStart());
            }
        }
    }

    //스페셜 출격시 운명의 카드 선택후 이 메소드를 호출한다//
    public IEnumerator RealStart()
    {
        while (true)
        {
            if (isObjectPoolFnish == true)
            {
                GetComponent<PortalControlScript>().SetStart();

                StartCoroutine(GetComponent<BulletControlScript>().BulletShot());
                StartCoroutine(GetComponent<BulletControlScript>().BulletMissileShot());
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }

    //이 튜트 스타트는 모든 튜토리얼 안내 내용이 끝난다음에 호출이 된다//
    public void TutStart()
    {
        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterSpeak(0);    //인게임 실행시 캐릭터가 시작을 알림.
        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterMessageShow(7);

        GetComponent<PortalControlScript>().SetStart();

        StartCoroutine(GetComponent<BulletControlScript>().BulletShot());
        StartCoroutine(GetComponent<BulletControlScript>().BulletMissileShot());
    }
}