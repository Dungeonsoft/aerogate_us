using UnityEngine;
using System.Collections;
using System.Text;

public class ActivateScript : MonoBehaviour
{

    Vector3 pcPosition;
    int oldPosition = -1;

    //총알 액티베이션.
    public void BulletActivate(int bulletLevel)
    {
        StringBuilder bulletLevelNum = new StringBuilder();
        bulletLevelNum.AppendFormat("Bullet{0}_{1}",ValueDeliverScript.flightNumber.ToString ("00"), bulletLevel.ToString("D3"));

        Transform bLevel = transform.FindChild(bulletLevelNum.ToString());
        int bulletCount = bLevel.childCount;
        //				Debug.Log ("bulletLevel ::: "+bulletLevel);
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = bLevel.GetChild(i).gameObject;
            if (bullet.activeSelf == false)
            {
                bullet.SetActiveRecursively(true);
                pcPosition = transform.Find("PC").position + new Vector3(0, 0, 1.2f);
                bullet.transform.position = pcPosition;
                bullet.GetComponent<BulletActivation>().Activate();
                bulletLevelNum.Length = 0;
                return;
            }
        }
    }

    //MissileComancheTf01 :: 300
    //MissileComancheTf02 :: 450
    //MissileComancheTf03 :: 400
    //MissileComancheTf04 :: 600
    //MissileComancheTf05 :: 500
    //MissileComancheTf06 :: 750


    IEnumerator missileActive01(int bulletLevel)
    {
        switch (bulletLevel)
        {
            case 1:
            case 2:
            case 3:
                BulletMissileActivate1(bulletLevel, "MissileComancheTf01", "missileMoveLeft01");
                BulletMissileActivate1(bulletLevel, "MissileComancheTf01", "missileMoveRight01");
                break;

            case 4:
            case 5:
            case 6:
                BulletMissileActivate1(bulletLevel, "MissileComancheTf01", "missileMoveLeft01");
                BulletMissileActivate1(bulletLevel, "MissileComancheTf01", "missileMoveRight01");
                yield return new WaitForSeconds(0.1f);
                BulletMissileActivate1(bulletLevel, "MissileComancheTf02", "missileMoveLeft02");
                BulletMissileActivate1(bulletLevel, "MissileComancheTf02", "missileMoveRight02");
                break;

            case 7:
            case 8:
            case 9:
                BulletMissileActivate1(bulletLevel, "MissileComancheTf03", "missileMoveLeft01");
                BulletMissileActivate1(bulletLevel, "MissileComancheTf03", "missileMoveRight01");
                yield return new WaitForSeconds(0.1f);
                BulletMissileActivate1(bulletLevel, "MissileComancheTf04", "missileMoveLeft02");
                BulletMissileActivate1(bulletLevel, "MissileComancheTf04", "missileMoveRight02");
                break;

            case 10:
            case 11:
            case 12:
                BulletMissileActivate1(bulletLevel, "MissileComancheTf03", "missileMoveLeft01");
                BulletMissileActivate1(bulletLevel, "MissileComancheTf03", "missileMoveRight01");
                yield return new WaitForSeconds(0.1f);
                BulletMissileActivate1(bulletLevel, "MissileComancheTf03", "missileMoveLeft02");
                BulletMissileActivate1(bulletLevel, "MissileComancheTf03", "missileMoveRight02");
                yield return new WaitForSeconds(0.1f);
                BulletMissileActivate1(bulletLevel, "MissileComancheTf04", "missileMoveLeft03");
                BulletMissileActivate1(bulletLevel, "MissileComancheTf04", "missileMoveRight03");
                break;

            case 13:
            case 14:
            case 15:
                BulletMissileActivate1(bulletLevel, "MissileComancheTf05", "missileMoveLeft01");
                BulletMissileActivate1(bulletLevel, "MissileComancheTf05", "missileMoveRight01");
                yield return new WaitForSeconds(0.1f);
                BulletMissileActivate1(bulletLevel, "MissileComancheTf06", "missileMoveLeft02");
                BulletMissileActivate1(bulletLevel, "MissileComancheTf06", "missileMoveRight02");
                yield return new WaitForSeconds(0.1f);
                BulletMissileActivate1(bulletLevel, "MissileComancheTf06", "missileMoveLeft03");
                BulletMissileActivate1(bulletLevel, "MissileComancheTf06", "missileMoveRight03");
                break;
        }
    }

    IEnumerator missileActive02(int bulletLevel)
    {
        switch (bulletLevel)
        {
            case 1:
            case 2:
            case 3:
                BulletMissileActivate2(bulletLevel, "MissilePantomTf01", 15f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf01", -15f);
                break;

            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
                BulletMissileActivate2(bulletLevel, "MissilePantomTf01", 15f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf01", -15f);
                yield return new WaitForSeconds(0.1f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf01", 30f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf01", -30f);
                break;

            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
                BulletMissileActivate2(bulletLevel, "MissilePantomTf01", 15f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf01", -15f);
                yield return new WaitForSeconds(0.1f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf01", 30f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf01", -30f);
                yield return new WaitForSeconds(0.1f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf01", 45f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf01", -45f);
                break;

            case 15:
                BulletMissileActivate2(bulletLevel, "MissilePantomTf02", 15f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf02", -15f);
                yield return new WaitForSeconds(0.1f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf02", 30f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf02", -30f);
                yield return new WaitForSeconds(0.1f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf02", 45f);
                BulletMissileActivate2(bulletLevel, "MissilePantomTf02", -45f);
                break;
        }

    }

    public void BulletMissileActivate(int bulletLevel)
    {
        //Debug.Log("bulletLevel ::: " + bulletLevel);
        if (ValueDeliverScript.flightNumber == 1)
        {
            StartCoroutine(missileActive01(bulletLevel));
        }
        if (ValueDeliverScript.flightNumber == 2)
        {
            StartCoroutine(missileActive02(bulletLevel));
        }
    }


    void BulletMissileActivate1(int bulletLevel, string goName, string clipName)
    {
        Transform gName = transform.FindChild(goName);
        int bulletMissileCount = gName.childCount;
        for (int i = 0; i < bulletMissileCount; i++)
        {
            GameObject bulletMissile = gName.GetChild(i).gameObject;
            if (bulletMissile.activeSelf == false)
            {
                bulletMissile.SetActiveRecursively(true);
                pcPosition = transform.Find("PC").position + new Vector3(0, 0, 1.2f);
                bulletMissile.transform.position = pcPosition;
                bulletMissile.transform.FindChild("Missile").animation.Play(clipName);
                bulletMissile.GetComponent<BulletMissileActivation>().Activate();

                return;
            }
        }
    }

    void BulletMissileActivate2(int bulletLevel, string goName, float missileAngle)
    {
        Transform gName = transform.FindChild(goName);
        int bulletMissileCount = gName.childCount;
        for (int i = 0; i < bulletMissileCount; i++)
        {
            GameObject bulletMissile = gName.GetChild(i).gameObject;
            if (bulletMissile.activeSelf == false)
            {
                bulletMissile.SetActiveRecursively(true);
                pcPosition = transform.Find("PC").position + new Vector3(0, 0, 1.2f);
                bulletMissile.transform.position = pcPosition;
                bulletMissile.GetComponent<BulletMissileActivation>().Activate(missileAngle);

                return;
            }
        }
    }

    //포탈 액티베이션.
    public void PortalActivate(int portalLevel, int nameNumber = -1)
    {
        Transform portalL = transform.FindChild("Portal01");
        int portalCount = portalL.childCount;
                //Debug.Log ("portalCount : "+portalCount);
        for (int j = 0; j < portalCount; j++)
        {
            GameObject Portal = portalL.GetChild(j).gameObject;
            if (Portal.activeSelf == false)
            {
                int xPosition = RePosition(oldPosition);
                Portal.SetActive(true);
                Portal.GetComponent<PortalActivation>().Activate(portalLevel, nameNumber);
                                //Debug.Log ("2portalLevel : " + portalLevel);
                Portal.transform.position = new Vector3(Random.Range(-11f, -7f) + xPosition * 6f, 0, Random.Range(27, 45));

                oldPosition = xPosition;
                return;
            }
        }
    }

    int RePosition(int oldPosition2)
    {
        int xPosition = Random.Range(0, 4);

        if (xPosition == oldPosition2)
        {
            return RePosition(oldPosition2);
        }
        else
        {
            return xPosition;
        }
    }

    //유에프오 액티베이션.
    public void UfoActivate(string portalName, Transform portalTransform, string ufoName, int ufoNumber, float delayStartTime, float addY, float randomAngle, GameObject parentPortal, int enemyMaxCount)
    {
        StringBuilder ufoLevelNum = new StringBuilder();
        ufoLevelNum.AppendFormat("{0}{1}", ufoName, ufoNumber.ToString("D2"));
        Transform ufo = transform.FindChild(ufoLevelNum.ToString());

        for (int i = 0; i < ufo.childCount; i++)
        {
            GameObject ufoChild = ufo.GetChild(i).gameObject;
            if (ufoChild.activeSelf == false)
            {
                UfoActivation ufoActivation = ufoChild.GetComponent(ufoName) as UfoActivation;
                ufoChild.SetActive(true);
                if (ufoName == "UfoDart")
                    ufoChild.transform.position = portalTransform.position + new Vector3(0, 0, -2) + new Vector3((-(0.9f * (enemyMaxCount - 1)) + addY), 0, 0);
                else
                    ufoChild.transform.position = portalTransform.position;
                ufoActivation.Activate(delayStartTime, addY, randomAngle, parentPortal);
                ufoChild.GetComponent<UfoExplosion>().ufoName = ufoName;
                ufoLevelNum.Length = 0;
                return;
            }
        }
    }

    //폭발 액티베이션.
    public void ExploActivation(Vector3 ufoPosition, int exploLevel , string ufoName)
    {
        StringBuilder exploLevelNum = new StringBuilder();
        exploLevelNum.AppendFormat("Explo{0}", exploLevel.ToString("D2"));

        Transform eLevel = transform.FindChild(exploLevelNum.ToString());
        int exploCount = eLevel.childCount;
        for (int j = 0; j < exploCount; j++)
        {
            GameObject explo = eLevel.GetChild(j).gameObject;
            if (explo.activeSelf == false)
            {
                explo.SetActive(true);
                explo.transform.position = ufoPosition;
                //explo.GetComponent<FxLifeScript>().Activate(ufoName);
                exploLevelNum.Length = 0;
                return;
            }
        }
    }


    public void ExploActivation(Vector3 ufoPosition, int exploLevel, float Scale)
    {
        StringBuilder exploLevelNum = new StringBuilder();
        exploLevelNum.AppendFormat("Explo{0}", exploLevel.ToString("D2"));
        Transform eLevel = transform.FindChild(exploLevelNum.ToString());
        int exploCount = eLevel.childCount;
        for (int j = 0; j < exploCount; j++)
        {
            GameObject explo = eLevel.GetChild(j).gameObject;
            if (explo.activeSelf == false)
            {
                explo.SetActive(true);
                explo.transform.position = ufoPosition;
                //explo.GetComponent<FxLifeScript>().Activate("None"); 
                exploLevelNum.Length = 0;
                return;
            }
        }
    }




    //동전 액티베이션.
    public void CoinActivation(Vector3 ufoPosition, int coinLevel)
    {
        StringBuilder coinLevelNum = new StringBuilder();
        coinLevelNum.AppendFormat("Coin{0}", coinLevel.ToString("D2"));
        //		Debug.Log ("coinLevelNum : "+coinLevelNum);
        Transform cLevel = transform.FindChild(coinLevelNum.ToString());
        int coinCount = cLevel.childCount;

        for (int j = 0; j < coinCount; j++)
        {
            GameObject coin = cLevel.GetChild(j).gameObject;
            if (coin.activeSelf == false)
            {
                coin.transform.position = ufoPosition;
                coin.SetActive(true);
                coin.GetComponent<ItemMove>().Activate();
                coinLevelNum.Length = 0;
                return;
            }
        }
    }

    //아이템들 액티베이션(파워업, 스킬업,마그넷...).
    public void ItemActivation(Vector3 ufoPosition, int itemLevel)
    {
        //		Debug.Log ("SkillUp2222");
        StringBuilder itemLevelNum = new StringBuilder();
        itemLevelNum.AppendFormat("Item{0}", itemLevel.ToString("D2"));
        Transform iLevel = transform.FindChild(itemLevelNum.ToString());
        int itemCount = iLevel.childCount;
        for (int j = 0; j < itemCount; j++)
        {
            GameObject item = iLevel.GetChild(j).gameObject;
            if (item.activeSelf == false)
            {
                //				Debug.Log ("SkillUp3333");
                item.transform.position = ufoPosition;
                item.SetActive(true);
                if (item.tag != "Item06") item.GetComponent<ItemMove>().Activate();
                itemLevelNum.Length = 0;
                return;
            }
        }
    }

    //핵폭탄 액티베이션.
    public void BombActivation(int bombLevel , float addRange)
    {
        StringBuilder bombLevelNum = new StringBuilder();
        bombLevelNum.AppendFormat("Bomb{0}", bombLevel.ToString("D2"));
        //Debug.Log ("coinLevelNum : "+coinLevelNum);

        Transform bLevel = transform.FindChild(bombLevelNum.ToString());
        int bombCount = bLevel.childCount;

        for (int j = 0; j < bombCount; j++)
        {
            GameObject bomb = bLevel.GetChild(j).gameObject;
            if (bomb.activeSelf == false)
            {
                Vector3 scale =  bomb.transform.localScale;
                bomb.transform.position = GameObject.Find("PC").transform.position;
                bomb.transform.localScale = new Vector3(scale.x * addRange, scale.y * addRange, scale.z * addRange);
                bomb.SetActive(true);
                bomb.GetComponent<BombActivateScript>().Activate();
                bombLevelNum.Length = 0;
                return;
            }
        }
    }

    //스킬 액티베이션.
    public void SkillActivation(int skillLevel, float skillRot = 0f, string aniName = "None")
    {
        StringBuilder skillLevelNum = new StringBuilder();
        skillLevelNum.AppendFormat("SkillBullet{0}", skillLevel.ToString("D2"));
        //Debug.Log("Skill Level Number ::: " + skillLevelNum.ToString());

        Transform sLevel = transform.FindChild(skillLevelNum.ToString());
        int skillCount = sLevel.childCount;

        for (int j = 0; j < skillCount; j++)
        {
            GameObject skill = sLevel.GetChild(j).gameObject;
            if (skill.activeSelf == false)
            {
                skill.transform.position = GameObject.Find("PC").transform.position;
                skill.SetActive(true);
                skill.transform.eulerAngles += new Vector3(0, skillRot, 0);
                //								skill.GetComponent<SkillMoveActivateScript> ().Activate ();
                if (skillLevel != 4)
                {
                    skill.transform.FindChild("Skill").animation.Play(aniName);
                }
                else
                {
                    skill.GetComponent<PhantomSkillActivateScript>().Activate();
                }

                skillLevelNum.Length = 0;
                return;
            }
        }
    }


    //윙박스 액티베이션.
    public void WingBoxActivation(Vector3 birthPosition, int itemLevel)
    {
        Transform gHole = transform.FindChild("GoldenWormhole01");
        int gHoleCount = gHole.childCount;
        for (int j = 0; j < gHoleCount; j++)
        {
            GameObject gHoleGo = gHole.GetChild(j).gameObject;
            if (gHoleGo.activeSelf == false)
            {
                Debug.Log("골든 웜홀 오브젝트 이름 ::: " + gHoleGo.name + " ::: 위치 ::: " + birthPosition);
                gHoleGo.SetActive(true);
                gHoleGo.transform.position = birthPosition;
                gHoleGo.GetComponent<GHoleMove>().Activate(birthPosition);
                return;
            }
        }
    }

    //친구감옥 액티베이션.
    public void FriendJailActivation(Vector3 birthPosition, int itemLevel, Texture friendPhoto, int flightNumber, int BulletNumber , string FriendId ,int friendSkin ,string friendUrl)
    {

        StringBuilder friendJaillevelNum = new StringBuilder();
        friendJaillevelNum.AppendFormat("FriendJail{0}", itemLevel.ToString("D2"));
        Transform fJail = transform.FindChild(friendJaillevelNum.ToString());
        int friendJailCount = fJail.childCount;
        for (int j = 0; j < friendJailCount; j++)
        {
            GameObject friendJail = fJail.GetChild(j).gameObject;
            if (friendJail.activeSelf == false)
            {
                friendJail.SetActive(true);
                friendJail.transform.position = birthPosition;
                friendJail.GetComponent<FriendJailMoveScript>().FlightBulletNumber(flightNumber, BulletNumber, FriendId,friendSkin, friendUrl);
                friendJail.transform.FindChild("FriendJail/FriendJail01").gameObject.renderer.material.mainTexture = friendPhoto;
                friendJail.transform.FindChild("FriendJail/FriendJail01").gameObject.renderer.material.mainTextureScale = new Vector2(1, 1);
                friendJaillevelNum.Length = 0;
                return;
            }
        }
    }



    float bulletRotInterval;
    
    public void SeedBulletActivation(Vector3 seedPosition , int bulletCount , float bulletRotRage ,int crashDam)
    {
        int addBulletCount = 0;

        bulletRotInterval = bulletRotRage / (bulletCount - 1);
        Transform ufoSeedBullet01 = transform.FindChild("UfoSeedBullet01");
        int seedBulletCount = ufoSeedBullet01.childCount;
        for (int j = 0; j < seedBulletCount; j++)
        {
            GameObject seedBullet = ufoSeedBullet01.GetChild(j).gameObject;
            if (seedBullet.activeSelf == false)
            {
                seedBullet.SetActive(true);
                seedBullet.GetComponent<SeedBulletMove>().crashDamage = crashDam;
                seedBullet.transform.position = seedPosition;
                seedBullet.transform.eulerAngles = new Vector3(0, (bulletRotRage * -0.5f) + (bulletRotInterval * addBulletCount), 0);
                addBulletCount++;
                if (addBulletCount >= bulletCount) return;
            }
        }

    }

    //디스트로이어액티베이션//
    public void DestroyerActivation(Vector3 basePosition, int shieldLevel)
    {
        StringBuilder itemLevelNum = new StringBuilder();

        int shieldRange = Random.Range(1, shieldLevel + 1);

        itemLevelNum.AppendFormat("UfoShieldDestroy{0}", shieldLevel.ToString("D2"));
        Transform iLevel = transform.FindChild(itemLevelNum.ToString());
        int itemCount = iLevel.childCount;
        for (int j = 0; j < itemCount; j++)
        {
            GameObject destroyer = iLevel.GetChild(j).gameObject;
            if (destroyer.activeSelf == false)
            {
                destroyer.transform.position = new Vector3(Random.Range(-12f, 12f), basePosition.y, basePosition.z);
                destroyer.SetActive(true);
                itemLevelNum.Length = 0;    //오브젝트 찾을때 쓰는 스트링 초기화//
                return;
            }
        }
    }

}
