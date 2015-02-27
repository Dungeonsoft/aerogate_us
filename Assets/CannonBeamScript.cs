using UnityEngine;

public class CannonBeamScript : MonoBehaviour
{
    private GameObject fuelSlider;
    private GameObject flight;
    private SoundUiControlScript soundUiControlScript;
    private ActivateScript activate;

    public int[] crashDamage;

    //폭파 가능한 오브젝트인지 결정해주는 불린변수// 
    //현재는 모두 폭파가 가능해서 다 켜놓고 있음//
    //레이저는 이와 관련이 없어서 끔//
    public bool isExplo = false;    


    bool isBalckHallActive = false;

    //레이져 빔을 진동하게 해서 오브젝트 콜리젼이 제대로 작동하게 하려고 만든 불린변수//
    //일반 데브리쪽 오브젝트에는 필요가 없음//
    public bool isVib = false;
    public float vivVal = 0.1f;

    float vivValP;
    float vivValM;

    private void Start()
    {
        vivValP = vivVal; vivValM = vivVal * -1f;
        fuelSlider = GameObject.Find("FuelSlider");
        flight = GameObject.Find("PC/Flight");
        soundUiControlScript = GameObject.Find("GameManager").GetComponent<SoundUiControlScript>();
        activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();
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

        if (isVib == true)
        {
            transform.localPosition = new Vector3(Random.Range(vivValM, vivValP), 0, 0);
        }

    }
     
    private void OnTriggerStay(Collider col)
    {
        switch (col.tag)
        {
            //case "":
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
                        fuelSlider.GetComponent<FuelSliderScript>().GageReduceVoid(crashDamage[ValueDeliverScript.portalUpLevel] * Time.deltaTime, true);
                        soundUiControlScript.PcExplo();									//폭발사운드. 적용.
                    }
                }
                break;
        }

        if (isExplo == true)
        {
            switch (col.tag)
            {
                case "Bullet":
                case "Missile":
                    GetComponent<AttackWhilteScript>().AttackWhilte();
                    col.gameObject.SetActive(false);
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
    }

    private void ExploEnd()
    {
        if (transform.name == "EnemyLaserBeam")
            activate.ExploActivation(transform.root.FindChild("LaserCannonRot/LaserCannon01").position, 01, gameObject.name); //피탄 이펙트 켜짐.
        else
            activate.ExploActivation(transform.position, 01, gameObject.name); //피탄 이펙트 켜짐.

        soundUiControlScript.UfoExplo(); //폭파음재생.

        isBalckHallActive = false;

        if (transform.name == "EnemyLaserBeam")
            transform.root.gameObject.SetActive(false);
        else
            gameObject.SetActive(false);
    }
}