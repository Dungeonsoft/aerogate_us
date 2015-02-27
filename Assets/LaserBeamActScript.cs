using UnityEngine;
using System.Collections;

public class LaserBeamActScript : MonoBehaviour
{
    //float startT =0f;
    //float endT = 0f;

    //public bool newSuperPower = false;

    //void OnEnable()
    //{
    //    StartCoroutine(Activation());
    //}

    //public void StartLaser()
    //{
    //    StartCoroutine(Activation());
    //}

    //IEnumerator Activation()
    //{
    //    float spendTime = 0;

    //    float waitTime = 6f;
    //    float waitTimeF = waitTime - animation.GetClip("LaserBeamShowAnim02").length;
    //    //Debug.Log("시간체크시작");
    //    startT = Time.timeSinceLevelLoad;

    //    //Debug.Log("시작시간 ::: " + startT);
    //    animation.Play("LaserBeamShowAnim01");
    //    Camera.main.GetComponent<CameraShakeScript>().NowTime(6f, false, false);  // 가짜 융단폭격후 카메라 쉐이크.

    //    if (newSuperPower)
    //    {
    //        //yield return null;
    //        //Debug.Log("레이져멈추기 01");
    //        newSuperPower = false;
    //        yield break;
    //    }

    //    while (spendTime <= waitTimeF)
    //    {
    //        if (newSuperPower)
    //        {
    //            //yield return null;
    //            //Debug.Log("레이져멈추기 02");
    //            newSuperPower = false;
    //            yield break;
    //        }

    //        yield return null;
    //        spendTime += Time.deltaTime;
    //    }

    //    animation.Play("LaserBeamShowAnim02");

    //    if (newSuperPower)
    //    {
    //        //yield return null;
    //        //Debug.Log("레이져멈추기 03");
    //        newSuperPower = false;
    //        yield break;
    //    }

    //    endT = Time.timeSinceLevelLoad;
    //    //Debug.Log("중간시간" + endT);
    //    //Debug.Log("현재지속시간 ::: " + (endT - startT));

    //    while (spendTime <= waitTime)
    //    {
    //        if (newSuperPower)
    //        {
    //            //yield return null;
    //            //Debug.Log("레이져멈추기 04");
    //            newSuperPower = false;
    //            yield break;
    //        }

    //        yield return null;
    //        spendTime += Time.deltaTime;
    //    }

    //    endT = Time.timeSinceLevelLoad;
    //    //Debug.Log("종료시간" + endT);
    //    //Debug.Log("지속시간 ::: " + (endT - startT));
    //    gameObject.SetActive(false);
    //}
}
