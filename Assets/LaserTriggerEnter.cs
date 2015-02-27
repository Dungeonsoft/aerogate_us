using UnityEngine;
using System.Collections;

public class LaserTriggerEnter : MonoBehaviour {


    //이 아래 구성된 코드는 레이저 캐논을 폭탄이나 기타 강력한 무기로 폭파 시키려고 만든 코드이나  코루틴의 문제로 인해 현재 사용하면 안됨//
    //이 아래 구성된 코드는 레이저 캐논을 폭탄이나 기타 강력한 무기로 폭파 시키려고 만든 코드이나  코루틴의 문제로 인해 현재 사용하면 안됨//
    //이 아래 구성된 코드는 레이저 캐논을 폭탄이나 기타 강력한 무기로 폭파 시키려고 만든 코드이나  코루틴의 문제로 인해 현재 사용하면 안됨//
    //이 아래 구성된 코드는 레이저 캐논을 폭탄이나 기타 강력한 무기로 폭파 시키려고 만든 코드이나  코루틴의 문제로 인해 현재 사용하면 안됨//
    //이 아래 구성된 코드는 레이저 캐논을 폭탄이나 기타 강력한 무기로 폭파 시키려고 만든 코드이나  코루틴의 문제로 인해 현재 사용하면 안됨//
    //이 아래 구성된 코드는 레이저 캐논을 폭탄이나 기타 강력한 무기로 폭파 시키려고 만든 코드이나  코루틴의 문제로 인해 현재 사용하면 안됨//
    //이 아래 구성된 코드는 레이저 캐논을 폭탄이나 기타 강력한 무기로 폭파 시키려고 만든 코드이나  코루틴의 문제로 인해 현재 사용하면 안됨//


    SoundUiControlScript soundUiControlScript;
    ActivateScript activate;


    void Start()
    {
        soundUiControlScript = GameObject.Find("GameManager").GetComponent<SoundUiControlScript>();
        activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("콜라이더 태그 이름 ::: " + col.tag);
        switch (col.tag)
        {
            case "SuperPower":
            case "Bomb01":
            //case "Bomb":
            case "Bomb03":  //핵폭탄//
                StartCoroutine(ExploEnd());
                break;
        }
    }


    IEnumerator ExploEnd()
    {
        soundUiControlScript.UfoExplo(); //폭파음재생.

        activate.ExploActivation(transform.position + new Vector3(0, 0, -5), 01, gameObject.name); //피탄 이펙트 켜짐.
        yield return new WaitForSeconds(0.2f);
        activate.ExploActivation(transform.position, 01, gameObject.name); //피탄 이펙트 켜짐.
        yield return new WaitForSeconds(0.2f);
        activate.ExploActivation(transform.position + new Vector3(0, 0, 5), 01, gameObject.name); //피탄 이펙트 켜짐.

        transform.parent.parent.gameObject.SetActive(false);
    }
}
