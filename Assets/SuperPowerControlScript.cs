using UnityEngine;
using System.Collections;

public class SuperPowerControlScript : MonoBehaviour {

    bool isSuperPower = false;

    bool isMakeBic = false;

    bool isMakeSmall = false;
    bool isAlreadySmall = false;

    public GameObject LaserBeam;
    public Animation LaserBeamAnim;
    public GameObject FlightBody;
    public SoundUiControlScript soundControl;

    Transform flight;
    Transform PC;
    public float limitTime = 6;
    float smallStartTime;

    float spendTime;

    Vector3 fScale;
    Color fColor;
    Color redColor;
    Color wColor;
    Color newColor;

    float val;

    void Start()
    {
        FlightBody = GameObject.Find("PC").transform.FindChild("Flight/BodyBase").gameObject;
        smallStartTime = limitTime - 0.5f;
        Debug.Log("여기서 플라이트 정의");
        flight = GameObject.Find("Flight").transform;
        PC = transform.Find("PC");

        redColor = new Color(1, 0, 0, 0);
        wColor = new Color(1, 1, 1, 0);
        val = 0f;
    }

	// Update is called once per frame
    void Update()
    {

        if (isSuperPower == true)     //슈퍼파워 시작했을때.
        {
            spendTime += Time.deltaTime;

            if (spendTime >= smallStartTime)
            {
                isMakeSmall = true;
                //작아지는 기능 넣기//
            }
        }

        #region BicSize. 전투기 크기 커짐 & 전투기 빨갛게 변화.
        //전투기 크기 커짐 & 전투기 빨갛게 변화//
        if (isMakeBic == true)
        {
            if (val < 1)
            {
                flight.localScale = Vector3.Lerp(fScale, new Vector3(1.3f, 1.3f, 1.3f), val);

                newColor = Color.Lerp(fColor, redColor, val);
                FlightBody.renderer.material.SetColor("_AddColor", newColor);

                val += Time.deltaTime * 2;
            }
            else
            {
                FlightBody.renderer.material.SetColor("_AddColor", redColor);
                flight.localScale = new Vector3(1.3f, 1.3f, 1.3f);

                //기능이 완료 되었으니 더 이상 이 부분에 들어오지 않게 값을 false로 변경//
                isMakeBic = false;
                val = 0f;
            }
        }
        //전투기 크기 커짐 & 전투기 빨갛게 변화//
        #endregion

        #region SmallSize. 전투기 작아짐 & 전투기 본래 색으로 변화.
        //전투기 작아짐 & 전투기 본래 색으로 변화//
        if (isMakeSmall == true)
        {
            if (isAlreadySmall == false)
            {
                isAlreadySmall = true;
                LaserBeamAnim.Play("LaserBeamShowAnim02");
            }

            if (val < 1)
            {
                flight.localScale = Vector3.Lerp(fScale, new Vector3(1f, 1f, 1f), val);

                newColor = Color.Lerp(fColor, wColor, val);
                FlightBody.renderer.material.SetColor("_AddColor", newColor);

                val += Time.deltaTime * 2;
            }
            else
            {
                #region 종료와 관련된 것들을 이곳에 정리한다. 아래 내용이 실행된다는 것은 슈퍼파워가 기능을 마무리했다는 의미이다.
                //이 부분은 슈퍼파워의 종료 부분이 된다. 값을 초기화 할 경우 이곳에 모두 정리해서 넣는다//
                //이 부분은 슈퍼파워의 종료 부분이 된다. 값을 초기화 할 경우 이곳에 모두 정리해서 넣는다//

                //슈퍼파워 발동이 끝났으니 불린값을 false로 변경//
                isSuperPower = false;
                //작아지는(원래 크기와 색으로 돌아오는) 기능이 마무리 되었으니 false로 변경//
                isMakeSmall = false;
                //원래색으로 돌리고//
                FlightBody.renderer.material.SetColor("_AddColor", wColor);
                //크기도 정상으로//
                flight.localScale = new Vector3(1, 1, 1);
                //다음에 쓰일 변화값 val은 초기값 0으로 변경//
                val = 0;
                //슈퍼파워로 인한 스피드 패널티를 다시 정상으로 돌리고//
                PC.GetComponent<PlayerMoveScript>().OffSuperPowerSpeed();
                //일반 전투기의 태그인 Player 와 PlayerEtc 로 변경//
                PC.tag = "Player";
                PC.FindChild("ExtendPlayerBound").tag = "PlayerEtc";
                Debug.Log("//총알이 나가게 만들어준다//");
                GameObject.Find("GameManager").GetComponent<BulletControlScript>().OffSuperPower();
                //레이저를 끔으로서 슈퍼파워를 마무리한다//
                LaserBeam.SetActive(false);
                #endregion
            }
        }
        //전투기 작아짐 & 전투기 본래 색으로 변화//
        #endregion
    }

    public void OnLaserBeam()
    {
        //0//
        if (isSuperPower == false)
        {
            isSuperPower = true;    //true가 됨으로서 슈퍼파워 유지시간 체크가 시작됨//
        }

        //1-1//
        LaserBeam.SetActive(true);
        
        //1-2//
        LaserBeamAnim.Play("LaserBeamShowAnim01");
        //카메라 흔들기//
        Camera.main.GetComponent<CameraShakeScript>().NowTime(6f, false, false);  // 가짜 융단폭격후 카메라 쉐이크.
        //혹시 모를 비행기 연기 끄기//
        PC.transform.FindChild("RepairFx").gameObject.SetActive(false);
        soundControl.EffectLaseBeam();

        //2...3//
        isMakeBic = true;
        Debug.Log("Flight name ::: "+ flight.name);
        fScale = flight.localScale;
        fColor = FlightBody.renderer.material.GetColor("_AddColor");

        if (isMakeSmall == true)
        {
            val = 1f - val;
        }
        isMakeSmall = false;
        isAlreadySmall = false;
        
        //4//
        PC.tag = "SuperPower";
        PC.FindChild("ExtendPlayerBound").tag = "SuperPower";

        //5//
        spendTime = 0;

        //6//
        PC.GetComponent<PlayerMoveScript>().OnSuperPowerSpeed();

        //7//총알을 안나가게 세팅//
        GameObject.Find("GameManager").GetComponent<BulletControlScript>().OnSuperPower();
    }
}