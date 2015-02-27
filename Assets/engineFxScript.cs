using UnityEngine;
using System.Collections;

public class engineFxScript : MonoBehaviour
{

    bool isEngineOn = false;
    bool isEngineOff = false;
    bool isPlay = false;
    float spendTime = 0f;

    float firstDartPosZ;

    GameObject dart;

    public void Activate(GameObject parentDart)
    {
        firstDartPosZ = parentDart.transform.position.z;
        dart = parentDart;
        isEngineOn = true;
        isEngineOff = false;
        isPlay = false;
        spendTime = 0f;
        particleSystem.emissionRate = 0f;
    }

    void Update()
    {
        //다트가 발생되지 않았으면 업데이트 내용자체를 실행하지 않는다.
        if (!isEngineOn) return;

        if (dart.activeSelf == false)
        {
            PreEngineOff();
            return;
        }

        //여기부터는 실제 다트가 활성화 되고나서 파티클이 나오게 되면서 발생되는 것들을 코딩함//
        transform.position = dart.transform.position;

        //1초간 아무런 파티클이 나오지 않도록 대기한다//
        spendTime += Time.deltaTime;    //이코드는 다트가 생성되고 엔진이 발동되면(Activate)항상 작동, 매 프레임당 시간을 무조건 계산 해준다.
        if (spendTime < 1f) return;
        //======================================================//
        //시작후 일초가 넘지 않으면 절대 이선을 넘지 못한다.


        //실제 엔지의 발동 엔진발동 하는것은 딱 한번만 해야되기에 불린으로 처리를 해준다.
        // 하지만 처음에는 레이트 값이 0이라 아무런 파티클도 나오지 않는다//
        if (!isPlay)
        {
            isPlay = true;
            particleSystem.Play();
        }

        if (particleSystem.emissionRate < 20f)
        {
            particleSystem.emissionRate += 0.3f;
        }

        //다트가 보이지 않는 영역까지 이동했는가를 체크하고 그보다 작다면 엔진을 끄는 코드를 실행한다.
        if (transform.position.z < -5)
        {
            PreEngineOff();
        }

        //여기부터는 실제 다트가 활성화 되고나서 파티클이 나오게 되면서 발생되는 것들을 코딩함//
    }


    //여기서 엔진이 꺼졌다는 것을 기록하고 끄는 과정을 실행한다. 불린 변수를 넣음으로서 단 한번만 실행된다.
    void PreEngineOff()
    {
        if (isEngineOff == false)
        {
            isEngineOff = true; //한번 진입하면 다시는 진입을 못하게 막는다.
            float interval = firstDartPosZ - dart.transform.position.z;
            
            //다트가 이동한 거리가 1이상이 되면 파티클이 자연스럽게 사리지는 코드를 실행한다//
            if (interval > 1)
            {
                StartCoroutine(EngineOffIE());
            }
            //다트가 이동한 거리가 1보다 작으면 파티클을 바로 사라지게 해서 유령처럼 보이지 않게 한다//
            else
            {
                EngineOff();
            }
        }
    }

    //파티클이 점점 사라짐을 구현함//
    IEnumerator EngineOffIE()
    {
        particleSystem.emissionRate = 0f;

        //파티클이 완전히 사라질때까지 기다린다.
        while (particleSystem.particleCount > 0)
        {
            yield return null;
        }

        EngineOff();
    }


    //파티클이 다 사라지고 갯수가 0이 되었을때 이쪽으로 이동한다.// 파티클자체를 꺼줌//
    void EngineOff()
    {
        isEngineOn = false;
        gameObject.SetActive(false);
    }

}






    #region 이전 스크립트
    //GameObject parentUfo;
    //bool onFollow;


    //IEnumerator DurationEnd()
    //{
    //    float endTime = GetComponent<ParticleSystem>().duration;

    //    float spendTime = 0f;
    //    while (spendTime < endTime)
    //    {
    //        yield return null;
    //        spendTime += Time.deltaTime;
    //        if (parentUfo.activeSelf == false)
    //        {
    //            particleSystem.emissionRate = 0f;
    //            break;
    //        }
    //    }

    //    //yield return new WaitForSeconds(endTime);
    //    this.gameObject.SetActive(false);
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    if (onFollow)
    //    {
    //        transform.position = parentUfo.transform.position;
    //    }
    //    if (transform.localPosition.z < -5) this.gameObject.SetActive(false);
    //}



    //public void Activate(GameObject parentUfoFrom)
    //{
    //    Debug.Log("여기도 오긴 오냐?");
    //    parentUfo = parentUfoFrom;
    //    onFollow = true;
    //    StartCoroutine(DurationEnd());
    //    Debug.Log("와서 완성했냐?");
    //}

    //public void Deactivate()
    //{
    //    if (gameObject.activeSelf == true)
    //    {
    //        StartCoroutine(IEdeactivate());
    //    }
    //}

    //IEnumerator IEdeactivate()
    //{
    //    if (gameObject.activeSelf == true)
    //    {
    //        this.particleSystem.emissionRate = 0f;
    //        yield return new WaitForSeconds(1.5f);
    //        this.gameObject.SetActive(false);
    //    }
    //}

    #endregion

