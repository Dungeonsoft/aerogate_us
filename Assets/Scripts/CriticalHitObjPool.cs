using UnityEngine;
using System.Collections;

public class CriticalHitObjPool : MonoBehaviour {

    public GameObject criticalObj;
    public int criticalObjNum;



    // Use this for initialization
    void Start()
    {
        InstantiatePool(criticalObj, criticalObjNum, "CriticalObj");
    }

    void InstantiatePool(GameObject obj, int objNum, string objName)
    {
        for (int i = 0; i < objNum; i++)
        {
            GameObject go = Instantiate(obj) as GameObject;
            go.transform.parent = this.transform;
            go.name = objName + i;
            go.SetActive(false);
        }
    }

    //액티베이션.
    public void CriticalObjActivation(GameObject parentObj)
    {
        int criObjCount = transform.childCount;
        //Debug.Log("CHILD COUNT :: "+criObjCount);
        for (int j = 0; j < criObjCount; j++)
        {
            GameObject criObjGO = transform.GetChild(j).gameObject;
            if (criObjGO.activeSelf == false)
            {
                //Debug.Log("CriticalHit !!! CHILD NUMBER ::" + j);
                criObjGO.SetActive(true);
                criObjGO.transform.localScale = new Vector3(1, 1, 1);
                criObjGO.GetComponent<CriticalHitScript>().Activate(parentObj);
                return;
            }
        }
    }
}
