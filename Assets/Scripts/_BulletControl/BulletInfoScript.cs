using UnityEngine;
using System.Collections;

public class BulletInfoScript : MonoBehaviour
{
    public int bulletDamage = 100;
    public int flightNum;

    [System.NonSerialized]
    public int bulletDamageF;

    void Start()
    {
        float skin02_05Effect2 = 1f;
        skin02_05Effect2 = ValueDeliverScript.skin02_05Effect2;

        int upgradePointF00P01 = ValueDeliverScript.upgradePointF00P01;
        int upgradePointF01P01 = ValueDeliverScript.upgradePointF01P01;
        int upgradePointF02P01 = ValueDeliverScript.upgradePointF02P01;

        switch (flightNum)
        {
            case 0:
                bulletDamageF = (int)(bulletDamage * skin02_05Effect2) + (upgradePointF00P01 * ValueDeliverScript.damagePerUpoint) + ValueDeliverScript.skin00_04Effect;
                break;
            case 1:
                bulletDamageF = (int)(bulletDamage * skin02_05Effect2) + (upgradePointF01P01 * ValueDeliverScript.damagePerUpoint) + ValueDeliverScript.skin00_04Effect;
                break;
            case 2:
                bulletDamageF = (int)(bulletDamage * skin02_05Effect2) + (upgradePointF02P01 * ValueDeliverScript.damagePerUpoint) + ValueDeliverScript.skin00_04Effect;
                break;
        }
    }
}