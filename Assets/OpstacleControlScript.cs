using UnityEngine;
using System.Collections;

public class OpstacleControlScript : MonoBehaviour
{

    GameObject[] opstacleObjs;
    public GameObject[] laserObjs;
    public GameObject[] debrisObjs;
    public GameObject[] debrisRndObjs;
    public GameObject[] debrisShieldObjs;


    int opCount;
    int laCount;
    int deCount;
    int deRndCount;
    int deShieldCount;

    int apearObjNum;

    int pNum;
    float wTime;
    public float[] wTimeF;
    public float[] wTimeE;

    bool isShow = false;

    int selOpType;

    //옵스터클 기능이 활성화 되서 옵스터클이 얼만큼의 주기로//
    //어떻게 나오게 할 것인가를 정해주는 데 쓰이는 변수들//
    float nextOpSpendTime;

    void Start()
    {
        laCount = laserObjs.Length;
        deCount = debrisObjs.Length;
        deRndCount = debrisRndObjs.Length;
        deShieldCount = debrisShieldObjs.Length;
    }


    void Update()
    {
        if (isShow == false) return;

        if (nextOpSpendTime < wTime)
        {
            //Debug.Log(":: nextOpSpendTime :: " + nextOpSpendTime + "  :: wTime ::  " + wTime);
            nextOpSpendTime += Time.deltaTime;
            return;
        }
        else
        {
            Debug.Log(":: nextOpSpendTime :: " + nextOpSpendTime);
            nextOpSpendTime = 0;
            //옵스터클 보임//
            Show();
            //새로운 다음 옵스터클 생성간을 정해줌//
            wTime = Random.Range(wTimeF[pNum], wTimeE[pNum]);
            return;
        }
    }

    void RandomDebris()
    {
        selOpType = Random.Range(0, 4);

        switch (selOpType)
        {
            case 0:
                opstacleObjs = laserObjs;
                opCount = laCount;
                break;

            case 1:
                opstacleObjs = debrisObjs;
                opCount = deCount;
                break;

            case 2:
                opstacleObjs = debrisRndObjs;
                opCount = deRndCount;
                break;

            case 3:
                opstacleObjs = debrisShieldObjs;
                opCount = deShieldCount;
                break;
        }
    }

    public void Activate(int portalUpLevel)
    {
        Debug.Log("데브리 시작02");

        pNum = portalUpLevel;
        //여기서 이번 스테이지에선 어떤 타입의 방해물이 나오게 할 것인지를 결정한다.
        RandomDebris();
        //여기서 업뎃이 제대로 작동할수 있도록 만들어주는 뭔가를 한다//
        wTime = Random.Range(wTimeF[pNum], wTimeE[pNum]);
        Debug.Log("wTime ::: " + wTime);
        nextOpSpendTime = 0;
        isShow = true;

        if (ValueDeliverScript.portalUpLevel >= 6)
        {
            StartCoroutine(ChangeDEbris());
        }
    }



    IEnumerator ChangeDEbris()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);
            RandomDebris();
        }
    }

    public void IsShowChange()
    {
        isShow = false;
    }

    void Show()
    {
        // 스테이지가 얼마 남지 않으면 isShow를 false로 변경해서 더이상은 방해물이 안나오도록 설정한다.//
        if (isShow == false) return;    // 스테이지가 얼마 남지 않으면 isShow를 false로 변경해서 더이상은 방해물이 안나오도록 설정한다.//
        Debug.Log("데브리 시작05");

        while (true)
        {
            apearObjNum = Random.Range(0, opCount);

            if (opstacleObjs[apearObjNum].activeSelf == false)
            {
                Debug.Log("selOpType :: " + selOpType + "   :: apearObjNum ::" + apearObjNum);
                opstacleObjs[apearObjNum].SetActive(true);
                break;
            }
        }
        DebrisAct activate = opstacleObjs[apearObjNum].GetComponent<DebrisAct>();

        activate.Activate();
    }
}
