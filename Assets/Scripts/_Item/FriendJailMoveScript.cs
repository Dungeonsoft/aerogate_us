using UnityEngine;
using System.Collections;
using System.Text;

public class FriendJailMoveScript : MonoBehaviour
{
    float xPosition;
    float spendTime;
    int isPlusMinus;

    int flightNumber;
    int bulletNumber;
    string friendId;
    int friendSkin;
    string friendUrl;

    bool isSound = false;

    public GameObject[] flightFriend;//실제 친구 비행기로 바꾸어야 됨.

    GameObject helpObj;

    void Update() // 친구 감옥 포물선 움직임 담당.
    {
        if (!isSound)
        {
            GameObject.Find("GameManager").GetComponent<SoundUiControlScript>().FriendsDrop();
            isSound = true;
        }
        transform.Translate(isPlusMinus * 2f * Time.deltaTime, 0, (12 - spendTime) * Time.deltaTime);
        if (spendTime > 60)
            spendTime = 60;
        else
            spendTime += Time.deltaTime * 10;

        if (transform.position.z < -10)
        { // 일정위치 이하로 내려가면 death.
            //						helpObj.SetActive (false);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (!GameObject.Find("Flight")) return;


        if (col.gameObject.tag == "Player" || col.gameObject.tag == "PlayerEtc" || col.gameObject.tag == "SuperPower")
        {

            //구출한 친구의 아이디를 저장한다.
            //첫번째 저장하는 아이디가 아니면 아이디를 저장전에 쉼표를 하나 구분자로 넣어준다.
            if (ValueDeliverScript.rescueFriendId != "")
                ValueDeliverScript.rescueFriendId += ",";
            ValueDeliverScript.rescueFriendId += friendId;
            //구출한 친구의 아이디를 저장한다.

            if (ValueDeliverScript.flightNumber == 2)   //비행기가 가진 목표를 채우기 위한 기능.
            {
                ValueDeliverScript.flight002RescueFriendTemp++;
            }


            GameObject.Find("ScoreCount").GetComponent<UILabel>().text = ValueDeliverScript.scorePlay.ToString("0000000");

            GameObject earlyGhost;
            earlyGhost = GameObject.FindWithTag("GhostFlight");

            if (earlyGhost != null)
            {
                //Debug.Log("earlyGhost Name ::: " + earlyGhost.name);
                //earlyGhost.GetComponent<GhostFlight>().DestroyGhost();

                Destroy(earlyGhost);
            }

            GameObject ghostFlight = Instantiate(flightFriend[flightNumber], col.transform.position+ new Vector3(-6, 0, 0), Quaternion.identity) as GameObject;
            ghostFlight.name = "GhostFlight";
            ghostFlight.GetComponent<GhostFlight>().bulletNumber = bulletNumber;
            ghostFlight.GetComponent<GhostFlight>().flightNumber = flightNumber;

            Texture flightTex = null;
            switch (flightNumber)
            {
                case 0:
                    flightTex = GameObject.Find("GameManager").GetComponent<ObjectPoolScript>().flight001Skin[friendSkin];
                    break;
    
                case 1:
                    flightTex = GameObject.Find("GameManager").GetComponent<ObjectPoolScript>().flight002Skin[friendSkin];
                    break;
      
                case 2:
                    flightTex = GameObject.Find("GameManager").GetComponent<ObjectPoolScript>().flight003Skin[friendSkin];
                    break;
            }

            int fMeshCount = ghostFlight.GetComponent<GhostFlight>().flightMesh.Length;
            for (int cObj = 0; cObj < fMeshCount; cObj++)
            {
                ghostFlight.GetComponent<GhostFlight>().flightMesh[cObj].renderer.material.mainTexture = flightTex;
            }


            GameObject.Find("GameManager").GetComponent<SoundUiControlScript>().FriendsAircraftAppear();
            GameObject.Find("GameManager").GetComponent<SoundUiControlScript>().FriendHelp();

            gameObject.SetActive(false);
        }
    }


    public void FlightBulletNumber(int flight, int bullet , string id , int Skin, string url = null)
    {
        flightNumber = flight;
        bulletNumber = bullet;
        friendId = id;
        friendSkin = Skin;
        friendUrl = url;

        xPosition = transform.position.x;

        isPlusMinus = 1;
        if (xPosition > 0)
        {
            isPlusMinus = -1;
        }
        spendTime = 0;
        GameObject.Find("HelpText").GetComponent<HelpUiObjPool>().HelpObjActivation(gameObject);



    }
}
