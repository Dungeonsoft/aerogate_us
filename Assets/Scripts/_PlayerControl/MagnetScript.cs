using UnityEngine;
using System.Collections;

public class MagnetScript : MonoBehaviour
{

    public GameObject pcMagnet;
    public SphereCollider sphereCollider;
    public float extendMagnetRadius = 6f;

    public GameObject[] Mobjs;
    // Use this for initialization

    //bool isItemMagnet = false;
    void Awake()
    {
        //pcMagnet = gameObject.transform.FindChild("PC/Magnet").gameObject;
        sphereCollider = pcMagnet.GetComponent<SphereCollider>();
        //pcMagnet.SetActive(false);
        for (int i = 0; i < Mobjs.Length; i++)
        {
            Mobjs[i].SetActive(false);
        }
    }

    //public void ItemMagnet()
    //{
    //    pcMagnet.SetActive(true);
    //    isItemMagnet = true;
    //}

    void Update()
    {
        //		Debug ("Magnet Radius ::: " + sphereCollider.radius);
    }
    public void Activate(float mRadius, float mTime)
    {
        Debug.Log("Magnet Act!!!");
        //Debug.Log("isItemMagnet :::: " + isItemMagnet);
        Debug.Log("mRadius::" + mRadius + "____mTime::" + mTime);
        //pcMagnet.SetActive(true);
        for (int i = 0; i < Mobjs.Length; i++)
        {
            Mobjs[i].SetActive(false);
        }

        //Debug.Log("pcMagnet Act!!!" + pcMagnet.activeSelf);
        sphereCollider.radius = mRadius;
        StartCoroutine(Deactivate(mTime));
    }

    IEnumerator Deactivate(float mTime)
    {

        yield return new WaitForSeconds(mTime);
        sphereCollider.radius = extendMagnetRadius;
        //if (isItemMagnet == false)
        //{
            //pcMagnet.SetActive(false);
            for (int i = 0; i < Mobjs.Length; i++)
            {
                Mobjs[i].SetActive(false);
            }

        //}

    }
}
