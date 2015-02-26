using UnityEngine;
using System.Collections;

public class EnemyLaser : MonoBehaviour {

    public GameObject spark;
    public GameObject light;
    public GameObject laserBeam;
    public float timer = 9.0f;
    public float timer2 = 6.0f;
    // Use this for initialization
    //void Start()
    //{
    //    StartCoroutine(StartLaser());
    //}

    void Awake()
    {
        //laser.SetActive(false);
        //spark.SetActive(false);

        spark.particleSystem.Stop();
        light.particleSystem.Stop();
    }

    //코루틴 순서 003//
    public IEnumerator StartLaser()
    {
        Debug.Log("파티클 애니메이션 시작!!!");
        spark.SetActive(true);
        light.SetActive(true);

        spark.particleSystem.Play();
        light.particleSystem.Play();

        yield return new WaitForSeconds(timer);

        laserBeam.animation.Play("LaserCannonBeamAnim01");
        yield return new WaitForSeconds(timer2);

        //파티클 애니메이션 멈춤//
        spark.particleSystem.Stop();
        light.particleSystem.Stop();
        laserBeam.animation.Play("LaserCannonBeamAnim02");
        yield return new WaitForSeconds(1f);
        Debug.Log("StartLaser 015");

        //StartCoroutine(StartLaser());
    }

    float timeAllVal;
    public float SpendTime()
    {
        Debug.Log("SpendTime 001");

        timeAllVal = timer + timer2;
        return timeAllVal;
    }
}
