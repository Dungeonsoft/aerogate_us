using UnityEngine;
using System.Collections;

public class FuelSliderScript : MonoBehaviour
{
    UIFilledSprite FuelGageBar;
    UISprite FuelGageBase;
    UISlider fuelUiSlider;
    UILabel fuelGageCount;
    float fuelSize;
    float fuelGage;
    float fuelReduceInterval;
    float fuelSliderValue = 1;
    public float invincibleTime = 2f;
    bool isInvincible = false;

    public bool isFuel = false;

    public Color blueColor;
    public Color redColor;

    GameObject PC;


    //연료 추가 아이템을 먹었을때 처리하는 메서드//
    public void AddFuel(int addFuel)
    {

        ValueDeliverScript.fuelSize = fuelGage += addFuel; //숫자 부분을 증가 시킴.
        fuelSliderValue += fuelReduceInterval * addFuel;    //막대기 부분을 증가 시킴.

        if (ValueDeliverScript.fuelSize > ValueDeliverScript.fuelSizeOri)
        {
            ValueDeliverScript.fuelSize = fuelGage = ValueDeliverScript.fuelSizeOri;
            fuelSliderValue = 1;
        }
     
        if (ValueDeliverScript.fuelSize > ValueDeliverScript.fuelSizeOri) ValueDeliverScript.fuelSize = ValueDeliverScript.fuelSizeOri;
        if (fuelSliderValue > 1) fuelSliderValue = 1;
    }

    //연료를 가득 채워주는 아이템을 먹었을 경우 실행되는 메서드//
    public void FullFuel()
    {
        ValueDeliverScript.fuelSize = fuelGage = fuelSize;
        fuelSliderValue = 1;
    }
    //연료 추가 아이템을 먹었을때 처리하는 메서드//


    void Awake()
    {
        FuelGageBar = transform.FindChild("FuelGageBar").GetComponent<UIFilledSprite>();
        FuelGageBase = transform.FindChild("FuelGageBase").GetComponent<UISprite>();

        fuelUiSlider = GetComponent<UISlider>();
        fuelGageCount = transform.FindChild("FuelGageCount").GetComponent<UILabel>();


        PC = GameObject.Find("PC");
    }

    public void FuelGageSettingVoid()
    {
        StartCoroutine(FuelGageSettingIE());
    }

    IEnumerator FuelGageSettingIE()
    {
        Debug.Log("02 . 적용후 연료게이지 총량 :: " + ValueDeliverScript.fuelSizeOri);

        FuelGageBar.color = blueColor;
        FuelGageBase.color = blueColor;
        UISlider fuelSlider = GetComponent<UISlider>();
        UILabel fuelGageCount = transform.FindChild("FuelGageCount").GetComponent<UILabel>();
        fuelSize = ValueDeliverScript.fuelSizeOri;
        fuelSliderValue = 1;

        fuelGageCount.text = "0/" + fuelSize;

        float slideVal = 0;
        while (slideVal < 1)
        {
            fuelSlider.sliderValue = Mathf.Lerp(0, 1, slideVal);
            fuelGageCount.text = ((int)Mathf.Lerp(0f, fuelSize, slideVal)) + "/" + fuelSize;

            yield return null;

            slideVal += Time.deltaTime / 2;
        }
        fuelSlider.sliderValue = fuelSliderValue;
        fuelGageCount.text = (int)(fuelSize) + "/" + fuelSize;
        fuelGage = fuelSize = ValueDeliverScript.fuelSizeOri;
        fuelReduceInterval = fuelSliderValue / fuelSize;
    }

    bool isTimeCal = false;
    public void GageReduceVoid()
    {
        //StartCoroutine(GageReduceIE());
        isTimeCal = true;   //이 값이 트루가 되면 연료를 조금씩 소비하는 업데이트 내 if  구문이 실행된다.
    }


    void Update()
    {
        if (isTimeCal == false) return;

        //연료가 아직 있으면~
        if (fuelGage > 0)
        {
            ValueDeliverScript.fuelSize = fuelGage = fuelGage - Time.deltaTime;

            fuelSliderValue -= fuelReduceInterval * Time.deltaTime;

            if (fuelGage < 0) fuelGage = 0;

            fuelGageCount.text = (int)(fuelGage) + "/" + fuelSize;
            fuelUiSlider.sliderValue = fuelSliderValue;

            if (fuelSliderValue > 0.2f)
            {
                FuelGageBar.color = FuelGageBase.color = blueColor;
            }
            else
            {
                FuelGageBar.color = FuelGageBase.color = redColor;
            }
        }
        else if (ValueDeliverScript.isPcExplo == false)
        {
            Debug.Log(":::::::::::::::: 연료 다 떨어짐 ::::::::::::::::" + ValueDeliverScript.isPcExplo);
            FlightExplo();
        }
    }

    public void GageReduceVoid(float reduceValue , bool isDebris = false)
    {
        if (isInvincible) return;
        Debug.Log("부딪힘?");
        Debug.Log("감소값 ? :: " + reduceValue);
        ValueDeliverScript.fuelSize = fuelGage -= reduceValue;
        fuelSliderValue -= fuelReduceInterval * reduceValue;

        if (fuelGage < 0)
        {
            fuelGage = 0;
            FlightExplo();
        }
        fuelGageCount.text = fuelGage + "/" + fuelSize;
        fuelUiSlider.sliderValue = fuelSliderValue;

        Camera.main.GetComponent<CameraShakeScript>().NowTime(0.8f, false, true);

        if (isDebris == false)
        {
            isInvincible = true;
            StartCoroutine(InvincibleIE());
        }
    }

    void FlightExplo()
    {
        if (PC.tag == "Unbeatable") return;
        Debug.Log(":::::::::::::::: 연료 다 떨어짐 ::::::::::::::::" + ValueDeliverScript.isPcExplo);
        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterSpeak(1);   //기체파괴.
        GameObject.Find("CharacterSpeakManager").GetComponent<CharacterSpeakManagerScript>().CharacterMessageShow(8);

        //이부분에서 실제 폭파로 이한 비쥬얼적인 부분을 모두 처리한다//
        GameObject.Find("PC").GetComponent<PlayerMoveScript>().FlightExplo();

        Camera.main.GetComponent<CameraShakeScript>().NowTime(0.8f, false, true);

        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<UiShow>().GameEnd3(); 					// 비행기 파괴시 종료여부 결정 버튼 활성화.
        gameManager.GetComponent<SoundUiControlScript>().PcExplo();									//폭발사운드. 적용.	
    }

    IEnumerator InvincibleIE()
    {
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
}
