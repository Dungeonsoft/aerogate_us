using UnityEngine;

public class CannonBeamScript : MonoBehaviour
{
    private GameObject fuelSlider;
    private GameObject flight;
    private SoundUiControlScript soundUiControlScript;
    private ActivateScript activate;

    public int[] crashDamage;

    public bool isExplo = false;

    private void Start()
    {
        fuelSlider = GameObject.Find("FuelSlider");
        flight = GameObject.Find("PC/Flight");
        soundUiControlScript = GameObject.Find("GameManager").GetComponent<SoundUiControlScript>();
        activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();
    }


    //private void OnTriggerEnter(Collider col)
     
    private void OnTriggerStay(Collider col)
    {
        switch (col.tag)
        {
            case "":
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
                    col.gameObject.SetActive(false);
                    break;

                case "SuperPower":
                case "Bomb01":
                case "Bomb":
                case "Bomb03":
                    ExploEnd();
                    break;
            }
        }
    }

    private void ExploEnd()
    {
        activate.ExploActivation(transform.position, 01, gameObject.name); //피탄 이펙트 켜짐.

        soundUiControlScript.UfoExplo(); //폭파음재생.
        gameObject.SetActive(false);
    }
}