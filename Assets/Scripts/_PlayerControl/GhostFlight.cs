using UnityEngine;
using System.Collections;
using System.Text;

public class GhostFlight : MonoBehaviour
{
	public int bulletNumber;
    public int flightNumber;
	bool isFireBullet = false;
		
	GameObject flight;
//	ActivateScript Activate;

	float lerpValue = 0.05f;

	bool islerp;

	public float speed = 0.7f;
	public float zRotLimit =30;

	public float flightDistance = 5f;

	public float flyingTime = 5f;

	GameObject infoUi;

	bool isFallowflight = false;

    public GameObject[] flightMesh;
		
	void Start()
	{
		transform.localScale = new Vector3(0,0,0);
		infoUi = GameObject.Find ("InfoUI");
		flight = GameObject.Find ("Flight");
//		Activate = GameObject.Find("GameManager").GetComponent<ActivateScript>();
        flyingTime += ValueDeliverScript.friendFlightAddTime;
			
		StartCoroutine (DestroyTime());
	}
		
	IEnumerator DestroyTime ()
	{
		isFallowflight = true; 
		float scaleTime = 0;
		while(scaleTime < 1)
		{
			transform.localScale = new Vector3(scaleTime , scaleTime , scaleTime);
			scaleTime += Time.deltaTime*2f;
			yield return null;  
		}
		transform.localScale = new Vector3(1 , 1 , 1);

		isFireBullet = true;
		StartCoroutine (FireBullet());
		yield return new WaitForSeconds(flyingTime);			//친구비행기 유지시간을 정한다.
        float spendTime = 0;
        while (spendTime < flyingTime)
        {
            yield return null;
            if (ValueDeliverScript.isPcExplo == true) break;    //전투기가 파괴되었으므로 고스트전투기 상황을 종료한다//
            spendTime += Time.deltaTime;
        }

		DestroyGhost ();  
	}

	public void DestroyGhost ()
	{
		StartCoroutine (DestroyGhostIE ());
	}

	IEnumerator DestroyGhostIE ()
	{
		isFallowflight = false;
		isFireBullet = false;
		float customValue = 0;
		while(transform.position.z > -10)
		{
			transform.Translate (0, 0, -1 * customValue * Time.deltaTime);			 
			transform.eulerAngles += new Vector3 (0, 0, customValue* 300 * Time.deltaTime);
			customValue += 0.5f;
			yield return null;
		}
		Destroy (gameObject);
	}

	IEnumerator FireBullet ()
	{
		yield return new WaitForSeconds(1f);
		while(isFireBullet)
		{
            if (flight.activeSelf == false) break;
			BulletActivate (bulletNumber);
			yield return new WaitForSeconds(0.1f);
		}
	}
		
	//총알 액티베이션.
	public void BulletActivate(int bulletLevel)
	{
        if (bulletLevel <= 0) bulletLevel = 1;

        //Debug.Log("Ghost Bullet Level ::: " + bulletLevel);
        //Debug.Break();
		StringBuilder bulletLevelNum = new StringBuilder();
        bulletLevelNum.AppendFormat("Bullet{0}_{1}", flightNumber.ToString("00"), bulletLevel.ToString("D3"));

        //Debug.Log(" ::: bulletLevelNum :::: " + bulletLevelNum + " :::");
        int bulletCount = GameObject.Find(bulletLevelNum.ToString()).transform.childCount; 
		for(int i=0 ; i<bulletCount ; i++)
		{
			GameObject bullet = GameObject.Find(bulletLevelNum.ToString()).transform.GetChild(i).gameObject;
			if(bullet.activeSelf == false)
			{
				bullet.SetActiveRecursively(true);
				bullet.transform.position = transform.position + new Vector3( 0 , 0 , 1.2f );
				bullet.GetComponent<BulletActivation>().Activate();
				bulletLevelNum.Length = 0;
				return;
			}
		}
	}

    Vector3 fPos1;
    Vector3 fPos2;
    void Update()
    {
        if (isFallowflight && flight != null)
        {

            fPos1 = flight.transform.position + new Vector3(-5, 0, 0);
            transform.position = Vector3.Lerp(transform.position , fPos1 , 0.08f);
            transform.rotation = flight.transform.rotation;
        }

    }
}