using UnityEngine;
using System.Collections;

public class BlackHoleBombScript : MonoBehaviour
{
	public GameObject redHole;
	public GameObject blackHole;

    public float remainTime = 8f;

	SoundUiControlScript soundUiControlScript;

    new Vector3 oriPos;

    float rXpos;

    public static bool blackHallOn = false;

	void Awake ()
	{
        oriPos = transform.position;
		soundUiControlScript = GameObject.Find("GameManager").GetComponent<SoundUiControlScript>();
        //BombGageZero = GetComponent
	}

    void Start()
    {
        blackHallOn = false;
        remainTime = 4;
        if (ValueDeliverScript.flightNumber == 1 && ValueDeliverScript.skinNumber == 4)
        {
            remainTime += 3f + (0.1f * ValueDeliverScript.skillLevel);
        }
    }

    void Update()
    {
        rXpos = Random.Range(0f,1f);
        gameObject.transform.position = oriPos + new Vector3(rXpos,0,0);
        GetComponent<SphereCollider>().radius += 0.1f;
    }


	public void Activate ()
	{
        blackHallOn = true; //블랙홀이 발생했음을 알림//

		soundUiControlScript.BombHole();		//폭발사운드. 적용.	
		redHole.GetComponent<ParticleSystem>().Play ();
        //blackHole.GetComponent<ParticleSystem>().Play ();
		StartCoroutine (DestroyHole ());
		GetComponent<ThunderFXScript>().Activate();
	}

	IEnumerator DestroyHole ()
	{
		Camera.main.GetComponent<CameraShakeScript> ().NowTime (4f , true , true);
        //yield return new WaitForSeconds(1f);
        //gameObject.GetComponent<SphereCollider>().enabled = true;
        yield return new WaitForSeconds(remainTime-1);
        //gameObject.GetComponent<SphereCollider>().enabled = false;
        //yield return new WaitForSeconds(3f);
        //GetComponent<SphereCollider>().radius = 60;
        blackHallOn = false;
        yield return new WaitForSeconds(1);
		gameObject.SetActive(false);
	}

}
