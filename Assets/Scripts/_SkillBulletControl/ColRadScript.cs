using UnityEngine;
using System.Collections;

public class ColRadScript : MonoBehaviour
{
    public GameObject ChildObject;
    ActivateScript activate;
    public float fxSize = 25;

    // Use this for initialization
    void Start()
    {
        activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();
    }

    void ActShotSound()
    {
        GameObject.Find("GameManager").GetComponent<SoundUiControlScript>().FokkerSkillShot();
    }

    // Update is called once per frame
    void ColRad(float rad = 7)
    {
        GetComponent<SphereCollider>().radius = rad;
        ChildObject.SetActive(false);
        activate.ExploActivation(transform.position, 04, fxSize); //폭발이펙트 켜짐.
        StartCoroutine(DeadTime(1f));
    }

    IEnumerator DeadTime(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        GetComponent<SphereCollider>().radius = 0f;
        ChildObject.SetActive(true);
        transform.parent.eulerAngles = new Vector3(0, 0, 0);
        transform.parent.gameObject.SetActive(false);

    }
}
