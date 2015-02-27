using UnityEngine;
using System.Collections;

public class CannonController : DebrisAct
{

    public GameObject laser;
    public GameObject laserCannon01;
    public GameObject LaserCannonRot;
    public GameObject warningPanel;
    public GameObject spark;
    public GameObject bLight;
    public GameObject laserBeam;

    public float timer = 1f;
    public float[] timer2;

    int isWarning = 0;
    float fPositionX = 0;
    float cPositionX = 0;
    float changePositionX = 0;
    float changeVal = 0;
    float interval = 0;
    float elapsedTime = 0;
    float lerpVal = 0;
    float spendTime = 0f;
    bool isTargetting = false;
    bool isShotLaser = false;
    bool isShotLaser2 = false;
    bool isLerpOne = false;
    bool isSpendTime = false;
    bool isStartedTargetting = false;
    bool isCannonBump = false;
    bool isEndTime1 = false;
    GameObject flight;
    Vector3 cPositionV;
    Vector3 zeroPosition;

    SoundUiControlScript soundUiControlScript;
    ActivateScript activate;

    public float[] followTime;
    public float[] focusTime;
    public float[] actTime;

    GameObject gameManager;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager");


        zeroPosition = new Vector3(0, 0, 80);
        transform.position = zeroPosition + new Vector3(0, 0, 80);
        Debug.Log("캐논 컨트롤러 시작 어웨이크 ::: " + transform.position.z);
        laserCannon01 = transform.FindChild("LaserCannonRot/LaserCannon01").gameObject;
        LaserCannonRot = transform.FindChild("LaserCannonRot").gameObject;
        spark.particleSystem.Stop();
        bLight.particleSystem.Stop();
    }

    void Start()
    {
        flight = GameObject.Find("PC/Flight");
        Debug.Log("캐논 컨트롤러 시작 스타트 ::: " + transform.position.z);

        soundUiControlScript = GameObject.Find("GameManager").GetComponent<SoundUiControlScript>();
        activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();

        gameObject.SetActive(false);
    }

    public override void Activate()
    {
        isWarning = 0;
        fPositionX = 0;
        cPositionX = 0;
        changePositionX = 0;
        changeVal = 0;
        interval = 0;
        elapsedTime = 0;
        lerpVal = 0;
        spendTime = 0f;
        isTargetting = false;
        isShotLaser = false;
        isShotLaser2 = false;
        isLerpOne = false;
        isSpendTime = false;
        isStartedTargetting = false;
        isCannonBump = false;
        isEndTime1 = false;
        laserBeam.transform.localScale = new Vector3(0, 0, 0);

        //여기에서 바로 스파크를 꺼놔야 됨//
        spark.SetActive(false);
        bLight.SetActive(false);
        //여기에서 바로 스파크를 꺼놔야 됨//

        Debug.Log("진짜 액티베이트 캐논");
        Debug.Log("Flight Name ::: " + flight.name);
        transform.position = new Vector3(flight.transform.position.x, 0, 80);
        //transform.position = new Vector3(0,0,0);

        if (flight.activeSelf == false) return;

        spendTime = 0f;

        isWarning = 1;
        //StartCoroutine(CoroutineArray());

        //혹시라도 광선 오브젝트가 꺼져있으면 켜주는 코드//
        transform.FindChild("EnemyLaser/EnemyLaserBeam").gameObject.SetActive(true);
    }

    float time00;
    float time01;
    float time02;
    float time03;
    float time04;

    void Update()
    {
        //액티베이트후 처음 나오는 워닝 메세지를 보여주기 위한 if 구문//
        if (isWarning == 1)
        {
            time00 = 0.5f;
            time01 = time00 + 0.5f;
            time02 = time01 + followTime[ValueDeliverScript.portalUpLevel];
            time03 = time02 + focusTime[ValueDeliverScript.portalUpLevel];
            time04 = time03 + actTime[ValueDeliverScript.portalUpLevel];

            gameManager.GetComponent<SoundUiControlScript>().EffectWarningVoice();
            warningPanel.animation.Play("WarningAnim01");

            isWarning++;//isWarning의 값을 1을 더 올려줘서 더이상 이 if 구문이 실행되지 않게 막아준다//
        }

        if (isWarning > 1)
        {
            //워닝이 시작되면 시간흐름을 기록한다//
            spendTime += Time.deltaTime;

            if (isStartedTargetting == false && spendTime >= time00 && spendTime < time01)  //0.5f는 최초 대기시간//이 시간동안 워닝 글씨가 나왔다가 사라진다//
            {

                //1초가 지나고 난후 레이져 캐논이 움직이는 애니를 시작한다.(레이져 캐논 등장)//
                transform.position = new Vector3(flight.transform.position.x, 0, 45);

                laserCannon01.animation.Play("LaserCannonAnim01");  //화면 바깥에서 레이져캐논이 튀어나오는 애니메이션//
                LaserCannonRot.animation.Play("LaserCannonRotAnim01");//레이져캐논 빙글빙글 돔//
                //코어부분이 회전하는 애니// 포털 레벨별로 애니값이 다르니 애니키가 아닌 코드로 다시 만들어야 됨//
                //laserCannon01.transform.FindChild("LaserCannon/Core").animation.Play("LaserCannonCoreAnim01");
                isStartedTargetting = true;
            }

            else if (spendTime >= time01 && spendTime < time02) //최초 대기시간과 레이져캐논이 화면에 나타날때까지 시간 1.5f 절대 변하지 않음//
            {
                //레이져캐논이 시작된지 3초가 넘으면 아래 if 구문을 실행//
                if (isTargetting == false)
                {
                    cPositionV = transform.position;
                    isTargetting = true;
                    isLerpOne = false;
                }

                //실제 타게팅을 시작되었으니 잠시동안 캐논의 x축이 비행기의 x축을 따라 다닌다// 약 2초간 따라다닌다//
                fPositionX = flight.transform.position.x;
                cPositionX = transform.position.x;
                lerpVal = Time.deltaTime * 5;
                changePositionX = Mathf.Lerp(cPositionX, fPositionX, lerpVal);
                transform.position = new Vector3(changePositionX, cPositionV.y, cPositionV.z);
                changeVal += Time.deltaTime;
            }

            else if (isShotLaser == false && spendTime >= time02 && spendTime < time03)   //따라다님이 끝나는 시간 이제 에너지모음//
            {
                //약4초가 넘으면 더이상 캐논이 비행기를 따라다니지 않게 막는다.//지금부터는 레이져 발사에 관련된 부분이 작동한다.//
                isShotLaser = true;
                spark.SetActive(true);
                bLight.SetActive(true);
                spark.particleSystem.Play();
                bLight.particleSystem.Play();
            }

            else if (spendTime >= time03 && spendTime < time04)
            {
                if (isShotLaser2 == false)
                {
                    isShotLaser2 = true;
                    laserBeam.animation.Play("LaserCannonBeamAnim01");  //레이져 최초 발사//
                }
                else if (spendTime >= time03 + 0.2f)
                {
                    if (isCannonBump == false)
                    {
                        isCannonBump = true;
                        laserCannon01.animation.Play("LaserCannonAnim03");  //레이져 발사로 인한 캐논포 강한 흔들림//
                    }
                }
            }

            //캐논으로 인한 파괴가 끝난다//
            else if (isEndTime1 == false && spendTime >= time04)
            {
                //레이져 캐논 종료 애니메이션//
                isEndTime1 = true;
                spark.particleSystem.Stop();
                bLight.particleSystem.Stop();
                laserBeam.animation.Play("LaserCannonBeamAnim02");//레이져 발사 종료//
                laserCannon01.animation.Play("LaserCannonAnim02");//레이져 발사 종료로 인한 후퇴 동작//
            }
                
            //완전 종료// 캐논을 더이상 보이지 않게 한다//
            else if (spendTime >= time04 + 2f)
            {
                transform.position = zeroPosition + new Vector3(0, 0, 80);
                isTargetting = false;
                gameObject.SetActive(false);
            }
            //여기까지 모든 레이져 캐논 기믹이 끝난다.
        }
    }
}


