using UnityEngine;
using System.Collections;

public class BulletMissileActivation : MonoBehaviour
{

    public float lifeTime;
    float enemyDistance = 6;
    float enemyDistanceDouble;
    bool isFindEnemy = false;
    GameObject focusEnemy;

    float distX;
    float distZ;
    float rad;
    float degY;

    float tRotY;

    float fixedY;
    float addValue = 0;

    bool isFind1;
    bool isFind2;

    public float speed = 15;

    float realSpeed;

    float speedLerp;

    //	BulletControlScript bulletControlScript;

    GameObject[] enemyObject;

    GameObject engineParticle;

    // Use this for initialization
    void Awake()
    {
        //				bulletControlScript = GameObject.Find ("GameManager").GetComponent<BulletControlScript> ();
        ValueDeliverScript.enemyInGame.Clear();
    }


    public void Activate()
    {
        StartCoroutine(DeadTime());
        speedLerp = 0;
    }

    public void Activate(float missileAngle)
    {
        speedLerp = 0;
        addValue = 0;
        isFindEnemy = false;
        enemyDistanceDouble = enemyDistance * enemyDistance;
        transform.eulerAngles = new Vector3(0, missileAngle, 0);
        DeadPosition(); //타게팅 해주는 함수.

        //ActiveFx(); //미사일 연기 이펙트.
    }

    IEnumerator DeadTime()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

    void DeadPosition()
    {
        //				어레이 리스트를 만들어서 새로운 적기가 활성화되면 어레이리스트에 축했다가 비활성화 되면 빼는 형식으로 제작.
        if (ValueDeliverScript.enemyInGame.Count > 0)
        {
            int rndNum = Random.Range(0, ValueDeliverScript.enemyInGame.Count);
            focusEnemy = (GameObject)ValueDeliverScript.enemyInGame[rndNum];
        }

        //while (true)
        //{
        //    if (focusEnemy && focusEnemy.activeSelf == true)    //적 UFO가 있고 활성화 되어 있을때.
        //    {
        //        if (!focusEnemy.name.Contains("Dust"))
        //        {
        //            distX = focusEnemy.transform.position.x - transform.position.x;
        //            distZ = focusEnemy.transform.position.z - transform.position.z;
        //        }
        //        else
        //        {
        //            distX = focusEnemy.transform.GetChild(0).position.x - transform.position.x;
        //            distZ = focusEnemy.transform.GetChild(0).position.z - transform.position.z;
        //        }
        //        rad = Mathf.Atan2(distX, distZ);
        //        tRotY = transform.rotation.y;

        //        if (addValue < 1)
        //        {
        //            fixedY = Mathf.LerpAngle(tRotY, rad, addValue);
        //            transform.rotation = new Quaternion(transform.rotation.x, fixedY, transform.rotation.z, 1);
        //            addValue += Time.deltaTime * 2;
        //        }
        //        else
        //        {
        //            transform.rotation = new Quaternion(transform.rotation.x, rad, transform.rotation.z, 1);
        //        }
        //    }

        //    realSpeed = Mathf.Lerp(0, speed, speedLerp);

        //    transform.Translate(0, 0, realSpeed * Time.deltaTime);  //실제 미사일 움직임.

        //    if (transform.position.x > 25 || transform.position.x < -25 || transform.position.z > 120 || transform.parent.position.z < -10)
        //    {
        //        break;
        //    }

        //    yield return null;

        //    if (speedLerp < 1) speedLerp += Time.deltaTime * 1f;
        //}
        //gameObject.SetActive(false);
    }

    void Update()
    {
            if (focusEnemy && focusEnemy.activeSelf == true)    //적 UFO가 있고 활성화 되어 있을때.
            {
                if (!focusEnemy.name.Contains("Dust"))
                {
                    distX = focusEnemy.transform.position.x - transform.position.x;
                    distZ = focusEnemy.transform.position.z - transform.position.z;
                }
                else
                {
                    distX = focusEnemy.transform.GetChild(0).position.x - transform.position.x;
                    distZ = focusEnemy.transform.GetChild(0).position.z - transform.position.z;
                }
                rad = Mathf.Atan2(distX, distZ);
                tRotY = transform.rotation.y;

                if (addValue < 1)
                {
                    fixedY = Mathf.LerpAngle(tRotY, rad, addValue);
                    transform.rotation = new Quaternion(transform.rotation.x, fixedY, transform.rotation.z, 1);
                    addValue += Time.deltaTime * 2;
                }
                else
                {
                    transform.rotation = new Quaternion(transform.rotation.x, rad, transform.rotation.z, 1);
                }
            }

            realSpeed = Mathf.Lerp(0, speed, speedLerp);

            transform.Translate(0, 0, realSpeed * Time.deltaTime);  //실제 미사일 움직임.

            if (transform.position.x > 25 || transform.position.x < -25 || transform.position.z > 120 || transform.parent.position.z < -10)
            {
                gameObject.SetActive(false);
            }

            if (speedLerp < 1) speedLerp += Time.deltaTime * 1f;
    }

    #region 엔진파티클 구현부 - 다트에서 가지고 왔고 현재 전혀 다듬어 지지 않아. 주석 처리.
    //void ActiveFx()
    //{
    //    Transform engineFx = GameObject.Find("EngineFx").transform;
    //    int engineFxCount;
    //    engineFxCount = engineFx.GetChildCount();
    //    GameObject fxChild;
    //    for (int i = 0; i < engineFxCount; i++)
    //    {

    //        fxChild = engineFx.GetChild(i).gameObject;
    //        if (fxChild.activeSelf == false)
    //        {
    //            fxChild.SetActive(true);
    //            engineParticle = fxChild;
    //            fxChild.transform.position = this.transform.position;
    //            fxChild.GetComponent<engineFxScript>().Activate(this.gameObject);
    //            StartCoroutine(PlayEngine());
    //            return;
    //        }
    //    }
    //}

    //IEnumerator PlayEngine()
    //{
    //    yield return new WaitForSeconds(.1f);
    //    engineParticle.particleSystem.emissionRate = 0f;
    //    engineParticle.particleSystem.Play();
    //    while (engineParticle.particleSystem.emissionRate < 20f)
    //    {
    //        engineParticle.particleSystem.emissionRate += 0.3f;
    //        yield return null;
    //    }
    //}
    #endregion
}     

